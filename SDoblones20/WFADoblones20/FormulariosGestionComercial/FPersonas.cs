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
using WFADoblones20.FormulariosSistema;

namespace WFADoblones20
{
    public partial class FPersonas : Form
    {
        
        private PersonasCLN Personas = new PersonasCLN();
        private PaisesCLN Paises = new PaisesCLN();
        private DepartamentosCLN Departamentos = new DepartamentosCLN();
        private ProvinciasCLN Provincias = new ProvinciasCLN();
        private LugaresCLN Lugares = new LugaresCLN();
        public string DIPersonaNueva { get; set; }
        private string TipoOperacion = "";
        
        public FPersonas()
        {
            InitializeComponent();
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
            cBPais.Enabled= !Estado;
            cBDepartamento.Enabled = !Estado;
            cBProvincia.Enabled = !Estado;
            cBLugar.Enabled = !Estado;
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
            cBPais.SelectedIndex = -1;
            cBDepartamento.SelectedIndex = -1;
            cBProvincia.SelectedIndex = -1;
            cBLugar.SelectedIndex = -1;
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

            if (cBPais.SelectedIndex > -1)
                CodigoPaisD = cBPais.SelectedValue.ToString();

            if (cBDepartamento.SelectedIndex > -1)
                CodigoDepartamentoD = cBDepartamento.SelectedValue.ToString();

            if (cBProvincia.SelectedIndex > -1)
                CodigoProvinciaD = cBProvincia.SelectedValue.ToString();

            if (cBLugar.SelectedIndex > -1)
                CodigoLugarD = cBLugar.SelectedValue.ToString();


            if (TipoOperacion == "I")
            {
                Personas.InsertarPersona(tBDIPersona.Text, tBApellidoPaterno.Text, tBApellidoMaterno.Text, tBNombres.Text, dTPFechaNacimiento.Value,
                                         ObtenerSexo(), tBCelular.Text, tBEMail.Text,
                                         CodigoPaisD, CodigoDepartamentoD, CodigoProvinciaD, CodigoLugarD,
                                         tBDireccionD.Text, tBTelefonoD.Text, tBRutaArchivoHuellaDactilar.Text, tBRutaArchivoFotografia.Text, tBRutaArchivoFirma.Text, tBObservaciones.Text);
                this.DialogResult = DialogResult.OK;
                DIPersonaNueva = tBDIPersona.Text;
            }

            if (TipoOperacion == "E")
            {
                Personas.ActualizarPersona(tBDIPersona.Text, tBApellidoPaterno.Text, tBApellidoMaterno.Text, tBNombres.Text, dTPFechaNacimiento.Value,
                         ObtenerSexo(), tBCelular.Text, tBEMail.Text,
                         CodigoPaisD, CodigoDepartamentoD, CodigoProvinciaD, CodigoLugarD,
                         tBDireccionD.Text, tBTelefonoD.Text, tBRutaArchivoHuellaDactilar.Text, tBRutaArchivoFotografia.Text, tBRutaArchivoFirma.Text, tBObservaciones.Text);
            }

            InhabilitarControles(true);
            bNuevo.Enabled = true;
            bEditar.Enabled = true;
            bEliminar.Enabled = true;
            bAceptar.Enabled = false;
            bCancelar.Enabled = false;
        }


        private void cBPaisD_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cBPais.SelectedIndex >= 0)
                CargarDepartamentos(cBPais.SelectedValue.ToString(), cBDepartamento, "NombreDepartamento", "CodigoDepartamento");
        }

        private void cBDepartamentoD_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cBDepartamento.SelectedIndex >= 0)
                CargarProvincias(cBPais.SelectedValue.ToString(), cBDepartamento.SelectedValue.ToString(), cBProvincia, "NombreProvincia", "codigoProvincia");
        }

        private void cBProvinciaD_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cBProvincia.SelectedIndex >= 0)
                CargarLugares(cBPais.SelectedValue.ToString(), cBDepartamento.SelectedValue.ToString(), cBProvincia.SelectedValue.ToString(), cBLugar, "NombreLugar", "CodigoLugar");
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
                    cBPais.SelectedValue = DTPersona.Rows[0][8].ToString();
                else
                    cBPais.SelectedIndex = -1;

                if ((DTPersona.Rows[0][9].ToString() != null) && (DTPersona.Rows[0][9].ToString() != ""))
                    cBDepartamento.SelectedValue = DTPersona.Rows[0][9].ToString();
                else
                    cBDepartamento.SelectedIndex = -1;

                if ((DTPersona.Rows[0][10].ToString() != null) && (DTPersona.Rows[0][10].ToString() != ""))
                    cBProvincia.SelectedValue = DTPersona.Rows[0][10].ToString();
                else
                    cBProvincia.SelectedIndex = -1;

                if ((DTPersona.Rows[0][11].ToString() != null) && (DTPersona.Rows[0][11].ToString() != ""))
                    cBLugar.SelectedValue = DTPersona.Rows[0][11].ToString();
                else
                    cBLugar.SelectedIndex = -1;

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
