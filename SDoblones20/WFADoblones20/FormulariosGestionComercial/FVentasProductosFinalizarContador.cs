using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.GestionComercial;
using CLCLN.Sistema;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FVentasProductosFinalizarContador : Form
    {
        int NumeroAgencia;
        int CodigoUsuario;
        int NumeroVenta;
        int NumeroPC;
        bool esPosible;

        DataTable DTVentaProducto;
        DataTable DTCliente;
        DataTable DTVentasFacturas;
        DataTable DTAgencias;
        DataTable DTVentasProductosDetalle;
        DataTable DTMonedas;

        VentasFacturasCLN _VentasFacturasCLN;
        VentasProductosCLN _VentasProductosCLN;
        VentasProductosDetalleCLN _VentasProductosDetalleCLN;
        ClientesCLN _ClientesCLN;
        AgenciasCLN _AgenciasCLN;
        CreditosCLN _CreditosCLN;
        TransaccionesUtilidadesCLN VentaUtilidadesCLN;
        MonedasCLN _MonedasCLN;
        private DataTable VariablesConfiguracionSistemaGC;
        private PCsConfiguracionesCLN PCConfiguracion;

        private string _CodigoEstadoVentaActual;
        public string CodigoEstadoVentaActual
        {
            get { return _CodigoEstadoVentaActual; }
            set { _CodigoEstadoVentaActual = value; }
        }

        #region Propiedades de Configuración de Arranque del Sistema
        public decimal PorcentajeImpuestoSistema { get; set; }
        public int CodigoMonedaSistema { get; set; }
        public int CodigoMonedaRegion { get; set; }
        public string MascaraMonedaPago { get; set; }
        public string MascaraMonedaRegion { get; set; }
        public string NombreMonedaSistema { get; set; }
        public string NombreMonedaRegion { get; set; }
        public string MascaraMonedaSistema { get; set; }
        #endregion

        int CodigoMonedaVenta = -1;

        public FVentasProductosFinalizarContador(int numeroAgencia, int codigoUsuario, int NumeroVenta, int NumeroPC)
        {
            InitializeComponent();
            this.NumeroAgencia = numeroAgencia;
            this.CodigoUsuario = codigoUsuario;            
            this.NumeroVenta = NumeroVenta;
            this.NumeroPC = NumeroPC;

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


            _VentasFacturasCLN = new VentasFacturasCLN();
            _VentasProductosCLN = new VentasProductosCLN();
            _VentasProductosDetalleCLN = new VentasProductosDetalleCLN();
            _ClientesCLN = new ClientesCLN();
            _AgenciasCLN = new AgenciasCLN();
            VentaUtilidadesCLN = new TransaccionesUtilidadesCLN();
            _MonedasCLN = new MonedasCLN();
            _CreditosCLN = new CreditosCLN();

        }
         
        private void FVentasProductosFinalizarContador_Load(object sender, EventArgs e)
        {
            dtGVFinalizarVenta.AutoGenerateColumns = false;
            decimal MontoTotalVentaProductos = 0;

            DTVentaProducto = _VentasProductosCLN.ObtenerVentaProducto(NumeroAgencia, NumeroVenta);
            DTVentasProductosDetalle = _VentasProductosDetalleCLN.ListarVentaProductoDetalleReporteIncluidoAgregados(NumeroAgencia, NumeroVenta, "S", true, false);            
            dtGVFinalizarVenta.DataSource = DTVentasProductosDetalle;

            CodigoMonedaVenta = int.Parse(DTVentaProducto.Rows[0]["CodigoMoneda"].ToString());
            if (CodigoMonedaVenta == CodigoMonedaSistema)
            {
                gBoxMonedaPago.Visible = false;
                DGCPrecioOtraMoneda.Visible = false;
                txtBoxMontoTotal.Text = DTVentaProducto.Rows[0]["MontoTotalVenta"].ToString() + " " + MascaraMonedaPago;
                MontoTotalVentaProductos = decimal.Parse(DTVentaProducto.Rows[0]["MontoTotalVenta"].ToString());
            }
            else
            {
                rBtnMonedaSistema.Text = NombreMonedaSistema;
                DTMonedas = _MonedasCLN.ObtenerMoneda((byte)CodigoMonedaVenta);
                rBtnMonedaCotizacion.Text = DTMonedas.Rows[0]["NombreMoneda"].ToString();
                MascaraMonedaPago = DTMonedas.Rows[0]["MascaraMoneda"].ToString();
                rBtnMonedaCotizacion.Checked = true;
                txtBoxMontoTotal.Text = DTVentasProductosDetalle.Compute("sum(PrecioTotalMonedaCotizacion)","").ToString() + " " + MascaraMonedaPago;
                rBtnMonedaSistema.Enabled = false;
                MontoTotalVentaProductos = decimal.Parse(DTVentasProductosDetalle.Compute("sum(PrecioTotalMonedaCotizacion)", "").ToString());
            }

            lblNroVenta.Text = NumeroVenta.ToString();            
            //txtBoxMontoTotal.Text = DTVentaProducto.Rows[0]["MontoTotalVenta"].ToString() + " " + MascaraMonedaPago;
            txtMontoCancelado_TextChanged(sender, e);

            if (String.IsNullOrEmpty(DTVentaProducto.Rows[0]["NumeroFactura"].ToString()))
            {
                checkBFactura.Checked = false;
                txtBoxNroFactura.Text = "Sin Factura";
            }
            else
            {
                checkBFactura.Checked = true;
                DTAgencias = _AgenciasCLN.ObtenerAgencia(NumeroAgencia);
                txtBoxNroFactura.Text = DTAgencias.Rows[0]["NumeroSiguienteFactura"].ToString();
            }

            dtGVFinalizarVenta.Columns["DGCCodigoProducto"].Visible = false;
            dtGVFinalizarVenta.Columns["DGCNombreProducto"].Width = 250;


            int CodigoCliente = int.Parse(DTVentaProducto.Rows[0]["CodigoCliente"].ToString());
            DTCliente = _ClientesCLN.ObtenerCliente(CodigoCliente);            

            txtBoxNITCliente.Text = DTCliente.Rows[0]["NITCliente"].ToString();
            txtBoxCliente.Text = DTCliente.Rows[0]["NombreCliente"].ToString();

            checkBFactura.Enabled = false;
            checkBRecibo.Checked = true;

            txtMontoCancelado.Focus();
            txtMontoCancelado.SelectAll();

            //esPosible = _VentasProductosCLN.EsPosibleConcluirEntregaDeProductos(NumeroAgencia, NumeroVenta);
            //CodigoEstadoVentaActual = DTVentaProducto.Rows[0]["CodigoEstadoVenta"].ToString();
            //if (CodigoEstadoVentaActual == "I" && !esPosible)
            //{                
            //        MessageBox.Show(this, "No puede realizar ninguna operación sobre esta venta, debido a que la cantidad de entrega de productos sobrepasa a la cantidad de Existencia en Inventarios"
            //            + Environment.NewLine + "Probablemente se realizó la entrega de los productos correspondientes a esta venta en otra venta"
            //            + Environment.NewLine + "Puede proceder a modificar la venta actual o esperar al reabastecimiento de Almacenes para la entrega actual");

            //        FVentaProductosEntrega _FVentaProductosEntrega = new FVentaProductosEntrega(NumeroAgencia, NumeroVenta);
            //        _FVentaProductosEntrega.DeshabilitarBotones();
            //        _FVentaProductosEntrega.ShowDialog(this);

            //        if (MessageBox.Show(this, "¿Desea realizar el Pago de esta Venta pero moficando la cantidad de Entrega a la existencia Actual en Inventarios?(No Recomendado)"
            //            +Environment.NewLine + " (Es preferible que el encargado de Ventas modifique la Cantidad de Entrega para Esta Venta)" , this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //            btnFinalizar.Enabled = false;
            //        else
            //        {
            //            //modificar la venta a la existencia actual 
            //            //donde los productos a entregar son insuficientes y poner esa cantidad a la cantidad existente en inventarios

            //        }
                    
            //}

            //para los creditos
            if (!String.IsNullOrEmpty(DTVentaProducto.Rows[0]["NumeroCredito"].ToString()))
            {                
                CLCAD.DSDoblones20GestionComercial.CreditosDataTable DTCreditos = (CLCAD.DSDoblones20GestionComercial.CreditosDataTable)_CreditosCLN.ObtenerCredito(int.Parse(DTVentaProducto.Rows[0]["NumeroCredito"].ToString()));
                if (DTCreditos.Count > 0)
                {
                    lblMontoCredito.Visible = true;
                    lblMontoTotalVenta.Visible = true;
                    txtBoxMontoTotalVenta.Visible = true;
                    txtBoxMontoCredito.Visible = true;

                    txtBoxMontoTotalVenta.Text = MontoTotalVentaProductos.ToString() + " " + MascaraMonedaPago;
                    txtBoxMontoCredito.Text = DTCreditos[0].MontoDisponible.ToString() + " " + MascaraMonedaPago;
                    if (DTCreditos[0].CodigoTipoCredito == "L" || DTCreditos[0].CodigoTipoCredito == "T")
                    {
                        txtBoxMontoTotal.Text = "0.00";
                    }
                    else if (DTCreditos[0].CodigoTipoCredito == "P")
                    {
                        txtBoxMontoTotal.Text = (MontoTotalVentaProductos - DTCreditos[0].MontoDisponible).ToString() + " " + MascaraMonedaPago;
                    }

                }

            }

        }

        private void códigoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DGCCodigoProducto.Visible = !DGCCodigoProducto.Visible;
        }

        private void precioUnitarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DGCPrecioUnitarioVenta.Visible = !DGCPrecioUnitarioVenta.Visible;
        }

        private void cantidadVendidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DGCCantidadVenta.Visible = !DGCCantidadVenta.Visible;
        }

        private void txtMontoCancelado_TextChanged(object sender, EventArgs e)
        {            
            decimal precioEfectivo = (decimal)0.0f, precioCambio = (decimal)0.0f, precioTotal = (decimal)0.0f;
            if (Decimal.TryParse(txtBoxMontoTotal.Text.Trim().Substring(0, txtBoxMontoTotal.Text.Length - MascaraMonedaPago.Length), out precioTotal))
            {
                if (txtMontoCancelado.Text.Trim().Contains(MascaraMonedaPago))
                {
                    if (Decimal.TryParse(txtMontoCancelado.Text.Trim().Substring(0, txtMontoCancelado.Text.Trim().Length - MascaraMonedaPago.Length), out precioEfectivo))
                    {
                        precioCambio = precioEfectivo - precioTotal;
                        //txtBoxCambio.Text = precioCambio >= 0 ? (precioCambio.ToString() + " " + MascaraMonedaPago) : ("0,00 " + MascaraMonedaPago);
                        txtBoxCambio.Text = precioCambio.ToString() + " " + MascaraMonedaPago;
                    }
                }
                else
                {

                    precioCambio = precioEfectivo - precioTotal;
                    txtMontoCancelado.Text = precioEfectivo.ToString() + ",00 " + MascaraMonedaPago;
                    txtMontoCancelado.Select(0, 4);
                    //txtBoxCambio.Text = precioCambio >= 0 ? (precioCambio.ToString() + " " + MascaraMonedaPago) : ("0,00 " + MascaraMonedaPago);
                    txtBoxCambio.Text = precioCambio.ToString() + " " + MascaraMonedaPago;
                }
            }
        }

        private void txtMontoCancelado_Enter(object sender, EventArgs e)
        {
            if (txtMontoCancelado.Text.Trim().Contains(MascaraMonedaPago))
            {
                txtMontoCancelado.Select(0, txtMontoCancelado.Text.Trim().Length - MascaraMonedaPago.Length);
            }
            else
            {
                txtMontoCancelado.SelectAll();
            }
        }

        private void txtMontoCancelado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txtMontoCancelado_Enter(sender, e as EventArgs);
            }
            if (e.KeyCode == Keys.Enter)
            {
                btnFinalizar_Click(btnFinalizar, e as EventArgs);
            }
        }

        private void txtMontoCancelado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & (Keys)e.KeyChar != Keys.Enter & e.KeyChar != ',')
            {
                txtMontoCancelado_Enter(sender, e as EventArgs);
                e.Handled = true;
                return;
            }
        }

        private void txtMontoCancelado_MouseEnter(object sender, EventArgs e)
        {
            if (txtMontoCancelado.Text.Trim().Contains(MascaraMonedaSistema))
            {
                txtMontoCancelado.Select(0, txtMontoCancelado.Text.Trim().Length - MascaraMonedaSistema.Length);
            }
            else
            {
                txtMontoCancelado.SelectAll();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Monto Cancelado" + txtMontoCancelado.Text + ",  Monto Total" + txtBoxMontoTotal.Text + ", Cambio" + txtBoxCambio.Text);
            this.Close();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMontoCancelado.Text.Trim()))
            {
                MessageBox.Show("No puede Finalizar la Venta sin haber introducido un Monto de Pago");
                txtMontoCancelado.Focus();
                txtMontoCancelado.SelectAll();
                return;
            }
            decimal MontoCambio;
            if (Decimal.TryParse(txtBoxCambio.Text.Substring(0, txtBoxCambio.Text.Length - MascaraMonedaPago.Length), out MontoCambio))
            {
                if (MontoCambio >= 0)
                {
                    int NumeroAgencia = 1;
                    if (DTVentaProducto.Rows[0]["NumeroAgencia"] != null) NumeroAgencia = Int16.Parse(DTVentaProducto.Rows[0]["NumeroAgencia"].ToString());
                    //else _NumeroAgencia = var;

                    int NumeroVentaProducto = 1;
                    if (DTVentaProducto.Rows[0]["NumeroVentaProducto"] != null) NumeroVentaProducto = Int16.Parse(DTVentaProducto.Rows[0]["NumeroVentaProducto"].ToString());
                    //else NumeroCompraProducto = varNula;

                    string CodigoCliente;
                    if (DTVentaProducto.Rows[0]["CodigoCliente"] != null) CodigoCliente = DTVentaProducto.Rows[0]["CodigoCliente"].ToString();
                    else CodigoCliente = null;

                    int NumFactura;
                    int? NumeroFactura;
                    if (string.IsNullOrEmpty(txtBoxNroFactura.Text) || !int.TryParse(txtBoxNroFactura.Text.Trim(), out NumFactura))
                    {
                        NumeroFactura = null;
                    }
                    else NumeroFactura = NumFactura;

                    DateTime FechaHoraVenta = DateTime.Now;

                    

                    string CodigoEstadoVenta = null;
                    if (DTVentaProducto.Rows[0]["CodigoEstadoVenta"] != null) CodigoEstadoVenta = "P";
                    CodigoEstadoVentaActual = DTVentaProducto.Rows[0]["CodigoEstadoVenta"].ToString();

                    int? NumeroCredito; //= varNula;
                    if (DTVentaProducto.Rows[0]["NumeroCredito"] != null && DTVentaProducto.Rows[0]["NumeroCredito"].ToString() != "") NumeroCredito = Int16.Parse(DTVentaProducto.Rows[0]["NumeroCredito"].ToString());
                    else NumeroCredito = null;

                    string Observaciones = null;
                    if (DTVentaProducto.Rows[0]["Observaciones"] != null) Observaciones = DTVentaProducto.Rows[0]["Observaciones"].ToString();

                    decimal MontoTotalPago = 0;
                    MontoTotalPago = decimal.Parse(DTVentaProducto.Rows[0]["MontoTotalVenta"].ToString());
                    byte CodigoMoneda = byte.Parse(DTVentaProducto.Rows[0]["CodigoMoneda"].ToString());
                    string CodigoTipoVenta = DTVentaProducto.Rows[0]["CodigoTipoVenta"].ToString();


                    if (checkBFactura.Checked)
                    {
                        DateTime fechaActual = new TransaccionesUtilidadesCLN().ObtenerFechaHoraServidor();
                        try
                        {
                            _VentasFacturasCLN.InsertarVentaFactura(NumeroAgencia, Int16.Parse(DTAgencias.Rows[0]["NumeroSiguienteFactura"].ToString()), txtBoxCliente.Text, txtBoxNITCliente.Text, fechaActual);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ocurrio el siguiente error " + ex.Message.ToString()+ Environment.NewLine + "Probablemente el Número de Factura ya fue generado. Intentelo Nuevamente");
                            DTAgencias = _AgenciasCLN.ObtenerAgencia(NumeroAgencia);
                            txtBoxNroFactura.Text = DTAgencias.Rows[0]["NumeroSiguienteFactura"].ToString();
                            return;                            
                        }

                        string NombreAgencia = DTAgencias.Rows[0][1].ToString();
                        string CodigoPais = DTAgencias.Rows[0][2].ToString();
                        string CodigoDepartamento = DTAgencias.Rows[0][3].ToString();
                        string CodigoProvincia = DTAgencias.Rows[0][4].ToString();
                        string CodigoLugar = DTAgencias.Rows[0][5].ToString();
                        string DireccionAgencia = DTAgencias.Rows[0][6].ToString();
                        string NITAgencia = DTAgencias.Rows[0][7].ToString();
                        int NumeroSiguienteFactura = Int16.Parse(DTAgencias.Rows[0][8].ToString());
                        string NumeroAutorizacion = DTAgencias.Rows[0][9].ToString();
                        string DIResponsable = DTAgencias.Rows[0][10].ToString();
                        int? NumeroAgenciaSuperior = null;
                        if ((DTAgencias.Rows[0][11] != null))
                            NumeroAgenciaSuperior = string.IsNullOrEmpty(DTAgencias.Rows[0][11].ToString()) ? null : (int?)int.Parse(DTAgencias.Rows[0][11].ToString());
                        

                        //actualizarmos el Número Siguente de la Factura
                        try
                        {
                            _AgenciasCLN.ActualizarAgencia(NumeroAgencia, NombreAgencia, CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLugar, DireccionAgencia, NITAgencia, NumeroSiguienteFactura + 1, NumeroAutorizacion, DIResponsable, NumeroAgenciaSuperior);

                            //_VentasProductosCLN.ActualizarVentaProducto(NumeroAgencia, NumeroVentaProducto, Int16.Parse(CodigoCliente), CodigoUsuario, NumeroFactura, FechaHoraVenta, CodigoTipoVenta, CodigoEstadoVenta, NumeroCredito, Observaciones);
                            if (CodigoEstadoVentaActual.CompareTo("C") == 0)
                                _VentasProductosCLN.ActualizarCodigoEstadoVenta(NumeroAgencia, NumeroVentaProducto, "F", NumeroFactura);
                            else
                                _VentasProductosCLN.ActualizarCodigoEstadoVenta(NumeroAgencia, NumeroVentaProducto, "P", NumeroFactura);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se pudo Finalizar correctamente la Transacción, ocurrió la siguiente excepción : " + ex.Message);                            
                        }
                    }
                    else
                    {
                        try
                        {
                            _VentasProductosCLN.ActualizarVentaProducto(NumeroAgencia, NumeroVentaProducto, Int16.Parse(CodigoCliente), CodigoUsuario, null, FechaHoraVenta, CodigoTipoVenta, MontoTotalPago, CodigoTipoVenta == "T" ? "F" : "P", NumeroCredito, CodigoMoneda, Observaciones);
                            //_VentasProductosCLN.ActualizarCodigoEstadoVenta(NumeroAgencia, NumeroVentaProducto, CodigoEstadoVenta, null);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se puedo Actualizar correctamente la Venta debido a la siguiente Excepción : " + ex.Message);
                            return;
                        }
                    }
                    //if (CodigoEstadoVentaActual == "I")
                    //    VentaUtilidadesCLN.ActualizarInventarioProductosVentas(NumeroAgencia, NumeroVentaProducto);
                    btnFinalizar.Enabled = false;
                    txtMontoCancelado.Enabled = false;

                    //MostrarReportes

                    DataTable DTVentasProductos;
                    DataTable DTVentasProductosDetalle;
                    DataTable DTDatosAgencia;
                    FReporteVentasProductosGeneral formReporteVentasProductos;
                    if (checkBRecibo.Checked)
                    {
                        DTVentasProductos = _VentasProductosCLN.ListarVentaProductoReporte(NumeroAgencia, NumeroVenta);
                        DTVentasProductosDetalle = _VentasProductosDetalleCLN.ListarVentaProductoDetalleReporteIncluidoAgregados(NumeroAgencia, NumeroVenta, "S", true, false);
                        DTDatosAgencia = new CLCLN.Sistema.AgenciasCLN().ListarDatosAgenciasParaTransaccionesReportes(NumeroAgencia);
                        //FReporteVentasProductosGeneral formReporteVentasProductos = new FReporteVentasProductosGeneral(DTDatosAgencia, DTVentasProductos, VentaUtilidadesCLN.ObtenerListaProductosParaCambiarMoneda(NumeroAgencia, null, DTVentasProductosDetalle), 'R');
                        formReporteVentasProductos = new FReporteVentasProductosGeneral(DTDatosAgencia, DTVentasProductos, DTVentasProductosDetalle, 'R');
                        formReporteVentasProductos.ShowDialog(this);
                    }

                    if (checkBFactura.Checked)
                    {
                        DTVentasProductos = _VentasProductosCLN.ListarVentaProductoReporte(NumeroAgencia, NumeroVenta);
                        DTVentasProductosDetalle = _VentasProductosDetalleCLN.ListarVentaProductoDetalleReporteIncluidoAgregados(NumeroAgencia, NumeroVenta, "S", true, true);
                        DTDatosAgencia = new CLCLN.Sistema.AgenciasCLN().ListarDatosAgenciasParaTransaccionesReportes(NumeroAgencia);
                        formReporteVentasProductos = new FReporteVentasProductosGeneral(DTDatosAgencia, DTVentasProductos, DTVentasProductosDetalle, 'F');
                        formReporteVentasProductos.ShowDialog(this);
                    }
                    //this.Close();
                }
                else
                {
                    MessageBox.Show(this,"El Monto ingresado no es suficiente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMontoCancelado.Focus();
                    txtMontoCancelado.Select(0, txtMontoCancelado.Text.Length - MascaraMonedaPago.Length);
                }
            }
            else
            {
                MessageBox.Show(this,"Su Monto ingresado no es coherente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMontoCancelado.Focus();
                txtMontoCancelado.Select(0, txtMontoCancelado.Text.Length - MascaraMonedaPago.Length);
            }
        }

        private void FVentasProductosFinalizarContador_Shown(object sender, EventArgs e)
        {
            esPosible = _VentasProductosCLN.EsPosibleConcluirEntregaDeProductos(NumeroAgencia, NumeroVenta, "A");
            CodigoEstadoVentaActual = DTVentaProducto.Rows[0]["CodigoEstadoVenta"].ToString();
            if (CodigoEstadoVentaActual == "I" && !esPosible)
            {
                MessageBox.Show(this, "No puede realizar ninguna operación sobre esta venta, debido a que la cantidad de entrega de productos sobrepasa a la cantidad de Existencia en Inventarios"
                    + Environment.NewLine + "Probablemente se realizó la entrega de los productos correspondientes a esta venta en otra venta"
                    + Environment.NewLine + "Puede proceder a modificar la venta actual o esperar al reabastecimiento de Almacenes para la entrega actual");

                FVentaProductosEntrega _FVentaProductosEntrega = new FVentaProductosEntrega(NumeroAgencia, NumeroVenta);
                _FVentaProductosEntrega.permitirDeshabilitar = true;
                _FVentaProductosEntrega.ShowDialog(this);

                if (MessageBox.Show(this, "¿Desea realizar el Pago de esta Venta pero moficando la cantidad de Entrega a la existencia Actual en Inventarios?(No Recomendado)"
                    + Environment.NewLine + " (Es preferible que el encargado de Ventas modifique la Cantidad de Entrega para Esta Venta)", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    btnFinalizar.Enabled = false;
                    txtMontoCancelado.Enabled = false;
                }
                else
                {
                    btnFinalizar.Enabled = false;
                    txtMontoCancelado.Enabled = false;
                    //modificar la venta a la existencia actual 
                    //donde los productos a entregar son insuficientes y poner esa cantidad a la cantidad existente en inventarios
                    //_VentasProductosCLN.ActualizarCantidadProductosEntregadosVentasInalcanzables(NumeroAgencia, NumeroVenta);
                }

            }
            else if (!String.IsNullOrEmpty(DTVentaProducto.Rows[0]["NumeroCredito"].ToString()))
            {
                MessageBox.Show(this, "Debe Confirmar el Uso de un credito autorizado para esta venta", "Venta a Credito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            txtMontoCancelado.Focus();
            txtMontoCancelado.Select(0, txtMontoCancelado.Text.Length - MascaraMonedaPago.Length);
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

            this.MascaraMonedaPago = MascaraMonedaSistema;
        }

        private void rBtnMonedaSistema_CheckedChanged(object sender, EventArgs e)
        {
            MascaraMonedaPago = MascaraMonedaSistema;
        }

        private void rBtnMonedaCotizacion_CheckedChanged(object sender, EventArgs e)
        {
            MascaraMonedaPago = DTMonedas.Rows[0]["MascaraMoneda"].ToString();
        }

        
    }
}
  