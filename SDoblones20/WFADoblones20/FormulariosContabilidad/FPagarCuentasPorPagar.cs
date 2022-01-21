using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN;
using CLCLN.Contabilidad;
using CLCLN.Sistema;

namespace WFADoblones20.FormulariosContabilidad
{
    public partial class FPagarCuentasPorPagar : Form
    {
        private class CuentasConfig
        {
            private string NumCta;
            private string Nombre;

            public CuentasConfig(string NumeroCuenta, string NombreCuenta)
            {
                this.NumCta = NumeroCuenta;
                this.Nombre = NombreCuenta;
            }

            public string GetNumero
            {
                get
                {
                    return this.NumCta;
                }
            }

            public string GetNombre
            {
                get
                {
                    return "(" + this.NumCta + ") " + this.Nombre;
                }
            }

        }

        private int NumPago;
        private int NumeroCtaPorPagar;
        private int CodUsuario;

        public FPagarCuentasPorPagar(int NumeroCuentaPorPagar, int CodigoUsuario, string Moneda)
        {
            InitializeComponent();

            this.NumeroCtaPorPagar = NumeroCuentaPorPagar;
            this.CodUsuario = CodigoUsuario;
            this.lbMoneda.Text = Moneda;
        }

        public FPagarCuentasPorPagar(int NumeroPago, int CodigoUsuario, string Moneda, string Monto)
        {
            InitializeComponent();

            this.NumPago = NumeroPago;
            this.CodUsuario = CodigoUsuario;
            this.lbMoneda.Text = Moneda;
            this.tbMonto.Text = Monto;
            this.btAceptar.Text = "Modificar";
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & (Keys)e.KeyChar != Keys.Enter & e.KeyChar == '-')
            {
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void FPagarCuentasPorPagar_Load(object sender, EventArgs e)
        {
            CargarConfiguraciones();
            tbMontoDelTotal.Text = decimal.Parse("0").ToString("F2");
            tbDebe.Text = decimal.Parse("0").ToString("F2");
            tbHaber.Text = decimal.Parse("0").ToString("F2");
            cbCuentas.Enabled = false;
            tbMontoDelTotal.Enabled = false;
            btOk.Enabled = false;
        }

        private void CargarConfiguraciones()
        {
            ConfiguracionesTransaccionesCuentasCLN configuraciones = new ConfiguracionesTransaccionesCuentasCLN();
            cbConfiguraciones.ValueMember = "NumeroConfiguracion";
            cbConfiguraciones.DisplayMember = "NombreConfiguracion";
            cbConfiguraciones.DataSource = configuraciones.ListarConfiguracionesTransaccionesCuentas();

            //<CARGAR CONFIGURACION DESDE XML
            /*int numconfig = ConfiguracionesCuentas.NumeroConfiguracion(this.Name);

            int n = cbConfiguraciones.Items.Count;
            DataRowView obj;
            for (int i = 0; i < n; i++)
            {
                obj = (DataRowView)cbConfiguraciones.Items[i];
                if (obj.Row["NumeroConfiguracion"].ToString() == numconfig.ToString())
                {
                    cbConfiguraciones.SelectedIndex = i;
                    break;
                }
            }*/
            //CARGAR CONFIGURACION DESDE XML>
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (tbMonto.Text != string.Empty)
            {
                decimal Monto;
                if (decimal.TryParse(tbMonto.Text, out Monto))
                {
                    if (cbConfiguraciones.SelectedIndex > -1)
                    {
                        if (decimal.Parse(tbDebe.Text) == decimal.Parse(tbHaber.Text))
                        {
                            CuentasPorPagarPagosCLN detalle = new CuentasPorPagarPagosCLN();
                            if (btAceptar.Text == "Modificar")
                            {
                                detalle.ActualizarCuentaPorPagarPago(NumPago, Monto, CodUsuario);
                            }
                            else
                            {    
                                detalle.InsertarCuentaPorPagarPago(NumeroCtaPorPagar, Monto, CodUsuario, RegistrarAsientoContable());
                            }

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Las sumas del Debe y Haber no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            tbMontoDelTotal.Focus();
                            tbMontoDelTotal.SelectAll();
                        }
                    }
                    else if (MessageBox.Show("No se ha seleccionado una configuración de cuentas ppara realizar\nel aasiento contable.\n\n"+
                        "¿Desea registrar el pago de todas formas?", "No se registrará asiento contable",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CuentasPorPagarPagosCLN detalle = new CuentasPorPagarPagosCLN();
                        if (btAceptar.Text == "Modificar")
                        {
                            detalle.ActualizarCuentaPorPagarPago(NumPago, Monto, CodUsuario);
                        }
                        else
                        {
                            detalle.InsertarCuentaPorPagarPago(NumeroCtaPorPagar, Monto, CodUsuario, 0);
                        }

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("El Monto tiene un formato erróneo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbMonto.Focus();
                    tbMonto.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("Debe introducir un valor para el Monto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbMonto.Focus();
            }
        }

        private void tbMontoDelTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & (Keys)e.KeyChar != Keys.Enter & e.KeyChar == '-')
            {
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void cbConfiguraciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarCuentas(int.Parse(cbConfiguraciones.SelectedValue.ToString()));
            }
            catch (Exception)
            { }
        }

        private void CargarCuentas(int NumeroConfugarcion)
        {
            CuentasConfiguracionCLN cuentas = new CuentasConfiguracionCLN();
            DataTable dt = cuentas.ListarPorNumero(NumeroConfugarcion);

            List<CuentasConfig> CtasConfig = new List<CuentasConfig>();

            dgvConfiguracionDetalle.Rows.Clear();
            int n = dt.Rows.Count;
            dgvConfiguracionDetalle.Rows.Add(n);
            FuncionesContabilidad saldoencuenta = new FuncionesContabilidad();
            for (int i = 0; i < n; i++)
            {
                CtasConfig.Add(new CuentasConfig(dt.Rows[i]["NumeroCuentaConfiguracion"].ToString(), dt.Rows[i]["NombreCuenta"].ToString()));
                dgvConfiguracionDetalle.Rows[i].Cells["dgvcNumeroCuenta"].Value = dt.Rows[i]["NumeroCuentaConfiguracion"].ToString();
                dgvConfiguracionDetalle.Rows[i].Cells["dgvcNombreCuenta"].Value = dt.Rows[i]["NombreCuenta"].ToString();
                dgvConfiguracionDetalle.Rows[i].Cells["dgvcSaldo"].Value = saldoencuenta.SaldoCuenta(dt.Rows[i]["NumeroCuentaConfiguracion"].ToString());
                if (dt.Rows[i]["TipoCuentaDebeHaber"].ToString() == "D")
                {
                    dgvConfiguracionDetalle.Rows[i].Cells["dgvcDebe"].Value = decimal.Parse(tbMonto.Text) * decimal.Parse(dt.Rows[i]["PorcentajeMontoTotalDH"].ToString());
                    dgvConfiguracionDetalle.Rows[i].Cells["dgvcHaber"].Value = 0.00M;

                    dgvConfiguracionDetalle.Rows[i].Tag = true;
                }
                else
                {
                    dgvConfiguracionDetalle.Rows[i].Cells["dgvcDebe"].Value = 0.00M;
                    dgvConfiguracionDetalle.Rows[i].Cells["dgvcHaber"].Value = decimal.Parse(tbMonto.Text) * decimal.Parse(dt.Rows[i]["PorcentajeMontoTotalDH"].ToString());

                    dgvConfiguracionDetalle.Rows[i].Tag = false;
                }
            }

            SumarDH();

            if (n == 2)
            {
                /*decimal montoparcial = decimal.Parse(tbMonto.Text) * decimal.Parse(dt.Rows[0]["PorcentajeMontoTotalDH"].ToString());
                if (dt.Rows[0]["TipoCuentaDebeHaber"].ToString() == "D")
                {
                    dgvConfiguracionDetalle.Rows[0].Cells["dgvcDebe"].Value = montoparcial;
                    dgvConfiguracionDetalle.Rows[1].Cells["dgvcHaber"].Value = decimal.Parse(tbMonto.Text) - montoparcial;
                }
                else
                {
                    dgvConfiguracionDetalle.Rows[0].Cells["dgvcHaber"].Value = montoparcial;
                    dgvConfiguracionDetalle.Rows[1].Cells["dgvcDebe"].Value = decimal.Parse(tbMonto.Text) - montoparcial;
                }*/

                chbMontosParciales.Checked = false;
                chbMontosParciales.Enabled = false;
                btOk.Enabled = false;
                cbCuentas.Enabled = false;
                tbMontoDelTotal.Enabled = false;
            }
            else
            {
                chbMontosParciales.Enabled = true;
                btOk.Enabled = true;
                cbCuentas.Enabled = true;
                tbMontoDelTotal.Enabled = false;
            }

            cbCuentas.DisplayMember = "GetNombre";
            cbCuentas.ValueMember = "GetNumero";
            cbCuentas.DataSource = CtasConfig;           
                
        }

        private void btNuevaConfiguracion_Click(object sender, EventArgs e)
        {
            new FConfiguracionCuentas(this.CodUsuario, true, true, true, true, true).ShowDialog();
            CargarConfiguraciones();
        }

        private void cbCuentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbCuentas.Enabled)
            {
                string numcta = cbCuentas.SelectedValue.ToString();
                int n = dgvConfiguracionDetalle.RowCount;
                for (int i = 0; i < n; i++)
                {
                    if (dgvConfiguracionDetalle.Rows[i].Cells["dgvcNumeroCuenta"].Value.ToString() == numcta)
                    {
                        if ((bool)dgvConfiguracionDetalle.Rows[i].Tag)
                        {
                            tbMontoDelTotal.Text = decimal.Parse(dgvConfiguracionDetalle.Rows[i].Cells["dgvcDebe"].Value.ToString()).ToString("F2");                            
                        }
                        else
                        {
                            tbMontoDelTotal.Text = decimal.Parse(dgvConfiguracionDetalle.Rows[i].Cells["dgvcHaber"].Value.ToString()).ToString("F2");
                        }

                        tbMontoDelTotal.Focus();
                        tbMontoDelTotal.SelectAll();

                        break;                         
                    }
                    
                }
            }
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (decimal.Parse(tbMontoDelTotal.ToString()) >= 0)
                {                    
                    string numcta = cbCuentas.SelectedValue.ToString();
                    int n = dgvConfiguracionDetalle.RowCount;
                    for (int i = 0; i < n; i++)
                    {
                        if (dgvConfiguracionDetalle.Rows[i].Cells["dgvcNumeroCuenta"].Value.ToString() == numcta)
                        {
                            if (decimal.Parse(tbMontoDelTotal.Text) <= decimal.Parse(dgvConfiguracionDetalle.Rows[i].Cells["dgvcSaldo"].Value.ToString()))
                            {
                                if ((bool)dgvConfiguracionDetalle.Rows[i].Tag)
                                {
                                    dgvConfiguracionDetalle.Rows[i].Cells["dgvcDebe"].Value = decimal.Parse(tbMontoDelTotal.Text);
                                }
                                else
                                {
                                    dgvConfiguracionDetalle.Rows[i].Cells["dgvcHaber"].Value = decimal.Parse(tbMontoDelTotal.Text);
                                }
                            }
                            else
                            {
                                MessageBox.Show("El Monto Parcial no puede ser mayor que el saldo en cuenta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                tbMontoDelTotal.Focus();
                                tbMontoDelTotal.SelectAll();
                            }

                            break;
                        }

                    }
                }
                else
                {
                    MessageBox.Show("El Monto Parcial no puede ser negativo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbMontoDelTotal.Focus();
                    tbMontoDelTotal.SelectAll();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("El Monto Parcial tiene un formato erróneo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbMontoDelTotal.Focus();
                tbMontoDelTotal.SelectAll();
            }
        }

        

        private void chbMontosParciales_CheckedChanged(object sender, EventArgs e)
        {
            if (chbMontosParciales.Checked)
            {
                cbCuentas.Enabled = true;
                tbMontoDelTotal.Enabled = true;
                btOk.Enabled = true;
            }
            else
            {
                cbCuentas.Enabled = false;
                tbMontoDelTotal.Enabled = false;
                btOk.Enabled = false;
            }
        }

        private void SumarDH()
        {
            if (dgvConfiguracionDetalle.RowCount > 1)
            {
                int n = dgvConfiguracionDetalle.RowCount;
                decimal sd = 0, sh = 0;

                for (int i = 0; i < n; i++)
                {
                    sd += decimal.Parse(dgvConfiguracionDetalle.Rows[i].Cells["dgvcDebe"].Value.ToString());
                    sh += decimal.Parse(dgvConfiguracionDetalle.Rows[i].Cells["dgvcHaber"].Value.ToString());
                }

                tbDebe.Text = sd.ToString("F2");
                tbHaber.Text = sh.ToString("F2");
            }
        }

        private int RegistrarAsientoContable()
        {
            AsientosCLN asiento = new AsientosCLN();
            string datosusuario = string.Empty;
            DataTable dt = new UsuariosCLN().ObtenerUsuario(this.CodUsuario);

            int n = dgvConfiguracionDetalle.RowCount;
            List<decimal> montos = new List<decimal>();
            for (int i = 0; i > n; i++)
            {
                if ((bool)dgvConfiguracionDetalle.Rows[i].Tag)
                {
                    montos.Add(decimal.Parse(dgvConfiguracionDetalle.Rows[i].Cells["dgvcDebe"].Value.ToString()));
                }
                else
                {
                    montos.Add(decimal.Parse(dgvConfiguracionDetalle.Rows[i].Cells["dgvcHaber"].Value.ToString()));
                }
            }

            datosusuario = dt.Rows[0]["Nombres"].ToString() + dt.Rows[0]["Paterno"].ToString() + dt.Rows[0]["Materno"].ToString();

            asiento.InsertarAsientoPorNumeroConfiguracion(this.CodUsuario, int.Parse(cbConfiguraciones.SelectedValue.ToString()), "Pago realizado en "
                + new FuncionesContabilidad().ObtenerFechaHora() + ", realizado por " + datosusuario, montos);

            
            return asiento.ObtenerUltimoNumeroAsiento();
        }

        private void FPagarCuentasPorPagar_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void FPagarCuentasPorPagar_Shown(object sender, EventArgs e)
        {
            tbMonto.Focus();
        }




    }
}
