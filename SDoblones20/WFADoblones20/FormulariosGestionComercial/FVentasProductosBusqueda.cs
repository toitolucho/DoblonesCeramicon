using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using CLCLN.GestionComercial;
using CLCLN.Sistema;
namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FVentasProductosBusqueda : Form
    {
        ArrayList ListaCodigosEstadoVenta = new ArrayList();
        DataTable DTVentasProductosBusqueda;
        DataTable VariablesConfiguracionSistemaGC;
        VentasProductosCLN _VentasProductosCLN;
        TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;
        CLCLN.Sistema.PCsConfiguracionesCLN PCConfiguracion;
        int NumeroAgencia;
        int NumeroPC = 0;
        int CodigoUsuario;

        public bool esParaPagarVenta = false;
        public bool soloNavegacion = false;
        private int numeroTransaccion = -1;
        public int NumeroTransaccion
        {
            get { return numeroTransaccion; }
            set { numeroTransaccion = value; }
        }
        string EstadoVentaActual_deEntrega = "";

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

        public FVentasProductosBusqueda(int NumeroAgencia, int NumeroPC, int CodigoUsuario)
        {
            InitializeComponent();

            this.dateTimePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            _VentasProductosCLN = new VentasProductosCLN();
            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();

            this.NumeroAgencia = NumeroAgencia;
            this.NumeroPC = NumeroPC;
            this.CodigoUsuario = CodigoUsuario;

            txtBoxNumeroTransaccion.Clear();
            txtBoxTextoBusqueda.Clear();
            this.lblNroTransaccion.Text = "Numero de Venta";
            this.cBoxBuscarPor.Items.Clear();
            this.cBoxBuscarPor.Items.Add("Nombre Cliente");
            this.cBoxBuscarPor.Items.Add("NIT Cliente");
            this.cBoxBuscarPor.Items.Add("Nombre Producto");
            this.cBoxBuscarPor.Items.Add("Observaciones");
            this.cBoxBuscarPor.SelectedIndex = 0;          

            DGCNumeroAgencia.Width = 75;
            DGCNumeroVentaProducto.Width = 100;
            DGCFechaHoraVenta.Width = 165;
            DGCObservaciones.Width = 250;
            dtGVTransacciones.CellDoubleClick +=new DataGridViewCellEventHandler(dtGVTransacciones_CellDoubleClick);
            dtGVTransacciones.DoubleClick += new EventHandler(dtGVTransacciones_DoubleClick);

            //Inicio codigo agregado
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
            //Fin codigo agregado

        }

        private void FVentasProductosBusqueda_Load(object sender, EventArgs e)
        {
            DTVentasProductosBusqueda = _VentasProductosCLN.BuscarVentaProducto("0", " ", NumeroAgencia, null, null, DateTime.Now, DateTime.Now, false);
            bdSourceTransacciones.DataSource = DTVentasProductosBusqueda;
            dtGVTransacciones.DataSource = bdSourceTransacciones;
            statusStrip1.Items[0].Text = "Numero de registros encontrados: " + bdSourceTransacciones.Count.ToString();
            DGCNumeroAgencia.Width = 85;
            DGCNombreCliente.Width = 200;
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBoxNumeroTransaccion.Clear();
            txtBoxTextoBusqueda.Clear();
            this.DTVentasProductosBusqueda.Clear();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtGVTransacciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 )
            {
                return;
            }
            this.NumeroTransaccion = Int32.Parse(dtGVTransacciones[1, e.RowIndex].Value.ToString());
            if (!soloNavegacion)
            {
                try
                {                    
                    if (esParaPagarVenta)
                    {
                        EstadoVentaActual_deEntrega = _VentasProductosCLN.obtenerEstadoVentaFinalizadaParaAlmacenes(NumeroAgencia, NumeroTransaccion);
                        if (dtGVTransacciones.CurrentCell != null)
                        {
                            string CodigoEstadoVenta = DTVentasProductosBusqueda.Rows[dtGVTransacciones.CurrentCell.RowIndex]["CodigoEstadoVenta"].ToString();
                            //if (CodigoEstadoVenta.Equals("P") || (CodigoEstadoVenta.Equals("T")) || (CodigoEstadoVenta.Equals("D")))
                            //{// si la venta se encuentra Pagada, o se encuentra en un estado de Institucion, se debe realizar la entrega de productos
                            //    FVentaProductosEntrega formVentaProductosEntrega = new FVentaProductosEntrega(NumeroAgencia, numeroTransaccion);
                            //    formVentaProductosEntrega.ShowDialog(this);

                            //}
                            //else if (CodigoEstadoVenta.Equals("I") || (EstadoVentaActual_deEntrega.Equals("T") && CodigoEstadoVenta.Equals("C")))
                            if (CodigoEstadoVenta.Equals("I") || (EstadoVentaActual_deEntrega.Equals("T") && CodigoEstadoVenta.Equals("C")))
                            {//si la venta se encuentra iniciada o ya ha sido entregada en una venta institucional como de Confianza
                                FVentasProductosFinalizarContador formVentasProductosFinalizarContador = new FVentasProductosFinalizarContador(NumeroAgencia, CodigoUsuario, numeroTransaccion, NumeroPC);
                                formVentasProductosFinalizarContador.CargarConfiguracionInicial(NombreMonedaSistema, CodigoMonedaSistema, MascaraMonedaSistema, CodigoMonedaRegion, NombreMonedaRegion, MascaraMonedaRegion, PorcentajeImpuestoSistema);
                                formVentasProductosFinalizarContador.ShowDialog(this);
                                formVentasProductosFinalizarContador.Dispose();


                                CodigoEstadoVenta = _TransaccionesUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(NumeroAgencia, NumeroTransaccion, "V");
                                DTVentasProductosBusqueda.Columns["EstadoVenta"].ReadOnly = false;
                                DTVentasProductosBusqueda.Rows[dtGVTransacciones.CurrentCell.RowIndex]["EstadoVenta"] = EstadoVenta.obtenerSignificadoCodigoEstadoVenta(CodigoEstadoVenta);
                                DTVentasProductosBusqueda.Rows[dtGVTransacciones.CurrentCell.RowIndex].AcceptChanges();
                                DTVentasProductosBusqueda.Columns["EstadoVenta"].ReadOnly = true;
                            }
                            else
                            {
                                MessageBox.Show(this, "No Puede Realizar una Operación con una Venta Anulada, Finalizada o si la misma no pertenece a la operación que desea Realizar ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            DTVentasProductosBusqueda.Rows[dtGVTransacciones.CurrentCell.RowIndex]["CodigoEstadoVenta"] = _TransaccionesUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(NumeroAgencia, numeroTransaccion, "V");
                        }
                    }
                    else
                    {
                        this.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No ha Seleccionado aún una Venta " + ex.Message);
                }
            }
            else
            {
                FVentasProductos2 _FVentasProductos = new FVentasProductos2(NumeroAgencia, NumeroPC, CodigoUsuario);
                _FVentasProductos.emitirPermisos(false, false, true, false, true, false, false);
                _FVentasProductos.CargarConfiguracionInicial(NombreMonedaSistema, CodigoMonedaSistema, MascaraMonedaSistema, CodigoMonedaRegion, NombreMonedaRegion, MascaraMonedaRegion, PorcentajeImpuestoSistema);
                _FVentasProductos.cargarDatosVentasProductos(numeroTransaccion);
                _FVentasProductos.ShowDialog(this);
                _FVentasProductos.Dispose();
            }
        }


        private void dtGVTransacciones_DoubleClick(object sender, EventArgs e)
        {
            //try
            //{
            //    this.NumeroTransaccion = Int32.Parse(dtGVTransacciones[1, dtGVTransacciones.CurrentCell.RowIndex].Value.ToString());
            //    FVentaProductosEntrega formVentaProductosEntrega = new FVentaProductosEntrega(NumeroAgencia, numeroTransaccion);
            //    formVentaProductosEntrega.ShowDialog(this);
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("No ha Seleccionado aún una Venta");
            //}

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtBoxNumeroTransaccion.Text.Trim()) && String.IsNullOrEmpty(txtBoxTextoBusqueda.Text))
            {
                MessageBox.Show(this, "Aun no ha ingresado un Texto a Buscar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DTVentasProductosBusqueda.Clear();
                int NumeroTransaccion = -1;
                if (txtBoxNumeroTransaccion.Text.Trim().Length > 0 && txtBoxNumeroTransaccion.Text != null)
                {
                    NumeroTransaccion = Int32.Parse(txtBoxNumeroTransaccion.Text);
                }

                DTVentasProductosBusqueda = _VentasProductosCLN.BuscarVentaProducto(cBoxBuscarPor.SelectedIndex.ToString(), txtBoxTextoBusqueda.Text.Trim(), NumeroAgencia, NumeroTransaccion , cBoxCodigoEstadoVenta.SelectedValue.Equals("D") ? null : cBoxCodigoEstadoVenta.SelectedValue.ToString(), dateTimePicker1.Value, dateTimePicker2.Value, checkTextoIdentico.Checked);
                bdSourceTransacciones.DataSource = DTVentasProductosBusqueda;
                dtGVTransacciones.DataSource = bdSourceTransacciones;

                if (DTVentasProductosBusqueda.Rows.Count == 0)
                    DTVentasProductosBusqueda.Rows.Clear();
                statusStrip1.Items[0].Text = "Numero de registros encontrados: " + bdSourceTransacciones.Count.ToString();
                if (txtBoxNumeroTransaccion.Focused)
                    txtBoxNumeroTransaccion.SelectAll();
                else if (txtBoxTextoBusqueda.Focused)
                    txtBoxTextoBusqueda.SelectAll();
            }
        }

        private void ocultarColumnaNumeroAgenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dtGVTransacciones.Columns[0].Visible = !dtGVTransacciones.Columns[0].Visible;
        }

        private void ocultarNumeroTransacciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dtGVTransacciones.Columns[1].Visible = !dtGVTransacciones.Columns[1].Visible;
        }

        private void ocultarFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dtGVTransacciones.Columns[2].Visible = !dtGVTransacciones.Columns[2].Visible;
        }


        private void txtBoxTextoBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e as EventArgs);
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


        public void formatearParaBusquedaEntregas()
        {            
            ListaCodigosEstadoVenta.Add(new EstadoVenta("P", "Pagadas"));
            ListaCodigosEstadoVenta.Add(new EstadoVenta("T", "Institucionales"));
            ListaCodigosEstadoVenta.Add(new EstadoVenta("E", "En Espera de Entrega(Pendientes)"));
            ListaCodigosEstadoVenta.Add(new EstadoVenta("D", "Todas"));

            this.cBoxCodigoEstadoVenta.DataSource = ListaCodigosEstadoVenta;
            this.cBoxCodigoEstadoVenta.ValueMember = "CodigoEstadoVenta";
            this.cBoxCodigoEstadoVenta.DisplayMember = "Descripcion";
            this.cBoxCodigoEstadoVenta.SelectedValue = "P";
        }

        public void formatearParaPagosCancelacionMonetaria()
        {            
            ListaCodigosEstadoVenta.Add(new EstadoVenta("I", "Iniciadas"));           
            ListaCodigosEstadoVenta.Add(new EstadoVenta("C", "En Confianza"));
            ListaCodigosEstadoVenta.Add(new EstadoVenta("D", "Todas"));            

            this.cBoxCodigoEstadoVenta.DataSource = ListaCodigosEstadoVenta;
            this.cBoxCodigoEstadoVenta.ValueMember = "CodigoEstadoVenta";
            this.cBoxCodigoEstadoVenta.DisplayMember = "Descripcion";
            this.cBoxCodigoEstadoVenta.SelectedValue = "I";

            esParaPagarVenta = true;
        }


        public void formatearParaBusquedasGeneral()
        {
            ListaCodigosEstadoVenta.Add(new EstadoVenta("F", "Finalizadas"));
            ListaCodigosEstadoVenta.Add(new EstadoVenta("I", "Iniciadas"));
            ListaCodigosEstadoVenta.Add(new EstadoVenta("A", "Anuladas"));
            ListaCodigosEstadoVenta.Add(new EstadoVenta("P", "Pagadas"));
            ListaCodigosEstadoVenta.Add(new EstadoVenta("T", "Institucionales"));
            ListaCodigosEstadoVenta.Add(new EstadoVenta("E", "En Espera de Entrega(Pendientes)"));
            ListaCodigosEstadoVenta.Add(new EstadoVenta("D", "Todas"));


            this.cBoxCodigoEstadoVenta.DataSource = ListaCodigosEstadoVenta;
            this.cBoxCodigoEstadoVenta.ValueMember = "CodigoEstadoVenta";
            this.cBoxCodigoEstadoVenta.DisplayMember = "Descripcion";
            this.cBoxCodigoEstadoVenta.SelectedValue = "D";

            
        }

        public void CargarConfiguracionInicial(string NombreMonedaSistema, int CodigoMonedaSistema, string MascaraMonedaSistema, int CodigoMonedaRegion, string NombreMonedaRegion, string MascaraMonedaRegion, decimal PorcentajeImpuestoSistema)
        {
            this.NombreMonedaSistema = NombreMonedaSistema;
            this.CodigoMonedaSistema = CodigoMonedaSistema;
            this.MascaraMonedaSistema = MascaraMonedaSistema;
            this.CodigoMonedaRegion = CodigoMonedaRegion;
            this.NombreMonedaRegion = NombreMonedaRegion;
            this.MascaraMonedaRegion = MascaraMonedaRegion;
            this.PorcentajeImpuestoSistema = PorcentajeImpuestoSistema;
        }

    }

    public class EstadoVenta
    {
        private string _codigoEstadoVenta;
        private string _descripcion;
        //Finalizadas
        //Iniciadas
        //Anuladas

        public string CodigoEstadoVenta
        {
            get { return _codigoEstadoVenta; }
            set { _codigoEstadoVenta = value; }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; } 
        }

        public EstadoVenta()
        {

        }
        public EstadoVenta(string codigoEstadoVenta, string descripcion )
        {
            this._codigoEstadoVenta = codigoEstadoVenta;
            this._descripcion = descripcion;
        }

        public static string obtenerSignificadoCodigoEstadoVenta(string codigoEstadoVenta)
        {
            string significadoCodigo = "";
            switch (codigoEstadoVenta)
            {//WHEN ''T'' THEN ''ENTREGA DIRECTA INST'' WHEN ''C'' THEN ''EN CONFIANZA'' WHEN ''D'' THEN ''PENDIENTE'' WHEN ''E'' THEN ''EN ESPERA'' END AS EstadoVenta
                case "I":
                    significadoCodigo = "INICIADA";
                    break;
                case "P":
                    significadoCodigo = "PAGADA";
                    break;
                case "F":
                    significadoCodigo = "FINALIZADA";
                    break;
                case "A":
                    significadoCodigo = "ANULADA";
                    break;
                case "T":
                    significadoCodigo = "ENTREGA DIRECTA INST";
                    break;
                case "C":
                    significadoCodigo = "EN CONFIANZA";
                    break;
                case "D":
                    significadoCodigo = "PENDIENTE";
                    break;
                case "E":
                    significadoCodigo = "EN ESPERA";
                    break;
                default:
                    significadoCodigo = "INDETERMINADO";
                    break;

            }
            return significadoCodigo;
        }
    }
}
