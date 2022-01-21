using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCAD;
using CLCAD.DSDoblones20GestionComercial2TableAdapters;
using CLCLN.GestionComercial;
using CLCLN.Sistema;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FVentasServicios : Form
    {
        #region Variables de la Capa de Negocio
        private ServiciosCLN _ServiciosCLN;
        private VentasServiciosCLN _VentasServiciosCLN;
        private VentasServiciosDetalleCLN _VentasServiciosDetalleCLN;
        private ClientesCLN _ClientesCLN;
        private PersonasCLN _PersonasCLN;
        private UsuariosCLN _UsuariosCLN;
        private TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;
        private MonedasCLN _MonedasCLN;
        private PCsConfiguracionesCLN PCConfiguracion = null;
        #endregion

        #region DataTables
        DSDoblones20GestionComercial2.ServiciosDataTable DTServicios;
        DSDoblones20GestionComercial2.VentasServiciosDataTable DTVentasServicios;
        DSDoblones20GestionComercial2.VentasServiciosDetalleDataTable DTVentasServiciosDetalle;
        DSDoblones20GestionComercial2.VentasServiciosDetalleDataTable DTVentasServiciosDetalleTemporal;
        DSDoblones20GestionComercial.ClientesDataTable DTClientes;
        DSDoblones20Sistema.PersonasDataTable DTPersonas;
        DSDoblones20Sistema.MonedasDataTable DTMonedas;
        DataTable VariablesConfiguracionSistemaGC;
        #endregion

        public int NumeroVentaServicio;
        int NumeroAgencia = 1;
        int CodigoUsuario = 1;
        int NumeroPC = 1;
        string TipoOperacion = "";
        private DataSet DSVentasServicios;

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

        public FVentasServicios(int NumeroPC, int NumeroAgencia, int CodigoUsuario)
        {
            InitializeComponent();

            this.NumeroPC = NumeroPC;
            this.NumeroAgencia = NumeroAgencia;
            this.CodigoUsuario = CodigoUsuario;

            DSVentasServicios = new DataSet("VentaServicios");

            _ClientesCLN = new ClientesCLN();
            _PersonasCLN = new PersonasCLN();
            _ServiciosCLN = new ServiciosCLN();
            _UsuariosCLN = new UsuariosCLN();
            _VentasServiciosCLN = new VentasServiciosCLN();
            _VentasServiciosDetalleCLN = new VentasServiciosDetalleCLN();
            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();
            _MonedasCLN = new MonedasCLN();



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

            DTVentasServicios = _VentasServiciosCLN.ObtenerVentaServicio(1,-1);
            DTVentasServiciosDetalle = _VentasServiciosDetalleCLN.ObtenerVentaServicioDetalle(1,-1,-1);
            DTVentasServiciosDetalle.Columns.Add("PrecioTotal", Type.GetType("System.Decimal"), "CantidadVentaServicio * PrecioUnitario");

            DTVentasServiciosDetalleTemporal = (DSDoblones20GestionComercial2.VentasServiciosDetalleDataTable)DTVentasServiciosDetalle.Clone();
            DTVentasServiciosDetalleTemporal.PrimaryKey = null;
            DTVentasServiciosDetalleTemporal.Columns.Remove("NumeroAgencia");
            DTVentasServiciosDetalleTemporal.Columns.Remove("NumeroVentaServicio");
            DTVentasServiciosDetalleTemporal.PrimaryKey = new DataColumn[1] { DTVentasServiciosDetalleTemporal.CodigoServicioColumn};
            DTVentasServiciosDetalleTemporal.CantidadVentaServicioColumn.DefaultValue = 1;
            DTVentasServiciosDetalleTemporal.PrecioUnitarioColumn.DefaultValue = 1;
            DTVentasServiciosDetalleTemporal.TiempoGarantiaDiasColumn.DefaultValue = 1;
            
            DTServicios = _ServiciosCLN.ListarServicios();
            DTMonedas = (DSDoblones20Sistema.MonedasDataTable) _MonedasCLN.ListarMonedas();

            cBoxMonedas.DataSource = DTMonedas;
            cBoxMonedas.DisplayMember = "NombreMoneda";
            cBoxMonedas.ValueMember = "CodigoMoneda";

            DGCCodigoServicio.DataSource = DTServicios;
            DGCCodigoServicio.DisplayMember = "NombreServicio";
            DGCCodigoServicio.ValueMember = "CodigoServicio";
            DGCCodigoServicio.DataPropertyName = "CodigoServicio";

            dtGVServiciosDetalle.AutoGenerateColumns = false;

            NumeroVentaServicio = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("VentasServicios");
            bindingSourceServicios.DataSource = DTVentasServiciosDetalleTemporal;
            dtGVServiciosDetalle.DataSource = bindingSourceServicios;
            bindingNavigator1.BindingSource = bindingSourceServicios;
            DTVentasServiciosDetalleTemporal.RowChanged += new DataRowChangeEventHandler(DTVentasServiciosDetalleTemporal_RowChanged);
            DTVentasServiciosDetalleTemporal.RowDeleted += new DataRowChangeEventHandler(DTVentasServiciosDetalleTemporal_RowChanged);

            DSVentasServicios.Tables.AddRange ( new DataTable[]{DTVentasServicios, DTVentasServiciosDetalleTemporal});

            cargarDatosVentasServcios(NumeroVentaServicio);
            

        }

        void DTVentasServiciosDetalleTemporal_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            txtBoxMontoTotal.Text = DTVentasServiciosDetalleTemporal.Compute("sum(PrecioTotal)", "").ToString();
        }

        private void FVentasServicios_Load(object sender, EventArgs e)
        {

        }

        private void dtGVServiciosDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dtGVServiciosDetalle.BeginEdit(true);
        }

        public void cargarDatosVentasServcios(int NumeroServ)
        {
            DTVentasServicios = _VentasServiciosCLN.ObtenerVentaServicio(NumeroAgencia, NumeroServ);
            DTVentasServiciosDetalle = _VentasServiciosDetalleCLN.ListarVentaServicioDetalleParaMostrar (NumeroAgencia, NumeroServ);
            if (DTVentasServiciosDetalle.Count != 0)
            {
                this.NumeroVentaServicio = NumeroServ;
                this.lblFechaEntrega.Text = DTVentasServicios[0].IsFechaHoraEntregaServicioNull() ? "Pendiente" : String.Format("{0:G}", DTVentasServicios[0].FechaHoraEntregaServicio);
                this.lblFechaRegistro.Text = DTVentasServicios[0].IsFechaHoraVentaServicioNull() ? "Pendiente": String.Format("{0:G}", DTVentasServicios[0].FechaHoraVentaServicio);
                this.lblNumeroServicio.Text = NumeroVentaServicio.ToString();
                DTClientes = (DSDoblones20GestionComercial.ClientesDataTable)_ClientesCLN.ObtenerCliente(DTVentasServicios[0].CodigoCliente);
                txtBoxNombreCliente.Text = DTClientes[0].NombreCliente;
                txtBoxResponsable1.Text = _PersonasCLN.ObtenerNombreCompleto(DTVentasServicios[0].DIPersonaResponsable1) + "(" + DTVentasServicios[0].DIPersonaResponsable1.Trim() + ")";
                txtBoxResponsable2.Text = DTVentasServicios[0].IsDIPersonaResponsable2Null() ? String.Empty : _PersonasCLN.ObtenerNombreCompleto(DTVentasServicios[0].DIPersonaResponsable2) + "(" + DTVentasServicios[0].DIPersonaResponsable2.Trim() + ")";
                txtBoxResponsable3.Text = DTVentasServicios[0].IsDIPersonaResponsable3Null() ? String.Empty : _PersonasCLN.ObtenerNombreCompleto(DTVentasServicios[0].DIPersonaResponsable3) + "(" + DTVentasServicios[0].DIPersonaResponsable3.Trim() + ")";
                rBtnEfectivo.Checked = DTVentasServicios[0].CodigoTipoServicio == "E";
                rBtnCredito.Checked = DTVentasServicios[0].CodigoTipoServicio == "C";
                checkFactura.Checked = !DTVentasServicios[0].IsNumeroFacturaNull(); // && DTVentasServicios[0].NumeroFactura != -1;
                txtBoxObservaciones.Text = DTVentasServicios[0].IsObservacionesNull() ? "" : DTVentasServicios[0].Observaciones;
                txtBoxMontoTotal.Text = DTVentasServicios[0].MontoTotal.ToString();
                cBoxMonedas.SelectedValue = DTVentasServicios[0].CodigoMoneda;

                DTVentasServiciosDetalle.Columns.Add("PrecioTotal", Type.GetType("System.Decimal"), "PrecioUnitario * CantidadVentaServicio");
                bindingSourceServicios.DataSource = DTVentasServiciosDetalle;
                bindingNavigator1.BindingSource = bindingSourceServicios;
                dtGVServiciosDetalle.DataSource = bindingSourceServicios;

                habilitarCampos(false);

                switch (DTVentasServicios[0].CodigoEstadoServicio)
                {
                    case "I":
                        lblEstadoServicio.Text = "INICIADO";
                        habilitarBotones(true, false, true, false, true, false, true, true, true);
                        break;
                    case "A":
                        lblEstadoServicio.Text = "ANULADO";
                        habilitarBotones(true, false, false, false, false, false, false, true, false);
                        break;
                    case "F":
                        lblEstadoServicio.Text = "FINALIZADO";
                        habilitarBotones(true, false, false, false, false, false, true, true, false);
                        break;
                    case "C":
                        lblEstadoServicio.Text = "SERVICIO PARA COTIZACION";
                        habilitarBotones(true, false, false, false, false, false, true, true, false);
                        break;
                    case "V":
                        lblEstadoServicio.Text = "SERVICIO PARA VENTA";
                        habilitarBotones(true, false, false, false, false, false, true, true, false);
                        break;
                    case "P":
                        lblEstadoServicio.Text = "PAGADO";
                        habilitarBotones(true, false, false, false, true, true, true, true, false);
                        break;
                    default :
                        lblEstadoServicio.Text = "INDEFINIDO";
                        habilitarBotones(true, false, false, false, false, false, false, false, false);
                        break;
                }

            }

            else
            {
                limpiarCampos();
                habilitarCampos(false);
                habilitarBotones(true, false, false, false, false, false, false, true, false);
            }
        }

        public void limpiarCampos()
        {
            this.txtBoxMontoTotal.Text = "0.00";
            this.txtBoxNombreCliente.Text = String.Empty;
            this.txtBoxObservaciones.Text = String.Empty;
            this.txtBoxResponsable1.Text = String.Empty;
            this.txtBoxResponsable2.Text = String.Empty;
            this.txtBoxResponsable3.Text = String.Empty;
            this.rBtnEfectivo.Checked = true;
            this.checkFactura.Checked = false;
            this.cBoxMonedas.SelectedIndex = -1;
            
        }
        public void habilitarCampos(bool EstadoHabilitacion)
        {
            this.rBtnEfectivo.Enabled = EstadoHabilitacion;
            this.rBtnCredito.Enabled = EstadoHabilitacion;
            this.checkFactura.Enabled = EstadoHabilitacion;
            cBoxMonedas.Enabled = EstadoHabilitacion;
            this.txtBoxObservaciones.ReadOnly = !EstadoHabilitacion;
            this.checkFactura.Checked = false;
            this.cBoxMonedas.Enabled = EstadoHabilitacion;
            dtGVServiciosDetalle.ReadOnly = !EstadoHabilitacion;
            DGCPrecioTotal.ReadOnly = true;

            btnAgregarCliente.Enabled = EstadoHabilitacion;
            btnAgregarPersonas1.Enabled = EstadoHabilitacion;
            btnAgregarPersonas2.Enabled = EstadoHabilitacion;
            btnAgregarPersonas3.Enabled = EstadoHabilitacion;
            btnBuscarCliente.Enabled = EstadoHabilitacion;
            btnBuscarResponsable1.Enabled = EstadoHabilitacion;
            btnBuscarResponsable2.Enabled = EstadoHabilitacion;
            btnBuscarResponsable3.Enabled = EstadoHabilitacion;
            bindingNavigator1.Enabled = EstadoHabilitacion;
        }

        public bool verificarDatos()
        {
            errorProvider1.Clear();
            if (String.IsNullOrEmpty(txtBoxNombreCliente.Text))
            {
                errorProvider1.SetError(txtBoxNombreCliente, "Aún no ha seleccionado un Cliente");
                return false;
            }
            if (string.IsNullOrEmpty(txtBoxResponsable1.Text))
            {
                errorProvider1.SetError(txtBoxResponsable1, "Aún no ha seleccionad una Persona que se hará Responsable del Servicio");
                return false;
            }
            if (cBoxMonedas.SelectedIndex == -1)
            {
                errorProvider1.SetError(cBoxMonedas, "No ha Seleccionado una Moneda para la Transacción");
                return false;
            }

            if (dtGVServiciosDetalle.RowCount == 0)
            {
                errorProvider1.SetError(dtGVServiciosDetalle, "la Solicitud de la venta de Servicios, no tiene un detalle");
                MessageBox.Show("La Solicitud de la venta de Servicios, no tiene un detalle");
                return false;
            }
            return true;
        }

        public void habilitarBotones(bool nuevo, bool cancelar, bool modificar, bool aceptar, bool anular, bool finalizar, bool reportes, bool buscar, bool cobrar)
        {
            this.tBtnNuevo.Enabled = nuevo;
            this.tBtnCancelar.Enabled = cancelar;
            this.tBtnModificar.Enabled = modificar;
            this.tBtnAceptar.Enabled = aceptar;
            this.tBtnAnular.Enabled = anular;
            this.tBtnFinalizar.Enabled = finalizar;
            this.tBtnReportes.Enabled = reportes;
            this.tBtnBuscar.Enabled = buscar;
            this.tBtnCobrar.Enabled = cobrar;
        }

        private void tBtnNuevo_Click(object sender, EventArgs e)
        {
            habilitarBotones(false, true, false, true, false, false, false, false, false);
            DTVentasServiciosDetalleTemporal.Clear();
            bindingSourceServicios.DataSource = DTVentasServiciosDetalleTemporal;
            bindingNavigator1.BindingSource = bindingSourceServicios;
            dtGVServiciosDetalle.DataSource = bindingSourceServicios;
            limpiarCampos();
            habilitarCampos(true);
            TipoOperacion = "N";
        }

        private void tBtnCancelar_Click(object sender, EventArgs e)
        {
            TipoOperacion = "";
            cargarDatosVentasServcios(NumeroVentaServicio);
            
        }

        private void tBtnModificar_Click(object sender, EventArgs e)
        {
            habilitarBotones(false, true, false, true, false, false, false, false, false);
            habilitarCampos(true);
            DTVentasServiciosDetalleTemporal.Clear();

            foreach (DSDoblones20GestionComercial2.VentasServiciosDetalleRow DRVentasServiciosDetalle in DTVentasServiciosDetalle.Rows)
            {
                DTVentasServiciosDetalleTemporal.Rows.Add(new object[] { DRVentasServiciosDetalle.CodigoServicio, DRVentasServiciosDetalle.CantidadVentaServicio, DRVentasServiciosDetalle.PrecioUnitario, DRVentasServiciosDetalle.TiempoGarantiaDias });
            }
            DTVentasServiciosDetalleTemporal.AcceptChanges();
            bindingSourceServicios.DataSource = DTVentasServiciosDetalleTemporal;
            bindingNavigator1.BindingSource = bindingSourceServicios;
            dtGVServiciosDetalle.DataSource = bindingSourceServicios;
            TipoOperacion = "E";
        }

        private void tBtnAceptar_Click(object sender, EventArgs e)
        {
            if (verificarDatos())
            {
                try
                {
                    DTVentasServiciosDetalleTemporal.AcceptChanges();
                    string VentaServicioDetallXML = DTVentasServiciosDetalleTemporal.DataSet.GetXml();
                    Clipboard.SetText(VentaServicioDetallXML);
                    string DIResponsable1, DIResponsable2, DIResponsable3 = String.Empty;
                    int CodigoCliente = DTClientes[0].CodigoCliente;
                    decimal PrecioTotal = decimal.Parse(DTVentasServiciosDetalleTemporal.Compute("sum(PrecioTotal)", "").ToString());
                    DIResponsable1 = txtBoxResponsable1.Text.Substring(txtBoxResponsable1.Text.IndexOf("(") + 1, txtBoxResponsable1.Text.Length - txtBoxResponsable1.Text.IndexOf("(") - 2);
                    DIResponsable2 = string.IsNullOrEmpty(txtBoxResponsable2.Text) ? null : txtBoxResponsable2.Text.Substring(txtBoxResponsable2.Text.IndexOf("(") + 1, txtBoxResponsable2.Text.Length - txtBoxResponsable2.Text.IndexOf("(") - 2);
                    DIResponsable3 = string.IsNullOrEmpty(txtBoxResponsable3.Text) ? null : txtBoxResponsable3.Text.Substring(txtBoxResponsable3.Text.IndexOf("(") + 1, txtBoxResponsable3.Text.Length - txtBoxResponsable3.Text.IndexOf("(") - 2);

                    

                    if (TipoOperacion == "N")
                    {
                        
                        _VentasServiciosCLN.InsertarVentaServicio(NumeroAgencia, CodigoUsuario, 
                            DIResponsable1.Trim(),
                            String.IsNullOrEmpty(DIResponsable2) ? null : DIResponsable2.Trim(),
                            String.IsNullOrEmpty(DIResponsable3) ? null :DIResponsable3.Trim(),
                            CodigoCliente, null, null, "I", rBtnEfectivo.Checked ? "E":"C",
                            PrecioTotal,
                            checkFactura.Checked ? (int?)(-1) : null, 
                            null, byte.Parse(cBoxMonedas.SelectedValue.ToString()),
                            txtBoxObservaciones.Text, VentaServicioDetallXML
                            );

                        NumeroVentaServicio = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("VentasServicios");
                        
                    }

                    if (TipoOperacion == "E")
                    {
                        _VentasServiciosCLN.ActualizarVentaServicio(NumeroAgencia, NumeroVentaServicio,
                            CodigoUsuario,
                            DIResponsable1.Trim(),
                            String.IsNullOrEmpty(DIResponsable2) ? null : DIResponsable2.Trim(),
                            String.IsNullOrEmpty(DIResponsable3) ? null : DIResponsable3.Trim(),
                            CodigoCliente, null, null, "I", rBtnEfectivo.Checked ? "E" : "C",
                            PrecioTotal,
                            null, null, byte.Parse(cBoxMonedas.SelectedValue.ToString()),
                            txtBoxObservaciones.Text, VentaServicioDetallXML);
                    }
                    cargarDatosVentasServcios(NumeroVentaServicio);
                    habilitarCampos(false);
                    habilitarBotones(true, false, true, false, true, false, true, true, true);
                    TipoOperacion = "";
                    MessageBox.Show(this, "Se registró correctamente los cambios realizados", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Ocurrió la Siguiente Excepción " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
            else
                MessageBox.Show(this, "Revise sus datos, le falta llenar valores para algunos campos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FBuscarClientes _FBuscarClientes = new FBuscarClientes();
            _FBuscarClientes.ShowDialog(this);
            int CodigoCliente = _FBuscarClientes.CodigoCliente;
            if (CodigoCliente > 0)
            {
                DTClientes =  (DSDoblones20GestionComercial.ClientesDataTable)_ClientesCLN.ObtenerCliente(CodigoCliente);
                txtBoxNombreCliente.Text = DTClientes[0].NombreCliente;
            }

        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            FClientes _FClientes = new FClientes(true, false, false, false);
            _FClientes.ShowDialog(this);
            int CodigoCliente = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("Clientes");
            if (CodigoCliente > 0)
            {
                DTClientes = (DSDoblones20GestionComercial.ClientesDataTable)_ClientesCLN.ObtenerCliente(CodigoCliente);
                txtBoxNombreCliente.Text = DTClientes[0].NombreCliente;
            }
        }

        private void btnBuscarResponsable1_Click(object sender, EventArgs e)
        {
            Button btnBusquedaActivado = sender as Button;
            //txtBoxResponsable1
            TextBox txtBoxResponsable = (TextBox)this.Controls.Find("txtBoxResponsable" + btnBusquedaActivado.Name.Substring(btnBusquedaActivado.Name.Length - 1), true)[0];
            
            FormulariosSistema.FBuscarPersonas _FBuscarPersonas = new WFADoblones20.FormulariosSistema.FBuscarPersonas();
            _FBuscarPersonas.ShowDialog(this);
            string DIPersonaResponsable = _FBuscarPersonas.DISeleccionado;
            if (!string.IsNullOrEmpty(DIPersonaResponsable))
            {
                txtBoxResponsable.Text = _PersonasCLN.ObtenerNombreCompleto(DIPersonaResponsable).Trim() + " - (" + DIPersonaResponsable+")";
            }
        }

        private void btnAgregarPersonas1_Click(object sender, EventArgs e)
        {
            Button btnBusquedaActivado = sender as Button;            
            TextBox txtBoxResponsable = (TextBox)this.Controls.Find("txtBoxResponsable" + btnBusquedaActivado.Name.Substring(btnBusquedaActivado.Name.Length - 1), true)[0];
            FormulariosSistema.FPersonas _FPersonas = new WFADoblones20.FormulariosSistema.FPersonas(true, false, false, false);
            _FPersonas.ShowDialog(this);
            string DIPersonaResponsable = _FPersonas.DIPersona;
            if (!string.IsNullOrEmpty(DIPersonaResponsable))
            {
                txtBoxResponsable.Text = _PersonasCLN.ObtenerNombreCompleto(DIPersonaResponsable).Trim() + " - (" + DIPersonaResponsable + ")";
            }
        }

        private void dtGVServiciosDetalle_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(this, "No Puede ingresar Servicios Repetidos", "Venta de Servicios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //DTVentasServiciosDetalleTemporal.RejectChanges();
            
        }

        private void tBtnAnular_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Se encuentra seguro de Anular la solicitud de venta de Servicios?", "Anulación de Venta de Servicios", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _VentasServiciosCLN.ActualizarCodigoEstadoVentaServicio(NumeroAgencia, NumeroVentaServicio, "A");
                    cargarDatosVentasServcios(NumeroVentaServicio);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Ocurrió la Siguiente Excepcion : " + ex.Message, "Venta de Servicios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void tBtnFinalizar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "La Finalización de Venta de Servicios implica la culminación completa de los mismos. ¿Se encuentra seguro de Finalizar la solicitud de venta de Servicios?", "Anulación de Venta de Servicios", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _VentasServiciosCLN.ActualizarCodigoEstadoVentaServicio(NumeroAgencia, NumeroVentaServicio, "F");
                    cargarDatosVentasServcios(NumeroVentaServicio);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Ocurrió la Siguiente Excepcion : " + ex.Message, "Venta de Servicios", MessageBoxButtons.OK, MessageBoxIcon.Stop);                    
                }
            }
        }

        private void tBtnCobrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "El Cobro de servicio implica recepción monetaria por los servicios que se provee al Cliene. ¿Se encuentra seguro de realizar el Cobor por la solicitud de venta de Servicios?", "Anulación de Venta de Servicios", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _VentasServiciosCLN.ActualizarCodigoEstadoVentaServicio(NumeroAgencia, NumeroVentaServicio, "P");
                    cargarDatosVentasServcios(NumeroVentaServicio);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Ocurrió la Siguiente Excepcion : " + ex.Message, "Venta de Servicios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        public void cargarDetalleConFactura(DSDoblones20GestionComercial2.VentasServiciosDetalleDataTable DTVServiciosDetalle, object sender)
        {
            decimal FactorCambioMoneda = 1;
            int CodigoMonedaSeleccionada = int.Parse(cBoxMonedas.SelectedValue.ToString());
            //if (sender.GetType().Name.CompareTo("ComboBox") == 0)
            //MessageBox.Show(sender.GetType().Name);
            if (CodigoMonedaSistema != CodigoMonedaSeleccionada)
            {
                FactorCambioMoneda = _TransaccionesUtilidadesCLN.ObtenerFactorCambioCotizacion(CodigoMonedaSistema, _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor(), int.Parse(cBoxMonedas.SelectedValue.ToString()));
                if(FactorCambioMoneda == -1)
                    FactorCambioMoneda = _TransaccionesUtilidadesCLN.ObtenerFactorCambioCotizacion(CodigoMonedaSistema, null, int.Parse(cBoxMonedas.SelectedValue.ToString()));
            }
            if (sender.GetType().Name.CompareTo("ComboBox") == 0)
            {

            }
            else if (sender.GetType().Name.CompareTo("CheckBox") == 0)  
            {
                foreach (DSDoblones20GestionComercial2.VentasServiciosDetalleRow DRServicioDetalle in DTVServiciosDetalle.Rows)
                {
                    if (checkFactura.Checked)//cuando se encuentra con Factura
                    {
                        if (CodigoMonedaSeleccionada == CodigoMonedaSistema)
                        {
                            DRServicioDetalle.PrecioUnitario = Math.Round(DRServicioDetalle.PrecioUnitario + DRServicioDetalle.PrecioUnitario * PorcentajeImpuestoSistema / 100, 2);
                        }
                        else
                        {
                            DRServicioDetalle.PrecioUnitario = DRServicioDetalle.PrecioUnitario * FactorCambioMoneda;
                            DRServicioDetalle.PrecioUnitario = Math.Round(DRServicioDetalle.PrecioUnitario + DRServicioDetalle.PrecioUnitario * PorcentajeImpuestoSistema / 100, 2);
                        }
                    }
                    else
                    {
                        if (CodigoMonedaSeleccionada == CodigoMonedaSistema)
                            DTVServiciosDetalle.RejectChanges();
                        else
                        {
                            DRServicioDetalle.PrecioUnitario = Math.Round(DRServicioDetalle.PrecioUnitario / FactorCambioMoneda, 2);
                        }
                    }
                }
            }
            else
            {
            }
            
        }

        private void checkFactura_CheckedChanged(object sender, EventArgs e)
        {
            if (TipoOperacion == "I" || TipoOperacion == "E")
                cargarDetalleConFactura(DTVentasServiciosDetalleTemporal, sender);
        }

        private void tBtnVerOtraMoneda_Click(object sender, EventArgs e)
        {
            FCambiarMonedaCotizacionDeTransaccionesGC formCambioMoneda;
            if (tBtnAceptar.Enabled)
            {
                DTVentasServiciosDetalleTemporal.AcceptChanges();
                DataTable DTAuxiliar = DTVentasServiciosDetalleTemporal.Copy();
                DTAuxiliar.Columns.Add("NombreServicio", Type.GetType("System.String"));
                DTAuxiliar.Columns.Add("Cantidad", Type.GetType("System.Int32"));
                DTAuxiliar.Columns.Add("Precio", Type.GetType("System.Decimal"));
                DTAuxiliar.Columns["PrecioTotal"].Expression = String.Empty;
                DTAuxiliar.Columns["PrecioTotal"].ReadOnly = false;
                foreach (DataRow DRAuxiliar in DTAuxiliar.Rows)
                {
                    DRAuxiliar["NombreServicio"] = DTServicios.Rows.Find(DRAuxiliar["CodigoServicio"])["NombreServicio"];
                    DRAuxiliar["Cantidad"] = DRAuxiliar["CantidadVentaServicio"];
                    DRAuxiliar["Precio"] = DRAuxiliar["PrecioUnitario"];
                    DRAuxiliar["PrecioTotal"] = Math.Round( decimal.Parse(DRAuxiliar["PrecioUnitario"].ToString()) * int.Parse(DRAuxiliar["CantidadVentaServicio"].ToString()),2);
                }
                DTAuxiliar.AcceptChanges();
                formCambioMoneda = new FCambiarMonedaCotizacionDeTransaccionesGC(DTAuxiliar, NumeroPC, NumeroAgencia, NumeroVentaServicio, _TransaccionesUtilidadesCLN, 'I');
                formCambioMoneda.DarEstiloParaVentasServicios(DTVentasServiciosDetalleTemporal);
            }
            else
            {
                formCambioMoneda = new FCambiarMonedaCotizacionDeTransaccionesGC(DTVentasServiciosDetalle, NumeroPC, NumeroAgencia, NumeroVentaServicio, _TransaccionesUtilidadesCLN, 'F');
                formCambioMoneda.DarEstiloParaVentasServicios(DTVentasServiciosDetalle);
            }
            
            formCambioMoneda.ShowDialog(this);
            formCambioMoneda.Dispose();
        }

        private void tBtnBuscar_Click(object sender, EventArgs e)
        {
            FBuscarTransaccion formBuscarTransaccion = new FBuscarTransaccion(NumeroAgencia);
            formBuscarTransaccion.formatearEstiloParaVentasServicios();
            formBuscarTransaccion.ShowDialog(this);
            if (formBuscarTransaccion.NumeroTransaccion > 0)
            {
                NumeroVentaServicio = formBuscarTransaccion.NumeroTransaccion;
                cargarDatosVentasServcios(NumeroVentaServicio);
                formBuscarTransaccion.Dispose();
            }
            else
                MessageBox.Show(this, "No se encontró ninguna Venta de Servicios con los parametros provistos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tBtnAgregarServicio_Click(object sender, EventArgs e)
        {
            FServicios _FServicios = new FServicios();
            _FServicios.ShowDialog(this);
            int CodigoServicio = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("Servicios");
            DataRow DTRServicioNuevo = DTServicios.Rows.Find(CodigoServicio);
            if (DTRServicioNuevo == null)
            {
                DTServicios.Rows.Add(_ServiciosCLN.ObtenerServicio(CodigoServicio)[0].ItemArray);

                DTServicios.DefaultView.Sort = "NombreServicio ASC";


            }
        }

        private void dtGVServiciosDetalle_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (TipoOperacion =="N" && dtGVServiciosDetalle.IsCurrentCellDirty && dtGVServiciosDetalle.CurrentCell.ColumnIndex == DGCCodigoServicio.Index)
            {
                dtGVServiciosDetalle.CommitEdit(DataGridViewDataErrorContexts.Commit);
                //dtGVServiciosDetalle[dtGVServiciosDetalle.CurrentRow.Index, DGCPrecioUnitario.Index].Value = 9;
            }
        }

        private void dtGVServiciosDetalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (TipoOperacion =="N" && dtGVServiciosDetalle.RowCount > 0 && dtGVServiciosDetalle.CurrentRow != null && DGCCodigoServicio.Index == e.ColumnIndex)
            {
                string codigoServicio = dtGVServiciosDetalle[e.ColumnIndex, e.RowIndex].Value.ToString();
                //MessageBox.Show(DGCCodigoServicio.Items.Count.ToString() +", fila " + e.RowIndex.ToString() + ", Value " + codigoServicio);
                DSDoblones20GestionComercial2.ServiciosRow DRServicioSeleccionado = DTServicios.FindByCodigoServicio(int.Parse(codigoServicio));
                if (DRServicioSeleccionado != null)
                {
                    dtGVServiciosDetalle[DGCPrecioUnitario.Index, e.RowIndex].Value = DTServicios.FindByCodigoServicio(int.Parse(codigoServicio)).PrecioUnitario;
                    //dtGVServiciosDetalle.EndEdit(DataGridViewDataErrorContexts.Commit);
                }
                
            }
        }

        private void dtGVServiciosDetalle_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int CantidadNuevaDeServicio;
            decimal PrecioNuevoServicio;
            this.dtGVServiciosDetalle.Rows[e.RowIndex].ErrorText = "";
            if (this.dtGVServiciosDetalle.Rows[e.RowIndex].IsNewRow) { return; }

            if (this.dtGVServiciosDetalle.IsCurrentCellDirty)
            {
                switch (this.dtGVServiciosDetalle.Columns[e.ColumnIndex].Name)
                {

                    case "DGCCantidadVentaServicio": 
                        if (e.FormattedValue.ToString().Trim().Length < 1)
                        {
                            this.dtGVServiciosDetalle.Rows[e.RowIndex].ErrorText = "   La Cantidad a entregar es necesaria y no puede estar vacia.";
                            e.Cancel = true;
                        }
                        else if (!int.TryParse(e.FormattedValue.ToString(), out CantidadNuevaDeServicio) || CantidadNuevaDeServicio <= 0)
                        {
                            this.dtGVServiciosDetalle.Rows[e.RowIndex].ErrorText = "   La Cantidad a entregar debe ser un entero positivo.";
                            e.Cancel = true;
                            return;
                        }                        
                        break;
                    case "DGCPrecioUnitario":
                        if (!decimal.TryParse(e.FormattedValue.ToString(), out PrecioNuevoServicio) || PrecioNuevoServicio <= 0)
                        {
                            this.dtGVServiciosDetalle.Rows[e.RowIndex].ErrorText = "   El Precio del Servicio debe ser un entero positivo.";
                            e.Cancel = true;
                            return;
                        }
                        break;

                }

            }
        }

    }
}
