using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCAD;
using CLCLN.GestionComercial;
using System.Collections;


namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FTransferenciasProductosRecepcion : Form
    {
        int NumeroAgencia, NumeroTransferenciaProducto, CodigoUsuario;
        DataTable DTProductosRecepcion;
        DataTable DTProductosRecepcionEspecificos;
        DSDoblones20GestionComercial2.ListarTransferenciaProductosEnviadosPorFechaDataTable DTTransferenciasProductosEnviados;
        DSDoblones20GestionComercial2.ListarGastosPorTransferenciasDataTable DTGastosTransferencias;

        TransferenciasProductosCLN _TransferenciasProductosCLN;
        TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;
        TransferenciasProductosDetalleRecepcionRecepcionCLN _TransferenciasProductosDetalleRecepcionRecepcionCLN;
        TransferenciasProductosEspecificosCLN _TransferenciasProductosEspecificosCLN;
        TransferenciasProductosGastosDetalleCLN _TransferenciasProductosGastosDetalleCLN;
        InventariosProductosCLN _InventariosProductosCLN;
        FIngresarCantidad formIngresarCantidad;

        string CodigoTipoEnvioRecepcion = "R";
        public DateTime? FechaEnvio = null;
        Font fuenteDefecto;
        public bool OperacionConfirmada = false;
        bool ExistenGastos = false;
        public FTransferenciasProductosRecepcion(int NumeroAgencia, int NumeroTransferencia, int CodigoUsuario)
        {
            InitializeComponent();

            this.NumeroAgencia = NumeroAgencia;
            this.NumeroTransferenciaProducto = NumeroTransferencia;
            this.CodigoUsuario = CodigoUsuario;

            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();
            _TransferenciasProductosDetalleRecepcionRecepcionCLN = new TransferenciasProductosDetalleRecepcionRecepcionCLN();
            _TransferenciasProductosEspecificosCLN = new TransferenciasProductosEspecificosCLN();
            _TransferenciasProductosGastosDetalleCLN = new TransferenciasProductosGastosDetalleCLN();
            _InventariosProductosCLN = new InventariosProductosCLN();
            _TransferenciasProductosCLN = new TransferenciasProductosCLN();
        }

        public void crearTablas()
        {
            DTProductosRecepcion = new DataTable("ProductosEnviar");
            DataColumn DCCodigoProducto = new DataColumn("CodigoProducto", Type.GetType("System.String"));
            DCCodigoProducto.AllowDBNull = false;
            DCCodigoProducto.Unique = true;
            DataColumn DCNombreProducto = new DataColumn("NombreProducto", Type.GetType("System.String"));
            DataColumn DCCantidadEnvio = new DataColumn("CantidadRecepcion", Type.GetType("System.Int32"));
            DataColumn DCMontoIncrementePrecio = new DataColumn("MontoIncrementoPrecio", Type.GetType("System.Decimal"));
            DataColumn DCCodigoTipoCalculoInventario = new DataColumn("TipoCalculoInventario", Type.GetType("System.String"));
            DataColumn DCActualizarPrecioVenta = new DataColumn("ActualizarPrecioVenta", Type.GetType("System.Boolean"));
            DCActualizarPrecioVenta.DefaultValue = true;
            DataColumn DCPromedio = new DataColumn("Promedio", Type.GetType("System.Boolean"));            
            DataColumn DCUltimaRecepcion = new DataColumn("UltimaRecepcion", Type.GetType("System.Boolean"));
            DTProductosRecepcion.Columns.AddRange(new DataColumn[] { DCCodigoProducto, DCNombreProducto, DCCantidadEnvio, DCMontoIncrementePrecio, DCCodigoTipoCalculoInventario, DCActualizarPrecioVenta, DCPromedio, DCUltimaRecepcion });
            DTProductosRecepcion.PrimaryKey = new DataColumn[] { DCCodigoProducto };

            DTProductosRecepcionEspecificos = new DataTable("ProductosEspecificos");
            DataColumn DCCodigoProductoPE = new DataColumn("CodigoProducto", Type.GetType("System.String"));
            DataColumn DCNombreProducto2 = new DataColumn("NombreProducto", Type.GetType("System.String"));
            DataColumn DCCodigoProductoEspecifico = new DataColumn("CodigoProductoEspecifico", Type.GetType("System.String"));
            DataColumn DCCodigoEstadoRecepcion = new DataColumn("CodigoEstadoRecepcion", Type.GetType("System.String"));
            DataColumn DCSeleccionadoPE = new DataColumn("Seleccionado", Type.GetType("System.Boolean"));
            DTProductosRecepcionEspecificos.Columns.AddRange(new DataColumn[] { DCCodigoProductoPE, DCNombreProducto2, DCCodigoProductoEspecifico, DCCodigoEstadoRecepcion, DCSeleccionadoPE });
            DTProductosRecepcionEspecificos.PrimaryKey = new DataColumn[] { DCCodigoProductoPE, DCCodigoProductoEspecifico };
            DTProductosRecepcionEspecificos.DefaultView.Sort = "CodigoProducto ASC";            


        }

        private void FTransferenciasProductosRecepcion_Load(object sender, EventArgs e)
        {
            formIngresarCantidad = new FIngresarCantidad();
            crearTablas();
            

            dtGVProductosEnviados.AutoGenerateColumns = false;
            dtGVProductosRecepcionEspecificos.AutoGenerateColumns = false;
            dtGVProductosRecepcion.AutoGenerateColumns = false;
            dtGVTransferenciasGastosRecepcion.AutoGenerateColumns = false;           

            DGCCodigoProducto.Width = 70;
            DGCNombreProducto.Width = 300;
            DGCCantidadTransferencia.Width = 80;
            DGCCantidadEnvio.Width = 80;
            DGCPrecioUnitarioTransferencia.Width = 80;
            DGCEsProductoEspecifico.Width = 80;
            DGCSeleccionado.Width = 80;


            DGCCodigoProductoRE.Width = 70;
            DGCNombreProductoRE.Width = 180;
            DGCActualizarPrecioVentaRE.Width = 70;
            DGCUltimaRecepcionRE.Width = 75;
            DGCPromedioRE.Width = 70;


            DGCCodigoProductoPE.Visible = false;
            DGCNombreProductoPE.Width = 230;
            DGCCodigoProductoEspecificoPE.Width = 200;
            DGCSeleccionadoPE.Width = 80;

            //dtGVProductosRecepcionEspecificos.Columns.Remove(DGCCodigoEstadoRecepcionPE);

            DGCCodigoEstadoRecepcionPE.DataSource = TiposEstadosRecepcion.getListadoInsercion();
            DGCCodigoEstadoRecepcionPE.DisplayMember = TiposEstadosRecepcion.DisplayMember;
            DGCCodigoEstadoRecepcionPE.ValueMember = TiposEstadosRecepcion.ValueMember;
            DGCCodigoEstadoRecepcionPE.DataPropertyName = "CodigoEstadoRecepcion";
            dtGVProductosRecepcion.DataSource = DTProductosRecepcion;
            dtGVProductosRecepcionEspecificos.DataSource = DTProductosRecepcionEspecificos;
            //dtGVProductosRecepcionEspecificos.Columns.Add(DGCCodigoEstadoRecepcionPE);

            ExistenGastos = _TransferenciasProductosGastosDetalleCLN.ExisteGastosParaTransferencia(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEnvioRecepcion);
            if (!ExistenGastos)
            {
                checkAplicarGastos.Visible = false;
                gBoxOpcionesCalculoGastos.Visible = false;
                gBoxOpcionesCalculoGastos.Width = 0;
                DGCMontoIncrementoPrecioRE.Visible = false;                    
            }


            dtGVProductosRecepcionEspecificos.CellFormatting += new DataGridViewCellFormattingEventHandler(dtGVProductosEspecificosRecepcion_CellFormatting);
            fuenteDefecto = dtGVProductosRecepcionEspecificos.Font;
            DTGastosTransferencias = _TransferenciasProductosGastosDetalleCLN.ListarGastosPorTransferencias(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEnvioRecepcion);

            if(DTGastosTransferencias.Count > 0)
                txtBoxMontoTotalGasto.Text = txtBoxMontoRestante.Text = DTGastosTransferencias.Compute("sum(MontoPagoGasto)", "").ToString();
        }

        public void dtGVProductosEspecificosRecepcion_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtGVProductosRecepcionEspecificos.Rows.Count > 0)
            {

                if (dtGVProductosRecepcionEspecificos.Rows[e.RowIndex].Cells[DGCNombreProductoPE.Index].Value != null && !dtGVProductosRecepcionEspecificos.Rows[e.RowIndex].Cells[DGCNombreProductoPE.Index].Value.Equals(""))
                {
                    dtGVProductosRecepcionEspecificos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Bisque;
                    dtGVProductosRecepcionEspecificos.Rows[e.RowIndex].Cells["DGCNombreProductoPE"].Style.Font = new Font(fuenteDefecto.Name, 6, FontStyle.Bold);
                }
            }
        }

        private void dtGVProductosEnviados_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (DTTransferenciasProductosEnviados!= null && DTTransferenciasProductosEnviados.Count > 0 && dtGVProductosEnviados.CurrentCell != null)
            {
                if (e.ColumnIndex == DGCSeleccionado.Index)
                {
                    if (dtGVProductosEnviados[e.ColumnIndex, e.RowIndex].Value.Equals(true))
                    {
                        DSDoblones20GestionComercial2.ListarTransferenciaProductosEnviadosPorFechaRow DRProductoEnviado =
                            DTTransferenciasProductosEnviados[e.RowIndex];
                        int CantidadMaximaRecepcion = DRProductoEnviado.CantidadEnvio - DRProductoEnviado.CantidadRecepcionada;
                        formIngresarCantidad.Cantidad = CantidadMaximaRecepcion;
                        formIngresarCantidad.ShowDialog();
                        if (formIngresarCantidad.OperacionConfirmada)
                        {
                            int CantidadIngresada = formIngresarCantidad.Cantidad;                            
                            if (CantidadIngresada > CantidadMaximaRecepcion)
                            {
                                MessageBox.Show(this, "No puede Recepcionar una cantidad superior a la cantidad Enviada de la Agencia que Transfiere los Producots", "Cantidad No valida",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                DTTransferenciasProductosEnviados[e.RowIndex].RejectChanges();
                                dtGVProductosEnviados_CurrentCellDirtyStateChanged(dtGVProductosEnviados, e as EventArgs);
                                return;
                            }
                            else if (CantidadIngresada < CantidadMaximaRecepcion)
                            {
                                MessageBox.Show(this, "Esta Recepcionando una cantidad inferior a la cantidad que fue enviada, indique un motivo por el cual no se puede recepcionar completamente" +
                                    "El Producto " + DRProductoEnviado.NombreProducto + " en el campo Observaciones",
                                    "Recepción no completa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtBoxObservaciones.Focus();
                            }
                            //DCCodigoProducto, DCNombreProducto, DCCantidadEnvio, DCMontoIncrementePrecio, DCCodigoTipoCalculoInventario, DCActualizarPrecioVenta, DCPromedio, DCUltimaRecepcion
                            DTProductosRecepcion.Rows.Add(new object[]{
                                DRProductoEnviado.CodigoProducto, DRProductoEnviado.NombreProducto,CantidadIngresada,
                                0, DRProductoEnviado.TipoCalculoInventario, true, false, false });



                            if (DRProductoEnviado.EsProductoEspecifico)
                            {
                                FTransferenciasProductosEspecificosEnvioRecepcion formTransferenciasProductosEspecificosEnvioRecepcion;
                                formTransferenciasProductosEspecificosEnvioRecepcion = new FTransferenciasProductosEspecificosEnvioRecepcion(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEnvioRecepcion, DRProductoEnviado.CodigoProducto);
                                formTransferenciasProductosEspecificosEnvioRecepcion.FechaHoraEnvio = FechaEnvio;
                                formTransferenciasProductosEspecificosEnvioRecepcion.ShowDialog();
                                if (formTransferenciasProductosEspecificosEnvioRecepcion.OperacionConfirmada)
                                {
                                    if (CantidadIngresada != formTransferenciasProductosEspecificosEnvioRecepcion.getCantidadSeleccionada())
                                    {
                                        MessageBox.Show(this, "No ha Seleccionado la cantidad de Productos Especificos que introdució, corrija sus Datos", "Selección incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        DTTransferenciasProductosEnviados[e.RowIndex].RejectChanges();
                                        DTProductosRecepcion.Rows[e.RowIndex].RejectChanges();
                                        return;
                                    }

                                    int i = 0;
                                    foreach (DSDoblones20GestionComercial2.ListarCodigosEspecificosFaltantesRecepcionRow DRProductoEspecifico
                                        in formTransferenciasProductosEspecificosEnvioRecepcion.DTProductosEspecificosRecpcion.Select("Entregado = true"))
                                    {
                                        //DCCodigoProductoPE, DCNombreProducto2, DCCodigoProductoEspecifico, DCCodigoEstadoRecepcion
                                        DTProductosRecepcionEspecificos.Rows.Add(new object[] { DRProductoEnviado.CodigoProducto, i == 0 ? DRProductoEnviado.NombreProducto : String.Empty, DRProductoEspecifico.CodigoProductoEspecifico, DRProductoEspecifico.Entregado ? "A" : "B", DRProductoEspecifico.Entregado });
                                        i++;
                                    }
                                    DTProductosRecepcion.AcceptChanges();
                                    DTProductosRecepcionEspecificos.AcceptChanges();
                                }
                                else
                                {
                                    MessageBox.Show(this, "No ha Seleccionado los Productos Especificos que recepcionara", "Selección de Produtos Especificos No valida",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    DTTransferenciasProductosEnviados[e.RowIndex].RejectChanges();
                                    dtGVProductosEnviados_CurrentCellDirtyStateChanged(dtGVProductosEnviados, e as EventArgs);
                                    return;
                                }
                            }

                            if (ExistenGastos)
                            {
                                if (rBtnProrrateo.Checked)
                                    calcularProrrateo();
                            }
                        }

                        else
                        {
                            MessageBox.Show(this, "No ha confirmado una cantidad de Recepción", "Operación Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            DTTransferenciasProductosEnviados[e.RowIndex].RejectChanges();

                        }

                    }
                    else // Debemos Eliminar el Producto
                    {
                        DSDoblones20GestionComercial2.ListarTransferenciaProductosEnviadosPorFechaRow DRProductoEnviado =
                            DTTransferenciasProductosEnviados[e.RowIndex];
                        DTProductosRecepcion.Rows.Find(DRProductoEnviado.CodigoProducto).Delete();
                        foreach (DataRow DRProductoEspecifico in DTProductosRecepcionEspecificos.Select("CodigoProducto = '" + DRProductoEnviado.CodigoProducto + "'"))
                        {
                            DRProductoEspecifico.Delete();
                        }
                    }

                }
            }
        }

        private void dtGVProductosEnviados_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtGVProductosEnviados.RowCount > 0 && dtGVProductosEnviados.CurrentCell.ColumnIndex == DGCSeleccionado.Index)
            {
                dtGVProductosEnviados.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void FTransferenciasProductosRecepcion_Shown(object sender, EventArgs e)
        {
            FTransferenciasProductosSeleccionFechasEnvios formFechasEnvios = new FTransferenciasProductosSeleccionFechasEnvios(NumeroAgencia, NumeroTransferenciaProducto);
            formFechasEnvios.ShowDialog();
            if (formFechasEnvios.OperacionConfirmada)
            {
                if (formFechasEnvios.recepcionarTodosEnvios())
                {
                    FechaEnvio = null;
                    btnForzarEnvio.Enabled = true;
                }
                else
                {
                    FechaEnvio = formFechasEnvios.getFechaEnvioSeleccionada();
                    btnForzarEnvio.Enabled = false;
                }

                DTTransferenciasProductosEnviados = _TransferenciasProductosDetalleRecepcionRecepcionCLN.ListarTransferenciaProductosEnviadosPorFecha(NumeroAgencia, NumeroTransferenciaProducto, FechaEnvio);
                DTGastosTransferencias = _TransferenciasProductosGastosDetalleCLN.ListarGastosPorTransferencias(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEnvioRecepcion);


                if (DTTransferenciasProductosEnviados.Count == 0)
                {
                    MessageBox.Show(this, "La Fecha de Envio que selecciono ya ha sido completamente Recepcionada", "Recepcion Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnConfirmar.Enabled = false;
                    btnForzarEnvio.Enabled = false;
                    btnAnadirSelecionarCodPE.Enabled = false;
                }

                dtGVProductosEnviados.DataSource = DTTransferenciasProductosEnviados;
                dtGVTransferenciasGastosRecepcion.DataSource = DTGastosTransferencias;
            }
            else
            {
                MessageBox.Show(this, "No Selecciono una Fecha de Envio para la recepción de sus Productos, No Puede continuar con la Operacion", "Operación cancelada", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }
        }

        private void dtGVProductosRecepcion_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (DTProductosRecepcion!= null && DTProductosRecepcion.Rows.Count> 0 && dtGVProductosRecepcion.CurrentCell != null)
            {
                if (e.ColumnIndex == DGCCantidadRecepcionRE.Index)
                {
                    int NuevaCantidadIngresada = (int)dtGVProductosRecepcion[e.ColumnIndex, e.RowIndex].Value;
                    string CodigoProducto = dtGVProductosRecepcion[DGCCodigoProductoPE.Index, e.RowIndex].Value.ToString();
                    DSDoblones20GestionComercial2.ListarTransferenciaProductosEnviadosPorFechaRow DRProductoEnviado =
                           DTTransferenciasProductosEnviados.FindByCodigoProducto(CodigoProducto);                    
                    if (DRProductoEnviado.EsProductoEspecifico)
                    {
                        FTransferenciasProductosEspecificosEnvioRecepcion _FTransferenciasProductosEspecificosEnvioRecepcion = new FTransferenciasProductosEspecificosEnvioRecepcion(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEnvioRecepcion, CodigoProducto);
                        _FTransferenciasProductosEspecificosEnvioRecepcion.FechaHoraEnvio = FechaEnvio;
                        _FTransferenciasProductosEspecificosEnvioRecepcion.seleccionarNuevamenteProductosActualizados(DTProductosRecepcionEspecificos);
                        _FTransferenciasProductosEspecificosEnvioRecepcion.ShowDialog();
                        
                        if (_FTransferenciasProductosEspecificosEnvioRecepcion.OperacionConfirmada)
                        {
                            if (NuevaCantidadIngresada != _FTransferenciasProductosEspecificosEnvioRecepcion.getCantidadSeleccionada())
                            {
                                MessageBox.Show(this, "No ha Seleccionado la cantidad de Productos Especificos que introdució, corrija sus Datos", "Selección incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                DTProductosRecepcion.Rows[e.RowIndex].RejectChanges();
                                return;
                            }

                            foreach (DataRow DRProductoEspecifico in DTProductosRecepcionEspecificos.Select("CodigoProducto = '" + CodigoProducto + "'"))
                            {
                                DRProductoEspecifico.Delete();
                            }
                            DTProductosRecepcionEspecificos.AcceptChanges();
                            int i = 0;
                            foreach (DSDoblones20GestionComercial2.ListarCodigosEspecificosFaltantesRecepcionRow DRProductoEspecifico
                                in _FTransferenciasProductosEspecificosEnvioRecepcion.DTProductosEspecificosRecpcion.Select("Entregado = true"))
                            {
                                //DCCodigoProductoPE, DCNombreProducto2, DCCodigoProductoEspecifico, DCCodigoEstadoRecepcion
                                DTProductosRecepcionEspecificos.Rows.Add(new object[] { DRProductoEnviado.CodigoProducto, i == 0 ? DRProductoEnviado.NombreProducto : String.Empty, DRProductoEspecifico.CodigoProductoEspecifico, DRProductoEspecifico.Entregado ? "A" : "B", DRProductoEspecifico.Entregado });
                                i++;
                            }

                            //DTProductosRecepcionEspecificos.AcceptChanges();
                        }
                        else
                        {
                            MessageBox.Show(this, "No ha confirmado la selección de Códigos Especificos", "Operación Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            DTProductosRecepcion.Rows[e.RowIndex].RejectChanges();
                        }


                    }

                    if (ExistenGastos)
                    {
                        if (rBtnProrrateo.Checked)
                            calcularProrrateo();
                    }
                }

                if (DTProductosRecepcion.Rows[e.RowIndex]["ActualizarPrecioVenta"].Equals(true))
                {
                    if (e.ColumnIndex == DGCPromedioRE.Index && DTProductosRecepcion.Rows[e.RowIndex]["Promedio"].Equals(true))
                    {
                        DTProductosRecepcion.Rows[e.RowIndex]["UltimaRecepcion"] = false;
                    }

                    else if (e.ColumnIndex == DGCUltimaRecepcionRE.Index && DTProductosRecepcion.Rows[e.RowIndex]["UltimaRecepcion"].Equals(true))
                    {
                        DTProductosRecepcion.Rows[e.RowIndex]["Promedio"] = false;
                    }
                }
                else if (DTProductosRecepcion.Rows[e.RowIndex]["ActualizarPrecioVenta"].Equals(false))
                {
                    DTProductosRecepcion.Rows[e.RowIndex]["Promedio"] = false;
                    DTProductosRecepcion.Rows[e.RowIndex]["UltimaRecepcion"] = false;
                }

                if (e.ColumnIndex == DGCMontoIncrementoPrecioRE.Index)
                {
                    if (ExistenGastos && rBtnPersonalizado.Checked)
                    {
                        decimal MontoTotalUtilizado = decimal.Parse(DTProductosRecepcion.Compute("sum(MontoIncrementoPrecio)", "").ToString());
                        decimal MontoTotalDisponible = decimal.Parse(DTGastosTransferencias.Compute("sum(MontoPagoGasto)", "").ToString());

                        //if (MontoTotalUtilizado > MontoTotalDisponible)
                        //{
                        //    MessageBox.Show(this, "El Monto ingresado es demasiado Alto y supera a la cantidad Disponible de Gastos", "Monto Excesivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    DTProductosEnvioSeleccionados.Rows[e.RowIndex].RejectChanges();
                        //    return;
                        //}

                        txtBoxMontoRestante.Text = (MontoTotalDisponible - MontoTotalUtilizado).ToString();

                    }


                }

            
                
            }
        }

        private void dtGVProductosRecepcion_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtGVProductosRecepcion.RowCount > 0 &&
                (DGCActualizarPrecioVentaRE.Index == dtGVProductosRecepcion.CurrentCell.ColumnIndex                
                || DGCPromedioRE.Index == dtGVProductosRecepcion.CurrentCell.ColumnIndex
                || DGCUltimaRecepcionRE.Index == dtGVProductosRecepcion.CurrentCell.ColumnIndex))
            {
                dtGVProductosRecepcion.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dtGVProductosRecepcion_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int CantidadNuevaDeEntrega;
            decimal MontoIncrementoPrecio = 0;
            this.dtGVProductosRecepcion.Rows[e.RowIndex].ErrorText = "";

            // No cell validation for new rows. New rows are validated on Row Validation.
            if (this.dtGVProductosRecepcion.Rows[e.RowIndex].IsNewRow) { return; }

            if (this.dtGVProductosRecepcion.IsCurrentCellDirty)
            {
                switch (this.dtGVProductosRecepcion.Columns[e.ColumnIndex].Name)
                {

                    case "DGCCantidadRecepcionRE":
                        if (e.FormattedValue.ToString().Trim().Length < 1)
                        {
                            this.dtGVProductosRecepcion.Rows[e.RowIndex].ErrorText = "   La Cantidad a Recepcionar es necesaria y no puede estar vacia.";
                            e.Cancel = true;
                        }
                        else if (!int.TryParse(e.FormattedValue.ToString(), out CantidadNuevaDeEntrega) || CantidadNuevaDeEntrega <= 0)
                        {
                            this.dtGVProductosRecepcion.Rows[e.RowIndex].ErrorText = "   La Cantidad a Recepcionar debe ser un entero positivo.";
                            e.Cancel = true;
                            return;
                        }

                        if (int.TryParse(e.FormattedValue.ToString(), out CantidadNuevaDeEntrega))
                        {
                            string CodigoProducto = DTProductosRecepcion.Rows[e.RowIndex]["CodigoProducto"].ToString();

                            DSDoblones20GestionComercial2.ListarTransferenciaProductosEnviadosPorFechaRow DRProductovalidar =
                                DTTransferenciasProductosEnviados.FindByCodigoProducto(CodigoProducto);
                            int CantidadMaximaRecepcion = DRProductovalidar.CantidadEnvio - DRProductovalidar.CantidadRecepcionada;
                            if (CantidadNuevaDeEntrega > (CantidadMaximaRecepcion))
                            {
                                this.dtGVProductosRecepcion.Rows[e.RowIndex].ErrorText = "   No puede Recepcionar una cantidad superior a la Cantidad de Envio de la Transferencia.";
                                e.Cancel = true;
                            }
                        }
                        break;

                    case "DGCMontoIncrementoPrecioRE": 
                        if (e.FormattedValue.ToString().Trim().Length < 1)
                        {
                            this.dtGVProductosRecepcion.Rows[e.RowIndex].ErrorText = "   El Monto de Incremento es necesario y no puede estar vacio.";
                            e.Cancel = true;
                        }
                        else if (!decimal.TryParse(e.FormattedValue.ToString(), out MontoIncrementoPrecio) || MontoIncrementoPrecio < 0)
                        {
                            this.dtGVProductosRecepcion.Rows[e.RowIndex].ErrorText = "   El Monto de Incremento de Precio de ser un valo positivo.";
                            e.Cancel = true;
                            return;
                        }
                        break;

                }

            }
        }

        private void btnAnadirSelecionarCodPE_Click(object sender, EventArgs e)
        {
            string CodigoProductoEspecifico = txtBoxCodigoProductoEspecifico.Text.Trim();
            if (!String.IsNullOrEmpty(CodigoProductoEspecifico))
            {
                DataRow[] DRProductoEspecifico = DTProductosRecepcionEspecificos.Select("CodigoProductoEspecifico ='" + CodigoProductoEspecifico + "'");
                if (DRProductoEspecifico.Length > 0)
                {
                    int indice = DTProductosRecepcionEspecificos.Rows.IndexOf(DRProductoEspecifico[0]);
                    dtGVProductosRecepcionEspecificos.ClearSelection();
                    dtGVProductosRecepcionEspecificos.FirstDisplayedScrollingRowIndex = indice;
                    dtGVProductosRecepcionEspecificos.CurrentCell = dtGVProductosRecepcionEspecificos["DGCCodigoProductoEspecificoPE", indice];
                }
                else
                {
                    toolTip1.Show("No se encuentra el Codigo Ingresado", txtBoxCodigoProductoEspecifico, 4000);
                }
            }
            else
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtBoxCodigoProductoEspecifico, "Aún no ha ingresado un codigo");
            }
            txtBoxCodigoProductoEspecifico.Focus();
            txtBoxCodigoProductoEspecifico.SelectAll();
            
        }

        private void txtBoxCodigoProductoEspecifico_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxCodigoProductoEspecifico.Text.Length >= 20)
            {
                btnAnadirSelecionarCodPE_Click(btnAnadirSelecionarCodPE, e);
            }
        }

        private void txtBoxCodigoProductoEspecifico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnAnadirSelecionarCodPE_Click(btnAnadirSelecionarCodPE, e as EventArgs);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            OperacionConfirmada = false;
            this.Close();
        }

        private void FTransferenciasProductosRecepcion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!OperacionConfirmada && MessageBox.Show(this, "¿Se encuentra seguro de Cancelar la Recepción de Mercaderia por Transferencias?", "Cancelación de Recepcion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (DTProductosRecepcion.Rows.Count == 0)
            {
                MessageBox.Show(this, "No puede Confirmar la operación debido a que no ha seleccionado ningun Producto para su Recepción", "Confirmación Erronea", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (ExistenGastos && rBtnPersonalizado.Checked && checkAplicarGastos.Checked)
            {
                decimal MontoUtilizadoGasto = decimal.Parse(DTProductosRecepcion.Compute("sum(MontoIncrementoPrecio)", "").ToString());
                decimal MontoTotalGasto = decimal.Parse(DTGastosTransferencias.Compute("sum(MontoPagoGasto)", "").ToString());

                if (MontoUtilizadoGasto != MontoTotalGasto)
                {
                    MessageBox.Show(this, "Las cantidades de los montos de incremento que ingreso para cada Producto aún no han alcanzado el Monto Total Diponible por los Gastos", "Montos no coincidentes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    toolTip1.Show("Personalize su Precio de Incremento", gBoxProductosRecepcion, new Point(gBoxProductosRecepcion.Bounds.Width - 150, gBoxProductosRecepcion.Bounds.Y + 20), 3000);
                    return;
                }
            }

            if (DTTransferenciasProductosEnviados.Select("Seleccionado = true").Length != DTTransferenciasProductosEnviados.Count)
            {
                MessageBox.Show(this, "Aún no ha seleccionado todos los productos para su recepción.", "Recepcion incompleta", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (DTProductosRecepcionEspecificos.Select("CodigoEstadoRecepcion <> 'A'").Length > 0)
            {
                if (MessageBox.Show(this, "Existe Productos que ingresaran en mal estado.\r\n¿Se encuentra seguro de recepcionarlos en ese estado?", "Recepción de Mercaderia en mal Estado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }

            if (FechaEnvio == null )   
            {
                int CantidadTotalEnvio = int.Parse(DTTransferenciasProductosEnviados.Compute("sum(CantidadEnvio)","").ToString());
                int CantidadMaximaRecepcionTotal = int.Parse(DTTransferenciasProductosEnviados.Compute("sum(CantidadRecepcionada)", "").ToString());
                int CantidadRecepcionTotal = int.Parse(DTProductosRecepcion.Compute("sum(CantidadRecepcion)", "").ToString());

                if (CantidadRecepcionTotal < (CantidadTotalEnvio - CantidadMaximaRecepcionTotal))
                {
                    MessageBox.Show(this, "No Puede Confirmar esta Recepcion Total debido a que no esta Recepcionando todos los productos en su totalidad.\r\nSi Desea Continuar de esta manera, debe Forzar la Recepción en este estado",
                        "Error en la Confirmación total", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            if (MessageBox.Show(this, "Esta apunto de Recepcionar los productos seleccionados Enviados por una Transferencia, Los mismos ingresaran a su inventario" +
                "con la configuración actual, sin Opcion de poder modificar posteriormente la Cantidad de Recepción.\r\n¿Se encuentra seguro de su configuración?",
                "Confirmación de configuración de Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            guardarCambiosRecepcionarMercaderia();
            if(_TransferenciasProductosCLN.VerificarPosibilidadFinalizacionTransferencia(NumeroAgencia, NumeroTransferenciaProducto))
                _TransferenciasProductosCLN.ActualizarCodigoEstadoTransferencia(NumeroAgencia, NumeroTransferenciaProducto,"F", null, CodigoTipoEnvioRecepcion);
            _TransaccionesUtilidadesCLN.InsertarAsientosTransacciones(CodigoUsuario,
                                    "Asiento Contable Correspondiente a Numero de Transferencia de Recepcion " + NumeroTransferenciaProducto.ToString(),
                                    "C", NumeroTransferenciaProducto, "R", NumeroAgencia);
        }

        private void btnForzarEnvio_Click(object sender, EventArgs e)
        {
            if (DTTransferenciasProductosEnviados.Select("Seleccionado = true").Length != DTTransferenciasProductosEnviados.Count)
            {
                if (MessageBox.Show(this, "Aún no ha seleccionado todos los productos para su recepción. ¿Se encuentra Seguro de Continuar?", "Recepcion incompleta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }

            if (ExistenGastos && rBtnPersonalizado.Checked && checkAplicarGastos.Checked)
            {
                decimal MontoUtilizadoGasto = decimal.Parse(DTProductosRecepcion.Compute("sum(MontoIncrementoPrecio)", "").ToString());
                decimal MontoTotalGasto = decimal.Parse(DTGastosTransferencias.Compute("sum(MontoPagoGasto)", "").ToString());

                if (MontoUtilizadoGasto != MontoTotalGasto)
                {
                    MessageBox.Show(this, "Las cantidades de los montos de incremento que ingreso para cada Producto aún no han alcanzado el Monto Total Diponible por los Gastos", "Montos no coincidentes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    toolTip1.Show("Personalize su Precio de Incremento", gBoxProductosRecepcion, new Point(gBoxProductosRecepcion.Bounds.Width - 150, gBoxProductosRecepcion.Bounds.Y + 20), 3000);
                    return;
                }
            }

            if (MessageBox.Show(this, "Esta apunto de Recepcionar INCOMPLETAMENTE los productos seleccionados Enviados por una Transferencia, Los mismos ingresaran a su inventario" +
                "con la configuración actual, sin Opcion de poder modificar posteriormente la Cantidad de Recepción.\r\n¿Se encuentra seguro de su configuración?",
                "Confirmación de configuración de Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            

            guardarCambiosRecepcionarMercaderia();
            _TransferenciasProductosCLN.ActualizarCodigoEstadoTransferencia(NumeroAgencia, NumeroTransferenciaProducto, "X", null, CodigoTipoEnvioRecepcion);
            _TransaccionesUtilidadesCLN.InsertarAsientosTransacciones(CodigoUsuario,
                                    "Asiento Contable Correspondiente a Numero de Transferencia de Recepcion " + NumeroTransferenciaProducto.ToString(),
                                    "C", NumeroTransferenciaProducto, "R", NumeroAgencia);
        }

        public void calcularProrrateo()
        {
            if (DTProductosRecepcion.Rows.Count > 0)
            {
                decimal MontoTotalDisponible = decimal.Parse(DTGastosTransferencias.Compute("sum(MontoPagoGasto)", "").ToString());
                int CantidadTotalRecepcion = int.Parse(DTProductosRecepcion.Compute("sum(CantidadRecepcion)", "").ToString());
                decimal MontoIncrementoIndividual = Math.Round((MontoTotalDisponible / CantidadTotalRecepcion), 2);

                foreach (DataRow FilaProducto in DTProductosRecepcion.Rows)
                {
                    FilaProducto["MontoIncrementoPrecio"] = MontoIncrementoIndividual;
                }
                DTProductosRecepcion.AcceptChanges();
            }
        }

        public void calcularPrecioPersonalizadoPorDefecto()
        {
            if (DTProductosRecepcion.Rows.Count > 0)
            {
                decimal MontoTotalDisponible = decimal.Parse(DTGastosTransferencias.Compute("sum(MontoPagoGasto)", "").ToString());
                decimal MontoIncrementoIndividual = Math.Round((MontoTotalDisponible / dtGVProductosRecepcion.RowCount), 2);

                foreach (DataRow FilaProducto in DTProductosRecepcion.Rows)
                {
                    FilaProducto["MontoIncrementoPrecio"] = MontoIncrementoIndividual;
                }
                DTProductosRecepcion.AcceptChanges();
            }
        }
        private void rBtnProrrateo_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnProrrateo.Checked && DTProductosRecepcion.Rows.Count > 0)
            {
                calcularProrrateo();
                DGCMontoIncrementoPrecioRE.ReadOnly = true;
            }
        }

        private void rBtnPersonalizado_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnPersonalizado.Checked && DTProductosRecepcion.Rows.Count > 0)
            {
                calcularPrecioPersonalizadoPorDefecto();
                toolTip1.Show("Personalize su Precio de Incremento", gBoxProductosRecepcion, new Point(gBoxProductosRecepcion.Bounds.Width - 50, gBoxProductosRecepcion.Bounds.Y + 20), 3000);
                DGCMontoIncrementoPrecioRE.ReadOnly = false;
            }

        }

        public void guardarCambiosRecepcionarMercaderia()
        {
            DateTime FechaHoraRecepcion = _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor();
            string FilaCodigoProductoOpcion = "", CodigoProducto;
            int NuevaCantidadIngresada = 0;
            try
            {
                foreach (DataRow DRProductoRecepcion in DTProductosRecepcion.Rows)
                {
                    NuevaCantidadIngresada = (int)DRProductoRecepcion["CantidadRecepcion"];
                    CodigoProducto = DRProductoRecepcion["CodigoProducto"].ToString();
                    DSDoblones20GestionComercial2.ListarTransferenciaProductosEnviadosPorFechaRow DRProductoEnviado =
                           DTTransferenciasProductosEnviados.FindByCodigoProducto(CodigoProducto);
                    /*Registro de la recepcion de Mercaderia*/
                    _TransferenciasProductosDetalleRecepcionRecepcionCLN.InsertarTransferenciaProductoDetalleRecepcion(_TransaccionesUtilidadesCLN.ObtenerNumeroAgenciaEmisoraDeTransferencias(NumeroTransferenciaProducto, NumeroAgencia), NumeroTransferenciaProducto, CodigoProducto, FechaHoraRecepcion, NuevaCantidadIngresada, DRProductoEnviado.CantidadEnvio == NuevaCantidadIngresada ? "R" : "X", FechaEnvio);
                    if (DRProductoEnviado.EsProductoEspecifico)
                    {
                        foreach (DataRow DRProductoEspecifico in DTProductosRecepcionEspecificos.Select("CodigoProducto ='" + CodigoProducto + "'"))
                        {
                            _TransferenciasProductosEspecificosCLN.ActualizarTransferenciaProductoEspecificoFechaRecepcion(NumeroAgencia, NumeroTransferenciaProducto, CodigoProducto, DRProductoEspecifico["CodigoProductoEspecifico"].ToString(), true, FechaHoraRecepcion, DRProductoEspecifico["CodigoEstadoRecepcion"].ToString());
                        }
                    }

                    if (DRProductoRecepcion["ActualizarPrecioVenta"].Equals(true))
                    {
                        FilaCodigoProductoOpcion += CodigoProducto.Trim() + ";" + (DRProductoRecepcion["ActualizarPrecioVenta"].Equals(true) ? "1" : "0") + (DRProductoRecepcion["Promedio"].Equals(true) ? "1" : "0") + (DRProductoRecepcion["UltimaRecepcion"].Equals(true) ? "1" : "0") + "|";
                    }
                    else
                    {
                        FilaCodigoProductoOpcion += CodigoProducto.Trim() + ";" + "000" + "|";
                    }

                    //Actualizamos inventarios
                    if (ExistenGastos)
                    {
                        //Actualizamos los montos adicionales existentes por esta recepcion en el detalle de Transferencia
                        if (rBtnPersonalizado.Checked)
                        {
                            _TransferenciasProductosGastosDetalleCLN.ActualizarTransferenciasProductosMontoAdicionalGastos(NumeroAgencia, NumeroTransferenciaProducto, CodigoProducto, CodigoTipoEnvioRecepcion, decimal.Parse(DRProductoRecepcion["MontoIncrementoPrecio"].ToString()) );
                        }


                        //creamos un historial de recepcion de productos
                        if (rBtnPersonalizado.Checked && checkAplicarGastos.Checked)
                        {
                            _InventariosProductosCLN.InsertarInventarioProductosCantidadesComprasHistorial(NumeroAgencia, NumeroTransferenciaProducto, CodigoProducto, FechaHoraRecepcion, NuevaCantidadIngresada, DRProductoEnviado.PrecioUnitarioTransferencia + decimal.Parse(DRProductoRecepcion["MontoIncrementoPrecio"].ToString()) / NuevaCantidadIngresada);
                        }
                        if (rBtnPersonalizado.Checked && !checkAplicarGastos.Checked)
                        {
                            _InventariosProductosCLN.InsertarInventarioProductosCantidadesComprasHistorial(NumeroAgencia, NumeroTransferenciaProducto, CodigoProducto, FechaHoraRecepcion, NuevaCantidadIngresada, DRProductoEnviado.PrecioUnitarioTransferencia);
                        }
                    }
                    else
                    {
                        _InventariosProductosCLN.InsertarInventarioProductosCantidadesComprasHistorial(NumeroAgencia, NumeroTransferenciaProducto, CodigoProducto, FechaHoraRecepcion, NuevaCantidadIngresada, DRProductoEnviado.PrecioUnitarioTransferencia);
                    }
                }

                FilaCodigoProductoOpcion = FilaCodigoProductoOpcion.Substring(0, FilaCodigoProductoOpcion.Length - 1);

                
                if (ExistenGastos && checkAplicarGastos.Checked && rBtnProrrateo.Checked)
                    _TransferenciasProductosGastosDetalleCLN.ActualizarTransferenciasProductosGastosAdicionalesProrrateados(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEnvioRecepcion, FechaHoraRecepcion);

                //Actualizamos inventarios
                _TransaccionesUtilidadesCLN.ActualizarInventariosTransferenciaProductos(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEnvioRecepcion, FilaCodigoProductoOpcion);

                if (DTProductosRecepcionEspecificos.Select("CodigoEstadoRecepcion <> 'A'").Length > 0)
                {
                    _TransferenciasProductosEspecificosCLN.ActualizarTransferenciaProductoEspecificoRecepcionIncorrecta(NumeroAgencia, NumeroTransferenciaProducto, FechaHoraRecepcion);
                }

                if (ExistenGastos && checkAplicarGastos.Checked)
                {
                    _TransferenciasProductosGastosDetalleCLN.ActualizarTransferenciaProductosGastosDetalleGeneral(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEnvioRecepcion);
                }

                MessageBox.Show(this, "Operación culminada Satisfactoriamente", "Operación Correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OperacionConfirmada = true;
                this.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(this, "No se pudo realizar satisfactoriamente la operación debido a " + es.Message + "\r\nConsulte con su administrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void checkVerCantidadRecepcionada_CheckedChanged(object sender, EventArgs e)
        {
            DGCCantidadRecepcionada.Visible = checkVerCantidadRecepcionada.Checked;
        }

    }

    class TiposEstadosRecepcion
    {
        public string CodigoEstadoRecepcion { get; set; }
        public string NombreDescripcionEstado { get; set; }

        public static string ValueMember
        {
            get { return "CodigoEstadoRecepcion"; }
        }
        public static string DisplayMember
        {
            get { return "NombreDescripcionEstado"; }
        }

        public TiposEstadosRecepcion()
        {
            CodigoEstadoRecepcion = "A";
            NombreDescripcionEstado = "ALTA Y DISPONIBLE";
        }

        public TiposEstadosRecepcion(string CodigoEstadoRecepcion, string NombreDescripcionEstado)
        {
            this.CodigoEstadoRecepcion = CodigoEstadoRecepcion;
            this.NombreDescripcionEstado = NombreDescripcionEstado;
        }

        public static string ObtenerSignificadoCodigo(string CodigoEstadoRecepcion)
        {
            string significado = "";
            return significado;
        }

        public static List<TiposEstadosRecepcion> getListadoInsercion()
        {
            List<TiposEstadosRecepcion> listadoTiposEstadosRecepcion = new List<TiposEstadosRecepcion>();
            listadoTiposEstadosRecepcion.Add(new TiposEstadosRecepcion("A", "BUEN ESTADO"));
            listadoTiposEstadosRecepcion.Add(new TiposEstadosRecepcion("R", "DAÑADO"));
            listadoTiposEstadosRecepcion.Add(new TiposEstadosRecepcion("R", "REPARACION"));
            listadoTiposEstadosRecepcion.Add(new TiposEstadosRecepcion("B", "MAL ESTADO, NO DISPONBLE"));
            return listadoTiposEstadosRecepcion;
        }
        
    }
}
