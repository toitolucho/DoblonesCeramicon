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
    public class BalanceGeneralCLN
    {
        private DateTime FechaInicio, FechaFin;

        public BalanceGeneralCLN()
        { }

        public BalanceGeneralCLN(string FechaInicial, string FechaFinal)
        {
            this.FechaInicio = DateTime.Parse(FechaInicial);
            this.FechaFin = DateTime.Parse(FechaFinal);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarActivo()
        {
            DataTable dt = new DSDoblones20Contabilidad.VistaBalanceGeneralReporteDataTable();
            PlanCuentasCLN cuentas = new PlanCuentasCLN();
            DataTable dtaux = new DataTable();

            dtaux = cuentas.ListarPlanCuentasActivo();

            foreach (DataRow r in dtaux.Rows)
            {
                dt.Rows.Add(r.ItemArray);
            }

            dtaux.Dispose();
            dtaux = new DataTable();

            ListarBalanceGeneralActivoTableAdapter TAactivo = new ListarBalanceGeneralActivoTableAdapter();
            dtaux = TAactivo.GetData(FechaInicio, FechaFin);

            int n1 = dt.Rows.Count;
            int n2 = dtaux.Rows.Count;

            for (int i = 0; i < n2; i++)
            {
                for (int j = 0; j < n1; j++)
                {
                    if (dtaux.Rows[i][0].ToString() == dt.Rows[j][1].ToString())
                    {
                        dt.Rows[j][5] = dtaux.Rows[i][1].ToString();
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
        public DataTable ListarPasivoCapital()
        {
            DataTable dt = new DSDoblones20Contabilidad.VistaBalanceGeneralReporteDataTable();
            PlanCuentasCLN cuentas = new PlanCuentasCLN();
            DataTable dtaux = new DataTable();

            dtaux = cuentas.ListarPlanCuentasPasivoCapital();

            foreach (DataRow r in dtaux.Rows)
            {
                dt.Rows.Add(r.ItemArray);
            }

            dtaux.Dispose();
            dtaux = new DataTable();

            ListarBalanceGeneralPasivoCapitalTableAdapter TAactivo = new ListarBalanceGeneralPasivoCapitalTableAdapter();
            dtaux = TAactivo.GetData(FechaInicio, FechaFin);

            int n1 = dt.Rows.Count;
            int n2 = dtaux.Rows.Count;

            for (int i = 0; i < n2; i++)
            {
                for (int j = 0; j < n1; j++)
                {
                    if (dtaux.Rows[i][0].ToString() == dt.Rows[j][1].ToString())
                    {
                        dt.Rows[j][4] = dtaux.Rows[i][1].ToString();
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


        //Balance general comparativo


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarActivo(string FechaInicioComparativa, string FechaFinComparativa)
        {
            DataTable dt = new DSDoblones20Contabilidad.VistaBalanceGeneralComparativoReporteDataTable();
            PlanCuentasCLN cuentas = new PlanCuentasCLN();
            DataTable dtaux = new DataTable();
            DateTime FechaInicialComparativa, FechaFinalComparativa;

            FechaInicialComparativa = DateTime.Parse(FechaInicioComparativa);
            FechaFinalComparativa = DateTime.Parse(FechaFinComparativa);

            dtaux = cuentas.ListarPlanCuentasActivo();

            foreach (DataRow r in dtaux.Rows)
            {
                dt.Rows.Add(r.ItemArray);
            }

            dtaux.Dispose();
            dtaux = new DataTable();

            ListarBalanceGeneralActivoTableAdapter TAactivo = new ListarBalanceGeneralActivoTableAdapter();

            int n1 = dt.Rows.Count;

            //Se calcula la primera gestion
            dtaux = TAactivo.GetData(FechaInicio, FechaFin);
            int n2 = dtaux.Rows.Count;

            for (int i = 0; i < n2; i++)
            {
                for (int j = 0; j < n1; j++)
                {
                    if (dtaux.Rows[i][0].ToString() == dt.Rows[j][1].ToString())
                    {
                        dt.Rows[j][4] = dtaux.Rows[i][1].ToString();
                        break;
                    }
                }
            }

            //Se calcula la segunda gestion
            dtaux = TAactivo.GetData(FechaInicialComparativa, FechaFinalComparativa);
            n2 = dtaux.Rows.Count;

            for (int i = 0; i < n2; i++)
            {
                for (int j = 0; j < n1; j++)
                {
                    if (dtaux.Rows[i][0].ToString() == dt.Rows[j][1].ToString())
                    {
                        dt.Rows[j][5] = dtaux.Rows[i][1].ToString();
                        break;
                    }
                }
            }


            dtaux.Clear();
            dtaux.Dispose();

            return dt;
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarPasivoCapital(string FechaInicioComparativa, string FechaFinComparativa)
        {
            DataTable dt = new DSDoblones20Contabilidad.VistaBalanceGeneralComparativoReporteDataTable();
            PlanCuentasCLN cuentas = new PlanCuentasCLN();
            DataTable dtaux = new DataTable();
            DateTime FechaInicialComparativa, FechaFinalComparativa;

            FechaInicialComparativa = DateTime.Parse(FechaInicioComparativa);
            FechaFinalComparativa = DateTime.Parse(FechaFinComparativa);

            dtaux = cuentas.ListarPlanCuentasPasivoCapital();

            foreach (DataRow r in dtaux.Rows)
            {
                dt.Rows.Add(r.ItemArray);
            }

            dtaux.Dispose();
            dtaux = new DataTable();

            ListarBalanceGeneralPasivoCapitalTableAdapter TAactivo = new ListarBalanceGeneralPasivoCapitalTableAdapter();

            int n1 = dt.Rows.Count;

            //Se calcula la primera gestion
            dtaux = TAactivo.GetData(FechaInicio, FechaFin);
            int n2 = dtaux.Rows.Count;

            for (int i = 0; i < n2; i++)
            {
                for (int j = 0; j < n1; j++)
                {
                    if (dtaux.Rows[i][0].ToString() == dt.Rows[j][1].ToString())
                    {
                        dt.Rows[j][4] = dtaux.Rows[i][1].ToString();
                        break;
                    }
                }
            }

            //Se calcula la segunda gestion
            dtaux = TAactivo.GetData(FechaInicialComparativa, FechaFinalComparativa);
            n2 = dtaux.Rows.Count;

            for (int i = 0; i < n2; i++)
            {
                for (int j = 0; j < n1; j++)
                {
                    if (dtaux.Rows[i][0].ToString() == dt.Rows[j][1].ToString())
                    {
                        dt.Rows[j][5] = dtaux.Rows[i][1].ToString();
                        break;
                    }
                }
            }


            dtaux.Clear();
            dtaux.Dispose();

            return dt;
        }

    }
}
