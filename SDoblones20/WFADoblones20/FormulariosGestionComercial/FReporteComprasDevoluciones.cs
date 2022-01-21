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
    public partial class FReporteComprasDevoluciones : Form
    {
        DataTable DTCompras = null;
        DataTable DTDevolucionCompra = null;
        DataTable DTProductosDetalle = null;
        DataTable DTProductosEspecificos = null;
        DataSet DSComprasDevoluciones = null;
        Button btnCerrarReporte;

        public FReporteComprasDevoluciones(DataTable compra, DataTable devolucion, DataTable productos, DataTable especificos)
        {
            InitializeComponent();
            btnCerrarReporte = new Button();
            btnCerrarReporte.Click += new EventHandler(btnCerrarReporte_Click);

            this.DTCompras = compra;
            this.DTDevolucionCompra = devolucion;
            this.DTProductosDetalle = productos;
            this.DTProductosEspecificos = especificos;

            this.DTCompras.TableName = "CompraProductoReporte";
            this.DTDevolucionCompra.TableName = "ComprasProductosDevolucionesReporte";
            this.DTProductosDetalle.TableName = "ComprasProductosDevolucionesDetalleReporte";
            this.DTProductosEspecificos.TableName = "ComprasProductosDevolucionesEspecificosReporte";

            DSComprasDevoluciones = new DataSet();
            DSComprasDevoluciones.Tables.Add(DTCompras);
            DSComprasDevoluciones.Tables.Add(DTDevolucionCompra);
            DSComprasDevoluciones.Tables.Add(DTProductosDetalle);
            DSComprasDevoluciones.Tables.Add(DTProductosEspecificos);

        }

        void btnCerrarReporte_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FReporteComprasDevoluciones_Load(object sender, EventArgs e)
        {
            ReportesGestionComercial.CRComprasDevoluciones reporteDevoluciones = new WFADoblones20.ReportesGestionComercial.CRComprasDevoluciones();
            reporteDevoluciones.SetDataSource(DSComprasDevoluciones);

            CRVComprasDevoluciones.ReportSource = reporteDevoluciones;

            this.CancelButton = btnCerrarReporte;
        }
    }
}
