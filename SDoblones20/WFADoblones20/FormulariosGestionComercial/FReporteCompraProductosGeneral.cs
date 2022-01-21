using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WFADoblones20.ReportesGestionComercial;
using System.Drawing.Printing;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FReporteCompraProductosGeneral : Form
    {
        DataTable DTCompraProductoReporte, DTCompraProductoDetalleReporte, DTCompraProductoEspecificoAgregadoReporte;
        DataSet DSCompraProductos = null;
        CRComprasProductosGeneral reporteComprasProductos = null;
        CRComprasProductosFactura reporteRecibo = null;
        CRCodiigoProductosEspecificos reporteCodigosEspecificos = null;

        Button btnCerrarReporte;
        public FReporteCompraProductosGeneral(DataTable DTCompraProductoReporte, DataTable DTCompraProductoDetalleReporte, DataTable DTCompraProductoEspecificoAgregadoReporte)
        {
            InitializeComponent();
            btnCerrarReporte = new Button();

            btnCerrarReporte.Click += new EventHandler(btnCerrarReporte_Click);
            this.CancelButton = btnCerrarReporte;

            this.DTCompraProductoReporte = DTCompraProductoReporte;
            this.DTCompraProductoReporte.TableName = "CompraProductoReporte";

            this.DTCompraProductoDetalleReporte = DTCompraProductoDetalleReporte;
            this.DTCompraProductoDetalleReporte.TableName = "CompraProductoDetalleReporte";

            this.DTCompraProductoEspecificoAgregadoReporte = DTCompraProductoEspecificoAgregadoReporte;
            this.DTCompraProductoEspecificoAgregadoReporte.TableName = "CompraProductoEspecificoAgregadoReporte";

            DSCompraProductos = new DataSet();
            DSCompraProductos.Tables.AddRange(new DataTable[] { DTCompraProductoReporte, DTCompraProductoDetalleReporte, DTCompraProductoEspecificoAgregadoReporte });
            reporteComprasProductos = new CRComprasProductosGeneral();
            this.Load += new EventHandler(FReporteCompraProductosGeneral_Load);

        }

        public FReporteCompraProductosGeneral()
        {
            InitializeComponent();
            btnCerrarReporte = new Button();
            btnCerrarReporte.Click += new EventHandler(btnCerrarReporte_Click);
            this.CancelButton = btnCerrarReporte;
        }

        void btnCerrarReporte_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ListarReporteComprasProductosCopiaSistemaCEATEC(DataTable DTComprasProductos, DataTable DTComprasProductosDetalle)
        {
            this.DTCompraProductoReporte = DTComprasProductos;
            this.DTCompraProductoDetalleReporte = DTComprasProductosDetalle;
            DSCompraProductos = new DataSet();
            DSCompraProductos.Tables.AddRange(new DataTable[] { DTCompraProductoReporte, DTCompraProductoDetalleReporte });
            CRComprasProductosCopiaSistemaCEATEC reporte = new CRComprasProductosCopiaSistemaCEATEC();
            reporte.SetDataSource(DSCompraProductos);
            CRVCompraProductos.ReportSource = reporte;
        }

        public void ListarReporteComprasProductosImportacion(DataTable DTComprasProductos, DataTable DTComprasProductosDetalle)
        {
            this.DTCompraProductoReporte = DTComprasProductos;
            this.DTCompraProductoDetalleReporte = DTComprasProductosDetalle;
            DSCompraProductos = new DataSet();
            DSCompraProductos.Tables.AddRange(new DataTable[] { DTCompraProductoReporte, DTCompraProductoDetalleReporte });
            CRComprasProductosImportacion reporte = new CRComprasProductosImportacion();
            reporte.SetDataSource(DSCompraProductos);
            CRVCompraProductos.ReportSource = reporte;
        }


        public FReporteCompraProductosGeneral(DataTable DTCompraProductoReporte, DataTable DTCompraProductoDetalleReporte)
        {
            InitializeComponent();
            this.DTCompraProductoReporte = DTCompraProductoReporte;
            this.DTCompraProductoReporte.TableName = "CompraProductoReporte";

            this.DTCompraProductoDetalleReporte = DTCompraProductoDetalleReporte;
            this.DTCompraProductoDetalleReporte.TableName = "CompraProductoDetalleReporteIncluidoAgregados";            

            DSCompraProductos = new DataSet();
            DSCompraProductos.Tables.AddRange(new DataTable[] { DTCompraProductoReporte, DTCompraProductoDetalleReporte});
            reporteRecibo = new CRComprasProductosFactura();
            this.Load += new EventHandler(FReporteCompraProductosRecibo_Load);


            //PrintDocument printDoc = new PrintDocument();

            //PaperSize pkSize = new PaperSize();

            //int rawKind = 0;

            ////rawKind = (int)printDoc.PrinterSettings.PaperSizes.GetType().GetField("CEATEC", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(printDoc.PrinterSettings.PaperSizes);
            ////MessageBox.Show(rawKind.ToString());

            //for (int a = 0; a < printDoc.PrinterSettings.PaperSizes.Count; a++)
            //{

            //    if (printDoc.PrinterSettings.PaperSizes[a].PaperName == "CEATEC")
            //    {

            //        rawKind = (int)printDoc.PrinterSettings.PaperSizes[a].RawKind;

            //        break;

            //    }

            //}
            ////MessageBox.Show(rawKind.ToString());




            //PrintDialog pDialog =new PrintDialog();
            //PrinterSettings pSettings =new PrinterSettings();
            //pDialog.ShowDialog();
            //pSettings = pDialog.PrinterSettings; // apply all the settings to pSettings as per user specified like printer,papersize,etc
            //PageSettings pSize= PageSettigns(pSettings); // (not sure weather PageSetting / PageSize u just check it) with the hellp of above code you will get printersettings and papersizes Now call the rpt Object.
            //PageSettings PS
             

            ////rpt.PrintOptions.CopyFrom(pSettings,pSize);

            //reporteRecibo.PrintOptions.CopyFrom(printDoc.PrinterSettings, printDoc.PrinterSettings.PaperSizes[a]);
            //reporteRecibo.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
            //reporteRecibo.PrintToPrinter(1, true, 1, 99);

        }


        public FReporteCompraProductosGeneral(DataTable DTProductosEspecificos, DataTable DTDatosAgencia, bool isProductosEspecificos)
        {
            InitializeComponent();
            this.DTCompraProductoReporte = DTProductosEspecificos;
            this.DTCompraProductoReporte.TableName = "AgenciasParaTransaccionesReportes";

            this.DTCompraProductoDetalleReporte = DTDatosAgencia;
            this.DTCompraProductoDetalleReporte.TableName = "CodigosProductosEspecificosReporte";

            DSCompraProductos = new DataSet();
            DSCompraProductos.Tables.AddRange(new DataTable[] { DTCompraProductoReporte, DTCompraProductoDetalleReporte });
            reporteCodigosEspecificos = new CRCodiigoProductosEspecificos();
            this.Load += new EventHandler(FReporteCodigoEspecificos_Load);
        }

        void FReporteCompraProductosGeneral_Load(object sender, EventArgs e)
        {            
            reporteComprasProductos.SetDataSource(DSCompraProductos);
            CRVCompraProductos.ReportSource = reporteComprasProductos;
        }

        void FReporteCompraProductosRecibo_Load(object sender, EventArgs e)
        {            
            reporteRecibo.SetDataSource(DSCompraProductos);
            CRVCompraProductos.ReportSource = reporteRecibo;
        }

        void FReporteCodigoEspecificos_Load(object sender, EventArgs e)
        {            
            reporteCodigosEspecificos.SetDataSource(DSCompraProductos);
            CRVCompraProductos.ReportSource = reporteCodigosEspecificos;
        }
    }
}
