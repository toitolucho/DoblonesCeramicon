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
using System.Collections;
using WFADoblones20.ReportesGestionComercial;
using WFADoblones20.FormulariosSistema;
using System.Globalization;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FCreditos : Form
    {
        private AgenciasCLN Agencias = new AgenciasCLN();
        private MonedasCLN Monedas = new MonedasCLN();
        private CreditosCLN Creditos = new CreditosCLN();
        private CreditosCuotasCLN CreditosCuotas = new CreditosCuotasCLN();
        private CreditosCuotasPagosCLN CreditosCuotasPagos = new CreditosCuotasPagosCLN();
        private FrecuenciasPagosCLN FrecuenciasPagos = new FrecuenciasPagosCLN();
        private PersonasCLN Personas = new PersonasCLN();
        private TransaccionesUtilidadesCLN TransaccionesUtilidades = new TransaccionesUtilidadesCLN();

        private DataTable RBCreditos = new DataTable();

        private int CodigoUsuario = 0;
        private int NumeroPC = 0;
        private int NumeroAgencia = 0;
        private int NumeroDiasFrecuenciaPago = 0;
        private string TipoOperacion = "";

        private int NumeroCredito = 0;
        private string Moneda = "";
        private decimal MontoLimite = 0.00m;
        private bool CotizacionEncontrada = false;


        string TipoOperacionProductosDescripcion = "";
        int FilaActual = 0;



        public FCreditos(int na, int npc, int cu, bool PermitirInsertar, bool PermitirEditar, bool PermitirEliminar, bool PermitirNavegar)
        {
            InitializeComponent();

            this.NumeroAgencia = na;
            this.NumeroPC = npc;
            this.CodigoUsuario = cu;
            
            this.bNuevo.Visible = PermitirInsertar;
            this.bEditar.Visible = PermitirEditar;
            this.bEliminar.Visible = PermitirEliminar;
            this.bCancelar.Visible = (PermitirInsertar || PermitirEditar) ? true : false;
            this.bAceptar.Visible = (PermitirInsertar || PermitirEditar) ? true : false;
            this.bBuscar.Visible = PermitirNavegar;
        }

        private void CargarSistemasAmortizacion()
        {
            ArrayList SistemasAmortizacion = new ArrayList();
            SistemasAmortizacion.Add(new SistemaAmortizacion("A", "Cuota variable (ALEMAN)"));
            SistemasAmortizacion.Add(new SistemaAmortizacion("F", "Cuota fija (FRANCES)"));

            cBSistemaAmortizacion.DataSource = SistemasAmortizacion;
            cBSistemaAmortizacion.DisplayMember = "NombreSistemaAmortizacion";
            cBSistemaAmortizacion.ValueMember = "CodigoSistemaAmortizacion";
        }

        private void CargarMonedas()
        {
            DataTable DTMonedas = new DataTable();
            DTMonedas = Monedas.ListarMonedas();
            cBMoneda.DataSource = DTMonedas.DefaultView;
            cBMoneda.DisplayMember = "NombreMoneda";
            cBMoneda.ValueMember = "CodigoMoneda";
        }

        private void CargarFrecuenciasPagos()
        {
            DataTable DTFrecuenciasPagos = new DataTable();
            DTFrecuenciasPagos = FrecuenciasPagos.ListarFrecuenciasPagos();
            cBFrecuenciaPago.DataSource = DTFrecuenciasPagos.DefaultView;
            cBFrecuenciaPago.DisplayMember = "NombreFrecuenciaPago";
            cBFrecuenciaPago.ValueMember = "CodigoFrecuenciaPago";
        }
        
        private void CargarTipoEstadosCreditosNavegacion()
        {
            ArrayList TiposEstadosCreditos = new ArrayList();
            TiposEstadosCreditos.Add(new TipoEstadoCredito("A", "AUTORIZADO"));
            TiposEstadosCreditos.Add(new TipoEstadoCredito("R", "RECHAZADO"));
            TiposEstadosCreditos.Add(new TipoEstadoCredito("P", "PAGADO"));
            TiposEstadosCreditos.Add(new TipoEstadoCredito("S", "SOLICITADO"));

            cBEstadoCredito.DataSource = null;
            cBEstadoCredito.Items.Clear();
            cBEstadoCredito.DataSource = TiposEstadosCreditos;
            cBEstadoCredito.DisplayMember = "NombreTipoEstadoCredito";
            cBEstadoCredito.ValueMember = "CodigoTipoEstadoCredito";
        }


        private void CargarTipoEstadosCreditosEdicion()
        {
            ArrayList TiposEstadosCreditos = new ArrayList();
            TiposEstadosCreditos.Add(new TipoEstadoCredito("A", "AUTORIZADO"));
            TiposEstadosCreditos.Add(new TipoEstadoCredito("R", "RECHAZADO"));
            TiposEstadosCreditos.Add(new TipoEstadoCredito("S", "SOLICITADO"));

            cBEstadoCredito.DataSource = null;
            cBEstadoCredito.Items.Clear();
            cBEstadoCredito.DataSource = TiposEstadosCreditos;
            cBEstadoCredito.DisplayMember = "NombreTipoEstadoCredito";
            cBEstadoCredito.ValueMember = "CodigoTipoEstadoCredito";
        }

        private void CargarMediosPagos()
        {
            ArrayList MediosPagos = new ArrayList();
            MediosPagos.Add(new MedioPago("E", "EFECTIVO"));
            MediosPagos.Add(new MedioPago("C", "CHEQUE"));
            MediosPagos.Add(new MedioPago("D", "DEPOSITO"));

            dGVTBCMedioPago.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            dGVTBCMedioPago.DataSource = MediosPagos;
            dGVTBCMedioPago.DataPropertyName = "CodigoMedioPago";
            dGVTBCMedioPago.DisplayMember = "NombreMedioPago";
            dGVTBCMedioPago.ValueMember = "CodigoMedioPago";
        }

        private void CargarTiposCreditos()
        {
            ArrayList ALTiposCreditos = new ArrayList();
            ALTiposCreditos.Add(new TiposCreditos("L", "LIBRE DISPONIBILIDAD"));
            ALTiposCreditos.Add(new TiposCreditos("T", "POR MONTO TOTAL VENTA"));
            ALTiposCreditos.Add(new TiposCreditos("P", "POR MONTO PARCIAL VENTA"));

            cBTipoCredito.DataSource = null;
            cBTipoCredito.Items.Clear();
            cBTipoCredito.DataSource = ALTiposCreditos;
            cBTipoCredito.DisplayMember = "NombreTipoCredito";
            cBTipoCredito.ValueMember = "CodigoTipoCredito";
        }

        private void CargarAgenciasCotizacion()
        {
            DataTable DTAgencias = new DataTable();
            DTAgencias = Agencias.ListarAgencias();
            cBNumeroAgenciaCotizacion.DataSource = DTAgencias.DefaultView;
            cBNumeroAgenciaCotizacion.DisplayMember = "NombreAgencia";
            cBNumeroAgenciaCotizacion.ValueMember = "NumeroAgencia";
        }

        private void InhabilitarControles(bool Estado)
        {
            //tBNumeroCredito.ReadOnly = Estado;
            tBDIDeudor.ReadOnly = Estado;
            bBuscarDeudor.Enabled = Estado;
            bAgregarPersonaDeudor.Enabled = Estado;
            tBDIGarante1.ReadOnly = Estado;
            bBuscarGarante1.Enabled = Estado;
            bAgregarPersonaGarante1.Enabled = Estado;
            tBDIGarante2.ReadOnly = Estado;
            bBuscarGarante2.Enabled = Estado;
            bAgregarPersonaGarante2.Enabled = Estado;
            tBDIGarante3.ReadOnly = Estado;
            bBuscarGarante3.Enabled = Estado;
            bAgregarPersonaGarante3.Enabled = Estado;
            tBDIGarante4.ReadOnly = Estado;
            bBuscarGarante4.Enabled = Estado;
            bAgregarPersonaGarante4.Enabled = Estado;
            tBDIGarante5.ReadOnly = Estado;
            bBuscarGarante5.Enabled = Estado;
            bAgregarPersonaGarante5.Enabled = Estado;
            cBTipoCredito.Enabled = !Estado;
            cBNumeroAgenciaCotizacion.Enabled = !Estado;
            tBNumeroCotizacion.ReadOnly = Estado;
            bBuscarCotizacion.Enabled = !Estado;
            cBSistemaAmortizacion.Enabled = !Estado;
            mTBMontoCredito.ReadOnly = Estado;
            cBMoneda.Enabled = !Estado;
            cBFrecuenciaPago.Enabled = !Estado;
            nUDNumeroPeriodos.Enabled = !Estado;
            nUDInteresAnual.Enabled = !Estado;
            nUDInteresAnualMora.Enabled = !Estado;
            dTPFechaPrimerPago.Enabled = !Estado;
            //mTBMontoDisponible.ReadOnly = Estado;
            tBObservaciones.ReadOnly = Estado;
            cBRegistrarAsientoContable.Enabled = !Estado;

            /*tBNumeroAgenciaSolicitud.ReadOnly = Estado;
            tBUsuarioSolicitud.ReadOnly = Estado;
            tBFechaHoraSolicitud.ReadOnly = Estado;
            tBNumeroAgenciaAutorizacion.ReadOnly = Estado;
            tBUsuarioAutorizacion.ReadOnly = Estado;
            tBFechaHoraAutorizacion.ReadOnly = Estado;
            tBCodigoAutorizacion.ReadOnly = Estado;*/
            
            cBEstadoCredito.Enabled = !Estado;
            
            bBuscarDeudor.Enabled = !Estado;
            bBuscarGarante1.Enabled = !Estado;
            bBuscarGarante2.Enabled = !Estado;
            bBuscarGarante3.Enabled = !Estado;
            bBuscarGarante4.Enabled = !Estado;
            bBuscarGarante5.Enabled = !Estado;
        }

        private void InicializarControles()
        {
            tBNumeroCredito.Text = "";
            tBDIDeudor.Text = "";
            tBNombreCompletoDeudor.Text = "";
            tBDIGarante1.Text = "";
            tBNombreCompletoGarante1.Text = "";
            tBDIGarante2.Text = "";
            tBNombreCompletoGarante2.Text = "";
            tBDIGarante3.Text = "";
            tBNombreCompletoGarante3.Text = "";
            tBDIGarante4.Text = "";
            tBNombreCompletoGarante4.Text = "";
            tBDIGarante5.Text = "";
            tBNombreCompletoGarante5.Text = "";

            cBTipoCredito.SelectedIndex = 1;
            cBNumeroAgenciaCotizacion.SelectedIndex = -1;
            tBNumeroCotizacion.Text = "";
           
            mTBMontoCredito.Text = "";
            cBMoneda.SelectedIndex = 0;
            cBFrecuenciaPago.SelectedIndex = 3;
            nUDNumeroPeriodos.Value = 0;
            nUDInteresAnual.Value = 0;
            nUDInteresAnualMora.Value = 0;
            dTPFechaPrimerPago.Value = DateTime.Now;
            mTBMontoDisponible.Text = "";
            tBObservaciones.Text = "";
            cBRegistrarAsientoContable.Checked = true;

            if (TipoOperacion == "I")
            {
                CargarTipoEstadosCreditosEdicion();

                tBNumeroAgenciaSolicitud.Text = NumeroAgencia.ToString();
                tBUsuarioSolicitud.Text = CodigoUsuario.ToString();
                tBFechaHoraSolicitud.Text = TransaccionesUtilidades.ObtenerFechaHoraServidor().ToString();
                    
            }
            else
            {
                CargarTipoEstadosCreditosNavegacion();

                tBNumeroAgenciaSolicitud.Text = "";
                tBUsuarioSolicitud.Text = "";
                tBFechaHoraSolicitud.Text = "";
            }

            tBNumeroAgenciaAutorizacion.Text = "";
            tBUsuarioAutorizacion.Text = "";
            tBFechaHoraAutorizacion.Text = "";

            cBEstadoCredito.SelectedIndex = 2;

            tBCodigoAutorizacion.Text = "";

            NumeroDiasFrecuenciaPago = 30;
        }
    
        private void bNuevo_Click(object sender, EventArgs e)
        {
            TipoOperacion = "I";

            InhabilitarControles(false);
            InicializarControles();
            bNuevo.Enabled = false;
            bEditar.Enabled = false;
            bEliminar.Enabled = false;
            bAceptar.Enabled = true;
            bCancelar.Enabled = true;

            tBNumeroCredito.Focus();
        }

        private void bEditar_Click(object sender, EventArgs e)
        {
            TipoOperacion = "E";
            string CodEstCred = cBEstadoCredito.SelectedValue.ToString();
            CargarTipoEstadosCreditosEdicion();
            cBEstadoCredito.SelectedValue = CodEstCred;
            InhabilitarControles(false);

            bNuevo.Enabled = false;
            bEditar.Enabled = false;
            bEliminar.Enabled = false;
            bAceptar.Enabled = true;
            bCancelar.Enabled = true;
            tBNumeroCredito.Focus();
        }

        private void bEliminar_Click(object sender, EventArgs e)
        {
            string Mensaje = "Esta seguro que desea eliminar el registro actual, recuerde que una vez aceptada la operacion es irreversible.";
            string Titulo = "Confimarción eliminación registro";
            MessageBoxButtons Botones = MessageBoxButtons.YesNo;
            MessageBoxIcon Icono = MessageBoxIcon.Exclamation;
            DialogResult result;

            result = MessageBox.Show(Mensaje, Titulo, Botones, Icono);

            if (result == DialogResult.Yes)
            {
                Creditos.EliminarCredito(int.Parse(tBNumeroCredito.Text));                
                InhabilitarControles(true);
                InicializarControles();
                bNuevo.Enabled = true;
                bEditar.Enabled = false;
                bEliminar.Enabled = false;
                bAceptar.Enabled = false;
                bCancelar.Enabled = false;
            }
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            string DIDeudor = null;
            string DIGarante1 = null;
            string DIGarante2 = null;
            string DIGarante3 = null;
            string DIGarante4 = null;
            string DIGarante5 = null;
            string CodigoTipoCredito = null;
            int? NumeroAgenciaCotizacion = null;
            int? NumeroCotizacion = null;
            string CodigoSistemaAmortizacion = null;
            decimal MontoDeuda = 0.0m;
            byte CodigoMoneda = 0;
            int CodigoFrecuenciaPago = 0;
            int NumeroPeriodos = 0;
            decimal InteresAnual = 0.00m;
            decimal InteresAnualMora = 0.00m;
            DateTime FechaPrimerPago = DateTime.Now;
            DateTime FechaUltimoPago = DateTime.Now;
            decimal MontoDisponible = 0.0m;
            string Observaciones = null;
            bool RegistrarContabilidad = true;
            int NumeroAgenciaSolicitud = 0;
            int CodigoUsuarioSolicitud = 0;
            DateTime FechaHoraSolicitud = DateTime.Now;
            int? NumeroAgenciaAutorizacion = null;
            int? CodigoUsuarioAutorizacion = null;
            DateTime? FechaHoraAutorizacion = DateTime.Now;
            string CodigoAutorizacion = null;
            string CodigoEstadoCredito = null;
            

            if (tBDIDeudor.Text.Trim().Length > 0)
                DIDeudor = tBDIDeudor.Text;
            else
            {
                string Mensaje = "No ingreso el Document Identificativo del deudor.";
                string Titulo = "Verificación Deudor Crédito";
                MessageBoxButtons Botones = MessageBoxButtons.OK;
                MessageBoxIcon Icono = MessageBoxIcon.Warning;

                MessageBox.Show(Mensaje, Titulo, Botones, Icono);
                return;
            }

            if (tBDIGarante1.Text.Trim().Length > 0)
                DIGarante1 = tBDIGarante1.Text;
            else
            {
                string Mensaje = "No ingreso el Documento Identificativo del primer garante del crédito, por lo menos debe existir un garante registrado.";
                string Titulo = "Verificación Garante 1 Crédito";
                MessageBoxButtons Botones = MessageBoxButtons.OK;
                MessageBoxIcon Icono = MessageBoxIcon.Warning;

                MessageBox.Show(Mensaje, Titulo, Botones, Icono);
                return;
            }
            
            if (tBDIGarante2.Text.Trim().Length > 0)
                DIGarante2 = tBDIGarante2.Text;
            if (tBDIGarante3.Text.Trim().Length > 0)
                DIGarante3 = tBDIGarante3.Text;
            if (tBDIGarante4.Text.Trim().Length > 0)
                DIGarante4 = tBDIGarante4.Text;
            if (tBDIGarante5.Text.Trim().Length > 0)
                DIGarante5 = tBDIGarante5.Text;

            if (cBTipoCredito.SelectedIndex > -1)
            {
                CodigoTipoCredito = cBTipoCredito.SelectedValue.ToString();

                if (cBTipoCredito.SelectedIndex > 0)
                {
                    //if (!CotizacionEncontrada)
                    //{
                    //    string Mensaje = "El numero de cotizacion no es valido, verifique la cotizacion para completar la operación.";
                    //    string Titulo = "Numero Cotizacion Invalido";
                    //    MessageBoxButtons Botones = MessageBoxButtons.OK;
                    //    MessageBoxIcon Icono = MessageBoxIcon.Warning;

                    //    MessageBox.Show(Mensaje, Titulo, Botones, Icono);

                    //    return;
                    //}

                    if (cBNumeroAgenciaCotizacion.SelectedIndex > -1)
                    {
                        NumeroAgenciaCotizacion = int.Parse(cBNumeroAgenciaCotizacion.SelectedValue.ToString());
                    }
                    else
                    {
                        string Mensaje = "Debe seleccionar una agencia donde se realizo una cotizacio previa, para este tipo de crédito.";
                        string Titulo = "Verificación agencia cotización";
                        MessageBoxButtons Botones = MessageBoxButtons.OK;
                        MessageBoxIcon Icono = MessageBoxIcon.Warning;

                        MessageBox.Show(Mensaje, Titulo, Botones, Icono);
                        return;
                    }

                    if (tBNumeroCotizacion.Text.Trim().Length > 0)
                    {
                        NumeroCotizacion = int.Parse(tBNumeroCotizacion.Text);
                    }
                    else
                    {
                        string Mensaje = "Debe seleccionar un numero de cotización realizada previamente, para este tipo de crédito.";
                        string Titulo = "Verificación número cotización";
                        MessageBoxButtons Botones = MessageBoxButtons.OK;
                        MessageBoxIcon Icono = MessageBoxIcon.Warning;

                        MessageBox.Show(Mensaje, Titulo, Botones, Icono);
                        return;
                    }
                }
            }

            if (cBSistemaAmortizacion.SelectedIndex > -1)
                CodigoSistemaAmortizacion = cBSistemaAmortizacion.SelectedValue.ToString();
       
            if (mTBMontoCredito.Text.Trim().Length > 0)
                MontoDeuda = decimal.Parse(mTBMontoCredito.Text);
            else
            {
                string Mensaje = "No ingreso un monto valido para el campo Monto Total Crédito.";
                string Titulo = "Verificación Monto Crédito";
                MessageBoxButtons Botones = MessageBoxButtons.OK;
                MessageBoxIcon Icono = MessageBoxIcon.Warning;

                MessageBox.Show(Mensaje, Titulo, Botones, Icono);
                return ;
            }

            if (cBMoneda.SelectedIndex > -1)
            {
                CodigoMoneda = byte.Parse(cBMoneda.SelectedValue.ToString());
                Moneda = cBMoneda.SelectedText;
            }

            if (cBFrecuenciaPago.SelectedIndex > -1)
                CodigoFrecuenciaPago = int.Parse(cBFrecuenciaPago.SelectedValue.ToString());
       
            if (nUDNumeroPeriodos.Value > 0)
                NumeroPeriodos = int.Parse(nUDNumeroPeriodos.Value.ToString());
            else
            {
                string Mensaje = "No ingresó una cantidad valida para el campo Número de Pagos.";
                string Titulo = "Verificación Numero de Pagos";
                MessageBoxButtons Botones = MessageBoxButtons.OK;
                MessageBoxIcon Icono = MessageBoxIcon.Warning;

                MessageBox.Show(Mensaje, Titulo, Botones, Icono);
                return;
            }

            if (decimal.Parse(nUDInteresAnual.Value.ToString()) > 0)
                InteresAnual = decimal.Parse(nUDInteresAnual.Value.ToString());

            if (decimal.Parse(nUDInteresAnual.Value.ToString()) > 0)
                InteresAnualMora = decimal.Parse(nUDInteresAnualMora.Value.ToString());

            FechaPrimerPago = dTPFechaPrimerPago.Value;
            FechaUltimoPago = DateTime.Parse(tBFechaUltimoPago.Text);
            MontoDisponible = decimal.Parse(mTBMontoDisponible.Text);

            if (tBObservaciones.Text.Trim().Length > 0)
                Observaciones = tBObservaciones.Text;

            RegistrarContabilidad = cBRegistrarAsientoContable.Checked;

            NumeroAgenciaSolicitud = NumeroAgencia;
            CodigoUsuarioSolicitud = CodigoUsuario;
            if (tBFechaHoraSolicitud.Text.Trim().Length > 0)
            {
                FechaHoraSolicitud = DateTime.Parse(tBFechaHoraSolicitud.Text);
            }

            if (tBNumeroAgenciaAutorizacion.Text.Trim().Length > 0)
            {
                NumeroAgenciaAutorizacion = int.Parse(tBNumeroAgenciaAutorizacion.Text);
            }

            if (tBUsuarioAutorizacion.Text.Trim().Length > 0)
            {
                CodigoUsuarioAutorizacion = int.Parse(tBUsuarioAutorizacion.Text);
            }

            if (tBFechaHoraAutorizacion.Text.Trim().Length > 0)
            {
                FechaHoraAutorizacion = DateTime.Parse(tBFechaHoraAutorizacion.Text);
            }

            if (tBCodigoAutorizacion.Text.Trim().Length > 0)
            {
                CodigoAutorizacion = tBCodigoAutorizacion.Text;
            }

            if (cBEstadoCredito.SelectedValue.ToString() == "A")
            {
                string Mensaje = "Esta seguro que desea autorizar el crédito, recuerde que posterior a esta acción, ya no podra cambiar ningun valor del crédito por que la operacion es irreversible.";
                string Titulo = "Confimarción autorización crédito";
                MessageBoxButtons Botones = MessageBoxButtons.YesNo;
                MessageBoxIcon Icono = MessageBoxIcon.Exclamation;
                DialogResult result;

                result = MessageBox.Show(Mensaje, Titulo, Botones, Icono);

                if (result == DialogResult.Yes)
                {
                    NumeroAgenciaAutorizacion = NumeroAgencia;
                    CodigoUsuarioAutorizacion = CodigoUsuario;
                    FechaHoraAutorizacion = TransaccionesUtilidades.ObtenerFechaHoraServidor();
                }
            }
            else
            {
                NumeroAgenciaAutorizacion = null;
                CodigoUsuarioAutorizacion = null;
                FechaHoraAutorizacion = null;
            }

               
            if (cBEstadoCredito.SelectedIndex > -1)
                CodigoEstadoCredito = cBEstadoCredito.SelectedValue.ToString();
       
            if (TipoOperacion == "I")
            {
                try
                {
                    Creditos.InsertarCredito(DIDeudor, DIGarante1, DIGarante2, DIGarante3, DIGarante4, DIGarante5,
                    CodigoTipoCredito, NumeroAgenciaCotizacion, NumeroCotizacion,
                    CodigoSistemaAmortizacion, MontoDeuda, CodigoMoneda, CodigoFrecuenciaPago, NumeroPeriodos,
                    decimal.Parse(nUDInteresAnual.Value.ToString()), decimal.Parse(nUDInteresAnualMora.Value.ToString()),
                    FechaPrimerPago, FechaUltimoPago, MontoDisponible, tBObservaciones.Text, cBRegistrarAsientoContable.Checked,
                    NumeroAgenciaSolicitud, CodigoUsuarioSolicitud, FechaHoraSolicitud,
                    NumeroAgenciaAutorizacion, CodigoUsuarioAutorizacion, FechaHoraAutorizacion,
                    tBCodigoAutorizacion.Text, CodigoEstadoCredito, ref NumeroCredito);

                    tBNumeroCredito.Text = NumeroCredito.ToString();
                    
                    //RBCreditos = Creditos.ObtenerCredito(NumeroCredito);
                
                    string Mensaje = "¿Desea ver el Plan de Pagos?.";
                    string Titulo = "Visualizacion Plan de Pagos";
                    MessageBoxButtons Botones = MessageBoxButtons.YesNo;
                    MessageBoxIcon Icono = MessageBoxIcon.Exclamation;
                    DialogResult result;

                    result = MessageBox.Show(Mensaje, Titulo, Botones, Icono);

                    if (result == DialogResult.Yes)
                    {
                        tCCreditos.SelectedIndex = 1;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo completar con exito el registro del respectivo crédito");
                }
                    
            }

            if (TipoOperacion == "E")
            {
                Creditos.ActualizarCredito(int.Parse(tBNumeroCredito.Text), DIDeudor, DIGarante1, DIGarante2, DIGarante3, DIGarante4, DIGarante5, CodigoTipoCredito, NumeroAgenciaCotizacion, NumeroCotizacion, CodigoSistemaAmortizacion,
                    MontoDeuda, CodigoMoneda, CodigoFrecuenciaPago, NumeroPeriodos, decimal.Parse(nUDInteresAnual.Value.ToString()), decimal.Parse(nUDInteresAnualMora.Value.ToString()),
                    FechaPrimerPago, FechaUltimoPago, MontoDisponible, tBObservaciones.Text, cBRegistrarAsientoContable.Checked,
                    NumeroAgenciaSolicitud, CodigoUsuarioSolicitud, FechaHoraSolicitud,
                    NumeroAgenciaAutorizacion, CodigoUsuarioAutorizacion, FechaHoraAutorizacion,
                    tBCodigoAutorizacion.Text, CodigoEstadoCredito);
                tBNumeroCredito.Text = NumeroCredito.ToString();
                RBCreditos = Creditos.ObtenerCredito(NumeroCredito);
            }


            InhabilitarControles(true);
            bNuevo.Enabled = true;

            if (CodigoEstadoCredito == "A" || CodigoEstadoCredito == "P")
            {
                bEditar.Enabled = false;
                bEliminar.Enabled = false;
            }
            else
            {
                bEditar.Enabled = true;
                bEliminar.Enabled = true;
            }

            bAceptar.Enabled = false;
            bCancelar.Enabled = false;
        }

        private string GenerarCodigoAutorizacion()
        {
            string Cadena = "";
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                Cadena += Convert.ToChar(r.Next(10) + 48);
            }

            return Cadena;
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            if (TipoOperacion == "E")
            {
                CargarControlesDeTabla();
            }
            else
            {
                InicializarControles();
            }
            
            TipoOperacion = "C";
            
            InhabilitarControles(true);
            bNuevo.Enabled = true;
            bEditar.Enabled = false;
            bEliminar.Enabled = false;
            bAceptar.Enabled = false;
            bCancelar.Enabled = false;
        }

        private void CargarControlesDeTabla()
        { 
            if (RBCreditos.Rows.Count > 0)
            {

                tBNumeroCredito.Text = RBCreditos.Rows[0][0].ToString();
                tBDIDeudor.Text = RBCreditos.Rows[0][1].ToString();
                tBDIGarante1.Text = RBCreditos.Rows[0][2].ToString();
                tBDIGarante2.Text = RBCreditos.Rows[0][3].ToString();
                tBDIGarante3.Text = RBCreditos.Rows[0][4].ToString();
                tBDIGarante4.Text = RBCreditos.Rows[0][5].ToString();
                tBDIGarante5.Text = RBCreditos.Rows[0][6].ToString();
                if ((RBCreditos.Rows[0][7].ToString() != null) && (RBCreditos.Rows[0][7].ToString() != ""))
                    cBTipoCredito.SelectedValue = RBCreditos.Rows[0][7].ToString();
                else
                    cBTipoCredito.SelectedIndex = -1;
                if ((RBCreditos.Rows[0][8].ToString() != null) && (RBCreditos.Rows[0][8].ToString() != ""))
                    cBNumeroAgenciaCotizacion.SelectedValue = RBCreditos.Rows[0][8].ToString();
                else
                    cBNumeroAgenciaCotizacion.SelectedIndex = -1;

                if ((RBCreditos.Rows[0][9].ToString() != null) && (RBCreditos.Rows[0][9].ToString() != ""))
                    tBNumeroCotizacion.Text = RBCreditos.Rows[0][9].ToString();
                else
                    tBNumeroCotizacion.Text = "";

                if ((RBCreditos.Rows[0][10].ToString() != null) && (RBCreditos.Rows[0][10].ToString() != ""))
                    cBSistemaAmortizacion.SelectedValue = RBCreditos.Rows[0][10].ToString();
                else
                    cBSistemaAmortizacion.SelectedIndex = -1;
                mTBMontoCredito.Text = RBCreditos.Rows[0][11].ToString();
                if ((RBCreditos.Rows[0][12].ToString() != null) && (RBCreditos.Rows[0][12].ToString() != ""))
                    cBMoneda.SelectedValue = RBCreditos.Rows[0][12].ToString();
                else
                    cBMoneda.SelectedIndex = -1;
                if ((RBCreditos.Rows[0][13].ToString() != null) && (RBCreditos.Rows[0][13].ToString() != ""))
                    cBFrecuenciaPago.SelectedValue = RBCreditos.Rows[0][13].ToString();
                else
                    cBFrecuenciaPago.SelectedIndex = -1;
                
                nUDNumeroPeriodos.Value = int.Parse(RBCreditos.Rows[0][14].ToString());
                nUDInteresAnual.Value = decimal.Parse(RBCreditos.Rows[0][15].ToString());
                nUDInteresAnualMora.Value = decimal.Parse(RBCreditos.Rows[0][16].ToString());
                dTPFechaPrimerPago.Value = DateTime.Parse(RBCreditos.Rows[0][17].ToString());
                tBFechaUltimoPago.Text = RBCreditos.Rows[0][18].ToString();
                mTBMontoDisponible.Text = RBCreditos.Rows[0][19].ToString();
                tBObservaciones.Text = RBCreditos.Rows[0][20].ToString();
                cBRegistrarAsientoContable.Checked = bool.Parse(RBCreditos.Rows[0][21].ToString());
                tBNumeroAgenciaSolicitud.Text = RBCreditos.Rows[0][22].ToString();
                tBUsuarioSolicitud.Text = RBCreditos.Rows[0][23].ToString();
                tBFechaHoraSolicitud.Text = RBCreditos.Rows[0][24].ToString();
                tBNumeroAgenciaAutorizacion.Text = RBCreditos.Rows[0][25].ToString();
                tBUsuarioAutorizacion.Text = RBCreditos.Rows[0][26].ToString();
                tBFechaHoraAutorizacion.Text = RBCreditos.Rows[0][27].ToString();
                tBCodigoAutorizacion.Text = RBCreditos.Rows[0][28].ToString();
                if ((RBCreditos.Rows[0][29].ToString() != null) && (RBCreditos.Rows[0][29].ToString() != ""))
                    cBEstadoCredito.SelectedValue = RBCreditos.Rows[0][29].ToString();
                else
                    cBEstadoCredito.SelectedIndex = -1;

                bNuevo.Enabled = true;
                bContrato.Enabled = true;

                if (RBCreditos.Rows[0][29].ToString() == "A" || RBCreditos.Rows[0][29].ToString() == "P")
                {
                    bEditar.Enabled = false;
                    bEliminar.Enabled = false;
                    if (RBCreditos.Rows[0][29].ToString() == "A")
                    {
                        bContrato.Enabled = true;
                    }
                }
                else
                {
                    bEditar.Enabled = true;
                    bEliminar.Enabled = true;
                }
               
                bAceptar.Enabled = false;
                bCancelar.Enabled = false;
            }
            else
            {
                InhabilitarControles(true);
                InicializarControles();
                bNuevo.Enabled = true;
                bEditar.Enabled = false;
                bEliminar.Enabled = false;
                bAceptar.Enabled = false;
                bCancelar.Enabled = false;
            }
        }

        private void bBuscar_Click(object sender, EventArgs e)
        {
            FBuscarCreditos fBuscarCreditos = new FBuscarCreditos();
            fBuscarCreditos.ShowDialog();
            RBCreditos = fBuscarCreditos.ResultadoBusquedaCreditos;
            NumeroCredito = fBuscarCreditos.NumeroCredito;

            RBCreditos = Creditos.ObtenerCredito(NumeroCredito);
            CargarControlesDeTabla();
        }

        private void bCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FCreditos_Load(object sender, EventArgs e)
        {
            CargarSistemasAmortizacion();
            CargarMonedas();
            CargarFrecuenciasPagos();
            CargarTipoEstadosCreditosNavegacion();
            CargarMediosPagos();
            CargarTiposCreditos();
            CargarAgenciasCotizacion();

            dGVPlanPagos.AutoGenerateColumns = false;
            dGVCuotasPagos.AutoGenerateColumns = false;

            InhabilitarControles(true);
            InicializarControles();

            bNuevo.Enabled = true;
            bEditar.Enabled = false;
            bEliminar.Enabled = false;
            bAceptar.Enabled = false;
            bCancelar.Enabled = false;
        }
        
        private void bReporte_Click(object sender, EventArgs e)
        {
            /*
            FReportesGestionComercialProductos fReportesGestionComercialproductos = new FReportesGestionComercialProductos(Productos.ListarProductosReporte());
            fReportesGestionComercialproductos.ShowDialog();
            */ 
        }

        private void bBuscarDeudor_Click(object sender, EventArgs e)
        {
            BuscarPersona(tBDIDeudor, tBNombreCompletoDeudor);
        }
 
        private void BuscarPersona(TextBox tbDI, TextBox tbNombreCompleto)
        {
            string DIP = "";
            string NCP = "";
            FBuscarPersonas fBuscarPersonas = new FBuscarPersonas();
            fBuscarPersonas.ShowDialog();
            DIP = fBuscarPersonas.DISeleccionado;
            NCP = fBuscarPersonas.NombreCompletoSeleccionado;
            if ((DIP == null) || (DIP == ""))
            {
                MessageBox.Show("No ha seleccionado ninguna persona");
            }
            else
            {
                tbDI.Text = DIP;
                tbNombreCompleto.Text = NCP;
            }
        }


        private void bBuscarGarante1_Click(object sender, EventArgs e)
        {
            BuscarPersona(tBDIGarante1, tBNombreCompletoGarante1);
        }

        private void bBuscarGarante2_Click(object sender, EventArgs e)
        {
            BuscarPersona(tBDIGarante2, tBNombreCompletoGarante2);
        }

        private void bBuscarGarante3_Click(object sender, EventArgs e)
        {
            BuscarPersona(tBDIGarante3, tBNombreCompletoGarante3);
        }

        private void bBuscarGarante4_Click(object sender, EventArgs e)
        {
            BuscarPersona(tBDIGarante4, tBNombreCompletoGarante4);
        }

        private void bBuscarGarante5_Click(object sender, EventArgs e)
        {
            BuscarPersona(tBDIGarante5, tBNombreCompletoGarante5);
        }

        private void bAnadirDeudor_Click(object sender, EventArgs e)
        {
            FPersonas fp = new FPersonas();
            fp.ShowDialog();
        }

        private void cBFrecuenciaPago_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void nUDNumeroPagos_ValueChanged(object sender, EventArgs e)
        {
            DateTime FechaHoraFin = dTPFechaPrimerPago.Value;
            int NumeroMeses = 0;
            int NumeroDias = 0;

            if (NumeroDiasFrecuenciaPago < 30)
            {
                NumeroDias = NumeroDiasFrecuenciaPago * int.Parse(nUDNumeroPeriodos.Value.ToString());
                FechaHoraFin = FechaHoraFin.AddDays(NumeroDias);
            }
            else
            {
                NumeroMeses = (NumeroDiasFrecuenciaPago * int.Parse(nUDNumeroPeriodos.Value.ToString())) / 30;
                FechaHoraFin = FechaHoraFin.AddMonths(NumeroMeses);
            }
            tBFechaUltimoPago.Text = FechaHoraFin.ToString();
        }

        private void cBFrecuenciaPago_ValueMemberChanged(object sender, EventArgs e)
        {
        }

        private void cBFrecuenciaPago_SelectedValueChanged(object sender, EventArgs e)
        {
            

        }

        private void cBFrecuenciaPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (int.Parse(cBFrecuenciaPago.SelectedValue.ToString()) > 0)
            {
                NumeroDiasFrecuenciaPago = FrecuenciasPagos.ObtenerDiasFrecuenciaPago(int.Parse(cBFrecuenciaPago.SelectedValue.ToString()));
            }
        }


        private void tBDIDeudor_Leave(object sender, EventArgs e)
        {
            tBNombreCompletoDeudor.Text = Personas.ObtenerNombreCompleto(tBDIDeudor.Text);
        }

        private void tBDIGarante1_Leave(object sender, EventArgs e)
        {
            tBNombreCompletoGarante1.Text = Personas.ObtenerNombreCompleto(tBDIGarante1.Text);
        }

        private void tBDIGarante2_Leave(object sender, EventArgs e)
        {
            tBNombreCompletoGarante2.Text = Personas.ObtenerNombreCompleto(tBDIGarante2.Text);
        }

        private void tBDIGarante3_Leave(object sender, EventArgs e)
        {
            tBNombreCompletoGarante3.Text = Personas.ObtenerNombreCompleto(tBDIGarante3.Text);
        }

        private void tBDIGarante4_Leave(object sender, EventArgs e)
        {
            tBNombreCompletoGarante4.Text = Personas.ObtenerNombreCompleto(tBDIGarante4.Text);
        }

        private void tBDIGarante5_Leave(object sender, EventArgs e)
        {
            tBNombreCompletoGarante5.Text = Personas.ObtenerNombreCompleto(tBDIGarante5.Text);
        }


        private void cBEstadoCredito_SelectionChangeCommitted(object sender, EventArgs e)
        {


            if (cBEstadoCredito.SelectedValue.ToString() == "A")
            {
                tBNumeroAgenciaAutorizacion.Text = NumeroAgencia.ToString();
                tBUsuarioAutorizacion.Text = CodigoUsuario.ToString();
                tBFechaHoraAutorizacion.Text = TransaccionesUtilidades.ObtenerFechaHoraServidor().ToString();
                tBCodigoAutorizacion.Text = GenerarCodigoAutorizacion();
            }
            else
            {
                tBNumeroAgenciaAutorizacion.Text = "";
                tBUsuarioAutorizacion.Text = "";
                tBFechaHoraAutorizacion.Text = "";
                tBCodigoAutorizacion.Text = "";
            }
        }

        private void tCCredtos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tCCreditos.SelectedIndex == 1)
            {
                if (tBNumeroCredito.Text.Length > 0)
                {
                    dGVPlanPagos.DataSource = CreditosCuotas.ListarCreditoCuotasNumeroCredito(int.Parse(tBNumeroCredito.Text));
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado el numero de credito del que se desea visualizar su Plan de Pagos");
                    tCCreditos.SelectedIndex = 0;
                }
            }
            if (tCCreditos.SelectedIndex == 2)
            {
                if (tBNumeroCredito.Text.Length > 0)
                {
                    dGVCuotasPagos.DataSource = CreditosCuotasPagos.ListarCreditosCuotasPagosNumeroCredito(int.Parse(tBNumeroCredito.Text));
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado el numero de credito del que se desea visualizar sus Cuotas Canceladas");
                    tCCreditos.SelectedIndex = 0;
                }
            }
        }

        private void bNuevoPago_Click(object sender, EventArgs e)
        {
            DataTable SiguienteCuotaPago = new DataTable();
            SiguienteCuotaPago = CreditosCuotas.ObtenerSiguienteCuotaPago(NumeroCredito);
            if (SiguienteCuotaPago != null)
            {
                string NombreDeudor = tBNombreCompletoDeudor.Text;
                string Garante1 = tBNombreCompletoGarante1.Text;
                string Garante2 = tBNombreCompletoGarante2.Text;
                string Garante3 = tBNombreCompletoGarante3.Text;
                string Garante4 = tBNombreCompletoGarante4.Text;
                string Garante5 = tBNombreCompletoGarante5.Text;
                string SistemaAmortizacion = cBSistemaAmortizacion.Text;
                decimal Monto = decimal.Parse(mTBMontoCredito.Text);
                string TipoFrecuenciaPagos = cBFrecuenciaPago.Text;
                int NumeroPagos = int.Parse(nUDNumeroPeriodos.Value.ToString());
                decimal InteresAnual = decimal.Parse(nUDInteresAnual.Value.ToString());
                int NumeroCuota = int.Parse(SiguienteCuotaPago.Rows[0][1].ToString());
                DateTime FechaCuota = DateTime.Parse(SiguienteCuotaPago.Rows[0][2].ToString());
                decimal Cuota = decimal.Parse(SiguienteCuotaPago.Rows[0][3].ToString());
                string Moneda = cBMoneda.Text;
                int NumeroAgenciaPago = NumeroAgencia;
                int CodigoUsuarioPago = CodigoUsuario;

                FCreditosSiguientePagoAmortizacion fcspa = new FCreditosSiguientePagoAmortizacion(NumeroCredito, NombreDeudor, Garante1, Garante2, Garante3, Garante4, Garante5,
                    SistemaAmortizacion, Monto, TipoFrecuenciaPagos, NumeroPagos, InteresAnual, NumeroCuota, FechaCuota, Cuota, Moneda, NumeroAgenciaPago, CodigoUsuarioPago,
                    decimal.Parse(SiguienteCuotaPago.Rows[0][4].ToString()), decimal.Parse(SiguienteCuotaPago.Rows[0][5].ToString()), decimal.Parse(SiguienteCuotaPago.Rows[0][6].ToString()),
                    decimal.Parse(SiguienteCuotaPago.Rows[0][7].ToString()), decimal.Parse(SiguienteCuotaPago.Rows[0][8].ToString()));

                fcspa.ShowDialog();
                if (fcspa.CuotaPagada)
                {
                    if (tBNumeroCredito.Text.Length > 0)
                    {
                        dGVCuotasPagos.DataSource = CreditosCuotasPagos.ListarCreditosCuotasPagosNumeroCredito(int.Parse(tBNumeroCredito.Text));
                    }
                    else
                    {
                        MessageBox.Show("No se ha seleccionado el numero de credito del que se desea visualizar sus Cuotas Canceladas");
                        tCCreditos.SelectedIndex = 0;
                    }
                }
            }
            else
            {
                MessageBox.Show("No existen cuotas para cancelar");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bImprimirPlanPagos_Click(object sender, EventArgs e)
        {
            string NombreCompleto = tBNombreCompletoDeudor.Text;
            string Garante1 = tBNombreCompletoGarante1.Text;
            string Garante2 = tBNombreCompletoGarante2.Text;
            string Garante3 = tBNombreCompletoGarante3.Text;
            string Garante4 = tBNombreCompletoGarante4.Text;
            string Garante5 = tBNombreCompletoGarante5.Text;
            string SistemaAmortizacion = cBSistemaAmortizacion.Text;
            decimal Monto = decimal.Parse(mTBMontoCredito.Text);
            string TipoFrecuenciaPagos = cBFrecuenciaPago.Text;
            int NumeroPagos = int.Parse(nUDNumeroPeriodos.Value.ToString());
            decimal InteresAnual = decimal.Parse(nUDInteresAnual.Value.ToString());

            FReporteCreditosPlanPagos frCreditosPlanPagos = new FReporteCreditosPlanPagos(CreditosCuotas.ListarCreditoCuotasNumeroCredito(int.Parse(tBNumeroCredito.Text)), NumeroCredito, NombreCompleto, Garante1, Garante2, Garante3, Garante4, Garante5, SistemaAmortizacion, Monto, TipoFrecuenciaPagos, NumeroPagos, InteresAnual);
            
            frCreditosPlanPagos.ShowDialog();
        }

        private void bImprimirPagosRealizados_Click(object sender, EventArgs e)
        {
            string NombreCompleto = tBNombreCompletoDeudor.Text;
            string Garante1 = tBNombreCompletoGarante1.Text;
            string Garante2 = tBNombreCompletoGarante2.Text;
            string Garante3 = tBNombreCompletoGarante3.Text;
            string Garante4 = tBNombreCompletoGarante4.Text;
            string Garante5 = tBNombreCompletoGarante5.Text;
            string SistemaAmortizacion = cBSistemaAmortizacion.Text;
            decimal Monto = decimal.Parse(mTBMontoCredito.Text);
            string TipoFrecuenciaPagos = cBFrecuenciaPago.Text;
            int NumeroPagos = int.Parse(nUDNumeroPeriodos.Value.ToString());
            decimal InteresAnual = decimal.Parse(nUDInteresAnual.Value.ToString());

            FReporteCreditosPagosRealizados frCreditosPagosRealizados = new FReporteCreditosPagosRealizados(CreditosCuotasPagos.ListarCreditosCuotasPagosNumeroCredito(int.Parse(tBNumeroCredito.Text)), NumeroCredito, NombreCompleto, Garante1, Garante2, Garante3, Garante4, Garante5, SistemaAmortizacion, Monto, TipoFrecuenciaPagos, NumeroPagos, InteresAnual);
            frCreditosPagosRealizados.ShowDialog();
        }

        private void bImprimirReciboPago_Click(object sender, EventArgs e)
        {
            string NombreDeudor = tBNombreCompletoDeudor.Text;
            string Garante1 = tBNombreCompletoGarante1.Text;
            string Garante2 = tBNombreCompletoGarante2.Text;
            string Garante3 = tBNombreCompletoGarante3.Text;
            string Garante4 = tBNombreCompletoGarante4.Text;
            string Garante5 = tBNombreCompletoGarante5.Text;
            string SistemaAmortizacion = cBSistemaAmortizacion.Text;
            decimal Monto = decimal.Parse(mTBMontoCredito.Text);
            string TipoFrecuenciaPagos = cBFrecuenciaPago.Text;
            int NumeroPagos = int.Parse(nUDNumeroPeriodos.Value.ToString());
            decimal InteresAnual = decimal.Parse(nUDInteresAnual.Value.ToString());
            int NumeroCuota = int.Parse(dGVCuotasPagos.Rows[dGVCuotasPagos.CurrentRow.Index].Cells[0].Value.ToString());
            DateTime FechaCuota = DateTime.Parse(dGVCuotasPagos.Rows[dGVCuotasPagos.CurrentRow.Index].Cells[1].Value.ToString());
            string DIDepositante = dGVCuotasPagos.Rows[dGVCuotasPagos.CurrentRow.Index].Cells[5].Value.ToString();
            string NombreDepositante = dGVCuotasPagos.Rows[dGVCuotasPagos.CurrentRow.Index].Cells[6].Value.ToString();
            decimal Cuota = decimal.Parse(dGVCuotasPagos.Rows[dGVCuotasPagos.CurrentRow.Index].Cells[2].Value.ToString());
            string CodigoMedioPago = dGVCuotasPagos.Rows[dGVCuotasPagos.CurrentRow.Index].Cells[3].Value.ToString();
            string Moneda = cBMoneda.Text;
            string Deposito = dGVCuotasPagos.Rows[dGVCuotasPagos.CurrentRow.Index].Cells[4].Value.ToString();
            int NumeroAgenciaPago = int.Parse(dGVCuotasPagos.Rows[dGVCuotasPagos.CurrentRow.Index].Cells[7].Value.ToString());
            int CodigoUsuarioPago = int.Parse(dGVCuotasPagos.Rows[dGVCuotasPagos.CurrentRow.Index].Cells[8].Value.ToString());
            
            FReporteCreditosReciboPagoCuota frCreditosReciboPagoCuota = new FReporteCreditosReciboPagoCuota(NumeroCredito, NombreDeudor, Garante1, Garante2, Garante3, Garante4, Garante5,
                SistemaAmortizacion, Monto, TipoFrecuenciaPagos, NumeroPagos, InteresAnual, NumeroCuota, FechaCuota, DIDepositante, NombreDepositante, Cuota, CodigoMedioPago,
                Moneda, Deposito, NumeroAgenciaPago, CodigoUsuarioPago);

            frCreditosReciboPagoCuota.ShowDialog();        
        }

        private void bPersonas_Click(object sender, EventArgs e)
        {
            FPersonas fp = new FPersonas();
            fp.ShowDialog();
        }

        private void mTBMontoCredito_TextChanged(object sender, EventArgs e)
        {
            if (TipoOperacion == "I")
            {
                mTBMontoDisponible.Text = mTBMontoCredito.Text;
            }
            
            

        }

        private void cBTipoCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void bBuscarCotizacion_Click(object sender, EventArgs e)
        {

            if (cBNumeroAgenciaCotizacion.SelectedIndex >= 0)
            {
                FBuscarTransaccion formBuscarTransaccion = new FBuscarTransaccion(NumeroAgencia);
                formBuscarTransaccion.formatearEstiloParaCotizaciones();
                formBuscarTransaccion.ShowDialog(this);

                int NumeroAgenciaCotizacion = int.Parse(cBNumeroAgenciaCotizacion.SelectedValue.ToString());

                int NumeroCotizacion = formBuscarTransaccion.NumeroTransaccion;


                if (NumeroCotizacion > 0)
                {
                    tBNumeroCotizacion.Text = NumeroCotizacion.ToString();
                    formBuscarTransaccion.Dispose();

                    if (TransferirValoresCotizacion(NumeroAgenciaCotizacion, NumeroCotizacion))
                    {
                        MessageBox.Show("Cotizacion cargada exitosamente");
                        CotizacionEncontrada = true;
                    }
                    else
                    {
                        CotizacionEncontrada = false;
                        string Mensaje = "El número de cotización ingresada no es valida.";
                        string Titulo = "Error número cotización";
                        MessageBoxButtons Botones = MessageBoxButtons.OK;
                        MessageBoxIcon Icono = MessageBoxIcon.Exclamation;

                        MessageBox.Show(Mensaje, Titulo, Botones, Icono);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(this, "No se encontro ninguna Cotización de Venta con los parametros o Descripción que usted Acaba de Ingresar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                string Mensaje = "No puede buscar una cotización sin seleccionar previamente una agencia.";
                string Titulo = "Advertencia selección agencia cotizacion";
                MessageBoxButtons Botones = MessageBoxButtons.OK;
                MessageBoxIcon Icono = MessageBoxIcon.Exclamation;
                
                MessageBox.Show(Mensaje, Titulo, Botones, Icono);
                cBNumeroAgenciaCotizacion.Focus();   
            }
        }

        private bool TransferirValoresCotizacion(int NumeroAgenciaCotizacion, int NumeroCotizacion)
        {
            CotizacionVentasProductosCLN CotizacionVentasProductos = new CotizacionVentasProductosCLN();
            DataTable DTCotizacionVentaProductos = new DataTable();
            DTCotizacionVentaProductos = CotizacionVentasProductos.ObtenerCotizacionVentaProducto(NumeroAgenciaCotizacion, NumeroCotizacion);

            if (DTCotizacionVentaProductos.Rows.Count > 0)
            {
                MontoLimite = decimal.Parse(DTCotizacionVentaProductos.Rows[0]["MontoTotalCotizacion"].ToString());
                cBMoneda.SelectedValue = byte.Parse(DTCotizacionVentaProductos.Rows[0]["CodigoMonedaCotizacionVenta"].ToString());

                mTBMontoCredito.Text = (decimal.Parse(DTCotizacionVentaProductos.Rows[0]["MontoTotalCotizacion"].ToString())).ToString();
                mTBMontoDisponible.Text = (decimal.Parse(DTCotizacionVentaProductos.Rows[0]["MontoTotalCotizacion"].ToString())).ToString();

                return true;
            }
            return false;

        }

        private void mTBMontoCredito_Leave(object sender, EventArgs e)
        {
            if (cBTipoCredito.SelectedIndex == 2)
            {
                if (mTBMontoCredito.Text.Length > 0)
                {
                    if (decimal.Parse(mTBMontoCredito.Text) > MontoLimite)
                    {
                        string Mensaje = "El monto de credito no puede superar el monto de cotizacón, bajo esta modalidad de crédito.";
                        string Titulo = "Error monto crédito";
                        MessageBoxButtons Botones = MessageBoxButtons.OK;
                        MessageBoxIcon Icono = MessageBoxIcon.Exclamation;

                        MessageBox.Show(Mensaje, Titulo, Botones, Icono);
                        mTBMontoCredito.Focus();
                        return;
                    }
                }
            }


        }

        private void tBNumeroCotizacion_Leave(object sender, EventArgs e)
        {
            CotizacionEncontrada = false;
            if (cBNumeroAgenciaCotizacion.SelectedIndex >= 0)
            {
                if ((tBNumeroCotizacion.Text.Length > 0) && (!tBNumeroCotizacion.ReadOnly))
                {
                    int NumeroAgenciaCotizacion = int.Parse(cBNumeroAgenciaCotizacion.SelectedValue.ToString());
                    int NumeroCotizacion = int.Parse(tBNumeroCotizacion.Text);

                    if (NumeroCotizacion > 0)
                    {
                        //tBNumeroCotizacion.Text = NumeroCotizacion.ToString();

                        if (TransferirValoresCotizacion(NumeroAgenciaCotizacion, NumeroCotizacion))
                        {
                            CotizacionEncontrada = true;
                            MessageBox.Show("Cotizacion cargada exitosamente");
                        }
                        else
                        {
             
                            string Mensaje = "El número de cotización ingresada no es valida.";
                            string Titulo = "Error número cotización";
                            MessageBoxButtons Botones = MessageBoxButtons.OK;
                            MessageBoxIcon Icono = MessageBoxIcon.Exclamation;

                            MessageBox.Show(Mensaje, Titulo, Botones, Icono);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "No se encontro ninguna Cotización de Venta con los parametros o Descripción que usted Acaba de Ingresar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                string Mensaje = "Debe seleccionar una agencia para buscar una cotización.";
                string Titulo = "Error seleccion agengia cotización";
                MessageBoxButtons Botones = MessageBoxButtons.OK;
                MessageBoxIcon Icono = MessageBoxIcon.Exclamation;

                MessageBox.Show(Mensaje, Titulo, Botones, Icono);
                return;
            }
        }

        private void cBTipoCredito_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tBNumeroCotizacion.Text = "";
            CotizacionEncontrada = false;

            if (cBTipoCredito.Enabled)
            {
                if (cBTipoCredito.SelectedIndex == 0)
                {
                    cBNumeroAgenciaCotizacion.SelectedIndex = -1;
                    cBNumeroAgenciaCotizacion.Enabled = false;
                    tBNumeroCotizacion.Enabled = false;
                    bBuscarCotizacion.Enabled = false;

                    cBMoneda.Enabled = true;
                    mTBMontoCredito.Enabled = true;
                    cBSistemaAmortizacion.Focus();

                }
                else if (cBTipoCredito.SelectedIndex == 1)
                {
                    cBNumeroAgenciaCotizacion.SelectedIndex = -1;
                    cBNumeroAgenciaCotizacion.Enabled = true;
                    tBNumeroCotizacion.Enabled = true;
                    bBuscarCotizacion.Enabled = true;

                    cBMoneda.Enabled = false;
                    mTBMontoCredito.Enabled = false;
                    cBNumeroAgenciaCotizacion.Focus();
                }
                else
                {
                    cBNumeroAgenciaCotizacion.SelectedIndex = -1;
                    cBNumeroAgenciaCotizacion.Enabled = true;
                    tBNumeroCotizacion.Enabled = true;
                    bBuscarCotizacion.Enabled = true;

                    cBMoneda.Enabled = false;
                    mTBMontoCredito.Enabled = true;
                    cBNumeroAgenciaCotizacion.Focus();
                }
            }
        }
    }

    public class TipoEstadoCredito
    {
        private string CodTipEstCre;
        private string NomTipEstCre;

        public TipoEstadoCredito(string CodigoTipoEstadoCredito, string NombreTipoEstadoCredito)
        {
            this.CodTipEstCre = CodigoTipoEstadoCredito;
            this.NomTipEstCre = NombreTipoEstadoCredito;
        }

        public string CodigoTipoEstadoCredito
        {
            get
            {
                return CodTipEstCre;
            }
        }

        public string NombreTipoEstadoCredito
        {

            get
            {
                return NomTipEstCre;
            }
        }
    }

    public class SistemaAmortizacion
    {
        private string CodSisAmo;
        private string NomSisAmo;

        public SistemaAmortizacion(string CodigoSistemaAmortizacion, string NombreSistemaAmortizacion)
        {
            this.CodSisAmo = CodigoSistemaAmortizacion;
            this.NomSisAmo = NombreSistemaAmortizacion;
        }

        public string CodigoSistemaAmortizacion
        {
            get
            {
                return CodSisAmo;
            }
        }

        public string NombreSistemaAmortizacion
        {

            get
            {
                return NomSisAmo;
            }
        }
    }

    public class TiposCreditos
    {
        private string CodTipCre;
        private string NomTipCre;

        public TiposCreditos(string CodigoTipoCredito, string NombreTipoCredito)
        {
            this.CodTipCre = CodigoTipoCredito;
            this.NomTipCre = NombreTipoCredito;
        }

        public string CodigoTipoCredito
        {
            get
            {
                return CodTipCre;
            }
        }

        public string NombreTipoCredito
        {
            get
            {
                return NomTipCre;
            }
        }
    }

}
