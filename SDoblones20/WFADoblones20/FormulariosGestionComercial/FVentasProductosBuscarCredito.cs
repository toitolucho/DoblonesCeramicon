using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.GestionComercial;
using CLCAD;
namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FVentasProductosBuscarCredito : Form
    {
        private int NumeroAgencia, NumeroPc;
        TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;
        CLCLN.Sistema.MonedasCLN _MonedasCLN;
        public String CodigoAutorizacion;
        public int NumeroCredito;
        public DSDoblones20GestionComercial2.ObtenerCreditoDesdeCodigoAutorizacionDataTable DTCreditos;
        public DSDoblones20Sistema.MonedasDataTable DTMonedas;
        public decimal MontoTotalVenta;
        public int CodigoMonedaVenta = -1;
        public bool OperacionConfirmada = false;
        public bool EsParaCreditoLibreDisposicion = false;
        private string MascaraMonedaVenta;
        private string MascaraMonedaCredito;

        public FVentasProductosBuscarCredito()
        {
            InitializeComponent();
        }

        public FVentasProductosBuscarCredito(int NumeroAgencia, int NumeroPC)
        {
            InitializeComponent();
            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();
            _MonedasCLN = new CLCLN.Sistema.MonedasCLN();
            this.NumeroAgencia = NumeroAgencia;
            this.NumeroPc = NumeroPC;
        }

        private void FVentasProductosBuscarCredito_Load(object sender, EventArgs e)
        {
            CargarTiposCreditos();
            DTMonedas = (DSDoblones20Sistema.MonedasDataTable)_MonedasCLN.ListarMonedas();
            MascaraMonedaVenta = DTMonedas.FindByCodigoMoneda((byte)CodigoMonedaVenta).MascaraMoneda;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtBosCodigoCredito.Text.Trim()))
            {
                errorProvider1.SetError(txtBosCodigoCredito, "Aún no ha ingresado el Número de Autorización de Crédito");
                return;
            }
            CodigoAutorizacion = txtBosCodigoCredito.Text.Trim();
            DTCreditos = _TransaccionesUtilidadesCLN.ObtenerCreditoDesdeCodigoAutorizacion(CodigoAutorizacion, NumeroAgencia, EsParaCreditoLibreDisposicion);
            cargarDatos();
        }


        public void cargarDatos()
        {
            errorProvider1.Clear();
            
            if (DTCreditos.Count > 0)
            {                
                DSDoblones20GestionComercial2.ObtenerCreditoDesdeCodigoAutorizacionRow DRCredito = DTCreditos[0];
                MascaraMonedaCredito = DTMonedas.FindByCodigoMoneda(DRCredito.CodigoMoneda).MascaraMoneda;
                groupBox2.Text = "Datos del Crédito " + DRCredito.NumeroCredito.ToString() + ", Numero Autorizacion : " + CodigoAutorizacion;
                txtBoxMontoCredito.Text = DRCredito.MontoDeuda.ToString() + " " + MascaraMonedaCredito;
                txtBoxMontoVenta.Text = MontoTotalVenta.ToString() + " " + MascaraMonedaVenta;
                txtBoxObservaciones.Text = DRCredito.IsObservacionesNull() ? "" : DRCredito.Observaciones;
                txtBoxPersonaGarante.Text = DRCredito.IsNombreCompletoGaranteNull() ? "" : DRCredito.NombreCompletoGarante;
                txtInterez.Text = DRCredito.InteresAnual.ToString();
                txtPersonasDeudor.Text = DRCredito.IsNombreCompletoDeudorNull() ? "" : DRCredito.NombreCompletoDeudor;
                if (DRCredito.CodigoTipoCredito == "L" || DRCredito.CodigoTipoCredito == "T")
                {
                    if (DRCredito.MontoDisponible < MontoTotalVenta)
                    {
                        txtBoxMontoGastadoCredito.ForeColor = Color.Red;
                        errorProvider1.SetError(txtBoxMontoGastadoCredito, "El Monto Disponible de este credito no es Suficiente para satisfacer La Venta");
                    }
                    else
                    {
                        txtBoxMontoGastadoCredito.ForeColor = Color.Black;
                        errorProvider1.Clear();
                    }
                }
                txtBoxMontoGastadoCredito.Text = DRCredito.IsMontoGastadoCreditoNull() ? "0.00" + " " + MascaraMonedaCredito : DRCredito.MontoGastadoCredito.ToString() + " " + MascaraMonedaCredito;
                cBoxTipoCredito.SelectedValue = DRCredito.CodigoTipoCredito;
                txtBoxMontoDisponible.Text = DRCredito.MontoDisponible.ToString() + " " + MascaraMonedaCredito;

                this.Text = "Autorización de Crédito " + DRCredito.NumeroCredito + " " +obtenerSignificadoCodigoEstadoCredito(DRCredito.CodigoEstadoCredito) ;
            }
            else
            {
                errorProvider1.SetError(txtBosCodigoCredito, "No se encuentra el Número de Autorización de Crédito");
                DTCreditos.Rows.Clear();
                limpiarCampos();
                this.Text = "Autorización de Crédito ";
                
            }
        }

        public static string obtenerSignificadoCodigoEstadoCredito(string CodigoEstadoCredito)
        {
            switch (CodigoEstadoCredito)
            {
                case "A":
                    return "AUTORIZADO";
                case "R":
                    return "RECHAZADO";
                case "S":
                    return "SOLICITADO";
                default :
                    return "INDETERMINADO";                
            }
            
        }

        public void limpiarCampos()
        {
            groupBox2.Text = string.Empty;
            txtBoxMontoCredito.Text = string.Empty;
            txtBoxMontoVenta.Text = string.Empty;
            txtBoxObservaciones.Text = string.Empty;
            txtBoxPersonaGarante.Text = string.Empty;
            txtInterez.Text = string.Empty;
            txtPersonasDeudor.Text = string.Empty;
            txtBoxMontoGastadoCredito.Text = string.Empty;
            cBoxTipoCredito.SelectedValue = -1;
            txtBoxMontoDisponible.Text = string.Empty;
        }
        private void txtBosCodigoCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscar_Click(btnBuscar, e as EventArgs);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (DTCreditos != null && DTCreditos.Count > 0)
            {
                if (DTCreditos[0].CodigoEstadoCredito.CompareTo("A") != 0)
                {
                    MessageBox.Show(this, "No puede Seleccionar un crédito que aún no ha sido Autorizado", "Creditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (DTCreditos[0].CodigoTipoCredito == "L" || DTCreditos[0].CodigoTipoCredito == "T")
                {
                    if (MontoTotalVenta > DTCreditos[0].MontoDeuda || MontoTotalVenta > DTCreditos[0].MontoDisponible)
                    {
                        MessageBox.Show(this, "No puede Seleccionar este crédito debido a que el Monto del mismo no es suficiente para la Venta", "Créditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                if (DTCreditos[0].CodigoMoneda != this.CodigoMonedaVenta)
                {
                    
                    MessageBox.Show(this, "No puede utilizar esta Autorización de credito, debido a que la Moneda en la que se autorizó el credito es " + DTMonedas.FindByCodigoMoneda((byte)DTCreditos[0].CodigoMoneda).NombreMoneda + " en Comparacion a la Orden de Venta (" + DTMonedas.FindByCodigoMoneda((byte)CodigoMonedaVenta).NombreMoneda + "). Cancele la operación actual y modifique el Tipo de Moneda", "Autorización de Creditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                OperacionConfirmada = true;
                this.Close();
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FVentasProductosBuscarCredito_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!OperacionConfirmada && MessageBox.Show(this, "Se Encuentra seguro de Cancelar la Operación Actual", "Creditos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }

        private void btnBuscarAvanzada_Click(object sender, EventArgs e)
        {
            FBuscarCreditos _FBuscarCreditos = new FBuscarCreditos();
            _FBuscarCreditos.ShowDialog(this);
            int NumeroCredito = _FBuscarCreditos.NumeroCredito;
            DataTable DTCreditoAux = new CreditosCLN().ObtenerCredito(NumeroCredito);
            if (DTCreditoAux.Rows.Count > 0)
            {
                if(String.IsNullOrEmpty(DTCreditoAux.Rows[0]["CodigoAutorizacion"].ToString().Trim()))
                {
                    MessageBox.Show(this,"El Credito aún no ha sido autorizado","Creditos para Ventas", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                CodigoAutorizacion = DTCreditoAux.Rows[0]["CodigoAutorizacion"].ToString();
                txtBosCodigoCredito.Text = CodigoAutorizacion;
                btnBuscar_Click(btnBuscar, e);

                if (!string.IsNullOrEmpty(txtBosCodigoCredito.Text) && DTCreditos.Count == 0)
                {
                    MessageBox.Show(this, "Cerciorese de buscar un credito acorde a la solicitud de Orden de venta."
                        + (EsParaCreditoLibreDisposicion ? "\r\nBusque un credito que haya sido registrado como 'LIBRE DISPONIBILIDAD'"
                        : "\r\nBusque un credito que hay sido Registrado como 'POR MONTO TOTAL VENTA'  o  'POR MONTO PARCIAL VENTA'"), 
                        "Busqued Autorización de Creditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void CargarTiposCreditos()
        {
            List<TiposCreditos> ALTiposCreditos = new List<TiposCreditos>();
            ALTiposCreditos.Add(new TiposCreditos("L", "LIBRE DISPONIBILIDAD"));
            ALTiposCreditos.Add(new TiposCreditos("T", "POR MONTO TOTAL VENTA"));
            ALTiposCreditos.Add(new TiposCreditos("P", "POR MONTO PARCIAL VENTA"));

            cBoxTipoCredito.DataSource = null;
            cBoxTipoCredito.Items.Clear();
            cBoxTipoCredito.DataSource = ALTiposCreditos;
            cBoxTipoCredito.DisplayMember = "NombreTipoCredito";
            cBoxTipoCredito.ValueMember = "CodigoTipoCredito";
        }
    }
}
