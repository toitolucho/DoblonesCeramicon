using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.Contabilidad;

namespace WFADoblones20.FormulariosContabilidad
{
    public partial class FPlanCuentasNuevo : Form
    {
        private DataTable dt;
        private string NumeroCuentaOriginal;

        public FPlanCuentasNuevo()
        {
            InitializeComponent();

            CargarComboBoxes();

            tbDescripcion.ReadOnly = false;
            tbNombreCuenta.ReadOnly = false;
            tbNumCta1.ReadOnly = true;
            tbNumCta2.ReadOnly = true;
            tbNumCta3.ReadOnly = true;
            tbNumCta4.ReadOnly = true;
            tbNumCta5.ReadOnly = true;
            chbSelCtaPadre.Enabled = true;

            tbDescripcion.Clear();
            tbNombreCuenta.Clear();
            tbNumCta1.Clear();
            tbNumCta2.Clear();
            tbNumCta3.Clear();
            tbNumCta4.Clear();
            tbNumCta5.Clear();

            MostrarInfoNuevo();

            cbNumeroCuentaPadre.Focus();
            cbNumeroCuentaPadre.Select();
        }

        private int SiguienteNumCta(int n)
        {
            int aux = 0;

            DataRow draux = dt.Select("NumeroCuentaPadre = '" + cbNumeroCuentaPadre.SelectedValue.ToString() + "'", "NumeroCuenta DESC")[0];
            aux = int.Parse(draux["NumeroCuenta"].ToString().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)[n]);

            return aux++;
        }

        private void MostrarInfoNuevo()
        {
            string[] ctapadre = cbNumeroCuentaPadre.SelectedValue.ToString().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            int aux;
            int niv = NivelCuenta(cbNumeroCuentaPadre.SelectedValue.ToString());
            switch (niv)
            {
                case 1:
                    tbNumCta1.Text = ctapadre[0];
                    tbNumCta1.ReadOnly = true;
                    aux = SiguienteNumCta(1);
                    aux++;
                    tbNumCta2.Text = aux.ToString();
                    tbNumCta2.ReadOnly = false;
                    tbNumCta2.Focus();
                    tbNumCta2.SelectAll();
                    tbNumCta3.Text = "00";
                    tbNumCta3.ReadOnly = true;
                    tbNumCta4.Text = "00";
                    tbNumCta4.ReadOnly = true;
                    tbNumCta5.Text = "000";
                    tbNumCta5.ReadOnly = true;
                    break;
                case 2:
                    tbNumCta1.Text = ctapadre[0];
                    tbNumCta1.ReadOnly = true;
                    tbNumCta2.Text = ctapadre[1];
                    tbNumCta2.ReadOnly = true;
                    aux = SiguienteNumCta(2);
                    aux++;
                    tbNumCta3.Text = aux.ToString();
                    tbNumCta3.ReadOnly = false;
                    tbNumCta3.Focus();
                    tbNumCta3.SelectAll();
                    tbNumCta4.Text = "00";
                    tbNumCta4.ReadOnly = true;
                    tbNumCta5.Text = "000";
                    tbNumCta5.ReadOnly = true;
                    break;
                case 3:
                    tbNumCta1.Text = ctapadre[0];
                    tbNumCta1.ReadOnly = true;
                    tbNumCta2.Text = ctapadre[1];
                    tbNumCta2.ReadOnly = true;
                    tbNumCta3.Text = ctapadre[2];
                    tbNumCta3.ReadOnly = true;
                    aux = SiguienteNumCta(3);
                    aux++;
                    tbNumCta4.Text = aux.ToString();
                    tbNumCta4.ReadOnly = false;
                    tbNumCta4.Focus();
                    tbNumCta4.SelectAll();
                    tbNumCta5.Text = "000";
                    tbNumCta5.ReadOnly = true;
                    break;
                case 4:
                case 5:
                    tbNumCta1.Text = ctapadre[0];
                    tbNumCta1.ReadOnly = true;
                    tbNumCta2.Text = ctapadre[1];
                    tbNumCta2.ReadOnly = true;
                    tbNumCta3.Text = ctapadre[2];
                    tbNumCta3.ReadOnly = true;
                    tbNumCta4.Text = ctapadre[3];
                    tbNumCta4.ReadOnly = true;
                    aux = SiguienteNumCta(4);
                    aux++;
                    tbNumCta5.Text = aux.ToString();
                    tbNumCta5.ReadOnly = false;
                    tbNumCta5.Focus();
                    tbNumCta5.SelectAll();
                    break;
            }
        }

