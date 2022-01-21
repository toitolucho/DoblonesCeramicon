using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.GestionComercial;
using CLCLN.Sistema;
using System.Collections;
using WFADoblones20.ReportesGestionComercial;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FProveedores : Form
    {
        private ProveedoresCLN Proveedores = new ProveedoresCLN();
        private MonedasCLN Monedas = new MonedasCLN();
        private BancosCLN Bancos = new BancosCLN();
        private PaisesCLN Paises = new PaisesCLN();
        private DepartamentosCLN Departamentos = new DepartamentosCLN();
        private ProvinciasCLN Provincias = new ProvinciasCLN();
        private LugaresCLN Lugares = new LugaresCLN();
        private DataTable RBProveedores = new DataTable();
        private string TipoOperacion = "";

        public FProveedores(bool PermitirInsertar, bool PermitirEditar, bool PermitirEliminar, bool PermitirNavegar)
        {
            InitializeComponent();

            this.bNuevo.Visible = PermitirInsertar;
            this.bEditar.Visible = PermitirEditar;
            this.bEliminar.Visible = PermitirEliminar;
            this.bCancelar.Visible = (PermitirInsertar || PermitirEditar) ? true: false;
            this.bAceptar.Visible = (PermitirInsertar || PermitirEditar) ? true: false;
            this.bBuscar.Visible = PermitirNavegar;
        }

        private void CargarMonedas()
        {
            DataTable DTMonedas = new DataTable();
            DTMonedas = Monedas.ListarMonedas();
            cBMonedas.DataSource = DTMonedas.DefaultView;
            cBMonedas.DisplayMember = "NombreMoneda";
            cBMonedas.ValueMember = "CodigoMoneda";
        }

        private void CargarBancos()
        {
            DataTable DTBancos = new DataTable();
            DTBancos = Bancos.ListarBancos();
            cBBancos.DataSource = DTBancos.DefaultView;
            cBBancos.DisplayMember = "NombreBanco";
            cBBancos.ValueMember = "CodigoBanco";
        }

        private void CargarPaises()
        {
            DataTable DTPaises = new DataTable();
            DTPaises = Paises.ListarPaises();
            cBPais.DataSource = DTPaises.DefaultView;
            cBPais.DisplayMember = "NombrePais";
            cBPais.ValueMember = "CodigoPais";
        }
        
        private void CargarDepartamentos(string CodigoPais)
        {
            DataTable DTDepartamentos = new DataTable();
            DTDepartamentos = Departamentos.ObtenerDepartamentosPorPais(CodigoPais);
            cBDepartamento.DataSource = DTDepartamentos.DefaultView;
            cBDepartamento.DisplayMember = "NombreDepartamento";
            cBDepartamento.ValueMember = "CodigoDepartamento";
        }

        private void CargarProvincias(string CodigoPais, string CodigoDepartamento)
        {
            DataTable DTProvincias = new DataTable();
            DTProvincias = Provincias.ObtenerProvinciasPorDepartamento(CodigoPais, CodigoDepartamento);
            cBProvincia.DataSource = DTProvincias.DefaultView;
            cBProvincia.DisplayMember = "NombreProvincia";
            cBProvincia.ValueMember = "CodigoProvincia";
        }

        private void CargarLugares(string CodigoPais, string CodigoDepartamento, string CodigoProvincia)
        {
            DataTable DTLugares = new DataTable();
            DTLugares = Lugares.ObtenerLugaresPorProvincia(CodigoPais, CodigoDepartamento, CodigoProvincia);
            cBLugar.DataSource = DTLugares.DefaultView;
            cBLugar.DisplayMember = "NombreLugar";
            cBLugar.ValueMember = "CodigoLugar";
        }

        private void CargarTiposProveedores()
        {
            ArrayList TiposProveedores = new ArrayList();
            TiposProveedores.Add(new TipoProveedor("E", "Empresa"));
            TiposProveedores.Add(new TipoProveedor("P", "Persona"));

            cBTipoProveedor.DataSource = TiposProveedores;
            cBTipoProveedor.DisplayMember = "NombreTipoProveedor";
            cBTipoProveedor.ValueMember = "CodigoTipoProveedor";
            cBTipoProveedor.SelectedIndex = 0;
        }

        private void InhabilitarControles(bool Estado)
        {
            tBCodigoProveedor.ReadOnly = Estado; 
            tBNombreRazonSocial.ReadOnly = Estado; 
            tBNombreRepresentante.ReadOnly = Estado; 
            cBTipoProveedor.Enabled = !Estado;
            tBNITProveedor.ReadOnly = Estado;
            cBBancos.Enabled = !Estado;
            tBNumeroCuenta.ReadOnly = Estado;
            cBMonedas.Enabled = !Estado;
            tBNombreOrdenCheque.ReadOnly = Estado;
            cBPais.Enabled = !Estado;
            cBDepartamento.Enabled = !Estado;
            cBProvincia.Enabled = !Estado;
            cBLugar.Enabled = !Estado;
            tBDireccion.ReadOnly = Estado; 
            tBTelefono.ReadOnly = Estado; 
            tBFax.ReadOnly = Estado; 
            tBCasilla.ReadOnly = Estado; 
            tBEmail.ReadOnly = Estado; 
            tBObservaciones.ReadOnly = Estado;
            cBProveedorActivo.Enabled = !Estado;
        }

        private void InicializarControles()
        {
            tBCodigoProveedor.Text = "";
            tBNombreRazonSocial.Text = "";
            tBNombreRepresentante.Text = "";
            cBTipoProveedor.SelectedIndex = 0;
            tBNITProveedor.Text = "";
            cBBancos.SelectedIndex = -1;
            tBNumeroCuenta.Text = "";
            cBMonedas.SelectedIndex = -1;
            tBNombreOrdenCheque.Text = "";
            cBPais.SelectedIndex = -1;
            cBDepartamento.SelectedIndex = -1;
            cBProvincia.SelectedIndex = -1;
            cBLugar.SelectedIndex = -1;
            tBDireccion.Text = "";
            tBTelefono.Text = "";
            tBFax.Text = "";
            tBCasilla.Text = "";
            tBEmail.Text = "";
            tBObservaciones.Text = "";
            cBProveedorActivo.Checked = true;
        }
    
        private void bNuevo_Click(object sender, EventArgs e)
        {
            TipoOperacion = "I";

            InhabilitarControles(false);
            InicializarControles();
            bNuevo.Enabled = false;
            bEditar.Enabled = false;
            bEliminar.Enabled = false;
            bAceptar.Enabled = true;
            bCancelar.Enabled = true;

            tBNombreRazonSocial.Focus();
        }

        private void bEditar_Click(object sender, EventArgs e)
        {
            TipoOperacion = "E";
            InhabilitarControles(false);
            bNuevo.Enabled = false;
            bEditar.Enabled = false;
            bEliminar.Enabled = false;
            bAceptar.Enabled = true;
            bCancelar.Enabled = true;
        }

        private void bEliminar_Click(object sender, EventArgs e)
        {
            string Mensaje = "Esta seguro que desea eliminar el registro actual, recuerde que una vez aceptada la operacion es irreversible.";
            string Titulo = "Confimarción eliminación registro";
            MessageBoxButtons Botones = MessageBoxButtons.YesNo;
            MessageBoxIcon Icono = MessageBoxIcon.Exclamation;
            DialogResult result;

            result = MessageBox.Show(Mensaje, Titulo, Botones, Icono);

            if (result == DialogResult.Yes)
            {
                Proveedores.EliminarProveedor(int.Parse(tBCodigoProveedor.Text));
                InhabilitarControles(true);
                InicializarControles();
                bNuevo.Enabled = true;
                bEditar.Enabled = false;
                bEliminar.Enabled = false;
                bAceptar.Enabled = false;
                bCancelar.Enabled = false;
            }
        }

        public bool validarCampos()
        {
            if (String.IsNullOrEmpty(tBNombreRazonSocial.Text.Trim()))
            {
                errorProvider1.SetError(tBNombreRazonSocial, "Aún no ha ingresado el Nombre de la Razón Social");
                tBNombreRazonSocial.Focus();
                tBNombreRazonSocial.SelectAll();
                return false;
            }
            if (String.IsNullOrEmpty(tBNombreRepresentante.Text.Trim()))
            {
                errorProvider1.SetError(tBNombreRepresentante, "Aún no ha ingresado el Nombre del Representante");
                tBNombreRepresentante.Focus();
                tBNombreRepresentante.SelectAll();
                return false;
            }
            if (cBTipoProveedor.SelectedIndex == -1)
            {
                errorProvider1.SetError(cBTipoProveedor, "Aún no ha seleccionado el Tipo de Proveedor");
                cBTipoProveedor.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(tBNITProveedor.Text.Trim()))
            {
                if (MessageBox.Show(this, "Se encuentra Seguro de dejar en Blanco el NIT del Proveedor?", "Validación de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    errorProvider1.SetError(tBNITProveedor, "Aún no ha ingresado el NIT del Proveedor");
                    tBNITProveedor.Focus();
                    tBNITProveedor.SelectAll();
                    return false;
                }
            }
            if (cBBancos.SelectedIndex == -1)
            {
                errorProvider1.SetError(cBBancos, "Aún no ha seleccionado el Banco del Proveedor");
                cBBancos.Focus();
                return false;
            }

            if (cBMonedas.SelectedIndex == -1)
            {
                errorProvider1.SetError(cBMonedas, "Aún no ha seleccionado la Moneda de la cuenta del Proveedor");
                cBMonedas.Focus();
                return false;
            }

            return true;
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            string CodigoTipoProveedor = null;
            byte CodigoBanco = 0;
            byte CodigoMoneda = 0;
            string CodigoPais = null;
            string CodigoDepartamento = null;
            string CodigoProvincia = null;
            string CodigoLugar = null;

            if (!validarCampos())
            {
                MessageBox.Show(this, "Revise sus Datos, existen campos Faltantes", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cBTipoProveedor.SelectedIndex > -1)
                CodigoTipoProveedor = cBTipoProveedor.SelectedValue.ToString();

            if (cBBancos.SelectedIndex > -1)
                CodigoBanco = byte.Parse(cBBancos.SelectedValue.ToString());

            if (cBMonedas.SelectedIndex > -1)
                CodigoMoneda = byte.Parse(cBMonedas.SelectedValue.ToString());

            if (cBPais.SelectedIndex > -1)
                CodigoPais = cBPais.SelectedValue.ToString();

            if (cBDepartamento.SelectedIndex > -1)
                CodigoDepartamento = cBDepartamento.SelectedValue.ToString();

            if (cBProvincia.SelectedIndex > -1)
                CodigoProvincia = cBProvincia.SelectedValue.ToString();

            if (cBLugar.SelectedIndex > -1)
                CodigoLugar = cBLugar.SelectedValue.ToString();
            try
            {
                if (TipoOperacion == "I")
                {
                    Proveedores.InsertarProveedor(tBNombreRazonSocial.Text, tBNombreRepresentante.Text, CodigoTipoProveedor, tBNITProveedor.Text, CodigoBanco, tBNumeroCuenta.Text, CodigoMoneda, tBNombreOrdenCheque.Text, CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLugar, tBDireccion.Text, tBTelefono.Text, tBFax.Text, tBCasilla.Text, tBEmail.Text, tBObservaciones.Text, cBProveedorActivo.Checked, 1);

                }

                if (TipoOperacion == "E")
                {
                    Proveedores.ActualizarProveedor(int.Parse(tBCodigoProveedor.Text), tBNombreRazonSocial.Text, tBNombreRepresentante.Text, CodigoTipoProveedor, tBNITProveedor.Text, CodigoBanco, tBNumeroCuenta.Text, CodigoMoneda, tBNombreOrdenCheque.Text, CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLugar, tBDireccion.Text, tBTelefono.Text, tBFax.Text, tBCasilla.Text, tBEmail.Text, tBObservaciones.Text, cBProveedorActivo.Checked, 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Ocurrio la siguiente Excepción " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InhabilitarControles(true);
            bNuevo.Enabled = true;
            bEditar.Enabled = true;
            bEliminar.Enabled = true;
            bAceptar.Enabled = false;
            bCancelar.Enabled = false;
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (TipoOperacion == "I")
                InicializarControles();
            InhabilitarControles(true);
            bNuevo.Enabled = true;
            bEditar.Enabled = false;
            bEliminar.Enabled = false;
            bAceptar.Enabled = false;
            bCancelar.Enabled = false;
        }

        private void bBuscar_Click(object sender, EventArgs e)
        {
            FBuscarProveedores fBuscarProveedores = new FBuscarProveedores();
            fBuscarProveedores.ShowDialog();
            int CodigoProveedor = fBuscarProveedores.CodigoProveedor;

            RBProveedores = Proveedores.ObtenerProveedor(CodigoProveedor);
            
            if (RBProveedores.Rows.Count > 0)
            {
                tBCodigoProveedor.Text = RBProveedores.Rows[0][0].ToString();
                tBNombreRazonSocial.Text = RBProveedores.Rows[0][1].ToString();
                tBNombreRepresentante.Text = RBProveedores.Rows[0][2].ToString();
                if ((RBProveedores.Rows[0][3].ToString() != null) && (RBProveedores.Rows[0][3].ToString() != ""))
                    cBTipoProveedor.SelectedValue = RBProveedores.Rows[0][3].ToString();
                else
                    cBTipoProveedor.SelectedIndex = -1;
                tBNITProveedor.Text = RBProveedores.Rows[0][4].ToString();
                if ((RBProveedores.Rows[0][5].ToString() != null) && (RBProveedores.Rows[0][5].ToString() != ""))
                    cBBancos.SelectedValue = RBProveedores.Rows[0][5].ToString();
                else
                    cBBancos.SelectedIndex = -1;
                tBNumeroCuenta.Text = RBProveedores.Rows[0][6].ToString();
                if ((RBProveedores.Rows[0][7].ToString() != null) && (RBProveedores.Rows[0][7].ToString() != ""))
                    cBMonedas.SelectedValue = RBProveedores.Rows[0][7].ToString();
                else
                    cBMonedas.SelectedIndex = -1;
                tBNombreOrdenCheque.Text = RBProveedores.Rows[0][8].ToString();
                if ((RBProveedores.Rows[0][9].ToString() != null) && (RBProveedores.Rows[0][9].ToString() != ""))
                    cBPais.SelectedValue = RBProveedores.Rows[0][9].ToString();
                else
                    cBPais.SelectedIndex = -1;
                if ((RBProveedores.Rows[0][10].ToString() != null) && (RBProveedores.Rows[0][10].ToString() != ""))
                    cBDepartamento.SelectedValue = RBProveedores.Rows[0][10].ToString();
                else
                    cBDepartamento.SelectedIndex = -1;
                if ((RBProveedores.Rows[0][11].ToString() != null) && (RBProveedores.Rows[0][11].ToString() != ""))
                    cBProvincia.SelectedValue = RBProveedores.Rows[0][11].ToString();
                else
                    cBProvincia.SelectedIndex = -1;
                if ((RBProveedores.Rows[0][12].ToString() != null) && (RBProveedores.Rows[0][12].ToString() != ""))
                    cBLugar.SelectedValue = RBProveedores.Rows[0][12].ToString();
                else
                    cBLugar.SelectedIndex = -1;
                tBDireccion.Text = RBProveedores.Rows[0][13].ToString();
                tBTelefono.Text = RBProveedores.Rows[0][14].ToString();
                tBFax.Text = RBProveedores.Rows[0][15].ToString();
                tBCasilla.Text = RBProveedores.Rows[0][16].ToString();
                tBEmail.Text = RBProveedores.Rows[0][17].ToString();
                tBObservaciones.Text = RBProveedores.Rows[0][18].ToString();
                cBProveedorActivo.Checked = bool.Parse(RBProveedores.Rows[0][19].ToString());

                bNuevo.Enabled = true;
                bEditar.Enabled = true;
                bEliminar.Enabled = true;
                bAceptar.Enabled = false;
                bCancelar.Enabled = false;
            }
            else
            {
                InhabilitarControles(true);
                InicializarControles();
                bNuevo.Enabled = true;
                bEditar.Enabled = false;
                bEliminar.Enabled = false;
                bAceptar.Enabled = false;
                bCancelar.Enabled = false;
            }

            
        }

        private void bCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FProveedores_Load(object sender, EventArgs e)
        {
            CargarMonedas();
            CargarBancos();
            CargarPaises();
            CargarTiposProveedores();

            InhabilitarControles(true);
            InicializarControles();

            bNuevo.Enabled = true;
            bEditar.Enabled = false;
            bEliminar.Enabled = false;
            bAceptar.Enabled = false;
            bCancelar.Enabled = false;
        }

        private void cBPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBPais.SelectedIndex >= 0) 
                CargarDepartamentos(cBPais.SelectedValue.ToString());
        }

        private void cBDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBDepartamento.SelectedIndex >= 0)
                CargarProvincias(cBPais.SelectedValue.ToString(), cBDepartamento.SelectedValue.ToString());
        }

        private void cBProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBProvincia.SelectedIndex >= 0)
                CargarLugares(cBPais.SelectedValue.ToString(), cBDepartamento.SelectedValue.ToString(), cBProvincia.SelectedValue.ToString());
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cBBancos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bReporte_Click(object sender, EventArgs e)
        {
            FReportesGestionComercialProveedores fReportesGestionComercialproveedores = new FReportesGestionComercialProveedores(Proveedores.ListarProveedoresReporte());
            fReportesGestionComercialproveedores.ShowDialog();
        }
    }

    public class TipoProveedor
    {
        private string CodTipPro;
        private string NomTipPro;

        public TipoProveedor(string CodigoTipoProveedor, string NombreTipoProveedor)
        {
            this.CodTipPro = CodigoTipoProveedor;
            this.NomTipPro = NombreTipoProveedor;
        }

        public string CodigoTipoProveedor
        {
            get
            {
                return CodTipPro;
            }
        }

        public string NombreTipoProveedor
        {

            get
            {
                return NomTipPro;
            }
        }
    }
}
