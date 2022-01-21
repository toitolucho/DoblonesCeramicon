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
    public class LibroDiarioCLN
    {
        public LibroDiarioCLN()
        { }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable LibroDiarioFechasEstado(string Fecha, char Estado)
        {
            ListarLibroDiarioFechaEstadoTableAdapter LibroDiarioTA = new ListarLibroDiarioFechaEstadoTableAdapter();
            DateTime? FechaLibro = DateTime.Parse(Fecha);

            string EstadoAsiento = string.Empty;

            if (Estado == 'P')
                EstadoAsiento = "Pendiente";
            else
                EstadoAsiento = "Confirmado";

            return LibroDiarioTA.GetData(FechaLibro, EstadoAsiento);
        }


        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable LibroDiarioNumeroAsiento(string NumeroAsiento)
        {
            ListarLibroDiarioNumeroAsientoTableAdapter LibroDiarioTA = new ListarLibroDiarioNumeroAsientoTableAdapter();

            int? NumAsiento = int.Parse(NumeroAsiento);

            return LibroDiarioTA.GetData(NumAsiento);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable LibroDiarioDelAl(string FechaDel, string FechaAl)
        {
            ListarLibroDiarioFechaDelAlTableAdapter LibroDiarioTA = new ListarLibroDiarioFechaDelAlTableAdapter();
            
            DateTime? FechaLibroDel = DateTime.Parse(FechaDel);
            DateTime? FechaLibroAl = DateTime.Parse(FechaAl);

            return LibroDiarioTA.GetData(FechaLibroDel, FechaLibroAl);
        }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable LibroDiarioFecha(string Fecha)
        {
            ListarLibroDiarioFechaTableAdapter miadapter = new ListarLibroDiarioFechaTableAdapter();
            DateTime? mifecha = DateTime.Parse(Fecha);

            return miadapter.GetData(mifecha);
        }
        
    }
}
