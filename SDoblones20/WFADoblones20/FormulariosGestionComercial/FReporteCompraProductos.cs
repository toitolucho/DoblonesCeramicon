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
    public partial class FReporteCompraProductos : Form
    {
        DataTable _DTCompraProductos;
        DataTable _DTCompraProductosAgregadosReporte;
        string DatosComprasProductosTupla;
        Button btnCerrarReporte;

        public FReporteCompraProductos(DataTable DTCompraProductos, string DatosCompraProductos, DataTable DTCompraProductosAgregadosReporte)
        {
            this._DTCompraProductos = DTCompraProductos;
            this._DTCompraProductosAgregadosReporte = DTCompraProductosAgregadosReporte;
            this.DatosComprasProductosTupla = DatosCompraProductos;
            InitializeComponent();

            btnCerrarReporte.Click += new EventHandler(btnCerrarReporte_Click);
        }

        void btnCerrarReporte_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FReporteCompraProductos_Load(object sender, EventArgs e)
        {
            this.CancelButton = btnCerrarReporte;

            CRComprasProductos ReporteComprasProductos = new CRComprasProductos();
            ReporteComprasProductos.SetDataSource(_DTCompraProductos);
            cRVComprasProductos.ReportSource = ReporteComprasProductos;
            string[] listadoParametros = DatosComprasProductosTupla.Trim().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            ReporteComprasProductos.Subreports[0].SetDataSource(_DTCompraProductosAgregadosReporte);

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
            crtParamField.ParameterFieldName = "NumeroCompraProducto";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);



            //----------------NombreProveedor
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = listadoParametros[2].Trim();
            crtParamField.ParameterFieldName = "NombreProveedor";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);



            //----------------FechaHoraCompra
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = listadoParametros[3].Trim();
            crtParamField.ParameterFieldName = "FechaHoraCompra";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);


            
            //------------------TipoCompra
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = listadoParametros[4].Trim();
            crtParamField.ParameterFieldName = "TipoCompra";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);


            //-----------------NumeroCuentaPorPagar
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = listadoParametros[5].Trim();
            crtParamField.ParameterFieldName = "NumeroCuentaPorPagar";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);


            //-----------------Observaciones
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = listadoParametros[6].Trim();
            crtParamField.ParameterFieldName = "Observaciones";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);


            //----------------NITProveedor
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = listadoParametros[7].Trim();
            crtParamField.ParameterFieldName = "NITProveedor";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);


            
            //-----------------NombreRepresentante
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = listadoParametros[8].Trim();
            crtParamField.ParameterFieldName = "NombreRepresentante";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);


            //-----------------Telefono
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = listadoParametros[9].Trim();
            crtParamField.ParameterFieldName = "Telefono";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);


            //----------------Direccion
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = listadoParametros[10].Trim();
            crtParamField.ParameterFieldName = "Direccion";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);


            //----------------NombreUsuario
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = listadoParametros[11].Trim();
            crtParamField.ParameterFieldName = "NombreUsuario";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);


            //--------------TotalPago
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            if (listadoParametros.Length > 13)
                crtParamDiscreteValue.Value = listadoParametros[12].Trim() + "," + listadoParametros[13].Trim();
            else
                crtParamDiscreteValue.Value = listadoParametros[12].Trim();
            crtParamField.ParameterFieldName = "TotalPago";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);

            cRVComprasProductos.ParameterFieldInfo = crtParamFields;           

        }
    }
}