        public FPlanCuentasNuevo(string NumCuenta, string NomCuenta, string NumCuentaPadre, byte Niv, string Desc)
        {
            InitializeComponent();

            CargarComboBoxes();

            this.Text = "Modificar cuenta";
            this.btAceptar.Text = "Modificar";

            /*int n = cbNumeroCuentaPadre.Items.Count;
            DataRowView obj;
            string cod = dt.Rows[0]["NumeroCuenta"].ToString();
            for (int i = 0; i < n; i++)
            {
                obj = (DataRowView)cbNumeroCuentaPadre.Items[i];
                if (obj.Row["NumeroCuenta"].ToString() == cod)
                {
                    cbNumeroCuentaPadre.SelectedIndex = i;
                    break;
                }
            }*/

            NumeroCuentaOriginal = NumCuenta;

            string[] NumeroCta = NumCuenta.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            tbNumCta1.Text = NumeroCta[0];
            tbNumCta2.Text = NumeroCta[1];
            tbNumCta3.Text = NumeroCta[2];
            tbNumCta4.Text = NumeroCta[3];
            tbNumCta5.Text = NumeroCta[4];

            //mtbNumeroCuenta.Text = NumCuenta;
            //mtbNumeroCuenta.Enabled = false;
            tbNombreCuenta.Text = NomCuenta;
            
            
            tbDescripcion.Text = Desc;
            //cbNivelCuenta.SelectedIndex = Niv - 1;            

            
            chbSelCtaPadre.Checked = false;

            cbNumeroCuentaPadre.Enabled = false;
            cbNombreCuentaPadre.Enabled = false;

            cbNumeroCuentaPadre.SelectedIndex = IndiceCuentaPadre(NumCuentaPadre);

            int aux = NivelCuenta(NumCuenta);

            switch (aux)
            {
                case 1:
                    tbNumCta1.ReadOnly = true;
                    tbNumCta1.Focus();
                    tbNumCta1.SelectAll();
                    tbNumCta2.ReadOnly = true;
                    tbNumCta3.ReadOnly = true;
                    tbNumCta4.ReadOnly = true;
                    tbNumCta5.ReadOnly = true;
                    break;
                case 2:
                    chbSelCtaPadre.Checked = true;
                    tbNumCta1.ReadOnly = true;
                    tbNumCta2.ReadOnly = true;
                    tbNumCta2.Focus();
                    tbNumCta2.SelectAll();
                    tbNumCta3.ReadOnly = true;
                    tbNumCta4.ReadOnly = true;
                    tbNumCta5.ReadOnly = true;
                    break;
                case 3:
                    chbSelCtaPadre.Checked = true;
                    tbNumCta1.ReadOnly = true;
                    tbNumCta2.ReadOnly = true;
                    tbNumCta3.ReadOnly = true;
                    tbNumCta3.Focus();
                    tbNumCta3.SelectAll();
                    tbNumCta4.ReadOnly = true;
                    tbNumCta5.ReadOnly = true;
                    break;
                case 4:
                    chbSelCtaPadre.Checked = true;
                    tbNumCta1.ReadOnly = true;
                    tbNumCta2.ReadOnly = true;
                    tbNumCta3.ReadOnly = true;
                    tbNumCta4.ReadOnly = true;
                    tbNumCta4.Focus();
                    tbNumCta4.SelectAll();
                    tbNumCta5.ReadOnly = true;
                    break;
                case 5:
                    chbSelCtaPadre.Checked = true;
                    tbNumCta1.ReadOnly = true;
                    tbNumCta2.ReadOnly = true;
                    tbNumCta3.ReadOnly = true;
                    tbNumCta4.ReadOnly = true;
                    tbNumCta5.ReadOnly = true;
                    tbNumCta5.Focus();
                    tbNumCta5.SelectAll();
                    break;
            }            
        }

