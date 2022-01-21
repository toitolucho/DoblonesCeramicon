 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN;
using WFADoblones20.Utilitarios;
using System.Data.SqlClient;
using System.Collections;
using CLCLN.GestionComercial;
using CLCLN.Sistema;
using WFADoblones20.ReportesGestionComercial;
using CLCAD;
namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FVentasProductos2 : Form
    {
        int NumeroAgencia, NumeroPC, CodigoUsuario, NumeroVentaProducto;
        DSDoblones20GestionComercial.ListarVentasProductosDetalleParaVentaDataTable DTVentasProductosDetalle;
        DSDoblones20GestionComercial.VentasProductosDataTable DTVentasProductos;
        DSDoblones20GestionComercial.ListarVentasProductosEspecificosParaVentaDataTable DTVentasProductosEspecificos;
        DSDoblones20GestionComercial2.VentasServiciosDataTable DTVentasServicios;
        DSDoblones20GestionComercial2.VentasServiciosDetalleDataTable DTVentasServiciosDetalle;
        DSDoblones20Sistema.MonedasDataTable DTMonedas;
        DataTable DTVentasProductosDetalleTemporalVisualizacion;
        DataTable DTVentasProductosDetalleTemporalMonedaSistema;
        DSDoblones20GestionComercial2.ObtenerCreditoDesdeCodigoAutorizacionRow DRCredito;
        DataTable VariablesConfiguracionSistemaGC;

        DSDoblones20Sistema.UsuariosDataTable DTUsuarios;
        DSDoblones20GestionComercial.ClientesDataTable DTClientes;

        VentasProductosCLN _VentasProductosCLN;
        VentasProductosDetalleCLN _VentasProductosDetalleCLN;
        VentasProductosEspecificosCLN _VentasProductosEspecificosCLN;
        VentasProductosEspecificosAgregadosCLN _VentasProductosEspecificosAgregadosCLN;
        InventariosProductosCLN _InventariosProductosCLN;
        TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;
        VentasServiciosCLN _VentasServiciosCLN;
        VentasServiciosDetalleCLN _VentasServiciosDetalleCLN;
        UsuariosCLN _UsuariosCLN;
        ClientesCLN _ClientesCLN;
        MonedasCLN _MonedasCLN;
        PCsConfiguracionesCLN PCConfiguracion;
        CreditosCLN _CreditosCLN;

        #region Propiedades de Configuración de Arranque del Sistema
        public decimal PorcentajeImpuestoSistema { get; set; }
        public int CodigoMonedaSistema { get; set; }
        public int CodigoMonedaRegion { get; set; }
        public string MascaraMonedaSistema { get; set; }
        public string MascaraMonedaRegion { get; set; }
        public string NombreMonedaSistema { get; set; }
        public string NombreMonedaRegion { get; set; }
        public bool ContabilidadIntegrada { get; set; }
        #endregion

        bool permitirModificar = true;
        FProductosBusqueda2 fProductosBusqueda;
        string TipoOperacion = "";
        int? NumeroCredito = null;
        bool EsCodigoTipoCreditoLibreDispocion = false;
        bool ventaParaInsitituciones = false;
        char CodigoTipoVenta = 'N';
        bool esCotizacionVenta = false;
        decimal MontoPrestamoCredito = 0;

        public FVentasProductos2(int NumeroAgencia, int NumeroPC, int CodigoUsuario)
        {
            InitializeComponent();

            
            this.NumeroAgencia = NumeroAgencia;
            this.NumeroPC = NumeroPC;
            this.CodigoUsuario = CodigoUsuario;

            //Inicio codigo agregado
            VariablesConfiguracionSistemaGC = new DataTable();
            PCConfiguracion = new PCsConfiguracionesCLN();
            VariablesConfiguracionSistemaGC = PCConfiguracion.ObtenerConfiguracionSistemaParaTransaccionesGC(NumeroPC);

            this.CodigoMonedaSistema = int.Parse(VariablesConfiguracionSistemaGC.Rows[0][3].ToString());
            this.NombreMonedaSistema = VariablesConfiguracionSistemaGC.Rows[0][4].ToString();
            this.MascaraMonedaSistema = VariablesConfiguracionSistemaGC.Rows[0][5].ToString();
            this.CodigoMonedaRegion = int.Parse(VariablesConfiguracionSistemaGC.Rows[0][6].ToString());
            this.NombreMonedaRegion = VariablesConfiguracionSistemaGC.Rows[0][7].ToString();
            this.MascaraMonedaRegion = VariablesConfiguracionSistemaGC.Rows[0][8].ToString();
            this.PorcentajeImpuestoSistema = decimal.Parse(VariablesConfiguracionSistemaGC.Rows[0][9].ToString());
            this.ContabilidadIntegrada = bool.Parse(VariablesConfiguracionSistemaGC.Rows[0][10].ToString());
            //Fin codigo agregado

            _ClientesCLN = new ClientesCLN();
            _InventariosProductosCLN = new InventariosProductosCLN();
            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();
            _UsuariosCLN = new UsuariosCLN();
            _VentasProductosCLN = new VentasProductosCLN();
            _VentasProductosDetalleCLN = new VentasProductosDetalleCLN();
            _VentasProductosEspecificosCLN = new VentasProductosEspecificosCLN();
            _VentasServiciosCLN = new VentasServiciosCLN();
            _VentasServiciosDetalleCLN = new VentasServiciosDetalleCLN();
            _MonedasCLN = new MonedasCLN();
            _VentasProductosEspecificosAgregadosCLN = new VentasProductosEspecificosAgregadosCLN();
            _CreditosCLN = new CreditosCLN();

            fProductosBusqueda = new FProductosBusqueda2(NumeroAgencia, NumeroPC, 'V', CodigoMonedaSistema, PorcentajeImpuestoSistema);

            DTClientes = new DSDoblones20GestionComercial.ClientesDataTable();
            DTUsuarios = new DSDoblones20Sistema.UsuariosDataTable();
            DTVentasProductos = new DSDoblones20GestionComercial.VentasProductosDataTable();
            DTVentasProductosDetalle = new DSDoblones20GestionComercial.ListarVentasProductosDetalleParaVentaDataTable();
            DTVentasProductosEspecificos = new DSDoblones20GestionComercial.ListarVentasProductosEspecificosParaVentaDataTable();
            DTVentasServicios = new DSDoblones20GestionComercial2.VentasServiciosDataTable();
            DTVentasServiciosDetalle = new DSDoblones20GestionComercial2.VentasServiciosDetalleDataTable();
            DTVentasProductosDetalleTemporalMonedaSistema = new DataTable();
            DTVentasProductosDetalleTemporalVisualizacion = fProductosBusqueda.DTProductosSeleccionados.Copy();
            DTMonedas = new DSDoblones20Sistema.MonedasDataTable();

            DGCNombreProductoD.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            DTClientes = (DSDoblones20GestionComercial.ClientesDataTable)_ClientesCLN.ObtenerCliente(1);
            cBoxCliente.DataSource = DTClientes;
            cBoxCliente.ValueMember = "CodigoCliente";
            cBoxCliente.DisplayMember = "NombreCliente";


            DTUsuarios = (DSDoblones20Sistema.UsuariosDataTable)_UsuariosCLN.ObtenerUsuario(CodigoUsuario);
            DTUsuarios.Columns.Add("NombreCompleto" ,Type.GetType("System.String"), "Paterno + ' '+ Materno + ' ' + Nombres ");
            cBoxVendedor.DataSource = DTUsuarios;
            cBoxVendedor.ValueMember = "CodigoUsuario";
            cBoxVendedor.DisplayMember = "NombreCompleto";

            DTMonedas = (DSDoblones20Sistema.MonedasDataTable)_MonedasCLN.ListarMonedas();
            cBoxMoneda.DataSource = DTMonedas;
            cBoxMoneda.DisplayMember = "NombreMoneda";
            cBoxMoneda.ValueMember = "CodigoMoneda";
            cBoxMoneda.SelectedValue = CodigoMonedaSistema;

            DGCProductoSeleccionado.Visible = false;

            cargarDatosVentasProductos(_TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("VentasProductos"));
            bdNavVentaProductosEspecificos.Visible = true;
            btnClientesBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAgregarCliente.Cursor = System.Windows.Forms.Cursors.Hand; 

            btnBuscar.Click += new EventHandler(btnBuscar_Click);
            //btnPagar.Click += new EventHandler(btnCambiarMoneda_Click);
            informeGeneralToolStripMenuItem.Click += new EventHandler(informeGeneralToolStripMenuItem_Click);
            incluirAgregadosToolStripMenuItem.Click += new EventHandler(incluirAgregadosToolStripMenuItem_Click);
            sinAgregadosToolStripMenuItem.Click += new EventHandler(sinAgregadosToolStripMenuItem_Click);
            reciboToolStripMenuItem.Click += new EventHandler(reciboToolStripMenuItem_Click);
            entregaInstitucionalToolStripMenuItem.Click += new EventHandler(entregaInstitucionalToolStripMenuItem_Click);
            btnNuevaVenta.Click += new EventHandler(btnNuevaVenta_Click);
            btnVentaInstitucional.Click += new EventHandler(btnNuevaVenta_Click);            
            btnCancelar.Click += new EventHandler(btnCancelar_Click);
            btnAnular.Click += new EventHandler(btnAnular_Click);
            btnModificar.Click += new EventHandler(btnModificar_Click);
            btnAceptar.Click += new EventHandler(btnAceptar_Click);
            rBtnEfectivo.CheckedChanged += new EventHandler(rBtnEfectivo_CheckedChanged);
            rBtnCredito.CheckedChanged += new EventHandler(rBtnCredito_CheckedChanged);
            btnClientesBuscar.Click += new EventHandler(btnClientesBuscar_Click);
            btnAgregarCliente.Click += new EventHandler(btnAgregarCliente_Click);
            modificarToolStripMenuItem.Click += new EventHandler(modificarToolStripMenuItem_Click);
        }

        void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FObservacionesTransaccionesModificacion _FObservacionesTransaccionesModificacion = new FObservacionesTransaccionesModificacion("V", CodigoUsuario, NumeroAgencia, NumeroVentaProducto);
            _FObservacionesTransaccionesModificacion.TxtBoxObservaciones.Text = txtBoxObservaciones.Text;
            if (_FObservacionesTransaccionesModificacion.ShowDialog() == DialogResult.OK)
                txtBoxObservaciones.Text = _FObservacionesTransaccionesModificacion.TxtBoxObservaciones.Text;
        }

        void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            FClientes formClientes = new FClientes(true, false, false, true);
            formClientes.ShowDialog(this);
            
            int CodigoCliente = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("Clientes");
            DTClientes = (DSDoblones20GestionComercial.ClientesDataTable)_ClientesCLN.ObtenerCliente(CodigoCliente);            
            cBoxCliente.DataSource = DTClientes;
            cBoxCliente.DisplayMember = "NombreCliente";
            cBoxCliente.ValueMember = "CodigoCliente";
            cBoxCliente.SelectedValue = CodigoCliente;
            errorProvider1.Clear();
        }

        void btnClientesBuscar_Click(object sender, EventArgs e)
        {
            FBuscarClientes formClientes = new FBuscarClientes();
            formClientes.ShowDialog(this);
            int CodigoCliente = formClientes.CodigoCliente;
            DTClientes = (DSDoblones20GestionComercial.ClientesDataTable) _ClientesCLN.ObtenerCliente(CodigoCliente);
            cBoxCliente.DataSource = DTClientes;
            cBoxCliente.DisplayMember = "NombreCliente";
            cBoxCliente.ValueMember = "CodigoCliente";
            cBoxCliente.SelectedValue = CodigoCliente;
            errorProvider1.Clear();
        }

        void rBtnCredito_CheckedChanged(object sender, EventArgs e)
        {
            if ((TipoOperacion == "N" || TipoOperacion == "E") && rBtnCredito.Checked && (!btnNuevaVenta.Enabled || !btnVentaInstitucional.Enabled))
            {
                
                //FVentasProductosBuscarCredito _FVentasProductosBuscarCredito = new FVentasProductosBuscarCredito(NumeroAgencia, NumeroPC);
                //_FVentasProductosBuscarCredito.CodigoMonedaVenta = int.Parse(cBoxMoneda.SelectedValue.ToString());
                
                
                //_FVentasProductosBuscarCredito.MontoTotalVenta = (decimal)(bdSourceVentasProductosDetalle.DataSource as DataTable).Compute("sum(PrecioTotal)", "");
                //_FVentasProductosBuscarCredito.EsParaCreditoLibreDisposicion = EsCodigoTipoCreditoLibreDispocion;
                //_FVentasProductosBuscarCredito.ShowDialog(this);
                //if (_FVentasProductosBuscarCredito.OperacionConfirmada)
                ////if(_FVentasProductosBuscarCredito.ShowDialog(this) == DialogResult.OK)
                //{
                    //NumeroCredito = _FVentasProductosBuscarCredito.DTCreditos[0].NumeroCredito;
                    //DRCredito = _FVentasProductosBuscarCredito.DTCreditos[0];
                    //MontoPrestamoCredito = DRCredito.MontoDisponible;

                    btnModificar.Enabled = false;
                    cBoxMoneda.Enabled = false;
                    checkBIncluirFactura.Enabled = false;

                    //gBoxDatosCreditos.Visible = true;
                    //txtBoxMontoDisponibleCredito.Text = DRCredito.MontoDisponible.ToString();
                    //txtBoxMontoTotalCredito.Text = DRCredito.MontoDeuda.ToString();
                    //if (DRCredito.CodigoTipoCredito == "T" || DRCredito.CodigoTipoCredito == "L")
                    //    txtBoxMontoPagoCredito.Text = "0.00";
                    //else
                    //    txtBoxMontoPagoCredito.Text = (decimal.Parse(DTVentasProductosDetalleTemporalVisualizacion.Compute("sum(PrecioTotal)", "").ToString()) - 
                    //        DRCredito.MontoDisponible).ToString();

                    gBoxDatosCreditos.Visible = false;
                    txtBoxMontoPagoCredito.Text = "0.00";
                    txtBoxMontoDisponibleCredito.Text = "0.00";
                    txtBoxMontoTotalCredito.Text = "0.00";
                    NumeroCredito = -1;
                    
                //}
                //else
                //{
                //    MessageBox.Show(this, "No ha ingresado un crédito válido, no puede Realizar una Venta a Credito", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                //    rBtnEfectivo.Checked = true;
                //    NumeroCredito = null;
                //    gBoxDatosCreditos.Visible = false;
                //    txtBoxMontoPagoCredito.Text = "0.00";
                //    txtBoxMontoDisponibleCredito.Text = "0.00";
                //    txtBoxMontoTotalCredito.Text = "0.00";
                //    gBoxDatosCreditos.Visible = false;
                //    return;
                //}
            }
        }

        void rBtnEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            NumeroCredito = null;
            DRCredito = null;
            btnModificar.Enabled = TipoOperacion == "N" || TipoOperacion == "E";
            cBoxMoneda.Enabled = false;
            gBoxDatosCreditos.Visible = false;
        }

        void btnAceptar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (checkBIncluirFactura.Checked)
            {                
                if (MessageBox.Show(this, "Ha seleccionado incluir Factura en la Venta. ¿Desea Continuar La Venta con Factura?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            if (validarCampos())
            {
                
                if (DTVentasProductosDetalleTemporalVisualizacion.Rows.Count > 0)
                {
                    
                    
                    //Revisamos de que la cantidad de entrega sea coherente
                    //a la cantidad que se vende, tomando en cuenta
                    //que solo se puede entregar lo que hay en almacenes, sin sobrepasar la cantidad de Venta
                    if (fProductosBusqueda.ExistenProductosInalcanzables)
                    {
                        int CantidadVendida = 0;
                        int CantidadEntregada = 0;
                        int CantidadExistencia = 0;
                        foreach (DataRow fila in DTVentasProductosDetalleTemporalVisualizacion.Rows)
                        {
                            CantidadVendida = Int32.Parse(fila["Cantidad"].ToString());
                            CantidadEntregada = Int32.Parse(fila["CantidadEntregada"].ToString());//CantidadEntregada
                            CantidadExistencia = Int32.Parse(fila["CantidadExistencia"].ToString());

                            if (CantidadEntregada > CantidadVendida)
                            {
                                if (MessageBox.Show(this, "No Puede continuar la operación debido a que existe una cantidad de entrega superior a la que desea vender. ¿Desea que el Sistema arregle la cantidad de entrega a la cantidad existencia en Almacenes?", "Venta de Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    fila["CantidadEntregada"] = fila["CantidadExistencia"];
                                    fila.AcceptChanges();
                                }//Mandamos el foco a la Celda del Producto en su cantidad de Entrega
                                dGVProductosSeleccionados.CurrentCell = dGVProductosSeleccionados[DGCCantidadEntregada.Index, DTVentasProductosDetalleTemporalVisualizacion.Rows.IndexOf(fila)];
                                //dGVProductosSeleccionados.Rows[DTVentasProductosDetalleTemporalVisualizacion.Rows.IndexOf(fila)].Cells[DTVentasProductosDetalleTemporalVisualizacion.Columns.Count - 1].Selected = true;                                
                                dGVProductosSeleccionados.BeginEdit(true);
                                MessageBox.Show(this, "Por Favor proceda a Revisar sus Datos y a continuación vuelva a realizar la confirmación de la Operación", "Venta de Productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //dGVProductosSeleccionados.ReadOnly = false;
                                DGCCantidadEntregada.ReadOnly = false;

                                return;
                            }
                            if (CantidadEntregada > CantidadExistencia)
                            {
                                if (MessageBox.Show(this, "No Puede continuar la operación debido a que existe una cantidad de entrega superior a la que existe en Almacenes. ¿Desea que el Sistema arregle la cantidad de entrega a la cantidad existencia en Almacenes?", "Venta de Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    fila["CantidadEntregada"] = Int32.Parse(fila["CantidadExistencia"].ToString());
                                dGVProductosSeleccionados.CurrentCell = dGVProductosSeleccionados[DGCCantidadEntregada.Index, DTVentasProductosDetalleTemporalVisualizacion.Rows.IndexOf(fila)];
                                //dGVProductosSeleccionados.Rows[DTVentasProductosDetalleTemporalVisualizacion.Rows.IndexOf(fila)].Cells[DTVentasProductosDetalleTemporalVisualizacion.Columns.Count - 1].Selected = true;
                                dGVProductosSeleccionados.BeginEdit(true);
                                MessageBox.Show(this, "Por Favor proceda a Revisar sus Datos y a continuación vuelva a realizar la confirmación de la Operación", "Venta de Productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ///dGVProductosSeleccionados.ReadOnly = false;
                                DGCCantidadEntregada.ReadOnly = false;
                                return;
                            }
                        }

                    }


                    // aceptamos todos los cambios y generamos el XML que nos servira
                    //para insertar toda la venta en uno, y a la vez realizar una revisión de los datos
                    DTVentasProductosDetalleTemporalMonedaSistema.AcceptChanges();
                    
                    DataSet DSTemporal = new DataSet("Productos");
                    DataTable DTProductosPreciosActualizados = DTVentasProductosDetalleTemporalMonedaSistema.Copy();
                    DTProductosPreciosActualizados.PrimaryKey = null;
                    DTProductosPreciosActualizados.Constraints.Clear();
                    DTProductosPreciosActualizados.Columns["Código Producto"].ColumnName = "CodigoProducto";
                    DTProductosPreciosActualizados.Columns.Remove(DTProductosPreciosActualizados.Columns["Nombre Producto"]);

                    /*para Aumentar una columna que conserve los montos de los precio en la moneda en la que se visualiza*/
                    DTProductosPreciosActualizados.Columns.Add("PrecioUnitarioOtraMoneda", Type.GetType("System.Decimal"));
                    foreach (DataRow DRProducto in DTVentasProductosDetalleTemporalVisualizacion.Rows)
                    {
                        DTProductosPreciosActualizados.Rows[DTVentasProductosDetalleTemporalVisualizacion.Rows.IndexOf(DRProducto)]["PrecioUnitarioOtraMoneda"] = DRProducto["Precio"];
                        DTProductosPreciosActualizados.Rows[DTVentasProductosDetalleTemporalVisualizacion.Rows.IndexOf(DRProducto)]["Cantidad"] = DRProducto["Cantidad"];
                    }

                    DSTemporal.Tables.Add(DTProductosPreciosActualizados);



                    string ProductosDetalle = DTProductosPreciosActualizados.DataSet.GetXml();

                    //Revisamos que el credito que se va asignar a la venta sea coherente y acorde a la misma
                    //if (NumeroCredito != null )
                    //{
                    //    decimal MontoTotalVentaAux = decimal.Parse(DTVentasProductosDetalleTemporalVisualizacion.Compute("sum(PrecioTotal)", "VendidoComoAgregado = false").ToString());
                    //    if (DRCredito != null)
                    //    {
                    //        string RespuestaValidacionCredito = _TransaccionesUtilidadesCLN.EsPosibleAsignarCreditoAVentaProductos(null, DRCredito.NumeroCredito, NumeroAgencia, ProductosDetalle, MontoTotalVentaAux);
                    //        if (!string.IsNullOrEmpty(RespuestaValidacionCredito))
                    //        {
                    //            MessageBox.Show(this, "Ocurrio la siguiente excepción al momento de asignar el Numero de Credito a la Venta actual.\r\n " + RespuestaValidacionCredito,
                    //                "Venta a Credito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //            rBtnEfectivo.Checked = true;
                    //            return;
                    //        }                            
                    //    }
                        
                    //    if (MontoTotalVentaAux > MontoPrestamoCredito)
                    //    {
                    //        MessageBox.Show(this, "No puede Realizar una Venta cuyo Precio Total de Pago sea superior al crédito Otorgado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        return;
                    //    }
                    //}

                    //si no existió ningun error, se Procede a registrar la Venta

                    DTVentasProductosDetalleTemporalMonedaSistema.Columns["PrecioTotal"].Expression = "Cantidad * Precio";
                    DTVentasProductosDetalleTemporalMonedaSistema.AcceptChanges();
                    object precioParcialDetalle = DTVentasProductosDetalleTemporalMonedaSistema.Compute("sum(PrecioTotal)", "VendidoComoAgregado = false");

                    decimal PrecioTotal = Decimal.Parse(precioParcialDetalle.ToString());
                    try
                    {
                        if (TipoOperacion == "E")
                        {
                            foreach (DataRow fila in this.DTVentasProductosDetalleTemporalVisualizacion.Rows)
                            {
                                DTVentasProductosDetalleTemporalMonedaSistema.Rows[DTVentasProductosDetalleTemporalVisualizacion.Rows.IndexOf(fila)]["CantidadEntregada"]
                                    = fila["CantidadEntregada"];
                            }
                        }

                        int? NumeroFactura = -1;
                        if (TipoOperacion == "N")
                        {
                           
                            //Insertar toda la Venta en uno, incluyendo DETALLE DE VENTA MEDIANTE UN XML
                            
                            if (TipoOperacion == "N")
                                _VentasProductosCLN.InsertarVentaProductoXMLDetalle(NumeroAgencia, 
                                    cBoxCliente.SelectedValue == null ? 1 : int.Parse(cBoxCliente.SelectedValue.ToString().Trim()), 
                                    CodigoUsuario, 
                                    checkBIncluirFactura.Checked ? NumeroFactura : null, 
                                    _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor(), 
                                    CodigoTipoVenta.ToString(), 
                                    ventaParaInsitituciones ? "T" : NumeroCredito == null ? "I" : "P", 
                                    PrecioTotal, NumeroCredito, 
                                    byte.Parse(cBoxMoneda.SelectedValue.ToString()), 
                                    txtBoxObservaciones.Text, ProductosDetalle, 
                                    null, null, null);
                            else
                                _VentasProductosCLN.InsertarVentaProductoXMLDetalle(NumeroAgencia, 
                                    cBoxCliente.SelectedValue == null ? 1 : int.Parse(cBoxCliente.SelectedValue.ToString().Trim()), 
                                    CodigoUsuario, 
                                    checkBIncluirFactura.Checked ? NumeroFactura : null, 
                                    _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor(), 
                                    CodigoTipoVenta.ToString(), "P", PrecioTotal, NumeroCredito, 
                                    byte.Parse(cBoxMoneda.SelectedValue.ToString()), 
                                    txtBoxObservaciones.Text, ProductosDetalle, null, null, null);

                            
                            NumeroVentaProducto = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("VentasProductos");
                            cargarDatosVentasProductos(NumeroVentaProducto);
                            cBoxCliente.Focus();
                            
                        }
                        else // SI SE EDITA LA VENTA
                        {

                            if (!fProductosBusqueda.ExistenProductosInalcanzables)
                            {
                                foreach (DataRow DRProducto in DTProductosPreciosActualizados.Rows)
                                {
                                    DRProducto["CantidadEntregada"] = DRProducto[2];
                                }
                            }
                            DTProductosPreciosActualizados.AcceptChanges();

                            
                            if (NumeroCredito == null)
                                _VentasProductosCLN.ActualizarVentaProductoXMLDetalle(NumeroAgencia,
                                    NumeroVentaProducto,
                                    cBoxCliente.SelectedValue == null ? 1 : int.Parse(cBoxCliente.SelectedValue.ToString().Trim()),
                                    CodigoUsuario, checkBIncluirFactura.Checked ? NumeroFactura : null,
                                    _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor(),
                                    CodigoTipoVenta.ToString(),
                                    ventaParaInsitituciones ? "T" : "I",
                                    PrecioTotal, NumeroCredito,
                                    byte.Parse(cBoxMoneda.SelectedValue.ToString()), 
                                    txtBoxObservaciones.Text, DSTemporal.GetXml(),
                                    null, null, null);
                            else                                
                                _VentasProductosCLN.ActualizarVentaProductoXMLDetalle(NumeroAgencia,
                                    NumeroVentaProducto,
                                    cBoxCliente.SelectedValue == null ? 1 : int.Parse(cBoxCliente.SelectedValue.ToString().Trim()),
                                    CodigoUsuario, checkBIncluirFactura.Checked ? NumeroFactura : null,
                                    _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor(),
                                    CodigoTipoVenta.ToString(), "P",
                                    PrecioTotal, NumeroCredito,
                                    byte.Parse(cBoxMoneda.SelectedValue.ToString()),
                                    txtBoxObservaciones.Text, DSTemporal.GetXml(),
                                    null, null, null);


                            ////PARA EL DETALLE
                            //foreach (DataRow FilaProductoModificado in DTVentasProductosDetalleTemporalMonedaSistema.Rows)
                            //{
                            //    if (FilaProductoModificado.RowState == DataRowState.Deleted)
                            //        _VentasProductosDetalleCLN.EliminarVentaProductoDetalle(NumeroAgencia, NumeroVentaProducto, FilaProductoModificado["Código Producto"].ToString());
                            //    else
                            //    {
                            //        int cantidadEntregada = 0;
                            //        //si el producto no es producto Especifico Agregado
                            //        if (!FilaProductoModificado[7].Equals(true))
                            //        {
                            //            if (fProductosBusqueda.ExistenProductosInalcanzables)
                            //                cantidadEntregada = Int32.Parse(FilaProductoModificado["CantidadEntregada"].ToString());
                            //            else
                            //                cantidadEntregada = Int32.Parse(FilaProductoModificado[2].ToString());
                            //            //VentaProductosDetalleCLN.InsertarVentaProductoDetalle(NumeroAgencia, numeroVenta, fila[0].ToString(), Int32.Parse(fila[2].ToString()), Int32.Parse(fila[2].ToString()), Decimal.Parse(fila[3].ToString()), 1);
                            //            _VentasProductosDetalleCLN.InsertarVentaProductoDetalle(
                            //                NumeroAgencia, NumeroVentaProducto, 
                            //                FilaProductoModificado[0].ToString(), 
                            //                Int32.Parse(FilaProductoModificado[2].ToString()), 
                            //                cantidadEntregada, 
                            //                checkBIncluirFactura.Checked ? Decimal.Parse(FilaProductoModificado[3].ToString()) + (Decimal.Parse(FilaProductoModificado[3].ToString())* (PorcentajeImpuestoSistema /100))
                            //                : Decimal.Parse(FilaProductoModificado[3].ToString()), 
                            //                int.Parse(FilaProductoModificado["Garantia"].ToString()), 
                            //                Decimal.Parse(FilaProductoModificado["PorcentajeDescuento"].ToString()), 
                            //                FilaProductoModificado["NumeroPrecioSeleccionado"].ToString());
                            //        }
                            //    }

                            //}
                            //string CodigoProducto = "";
                            //foreach (DataRow FilaAntigua in DTVentasProductosDetalle.Rows)
                            //{
                            //    CodigoProducto = FilaAntigua["CodigoProducto"].ToString().Trim();
                            //    if (DTVentasProductosDetalleTemporalVisualizacion.Rows.Find(CodigoProducto) == null)
                            //    {
                            //        _VentasProductosDetalleCLN.EliminarVentaProductoDetalle(NumeroAgencia, NumeroVentaProducto, FilaAntigua["CodigoProducto"].ToString());
                            //    }
                            //}

                            cargarDatosVentasProductos(NumeroVentaProducto);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo realizar la Venta. Ocurrio la siguiente Excepción " + ex.Message);
                        return;
                    }

                    mostarReporteParaEntregaProductosAlmacenes();
                    TipoOperacion = "";
                    esCotizacionVenta = false;
                    if (rBtnCredito.Checked)
                    {
                        gBoxDatosCreditos.Visible = false;
                        txtBoxMontoTotalCredito.Text = "0.00";
                        txtBoxMontoPagoCredito.Text = "0.00";
                        txtBoxMontoDisponibleCredito.Text = "0.00";
                    }
                }
                else
                {
                    if (MessageBox.Show(this, "No Puede Realizar Esta Transacción sin Haber por lo Menos Seleccionado una Producto para su Venta. \\n ¿Desea Agregar Productos a la Venta Actual?", "Verifique la Venta", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        fProductosBusqueda.ShowDialog(this);
                    }
                    else
                    {                        
                        cargarDatosVentasProductos(_TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("VentasProductos"));
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "No Puede Aceptar La Venta Actual, sin haber Seleccionado un Cliente" + Environment.NewLine + "Se desea realizar la Venta sin Ningun Cliente, seleccione el Cliente Anonimo y Proceda a aceptar la Venta", "Ventas de Productos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cBoxCliente.Focus();
            }
            dGVProductosSeleccionados.ReadOnly = true;
        }

        private void mostarReporteParaEntregaProductosAlmacenes()
        {
            DataTable DTVentasProductos = _VentasProductosCLN.ListarVentaProductoReporte(NumeroAgencia, NumeroVentaProducto);
            DataTable DTVentasProductosDetalle = _VentasProductosDetalleCLN.ListarVentaProductoDetalleReporteParaRecogerDeAlmacenes(NumeroAgencia, NumeroVentaProducto, "S", true);
            DataTable DTDatosAgencia = new CLCLN.Sistema.AgenciasCLN().ListarDatosAgenciasParaTransaccionesReportes(NumeroAgencia);
            //FReporteVentaEntregaProductosAlmacenes formReporteVentasProductos = new FReporteVentaEntregaProductosAlmacenes(DTDatosAgencia, DTVentasProductos, VentaUtilidadesCLN.ObtenerListaProductosParaCambiarMoneda(NumeroAgencia, null, DTVentasProductosDetalle));
            FReporteVentaEntregaProductosAlmacenes formReporteVentasProductos = new FReporteVentaEntregaProductosAlmacenes(DTDatosAgencia, DTVentasProductos, DTVentasProductosDetalle);
            formReporteVentasProductos.ListarVentaProductoDetalleReporteParaRecogerDeAlmacenes();
            formReporteVentasProductos.ShowDialog(this);
        }

        //ListarVentaProductoCompuestosDetalleReporte
        private void ListarVentaProductoCompuestosDetalleReporte()
        {
            DataTable DTVentasProductos = _VentasProductosCLN.ListarVentaProductoReporte(NumeroAgencia, NumeroVentaProducto);
            DataTable DTVentasProductosDetalle = _VentasProductosDetalleCLN.ListarVentaProductoCompuestosDetalleReporte(NumeroAgencia, NumeroVentaProducto);
            DataTable DTDatosAgencia = new CLCLN.Sistema.AgenciasCLN().ListarDatosAgenciasParaTransaccionesReportes(NumeroAgencia);
            DataTable DTVentasProductosDetalleSimples = _VentasProductosDetalleCLN.ListarVentaProductoSimplesDetalleReporte(NumeroAgencia, NumeroVentaProducto, true);
            //FReporteVentaEntregaProductosAlmacenes formReporteVentasProductos = new FReporteVentaEntregaProductosAlmacenes(DTDatosAgencia, DTVentasProductos, VentaUtilidadesCLN.ObtenerListaProductosParaCambiarMoneda(NumeroAgencia, null, DTVentasProductosDetalle));
            FReporteVentaEntregaProductosAlmacenes formReporteVentasProductos = new FReporteVentaEntregaProductosAlmacenes(DTDatosAgencia, DTVentasProductos, DTVentasProductosDetalle);
            formReporteVentasProductos.ListarVentaProductoCompuestosDetalleReporte(DTVentasProductosDetalleSimples);
            formReporteVentasProductos.ShowDialog(this);
        }

        //private void ListarVentaProductoSimplesDetalleReporte()
        //{
        //    DataTable DTVentasProductos = _VentasProductosCLN.ListarVentaProductoReporte(NumeroAgencia, NumeroVentaProducto);
        //    DataTable DTVentasProductosDetalle = _VentasProductosDetalleCLN.ListarVentaProductoCompuestosDetalleReporte(NumeroAgencia, NumeroVentaProducto);
        //    DataTable DTDatosAgencia = new CLCLN.Sistema.AgenciasCLN().ListarDatosAgenciasParaTransaccionesReportes(NumeroAgencia);
        //    //FReporteVentaEntregaProductosAlmacenes formReporteVentasProductos = new FReporteVentaEntregaProductosAlmacenes(DTDatosAgencia, DTVentasProductos, VentaUtilidadesCLN.ObtenerListaProductosParaCambiarMoneda(NumeroAgencia, null, DTVentasProductosDetalle));
        //    FReporteVentaEntregaProductosAlmacenes formReporteVentasProductos = new FReporteVentaEntregaProductosAlmacenes(DTDatosAgencia, DTVentasProductos, DTVentasProductosDetalle);
        //    formReporteVentasProductos.ListarVentaProductoCompuestosDetalleReporte(DTVentasProductosDetalleSimples);
        //    formReporteVentasProductos.ShowDialog(this);
        //}

        void btnModificar_Click(object sender, EventArgs e)
        {
            if (btnNuevaVenta.Enabled || btnVentaInstitucional.Enabled)
            {
                
                habilitarControles(true);
                
                TipoOperacion = "E";
                int indice = 0;

                CodigoTipoVenta = DTVentasProductos[0].CodigoTipoVenta[0];
                DTVentasProductosDetalleTemporalVisualizacion.Clear();
                foreach (DSDoblones20GestionComercial.ListarVentasProductosDetalleParaVentaRow FilaNueva 
                    in DTVentasProductosDetalle.Rows)
                {
                    DataRow FilaProducto = DTVentasProductosDetalleTemporalVisualizacion.NewRow();
                    FilaProducto["Código Producto"] = FilaNueva.CodigoProducto;
                    FilaProducto["Nombre Producto"] = FilaNueva["NombreProducto"];
                    FilaProducto["Cantidad"] = FilaNueva["CantidadVenta"];
                    FilaProducto["Precio"] = DTVentasProductos[0].IsNumeroFacturaNull() ? FilaNueva["PrecioUnitarioVenta"] : decimal.Round(FilaNueva.PrecioUnitarioVenta / (1 + PorcentajeImpuestoSistema / 100), 2);
                    //FilaProducto["Precio"] = FilaNueva.PrecioUnitarioVenta;
                    FilaProducto["PrecioTotal"] = DTVentasProductos[0].IsNumeroFacturaNull() ? FilaNueva.CantidadVenta * FilaNueva.PrecioUnitarioVenta
                        : decimal.Round(FilaNueva.CantidadVenta * FilaNueva.PrecioUnitarioVenta / (1 + PorcentajeImpuestoSistema / 100), 2);
                    //FilaProducto["PrecioTotal"] = FilaNueva.PrecioUnitarioVenta * FilaNueva.CantidadVenta;
                    FilaProducto["Garantia"] = FilaNueva["TiempoGarantiaVenta"];
                    FilaProducto["EsProductoEspecifico"] = _TransaccionesUtilidadesCLN.esProductoEspecifico(NumeroAgencia, FilaNueva["CodigoProducto"].ToString());
                    FilaProducto["VendidoComoAgregado"] = false;
                    FilaProducto["CantidadExistencia"] = _TransaccionesUtilidadesCLN.ObtenerExistenciaProductoInventario(NumeroAgencia, FilaNueva["CodigoProducto"].ToString());
                    FilaProducto["CantidadEntregada"] = FilaNueva["CantidadEntregada"];
                    FilaProducto["PorcentajeDescuento"] = FilaNueva["PorcentajeDescuento"];
                    FilaProducto["NumeroPrecioSeleccionado"] = FilaNueva["NumeroPrecioSeleccionado"];
                    DTVentasProductosDetalleTemporalVisualizacion.Rows.Add(FilaProducto);
                    indice++;
                }
                DTVentasProductosDetalleTemporalVisualizacion.AcceptChanges();

                fProductosBusqueda.DTProductosSeleccionadosMonedaSistema = DTVentasProductosDetalleTemporalVisualizacion.Copy();
                fProductosBusqueda.DTProductosSeleccionados = this.DTVentasProductosDetalleTemporalVisualizacion;
                fProductosBusqueda.BDSourceProductosSeleccionados.DataSource = fProductosBusqueda.DTProductosSeleccionados;
                fProductosBusqueda.DTGridViewProductosSeleccionados.DataSource = fProductosBusqueda.BDSourceProductosSeleccionados;
                fProductosBusqueda.nuevaVenta = false;
                fProductosBusqueda.ListaCodigosProductosEliminados.Clear();
                fProductosBusqueda.limpiarControles();
                fProductosBusqueda.habilitarEvento();
                DTVentasProductosDetalleTemporalMonedaSistema = fProductosBusqueda.DTProductosSeleccionadosMonedaSistema;
                // fProductosBusqueda.cargarPieDetalleResultado();
                bdSourceVentasProductosDetalle.DataSource = DTVentasProductosDetalleTemporalVisualizacion;
                formatearEstiloTabla();
                habilitarBotones(false, false, true, true, false, false, false, false, true, true);

                
                EsCodigoTipoCreditoLibreDispocion = true;

                fProductosBusqueda.CheckConFactura.Checked = checkBIncluirFactura.Checked;
                fProductosBusqueda.CBoxMonedas.SelectedValue = cBoxMoneda.SelectedValue;

                if (DTVentasProductos[0].CodigoTipoVenta == "T")
                {
                    rBtnCredito.Enabled = false;
                }

                //CODIGO AUMENTADO
                if (!DTVentasProductos[0].IsNumeroCreditoNull())
                {
                    NumeroCredito = DTVentasProductos[0].IsNumeroCreditoNull() ? null : (int?)DTVentasProductos[0].NumeroCredito;
                    DataTable DTCreditosAux = _CreditosCLN.ObtenerCredito(NumeroCredito.Value);
                    DRCredito = (CLCAD.DSDoblones20GestionComercial2.ObtenerCreditoDesdeCodigoAutorizacionRow) _TransaccionesUtilidadesCLN.ObtenerCreditoDesdeCodigoAutorizacion(
                        DTCreditosAux.Rows[0]["CodigoAutorizacion"].ToString()  , NumeroAgencia,  DTCreditosAux.Rows[0]["CodigoTipoCredito"].ToString() == "L"  ).Rows[0];
                    if (DTVentasProductos[0].CodigoMoneda == CodigoMonedaSistema)
                        MontoPrestamoCredito = DRCredito.MontoDisponible + DTVentasProductos[0].MontoTotalVenta;
                    else
                    {
                        decimal FactorCambioCotizacion = _TransaccionesUtilidadesCLN.ObtenerFactorCambioCotizacion(CodigoMonedaSistema,
                            DTVentasProductos[0].FechaHoraVenta, DTVentasProductos[0].CodigoMoneda);
                        MontoPrestamoCredito = decimal.Round(DRCredito.MontoDisponible + DTVentasProductos[0].MontoTotalVenta * FactorCambioCotizacion, 2);
                    }

                    btnModificar.Enabled = false;
                    cBoxMoneda.Enabled = false;
                    checkBIncluirFactura.Enabled = false;

                    gBoxDatosCreditos.Visible = true;
                    txtBoxMontoDisponibleCredito.Text = DRCredito.MontoDisponible.ToString();
                    txtBoxMontoTotalCredito.Text = DRCredito.MontoDeuda.ToString();
                    if (DRCredito.CodigoTipoCredito == "T" || DRCredito.CodigoTipoCredito == "L")
                        txtBoxMontoPagoCredito.Text = "0.00";
                    else
                        txtBoxMontoPagoCredito.Text = (decimal.Parse(DTVentasProductosDetalleTemporalVisualizacion.Compute("sum(PrecioTotal)", "").ToString()) -
                            DRCredito.MontoDisponible).ToString();
                }
            }

            if (esCotizacionVenta)
            {
                fProductosBusqueda.DTProductosSeleccionados = this.DTVentasProductosDetalleTemporalVisualizacion;

            }
            if (ventaParaInsitituciones && esCotizacionVenta)
            {
                TipoOperacion = "N";
                checkBIncluirFactura.Enabled = false;
            }
            
            

            fProductosBusqueda.ShowDialog(this);

            

            if (fProductosBusqueda.DTProductosSeleccionados.Rows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ningún Producto para su Venta, se procederá a cancelar la operación Actual");
                btnCancelar_Click(sender, e);
                return;
            }
            checkBIncluirFactura.Checked = fProductosBusqueda.CheckConFactura.Checked;
            cBoxMoneda.SelectedValue = fProductosBusqueda.CBoxMonedas.SelectedValue;
            string MascaraMonedaCotizacion = DTMonedas.Rows.Find(fProductosBusqueda.CBoxMonedas.SelectedValue)["MascaraMoneda"].ToString();
            revisarProductosInalcanzables();
            NumeroCredito = DTVentasProductos[0].IsNumeroCreditoNull() ? null : (int?)DTVentasProductos[0].NumeroCredito;
            this.txtBoxPrecioTotal.Text = DTVentasProductosDetalleTemporalVisualizacion.Compute("sum(PrecioTotal)", "VendidoComoAgregado = false").ToString() + " " + MascaraMonedaCotizacion;
            this.txtBoxPrecioTotalCancelar.Text = DTVentasProductosDetalleTemporalVisualizacion.Compute("sum(PrecioTotal)", "").ToString() + " " + MascaraMonedaCotizacion;
            tabControl1.SelectedIndex = 0;
            
        }

        void btnAnular_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Se encuentra seguro de Anular la Orden de Venta Actual?", "Anulación de Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            int indiceActual = bdSourceVentasProductos.Position;
            _VentasProductosCLN.ActualizarVentaProducto(NumeroAgencia, 
                DTVentasProductos[0].NumeroVentaProducto, 
                DTVentasProductos[0].CodigoCliente, CodigoUsuario, null, 
                DTVentasProductos[0].FechaHoraVenta, 
                DTVentasProductos[0].CodigoTipoVenta, 
                DTVentasProductos[0].MontoTotalVenta, "A", 
                DTVentasProductos[0].IsNumeroCreditoNull() ? null : (int?)DTVentasProductos[0].NumeroCredito, 
                DTVentasProductos[0].CodigoMoneda, txtBoxObservaciones.Text);
            cargarDatosVentasProductos(NumeroVentaProducto);
            
        }

        void btnCancelar_Click(object sender, EventArgs e)
        {
            
            cBoxMoneda.SelectedValue = CodigoMonedaSistema;
            cargarDatosVentasProductos(_TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("VentasProductos"));
            
        }

        void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            fProductosBusqueda.inhabilitarControlesParaCotizacion(false);
            fProductosBusqueda.limpiarControles();
            cBoxMoneda.SelectedValue = CodigoMonedaSistema;
            TipoOperacion = "N";
            NumeroCredito = null;
            rBtnEfectivo.Checked = true;
            EsCodigoTipoCreditoLibreDispocion = true;

            



            if ((sender as ToolStripButton).Name.CompareTo("btnNuevaVenta") == 0)
            {
                ventaParaInsitituciones = false;
                CodigoTipoVenta = 'N';
            }
            else
            {
                ventaParaInsitituciones = true;
                CodigoTipoVenta = 'T';
                rBtnCredito.Enabled = false;
            }
            
            checkBIncluirFactura.Checked = false;
            cBoxVendedor.SelectedValue = CodigoUsuario;
            LimpiarCampos();

            DTUsuarios = (DSDoblones20Sistema.UsuariosDataTable)_UsuariosCLN.ObtenerUsuario(CodigoUsuario);
            DTUsuarios.Columns.Add("NombreCompleto", Type.GetType("System.String"), "Paterno + ' '+ Materno + ' ' + Nombres ");
            cBoxVendedor.DataSource = DTUsuarios;
            cBoxVendedor.DisplayMember = "NombreCompleto";
            cBoxVendedor.ValueMember = "CodigoUsuario";
            cBoxVendedor.SelectedValue = CodigoUsuario;

            rBtnEfectivo.Checked = true;
            checkBIncluirFactura.Enabled = false;

            DGCCantidadEntregada.Visible = DGCPorcentajeDescuento.Visible = DGCProductoSeleccionado.Visible = false;
            DGCCodigoProductoD.DataPropertyName = "Código Producto";
            
            
            DTVentasProductosDetalleTemporalVisualizacion = fProductosBusqueda.DTProductosSeleccionados;
            DTVentasProductosDetalleTemporalMonedaSistema = fProductosBusqueda.DTProductosSeleccionadosMonedaSistema;
            bdSourceVentasProductosDetalle.DataSource = DTVentasProductosDetalleTemporalVisualizacion;
            formatearEstiloTabla();
            NumeroVentaProducto = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("VentasProductos");
            if (NumeroVentaProducto == 0) NumeroVentaProducto = 1;
            if (NumeroVentaProducto > 1)
                NumeroVentaProducto++;


            lblNumeroVenta.Text = NumeroVentaProducto.ToString();
            lblEstado.Text = "Iniciada";
            toolStripPBEstado.Value = (int)(toolStripPBEstado.Maximum) / 3;
            habilitarBotones(false, false, true, true, false, false, false, false, true, true);
            fProductosBusqueda.LabelNombrePersonaTransaccion.Text = this.cBoxCliente.Text;
            fProductosBusqueda.LabelNumeroTransaccion.Text = this.NumeroVentaProducto.ToString();

            if (rBtnCredito.Checked)
                fProductosBusqueda.LabelTipoTransaccion.Text = "Crédito";
            if (rBtnEfectivo.Checked)
                fProductosBusqueda.LabelTipoTransaccion.Text = "Efectivo";
            this.txtBoxPrecioTotal.Text = fProductosBusqueda.LabelPrecioTotal.Text;
            habilitarControles(true);
            if (CodigoTipoVenta == 'T')
                rBtnCredito.Enabled = false;
            fProductosBusqueda.ShowDialog(this);


            if (fProductosBusqueda.DTProductosSeleccionados.Rows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ningún Producto para su Venta, se procederá a cancelar la operación Actual");
                btnCancelar_Click(sender, e);
                return;
            }
            
            if (fProductosBusqueda.detalleConfirmado)
            {
                checkBIncluirFactura.Checked = fProductosBusqueda.CheckConFactura.Checked;
                cBoxMoneda.SelectedValue = fProductosBusqueda.CBoxMonedas.SelectedValue;

                string MascaraMonedaCotizacion = DTMonedas.Rows.Find(fProductosBusqueda.CBoxMonedas.SelectedValue)["MascaraMoneda"].ToString();
                this.txtBoxPrecioTotal.Text = DTVentasProductosDetalleTemporalVisualizacion.Compute("sum(PrecioTotal)", "VendidoComoAgregado = false").ToString() + " " + MascaraMonedaCotizacion;
                this.txtBoxPrecioTotalCancelar.Text = DTVentasProductosDetalleTemporalVisualizacion.Compute("sum(PrecioTotal)", "").ToString() + " " + MascaraMonedaCotizacion;
                this.tabControl1.TabIndex = 0;

            }
            else
            {
                this.txtBoxPrecioTotal.Text = " 0.00 " + DTMonedas.FindByCodigoMoneda((byte)CodigoMonedaSistema).MascaraMoneda;
                this.txtBoxPrecioTotalCancelar.Text = " 0.00 " + DTMonedas.FindByCodigoMoneda((byte)CodigoMonedaSistema).MascaraMoneda;
                lblNumeroVenta.Text = "";
                toolStripPBEstado.Value = 0;
            }
            tabControl1.SelectedIndex = 0;
            revisarProductosInalcanzables();
            cBoxCliente.Focus();
        }

        public void revisarProductosInalcanzables()
        {
            if (fProductosBusqueda.ExistenProductosInalcanzables)
            {

                dGVProductosSeleccionados.Columns[4].Width = 90;
                dGVProductosSeleccionados.ReadOnly = false;
                foreach (DataGridViewColumn columna in dGVProductosSeleccionados.Columns)
                    columna.ReadOnly = true;

                if (!DGCCantidadEntregada.Visible)
                    DGCCantidadEntregada.Visible = true;
                DGCCantidadEntregada.HeaderText = "Entregados";
                DGCCantidadEntregada.Width = 70;
                DGCCantidadEntregada.ReadOnly = false;
                DGCCantidadEntregada.DisplayIndex = 3;

                int CantidadVendida = 0;
                int CantidadEntregada = 0;
                int CantidadExistencia = 0;
                foreach (DataRow fila in fProductosBusqueda.DTProductosSeleccionados.Rows)
                {
                    CantidadVendida = Int32.Parse(fila["Cantidad"].ToString());
                    CantidadExistencia = Int32.Parse(fila["CantidadExistencia"].ToString());//CantidadEntregada
                    if (CantidadVendida > CantidadExistencia)
                    {
                        CantidadEntregada = CantidadExistencia;
                        fila["CantidadEntregada"] = CantidadEntregada;
                    }
                    else
                    {
                        fila["CantidadEntregada"] = CantidadVendida;
                    }

                }
            }
            else
            {
                //para cuando se debe revisar los otros casos                
                int CantidadExistencia = 0;
                foreach (DataRow fila in fProductosBusqueda.DTProductosSeleccionados.Rows)
                {
                    CantidadExistencia = Int32.Parse(fila["CantidadExistencia"].ToString());//CantidadEntregada
                    if (CantidadExistencia == 0)
                    {
                        fila["CantidadEntregada"] = 0;
                    }
                }
            }

        }

        public void formatearEstiloTabla()
        {
            DGCCodigoProductoD.Width = 80;
            DGCCodigoProductoD.ToolTipText = "Código del Producto Seleccionado";
            DGCCodigoProductoD.HeaderText = "Código";
            DGCCodigoProductoD.DataPropertyName = "Código Producto";

            DGCNombreProductoD.Width = 320;
            DGCNombreProductoD.ToolTipText = "Nombre del Producto Seleccionado";
            DGCNombreProductoD.HeaderText = "Nombre Producto";
            DGCNombreProductoD.DataPropertyName = "Nombre Producto";

            
            DGCCantidadVenta.ToolTipText = "Catidad Seleccionada a ser vendida";
            DGCCantidadVenta.HeaderText = "Vendidos";
            DGCCantidadVenta.DataPropertyName = "Cantidad";

            
            DGCPrecioUnitarioVentaD.ToolTipText = "Precio del Producto Seleccionado";
            DGCPrecioUnitarioVentaD.HeaderText = "Precio";
            DGCPrecioUnitarioVentaD.DataPropertyName = "Precio";

            
            DGCTiempoGarantiaVentaD.DataPropertyName = "Garantia";

            DGCPrecioTotal.HeaderText = "Precio Total";
            DGCPrecioTotal.ReadOnly = true;
            DGCPrecioTotal.ToolTipText = "Precio Total del la Venta del Producto Seleccionado";
            DGCPrecioTotal.DataPropertyName = "PrecioTotal";

            //DGCCantidadEntregada.Width = 80;
            DGCCantidadEntregada.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            DGCCantidadEntregada.ToolTipText = "Catidad Seleccionada que debe ser entregada";
            DGCCantidadEntregada.HeaderText = "Entregados";
            DGCCantidadEntregada.DataPropertyName = "CantidadEntregada";
        }

        void entregaInstitucionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable DTVentasProductos = _VentasProductosCLN.ListarVentaProductoReporte(NumeroAgencia, NumeroVentaProducto);            
            DataTable DTVentasProductosDetalle = _VentasProductosDetalleCLN.ListarVentaProductoDetalleReporteIncluidoEspecificos(NumeroAgencia, NumeroVentaProducto, "S", true, false);
            DataTable DTDatosAgencia = new CLCLN.Sistema.AgenciasCLN().ListarDatosAgenciasParaTransaccionesReportes(NumeroAgencia);            
            FReporteVentasProductosGeneral formReporteVentasProductos = new FReporteVentasProductosGeneral(DTDatosAgencia, DTVentasProductos, DTVentasProductosDetalle, 'T');
            formReporteVentasProductos.ShowDialog(this);
        }

        void reciboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable DTVentasProductos = _VentasProductosCLN.ListarVentaProductoReporte(NumeroAgencia, NumeroVentaProducto);
            DataTable DTVentasProductosDetalle = _VentasProductosDetalleCLN.ListarVentaProductoDetalleReporteIncluidoAgregados(NumeroAgencia, NumeroVentaProducto, "S", true, false);
            DataTable DTDatosAgencia = new CLCLN.Sistema.AgenciasCLN().ListarDatosAgenciasParaTransaccionesReportes(NumeroAgencia);
            //FReporteVentasProductosGeneral formReporteVentasProductos = new FReporteVentasProductosGeneral(DTDatosAgencia, DTVentasProductos, VentaUtilidadesCLN.ObtenerListaProductosParaCambiarMoneda(NumeroAgencia,null, DTVentasProductosDetalle), 'R');
            FReporteVentasProductosGeneral formReporteVentasProductos = new FReporteVentasProductosGeneral(DTDatosAgencia, DTVentasProductos, DTVentasProductosDetalle, 'R');
            formReporteVentasProductos.ShowDialog(this);
        }

        void sinAgregadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable DTVentasProductos = _VentasProductosCLN.ListarVentaProductoReporte(NumeroAgencia, NumeroVentaProducto);
            DataTable DTVentasProductosDetalle = _VentasProductosDetalleCLN.ListarVentaProductoDetalleReporteIncluidoAgregados(NumeroAgencia, NumeroVentaProducto, "S", false, true);
            DataTable DTDatosAgencia = new CLCLN.Sistema.AgenciasCLN().ListarDatosAgenciasParaTransaccionesReportes(NumeroAgencia);
            FReporteVentasProductosGeneral formReporteVentasProductos = new FReporteVentasProductosGeneral(DTDatosAgencia, DTVentasProductos, DTVentasProductosDetalle, 'F');
            formReporteVentasProductos.ShowDialog(this);
        }

        void incluirAgregadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable DTVentasProductos = _VentasProductosCLN.ListarVentaProductoReporte(NumeroAgencia, NumeroVentaProducto);
            DataTable DTVentasProductosDetalle = _VentasProductosDetalleCLN.ListarVentaProductoDetalleReporteIncluidoAgregados(NumeroAgencia, NumeroVentaProducto, "S", true, true);
            DataTable DTDatosAgencia = new CLCLN.Sistema.AgenciasCLN().ListarDatosAgenciasParaTransaccionesReportes(NumeroAgencia);
            FReporteVentasProductosGeneral formReporteVentasProductos = new FReporteVentasProductosGeneral(DTDatosAgencia, DTVentasProductos, DTVentasProductosDetalle, 'F');
            formReporteVentasProductos.ShowDialog(this);
        }

        void informeGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable DTVentasProductos = _VentasProductosCLN.ListarVentaProductoReporte(NumeroAgencia, NumeroVentaProducto);
            DataTable DTVentasProductosDetalle = _VentasProductosDetalleCLN.ListarVentaProductoDetalleReporte(NumeroAgencia, NumeroVentaProducto);
            DataTable DTVentasProductosAgregados = _VentasProductosEspecificosAgregadosCLN.ListarVentasProductosEspecificosAgregadosReportes(NumeroAgencia, NumeroVentaProducto);
            FReporteVentasProductosGeneral formReporteVentasProductos = new FReporteVentasProductosGeneral(DTVentasProductosAgregados, DTVentasProductos, DTVentasProductosDetalle, 'G');
            formReporteVentasProductos.ShowDialog(this);
        }

        void btnCambiarMoneda_Click(object sender, EventArgs e)
        {
            FCambiarMonedaCotizacionDeTransaccionesGC formCambioMoneda;
            if (btnAceptar.Enabled)
            {
                formCambioMoneda = new FCambiarMonedaCotizacionDeTransaccionesGC(DTVentasProductosDetalleTemporalMonedaSistema, NumeroPC, NumeroAgencia, NumeroVentaProducto, _TransaccionesUtilidadesCLN, 'I');
            }
            else
            {
                formCambioMoneda = new FCambiarMonedaCotizacionDeTransaccionesGC(DTVentasProductosDetalle, NumeroPC, NumeroAgencia, NumeroVentaProducto, _TransaccionesUtilidadesCLN, 'F');
            }
            formCambioMoneda.DarEstiloParaVentas();
            formCambioMoneda.ShowDialog(this);
            formCambioMoneda.Dispose();
        }

        void btnBuscar_Click(object sender, EventArgs e)
        {
            FBuscarTransaccion formBuscarTransaccion = new FBuscarTransaccion(NumeroAgencia);
            formBuscarTransaccion.formatearEstiloParaVentas();
            formBuscarTransaccion.ShowDialog(this);
            NumeroVentaProducto = formBuscarTransaccion.NumeroTransaccion;
            cargarDatosVentasProductos(NumeroVentaProducto);
            formBuscarTransaccion.Dispose();
        }

        public void habilitarBotones(bool nuevo, bool institucional, bool editar, bool cancelar, bool anular, bool finalizar, bool reportes, bool buscar, bool otraMoneda, bool aceptar)
        {
            btnNuevaVenta.Enabled = nuevo;
            btnVentaInstitucional.Enabled = institucional;
            btnModificar.Enabled = editar;
            btnCancelar.Enabled = cancelar;
            btnAnular.Enabled = anular;
            btnFinalizar.Enabled = finalizar;
            btnReportes.Enabled = reportes;
            btnBuscar.Enabled = buscar;
            btnPagar.Enabled = otraMoneda;
            btnAceptar.Enabled = aceptar;
        }

        public void habilitarControles(bool EstadoHabilitacion)
        {
            txtBoxObservaciones.ReadOnly = !EstadoHabilitacion;
            rBtnCredito.Enabled = EstadoHabilitacion;
            rBtnEfectivo.Enabled = EstadoHabilitacion;
            tabControl1.Controls[1].Enabled = !EstadoHabilitacion;
            tabControl1.Controls[2].Enabled = !EstadoHabilitacion;
            btnAgregarCliente.Enabled = EstadoHabilitacion;
            btnClientesBuscar.Enabled = EstadoHabilitacion;
        }


        public void LimpiarCampos()
        {
            cBoxMoneda.SelectedValue = CodigoMonedaSistema;
            string MascaraMonedaSistema = DTMonedas.FindByCodigoMoneda((byte)CodigoMonedaSistema).MascaraMoneda;
            checkBIncluirFactura.Checked = false;
            cBoxMoneda.SelectedIndex = -1;
            cBoxVendedor.SelectedIndex = -1;
            cBoxCliente.SelectedIndex = -1;
            rBtnEfectivo.Checked = false;
            rBtnCredito.Checked = false;
            txtBoxObservaciones.Text = "";
            tabControl1.SelectedIndex = 0;
            txtBoxPrecioTotal.Text = "0.00" + " " + MascaraMonedaSistema;
            txtBoxPrecioTotalCancelar.Text = "0.00" + " " + MascaraMonedaSistema;
            txtBoxPrecioAgregados.Text = "0.00" + " " + MascaraMonedaSistema;
            txtBoxMontoDisponibleCredito.Text = "0.00" + " " + MascaraMonedaSistema;
            txtBoxMontoPagoCredito.Text = "0.00" + " " + MascaraMonedaSistema;
            txtBoxMontoTotalCredito.Text = "0.00" + " " + MascaraMonedaSistema;

            DTVentasProductosDetalleTemporalMonedaSistema.Clear();
            DTVentasProductosDetalleTemporalMonedaSistema.AcceptChanges();
            DTVentasProductosDetalleTemporalVisualizacion.Clear();
            DTVentasProductosDetalleTemporalVisualizacion.AcceptChanges();
        }

        public bool validarCampos()
        {
            errorProvider1.Clear();
            if (cBoxCliente.SelectedIndex == -1)
            {
                errorProvider1.SetError(cBoxCliente, "Aún no ha Seleccionado ningun Cliente");
                cBoxCliente.Focus();
                return false;
            }
            if (!rBtnCredito.Checked && !rBtnEfectivo.Checked)
            {
                errorProvider1.SetError(rBtnEfectivo, "Aún no ha seleccionado el Tipo de Venta que desea Realizar");
                rBtnEfectivo.Checked = true;
                rBtnEfectivo.Focus();
                return false;
            }
            return true;
        }

        public void cargarDatosDetalle()
        {
            

            DTVentasProductosEspecificos = (DSDoblones20GestionComercial.ListarVentasProductosEspecificosParaVentaDataTable)
                _VentasProductosEspecificosCLN.ListarVentasProductosEspecificosParaVenta(NumeroAgencia, NumeroVentaProducto);


            bdSourceVentaProductosEspecificos.DataSource = DTVentasProductosEspecificos;

            DGCCantidadEntregada.Visible = DGCPorcentajeDescuento.Visible = DGCProductoSeleccionado.Visible = true;

            DGCCantidadEntregada.DataPropertyName = "CantidadEntregada";
            DGCCantidadVenta.DataPropertyName = "CantidadVenta";
            DGCCodigoProductoD.DataPropertyName = "CodigoProducto";
            DGCNombreProductoD.DataPropertyName = "NombreProducto";
            DGCPorcentajeDescuento.DataPropertyName = "PorcentajeDescuento";
            DGCPrecioTotal.DataPropertyName = "PrecioTotal";
            //DGCPrecioUnitarioVentaD.DataPropertyName = "PrecioUnitarioVenta";            
            DGCPrecioUnitarioVentaD.DataPropertyName = "PrecioUnitarioVentaOtraMoneda";
            DGCTiempoGarantiaVentaD.DataPropertyName = "TiempoGarantiaVenta";

            entregaInstitucionalToolStripMenuItem.Visible = DTVentasProductos[0].CodigoTipoVenta.CompareTo("T") == 0;
            string MascaraMonedaVenta = DTMonedas.FindByCodigoMoneda(DTVentasProductos[0].CodigoMoneda).MascaraMoneda;

            //quitar esto si se habilita el otro sector
            //----------------------------------------------------------------------------------------------------
            bdSourceVentasProductosDetalle.DataSource = DTVentasProductosDetalle;
            this.dGVProductosSeleccionados.DataSource = bdSourceVentasProductosDetalle;

            txtBoxPrecioTotal.Text = DTVentasProductosDetalle.Compute("Sum(PrecioTotal)", "").ToString()
                + " " + MascaraMonedaVenta;

            txtBoxPrecioTotalCancelar.Text = DTVentasProductosDetalle.Compute("Sum(PrecioTotal)", "").ToString()
                + " " + MascaraMonedaVenta;
            //----------------------------------------------------------------------------------------------------



            #region Codigo que Anterior, que manejaba el cambio de Moneda, actualmente trabaja con el campo Auxiliar "PrecioUnitarioVentaOtraMoneda" de cuenta de "PrecioUnitarioVenta"
            //sector deshabilitado para el manejo perfecto de decimales en monedas
            //----------------------------------------------------------------------------------------------------
            //if (DTVentasProductos[0].CodigoMoneda != CodigoMonedaSistema)
            //{
            //    DSDoblones20GestionComercial.ListarVentasProductosDetalleParaVentaDataTable DTVentasProductosDetalleOtraMoneda =
            //        (DSDoblones20GestionComercial.ListarVentasProductosDetalleParaVentaDataTable)DTVentasProductosDetalle.Copy();
            //    decimal FactorCambioCotizacion = _TransaccionesUtilidadesCLN.ObtenerFactorCambioCotizacion(CodigoMonedaSistema,
            //            DTVentasProductos[0].FechaHoraVenta, DTVentasProductos[0].CodigoMoneda);
            //    if (FactorCambioCotizacion == -1)
            //        FactorCambioCotizacion = _TransaccionesUtilidadesCLN.ObtenerFactorCambioCotizacion(CodigoMonedaSistema,
            //        null, DTVentasProductos[0].CodigoMoneda);

            //    foreach (DSDoblones20GestionComercial.ListarVentasProductosDetalleParaVentaRow DRVentaProductoDetalle
            //        in DTVentasProductosDetalleOtraMoneda)
            //    {
            //        DRVentaProductoDetalle.PrecioUnitarioVenta = decimal.Round(DRVentaProductoDetalle.PrecioUnitarioVenta * FactorCambioCotizacion, 2);
            //    }

            //    bdSourceVentasProductosDetalle.DataSource = DTVentasProductosDetalleOtraMoneda;
            //    this.dGVProductosSeleccionados.DataSource = bdSourceVentasProductosDetalle;

            //    txtBoxPrecioTotal.Text = DTVentasProductosDetalleOtraMoneda.Compute("Sum(PrecioTotal)", "").ToString()
            //        + " " + MascaraMonedaVenta;

            //    txtBoxPrecioTotalCancelar.Text = DTVentasProductosDetalleOtraMoneda.Compute("Sum(PrecioTotal)", "").ToString()
            //        + " " + MascaraMonedaVenta;

            //}
            //else
            //{
            //    bdSourceVentasProductosDetalle.DataSource = DTVentasProductosDetalle;
            //    this.dGVProductosSeleccionados.DataSource = bdSourceVentasProductosDetalle;

            //    txtBoxPrecioTotal.Text = DTVentasProductosDetalle.Compute("Sum(PrecioTotal)", "").ToString()
            //        + " " + MascaraMonedaVenta;

            //    txtBoxPrecioTotalCancelar.Text = DTVentasProductosDetalle.Compute("Sum(PrecioTotal)", "").ToString()
            //        + " " + MascaraMonedaVenta;
            //}
            //---------------------------------------------------------------------------------------------------- 
            #endregion

            dGVProductosSeleccionados.DataSource = bdSourceVentasProductosDetalle;
            DTUsuarios = (DSDoblones20Sistema.UsuariosDataTable)_UsuariosCLN.ObtenerUsuario(DTVentasProductos[0].CodigoUsuario);
            DTUsuarios.Columns.Add("NombreCompleto", Type.GetType("System.String"), "Paterno + ' '+ Materno + ' ' + Nombres ");
            cBoxVendedor.DataSource = DTUsuarios;
            cBoxVendedor.SelectedValue = DTVentasProductos[0].CodigoUsuario;

            cBoxMoneda.SelectedValue = DTVentasProductos[0].CodigoMoneda;
            checkBIncluirFactura.Checked = !DTVentasProductos[0].IsNumeroFacturaNull();

            DTClientes = (DSDoblones20GestionComercial.ClientesDataTable)_ClientesCLN.ObtenerCliente(DTVentasProductos[0].CodigoCliente);
            cBoxCliente.DataSource = DTClientes;
            cBoxCliente.DisplayMember = "NombreCliente";
            cBoxCliente.ValueMember = "CodigoCliente";
            cBoxCliente.SelectedValue = DTVentasProductos[0].CodigoCliente;

            txtBoxObservaciones.Text = DTVentasProductos[0].IsObservacionesNull() ? "" : DTVentasProductos[0].Observaciones;

            lblNumeroVenta.Text = DTVentasProductos[0].NumeroVentaProducto.ToString();
            toolStripFechaVenta.Text = DTVentasProductos[0].FechaHoraVenta.ToString();

            if (DTVentasProductos[0].IsNumeroCreditoNull())
                rBtnEfectivo.Checked = true;
            else
                rBtnCredito.Checked = true;
            facturasToolStripMenuItem.Enabled = !DTVentasProductos[0].IsNumeroFacturaNull();
            switch (DTVentasProductos[0].CodigoEstadoVenta)
            {
                case "F":
                    habilitarBotones(true, true, false, false, false, false, true, true, true, false);
                    lblEstado.Text = "Finalizada";
                    toolStripPBEstado.Value = toolStripPBEstado.Maximum;

                    break;
                case "C":
                    habilitarBotones(true, true, false, false, false, false, true, true, true, false);
                    lblEstado.Text = "Venta de Confianza";
                    toolStripPBEstado.Value = toolStripPBEstado.Maximum / 3 + toolStripPBEstado.Maximum / 3;
                    break;
                case "D":
                    habilitarBotones(true, true, false, false, false, false, false, true, true, false);
                    lblEstado.Text = "Venta de Confianza en Espera";
                    toolStripPBEstado.Value = toolStripPBEstado.Maximum / 3 + toolStripPBEstado.Maximum / 3;
                    break;
                case "I":
                    lblEstado.Text = "Iniciada";
                    toolStripPBEstado.Value = toolStripPBEstado.Maximum / 3;

                    if (DTVentasProductos[0].IsNumeroCreditoNull())
                        habilitarBotones(true, true, permitirModificar, false, true, false, true, true, true, false);
                    else
                        habilitarBotones(true, true, permitirModificar && _VentasProductosCLN.EsPosibleModificarVentaProductos(NumeroAgencia, NumeroVentaProducto), false, true, false, true, true, true, false);
                    facturasToolStripMenuItem.Enabled = false;
                    break;
                case "A":
                    lblEstado.Text = "Anulada";
                    toolStripPBEstado.Value = toolStripPBEstado.Maximum;
                    habilitarBotones(true, true, false, false, false, false, false, true, true, false);
                    break;
                case "T":
                    habilitarBotones(true, true, permitirModificar, false, false, true, true, true, true, false);
                    lblEstado.Text = "Institucional";
                    toolStripPBEstado.Value = toolStripPBEstado.Maximum / 3;
                    facturasToolStripMenuItem.Enabled = !DTVentasProductos[0].IsNumeroFacturaNull();
                    break;
                case "P":
                    if(DTVentasProductos[0].IsNumeroCreditoNull())
                        habilitarBotones(true, true, false, false, false, false, true, true, true, false);
                    else
                        habilitarBotones(true, true, permitirModificar && _VentasProductosCLN.EsPosibleModificarVentaProductos(NumeroAgencia, NumeroVentaProducto), false, true, false, true, true, true, false);
                    lblEstado.Text = "Cancelada en Efectivo";
                    toolStripPBEstado.Value = toolStripPBEstado.Maximum / 3 + toolStripPBEstado.Maximum / 3;
                    facturasToolStripMenuItem.Enabled = !DTVentasProductos[0].IsNumeroFacturaNull();
                    break;
                default:

                    break;
            }
            habilitarControles(false);
        }

        public void cargarDatosVentasProductos(int NumeroVenta)
        {
            TipoOperacion = "";
            DTVentasProductos = (DSDoblones20GestionComercial.VentasProductosDataTable) _VentasProductosCLN.ObtenerVentaProducto(NumeroAgencia, NumeroVenta);
            if (DTVentasProductos.Count > 0)
            {
                NumeroVentaProducto = NumeroVenta;
                DTVentasProductosDetalle =(DSDoblones20GestionComercial.ListarVentasProductosDetalleParaVentaDataTable) _TransaccionesUtilidadesCLN.ListarDetalleDeVenta(NumeroAgencia, NumeroVentaProducto);
                DTVentasProductosDetalle.Columns.Add("PrecioTotal", typeof(decimal), "CantidadVenta*PrecioUnitarioVentaOtraMoneda");
                //DTVentasProductosDetalle.Columns.Add("PrecioTotal", typeof(decimal), "CantidadVenta*PrecioUnitarioVenta");
                
                //DTVentasProductosEspecificos = (DSDoblones20GestionComercial.ListarVentasProductosEspecificosParaVentaDataTable)
                //    _VentasProductosEspecificosCLN.ListarVentasProductosEspecificosParaVenta(NumeroAgencia, NumeroVentaProducto);
                               

                //bdSourceVentaProductosEspecificos.DataSource = DTVentasProductosEspecificos;

                //DGCCantidadEntregada.Visible = DGCPorcentajeDescuento.Visible = DGCProductoSeleccionado.Visible = true;

                //DGCCantidadEntregada.DataPropertyName = "CantidadEntregada";
                //DGCCantidadVenta.DataPropertyName = "CantidadVenta";
                //DGCCodigoProductoD.DataPropertyName = "CodigoProducto";
                //DGCNombreProductoD.DataPropertyName = "NombreProducto";
                //DGCPorcentajeDescuento.DataPropertyName = "PorcentajeDescuento";
                //DGCPrecioTotal.DataPropertyName = "PrecioTotal";
                //DGCPrecioUnitarioVentaD.DataPropertyName = "PrecioUnitarioVenta";
                //DGCTiempoGarantiaVentaD.DataPropertyName = "TiempoGarantiaVenta";

                //entregaInstitucionalToolStripMenuItem.Visible = DTVentasProductos[0].CodigoTipoVenta.CompareTo("T") == 0;
                //string MascaraMonedaVenta = DTMonedas.FindByCodigoMoneda(DTVentasProductos[0].CodigoMoneda).MascaraMoneda;
                //if (DTVentasProductos[0].CodigoMoneda != CodigoMonedaSistema)
                //{
                //    DSDoblones20GestionComercial.ListarVentasProductosDetalleParaVentaDataTable DTVentasProductosDetalleOtraMoneda =
                //        (DSDoblones20GestionComercial.ListarVentasProductosDetalleParaVentaDataTable)DTVentasProductosDetalle.Copy();
                //    decimal FactorCambioCotizacion = _TransaccionesUtilidadesCLN.ObtenerFactorCambioCotizacion(CodigoMonedaSistema,
                //            DTVentasProductos[0].FechaHoraVenta, DTVentasProductos[0].CodigoMoneda);
                //    if (FactorCambioCotizacion == -1)
                //        FactorCambioCotizacion = _TransaccionesUtilidadesCLN.ObtenerFactorCambioCotizacion(CodigoMonedaSistema,
                //        null, DTVentasProductos[0].CodigoMoneda);

                //    foreach (DSDoblones20GestionComercial.ListarVentasProductosDetalleParaVentaRow DRVentaProductoDetalle
                //        in DTVentasProductosDetalleOtraMoneda)
                //    {
                //        DRVentaProductoDetalle.PrecioUnitarioVenta = decimal.Round(DRVentaProductoDetalle.PrecioUnitarioVenta * FactorCambioCotizacion, 2);
                //    }

                //    bdSourceVentasProductosDetalle.DataSource = DTVentasProductosDetalleOtraMoneda;
                //    this.dGVProductosSeleccionados.DataSource = bdSourceVentasProductosDetalle;

                //    txtBoxPrecioTotal.Text = DTVentasProductosDetalleOtraMoneda.Compute("Sum(PrecioTotal)", "").ToString()
                //        + " " + MascaraMonedaVenta;

                //    txtBoxPrecioTotalCancelar.Text = DTVentasProductosDetalleOtraMoneda.Compute("Sum(PrecioTotal)", "").ToString()
                //        + " " + MascaraMonedaVenta;

                //}
                //else
                //{
                //    bdSourceVentasProductosDetalle.DataSource = DTVentasProductosDetalle;
                //    this.dGVProductosSeleccionados.DataSource = bdSourceVentasProductosDetalle;

                //    txtBoxPrecioTotal.Text = DTVentasProductosDetalle.Compute("Sum(PrecioTotal)", "").ToString()
                //        + " " + MascaraMonedaVenta;

                //    txtBoxPrecioTotalCancelar.Text = DTVentasProductosDetalle.Compute("Sum(PrecioTotal)", "").ToString()
                //        + " " + MascaraMonedaVenta;
                //}

                //dGVProductosSeleccionados.DataSource = bdSourceVentasProductosDetalle;
                //DTUsuarios = (DSDoblones20Sistema.UsuariosDataTable)_UsuariosCLN.ObtenerUsuario(DTVentasProductos[0].CodigoUsuario);
                //DTUsuarios.Columns.Add("NombreCompleto", Type.GetType("System.String"), "Paterno + ' '+ Materno + ' ' + Nombres ");
                //cBoxVendedor.DataSource = DTUsuarios;
                //cBoxVendedor.SelectedValue = DTVentasProductos[0].CodigoUsuario;

                //cBoxMoneda.SelectedValue = DTVentasProductos[0].CodigoMoneda;
                //checkBIncluirFactura.Checked = !DTVentasProductos[0].IsNumeroFacturaNull();
                
                //DTClientes = (DSDoblones20GestionComercial.ClientesDataTable)_ClientesCLN.ObtenerCliente(DTVentasProductos[0].CodigoCliente);
                //cBoxCliente.DataSource = DTClientes;
                //cBoxCliente.DisplayMember = "NombreCliente";
                //cBoxCliente.ValueMember = "CodigoCliente";
                //cBoxCliente.SelectedValue = DTVentasProductos[0].CodigoCliente;

                //txtBoxObservaciones.Text = DTVentasProductos[0].IsObservacionesNull() ? "" : DTVentasProductos[0].Observaciones;

                //lblNumeroVenta.Text = DTVentasProductos[0].NumeroVentaProducto.ToString();
                //toolStripFechaVenta.Text = DTVentasProductos[0].FechaHoraVenta.ToString();

                
                //facturasToolStripMenuItem.Enabled = !DTVentasProductos[0].IsNumeroFacturaNull();
                //switch (DTVentasProductos[0].CodigoEstadoVenta)
                //{
                //    case "F":
                //        habilitarBotones(true, true, false, false, false, false, true, true, true, false);
                //        lblEstado.Text = "Finalizada";
                //        toolStripPBEstado.Value = toolStripPBEstado.Maximum;
                        
                //        break;
                //    case "C":
                //        habilitarBotones(true, true, false, false, false, false, true, true, true, false);
                //        lblEstado.Text = "Venta de Confianza";
                //        toolStripPBEstado.Value = toolStripPBEstado.Maximum / 3 + toolStripPBEstado.Maximum / 3;
                //        break;
                //    case "D":
                //        habilitarBotones(true, true, false, false, false, false, false, true, true, false);
                //        lblEstado.Text = "Venta de Confianza en Espera";
                //        toolStripPBEstado.Value = toolStripPBEstado.Maximum / 3 + toolStripPBEstado.Maximum / 3;
                //        break;
                //    case "I":
                //        lblEstado.Text = "Iniciada";
                //        toolStripPBEstado.Value = toolStripPBEstado.Maximum / 3;
                        
                //        if (DTVentasProductos[0].IsNumeroCreditoNull())                            
                //            habilitarBotones(true, true, permitirModificar, false, true, false, true, true, true, false);
                //        else                            
                //        habilitarBotones(true, true, permitirModificar && _VentasProductosCLN.EsPosibleModificarVentaProductos(NumeroAgencia, NumeroVentaProducto), false, true, false, true, true, true, false);
                //        facturasToolStripMenuItem.Enabled = false;
                //        break;
                //    case "A": 
                //        lblEstado.Text = "Anulada";
                //        toolStripPBEstado.Value = toolStripPBEstado.Maximum;
                //        habilitarBotones(true, true, false, false, false, false, false, true, true, false);
                //        break;
                //    case "T":
                //        habilitarBotones(true, true, permitirModificar, false, false, true, true, true, true, false);
                //        lblEstado.Text = "Institucional";
                //        toolStripPBEstado.Value = toolStripPBEstado.Maximum / 3;
                //        facturasToolStripMenuItem.Enabled = !DTVentasProductos[0].IsNumeroFacturaNull();
                //        break;
                //    case "P":                        
                //        habilitarBotones(true, true, false, false, false, false, true, true, true, false);
                //        lblEstado.Text = "Cancelada en Efectivo";
                //        toolStripPBEstado.Value = toolStripPBEstado.Maximum / 3 + toolStripPBEstado.Maximum / 3;
                //        facturasToolStripMenuItem.Enabled = !DTVentasProductos[0].IsNumeroFacturaNull();
                //        break;
                //    default:
                        
                //        break;
                //}
                //habilitarControles(false);
                cargarDatosDetalle();


            }
            else
            {
                LimpiarCampos();
                habilitarControles(false);
                habilitarBotones(true, true, false, false, false, false, false, true, false, false);
                DTVentasProductosDetalle.Clear();
                DTVentasProductosDetalleTemporalMonedaSistema.Clear();
                DTVentasProductosDetalleTemporalVisualizacion.Clear();
                DTVentasProductosEspecificos.Clear();
            }
        }

        private void dGVProductosEspecificos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (DTVentasProductosEspecificos.Rows.Count > 0)
            //{

            //    if (dGVProductosEspecificos.Rows[e.RowIndex].Cells[DGCNombreProductoEspecifico.Index].Value != null && !dGVProductosEspecificos.Rows[e.RowIndex].Cells[DGCNombreProductoEspecifico.Index].Value.Equals(""))
            //    {
            //        dGVProductosEspecificos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Bisque;
            //        dGVProductosEspecificos.Rows[e.RowIndex].Cells["DGCNombreProductoEspecifico"].Style.Font = new Font(dtGVProductosAgregados.Font.Name, dtGVProductosAgregados.Font.Size, FontStyle.Bold);
            //    }
            //}
        }

        private void btnBuscarProductoEspecifico_Click(object sender, EventArgs e)
        {
            if (DTVentasProductosEspecificos.Count > 0)
            {
                string CodigoProductoEspecifico = txtBoxCodEspecifico.Text;
                DataRow DRProductoEspecifico = DTVentasProductosEspecificos.FindByCódigo_Específico(CodigoProductoEspecifico);
                if (DRProductoEspecifico != null)
                {
                    dGVProductosEspecificos.CurrentCell = dGVProductosEspecificos[0, DTVentasProductosEspecificos.Rows.IndexOf(DRProductoEspecifico)];
                    dGVProductosEspecificos.CurrentRow.Selected = true;
                    dGVProductosEspecificos.FirstDisplayedScrollingRowIndex = DTVentasProductosEspecificos.Rows.IndexOf(DRProductoEspecifico);
                }
                else
                {
                    dGVProductosEspecificos.FirstDisplayedScrollingRowIndex = 0;
                    dGVProductosEspecificos.ClearSelection();
                }
            }
        }

        public void emitirPermisos(bool permitirVender, bool permitirVenderInstituciones, bool permitirAnular, bool permitirModificar, bool permitirReportes, bool permitirNavegar, bool permitirPagar)
        {
            btnNuevaVenta.Visible = permitirVender;
            btnVentaInstitucional.Visible = permitirVenderInstituciones;
            btnAnular.Visible = permitirAnular;
            btnModificar.Visible = permitirModificar;
            btnReportes.Visible = permitirReportes;
            btnBuscar.Visible = permitirNavegar;
            btnFinalizar.Visible = permitirPagar;
            this.permitirModificar = permitirModificar;
        }

        public void CargarConfiguracionInicial(string NombreMonedaSistema, int CodigoMonedaSistema, string MascaraMonedaSistema, int CodigoMonedaRegion, string NombreMonedaRegion, string MascaraMonedaRegion, decimal PorcentajeImpuestoSistema)
        {
            this.NombreMonedaSistema = NombreMonedaSistema;
            this.CodigoMonedaSistema = CodigoMonedaSistema;
            this.MascaraMonedaSistema = MascaraMonedaSistema;
            this.CodigoMonedaRegion = CodigoMonedaRegion;
            this.NombreMonedaRegion = NombreMonedaRegion;
            this.MascaraMonedaRegion = MascaraMonedaRegion;
            this.PorcentajeImpuestoSistema = PorcentajeImpuestoSistema;
        }


        public void ListarDetalledeCotizacionParaVenta(DSDoblones20GestionComercial.CotizacionVentasProductosDataTable DTCotizacionVentaProducto2,
            DSDoblones20GestionComercial.ListarCotizacionesProductosDetalleParaCotizacionesDataTable DTCotizacionVentaProductoDetalle2, 
            string TipoCotizacion, object sender, EventArgs e)
        {

            if (TipoCotizacion.Equals("T"))
            {
                CodigoTipoVenta = TipoCotizacion[0];
            }


            if (TipoCotizacion.Equals("T"))
                fProductosBusqueda.inhabilitarControlesParaCotizacion(true);
            else
                fProductosBusqueda.inhabilitarControlesParaCotizacion(false);

            DTVentasProductos.Clear();            
            DTVentasProductos.AcceptChanges();
            DTVentasProductosDetalle.Clear();
            DTVentasProductosDetalle.AcceptChanges();

            int NumeroVenta = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("VentasProductos") + 1;
            foreach (DSDoblones20GestionComercial.CotizacionVentasProductosRow DRCotizacion
                in DTCotizacionVentaProducto2)
            {
                DSDoblones20GestionComercial.VentasProductosRow DRVenta = DTVentasProductos.NewVentasProductosRow();

                DRVenta.NumeroAgencia = DRCotizacion.NumeroAgencia;
                DRVenta.NumeroVentaProducto = NumeroVenta;
                DRVenta.Observaciones = DRCotizacion.Observaciones;
                DRVenta.CodigoCliente = DRCotizacion.CodigoCliente;
                DRVenta.CodigoUsuario = DRCotizacion.CodigoUsuario;
                if (DRCotizacion.ConFactura)
                    DRVenta.NumeroFactura = -1;
                DRVenta.FechaHoraVenta = _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor();
                DRVenta.CodigoEstadoVenta = "I";
                DRVenta.MontoTotalVenta = DRCotizacion.MontoTotalCotizacion;
                DRVenta.CodigoMoneda = DRCotizacion.CodigoMonedaCotizacionVenta;
                DRVenta.CodigoTipoVenta = DRCotizacion.CodigoTipoCotizacion;

                DTVentasProductos.AddVentasProductosRow(DRVenta);
                DRVenta.AcceptChanges();

            }

            foreach (DSDoblones20GestionComercial.ListarCotizacionesProductosDetalleParaCotizacionesRow DRCotizacionProducto
                in DTCotizacionVentaProductoDetalle2)
            {
                DSDoblones20GestionComercial.ListarVentasProductosDetalleParaVentaRow
                    DRVentaProducto = DTVentasProductosDetalle.NewListarVentasProductosDetalleParaVentaRow();

                DRVentaProducto.NumeroAgencia = DRCotizacionProducto.NumeroAgencia;
                DRVentaProducto.NumeroVentaProducto = NumeroVenta;
                DRVentaProducto.CodigoProducto = DRCotizacionProducto.CodigoProducto;
                DRVentaProducto.CantidadVenta = DRCotizacionProducto.CantidadCotizacionVenta;
                DRVentaProducto.CantidadEntregada = DRCotizacionProducto.CantidadCotizacionVenta;
                DRVentaProducto.PrecioUnitarioVenta = DRCotizacionProducto.PrecioUnitarioCotizacionVenta;
                DRVentaProducto.TiempoGarantiaVenta = DRCotizacionProducto.TiempoGarantiaCotizacionVenta;
                DRVentaProducto["PorcentajeDescuento"] = DRCotizacionProducto.PorcentajeDescuento;
                DRVentaProducto["NumeroPrecioSeleccionado"] = DRCotizacionProducto.NumeroPrecioSeleccionado;
                DRVentaProducto.NombreProducto = DRCotizacionProducto.NombreProducto;
                DTVentasProductosDetalle.AddListarVentasProductosDetalleParaVentaRow(DRVentaProducto);
                DRVentaProducto.AcceptChanges();
            }

            DTVentasProductosDetalle.AcceptChanges();            
            cargarDatosDetalle();
            btnModificar_Click(sender, e);
            fProductosBusqueda.habilitarEvento();
            btnAnular.Enabled = false;
            TipoOperacion = "N";
            EsCodigoTipoCreditoLibreDispocion = false;

        }

        private void papeletaDeRecojoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mostarReporteParaEntregaProductosAlmacenes();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            string EstadoVentaActual_deEntrega = _VentasProductosCLN.obtenerEstadoVentaFinalizadaParaAlmacenes(NumeroAgencia, NumeroVentaProducto);
            string CodigoEstadoVenta = DTVentasProductos[0].CodigoEstadoVenta;
                            
            if (CodigoEstadoVenta.Equals("I") || (EstadoVentaActual_deEntrega.Equals("T") && CodigoEstadoVenta.Equals("C")))
            {//si la venta se encuentra iniciada o ya ha sido entregada en una venta institucional como de Confianza
                FVentasProductosFinalizarContador formVentasProductosFinalizarContador = new FVentasProductosFinalizarContador(NumeroAgencia, CodigoUsuario, NumeroVentaProducto, NumeroPC);
                formVentasProductosFinalizarContador.CargarConfiguracionInicial(NombreMonedaSistema, CodigoMonedaSistema, MascaraMonedaSistema, CodigoMonedaRegion, NombreMonedaRegion, MascaraMonedaRegion, PorcentajeImpuestoSistema);
                formVentasProductosFinalizarContador.ShowDialog(this);
                formVentasProductosFinalizarContador.Dispose();


                if(_TransaccionesUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(NumeroAgencia, NumeroVentaProducto, "V").CompareTo(CodigoEstadoVenta) != 0)
                {
                    cargarDatosVentasProductos(NumeroVentaProducto);
                    btnPagar.Enabled = false;
                }

            }
        }

        private void productosCompuestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListarVentaProductoCompuestosDetalleReporte();
        }



   

        

    }



    //public class TiposAgregados
    //{
    //    private string _CodigoTipoAgregado;
    //    public string CodigoTipoAgregado
    //    {
    //        get { return _CodigoTipoAgregado; }
    //        set { this._CodigoTipoAgregado = value; }
    //    }

    //    private string _NombreAgregado;
    //    public string NombreAgregado
    //    {
    //        get { return _NombreAgregado; }
    //        set { this._NombreAgregado = value; }
    //    }


    //    public TiposAgregados(string codigo, string nombre)
    //    {
    //        this._CodigoTipoAgregado = codigo;
    //        this._NombreAgregado = nombre;
    //    }
    //}

}


