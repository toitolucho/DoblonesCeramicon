using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.GestionComercial;
namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FObservacionesTransaccionesModificacion : Form
    {
        private string TipoTransaccion;
        private int CodigoUsuario;
        private int NumeroAgencia;
        private int NumeroTransaccion;
        VentasProductosCLN _VentasProductosCLN;
        ComprasProductosCLN _ComprasProductosCLN;
        CotizacionVentasProductosCLN _CotizacionVentasProductosCLN;
        TransferenciasProductosCLN _TransferenciasProductosCLN;
        VentasProductosDevolucionesCLN _VentasProductosDevolucionesCLN;
        ComprasProductosDevolucionesCLN _ComprasProductosDevolucionesCLN;

        public TextBox TxtBoxObservaciones
        {
            get { return this.txtBoxObservaciones; }
        }

        public FObservacionesTransaccionesModificacion(string TipoTransaccion, int codigoUsuario, int NumeroAgencia, int NumeroTransaccion)
        {
            InitializeComponent();
            this.TipoTransaccion = TipoTransaccion;
            this.CodigoUsuario = codigoUsuario;
            this.NumeroAgencia = NumeroAgencia;
            this.NumeroTransaccion = NumeroTransaccion;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (TipoTransaccion)
            {
                case "V"://ventas
                    _VentasProductosCLN = new VentasProductosCLN();
                    _VentasProductosCLN.ActualizarVentaProducto(NumeroAgencia, NumeroTransaccion, txtBoxObservaciones.Text);
                    break;
                case "C"://compras
                    _ComprasProductosCLN = new ComprasProductosCLN();
                    _ComprasProductosCLN.ActualizarCompraProducto(NumeroAgencia, NumeroTransaccion, txtBoxObservaciones.Text);
                    break;
                case "T"://cotizaciones
                    _CotizacionVentasProductosCLN = new CotizacionVentasProductosCLN();
                    _CotizacionVentasProductosCLN.ActualizarCotizacionVentaProducto(NumeroAgencia, NumeroTransaccion, txtBoxObservaciones.Text);
                    break;
                case "F"://transferencias
                    _TransferenciasProductosCLN = new TransferenciasProductosCLN();
                    _TransferenciasProductosCLN.ActualizarTransferenciaProducto(NumeroAgencia, NumeroTransaccion, txtBoxObservaciones.Text);
                    break;
                case "D": //devolucion venta
                    _VentasProductosDevolucionesCLN = new VentasProductosDevolucionesCLN();
                    _VentasProductosDevolucionesCLN.ActualizarVentaProductoReemDevo(NumeroAgencia, NumeroTransaccion, txtBoxObservaciones.Text);
                    break;
                case "P": //devolucion compra
                    _ComprasProductosDevolucionesCLN = new ComprasProductosDevolucionesCLN();
                    _ComprasProductosDevolucionesCLN.ActualizarCompraProductoDevolucion(NumeroAgencia, NumeroTransaccion, txtBoxObservaciones.Text);
                    break;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FObservacionesTransaccionesModificacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK &&
                MessageBox.Show(this, "¿Se encuentra seguro de cancelar la Operación actual?", "Modificación de Observaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;

        }
    }
}