        private int IndiceCuentaPadre(string NumCtaPadre)
        {
            int n = cbNumeroCuentaPadre.Items.Count;
            int respuesta = 0;
            DataRowView objeto;

            for (int i = 0; i < n; i++)
            {
                objeto = (DataRowView)cbNumeroCuentaPadre.Items[i];
                if (objeto[0].ToString() == NumCtaPadre)
                {
                    respuesta = i;
                    break;
                }
            }

            return respuesta;
        }

        private void CargarComboBoxes()
        {
            PlanCuentasCLN cuentas = new PlanCuentasCLN();
            DataTable dtp = new DataTable();
            dtp = cuentas.ListarPlanCuentasPadre();
            dt = new DataTable();
            dt = cuentas.ListarPlanCuentas();

            if (dt.Rows.Count > 0)
            {
                cbNumeroCuentaPadre.DisplayMember = "NumeroCuenta";
                cbNumeroCuentaPadre.ValueMember = "NumeroCuenta";
                cbNombreCuentaPadre.DisplayMember = "NombreCuenta";
                cbNombreCuentaPadre.ValueMember = "NumeroCuenta";

                cbNumeroCuentaPadre.DataSource = dtp;
                cbNombreCuentaPadre.DataSource = dtp;
            }
            else
            {
                MessageBox.Show("No existen registros en el Plan de Cuentas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (btAceptar.Text == "Registrar")
                Registrar();
            else
                Modificar();
        }

        public void Registrar()
        {
            if (cbNumeroCuentaPadre.Enabled)
            {
                string NumCta = tbNumCta1.Text + '-' + tbNumCta2.Text + '-' + tbNumCta3.Text + '-' + tbNumCta4.Text + '-' + tbNumCta5.Text;

                if (pbOk.Visible)
                {
                    if (tbNombreCuenta.Text != string.Empty)
                    {
                        PlanCuentasCLN pc = new PlanCuentasCLN();
                        pc.InsertarPlanCuentas(NumCta, tbNombreCuenta.Text, cbNumeroCuentaPadre.SelectedValue.ToString(), NivelCuenta(NumCta), tbDescripcion.Text);
                        MessageBox.Show("Datos registrados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Debe introducir un nombre de cuenta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tbNombreCuenta.Focus();
                        tbNombreCuenta.SelectAll();
                    }
                }
                else
                {
                    MessageBox.Show("Número de cuenta inválido (La cuenta ya existe).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbNumCta1.Focus();
                    tbNumCta1.SelectAll();
                }
            }
            else
            {
                string NumCta = tbNumCta1.Text + '-' + tbNumCta2.Text + '-' + tbNumCta3.Text + '-' + tbNumCta4.Text + '-' + tbNumCta5.Text;

                if (pbOk.Visible)
                {
                    if (tbNombreCuenta.Text != string.Empty)
                    {
                        PlanCuentasCLN pc = new PlanCuentasCLN();
                        pc.InsertarPlanCuentas(NumCta, tbNombreCuenta.Text, string.Empty, NivelCuenta(NumCta), tbDescripcion.Text);
                        MessageBox.Show("Datos registrados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Debe introducir un nombre de cuenta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tbNombreCuenta.Focus();
                        tbNombreCuenta.SelectAll();
                    }
                }
                else
                {
                    MessageBox.Show("Número de cuenta inválido (La cuenta ya existe).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbNumCta1.Focus();
                    tbNumCta1.SelectAll();
                }
            }
        }
        

        /*private bool EsNumeroCuentaValida()
        {
            bool respuesta = true;

            char primerCharNumeroCuentaPadre = cbNumeroCuentaPadre.SelectedValue.ToString()[0];
            if (primerCharNumeroCuentaPadre != mtbNumeroCuenta.Text[0])
            {
                MessageBox.Show("El número de cuenta no puede pertenecer a la cuenta padre especificada.", "Cuenta inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                respuesta = false;
            }
            else
                respuesta = true;

            return respuesta;
        }*/

        public void Modificar()
        {
            string NumCuenta = tbNumCta1.Text + '-' + tbNumCta2.Text + '-' + tbNumCta3.Text + '-' + tbNumCta4.Text + '-' + tbNumCta5.Text;

            if (NumCuenta == NumeroCuentaOriginal || !ExisteNumeroCuenta(NumCuenta))
            {
                if (tbNombreCuenta.Text != string.Empty)
                {

                    PlanCuentasCLN cuentas = new PlanCuentasCLN();

                    string NomCuenta = tbNombreCuenta.Text;

                    string NumCuentaPadre;
                    if (chbSelCtaPadre.Checked)
                    {
                        if (cbNumeroCuentaPadre.SelectedIndex > -1)
                            NumCuentaPadre = cbNumeroCuentaPadre.SelectedValue.ToString();
                        else
                            NumCuentaPadre = string.Empty;
                    }
                    else
                        NumCuentaPadre = string.Empty;

                    string Desc = tbDescripcion.Text;

                    cuentas.ActualizarPlanCuentas(NumCuenta, NomCuenta, NumCuentaPadre, NivelCuenta(NumCuenta), Desc);

                    MessageBox.Show("Se realizó la actualización de manera exitosa", "Actualizción exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Debe introducir un nombre de cuenta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbNombreCuenta.Focus();
                    tbNombreCuenta.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("Número de cuenta inválido (La cuenta ya existe).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbNumCta1.Focus();
                tbNumCta1.SelectAll();
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cbNivelCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ControlarNivelUno();
        }

        /*private void ControlarNivelUno()
        {
            if (cbNivelCuenta.SelectedIndex == 0)
            {
                cbNumeroCuentaPadre.Enabled = false;
                cbNombreCuentaPadre.Enabled = false;
            }
            else
            {
                cbNumeroCuentaPadre.Enabled = true;
                cbNombreCuentaPadre.Enabled = true;
            }
        }*/

        private void cbNumeroCuentaPadre_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back)
            {
                int n = cbNumeroCuentaPadre.Text.Length;

                switch (n)
                {
                    case 1:
                    case 3:
                    case 6:
                    case 9:
                        cbNumeroCuentaPadre.Text += "-";
                        cbNumeroCuentaPadre.SelectionStart = n + 1;
                        cbNumeroCuentaPadre.DroppedDown = true;
                        break;
                }
            }
        }

        private void cbNumeroCuentaPadre_Leave(object sender, EventArgs e)
        {
            if (cbNumeroCuentaPadre.SelectedValue == null)
            {
                MessageBox.Show("El número de cuenta que ha introducido no existe.\nSeleccione una cuanta válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbNumeroCuentaPadre.Focus();
                cbNumeroCuentaPadre.SelectAll();
            }
        }

        private void cbNombreCuentaPadre_Leave(object sender, EventArgs e)
        {
            if (cbNombreCuentaPadre.SelectedValue == null)
            {
                MessageBox.Show("La cuenta que ha introducido no existe.\nSeleccione una cuanta válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbNombreCuentaPadre.Focus();
                cbNombreCuentaPadre.SelectAll();
            }
            
        }

        private void tbNumCta1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '0')
            {
                e.Handled = true;
                tbNumCta1.Focus();
                tbNumCta1.SelectAll();
                System.Media.SystemSounds.Beep.Play();
            }
            else if (!Char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & (Keys)e.KeyChar != Keys.Enter)
            {
                e.Handled = true;
                tbNumCta1.Focus();
                tbNumCta1.SelectAll();
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void tbNumCta2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & (Keys)e.KeyChar != Keys.Enter)
            {
                e.Handled = true;
                tbNumCta2.Focus();
                tbNumCta2.SelectAll();
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void tbNumCta3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & (Keys)e.KeyChar != Keys.Enter)
            {
                e.Handled = true;
                tbNumCta3.Focus();
                tbNumCta3.SelectAll();
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void tbNumCta4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & (Keys)e.KeyChar != Keys.Enter)
            {
                e.Handled = true;
                tbNumCta4.Focus();
                tbNumCta4.SelectAll();
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void tbNumCta5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & (Keys)e.KeyChar != Keys.Enter)
            {
                e.Handled = true;
                tbNumCta5.Focus();
                tbNumCta5.SelectAll();
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void ControlarNumeroCuenta()
        {
            if (this.btAceptar.Text != "Modificar")
            {
                string NumCta = tbNumCta1.Text + '-' + tbNumCta2.Text + '-' + tbNumCta3.Text + '-' + tbNumCta4.Text + '-' + tbNumCta5.Text;

                if (!ExisteNumeroCuenta(NumCta))
                {
                    pbOk.Visible = true;
                }
                else
                {
                    pbOk.Visible = false;
                }
            }
        }

        private bool ExisteNumeroCuenta(string NumCta)
        {
            DataRow[] drs = dt.Select("NumeroCuenta = '" + NumCta + "'");

            if (drs.Length == 0)
                return false;
            else
                return true;
        }

        private void tbNumCta1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue > 96 && e.KeyValue < 106)
                if (tbNumCta1.Text.Length == 1)
                {
                    tbNumCta2.Focus();
                    tbNumCta2.SelectAll();
                    ControlarNumeroCuenta();
                }
        }

        private void tbNumCta2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue > 95 && e.KeyValue < 106)
                if (tbNumCta2.Text.Length == 1)
                {
                    tbNumCta3.Focus();
                    tbNumCta3.SelectAll();
                    ControlarNumeroCuenta();
                }
        }

        private void tbNumCta3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue > 95 && e.KeyValue < 106)
                if (tbNumCta3.Text.Length == 2)
                {
                    tbNumCta4.Focus();
                    tbNumCta4.SelectAll();
                    ControlarNumeroCuenta();
                }
        }

        private void tbNumCta4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue > 95 && e.KeyValue < 106)
                if (tbNumCta4.Text.Length == 2)
                {
                    tbNumCta5.Focus();
                    tbNumCta5.SelectAll();
                    ControlarNumeroCuenta();
                }
        }

        private void tbNumCta5_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue > 95 && e.KeyValue < 106)
            {
                if (tbNumCta5.Text.Length == 3)
                {
                    ControlarNumeroCuenta();
                }
                if ((Keys)e.KeyData == Keys.Back || (Keys)e.KeyData == Keys.Enter)
                {
                    if (tbNumCta5.Text.Length < 3)
                    {
                        pbOk.Visible = false;
                    }
                }
            }
        }

