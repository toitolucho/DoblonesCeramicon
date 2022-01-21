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
using CLCLN.GestionComercial;
using WFADoblones20.FormulariosGestionComercial;

namespace WFADoblones20.FormulariosContabilidad
{
    public partial class FCuentasPorCobrarNuevo : Form
    {
        private int CodUsuario;
        private int NumCtaPorCobrar;
        private int NumAgencia;
        private bool p0, p1, p2, p3, p4;

        public FCuentasPorCobrarNuevo(int CodigoUsuario, int NumeroAgencia, bool P0, bool P1, bool P2, bool P3, bool P4)
        {
            InitializeComponent();

            groupBox2.Visible = false;
            this.Width = 380;

            this.CodUsuario = CodigoUsuario;
            this.NumAgencia = NumeroAgencia;

            p0 = P0;
            p1 = P1;
            p2 = P2;
            p3 = P3;
            p4 = P4;

            CargarMonedas();
            CargarProveedores();
            CargarConceptos();
        }

        public FCuentasPorCobrarNuevo(string NumeroCuentaPorCobrar, int CodigoUsuario, int NumeroAgencia, bool P0, bool P1, bool P2, bool P3, bool P4)
        {
            InitializeComponent();

            groupBox2.Visible = true;
            this.Width = 660;

            btModificar.Enabled = false;
            btEliminar.Enabled = false;

            p0 = P0;
            p1 = P1;
            p2 = P2;
            p3 = P3;
            p4 = P4;

            CargarMonedas();
            CargarProveedores();
            CargarConceptos();

            CuentasPorCobrarCLN cpp = new CuentasPorCobrarCLN();
            DataTable dt = cpp.ListarCuentasPorCobrarPorNumeroCuenta(int.Parse(NumeroCuentaPorCobrar));

            this.CodUsuario = CodigoUsuario;
            this.NumCtaPorCobrar = int.Parse(NumeroCuentaPorCobrar);
            this.NumAgencia = NumeroAgencia;

            int n = cbMoneda.Items.Count;
            DataRowView obj;
            string cod = dt.Rows[0]["CodigoMoneda"].ToString();
            for (int i = 0; i < n; i++)
            {
                obj = (DataRowView)cbMoneda.Items[i];
                if (obj.Row["CodigoMoneda"].ToString() == cod)
                {
                    cbMoneda.SelectedIndex = i;
                    break;
                }
            }

            n = cbProveedores.Items.Count;
            cod = dt.Rows[0]["CodigoProveedor"].ToString();
            for (int i = 0; i < n; i++)
            {
                obj = (DataRowView)cbProveedores.Items[i];
                if (obj.Row["CodigoProveedor"].ToString() == cod)
                {
                    cbProveedores.SelectedIndex = i;
                    break;
                }
            }

            n = cbConceptos.Items.Count;
            cod = dt.Rows[0]["NumeroConcepto"].ToString();
            for (int i = 0; i < n; i++)
            {
                obj = (DataRowView)cbConceptos.Items[i];
                if (obj.Row["NumeroConcepto"].ToString() == cod)
                {
                    cbConceptos.SelectedIndex = i;
                    break;
                }
            }


            tbMonto.Text = dt.Rows[0]["Monto"].ToString();
            tbDescripcion.Text = dt.Rows[0]["Observaciones"].ToString();
            DateTime fecha = DateTime.Now;
            try
            {
                fecha = DateTime.Parse(dt.Rows[0]["FechaLimite"].ToString());
            }
            catch (FormatException)
            {
                chbxFechaLim.Checked = false;
            }

            dtpFechaLim.Value = fecha;

            if (dt.Rows[0]["CodigoEstado"].ToString() == "C")
            {
                chbxEstado.Checked = true;
            }
            else
            {
                chbxEstado.Checked = false;
            }

            this.Text = "Modificar cuenta por cobrar";
            btAceptar.Text = "Modificar";

            CargarTablaPagos(NumCtaPorCobrar);
        }

