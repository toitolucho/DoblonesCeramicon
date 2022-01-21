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
    public partial class FReporteLibroMayores : Form
    {
        private string NumeroCuenta;

        public FReporteLibroMayores(string NumCuenta)
        {
            InitializeComponent();
            NumeroCuenta = NumCuenta;
        }

        private void FReporteLibroMayores_Load(object sender, EventArgs e)
        {
            LibroMayoresCLN LibroMayores = new LibroMayoresCLN();
            DataTable DTLibroMayores = new DataTable();
            DTLibroMayores = LibroMayores.ListarLibroMayores(NumeroCuenta);
            CRLibroMayores crlm = new CRLibroMayores();
            crlm.SetDataSource(DTLibroMayores);
            crvLibroMayores.ReportSource = crlm;
        }
    }
}