        private byte NivelCuenta(string NumCta)
        {
            byte nivel = 1;

            string[] nc = NumCta.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

            if (int.Parse(nc[4]) > 0)
            {
                nivel = 5;
            }
            else if (int.Parse(nc[3]) > 0)
            {
                nivel = 4;
            }
            else if (int.Parse(nc[2]) > 0)
            {
                nivel = 3;
            }
            else if (int.Parse(nc[1]) > 0)
            {
                nivel = 2;
            }
            else if (int.Parse(nc[0]) > 0)
            {
                nivel = 1;
            }

            return nivel;
        }

        private void chbSelCtaPadre_CheckedChanged(object sender, EventArgs e)
        {            
            if (chbSelCtaPadre.Checked)
            {
                tbNumCta1.ReadOnly = true;

                if (btAceptar.Text != "Modificar")
                {
                    cbNumeroCuentaPadre.Enabled = true;
                    cbNombreCuentaPadre.Enabled = true;
                }
                else
                {
                    cbNumeroCuentaPadre.Enabled = false;
                    cbNombreCuentaPadre.Enabled = false;
                }

                if (cbNumeroCuentaPadre.SelectedIndex > -1)
                {
                    int n = NivelCuenta(cbNumeroCuentaPadre.SelectedValue.ToString());

                    switch (n)
                    {                        
                        case 2:
                            tbNumCta2.ReadOnly = true;
                            tbNumCta3.ReadOnly = false;
                            tbNumCta4.ReadOnly = false;
                            tbNumCta5.ReadOnly = false;
                            break;
                        case 3:
                            tbNumCta2.ReadOnly = true;
                            tbNumCta3.ReadOnly = true;
                            tbNumCta4.ReadOnly = false;
                            tbNumCta5.ReadOnly = false;
                            break;
                        case 4:
                        case 5:
                            tbNumCta2.ReadOnly = true;
                            tbNumCta3.ReadOnly = true;
                            tbNumCta4.ReadOnly = true;
                            tbNumCta5.ReadOnly = false;
                            break;
                    }

                    cbNumeroCuentaPadre.Focus();
                    cbNumeroCuentaPadre.SelectAll();

                    MostrarInfoNuevo();
                }
            }
            else if (btAceptar.Text != "Modificar")
            {
                DataRow draux = dt.Select("NivelCuenta = 1", "NumeroCuenta DESC")[0];

                tbNumCta1.ReadOnly = false;
                int aux = int.Parse(draux["NumeroCuenta"].ToString().Split(new char[] { '-' })[0]);
                aux++;
                tbNumCta1.Text = aux.ToString();
                tbNumCta1.Focus();
                tbNumCta1.SelectAll();
                tbNumCta2.ReadOnly = true;
                tbNumCta3.ReadOnly = true;
                tbNumCta4.ReadOnly = true;
                tbNumCta5.ReadOnly = true;

                tbNumCta2.Text = "0";
                tbNumCta3.Text = "00";
                tbNumCta4.Text = "00";
                tbNumCta5.Text = "000";

                cbNumeroCuentaPadre.Enabled = false;
                cbNombreCuentaPadre.Enabled = false;
            }
        }

