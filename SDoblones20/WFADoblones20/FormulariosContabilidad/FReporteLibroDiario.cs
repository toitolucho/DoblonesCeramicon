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
    public partial class FReporteLibroDiario : Form
    {
        public FReporteLibroDiario(string Fecha, char Estado)
        {
            InitializeComponent();
            Cargar(Fecha, Estado);
        }

        public FReporteLibroDiario(string NumeroAsiento)
        {
            InitializeComponent();
            Cargar(NumeroAsiento);
        }

        public FReporteLibroDiario(string FechaDel, string FechaAl)
        {
            InitializeComponent();
            Cargar(FechaDel, FechaAl);
        }

        private void Cargar(string Fecha, char Estado)
        {
            LibroDiarioCLN librodiario = new LibroDiarioCLN();
            DataTable DTLibroDiario = new DataTable();
            DTLibroDiario = librodiario.LibroDiarioFechasEstado(Fecha,Estado);

            CRLibroDiario crLibroDiario = new CRLibroDiario();          

            crLibroDiario.SetDataSource(DTLibroDiario);

            crvLibroDiario.ReportSource = crLibroDiario;
        }

        private void Cargar(string NumeAsiento)
        {
            LibroDiarioCLN librodiario = new LibroDiarioCLN();
            DataTable DTLibroDiario = new DataTable();
            DTLibroDiario = librodiario.LibroDiarioNumeroAsiento(NumeAsiento);

            CRLibroDiario crLibroDiario = new CRLibroDiario();
            crLibroDiario.SetDataSource(DTLibroDiario);

            crvLibroDiario.ReportSource = crLibroDiario;
        }

        private void Cargar(string FechaDel, string FechaAl)
        {
            LibroDiarioCLN librodiario = new LibroDiarioCLN();
            DataTable DTLibroDiario = new DataTable();
            DTLibroDiario = librodiario.LibroDiarioDelAl(FechaDel, FechaAl);

            CRLibroDiario crLibroDiario = new CRLibroDiario();
            crLibroDiario.SetDataSource(DTLibroDiario);

            crvLibroDiario.ReportSource = crLibroDiario;
        }

        private void FReporteLibroDiario_Load(object sender, EventArgs e)
        {

        }
    }
}
