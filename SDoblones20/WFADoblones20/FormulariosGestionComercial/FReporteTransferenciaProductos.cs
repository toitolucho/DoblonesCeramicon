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
    public partial class FReporteTransferenciaProductos : Form
    {
        DataTable DTTransferenciaProductos;
        DataTable DTTransferenciaProductosDetalle;
        DataTable DTTransferenciaProductosGastosDetalle;
        DataTable DTTransferenciasProductosEspecificos;
        DataTable DTTransferenciasMontoMonedaLiteral;
        string CodigoTipoReporte;
        DataSet DSTransferenciaProductos;
        Button btnCerrarReporte;

        public FReporteTransferenciaProductos()
        {
            InitializeComponent();            
            DSTransferenciaProductos = new DataSet();
            btnCerrarReporte = new Button();
            btnCerrarReporte.Click += new EventHandler(btnCerrarReporte_Click);
            this.CancelButton = btnCerrarReporte;
        }

        void btnCerrarReporte_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FReporteTransferenciaProductos_Load(object sender, EventArgs e)
        {
            switch(CodigoTipoReporte)
            {
                case "G": // reporte General
                    DSTransferenciaProductos.Tables.Clear();
                    DSTransferenciaProductos.Tables.AddRange(new DataTable[] { DTTransferenciaProductos, DTTransferenciaProductosDetalle, DTTransferenciaProductosGastosDetalle });
                    CRTransferenciasProductosGeneral _CRTransferenciasProductosGeneral;
                    _CRTransferenciasProductosGeneral = new CRTransferenciasProductosGeneral();
                    _CRTransferenciasProductosGeneral.SetDataSource(DSTransferenciaProductos);
                    CRVTransferenciaProductos.ReportSource = _CRTransferenciasProductosGeneral;
                    break;
                case "T" : //reporte de gastos
                    DSTransferenciaProductos.Tables.Clear();
                    DSTransferenciaProductos.Tables.AddRange(new DataTable[] { DTTransferenciaProductos, DTTransferenciaProductosGastosDetalle, DTTransferenciasMontoMonedaLiteral });
                    CRTransferenciasProductosGastosDetalle _CRTransferenciasProductosGastosDetalle = new CRTransferenciasProductosGastosDetalle();
                    _CRTransferenciasProductosGastosDetalle.SetDataSource(DSTransferenciaProductos);
                    CRVTransferenciaProductos.ReportSource = _CRTransferenciasProductosGastosDetalle;
                    break;
                case "E": //reporte de Productos Espeficos
                    DSTransferenciaProductos.Tables.Clear();                    
                    DSTransferenciaProductos.Tables.AddRange(new DataTable[] { DTTransferenciaProductos, DTTransferenciaProductosGastosDetalle, DTTransferenciaProductosDetalle, DTTransferenciasProductosEspecificos });
                    CRTransferenciasProductosGeneralEspecificos _CRTransferenciasProductosEspecificos = new CRTransferenciasProductosGeneralEspecificos();
                    _CRTransferenciasProductosEspecificos.SetDataSource(DSTransferenciaProductos);
                    CRVTransferenciaProductos.ReportSource = _CRTransferenciasProductosEspecificos;
                    break;
            }
            
        }


        public void enviarTablasParaGastos(DataTable DTTransferenciasProductos, DataTable DTTrransferenciasProductosGastosDetalle, DataTable DTTransferenciasMontoMonedaLiteral)
        {
            this.DTTransferenciaProductos = DTTransferenciasProductos;
            this.DTTransferenciaProductosGastosDetalle = DTTrransferenciasProductosGastosDetalle;
            this.DTTransferenciasMontoMonedaLiteral = DTTransferenciasMontoMonedaLiteral;
            CodigoTipoReporte = "T";
        }

        public void enviarTablasParaGastosGeneral(DataTable DTTransferenciaProductos, DataTable DTTransferenciaProductosDetalle, DataTable DTTransferenciaProductosGastosDetalle)
        {
            this.DTTransferenciaProductos = DTTransferenciaProductos;
            this.DTTransferenciaProductosDetalle = DTTransferenciaProductosDetalle;
            this.DTTransferenciaProductosGastosDetalle = DTTransferenciaProductosGastosDetalle;
            CodigoTipoReporte = "G";
        }

        public void enviarTablasParaEspecificos(DataTable DTTransferenciaProductos, DataTable DTTransferenciaProductosDetalle, DataTable DTTransferenciaProductosGastosDetalle, DataTable DTTransferenciasProductosEspecificos)
        {
            this.DTTransferenciaProductos = DTTransferenciaProductos;
            this.DTTransferenciaProductosDetalle = DTTransferenciaProductosDetalle;
            this.DTTransferenciaProductosDetalle.TableName = "ListarTransferenciaProductosDetalleReporte";
            this.DTTransferenciaProductosGastosDetalle = DTTransferenciaProductosGastosDetalle;
            this.DTTransferenciasProductosEspecificos = DTTransferenciasProductosEspecificos;
            CodigoTipoReporte = "E";
        }

        
    }
}
