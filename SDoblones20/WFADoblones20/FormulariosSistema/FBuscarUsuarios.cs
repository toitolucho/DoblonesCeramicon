using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.Sistema;
namespace WFADoblones20.FormulariosSistema
{
    public partial class FBuscarUsuarios : Form
    {
        private UsuariosCLN Usuarios = new UsuariosCLN();
        private DataTable RBUsuarios = new DataTable();
        public int CodigoUsuario = 0;

        public DataTable ResultadoBusquedaUsuarios
        {
            get
            {
                return RBUsuarios;
            }
            set
            {
                RBUsuarios = value;
            }
        }

        public FBuscarUsuarios()
        {
            InitializeComponent();
        }

        private void bBuscar_Click(object sender, EventArgs e)
        {
            bool ProcederBusqueda = true;
            if (tBTextoBusqueda.Text.Trim() == "")
            {
                string Mensaje = "Usted a decidido realizar una busqueda sin condiciones, lo cual le mostrara todos los registros existentes. Este tipo de busquedas pueden sobrecargar el sistema, ¿Realmente desea continuar?";
                string Titulo = "Advertencia";
                MessageBoxButtons MensajeBotones = MessageBoxButtons.OKCancel;
                MessageBoxIcon MensajeIcono = MessageBoxIcon.Exclamation;

                if (MessageBox.Show(Mensaje, Titulo, MensajeBotones, MensajeIcono) == DialogResult.Cancel)
                {
                    ProcederBusqueda = false;
                }
            }

            if (ProcederBusqueda)
            {
                RBUsuarios = Usuarios.BuscarUsuarios(cBBuscarPor.SelectedIndex.ToString(), tBTextoBusqueda.Text, cBBusquedaExacta.Checked);
                bSUsuarios.DataSource = RBUsuarios;
                dGVResultadoBusquedaUsuarios.AutoGenerateColumns = false;

                sSBuscarUsuarios.Items[0].Text = "Numero de registros encontrados: " + bSUsuarios.Count.ToString();
                tBTextoBusqueda.Focus();
                tBTextoBusqueda.SelectAll();

                if (dGVResultadoBusquedaUsuarios.Rows.Count > 0)
                {
                    asignarGrupoAccesoSistemaToolStripMenuItem.Enabled = true;
                }
                else
                {
                    asignarGrupoAccesoSistemaToolStripMenuItem.Enabled = false;
                }
            }
            
        }

        private void dGVResultadoBusquedaUsuarios_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FBuscarProductos_Load(object sender, EventArgs e)
        {
            cBBuscarPor.SelectedIndex = 1;
            tBTextoBusqueda.Focus();
        }

        private void dGVResultadoBusquedaUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CodigoUsuario = int.Parse(dGVResultadoBusquedaUsuarios.CurrentRow.Cells[0].Value.ToString());
            this.Close();
        }

        private void asignarGrupoAccesoSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dGVResultadoBusquedaUsuarios.CurrentRow.Index >= 0)
            {
                FAsignacionSistemaGruposPorUsuario fasgpu = new FAsignacionSistemaGruposPorUsuario(int.Parse(dGVResultadoBusquedaUsuarios.Rows[dGVResultadoBusquedaUsuarios.CurrentRow.Index].Cells[0].Value.ToString()), dGVResultadoBusquedaUsuarios.Rows[dGVResultadoBusquedaUsuarios.CurrentRow.Index].Cells[1].Value.ToString());
                fasgpu.ShowDialog();
            }
            else
            {
                MessageBox.Show("No se tiene ningun usuario seleccionado para realizar su asignacion de grupo");
            }
        }

    }

}
