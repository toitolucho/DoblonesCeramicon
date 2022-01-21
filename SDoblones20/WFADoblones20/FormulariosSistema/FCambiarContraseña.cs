using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.Sistema;
using CLCAD;

namespace WFADoblones20.FormulariosSistema
{
    public partial class FCambiarContraseña : Form
    {
        static private UsuariosCLN Usuarios = new UsuariosCLN();
        int CodigoUsuario;
        public FCambiarContraseña(int CodigoUsuario)
        {
            InitializeComponent();
            this.CodigoUsuario = CodigoUsuario;
        }
        public FCambiarContraseña(string NombreServidor, int CodigoUsuario)
        {
            if (!Usuarios.AutenticaPrivilegiosAdministrador())
            {
                MessageBox.Show(this, "Temporalmente no puede ingresar a este Formulario sin permisos de administración, consulte con el Administrador del sistema",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            InitializeComponent();
            this.CodigoUsuario = CodigoUsuario;
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            if (Usuarios.VerificarContrasena(CodigoUsuario, tBContrasenaActual.Text))
            {
                if (tBContrasenaNueva.Text == tBContrasenaNuevaRepetida.Text)
                {
                    Usuarios.CambiarContrasena(CodigoUsuario, tBContrasenaNueva.Text);
                    MessageBox.Show("Se ha registrado exitosamente su nueva contraseña");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Las contraseña nueva no coindice en los dos cuadros de texto");
                }
            }
            else
            {
                MessageBox.Show("La contraseña actual escrita, no es correcta. Vuelva a escribirla.");
            }
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
