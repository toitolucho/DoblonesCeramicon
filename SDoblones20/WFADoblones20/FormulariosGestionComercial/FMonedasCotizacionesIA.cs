using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.Sistema;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FMonedasCotizacionesIA : Form
    {
        private MonedasCLN Monedas = new MonedasCLN();
        private MonedasCotizacionesCLN MonedasCotizaciones = new MonedasCotizacionesCLN();
        private DataTable RBMonedasCotizaciones = new DataTable();
        private string TipoOperacion = "";

        public FMonedasCotizacionesIA()
        {
            InitializeComponent();
        }

        public FMonedasCotizacionesIA(string TO, byte CodigoMoneda, byte CodigoMonedaCotizacion, DateTime FechaHoraCotizacion, decimal CambioOficial, decimal CambioParalelo)
        {
            InitializeComponent();
            CargarMonedas();
            CargarMonedasCotizacion();
            this.TipoOperacion = TO;
            this.cBMoneda.SelectedValue = CodigoMoneda;
            this.cBMonedaCotizacion.SelectedValue = CodigoMonedaCotizacion;
            this.dTPFEchaHoraCotizacion.Value = FechaHoraCotizacion;
            this.tBCambioOficial.Text = CambioOficial.ToString();
            this.tBCambioParalelo.Text = CambioParalelo.ToString();
            if (TO == "I")
            {
                this.Text = "Insertar cotización";
            }
            else if (TO == "E")
            {
                this.Text = "Editar cotización";
            }
        }

        private void CargarMonedas()
        {
            DataTable DTMonedas = new DataTable();
            DTMonedas = Monedas.ListarMonedas();
            cBMoneda.DataSource = DTMonedas.DefaultView;
            cBMoneda.DisplayMember = "NombreMoneda";
            cBMoneda.ValueMember = "CodigoMoneda";
        }

        private void CargarMonedasCotizacion()
        {
            DataTable DTMonedasCotizacion = new DataTable();
            DTMonedasCotizacion = Monedas.ListarMonedas();
            cBMonedaCotizacion.DataSource = DTMonedasCotizacion.DefaultView;
            cBMonedaCotizacion.DisplayMember = "NombreMoneda";
            cBMonedaCotizacion.ValueMember = "CodigoMoneda";
        }

        private void FMonedasCotizacionesIA_Load(object sender, EventArgs e)
        {
            dTPFEchaHoraCotizacion.Focus();
        }

        public void cargarNuevaCotizacionDiaria(byte CodigoMonedaSistema, byte CodigoMonedaCotizacion)
        {
            
            CLCAD.DSDoblones20Sistema.MonedasCotizacionesDataTable DTUltimaMonedaCotizacion = MonedasCotizaciones.ObtenerUltimaMonedaCotizacionFecha(CodigoMonedaSistema, CodigoMonedaCotizacion);
            CargarMonedas();
            CargarMonedasCotizacion();

            cBMoneda.SelectedValue = CodigoMonedaSistema;
            cBMonedaCotizacion.SelectedValue = CodigoMonedaCotizacion;

            if (DTUltimaMonedaCotizacion.Count > 0)
            {
                tBCambioOficial.Text = DTUltimaMonedaCotizacion[0].CambioOficial.ToString();
                tBCambioParalelo.Text = DTUltimaMonedaCotizacion[0].CambioParalelo.ToString();                
                this.dTPFEchaHoraCotizacion.Value = new CLCLN.GestionComercial.TransaccionesUtilidadesCLN().ObtenerFechaHoraServidor();
            }

            MessageBox.Show(this, "No Existe aún registrado en la Fecha de HOY una cotización para "
                + (cBMoneda.SelectedItem as DataRowView)["NombreMoneda"].ToString()
                + " en " + (cBMonedaCotizacion.SelectedItem as DataRowView)["NombreMoneda"].ToString(), "Cotizacion No Existente",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            cBMonedaCotizacion.Enabled = false;
            dTPFEchaHoraCotizacion.Enabled = false;
            TipoOperacion = "I";
            this.Text = "Insertar cotización";
            tBCambioOficial.Focus();
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            byte CodigoMoneda = 0;
            byte CodigoMonedaCotizacion = 0;
            if (cBMoneda.SelectedIndex > -1)
                CodigoMoneda = byte.Parse(cBMoneda.SelectedValue.ToString());

            if (cBMonedaCotizacion.SelectedIndex > -1)
                CodigoMonedaCotizacion = byte.Parse(cBMonedaCotizacion.SelectedValue.ToString());

            try
            {
                if (TipoOperacion == "I")
                {
                    MonedasCotizaciones.InsertarMonedaCotizacion(CodigoMoneda, dTPFEchaHoraCotizacion.Value, CodigoMonedaCotizacion, decimal.Parse(tBCambioOficial.Text), decimal.Parse(tBCambioParalelo.Text));
                    MessageBox.Show("Se ha registrado exitosamente la cotizacion.");
                }
                else if (TipoOperacion == "E")
                {
                    MonedasCotizaciones.ActualizarMonedaCotizacion(CodigoMoneda, dTPFEchaHoraCotizacion.Value, CodigoMonedaCotizacion, decimal.Parse(tBCambioOficial.Text), decimal.Parse(tBCambioParalelo.Text));
                    MessageBox.Show("Se ha cambiado exitosamente la cotizacion.");
                }
                this.DialogResult = DialogResult.OK;
                this.Close();                
            }
            catch (Exception ex) 
            {
                MessageBox.Show("No se ha registrado la cotizacion solicitada debido a que ocurrio la siguiente excepcion " + ex.Message);
                this.Close();
            }
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tBCambioParalelo_TextChanged(object sender, EventArgs e)
        {

        }

        private void tBCambioOficial_TextChanged(object sender, EventArgs e)
        {

        }

        private void tBCambioOficial_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (!Char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && (Keys)e.KeyChar != Keys.Enter && e.KeyChar != ',' && e.KeyChar != '.')
            {
                txtBox.SelectAll();
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
                return;
            }
        }

    }
}
