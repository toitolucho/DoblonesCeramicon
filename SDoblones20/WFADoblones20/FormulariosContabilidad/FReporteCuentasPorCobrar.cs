using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.Contabilidad;
using WFADoblones20.ReportesContabilidad;

namespace WFADoblones20.FormulariosContabilidad
{
    public partial class FReporteCuentasPorCobrar : Form
    {
        public FReporteCuentasPorCobrar()
        {
            InitializeComponent();

            /*DataTable dt = new CuentasPorCobrarCLN().Reporte();


            CRCuentasPorCobrar crcc = new CRCuentasPorCobrar();
            crcc.SetDataSource(dt);
            crvCuentasPorCobrar.ReportSource = crcc;*/
        }

        public FReporteCuentasPorCobrar(int[] Numeros)
        {
            InitializeComponent();

            DataTable dt = new CuentasPorCobrarCLN().Reporte();

            DataTable dtaux = new DataTable();

            /*int columcount = dt.Columns.Count;
            for (int j = 0; j < columcount; j++)
            {

                dtaux.Columns.Add(dt.Columns.[j].ColumnName);
            }*/

            /*dtaux = dt.Copy();
            dtaux.Rows.Clear();

            DataRow[] drs;
            foreach (int i in Numeros)
            {
                drs = dt.Select("NumeroCuentaPorCobrar = " + i.ToString());
                foreach (DataRow dr in drs)
                {
                    dtaux.Rows.Add(dr.ItemArray);
                }
            }
            if(dtaux.Rows.Count==0)
                MessageBox.Show("Número de registros: " + dtaux.Rows.Count.ToString());
            /*for (int i = 0; i < n; i++)
            {
                if(dt.Rows[i]["NumeroCuentaPorCobrar"].ToString()==
            }*/

            
           /* CRCuentasPorCobrar crcc = new CRCuentasPorCobrar();
            crcc.SetDataSource(dtaux);
            dt.Clear();
            dtaux.Clear();
            crvCuentasPorCobrar.ReportSource = crcc;    */        
        }

        private void FReporteCuentasPorCobrar_Load(object sender, EventArgs e)
        {

        }
    }
}
