using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using CLCAD;
using CLCLN.GestionComercial;
using CLCLN.Sistema;
namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FVentasServiciosBuscador : Form
    {

        DSDoblones20GestionComercial2.BuscarVentaServicioDataTable DTBusquedaVentaServicio;
        DataTable VariablesConfiguracionSistemaGC;
        VentasServiciosCLN _VentasServiciosCLN;
        PCsConfiguracionesCLN PCConfiguracion;
        TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;
        ArrayList ListaCodigosEstadoCompra = new ArrayList();

        public int NumeroAgencia { get; set; }
        private int NumeroPC = 0;
        public int CodigoUsuario { get; set; }
        public int NumeroTransaccion { get; set; }
        private string TipoOperacion = "";

        #region Propiedades de Configuración de Arranque del Sistema
        public decimal PorcentajeImpuestoSistema { get; set; }
        public int CodigoMonedaSistema { get; set; }
        public int CodigoMonedaRegion { get; set; }
        public string MascaraMonedaSistema { get; set; }
        public string MascaraMonedaRegion { get; set; }
        public string NombreMonedaSistema { get; set; }
        public string NombreMonedaRegion { get; set; }
        public bool ContabilidadIntegrada { get; set; }
        #endregion

        public FVentasServiciosBuscador(int NumeroAgencia, int NumeroPC, int CodigoUsuario)
        {
            InitializeComponent();

            this.NumeroAgencia = NumeroAgencia;
            this.NumeroPC = NumeroPC;
            this.CodigoUsuario = CodigoUsuario;

            txtBoxNumeroTransaccion.Clear();
            txtBoxTextoBusqueda.Clear();
            this.lblNroTransaccion.Text = "Nro Venta Serivicio";
            this.cBoxBuscarPor.Items.Clear();
            this.cBoxBuscarPor.Items.Add("Nombre Cliente");
            this.cBoxBuscarPor.Items.Add("NIT Cliente");
            this.cBoxBuscarPor.Items.Add("Nombre Servicio");
            this.cBoxBuscarPor.Items.Add("Observaciones");
            this.cBoxBuscarPor.SelectedIndex = 0;

            _VentasServiciosCLN = new VentasServiciosCLN();
            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();

            #region Inicio codigo agregado
            VariablesConfiguracionSistemaGC = new DataTable();
            PCConfiguracion = new PCsConfiguracionesCLN();
            VariablesConfiguracionSistemaGC = PCConfiguracion.ObtenerConfiguracionSistemaParaTransaccionesGC(NumeroPC);

            this.CodigoMonedaSistema = int.Parse(VariablesConfiguracionSistemaGC.Rows[0][3].ToString());
            this.NombreMonedaSistema = VariablesConfiguracionSistemaGC.Rows[0][4].ToString();
            this.MascaraMonedaSistema = VariablesConfiguracionSistemaGC.Rows[0][5].ToString();
            this.CodigoMonedaRegion = int.Parse(VariablesConfiguracionSistemaGC.Rows[0][6].ToString());
            this.NombreMonedaRegion = VariablesConfiguracionSistemaGC.Rows[0][7].ToString();
            this.MascaraMonedaRegion = VariablesConfiguracionSistemaGC.Rows[0][8].ToString();
            this.PorcentajeImpuestoSistema = decimal.Parse(VariablesConfiguracionSistemaGC.Rows[0][9].ToString());
            this.ContabilidadIntegrada = bool.Parse(VariablesConfiguracionSistemaGC.Rows[0][10].ToString());
            #endregion Fin codigo agregado

            DGCNumeroAgencia.Width = 75;
            DGCNumeroVentaServicio.Width = 100;
            DGCFechaHoraVentaServicio.Width = 165;
            DGCObservaciones.Width = 250;
            dtGVTransacciones.CellDoubleClick += new DataGridViewCellEventHandler(dtGVTransacciones_CellDoubleClick);
            formatearParaBusquedasGeneral();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        void dtGVTransacciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtGVTransacciones.RowCount > 0 && dtGVTransacciones.CurrentRow != null)
            {

                this.NumeroTransaccion = int.Parse(DTBusquedaVentaServicio.DefaultView[e.RowIndex][DTBusquedaVentaServicio.NumeroVentaServicioColumn.ColumnName].ToString());                
                string CodigoEstadoVentaServicio = DTBusquedaVentaServicio.DefaultView[e.RowIndex][DTBusquedaVentaServicio.CodigoEstadoServicioColumn.ColumnName].ToString();

                switch (TipoOperacion)
                {
                    case "A": //Recepción en Almacenes                        
                        //FCompraProductosAdministradorIngresoInventarios _FCompraProductosAdministradorIngresoInventarios = new FCompraProductosAdministradorIngresoInventarios(NumeroAgencia, NumeroPC, NumeroTransaccion, CodigoUsuario);
                        ////_FCompraProductosAdministradorIngresoInventarios.
                        //_FCompraProductosAdministradorIngresoInventarios.ShowDialog();
                        //_FCompraProductosAdministradorIngresoInventarios.Dispose();
                        //DTBusquedaVentaServicio[e.RowIndex].CodigoEstadoServicio = _TransaccionesUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(NumeroAgencia, NumeroTransaccion, "S");                        
                        break;
                    case "C": //Cancelacion y pago para el Contador                        
                        //FCompraProductosAdministradorPagos _FCompraProductosAdministradorPagos = new FCompraProductosAdministradorPagos(NumeroAgencia, NumeroTransaccion);
                        //_FCompraProductosAdministradorPagos.MascaraMoneda = MascaraMonedaSistema;
                        //_FCompraProductosAdministradorPagos.ShowDialog();
                        //_FCompraProductosAdministradorPagos.Dispose();                        
                        break;
                    case "N": //Navegación                        
                        FVentasServicios _FVentasServicios = new FVentasServicios(NumeroPC, NumeroAgencia, CodigoUsuario);
                        _FVentasServicios.cargarDatosVentasServcios(NumeroTransaccion);
                        _FVentasServicios.ShowDialog(this);
                        _FVentasServicios.Dispose();
                        break;
                    default:
                        break;
                }

                CodigoEstadoVentaServicio = _TransaccionesUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(NumeroAgencia, NumeroTransaccion, "C");
                DTBusquedaVentaServicio[e.RowIndex].CodigoEstadoServicio = CodigoEstadoVentaServicio;
                DTBusquedaVentaServicio[e.RowIndex].EstadoVentaServicio = EstadoVentaServicio.obtenerSignificadoEstado(CodigoEstadoVentaServicio);


            }
           
        }

        private void FVentasServiciosBuscador_Load(object sender, EventArgs e)
        {
            DTBusquedaVentaServicio = _VentasServiciosCLN.BuscarVentaServicio("0", " ", NumeroAgencia, null, null, DateTime.Now, DateTime.Now, false);
            bdSourceTransacciones.DataSource = DTBusquedaVentaServicio;
            dtGVTransacciones.DataSource = bdSourceTransacciones;
            statusStrip1.Items[0].Text = "Numero de registros encontrados: " + bdSourceTransacciones.Count.ToString();
            DGCNumeroAgencia.Width = 85;
            DGCNombreCliente.Width = 200;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(txtBoxNumeroTransaccion.Text.Trim()) && String.IsNullOrEmpty(txtBoxTextoBusqueda.Text))
            {
                MessageBox.Show(this, "Aun no ha ingresado un Texto a Buscar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DTBusquedaVentaServicio.Clear();
                int NumeroTransaccion = -1;
                if (txtBoxNumeroTransaccion.Text.Trim().Length > 0 && txtBoxNumeroTransaccion.Text != null)
                {
                    NumeroTransaccion = Int32.Parse(txtBoxNumeroTransaccion.Text);
                }

                DTBusquedaVentaServicio = _VentasServiciosCLN.BuscarVentaServicio(cBoxBuscarPor.SelectedIndex.ToString(), txtBoxTextoBusqueda.Text.Trim(), NumeroAgencia, NumeroTransaccion, cBoxCodigoEstadoVenta.SelectedValue.Equals("T") ? null : cBoxCodigoEstadoVenta.SelectedValue.ToString(), dateTimePicker1.Value, dateTimePicker2.Value, checkTextoIdentico.Checked);
                bdSourceTransacciones.DataSource = DTBusquedaVentaServicio;
                dtGVTransacciones.DataSource = bdSourceTransacciones;

                if (DTBusquedaVentaServicio.Rows.Count == 0)
                    DTBusquedaVentaServicio.Rows.Clear();
                statusStrip1.Items[0].Text = "Numero de registros encontrados: " + bdSourceTransacciones.Count.ToString();
                if (txtBoxNumeroTransaccion.Focused)
                    txtBoxNumeroTransaccion.SelectAll();
                else if (txtBoxTextoBusqueda.Focused)
                    txtBoxTextoBusqueda.SelectAll();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBoxNumeroTransaccion.Clear();
            txtBoxTextoBusqueda.Clear();
            this.DTBusquedaVentaServicio.Clear();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBoxTextoBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click(sender, e as EventArgs);
            }
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                if (dtGVTransacciones.RowCount > 0)
                {
                    dtGVTransacciones.Focus();
                    dtGVTransacciones.Columns[3].Selected = true;
                    dtGVTransacciones.CurrentCell = dtGVTransacciones.Rows[0].Cells[3];
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.txtBoxTextoBusqueda.Clear();
                this.txtBoxNumeroTransaccion.Clear();
                this.txtBoxTextoBusqueda.Focus();
            }    
        }

        public void formatearParaBusquedaRecepcion()
        {
            ListaCodigosEstadoCompra.Add(new EstadoVenta("P", "Pagadas"));
            ListaCodigosEstadoCompra.Add(new EstadoVenta("D", "En Espera de Recepción(Pendientes)"));
            ListaCodigosEstadoCompra.Add(new EstadoVenta("T", "Todas"));

            this.cBoxCodigoEstadoVenta.DataSource = ListaCodigosEstadoCompra;
            this.cBoxCodigoEstadoVenta.ValueMember = "CodigoEstadoVenta";
            this.cBoxCodigoEstadoVenta.DisplayMember = "Descripcion";
            this.cBoxCodigoEstadoVenta.SelectedValue = "P";

            TipoOperacion = "A";

            this.Text = "Administrador de Compras para Recepción de Mercadería";
        }

        public void formatearParaPagosCancelacionMonetaria()
        {
            ListaCodigosEstadoCompra.Add(new EstadoVenta("I", "Iniciadas"));
            ListaCodigosEstadoCompra.Add(new EstadoVenta("P", "Pagadas"));
            ListaCodigosEstadoCompra.Add(new EstadoVenta("D", "Pendientes"));
            ListaCodigosEstadoCompra.Add(new EstadoVenta("T", "Todas"));

            this.cBoxCodigoEstadoVenta.DataSource = ListaCodigosEstadoCompra;
            this.cBoxCodigoEstadoVenta.ValueMember = "CodigoEstadoVenta";
            this.cBoxCodigoEstadoVenta.DisplayMember = "Descripcion";
            this.cBoxCodigoEstadoVenta.SelectedValue = "I";

            TipoOperacion = "C";

            this.Text = "Administrador de Compras para cancelación, pago y gastos";
        }


        public void formatearParaBusquedasGeneral()
        {
            ListaCodigosEstadoCompra.Add(new EstadoVenta("F", "Finalizadas"));
            ListaCodigosEstadoCompra.Add(new EstadoVenta("I", "Iniciadas"));
            ListaCodigosEstadoCompra.Add(new EstadoVenta("A", "Anuladas"));
            ListaCodigosEstadoCompra.Add(new EstadoVenta("P", "Pagadas"));
            ListaCodigosEstadoCompra.Add(new EstadoVenta("C", "Cotizaciones"));
            ListaCodigosEstadoCompra.Add(new EstadoVenta("V", "Ventas"));
            ListaCodigosEstadoCompra.Add(new EstadoVenta("X", "Finalizadas Incompletas"));
            ListaCodigosEstadoCompra.Add(new EstadoVenta("T", "Todas"));


            this.cBoxCodigoEstadoVenta.DataSource = ListaCodigosEstadoCompra;
            this.cBoxCodigoEstadoVenta.ValueMember = "CodigoEstadoVenta";
            this.cBoxCodigoEstadoVenta.DisplayMember = "Descripcion";
            this.cBoxCodigoEstadoVenta.SelectedValue = "T";

            TipoOperacion = "N";


        }

        private void txtBoxNumeroTransaccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & (Keys)e.KeyChar != Keys.Enter)
            {
                e.Handled = true;
                txtBoxNumeroTransaccion.SelectionStart = 0;
                txtBoxNumeroTransaccion.SelectionLength = txtBoxNumeroTransaccion.Text.Length;
                System.Media.SystemSounds.Beep.Play();
                return;
            }
        }
    }

    public class EstadoVentaServicio
    {
        private string _codigoEstadoVentaServicio;
        private string _descripcion;

        public string CodigoEstadoVentaServicio
        {
            get { return _codigoEstadoVentaServicio; }
            set { _codigoEstadoVentaServicio = value; }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public EstadoVentaServicio()
        {

        }
        public EstadoVentaServicio(string codigoEstadoVenta, string descripcion)
        {
            this._codigoEstadoVentaServicio = codigoEstadoVenta;
            this._descripcion = descripcion;
        }


        public static string obtenerSignificadoEstado(string estadoCompra)
        {            
            switch (estadoCompra)
            {
                case "I":
                    return "INICIADA";
                case "A":
                    return "ANULADA";
                case "P":
                    return "PAGADA";
                case "D":
                    return "PENDIENTE";
                case "F":
                    return "FINALIZADO";
                case "C":
                    return "SERVICIO PARA COTIZACIONES";
                case "V":
                    return "SERVICIO PARA VENTAS";
                case "X":
                    return "FINALIZADO INCOMPLETO";
                default:
                    return "INDETERMINADO";
            }
        }
    }
}
 