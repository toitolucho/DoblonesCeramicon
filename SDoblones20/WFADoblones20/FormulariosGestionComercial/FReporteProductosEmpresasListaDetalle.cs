using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.Contabilidad;
using CLCLN.GestionComercial;
using WFADoblones20;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FReporteProductosEmpresasListaDetalle : Form
    {
        public FReporteProductosEmpresasListaDetalle(int NumeroLista)
        {
            InitializeComponent();
            CargarReporte(NumeroLista);
        }

        private void FReporteProductosEmpresasListaDetalle_Load(object sender, EventArgs e)
        {

        }

        private void CargarReporte(int NumLista)
        {
            ProductosEmpresasListaDetalleCLN listadetalle = new ProductosEmpresasListaDetalleCLN();
            DataTable dt = new DataTable();
            CRProductosEmpresasListaDetalle crListaDetalle = new CRProductosEmpresasListaDetalle();

            dt = listadetalle.ListarProductosEmpresasListaDetalleNumeroListaReporte(NumLista);

            crListaDetalle.SetDataSource(dt);

            crvProductosEmpresasListaDetalle.ReportSource = crListaDetalle;
        }
    }
}
