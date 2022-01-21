using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WFADoblones20.ReportesContabilidad;

namespace WFADoblones20.FormulariosContabilidad
{
    public partial class FReporteContabilidad : WFADoblones20.FormulariosGestionComercial.FReporteGeneral
    {
        public FReporteContabilidad()
        {
            InitializeComponent();
        }

        public void ListarMovimientoCajaReporte(DataTable DTListarMovimientoCajaReporte, DataTable DTAperturaFracciones,
            DataTable DTCierreFracciones, DataTable DTListarResumenCajaMovimientoReporte)
        {
            this.DSReporteGeneral.Clear();
            DTCierreFracciones.TableName = DTCierreFracciones.TableName + "2";
            this.DSReporteGeneral.Tables.AddRange(new DataTable[] { DTListarMovimientoCajaReporte ,
                DTAperturaFracciones, DTCierreFracciones, DTListarResumenCajaMovimientoReporte});
            this.fuenteReporteGeneral = new CRMovimientoArqueoCaja();
            fuenteReporteGeneral.SetDataSource(DSReporteGeneral);
            fuenteReporteGeneral.Subreports[0].SetDataSource(DTAperturaFracciones);
            fuenteReporteGeneral.Subreports[1].SetDataSource(DTCierreFracciones);
            this.CRVReporteGeneralAcceso.ReportSource = fuenteReporteGeneral;
        }
    }
}
