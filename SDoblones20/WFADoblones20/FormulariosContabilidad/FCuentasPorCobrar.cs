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
using CLCLN.GestionComercial;

namespace WFADoblones20.FormulariosContabilidad
{
    public partial class FCuentasPorCobrar : Form
    {
        public class ClientesProveedores
        {
            private string nombre;
            private int codigo;

            public ClientesProveedores(string Nombre, int Codigo)
            {
                this.nombre = Nombre;
                this.codigo = Codigo;
            }

            public string GetNombre
            {
                get
                {
                    return this.nombre;
                }
            }

            public int GetCodigo
            {
                get
                {
                    return this.codigo;
                }
            }
        }

        private int CodUsuario;
        private int NumAgencia;
        private bool p0, p1, p2, p3, p4;
        private DataTable dtaux;

        public FCuentasPorCobrar(int CodigoUsuario, int NumeroAgencia, bool P0, bool P1, bool P2, bool P3, bool P4)
        {
            InitializeComponent();

            p0 = P0;
            p1 = P1;
            p2 = P2;
            p3 = P3;
            p4 = P4;

            btPagar.Enabled = false;
            this.CodUsuario = CodigoUsuario;
            this.NumAgencia = NumeroAgencia;
            cbEstado.SelectedIndex = 2;
        }

        private void FCuentasPorCobrar_Load(object sender, EventArgs e)
        {
            btPagar.Enabled = false;
            btEliminar.Enabled = false;
            btModificar.Enabled = false;
            btVer.Enabled = false;

            CargarClientesProveedores();
            Buscar();
        }

        private void CargarClientesProveedores()
        {
            DataTable dt = new ProveedoresCLN().ListarProveedores();

            /*cbProveedor.DisplayMember = "NombreRazonSocial";
            cbProveedor.ValueMember = "CodigoProveedor";
            cbProveedor.DataSource = dt;*/

            int n = dt.Rows.Count;
            ClientesProveedores cp;
            List<ClientesProveedores> lcp = new List<ClientesProveedores>();

            cp = new ClientesProveedores("Todos", 0);
            lcp.Add(cp);

            for (int i = 0; i < n; i++)
            {
                cp = new ClientesProveedores(dt.Rows[i]["NombreRazonSocial"].ToString(), int.Parse(dt.Rows[i]["CodigoProveedor"].ToString()));
                lcp.Add(cp);
            }

            cbProveedor.DisplayMember = "GetNombre";
            cbProveedor.ValueMember = "GetCodigo";
            cbProveedor.DataSource = lcp;
        }

