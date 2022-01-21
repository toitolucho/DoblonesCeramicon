using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.Contabilidad;
using CLCLN.Sistema;
using CLCLN.GestionComercial;
using WFADoblones20.ReportesContabilidad;

namespace WFADoblones20.FormulariosContabilidad
{
    public partial class FReporteCajaMovimientosComprobante : Form
    {
        private DataTable dt;
        private CajaMovimientosCLN caja;

        public FReporteCajaMovimientosComprobante(string NumMov)
        {
            InitializeComponent();

            caja = new CajaMovimientosCLN();     
            dt = new DataTable();
            dt = caja.ListarCajaMovimientosReporte(int.Parse(NumMov));
        }

        public FReporteCajaMovimientosComprobante(DateTime Fecha)
        {
            InitializeComponent();

            caja = new CajaMovimientosCLN();
            dt = new DataTable();
            dt = caja.ListarCajaMovimientosReporte(Fecha);
        }

        private void FReporteCajaMovimientosDetalle_Load(object sender, EventArgs e)
        {                   
            CRCajaMovimientos crcm = new CRCajaMovimientos();
            crcm.SetDataSource(dt);
            crvCajaMovimientoDetalle.ReportSource = crcm;
        }

    }
}
