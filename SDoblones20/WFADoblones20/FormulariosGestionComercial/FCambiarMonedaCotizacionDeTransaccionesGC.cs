using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FCambiarMonedaCotizacionDeTransaccionesGC : Form
    {
        DataTable DTTransaccion = null;
        DataTable DTTransaccionTemporal = null;
        DataTable DTConfiguracionSistema = null;
        DataTable DTMonedas = null;
        CLCLN.GestionComercial.TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN = null;
        CLCLN.Sistema.MonedasCLN _MonedasCLN = null;
        /// <summary>
        /// El estado de la Transaccion : I->'Iniciada o en Edicion', 'F'-> 'Finalizada o Concluida'
        /// </summary>
        char EstadoTransaccion = 'I';
        char TipoTransaccion = 'V';
        int NumeroAgencia = 0;
        int NumeroTransaccion;
        string MascaraMoneda;
        string NombreMoneda;
        public Button btnCerrarReporte;

        public FCambiarMonedaCotizacionDeTransaccionesGC(DataTable DTTRansaccion, int NumeroPC, int NumeroAgencia, int NumeroTransaccion,CLCLN.GestionComercial.TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN, char EstadoTransaccion)
        {            
            InitializeComponent();
            this.DTTransaccion = DTTRansaccion;
            this.NumeroAgencia = NumeroAgencia;
            this.EstadoTransaccion = EstadoTransaccion;
            this._TransaccionesUtilidadesCLN = _TransaccionesUtilidadesCLN;
            btnCerrarReporte = new Button();
            btnCerrarReporte.Click += new EventHandler(btnCerrarReporte_Click);
            this.CancelButton = btnCerrarReporte;
            _TransaccionesUtilidadesCLN = new CLCLN.GestionComercial.TransaccionesUtilidadesCLN();
            _MonedasCLN = new CLCLN.Sistema.MonedasCLN();
            DTConfiguracionSistema = _TransaccionesUtilidadesCLN.ObtenerSistemaConfiguracionParaTransacciones(NumeroPC);
            DTMonedas = _MonedasCLN.ListarMonedas();
            this.NumeroTransaccion = NumeroTransaccion;
            this.Load += new EventHandler(FCambiarMonedaCotizacionDeTransaccionesGC_Load);
        }

        void btnCerrarReporte_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void FCambiarMonedaCotizacionDeTransaccionesGC_Load(object sender, EventArgs e)
        {
            txtBoxIVA.Text = DTConfiguracionSistema.Rows[0]["PorcentajeImpuestoSistema"].ToString();
            MascaraMoneda = DTConfiguracionSistema.Rows[0]["MascaraMonedaSistema"].ToString();
            NombreMoneda = DTConfiguracionSistema.Rows[0]["NombreMonedaSistema"].ToString();
            txtMonedaSistema.Text = DTConfiguracionSistema.Rows[0]["NombreMonedaSistema"].ToString();
            dtGVTransaccion.AutoGenerateColumns = false;
            dtGVTransaccion.DataSource = DTTransaccion;
            object detallePrecioTotal = DTTransaccion.Compute("sum(PrecioTotal)", "");
            txtBoxImporteTotal.Text = detallePrecioTotal.ToString() + " " + MascaraMoneda;

            cBoxMonedas.DataSource = DTMonedas;
            cBoxMonedas.DisplayMember = "NombreMoneda";
            cBoxMonedas.ValueMember = "CodigoMoneda";
        }

        public void DarEstiloParaVentas()
        {
            switch (EstadoTransaccion)
            {
                case 'I':
                    DarEstiloParaTransaccionIniciada();
                    break;
                case 'F':
                    DGCCantidad.DataPropertyName = "CantidadVenta";
                    DGCCodigoProducto.DataPropertyName = "CodigoProducto";
                    DGCNombreProducto.DataPropertyName = "NombreProducto";
                    DGCPrecioTotal.DataPropertyName = "PrecioTotal";
                    DGCPrecioUnitario.DataPropertyName = "PrecioUnitarioVenta";
                    break;
            }
            TipoTransaccion = 'V';
        }

        public void DarEstiloParaVentasServicios(DataTable DTServiciosDetalle)
        {
            _TransaccionesUtilidadesCLN.DTVentasServiciosDetalle = DTServiciosDetalle;
            switch (EstadoTransaccion)
            {
                case 'I':
                    DGCCodigoProducto.DataPropertyName = "CodigoServicio";
                    DGCNombreProducto.DataPropertyName = "NombreServicio";                    
                    DGCPrecioTotal.DataPropertyName = "PrecioTotal";
                    DGCCantidad.DataPropertyName = "Cantidad";
                    DGCPrecioUnitario.DataPropertyName = "Precio";
                    break;
                case 'F':
                    DGCCantidad.DataPropertyName = "CantidadVentaServicio";
                    DGCCodigoProducto.DataPropertyName = "CodigoServicio";
                    DGCNombreProducto.DataPropertyName = "NombreServicio";
                    DGCPrecioTotal.DataPropertyName = "PrecioTotal";
                    DGCPrecioUnitario.DataPropertyName = "PrecioUnitario";
                    break;
            }
            TipoTransaccion = 'S';
        }

        public void DarEstiloParaCotizaciones()
        {
            switch (EstadoTransaccion)
            {
                case 'I':
                    DarEstiloParaTransaccionIniciada();
                    break;
                case 'F':
                    DGCCantidad.DataPropertyName = "CantidadCotizacionVenta";
                    DGCCodigoProducto.DataPropertyName = "CodigoProducto";
                    DGCNombreProducto.DataPropertyName = "NombreProducto";
                    DGCPrecioTotal.DataPropertyName = "PrecioTotal";
                    DGCPrecioUnitario.DataPropertyName = "PrecioUnitarioCotizacionVenta";

                    break;
            }
            TipoTransaccion = 'T';
        }
        public void DarEstiloParaCompras()
        {
            switch (EstadoTransaccion)
            {
                case 'I':
                    DarEstiloParaTransaccionIniciada();
                    break;
                case 'F':
                    DGCCantidad.DataPropertyName = "CantidadCompra";
                    DGCCodigoProducto.DataPropertyName = "CodigoProducto";
                    DGCNombreProducto.DataPropertyName = "NombreProducto";
                    DGCPrecioTotal.DataPropertyName = "PrecioTotal";
                    DGCPrecioUnitario.DataPropertyName = "PrecioUnitarioCompra";
                    break;
            }
            TipoTransaccion = 'C';
        }
        protected void DarEstiloParaTransaccionIniciada()
        {            
            DGCCodigoProducto.DataPropertyName = "Código Producto";
            DGCNombreProducto.DataPropertyName = "Nombre Producto";
            DGCCantidad.DataPropertyName = "Cantidad";            
            DGCPrecioUnitario.DataPropertyName = "Precio";
            DGCPrecioTotal.DataPropertyName = "PrecioTotal";
        }

        private void btnConvertir_Click(object sender, EventArgs e)
        {
            if (checkUltimaCotizacionMoneda.Checked)
            {
                if (EstadoTransaccion == 'I')
                {
                    DTTransaccionTemporal = _TransaccionesUtilidadesCLN.CambiarMonedaCotizacionDetalleDeTransaccionTemporal(DTTransaccion, NumeroAgencia, Int32.Parse(cBoxMonedas.SelectedValue.ToString()), null, checkIncluirIva.Checked, false);
                }
                if (EstadoTransaccion == 'F')
                {
                    DTTransaccionTemporal = _TransaccionesUtilidadesCLN.CambiarMonedaCotizacionDetalleDeTransaccion(NumeroAgencia, Int32.Parse(cBoxMonedas.SelectedValue.ToString()), null, checkIncluirIva.Checked, TipoTransaccion, NumeroTransaccion, false);
                }
            }
            else
            {
                if (EstadoTransaccion == 'I')
                {
                    DTTransaccionTemporal = _TransaccionesUtilidadesCLN.CambiarMonedaCotizacionDetalleDeTransaccionTemporal(DTTransaccion, NumeroAgencia, Int32.Parse(cBoxMonedas.SelectedValue.ToString()), dateTimePicker1.Value, checkIncluirIva.Checked, false);
                }
                if (EstadoTransaccion == 'F')
                {
                    DTTransaccionTemporal = _TransaccionesUtilidadesCLN.CambiarMonedaCotizacionDetalleDeTransaccion(NumeroAgencia, Int32.Parse(cBoxMonedas.SelectedValue.ToString()), dateTimePicker1.Value, checkIncluirIva.Checked, TipoTransaccion, NumeroTransaccion, false);
                }
            }

            if (DTTransaccionTemporal == null)
            {
                MessageBox.Show("No Existe una Taza de Cambio o Cotización para la fecha que Introdució");
            }
            else
            {
                dtGVTransaccion.DataSource = DTTransaccionTemporal;
                object detallePrecioTotal = DTTransaccionTemporal.Compute("sum(PrecioTotal)", "");
                DataRow filaMoneda = DTMonedas.Rows.Find(cBoxMonedas.SelectedValue);
                if (filaMoneda != null)

                    txtBoxImporteTotal.Text = detallePrecioTotal.ToString() + " " + filaMoneda["MascaraMoneda"].ToString().Trim(); ;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtGVTransaccion.DataSource = DTTransaccion;
            object detallePrecioTotal = DTTransaccion.Compute("sum(PrecioTotal)", "");
            txtBoxImporteTotal.Text = detallePrecioTotal.ToString() + " " + MascaraMoneda;
        }

        private void btnNuevaCotizacion_Click(object sender, EventArgs e)
        {
            FMonedasCotizaciones fmonedasCotizaciones = new FMonedasCotizaciones(true, false, false, true);
            fmonedasCotizaciones.ShowDialog(this);
            fmonedasCotizaciones.Dispose();
        }

        private void btnNuevaMoneda_Click(object sender, EventArgs e)
        {
            FMonedas fmonedas = new FMonedas();
            fmonedas.ShowDialog(this);
            fmonedas.Dispose();

            DTMonedas = _MonedasCLN.ListarMonedas();
            cBoxMonedas.DataSource = DTMonedas;
            cBoxMonedas.DisplayMember = "NombreMoneda";
            cBoxMonedas.ValueMember = "CodigoMoneda";

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FCambiarMonedaCotizacionDeTransaccionesGC_Load_1(object sender, EventArgs e)
        {
            DGCNombreProducto.Width = 200;
            DGCCodigoProducto.Width = 80;
        }
    }
}