        private void Buscar()
        {
            if (dtpFecha2.Value.DayOfYear >= dtpFecha1.Value.DayOfYear)
            {
                CuentasPorCobrarCLN cpc = new CuentasPorCobrarCLN();
                if (cbEstado.SelectedIndex == 2)
                {
                    //dgvCuentasPorPagar.DataSource = cpc.ListarCuentasPorCobrarBusqueda(tbBuscar.Text, DateTime.Parse(dtpFecha1.Value.ToShortDateString()), DateTime.Parse(dtpFecha2.Value.ToShortDateString()), "Cancelado", "Pendiente");
                    //dtaux = cpc.ListarCuentasPorCobrarBusqueda(tbBuscar.Text, DateTime.Parse(dtpFecha1.Value.ToShortDateString()), DateTime.Parse(dtpFecha2.Value.ToShortDateString()), cbEstado.SelectedItem.ToString(), cbEstado.SelectedItem.ToString());
                    dtaux = cpc.ListarCuentasPorCobrarBusqueda(tbBuscar.Text, DateTime.Parse(dtpFecha1.Value.ToShortDateString()), DateTime.Parse(dtpFecha2.Value.ToShortDateString()), "C", "P");

                    if (cbProveedor.SelectedIndex == 0)
                    {
                        dgvCuentasPorPagar.DataSource = dtaux;
                    }
                    else
                    {
                        dgvCuentasPorPagar.DataSource = dtaux.Select("CodigoProveedor = " + cbProveedor.SelectedValue.ToString(), "NombreRazonSocial ASC");
                    }
                }
                else
                {
                    dtaux = cpc.ListarCuentasPorCobrarBusqueda(tbBuscar.Text, DateTime.Parse(dtpFecha1.Value.ToShortDateString()), DateTime.Parse(dtpFecha2.Value.ToShortDateString()), cbEstado.SelectedItem.ToString()[0].ToString(), cbEstado.SelectedItem.ToString()[0].ToString());

                    if (cbProveedor.SelectedIndex == 0)
                    {
                        dgvCuentasPorPagar.DataSource = dtaux;
                    }
                    else
                    {
                        dgvCuentasPorPagar.DataSource = dtaux.Select("CodigoProveedor = " + cbProveedor.SelectedValue.ToString(), "NombreRazonSocial ASC");
                    }
                    //dgvCuentasPorPagar.DataSource = dtaux;
                }
            }
            else
            {
                MessageBox.Show("La primera fecha no puede ser mayor a la segunda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvCuentasPorPagar_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCuentasPorPagar.SelectedRows.Count == 1)
            {
                if (dgvCuentasPorPagar.SelectedRows[0].Cells["dgvcEstado"].Value.ToString() == "Pendiente")
                {
                    btPagar.Enabled = true;
                    btModificar.Enabled = true;
                    btEliminar.Enabled = true;
                    btVer.Enabled = true;
                    btImprimir.Enabled = true;
                }
                else
                {
                    btPagar.Enabled = false;
                    btModificar.Enabled = false;
                    btEliminar.Enabled = true;
                    btVer.Enabled = true;
                    btImprimir.Enabled = true;
                }
            }
            else
            {
                btPagar.Enabled = false;
                btEliminar.Enabled = false;
                btModificar.Enabled = false;
                btVer.Enabled = false;
                btImprimir.Enabled = false;
            }
        }

        private void CargarTabla(string Estado)
        {
            CuentasPorCobrarCLN cuentas = new CuentasPorCobrarCLN();

            if (Estado == "Todos")
            {
                dgvCuentasPorPagar.DataSource = cuentas.ListarCuentasPorCobrarBusqueda(string.Empty, dtpFecha1.Value, dtpFecha2.Value, "P", "C");
            }
            else
            {
                dgvCuentasPorPagar.DataSource = cuentas.ListarCuentasPorCobrarBusqueda(string.Empty, dtpFecha1.Value, dtpFecha2.Value, cbEstado.SelectedItem.ToString()[0].ToString(), cbEstado.SelectedItem.ToString()[0].ToString());
            }
        }

        private void Nuevo()
        {
            FCuentasPorCobrarNuevo nuevacuenta = new FCuentasPorCobrarNuevo(CodUsuario, NumAgencia, p0, p1, p2, p3, p4);
            try
            {
                if (nuevacuenta.ShowDialog() == DialogResult.OK)
                {
                    if (cbEstado.SelectedIndex != 1)
                    {
                        Buscar();
                    }
                }
            }
            catch (ObjectDisposedException)
            { }
        }

        private void Modidicar()
        {
            string NumeroCuentaPorPagar = dgvCuentasPorPagar.SelectedRows[0].Cells["dgvcNumeroCuentaPorCobrar"].Value.ToString();
            try
            {
                FCuentasPorCobrarNuevo fcpn = new FCuentasPorCobrarNuevo(NumeroCuentaPorPagar, CodUsuario, NumAgencia, p0, p1, p2, p3, p4);
                if (fcpn.ShowDialog() == DialogResult.OK)
                {
                    Buscar();
                }
            }
            catch (ObjectDisposedException)
            { }
        }

        public void Eliminar()
        {
            if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CuentasPorCobrarCLN cpc = new CuentasPorCobrarCLN();
                int NumCuentaPorPagar = int.Parse(dgvCuentasPorPagar.SelectedRows[0].Cells["dgvcNumeroCuentaPorPagar"].Value.ToString());
                cpc.EliminarCuentaPorCobrar(NumCuentaPorPagar);
                Buscar();
            }
        }

        private void Pagar()
        {
            int NumeroCuentaPorCobrar = int.Parse(dgvCuentasPorPagar.SelectedRows[0].Cells["dgvcNumeroCuentaPorCobrar"].Value.ToString());            
            string NomMoneda = dgvCuentasPorPagar.SelectedRows[0].Cells["dgvcMoneda"].Value.ToString();

            FPagarCuentasPorCobrar fpagar = new FPagarCuentasPorCobrar(NumeroCuentaPorCobrar, CodUsuario, NomMoneda);
            if (fpagar.ShowDialog() == DialogResult.OK)
            {
                Buscar();
            }

        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            Modidicar();
        }

        private void btVer_Click(object sender, EventArgs e)
        {
            Modidicar();
        }

        private void btPagar_Click(object sender, EventArgs e)
        {
            Pagar();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dgvCuentasPorPagar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvCuentasPorPagar.SelectedRows.Count == 1)
            {
                Modidicar();
            }
        }

