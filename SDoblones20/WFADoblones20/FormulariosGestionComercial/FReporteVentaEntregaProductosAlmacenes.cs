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
    public partial class FReporteVentaEntregaProductosAlmacenes : Form
    {
        DataTable DTVentaProductoReporte1 = null;
        DataTable DTVentaProductoDetalleReporte1 = null;        
        DataTable DTDatosAgencia1 = null;
        DataSet DSReporteVentaProductos = null;
        Button btnCerrarReporte;

        public FReporteVentaEntregaProductosAlmacenes(DataTable DTDatosAgencia, DataTable DTVentaProductoReporte, DataTable DTVentaProductoDetalleReporte)
        {
            InitializeComponent();
            DSReporteVentaProductos = new DataSet();

            this.DTDatosAgencia1 = DTDatosAgencia;
            this.DTVentaProductoReporte1 = DTVentaProductoReporte;
            this.DTVentaProductoDetalleReporte1 = DTVentaProductoDetalleReporte;

            //this.DTDatosAgencia1.TableName = "ListarDatosAgenciasParaTransaccionesReportes";
            //this.DTVentaProductoDetalleReporte1.TableName = "ListarVentaProductoDetalleReporteParaRecogerDeAlmacenes";
            //this.DTVentaProductoReporte1.TableName = "VentaProductoReporte";
            //DTVentaProductoDetalleReporte.PrimaryKey = null;
            //DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            //PrimaryKeyColumns[0] = DTVentaProductoDetalleReporte.Columns["CodigoProducto"];
            //DTVentaProductoDetalleReporte.PrimaryKey = PrimaryKeyColumns;
            DSReporteVentaProductos.Tables.AddRange(new DataTable[] { DTDatosAgencia1, DTVentaProductoDetalleReporte1, DTVentaProductoReporte1});

            btnCerrarReporte = new Button();
            btnCerrarReporte.Click += new EventHandler(btnCerrarReporte_Click);
            this.CancelButton = btnCerrarReporte;
        }

        void btnCerrarReporte_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ListarVentaProductoDetalleReporteParaRecogerDeAlmacenes()
        {
            this.DTDatosAgencia1.TableName = "ListarDatosAgenciasParaTransaccionesReportes";
            this.DTVentaProductoDetalleReporte1.TableName = "ListarVentaProductoDetalleReporteParaRecogerDeAlmacenes";
            this.DTVentaProductoReporte1.TableName = "VentaProductoReporte";
            ReportesGestionComercial.CRVentasProductosEntregaParaAlmacenes reporteParaAlmacenes = new WFADoblones20.ReportesGestionComercial.CRVentasProductosEntregaParaAlmacenes();
            reporteParaAlmacenes.SetDataSource(DSReporteVentaProductos);
            CRVReporteVentaEntregaProductosAlmacenes.ReportSource = reporteParaAlmacenes;
        }

        public void ListarVentaProductoCompuestosDetalleReporte(DataTable DTVentasProductosDetalleSimples)
        {
            DSReporteVentaProductos.Tables.Add(DTVentasProductosDetalleSimples);
            
            ReportesGestionComercial.CRVentasProductosCompuestosEntregaParaAlmacenes reporteParaAlmacenes = new WFADoblones20.ReportesGestionComercial.CRVentasProductosCompuestosEntregaParaAlmacenes();
            reporteParaAlmacenes.SetDataSource(DSReporteVentaProductos);
            CRVReporteVentaEntregaProductosAlmacenes.ReportSource = reporteParaAlmacenes;
        }

        private void FReporteVentaEntregaProductosAlmacenes_Load(object sender, EventArgs e)
        {
            //ReportesGestionComercial.CRVentasProductosEntregaParaAlmacenes reporteParaAlmacenes = new WFADoblones20.ReportesGestionComercial.CRVentasProductosEntregaParaAlmacenes();
            //reporteParaAlmacenes.SetDataSource(DSReporteVentaProductos);
            //CRVReporteVentaEntregaProductosAlmacenes.ReportSource = reporteParaAlmacenes;
        }
    }
}
