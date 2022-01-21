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

namespace WFADoblones20.FormulariosSistema
{
    public partial class FPersonas : Form
    {
        private PersonasCLN Personas = new PersonasCLN();
        private PaisesCLN Paises = new PaisesCLN();
        private DepartamentosCLN Departamentos = new DepartamentosCLN();
        private ProvinciasCLN Provincias = new ProvinciasCLN();
        private LugaresCLN Lugares = new LugaresCLN();
        
        private string TipoOperacion = "";
        public string DIPersona = "";
        
        public FPersonas()
        {
            InitializeComponent();
        }
        public FPersonas(bool PermitirInsertar, bool PermitirEditar, bool PermitirEliminar, bool PermitirNavegar)
        {
            InitializeComponent();

            this.bNuevo.Visible = PermitirInsertar;
            this.bEditar.Visible = PermitirEditar;
            this.bEliminar.Visible = PermitirEliminar;
            this.bCancelar.Visible = (PermitirInsertar || PermitirEditar) ? true : false;
            this.bAceptar.Visible = (PermitirInsertar || PermitirEditar) ? true : false;
            this.bBuscar.Visible = PermitirNavegar;
        }


        private void CargarPaises(ComboBox CBPais, string DisplayMember, string ValueMember)
        {
            DataTable DTPaises = new DataTable();
            DTPaises = Paises.ListarPaises();
            CBPais.DataSource = DTPaises.DefaultView;
            CBPais.DisplayMember = DisplayMember;
            CBPais.ValueMember = ValueMember;
        }

        private void CargarDepartamentos(string CodigoPais, ComboBox CBDepartamento, string DisplayMember, string ValueMember)
        {
            DataTable DTDepartamentos = new DataTable();
            DTDepartamentos = Departamentos.ObtenerDepartamentosPorPais(CodigoPais);
            CBDepartamento.DataSource = DTDepartamentos.DefaultView;
            CBDepartamento.DisplayMember = DisplayMember;
            CBDepartamento.ValueMember = ValueMember;
        }

        private void CargarProvincias(string CodigoPais, string CodigoDepartamento, ComboBox CBProvincia, string DisplayMember, string ValueMember)
        {
            DataTable DTProvincias = new DataTable();
            DTProvincias = Provincias.ObtenerProvinciasPorDepartamento(CodigoPais, CodigoDepartamento);
            CBProvincia.DataSource = DTProvincias.DefaultView;
            CBProvincia.DisplayMember = DisplayMember;
            CBProvincia.ValueMember = ValueMember;
        }

        private void CargarLugares(string CodigoPais, string CodigoDepartamento, string CodigoProvincia, ComboBox CBLugar, string DisplayMember, string ValueMember)
        {
            DataTable DTLugares = new DataTable();
            DTLugares = Lugares.ObtenerLugaresPorProvincia(CodigoPais, CodigoDepartamento, CodigoProvincia);
            CBLugar.DataSource = DTLugares.DefaultView;
            CBLugar.DisplayMember = DisplayMember;
            CBLugar.ValueMember = ValueMember;
        }

        private void FPersonas_Load(object sender, EventArgs e)
        {
            CargarPaises(cBPaisD, "NombrePais", "CodigoPais");
            InhabilitarControles(true);
            InicializarControles();

            bNuevo.Enabled = true;
            bEditar.Enabled = false;
            bEliminar.Enabled = false;
            bAceptar.Enabled = false;
            bCancelar.Enabled = false;
        }


        private void RepresentarSexo(string CodigoSexo)
        {
            if (CodigoSexo == "F")
            {
                rBFemenino.Checked = true;
            }
            else
            {
                rBMasculino.Checked = true;
            }
        }

        private string ObtenerSexo()
        {
            if (rBFemenino.Checked)
                return "F";
            else
                return "M";
        }

