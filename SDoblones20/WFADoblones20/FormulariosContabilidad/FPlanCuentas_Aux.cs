using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.Contabilidad;

namespace WFADoblones20.FormulariosContabilidad
{
    public partial class FPlanCuentas_Aux : Form
    {
        private DataTable dt;

        public FPlanCuentas_Aux()
        {
            InitializeComponent();
        }

        private void FPlanCuentas_Aux_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            PlanCuentasCLN pc = new PlanCuentasCLN();
            dt = new DataTable();
            dt = pc.ListarPlanCuentas();
            tvPlanCuentas.ImageList = ilPlanCuentas;
            if (dt.Rows.Count > 0)
            {
                DataRow[] drs = dt.Select("NivelCuenta = 1");
                foreach (DataRow dr in drs)
                {
                    tvPlanCuentas.Nodes.Add(dr["NumeroCuenta"].ToString(), dr["NombreCuenta"].ToString()).ImageIndex = 1;
                }

                foreach (TreeNode tn in tvPlanCuentas.Nodes)
                {
                    CargarNodosHijos(tn.Name);
                }
            }
            else
            {
                MessageBox.Show("No existen registros en el Plan de Cuentas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CargarNodosHijos(string NodoPadre)
        {
            DataRow[] drs = dt.Select("NumeroCuentaPadre = '" + NodoPadre + "'");
            int nivel = 0;
            foreach (DataRow dr in drs)
            {
                nivel = int.Parse(dr["NivelCuenta"].ToString());
                tvPlanCuentas.Nodes.Find(NodoPadre, true)[0].Nodes.Add(dr["NumeroCuenta"].ToString(), dr["NombreCuenta"].ToString()).ImageIndex = nivel;
            }

            foreach (TreeNode tn in tvPlanCuentas.Nodes.Find(NodoPadre, true)[0].Nodes)
            {
                CargarNodosHijos(tn.Name);
            }
        }

    }
}
