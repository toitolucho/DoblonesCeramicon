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
    public class LibroMayoresCLN
    {
        public LibroMayoresCLN()
        { }

        [System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarLibroMayores(string NumeroCuenta)
        {
            ListarLibroMayoresTableAdapter LibroMayoresTA = new ListarLibroMayoresTableAdapter();

            return LibroMayoresTA.GetData(NumeroCuenta);
        }

    }
}
