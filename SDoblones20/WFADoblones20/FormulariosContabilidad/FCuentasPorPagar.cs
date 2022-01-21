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
    public partial class FCuentasPorPagar : Form
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

        public FCuentasPorPagar(int CodigoUsuario, int NumeroAgencia, bool P0, bool P1, bool P2, bool P3, bool P4)
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

            CargarClientesProveedores();  

            Buscar();
        }

        /// <summary>
        /// Constructor para cargar una CtaXPagar de ComprasProductos
        /// </summary>
        /// <param name="CodigoUsuario"></param>
        /// <param name="NumeroAgencia"></param>
        /// <param name="NumeroCuentaPorPagar"></param>
        /// <param name="P0"></param>
        /// <param name="P1"></param>
        /// <param name="P2"></param>
        /// <param name="P3"></param>
        /// <param name="P4"></param>
        public FCuentasPorPagar(int CodigoUsuario, int NumeroAgencia, int NumeroCuentaPorPagar, bool P0, bool P1, bool P2, bool P3, bool P4)
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

            DataTable dt = new CuentasPorPagarCLN().ListarCuentasPorPagar(NumeroCuentaPorPagar);

            CargarClientesProveedores();  

            int n = cbProveedor.Items.Count;
            string cod = dt.Rows[0]["CodigoProveedor"].ToString();
            ClientesProveedores obj;
            //DataRowView obj;
            for (int i = 0; i < n; i++)
            {
                obj = /*(DataRowView)*/(ClientesProveedores)cbProveedor.Items[i];
                if (obj.GetCodigo.ToString() == cod)
                {
                    cbProveedor.SelectedIndex = i;
                    break;
                }
            }

            if (dt.Rows[0]["CodigoEstado"].ToString() == "C")
            {
                cbEstado.SelectedIndex = 0;
            }
            else
            {
                cbEstado.SelectedIndex = 1;
            }

            

            Buscar(NumeroCuentaPorPagar);
            //dgvCuentasPorPagar.Rows[0].Selected = true;
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
                }
                else
                {
                    btPagar.Enabled = false;
                    btModificar.Enabled = false;
                    btEliminar.Enabled = true;
                    btVer.Enabled = true;
                }
            }
            else
            {
                btPagar.Enabled = false;
                btEliminar.Enabled = false;
                btModificar.Enabled = false;
                btVer.Enabled = false;
            }
        }

        private void CargarTabla(string Estado)
        {
            CuentasPorPagarCLN cuentas = new CuentasPorPagarCLN();

            if (Estado == "Todos")
            {
                dgvCuentasPorPagar.DataSource = cuentas.ListarBusquedaCuentasPorPagar(string.Empty, dtpFecha1.Value, dtpFecha2.Value, "P", "C");
            }
            else
            {
                dgvCuentasPorPagar.DataSource = cuentas.ListarBusquedaCuentasPorPagar(string.Empty, dtpFecha1.Value, dtpFecha2.Value, cbEstado.SelectedItem.ToString()[0].ToString(), cbEstado.SelectedItem.ToString()[0].ToString());
            }
        }

        private void tsbtNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void Nuevo()
        {
            FCuentasPorPagarNuevo nuevacuenta = new FCuentasPorPagarNuevo(CodUsuario, NumAgencia, p0, p1, p2, p3, p4);
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
            string NumeroCuentaPorPagar = dgvCuentasPorPagar.SelectedRows[0].Cells["dgvcNumeroCuentaPorPagar"].Value.ToString();
            string NumeroConcepto = dgvCuentasPorPagar.SelectedRows[0].Cells["dgvcNumeroConcepto"].Value.ToString();
            try
            {
                FCuentasPorPagarNuevo fcpn = new FCuentasPorPagarNuevo(NumeroCuentaPorPagar, CodUsuario, NumAgencia, p0, p1, p2, p3, p4);
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
                bool esdecomprasproductos = new CuentasPorPagarCLN().EsDeCompraProductos(int.Parse(dgvCuentasPorPagar.SelectedRows[0].Cells["dgvcNumeroCuentaPorPagar"].Value.ToString()));
                if (esdecomprasproductos)
                {
                    MessageBox.Show("Esta Cuenta Por Pagar fue generada de una transacción por compra.\n" +
                    "Por este motivo no puede ser eliminada desde este administrador.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    CuentasPorPagarCLN cpp = new CuentasPorPagarCLN();
                    int NumCuentaPorPagar = int.Parse(dgvCuentasPorPagar.SelectedRows[0].Cells["dgvcNumeroCuentaPorPagar"].Value.ToString());
                    cpp.EliminarCuentaPorPagar(NumCuentaPorPagar);
                    Buscar();
                }
            }
        }

        private void dgvCuentasPorPagar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvCuentasPorPagar.SelectedRows.Count == 1)
                Modidicar();
        }

        /*private void MostrarDetalle()
        {
            int IdCuenta = int.Parse(dgvCuentasPorPagar.SelectedRows[0].Cells["dgvcIdCuentaPagar"].Value.ToString());
            string Concepto = dgvCuentasPorPagar.SelectedRows[0].Cells["dgvcConcepto"].Value.ToString();
            string Monto = dgvCuentasPorPagar.SelectedRows[0].Cells["dgvcMonto"].Value.ToString();
            string Moneda = dgvCuentasPorPagar.SelectedRows[0].Cells["dgvcMoneda"].Value.ToString();
            string Estado = dgvCuentasPorPagar.SelectedRows[0].Cells["dgvcEstado"].Value.ToString();
            
            FCuentasPorPagarDetalle detalle = new FCuentasPorPagarDetalle(IdCuenta, Concepto, Monto, Moneda, Estado);
            detalle.ShowDialog();
        }*/

        private void Pagar()
        {
            int NumeroCuentaPorPagar = int.Parse(dgvCuentasPorPagar.SelectedRows[0].Cells["dgvcNumeroCuentaPorPagar"].Value.ToString());
            //string Saldo = dgvCuentasPorPagar.SelectedRows[0].Cells["dgvcSaldo"].Value.ToString();
            string CodMoneda = dgvCuentasPorPagar.SelectedRows[0].Cells["dgvcMoneda"].Value.ToString();

            FPagarCuentasPorPagar fpagar = new FPagarCuentasPorPagar(NumeroCuentaPorPagar,CodUsuario, CodMoneda);
            if (fpagar.ShowDialog() == DialogResult.OK)
            {
                CargarTabla(cbEstado.SelectedItem.ToString());
            }
            
        }

        private void Buscar()
        {
            /*if (dtpFecha2.Value.DayOfYear >= dtpFecha1.Value.DayOfYear)
            {
                CuentasPorPagarCLN cpp = new CuentasPorPagarCLN();
                if (cbEstado.SelectedIndex == 2)
                    dgvCuentasPorPagar.DataSource = cpp.ListarBusquedaCuentasPorPagar(tbBuscar.Text, DateTime.Parse(dtpFecha1.Value.ToShortDateString()), DateTime.Parse(dtpFecha2.Value.ToShortDateString()), "Cancelado", "Pendiente");
                else
                {
                    dgvCuentasPorPagar.DataSource = cpp.ListarBusquedaCuentasPorPagar(tbBuscar.Text, DateTime.Parse(dtpFecha1.Value.ToShortDateString()), DateTime.Parse(dtpFecha2.Value.ToShortDateString()), cbEstado.SelectedItem.ToString(), cbEstado.SelectedItem.ToString());
                }
            }
            else
            {
                MessageBox.Show("La primera fecha no puede ser mayor a la segunda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }*/
            if (dtpFecha2.Value.DayOfYear >= dtpFecha1.Value.DayOfYear)
            {
                CuentasPorPagarCLN cpc = new CuentasPorPagarCLN();
                if (cbEstado.SelectedIndex == 2)
                {
                    //dgvCuentasPorPagar.DataSource = cpc.ListarCuentasPorCobrarBusqueda(tbBuscar.Text, DateTime.Parse(dtpFecha1.Value.ToShortDateString()), DateTime.Parse(dtpFecha2.Value.ToShortDateString()), "Cancelado", "Pendiente");
                    //dtaux = cpc.ListarCuentasPorCobrarBusqueda(tbBuscar.Text, DateTime.Parse(dtpFecha1.Value.ToShortDateString()), DateTime.Parse(dtpFecha2.Value.ToShortDateString()), cbEstado.SelectedItem.ToString(), cbEstado.SelectedItem.ToString());
                    dtaux = cpc.ListarBusquedaCuentasPorPagar(tbBuscar.Text, DateTime.Parse(dtpFecha1.Value.ToShortDateString()), DateTime.Parse(dtpFecha2.Value.ToShortDateString()), "C", "P");

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
                    dtaux = cpc.ListarBusquedaCuentasPorPagar(tbBuscar.Text, DateTime.Parse(dtpFecha1.Value.ToShortDateString()), DateTime.Parse(dtpFecha2.Value.ToShortDateString()), cbEstado.SelectedItem.ToString()[0].ToString(), cbEstado.SelectedItem.ToString()[0].ToString());

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

        private void Buscar(int NumCtaXPagar)
        {
            CuentasPorPagarCLN cpc = new CuentasPorPagarCLN();

            dtaux = cpc.ListarBusquedaCuentasPorPagar(NumCtaXPagar);
            dgvCuentasPorPagar.DataSource = dtaux;

            //dgvCuentasPorPagar.DataSource = dtaux;
        }
        

        private void FCuentasPorPagar_Load(object sender, EventArgs e)
        {
            btPagar.Enabled = false;
            btEliminar.Enabled = false;
            btModificar.Enabled = false;
            btVer.Enabled = false;

            if (dgvCuentasPorPagar.RowCount > 0)
            {
                dgvCuentasPorPagar.Rows[0].Selected = true;
                dgvCuentasPorPagar_SelectionChanged(dgvCuentasPorPagar, null);
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

        private void btAsiento_Click(object sender, EventArgs e)
        {
            if (btAsiento.Text == "Seleccionar")
            {
                btAsiento.Text = "Registrar";
                btCancelar.Enabled = true;
                dgvcSelccionar.Visible = true;
            }
            else
            {

                decimal monto = 0;
                int n = dgvCuentasPorPagar.RowCount;
                for (int i = 0; i < n; i++)
                {
                    if (dgvCuentasPorPagar.Rows[i].Cells["dgvcSelccionar"].Value != null)
                    {
                        if (dgvCuentasPorPagar.Rows[i].Cells["dgvcSelccionar"].Value.ToString() == "True")
                            monto += decimal.Parse(dgvCuentasPorPagar.Rows[i].Cells["dgvcMonto"].Value.ToString());
                    }
                }

                if (monto > 0)
                {
                    //FSeleccionarAsiento fsa = new FSeleccionarAsiento(CodUsuario, monto, false, p0, p1, p2, p3, p4);
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
            dgvcSelccionar.Visible = false;
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            int n = dgvCuentasPorPagar.RowCount;
            int[] numeros = new int[n];

            for (int i = 0; i < n; i++)
            {
                numeros[i] = int.Parse(dgvCuentasPorPagar.Rows[i].Cells["dgvcNumeroCuentaPorPagar"].Value.ToString());
            }
            new FReporteCuentasPorPagar(numeros).ShowDialog();
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

    }
}
