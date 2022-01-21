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
    public partial class FSistemaGruposListado : Form
    {
        int NumeroAgencia;
        int CodigoUsuario;
        SistemaGruposUsuariosCLN _SistemaGruposUsuariosCLN = null;
        SistemaGruposCLN _SistemaGruposCLN = null;
        DataTable DTSistemaGrupos = null;
        DataTable DTSistemaGruposUsuarios = null;

        public FSistemaGruposListado(int NumeroAgencia, int CodigoUsuario)
        {
            InitializeComponent();
            this.NumeroAgencia = NumeroAgencia;
            this.CodigoUsuario = CodigoUsuario;

            _SistemaGruposCLN = new SistemaGruposCLN();
            _SistemaGruposUsuariosCLN = new SistemaGruposUsuariosCLN();

            this.Load += new EventHandler(FSistemaGruposListado_Load);
            this.btnAceptar.Click += new EventHandler(btnAceptar_Click);
            this.btnCancelar.Click += new EventHandler(btnCancelar_Click);
        }

        void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnAceptar_Click(object sender, EventArgs e)
        {
            foreach (DataRow fila in DTSistemaGrupos.Rows)
            {
                if (fila.RowState == DataRowState.Modified)
                {
                    try
                    {
                        _SistemaGruposUsuariosCLN.RealizarOperacionesSistemaGruposUsuarios(CodigoUsuario, NumeroAgencia, Byte.Parse(fila["CodigoGrupoSistema"].ToString()), Boolean.Parse(fila["Seleccionado"].ToString()));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrio el siguiente Error : " + ex.Message);                        
                    }
                }
            }
            DTSistemaGrupos.AcceptChanges();
        }

        void FSistemaGruposListado_Load(object sender, EventArgs e)
        {
            DTSistemaGrupos = _SistemaGruposCLN.ListarSistemasGrupos();
            DTSistemaGrupos.Columns.Add("Seleccionado", Type.GetType("System.Boolean"));
            dtGVSistemaGrupos.AutoGenerateColumns = false;
            dtGVSistemaGrupos.DataSource = DTSistemaGrupos;

            DTSistemaGruposUsuarios = _SistemaGruposUsuariosCLN.ObtenerSistemaGruposUsuario(CodigoUsuario);

            foreach (DataRow FilaGrupoUsuarios in DTSistemaGruposUsuarios.Rows)
            {
                DataRow filaGrupo = DTSistemaGrupos.Rows.Find(FilaGrupoUsuarios["CodigoGrupoSistema"]);
                if (filaGrupo != null)
                {
                    filaGrupo["Seleccionado"] = true;
                }
            }
            DTSistemaGrupos.AcceptChanges();

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
