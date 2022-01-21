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
    public partial class FTransferenciasEnvioRecepcion : Form
    {
        TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;
        TransferenciasProductosCLN _TransferenciasProductosCLN;
        TransferenciasProductosDetalleCLN _TransferenciasProductosDetalleCLN;
        TransferenciasProductosDetalleRecepcionRecepcionCLN _TransferenciasProductosDetalleRecepcionRecepcionCLN;
        TransferenciasProductosEspecificosCLN _TransferenciasProductosEspecificosCLN;
        TransferenciasProductosGastosDetalleCLN _TransferenciasProductosGastosDetalleCLN;
        InventariosProductosCLN _InventariosProductosCLN;

        DSDoblones20GestionComercial2.ListarTransferenciaProductosEnviadosRecepcionadosDataTable DTProductosRecepcionEnvio;
        DataTable DTProductosEspecificos;
        DataSet DSTransferenciasEnvioRecepcion;
        public int NumeroAgencia { get; set; }
        public int NumeroTransferenciaProducto { get; set; }
        public string CodigoTipoEnvioRecepcion { get; set; }
        bool llenadoConfirmadoPE = false;
        Font fuenteDefecto;
        public bool OperacionConfirmada { get; set; }
        bool existeGastos = false;


        public FTransferenciasEnvioRecepcion(int NumeroAgencia, int NumeroTransferencia, string CodigoTipoEnvioRecepcion)
        {
            InitializeComponent();
            this.NumeroAgencia = NumeroAgencia;
            this.NumeroTransferenciaProducto = NumeroTransferencia;
            this.CodigoTipoEnvioRecepcion = CodigoTipoEnvioRecepcion;

            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();
            _TransferenciasProductosDetalleCLN = new TransferenciasProductosDetalleCLN();
            _TransferenciasProductosEspecificosCLN = new TransferenciasProductosEspecificosCLN();
            _TransferenciasProductosGastosDetalleCLN = new TransferenciasProductosGastosDetalleCLN();
            _TransferenciasProductosDetalleRecepcionRecepcionCLN = new TransferenciasProductosDetalleRecepcionRecepcionCLN();
            _InventariosProductosCLN = new InventariosProductosCLN();
            _TransferenciasProductosCLN = new TransferenciasProductosCLN();

            fuenteDefecto = dtGVProductos.Font;

            DSTransferenciasEnvioRecepcion = new DataSet("TransferenciaProductos");
        }

        private void FTransferenciasEnvioRecepcion_Load(object sender, EventArgs e)
        {           

            DGCCodigoProducto.Width = 85;
            DGCNombreProducto.Width = 250;

            DGCCodigoProductoPE.Width = 85;
            DGCNombreProductoPE.Width = 250;

           


            crearTablas();
            dtGVProductos.AutoGenerateColumns = false;
            DTProductosRecepcionEnvio = _TransferenciasProductosDetalleCLN.ListarTransferenciaProductosEnviadosRecepcionados(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEnvioRecepcion, true);
            dtGVProductos.DataSource = DTProductosRecepcionEnvio;   
            dtGVProductosEspecificos.DataSource = DTProductosEspecificos;

            DSTransferenciasEnvioRecepcion.Tables.Add(DTProductosRecepcionEnvio);
            DSTransferenciasEnvioRecepcion.Tables.Add(DTProductosEspecificos);


            DGCCantidadTransferencia.HeaderText = "Cant. Trnasferencia";

            if (CodigoTipoEnvioRecepcion == "R")
            {
            }
            if (CodigoTipoEnvioRecepcion == "E")
            {
                DataColumn DCNuevaCantidad = new DataColumn("NuevaCantidad");
                DCNuevaCantidad.DataType = Type.GetType("System.Int32");
                DCNuevaCantidad.DefaultValue = 0;
                DTProductosRecepcionEnvio.Columns.Add(DCNuevaCantidad);


                DTProductosRecepcionEnvio.Columns["CantidadFaltante"].ReadOnly = true;
                DTProductosRecepcionEnvio.Columns["CantidadFaltante"].Expression = "CantidadCompra - ( CantidadRecepcionada + NuevaCantidad)";
            }


            DTProductosEspecificos.DefaultView.Sort = "CodigoProducto ASC";

            if (CodigoTipoEnvioRecepcion == "R")
            {
                DGCCantidadRecepcionadaEnviada.HeaderText = "Cant. Recepcionada";
                DGCCantidadRecepcionadaEnviada.ToolTipText = "Cantidad de Productos que Fueron Recepcionados hasta la Fecha";
                
                this.Text = "Recepción de Mercadería por Transferencias";
            }
            else if (CodigoTipoEnvioRecepcion == "E")
            {
                DGCCantidadRecepcionadaEnviada.HeaderText = "Cant. Enviada";
                DGCCantidadRecepcionadaEnviada.ToolTipText = "Cantidad de Productos que Fueron Enviados hasta la Fecha";                
                this.Text = "Envió de Mercadería por Transferencias";
            }


        }

        public void crearTablas()
        {
            DTProductosEspecificos = new DataTable("ProductosEspecificos");

            DataColumn DCCodigoProducto = new DataColumn();
            DCCodigoProducto.DataType = Type.GetType("System.String");
            DCCodigoProducto.AllowDBNull = false;
            DCCodigoProducto.Unique = false;
            DCCodigoProducto.DefaultValue = "";
            DCCodigoProducto.ColumnName = "CodigoProducto";

            DataColumn DCNombreProducto = new DataColumn();
            DCNombreProducto.DataType = Type.GetType("System.String");
            DCNombreProducto.AllowDBNull = false;
            DCNombreProducto.Unique = false;
            DCNombreProducto.DefaultValue = "";
            DCNombreProducto.ColumnName = "NombreProducto";

            DataColumn DCCodigoProductoEspecifico = new DataColumn();
            DCCodigoProductoEspecifico.DataType = Type.GetType("System.String");
            DCCodigoProductoEspecifico.AllowDBNull = false;
            DCCodigoProductoEspecifico.Unique = true;
            DCCodigoProductoEspecifico.DefaultValue = "______-1";
            DCCodigoProductoEspecifico.ColumnName = "CodigoProductoEspecifico";

           
            DTProductosEspecificos.Columns.AddRange(new DataColumn[] { DCNombreProducto, DCCodigoProducto,
                    DCCodigoProductoEspecifico});

            DTProductosEspecificos.PrimaryKey = null;
            DataColumn[] PrimaryKeyColumns = new DataColumn[2];
            PrimaryKeyColumns[0] = DTProductosEspecificos.Columns["CodigoProducto"];
            PrimaryKeyColumns[1] = DTProductosEspecificos.Columns["CodigoProductoEspecifico"];
            DTProductosEspecificos.PrimaryKey = PrimaryKeyColumns;
        }

        private void dtGVProductos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int CantidadNuevaDeEntrega;

            this.dtGVProductos.Rows[e.RowIndex].ErrorText = "";

            // No cell validation for new rows. New rows are validated on Row Validation.
            if (this.dtGVProductos.Rows[e.RowIndex].IsNewRow) { return; }

            if (this.dtGVProductos.IsCurrentCellDirty)
            {
                switch (this.dtGVProductos.Columns[e.ColumnIndex].Name)
                {

                    case "DGCNuevaCantidad":
                        if (e.FormattedValue.ToString().Trim().Length < 1)
                        {
                            this.dtGVProductos.Rows[e.RowIndex].ErrorText = "   La Cantidad a entregar es necesaria y no puede estar vacia.";
                            e.Cancel = true;
                        }
                        else if (!int.TryParse(e.FormattedValue.ToString(), out CantidadNuevaDeEntrega) || CantidadNuevaDeEntrega < 0)
                        {
                            this.dtGVProductos.Rows[e.RowIndex].ErrorText = "   La Cantidad a entregar debe ser un entero positivo.";
                            e.Cancel = true;
                        }

                        if (int.TryParse(e.FormattedValue.ToString(), out CantidadNuevaDeEntrega))
                        {
                            int CantidadComprada = int.Parse(this.dtGVProductos.Rows[e.RowIndex].Cells["DGCCantidadTransferencia"].Value.ToString());
                            int CantidadRecepcionada = int.Parse(this.dtGVProductos.Rows[e.RowIndex].Cells["DGCCantidadRecepcionadaEnviada"].Value.ToString());
                            if (CantidadNuevaDeEntrega > (CantidadComprada - CantidadRecepcionada))
                            {
                                this.dtGVProductos.Rows[e.RowIndex].ErrorText = "   No puede entregar una cantidad superior a la Cantidad Requerida de Recepción.";
                                e.Cancel = true;
                            }
                        }
                        break;


                }

            }
        }

        private void dtGVProductos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dtGVProductos.RowCount > 0 && dtGVProductos.CurrentRow != null && e.RowIndex >=0)
            {
                string CodigoProducto = DTProductosRecepcionEnvio.Rows[e.RowIndex]["CodigoProducto"].ToString();
                string NombreProducto = DTProductosRecepcionEnvio.Rows[e.RowIndex]["NombreProducto"].ToString();
                bool EsProductoEspecifico = bool.Parse(DTProductosRecepcionEnvio.Rows[e.RowIndex]["EsProductoEspecifico"].ToString());


                if (e.ColumnIndex == DGCNuevaCantidad.Index)
                {
                    if (EsProductoEspecifico)
                    {
                        
                        object CantidadProductoRegistrado = DTProductosEspecificos.Compute("count(CodigoProducto)", "CodigoProducto = '" + CodigoProducto + "'");
                        int CantidadMaxima = int.Parse(DTProductosRecepcionEnvio.Rows[e.RowIndex]["CantidadTransferencia"].ToString()) - int.Parse(DTProductosRecepcionEnvio.Rows[e.RowIndex]["CantidadRecepcionadaEnviada"].ToString());
                        int CantidadNueva = int.Parse(DTProductosRecepcionEnvio.Rows[e.RowIndex]["NuevaCantidad"].ToString());

                        if (CantidadNueva > CantidadMaxima)
                        {
                            if (MessageBox.Show(this, "No puede Recepcionar una Cantidad que supera a lo especificado dentro de la Transferencia incluyendo ya las partes ingresadas para este Producto"
                                + Environment.NewLine + " ¿Desea que el Sistema actualize a la Cantidad Recomendable Tope de Recepción? "
                                , this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                DTProductosRecepcionEnvio.Rows[e.RowIndex]["NuevaCantidad"] = CantidadMaxima;
                                DTProductosRecepcionEnvio.Rows[e.RowIndex].AcceptChanges();
                                CantidadNueva = CantidadMaxima;
                            }
                            else
                            {
                                DTProductosRecepcionEnvio.Rows[e.RowIndex].RejectChanges();
                                dtGVProductos.CurrentCell = dtGVProductos["DGCNuevaCantidad", e.RowIndex];
                                dtGVProductos.BeginEdit(true);
                                llenadoConfirmadoPE = false;
                            }
                        }

                        if (CantidadProductoRegistrado.Equals(0))
                        {
                            FCompraProductosIngresoEspecificos _FCompraProductosIngresoEspecificos = new FCompraProductosIngresoEspecificos(CodigoProducto, CantidadNueva, NombreProducto);
                            _FCompraProductosIngresoEspecificos.ShowDialog();
                            if (_FCompraProductosIngresoEspecificos.OperacionConfirmada)
                            {
                                int indice = 0;
                                foreach (DataRow FilaNueva in _FCompraProductosIngresoEspecificos.DTProductosEspecificos.Rows)
                                {
                                    DataRow DRNuevoEspecifico = DTProductosEspecificos.NewRow();
                                    if (indice == 0)
                                        DRNuevoEspecifico["NombreProducto"] = NombreProducto;
                                    DRNuevoEspecifico["CodigoProducto"] = CodigoProducto;
                                    DRNuevoEspecifico["CodigoProductoEspecifico"] = FilaNueva["CodigoProductoEspecifico"];                                    

                                    DTProductosEspecificos.Rows.Add(DRNuevoEspecifico);
                                    DRNuevoEspecifico.AcceptChanges();
                                    indice++;

                                }
                                llenadoConfirmadoPE = true;
                            }
                            else
                            {
                                DTProductosRecepcionEnvio.Rows[e.RowIndex].RejectChanges();
                                dtGVProductos.CurrentCell = dtGVProductos["DGCNuevaCantidad", e.RowIndex];
                                dtGVProductos.BeginEdit(true);
                                llenadoConfirmadoPE = false;
                            }
                            //_FCompraProductosIngresoEspecificos.Dispose();
                        }
                        else
                        {
                            FCompraProductosIngresoEspecificos _FCompraProductosIngresoEspecificos = new FCompraProductosIngresoEspecificos(CodigoProducto, CantidadNueva, NombreProducto);
                            DataRow[] DRProductosEspecificosPorProductos = DTProductosEspecificos.Select("CodigoProducto = '" + CodigoProducto + "'");

                            foreach (DataRow DRProductoEspecifico in DRProductosEspecificosPorProductos)
                            {
                                DataRow DRNuevoProductoEspecifico = _FCompraProductosIngresoEspecificos.DTProductosEspecificos.NewRow();
                                DRNuevoProductoEspecifico["CodigoProductoEspecifico"] = DRProductoEspecifico["CodigoProductoEspecifico"];                                

                                _FCompraProductosIngresoEspecificos.DTProductosEspecificos.Rows.Add(DRNuevoProductoEspecifico);
                                DRNuevoProductoEspecifico.AcceptChanges();
                            }



                            int CantidadRegistrada = int.Parse(CantidadProductoRegistrado.ToString());
                            if (CantidadNueva > CantidadRegistrada) // se Adicionan mas Productos
                            {
                                _FCompraProductosIngresoEspecificos.ShowDialog();
                                if (_FCompraProductosIngresoEspecificos.OperacionConfirmada)
                                {
                                    foreach (DataRow DRProductoNuevo in _FCompraProductosIngresoEspecificos.DTProductosEspecificos.Rows)
                                    {
                                        if (DTProductosEspecificos.Rows.Find(new object[] { CodigoProducto, DRProductoNuevo["CodigoProductoEspecifico"] }) == null)
                                        {
                                            DataRow DRNuevoEspecifico = DTProductosEspecificos.NewRow();
                                            DRNuevoEspecifico["CodigoProducto"] = CodigoProducto;
                                            DRNuevoEspecifico["CodigoProductoEspecifico"] = DRProductoNuevo["CodigoProductoEspecifico"];
                                            

                                            DTProductosEspecificos.Rows.Add(DRNuevoEspecifico);
                                            DRNuevoEspecifico.AcceptChanges();
                                        }
                                    }
                                    llenadoConfirmadoPE = true;
                                }
                                else
                                {
                                    DTProductosRecepcionEnvio.Rows[e.RowIndex].RejectChanges();
                                    dtGVProductos.CurrentCell = dtGVProductos["DGCNuevaCantidad", e.RowIndex];
                                    dtGVProductos.BeginEdit(true);
                                    llenadoConfirmadoPE = false;
                                }
                            }
                            else // Cuando disminuyen la cantidad, se debe eliminar codigos especificos
                            {
                                MessageBox.Show("Debe Seleccionar los productos Específicos que desea eliminar");
                                _FCompraProductosIngresoEspecificos.ShowDialog();
                                if (_FCompraProductosIngresoEspecificos.OperacionConfirmada && _FCompraProductosIngresoEspecificos.ListadoProductosEspecificosEliminados.Count > 0)
                                {
                                    foreach (string codEspecifico in _FCompraProductosIngresoEspecificos.ListadoProductosEspecificosEliminados)
                                    {
                                        DataRow DRProductoEliminar = DTProductosEspecificos.Rows.Find(new object[] { CodigoProducto, codEspecifico });
                                        if (DRProductoEliminar != null)
                                            DTProductosEspecificos.Rows[DTProductosEspecificos.Rows.IndexOf(DRProductoEliminar)].Delete();

                                    }
                                    llenadoConfirmadoPE = true;
                                }
                                else
                                {
                                    DTProductosRecepcionEnvio.Rows[e.RowIndex].RejectChanges();
                                    dtGVProductos.CurrentCell = dtGVProductos["DGCNuevaCantidad", e.RowIndex];
                                    dtGVProductos.BeginEdit(true);
                                    llenadoConfirmadoPE = false;
                                }
                            }
                            //_FCompraProductosIngresoEspecificos.Dispose();
                        }
                        DTProductosRecepcionEnvio.AcceptChanges();
                        DTProductosEspecificos.AcceptChanges();
                    }
                }

                //else if (e.ColumnIndex == DGCSeleccionado.Index && EsProductoEspecifico)
                //{
                //    int CantidadProductoRegistrado = int.Parse(DTProductosEspecificos.Compute("count(CodigoProducto)", "CodigoProducto = '" + CodigoProducto + "'").ToString());
                //    int CantidadTransferencia = DTProductosRecepcionEnvio[e.RowIndex].CantidadTransferencia;
                //    if (DTProductosRecepcionEnvio[e.RowIndex].Seleccionado && EsProductoEspecifico)
                //    {
                //        if (CantidadProductoRegistrado > 0 ) // ya estan seleccionados los Productos Especificos
                //        {
                //            MessageBox.Show("Ya ha Seleccionado los Códigos Especificos para este Producto");
                //            return;
                //        }
                //        else // hay que seleccionar los Productos Especificos
                //        {
                //            FTransferenciaProductosRecepcionEnvioPE formTransferenciaProductosRecepcionEnvioPE;
                //            formTransferenciaProductosRecepcionEnvioPE = new FTransferenciaProductosRecepcionEnvioPE(NumeroAgencia, NumeroTransferenciaProducto, CodigoProducto, CodigoTipoEnvioRecepcion, NombreProducto, CantidadTransferencia);
                //            formTransferenciaProductosRecepcionEnvioPE.ShowDialog(this);
                //            if (formTransferenciaProductosRecepcionEnvioPE.OperacionConfirmada)
                //            {
                //                int indice = 0;
                //                foreach (DataRow FilaNueva in formTransferenciaProductosRecepcionEnvioPE.DTProductosEspecificos.Select("Seleccionar = true"))
                //                {
                //                    DataRow DRNuevoEspecifico = DTProductosEspecificos.NewRow();
                //                    if (indice == 0)
                //                        DRNuevoEspecifico["NombreProducto"] = NombreProducto;
                //                    DRNuevoEspecifico["CodigoProducto"] = CodigoProducto;
                //                    DRNuevoEspecifico["CodigoProductoEspecifico"] = FilaNueva["CodigoProductoEspecifico"];

                //                    DTProductosEspecificos.Rows.Add(DRNuevoEspecifico);
                //                    DRNuevoEspecifico.AcceptChanges();
                //                    indice++;

                //                }
                //                llenadoConfirmadoPE = true;
                //            }
                //            else
                //            {
                //                cancelarCambios(e.RowIndex);
                //            }
                //        }

                //    }
                //    else //el check no esta seleccionado
                //    {
                //        if (EsProductoEspecifico && CantidadProductoRegistrado > 0 && MessageBox.Show(this, "Existe Códigos ya Seleccionados para Este Producto. \r\n ¿Está seguro de eliminar su selección?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //        {
                //            foreach (DataRow FilaProductoEspecifico in DTProductosEspecificos.Select("CodigoProducto = '" + CodigoProducto + "'"))
                //            {
                //                FilaProductoEspecifico.Delete();
                //            }
                //            DTProductosEspecificos.AcceptChanges();
                //        }
                //        else
                //        {
                //            cancelarCambios(e.RowIndex);
                //        }
                //    }
                //}
            }
        }

        public void cancelarCambios(int indice)
        {
            DTProductosRecepcionEnvio.Rows[indice].RejectChanges();
            dtGVProductos.CurrentCell = dtGVProductos["DGCSeleccionado", indice];
            dtGVProductos.BeginEdit(true);
            llenadoConfirmadoPE = false;
        }

        private void dtGVProductosEspecificos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DTProductosRecepcionEnvio.Rows.Count > 0)
            {

                if (dtGVProductosEspecificos.Rows[e.RowIndex].Cells[0].Value != null && !dtGVProductosEspecificos.Rows[e.RowIndex].Cells[0].Value.Equals(""))
                {
                    dtGVProductosEspecificos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Bisque;
                    dtGVProductosEspecificos.Rows[e.RowIndex].Cells["DGCNombreProductoPE"].Style.Font = new Font(fuenteDefecto.Name, fuenteDefecto.Size, FontStyle.Bold);
                }
            }
        }



        //private void dtGVProductos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        //{
        //    if (dtGVProductos.IsCurrentCellDirty && dtGVProductos.CurrentCell.ColumnIndex == DGCSeleccionado.Index)
        //    {
        //        dtGVProductos.CommitEdit(DataGridViewDataErrorContexts.Commit);
        //    }
        //}

        private void btnConfirmarTodo_Click(object sender, EventArgs e)
        {            
            //MessageBox.Show(this.DTProductosRecepcionEnvio.DataSet.DataSetName + "  " +  DTProductosRecepcionEnvio.TableName +" " + DTProductosEspecificos);
            

            Button btnSeleccionado = sender as Button;
            string listadoProductos = "";

            if (DTProductosRecepcionEnvio.Compute("sum(NuevaCantidad)", "").ToString().Equals("0"))
            {
                MessageBox.Show(this, "Aún no ha ingresado un cantidad nueva de ingreso para la recepción del listado de productos Actual", "Cantidades Nulas", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            
            String XML = DTProductosRecepcionEnvio.DataSet.GetXml();
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

            foreach (DSDoblones20GestionComercial2.ListarTransferenciaProductosEnviadosRecepcionadosRow DRFilaProducto in DTProductosRecepcionEnvio.Rows)
            {                
                if (DRFilaProducto.NuevaCantidad > 0)
                    listadoProductos += "'" + DRFilaProducto.CodigoProducto.Trim() + "',";
            }
            listadoProductos = listadoProductos.Substring(0, listadoProductos.Length - 1);
                        
            
            DSDoblones20GestionComercial2.ListarTransferenciasProductosDetalleGastosDataTable DTProductosSeleccionados;

            FTransferenciasProductosListadoCalculoGastos _FTransferenciasProductosListadoCalculoGastos = new FTransferenciasProductosListadoCalculoGastos(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEnvioRecepcion, null);
                        
            existeGastos = _TransferenciasProductosGastosDetalleCLN.ExisteGastosParaTransferencia(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEnvioRecepcion);
            if (existeGastos)
            {
                if (rBtnGastosRepartidos.Checked)
                {
                    _FTransferenciasProductosListadoCalculoGastos.formatearParaTransferenciaConGastosRepartidos();
                }
                else if (rBtnPersonalizado.Checked)
                {
                    _FTransferenciasProductosListadoCalculoGastos.formatearParaTransferenciaConGastosPersonalizados();
                }
            }
            else
            {
                _FTransferenciasProductosListadoCalculoGastos.formatearParaTransferenciaSinGastos();
            }
            
            _FTransferenciasProductosListadoCalculoGastos.ShowDialog();

            if (_FTransferenciasProductosListadoCalculoGastos.OperacionConfirmada)
            {
                
                bool aplicarGastos = _FTransferenciasProductosListadoCalculoGastos.ChecUtilizarGastosActuales.Checked;
                try
                {
                    DTProductosSeleccionados = _FTransferenciasProductosListadoCalculoGastos.DTProductosGastosTiposCalculo;
                    DateTime FechaHoraRecepcion = _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor();
                    int CantidadNueva;
                    string CodigoProducto, FilaCodigoProductoOpcion = "";

                    foreach (DataRow DRProducto in DTProductosRecepcionEnvio.Rows) 
                    {
                        //CantidadNueva = int.Parse(DRProducto["NuevaCantidad"].ToString());CantidadTransferencia
                        CantidadNueva = int.Parse(DRProducto["CantidadTransferencia"].ToString());
                        if (CantidadNueva > 0)
                        //if(DRProducto["Seleccionado"].Equals(true))
                        {
                            CodigoProducto = DRProducto["CodigoProducto"].ToString();
                            CLCAD.DSDoblones20GestionComercial2.ListarTransferenciasProductosDetalleGastosRow FilaProductoTipoCalculo = DTProductosSeleccionados.FindByCodigoProducto(CodigoProducto);

                            if (FilaProductoTipoCalculo["ActualizarPrecioVenta"].Equals(true))
                            {
                                FilaCodigoProductoOpcion += CodigoProducto.Trim() + ";" + (FilaProductoTipoCalculo["ActualizarPrecioVenta"].Equals(true) ? "1" : "0") + (FilaProductoTipoCalculo["Promedio"].Equals(true) ? "1" : "0") + (FilaProductoTipoCalculo["UltimaRecepcion"].Equals(true) ? "1" : "0") + "|";
                            }
                            else
                            {
                                FilaCodigoProductoOpcion += CodigoProducto.Trim() + ";" + "000" + "|";
                            }

                            if (CodigoTipoEnvioRecepcion == "R")
                            {
                                if (!existeGastos)
                                {
                                    _InventariosProductosCLN.InsertarInventarioProductosCantidadesComprasHistorial(NumeroAgencia, NumeroTransferenciaProducto, CodigoProducto, FechaHoraRecepcion, CantidadNueva, FilaProductoTipoCalculo.PrecioUnitarioTransferencia);
                                }
                                if (rBtnPersonalizado.Checked && existeGastos && aplicarGastos)
                                {
                                    _InventariosProductosCLN.InsertarInventarioProductosCantidadesComprasHistorial(NumeroAgencia, NumeroTransferenciaProducto, CodigoProducto, FechaHoraRecepcion, CantidadNueva, FilaProductoTipoCalculo.PrecioUnitarioTransferencia + decimal.Parse(FilaProductoTipoCalculo["MontoGastoProducto"].ToString()));
                                }
                                if (rBtnPersonalizado.Checked && existeGastos && !aplicarGastos)
                                {
                                    _InventariosProductosCLN.InsertarInventarioProductosCantidadesComprasHistorial(NumeroAgencia, NumeroTransferenciaProducto, CodigoProducto, FechaHoraRecepcion, CantidadNueva, FilaProductoTipoCalculo.PrecioUnitarioTransferencia);
                                }
                                _TransferenciasProductosDetalleRecepcionRecepcionCLN.InsertarTransferenciaProductoDetalleRecepcion(_TransaccionesUtilidadesCLN.ObtenerNumeroAgenciaEmisoraDeTransferencias(NumeroTransferenciaProducto, NumeroAgencia), NumeroTransferenciaProducto, CodigoProducto, FechaHoraRecepcion, CantidadNueva, CodigoTipoEnvioRecepcion);

                                if (DRProducto["EsProductoEspecifico"].Equals(true))
                                {
                                    foreach (DataRow DRProductoPE in DTProductosEspecificos.Select(" CodigoProducto = '" + CodigoProducto.Trim() + "'"))
                                    {
                                        _TransferenciasProductosEspecificosCLN.ActualizarTransferenciaProductoEspecificoFechaRecepcion(NumeroAgencia, NumeroTransferenciaProducto, CodigoProducto, DRProductoPE["CodigoProductoEspecifico"].ToString(), false, FechaHoraRecepcion, "A");
                                        //_TransferenciasProductosEspecificosCLN.InsertarTransferenciaProductoEspecifico(NumeroAgencia, NumeroTransferenciaProducto, CodigoProducto, DRProductoPE["CodigoProductoEspecifico"].ToString(), true, FechaHoraRecepcion, null);
                                    } 
                                }
                            }
                            else
                            {                                
                                if (DRProducto["EsProductoEspecifico"].Equals(true))
                                {
                                    string CodigoProductoEspecifico;
                                    DataRow[] DRProductosEspecificos = DTProductosEspecificos.Select(" CodigoProducto = '" + CodigoProducto.Trim() + "'");
                                    foreach (DataRow DRProductoPE in DRProductosEspecificos)
                                    {
                                        CodigoProductoEspecifico = DRProductoPE["CodigoProductoEspecifico"].ToString();
                                        _TransferenciasProductosEspecificosCLN.InsertarTransferenciaProductoEspecifico(NumeroAgencia, NumeroTransferenciaProducto, CodigoProducto, CodigoProductoEspecifico, false, null, FechaHoraRecepcion, null);
                                    }                                
                                }

                                _TransferenciasProductosDetalleRecepcionRecepcionCLN.InsertarTransferenciaProductoDetalleRecepcion(NumeroAgencia, NumeroTransferenciaProducto, CodigoProducto, FechaHoraRecepcion, CantidadNueva, CodigoTipoEnvioRecepcion);
                            
                            }

                            
                            if (existeGastos && rBtnPersonalizado.Checked)
                            {
                                _TransferenciasProductosGastosDetalleCLN.ActualizarTransferenciasProductosMontoAdicionalGastos(NumeroAgencia, NumeroTransferenciaProducto, CodigoProducto, CodigoTipoEnvioRecepcion, decimal.Parse(FilaProductoTipoCalculo["MontoGastoProducto"].ToString()));
                            }
                        }
                    }

                    FilaCodigoProductoOpcion = FilaCodigoProductoOpcion.Substring(0, FilaCodigoProductoOpcion.Length - 1);

                    if (existeGastos && aplicarGastos && rBtnGastosRepartidos.Checked )                        
                        _TransferenciasProductosGastosDetalleCLN.ActualizarTransferenciasProductosGastosAdicionalesProrrateados(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEnvioRecepcion, FechaHoraRecepcion);
                    
                    _TransaccionesUtilidadesCLN.ActualizarInventariosTransferenciaProductos(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEnvioRecepcion, CodigoTipoEnvioRecepcion == "R" ? FilaCodigoProductoOpcion : null);

                    //cargar el Reporte
                    cargarReportePorPartes(FechaHoraRecepcion);
                    if (existeGastos && aplicarGastos)
                    {                        
                        _TransferenciasProductosGastosDetalleCLN.ActualizarTransferenciaProductosGastosDetalleGeneral(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEnvioRecepcion);                        
                    }

                    if (btnSeleccionado.Name.CompareTo("btnConfirmarTodo") == 0)
                    {
                        if (CodigoTipoEnvioRecepcion == "R")
                            _TransferenciasProductosCLN.ActualizarCodigoEstadoTransferencia(NumeroAgencia, NumeroTransferenciaProducto, "F", null, CodigoTipoEnvioRecepcion);
                        else if (CodigoTipoEnvioRecepcion == "E")
                            _TransferenciasProductosCLN.ActualizarCodigoEstadoTransferencia(NumeroAgencia, NumeroTransferenciaProducto, "E", null, CodigoTipoEnvioRecepcion);
                    }
                    else
                    {
                        if (DTProductosRecepcionEnvio.Compute("sum(CantidadFaltante)", "").ToString().Equals("0"))
                        {
                            _TransferenciasProductosCLN.ActualizarCodigoEstadoTransferencia(NumeroAgencia, NumeroTransferenciaProducto, "F", null, CodigoTipoEnvioRecepcion);
                        }
                        else
                        {
                            _TransferenciasProductosCLN.ActualizarCodigoEstadoTransferencia(NumeroAgencia, NumeroTransferenciaProducto, "F", null, CodigoTipoEnvioRecepcion);
                        }
                    }


                    MessageBox.Show(this, "Se realizó correctamente la recepción de Productos", "Recepción de Mercadería", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //DTProductosRecepcion = _ComprasProductosDetalleCLN.ListarCompraProductosDetalleEntregados(NumeroAgencia, NumeroCompraProducto, true);
                    DTProductosRecepcionEnvio = _TransferenciasProductosDetalleCLN.ListarTransferenciaProductosEnviadosRecepcionados(NumeroAgencia, NumeroTransferenciaProducto, CodigoTipoEnvioRecepcion, true);
                    DTProductosEspecificos.Clear();                    
                    btnConfirmarTodo.Enabled = false;
                    dtGVProductos.Enabled = false;
                    OperacionConfirmada = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio la siguiente Excepción : \r\n" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("La Operación ha sido Cancelada");
            }
            _FTransferenciasProductosListadoCalculoGastos.Dispose();
        }

        public void cargarReportePorPartes(DateTime FechaHoraRecepcion)
        {
            //DataTable DTCompraProductos = _ComprasProductosCLN.ListarCompraProductoReporte(NumeroAgencia, NumeroCompraProducto);
            //DataTable DTCompraProductosGastos = _ComprasProductosCLN.ListarCompraProductosGastosRecepcionPartesReportes(NumeroAgencia, NumeroCompraProducto, false);
            //DataTable DTCompraProductosRecepcion = _ComprasProductosCLN.ListarProductosRecepcionadosPorFechaReporte(NumeroAgencia, NumeroCompraProducto, FechaHoraRecepcion);

            //FReporteCompraProductosRecepcion _FReporteCompraProductosRecepcion = new FReporteCompraProductosRecepcion(DTCompraProductos, DTCompraProductosRecepcion, DTCompraProductosGastos, false);
            //_FReporteCompraProductosRecepcion.ShowDialog(this);
            //_FReporteCompraProductosRecepcion.Dispose();
        }

        private void FTransferenciasEnvioRecepcion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!OperacionConfirmada && MessageBox.Show(this, "No ha confirmado la Operación Actual. ¿Desea Cancelar la Operación?", "Recepción de Mercadería", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        } 

        private void btnForzar_Click(object sender, EventArgs e)
        {

        }

        private void completarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DSDoblones20GestionComercial2.ListarTransferenciaProductosEnviadosRecepcionadosRow FilaProducto in DTProductosRecepcionEnvio.Rows)
            {                
                dtGVProductos.Rows[DTProductosRecepcionEnvio.Rows.IndexOf(FilaProducto)].Cells["DGCNuevaCantidad"].Value = FilaProducto.CantidadTransferencia - FilaProducto.CantidadRecepcionadaEnviada;
                dtGVProductos.CurrentCell = dtGVProductos["DGCNuevaCantidad", DTProductosRecepcionEnvio.Rows.IndexOf(FilaProducto)];
                if (dtGVProductos.IsCurrentCellDirty)
                {
                    dtGVProductos.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }

            dtGVProductos.ClearSelection();

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (DTProductosRecepcionEnvio.Compute("sum(CantidadFaltante)", "").ToString().Equals("0"))
            {
                completarTodoToolStripMenuItem.Enabled = false;
                deshacerCambiosToolStripMenuItem.Enabled = true;                    
            }
            else
            {
                completarTodoToolStripMenuItem.Enabled = true;
                deshacerCambiosToolStripMenuItem.Enabled = false;
            }
        }

       

        private void deshacerCambiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!completarTodoToolStripMenuItem.Enabled)
            {
                DTProductosRecepcionEnvio.RejectChanges();
            }
        }
    }
}
