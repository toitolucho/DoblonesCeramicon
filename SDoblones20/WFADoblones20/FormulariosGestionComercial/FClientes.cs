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
using WFADoblones20.FormulariosGestionComercial;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FClientes : Form
    {
        private ClientesCLN Clientes = new ClientesCLN();
        private PaisesCLN Paises = new PaisesCLN();
        private DepartamentosCLN Departamentos = new DepartamentosCLN();
        private ProvinciasCLN Provincias = new ProvinciasCLN();
        private LugaresCLN Lugares = new LugaresCLN();
        private DataTable RBClientes = new DataTable();
        ErrorProvider errorPClientes = new ErrorProvider();
        private string TipoOperacion = "";

        public FClientes(bool PermitirInsertar, bool PermitirEditar, bool PermitirEliminar, bool PermitirNavegar)
        {
            InitializeComponent();

            this.bNuevo.Visible = PermitirInsertar;
            this.bEditar.Visible = PermitirEditar;
            this.bEliminar.Visible = PermitirEliminar;
            this.bCancelar.Visible = (PermitirInsertar || PermitirEditar) ? true : false;
            this.bAceptar.Visible = (PermitirInsertar || PermitirEditar) ? true : false;
            this.bBuscar.Visible = PermitirNavegar;
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

        private void CargarTiposCliente()
        {
            ArrayList TiposCliente = new ArrayList();
            TiposCliente.Add(new TipoCliente("E", "Empresa"));
            TiposCliente.Add(new TipoCliente("P", "Persona"));

            cBTiposCliente.DataSource = TiposCliente;
            cBTiposCliente.DisplayMember = "NombreTipoCliente";
            cBTiposCliente.ValueMember = "CodigoTipoCliente";
            cBTiposCliente.SelectedIndex = 0;
        }

        private void CargarEstadosCliente()
        {
            ArrayList EstadosCliente = new ArrayList();
            EstadosCliente.Add(new EstadoCliente("H", "Habilitado"));
            EstadosCliente.Add(new EstadoCliente("I", "Inhabilitado"));
            EstadosCliente.Add(new EstadoCliente("S", "Suspendido"));


            cBEstadosCliente.DataSource = EstadosCliente;
            cBEstadosCliente.DisplayMember = "NombreEstadoCliente";
            cBEstadosCliente.ValueMember = "CodigoEstadoCliente";
            cBEstadosCliente.SelectedIndex = 0;
        }

        private void InhabilitarControles(bool Estado)
        {
            tBCodigoCliente.ReadOnly = Estado; 
            tBNombreCliente.ReadOnly = Estado; 
            tBNombreRepresentante.ReadOnly = Estado; 
            cBTiposCliente.Enabled = !Estado;
            tBNITCliente.ReadOnly = Estado;
            cBPais.Enabled = !Estado;
            cBDepartamento.Enabled = !Estado;
            cBProvincia.Enabled = !Estado;
            cBLugar.Enabled = !Estado;
            tBDireccion.ReadOnly = Estado; 
            tBTelefono.ReadOnly = Estado; 
            tBEmail.ReadOnly = Estado; 
            tBObservaciones.ReadOnly = Estado;
            cBEstadosCliente.Enabled = !Estado;
        }

        private void InicializarControles()
        {
            tBCodigoCliente.Text = "";
            tBNombreCliente.Text = "";
            tBNombreRepresentante.Text = "";
            cBTiposCliente.SelectedIndex = 0;
            tBNITCliente.Text = "";
            cBPais.SelectedIndex = -1;
            cBDepartamento.SelectedIndex = -1;
            cBProvincia.SelectedIndex = -1;
            cBLugar.SelectedIndex = -1;
            tBDireccion.Text = "";
            tBTelefono.Text = "";
            tBEmail.Text = "";
            tBObservaciones.Text = "";
            cBEstadosCliente.SelectedIndex = 0;
            errorPClientes.Clear();
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

            tBNombreCliente.Focus();
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
            errorPClientes.Clear();
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
                try
                {
                    Clientes.EliminarCliente(int.Parse(tBCodigoCliente.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Ocurrio la siguiente Excepción " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                InhabilitarControles(true);
                InicializarControles();
                bNuevo.Enabled = true;
                bEditar.Enabled = false;
                bEliminar.Enabled = false;
                bAceptar.Enabled = false;
                bCancelar.Enabled = false;
            }
        }

        public bool validarDatos()
        {
            if (String.IsNullOrEmpty(tBNombreCliente.Text.Trim()))
            {
                errorPClientes.SetError(tBNombreCliente, "Aún no ha ingresado el Nombre del Cliente");
                tBNombreCliente.Focus();
                tBNombreCliente.SelectAll();
                return false;
            }
            if (String.IsNullOrEmpty(tBNombreRepresentante.Text.Trim()))
            {
                errorPClientes.SetError(tBNombreRepresentante, "Aún no ha ingresado el Nombre del Representante");
                tBNombreRepresentante.Focus();
                tBNombreRepresentante.SelectAll();
                return false;
            }
            if (cBTiposCliente.SelectedIndex == -1)
            {
                errorPClientes.SetError(cBTiposCliente, "Aún no ha seleccionado el Tipo de Cliente");
                cBTiposCliente.Focus();
                cBTiposCliente.SelectAll();
                return false;
            }
            if (String.IsNullOrEmpty(tBNITCliente.Text.Trim()) &&
                MessageBox.Show(this,"¿Se encuentra seguro de dejar en Blanco el NIT del Cliente?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                errorPClientes.SetError(tBNITCliente, "Aún no ha ingresado el Nombre del Cliente");
                tBNITCliente.Focus();
                tBNITCliente.SelectAll();
                return false;
            }
            return true;
        }


        private void bAceptar_Click(object sender, EventArgs e)
        {
            errorPClientes.Clear();
            string CodigoTipoCliente = null;
            string CodigoPais = null;
            string CodigoDepartamento = null;
            string CodigoProvincia = null;
            string CodigoLugar = null;
            string CodigoEstadosCliente = null;

            if (!validarDatos())
            {
                MessageBox.Show(this, "Existen algunos datos que faltan, Porfavor reviselos y corrijalos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cBTiposCliente.SelectedIndex > -1)
                CodigoTipoCliente = cBTiposCliente.SelectedValue.ToString();

            if (cBPais.SelectedIndex > -1)
                CodigoPais = cBPais.SelectedValue.ToString();

            if (cBDepartamento.SelectedIndex > -1)
                CodigoDepartamento = cBDepartamento.SelectedValue.ToString();

            if (cBProvincia.SelectedIndex > -1)
                CodigoProvincia = cBProvincia.SelectedValue.ToString();

            if (cBLugar.SelectedIndex > -1)
                CodigoLugar = cBLugar.SelectedValue.ToString();

            if (cBEstadosCliente.SelectedIndex > -1)
            {
                CodigoEstadosCliente = cBEstadosCliente.SelectedValue.ToString();

                try
                {
                    if (TipoOperacion == "I")
                    {
                        Clientes.InsertarCliente(tBNombreCliente.Text, tBNombreRepresentante.Text, CodigoTipoCliente, tBNITCliente.Text, CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLugar, tBDireccion.Text, tBTelefono.Text, tBEmail.Text, tBObservaciones.Text, CodigoEstadosCliente, 1);

                    }

                    if (TipoOperacion == "E")
                    {
                        Clientes.ActualizarCliente(int.Parse(tBCodigoCliente.Text), tBNombreCliente.Text, tBNombreRepresentante.Text, CodigoTipoCliente, tBNITCliente.Text, CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLugar, tBDireccion.Text, tBTelefono.Text, tBEmail.Text, tBObservaciones.Text, CodigoEstadosCliente, 1);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Ocurrió la Siguiente Excepción " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                    
                }

                InhabilitarControles(true);
                bNuevo.Enabled = true;
                bEditar.Enabled = true;
                bEliminar.Enabled = true;
                bAceptar.Enabled = false;
                bCancelar.Enabled = false;
            }
            else
            {
                MessageBox.Show("Se debe seleccionar un estado para el cliente");
            }   

        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            errorPClientes.Clear();
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
            FBuscarClientes fBuscarClientes = new FBuscarClientes();
            fBuscarClientes.ShowDialog();
            
            int CodigoCliente = fBuscarClientes.CodigoCliente;
            
            RBClientes = Clientes.ObtenerCliente(CodigoCliente);

            if (RBClientes.Rows.Count > 0)
            {
                tBCodigoCliente.Text = RBClientes.Rows[0][0].ToString();
                tBNombreCliente.Text = RBClientes.Rows[0][1].ToString();
                tBNombreRepresentante.Text = RBClientes.Rows[0][2].ToString();
                if ((RBClientes.Rows[0][3].ToString() != null) && (RBClientes.Rows[0][3].ToString() != ""))
                    cBTiposCliente.SelectedValue = RBClientes.Rows[0][3].ToString();
                else
                    cBTiposCliente.SelectedIndex = -1;
                tBNITCliente.Text = RBClientes.Rows[0][4].ToString();
                if ((RBClientes.Rows[0][5].ToString() != null) && (RBClientes.Rows[0][5].ToString() != ""))
                    cBPais.SelectedValue = RBClientes.Rows[0][5].ToString();
                else
                    cBPais.SelectedIndex = -1;
                if ((RBClientes.Rows[0][6].ToString() != null) && (RBClientes.Rows[0][6].ToString() != ""))
                    cBDepartamento.SelectedValue = RBClientes.Rows[0][6].ToString();
                else
                    cBDepartamento.SelectedIndex = -1;
                if ((RBClientes.Rows[0][7].ToString() != null) && (RBClientes.Rows[0][7].ToString() != ""))
                    cBProvincia.SelectedValue = RBClientes.Rows[0][7].ToString();
                else
                    cBProvincia.SelectedIndex = -1;
                if ((RBClientes.Rows[0][8].ToString() != null) && (RBClientes.Rows[0][8].ToString() != ""))
                    cBLugar.SelectedValue = RBClientes.Rows[0][8].ToString();
                else
                    cBLugar.SelectedIndex = -1;
                tBDireccion.Text = RBClientes.Rows[0][9].ToString();
                tBTelefono.Text = RBClientes.Rows[0][10].ToString();
                tBEmail.Text = RBClientes.Rows[0][11].ToString();
                tBObservaciones.Text = RBClientes.Rows[0][12].ToString();
                if ((RBClientes.Rows[0][12].ToString() != null) && (RBClientes.Rows[0][12].ToString() != ""))
                    cBEstadosCliente.SelectedValue = RBClientes.Rows[0][13].ToString();
                else
                    cBEstadosCliente.SelectedIndex = -1;

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

        private void FClientes_Load(object sender, EventArgs e)
        {
            CargarPaises();
            CargarTiposCliente();
            CargarEstadosCliente();

            InhabilitarControles(true);
            InicializarControles();

            bNuevo.Enabled = true;
            bEditar.Enabled = false;
            bEliminar.Enabled = false;
            bAceptar.Enabled = false;
            bCancelar.Enabled = false;
            errorPClientes.Clear();
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

        private void cBEstadosCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FReportesGestionComercialClientes fReportesGestionComercialclientes = new FReportesGestionComercialClientes(Clientes.ListarClientesReporte());
            fReportesGestionComercialclientes.ShowDialog();
        }
    }

    public class TipoCliente
    {
        private string CodTipCli;
        private string NomTipCli;

        public TipoCliente(string CodigoTipoCliente, string NombreTipoCliente)
        {
            this.CodTipCli = CodigoTipoCliente;
            this.NomTipCli = NombreTipoCliente;
        }

        public string CodigoTipoCliente
        {
            get
            {
                return CodTipCli;
            }
        }

        public string NombreTipoCliente
        {

            get
            {
                return NomTipCli;
            }
        }
    }

    public class EstadoCliente
    {
        private string CodEstCli;
        private string NomEstCli;

        public EstadoCliente(string CodigoEstadoCliente, string NombreEstadoCliente)
        {
            this.CodEstCli = CodigoEstadoCliente;
            this.NomEstCli = NombreEstadoCliente;
        }

        public string CodigoEstadoCliente
        {
            get
            {
                return CodEstCli;
            }
        }

        public string NombreEstadoCliente
        {

            get
            {
                return NomEstCli;
            }
        }
    }
}
