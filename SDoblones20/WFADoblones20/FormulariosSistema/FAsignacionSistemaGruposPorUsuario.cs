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
    public partial class FAsignacionSistemaGruposPorUsuario : Form
    {
        DataTable DTListadoAgencias = null;
        DataTable DTListadoSistemaGrupos = null;
        DataTable DTSistemaGruposUsuarioAgencia = null;

        private int CodigoUsuario;
        private string NombreUsuario;
        private int  NumeroAgencia;
        private UsuariosCLN Usuarios;
        private AgenciasCLN Agencias;
        private SistemaGruposCLN SistemaGrupos;
        private SistemaGruposUsuariosCLN SistemaGruposUsuarios;

        public bool UsuarioSeleccionado = false;
        public int CodigoGrupoSistema = -1;

        public FAsignacionSistemaGruposPorUsuario(int CodigoUsuario, string NombreUsuario)
        {
            InitializeComponent();

            this.CodigoUsuario = CodigoUsuario;
            this.NombreUsuario = NombreUsuario;
            this.NumeroAgencia = 0;

            Usuarios = new UsuariosCLN();
            Agencias = new AgenciasCLN();
            SistemaGrupos = new SistemaGruposCLN();
            SistemaGruposUsuarios = new SistemaGruposUsuariosCLN();


            dGVAgencias.AutoGenerateColumns = false;
            dGVSistemaGrupos.AutoGenerateColumns = false;
            tSSLCodigoUsuario.Text = "Codigo usuario: " + CodigoUsuario.ToString();
            tSSLNombreUsuario.Text = "Nombre usuario: " + NombreUsuario;
            tSSLEstado.Text = "Estado: Navegación";
        }

        void btnAceptar_Click(object sender, EventArgs e)
        {
            NumeroAgencia = int.Parse(dGVAgencias.Rows[dGVAgencias.CurrentRow.Index].Cells[0].Value.ToString());
            foreach (DataGridViewRow FilaGrilla in dGVSistemaGrupos.Rows)
            {
                DataGridViewCell CeldaGrilla2 = FilaGrilla.Cells[2];
                DataGridViewCell CeldaGrilla0 = FilaGrilla.Cells[0];

                DataTable dtaux = SistemaGruposUsuarios.ObtenerSistemaGrupoUsuarioAgencia(CodigoUsuario, NumeroAgencia, byte.Parse(CeldaGrilla0.Value.ToString()));
                    
                if (Convert.ToBoolean(CeldaGrilla2.FormattedValue) == true)
                {
                    if (dtaux.Rows.Count <= 0)
                    {
                        SistemaGruposUsuarios.InsertarSistemaGrupoUsuario(CodigoUsuario, NumeroAgencia, byte.Parse(CeldaGrilla0.Value.ToString()));
                    }
                }
                else
                {
                    if (dtaux.Rows.Count > 0)
                    {
                        SistemaGruposUsuarios.EliminarSistemaGrupoUsuario(CodigoUsuario, NumeroAgencia, byte.Parse(CeldaGrilla0.Value.ToString()));
                    }
                }
            }
            bAceptar.Enabled = false;
            bCancelar.Enabled = false;
            
            tSSLEstado.Text = "Estado: Navegación";
        }

        private void FListadoSistemaGruposPorUsuario_Load(object sender, EventArgs e)
        {
            DTListadoAgencias = Agencias.ListarAgencias();
            dGVAgencias.DataSource = DTListadoAgencias;
            DTListadoSistemaGrupos = SistemaGrupos.ListarSistemasGrupos();
            dGVSistemaGrupos.DataSource = DTListadoSistemaGrupos;
        }


        private DataTable ObtenerSistemaGruposPorAgenciaUsuario(int CodigoUsuario, int NumeroAgencia)
        {
            
            return SistemaGruposUsuarios.ObtenerSistemaGruposUsuarioAgencia(CodigoUsuario, NumeroAgencia);

        }
        

        private void dGVAgencias_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DTSistemaGruposUsuarioAgencia = ObtenerSistemaGruposPorAgenciaUsuario(CodigoUsuario, int.Parse(DTListadoAgencias.Rows[e.RowIndex]["NumeroAgencia"].ToString()));

            if (DTSistemaGruposUsuarioAgencia.Rows.Count > 0)
            {
                NumeroAgencia = int.Parse(dGVAgencias.Rows[e.RowIndex].Cells[0].Value.ToString());

                foreach (DataGridViewRow FilaGrilla in dGVSistemaGrupos.Rows)
                {
                    DataGridViewCell CeldaGrilla = FilaGrilla.Cells[2];
                    CeldaGrilla.Value = false;

                    foreach (DataRow FilaTabla in DTSistemaGruposUsuarioAgencia.Rows)
                    {
                        if (int.Parse(FilaTabla["CodigoGrupoSistema"].ToString()) == int.Parse(FilaGrilla.Cells[0].Value.ToString()))
                        {
                            CeldaGrilla.Value = true;
                        }
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow FilaGrilla in dGVSistemaGrupos.Rows)
                {
                    DataGridViewCell CeldaGrilla = FilaGrilla.Cells[2];
                    CeldaGrilla.Value = false;

                    foreach (DataRow FilaTabla in DTSistemaGruposUsuarioAgencia.Rows)
                    {
                        CeldaGrilla.Value = false;
                    }
                }

            }
            bAceptar.Enabled = false;
            bCancelar.Enabled = false;
            tSSLEstado.Text = "Estado: Navegación"; 
        }

        private void dGVSistemaGrupos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            DTSistemaGruposUsuarioAgencia = ObtenerSistemaGruposPorAgenciaUsuario(CodigoUsuario, int.Parse(DTListadoAgencias.Rows[dGVAgencias.CurrentRow.Index]["NumeroAgencia"].ToString()));

            foreach (DataGridViewRow FilaGrilla in dGVSistemaGrupos.Rows)
            {
                DataGridViewCell CeldaGrilla = FilaGrilla.Cells[2];
                CeldaGrilla.Value = false;

                foreach (DataRow FilaTabla in DTSistemaGruposUsuarioAgencia.Rows)
                {
                    if (int.Parse(FilaTabla["CodigoGrupoSistema"].ToString()) == int.Parse(FilaGrilla.Cells[0].Value.ToString()))
                    {
                        CeldaGrilla.Value = true;
                    }
                }
            }
            bAceptar.Enabled = false;
            bCancelar.Enabled = false;
            tSSLEstado.Text = "Estado: Navegación";
        }

        private void dGVSistemaGrupos_CurrentCellChanged(object sender, EventArgs e)
        {
            bAceptar.Enabled = true;
            bCancelar.Enabled = true;
            tSSLEstado.Text = "Estado: Edición";
        }

        private void bCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
