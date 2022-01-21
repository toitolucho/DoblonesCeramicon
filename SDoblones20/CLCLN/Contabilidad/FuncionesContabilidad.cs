using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD;
using CLCAD.DSDoblones20ContabilidadTableAdapters;
using CLCAD.DSDoblones20SistemaTableAdapters;
using System.Data;
using System.Data.SqlClient;

namespace CLCLN.Contabilidad
{
    public class FuncionesContabilidad
    {
        public FuncionesContabilidad()
        { }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public string ObtenerFechaHora()
        {
            QTAFuncionesSistema FechaHora = new QTAFuncionesSistema();
            DateTime? fh =  null;
            //FechaHora.ObtenerFechaHoraServidor(ref fh).ToString();
            FechaHora.ObtenerFechaHoraServidor(ref fh);
            return fh != null ? fh.ToString() : DateTime.Now.ToString();
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public string FechaHora()
        {
            QTAFuncionesContabilidad consulta = new QTAFuncionesContabilidad();
            return consulta.FechaHora();
        }


        public decimal SaldoCuenta(string NumeroCuento)
        {
            //decimal? saldo = null;
            //QTAFuncionesContabilidad consulta = new QTAFuncionesContabilidad();
            //consulta.SaldoEnCuenta(NumeroCuento, ref saldo);
            //return saldo.Value;

            QTAFuncionesContabilidad consulta = new QTAFuncionesContabilidad();
            return consulta.FuncionSaldoEnCuenta(NumeroCuento).Value;
        }

        public void AbrirCajaMovimiento()
        {
            QTAFuncionesContabilidad consulta = new QTAFuncionesContabilidad();
            consulta.AbrirCajaMovimiento();
        }

        public string ObtenerUltimaFechaMovimientoCierre()
        {
            QTAFuncionesContabilidad consulta = new QTAFuncionesContabilidad();
            return consulta.ObtenerUltimaFechaMovimientoCierre();
        }
    }
}
