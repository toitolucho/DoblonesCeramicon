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
namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FTransferenciaProductosEnvio : Form
    {

        TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;
        TransferenciasProductosDetalleCLN _TransferenciasProductosDetalleCLN;
        TransferenciasProductosGastosDetalleCLN _TransferenciasProductosGastosDetalleCLN;
        TransferenciasProductosEspecificosCLN _TransferenciasProductosEspecificosCLN;
        TransferenciasProductosDetalleRecepcionRecepcionCLN _TransferenciasProductosDetalleRecepcionRecepcionCLN;
        TransferenciasProductosCLN _TransferenciasProductosCLN;

        DSDoblones20GestionComercial2.ListarTransferenciaProductosEnviadosRecepcionadosDataTable DTTransferenciaProductosDetalle;
        DSDoblones20GestionComercial2.ListarGastosPorTransferenciasDataTable DTGastosTransferencias;
        DataTable DTProductosEnvioSeleccionados;
        DataTable DTProductosEspecificosSeleccionados;

        int NumeroAgencia;
        int NumeroTransferenciaProducto;
        int CodigoUsuario;
        public string CodigoTipoEnvioRecepcion = "E";
        FIngresarCantidad formIngresarCantidad;
        FTransferenciaProductosRecepcionEnvioPE _FTransferenciaProductosRecepcionEnvioPE;
        Font fuenteDefecto;

        public DateTime FechaHoraRecepcion;
        public bool OperacionConfirmada { get; set; }
        bool ExisteGastosEnvio = false;
        //DataSet DSTransferenciasEnvio;
        public FTransferenciaProductosEnvio(int NumeroAgencia, int NumeroTransferenciaProducto, int CodigoUsuario)
        {
            InitializeComponent();

            this.NumeroAgencia = NumeroAgencia;
            this.NumeroTransferenciaProducto = NumeroTransferenciaProducto;
            this.CodigoUsuario = CodigoUsuario;

            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();
            _TransferenciasProductosDetalleCLN = new TransferenciasProductosDetalleCLN();
            _TransferenciasProductosGastosDetalleCLN = new TransferenciasProductosGastosDetalleCLN();
            _TransferenciasProductosEspecificosCLN = new TransferenciasProductosEspecificosCLN();
            _TransferenciasProductosDetalleRecepcionRecepcionCLN = new TransferenciasProductosDetalleRecepcionRecepcionCLN();
            _TransferenciasProductosCLN = new TransferenciasProductosCLN();
            formIngresarCantidad = new FIngresarCantidad();
            //DSTransferenciasEnvio = new DataSet("TransferenciaProductos");
        }

        private void FTransferenciaProductosEnvio_Load(object sender, EventArgs e)
        {

            dtGVTransferenciaProductosDetalle.CurrentCellDirtyStateChanged += new EventHandler(dtGVTransferenciaProductosDetalle_CurrentCellDirtyStateChanged);

            DTGastosTransferencias = _TransferenciasProductosGastosDetalleCLN.ListarGastosPorTransferencias(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEnvioRecepcion);
            DTTransferenciaProductosDetalle = _TransferenciasProductosDetalleCLN.ListarTransferenciaProductosEnviadosRecepcionados(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEnvioRecepcion, true);

            dtGVGastosDetalle.AutoGenerateColumns = false;
            dtGVProductosEspecificosSeleccionados.AutoGenerateColumns = false;
            dtGVProductosSeleccionados.AutoGenerateColumns = false;
            dtGVTransferenciaProductosDetalle.AutoGenerateColumns = false;


            dtGVTransferenciaProductosDetalle.DataSource = DTTransferenciaProductosDetalle;
            dtGVGastosDetalle.DataSource = DTGastosTransferencias;
            txtMontoTotal.Text = txtMontoDisponible.Text = DTGastosTransferencias.Compute("sum(MontoPagoGasto)", "").ToString();

            txtMontoDisponible.ReadOnly = txtMontoTotal.ReadOnly = true;
            

            DGCNombreProducto.Width = 260;
            DGCNombreProductoPE.Width = 230;
            DGCCodigoProductoPE.Width = 75;
            DGCCodigoProductoEspecifico.Width = 110;

            crearTablas();

            //DSTransferenciasEnvio.Tables.AddRange(new DataTable[] { DTProductosEnvioSeleccionados, DTTransferenciaProductosDetalle, DTProductosEspecificosSeleccionados });
            dtGVProductosEspecificosSeleccionados.DataSource = DTProductosEspecificosSeleccionados;
            dtGVProductosSeleccionados.DataSource = DTProductosEnvioSeleccionados;

            DGCCodigoProductoPE.Visible = false;
            fuenteDefecto = dtGVProductosEspecificosSeleccionados.Font;

            ExisteGastosEnvio = _TransferenciasProductosGastosDetalleCLN.ExisteGastosParaTransferencia(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEnvioRecepcion);
            DGCMontoIncrementoPrecio.ReadOnly = true;

            if (!ExisteGastosEnvio)
            {
                checkAplicarGastos.Visible = false;
                gBoxOpcionesCalculoGastos.Visible = false;
                DGCMontoIncrementoPrecio.Visible = false;
            }
        }

        public void crearTablas()
        {
            DTProductosEnvioSeleccionados = new DataTable("ProductosEnviar");
            DataColumn DCCodigoProducto = new DataColumn("CodigoProducto", Type.GetType("System.String"));
            DCCodigoProducto.AllowDBNull = false;
            DCCodigoProducto.Unique = true;
            DataColumn DCNombreProducto = new DataColumn("NombreProducto", Type.GetType("System.String"));
            DataColumn DCCantidadEnvio = new DataColumn("CantidadEnvio", Type.GetType("System.Int32"));
            DataColumn DCMontoIncrementePrecio = new DataColumn("MontoIncrementoPrecio", Type.GetType("System.Decimal"));
            DTProductosEnvioSeleccionados.Columns.AddRange(new DataColumn[] { DCCodigoProducto, DCNombreProducto, DCCantidadEnvio, DCMontoIncrementePrecio});
            DTProductosEnvioSeleccionados.PrimaryKey = new DataColumn[] { DCCodigoProducto};

            DTProductosEspecificosSeleccionados = new DataTable("ProductosEspecificos");
            DataColumn DCCodigoProductoPE = new DataColumn("CodigoProducto", Type.GetType("System.String"));            
            DataColumn DCNombreProducto2 = new DataColumn("NombreProducto", Type.GetType("System.String"));
            DataColumn DCCodigoProductoEspecifico = new DataColumn("CodigoProductoEspecifico", Type.GetType("System.String"));
            DTProductosEspecificosSeleccionados.Columns.AddRange(new DataColumn[] { DCCodigoProductoPE, DCNombreProducto2, DCCodigoProductoEspecifico });
            DTProductosEspecificosSeleccionados.PrimaryKey = new DataColumn[]{DCCodigoProductoPE, DCCodigoProductoEspecifico};
            DTProductosEspecificosSeleccionados.DefaultView.Sort = "CodigoProducto ASC";

        }

        private void dtGVTransferenciaProductosDetalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(dtGVTransferenciaProductosDetalle.RowCount > 0 && dtGVTransferenciaProductosDetalle.CurrentCell != null)
            {
                if (e.ColumnIndex == DGCSeleccionado.Index)
                {
                    string CodigoProducto ="", NombreProducto ="";
                    int CantidadEnvio = 0, CantidadMaximaEnvio = 0;
                    
                    CodigoProducto = DTTransferenciaProductosDetalle[e.RowIndex].CodigoProducto;
                    NombreProducto = DTTransferenciaProductosDetalle[e.RowIndex].NombreProducto;
                    CantidadMaximaEnvio = DTTransferenciaProductosDetalle[e.RowIndex].CantidadTransferencia - DTTransferenciaProductosDetalle[e.RowIndex].CantidadRecepcionadaEnviada;

                    //Agrega el producto a la Lista de Productos de Envio
                    if (dtGVTransferenciaProductosDetalle[e.ColumnIndex, e.RowIndex].Value.Equals(true))
                    {
                        formIngresarCantidad.Cantidad = CantidadMaximaEnvio;
                        formIngresarCantidad.ShowDialog();
                        if (formIngresarCantidad.OperacionConfirmada)
                        {
                            CantidadEnvio = formIngresarCantidad.Cantidad;
                            if (CantidadEnvio > CantidadMaximaEnvio)
                            {
                                MessageBox.Show(this,"La cantida de Envio supera la Cantidad de Transferencia Disponible de Envio", "Cantidad no Valida", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                DTTransferenciaProductosDetalle[e.RowIndex].RejectChanges();
                                return;
                            }                            

                            if (DTProductosEnvioSeleccionados.Rows.Find(CodigoProducto) == null)
                            {
                                if (DTTransferenciaProductosDetalle[e.RowIndex].EsProductoEspecifico)
                                {
                                    _FTransferenciaProductosRecepcionEnvioPE = new FTransferenciaProductosRecepcionEnvioPE(NumeroAgencia, NumeroTransferenciaProducto, CodigoProducto, CodigoTipoEnvioRecepcion, NombreProducto, CantidadEnvio);
                                    _FTransferenciaProductosRecepcionEnvioPE.ShowDialog();
                                    if (!_FTransferenciaProductosRecepcionEnvioPE.OperacionConfirmada)
                                    {
                                        DTTransferenciaProductosDetalle[e.RowIndex].RejectChanges();
                                        return;

                                    }
                                    else
                                    {
                                        int i = 0;
                                        foreach (DSDoblones20GestionComercial2.ListarCodigosProductosEspecificosTransferenciasRow FilaEspecifico
                                            in (DSDoblones20GestionComercial2.ListarCodigosProductosEspecificosTransferenciasRow[])
                                            _FTransferenciaProductosRecepcionEnvioPE.DTProductosEspecificos.Select("Seleccionar = true"))
                                        {
                                            DTProductosEspecificosSeleccionados.Rows.Add(new object[] { CodigoProducto, ((i == 0) ? NombreProducto : String.Empty), FilaEspecifico.CodigoProductoEspecifico });
                                            i++;
                                        }
                                        DTProductosEspecificosSeleccionados.AcceptChanges();
                                    }

                                }

                                DTProductosEnvioSeleccionados.Rows.Add(new object[] { CodigoProducto, NombreProducto, CantidadEnvio, 0});
                                DTProductosEnvioSeleccionados.AcceptChanges();

                                DTTransferenciaProductosDetalle[e.RowIndex].NuevaCantidad = CantidadEnvio;
                                if (ExisteGastosEnvio)
                                {                                    
                                    if (rBtnProrrateo.Checked)
                                        calcularProrrateo();
                                }
                            }
                        }
                        else
                        {
                            DTTransferenciaProductosDetalle[e.RowIndex].RejectChanges();
                        }

                    }
                    else//quitar de la lista
                    {
                        DataRow DRProductosEliminar = DTProductosEnvioSeleccionados.Rows.Find(CodigoProducto);
                        if(DRProductosEliminar != null)
                        {
                            //if (MessageBox.Show(this, "¿Esta seguro de Cancelar el Envio del Producto " + NombreProducto + "?", "Elimiar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            //{
                            //    //DTTransferenciaProductosDetalle[e.RowIndex].RejectChanges();
                            //    dtGVTransferenciaProductosDetalle[e.ColumnIndex, e.RowIndex].Value = true;
                            //    return;
                            //}
                            DataRow[] DRProductosEspecificosEliminar = DTProductosEspecificosSeleccionados.Select("CodigoProducto = '" + CodigoProducto + "'");
                            if (DRProductosEspecificosEliminar != null)
                                foreach (DataRow DRProductoEspecifico in DRProductosEspecificosEliminar)
                                    DRProductoEspecifico.Delete();
                            DRProductosEliminar.Delete();

                            DTProductosEspecificosSeleccionados.AcceptChanges();
                            DTProductosEnvioSeleccionados.AcceptChanges();
                        }

                        if (ExisteGastosEnvio)
                        {                            
                            if (rBtnProrrateo.Checked)
                                calcularProrrateo();
                        }
                    }
                }

                
            }
        }
        void dtGVTransferenciaProductosDetalle_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtGVTransferenciaProductosDetalle.IsCurrentCellDirty && dtGVTransferenciaProductosDetalle.CurrentCell.ColumnIndex == DGCSeleccionado.Index)
            {
                dtGVTransferenciaProductosDetalle.CommitEdit(DataGridViewDataErrorContexts.Commit);
            } 
        }

        private void dtGVProductosEspecificosSeleccionados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DTProductosEspecificosSeleccionados.Rows.Count > 0)
            {

                if (dtGVProductosEspecificosSeleccionados.Rows[e.RowIndex].Cells[DGCNombreProductoPE.Index].Value != null && !dtGVProductosEspecificosSeleccionados.Rows[e.RowIndex].Cells[DGCNombreProductoPE.Index].Value.Equals(""))
                {
                    dtGVProductosEspecificosSeleccionados.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Bisque;
                    dtGVProductosEspecificosSeleccionados.Rows[e.RowIndex].Cells["DGCNombreProductoPE"].Style.Font = new Font(fuenteDefecto.Name, fuenteDefecto.Size, FontStyle.Bold);
                }
            }
        }

        private void dtGVProductosSeleccionados_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dtGVProductosSeleccionados.RowCount > 0 && dtGVProductosSeleccionados.CurrentCell != null)
            {
                if (e.ColumnIndex == DGCCantidadEnvio.Index)
                {
                    int NuevaCantidadEnvio = (int)dtGVProductosSeleccionados[e.ColumnIndex, e.RowIndex].Value;
                    string CodigoProducto = DTProductosEnvioSeleccionados.Rows[e.RowIndex]["CodigoProducto"].ToString();
                    DSDoblones20GestionComercial2.ListarTransferenciaProductosEnviadosRecepcionadosRow DRProductoSeleccionado
                        = DTTransferenciaProductosDetalle.FindByCodigoProducto(CodigoProducto);

                    int CantidadAnterior = int.Parse(DTProductosEspecificosSeleccionados.Compute("count(CodigoProducto)", "CodigoProducto = '" + CodigoProducto + "'").ToString());
                    if (DRProductoSeleccionado.EsProductoEspecifico)
                    {
                        _FTransferenciaProductosRecepcionEnvioPE = new FTransferenciaProductosRecepcionEnvioPE(NumeroAgencia, NumeroTransferenciaProducto, CodigoProducto, CodigoTipoEnvioRecepcion, DRProductoSeleccionado.NombreProducto, NuevaCantidadEnvio);
                        _FTransferenciaProductosRecepcionEnvioPE.DTProductosEspecificosSeleccionados = DTProductosEspecificosSeleccionados;
                        _FTransferenciaProductosRecepcionEnvioPE.ShowDialog(this);
                        if (_FTransferenciaProductosRecepcionEnvioPE.OperacionConfirmada)
                        {
                            foreach (DataRow DRCodigoEspecificoAntiguo in DTProductosEspecificosSeleccionados.Select("CodigoProducto ='" + CodigoProducto + "'"))
                            {
                                DRCodigoEspecificoAntiguo.Delete();
                            }
                            DTProductosEspecificosSeleccionados.AcceptChanges();

                            int indice = 0;
                            foreach (DataRow DRCodigoEspecificoNuevo in _FTransferenciaProductosRecepcionEnvioPE.DTProductosEspecificos.Select("Seleccionar = true"))
                            {
                                DTProductosEspecificosSeleccionados.Rows.Add(new object[] { CodigoProducto, (indice == 0 ? DRProductoSeleccionado.NombreProducto : String.Empty), DRCodigoEspecificoNuevo["CodigoProductoEspecifico"] });
                                indice++;
                            }

                            DTProductosEspecificosSeleccionados.AcceptChanges();

                            DRProductoSeleccionado.NuevaCantidad = NuevaCantidadEnvio;
                            DRProductoSeleccionado.AcceptChanges();
                        }
                        else
                        {
                            DTProductosEnvioSeleccionados.Rows[e.RowIndex].RejectChanges();
                        }
                    }

                    if (ExisteGastosEnvio)
                    {                        
                        if (rBtnProrrateo.Checked)
                            calcularProrrateo();
                    }
                }

                //Para el Monto de Incremento del Precio de Envio para el Producto
                if(e.ColumnIndex == DGCMontoIncrementoPrecio.Index )
                {
                    if (ExisteGastosEnvio && rBtnPersonalizado.Checked)
                    {                        
                        decimal MontoTotalUtilizado = decimal.Parse(DTProductosEnvioSeleccionados.Compute("sum(MontoIncrementoPrecio)", "").ToString());
                        decimal MontoTotalDisponible = decimal.Parse(DTGastosTransferencias.Compute("sum(MontoPagoGasto)", "").ToString());

                        if (MontoTotalUtilizado > MontoTotalDisponible)
                        {
                            MessageBox.Show(this, "El Monto ingresado es demasiado Alto y supera a la cantidad Disponible de Gastos", "Monto Excesivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DTProductosEnvioSeleccionados.Rows[e.RowIndex].RejectChanges();
                            return;
                        }

                        txtMontoDisponible.Text = (MontoTotalDisponible - MontoTotalUtilizado).ToString();

                    }


                }
            }
        }

        private void dtGVProductosSeleccionados_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int CantidadNuevaDeEntrega;
            decimal MontoIncrementoPrecio = 0;
            this.dtGVProductosSeleccionados.Rows[e.RowIndex].ErrorText = "";

            // No cell validation for new rows. New rows are validated on Row Validation.
            if (this.dtGVProductosSeleccionados.Rows[e.RowIndex].IsNewRow) { return; }

            if (this.dtGVProductosSeleccionados.IsCurrentCellDirty)
            {
                switch (this.dtGVProductosSeleccionados.Columns[e.ColumnIndex].Name)
                {

                    case "DGCCantidadEnvio":
                        if (e.FormattedValue.ToString().Trim().Length < 1)
                        {
                            this.dtGVProductosSeleccionados.Rows[e.RowIndex].ErrorText = "   La Cantidad a entregar es necesaria y no puede estar vacia.";
                            e.Cancel = true;
                        }
                        else if (!int.TryParse(e.FormattedValue.ToString(), out CantidadNuevaDeEntrega) || CantidadNuevaDeEntrega <= 0)
                        {
                            this.dtGVProductosSeleccionados.Rows[e.RowIndex].ErrorText = "   La Cantidad a entregar debe ser un entero positivo.";
                            e.Cancel = true;
                            return;
                        }

                        if (int.TryParse(e.FormattedValue.ToString(), out CantidadNuevaDeEntrega))
                        {
                            string CodigoProducto = DTProductosEnvioSeleccionados.Rows[e.RowIndex]["CodigoProducto"].ToString();
                            DSDoblones20GestionComercial2.ListarTransferenciaProductosEnviadosRecepcionadosRow DRProductovalidar =                                
                                DTTransferenciaProductosDetalle.FindByCodigoProducto(CodigoProducto);

                            if (CantidadNuevaDeEntrega > (DRProductovalidar.CantidadTransferencia - DRProductovalidar.CantidadRecepcionadaEnviada))
                            {
                                this.dtGVProductosSeleccionados.Rows[e.RowIndex].ErrorText = "   No puede entregar una cantidad superior a la Cantidad Requerida de Envio de la Transferencia.";
                                e.Cancel = true;
                            }
                        }
                        break;

                    case "DGCMontoIncrementoPrecio":
                        if (e.FormattedValue.ToString().Trim().Length < 1)
                        {
                            this.dtGVProductosSeleccionados.Rows[e.RowIndex].ErrorText = "   El Monto de Incremento es necesario y no puede estar vacio.";
                            e.Cancel = true;
                        }
                        else if (!decimal.TryParse(e.FormattedValue.ToString(), out MontoIncrementoPrecio) || MontoIncrementoPrecio < 0)
                        {
                            this.dtGVProductosSeleccionados.Rows[e.RowIndex].ErrorText = "   El Monto de Incremento de Precio de ser un valo positivo.";
                            e.Cancel = true;
                            return;
                        }
                            break;
                        
                }

            }
        }

        private void checkAplicarGastos_CheckedChanged(object sender, EventArgs e)
        {
            gBoxOpcionesCalculoGastos.Enabled = checkAplicarGastos.Checked;
            DGCMontoIncrementoPrecio.Visible = checkAplicarGastos.Checked;
        }


        public void calcularProrrateo()
        {
            if (DTProductosEnvioSeleccionados.Rows.Count > 0)
            {
                decimal MontoTotalDisponible = decimal.Parse(DTGastosTransferencias.Compute("sum(MontoPagoGasto)", "").ToString());
                int CantidadTotalEnvio = int.Parse(DTProductosEnvioSeleccionados.Compute("sum(CantidadEnvio)", "").ToString());
                decimal MontoIncrementoIndividual = Math.Round((MontoTotalDisponible / CantidadTotalEnvio), 2);

                foreach (DataRow FilaProducto in DTProductosEnvioSeleccionados.Rows)
                {
                    FilaProducto["MontoIncrementoPrecio"] = MontoIncrementoIndividual;
                }
                DTProductosEnvioSeleccionados.AcceptChanges();
            }
        }

        public void calcularPrecioPersonalizadoPorDefecto()
        {
            if (DTProductosEnvioSeleccionados.Rows.Count > 0)
            {
                decimal MontoTotalDisponible = decimal.Parse(DTGastosTransferencias.Compute("sum(MontoPagoGasto)", "").ToString());
                decimal MontoIncrementoIndividual = Math.Round((MontoTotalDisponible / dtGVProductosSeleccionados.RowCount), 2);

                foreach (DataRow FilaProducto in DTProductosEnvioSeleccionados.Rows)
                {
                    FilaProducto["MontoIncrementoPrecio"] = MontoIncrementoIndividual;
                }
                DTProductosEnvioSeleccionados.AcceptChanges();
            }
        }

        private void rBtnProrrateo_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnProrrateo.Checked && DTProductosEnvioSeleccionados.Rows.Count > 0)
            {
                calcularProrrateo();
                DGCMontoIncrementoPrecio.ReadOnly = true;
            }
        }

        private void rBtnPersonalizado_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnPersonalizado.Checked && dtGVProductosSeleccionados.RowCount > 0)
            {
                calcularPrecioPersonalizadoPorDefecto();
                toolTip1.Show("Personalize su Precio de Incremento", gBoxProductosEnviar, new Point(gBoxProductosEnviar.Bounds.Width - 50 , gBoxProductosEnviar.Bounds.Y + 20), 3000);
                DGCMontoIncrementoPrecio.ReadOnly = false;
            }
            

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Esta Seguro de cancelar la operación Actual", "Cancelación de Accion actual", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                OperacionConfirmada = false;
                this.Close();
            }
        }

        private void FTransferenciaProductosEnvio_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!OperacionConfirmada && MessageBox.Show(this, "¿Esta Seguro de cancelar la operación Actual", "Cancelación de Accion actual", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (DTProductosEnvioSeleccionados.Rows.Count == 0)
            {
                MessageBox.Show(this, "Aún no ha seleccionado ningún Producto a ser Enviado", "Selección no Completa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ExisteGastosEnvio && rBtnPersonalizado.Checked && checkAplicarGastos.Checked)
            {
                decimal MontoUtilizadoGasto = decimal.Parse(DTProductosEnvioSeleccionados.Compute("sum(MontoIncrementoPrecio)", "").ToString());
                decimal MontoTotalGasto = decimal.Parse(DTGastosTransferencias.Compute("sum(MontoPagoGasto)", "").ToString());

                if (MontoUtilizadoGasto != MontoTotalGasto)
                {
                    MessageBox.Show(this, "Las cantidades de los montos de incremento que ingreso para cada Producto aún no han alcanzado el Monto Total Diponible por los Gastos", "Montos no coincidentes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    toolTip1.Show("Personalize su Precio de Incremento", gBoxProductosEnviar, new Point(gBoxProductosEnviar.Bounds.Width - 50, gBoxProductosEnviar.Bounds.Y + 20), 3000);
                    return;
                }
            }

            DataTable DTTemporal = DTTransferenciaProductosDetalle.Copy();
            DTTemporal.Constraints.Clear();
            DTTemporal.Columns.Remove(DTTemporal.Columns["NombreProducto"]);
            DataSet DSTemporal = new DataSet("TransferenciaProductos");
            DSTemporal.Tables.Add(DTTemporal);

            //String XML = DTTransferenciaProductosDetalle.DataSet.GetXml();
            String XML = DTTemporal.DataSet.GetXml();
            try
            {
                string DetalleProductosTexto = _TransaccionesUtilidadesCLN.EsPosibleEnviarTransferencia(NumeroAgencia, XML);
                if (!String.IsNullOrEmpty(DetalleProductosTexto))
                {
                    MessageBox.Show(this, "No puede confirmar esta Transferencia debido a que no existe la cantidad suficiente para enviar los productos Requeridos"
                        + "\r\nListado de Productos:\r\n"
                        + DetalleProductosTexto, "Cantidad insuficiente en inventarios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No puede continuar con la operación");
                return;
            }

            if (MessageBox.Show(this, "¿Se encuentra seguro de continuar con los cambios realizados para enviar esta Transferencia?", "Confirmación de Transfernecia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            DTTransferenciaProductosDetalle.AcceptChanges();
            FechaHoraRecepcion = _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor();

            string CodigoProducto = String.Empty; int CantidadNueva = 0;
            foreach (DataRow DRProducto in DTProductosEnvioSeleccionados.Rows)
            {
                CodigoProducto = DRProducto["CodigoProducto"].ToString();
                CantidadNueva = (int)DRProducto["CantidadEnvio"]; 
                if (DTTransferenciaProductosDetalle.FindByCodigoProducto(CodigoProducto).EsProductoEspecifico)                {
                    
                    string CodigoProductoEspecifico;
                    DataRow[] DRProductosEspecificos = DTProductosEspecificosSeleccionados.Select(" CodigoProducto = '" + CodigoProducto.Trim() + "'");
                    foreach (DataRow DRProductoPE in DRProductosEspecificos)
                    {
                        CodigoProductoEspecifico = DRProductoPE["CodigoProductoEspecifico"].ToString();
                        _TransferenciasProductosEspecificosCLN.InsertarTransferenciaProductoEspecifico(NumeroAgencia, NumeroTransferenciaProducto, CodigoProducto, CodigoProductoEspecifico, false, null, FechaHoraRecepcion, null);
                    }
                }
                _TransferenciasProductosDetalleRecepcionRecepcionCLN.InsertarTransferenciaProductoDetalleRecepcion(NumeroAgencia, NumeroTransferenciaProducto, CodigoProducto, FechaHoraRecepcion, CantidadNueva, CodigoTipoEnvioRecepcion);                

                if (ExisteGastosEnvio && checkAplicarGastos.Checked && rBtnPersonalizado.Checked)
                {                    
                    _TransferenciasProductosGastosDetalleCLN.ActualizarTransferenciasProductosMontoAdicionalGastos(NumeroAgencia, NumeroTransferenciaProducto, CodigoProducto, CodigoTipoEnvioRecepcion, decimal.Parse(DRProducto["MontoIncrementoPrecio"].ToString()) );
                }
            }

            if (ExisteGastosEnvio && checkAplicarGastos.Checked && rBtnProrrateo.Checked)
                _TransferenciasProductosGastosDetalleCLN.ActualizarTransferenciasProductosGastosAdicionalesProrrateados(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEnvioRecepcion, FechaHoraRecepcion);
            //ACTUALIZAMOS INVENTARIOS
            _TransaccionesUtilidadesCLN.ActualizarInventariosTransferenciaProductos(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEnvioRecepcion, null);

            //aCTUALIZAMOS Y CAMBIAMOS LOS GASTOS DE TRANSFERENCIAS A UN ESTADO EN EL CUAL YA FUERON APLICADOS
            if (ExisteGastosEnvio && checkAplicarGastos.Checked)
            {
                _TransferenciasProductosGastosDetalleCLN.ActualizarTransferenciaProductosGastosDetalleGeneral(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEnvioRecepcion);
            }


            if ((sender as Button).Name.CompareTo(btnConfirmar.Name) == 0)
            {
                if (DTTransferenciaProductosDetalle.Compute("sum(CantidadFaltante)", "").ToString().Equals("0"))
                {// LA TRANSFERENCIA HA SIDO REALIZADO EN SU TOTALIDAD
                    _TransferenciasProductosCLN.ActualizarCodigoEstadoTransferencia(NumeroAgencia, NumeroTransferenciaProducto, "E", null, CodigoTipoEnvioRecepcion);
                    _TransaccionesUtilidadesCLN.InsertarAsientosTransacciones(CodigoUsuario,
                                    "Asiento Contable Correspondiente a Numero de Transferencia de Envio " + NumeroTransferenciaProducto.ToString(),
                                    "C", NumeroTransferenciaProducto, "T", NumeroAgencia);
                }
                else
                {//LA TRANSFERENCIAS ES POR PARTES Y SE HA ENVIADO UN ENVIO PARCIAL
                    _TransferenciasProductosCLN.ActualizarCodigoEstadoTransferencia(NumeroAgencia, NumeroTransferenciaProducto, "D", null, CodigoTipoEnvioRecepcion);
                }
            }
            else // El Boton ForzarEnvioIncompleto fue el que se Activo
            {
                _TransferenciasProductosCLN.ActualizarCodigoEstadoTransferencia(NumeroAgencia, NumeroTransferenciaProducto, "E", null, CodigoTipoEnvioRecepcion);
                _TransaccionesUtilidadesCLN.InsertarAsientosTransacciones(CodigoUsuario,
                                    "Asiento Contable Correspondiente a Numero de Transferencia de Envio " + NumeroTransferenciaProducto.ToString(),
                                    "C", NumeroTransferenciaProducto, "T", NumeroAgencia);
            }

            MessageBox.Show(this, "Operación Realizada Correctamente", "Operacion Satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
            OperacionConfirmada = true;
            this.Close();
        }

        private void btnForzarEnvio_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Esta apunto de Confirmar toda una Transferencia, cuyos productos no seran enviados en su Totalidad.\r\n¿Se encuentra Seguro de Continuar?", "Forzar Envio Total Incompleto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            btnConfirmar_Click(btnForzarEnvio, e);
        }

    }
}
