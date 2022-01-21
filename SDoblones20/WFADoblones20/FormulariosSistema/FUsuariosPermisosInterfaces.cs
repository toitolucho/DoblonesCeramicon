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
namespace WFADoblones20.FormulariosSistema
{
    public partial class FUsuariosPermisosInterfaces : Form
    {
        int NumeroAGencia;
        int CodigoUsuario;
        DataTable DTPermisosPorGrupos;
        DataTable DTPermisosIndividuales;
        DataTable DTPermisosIndividualesBackup;
        DataTable DTSistemaGrupos;
        SistemaGruposCLN _SistemaGruposCLN = null;
        SistemaGruposUsuariosCLN _SistemaGruposUsuariosCLN = null;
        SistemaGruposPermisosInterfacesCLN _SistemaGruposPermisosInterfacesCLN = null;
        UsuariosAgenciasPermisosInterfacesCLN _UsuariosAgenciasPermisosInterfacesCLN = null;
        private char TipoOperacion = 'N';
        bool OperacionInsertadoConcluido = false;
        public FUsuariosPermisosInterfaces(int NumeroAgencia, int CodigoUsuario, char TipoOperacion)
        {
            InitializeComponent();
            this.NumeroAGencia = NumeroAgencia;
            this.CodigoUsuario = CodigoUsuario;
            this.TipoOperacion = TipoOperacion;

            _SistemaGruposCLN = new SistemaGruposCLN();
            _SistemaGruposUsuariosCLN = new SistemaGruposUsuariosCLN();
            _SistemaGruposPermisosInterfacesCLN = new SistemaGruposPermisosInterfacesCLN();
            _UsuariosAgenciasPermisosInterfacesCLN = new UsuariosAgenciasPermisosInterfacesCLN();
            btnAceptar.Enabled = false;
            btnModificar.Enabled = false;
            btnCancelar.Enabled = false;

            dtGVPermisosIndividuales.Columns[0].Width -= 45;
            dtGVPermisosIndividuales.Columns[1].Width += 15;
            dtGVPermisosIndividuales.Columns[2].Width += 55;

            dtGVPermisosPorGrupos.Columns[0].Width -= 45;
            dtGVPermisosPorGrupos.Columns[1].Width += 15;
            dtGVPermisosPorGrupos.Columns[2].Width += 55;

            tabControl1.Controls["tabPagePorGrupos"].Enabled = false;
            tabControl1.SelectedTab = tabPageParticulares; 
        }

        private void FUsuariosPermisosInterfaces_Load(object sender, EventArgs e)
        {
            if (TipoOperacion == 'E') //navegación y Edición de Permisos
            {
                DTSistemaGrupos = _SistemaGruposCLN.ObtenerSistemaGruposUsuariosPorUsuario(CodigoUsuario, NumeroAGencia);
                if (DTSistemaGrupos.Rows.Count > 0)
                {
                    cBoxGruposUsuarios.DataSource = DTSistemaGrupos;
                    cBoxGruposUsuarios.DisplayMember = "NombreGrupoSistema";
                    cBoxGruposUsuarios.ValueMember = "CodigoGrupoSistema";
                    cBoxGruposUsuarios.SelectedIndex = 0;

                    DTPermisosPorGrupos = _SistemaGruposPermisosInterfacesCLN.ListarPermisosPorGrupo(Byte.Parse(DTSistemaGrupos.Rows[0]["CodigoGrupoSistema"].ToString()));

                    dtGVPermisosPorGrupos.DataSource = DTPermisosPorGrupos;
                }

                DTPermisosIndividuales = _UsuariosAgenciasPermisosInterfacesCLN.ListarPermisosPorUsuario(CodigoUsuario, NumeroAGencia);
                if (DTPermisosIndividuales.Rows.Count > 0)
                {
                    DTPermisosIndividualesBackup = DTPermisosIndividuales.Copy();
                    dtGVPermisosIndividuales.DataSource = DTPermisosIndividuales;

                    btnAceptar.Enabled = false;
                    btnModificar.Enabled = true;
                    btnCancelar.Enabled = false;
                }
                dtGVPermisosIndividuales.ReadOnly = true;
                habilitarChecks(false);
            }
            else if(TipoOperacion == 'N') // si se registra por primera vez los registros
            {
                btnAceptar.Enabled = true;
                btnModificar.Enabled = false;
                btnCancelar.Enabled = false;
                habilitarChecks(true);

                DTPermisosIndividuales = _UsuariosAgenciasPermisosInterfacesCLN.ListarPermisosPorUsuarioNuevo();
                dtGVPermisosIndividuales.DataSource = DTPermisosIndividuales;
                dtGVPermisosIndividuales.ReadOnly = false;
            }

            

            cBoxGruposUsuarios.SelectedIndexChanged += new EventHandler(cBoxGruposUsuarios_SelectedIndexChanged);
            
            
        }

        

