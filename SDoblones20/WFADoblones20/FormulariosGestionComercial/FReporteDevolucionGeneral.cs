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
    public partial class FReporteDevolucionGeneral : Form
    {
        DataTable Ventas = null;
        DataTable VentasDevoluciones = null;
        DataTable VentasDevolucionesDetalle = null;
        DataTable VentasDevolucionesReemplazoDetalle = null;
        DataSet DSGeneral = null;
        Button btnCerrarReporte;
        public FReporteDevolucionGeneral(DataTable Ventas, DataTable VentasDevoluciones, DataTable VentasDevolucionesDetalle, DataTable VentasDevolucionesReemplazoDetalle)
        {
            this.Ventas = Ventas;
            this.VentasDevoluciones = VentasDevoluciones;
            this.VentasDevolucionesDetalle = VentasDevolucionesDetalle;
            this.VentasDevolucionesReemplazoDetalle = VentasDevolucionesReemplazoDetalle;

            this.Ventas.TableName = "VentaProductoReporte";
            this.VentasDevoluciones.TableName = "VentasProductosDevolucionesReporte";
            this.VentasDevolucionesDetalle.TableName = "VentasProductosDevolucionesDetalleReporte";
            this.VentasDevolucionesReemplazoDetalle.TableName = "VentasProductosDevolucionesReemplazoReporte";

            DSGeneral = new DataSet();
            DSGeneral.Tables.AddRange(new DataTable[] { this.Ventas, this.VentasDevoluciones, this.VentasDevolucionesDetalle, this.VentasDevolucionesReemplazoDetalle });

            InitializeComponent();

            btnCerrarReporte = new Button();
            btnCerrarReporte.Click += new EventHandler(btnCerrarReporte_Click);
        }

        void btnCerrarReporte_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FReporteDevolucionGeneral_Load(object sender, EventArgs e)
        {
            this.CancelButton = btnCerrarReporte;
            ReportesGestionComercial.CRVentasDevolucionesGeneral reporte = new WFADoblones20.ReportesGestionComercial.CRVentasDevolucionesGeneral();
            reporte.SetDataSource(DSGeneral);

            CRVVentaProductosDevolucion.ReportSource = reporte;
        }
    }
}