        private void tbNumCta1_Leave(object sender, EventArgs e)
        {
            if (!pbOk.Visible)
            {
                ControlarNumeroCuenta();
            }

            if (tbNumCta1.Text == string.Empty)
            {
                tbNumCta1.Text = "1";
            }
        }

        private void tbNumCta2_Leave(object sender, EventArgs e)
        {
            if (tbNumCta2.Text == string.Empty)
            {
                tbNumCta2.Text = "0";
            }
            ControlarNumeroCuenta();
        }

        private void tbNumCta3_Leave(object sender, EventArgs e)
        {
            if (tbNumCta3.Text == string.Empty)
            {
                tbNumCta3.Text = "00";
            }
            else if (tbNumCta3.Text.Length < 2)
            {
                tbNumCta3.Text = "0" + tbNumCta3.Text;
            }

            ControlarNumeroCuenta();
        }

        private void tbNumCta4_Leave(object sender, EventArgs e)
        {
            if (tbNumCta4.Text == string.Empty)
            {
                tbNumCta4.Text = "00";
            }
            else if (tbNumCta4.Text.Length < 2)
            {
                tbNumCta4.Text = "0" + tbNumCta4.Text;
            }

            ControlarNumeroCuenta();
        }

        private void tbNumCta5_Leave(object sender, EventArgs e)
        {     
            if (tbNumCta5.Text == string.Empty)
            {
                tbNumCta5.Text = "00";
            }
            else if (tbNumCta5.Text.Length < 3)
            {
                if (tbNumCta5.Text.Length == 2)
                    tbNumCta5.Text = "0" + tbNumCta5.Text;
                else
                    tbNumCta5.Text = "00" + tbNumCta5.Text;
            }

            ControlarNumeroCuenta();
        }

        private void cbNumeroCuentaPadre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btAceptar.Text != "Modificar")
                MostrarInfoNuevo();
        }

        private void FPlanCuentasNuevo_Load(object sender, EventArgs e)
        {
            
        }

        private void FPlanCuentasNuevo_Shown(object sender, EventArgs e)
        {
            if (btAceptar.Text == "Modificar")
            {
                tbNombreCuenta.Focus();
                tbNombreCuenta.SelectAll();
            }
        }

    }
}
