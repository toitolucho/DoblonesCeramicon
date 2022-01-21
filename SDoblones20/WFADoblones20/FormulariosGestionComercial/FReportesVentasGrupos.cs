using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WFADoblones20.FormulariosGestionComercial;
using WFADoblones20.FormulariosSistema;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FReportesVentasGrupos : Form
    {
        CLCLN.GestionComercial.VentasProductosCLN _VentasProductosCLN = new CLCLN.GestionComercial.VentasProductosCLN();
        DataTable DTReportesVentas = null;
        protected int NumeroAgencia;
        string TipoReporte = "Usuarios";
        FReportesVentasAgrupaciones formReportesGrupos;
        Button btnCerrarReporte;

        public FReportesVentasGrupos(int NumeroAgencia)
        {
            InitializeComponent();
            this.NumeroAgencia = NumeroAgencia;

            this.btnCerrarReporte = new Button();
            btnCerrarReporte.Click += new EventHandler(btnCerrarReporte_Click);
            this.CancelButton = btnCerrarReporte;
        }

        void btnCerrarReporte_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {            
            if (rBtnPorClientes.Checked)
            {
                int? CodigoCliente = null;
                if (checkSeleccionarCliente.Checked)
                {
                    FBuscarClientes formBuscarProductos = new FBuscarClientes();
                    formBuscarProductos.StartPosition = FormStartPosition.CenterScreen;
                    formBuscarProductos.ShowDialog(this);
                    CodigoCliente = formBuscarProductos.CodigoCliente;
                }
                TipoReporte = "Clientes";
                DTReportesVentas = _VentasProductosCLN.ListarVentasProductosPorClientesReporte(CodigoCliente, NumeroAgencia);
                formReportesGrupos = new FReportesVentasAgrupaciones(DTReportesVentas, TipoReporte);
                formReportesGrupos.Show();
            }
            if (rBtnPorCreditos.Checked)
            {
                TipoReporte = "Creditos";
                int? NumeroCredito = null;
                if (checkSeleccionarCredito.Checked)
                {
                    //lanzar ventana para buscar venta de Credito
                }
                DTReportesVentas = _VentasProductosCLN.ListarVentasProductosCreditosReporte(NumeroAgencia);
                formReportesGrupos = new FReportesVentasAgrupaciones(DTReportesVentas, TipoReporte);
                formReportesGrupos.Show();
            }
            if (rBtnPorFecha.Checked)
            {
                TipoReporte = "Fechas";
                DTReportesVentas = _VentasProductosCLN.ListarVentasProductosPorRangoFechasReporte(dateTimePicker1.Value, dateTimePicker2.Value, NumeroAgencia);
                formReportesGrupos = new FReportesVentasAgrupaciones(DTReportesVentas, TipoReporte);
                formReportesGrupos.Show();
            }
            if (rBtnPorProductos.Checked)
            {
                string CodigoProducto = null;
                if (checkSeleccionarProducto.Checked)
                {
                    FBuscarProductos formBuscarProductos = new FBuscarProductos();
                    formBuscarProductos.StartPosition = FormStartPosition.CenterScreen;
                    formBuscarProductos.ShowDialog(this);
                    CodigoProducto = formBuscarProductos.CodigoProducto;
                }
                TipoReporte = "Productos";
                DTReportesVentas = _VentasProductosCLN.ListarVentasProductosPorProductosReporte(CodigoProducto, NumeroAgencia);
                formReportesGrupos = new FReportesVentasAgrupaciones(DTReportesVentas, TipoReporte);
                formReportesGrupos.Show();
            }
            if (rBtnPorUsuarios.Checked)
            {
                int? CodigoUsuario = null;
                if (checkSeleccionarUsuarios.Checked)
                {
                    FBuscarUsuarios formBuscarUsuarios = new FBuscarUsuarios();
                    formBuscarUsuarios.StartPosition = FormStartPosition.CenterScreen;
                    formBuscarUsuarios.ShowDialog();
                    CodigoUsuario = formBuscarUsuarios.CodigoUsuario;
                }
                TipoReporte = "Usuarios";
                DTReportesVentas = _VentasProductosCLN.ListarVentasProductosPorUsuariosReporte(NumeroAgencia, CodigoUsuario);
                formReportesGrupos = new FReportesVentasAgrupaciones(DTReportesVentas, TipoReporte);
                formReportesGrupos.Show();
            }
            if (rBtnMasVendidos.Checked)
            {
                int Top = 10;
                if (Int32.TryParse(txtBoxTopMasVendidos.Text.Trim(), out Top))
                {
                    DTReportesVentas = _VentasProductosCLN.ListarProductosMasVendidosReporte(NumeroAgencia, Top);    
                }
                else
                    DTReportesVentas = _VentasProductosCLN.ListarProductosMasVendidosReporte(NumeroAgencia, 10);
                TipoReporte = "MasVendidos";                
                formReportesGrupos = new FReportesVentasAgrupaciones(DTReportesVentas, TipoReporte);
                formReportesGrupos.Show();
            }
            if (rBtnMenosVendidos.Checked)
            {
                int Top = 10;
                if (Int32.TryParse(txtBoxTopMasVendidos.Text.Trim(), out Top))
                {
                    DTReportesVentas = _VentasProductosCLN.ListarProductosMenosVendidosReporte(NumeroAgencia, Top);
                }
                else
                    DTReportesVentas = _VentasProductosCLN.ListarProductosMenosVendidosReporte(NumeroAgencia, 10);
                TipoReporte = "MenosVendidos";
                formReportesGrupos = new FReportesVentasAgrupaciones(DTReportesVentas, TipoReporte);
                formReportesGrupos.Show();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();            
        }
    }
}
