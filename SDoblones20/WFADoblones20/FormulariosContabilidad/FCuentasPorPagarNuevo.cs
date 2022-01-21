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
    public partial class FCuentasPorPagarNuevo : Form
    {
        private int CodUsuario;
        private int NumCtaPorPagar;
        private int NumAgencia;
        private bool p0, p1, p2, p3, p4;

        public FCuentasPorPagarNuevo(int CodigoUsuario, int NumeroAgencia, bool P0, bool P1, bool P2, bool P3, bool P4)
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

            btAceptar.Text = "Registrar";
        }

        /// <summary>
        /// Constructor para modificar
        /// </summary>
        /// <param name="NumeroCuentaPorPagar"></param>
        public FCuentasPorPagarNuevo(string NumeroCuentaPorPagar, int CodigoUsuario, int NumeroAgencia, bool P0, bool P1, bool P2, bool P3, bool P4)
        {
            InitializeComponent();

            groupBox2.Visible = true;
            this.Width = 660;

            btModificar.Enabled = false;
            btEliminar.Enabled = false;


            bool esdecomprasproductos = new CuentasPorPagarCLN().EsDeCompraProductos(int.Parse(NumeroCuentaPorPagar));

            p0 = P0;
            p1 = P1;
            p2 = P2;
            p3 = P3;
            p4 = P4;

            CargarMonedas();
            CargarProveedores();
            CargarConceptos();

            CuentasPorPagarCLN cpp = new CuentasPorPagarCLN();
            DataTable dt = cpp.ListarCuentasPorPagar(int.Parse(NumeroCuentaPorPagar));

            this.CodUsuario = CodigoUsuario;
            this.NumCtaPorPagar = int.Parse(NumeroCuentaPorPagar);
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

            n = cbProveedor.Items.Count;
            cod = dt.Rows[0]["CodigoProveedor"].ToString();
            for (int i = 0; i < n; i++)
            {
                obj = (DataRowView)cbProveedor.Items[i];
                if (obj.Row["CodigoProveedor"].ToString() == cod)
                {
                    cbProveedor.SelectedIndex = i;
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

            this.Text = "Modificar cuenta por pagar";
            btAceptar.Text = "Modificar";

            CargarTablaPagos(NumCtaPorPagar);

            if (esdecomprasproductos)
            {
                MessageBox.Show("Esta Cuenta Por Pagar fue generada de una transacción por compra.\n" +
                    "Por este motivo se han deshabilitado las opciones de modificación.\n" +
                    "Solo se podran registrar nuevos pagos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                groupBox1.Enabled = false;

                btAceptar.Text = "Aceptar";
            }
        }

        /// <summary>
        /// Constructor solo para VER desde Cuentas x pagar Compras
        /// </summary>
        /// <param name="CodigoUsuario"></param>
        /// <param name="NumeroCuentaPorPagar"></param>
        /// <param name="NumeroAgencia"></param>
        /// <param name="P0"></param>
        /// <param name="P1"></param>
        /// <param name="P2"></param>
        /// <param name="P3"></param>
        /// <param name="P4"></param>
        public FCuentasPorPagarNuevo(int CodigoUsuario, string NumeroCuentaPorPagar, int NumeroAgencia, bool P0, bool P1, bool P2, bool P3, bool P4)
        {
            InitializeComponent();

            groupBox2.Visible = true;
            this.Width = 660;

            btModificar.Enabled = false;
            btEliminar.Enabled = false;


            bool esdecomprasproductos = new CuentasPorPagarCLN().EsDeCompraProductos(int.Parse(NumeroCuentaPorPagar));

            p0 = P0;
            p1 = P1;
            p2 = P2;
            p3 = P3;
            p4 = P4;

            CargarMonedas();
            CargarProveedores();
            CargarConceptos();

            CuentasPorPagarCLN cpp = new CuentasPorPagarCLN();
            DataTable dt = cpp.ListarCuentasPorPagar(int.Parse(NumeroCuentaPorPagar));

            this.CodUsuario = CodigoUsuario;
            this.NumCtaPorPagar = int.Parse(NumeroCuentaPorPagar);
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

            n = cbProveedor.Items.Count;
            cod = dt.Rows[0]["CodigoProveedor"].ToString();
            for (int i = 0; i < n; i++)
            {
                obj = (DataRowView)cbProveedor.Items[i];
                if (obj.Row["CodigoProveedor"].ToString() == cod)
                {
                    cbProveedor.SelectedIndex = i;
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

            this.Text = "Ver cuenta por pagar";
            btAceptar.Text = "Aceptar";

            CargarTablaPagos(NumCtaPorPagar);

            if (esdecomprasproductos)
            {
                groupBox1.Enabled = false;
            }
        }

        private void CargarTablaPagos(int NumeroCuentaPorPagar)
        {
            CuentasPorPagarPagosCLN pagos = new CuentasPorPagarPagosCLN();
            dgvDetalle.DataSource = pagos.ListarCuentasPorPagarPagosDetalle(NumeroCuentaPorPagar);
        }

        private void tbMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & (Keys)e.KeyChar != Keys.Enter)
            {
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
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

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FCuentasPorPagarNuevo_Load(object sender, EventArgs e)
        {
            
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

        private void CargarProveedores()
        {
            ProveedoresCLN proveedores = new ProveedoresCLN();
            DataTable dt = proveedores.ListarProveedores();

            if (dt.Rows.Count > 0)
            {
                cbProveedor.DataSource = dt.DefaultView;
                cbProveedor.ValueMember = "CodigoProveedor";
                cbProveedor.DisplayMember = "NombreRazonSocial";
            }
            else
            {
                MessageBox.Show("No se ha podido cargar la lista de Proveedores", "Error en la base de datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (cbProveedor.SelectedIndex > -1)
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
                                CuentasPorPagarCLN cuenta = new CuentasPorPagarCLN();
                                int NumAsiento = -1;
                                FAsientosDetalle fad;

                                string Estado;
                                if (chbxEstado.Checked)
                                    Estado = "C";
                                else
                                    Estado = "P";

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
                                                cuenta.ActualizarCuentaPorPagar(this.NumCtaPorPagar, int.Parse(cbConceptos.SelectedValue.ToString()), this.NumAgencia, int.Parse(cbProveedor.SelectedValue.ToString()), byte.Parse(cbMoneda.SelectedValue.ToString()), Monto, dtpFechaLim.Value, Estado, tbDescripcion.Text, CodUsuario, NumAsiento);
                                                this.DialogResult = DialogResult.OK;
                                                this.Close();
                                            }
                                        }
                                        else
                                        {*/
                                        cuenta.ActualizarCuentaPorPagar(this.NumCtaPorPagar, int.Parse(cbConceptos.SelectedValue.ToString()), this.NumAgencia, int.Parse(cbProveedor.SelectedValue.ToString()), byte.Parse(cbMoneda.SelectedValue.ToString()), Monto, dtpFechaLim.Value, Estado, tbDescripcion.Text, CodUsuario, NumAsiento);
                                        this.DialogResult = DialogResult.OK;
                                        this.Close();
                                        //}
                                    }
                                    else if (btAceptar.Text == "Registrar")
                                    {
                                        /*if (chbAsientos.Checked)
                                        {
                                            fad = new FAsientosDetalle(CodUsuario, p0, p1, p2, p3, p4);
                                            if (fad.ShowDialog() == DialogResult.OK)
                                            {
                                                NumAsiento = fad.GetNumeroAsiento;
                                                cuenta.InsertarCuentaPorPagar(this.NumAgencia, int.Parse(cbConceptos.SelectedValue.ToString()), int.Parse(cbProveedor.SelectedValue.ToString()), byte.Parse(cbMoneda.SelectedValue.ToString()), Monto, dtpFechaLim.Value, Estado, tbDescripcion.Text, CodUsuario, NumAsiento);
                                                this.DialogResult = DialogResult.OK;
                                                this.Close();
                                            }
                                        }
                                        else
                                        {*/
                                        cuenta.InsertarCuentaPorPagar(this.NumAgencia, int.Parse(cbConceptos.SelectedValue.ToString()), int.Parse(cbProveedor.SelectedValue.ToString()), byte.Parse(cbMoneda.SelectedValue.ToString()), Monto, dtpFechaLim.Value, Estado, tbDescripcion.Text, CodUsuario, NumAsiento);
                                        this.DialogResult = DialogResult.OK;
                                        this.Close();
                                        //}
                                    }
                                    else
                                        this.Close();
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
                                                cuenta.ActualizarCuentaPorPagar(this.NumCtaPorPagar, int.Parse(cbConceptos.SelectedValue.ToString()), this.NumAgencia, int.Parse(cbProveedor.SelectedValue.ToString()), byte.Parse(cbMoneda.SelectedValue.ToString()), Monto, new DateTime(), Estado, tbDescripcion.Text, CodUsuario, NumAsiento);
                                                this.DialogResult = DialogResult.OK;
                                                this.Close();
                                            }
                                        }
                                        else
                                        {*/
                                            cuenta.ActualizarCuentaPorPagar(this.NumCtaPorPagar, int.Parse(cbConceptos.SelectedValue.ToString()), this.NumAgencia, int.Parse(cbProveedor.SelectedValue.ToString()), byte.Parse(cbMoneda.SelectedValue.ToString()), Monto, new DateTime(), Estado, tbDescripcion.Text, CodUsuario, NumAsiento);
                                            this.DialogResult = DialogResult.OK;
                                            this.Close();
                                        //}
                                    }
                                    else if (btAceptar.Text == "Registrar")
                                    {
                                        /*if (chbAsientos.Checked)
                                        {
                                            fad = new FAsientosDetalle(CodUsuario, p0, p1, p2, p3, p4);
                                            if (fad.ShowDialog() == DialogResult.OK)
                                            {
                                                NumAsiento = fad.GetNumeroAsiento;
                                                cuenta.InsertarCuentaPorPagar(this.NumAgencia, int.Parse(cbConceptos.SelectedValue.ToString()), int.Parse(cbProveedor.SelectedValue.ToString()), byte.Parse(cbMoneda.SelectedValue.ToString()), Monto, new DateTime(), Estado, tbDescripcion.Text, CodUsuario, NumAsiento);
                                                this.DialogResult = DialogResult.OK;
                                                this.Close();
                                            }
                                        }
                                        else
                                        {*/
                                        cuenta.InsertarCuentaPorPagar(this.NumAgencia, int.Parse(cbConceptos.SelectedValue.ToString()), int.Parse(cbProveedor.SelectedValue.ToString()), byte.Parse(cbMoneda.SelectedValue.ToString()), Monto, new DateTime(), Estado, tbDescripcion.Text, CodUsuario, NumAsiento);
                                        this.DialogResult = DialogResult.OK;
                                        this.Close();
                                        //}
                                    }
                                    else
                                        this.Close();
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
                cbProveedor.Focus();
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
            FPagarCuentasPorPagar fpcpp = new FPagarCuentasPorPagar(NumCtaPorPagar, CodUsuario, drv["NombreMoneda"].ToString());

            if (fpcpp.ShowDialog() == DialogResult.OK)
            {
                CargarTablaPagos(NumCtaPorPagar);
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
            int NumeroPago = int.Parse(dgvDetalle.SelectedRows[0].Cells["dgvcNumeroPago"].Value.ToString());

            FPagarCuentasPorPagar fpcpp = new FPagarCuentasPorPagar(NumeroPago, CodUsuario, drv["NombreMoneda"].ToString(), Monto);

            if (fpcpp.ShowDialog() == DialogResult.OK)
            {
                CargarTablaPagos(NumCtaPorPagar);
            }
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CuentasPorPagarPagosCLN pago = new CuentasPorPagarPagosCLN();
                int NumeroPago = int.Parse(dgvDetalle.SelectedRows[0].Cells["dgvcNumeroPago"].Value.ToString());
                pago.EliminarCuentaPorPagarPago(NumeroPago);
                CargarTablaPagos(NumCtaPorPagar);
            }
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

        public void cargarDatosParaCompraACredito(string ConceptoPorDefecto, int CodigoProveedor, int CodigoMoneda, decimal MontoMaximo, decimal MontoCredito, string Observaciones)
        {
            CargarConceptos();
            CargarMonedas();
            CargarProveedores();

            cbConceptos.SelectedItem = ConceptoPorDefecto;
            cbProveedor.SelectedValue = CodigoProveedor;
            cbMoneda.SelectedValue = CodigoMoneda;
            tbMonto.Text = MontoCredito.ToString();
            tbDescripcion.Text = Observaciones;


            this.cbProveedor.Enabled = false;
            cbMoneda.Enabled = false;
            tbMonto.Enabled = false;
            chbxEstado.Enabled = false;
        }
    }
}
