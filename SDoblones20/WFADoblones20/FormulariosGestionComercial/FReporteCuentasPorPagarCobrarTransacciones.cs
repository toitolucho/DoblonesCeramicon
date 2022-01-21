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
    public partial class FReporteCuentasPorPagarCobrarTransacciones : FReporteGeneral
    {
        public FReporteCuentasPorPagarCobrarTransacciones()
        {
            
            InitializeComponent();
        }

        public void cargarParametros(DateTime FechaInicio, DateTime FechaFin)
        {
            ParameterDiscreteValue crtParamDiscreteValue;
            ParameterField crtParamField;
            ParameterFields crtParamFields;

            //------------------Fecha Inicio
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamFields = new ParameterFields();
            crtParamDiscreteValue.Value = FechaInicio;
            crtParamField.ParameterFieldName = "FechaHoraInicio";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);

            //------------------Fecha Fin
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = FechaFin;
            crtParamField.ParameterFieldName = "FechaHoraFin";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);

           
            this.CRVReporteGeneralAcceso.ParameterFieldInfo = crtParamFields;
        }

        public void ListarCompraProductoCuentasPorCobrarReporte(DataTable DTListarCompraProductoCuentasPorCobrarReporte, DateTime FechaInicio, DateTime FechaFin)
        {
            DTListarCompraProductoCuentasPorCobrarReporte.TableName = "ListarCompraProductoCuentasPorCobrarReporte";
            DTListarCompraProductoCuentasPorCobrarReporte.Constraints.Clear();

            this.DSReporteGeneral.Tables.Add(DTListarCompraProductoCuentasPorCobrarReporte);
            this.fuenteReporteGeneral = new CRListarCompraProductoCuentasPorCobrarReporte();
            fuenteReporteGeneral.SetDataSource(DSReporteGeneral);
            cargarParametros(FechaInicio, FechaFin);            
        }

        public void ListarCompraProductoCuentasPorPagarReporte(DataTable DTListarCompraProductoCuentasPorPagarReporte, DateTime FechaInicio, DateTime FechaFin)
        {
            DTListarCompraProductoCuentasPorPagarReporte.TableName = "ListarCompraProductoCuentasPorPagarReporte";
            DTListarCompraProductoCuentasPorPagarReporte.Constraints.Clear();

            this.DSReporteGeneral.Tables.Add(DTListarCompraProductoCuentasPorPagarReporte);
            this.fuenteReporteGeneral = new CRListarCompraProductoCuentasPorPagarReporte();
            fuenteReporteGeneral.SetDataSource(DSReporteGeneral);
            cargarParametros(FechaInicio, FechaFin);
        }

        public void ListarCompraProductoCuentasPorCobrarReportePorProveedor(DataTable DTListarCompraProductoCuentasPorCobrarReporte, DateTime FechaInicio, DateTime FechaFin)
        {
            DTListarCompraProductoCuentasPorCobrarReporte.TableName = "ListarCompraProductoCuentasPorCobrarReporte";
            DTListarCompraProductoCuentasPorCobrarReporte.Constraints.Clear();

            this.DSReporteGeneral.Tables.Add(DTListarCompraProductoCuentasPorCobrarReporte);
            this.fuenteReporteGeneral = new CRListarCompraProductoCuentasPorCobrarReportePorProveedor();
            fuenteReporteGeneral.SetDataSource(DSReporteGeneral);
            cargarParametros(FechaInicio, FechaFin);
        }

        public void ListarCompraProductoCuentasPorPagarReportePorProveedor(DataTable DTListarCompraProductoCuentasPorPagarReporte, DateTime FechaInicio, DateTime FechaFin)
        {
            DTListarCompraProductoCuentasPorPagarReporte.TableName = "ListarCompraProductoCuentasPorPagarReporte";
            DTListarCompraProductoCuentasPorPagarReporte.Constraints.Clear();

            this.DSReporteGeneral.Tables.Add(DTListarCompraProductoCuentasPorPagarReporte);
            this.fuenteReporteGeneral = new CRListarCompraProductoCuentasPorPagarReportePorProveedor();
            fuenteReporteGeneral.SetDataSource(DSReporteGeneral);
            cargarParametros(FechaInicio, FechaFin);
        }
    }
}