        private void btnModificar_Click(object sender, EventArgs e)
        {
            dtGVPermisosIndividuales.ReadOnly = false;
            btnAceptar.Enabled = true;
            btnModificar.Enabled = false;
            btnCancelar.Enabled = true;
            habilitarChecks(true);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool PermitirInsertar = false;
            bool PermitirEditar = false;
            bool PermitirEliminar = false;
            bool PermitirNavegar = false;
            bool PermitirReportes = false;
            int CodigoInterface = -1;
            if (TipoOperacion == 'E')
            {
                dtGVPermisosIndividuales.ReadOnly = false;
                btnAceptar.Enabled = false;
                btnModificar.Enabled = true;
                btnCancelar.Enabled = false;
                foreach (DataRow filaModificada in DTPermisosIndividuales.Rows)
                {
                    if (filaModificada.RowState == DataRowState.Modified)
                    {
                        PermitirInsertar = Boolean.Parse(filaModificada["PermitirInsertar"].ToString());
                        PermitirEditar = Boolean.Parse(filaModificada["PermitirEditar"].ToString());
                        PermitirEliminar = Boolean.Parse(filaModificada["PermitirEliminar"].ToString());
                        PermitirNavegar = Boolean.Parse(filaModificada["PermitirNavegar"].ToString());
                        PermitirReportes = Boolean.Parse(filaModificada["PermitirReportes"].ToString());
                        CodigoInterface = Int32.Parse(filaModificada["CodigoInterface"].ToString());

                        try
                        {
                            _UsuariosAgenciasPermisosInterfacesCLN.ActualizarUsuarioAgenciaPermisoInterface(CodigoUsuario, NumeroAGencia, (byte)CodigoInterface, PermitirInsertar, PermitirEditar, PermitirEliminar, PermitirNavegar, PermitirReportes);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ocurrio el siguiente error " + ex.Message);
                            return;
                        }
                    }
                }
                MessageBox.Show("Se realizaron Correctamente los cambios");
            }
            else if (TipoOperacion == 'N')
            {
                foreach (DataRow filaNueva in DTPermisosIndividuales.Rows)
                {
                    PermitirInsertar = Boolean.Parse(filaNueva["PermitirInsertar"].ToString());
                    PermitirEditar = Boolean.Parse(filaNueva["PermitirEditar"].ToString());
                    PermitirEliminar = Boolean.Parse(filaNueva["PermitirEliminar"].ToString());
                    PermitirNavegar = Boolean.Parse(filaNueva["PermitirNavegar"].ToString());
                    PermitirReportes = Boolean.Parse(filaNueva["PermitirReportes"].ToString());
                    CodigoInterface = Int32.Parse(filaNueva["CodigoInterface"].ToString());

                    try
                    {
                        _UsuariosAgenciasPermisosInterfacesCLN.InsertarUsuarioAgenciaPermisoInterface(CodigoUsuario, NumeroAGencia, (byte) CodigoInterface, PermitirInsertar, PermitirEditar, PermitirEliminar, PermitirNavegar, PermitirReportes);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrio el siguiente error " + ex.Message);
                        return;
                    }

                    TipoOperacion = 'E';
                }
                MessageBox.Show(this, "La Asigación de permisos se Realizó correctamente" , "Permisos de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtGVPermisosIndividuales.ReadOnly = true;
                btnAceptar.Enabled = false;
                btnModificar.Enabled = true;
                btnCancelar.Enabled = false;
                OperacionInsertadoConcluido = true;
            }
            habilitarChecks(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dtGVPermisosIndividuales.ReadOnly = true;
            DTPermisosIndividuales = DTPermisosIndividualesBackup.Copy();
            dtGVPermisosIndividuales.DataSource = DTPermisosIndividuales;
            btnModificar.Enabled = true;
            btnAceptar.Enabled = false;
            btnCancelar.Enabled = false;
            habilitarChecks(false);
        }

        private void cBoxGruposUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DTSistemaGrupos.Rows.Count > 0)
            {
                DTPermisosPorGrupos = _SistemaGruposPermisosInterfacesCLN.ListarPermisosPorGrupo(Byte.Parse(cBoxGruposUsuarios.SelectedValue.ToString()));
                dtGVPermisosPorGrupos.DataSource = DTPermisosPorGrupos;
            }
        }

