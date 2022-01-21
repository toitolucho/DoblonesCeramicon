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
    public partial class FFinalizarVenta : Form
    {
        
        DataRow Venta_a_Actualizar = null;
        VentasProductosCLN _ventasProductosCLN = null;
        VentasFacturasCLN _ventasFactuasCLN = null;
        AgenciasCLN _agenciaCLN = null;

        DataTable DTDatosAgenciaActual = null;

        public bool ventaFinalizada = false;
        #region Propiedades del Formulario

        public DataRow VentaConfirmar
        {
            get
            {
                return this.Venta_a_Actualizar;
            }
            set
            {
                this.Venta_a_Actualizar = value;
            }
        }


        public TextBox TxtNombreCliente
        {
            get
            {
                return this.txtBoxNombreCliente;
            }
        }

        public TextBox TxtNitCliente
        {
            get
            {
                return this.txtBoxNITCliente;
            }
        }

        public TextBox TxtNumeroFactura
        {
            get
            {
                return this.txtBoxFactura;
            }
        }
        public TextBox TxtMontoTotal
        {
            get
            {
                return this.txtBoxMontoTotal;
            }
        }

        public TextBox TxtMontoCancelado
        {
            get
            {
                return this.txtMontoCancelado;
            }
        }

        public TextBox TxtMontoCambio
        {
            get
            {
                return this.txtBoxCambio;
            }
        }       

        #endregion

        private int numeroAgencia = 0;

        #region Constantes
        private const int ColumnaNumeroFacturaSiguiente = 8;
        private const int altoPnlDocumentosVisible = 100;
        #endregion

        private int CodigoUsuario;
        public FFinalizarVenta(int numeroAgencia, int codigoUsuario)
        {
            this.numeroAgencia = numeroAgencia;
            this.CodigoUsuario = codigoUsuario;
            InitializeComponent();
            this._ventasProductosCLN = new VentasProductosCLN();
            this._ventasFactuasCLN = new VentasFacturasCLN();
            this._agenciaCLN = new AgenciasCLN();

            DTDatosAgenciaActual = _agenciaCLN.ObtenerAgencia(numeroAgencia);

            pnlDocumentos.Visible = false;
            pnlDocumentos.Height = 0;
            this.Height = this.Height - altoPnlDocumentosVisible;
            this.TxtMontoCancelado.Clear();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkFactura.Checked)
            {
                pnlDocumentos.Visible = true;
                pnlDocumentos.Height = pnlDocumentos.Height + altoPnlDocumentosVisible;
                this.Height = this.Height + altoPnlDocumentosVisible;
                txtMontoCancelado.Focus();
            }
            else
            {
                pnlDocumentos.Visible = true;
                pnlDocumentos.Height = pnlDocumentos.Height - altoPnlDocumentosVisible;
                this.Height = this.Height - altoPnlDocumentosVisible;
            }

        }

        private void txtBoxMontoTotal_Leave(object sender, EventArgs e)
        {
            //if (txtBoxMontoTotal.Text != "")
            //    try
            //    {
            //        txtBoxMontoTotal.Text = Convert.ToDecimal(txtBoxMontoTotal.Text.Replace("$", "").Replace(",", "")).ToString("columnaOrdenada");
            //    }
            //    catch
            //    {
            //        MessageBox.Show("El Monto que Intenta Introducir no es Válido");
            //        txtBoxMontoTotal.Focus();
            //    } 
        }

        private void txtMontoCancelado_TextChanged(object sender, EventArgs e)
        {
            if (TxtMontoCancelado.Text != null && TxtMontoCancelado.Text.Trim() != "")
            {
                decimal totalPago = Decimal.Parse(TxtMontoTotal.Text.Replace('B', ' ').Replace('s', ' ').Trim());
                decimal totalCancelado = Decimal.Parse(TxtMontoCancelado.Text);
                txtBoxCambio.Text = (totalCancelado - totalPago).ToString() + "Bs";
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            decimal cantidadCancelada = Decimal.Parse(txtBoxCambio.Text.Replace('B', ' ').Replace('s', ' ').Trim());
            if ( cantidadCancelada >= 0)
            {
                int NumeroAgencia = 1;
                if (VentaConfirmar["NumeroAgencia"] != null) NumeroAgencia = Int16.Parse(VentaConfirmar["NumeroAgencia"].ToString());
                //else _NumeroAgencia = var;

                int NumeroVentaProducto =1;
                if (VentaConfirmar["NumeroVentaProducto"] != null) NumeroVentaProducto = Int16.Parse(VentaConfirmar["NumeroVentaProducto"].ToString());
                //else NumeroCompraProducto = varNula;

                string CodigoCliente;
                if (VentaConfirmar["CodigoCliente"] != null) CodigoCliente = VentaConfirmar["CodigoCliente"].ToString();
                else CodigoCliente = null;

                int? NumeroFactura;
                if (txtBoxFactura.Text != null) NumeroFactura = Int16.Parse(txtBoxFactura.Text);
                else NumeroFactura = null;
                
                DateTime FechaHoraVenta = DateTime.Now;

               
                //if (VentaConfirmar["CodigoTipoVenta"] != null) CodigoTipoVenta = VentaConfirmar["CodigoTipoVenta"].ToString();
                

                string CodigoEstadoVenta = null;
                if (VentaConfirmar["CodigoEstadoVenta"] != null) CodigoEstadoVenta = "F";


                int? NumeroCuentaPorCobrar; //= varNula;
                if (VentaConfirmar["NumeroCredito"] != null && VentaConfirmar["NumeroCredito"].ToString() != "") NumeroCuentaPorCobrar = Int16.Parse(VentaConfirmar["NumeroCredito"].ToString());
                else NumeroCuentaPorCobrar = null;

                string Observaciones = null;
                if (VentaConfirmar["Observaciones"] != null) Observaciones = VentaConfirmar["Observaciones"].ToString();

                decimal MontoTotalPago = 0;
                MontoTotalPago = decimal.Parse(VentaConfirmar["MontoTotalVenta"].ToString());

                //_ventasProductosCLN.ActualizarVentaProducto(Int16.Parse(VentaConfirmar[0].ToString()), Int16.Parse(VentaConfirmar[0].ToString()), VentaConfirmar[2] != null ? (string)VentaConfirmar[2] : null, Int16.Parse(DTDatosAgenciaActual.Rows[0][ColumnaNumeroFacturaSiguiente].ToString()), DateTime.Now, VentaConfirmar[5] != null ? (string)VentaConfirmar[5] : null, "F", VentaConfirmar[7] != null ? Int16.Parse(VentaConfirmar[7].ToString()) : varNula, VentaConfirmar[8] != null ? (string)VentaConfirmar[8] : null);
                //_ventasProductosCLN.ActualizarVentaProducto(_NumeroAgencia, NumeroCompraProducto, CodigoCliente, NumeroFactura, FechaHoraVenta, CodigoTipoVenta, CodigoEstadoVenta, NumeroCredito, Observaciones);
                if (checkFactura.Checked)
                {
                    DateTime fechaActual = DateTime.Now;
                    _ventasFactuasCLN.InsertarVentaFactura(numeroAgencia, Int16.Parse(DTDatosAgenciaActual.Rows[0][ColumnaNumeroFacturaSiguiente].ToString()), txtBoxNombreCliente.Text, txtBoxNITCliente.Text, fechaActual);

                    string NombreAgencia = DTDatosAgenciaActual.Rows[0][1].ToString();
                    string CodigoPais = DTDatosAgenciaActual.Rows[0][2].ToString();
                    string CodigoDepartamento = DTDatosAgenciaActual.Rows[0][3].ToString();
                    string CodigoProvincia = DTDatosAgenciaActual.Rows[0][4].ToString();
                    string CodigoLugar = DTDatosAgenciaActual.Rows[0][5].ToString();
                    string DireccionAgencia = DTDatosAgenciaActual.Rows[0][6].ToString();
                    string NITAgencia = DTDatosAgenciaActual.Rows[0][7].ToString();
                    int NumeroSiguienteFactura = Int16.Parse(DTDatosAgenciaActual.Rows[0][8].ToString());
                    string NumeroAutorizacion  = DTDatosAgenciaActual.Rows[0][9].ToString();
                    string DIResponsable = DTDatosAgenciaActual.Rows[0][10].ToString();
                    int NumeroAgenciaSuperior = int.Parse(DTDatosAgenciaActual.Rows[0][11].ToString());
                    //actualizarmos el Número Siguente de la Factura
                    _agenciaCLN.ActualizarAgencia(NumeroAgencia, NombreAgencia, CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLugar, DireccionAgencia, NITAgencia, NumeroSiguienteFactura + 1, NumeroAutorizacion, DIResponsable, NumeroAgenciaSuperior);

                    //_ventasProductosCLN.ActualizarVentaProducto(NumeroAgencia, NumeroVentaProducto, Int16.Parse(CodigoCliente), CodigoUsuario, NumeroFactura, FechaHoraVenta, CodigoTipoVenta, MontoTotalPago, CodigoEstadoVenta, NumeroCuentaPorCobrar, Observaciones);
                    _ventasProductosCLN.ActualizarCodigoEstadoVenta(numeroAgencia, NumeroVentaProducto, CodigoEstadoVenta, NumeroFactura);
                }
                else
                {
                    //_ventasProductosCLN.ActualizarVentaProducto(NumeroAgencia, NumeroVentaProducto, Int16.Parse(CodigoCliente), CodigoUsuario, null, FechaHoraVenta, CodigoTipoVenta, MontoTotalPago, CodigoEstadoVenta, NumeroCuentaPorCobrar, Observaciones);
                    _ventasProductosCLN.ActualizarCodigoEstadoVenta(numeroAgencia, NumeroVentaProducto, CodigoEstadoVenta, null);
                }
                ventaFinalizada = true;
                this.Hide();
                DTDatosAgenciaActual = _agenciaCLN.ObtenerAgencia(numeroAgencia);
            }
            else
            {
                MessageBox.Show(this, "No Puede Finalizar la Venta, sin Haber Introducido Un Monto de Pago que Satisfaga el Precio Total de Venta", "Venta de Productos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void FFiinalizarVenta_Shown(object sender, EventArgs e)
        {
            txtBoxFactura.Text = DTDatosAgenciaActual.Rows[0][ColumnaNumeroFacturaSiguiente].ToString();
        }

        private void txtMontoCancelado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & (Keys)e.KeyChar != Keys.Enter & e.KeyChar != ',')
            {                
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
                return;
            }
        }

        private void FFinalizarVenta_Load(object sender, EventArgs e)
        {
            txtMontoCancelado.Clear();
            txtBoxCambio.Clear();
        }

    }
}