        private void CargarTablaPagos(int NumeroCuentaPorCobrar)
        {
            CuentasPorCobrarCobrosCLN cobros = new CuentasPorCobrarCobrosCLN();
            //dgvDetalle.DataSource = cobros.ListarCuentasPorCobrarCobros(NumeroCuentaPorCobrar);
            dgvDetalle.DataSource = cobros.ListarCuentasPorCobrarCobrosDetalle(NumeroCuentaPorCobrar);
        }

        private void CargarMonedas()
        {
            MonedasCLN monedas = new MonedasCLN();
            DataTable dt = monedas.ListarMonedas();
            if (dt.Rows.Count > 0)
            {
                cbMoneda.DataSource = dt.DefaultView;
                cbMoneda.ValueMember = "CodigoMoneda";
                cbMoneda.DisplayMember = "NombreMoneda";
            }
            else
            {
                MessageBox.Show("No se ha podido cargar la lista de Monedas", "Error en la base de datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void CargarProveedores()
        {
            ProveedoresCLN proveedores = new ProveedoresCLN();
            DataTable dt = proveedores.ListarProveedores();

            if (dt.Rows.Count > 0)
            {
                cbProveedores.DataSource = dt.DefaultView;
                cbProveedores.ValueMember = "CodigoProveedor";
                cbProveedores.DisplayMember = "NombreRazonSocial";
            }
        }

        private void CargarConceptos()
        {
            ConceptosCLN conceptos = new ConceptosCLN();
            DataTable dt = conceptos.ListarConceptos();

            if (dt.Rows.Count > 0)
            {
                cbConceptos.DataSource = dt.DefaultView;
                cbConceptos.ValueMember = "NumeroConcepto";
                cbConceptos.DisplayMember = "Concepto";
            }
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (cbProveedores.SelectedIndex > -1)
            {
                if (cbConceptos.SelectedIndex > -1)
                {
                    if (tbMonto.Text != string.Empty)
                    {
                        decimal Monto;
                        if (decimal.TryParse(tbMonto.Text, out Monto))
                        {
                            if (cbMoneda.SelectedIndex > -1)
                            {
                                CuentasPorCobrarCLN cuenta = new CuentasPorCobrarCLN();
                                int NumAsiento = -1;
                                FAsientosDetalle fad;

                                string Estado;
                                if (chbxEstado.Checked)
                                    Estado = "C";
                                else
                                    Estado = "P";

                                int numconcepto = 0;
                                int numproveedor = 0;
                                if (cbConceptos.SelectedValue != null)
                                    numconcepto = int.Parse(cbConceptos.SelectedValue.ToString());
                                if (cbProveedores.SelectedValue != null)
                                    numproveedor = int.Parse(cbProveedores.SelectedValue.ToString());
                                if (chbxFechaLim.Checked)
                                {
                                    if (btAceptar.Text == "Modificar")
                                    {
                                        /*if (chbAsientos.Checked)
                                        {
                                            fad = new FAsientosDetalle(CodUsuario, p0, p1, p2, p3, p4);
                                            if (fad.ShowDialog() == DialogResult.OK)
                                            {
                                                NumAsiento = fad.GetNumeroAsiento;
                                                cuenta.ActualizarCuentaPorCobrar(this.NumCtaPorCobrar, int.Parse(cbConceptos.SelectedValue.ToString()), this.NumAgencia, int.Parse(cbProveedores.SelectedValue.ToString()), byte.Parse(cbMoneda.SelectedValue.ToString()), Monto, dtpFechaLim.Value, Estado, tbDescripcion.Text, CodUsuario, NumAsiento);
                                                this.DialogResult = DialogResult.OK;
                                                this.Close();
                                            }
                                        }
                                        else
                                        {*/
                                            cuenta.ActualizarCuentaPorCobrar(this.NumCtaPorCobrar, numconcepto, this.NumAgencia, numproveedor, byte.Parse(cbMoneda.SelectedValue.ToString()), Monto, dtpFechaLim.Value, Estado, tbDescripcion.Text, CodUsuario, NumAsiento);
                                            MessageBox.Show("Datos actualizados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            this.DialogResult = DialogResult.OK;
                                            this.Close();
                                        //}
                                    }
                                    else
                                    {
                                        /*if (chbAsientos.Checked)
                                        {
                                            fad = new FAsientosDetalle(CodUsuario, p0, p1, p2, p3, p4);
                                            if (fad.ShowDialog() == DialogResult.OK)
                                            {
                                                NumAsiento = fad.GetNumeroAsiento;
                                                cuenta.InsertarCuentaPorCobrar(this.NumAgencia, int.Parse(cbConceptos.SelectedValue.ToString()), int.Parse(cbProveedores.SelectedValue.ToString()), byte.Parse(cbMoneda.SelectedValue.ToString()), Monto, dtpFechaLim.Value, Estado, tbDescripcion.Text, CodUsuario, NumAsiento);
                                                this.DialogResult = DialogResult.OK;
                                                this.Close();
                                            }
                                        }
                                        else
                                        {*/
                                            
                                            cuenta.InsertarCuentaPorCobrar(this.NumAgencia, numconcepto, numproveedor, byte.Parse(cbMoneda.SelectedValue.ToString()), Monto, dtpFechaLim.Value, Estado, tbDescripcion.Text, CodUsuario, NumAsiento);
                                            MessageBox.Show("Datos registrados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            this.DialogResult = DialogResult.OK;
                                            this.Close();
                                        //}
                                    }
                                }
                                else
                                {
                                    if (btAceptar.Text == "Modificar")
                                    {
                                        /*if (chbAsientos.Checked)
                                        {
                                            fad = new FAsientosDetalle(CodUsuario, p0, p1, p2, p3, p4);
                                            if (fad.ShowDialog() == DialogResult.OK)
                                            {
                                                NumAsiento = fad.GetNumeroAsiento;
                                                cuenta.ActualizarCuentaPorCobrar(this.NumCtaPorCobrar, int.Parse(cbConceptos.SelectedValue.ToString()), this.NumAgencia, int.Parse(cbProveedores.SelectedValue.ToString()), byte.Parse(cbMoneda.SelectedValue.ToString()), Monto, new DateTime(), Estado, tbDescripcion.Text, CodUsuario, NumAsiento);
                                                this.DialogResult = DialogResult.OK;
                                                this.Close();
                                            }
                                        }
                                        else
                                        {*/
                                            cuenta.ActualizarCuentaPorCobrar(this.NumCtaPorCobrar, int.Parse(cbConceptos.SelectedValue.ToString()), this.NumAgencia, int.Parse(cbProveedores.SelectedValue.ToString()), byte.Parse(cbMoneda.SelectedValue.ToString()), Monto, new DateTime(), Estado, tbDescripcion.Text, CodUsuario, NumAsiento);
                                            MessageBox.Show("Datos actualizados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            this.DialogResult = DialogResult.OK;
                                            this.Close();
                                        //}
                                    }
                                    else
                                    {
                                        /*if (chbAsientos.Checked)
                                        {
                                            fad = new FAsientosDetalle(CodUsuario, p0, p1, p2, p3, p4);
                                            if (fad.ShowDialog() == DialogResult.OK)
                                            {
                                                NumAsiento = fad.GetNumeroAsiento;
                                                cuenta.InsertarCuentaPorCobrar(this.NumAgencia, int.Parse(cbConceptos.SelectedValue.ToString()), int.Parse(cbProveedores.SelectedValue.ToString()), byte.Parse(cbMoneda.SelectedValue.ToString()), Monto, new DateTime(), Estado, tbDescripcion.Text, CodUsuario, NumAsiento);
                                                this.DialogResult = DialogResult.OK;
                                                this.Close();
                                            }
                                        }
                                        else
                                        {*/
                                            cuenta.InsertarCuentaPorCobrar(this.NumAgencia, numconcepto, numproveedor, byte.Parse(cbMoneda.SelectedValue.ToString()), Monto, new DateTime(), Estado, tbDescripcion.Text, CodUsuario, NumAsiento);
                                            MessageBox.Show("Datos registrados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            this.DialogResult = DialogResult.OK;
                                            this.Close();
                                        //}
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Debe seleccionar una Moneda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                cbMoneda.Focus();
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
                else
                {
                    MessageBox.Show("Debe seleccionar un Concepto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbConceptos.Focus();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbProveedores.Focus();
            }
        }

        private void tbMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & (Keys)e.KeyChar != Keys.Enter & e.KeyChar != ',' & e.KeyChar != '.')
            {
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void dgvDetalle_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDetalle.SelectedRows.Count == 1)
            {
                btModificar.Enabled = true;
                btEliminar.Enabled = true;
            }
            else
            {
                btModificar.Enabled = false;
                btEliminar.Enabled = false;
            }
        }

        private void btPagar_Click(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)cbMoneda.SelectedItem;
            FPagarCuentasPorCobrar fpcpc = new FPagarCuentasPorCobrar(NumCtaPorCobrar, CodUsuario, drv["NombreMoneda"].ToString());

            if (fpcpc.ShowDialog() == DialogResult.OK)
            {
                CargarTablaPagos(NumCtaPorCobrar);
            }
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void Modificar()
        {
            DataRowView drv = (DataRowView)cbMoneda.SelectedItem;
            string Monto = dgvDetalle.SelectedRows[0].Cells["dgvcMonto"].Value.ToString();
            int NumeroCobro = int.Parse(dgvDetalle.SelectedRows[0].Cells["dgvcNumeroPago"].Value.ToString());

            FPagarCuentasPorCobrar fpcpc = new FPagarCuentasPorCobrar(NumeroCobro, CodUsuario, drv["NombreMoneda"].ToString(), Monto);

            if (fpcpc.ShowDialog() == DialogResult.OK)
            {
                CargarTablaPagos(NumCtaPorCobrar);
            }
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CuentasPorCobrarCobrosCLN cobro = new CuentasPorCobrarCobrosCLN();
                int NumeroCobro = int.Parse(dgvDetalle.SelectedRows[0].Cells["dgvcNumeroPago"].Value.ToString());
                cobro.EliminarCuentaPorCobrarCobro(NumeroCobro);
                CargarTablaPagos(NumCtaPorCobrar);
            }
        }

        private void chbxFechaLim_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxFechaLim.Checked)
            {
                dtpFechaLim.Enabled = true;
            }
            else
            {
                dtpFechaLim.Enabled = false;
            }
        }

        private void FCuentasPorCobrarNuevo_Load(object sender, EventArgs e)
        {

        }

        private void dgvDetalle_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvDetalle.SelectedRows.Count == 1)
            {
                Modificar();
            }
        }

        private void btNuevoConcepto_Click(object sender, EventArgs e)
        {
            FConcepto fc = new FConcepto();
            if (fc.ShowDialog() == DialogResult.OK)
            {
                CargarConceptos();
            }
        }

        private void btNuevoProveedor_Click(object sender, EventArgs e)
        {
            FProveedores fp = new FProveedores(p0, p1, p2, p3);
            fp.ShowDialog();
            CargarProveedores();
        }

        private void tbMonto_Leave(object sender, EventArgs e)
        {
            decimal montodinero;
            if (decimal.TryParse(tbMonto.Text, out montodinero))
            {
                tbMonto.Text = montodinero.ToString("F2");
            }
            else
            {
                MessageBox.Show("Monto inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbMonto.Focus();
                tbMonto.SelectAll();
            }
        }

        public void cargarDatosParaCompra(string ConceptoPorDefecto, int CodigoProveedor, byte CodigoMoneda, decimal MontoMaximo, decimal MontoCobro, string Observaciones)
        {
            CargarConceptos();
            CargarProveedores();
            CargarMonedas();
            cbConceptos.SelectedItem = ConceptoPorDefecto;
            cbProveedores.SelectedValue = CodigoProveedor;
            cbMoneda.SelectedValue = CodigoMoneda;
            tbMonto.Text = MontoCobro.ToString();
            tbDescripcion.Text = Observaciones;

            this.cbProveedores.Enabled = false;
            cbMoneda.Enabled = false;
            tbMonto.Enabled = false;
            chbxEstado.Enabled = false;
        }
    }
}
