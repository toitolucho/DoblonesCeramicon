using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.GestionComercial;
using CLCLN.Sistema;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FComprasProductosReemDevo : Form
    {
        #region DataTables del Formulario
        private DataTable DTComprasProductosDevoluciones = null;        
        private DataTable DTComprasProductosDevolucionesDetalle = null;
        private DataTable DTComprasProductosDevolucionesDetalleTemporal = null;
        private DataTable DTComprasProductosDevolucionesEspecificos = null;
        private DataTable DTComprasProductosDevolucionesEspecificosTemporal = null;


        private DataTable DTUsuario = null;

        #endregion

        #region Atributos de la Capa del Negocio
        private ComprasProductosDevolucionesCLN _ComprasProductosDevolucionesCLN;
        private ComprasProductosDevolucionesDetalleCLN _ComprasProductosDevolucionesDetalleCLN;
        private ComprasProductosDevolucionesEspecificosCLN _ComprasProductosDevolucionesEspecificosCLN;
        private TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;
        private UsuariosCLN _UsuariosCLN;
        #endregion


        private int NumeroAgencia;
        private int CodigoUsuario;
        private int NumeroDevolucion;
        private int NumeroTransaccion;
        

        private DataSet DSMaestroDetalle = new DataSet();

        public FComprasProductosReemDevo(int NumeroAgencia, int CodigoUsuario)
        {
            InitializeComponent();
            this.NumeroAgencia = NumeroAgencia;
            this.CodigoUsuario = CodigoUsuario;

            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();
            _ComprasProductosDevolucionesCLN = new ComprasProductosDevolucionesCLN();
            _ComprasProductosDevolucionesDetalleCLN = new ComprasProductosDevolucionesDetalleCLN();
            _ComprasProductosDevolucionesEspecificosCLN = new ComprasProductosDevolucionesEspecificosCLN();
            _UsuariosCLN = new UsuariosCLN();

            dtGVDevolucionesProductosDetalle.DataSource = DTComprasProductosDevolucionesDetalle;
            //dtGVDevolucionesProductosEspecificos.DataSource = DTComprasProductosDevolucionesEspecificos;ç
            formatearEstiloGrilla();

            dtGVDevolucionesProductosDetalle.AutoGenerateColumns = false;
            dtGVDevolucionesProductosEspecificos.AutoGenerateColumns = false;
        }


        public void cargarDatosDevolucion(int numDevolucion)
        {
            DTComprasProductosDevoluciones = _ComprasProductosDevolucionesCLN.ObtenerCompraProductoDevolucion(NumeroAgencia, NumeroDevolucion);
            DTComprasProductosDevolucionesDetalle = _ComprasProductosDevolucionesDetalleCLN.ListarComprasProductosDevolucionesDetalleParaDevoluciones(NumeroAgencia, NumeroDevolucion);
            DTComprasProductosDevolucionesEspecificos = _ComprasProductosDevolucionesEspecificosCLN.ListarComprasProductosDevolucionesEspecificosParaDevoluciones(NumeroAgencia, NumeroDevolucion);

            dtGVDevolucionesProductosDetalle.DataSource = DTComprasProductosDevolucionesDetalle;


            if (DTComprasProductosDevoluciones.Rows.Count > 0)
            {
                DTComprasProductosDevolucionesDetalle.Columns.Add("PrecioTotal", typeof(decimal), "CantidadDevuelta*PrecioUnitarioDevolucion");

                lblCodigoUsuario.Text = DTComprasProductosDevoluciones.Rows[0]["CodigoUsuario"].ToString();
                string EstadoDevolucion = DTComprasProductosDevoluciones.Rows[0]["CodigoEstadoDevolucion"].ToString();
                lblFechaDevolucion.Text = DTComprasProductosDevoluciones.Rows[0]["FechaHoraSolicitudDevolucion"].ToString();
                lblNumeroDevolucion.Text = DTComprasProductosDevoluciones.Rows[0]["NumeroDevolucion"].ToString();
                lblNumeroCompra.Text = DTComprasProductosDevoluciones.Rows[0]["NumeroCompraProducto"].ToString();
                txtBoxObservaciones.Text = DTComprasProductosDevoluciones.Rows[0]["ObservacionesSolicitudDevo"].ToString();
                NumeroTransaccion = Int32.Parse(DTComprasProductosDevoluciones.Rows[0]["NumeroCompraProducto"].ToString());


                cMenuObservaciones.Enabled = true;
                lblDatosUsuario.Text = obtenerNombreCompletoUsuario(int.Parse(lblCodigoUsuario.Text));
                switch (EstadoDevolucion[0])
                {
                    case 'A':
                        lblEstadoDevolucion.Text = "ANULADA";
                        progressBarDevolucion.Value = 100;
                        habilitarBotonesDevolucion(true, false, false, false, false, true);
                        break;
                    case 'I':
                        lblEstadoDevolucion.Text = "INICIADA";
                        progressBarDevolucion.Value = 50;
                        habilitarBotonesDevolucion(true, false, false, true, true, true);
                        break;
                    case 'F':
                        lblEstadoDevolucion.Text = "FINALIZADA";
                        progressBarDevolucion.Value = 100;
                        habilitarBotonesDevolucion(true, false, false, false, false, true);
                        break;
                    case 'C':
                        lblEstadoDevolucion.Text = "CANCELADA";
                        progressBarDevolucion.Value = 0;
                        habilitarBotonesDevolucion(true, false, false, false, false, true);
                        break;
                    default:
                        lblEstadoDevolucion.Text = "NINGUNA";
                        progressBarDevolucion.Value = 0;
                        habilitarBotonesDevolucion(true, false, false, false, false, false);
                        break;
                }

                if (!DSMaestroDetalle.Tables.Contains(DTComprasProductosDevolucionesEspecificos.TableName))
                    DSMaestroDetalle.Tables.Add(DTComprasProductosDevolucionesEspecificos);
                dtGVDevolucionesProductosEspecificos.BindData(DSMaestroDetalle, DTComprasProductosDevolucionesEspecificos.TableName);
                if (DTComprasProductosDevolucionesEspecificos.Rows.Count > 0)
                {
                    dtGVDevolucionesProductosEspecificos.GroupTemplate.Column = dtGVDevolucionesProductosEspecificos.Columns[2];
                    ListSortDirection direction = ListSortDirection.Ascending;
                    dtGVDevolucionesProductosEspecificos.Sort(new DataRowComparer(2, direction));

                    dtGVDevolucionesProductosEspecificos.Columns[0].Width = 75;
                    dtGVDevolucionesProductosEspecificos.Columns[1].Width = 150;
                    dtGVDevolucionesProductosEspecificos.Columns[2].Width = 300;
                    dtGVDevolucionesProductosEspecificos.Columns[3].Width = 135;

                    dtGVDevolucionesProductosEspecificos.Columns[0].HeaderText = "Código";
                    dtGVDevolucionesProductosEspecificos.Columns[1].HeaderText = "Cód. Específico";
                    dtGVDevolucionesProductosEspecificos.Columns[2].HeaderText = "Nombre Producto";
                    dtGVDevolucionesProductosEspecificos.Columns[3].HeaderText = "Precio Unit. PE";
                }


                object PrecioProductoTemporal = DTComprasProductosDevolucionesDetalle.Compute("sum(PrecioTotal)", "");
                object PrecioEspecificos = DTComprasProductosDevolucionesEspecificos.Compute("sum(PrecioUnitarioDevolucionPE)", "");

                txtBoxMontoTotalDevolucion.Text = String.IsNullOrEmpty(PrecioProductoTemporal.ToString()) ? "0.00" : PrecioProductoTemporal.ToString();
                txtBoxTotalParcialEspecifico.Text = String.IsNullOrEmpty(PrecioEspecificos.ToString()) ? "0.00" : PrecioEspecificos.ToString();
                txtBoxTotalParcial.Text = String.IsNullOrEmpty(PrecioProductoTemporal.ToString()) ? "0.00" : PrecioProductoTemporal.ToString();
            }
            else
            {
                lblCodigoUsuario.Text = string.Empty;                
                lblFechaDevolucion.Text = string.Empty;
                lblNumeroDevolucion.Text = string.Empty;
                lblNumeroCompra.Text = string.Empty;
                txtBoxObservaciones.Text = string.Empty;
                lblDatosUsuario.Text = string.Empty;
                lblEstadoDevolucion.Text = string.Empty;
                progressBarDevolucion.Value = 0;

                txtBoxMontoTotalDevolucion.Text = "0.00";
                txtBoxTotalParcialEspecifico.Text = "0.00";
                txtBoxTotalParcial.Text = "0.00";
                cMenuObservaciones.Enabled = false;
                habilitarBotonesDevolucion(true, false, false, false, false, false);
            }
            
        }


        private void FComprasProductosReemDevo_Load(object sender, EventArgs e)
        {
            NumeroDevolucion = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("ComprasProductosDevoluciones");
            cargarDatosDevolucion(NumeroDevolucion);            
        }

        private void btnNuevaDevolucion_Click(object sender, EventArgs e)
        {
            habilitarBotonesDevolucion(false, true, true, false, false, false);
            NumeroDevolucion = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("ComprasProductosDevoluciones");
            lblNumeroDevolucion.Text = NumeroDevolucion.ToString();            
            lblEstadoDevolucion.Text = "INICIADA";
            lblFechaDevolucion.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            progressBarDevolucion.Value = 50;
            lblNumeroCompra.Text = "Ninguna";

            FBuscarTransaccion formBuscarTransaccion = new FBuscarTransaccion(NumeroAgencia);
            formBuscarTransaccion.formatearEstiloParaCompras();
            formBuscarTransaccion.ShowDialog(this);
            NumeroTransaccion = formBuscarTransaccion.NumeroTransaccion;
            formBuscarTransaccion.Dispose();

            if (NumeroTransaccion <= 0)
            {
                MessageBox.Show(this, "No ha Seleccionado una Compra Valida", "Error en la busqueda de una Compra", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                btnCancelarDevolucion_Click(btnCancelarDevolucion, e);
                return;
            }

            if (!_TransaccionesUtilidadesCLN.EsPosibleIniciarDevolucionDeUnaCompra(NumeroAgencia, NumeroTransaccion))
            {
                MessageBox.Show(this, "No se puede iniciar una Devolución para esta Compra debido a que posiblemente ya se devolvió todos los productos para esta Compra o Probablemente esta compra aún no ha sido recepcionada completamente", "Compra NO VALIDA", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                btnCancelarDevolucion_Click(btnCancelarDevolucion, e);
                return;
            }

            lblNumeroCompra.Text = NumeroTransaccion.ToString();

            FBusquedaProductosVendidos fBusquedaProductosVendidos = new FBusquedaProductosVendidos(NumeroAgencia, NumeroTransaccion, "C");
            fBusquedaProductosVendidos.ShowDialog(this);

            if (fBusquedaProductosVendidos.OperacionConfirmada)
            {
                DTComprasProductosDevolucionesDetalleTemporal = fBusquedaProductosVendidos.convertirCodigoMotivo_a_Descricpion();
                dtGVDevolucionesProductosDetalle.DataSource = DTComprasProductosDevolucionesDetalleTemporal;

                DTComprasProductosDevolucionesEspecificosTemporal = fBusquedaProductosVendidos.DTProductosDetalleEspecificosSeleccionados;
                if (!DSMaestroDetalle.Tables.Contains(DTComprasProductosDevolucionesEspecificosTemporal.TableName))
                    DSMaestroDetalle.Tables.Add(DTComprasProductosDevolucionesEspecificosTemporal);
                dtGVDevolucionesProductosEspecificos.BindData(DSMaestroDetalle, DTComprasProductosDevolucionesEspecificosTemporal.TableName);
                if (DTComprasProductosDevolucionesEspecificosTemporal.Rows.Count > 0)
                {
                    dtGVDevolucionesProductosEspecificos.GroupTemplate.Column = dtGVDevolucionesProductosEspecificos.Columns[0];
                    ListSortDirection direction = ListSortDirection.Ascending;
                    dtGVDevolucionesProductosEspecificos.Sort(new DataRowComparer(0, direction));

                    dtGVDevolucionesProductosEspecificos.Columns[0].Width = 300;
                    dtGVDevolucionesProductosEspecificos.Columns[1].Width = 75;
                    dtGVDevolucionesProductosEspecificos.Columns[2].Width = 150;
                    dtGVDevolucionesProductosEspecificos.Columns[3].Width = 135;

                    dtGVDevolucionesProductosEspecificos.Columns[0].HeaderText = "Nombre Producto";
                    dtGVDevolucionesProductosEspecificos.Columns[1].HeaderText = "Código";
                    dtGVDevolucionesProductosEspecificos.Columns[2].HeaderText = "Cód. Específico";
                    dtGVDevolucionesProductosEspecificos.Columns[3].HeaderText = "Precio Unit. PE";
                }


                object PrecioProductoTemporal = DTComprasProductosDevolucionesDetalleTemporal.Compute("sum(PrecioTotal)", "");
                object PrecioEspecificos = DTComprasProductosDevolucionesEspecificosTemporal.Compute("sum(PrecioUnitarioDevolucionPE)", "");

                txtBoxMontoTotalDevolucion.Text = String.IsNullOrEmpty(PrecioProductoTemporal.ToString()) ? "0.00" : PrecioProductoTemporal.ToString();
                txtBoxTotalParcialEspecifico.Text = String.IsNullOrEmpty(PrecioEspecificos.ToString()) ? "0.00" : PrecioEspecificos.ToString();
                txtBoxTotalParcial.Text = String.IsNullOrEmpty(PrecioProductoTemporal.ToString()) ? "0.00" : PrecioProductoTemporal.ToString();

                lblDatosUsuario.Text = obtenerNombreCompletoUsuario(CodigoUsuario);
            }
            
        }


        public void formatearEstiloGrilla()
        {
            this.dtGVDevolucionesProductosEspecificos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                       

            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dtGVDevolucionesProductosEspecificos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtGVDevolucionesProductosEspecificos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;

            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dtGVDevolucionesProductosEspecificos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;

            this.dtGVDevolucionesProductosEspecificos.GridColor = System.Drawing.SystemColors.Control;
            this.dtGVDevolucionesProductosEspecificos.RowTemplate.Height = 19;
            this.dtGVDevolucionesProductosEspecificos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dtGVDevolucionesProductosEspecificos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtGVDevolucionesProductosEspecificos.RowHeadersVisible = false;
            this.dtGVDevolucionesProductosEspecificos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtGVDevolucionesProductosEspecificos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtGVDevolucionesProductosEspecificos.AllowUserToAddRows = false;
            this.dtGVDevolucionesProductosEspecificos.AllowUserToDeleteRows = false;
            this.dtGVDevolucionesProductosEspecificos.AllowUserToResizeRows = true;
            //this.dtGVDevolucionesProductosEspecificos.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.dtGVDevolucionesProductosEspecificos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.dtGVDevolucionesProductosEspecificos.ClearGroups();  
        }

        private void btnAceptarDevolucion_Click(object sender, EventArgs e)
        {
            if (DTComprasProductosDevolucionesDetalleTemporal == null || DTComprasProductosDevolucionesDetalleTemporal.Rows.Count == 0)
            {
                MessageBox.Show(this, "Aun no ha seleccionado que productos va a devolver, no puede continuar con esta operación", "Seleccion incorrecta",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            DateTime FechaHoraSolicitudReemDevo = _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor();
            try
            {
                _ComprasProductosDevolucionesCLN.InsertarCompraProductoDevolucion(NumeroAgencia, NumeroTransaccion , "I", CodigoUsuario, FechaHoraSolicitudReemDevo, txtBoxObservaciones.Text, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,"No se Pudo insertar la Devolución actual " +Environment.NewLine + ex.Message);
                return;
            }
            NumeroDevolucion = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("ComprasProductosDevoluciones");


            int CodigoMotivoReemDevo = 0;
            string CodigoProducto = "";
            int CantidadDevuelta = 0;
            decimal PrecioUnitarioDevolucion = 0;
            string CodigoProductoEspecifico = "";
            decimal PrecioUnitarioDevolucionPE = 0;
            foreach(DataRow fila in DTComprasProductosDevolucionesDetalleTemporal.Rows)
            {
                CodigoMotivoReemDevo = Int32.Parse(fila["CodigoMotivoReemDevo"].ToString());
                CodigoProducto = fila["CodigoProducto"].ToString();
                CantidadDevuelta = Int32.Parse(fila["CantidadDevuelta"].ToString());
                PrecioUnitarioDevolucion = Decimal.Parse(fila["PrecioUnitarioDevolucion"].ToString());

                try
                {
                    _ComprasProductosDevolucionesDetalleCLN.InsertarCompraProductoDevolucionDetalle(NumeroAgencia, NumeroDevolucion, CodigoMotivoReemDevo, CodigoProducto, CantidadDevuelta, PrecioUnitarioDevolucion);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Ocurrio un error al momento de insertar el Detalle de Devolución debido a " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;                    
                }

            }

            foreach (DataRow fila in DTComprasProductosDevolucionesEspecificosTemporal.Rows)
            {
                CodigoProducto = fila["CodigoProducto"].ToString();
                CodigoProductoEspecifico = fila["CodigoProductoEspecifico"].ToString();
                PrecioUnitarioDevolucionPE = Decimal.Parse(fila["PrecioUnitarioDevolucionPE"].ToString());

                try
                {
                    _ComprasProductosDevolucionesEspecificosCLN.InsertarCompraProductoDevolucionEspecifico(NumeroAgencia, NumeroDevolucion, CodigoProducto, CodigoProductoEspecifico, PrecioUnitarioDevolucionPE);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Ocurrio un error al momento de insertar el Detalle de Devolución de Productos Específicos debido a " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;                                        
                }
            }
            lblFechaDevolucion.Text = FechaHoraSolicitudReemDevo.ToShortDateString() +" " + FechaHoraSolicitudReemDevo.ToShortTimeString();

            habilitarBotonesDevolucion(true, false, false, true, true, true);

            if (MessageBox.Show(this, "Se INICIO correctamente la Devolución." + Environment.NewLine + " ¿Desea Finalizar la Devolución? ", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //finalizar transacción
                btnFinalizarDevolucion_Click(sender, e);
            }

            
        }


        public void habilitarBotonesDevolucion(bool nuevo, bool cancelar, bool aceptar, bool finalizar, bool anular, bool reporte)
        {
            btnNuevaDevolucion.Enabled = nuevo;
            btnCancelarDevolucion.Enabled = cancelar;
            btnAceptarDevolucion.Enabled = aceptar;
            btnFinalizarDevolucion.Enabled = finalizar;
            btnAnularDevolucion.Enabled = anular;
            btnReporteDevolucion.Enabled = reporte;
        }

        private void btnCancelarDevolucion_Click(object sender, EventArgs e)
        {
            NumeroDevolucion = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("ComprasProductosDevoluciones");
            cargarDatosDevolucion(NumeroDevolucion);            
        }

        private void btnFinalizarDevolucion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Una vez Finalizada la Devolución, se debe hacer la entrega de los Productos seleccionados a ser devueltos, sin vuelta atrás" + Environment.NewLine +"¿ Desea Finalizar la Devolución ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _TransaccionesUtilidadesCLN.ActualizarInventarioProductosDevoluciones(NumeroAgencia, NumeroDevolucion, "C");
                    _TransaccionesUtilidadesCLN.InsertarAsientosTransacciones(CodigoUsuario,
                                    "Asiento Contable Correspondiente a Numero de Devolución de Compra " + NumeroDevolucion.ToString(),
                                    "C", NumeroDevolucion, "P", NumeroAgencia);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "No se Pudo Finalizar la Transaccion debido a que no se pudo Actualizar inventarios y :" + ex.Message, "Erro en Devolución", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                try
                {
                    _ComprasProductosDevolucionesCLN.FinalizarAnularCompraProductoDevolucion(NumeroAgencia, NumeroDevolucion, "F", _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "No se Pudo Finalizar la Transaccion debido a :" + ex.Message, "Erro en Devolución", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                lblEstadoDevolucion.Text = "FINALIZADA";
                progressBarDevolucion.Value = progressBarDevolucion.Maximum;

                habilitarBotonesDevolucion(true, false, false, false, false, true);
            }
        }

        private void btnAnularDevolucion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿ Está seguro de Anular la Devolución ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {                
                try
                {
                    _ComprasProductosDevolucionesCLN.FinalizarAnularCompraProductoDevolucion(NumeroAgencia, NumeroDevolucion, "A", _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "No se Pudo Anular la Transaccion debido a :" + ex.Message, "Erro en Devolución", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                lblEstadoDevolucion.Text = "ANULADA";
                progressBarDevolucion.Value = progressBarDevolucion.Maximum;

                habilitarBotonesDevolucion(true, false, false, false, false, true);
            }
        }

        public string obtenerNombreCompletoUsuario(int CodigoUsuario)
        {
            DTUsuario = _UsuariosCLN.ObtenerUsuario(CodigoUsuario);
            return DTUsuario.Rows[0]["Nombres"].ToString().Trim() + " " + DTUsuario.Rows[0]["Paterno"].ToString().Trim() + " " + DTUsuario.Rows[0]["Materno"].ToString().Trim();
        }

        private void brnBuscarTransaccion_Click(object sender, EventArgs e)
        {
            FBuscarTransaccion formBuscarTransaccion = new FBuscarTransaccion(NumeroAgencia);
            formBuscarTransaccion.formatearEstiloParaComprasDevoluciones();
            formBuscarTransaccion.ShowDialog(this);
            NumeroDevolucion = formBuscarTransaccion.NumeroTransaccion;
            if (NumeroDevolucion > 0)
            {
                cargarDatosDevolucion(NumeroDevolucion);
            }
            else
            {
                MessageBox.Show(this, "No se encontró Ningún registro con los parametros ingresados", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnCancelarDevolucion_Click(sender, e);
            }
            
            formBuscarTransaccion.Dispose();
        }

        private void btnReporteDevolucion_Click(object sender, EventArgs e)
        {
            ComprasProductosCLN _ComprasProductosCLN = new ComprasProductosCLN();
            DataTable compras = _ComprasProductosCLN.ListarCompraProductoReporte(NumeroAgencia, NumeroTransaccion);
            DataTable devoluciones = _ComprasProductosDevolucionesCLN.ListarCompraProductoDevolucionReporte(NumeroAgencia, NumeroDevolucion);
            DataTable productos = _ComprasProductosDevolucionesDetalleCLN.ListarComprasProductosDevolucionesDetalleParaDevoluciones(NumeroAgencia, NumeroDevolucion);
            DataTable especificos = _ComprasProductosDevolucionesEspecificosCLN.ListarComprasProductosDevolucionesEspecificosParaDevoluciones(NumeroAgencia, NumeroDevolucion);

            FReporteComprasDevoluciones formReporteDevolucion = new FReporteComprasDevoluciones(compras, devoluciones, productos, especificos);
            formReporteDevolucion.Show();

        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FObservacionesTransaccionesModificacion _FObservacionesTransaccionesModificacion = new FObservacionesTransaccionesModificacion("P", CodigoUsuario, NumeroAgencia, NumeroDevolucion);
            _FObservacionesTransaccionesModificacion.TxtBoxObservaciones.Text = txtBoxObservaciones.Text;
            if (_FObservacionesTransaccionesModificacion.ShowDialog() == DialogResult.OK)
                txtBoxObservaciones.Text = _FObservacionesTransaccionesModificacion.TxtBoxObservaciones.Text;
        }

        
    }
   
}
