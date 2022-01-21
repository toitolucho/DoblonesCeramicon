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
    public partial class FPlanCuentas : Form
    {
        private DataTable dt;
        private bool permiso0, permiso1, permiso2, permiso3, permiso4;
        private char estadoedicion;
        byte cta0;

        public FPlanCuentas(bool p0, bool p1, bool p2, bool p3, bool p4)
        {
            InitializeComponent();
            permiso0 = p0;
            permiso1 = p1;
            permiso2 = p2;
            permiso3 = p3;
            permiso4 = p4;
        }

        private void FPlanCuentas_Load(object sender, EventArgs e)
        {
            Cargar();
            CargarDataGridView();

            tvPlanCuentas.SelectedNode = tvPlanCuentas.Nodes[0];
        }

        private void Cargar()
        {
            estadoedicion = '0';
            PlanCuentasCLN pc = new PlanCuentasCLN();
            tvPlanCuentas.Nodes.Clear();
            dt = new DataTable();
            dt = pc.ListarPlanCuentas();
            btAceptar.Enabled = false;
            btCancelar.Enabled = false;

            btNuevo.Enabled = true;
            btEliminar.Enabled = true;
            btModificar.Enabled = true;

            tvPlanCuentas.ImageList = ilPlanCuentas;

            if (dt.Rows.Count > 0)
            {
                DataRow[] drs = dt.Select("NivelCuenta = 1");
                foreach (DataRow dr in drs)
                {
                    tvPlanCuentas.Nodes.Add(dr["NumeroCuenta"].ToString(), dr["NombreCuenta"].ToString()).ImageIndex = 1;
                    tvPlanCuentas.Nodes.Find(dr["NumeroCuenta"].ToString(), false)[0].SelectedImageKey = "1";
                }

                foreach (TreeNode tn in tvPlanCuentas.Nodes)
                {
                    CargarNodosHijos(tn.Name);
                }
            }
            else
            {
                MessageBox.Show("No existen registros en el Plan de Cuentas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CargarNodosHijos(string NodoPadre)
        {
            DataRow[] drs = dt.Select("NumeroCuentaPadre = '" + NodoPadre + "'");
            int nivel = 0;
            foreach (DataRow dr in drs)
            {
                nivel = int.Parse(dr["NivelCuenta"].ToString());
                tvPlanCuentas.Nodes.Find(NodoPadre, true)[0].Nodes.Add(dr["NumeroCuenta"].ToString(), dr["NombreCuenta"].ToString()).ImageIndex = nivel;
                tvPlanCuentas.Nodes.Find(dr["NumeroCuenta"].ToString(), true)[0].SelectedImageKey = nivel.ToString();
            }

            foreach (TreeNode tn in tvPlanCuentas.Nodes.Find(NodoPadre, true)[0].Nodes)
            {
                CargarNodosHijos(tn.Name);
            }
        }

        private void CargarDataGridView()
        {
            //dgvPlanCuentas.Rows.Clear();

            PlanCuentasCLN cuentas = new PlanCuentasCLN();
            DataTable dtaux = new DataTable();
            dtaux = cuentas.ListarPlanCuentas();
            dgvPlanCuentas.DataSource = dtaux;
        }

        private void tsbtNuevo_Click(object sender, EventArgs e)
        {
            FPlanCuentasNuevo NuevaCuenta = new FPlanCuentasNuevo();
            if (NuevaCuenta.ShowDialog() == DialogResult.OK)
            {
                Cargar();
                CargarDataGridView();
            }
        }

        private void ModificarCuenta()
        {
            if (dgvPlanCuentas.SelectedRows.Count > 0)
            {
                int indiceCelda = dgvPlanCuentas.SelectedCells[0].RowIndex;


                string NumCuenta = dgvPlanCuentas.SelectedRows[0].Cells["dgvcNumeroCuenta"].Value.ToString();
                string NomCuenta = dgvPlanCuentas.SelectedRows[0].Cells["dgvcNombreCuenta"].Value.ToString();
                string NumCuentaPadre = dgvPlanCuentas.SelectedRows[0].Cells["dgvcNumeroCuentaPadre"].Value.ToString();
                byte Niv = byte.Parse(dgvPlanCuentas.SelectedRows[0].Cells["dgvcNivelCuenta"].Value.ToString());
                string Desc = dgvPlanCuentas.SelectedRows[0].Cells["dgvcDescripcionCuenta"].Value.ToString();

                FPlanCuentasNuevo cuentamodificar = new FPlanCuentasNuevo(NumCuenta, NomCuenta, NumCuentaPadre, Niv, Desc);
                if (cuentamodificar.ShowDialog() == DialogResult.OK)
                {
                    Cargar();
                    CargarDataGridView();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una cuenta.", "Cuenta inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dgvPlanCuentas.Focus();
            }
        }

        private void tsbtModificar_Click(object sender, EventArgs e)
        {
            ModificarCuenta();
        }

        private void dgvPlanCuentas_DoubleClick(object sender, EventArgs e)
        {
            ModificarCuenta();
        }

        private void tsbtEliminar_Click(object sender, EventArgs e)
        {
            EliminarCuenta();
        }

        private void EliminarCuenta()
        {
            if (dgvPlanCuentas.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea eliminar la cuenta?", "Eliminar cuenta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PlanCuentasCLN cuentas = new PlanCuentasCLN();
                    string NumCuenta = dgvPlanCuentas.SelectedRows[0].Cells["dgvcNumeroCuenta"].Value.ToString();
                    cuentas.EliminarCuenta(NumCuenta);
                    Cargar();
                    CargarDataGridView();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una cuenta.", "Cuenta inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dgvPlanCuentas.Focus();
            }
        }

        private void tsbtImprimir_Click(object sender, EventArgs e)
        {
            FReportesPlanCuentas crvcuentas = new FReportesPlanCuentas();
            crvcuentas.ShowDialog();
        }

        private void tcPlanCuentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcPlanCuentas.SelectedIndex == 1)
            {
                tsbtEliminar.Enabled = true;
                tsbtModificar.Enabled = true;
                tsbtNuevo.Enabled = true;
            }
            else
            {
                tsbtEliminar.Enabled = false;
                tsbtModificar.Enabled = false;
                tsbtNuevo.Enabled = false;
            }
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void Eliminar()
        {
            if (tvPlanCuentas.SelectedNode != null)
            {
                if (MessageBox.Show("¿Desea eliminar la cuenta?", "Eliminar cuenta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PlanCuentasCLN cuentas = new PlanCuentasCLN();
                    string NumCuenta = tvPlanCuentas.SelectedNode.Name;
                    cuentas.EliminarCuenta(NumCuenta);
                    Cargar();
                    CargarDataGridView();

                    estadoedicion = '0';
                    chbSelCtaPadre.Checked = false;
                    chbSelCtaPadre.Enabled = false;

                    tvPlanCuentas.Enabled = true;

                    tbDescripcion.ReadOnly = true;
                    tbNombreCta.ReadOnly = true;
                    tbNumCta1.ReadOnly = true;
                    tbNumCta2.ReadOnly = true;
                    tbNumCta3.ReadOnly = true;
                    tbNumCta4.ReadOnly = true;
                    tbNumCta5.ReadOnly = true;

                    pbOk.Visible = false;

                    try
                    {
                        tvPlanCuentas.SelectedNode = tvPlanCuentas.Nodes.Find(mtbCtaPadre.Text, true)[0];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        tvPlanCuentas.SelectedNode = tvPlanCuentas.Nodes[0];
                    }
                    
                }
            }
        }

        private void tvPlanCuentas_AfterSelect(object sender, TreeViewEventArgs e)
        {
            MostrarInfo(e.Node.Name);
            int i = Fila(e.Node.Name);
            dgvPlanCuentas.Rows[i].Selected = true;
        }

        private int Fila(string NumCta)
        {
            int n = dgvPlanCuentas.RowCount;
            int resultado = 0;
            for (int i = 0; i < n; i++)
            {
                if (dgvPlanCuentas.Rows[i].Cells["dgvcNumeroCuenta"].Value.ToString() == NumCta)
                {
                    resultado = i;
                    break;
                }
            }

            return resultado;
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

        private void MostrarInfo(string NumCta)
        {
            if (chbSelCtaPadre.Enabled && chbSelCtaPadre.Checked)
            {
                if (tvPlanCuentas.SelectedNode != null)
                {
                    tbNomCtaPadre.Text = tvPlanCuentas.SelectedNode.Text;
                    mtbCtaPadre.Text = tvPlanCuentas.SelectedNode.Name;
                }
            }
            else if (estadoedicion != 'N')
            {
                DataRow dr = dt.Select("NumeroCuenta = '" + NumCta + "'")[0];
                tbDescripcion.Text = dr["DescripcionCuenta"].ToString();
                tbNombreCta.Text = dr["NombreCuenta"].ToString();
                mtbCtaPadre.Text = dr["NumeroCuentaPadre"].ToString();
                string[] NumeroCta = tvPlanCuentas.SelectedNode.Name.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                tbNumCta1.Text = NumeroCta[0];
                tbNumCta2.Text = NumeroCta[1];
                tbNumCta3.Text = NumeroCta[2];
                tbNumCta4.Text = NumeroCta[3];
                tbNumCta5.Text = NumeroCta[4];
                if (tvPlanCuentas.SelectedNode.Parent != null)
                {
                    tbNomCtaPadre.Text = tvPlanCuentas.SelectedNode.Parent.Text;
                    chbSelCtaPadre.Checked = true;
                }
                else
                {
                    tbNomCtaPadre.Clear();
                    chbSelCtaPadre.Checked = false;
                }

            }
            else if (estadoedicion == 'N')
            {
                mtbCtaPadre.Text = tvPlanCuentas.SelectedNode.Name;
                MostrarInfoNuevo();
            }
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void Nuevo()
        {
            estadoedicion = 'N';
            btNuevo.Enabled = false;
            btEliminar.Enabled = false;
            btModificar.Enabled = false;

            tbDescripcion.ReadOnly = false;
            tbNombreCta.ReadOnly = false;
            mtbCtaPadre.ReadOnly = true;
            tbNumCta1.ReadOnly = true;
            tbNumCta2.ReadOnly = true;
            tbNumCta3.ReadOnly = true;
            tbNumCta4.ReadOnly = true;
            tbNumCta5.ReadOnly = true;
            chbSelCtaPadre.Enabled = true;
            chbSelCtaPadre.Checked = false;

            tbDescripcion.Clear();
            tbNombreCta.Clear();
            mtbCtaPadre.Clear();
            tbNumCta1.Clear();
            tbNumCta2.Clear();
            tbNumCta3.Clear();
            tbNumCta4.Clear();
            tbNumCta5.Clear();

            btAceptar.Enabled = true;
            btCancelar.Enabled = true;

            MostrarInfoNuevo();

            tvPlanCuentas.Enabled = false;
        }

        private void MostrarInfoNuevo()
        {
            if (tvPlanCuentas.SelectedNode == null)
            {
                mtbCtaPadre.ReadOnly = true;
                tbNomCtaPadre.ReadOnly = true;
            }
            else if (tvPlanCuentas.SelectedNode.ImageIndex > 0)
            {
                int niv = tvPlanCuentas.SelectedNode.ImageIndex;

                if (niv == 5)
                {
                    mtbCtaPadre.Text = tvPlanCuentas.SelectedNode.Parent.Name;
                    tbNomCtaPadre.Text = tvPlanCuentas.SelectedNode.Parent.Text;
                }
                else
                {
                    mtbCtaPadre.Text = tvPlanCuentas.SelectedNode.Name;
                    tbNomCtaPadre.Text = tvPlanCuentas.SelectedNode.Text;
                }

                chbSelCtaPadre.Checked = true;

                string[] ctapadre = mtbCtaPadre.Text.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                int aux;                
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
        }

        private int SiguienteNumCta(int n)
        {
            int aux = 0;

            //int ctapadre = int.Parse(mtbCtaPadre.Text.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)[4]);
            DataRow draux = dt.Select("NumeroCuentaPadre = '" + mtbCtaPadre.Text + "'", "NumeroCuenta DESC")[0];
            aux = int.Parse(draux["NumeroCuenta"].ToString().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)[n]);            

            return aux++;
        }

        /*private void MostrarInfoModificar()
        {
            if (tvPlanCuentas.SelectedNode == null)
            {
                nudNivelCta.Value = 1;
                mtbCtaPadre.ReadOnly = true;
                nudNivelCta.ReadOnly = true;
            }
            else
            {
                nudNivelCta.Value = tvPlanCuentas.SelectedNode.ImageIndex;
                mtbCtaPadre.Text = tvPlanCuentas.SelectedNode.Parent.Name;
                mtbNumCta.Text = tvPlanCuentas.SelectedNode.Name;
                mtbNumCta.Focus();
                DataRow dr = dt.Select("NumeroCuenta = '" + mtbNumCta.Text + "'")[0];

            }
        }*/

        private void btCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void Cancelar()
        {
            estadoedicion = '0';

            btEliminar.Enabled = true;
            btNuevo.Enabled = true;
            btModificar.Enabled = true;
            btAceptar.Enabled = false;
            btCancelar.Enabled = false;

            tbDescripcion.ReadOnly = true;
            tbNombreCta.ReadOnly = true;
            mtbCtaPadre.ReadOnly = true;
            tbNomCtaPadre.ReadOnly = true;
            tbNumCta1.ReadOnly = true;
            tbNumCta2.ReadOnly = true;
            tbNumCta3.ReadOnly = true;
            tbNumCta4.ReadOnly = true;
            tbNumCta5.ReadOnly = true;
            chbSelCtaPadre.Enabled = false;
            chbSelCtaPadre.Checked = false;
            pbOk.Visible = false;

            tvPlanCuentas.Enabled = true;

            if (tvPlanCuentas.SelectedNode != null)
                MostrarInfo(tvPlanCuentas.SelectedNode.Name);
            else
            {
                tbDescripcion.Clear();
                tbNombreCta.Clear();
                tbNomCtaPadre.Clear();
                mtbCtaPadre.Clear();
                tbNumCta1.Clear();
                tbNumCta2.Clear();
                tbNumCta3.Clear();
                tbNumCta4.Clear();
                tbNumCta5.Clear();
            }

            mtbCtaPadre.Focus();
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void Modificar()
        {
            if (tvPlanCuentas.SelectedNode != null)
            {
                estadoedicion = 'M';
                btNuevo.Enabled = false;
                btEliminar.Enabled = false;
                btModificar.Enabled = false;

                tbDescripcion.ReadOnly = false;
                tbNombreCta.ReadOnly = false;

                int aux = NivelCuenta(tvPlanCuentas.SelectedNode.Name);

                switch (aux)
                {
                    case 1:
                        mtbCtaPadre.Enabled = false;
                        tbNomCtaPadre.Enabled = false;

                        tbNumCta1.ReadOnly = true;
                        /*tbNumCta1.Focus();
                        tbNumCta1.SelectAll();*/
                        tbNumCta2.ReadOnly = true;
                        tbNumCta3.ReadOnly = true;
                        tbNumCta4.ReadOnly = true;
                        tbNumCta5.ReadOnly = true;
                        break;
                    case 2:
                        mtbCtaPadre.Enabled = false;
                        tbNomCtaPadre.Enabled = false;

                        tbNumCta1.ReadOnly = true;
                        tbNumCta2.ReadOnly = true;
                        /*tbNumCta2.Focus();
                        tbNumCta2.SelectAll();*/
                        tbNumCta3.ReadOnly = true;
                        tbNumCta4.ReadOnly = true;
                        tbNumCta5.ReadOnly = true;
                        break;
                    case 3:
                        mtbCtaPadre.Enabled = false;
                        tbNomCtaPadre.Enabled = false;

                        tbNumCta1.ReadOnly = true;
                        tbNumCta2.ReadOnly = true;
                        tbNumCta3.ReadOnly = true;
                        /*tbNumCta3.Focus();
                        tbNumCta3.SelectAll();*/
                        tbNumCta4.ReadOnly = true;
                        tbNumCta5.ReadOnly = true;
                        break;
                    case 4:
                        mtbCtaPadre.Enabled = false;
                        tbNomCtaPadre.Enabled = false;

                        tbNumCta1.ReadOnly = true;
                        tbNumCta2.ReadOnly = true;
                        tbNumCta3.ReadOnly = true;
                        tbNumCta4.ReadOnly = true;
                        /*tbNumCta4.Focus();
                        tbNumCta4.SelectAll();*/
                        tbNumCta5.ReadOnly = true;
                        break;
                    case 5:
                        mtbCtaPadre.Enabled = false;
                        tbNomCtaPadre.Enabled = false;

                        tbNumCta1.ReadOnly = true;
                        tbNumCta2.ReadOnly = true;
                        tbNumCta3.ReadOnly = true;
                        tbNumCta4.ReadOnly = true;
                        tbNumCta5.ReadOnly = true;
                        /*tbNumCta5.Focus();
                        tbNumCta5.SelectAll();*/
                        break;
                }

                tbNombreCta.Focus();
                tbNombreCta.SelectAll();
                btAceptar.Enabled = true;
                btCancelar.Enabled = true;

            }
        }


        private void mtbCtaPadre_Leave(object sender, EventArgs e)
        {
            CargarInfoPadre();
        }

        private bool CargarInfoPadre()
        {
            bool resultado = false;

            if (estadoedicion != '0')
            {
                DataRow[] drs = dt.Select("NumeroCuenta = '" + mtbCtaPadre.Text + "'");
                if (drs.Length > 0)
                {
                    tbNomCtaPadre.Text = drs[0]["NombreCuenta"].ToString();
                    resultado = true;
                }
                else
                {
                    MessageBox.Show("Número de cuenta inválido (Cuenta Padre).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    mtbCtaPadre.SelectAll();
                    resultado = false;
                }
            }

            return resultado;
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (chbSelCtaPadre.Checked)
            {
                if (CargarInfoPadre())
                {
                    if (estadoedicion == 'N')
                    {
                        string NumCta = tbNumCta1.Text + '-' + tbNumCta2.Text + '-' + tbNumCta3.Text + '-' + tbNumCta4.Text + '-' + tbNumCta5.Text;

                        if (pbOk.Visible)
                        {
                            if (tbNombreCta.Text != string.Empty)
                            {
                                PlanCuentasCLN pc = new PlanCuentasCLN();
                                pc.InsertarPlanCuentas(NumCta, tbNombreCta.Text, mtbCtaPadre.Text, NivelCuenta(NumCta), tbDescripcion.Text);
                                MessageBox.Show("Datos registrados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Cargar();
                                CargarDataGridView();

                                estadoedicion = '0';
                                chbSelCtaPadre.Checked = false;
                                chbSelCtaPadre.Enabled = false;

                                tvPlanCuentas.Enabled = true;

                                tbDescripcion.ReadOnly = true;
                                tbNombreCta.ReadOnly = true;
                                tbNumCta1.ReadOnly = true;
                                tbNumCta2.ReadOnly = true;
                                tbNumCta3.ReadOnly = true;
                                tbNumCta4.ReadOnly = true;
                                tbNumCta5.ReadOnly = true;

                                pbOk.Visible = false;
                                tvPlanCuentas.SelectedNode = tvPlanCuentas.Nodes.Find(mtbCtaPadre.Text, true)[0];
                                tvPlanCuentas.SelectedNode.Expand();
                            }
                            else
                            {
                                MessageBox.Show("Debe introducir un nombre de cuenta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                tbNombreCta.Focus();
                                tbNombreCta.SelectAll();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Número de cuenta inválido (Debe contender 13 caracteres).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            tbNumCta1.Focus();
                            tbNumCta1.SelectAll();
                        }
                    }
                    else if (estadoedicion == 'M')
                    {
                        string NumCta = tbNumCta1.Text + '-' + tbNumCta2.Text + '-' + tbNumCta3.Text + '-' + tbNumCta4.Text + '-' + tbNumCta5.Text;

                        if (tvPlanCuentas.SelectedNode.Name == NumCta || !ExisteNumeroCuenta(NumCta))
                        {
                            if (tbNombreCta.Text != string.Empty || tbNombreCta.Text != tvPlanCuentas.SelectedNode.Text)
                            {
                                PlanCuentasCLN pc = new PlanCuentasCLN();
                                pc.ActualizarPlanCuentas(NumCta, tbNombreCta.Text, mtbCtaPadre.Text, NivelCuenta(NumCta), tbDescripcion.Text);
                                MessageBox.Show("Datos actualizados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Cargar();
                                CargarDataGridView();
                                tvPlanCuentas.Enabled = true;
                                pbOk.Visible = false;

                                estadoedicion = '0';
                                chbSelCtaPadre.Checked = false;
                                chbSelCtaPadre.Enabled = false;

                                tvPlanCuentas.Enabled = true;

                                tbDescripcion.ReadOnly = true;
                                tbNombreCta.ReadOnly = true;
                                tbNumCta1.ReadOnly = true;
                                tbNumCta2.ReadOnly = true;
                                tbNumCta3.ReadOnly = true;
                                tbNumCta4.ReadOnly = true;
                                tbNumCta5.ReadOnly = true;

                                pbOk.Visible = false;
                                tvPlanCuentas.SelectedNode = tvPlanCuentas.Nodes.Find(mtbCtaPadre.Text, true)[0];
                                tvPlanCuentas.SelectedNode.Expand();
                            }
                            else
                            {
                                MessageBox.Show("Debe introducir un nombre de cuenta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                tbNombreCta.Focus();
                                tbNombreCta.SelectAll();
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
                else
                {
                    MessageBox.Show("Número de cuenta inválido (Cuenta Padre).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    mtbCtaPadre.Focus();
                    mtbCtaPadre.SelectAll();
                }
            }
            else
            {
                if (estadoedicion == 'N')
                {
                    string NumCta = tbNumCta1.Text + '-' + tbNumCta2.Text + '-' + tbNumCta3.Text + '-' + tbNumCta4.Text + '-' + tbNumCta5.Text;
                    if (pbOk.Visible)
                    {
                        if (tbNombreCta.Text != string.Empty)
                        {
                            PlanCuentasCLN pc = new PlanCuentasCLN();
                            pc.InsertarPlanCuentas(NumCta, tbNombreCta.Text, string.Empty, NivelCuenta(NumCta), tbDescripcion.Text);
                            MessageBox.Show("Datos registrados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cargar();
                            CargarDataGridView();
                            tvPlanCuentas.Enabled = true;
                            pbOk.Visible = false;

                            estadoedicion = '0';
                            chbSelCtaPadre.Checked = false;
                            chbSelCtaPadre.Enabled = false;

                            tvPlanCuentas.Enabled = true;

                            tbDescripcion.ReadOnly = true;
                            tbNombreCta.ReadOnly = true;
                            tbNumCta1.ReadOnly = true;
                            tbNumCta2.ReadOnly = true;
                            tbNumCta3.ReadOnly = true;
                            tbNumCta4.ReadOnly = true;
                            tbNumCta5.ReadOnly = true;

                            pbOk.Visible = false;
                            tvPlanCuentas.SelectedNode = tvPlanCuentas.Nodes[0];
                            
                        }
                        else
                        {
                            MessageBox.Show("Debe introducir un nombre de cuenta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            tbNombreCta.Focus();
                            tbNombreCta.SelectAll();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Número de cuenta inválido (La cuenta ya existe)..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tbNumCta1.Focus();
                        tbNumCta1.SelectAll();
                    }
                }
                else if (estadoedicion == 'M')
                {
                    string NumCta = tbNumCta1.Text + '-' + tbNumCta2.Text + '-' + tbNumCta3.Text + '-' + tbNumCta4.Text + '-' + tbNumCta5.Text;

                    if (tvPlanCuentas.SelectedNode.Name == NumCta || !ExisteNumeroCuenta(NumCta))
                    {
                        if (tbNombreCta.Text != string.Empty)
                        {
                            PlanCuentasCLN pc = new PlanCuentasCLN();
                            pc.ActualizarPlanCuentas(NumCta, tbNombreCta.Text, string.Empty, NivelCuenta(NumCta), tbDescripcion.Text);
                            MessageBox.Show("Datos actualizados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cargar();
                            CargarDataGridView();
                            tvPlanCuentas.Enabled = true;
                            pbOk.Visible = false;

                            estadoedicion = '0';
                            chbSelCtaPadre.Checked = false;
                            chbSelCtaPadre.Enabled = false;

                            tvPlanCuentas.Enabled = true;

                            tbDescripcion.ReadOnly = true;
                            tbNombreCta.ReadOnly = true;
                            tbNumCta1.ReadOnly = true;
                            tbNumCta2.ReadOnly = true;
                            tbNumCta3.ReadOnly = true;
                            tbNumCta4.ReadOnly = true;
                            tbNumCta5.ReadOnly = true;

                            pbOk.Visible = false;
                            tvPlanCuentas.SelectedNode = tvPlanCuentas.Nodes[0];
                            
                        }
                        else
                        {
                            MessageBox.Show("Debe introducir un nombre de cuenta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            tbNombreCta.Focus();
                            tbNombreCta.SelectAll();
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
        }

        private void chbSelCtaPadre_CheckedChanged(object sender, EventArgs e)
        {
            if (chbSelCtaPadre.Checked && estadoedicion != '0')
            {
                tbNumCta1.ReadOnly = true;
                tbNumCta1.Text = cta0.ToString();

                //string[] ctapadre = mtbCtaPadre.Text.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                /*switch (tvPlanCuentas.SelectedNode.Level)
                {
                    case 0:
                        tbNumCta2.ReadOnly = false;
                        tbNumCta3.ReadOnly = false;
                        tbNumCta4.ReadOnly = false;
                        tbNumCta5.ReadOnly = false;
                        break;
                    case 1:
                        tbNumCta2.ReadOnly = true;
                        tbNumCta3.ReadOnly = false;
                        tbNumCta4.ReadOnly = false;
                        tbNumCta5.ReadOnly = false;
                        break;
                    case 2:
                        tbNumCta2.ReadOnly = true;
                        tbNumCta3.ReadOnly = true;
                        tbNumCta4.ReadOnly = false;
                        tbNumCta5.ReadOnly = false;
                        break;
                    case 3:
                    case 4:
                        tbNumCta2.ReadOnly = true;
                        tbNumCta3.ReadOnly = true;
                        tbNumCta4.ReadOnly = true;
                        tbNumCta5.ReadOnly = false;
                        break;
                }*/

                /*mtbCtaPadre.Enabled = true;
                tbNomCtaPadre.Enabled = true;

                int n = NivelCuenta(mtbCtaPadre.Text);

                switch (n)
                {
                    case 1:
                        tbNumCta2.ReadOnly = false;
                        break;
                    case 2:
                        tbNumCta2.ReadOnly = true;
                        break;
                    case 3:
                        tbNumCta2.ReadOnly = true;
                        tbNumCta3.ReadOnly = true;
                        break;
                    case 4:
                        tbNumCta3.ReadOnly = true;
                        tbNumCta4.ReadOnly = true;
                        break;
                }*/

                MostrarInfoNuevo();
            }
            else if (estadoedicion != '0')
            {
                DataRow draux = dt.Select("NivelCuenta = 1", "NumeroCuenta DESC")[0];

                tbNumCta1.ReadOnly = false;
                cta0 = byte.Parse(tbNumCta1.Text);
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

                mtbCtaPadre.Enabled = false;
                tbNomCtaPadre.Enabled = false;
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

        private void ControlarNumeroCuenta()
        {
            if (estadoedicion == 'N')
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

        private void tbNumCta1_Leave(object sender, EventArgs e)
        {
            if (tbNumCta1.Text == string.Empty)
            {
                tbNumCta1.Text = "1";
            }

            ControlarNumeroCuenta();
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
                tbNumCta5.Text = "000";
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

        private void cmsTvPlanCuentas_Opening(object sender, CancelEventArgs e)
        {
            if (tvPlanCuentas.SelectedNode != null)
            {
                modificarToolStripMenuItem.Enabled = true;
                eliminarToolStripMenuItem.Enabled = true;
            }
            else
            {
                modificarToolStripMenuItem.Enabled = false;
                eliminarToolStripMenuItem.Enabled = false;
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void dgvPlanCuentas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvPlanCuentas.SelectedRows.Count == 1)
            {
                string numcta = dgvPlanCuentas.SelectedRows[0].Cells["dgvcNumeroCuenta"].Value.ToString();
                string nomcta = dgvPlanCuentas.SelectedRows[0].Cells["dgvcNombreCuenta"].Value.ToString();
                string numctapdr = dgvPlanCuentas.SelectedRows[0].Cells["dgvcNumeroCuentaPadre"].Value.ToString();
                byte niv = byte.Parse(dgvPlanCuentas.SelectedRows[0].Cells["dgvcNivelCuenta"].Value.ToString());
                string descr = dgvPlanCuentas.SelectedRows[0].Cells["dgvcDescripcionCuenta"].Value.ToString();
                FPlanCuentasNuevo fpn = new FPlanCuentasNuevo(numcta, nomcta, numctapdr, niv, descr);

                if (fpn.ShowDialog() == DialogResult.OK)
                {
                    Cargar();
                    CargarDataGridView();
                }
            }
        }


    }
}