        private void InhabilitarControles(bool Estado)
        {
            if (TipoOperacion == "E")
                tBDIPersona.ReadOnly = true;
            else
                tBDIPersona.ReadOnly = Estado;
            tBApellidoPaterno.ReadOnly = Estado;
            tBApellidoMaterno.ReadOnly = Estado;
            tBNombres.ReadOnly = Estado;
            gBSexo.Enabled = !Estado;
            tBCelular.ReadOnly = Estado;
            dTPFechaNacimiento.Enabled = !Estado;
            tBEMail.ReadOnly = Estado;
            cBPaisD.Enabled= !Estado;
            cBDepartamentoD.Enabled = !Estado;
            cBProvinciaD.Enabled = !Estado;
            cBLugarD.Enabled = !Estado;
            tBDireccionD.ReadOnly = Estado;
            tBTelefonoD.ReadOnly = Estado;
            tBRutaArchivoHuellaDactilar.ReadOnly = Estado;
            tBRutaArchivoFotografia.ReadOnly = Estado;
            tBRutaArchivoFirma.ReadOnly = Estado;
            tBObservaciones.ReadOnly = Estado;
        }

        private void InicializarControles()
        {
            tBDIPersona.Text = "";
            tBApellidoPaterno.Text = "";
            tBApellidoMaterno.Text = "";
            tBNombres.Text = "";
            rBMasculino.Checked = false;
            rBFemenino.Checked = false;
            tBCelular.Text = "";
            tBEMail.Text = "";
            dTPFechaNacimiento.Text = "";
            cBPaisD.SelectedIndex = -1;
            cBDepartamentoD.SelectedIndex = -1;
            cBProvinciaD.SelectedIndex = -1;
            cBLugarD.SelectedIndex = -1;
            tBDireccionD.Text = "";
            tBTelefonoD.Text = "";
            tBRutaArchivoHuellaDactilar.Text = "";
            tBRutaArchivoFotografia.Text = "";
            tBRutaArchivoFirma.Text = "";
            tBObservaciones.Text = "";
        }

        private void bNuevo_Click(object sender, EventArgs e)
        {
            TipoOperacion = "I";

            InhabilitarControles(false);
            InicializarControles();
            rBFemenino.Checked = true;
            bNuevo.Enabled = false;
            bEditar.Enabled = false;
            bEliminar.Enabled = false;
            bAceptar.Enabled = true;
            bCancelar.Enabled = true;

            tBDIPersona.Focus();
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            string CodigoPaisD = null;
            string CodigoDepartamentoD = null;
            string CodigoProvinciaD = null;
            string CodigoLugarD = null;

            if (cBPaisD.SelectedIndex > -1)
                CodigoPaisD = cBPaisD.SelectedValue.ToString();

            if (cBDepartamentoD.SelectedIndex > -1)
                CodigoDepartamentoD = cBDepartamentoD.SelectedValue.ToString();

            if (cBProvinciaD.SelectedIndex > -1)
                CodigoProvinciaD = cBProvinciaD.SelectedValue.ToString();

            if (cBLugarD.SelectedIndex > -1)
                CodigoLugarD = cBLugarD.SelectedValue.ToString();


            if (TipoOperacion == "I")
            {
                Personas.InsertarPersona(tBDIPersona.Text, tBApellidoPaterno.Text, tBApellidoMaterno.Text, tBNombres.Text, dTPFechaNacimiento.Value,
                                         ObtenerSexo(), tBCelular.Text, tBEMail.Text,
                                         CodigoPaisD, CodigoDepartamentoD, CodigoProvinciaD, CodigoLugarD,
                                         tBDireccionD.Text, tBTelefonoD.Text, tBRutaArchivoHuellaDactilar.Text, tBRutaArchivoFotografia.Text, tBRutaArchivoFirma.Text, tBObservaciones.Text);
                
            }

            if (TipoOperacion == "E")
            {
                Personas.ActualizarPersona(tBDIPersona.Text, tBApellidoPaterno.Text, tBApellidoMaterno.Text, tBNombres.Text, dTPFechaNacimiento.Value,
                         ObtenerSexo(), tBCelular.Text, tBEMail.Text,
                         CodigoPaisD, CodigoDepartamentoD, CodigoProvinciaD, CodigoLugarD,
                         tBDireccionD.Text, tBTelefonoD.Text, tBRutaArchivoHuellaDactilar.Text, tBRutaArchivoFotografia.Text, tBRutaArchivoFirma.Text, tBObservaciones.Text);
            }
            DIPersona = tBDIPersona.Text;
            InhabilitarControles(true);
            bNuevo.Enabled = true;
            bEditar.Enabled = true;
            bEliminar.Enabled = true;
            bAceptar.Enabled = false;
            bCancelar.Enabled = false;
        }


