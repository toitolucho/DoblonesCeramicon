using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FReportesVentasAgrupaciones : Form
    {
        DataTable DTVentasGrupos = null;
        string TipoReporte = null;
        Button btnCerrarReporte;
        public FReportesVentasAgrupaciones(DataTable DTVentasGrupos, string TipoReporte)
        {
            InitializeComponent();
            this.DTVentasGrupos = DTVentasGrupos;
            this.TipoReporte = TipoReporte;

            btnCerrarReporte = new Button();
            btnCerrarReporte.Click += new EventHandler(btnCerrarReporte_Click);
            this.CancelButton = btnCerrarReporte;
        }

        void btnCerrarReporte_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FReportesVentasAgrupaciones_Load(object sender, EventArgs e)
        {
            switch(TipoReporte)
            {
                case "Productos":
                    WFADoblones20.ReportesGestionComercial.CRVentasProductosPorProductos CRVentasPorProductos = new WFADoblones20.ReportesGestionComercial.CRVentasProductosPorProductos();
                    CRVentasPorProductos.SetDataSource(DTVentasGrupos);
                    CRVVentasGrupos.ReportSource = CRVentasPorProductos;
                    break;
                case "Usuarios":
                    WFADoblones20.ReportesGestionComercial.CRVentasProductosPorUsuarios CRVentasPorUsuarios = new WFADoblones20.ReportesGestionComercial.CRVentasProductosPorUsuarios();
                    CRVentasPorUsuarios.SetDataSource(DTVentasGrupos);
                    CRVVentasGrupos.ReportSource = CRVentasPorUsuarios;
                    break;
                case "Clientes":
                    WFADoblones20.ReportesGestionComercial.CRVentasProductosPorClientes CRVentasPorClientes = new WFADoblones20.ReportesGestionComercial.CRVentasProductosPorClientes();
                    CRVentasPorClientes.SetDataSource(DTVentasGrupos);
                    CRVVentasGrupos.ReportSource = CRVentasPorClientes;
                    break;
                case "Fechas":
                    WFADoblones20.ReportesGestionComercial.CRVentasProductosPorFechas CRVentasPorFechas = new WFADoblones20.ReportesGestionComercial.CRVentasProductosPorFechas();
                    CRVentasPorFechas.SetDataSource(DTVentasGrupos);
                    CRVVentasGrupos.ReportSource = CRVentasPorFechas;
                    break;
                case "Creditos":
                    WFADoblones20.ReportesGestionComercial.CRVentasProductosPorCreditos CRVentasPorCreditos = new WFADoblones20.ReportesGestionComercial.CRVentasProductosPorCreditos();
                    CRVentasPorCreditos.SetDataSource(DTVentasGrupos);
                    CRVVentasGrupos.ReportSource = CRVentasPorCreditos;
                    break;
                case "MasVendidos":
                    WFADoblones20.ReportesGestionComercial.CRVentasProductosMasVendidos CRVentasMasVendidos = new WFADoblones20.ReportesGestionComercial.CRVentasProductosMasVendidos();
                    CRVentasMasVendidos.SetDataSource(DTVentasGrupos);
                    CRVVentasGrupos.ReportSource = CRVentasMasVendidos;
                    break;
                case "MenosVendidos":
                    WFADoblones20.ReportesGestionComercial.CRVentasProductosMenosVendidos CRVentasMenosVendidos = new WFADoblones20.ReportesGestionComercial.CRVentasProductosMenosVendidos();
                    CRVentasMenosVendidos.SetDataSource(DTVentasGrupos);
                    CRVVentasGrupos.ReportSource = CRVentasMenosVendidos;
                    break;
            }
        }
    }
}
