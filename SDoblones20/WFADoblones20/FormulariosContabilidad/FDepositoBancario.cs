using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN;
using CLCLN.Sistema;
using CLCLN.Contabilidad;
using CLCLN.GestionComercial;

namespace WFADoblones20.FormulariosContabilidad
{
    public partial class FDepositoBancario : Form
    {
        private int NumeroDepositoBancario;
        private int NumeroAgencia;

        /// <summary>
        /// Constructor para nuevo deposito
        /// </summary>
        public FDepositoBancario()
        {
            InitializeComponent();
            CargarComboBoxAgencia();
            DepositosBancariosCLN depositos = new DepositosBancariosCLN();
            int aux = depositos.ObtenerUltimoDepositoBancario() + 1;
            tbNumeroDeposito.Text = aux.ToString();
            NumeroDepositoBancario = aux;
            FuncionesContabilidad fc = new FuncionesContabilidad();
            dtpFecha.Value = DateTime.Parse(fc.ObtenerFechaHora());
        }

        /// <summary>
        /// Constructor para modificar
        /// </summary>
        /// <param name="NumDeposito"></param>
        /// <param name="NumAgencia"></param>
        public FDepositoBancario(int NumDeposito, string NomAgencia, DateTime fecha, string NomBanco, string numcuentabanco,
                                    string depositante, decimal monto, string NomMoneda,string observaciones)
        {
            InitializeComponent();
            CargarComboBoxAgencia();
            NumeroDepositoBancario = NumDeposito;
            tbNumeroDeposito.Text = NumeroDepositoBancario.ToString();
            cbAgencias.SelectedIndex = cbAgencias.Items.IndexOf(NomAgencia);
            cbAgencias.Enabled = false;
            dtpFecha.Value = fecha;
            cbBancos.SelectedIndex = cbBancos.Items.IndexOf(NomBanco);
            mtbNumeroCuentaBancaria.Text = numcuentabanco;
            tbDepositante.Text = depositante;
            tbMonto.Text = monto.ToString("F2");
            cbMoneda.SelectedIndex = cbMoneda.Items.IndexOf(NomMoneda);
            tbObservaciones.Text = observaciones;

        }

        private void FDepositoBancario_Load(object sender, EventArgs e)
        {
            CargarComboBoxBancos();
            CargarComboMonedas();
        }

        private void CargarComboBoxAgencia()
        {
            AgenciasCLN Agencias = new AgenciasCLN();
            DataTable DTAgencias = new DataTable();
            DTAgencias = Agencias.ListarAgencias();
            cbAgencias.DataSource = DTAgencias.DefaultView;
            cbAgencias.DisplayMember = "NombreAgencia";
            cbAgencias.ValueMember = "NumeroAgencia";                   
        }

        private void CargarComboBoxBancos()
        {
            BancosCLN Bancos = new BancosCLN();
            DataTable DTBancos = new DataTable();
            DTBancos = Bancos.ListarBancos();
            cbBancos.DataSource = DTBancos.DefaultView;
            cbBancos.DisplayMember = "NombreBanco";
            cbBancos.ValueMember = "CodigoBanco";
        }

        private void CargarComboMonedas()
        {
            MonedasCLN Monedas = new MonedasCLN();
            DataTable DTMonedas = new DataTable();
            DTMonedas = Monedas.ListarMonedas();
            cbMoneda.DataSource = DTMonedas.DefaultView;
            cbMoneda.DisplayMember = "NombreMoneda";
            cbMoneda.ValueMember = "CodigoMoneda";
        }

        private void tbMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) & e.KeyChar != '.' & e.KeyChar != ',' & (Keys)e.KeyChar != Keys.Back & (Keys)e.KeyChar != Keys.Tab)
            {
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            Registrar();
        }

        private void Registrar()
        {
            if (tbDepositante.Text != string.Empty || tbMonto.Text != string.Empty ||
                cbAgencias.SelectedIndex > -1 || cbMoneda.SelectedIndex > -1 || cbBancos.SelectedIndex > -1)
            {
                NumeroAgencia = int.Parse(cbAgencias.SelectedValue.ToString());
                string NumeroCuentaBanco = mtbNumeroCuentaBancaria.Text;
                string Depositante = tbDepositante.Text;
                decimal Monto = decimal.Parse(tbMonto.Text);
                DateTime Fecha = dtpFecha.Value;
                byte CodigoMoneda = byte.Parse(cbMoneda.SelectedValue.ToString());
                string Observaciones = tbObservaciones.Text;

                DepositosBancariosCLN NuevoDeposito = new DepositosBancariosCLN();
                NuevoDeposito.InsertarDepositoBancario(NumeroAgencia, NumeroCuentaBanco,Depositante,Monto,Fecha,CodigoMoneda, Observaciones);

                MessageBox.Show("Registro exitoso.", "registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if(chbImprimir.Checked)
                {
                    FReporteDepositosBancarios frdb = new FReporteDepositosBancarios(NumeroDepositoBancario, NumeroAgencia);
                    frdb.ShowDialog();
                }

            }

            else
            {
                MessageBox.Show("Datos inválidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpFecha.Focus();
            }
        }
    }
}