        private void cBPaisD_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cBPaisD.SelectedIndex >= 0)
                CargarDepartamentos(cBPaisD.SelectedValue.ToString(), cBDepartamentoD, "NombreDepartamento", "CodigoDepartamento");
        }

        private void cBDepartamentoD_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cBDepartamentoD.SelectedIndex >= 0)
                CargarProvincias(cBPaisD.SelectedValue.ToString(), cBDepartamentoD.SelectedValue.ToString(), cBProvinciaD, "NombreProvincia", "codigoProvincia");
        }

        private void cBProvinciaD_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cBProvinciaD.SelectedIndex >= 0)
                CargarLugares(cBPaisD.SelectedValue.ToString(), cBDepartamentoD.SelectedValue.ToString(), cBProvinciaD.SelectedValue.ToString(), cBLugarD, "NombreLugar", "CodigoLugar");
        }

        private void bEditar_Click(object sender, EventArgs e)
        {
            TipoOperacion = "E";
            InhabilitarControles(false);
            //tCPersonas.SelectTab("tPDatosBasicos");
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
            MessageBoxIcon Icono =  MessageBoxIcon.Exclamation;
            DialogResult result;

            result = MessageBox.Show(Mensaje, Titulo, Botones, Icono);

            if (result == DialogResult.Yes)
            {
                Personas.EliminarPersona(tBDIPersona.Text);
                InhabilitarControles(true);
                InicializarControles();
                bNuevo.Enabled = true;
                bEditar.Enabled = false;
                bEliminar.Enabled = false;
                bAceptar.Enabled = false;
                bCancelar.Enabled = false;
            }
           
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            if(TipoOperacion == "I")
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
            string DIP = "";
            FBuscarPersonas fBuscarPersonas = new FBuscarPersonas();
            fBuscarPersonas.ShowDialog();
            DIP = fBuscarPersonas.DISeleccionado;
            if ((DIP != null) && (DIP != ""))
            {
                DataTable DTPersona = new DataTable();
                DTPersona = Personas.ObtenerPersona(DIP);

                tBDIPersona.Text = DTPersona.Rows[0][0].ToString();
                tBApellidoPaterno.Text = DTPersona.Rows[0][1].ToString();
                tBApellidoMaterno.Text = DTPersona.Rows[0][2].ToString();
                tBNombres.Text = DTPersona.Rows[0][3].ToString();
                if ((DTPersona.Rows[0][4].ToString() != null) && (DTPersona.Rows[0][4].ToString() != ""))
                    dTPFechaNacimiento.Value = DateTime.Parse(DTPersona.Rows[0][4].ToString());
                else
                    dTPFechaNacimiento.Text = "";

                RepresentarSexo(DTPersona.Rows[0][5].ToString());
                tBCelular.Text = DTPersona.Rows[0][6].ToString();
                tBEMail.Text = DTPersona.Rows[0][7].ToString();
                
                if ((DTPersona.Rows[0][8].ToString() != null) && (DTPersona.Rows[0][8].ToString() != ""))
                    cBPaisD.SelectedValue = DTPersona.Rows[0][8].ToString();
                else
                    cBPaisD.SelectedIndex = -1;

                if ((DTPersona.Rows[0][9].ToString() != null) && (DTPersona.Rows[0][9].ToString() != ""))
                    cBDepartamentoD.SelectedValue = DTPersona.Rows[0][9].ToString();
                else
                    cBDepartamentoD.SelectedIndex = -1;

                if ((DTPersona.Rows[0][10].ToString() != null) && (DTPersona.Rows[0][10].ToString() != ""))
                    cBProvinciaD.SelectedValue = DTPersona.Rows[0][10].ToString();
                else
                    cBProvinciaD.SelectedIndex = -1;

                if ((DTPersona.Rows[0][11].ToString() != null) && (DTPersona.Rows[0][11].ToString() != ""))
                    cBLugarD.SelectedValue = DTPersona.Rows[0][11].ToString();
                else
                    cBLugarD.SelectedIndex = -1;

                tBDireccionD.Text = DTPersona.Rows[0][12].ToString();
                tBTelefonoD.Text = DTPersona.Rows[0][12].ToString();


                tBRutaArchivoHuellaDactilar.Text = DTPersona.Rows[0][13].ToString();
                tBRutaArchivoFotografia.Text = DTPersona.Rows[0][14].ToString();
                tBRutaArchivoFirma.Text = DTPersona.Rows[0][15].ToString();
                tBObservaciones.Text = DTPersona.Rows[0][16].ToString();

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
    }
}
