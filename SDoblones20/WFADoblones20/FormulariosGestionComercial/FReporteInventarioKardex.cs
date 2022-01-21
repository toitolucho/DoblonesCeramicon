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
    public partial class FReporteInventarioKardex : Form
    {
        DataTable DTHistorialInventario;
        Button btnCerrarReporte;
        bool esGeneral = true;
        private DateTime FechaHoraInicio, FechaHoraFin;
        public FReporteInventarioKardex(DataTable DTHistorialInventario, bool esGeneral, DateTime FechaHoraInicio, DateTime FechaHoraFin)
        {
            InitializeComponent();
            this.DTHistorialInventario = DTHistorialInventario;
            this.esGeneral = esGeneral;
            btnCerrarReporte = new Button();
            btnCerrarReporte.Click += new EventHandler(btnCerrarReporte_Click);
        }

        void btnCerrarReporte_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FReporteInventarioKardex_Load(object sender, EventArgs e)
        {
            if (esGeneral)
            {
                WFADoblones20.ReportesGestionComercial.InventarioHistorialKardex ReporteInventarioHistorialKardex = new WFADoblones20.ReportesGestionComercial.InventarioHistorialKardex();
                ReporteInventarioHistorialKardex.SetDataSource(DTHistorialInventario);
                CRVHistorialInventario.ReportSource = ReporteInventarioHistorialKardex;
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

                CRVHistorialInventario.ParameterFieldInfo = crtParamFields;
                
            }
            else
            {
                CRListarMovimientosKardexProductos _CRListarMovimientosKardexProductos = new CRListarMovimientosKardexProductos();
                _CRListarMovimientosKardexProductos.SetDataSource(DTHistorialInventario);
                CRVHistorialInventario.ReportSource = _CRListarMovimientosKardexProductos;
            }

            this.CancelButton = btnCerrarReporte;
        }
    }
}
