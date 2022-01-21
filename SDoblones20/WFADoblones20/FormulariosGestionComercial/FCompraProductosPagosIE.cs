using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCAD;
using CLCLN.GestionComercial;
using CLCLN.Contabilidad;
using CLCLN.Sistema;
namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FCompraProductosPagosIE : Form
    {
        private int NumeroAgencia;
        private int CodigoUsuario;
        private int NumeroCompraProducto;
        private int NumeroConfiguracionCuenta;
        private int CodigoMonedaSistema;
        string MascaraMonedaSistema;
        public decimal MontoTotalPagoCompra{get; set;}

        TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;
        ComprasProductosPagosDetalleCLN _ComprasProductosPagosDetalleCLN;
        ProveedoresCLN _ProveedoresCLN;
        CuentasConfiguracionCLN _CuentasConfiguracionCLN;
        ComprasProductosCLN _ComprasProductosCLN;
        MonedasCLN _MonedasCLN;

        DSDoblones20GestionComercial.ProveedoresDataTable DTProveedores;
        DSDoblones20GestionComercial2.ComprasProductosPagosDetalleDataTable DTComprasProductosPagosDetalle;
        DSDoblones20Contabilidad.ListarConfiguracionesCuentasDetallePorNumeroConfiguracionDHDataTable DTCuentasDisponibles;
        DSDoblones20GestionComercial.ComprasProductosDataTable DTCompraProducto;
        DataTable DTMonedas;
        DataTable DTDetallePagosTemporal;

        private const string CodigoTipoDebeHaber = "D";

        public FCompraProductosPagosIE(int NumeroAgencia, int CodigoUsuario, int NumeroCompraProducto,
            int NumeroConfiguracionCuenta, int CodigoMonedaSistema)
        {
            InitializeComponent();
            this.NumeroAgencia = NumeroAgencia;
            this.CodigoUsuario = CodigoUsuario;
            this.NumeroCompraProducto = NumeroCompraProducto;
            this.NumeroConfiguracionCuenta = NumeroConfiguracionCuenta;
            this.CodigoMonedaSistema = CodigoMonedaSistema;

            _ComprasProductosPagosDetalleCLN = new ComprasProductosPagosDetalleCLN();
            _CuentasConfiguracionCLN = new CuentasConfiguracionCLN();
            _ProveedoresCLN = new ProveedoresCLN();
            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();
            _ComprasProductosCLN = new ComprasProductosCLN();
            _MonedasCLN = new MonedasCLN();

            DTProveedores = new DSDoblones20GestionComercial.ProveedoresDataTable();
            DTComprasProductosPagosDetalle = new DSDoblones20GestionComercial2.ComprasProductosPagosDetalleDataTable();
            DTCuentasDisponibles = new DSDoblones20Contabilidad.ListarConfiguracionesCuentasDetallePorNumeroConfiguracionDHDataTable();
            DTCompraProducto = new DSDoblones20GestionComercial.ComprasProductosDataTable();
            

            txtBoxProveedor.ReadOnly = txtBoxProveedorCuentaBanco.ReadOnly = 
                txtBoxProveedorNIT.ReadOnly = txtBoxProveedorTelf.ReadOnly = true;

            DTDetallePagosTemporal = new DataTable("DetallePagosTemporal");
            DataColumn DCNumeroCuentaConfiguracion = new DataColumn("NumeroCuentaConfiguracion", Type.GetType("System.String"));
            DataColumn DCNombreCuenta = new DataColumn("NombreCuenta", Type.GetType("System.String"));            
            DataColumn DCMontoCanceladoMoneda = new DataColumn("MontoCanceladoMoneda", Type.GetType("System.Decimal"));
            DataColumn DCCodigoMoneda = new DataColumn("CodigoMoneda", Type.GetType("System.Byte"));
            DCCodigoMoneda.DefaultValue = CodigoMonedaSistema;
            DataColumn DCMontoCancelado = new DataColumn("MontoCancelado", Type.GetType("System.Decimal"));            
            DCMontoCancelado.DefaultValue = 0;
            DTDetallePagosTemporal.Columns.AddRange(new DataColumn[] { 
                DCNumeroCuentaConfiguracion, 
                DCNombreCuenta, 
                DCMontoCanceladoMoneda, 
                DCCodigoMoneda, 
                DCMontoCancelado });
            DTDetallePagosTemporal.PrimaryKey = new DataColumn[] { DCNumeroCuentaConfiguracion };
            
            
            DTDetallePagosTemporal.RowChanged += new DataRowChangeEventHandler(DTDetallePagosTemporal_RowChanged);

        }

        void DTDetallePagosTemporal_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            if(DTCompraProducto != null && DTCompraProducto.Count > 0)
            {
                decimal MontoCompra = MontoTotalPagoCompra;
                decimal MontoPagado = decimal.Parse(DTDetallePagosTemporal.Compute("Sum(MontoCancelado)", "").ToString());
                txtBoxMontoPagado.Text = MontoPagado.ToString() + " " + MascaraMonedaSistema;
                txtBoxMontoDiferencia.Text = decimal.Round((MontoCompra - MontoPagado),2).ToString() + " " + MascaraMonedaSistema;
                txtBoxMonto.Text = decimal.Round((MontoCompra - MontoPagado), 2).ToString();
            }
        }

        private void FCompraProductosPagosIE_Load(object sender, EventArgs e)
        {

            try
            {
                DTCuentasDisponibles = _CuentasConfiguracionCLN.ListarConfiguracionesCuentasDetallePorNumeroConfiguracionDH(NumeroConfiguracionCuenta, CodigoTipoDebeHaber);
                cboxCuentas.DataSource = DTCuentasDisponibles;
                cboxCuentas.DisplayMember = "NombreCuenta";
                cboxCuentas.ValueMember = "NumeroCuentaConfiguracion";
                cboxCuentas.SelectedIndex = -1;

                DTMonedas = _MonedasCLN.ListarMonedas();

                DGCNombreMoneda.DataSource = DTMonedas.Copy();
                DGCNombreMoneda.DataPropertyName = "CodigoMoneda";
                DGCNombreMoneda.ValueMember = "CodigoMoneda";
                DGCNombreMoneda.DisplayMember = "NombreMoneda";
                

                cboxMoneda.DataSource = DTMonedas;
                cboxMoneda.DisplayMember = "NombreMoneda";
                cboxMoneda.ValueMember = "CodigoMoneda";
                cboxMoneda.SelectedValue = CodigoMonedaSistema;

                bdSourcePagosDetalle.DataSource = DTDetallePagosTemporal;

                MascaraMonedaSistema = DTMonedas.Rows.Find(CodigoMonedaSistema)["MascaraMoneda"].ToString();
                DGCMontoPago.HeaderText = "Monto Moneda(" + MascaraMonedaSistema + ")";

                cargarDatos();
                lblDatosTransaccion.Text = "Moneda Sistema :" + DTMonedas.Rows.Find(CodigoMonedaSistema)["NombreMoneda"].ToString()
                    + "(" + MascaraMonedaSistema + ")";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio la siguiente Excepcion " + ex.Message);

            }
        }

        public void cargarDatos()
        {
            DTCompraProducto = (DSDoblones20GestionComercial.ComprasProductosDataTable)_ComprasProductosCLN.ObtenerCompraProducto(NumeroAgencia, NumeroCompraProducto);
            if (DTCompraProducto.Count > 0)
            {
                DTProveedores = (DSDoblones20GestionComercial.ProveedoresDataTable)_ProveedoresCLN.ObtenerProveedor(DTCompraProducto[0].CodigoProveedor);

                txtBoxProveedor.Text = DTProveedores[0].NombreRazonSocial;
                txtBoxProveedorCuentaBanco.Text = DTProveedores[0].IsNumeroCuentaBancoNull() ? "" : DTProveedores[0].NumeroCuentaBanco;
                txtBoxProveedorNIT.Text = DTProveedores[0].IsNITProveedorNull() ? "" : DTProveedores[0].NITProveedor;
                txtBoxProveedorTelf.Text = DTProveedores[0].IsTelefonoNull() ? "" : DTProveedores[0].Telefono;
                MontoTotalPagoCompra = _TransaccionesUtilidadesCLN.EsCompraCreditoEfectivo(NumeroAgencia, NumeroCompraProducto);
                MontoTotalPagoCompra = MontoTotalPagoCompra > 0 ? MontoTotalPagoCompra : DTCompraProducto[0].MontoTotalCompra;
                txtBoxMontoTotalCompra.Text = MontoTotalPagoCompra + " " + MascaraMonedaSistema;
                txtBoxMonto.Text = MontoTotalPagoCompra.ToString();
                
            }

            
            
            txtBoxMontoPagado.Text = "0.00";
            txtBoxMontoDiferencia.Text = "0.00";
        }

        bool isDecimal(String cadena)
        {
            bool flag = false;
            for (int i = 0; i < cadena.Length; i++)
            {
                char c = cadena[i];
                if ((c >= '0' && c <= '9'))
                {
                    continue;
                }
                else
                {
                    if ((c == ',') && (i != 0 && i < (cadena.Length - 1)) && (cadena[i - 1] != ','))
                    {
                        flag = true;

                    }
                    else return false;

                }
            }
            return flag;
        }

        private void txtBoxMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back &&
                (Keys)e.KeyChar != Keys.Enter
                && (Keys)e.KeyChar != (Keys)','
                )
            {                
                txtBoxMonto.SelectAll();
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
                return;
            }

            if (Keys.Enter == (Keys)e.KeyChar)
                btnAgregar_Click(btnAgregar, e as EventArgs);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            decimal MontoCancelado = 0;
            if (cboxCuentas.SelectedIndex < 0)
            {
                errorProvider1.SetError(cboxCuentas, "Aún no ha Seleccionado ninguna cuenta");
                cboxCuentas.SelectAll();
                cboxCuentas.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtBoxMonto.Text.Trim()))
            {
                errorProvider1.SetError(txtBoxMonto, "Aún no ha ingresado un Monto");
                txtBoxMonto.SelectAll();
                txtBoxMonto.Focus();
                return;
            }

            if( !Decimal.TryParse(txtBoxMonto.Text, out MontoCancelado )
                || MontoCancelado <= 0)
            {
                errorProvider1.SetError(txtBoxMonto, "El Monto ingresado no es Valido");
                txtBoxMonto.SelectAll();
                txtBoxMonto.Focus();
                return;
            }

            if(DTDetallePagosTemporal.Rows.Find(DTCuentasDisponibles[cboxCuentas.SelectedIndex].NumeroCuentaConfiguracion) != null) 
            {
                MessageBox.Show(this, "Ya ha seleccionó un pago con la Cuenta Seleccionada", "Pagos Por Compras", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(cboxCuentas, "Ya ha seleccionó un pago con la Cuenta Seleccionada");
                cboxCuentas.SelectAll();
                cboxCuentas.Focus();
                return;
            }

            string NumeroCuentaSeleccionada = DTCuentasDisponibles[cboxCuentas.SelectedIndex].NumeroCuentaConfiguracion;
            string NombreCuenta = DTCuentasDisponibles[cboxCuentas.SelectedIndex].NombreCuenta;

            decimal MontoCanceladoMonedaSistema = MontoCancelado;
            if (int.Parse(DTMonedas.Rows[cboxMoneda.SelectedIndex]["CodigoMoneda"].ToString()) != CodigoMonedaSistema)
            {
                decimal FactorCambio = _TransaccionesUtilidadesCLN.ObtenerFactorCambioCotizacion(CodigoMonedaSistema, _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor(),
                    int.Parse(DTMonedas.Rows[cboxMoneda.SelectedIndex]["CodigoMoneda"].ToString()));

                if(FactorCambio == -1)
                    FactorCambio = _TransaccionesUtilidadesCLN.ObtenerFactorCambioCotizacion(CodigoMonedaSistema, null,
                    int.Parse(DTMonedas.Rows[cboxMoneda.SelectedIndex]["CodigoMoneda"].ToString()));

                MontoCanceladoMonedaSistema = decimal.Round( MontoCancelado / FactorCambio ,2);
            }

            DTDetallePagosTemporal.Rows.Add(new object[]{NumeroCuentaSeleccionada, NombreCuenta,
                MontoCancelado, int.Parse(DTMonedas.Rows[cboxMoneda.SelectedIndex]["CodigoMoneda"].ToString()),
                MontoCanceladoMonedaSistema
            });
            DTDetallePagosTemporal.AcceptChanges();
            
            

        }

        private void dtGVPagosDetalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dtGVPagosDetalle.RowCount > 0 && DTDetallePagosTemporal.Rows.Count > 0)
            {
                decimal MontoCanceladoMoneda = 0;
                if (e.ColumnIndex == DGCMontoCanceladoMoneda.Index
                    || e.ColumnIndex == DGCNombreMoneda.Index)
                {
                    MontoCanceladoMoneda = decimal.Parse(dtGVPagosDetalle["DGCMontoCanceladoMoneda", e.RowIndex].Value.ToString());
                    byte CodigoMonedaSeleccionada = byte.Parse(dtGVPagosDetalle["DGCNombreMoneda", e.RowIndex].Value.ToString());
                    if (CodigoMonedaSeleccionada != CodigoMonedaSistema)
                    {
                        decimal FactorCambio = _TransaccionesUtilidadesCLN.ObtenerFactorCambioCotizacion(CodigoMonedaSistema, _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor(),
                        CodigoMonedaSeleccionada);

                        if (FactorCambio == -1)
                            FactorCambio = _TransaccionesUtilidadesCLN.ObtenerFactorCambioCotizacion(CodigoMonedaSistema, null,
                            CodigoMonedaSeleccionada);

                        dtGVPagosDetalle["DGCMontoPago", e.RowIndex].Value = decimal.Round(MontoCanceladoMoneda / FactorCambio, 2);
                    }
                    else
                    {
                        dtGVPagosDetalle["DGCMontoPago", e.RowIndex].Value = MontoCanceladoMoneda;
                    }
                    DTDetallePagosTemporal.AcceptChanges();
                }
                
            }
        }

        private void dtGVPagosDetalle_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            decimal CantidadNuevaDePago;

            this.dtGVPagosDetalle.Rows[e.RowIndex].ErrorText = "";

            // No cell validation for new rows. New rows are validated on Row Validation.
            if (this.dtGVPagosDetalle.Rows[e.RowIndex].IsNewRow) { return; }

            if (this.dtGVPagosDetalle.IsCurrentCellDirty)
            {
                switch (this.dtGVPagosDetalle.Columns[e.ColumnIndex].Name)
                {

                    case "DGCMontoCanceladoMoneda":
                        if (e.FormattedValue.ToString().Trim().Length < 1)
                        {
                            this.dtGVPagosDetalle.Rows[e.RowIndex].ErrorText = "   La Cantidad de Pago es necesaria y no puede estar vacia.";
                            e.Cancel = true;
                        }
                        else if (!decimal.TryParse(e.FormattedValue.ToString(), out CantidadNuevaDePago) || CantidadNuevaDePago < 0)
                        {
                            this.dtGVPagosDetalle.Rows[e.RowIndex].ErrorText = "   La Cantidad a entregar debe ser un entero positivo.";
                            e.Cancel = true;
                        }

                        //if (decimal.TryParse(e.FormattedValue.ToString(), out CantidadNuevaDePago))
                        //{
                        //    decimal CantidadCompra = DTCompraProducto[0].MontoTotalCompra;

                        //    if (CantidadNuevaDePago > CantidadCompra )
                        //    {
                        //        this.dtGVPagosDetalle.Rows[e.RowIndex].ErrorText = "   No puede entregar una cantidad superior a la Cantidad Requerida de Recepción.";
                        //        e.Cancel = true;
                        //    }
                        //}
                        break;


                }

            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DTDetallePagosTemporal.AcceptChanges();
        }

        private void dtGVPagosDetalle_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (DTDetallePagosTemporal.Rows.Count == 0)
            {
                MessageBox.Show(this, "Aún no ingresado ningún Monto de Pago", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            decimal MontoPagado = decimal.Parse(DTDetallePagosTemporal.Compute("sum(MontoCancelado)", "").ToString());
            decimal MontoTotalCompra = this.MontoTotalPagoCompra;
            decimal MontoDiferencia = decimal.Round(MontoTotalCompra - MontoPagado, 2);

            if (MontoDiferencia > 0)
            {
                MessageBox.Show(this, "Aún no alcanza a Pagar todo el Monto de la Compra", "Pago por Compras", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtBoxMontoPagado, "Aún no alcanza a Pagar todo el Monto de la Compra");
                return;
            }

            if (MontoDiferencia < 0)
            {
                MessageBox.Show(this, "El Monto a cancelar supera el Monto Total de la Compra", "Pago por Compras", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtBoxMontoPagado, "Aún no alcanza a Pagar todo el Monto de la Compra");
                return;
            }

            //ahora todo OK, registramos
            try
            {
                DateTime FechaHoraServidor = _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor();
                foreach (DataRow DRPago in DTDetallePagosTemporal.Rows)
                {
                    _ComprasProductosPagosDetalleCLN.InsertarCompraProductoPagoDetalle(NumeroAgencia, NumeroCompraProducto, 1,
                        FechaHoraServidor, decimal.Parse(DRPago["MontoCancelado"].ToString()), (byte)CodigoMonedaSistema,
                        DRPago["NumeroCuentaConfiguracion"].ToString(), "Observaciones");
                }

                MessageBox.Show(this, "Operación realizada correctamente", "Pago Por compras", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Ocurrio la siguiente Excepción " +ex.Message, "Pago Por compras", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
