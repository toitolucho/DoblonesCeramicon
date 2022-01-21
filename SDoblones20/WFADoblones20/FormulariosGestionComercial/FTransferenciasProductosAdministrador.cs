using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.GestionComercial;
using CLCAD;
using CLCLN.Sistema;
using System.Collections;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FTransferenciasProductosAdministrador : Form
    {
        DSDoblones20GestionComercial2.BuscarTransferenciaProductoDataTable DTBusquedaTransferenciaProducto;
        DataTable VariablesConfiguracionSistemaGC;
        TransferenciasProductosCLN _TransferenciasProductosCLN;
        TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;
        PCsConfiguracionesCLN PCConfiguracion;
        ArrayList ListaCodigosEstadoTransferencia = new ArrayList();

        public int NumeroAgencia { get; set; }
        private int NumeroPC = 0;
        public int CodigoUsuario { get; set; }
        public int NumeroTransaccion { get; set; }
        private string TipoOperacion = "";
        private string CodigoTipoEnvioRecepcion { get; set; }

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

        public FTransferenciasProductosAdministrador(int NumeroAgencia, int NumeroPC, int CodigoUsuario, string CodigoTipoEnvioRecepcion)
        {
            InitializeComponent();
            this.NumeroAgencia = NumeroAgencia;
            this.NumeroPC = NumeroPC;
            this.CodigoUsuario = CodigoUsuario;
            this.CodigoTipoEnvioRecepcion = CodigoTipoEnvioRecepcion;

            this.dateTimePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            txtBoxNumeroTransaccion.Clear();
            txtBoxTextoBusqueda.Clear();
            this.lblNroTransaccion.Text = "Numero de Transferencia";
            this.cBoxBuscarPor.Items.Clear();
            this.cBoxBuscarPor.Items.Add("Nombre Agencia Receptora");
            this.cBoxBuscarPor.Items.Add("NIT Agencia Receptora");
            this.cBoxBuscarPor.Items.Add("Nombre Producto");
            this.cBoxBuscarPor.Items.Add("Observaciones");
            this.cBoxBuscarPor.SelectedIndex = 0;

            _TransferenciasProductosCLN = new TransferenciasProductosCLN();
            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();


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

            //DGCNumeroAgenciaEmisora.Width = 75;
            //DGCNumeroTransferenciaProducto.Width = 100;
            //FechaHoraTransferencia.Width = 165;
            //DGCObservaciones.Width = 250;
            dtGVTransacciones.CellDoubleClick += new DataGridViewCellEventHandler(dtGVTransacciones_CellDoubleClick);
            this.button1.Click +=new EventHandler(button1_Click);
            this.btnLimpiar.Click +=new EventHandler(btnLimpiar_Click);
            this.btnLimpiar.Click +=new EventHandler(btnLimpiar_Click);             
            txtBoxTextoBusqueda.KeyDown +=new KeyEventHandler(txtBoxTextoBusqueda_KeyDown);
            this.Load +=new EventHandler(FTransferenciasProductosAdministrador_Load);            
            txtBoxNumeroTransaccion.KeyPress +=new KeyPressEventHandler(txtBoxNumeroTransaccion_KeyPress);            
            this.txtBoxNumeroTransaccion.KeyDown += new KeyEventHandler(txtBoxTextoBusqueda_KeyDown);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        void dtGVTransacciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                if (dtGVTransacciones.RowCount > 0 && dtGVTransacciones.CurrentRow != null)
                {
                    //this.NumeroTransaccion = DTBusquedaTransferenciaProducto[e.RowIndex].NumeroTransferenciaProducto;
                    //string CodigoEstadoCompra = DTBusquedaTransferenciaProducto[e.RowIndex].CodigoEstadoTransferencia;
                    //int NumeroAgenciaBusqueda = DTBusquedaTransferenciaProducto[e.RowIndex].NumeroAgenciaEmisora;

                    this.NumeroTransaccion = (int)DTBusquedaTransferenciaProducto.DefaultView[e.RowIndex][DTBusquedaTransferenciaProducto.NumeroTransferenciaProductoColumn.ColumnName];
                    string CodigoEstadoCompra = DTBusquedaTransferenciaProducto.DefaultView[e.RowIndex][DTBusquedaTransferenciaProducto.CodigoEstadoTransferenciaColumn.ColumnName].ToString();
                    int NumeroAgenciaBusqueda = (int)DTBusquedaTransferenciaProducto.DefaultView[e.RowIndex][DTBusquedaTransferenciaProducto.NumeroAgenciaEmisoraColumn.ColumnName];

                    switch (TipoOperacion)
                    {
                        case "A": //Recepción en Almacenes                            
                                FTRansferenciasProductosRecepcionEnvio _FTransferenciaProductosAdministradorIngresoInventarios = new FTRansferenciasProductosRecepcionEnvio(NumeroAgencia, NumeroTransaccion, CodigoTipoEnvioRecepcion, CodigoUsuario);
                                //_FCompraProductosAdministradorIngresoInventarios.
                                _FTransferenciaProductosAdministradorIngresoInventarios.ShowDialog();
                                _FTransferenciaProductosAdministradorIngresoInventarios.Dispose();
                                string CodigoEstadoTransferencia = _TransaccionesUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(NumeroAgencia, NumeroTransaccion, CodigoTipoEnvioRecepcion);
                                if (!String.IsNullOrEmpty(CodigoEstadoTransferencia))
                                {
                                    DTBusquedaTransferenciaProducto[e.RowIndex].CodigoEstadoTransferencia = CodigoEstadoTransferencia;
                                    DTBusquedaTransferenciaProducto[e.RowIndex].EstadoTransferencia = EstadoTransferencia.getSignificadoCodigoEstadoTransferencia(CodigoEstadoTransferencia);
                                }

                            break;
                        case "C": //Cancelacion y pago para el Contador                                
                                FTransferenciasProductosGastos _FTransferenciaProductosAdministradorPagos = new FTransferenciasProductosGastos(NumeroAgencia, NumeroTransaccion, CodigoTipoEnvioRecepcion);
                                //_FCompraProductosAdministradorPagos.cargar
                                //_FTransferenciaProductosAdministradorPagos.CodigoTipoEntradaSalida = "R";
                                _FTransferenciaProductosAdministradorPagos.ShowDialog();
                                _FTransferenciaProductosAdministradorPagos.Dispose();
                                CodigoEstadoTransferencia = _TransaccionesUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(NumeroAgencia, NumeroTransaccion, CodigoTipoEnvioRecepcion);
                                if (!String.IsNullOrEmpty(CodigoEstadoTransferencia))
                                {
                                    DTBusquedaTransferenciaProducto[e.RowIndex].CodigoEstadoTransferencia = CodigoEstadoTransferencia;
                                    DTBusquedaTransferenciaProducto[e.RowIndex].EstadoTransferencia = EstadoTransferencia.getSignificadoCodigoEstadoTransferencia(CodigoEstadoTransferencia);
                                }
                            break;
                        case "N": //Navegación 

                            FTransferenciasProductos _FTransferenciasProductos;
                            //= new FTransferenciasProductos(NumeroAgencia, CodigoUsuario);
                            if (NumeroAgencia != NumeroAgenciaBusqueda)
                                _FTransferenciasProductos = new FTransferenciasProductos(NumeroAgenciaBusqueda, NumeroPC, CodigoUsuario);
                            else
                                _FTransferenciasProductos = new FTransferenciasProductos(NumeroAgencia, NumeroPC, CodigoUsuario);
                            _FTransferenciasProductos.CargarConfiguracionInicial(NombreMonedaSistema, CodigoMonedaSistema, MascaraMonedaSistema, CodigoMonedaRegion, NombreMonedaRegion, MascaraMonedaRegion, PorcentajeImpuestoSistema);                            
                            _FTransferenciasProductos.emitirPermisos(false, true, true, true, false, false);
                            _FTransferenciasProductos.cargarTransferencias(NumeroTransaccion);
                            _FTransferenciasProductos.ShowDialog(this);
                            _FTransferenciasProductos.Dispose();
                            break;
                        default:
                            break;
                    }
                    
                    
                }              

            }
            catch (Exception ex)
            {
                MessageBox.Show("No ha Seleccionado aún una Transferencia " + ex.Message);
            }
            
        }

        private void FTransferenciasProductosAdministrador_Load(object sender, EventArgs e)
        {
            DTBusquedaTransferenciaProducto = _TransferenciasProductosCLN.BuscarTransferenciaProducto("0", " ", NumeroAgencia, null, null, DateTime.Now, DateTime.Now, false, CodigoTipoEnvioRecepcion);
            DTBusquedaTransferenciaProducto.CodigoEstadoTransferenciaColumn.ReadOnly = false;
            DTBusquedaTransferenciaProducto.EstadoTransferenciaColumn.ReadOnly = false;
            bdSourceTransacciones.DataSource = DTBusquedaTransferenciaProducto;
            dtGVTransacciones.DataSource = bdSourceTransacciones;
            statusStrip1.Items[0].Text = "Numero de registros encontrados: " + bdSourceTransacciones.Count.ToString();
            DGCNumeroAgenciaEmisora.Width = 85;
            DGCNombreAgencia.Width = 200;
                        
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
                DTBusquedaTransferenciaProducto.Clear();
                int NumeroTransaccion = -1;
                if (txtBoxNumeroTransaccion.Text.Trim().Length > 0 && txtBoxNumeroTransaccion.Text != null)
                {
                    NumeroTransaccion = Int32.Parse(txtBoxNumeroTransaccion.Text);
                }

                DTBusquedaTransferenciaProducto = _TransferenciasProductosCLN.BuscarTransferenciaProducto(cBoxBuscarPor.SelectedIndex.ToString(), txtBoxTextoBusqueda.Text.Trim(), NumeroAgencia, NumeroTransaccion, cBoxCodigoEstadoVenta.SelectedValue.Equals("T") ? null : cBoxCodigoEstadoVenta.SelectedValue.ToString(), dateTimePicker1.Value, dateTimePicker2.Value, checkTextoIdentico.Checked, cBoxCodigoEstadoVenta.SelectedValue.Equals("T") ? null : CodigoTipoEnvioRecepcion);
                DTBusquedaTransferenciaProducto.CodigoEstadoTransferenciaColumn.ReadOnly = false;
                DTBusquedaTransferenciaProducto.EstadoTransferenciaColumn.ReadOnly = false;
                bdSourceTransacciones.DataSource = DTBusquedaTransferenciaProducto;
                dtGVTransacciones.DataSource = bdSourceTransacciones;

                if (DTBusquedaTransferenciaProducto.Rows.Count == 0)
                    DTBusquedaTransferenciaProducto.Rows.Clear();
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
            this.DTBusquedaTransferenciaProducto.Clear();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        public void formatearParaBusquedaEnvio()
        {
            ListaCodigosEstadoTransferencia.Add(new EstadoTransferencia("P", "Con Gastos Agregados"));
            ListaCodigosEstadoTransferencia.Add(new EstadoTransferencia("I", "Iniciadas"));
            ListaCodigosEstadoTransferencia.Add(new EstadoTransferencia("T", "Todas"));

            this.cBoxCodigoEstadoVenta.DataSource = ListaCodigosEstadoTransferencia;
            this.cBoxCodigoEstadoVenta.ValueMember = "CodigoEstadoTransferencia";
            this.cBoxCodigoEstadoVenta.DisplayMember = "Descripcion";
            this.cBoxCodigoEstadoVenta.SelectedValue = "I";

            TipoOperacion = "A"; //trabajo de almacenes

            this.Text = "Administrador de Transferencias para Recepción de Mercadería";
        }

        public void formatearParaBusquedaRecepcion()
        {
            ListaCodigosEstadoTransferencia.Add(new EstadoTransferencia("E", "Emitias(Transferidas)"));
            ListaCodigosEstadoTransferencia.Add(new EstadoTransferencia("D", "En Espera de Recepción(Pendientes)"));
            ListaCodigosEstadoTransferencia.Add(new EstadoTransferencia("T", "Todas"));

            this.cBoxCodigoEstadoVenta.DataSource = ListaCodigosEstadoTransferencia;
            this.cBoxCodigoEstadoVenta.ValueMember = "CodigoEstadoTransferencia";
            this.cBoxCodigoEstadoVenta.DisplayMember = "Descripcion";
            this.cBoxCodigoEstadoVenta.SelectedValue = "E";

            TipoOperacion = "A";//trabajo de almacenes

            this.Text = "Administrador de Transferencias para Recepción de Mercadería";
        }

        public void formatearParaAgregarGastos()
        {
            ListaCodigosEstadoTransferencia.Add(new EstadoTransferencia("I", "Iniciadas"));
            ListaCodigosEstadoTransferencia.Add(new EstadoTransferencia("E", "Emitias(Transferidas)"));
            ListaCodigosEstadoTransferencia.Add(new EstadoTransferencia("D", "Pendientes"));
            ListaCodigosEstadoTransferencia.Add(new EstadoTransferencia("T", "Todas"));

            this.cBoxCodigoEstadoVenta.DataSource = ListaCodigosEstadoTransferencia;
            this.cBoxCodigoEstadoVenta.ValueMember = "CodigoEstadoTransferencia";
            this.cBoxCodigoEstadoVenta.DisplayMember = "Descripcion";
            this.cBoxCodigoEstadoVenta.SelectedValue = "I";

            TipoOperacion = "C"; //trabajo de contador y caja

            this.Text = "Administrador de Transferencias para adicionar Gastos";
        }


        public void formatearParaBusquedasGeneral()
        {
            ListaCodigosEstadoTransferencia.Add(new EstadoTransferencia("F", "Finalizadas"));
            ListaCodigosEstadoTransferencia.Add(new EstadoTransferencia("I", "Iniciadas"));
            ListaCodigosEstadoTransferencia.Add(new EstadoTransferencia("A", "Anuladas"));
            ListaCodigosEstadoTransferencia.Add(new EstadoTransferencia("E", "Emitidas y Enviadas"));
            ListaCodigosEstadoTransferencia.Add(new EstadoTransferencia("D", "Pendientes"));
            ListaCodigosEstadoTransferencia.Add(new EstadoTransferencia("T", "Todas"));


            this.cBoxCodigoEstadoVenta.DataSource = ListaCodigosEstadoTransferencia;
            this.cBoxCodigoEstadoVenta.ValueMember = "CodigoEstadoTransferencia";
            this.cBoxCodigoEstadoVenta.DisplayMember = "Descripcion";
            this.cBoxCodigoEstadoVenta.SelectedValue = "T";

            TipoOperacion = "N";


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

        private void FTransferenciasProductosAdministrador_Load_1(object sender, EventArgs e)
        {

        }


    }

    public class EstadoTransferencia
    {
        private string _codigoEstadoTransferencia;
        private string _descripcion;

        public string CodigoEstadoTransferencia
        {
            get { return _codigoEstadoTransferencia; }
            set { _codigoEstadoTransferencia = value; }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public EstadoTransferencia()
        {

        }
        public EstadoTransferencia(string codigoEstadoVenta, string descripcion)
        {
            this._codigoEstadoTransferencia = codigoEstadoVenta;
            this._descripcion = descripcion;
        }

        public static string getSignificadoCodigoEstadoTransferencia(string CodigoEstado)
        {
            //''I'' THEN ''INICIADA'' WHEN ''A'' THEN ''ANULADA'' WHEN ''E'' THEN ''ENVIADA Y EMITIDA'' WHEN ''D'' THEN ''PENDIENTE''  WHEN ''F'' THEN ''FINALIZADO Y RECIBIDO'' WHEN ''P'' THEN ''CON GASTOS PAGADOS'' WHEN ''X'' THEN ''FINALIZADA RECEPCION INCOMPLETA
            switch(CodigoEstado)
            {
                case "I":
                    return "INICIADA";
                case "A":
                    return "ANULADA";
                case "E":
                    return "ENVIADA Y EMITIDA";
                case "D":
                    return "PENDIENTE";
                case "F":
                    return "FINALIZADO Y RECIBIDO";
                case "P":
                    return "CON GASTOS PAGADOS";
                case "X":
                    return "FINALIZADA RECEPCION INCOMPLETA";
                default :
                    return "INDEFINIDO";                    
            }
        }
    }
}
