using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD;
using CLCAD.DSDoblones20ContabilidadTableAdapters;
using System.Data;
using System.Data.SqlClient;
namespace CLCLN.Contabilidad
{
    public class EstadoResultadosCLN
    {
        private DateTime FechaDel, FechaAl;
        private decimal SumaIngresos, SumaEgresos;
        private decimal SegundaSumaIngresos, SegundaSumaEgresos;

        public EstadoResultadosCLN(string fechaDel, string fechaAl)
        {
            FechaDel = DateTime.Parse(fechaDel);
            FechaAl = DateTime.Parse(fechaAl);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarIngresos()
        {
            DataTable dt = new DSDoblones20Contabilidad.VistaBalanceGeneralReporteDataTable();
            PlanCuentasCLN cuentas = new PlanCuentasCLN();
            DataTable dtaux = new DataTable();

            dtaux = cuentas.ListarPlanCuentasIngreso();
            SumaIngresos = 0;

            foreach (DataRow r in dtaux.Rows)
            {
                dt.Rows.Add(r.ItemArray);                
            }

            dtaux.Dispose();
            dtaux = new DataTable();

            ListarEstadoResultadosIngresosTableAdapter TAactivo = new ListarEstadoResultadosIngresosTableAdapter();
            dtaux = TAactivo.GetData(FechaDel, FechaAl);

            int n1 = dt.Rows.Count;
            int n2 = dtaux.Rows.Count;

            for (int i = 0; i < n2; i++)
            {
                for (int j = 0; j < n1; j++)
                {
                    if (dtaux.Rows[i][0].ToString() == dt.Rows[j][1].ToString())
                    {
                        dt.Rows[j][4] = dtaux.Rows[i][1].ToString();
                        SumaIngresos += decimal.Parse(dtaux.Rows[i][1].ToString());
                        break;
                    }
                }
            }

            dtaux.Clear();
            dtaux.Dispose();

            decimal sumas = 0;

            List<string> ListaPadres = new List<string>();
            List<int> ListaIndicePadres = new List<int>();
            int nivel = 4;
            string nivelpadre;

            while (nivel > 0)
            {
                nivelpadre = nivel.ToString();

                for (int i = 0; i < n1; i++)
                {
                    if (dt.Rows[i][3].ToString() == nivelpadre)
                    {
                        ListaPadres.Add(dt.Rows[i][1].ToString());
                        ListaIndicePadres.Add(i);
                    }
                }

                int n3 = ListaPadres.Count;
                

                for (int i = 0; i < n3; i++)
                {
                    sumas = 0;

                    for (int j = 0; j < n1; j++)
                    {
                        if (ListaPadres[i] == dt.Rows[j][0].ToString())
                        {
                            sumas += decimal.Parse(dt.Rows[j][4].ToString());
                        }                        
                    }

                    dt.Rows[ListaIndicePadres[i]][4] = sumas.ToString("F2");
                }

                nivel--;
                ListaPadres.Clear();
                ListaIndicePadres.Clear();                
            }

            return dt;
        }



        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarEgresos()
        {
            DataTable dt = new DSDoblones20Contabilidad.VistaBalanceGeneralReporteDataTable();
            PlanCuentasCLN cuentas = new PlanCuentasCLN();
            DataTable dtaux = new DataTable();

            dtaux = cuentas.ListarPlanCuentasEgreso();
            SumaEgresos = 0;

            foreach (DataRow r in dtaux.Rows)
            {
                dt.Rows.Add(r.ItemArray);                
            }

            dtaux.Dispose();
            dtaux = new DataTable();

            ListarEstadoResultadosEgresosTableAdapter TAactivo = new ListarEstadoResultadosEgresosTableAdapter();
            dtaux = TAactivo.GetData(FechaDel, FechaAl);

            int n1 = dt.Rows.Count;
            int n2 = dtaux.Rows.Count;

            for (int i = 0; i < n2; i++)
            {
                for (int j = 0; j < n1; j++)
                {
                    if (dtaux.Rows[i][0].ToString() == dt.Rows[j][1].ToString())
                    {
                        dt.Rows[j][4] = dtaux.Rows[i][1].ToString();
                        SumaEgresos += decimal.Parse(dtaux.Rows[i][1].ToString());
                        break;
                    }
                }
            }

            dtaux.Clear();
            dtaux.Dispose();

            decimal sumas = 0;

            List<string> ListaPadres = new List<string>();
            List<int> ListaIndicePadres = new List<int>();
            int nivel = 4;
            string nivelpadre;

            while (nivel > 0)
            {
                nivelpadre = nivel.ToString();

                for (int i = 0; i < n1; i++)
                {
                    if (dt.Rows[i][3].ToString() == nivelpadre)
                    {
                        ListaPadres.Add(dt.Rows[i][1].ToString());
                        ListaIndicePadres.Add(i);
                    }
                }

                int n3 = ListaPadres.Count;


                for (int i = 0; i < n3; i++)
                {
                    sumas = 0;

                    for (int j = 0; j < n1; j++)
                    {
                        if (ListaPadres[i] == dt.Rows[j][0].ToString())
                        {
                            sumas += decimal.Parse(dt.Rows[j][4].ToString());
                        }
                    }

                    dt.Rows[ListaIndicePadres[i]][4] = sumas.ToString("F2");
                }

                nivel--;
                ListaPadres.Clear();
                ListaIndicePadres.Clear();
            }
            
            return dt;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarEstadoResultadosDiferencias()
        {
            DataTable dt = new DSDoblones20Contabilidad.VistaEstadoResultadosDiferencialReporteDataTable();
            dt.Rows.Add(dt.NewRow());
            dt.Rows[0][0] = SumaIngresos.ToString("F2");
            dt.Rows[0][1] = SumaEgresos.ToString("F2");

            return dt;
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarIngresos(string SegundaFechaD, string SegundaFechaA)
        {
            DataTable dt = new DSDoblones20Contabilidad.VistaBalanceGeneralComparativoReporteDataTable();
            PlanCuentasCLN cuentas = new PlanCuentasCLN();
            DataTable dtaux = new DataTable();
            DateTime SegundaFechaDel, SegundaFechaAl;

            SegundaFechaDel = DateTime.Parse(SegundaFechaD);
            SegundaFechaAl = DateTime.Parse(SegundaFechaA);

            dtaux = cuentas.ListarPlanCuentasIngreso();
            SumaIngresos = 0;
            SegundaSumaIngresos = 0;

            foreach (DataRow r in dtaux.Rows)
            {
                dt.Rows.Add(r.ItemArray);
            }

            dtaux.Dispose();
            dtaux = new DataTable();
            int n1 = dt.Rows.Count;
            ListarEstadoResultadosIngresosTableAdapter TAactivo = new ListarEstadoResultadosIngresosTableAdapter();

            dtaux = TAactivo.GetData(FechaDel, FechaAl);
            int n2 = dtaux.Rows.Count;

            for (int i = 0; i < n2; i++)
            {
                for (int j = 0; j < n1; j++)
                {
                    if (dtaux.Rows[i][0].ToString() == dt.Rows[j][1].ToString())
                    {
                        dt.Rows[j][4] = dtaux.Rows[i][1].ToString();
                        SumaIngresos += decimal.Parse(dtaux.Rows[i][1].ToString());
                        break;
                    }
                }
            }

            dtaux.Clear();
            dtaux.Dispose();

            //Se calcula la segunda

            dtaux = TAactivo.GetData(SegundaFechaDel, SegundaFechaAl);
            n2 = dtaux.Rows.Count;

            for (int i = 0; i < n2; i++)
            {
                for (int j = 0; j < n1; j++)
                {
                    if (dtaux.Rows[i][0].ToString() == dt.Rows[j][1].ToString())
                    {
                        dt.Rows[j][4] = dtaux.Rows[i][1].ToString();
                        SegundaSumaIngresos += decimal.Parse(dtaux.Rows[i][1].ToString());
                        break;
                    }
                }
            }

            dtaux.Clear();
            dtaux.Dispose();


            return dt;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarEgresos(string SegundaFechaD, string SegundaFechaA)
        {
            DataTable dt = new DSDoblones20Contabilidad.VistaBalanceGeneralComparativoReporteDataTable();
            PlanCuentasCLN cuentas = new PlanCuentasCLN();
            DataTable dtaux = new DataTable();
            DateTime SegundaFechaDel, SegundaFechaAl;

            SegundaFechaDel = DateTime.Parse(SegundaFechaD);
            SegundaFechaAl = DateTime.Parse(SegundaFechaA);

            dtaux = cuentas.ListarPlanCuentasEgreso();
            SumaEgresos = 0;
            SegundaSumaEgresos = 0;

            foreach (DataRow r in dtaux.Rows)
            {
                dt.Rows.Add(r.ItemArray);
            }

            dtaux.Dispose();
            dtaux = new DataTable();
            int n1 = dt.Rows.Count;
            ListarEstadoResultadosEgresosTableAdapter TAactivo = new ListarEstadoResultadosEgresosTableAdapter();

            dtaux = TAactivo.GetData(FechaDel, FechaAl);
            int n2 = dtaux.Rows.Count;

            for (int i = 0; i < n2; i++)
            {
                for (int j = 0; j < n1; j++)
                {
                    if (dtaux.Rows[i][0].ToString() == dt.Rows[j][1].ToString())
                    {
                        dt.Rows[j][4] = dtaux.Rows[i][1].ToString();
                        SumaEgresos += decimal.Parse(dtaux.Rows[i][1].ToString());
                        break;
                    }
                }
            }

            dtaux.Clear();
            dtaux.Dispose();

            //Se calcula la segunda

            dtaux = TAactivo.GetData(SegundaFechaDel, SegundaFechaAl);
            n2 = dtaux.Rows.Count;

            for (int i = 0; i < n2; i++)
            {
                for (int j = 0; j < n1; j++)
                {
                    if (dtaux.Rows[i][0].ToString() == dt.Rows[j][1].ToString())
                    {
                        dt.Rows[j][4] = dtaux.Rows[i][1].ToString();
                        SegundaSumaEgresos += decimal.Parse(dtaux.Rows[i][1].ToString());
                        break;
                    }
                }
            }

            dtaux.Clear();
            dtaux.Dispose();


            return dt;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarEstadoResultadosComparativoDiferencias()
        {
            DataTable dt = new DSDoblones20Contabilidad.VistaEstadoResultadosDiferencialReporteDataTable();
            dt.Rows.Add(dt.NewRow());

            decimal Utilidad1, Utilidad2;

            Utilidad1 = SumaIngresos - SumaEgresos;
            Utilidad2 = SegundaSumaIngresos - SegundaSumaEgresos;

            dt.Rows[0][0] = Utilidad1.ToString("F2");
            dt.Rows[0][1] = Utilidad1.ToString("F2");

            return dt;
        }


    }
}
