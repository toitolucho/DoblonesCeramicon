using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WFADoblones20.ReportesGestionComercial;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FReporteInventarioMercaderiaEnTransito : Form
    {
        DataTable DTMercaderiaEnTransito;
        public FReporteInventarioMercaderiaEnTransito()
        {
            InitializeComponent();            
        }

        public void ListarInventarioMercaderiaEnTransito(DataTable DTMercaderiaEnTransito, bool AgruparPorProveedor)
        {
            this.DTMercaderiaEnTransito = DTMercaderiaEnTransito;
            ReportClass ReporteMercaderiaEnTransito = null;
            if (AgruparPorProveedor)            
                ReporteMercaderiaEnTransito = new CRInventarioMercaderiaEnTransitoProveedor();            
            else
                ReporteMercaderiaEnTransito = new CRInventarioMercaderiaEnTransitoPorProducto();
            ReporteMercaderiaEnTransito.SetDataSource(DTMercaderiaEnTransito);
            this.CRVMercaderiaEnTransito.ReportSource = ReporteMercaderiaEnTransito;

        }


        public void ListarComprasProductosReportesPorFechasProveedor(DataTable DTMercaderiaEnTransito, DateTime FechaHoraInicio, DateTime FechaHoraFin, bool AgruparPorProveedor)
        {
            this.DTMercaderiaEnTransito = DTMercaderiaEnTransito;
            ReportClass ReporteMercaderiaEnTransito = null;
            if (AgruparPorProveedor)
                ReporteMercaderiaEnTransito = new CRListarComprasProductosReportesPorFechasProveedor();
            else
                ReporteMercaderiaEnTransito = new CRListarComprasProductosReportesPorFechasProveedor2();
            ReporteMercaderiaEnTransito.SetDataSource(DTMercaderiaEnTransito);
            this.CRVMercaderiaEnTransito.ReportSource = ReporteMercaderiaEnTransito;

            ParameterDiscreteValue crtParamDiscreteValue;
            ParameterField crtParamField;
            ParameterFields crtParamFields;

            //------------------FechaHoraInicio
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamFields = new ParameterFields();
            crtParamDiscreteValue.Value = FechaHoraInicio;
            crtParamField.ParameterFieldName = "FechaHoraInicio";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);

            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = FechaHoraFin;
            crtParamField.ParameterFieldName = "FechaHoraFin";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);

            CRVMercaderiaEnTransito.ParameterFieldInfo = crtParamFields;           

            

        }

        public void ListarComprasProductosReportesPorFechasTipo(DataTable DTMercaderiaEnTransito, DateTime FechaHoraInicio, DateTime FechaHoraFin, bool AgruparPorFactura)
        {
            this.DTMercaderiaEnTransito = DTMercaderiaEnTransito;
            ReportClass ReporteMercaderiaEnTransito = null;
            if (AgruparPorFactura)
                ReporteMercaderiaEnTransito = new CRListarComprasProductosReportesPorFechasTipo();
            else
                ReporteMercaderiaEnTransito = new CRListarComprasProductosReportesPorFechasTipo2();
            ReporteMercaderiaEnTransito.SetDataSource(DTMercaderiaEnTransito);
            this.CRVMercaderiaEnTransito.ReportSource = ReporteMercaderiaEnTransito;

            ParameterDiscreteValue crtParamDiscreteValue;
            ParameterField crtParamField;
            ParameterFields crtParamFields;

            //------------------FechaHoraInicio
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamFields = new ParameterFields();
            crtParamDiscreteValue.Value = FechaHoraInicio;
            crtParamField.ParameterFieldName = "FechaHoraInicio";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);

            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = FechaHoraFin;
            crtParamField.ParameterFieldName = "FechaHoraFin";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);

            CRVMercaderiaEnTransito.ParameterFieldInfo = crtParamFields;  

        }


        #region Funciones para los reportes de Ventas
        public void ListarVentasProductosReportesPorFechasCliente(DataTable DTListarVentasProductosReportesPorFechasCliente, DateTime FechaHoraInicio, DateTime FechaHoraFin, bool AgruparPorCliente)
        {
            this.DTMercaderiaEnTransito = DTListarVentasProductosReportesPorFechasCliente;
            this.DTMercaderiaEnTransito.Columns["NombreCliente"].ColumnName = "NombreRazonSocial";
            ReportClass ReporteMercaderiaEnTransito = null;
            if (AgruparPorCliente)
                ReporteMercaderiaEnTransito = new CRListarVentasProductosReportesPorFechasCliente();
            else
                ReporteMercaderiaEnTransito = new CRListarVentasProductosReportesPorFechasCliente2();
            ReporteMercaderiaEnTransito.SetDataSource(DTListarVentasProductosReportesPorFechasCliente);
            this.CRVMercaderiaEnTransito.ReportSource = ReporteMercaderiaEnTransito;

            ParameterDiscreteValue crtParamDiscreteValue;
            ParameterField crtParamField;
            ParameterFields crtParamFields;

            //------------------FechaHoraInicio
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamFields = new ParameterFields();
            crtParamDiscreteValue.Value = FechaHoraInicio;
            crtParamField.ParameterFieldName = "FechaHoraInicio";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);

            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = FechaHoraFin;
            crtParamField.ParameterFieldName = "FechaHoraFin";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);

            CRVMercaderiaEnTransito.ParameterFieldInfo = crtParamFields;



        }

        public void ListarVentasProductosReportesPorFechasTipo(DataTable DTListarVentasProductosReportesPorFechasTipo, DateTime FechaHoraInicio, DateTime FechaHoraFin, bool AgruparPorFactura)
        {
            this.DTMercaderiaEnTransito = DTListarVentasProductosReportesPorFechasTipo;
            ReportClass ReporteMercaderiaEnTransito = null;
            if (AgruparPorFactura)
                ReporteMercaderiaEnTransito = new CRListarVentasProductosReportesPorFechasTipo();
            else
                ReporteMercaderiaEnTransito = new CRListarVentasProductosReportesPorFechasTipo2();
            ReporteMercaderiaEnTransito.SetDataSource(DTListarVentasProductosReportesPorFechasTipo);
            this.CRVMercaderiaEnTransito.ReportSource = ReporteMercaderiaEnTransito;

            ParameterDiscreteValue crtParamDiscreteValue;
            ParameterField crtParamField;
            ParameterFields crtParamFields;

            //------------------FechaHoraInicio
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamFields = new ParameterFields();
            crtParamDiscreteValue.Value = FechaHoraInicio;
            crtParamField.ParameterFieldName = "FechaHoraInicio";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);

            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = FechaHoraFin;
            crtParamField.ParameterFieldName = "FechaHoraFin";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);

            CRVMercaderiaEnTransito.ParameterFieldInfo = crtParamFields;

        }

        public void ListarVentasProductosReportesPorCreditosFechasCliente(DataTable DTListarVentasProductosReportesPorCreditosFechasCliente, DateTime FechaHoraInicio, DateTime FechaHoraFin, bool porProveedores)
        {
            this.DTMercaderiaEnTransito = DTListarVentasProductosReportesPorCreditosFechasCliente;
            ReportClass ReporteMercaderiaEnTransito = null;
            if (porProveedores)
                ReporteMercaderiaEnTransito = new CRListarVentasProductosReportesPorCreditosFechasCliente2();
            else
                ReporteMercaderiaEnTransito = new CRListarVentasProductosReportesPorCreditosFechasCliente();
            ReporteMercaderiaEnTransito.SetDataSource(DTListarVentasProductosReportesPorCreditosFechasCliente);
            this.CRVMercaderiaEnTransito.ReportSource = ReporteMercaderiaEnTransito;

            ParameterDiscreteValue crtParamDiscreteValue;
            ParameterField crtParamField;
            ParameterFields crtParamFields;

            //------------------FechaHoraInicio
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamFields = new ParameterFields();
            crtParamDiscreteValue.Value = FechaHoraInicio;
            crtParamField.ParameterFieldName = "FechaHoraInicio";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);

            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = FechaHoraFin;
            crtParamField.ParameterFieldName = "FechaHoraFin";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);

            CRVMercaderiaEnTransito.ParameterFieldInfo = crtParamFields;
        }
        #endregion




        /// <summary>
        /// Llama al reporte Provisional, permite personalizar el reporte, siempre y cuando se pase el listado
        /// de articulos que deseas visualizar, a  partir de los Listado de Codigos
        /// </summary>
        /// <param name="NumeroAgencia"></param>
        /// <param name="_InventariosProductosCLN"></param>
        /// <param name="FechaHoraInicio"></param>
        /// <param name="FechaHoraFin"></param>
        public void ListarKardexProductoDetalladoReporte(int NumeroAgencia, CLCLN.GestionComercial.InventariosProductosCLN _InventariosProductosCLN,
            DateTime FechaHoraInicio, DateTime FechaHoraFin)
        {
            this.DTMercaderiaEnTransito = _InventariosProductosCLN.ListarKardexProductoDetalladoReporte(NumeroAgencia, FechaHoraInicio, FechaHoraFin, null);
            ReportClass ReporteMercaderiaEnTransito = null;
            
            ReporteMercaderiaEnTransito = new CRKardexFisicoValoradoInventarioArticulos();
            ReporteMercaderiaEnTransito.SetDataSource(DTMercaderiaEnTransito);
            this.CRVMercaderiaEnTransito.ReportSource = ReporteMercaderiaEnTransito;

            ParameterDiscreteValue crtParamDiscreteValue;
            ParameterField crtParamField;
            ParameterFields crtParamFields;

            //------------------FechaHoraInicio
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamFields = new ParameterFields();
            crtParamDiscreteValue.Value = FechaHoraInicio;
            crtParamField.ParameterFieldName = "FechaHoraInicio";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);

            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = FechaHoraFin;
            crtParamField.ParameterFieldName = "FechaHoraFin";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);

            CRVMercaderiaEnTransito.ParameterFieldInfo = crtParamFields;  
        }


        public void ListarKardexValorado(int NumeroAgencia, CLCLN.GestionComercial.InventariosProductosCLN _InventariosProductosCLN,
            DateTime FechaHoraInicio, DateTime FechaHoraFin)
        {
            this.DTMercaderiaEnTransito = _InventariosProductosCLN.ListarKardexValorado(NumeroAgencia, FechaHoraInicio, FechaHoraFin);
            ReportClass ReporteMercaderiaEnTransito = null;

            ReporteMercaderiaEnTransito = new CRListarKardexValorado();
            ReporteMercaderiaEnTransito.SetDataSource(DTMercaderiaEnTransito);
            this.CRVMercaderiaEnTransito.ReportSource = ReporteMercaderiaEnTransito;

            ParameterDiscreteValue crtParamDiscreteValue;
            ParameterField crtParamField;
            ParameterFields crtParamFields;

            //------------------FechaHoraInicio
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamFields = new ParameterFields();
            crtParamDiscreteValue.Value = FechaHoraInicio;
            crtParamField.ParameterFieldName = "FechaHoraInicio";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);

            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = FechaHoraFin;
            crtParamField.ParameterFieldName = "FechaHoraFin";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);

            CRVMercaderiaEnTransito.ParameterFieldInfo = crtParamFields;
        }

        public void ListarHistorialInventarioPorFecha(int NumeroAgencia, CLCLN.GestionComercial.InventariosProductosCLN _InventariosProductosCLN,
            DateTime FechaHoraInicio, DateTime FechaHoraFin)
        {
            this.DTMercaderiaEnTransito = _InventariosProductosCLN.ListarHistorialInventarioPorFecha(NumeroAgencia, FechaHoraInicio, FechaHoraFin);
            ReportClass ReporteMercaderiaEnTransito = null;

            ReporteMercaderiaEnTransito = new InventarioHistorialKardex();
            ReporteMercaderiaEnTransito.SetDataSource(DTMercaderiaEnTransito);
            this.CRVMercaderiaEnTransito.ReportSource = ReporteMercaderiaEnTransito;

            ParameterDiscreteValue crtParamDiscreteValue;
            ParameterField crtParamField;
            ParameterFields crtParamFields;

            //------------------FechaHoraInicio
            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamFields = new ParameterFields();
            crtParamDiscreteValue.Value = FechaHoraInicio;
            crtParamField.ParameterFieldName = "FechaHoraInicio";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);

            crtParamDiscreteValue = new ParameterDiscreteValue();
            crtParamField = new ParameterField();
            crtParamDiscreteValue.Value = FechaHoraFin;
            crtParamField.ParameterFieldName = "FechaHoraFin";
            crtParamField.CurrentValues.Add(crtParamDiscreteValue);
            crtParamFields.Add(crtParamField);

            CRVMercaderiaEnTransito.ParameterFieldInfo = crtParamFields;
        }

        //public ListarHistorialInventarioPorFecha



        public void ListarInventarioMercaderiaEnTransitoFisico(DataTable DTMercaderiaEnTransito)
        {
            this.DTMercaderiaEnTransito = DTMercaderiaEnTransito;
            CRInventarioMercaderiaEnTransito ReporteMercaderiaEnTransito = new CRInventarioMercaderiaEnTransito();
            ReporteMercaderiaEnTransito.SetDataSource(DTMercaderiaEnTransito);
            this.CRVMercaderiaEnTransito.ReportSource = ReporteMercaderiaEnTransito;
        }


        public void ListarProductosEnTransitoPorPedido(DataTable DTMercaderiaEnTransito)
        {
            this.DTMercaderiaEnTransito = DTMercaderiaEnTransito;
            CRListarProductosEnTransitoPorPedido ReporteMercaderiaEnTransito = new CRListarProductosEnTransitoPorPedido();
            ReporteMercaderiaEnTransito.SetDataSource(DTMercaderiaEnTransito);
            this.CRVMercaderiaEnTransito.ReportSource = ReporteMercaderiaEnTransito;
        }
    }
}
