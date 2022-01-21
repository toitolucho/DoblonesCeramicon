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
using System.IO;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FReporteCotizacionesVentasProductos : Form
    {
        DataTable DTListarCotizacionVentasProductosDetalleReporte = null;
        DataTable DTListarDatosClienteCotizacionesVentaReporte = null;
        DataTable DTProductosDescripcion = null;
        DataSet DSCotizacionesVentaProductos = null;
        CRCotizacionesVentaProductos reporteCotizacionesVentaProductos = null;
        CRCotizacionesVentaProductosModificado reporteCotizacionesVentaProductosSinPrecios = null;
        bool incluirPrecios = false;
        Button btnCerrarReporte;
        public FReporteCotizacionesVentasProductos(DataTable DTListarCotizacionVentasProductosDetalleReporte, DataTable DTListarDatosClienteCotizacionesVentaReporte, bool incluirPrecios)
        {
            this.DTListarCotizacionVentasProductosDetalleReporte = DTListarCotizacionVentasProductosDetalleReporte;
            this.DTListarDatosClienteCotizacionesVentaReporte = DTListarDatosClienteCotizacionesVentaReporte;

            this.DTListarCotizacionVentasProductosDetalleReporte.TableName = "ListarCotizacionVentasProductosDetalleReporte";
            this.DTListarDatosClienteCotizacionesVentaReporte.TableName = "ListarDatosClienteCotizacionesVentaReporte";

            this.DSCotizacionesVentaProductos = new DataSet();
            this.DSCotizacionesVentaProductos.Tables.AddRange(new DataTable[] { DTListarCotizacionVentasProductosDetalleReporte,DTListarDatosClienteCotizacionesVentaReporte});

            this.incluirPrecios = incluirPrecios;
            InitializeComponent();

            btnCerrarReporte = new Button();
            btnCerrarReporte.Click += new EventHandler(btnCerrarReporte_Click);

            this.Load += new EventHandler(FReporteCotizacionesVentasProductos_Load);
        }

        public void cargarDatosCotizacionProductosCompuestos(DataTable DTMaestro, DataTable DTDetalle, DataTable DTSubReporte )
        {
            this.DSCotizacionesVentaProductos.DataSetName = "DSDoblones20GestionComercial";
            DTMaestro.TableName = "ListarDatosClienteCotizacionesVentaReporte";
            DTDetalle.TableName = "ListarCotizacionVentasProductosDetalleReporte";
            //DTSubReporte.TableName = "ListarVentaProductoSimplesDetalleReporte";
            DTDetalle.Columns["NombreProductoComponente"].ColumnName = "NombreMarcaProducto";
            this.DSCotizacionesVentaProductos.Tables.AddRange(new DataTable[]{DTMaestro, DTDetalle, DTSubReporte });
            CRCotizacionesVentaProductosCompuestos reporteCotizacion = new CRCotizacionesVentaProductosCompuestos();
            reporteCotizacion.SetDataSource(DSCotizacionesVentaProductos);
            CRVCotizacionesVentasProductos.ReportSource = reporteCotizacion;
        }


        public FReporteCotizacionesVentasProductos()
        {
            InitializeComponent();
            btnCerrarReporte = new Button();
            btnCerrarReporte.Click += new EventHandler(btnCerrarReporte_Click);

            this.DSCotizacionesVentaProductos = new DataSet();
        }


        public void enviarTablasReporteAvanzado(DataTable DTListarCotizacionVentasProductosDetalleReporte, DataTable DTListarDatosClienteCotizacionesVentaReporte, DataTable DTProductosDescripcion)
        {
            this.DTListarCotizacionVentasProductosDetalleReporte = DTListarCotizacionVentasProductosDetalleReporte;
            this.DTListarDatosClienteCotizacionesVentaReporte = DTListarDatosClienteCotizacionesVentaReporte;
            this.DTProductosDescripcion = DTProductosDescripcion;

            this.DSCotizacionesVentaProductos.Tables.AddRange(new DataTable[] { DTListarCotizacionVentasProductosDetalleReporte, DTListarDatosClienteCotizacionesVentaReporte, DTProductosDescripcion });

            CRCotizacionesVentaProductosDetallado reporteCotizacion = new CRCotizacionesVentaProductosDetallado();

            foreach (DataRow DRProducto in DTProductosDescripcion.Rows)
            {
                if (File.Exists(DRProducto["RutaImagenProducto1"].ToString()))
                {
                    FileStream FilStr = new FileStream(DRProducto["RutaImagenProducto1"].ToString(), FileMode.Open);
                    BinaryReader BinRed = new BinaryReader(FilStr);
                    DRProducto["Imagen1"] = BinRed.ReadBytes((int)BinRed.BaseStream.Length);
                    FilStr.Close();
                    BinRed.Close();
                }
                if (File.Exists(DRProducto["RutaImagenProducto2"].ToString()))
                {
                    FileStream FilStr = new FileStream(DRProducto["RutaImagenProducto2"].ToString(), FileMode.Open);
                    BinaryReader BinRed = new BinaryReader(FilStr);
                    DRProducto["Imagen2"] = BinRed.ReadBytes((int)BinRed.BaseStream.Length);
                    FilStr.Close();
                    BinRed.Close();
                }
                if (File.Exists(DRProducto["RutaImagenProducto3"].ToString()))
                {
                    FileStream FilStr = new FileStream(DRProducto["RutaImagenProducto3"].ToString(), FileMode.Open);
                    BinaryReader BinRed = new BinaryReader(FilStr);
                    DRProducto["Imagen3"] = BinRed.ReadBytes((int)BinRed.BaseStream.Length);
                    FilStr.Close();
                    BinRed.Close();
                }
                //else
                //{
                //    DRProducto["Imagen1"] = null;
                //}
            }
            DTProductosDescripcion.AcceptChanges();
            reporteCotizacion.SetDataSource(DSCotizacionesVentaProductos);
            CRVCotizacionesVentasProductos.ReportSource = reporteCotizacion;
        }



        public void enviarTablasReporteParaFax(DataTable DTListarCotizacionVentasProductosDetalleReporte, DataTable DTListarDatosClienteCotizacionesVentaReporte)
        {
            this.DTListarCotizacionVentasProductosDetalleReporte = DTListarCotizacionVentasProductosDetalleReporte;
            this.DTListarDatosClienteCotizacionesVentaReporte = DTListarDatosClienteCotizacionesVentaReporte;            

            this.DSCotizacionesVentaProductos.Tables.AddRange(new DataTable[] { DTListarCotizacionVentasProductosDetalleReporte, DTListarDatosClienteCotizacionesVentaReporte});

            CRCotizacionesVentaProductosDetalladoFax reporteCotizacion = new CRCotizacionesVentaProductosDetalladoFax();                        
            reporteCotizacion.SetDataSource(DSCotizacionesVentaProductos);
            CRVCotizacionesVentasProductos.ReportSource = reporteCotizacion;
        }


        void btnCerrarReporte_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void FReporteCotizacionesVentasProductos_Load(object sender, EventArgs e)
        {
            this.CancelButton = btnCerrarReporte;

            if (incluirPrecios)
            {                
                reporteCotizacionesVentaProductos = new CRCotizacionesVentaProductos();
                reporteCotizacionesVentaProductos.SetDataSource(DSCotizacionesVentaProductos);
                CRVCotizacionesVentasProductos.ReportSource = reporteCotizacionesVentaProductos;
            }
            else
            {
                object PrecioTotal1 = DTListarCotizacionVentasProductosDetalleReporte.Compute("sum(PrecioTotal)", "");                
                FIngresarPrecio form = new FIngresarPrecio();
                form.TxtBoxPrecioTotal.Text = PrecioTotal1.ToString();
                form.ShowDialog(this);
                decimal PrecioTotal = form.PrecioTotal;

                ParameterDiscreteValue crtParamDiscreteValue;
                ParameterField crtParamField;
                ParameterFields crtParamFields;

                //------------------Precio Total
                crtParamDiscreteValue = new ParameterDiscreteValue();
                crtParamField = new ParameterField();
                crtParamFields = new ParameterFields();
                crtParamDiscreteValue.Value = PrecioTotal.ToString();
                crtParamField.ParameterFieldName = "PrecioTotal";
                crtParamField.CurrentValues.Add(crtParamDiscreteValue);
                crtParamFields.Add(crtParamField);
                CRVCotizacionesVentasProductos.ParameterFieldInfo = crtParamFields;

                reporteCotizacionesVentaProductosSinPrecios = new CRCotizacionesVentaProductosModificado();
                reporteCotizacionesVentaProductosSinPrecios.SetDataSource(DSCotizacionesVentaProductos);
                CRVCotizacionesVentasProductos.ReportSource = reporteCotizacionesVentaProductosSinPrecios;
            }
            
        }
    }
}