        private void btAsiento_Click(object sender, EventArgs e)
        {
            if (btAsiento.Text == "Seleccionar")
            {
                btAsiento.Text = "Registrar";
                btCancelar.Enabled = true;
                dgvcSeleccionar.Visible = true;
            }
            else
            {

                decimal monto = 0;
                int n = dgvCuentasPorPagar.RowCount;
                for (int i = 0; i < n; i++)
                {
                    if (dgvCuentasPorPagar.Rows[i].Cells["dgvcSeleccionar"].Value != null)
                    {
                        if (dgvCuentasPorPagar.Rows[i].Cells["dgvcSeleccionar"].Value.ToString() == "True")
                            monto += decimal.Parse(dgvCuentasPorPagar.Rows[i].Cells["dgvcMonto"].Value.ToString());
                    }
                }

                if (monto > 0)
                {
                    //FSeleccionarAsiento fsa = new FSeleccionarAsiento(CodUsuario, monto, true, p0, p1, p2, p3, p4);
                    //fsa.ShowDialog();
                }
                else
                {
                    MessageBox.Show("La suma de montos no puede ser menor o igual a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            btAsiento.Text = "Seleccionar";
            btCancelar.Enabled = false;
            dgvcSeleccionar.Visible = false;
        }

        private void cbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvCuentasPorPagar.DataSource != null)
            {
                /*if (dtaux.Rows.Count < 1)
                {
                    dtaux = (DataTable)dgvCuentasPorPagar.DataSource;
                }*/

                if (cbProveedor.SelectedIndex == 0)
                {
                    dgvCuentasPorPagar.DataSource = dtaux;
                }
                else
                {
                    try
                    {
                        DataTable dttt = dtaux.Select("CodigoProveedor = " + cbProveedor.SelectedValue.ToString(), "Proveedor ASC").CopyToDataTable();
                        dgvCuentasPorPagar.DataSource = dtaux.Select("CodigoProveedor = " + cbProveedor.SelectedValue.ToString(), "Proveedor ASC").CopyToDataTable();
                    }
                    catch (InvalidOperationException)
                    {
                        MessageBox.Show("No existen registros para el Cliente/Proveedor seleccionado.");
                        cbProveedor.SelectedIndex = 0;
                    }
                }
            }
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            int n = dgvCuentasPorPagar.RowCount;
            int[] numeros = new int[n];
            
            for (int i = 0; i < n; i++)
            {
                numeros[i] = int.Parse(dgvCuentasPorPagar.Rows[i].Cells["dgvcNumeroCuentaPorCobrar"].Value.ToString());
            }
            //new FReporteCuentasPorCobrar(numeros).ShowDialog();
        }



    }
}
