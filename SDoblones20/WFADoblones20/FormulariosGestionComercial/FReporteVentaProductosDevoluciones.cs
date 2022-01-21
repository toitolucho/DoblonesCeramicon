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
    public partial class FReporteVentaProductosDevoluciones : Form
    {
        DataTable DTDatosVentas = null;
        DataTable DTDatosDevoluciones = null;
        DataTable DTDatosDevolucionesDetalle = null;
        DataTable DTDatosDevolucionesEspecificos = null;
        DataSet DSVentasProductosDevoluciones = null;
        Button btnCerrarReporte;
        public FReporteVentaProductosDevoluciones(DataTable Ventas, DataTable Devoluciones, DataTable Productos, DataTable ProductosEspecificos)
        {
            InitializeComponent();
            this.DTDatosVentas = Ventas;
            this.DTDatosDevoluciones = Devoluciones;
            this.DTDatosDevolucionesDetalle = Productos;
            this.DTDatosDevolucionesEspecificos = ProductosEspecificos;

            this.DTDatosVentas.TableName = "VentaProductoReporte";
            this.DTDatosDevoluciones.TableName = "VentasProductosDevolucionesReporte";
            this.DTDatosDevolucionesDetalle.TableName = "VentasProductosDevolucionesDetalleReporte";
            this.DTDatosDevolucionesEspecificos.TableName = "VentasProductosDevolucionesEspecificosReporte";

            DSVentasProductosDevoluciones = new DataSet();
            DSVentasProductosDevoluciones.Tables.Add(DTDatosVentas);
            DSVentasProductosDevoluciones.Tables.Add(DTDatosDevoluciones);
            DSVentasProductosDevoluciones.Tables.Add(DTDatosDevolucionesDetalle);
            DSVentasProductosDevoluciones.Tables.Add(DTDatosDevolucionesEspecificos);

            btnCerrarReporte = new Button();
            btnCerrarReporte.Click += new EventHandler(btnCerrarReporte_Click);
            this.CancelButton = btnCerrarReporte;

        }

        void btnCerrarReporte_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FReporteVentaProductosDevoluciones_Load(object sender, EventArgs e)
        {
            ReportesGestionComercial.CRVentasDevoluciones _CRVentasDevoluciones = new WFADoblones20.ReportesGestionComercial.CRVentasDevoluciones();
            _CRVentasDevoluciones.SetDataSource(DSVentasProductosDevoluciones);

            CRVProductosDevoluciones.ReportSource = _CRVentasDevoluciones;
        }
    }
}