        private void FUsuariosPermisosInterfaces_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (TipoOperacion == 'N' && !OperacionInsertadoConcluido)
            {
                if (MessageBox.Show(this, "Aun No ha Aceptado los permisos para el usuario. ¿ Desea Guardar los permisos en el Estado Actual?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else {
                    btnAceptar_Click(sender, e as EventArgs);
                    this.Close();
                }
            }
        }

        private void btnPermisosXGrupos_Click(object sender, EventArgs e)
        {
            FSistemaGruposListado formListadoGrupos = new FSistemaGruposListado(NumeroAGencia, CodigoUsuario);
            formListadoGrupos.ShowDialog(this);
            formListadoGrupos.Dispose();
        }

        private void cBoxInsertar_CheckedChanged(object sender, EventArgs e)
        {
            bool Estado = cBoxInsertar.Checked;
            for (int i = 0; i < dtGVPermisosIndividuales.RowCount; i++)
            {
                dtGVPermisosIndividuales[3, i].Value = Estado;
            }
            dtGVPermisosIndividuales.EndEdit();
        }

        private void cBoxEditar_CheckedChanged(object sender, EventArgs e)
        {
            bool Estado = cBoxEditar.Checked;
            for (int i = 0; i < dtGVPermisosIndividuales.RowCount; i++)
            {
                dtGVPermisosIndividuales[4, i].Value = Estado;
            }
            dtGVPermisosIndividuales.EndEdit();
        }

        private void cBoxEliminar_CheckedChanged(object sender, EventArgs e)
        {
            bool Estado = cBoxEliminar.Checked;
            for (int i = 0; i < dtGVPermisosIndividuales.RowCount; i++)
            {
                dtGVPermisosIndividuales[5, i].Value = Estado;
            }
            dtGVPermisosIndividuales.EndEdit();
        }

        private void cBoxNavegar_CheckedChanged(object sender, EventArgs e)
        {
            bool Estado = cBoxNavegar.Checked;
            for (int i = 0; i < dtGVPermisosIndividuales.RowCount; i++)
            {
                dtGVPermisosIndividuales[6, i].Value = Estado;
            }
            dtGVPermisosIndividuales.EndEdit();
        }

        private void cBoxReportes_CheckedChanged(object sender, EventArgs e)
        {
            bool Estado = cBoxReportes.Checked;
            for (int i = 0; i < dtGVPermisosIndividuales.RowCount; i++)
            {
                dtGVPermisosIndividuales[7, i].Value = Estado;
            }
            dtGVPermisosIndividuales.EndEdit();
        }

        public void habilitarChecks(bool habilitar)
        {
            cBoxEditar.Enabled = habilitar;
            cBoxEliminar.Enabled = habilitar;
            cBoxInsertar.Enabled = habilitar;
            cBoxNavegar.Enabled = habilitar;
            cBoxReportes.Enabled = habilitar;
        }
    }
}
