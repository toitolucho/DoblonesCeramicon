using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WFADoblones20.ReportesGestionComercial;
using CrystalDecisions.Shared;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FReporteVentasProductosGeneral : Form
    {
        DataTable DTVentaProductoReporte = null;
        DataTable DTVentaProductoDetalleReporte = null;
        DataTable DTVentaProductoEspecificoAgregadoReporte = null;
        DataTable DTDatosAgencia = null;
        DataSet DSReporteVentaProductos = null;
        private char TipoReporte = 'G'; // 'G' Reporte General, 'F'->Reporte de Factura, 'R'->Reporte de Recibo

        public String MontoPagoCadena = "Cero";

        public Button btnCerrarReporte;
        /// <summary>
        /// Reporte para los Documentos de las Ventas : Recibo y Factura, e Informe General Detallado
        /// </summary>
        /// <param name="DTDatosAgencia">Datos de la Agencia, o se puede pasar los Datos de los Productos Agregados</param>
        /// <param name="DTVentaProductoReporte">Datos de la Venta</param>
        /// <param name="DTVentaProductoDetalleReporte">Detalle de la Venta incluyendo agregados o no </param>
        /// <param name="TipoReporte">Tipo de Reporte :  'F'->Factura, 'R'->Recibo, 'G'->General(No se Puede Pasar para este constructor), 'T'->Nota de Entrega Institucional</param>
        public FReporteVentasProductosGeneral(DataTable DTDatosAgencia, DataTable DTVentaProductoReporte, DataTable DTVentaProductoDetalleReporte, char TipoReporte)
        {
            InitializeComponent();
            btnCerrarReporte = new Button();
            btnCerrarReporte.Click += new EventHandler(btnCerrarReporte_Click);
            this.TipoReporte = TipoReporte;

            this.DTVentaProductoReporte = DTVentaProductoReporte;
            DTVentaProductoReporte.TableName = "VentaProductoReporte";
            
            this.DTVentaProductoDetalleReporte = DTVentaProductoDetalleReporte;

            DSReporteVentaProductos = new DataSet();

            switch (this.TipoReporte)
            {
                case 'G':
                    this.DTVentaProductoEspecificoAgregadoReporte = DTDatosAgencia;
                    this.DTVentaProductoEspecificoAgregadoReporte.TableName = "VentaProductoEspecificoAgregadoReporte";
                    this.DTVentaProductoDetalleReporte.TableName = "VentaProductoDetalleReporte";
                    DSReporteVentaProductos.Tables.AddRange(new DataTable[] { DTVentaProductoReporte, DTVentaProductoDetalleReporte, DTVentaProductoEspecificoAgregadoReporte });                    
                    break;
                //case 'F':
                //    this.DTDatosAgencia = DTDatosAgencia;
                //    this.DTDatosAgencia.TableName = "AgenciasParaTransaccionesReportes";
                //    this.DTVentaProductoDetalleReporte.TableName = "VentaProductoDetalleReporteIncluidoAgregados";
                //    DSReporteVentaProductos.Tables.AddRange(new DataTable[] { DTVentaProductoReporte, DTVentaProductoDetalleReporte, DTDatosAgencia });
                //    break;
                case 'R': case 'F': case 'T':
                    this.DTDatosAgencia = DTDatosAgencia;
                    this.DTDatosAgencia.TableName = "ListarDatosAgenciasParaTransaccionesReportes";
                    this.DTVentaProductoDetalleReporte.TableName = ((this.TipoReporte == 'R' || TipoReporte == 'F')? "VentaProductoDetalleReporteIncluidoAgregados" : "VentaProductoDetalleReporte");
                    DTVentaProductoDetalleReporte.PrimaryKey = null;
                    DataColumn[] PrimaryKeyColumns = new DataColumn[1];
                    PrimaryKeyColumns[0] = DTVentaProductoDetalleReporte.Columns["CodigoProducto"];
                    //DTVentaProductoDetalleReporte.PrimaryKey = PrimaryKeyColumns;
                    DSReporteVentaProductos.Tables.AddRange(new DataTable[] { DTVentaProductoReporte, DTVentaProductoDetalleReporte, DTDatosAgencia });

                    if (DTVentaProductoDetalleReporte.Rows.Count > 0)
                    {
                        DTVentaProductoDetalleReporte.Columns["PrecioUnitarioVenta"].ColumnName = "PrecioUnitarioVenta1";
                        DTVentaProductoDetalleReporte.Columns["PrecioTotalVenta"].ColumnName = "PrecioTotalVenta1";
                        DTVentaProductoDetalleReporte.Columns["PrecioUnitarioMonedaCotizacion"].ColumnName = "PrecioUnitarioVenta";
                        DTVentaProductoDetalleReporte.Columns["PrecioTotalMonedaCotizacion"].ColumnName = "PrecioTotalVenta";
                    }
                    break;
            }
            
        }

        void btnCerrarReporte_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FReporteVentasProductosGeneral_Load(object sender, EventArgs e)
        {
            switch (TipoReporte)
            {
                case 'G':
                    CRVentasProductosGeneral reporteVentasProductosGeneral = new CRVentasProductosGeneral();
                    reporteVentasProductosGeneral.SetDataSource(DSReporteVentaProductos);
                    CRVVentasProductos.ReportSource = reporteVentasProductosGeneral;
                    break;
                case 'F':
                    CRVentasProductosFactura reporteVentasProductosFactura = new CRVentasProductosFactura();                    

                    //ParameterDiscreteValue crtParamDiscreteValue;
                    //ParameterField crtParamField;
                    //ParameterFields crtParamFields;

                    //object MontoTotal = DTVentaProductoDetalleReporte.Compute("sum(PrecioTotalVenta)", "");
                    //MontoPagoCadena = Numalet.ToString(Decimal.Parse(MontoTotal.ToString()));

                    ////------------------Monto Total de Pago
                    //crtParamDiscreteValue = new ParameterDiscreteValue();
                    //crtParamField = new ParameterField();
                    //crtParamFields = new ParameterFields();
                    //MontoPagoCadena = MontoPagoCadena[0].ToString().ToUpper() + MontoPagoCadena.Substring(1).Trim();
                    //crtParamDiscreteValue.Value = MontoPagoCadena.Trim();
                    //crtParamField.ParameterFieldName = "MontoTotalCadena";
                    //crtParamField.CurrentValues.Add(crtParamDiscreteValue);
                    //crtParamFields.Add(crtParamField);

                    //CRVVentasProductos.ParameterFieldInfo = crtParamFields;

                    reporteVentasProductosFactura.SetDataSource(DSReporteVentaProductos);

                    CRVVentasProductos.ReportSource = reporteVentasProductosFactura;
                    break;
                case 'R':
                    CRVentasProductosRecibo reporteVentasProductosRecibo = new CRVentasProductosRecibo();
                    reporteVentasProductosRecibo.SetDataSource(DSReporteVentaProductos);
                    CRVVentasProductos.ReportSource = reporteVentasProductosRecibo;
                    break;
                case 'T':
                    CRVentasProductosNotaEntregaInstitucional reporteVentasProductosEntregaInstitucional = new CRVentasProductosNotaEntregaInstitucional();
                    reporteVentasProductosEntregaInstitucional.SetDataSource(DSReporteVentaProductos);
                    CRVVentasProductos.ReportSource = reporteVentasProductosEntregaInstitucional;
                    break;
                default:
                    MessageBox.Show("No se pudo Cargar satisfactoriamente el Informe que desea Visualizar, Por favor intentelo de Nuevo");
                    break;
            }
            this.CancelButton = this.btnCerrarReporte;
            
        }
    }
}
