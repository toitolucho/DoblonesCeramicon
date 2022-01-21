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
using CLCLN.GestionComercial;
using CLCLN.Sistema;
using CLCAD;
namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FCotizacionesVentas2 : Form
    {
        CotizacionVentasProductosCLN _CotizacionVentasProductosCLN;
        CotizacionVentasProductosDetaCLN _CotizacionVentasProductosDetaCLN;
        TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;
        UsuariosCLN _UsuariosCLN;
        ClientesCLN _ClientesCLN;
        MonedasCLN _MonedasCLN;
        PCsConfiguracionesCLN PCConfiguracion;

        DSDoblones20GestionComercial.CotizacionVentasProductosDataTable DTCotizacionesProductos;
        DSDoblones20GestionComercial.ListarCotizacionesProductosDetalleParaCotizacionesDataTable DTCotizacionesProductosDetalle;
        DSDoblones20GestionComercial.ClientesDataTable DTClientes;
        DSDoblones20Sistema.UsuariosDataTable DTUsuarios;
        DSDoblones20Sistema.MonedasDataTable DTMonedas;
        DataTable DTCotizacionProductosDetalleTemporalMonedaSistema;
        DataTable DTCotizacionProductosDetalleTemporalVisualizacion;
        DataTable VariablesConfiguracionSistemaGC;

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

        bool PermitirModificar = true;
        private int CodigoUsuario;
        private string CodigoTipoCotizacion = "N";
        bool cotizacionConFactura;
        int NumeroCotizacionProducto = 0;
        /// <summary>
        /// Agencia para la cual se realizará las transacciones
        /// </summary>
        private int NumeroAgencia = 1;
        private int NumeroPC = 0;       
        string TipoOperacion = "";
        ErrorProvider errorProviderCotizaciones;
        FProductosBusqueda2 fProductosBusqueda;

        public FCotizacionesVentas2(int NumeroAgencia, int NumeroPC, int CodigoUsuario)
        {
            this.NumeroAgencia = NumeroAgencia;
            this.NumeroPC = NumeroPC;
            this.CodigoUsuario = CodigoUsuario;

            errorProviderCotizaciones = new ErrorProvider();
            InitializeComponent();

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


            DTClientes = new DSDoblones20GestionComercial.ClientesDataTable();
            DTCotizacionesProductos = new DSDoblones20GestionComercial.CotizacionVentasProductosDataTable();
            DTCotizacionesProductosDetalle = new DSDoblones20GestionComercial.ListarCotizacionesProductosDetalleParaCotizacionesDataTable();
            DTUsuarios = new DSDoblones20Sistema.UsuariosDataTable();
            DTMonedas = new DSDoblones20Sistema.MonedasDataTable();
            DTCotizacionProductosDetalleTemporalMonedaSistema = new DataTable();
            DTCotizacionProductosDetalleTemporalVisualizacion = new DataTable();


            _ClientesCLN = new ClientesCLN();
            _CotizacionVentasProductosCLN = new CotizacionVentasProductosCLN();
            _CotizacionVentasProductosDetaCLN = new CotizacionVentasProductosDetaCLN();
            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();
            _UsuariosCLN = new UsuariosCLN();
            _MonedasCLN = new MonedasCLN();


            DTMonedas = (DSDoblones20Sistema.MonedasDataTable)_MonedasCLN.ListarMonedas();
            cBoxMonedas.DataSource = DTMonedas;
            cBoxMonedas.DisplayMember = "NombreMoneda";
            cBoxMonedas.ValueMember = "CodigoMoneda";
            cBoxMonedas.SelectedValue = CodigoMonedaSistema;

            checkBIncluirFactura.Enabled = cBoxCliente.Enabled = cBoxMonedas.Enabled = cBoxVendedor.Enabled = false;
            DGCNombreProducto.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;



            fProductosBusqueda = new FProductosBusqueda2(NumeroAgencia, NumeroPC, 'T', CodigoMonedaSistema, PorcentajeImpuestoSistema);
            DTCotizacionProductosDetalleTemporalMonedaSistema = DTCotizacionProductosDetalleTemporalVisualizacion = 
                fProductosBusqueda.DTProductosSeleccionados.Clone();
            cargarDatosCotizaciones(_TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("CotizacionVentasProductos"));

        }


        /// <summary>
        /// Se encarga de habilitar o deshabilitar los campos del formulario de Ventas
        /// </summary>
        /// <param name="EstadoHabilitacion"></param>
        public void habilitarCampos(bool EstadoHabilitacion)
        {
            
            txtBoxTiempoEntrega.Enabled = EstadoHabilitacion;
            txtDiazValidez.Enabled = EstadoHabilitacion;
            txtBoxObservaciones.ReadOnly = !EstadoHabilitacion;            
            btnBuscarCliente.Enabled = EstadoHabilitacion;
            btnRegistrarCliente.Enabled = EstadoHabilitacion;
            cMenuObservaciones.Enabled = !EstadoHabilitacion;
            checkBInmediata.Enabled = EstadoHabilitacion;
            
        }

        /// <summary>
        /// Método que se encarga de la correspondiente habilitacion de los botones que controlan
        /// la transacción de la Cotizacion, de acuerdo al Estado en que se encuentra la misma
        /// Pasar valores booleanoes en caso de desear habilitar TRUE, caso contrario FALSE
        /// </summary>
        /// <param name="nuevaCotizacion">Habilitar una Nueva Cotizacion</param>
        /// <param name="nuevaCotInstitucional">Habilitar una Nueva Cotización Institucional</param>
        /// <param name="nuevaDesdeOtra">Nueva Cotización a partir de una Cotización</param>
        /// <param name="modificar">Modificar la Cotizacion que se Cursa Actualmente</param>
        /// <param name="cancelar">Cancelar la Cotizacion</param>
        /// <param name="anular">Anular la Cotizacion</param>
        /// <param name="reporte">Mostrar Reportes</param>
        /// <param name="aceptar">Confirmar la Cotizacion para recibir el Monto de Pago</param>
        /// <param name="finalizar">Finalizar completamente la Cotizacion una vez terminada toda la Transacción</param>
        /// <param name="vender">Vender la Cotización Actual</param>
        /// <param name="buscar">Buscar una Cotización</param>
        private void habilitarBotonesCotizaciones(bool nuevaCotizacion, bool nuevaCotInstitucional, bool nuevaDesdeOtra, bool modificar, bool cancelar, bool anular, bool reporte, bool aceptar, bool finalizar, bool vender, bool buscar)
        {
            btnNuevaCotizacion.Enabled = nuevaCotizacion;
            btnCotizacionInstitucional.Enabled = nuevaCotInstitucional;
            btnNuevoDesdeOtraCotizacion.Enabled = nuevaDesdeOtra;
            btnModificar.Enabled = modificar;
            btnCancelar.Enabled = cancelar;
            btnAnular.Enabled = anular;
            btnReporte.Enabled = reporte;
            btnAceptar.Enabled = aceptar;
            btnFinalizar.Enabled = finalizar;

            btnVender.Enabled = vender;
            btnBuscar.Enabled = buscar;
        }


        public void limpiarCampos()
        {
            cBoxCliente.SelectedIndex = -1;
            cBoxMonedas.SelectedIndex = -1;
            cBoxVendedor.SelectedIndex = -1;
            txtBoxObservaciones.Text = txtBoxTiempoEntrega.Text = txtDiazValidez.Text = "";

            DTCotizacionProductosDetalleTemporalMonedaSistema.Clear();
            DTCotizacionProductosDetalleTemporalVisualizacion.Clear();
            
        }

        /// <summary>
        /// Se encarga de Cargar nuevamente los datos de la Base de datos
        /// para Actualizar el Formulario
        /// </summary>
        public void cargarDatosCotizaciones(int NumeroCotizacion)
        {

            DTCotizacionesProductos = (DSDoblones20GestionComercial.CotizacionVentasProductosDataTable)_CotizacionVentasProductosCLN.ObtenerCotizacionVentaProducto(NumeroAgencia, NumeroCotizacion);

            if (DTCotizacionesProductos.Count > 0)
            {
                NumeroCotizacionProducto = NumeroCotizacion;

                DTClientes = (DSDoblones20GestionComercial.ClientesDataTable)_ClientesCLN.ObtenerCliente(DTCotizacionesProductos[0].CodigoCliente);
                cBoxCliente.DataSource = DTClientes;
                cBoxCliente.DisplayMember = "NombreCliente";
                cBoxCliente.ValueMember = "CodigoCliente";
                cBoxCliente.SelectedValue = DTCotizacionesProductos[0].CodigoCliente;

                DTUsuarios = (DSDoblones20Sistema.UsuariosDataTable)_UsuariosCLN.ObtenerUsuario(DTCotizacionesProductos[0].CodigoUsuario);
                DTUsuarios.Columns.Add("NombreCompleto", Type.GetType("System.String"), "Paterno + ' ' + Materno + ' ' + Nombres");
                cBoxVendedor.DataSource = DTUsuarios;
                cBoxVendedor.DisplayMember = "NombreCompleto";
                cBoxVendedor.ValueMember = "CodigoUsuario";
                cBoxVendedor.SelectedValue = DTCotizacionesProductos[0].CodigoUsuario;


                lblNumeroCotizacion.Text = DTCotizacionesProductos[0].NumeroCotizacionVentaProducto.ToString();
                toolStripFechaCotizacion.Text = DTCotizacionesProductos[0].FechaHoraCotizacion.ToString();
                txtBoxTiempoEntrega.Text = DTCotizacionesProductos[0].TiempoEntrega.ToString();
                txtDiazValidez.Text = DTCotizacionesProductos[0].ValidezOferta.ToString();
                checkBInmediata.Checked = DTCotizacionesProductos[0].TiempoEntrega == 0;
                checkBIncluirFactura.Checked = DTCotizacionesProductos[0].ConFactura;
                lblTipoCotizacion.Text = DTCotizacionesProductos[0].CodigoTipoCotizacion.CompareTo("N") == 0 ? "COT. NORMAL" : "COT. INSTITUCIONAL";
                cBoxMonedas.SelectedValue = DTCotizacionesProductos[0].CodigoMonedaCotizacionVenta;
                txtBoxObservaciones.Text = DTCotizacionesProductos[0].IsObservacionesNull() ? "" : DTCotizacionesProductos[0].Observaciones;

                switch(this.DTCotizacionesProductos[0].CodigoEstadoCotizacion )
                {
                    case "F":
                        lblEstado.Text = "Finalizada";
                        toolStripPBEstado.Value = toolStripPBEstado.Maximum;
                        habilitarBotonesCotizaciones(true, true, true, false, false, false, true, false, false, true, true);
                        break;
                    case "C":
                        lblEstado.Text = "Cancelada";
                        toolStripPBEstado.Value = toolStripPBEstado.Maximum;
                        habilitarBotonesCotizaciones(true, true, true, false, false, false, false, false, false, false, true);
                        break;
                    case "I":
                        lblEstado.Text = "Iniciada";
                        toolStripPBEstado.Value = toolStripPBEstado.Maximum / 2;
                        habilitarBotonesCotizaciones(true, true, true, true, false, true, true, false, true, false, true);
                        break;
                    case "A":
                        lblEstado.Text = "Anulada";
                        toolStripPBEstado.Value = toolStripPBEstado.Maximum / 2;
                        habilitarBotonesCotizaciones(true, true, true, false, false, false, false, false, false, false, true);
                        break;
                }
                DTCotizacionesProductosDetalle = (DSDoblones20GestionComercial.ListarCotizacionesProductosDetalleParaCotizacionesDataTable)
                   _TransaccionesUtilidadesCLN.ListarDetalleDeCotizacion(NumeroAgencia, NumeroCotizacionProducto);
                bdSourceCotizacionesProductosDetalle.DataSource = DTCotizacionesProductosDetalle;

                //DTCotizacionesProductosDetalle.Columns.Add("PrecioTotal", typeof(decimal), "CantidadCotizacionVenta*PrecioUnitarioCotizacionVenta");
                DTCotizacionesProductosDetalle.Columns.Add("PrecioTotal", typeof(decimal), "CantidadCotizacionVenta*PrecioUnitarioCotizacionOtraMoneda");


                DGCCantidadVenta.DataPropertyName = "CantidadCotizacionVenta";
                DGCCodigoProducto.DataPropertyName = "CodigoProducto";
                DGCNombreProducto.DataPropertyName = "NombreProducto";
                DGCPorcentajeDescuento.DataPropertyName = "PorcentajeDescuento";
                DGCPrecioTotal.DataPropertyName = "PrecioTotal";
                //DGCPrecioUnitarioCotizacionVenta.DataPropertyName = "PrecioUnitarioCotizacionVenta";
                DGCPrecioUnitarioCotizacionVenta.DataPropertyName = "PrecioUnitarioCotizacionOtraMoneda";                
                DGCTiempoGarantiaCotizacionVenta.DataPropertyName = "TiempoGarantiaCotizacionVenta";

                
                string MascaraMonedaVenta = DTMonedas.FindByCodigoMoneda(DTCotizacionesProductos[0].CodigoMonedaCotizacionVenta).MascaraMoneda;
                this.dGVProductosSeleccionados.DataSource = bdSourceCotizacionesProductosDetalle;

                txtBoxPrecioTotal.Text = DTCotizacionesProductosDetalle.Compute("Sum(PrecioTotal)", "").ToString()
                    + " " + MascaraMonedaVenta;


                //if (DTCotizacionesProductos[0].CodigoMonedaCotizacionVenta != CodigoMonedaSistema)
                //{
                //    DSDoblones20GestionComercial.ListarCotizacionesProductosDetalleParaCotizacionesDataTable DTCotizacionProductosDetalleOtraMoneda =
                //        (DSDoblones20GestionComercial.ListarCotizacionesProductosDetalleParaCotizacionesDataTable)DTCotizacionesProductosDetalle.Copy();
                //    decimal FactorCambioCotizacion = _TransaccionesUtilidadesCLN.ObtenerFactorCambioCotizacion(CodigoMonedaSistema,
                //            DTCotizacionesProductos[0].FechaHoraCotizacion, DTCotizacionesProductos[0].CodigoMonedaCotizacionVenta);
                //    if (FactorCambioCotizacion == -1)
                //        FactorCambioCotizacion = _TransaccionesUtilidadesCLN.ObtenerFactorCambioCotizacion(CodigoMonedaSistema,
                //        null, DTCotizacionesProductos[0].CodigoMonedaCotizacionVenta);

                //    foreach (DSDoblones20GestionComercial.ListarCotizacionesProductosDetalleParaCotizacionesRow DRVentaProductoDetalle
                //        in DTCotizacionProductosDetalleOtraMoneda)
                //    {
                //        DRVentaProductoDetalle.PrecioUnitarioCotizacionVenta = decimal.Round(DRVentaProductoDetalle.PrecioUnitarioCotizacionVenta * FactorCambioCotizacion, 2);
                //    }

                //    bdSourceCotizacionesProductosDetalle.DataSource = DTCotizacionProductosDetalleOtraMoneda;
                //    this.dGVProductosSeleccionados.DataSource = bdSourceCotizacionesProductosDetalle;

                //    txtBoxPrecioTotal.Text = DTCotizacionProductosDetalleOtraMoneda.Compute("Sum(PrecioTotal)", "").ToString()
                //        + " " + MascaraMonedaVenta;

                //}
                //else
                //{
                //    bdSourceCotizacionesProductosDetalle.DataSource = DTCotizacionesProductosDetalle;
                //    this.dGVProductosSeleccionados.DataSource = bdSourceCotizacionesProductosDetalle;

                //    txtBoxPrecioTotal.Text = DTCotizacionesProductosDetalle.Compute("Sum(PrecioTotal)", "").ToString()
                //        + " " + MascaraMonedaVenta;
                //}
                
            }
            else
            {
                habilitarBotonesCotizaciones(true, true, true, false, false, false, false, false, false, false, true);
                limpiarCampos();

                DTCotizacionesProductos.Clear();
                DTCotizacionesProductosDetalle.Clear();
            }

            habilitarCampos(false);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FBuscarTransaccion formBuscarTransaccion = new FBuscarTransaccion(NumeroAgencia);
            formBuscarTransaccion.formatearEstiloParaCotizaciones();
            formBuscarTransaccion.ShowDialog(this);            
            if (formBuscarTransaccion.NumeroTransaccion > 0)
            {
                cargarDatosCotizaciones(formBuscarTransaccion.NumeroTransaccion);
                formBuscarTransaccion.Dispose();
            }
            else
            {
                MessageBox.Show(this, "No se encontro ninguna Cotización de Venta con los parametros o Descripción que usted Acaba de Ingresar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNuevaCotizacion_Click(object sender, EventArgs e)
        {
            fProductosBusqueda.inhabilitarControlesParaCotizacion(false);
            fProductosBusqueda.limpiarControles();
            cBoxMonedas.SelectedValue = CodigoMonedaSistema;
            TipoOperacion = "N";

            if ((sender as ToolStripButton).Name.CompareTo("btnNuevaCotizacion") == 0)
            {
                CodigoTipoCotizacion = "N";
                lblTipoCotizacion.Text = "COT. NORMAL";
            }
            else
            {
                CodigoTipoCotizacion = "T";
                lblTipoCotizacion.Text = "COT. INSTITUCIONAL";
            }

            checkBIncluirFactura.Checked = false;
            limpiarCampos();


            DTUsuarios = (DSDoblones20Sistema.UsuariosDataTable)_UsuariosCLN.ObtenerUsuario(CodigoUsuario);
            DTUsuarios.Columns.Add("NombreCompleto", Type.GetType("System.String"), "Paterno + ' '+ Materno + ' ' + Nombres ");
            cBoxVendedor.DataSource = DTUsuarios;
            cBoxVendedor.DisplayMember = "NombreCompleto";
            cBoxVendedor.ValueMember = "CodigoUsuario";
            cBoxVendedor.SelectedValue = CodigoUsuario;

            checkBIncluirFactura.Enabled = false;

            
            DGCCodigoProducto.DataPropertyName = "Código Producto";

            
            DTCotizacionProductosDetalleTemporalVisualizacion = fProductosBusqueda.DTProductosSeleccionados;
            DTCotizacionProductosDetalleTemporalMonedaSistema = fProductosBusqueda.DTProductosSeleccionadosMonedaSistema;

            bdSourceCotizacionesProductosDetalle.DataSource = DTCotizacionProductosDetalleTemporalVisualizacion;
            formatearEstiloTabla();
            NumeroCotizacionProducto = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("CotizacionVentasProductos");
            if (NumeroCotizacionProducto == 0) NumeroCotizacionProducto = 1;
            if (NumeroCotizacionProducto > 1)
                NumeroCotizacionProducto++;


            lblNumeroCotizacion.Text = NumeroCotizacionProducto.ToString();
            lblEstado.Text = "Iniciada";
            toolStripPBEstado.Value = (int)(toolStripPBEstado.Maximum) / 3;
            habilitarBotonesCotizaciones(false, false, false, true, true, false, false, true, false, false, false);
            fProductosBusqueda.LabelNombrePersonaTransaccion.Text = this.cBoxCliente.Text;
            fProductosBusqueda.LabelNumeroTransaccion.Text = this.NumeroCotizacionProducto.ToString();

            this.txtBoxPrecioTotal.Text = fProductosBusqueda.LabelPrecioTotal.Text;
            habilitarCampos(true);
            
            fProductosBusqueda.ShowDialog(this);


            if (fProductosBusqueda.DTProductosSeleccionados.Rows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ningún Producto para la Cotización, se procederá a cancelar la operación Actual");
                btnCancelar_Click(sender, e);
                return;
            }


            checkBIncluirFactura.Checked = fProductosBusqueda.CheckConFactura.Checked;
            cBoxMonedas.SelectedValue = fProductosBusqueda.CBoxMonedas.SelectedValue;

            string MascaraMonedaCotizacion = DTMonedas.Rows.Find(fProductosBusqueda.CBoxMonedas.SelectedValue)["MascaraMoneda"].ToString();
            this.txtBoxPrecioTotal.Text = DTCotizacionProductosDetalleTemporalVisualizacion.Compute("sum(PrecioTotal)", "VendidoComoAgregado = false").ToString() + " " + MascaraMonedaCotizacion;
            this.tabControl1.TabIndex = 0;

            
            tabControl1.SelectedIndex = 0;
            cBoxCliente.Focus();
        }

        /// <summary>
        /// Se encarga de Formatear las Columnas del DataGridView ProductosSeleccionados
        /// de Acuerdo a la Operación que se desea mostrar
        /// en caso de que se desea mostrar el detalle de una Cotización ya Realizada, pasar como parametro false,
        /// caso contrario True, para mostrar el Detalle Actual de una Venta en Curso
        /// </summary>
        /// <param name="esParaVender"> si La Venta se lleva en Curso</param>
        public void formatearEstiloTabla()
        {            
            DGCCodigoProducto.Width = 80;
            DGCNombreProducto.Width = 350;

            DGCCodigoProducto.DataPropertyName = "Código Producto";
            DGCNombreProducto.DataPropertyName = "Nombre Producto";
            DGCCantidadVenta.DataPropertyName = "Cantidad";
            DGCPrecioUnitarioCotizacionVenta.DataPropertyName = "Precio";
            DGCPrecioTotal.DataPropertyName = "PrecioTotal";
            DGCTiempoGarantiaCotizacionVenta.DataPropertyName = "Garantia";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cBoxMonedas.SelectedValue = CodigoMonedaSistema;
            cargarDatosCotizaciones(_TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("CotizacionVentasProductos"));
            errorProviderCotizaciones.Clear();
        }

        private void btnNuevoDesdeOtraCotizacion_Click(object sender, EventArgs e)
        {
            FBuscarTransaccion formBuscarTransaccion = new FBuscarTransaccion(NumeroAgencia);
            formBuscarTransaccion.formatearEstiloParaCotizaciones();
            formBuscarTransaccion.ShowDialog(this);
            int NumeroCotizacionBuscada = formBuscarTransaccion.NumeroTransaccion;
            if (NumeroCotizacionBuscada > 0)
            {
                //DTCotizacionesProductos = 
                //    (DSDoblones20GestionComercial.CotizacionVentasProductosDataTable)
                //    _CotizacionVentasProductosCLN.ObtenerCotizacionVentaProducto(NumeroAgencia, NumeroCotizacionBuscada);

                //DTCotizacionProductosDetalleTemporalVisualizacion.Clear();
                //DTCotizacionProductosDetalleTemporalMonedaSistema.Clear();
                
                //toolStripFechaCotizacion.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                //DTCotizacionProductosDetalleTemporalVisualizacion = fProductosBusqueda.DTProductosSeleccionados;
                //bdSourceCotizacionesProductosDetalle.DataSource = DTCotizacionProductosDetalleTemporalVisualizacion;

                //DGCCodigoProducto.DataPropertyName = "CodigoProducto";
                //DGCNombreProducto.DataPropertyName = "NombreProducto";
                //DGCCantidadVenta.DataPropertyName = "CantidadCotizacionVenta";
                //DGCPrecioUnitarioCotizacionVenta.DataPropertyName = "PrecioUnitarioCotizacionVenta";
                //DGCPrecioTotal.DataPropertyName = "PrecioTotal";
                //DGCTiempoGarantiaCotizacionVenta.DataPropertyName = "TiempoGarantiaCotizacionVenta";


                //NumeroCotizacionProducto = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("CotizacionVentasProductos");

                //CodigoTipoCotizacion = "N";

                //if (NumeroCotizacionProducto == 0) NumeroCotizacionProducto = 1;
                //if (NumeroCotizacionProducto > 1)
                //    NumeroCotizacionProducto++;
                //if (NumeroCotizacionProducto == 1 && DTCotizacionesProductos.Rows.Count == 1)
                //    NumeroCotizacionProducto = 2;

                //lblNumeroCotizacion.Text = NumeroCotizacionProducto.ToString();
                //lblEstado.Text = "Iniciada";
                //toolStripPBEstado.Value = (int)(toolStripPBEstado.Maximum) / 2;

                //habilitarBotonesCotizaciones(false, false, false, true, true, false, false, true, false, false, false);
                //fProductosBusqueda.LabelNombrePersonaTransaccion.Text = this.cBoxCliente.Text;
                //fProductosBusqueda.LabelNumeroTransaccion.Text = this.NumeroCotizacionProducto.ToString();
                //fProductosBusqueda.LabelNombreTransaccion.Text = "Numero Cotización";
                //this.txtBoxPrecioTotal.Text = fProductosBusqueda.LabelPrecioTotal.Text;

                //DTCotizacionesProductosDetalle = 
                //    (DSDoblones20GestionComercial.ListarCotizacionesProductosDetalleParaCotizacionesDataTable)
                //    _TransaccionesUtilidadesCLN.ListarDetalleDeCotizacion(NumeroAgencia, NumeroCotizacionBuscada);
                //DTCotizacionesProductosDetalle.Columns.Add("PrecioTotal", typeof(decimal), "CantidadCotizacionVenta*PrecioUnitarioCotizacionVenta");

                //foreach (DSDoblones20GestionComercial.ListarCotizacionesProductosDetalleParaCotizacionesRow
                //    filaNueva in DTCotizacionesProductosDetalle.Rows)
                //{
                //    DataRow filaCopiada = fProductosBusqueda.DTProductosSeleccionados.NewRow();
                //    filaCopiada.BeginEdit();
                //    filaCopiada["Código Producto"] = filaNueva["CodigoProducto"];
                //    filaCopiada["Nombre Producto"] = filaNueva["NombreProducto"];
                //    filaCopiada["Cantidad"] = filaNueva["CantidadCotizacionVenta"];
                //    filaCopiada["Precio"] = DTCotizacionesProductos[0].ConFactura ?
                //        decimal.Round(filaNueva.PrecioUnitarioCotizacionVenta / (1 + PorcentajeImpuestoSistema / 100), 2)
                //        : filaNueva.PrecioUnitarioCotizacionVenta;
                //    filaCopiada["PrecioTotal"] = DTCotizacionesProductos[0].ConFactura ?
                //        filaNueva.CantidadCotizacionVenta * decimal.Round(filaNueva.PrecioUnitarioCotizacionVenta / (1 + PorcentajeImpuestoSistema / 100), 2)
                //        : filaNueva.CantidadCotizacionVenta * filaNueva.PrecioUnitarioCotizacionVenta;
                //    filaCopiada["Garantia"] = filaNueva["TiempoGarantiaCotizacionVenta"];
                //    filaCopiada["PorcentajeDescuento"] = filaNueva["PorcentajeDescuento"];
                //    filaCopiada["NumeroPrecioSeleccionado"] = filaNueva["NumeroPrecioSeleccionado"];
                //    fProductosBusqueda.DTProductosSeleccionados.Rows.Add(filaCopiada);
                //    filaCopiada.AcceptChanges();
                //}

                //checkBIncluirFactura.Checked = false;
                //habilitarCampos(true);
                //cBoxCliente.Focus();
                //fProductosBusqueda.nuevaVenta = false;
                //TipoOperacion = "";


                //DTCotizacionProductosDetalleTemporalMonedaSistema = fProductosBusqueda.DTProductosSeleccionados;
                //cBoxMonedas.SelectedValue = DTCotizacionesProductos[0].CodigoMonedaCotizacionVenta;

                //txtBoxPrecioTotal.Text = DTCotizacionProductosDetalleTemporalMonedaSistema.Compute("sum(PrecioTotal)", "").ToString() 
                //    + DTMonedas.FindByCodigoMoneda(DTCotizacionesProductos[0].CodigoMonedaCotizacionVenta).MascaraMoneda;



                //fProductosBusqueda.ShowDialog(this);
                //formBuscarTransaccion.Dispose();

                ////if (fProductosBusqueda.DTGridViewProductosSeleccionados.Rows.Count > 0)
                ////{

                ////    detallePrecioTotal = _DTCotizacionesProductosDetalleTemporal.Compute("sum(PrecioTotal)", "");
                ////    if (detallePrecioTotal.ToString().Length > 0)
                ////        txtBoxPrecioTotal.Text = detallePrecioTotal.ToString() + " " + MascaraMonedaSistema;
                ////    else
                ////        txtBoxPrecioTotal.Text = " 0.00 " + MascaraMonedaSistema;
                ////}
                ////else
                ////{
                ////    this.txtBoxPrecioTotal.Text = " 0.00 " + MascaraMonedaSistema;
                ////    lblNumeroCotizacion.Text = "";
                ////    toolStripPBEstado.Value = 0;
                ////    MessageBox.Show("No tiene Seleccionado ningún Producto");
                ////    btnCancelar_Click(sender, e);
                ////}

                ////if (cotizacionConFactura)
                ////    AumentarPrecioFactura(true);
                cargarDatosCotizaciones(NumeroCotizacionBuscada);
                btnModificar_Click(btnModificar, e);
                TipoOperacion = "N";
            }
            else
            {
                MessageBox.Show(this, "No se encontro ninguna Cotización de Venta con los parametros o Descripción que usted Acaba de Ingresar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Desea Anular la Cotizacion de Productos?", "Cotizacion de Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                _CotizacionVentasProductosCLN.ActualizarCoditoEstadoCotizacion(NumeroAgencia, DTCotizacionesProductos[0].NumeroCotizacionVentaProducto, "A");
                int indiceActual = bdSourceCotizacionesProductos.Position;                
                cargarDatosCotizaciones(_TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("CotizacionVentasProductos"));                
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (btnNuevaCotizacion.Enabled || btnCotizacionInstitucional.Enabled)
            {

                habilitarCampos(true);

                TipoOperacion = "E";

                CodigoTipoCotizacion = DTCotizacionesProductos[0].CodigoTipoCotizacion;
                DTCotizacionProductosDetalleTemporalVisualizacion.Clear();
                DTCotizacionProductosDetalleTemporalVisualizacion.Columns["NumeroOrdenInsertado"].AutoIncrementSeed = 1;
                foreach (DSDoblones20GestionComercial.ListarCotizacionesProductosDetalleParaCotizacionesRow FilaNueva
                    in DTCotizacionesProductosDetalle.Rows)
                {
                    DataRow FilaProducto = DTCotizacionProductosDetalleTemporalVisualizacion.NewRow();
                    FilaProducto["Código Producto"] = FilaNueva.CodigoProducto;
                    FilaProducto["Nombre Producto"] = FilaNueva["NombreProducto"];
                    FilaProducto["Cantidad"] = FilaNueva.CantidadCotizacionVenta;
                    FilaProducto["Precio"] = !DTCotizacionesProductos[0].ConFactura ? FilaNueva.PrecioUnitarioCotizacionVenta 
                        : decimal.Round(FilaNueva.PrecioUnitarioCotizacionVenta / (1 + PorcentajeImpuestoSistema / 100), 2);

                    FilaProducto["PrecioTotal"] = !DTCotizacionesProductos[0].ConFactura 
                        ? FilaNueva.CantidadCotizacionVenta * FilaNueva.PrecioUnitarioCotizacionVenta
                        : decimal.Round(FilaNueva.CantidadCotizacionVenta * FilaNueva.PrecioUnitarioCotizacionVenta / (1 + PorcentajeImpuestoSistema / 100), 2);
                    FilaProducto["Garantia"] = FilaNueva.TiempoGarantiaCotizacionVenta;
                    FilaProducto["EsProductoEspecifico"] = _TransaccionesUtilidadesCLN.esProductoEspecifico(NumeroAgencia, FilaNueva["CodigoProducto"].ToString());
                    FilaProducto["VendidoComoAgregado"] = false;
                    FilaProducto["CantidadExistencia"] = _TransaccionesUtilidadesCLN.ObtenerExistenciaProductoInventario(NumeroAgencia, FilaNueva["CodigoProducto"].ToString());
                    FilaProducto["CantidadEntregada"] = FilaNueva.CantidadCotizacionVenta;
                    FilaProducto["PorcentajeDescuento"] = FilaNueva.PorcentajeDescuento;
                    FilaProducto["NumeroPrecioSeleccionado"] = FilaNueva.NumeroPrecioSeleccionado;
                    DTCotizacionProductosDetalleTemporalVisualizacion.Rows.Add(FilaProducto);
                }
                DTCotizacionProductosDetalleTemporalVisualizacion.AcceptChanges();

                fProductosBusqueda.DTProductosSeleccionadosMonedaSistema = DTCotizacionProductosDetalleTemporalVisualizacion.Copy();
                fProductosBusqueda.DTProductosSeleccionados = this.DTCotizacionProductosDetalleTemporalVisualizacion;
                fProductosBusqueda.BDSourceProductosSeleccionados.DataSource = fProductosBusqueda.DTProductosSeleccionados;
                fProductosBusqueda.DTGridViewProductosSeleccionados.DataSource = fProductosBusqueda.BDSourceProductosSeleccionados;
                fProductosBusqueda.nuevaVenta = false;
                fProductosBusqueda.ListaCodigosProductosEliminados.Clear();
                fProductosBusqueda.limpiarControles();
                fProductosBusqueda.habilitarEvento();
                DTCotizacionProductosDetalleTemporalMonedaSistema = fProductosBusqueda.DTProductosSeleccionadosMonedaSistema;
                bdSourceCotizacionesProductosDetalle.DataSource = DTCotizacionProductosDetalleTemporalVisualizacion;
                formatearEstiloTabla();
                habilitarBotonesCotizaciones(false, false, false, true, true, false, false, true, false, false, false);

                fProductosBusqueda.CheckConFactura.Checked = checkBIncluirFactura.Checked;
                fProductosBusqueda.CBoxMonedas.SelectedValue = cBoxMonedas.SelectedValue;
            }

            //if (ventaParaInsitituciones && esCotizacionVenta)
            //{
            //    TipoOperacion = "N";
            //    checkBIncluirFactura.Enabled = false;
            //}



            fProductosBusqueda.ShowDialog(this);

            if (fProductosBusqueda.DTProductosSeleccionados.Rows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ningún Producto para su Venta, se procederá a cancelar la operación Actual");
                btnCancelar_Click(sender, e);
                return;
            }
            checkBIncluirFactura.Checked = fProductosBusqueda.CheckConFactura.Checked;
            cBoxMonedas.SelectedValue = fProductosBusqueda.CBoxMonedas.SelectedValue;
            string MascaraMonedaCotizacion = DTMonedas.Rows.Find(fProductosBusqueda.CBoxMonedas.SelectedValue)["MascaraMoneda"].ToString();

            this.txtBoxPrecioTotal.Text = DTCotizacionProductosDetalleTemporalVisualizacion.Compute("sum(PrecioTotal)", "VendidoComoAgregado = false").ToString() + " " + MascaraMonedaCotizacion;
            tabControl1.SelectedIndex = 0;
        }

        private void cotizacionSensillaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable DTListarDatosClienteCotizacionesVentaReporte;
            DataTable DTListarCotizacionVentasProductosDetalleReporte;

            DTListarCotizacionVentasProductosDetalleReporte = _CotizacionVentasProductosDetaCLN.ListarCotizacionVentasProductosDetalleReporte(NumeroAgencia, NumeroCotizacionProducto);
            DTListarDatosClienteCotizacionesVentaReporte = _CotizacionVentasProductosCLN.ListarDatosClienteCotizacionesVentaReporte(NumeroAgencia, NumeroCotizacionProducto);

            FReporteCotizacionesVentasProductos formReporteCotizacion;
            if (MessageBox.Show(this, "¿Desea que el Reporte incluya los Precios?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                formReporteCotizacion = new FReporteCotizacionesVentasProductos(DTListarCotizacionVentasProductosDetalleReporte, DTListarDatosClienteCotizacionesVentaReporte, true);
            else
                formReporteCotizacion = new FReporteCotizacionesVentasProductos(DTListarCotizacionVentasProductosDetalleReporte, DTListarDatosClienteCotizacionesVentaReporte, false);

            formReporteCotizacion.ShowDialog(this);
            formReporteCotizacion.Dispose();
        }

        private void FaxToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            DataTable DTListarDatosCotizacionesVentaReporteDetallado;
            DataTable DTListarCotizacionVentasProductosDetalleReporteDetallado;            

            DTListarCotizacionVentasProductosDetalleReporteDetallado = _CotizacionVentasProductosDetaCLN.ListarCotizacionVentasProductosDetalleReporteDetallado(NumeroAgencia, NumeroCotizacionProducto);
            DTListarDatosCotizacionesVentaReporteDetallado = _CotizacionVentasProductosCLN.ListarDatosCotizacionesVentaReporteDetallado(NumeroAgencia, NumeroCotizacionProducto);            

            FReporteCotizacionesVentasProductos formReporteCotizacion;

            formReporteCotizacion = new FReporteCotizacionesVentasProductos();
            formReporteCotizacion.enviarTablasReporteParaFax(DTListarCotizacionVentasProductosDetalleReporteDetallado, DTListarDatosCotizacionesVentaReporteDetallado);
            formReporteCotizacion.ShowDialog(this);
            formReporteCotizacion.Dispose();
        }

        private void detalladoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable DTListarDatosCotizacionesVentaReporteDetallado;
            DataTable DTListarCotizacionVentasProductosDetalleReporteDetallado;
            DataTable DTListarProductosDescripcionCotizacion;
            
            DTListarCotizacionVentasProductosDetalleReporteDetallado = _CotizacionVentasProductosDetaCLN.ListarCotizacionVentasProductosDetalleReporteDetallado(NumeroAgencia, NumeroCotizacionProducto);
            DTListarDatosCotizacionesVentaReporteDetallado = _CotizacionVentasProductosCLN.ListarDatosCotizacionesVentaReporteDetallado(NumeroAgencia, NumeroCotizacionProducto);
            DTListarProductosDescripcionCotizacion = _CotizacionVentasProductosCLN.ListarProductosDescripcionCotizacion(NumeroAgencia, NumeroCotizacionProducto);

            FReporteCotizacionesVentasProductos formReporteCotizacion;

            formReporteCotizacion = new FReporteCotizacionesVentasProductos();
            formReporteCotizacion.enviarTablasReporteAvanzado(DTListarCotizacionVentasProductosDetalleReporteDetallado, DTListarDatosCotizacionesVentaReporteDetallado, DTListarProductosDescripcionCotizacion);
            formReporteCotizacion.ShowDialog(this);
            formReporteCotizacion.Dispose();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FCambiarMonedaCotizacionDeTransaccionesGC formCambioMoneda;
            if (btnAceptar.Enabled)
            {
                formCambioMoneda = new FCambiarMonedaCotizacionDeTransaccionesGC(DTCotizacionProductosDetalleTemporalMonedaSistema, NumeroPC, NumeroAgencia, NumeroCotizacionProducto, _TransaccionesUtilidadesCLN, 'I');
            }
            else
            {
                formCambioMoneda = new FCambiarMonedaCotizacionDeTransaccionesGC(DTCotizacionesProductosDetalle, NumeroPC, NumeroAgencia, NumeroCotizacionProducto, _TransaccionesUtilidadesCLN, 'F');
            }
            formCambioMoneda.DarEstiloParaCotizaciones();
            formCambioMoneda.ShowDialog(this);
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "La finalización de una Cotizacion de Productos implica solamente Un Listado de Productos con su respectivo Precio." + Environment.NewLine + "La Misma no Implica la reserva de los Mismos. " + Environment.NewLine + "Pero Usted Puede finalizar la cotización convertiendola en una Venta" + Environment.NewLine + Environment.NewLine + "¿Desea Finalizar la Cotizacion de Productos?", "Cotizacion de Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {                
                _CotizacionVentasProductosCLN.ActualizarCoditoEstadoCotizacion(NumeroAgencia, DTCotizacionesProductos[0].NumeroCotizacionVentaProducto, "F");
                cargarDatosCotizaciones(_TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("CotizacionVentasProductos"));
            }
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            DataTable VentaProductosTemporal = new DataTable();
            DataTable VentasProductosDetalleTemporal = new DataTable();


            VentaProductosTemporal = _CotizacionVentasProductosCLN.ObtenerCotizacionVentaProducto(NumeroAgencia, NumeroCotizacionProducto);
            VentasProductosDetalleTemporal = _TransaccionesUtilidadesCLN.ListarDetalleDeCotizacionParaVenta(NumeroAgencia, this.NumeroCotizacionProducto);
            string TipoCotizacion = VentaProductosTemporal.Rows[0]["CodigoTipoCotizacion"].ToString();
            DateTime FechaCotizacion = DateTime.Parse(VentaProductosTemporal.Rows[0]["FechaHoraCotizacion"].ToString());
            int ValidezOferta = int.Parse(VentaProductosTemporal.Rows[0]["ValidezOferta"].ToString());
            DateTime FechaActual = _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor();
            if (FechaActual <= (FechaCotizacion.AddDays(ValidezOferta)))
            {
                FVentasProductos2 _FVentasProductos = new FVentasProductos2(NumeroAgencia, NumeroPC, CodigoUsuario);

                
                _FVentasProductos.emitirPermisos(true, true, true, true, true, true, false);
                _FVentasProductos.CargarConfiguracionInicial(NombreMonedaSistema, CodigoMonedaSistema, MascaraMonedaSistema, CodigoMonedaRegion, NombreMonedaRegion, MascaraMonedaRegion, PorcentajeImpuestoSistema);
                _FVentasProductos.ListarDetalledeCotizacionParaVenta(
                    (DSDoblones20GestionComercial.CotizacionVentasProductosDataTable)VentaProductosTemporal,
                    (DSDoblones20GestionComercial.ListarCotizacionesProductosDetalleParaCotizacionesDataTable)VentasProductosDetalleTemporal, 
                    TipoCotizacion, sender, e);
                _FVentasProductos.ShowDialog(this);
                _FVentasProductos.Dispose();
            }
            else
            {
                MessageBox.Show("No puede Culminar esta cotización en una Venta, debido a que los días de Validez ya vencieron");
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            errorProviderCotizaciones.Clear();
            if (cBoxCliente.SelectedValue != null)
            {
                if (DTCotizacionProductosDetalleTemporalVisualizacion.Rows.Count > 0)
                {

                    if (txtDiazValidez.Text.Trim().Length <= 0)
                    {
                        //MessageBox.Show("No puede Ingresar Valores Vacios");
                        errorProviderCotizaciones.SetError(txtDiazValidez, "Los Días de Validez aún no han sido Ingresados");
                        txtDiazValidez.Focus();
                        return;
                    }
                    if (txtBoxTiempoEntrega.Text.Trim().Length <= 0)
                    {                        
                        errorProviderCotizaciones.SetError(txtBoxTiempoEntrega, "El Timpo de Entrega aún no ha sido Ingresado");
                        txtBoxTiempoEntrega.Focus();
                        return;
                    }

                    if (checkBIncluirFactura.Checked)
                    {
                        int CodigoMonedaActual = int.Parse(cBoxMonedas.SelectedValue.ToString());
                        if (MessageBox.Show(this, "Ha seleccionado incluir Factura en la Cotización. ¿Desea Continuar La Cotización con Factura?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                    }


                    DTCotizacionProductosDetalleTemporalMonedaSistema.Columns["PrecioTotal"].Expression = "Cantidad * Precio";
                    DTCotizacionProductosDetalleTemporalMonedaSistema.AcceptChanges();
                    
                    object precioParcialDetalle = DTCotizacionProductosDetalleTemporalMonedaSistema.Compute("sum(PrecioTotal)", "VendidoComoAgregado = false");
                    decimal PrecioTotal = Decimal.Parse(precioParcialDetalle.ToString());
                    try
                    {
                        DataSet DSTemporal = new DataSet("Productos");
                        DataTable DTProductosPreciosActualizados = DTCotizacionProductosDetalleTemporalMonedaSistema.Copy();
                        DTProductosPreciosActualizados.PrimaryKey = null;
                        DTProductosPreciosActualizados.Constraints.Clear();
                        DTProductosPreciosActualizados.Columns["Código Producto"].ColumnName = "CodigoProducto";
                        DTProductosPreciosActualizados.Columns.Remove(DTProductosPreciosActualizados.Columns["Nombre Producto"]);
                        /*para Aumentar una columna que conserve los montos de los precio en la moneda en la que se visualiza*/
                        DTProductosPreciosActualizados.Columns.Add("PrecioUnitarioOtraMoneda", Type.GetType("System.Decimal"));
                        foreach (DataRow DRProducto in DTCotizacionProductosDetalleTemporalVisualizacion.Rows)
                        {
                            DTProductosPreciosActualizados.Rows[DTCotizacionProductosDetalleTemporalVisualizacion.Rows.IndexOf(DRProducto)]["PrecioUnitarioOtraMoneda"] = DRProducto["Precio"];
                        }
                        DSTemporal.Tables.Add(DTProductosPreciosActualizados);
                        string ProductosDetalle = DTProductosPreciosActualizados.DataSet.GetXml();

                        
                        if (TipoOperacion == "N")
                        {

                            //Insertar toda la Venta en uno, incluyendo DETALLE DE VENTA MEDIANTE UN XML
                            
                            _CotizacionVentasProductosCLN.InsertarCotizacionVentaProductoXMLDetalle(NumeroAgencia,
                                cBoxCliente.SelectedValue == null ? 1 : int.Parse(cBoxCliente.SelectedValue.ToString().Trim()),
                                CodigoUsuario, _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor(),
                                int.Parse(txtDiazValidez.Text),
                                int.Parse(txtBoxTiempoEntrega.Text), "I",
                                false, byte.Parse(cBoxMonedas.SelectedValue.ToString()),
                                CodigoTipoCotizacion,
                                checkBIncluirFactura.Checked,                                     
                                txtBoxObservaciones.Text, 
                                ProductosDetalle, PrecioTotal,
                                null, null, null);

                            cargarDatosCotizaciones(_TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("CotizacionVentasProductos"));
                            cBoxCliente.Focus();

                        }
                        else // SI SE EDITA LA COTIZACION
                        {
                            _CotizacionVentasProductosCLN.ActualizarCotizacionVentaProductoXMLDetalle(NumeroAgencia, NumeroCotizacionProducto,
                                 cBoxCliente.SelectedValue == null ? 1 : int.Parse(cBoxCliente.SelectedValue.ToString().Trim()),
                                 CodigoUsuario, _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor(),
                                 int.Parse(txtDiazValidez.Text),
                                 int.Parse(txtBoxTiempoEntrega.Text), "I",
                                 false, byte.Parse(cBoxMonedas.SelectedValue.ToString()),
                                 CodigoTipoCotizacion,
                                 checkBIncluirFactura.Checked,
                                 txtBoxObservaciones.Text,
                                 ProductosDetalle, PrecioTotal,
                                 null, null, null);

                            cargarDatosCotizaciones(NumeroCotizacionProducto);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo realizar la Venta. Ocurrio la siguiente Excepción " + ex.Message);
                        return;
                    }                    
                    TipoOperacion = "";                    
                    
                }
                else
                {
                    if (MessageBox.Show(this, "No Puede Realizar Esta Transacción sin Haber por lo Menos Seleccionado una Producto para su Cotización. \r\n ¿Desea Agregar Productos a la Cotización Actual?", "Verifique la Cotización", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        fProductosBusqueda.ShowDialog(this);
                    }
                    else
                    {                        
                        cargarDatosCotizaciones(_TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("CotizacionVentasProductos"));
                    }
                }
            }
            else
            {
                errorProviderCotizaciones.SetError(cBoxCliente, "Aún no ha seleccionado ningún Cliente");
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FBuscarClientes formClientes = new FBuscarClientes();
            formClientes.ShowDialog(this);
            int CodigoCliente = formClientes.CodigoCliente;
            DTClientes = (DSDoblones20GestionComercial.ClientesDataTable)_ClientesCLN.ObtenerCliente(CodigoCliente);
            cBoxCliente.DataSource = DTClientes;
            cBoxCliente.DisplayMember = "NombreCliente";
            cBoxCliente.ValueMember = "CodigoCliente";
            cBoxCliente.SelectedValue = CodigoCliente;
            errorProviderCotizaciones.Clear();
        }

        private void btnRegistrarCliente_Click(object sender, EventArgs e)
        {
            FClientes formClientes = new FClientes(true, false, false, true);
            formClientes.ShowDialog(this);

            int CodigoCliente = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("Clientes");
            DTClientes = (DSDoblones20GestionComercial.ClientesDataTable)_ClientesCLN.ObtenerCliente(CodigoCliente);
            cBoxCliente.DataSource = DTClientes;
            cBoxCliente.DisplayMember = "NombreCliente";
            cBoxCliente.ValueMember = "CodigoCliente";
            cBoxCliente.SelectedValue = CodigoCliente;
            errorProviderCotizaciones.Clear();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FObservacionesTransaccionesModificacion _FObservacionesTransaccionesModificacion = new FObservacionesTransaccionesModificacion("T", CodigoUsuario, NumeroAgencia, NumeroCotizacionProducto);
            _FObservacionesTransaccionesModificacion.TxtBoxObservaciones.Text = txtBoxObservaciones.Text;
            if (_FObservacionesTransaccionesModificacion.ShowDialog() == DialogResult.OK)
                txtBoxObservaciones.Text = _FObservacionesTransaccionesModificacion.TxtBoxObservaciones.Text;
        }

        private void ProductosCompuestosToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            VentasProductosDetalleCLN _VentasProductosDetalleCLN = new VentasProductosDetalleCLN();
            DataTable DTListarDatosClienteCotizacionesVentaReporte;
            DataTable DTListarCotizacionVentasProductosDetalleReporte;
            DataTable DTProductosSimples;

            DTListarCotizacionVentasProductosDetalleReporte = _CotizacionVentasProductosDetaCLN.ListarCotizacionVentaProductoCompuestosDetalleReporte(NumeroAgencia, NumeroCotizacionProducto);
            DTListarDatosClienteCotizacionesVentaReporte = _CotizacionVentasProductosCLN.ListarDatosClienteCotizacionesVentaReporte(NumeroAgencia, NumeroCotizacionProducto);
            DTProductosSimples = _VentasProductosDetalleCLN.ListarVentaProductoSimplesDetalleReporte(NumeroAgencia, NumeroCotizacionProducto, false);

            FReporteCotizacionesVentasProductos formReporteCotizacion = new FReporteCotizacionesVentasProductos();
            formReporteCotizacion.cargarDatosCotizacionProductosCompuestos(DTListarDatosClienteCotizacionesVentaReporte,
                DTListarCotizacionVentasProductosDetalleReporte, DTProductosSimples);
            formReporteCotizacion.ShowDialog(this);
            formReporteCotizacion.Dispose();
        }


        //productosCompuestos
    }
}
