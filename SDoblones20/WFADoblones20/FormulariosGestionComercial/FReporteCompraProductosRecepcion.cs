using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WFADoblones20.ReportesGestionComercial;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FReporteCompraProductosRecepcion : Form
    {
        DataTable DTCompraProductos;
        DataTable DTCompraProductosRecepcion;
        DataTable DTCompraProductosGastos;
        DataSet DSCompraProductosRecepcion;
        bool reporteCompleto;
        Button btnCerrarReporte;

        public FReporteCompraProductosRecepcion(DataTable DTCompraProductos, DataTable DTCompraProductosRecepcion, DataTable DTCompraProductosGastos, bool reporteCompleto)
        {
            InitializeComponent();

            this.DTCompraProductos = DTCompraProductos;
            this.DTCompraProductosGastos = DTCompraProductosGastos;
            this.DTCompraProductosRecepcion = DTCompraProductosRecepcion;
            this.reporteCompleto = reporteCompleto;

            DSCompraProductosRecepcion = new DataSet();
            DSCompraProductosRecepcion.Tables.AddRange(new DataTable[] { DTCompraProductos, DTCompraProductosRecepcion, DTCompraProductosGastos });


            btnCerrarReporte = new Button();
            btnCerrarReporte.Click += new EventHandler(btnCerrarReporte_Click);
        }

        void btnCerrarReporte_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FReporteCompraProductosRecepcion_Load(object sender, EventArgs e)
        {
            if (reporteCompleto)
            {
                CRComprasProductosRecepcionGeneral _CRComprasProductosRecepcionGeneral = new CRComprasProductosRecepcionGeneral();
                _CRComprasProductosRecepcionGeneral.SetDataSource(DSCompraProductosRecepcion);
                CRVRecepcionProductos.ReportSource = _CRComprasProductosRecepcionGeneral;
            }
            else
            {
                CRComprasProductosRecepcionPartes _CRComprasProductosRecepcionPartes = new CRComprasProductosRecepcionPartes();
                _CRComprasProductosRecepcionPartes.SetDataSource(DSCompraProductosRecepcion);
                CRVRecepcionProductos.ReportSource = _CRComprasProductosRecepcionPartes;
            }

            this.CancelButton = btnCerrarReporte;
        }
    }
}
