using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.Sistema;
using CLCLN.GestionComercial;
using WFADoblones20.FormulariosSistema;
using CLCAD;

namespace WFADoblones20.FormulariosSistema
{
    public partial class FUsuarios : Form
    {
        private UsuariosCLN Usuarios = new UsuariosCLN();
        private DataTable RBUsuarios = new DataTable();

        private string TipoOperacion = "";
        

        public FUsuarios(string NombreServidor, bool PermitirInsertar, bool PermitirEditar, bool PermitirEliminar, bool PermitirNavegar, bool PermitirReportesGestionComercial)
        {
            //if (!ConfiguracionConeccion.Conectar(NombreServidor, "Doblones20", "sa", "kc28ma10cw18"))
            //{
            //    MessageBox.Show(this,"Temporalmente no puede ingresar a este Formulario sin permisos de administración, consulte con el Administrador del sistema",
            //        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            if (!Usuarios.AutenticaPrivilegiosAdministrador())
            {
                MessageBox.Show(this,"Temporalmente no puede ingresar a este Formulario sin permisos de administración, consulte con el Administrador del sistema",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            InitializeComponent();

            this.bNuevo.Visible = PermitirInsertar;
            this.bEditar.Visible = PermitirEditar;
            this.bEliminar.Visible = PermitirEliminar;
            this.bCancelar.Visible = (PermitirInsertar || PermitirEditar) ? true : false;
            this.bAceptar.Visible = (PermitirInsertar || PermitirEditar) ? true : false;
            //this.btnPermisos.Visible = (PermitirInsertar || PermitirEditar) ? true : false;
            this.bGrupos.Visible = (PermitirInsertar || PermitirEditar || PermitirEliminar) ? true : false;
            this.bBuscar.Visible = PermitirNavegar;
            this.bReporte.Visible = PermitirReportesGestionComercial;
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
            bPermisos.Enabled = false;
            bGrupos.Enabled = false;
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
            tBNombreUsuario.ReadOnly = Estado;
            tBContrasena.ReadOnly = Estado;
            tBRepetirContrasena.ReadOnly = Estado;
            tBDIPersona.ReadOnly = Estado;
            tBApellidoPaterno.ReadOnly = Estado;
            tBApellidoMaterno.ReadOnly = Estado;
            tBNombres.ReadOnly = Estado;
            gBSexo.Enabled = !Estado;
            tBCelular.ReadOnly = Estado;
            dTPFechaNacimiento.Enabled = !Estado;
            tBEMail.ReadOnly = Estado;
            tBDireccion.ReadOnly = Estado;
            tBTelefono.ReadOnly = Estado;
            tBRutaArchivoHuellaDactilar.ReadOnly = Estado;
            tBRutaArchivoFotografia.ReadOnly = Estado;
            tBRutaArchivoFirma.ReadOnly = Estado;
            tBObservaciones.ReadOnly = Estado;
        }

        private void InicializarControles()
        {
            tBNombreUsuario.Text = "";
            tBContrasena.Text = "";
            tBRepetirContrasena.Text = "";
            tBDIPersona.Text = "";
            tBApellidoPaterno.Text = "";
            tBApellidoMaterno.Text = "";
            tBNombres.Text = "";
            rBMasculino.Checked = false;
            rBFemenino.Checked = false;
            tBCelular.Text = "";
            tBEMail.Text = "";
            dTPFechaNacimiento.Text = "";
            tBDireccion.Text = "";
            tBTelefono.Text = "";
            tBRutaArchivoHuellaDactilar.Text = "";
            tBRutaArchivoFotografia.Text = "";
            tBRutaArchivoFirma.Text = "";
            tBObservaciones.Text = "";
            tBCodigoUsuario.Text = "";
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
            bPermisos.Enabled = false;

            tBNombreUsuario.Focus();
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            if (tBContrasena.Text == tBRepetirContrasena.Text)
            {
                if (TipoOperacion == "I")
                {
                    Usuarios.InsertarUsuario(tBNombreUsuario.Text, tBContrasena.Text, tBDIPersona.Text, tBApellidoPaterno.Text, tBApellidoMaterno.Text, tBNombres.Text, dTPFechaNacimiento.Value,
                                             ObtenerSexo(), tBCelular.Text, tBEMail.Text, tBDireccion.Text, tBTelefono.Text, tBRutaArchivoHuellaDactilar.Text, tBRutaArchivoFotografia.Text, tBRutaArchivoFirma.Text, tBObservaciones.Text);
                    tBCodigoUsuario.Text = new TransaccionesUtilidadesCLN().ObtenerUltimoIndiceTabla("Usuarios").ToString();
                    btnPermisos_Click(sender, e);

                    if (MessageBox.Show("Es muy importante que usted asigne una agencia(s) y grupo(s) de usuario para que el mismo pueda ingresar al sistema. ¿Desea proceder asignando agencias y grupos de trabajo?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        FAsignacionSistemaGruposPorUsuario fasgpu = new FAsignacionSistemaGruposPorUsuario(int.Parse(tBCodigoUsuario.Text), tBNombreUsuario.Text);
                        fasgpu.ShowDialog();
                    }
                }

                if (TipoOperacion == "E")
                {
                    Usuarios.ActualizarUsuario(int.Parse(tBCodigoUsuario.Text), tBNombreUsuario.Text, tBContrasena.Text, tBDIPersona.Text, tBApellidoPaterno.Text, tBApellidoMaterno.Text, tBNombres.Text, dTPFechaNacimiento.Value,
                             ObtenerSexo(), tBCelular.Text, tBEMail.Text, tBDireccion.Text, tBTelefono.Text, tBRutaArchivoHuellaDactilar.Text, tBRutaArchivoFotografia.Text, tBRutaArchivoFirma.Text, tBObservaciones.Text);
                }

                InhabilitarControles(true);
                bNuevo.Enabled = true;
                bEditar.Enabled = true;
                bEliminar.Enabled = true;
                bAceptar.Enabled = false;
                bCancelar.Enabled = false;
                bPermisos.Enabled = true;
                bGrupos.Enabled = true;
                TipoOperacion = "";
            }
            else
                MessageBox.Show("Verifique los campos de contraseña, pues no coinciden");
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
            bPermisos.Enabled = false;
            bGrupos.Enabled = false;
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
                Usuarios.EliminarUsuario(int.Parse(tBCodigoUsuario.Text));
                InhabilitarControles(true);
                InicializarControles();
                bNuevo.Enabled = true;
                bEditar.Enabled = false;
                bEliminar.Enabled = false;
                bAceptar.Enabled = false;
                bCancelar.Enabled = false;
                bPermisos.Enabled = false;
                bGrupos.Enabled = false;
            }
            TipoOperacion = "";
           
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
            bPermisos.Enabled = false;
            bGrupos.Enabled = false;
            TipoOperacion = "";

            if (tBCodigoUsuario.Text.Length > 0)
            {
                bGrupos.Enabled = true;
            }
        }

        private void bBuscar_Click(object sender, EventArgs e)
        {
            FBuscarUsuarios fBuscarUsuarios = new FBuscarUsuarios();
            fBuscarUsuarios.ShowDialog();
            RBUsuarios = fBuscarUsuarios.ResultadoBusquedaUsuarios;

            int CodigoUsuario = fBuscarUsuarios.CodigoUsuario;

            RBUsuarios = Usuarios.ObtenerUsuario(CodigoUsuario);

            if (RBUsuarios.Rows.Count > 0)
            {

                tBCodigoUsuario.Text = RBUsuarios.Rows[0][0].ToString();
                tBNombreUsuario.Text = RBUsuarios.Rows[0][1].ToString();
                tBContrasena.Text = RBUsuarios.Rows[0][2].ToString().Trim();
                tBRepetirContrasena.Text = RBUsuarios.Rows[0][2].ToString().Trim();
                tBDIPersona.Text = RBUsuarios.Rows[0][3].ToString();
                tBApellidoPaterno.Text = RBUsuarios.Rows[0][4].ToString();
                tBApellidoMaterno.Text = RBUsuarios.Rows[0][5].ToString();
                tBNombres.Text = RBUsuarios.Rows[0][6].ToString();

                if ((RBUsuarios.Rows[0][7].ToString() != null) && (RBUsuarios.Rows[0][7].ToString() != ""))
                    RepresentarSexo(RBUsuarios.Rows[0][7].ToString());

                //dTPFechaNacimiento.Value = DateTime.Parse(RBUsuarios.Rows[0][8].ToString());
                tBCelular.Text = RBUsuarios.Rows[0][9].ToString();
                tBEMail.Text = RBUsuarios.Rows[0][10].ToString();
                tBDireccion.Text = RBUsuarios.Rows[0][11].ToString();
                tBTelefono.Text = RBUsuarios.Rows[0][12].ToString();
                tBRutaArchivoHuellaDactilar.Text = RBUsuarios.Rows[0][13].ToString();
                tBRutaArchivoFotografia.Text = RBUsuarios.Rows[0][14].ToString();
                tBRutaArchivoFirma.Text = RBUsuarios.Rows[0][15].ToString();
                tBObservaciones.Text = RBUsuarios.Rows[0][16].ToString();

                bNuevo.Enabled = true;
                bEditar.Enabled = true;
                bEliminar.Enabled = true;
                bAceptar.Enabled = false;
                bCancelar.Enabled = false;
                bPermisos.Enabled = true;
                bGrupos.Enabled = true;
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
                bPermisos.Enabled = false;
                bGrupos.Enabled = false;
            }
        }

        private void bCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tBTelefonoD_TextChanged(object sender, EventArgs e)
        {

        }


        private void btnPermisos_Click(object sender, EventArgs e)
        {
            /*
            int CodigoUsuario = -1;
            FUsuariosPermisosInterfaces fpermisos;
            if(Int32.TryParse(tBCodigoUsuario.Text, out CodigoUsuario))
            {
                if (TipoOperacion == "I")
                    CodigoUsuario = new TransaccionesUtilidadesCLN().ObtenerUltimoIndiceTabla("Usuarios");

            }
            else
            {
                TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();
                CodigoUsuario = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("Usuarios");
            }
            //CodigoUsuario = tBCodigoUsuario

            fpermisos = new FUsuariosPermisosInterfaces(1, CodigoUsuario, String.IsNullOrEmpty(TipoOperacion) || TipoOperacion == "E" ? 'E': 'N');
            fpermisos.ShowDialog(this);
            fpermisos.Dispose();
            */
        }

        private void bGrupos_Click(object sender, EventArgs e)
        {
            FAsignacionSistemaGruposPorUsuario fasgpu = new FAsignacionSistemaGruposPorUsuario(int.Parse(tBCodigoUsuario.Text), tBNombreUsuario.Text);
            fasgpu.ShowDialog();
        }
    }
}
