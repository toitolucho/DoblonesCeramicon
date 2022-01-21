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
    public partial class FReportesGestionComercialVentasProductos : Form
    {
        DataTable _DTVentaProductos;
        DataTable _DTVentaProductoEspecificoAgregadoReporte;
        string DatosVentasProductosTupla;
        Button btnCerrarReporte;
        public FReportesGestionComercialVentasProductos(DataTable DTVentaProductos, string DatosVentaProducto, DataTable DTVentaProductoEspecificoAgregadoReporte)
        {
            this._DTVentaProductos = DTVentaProductos;
            this.DatosVentasProductosTupla = DatosVentaProducto;
            this._DTVentaProductoEspecificoAgregadoReporte = DTVentaProductoEspecificoAgregadoReporte;
            InitializeComponent();

            btnCerrarReporte = new Button();
            btnCerrarReporte.Click += new EventHandler(btnCerrarReporte_Click);
            this.CancelButton = btnCerrarReporte;
        }

        void btnCerrarReporte_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FReportesGestionComercialVentasProductos_Load(object sender, EventArgs e)
        {

            CRVentasProductos ReporteVentasProductos = new CRVentasProductos();
            ReporteVentasProductos.SetDataSource(_DTVentaProductos);
            cRVVentasProductos.ReportSource = ReporteVentasProductos;
            string[] listadoParametros = DatosVentasProductosTupla.Trim().Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries);

            ReporteVentasProductos.Subreports[0].SetDataSource(_DTVentaProductoEspecificoAgregadoReporte);

            ParameterDiscreteValue crtParamDiscreteValue;
            ParameterField crtParamField;
            ParameterFields crtParamFields;

            //------------------NumeroAgencia
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamFields = new ParameterFields();
            crtParamDiscreteValue.Value = listadoParametros[0].Trim();
            crtParamField.ParameterFieldName = "NumeroAgencia";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);


            //-----------------NumeroCompraProducto

            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = listadoParametros[1].Trim();
            crtParamField.ParameterFieldName = "NumeroVentaProducto";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);



            //----------------NombreCliente
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = listadoParametros[2].Trim();
            crtParamField.ParameterFieldName = "NombreCliente";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);


            //-------------------NumeroFactura
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = listadoParametros[3].Trim();
            crtParamField.ParameterFieldName = "NumeroFactura";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);


            //----------------FechaHoraVenta
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = listadoParametros[4].Trim();
            crtParamField.ParameterFieldName = "FechaHoraVenta";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);


            //------------------TipoVenta
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = listadoParametros[5].Trim();
            crtParamField.ParameterFieldName = "TipoVenta";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);


            //-----------------NumeroCredito
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = listadoParametros[6].Trim();
            crtParamField.ParameterFieldName = "NumeroCuentaPorCobrar";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);


            //-----------------Observaciones
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = listadoParametros[7].Trim();
            crtParamField.ParameterFieldName = "Observaciones";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);


            //----------------NITCliente
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = listadoParametros[8].Trim();
            crtParamField.ParameterFieldName = "NITCliente";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);


            //------------------TipoCliente
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = listadoParametros[9].Trim();
            crtParamField.ParameterFieldName = "TipoCliente";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);


            //-----------------NombreRepresentante
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = listadoParametros[10].Trim();
            crtParamField.ParameterFieldName = "NombreRepresentante";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);


            //-----------------Telefono
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = listadoParametros[11].Trim();
            crtParamField.ParameterFieldName = "Telefono";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);


            //----------------Direccion
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = listadoParametros[12].Trim();
            crtParamField.ParameterFieldName = "Direccion";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);


            //----------------NombreUsuario
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = listadoParametros[13].Trim();
            crtParamField.ParameterFieldName = "NombreUsuario";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);


            //--------------TotalPago
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            if (listadoParametros.Length > 15)
                crtParamDiscreteValue.Value = listadoParametros[14].Trim() + "," + listadoParametros[15].Trim();
            else
                crtParamDiscreteValue.Value = listadoParametros[14].Trim();
            crtParamField.ParameterFieldName = "TotalPago";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);

            cRVVentasProductos.ParameterFieldInfo = crtParamFields;           

           
        }
    }
}
