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
using WFADoblones20.FormulariosSistema;
using WFADoblones20.FormulariosContabilidad;
using WFADoblones20.FormulariosGestionComercial;
using WFADoblones20.Librerias;
using System.Reflection;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Windows.Forms;
using System.Configuration;

namespace WFADoblones20.FormulariosSistema
{
    public partial class FPrincipal : Form
    {
        static private DataTable VariablesConfiguracionSistema = new DataTable();
        static private DataTable VariablesConfiguracionSistemaGC = new DataTable();
        static private DataTable PermisosInterface = new DataTable(); 
        static private PCsConfiguracionesCLN PCConfiguracion = new PCsConfiguracionesCLN();
        static private UsuariosAgeciasMenuPrincipalCLN UsuariosAgenciasMenuPrincipal = new UsuariosAgeciasMenuPrincipalCLN();
        static private InventariosProductosCLN _InventariosProductosCLN = new InventariosProductosCLN();
        
        private UsuariosCLN _UsuariosCLN = new UsuariosCLN();
        public bool UsuarioPertene_A_Grupo = false;
        public bool UsuarioTienePermisoDirecto_A_Interfaces = false;

        static private int CodigoUsuario = 0; 
        static private int NumeroAgencia = 0; 
        static private int NumeroPC = 0;
        static private string IDPC = "";
        static private string NombreServidor = "";
        static private string RutaDirectorioImagenes = "";
       
        /*
        static private int CodigoMonedaSistema = 0;
        static private int CodigoMonedaRegion = 0;
        static private string MascaraMonedaSistema = "";
        static private string MascaraMonedaRegion = "";
        static private string NombreMonedaSistema = "";
        static private string NombreMonedaRegion = "";
        static private decimal PorcentajeImpuestoSistema = 0;
        static private decimal CotizacionMonedaSistema = 0;
        static private bool ContabilidadIntegrada = false;*/

        static MenuDinamico MDPrincipal;
        static BarraHerramientasDinamica BHDPrincipal;
        static TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();
       
        
        public FPrincipal()
        {
            InitializeComponent();

            this.FormClosed += new FormClosedEventHandler(FPrincipal_FormClosed);
        }

        void FPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                _TransaccionesUtilidadesCLN.InsertarBitacora("Salida Sistema", 0, "Salida");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FPrincipal_Load(object sender, EventArgs e)
        {
            //FSplash fSplash = new FSplash(4);
            //fSplash.ShowDialog(this);     // Mostramos el formulario de forma modal.
            //fSplash.Dispose();

            FAutenticacion fautenticacion = new FAutenticacion();
            fautenticacion.ShowDialog();

            CodigoUsuario = fautenticacion.CodigoUsuario;


            NombreServidor = fautenticacion.Servidor;
            sSPrincipal.Items[0].Text += fautenticacion.Servidor;
            sSPrincipal.Items[1].Text += fautenticacion.BaseDatos;
            sSPrincipal.Items[2].Text += CodigoUsuario.ToString();
            sSPrincipal.Items[3].Text += fautenticacion.NombreUsuario;

            IDPC = "PC-CEATEC01"; //Se obtendra del archivo de licencia de sistema Doblones.als

            VariablesConfiguracionSistema = PCConfiguracion.ObtenerPCConfiguracionIDPC(IDPC);
            
            if (VariablesConfiguracionSistema.Rows.Count > 0)
            {
                NumeroPC = int.Parse(VariablesConfiguracionSistema.Rows[0][0].ToString());
                NumeroAgencia = int.Parse(VariablesConfiguracionSistema.Rows[0][3].ToString());
                sSPrincipal.Items[4].Text += NumeroAgencia.ToString();
                sSPrincipal.Items[5].Text += NumeroPC.ToString();
                VariablesConfiguracionSistemaGC = PCConfiguracion.ObtenerConfiguracionSistemaParaTransaccionesGC(NumeroPC);
                sSPrincipal.Items[6].Text += VariablesConfiguracionSistemaGC.Rows[0][4].ToString();
                RutaDirectorioImagenes = VariablesConfiguracionSistema.Rows[0]["RutaDirectorioImagenes"].ToString();
                
                SolicitarCotizacionMonedas();
            }
            else
            {
                MessageBox.Show("No se ha realizado la configuracion inicial del sistema la cual es necesaria, para proceder, consulte con su administrador del sistema");
                Application.Exit();
            }

            DataTable DTMenuUsuarioAgencia = UsuariosAgenciasMenuPrincipal.ObtenerMenuPrincipalUsuarioAgencia(CodigoUsuario, NumeroAgencia);

            MDPrincipal = new MenuDinamico(mSPrincipal, DTMenuUsuarioAgencia);
            MDPrincipal.ConstruirMenu();

            BHDPrincipal = new BarraHerramientasDinamica(tSCPrincipal, DTMenuUsuarioAgencia, this.Size.Width);
            BHDPrincipal.ConstruirBarraHerramientas();

            _TransaccionesUtilidadesCLN.InsertarBitacora("Ingreso Sistema", 0, "logueo");

        }


        public void SolicitarCotizacionMonedas()
        {
            MonedasCLN _MonedasCLN = new MonedasCLN();
            CLCAD.DSDoblones20Sistema.MonedasDataTable DTMonedas = (CLCAD.DSDoblones20Sistema.MonedasDataTable)_MonedasCLN.ListarMonedas();
            byte CodigoMonedaSistema = byte.Parse(VariablesConfiguracionSistemaGC.Rows[0]["CodigoMonedaSistema"].ToString());
            foreach (CLCAD.DSDoblones20Sistema.MonedasRow DRMoneda in DTMonedas.Select("CodigoMoneda <> " + CodigoMonedaSistema.ToString()))
            {
                if (!_TransaccionesUtilidadesCLN.ExisteCotizacionMonedaSistema(DRMoneda.CodigoMoneda, CodigoMonedaSistema))
                {
                    FMonedasCotizacionesIA _FMonedasCotizacionesIA = new FMonedasCotizacionesIA();
                    _FMonedasCotizacionesIA.cargarNuevaCotizacionDiaria(CodigoMonedaSistema, DRMoneda.CodigoMoneda);
                    if (_FMonedasCotizacionesIA.ShowDialog(this) != DialogResult.OK)
                    {
                        CLCAD.DSDoblones20Sistema.MonedasCotizacionesDataTable DTUltimaMonedaCotizacion = new MonedasCotizacionesCLN().ObtenerUltimaMonedaCotizacionFecha(CodigoMonedaSistema, DRMoneda.CodigoMoneda);
                        MessageBox.Show("No ingreso una Cotización para el "  + DRMoneda.NombreMoneda + ", El sistema utilizará la última cotización registrada para esa moneda ("
                            + (DTUltimaMonedaCotizacion.Count > 0 ? DTUltimaMonedaCotizacion[0].CambioOficial.ToString()+")" : "No Existe cotizacion)") );
                    }
                }
            }
        }

        public static void CopiaSeguridad(object sender, EventArgs e)
        {
            MessageBox.Show("CopiaSeguridad");
        }
        public static void Restaurar(object sender, EventArgs e)
        {
            MessageBox.Show("Restaurar");
        }
        public static void Bitacora(object sender, EventArgs e)
        {
            MessageBox.Show("Bitacora");
        }
        public static void Agencias(object sender, EventArgs e)
        {
            PermisosInterface = PCConfiguracion.ObtenerPermisosInterface(CodigoUsuario, NumeroAgencia, "FProveedores");
            if (PermisosInterface.Rows.Count > 0)
            {
                FAgencias fa = new FAgencias(bool.Parse(PermisosInterface.Rows[0][0].ToString()), bool.Parse(PermisosInterface.Rows[0][1].ToString()), bool.Parse(PermisosInterface.Rows[0][2].ToString()), bool.Parse(PermisosInterface.Rows[0][3].ToString()));
                fa.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usted no tiene ningun permiso asociado para ingresar a esta pantalla.");
            }
        }
        public static void Usuarios(object sender, EventArgs e)
        {
            PermisosInterface = PCConfiguracion.ObtenerPermisosInterface(CodigoUsuario, NumeroAgencia, "FUsuarios");
            
            if (PermisosInterface.Rows.Count > 0)
            {
                FUsuarios fusuarios = new FUsuarios(NombreServidor, bool.Parse(PermisosInterface.Rows[0][0].ToString()), bool.Parse(PermisosInterface.Rows[0][1].ToString()), bool.Parse(PermisosInterface.Rows[0][2].ToString()), bool.Parse(PermisosInterface.Rows[0][3].ToString()), bool.Parse(PermisosInterface.Rows[0][4].ToString()));
                fusuarios.ShowDialog();
                try
                {
                    CLCAD.ConfiguracionConeccion.ReConectar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Usted no tiene ningun permiso asociado para ingresar a esta pantalla.");
            }
        }
        public static void Preferencias(object sender, EventArgs e)
        {
            MessageBox.Show("Preferencias");
        }
        public static void CambiarContrasena(object sender, EventArgs e)
        {
            FCambiarContraseña fcc = new FCambiarContraseña(NombreServidor, CodigoUsuario);
            fcc.ShowDialog();
            try
            {
                CLCAD.ConfiguracionConeccion.ReConectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
      
        public static void Salir(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public static void Proveedores(object sender, EventArgs e)
        {
            PermisosInterface = PCConfiguracion.ObtenerPermisosInterface(CodigoUsuario, NumeroAgencia, "FProveedores");
            if (PermisosInterface.Rows.Count > 0)
            {
                FProveedores fproveedores = new FProveedores(bool.Parse(PermisosInterface.Rows[0][0].ToString()), bool.Parse(PermisosInterface.Rows[0][1].ToString()), bool.Parse(PermisosInterface.Rows[0][2].ToString()), bool.Parse(PermisosInterface.Rows[0][3].ToString()));
                fproveedores.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usted no tiene ningun permiso asociado para ingresar a esta pantalla.");
            }
        }
        public static void Clientes(object sender, EventArgs e)
        {

            PermisosInterface = PCConfiguracion.ObtenerPermisosInterface(CodigoUsuario, NumeroAgencia, "FClientes");
            if (PermisosInterface.Rows.Count > 0)
            {
                FClientes fclientes = new FClientes(bool.Parse(PermisosInterface.Rows[0][0].ToString()), bool.Parse(PermisosInterface.Rows[0][1].ToString()), bool.Parse(PermisosInterface.Rows[0][2].ToString()), bool.Parse(PermisosInterface.Rows[0][3].ToString()));
                fclientes.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usted no tiene ningun permiso asociado para ingresar a esta pantalla.");
            }
            
        }
        public static void Productos(object sender, EventArgs e)
        {
            ////PermisosInterface = PCConfiguracion.ObtenerPermisosInterface(CodigoUsuario, NumeroAgencia, "FProductos");
            ////if (PermisosInterface.Rows.Count > 0)
            ////{
            ////    FAgregarEditarProducto fproductos = new FAgregarEditarProducto(bool.Parse(PermisosInterface.Rows[0][0].ToString()), bool.Parse(PermisosInterface.Rows[0][1].ToString()), bool.Parse(PermisosInterface.Rows[0][2].ToString()), bool.Parse(PermisosInterface.Rows[0][3].ToString()));
            ////    fproductos.ShowDialog();
            ////}
            ////else
            ////{
            ////    MessageBox.Show("Usted no tiene ningun permiso asociado para ingresar a esta pantalla.");
            ////}
        }
        public static void CotizacionesMonedas(object sender, EventArgs e)
        {
            PermisosInterface = PCConfiguracion.ObtenerPermisosInterface(CodigoUsuario, NumeroAgencia, "FMonedasCotizaciones");
            if (PermisosInterface.Rows.Count > 0)
            {
                FMonedasCotizaciones fmonedascotizaciones = new FMonedasCotizaciones(bool.Parse(PermisosInterface.Rows[0][0].ToString()), bool.Parse(PermisosInterface.Rows[0][1].ToString()), bool.Parse(PermisosInterface.Rows[0][2].ToString()), bool.Parse(PermisosInterface.Rows[0][3].ToString()));
                fmonedascotizaciones.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usted no tiene ningun permiso asociado para ingresar a esta pantalla.");
            }
        }
        public static void IniciarCompra(object sender, EventArgs e)
        {
            FComprasProductos fcomprasproductos = new FComprasProductos(NumeroAgencia, NumeroPC, CodigoUsuario);
            //fcomprasproductos.CargarConfiguracionInicial(NombreMonedaSistema, CodigoMonedaSistema, MascaraMonedaSistema, CodigoMonedaRegion, NombreMonedaRegion, MascaraMonedaRegion, PorcentajeImpuestoSistema);
            fcomprasproductos.emitirPermisos(true, true, true, true, true, false);
            fcomprasproductos.ShowDialog();
            fcomprasproductos.Dispose();
        }
        public static void PagarCompra(object sender, EventArgs e)
        {
            FCompraProductosBuscador _FCompraProductosBuscador = new FCompraProductosBuscador(NumeroAgencia, NumeroPC, CodigoUsuario);
            //_FCompraProductosBuscador.CargarConfiguracionInicial(NombreMonedaSistema, CodigoMonedaSistema, MascaraMonedaSistema, CodigoMonedaRegion, NombreMonedaRegion, MascaraMonedaRegion, PorcentajeImpuestoSistema);
            _FCompraProductosBuscador.formatearParaPagosCancelacionMonetaria();
            _FCompraProductosBuscador.ShowDialog();
        }
        public static void RecepcionProductosCompra(object sender, EventArgs e)
        {
            FCompraProductosBuscador _FCompraProductosBuscador = new FCompraProductosBuscador(NumeroAgencia, NumeroPC, CodigoUsuario);
            //_FCompraProductosBuscador.CargarConfiguracionInicial(NombreMonedaSistema, CodigoMonedaSistema, MascaraMonedaSistema, CodigoMonedaRegion, NombreMonedaRegion, MascaraMonedaRegion, PorcentajeImpuestoSistema);
            _FCompraProductosBuscador.formatearParaBusquedaRecepcion();
            _FCompraProductosBuscador.ShowDialog();
        }
        public static void DevolucionesCompras(object sender, EventArgs e)
        {
            FComprasProductosReemDevo formComprasDevoluciones = new FComprasProductosReemDevo(NumeroAgencia, CodigoUsuario);
            formComprasDevoluciones.ShowDialog();
        }
        public static void CuentasPorPagarCompras(object sender, EventArgs e)
        {
            //MessageBox.Show("CuentasPorPagarCompras");
            FComprasProductosCuentasPorPagar formCuentasCompras = new FComprasProductosCuentasPorPagar(NumeroAgencia, NumeroPC, CodigoUsuario);
            formCuentasCompras.ShowDialog();
            formCuentasCompras.Dispose();
        }


        public static void IniciarVenta(object sender, EventArgs e)
        {
            FVentasProductos2 fventasproductos = new FVentasProductos2(NumeroAgencia, NumeroPC, CodigoUsuario);            
            //fventasproductos.CargarConfiguracionInicial(NombreMonedaSistema, CodigoMonedaSistema, MascaraMonedaSistema, CodigoMonedaRegion, NombreMonedaRegion, MascaraMonedaRegion, PorcentajeImpuestoSistema);
            fventasproductos.emitirPermisos(true, true, true, true, true, true, false);
            fventasproductos.ShowDialog();
        }
        public static void CobrarVenta(object sender, EventArgs e)
        {
            FVentasProductosBusqueda _FVentasProductosBusqueda = new FVentasProductosBusqueda(NumeroAgencia, NumeroPC, CodigoUsuario);
            //_FVentasProductosBusqueda.CargarConfiguracionInicial(NombreMonedaSistema, CodigoMonedaSistema, MascaraMonedaSistema, CodigoMonedaRegion, NombreMonedaRegion, MascaraMonedaRegion, PorcentajeImpuestoSistema);
            _FVentasProductosBusqueda.esParaPagarVenta = true;
            _FVentasProductosBusqueda.soloNavegacion = false;
            _FVentasProductosBusqueda.formatearParaPagosCancelacionMonetaria();            
            _FVentasProductosBusqueda.ShowDialog(); 
        }
        public static void EntregaProductosVenta(object sender, EventArgs e)
        {
            FVentaProductosAdministradorEntregas _FVentasProductosBusqueda = new FVentaProductosAdministradorEntregas(NumeroAgencia, NumeroPC, CodigoUsuario);
            //_FVentasProductosBusqueda.PorcentajeIVA = 13;
            //_FVentasProductosBusqueda.emitirPermisos(true, true, true, true, true, true, false);
            _FVentasProductosBusqueda.ShowDialog();
        }
        public static void DevolucionesVentas(object sender, EventArgs e)
        {
            FVentasProductosReemDevo formVentasDevoluciones = new FVentasProductosReemDevo(NumeroAgencia, NumeroPC, CodigoUsuario);
            formVentasDevoluciones.ShowDialog();
        }
        public static void CuentasPorCobrarVentas(object sender, EventArgs e)
        {
            MessageBox.Show("CuentasPorCobrarVentas");
        }
        public static void IniciarTransferencia(object sender, EventArgs e)
        {
            FTransferenciasProductos fTransferenciasProductos = new FTransferenciasProductos(NumeroAgencia, NumeroPC, CodigoUsuario);
            //fTransferenciasProductos.CargarConfiguracionInicial(NombreMonedaSistema, CodigoMonedaSistema, MascaraMonedaSistema, CodigoMonedaRegion, NombreMonedaRegion, MascaraMonedaRegion, PorcentajeImpuestoSistema);
            fTransferenciasProductos.emitirPermisos(true, true, true, true, true, false);
            fTransferenciasProductos.ShowDialog();
            fTransferenciasProductos.Dispose();
        }
        public static void GastosTransferencia(object sender, EventArgs e)
        {
            FTransferenciasProductosAdministrador _FTransferenciasProductosAdministrador = new FTransferenciasProductosAdministrador(NumeroAgencia, NumeroPC,  CodigoUsuario, "E");
            //_FTransferenciasProductosAdministrador.CargarConfiguracionInicial(NombreMonedaSistema, CodigoMonedaSistema, MascaraMonedaSistema, CodigoMonedaRegion, NombreMonedaRegion, MascaraMonedaRegion, PorcentajeImpuestoSistema);
            _FTransferenciasProductosAdministrador.formatearParaAgregarGastos();            
            _FTransferenciasProductosAdministrador.ShowDialog();
            _FTransferenciasProductosAdministrador.Dispose();
        }
        public static void EnviosTransferencia(object sender, EventArgs e)
        {
            FTransferenciasProductosAdministrador _FTransferenciasProductosAdministrador = new FTransferenciasProductosAdministrador(NumeroAgencia, NumeroPC, CodigoUsuario, "E");
            //_FTransferenciasProductosAdministrador.CargarConfiguracionInicial(NombreMonedaSistema, CodigoMonedaSistema, MascaraMonedaSistema, CodigoMonedaRegion, NombreMonedaRegion, MascaraMonedaRegion, PorcentajeImpuestoSistema);
            _FTransferenciasProductosAdministrador.formatearParaBusquedaRecepcion();
            _FTransferenciasProductosAdministrador.ShowDialog();
            _FTransferenciasProductosAdministrador.Dispose();
        }
        public static void RecepcionProductosTransferencia(object sender, EventArgs e)
        {
            FTransferenciasProductosAdministrador _FTransferenciasProductosAdministrador = new FTransferenciasProductosAdministrador(NumeroAgencia, NumeroPC, CodigoUsuario, "R");
            //_FTransferenciasProductosAdministrador.CargarConfiguracionInicial(NombreMonedaSistema, CodigoMonedaSistema, MascaraMonedaSistema, CodigoMonedaRegion, NombreMonedaRegion, MascaraMonedaRegion, PorcentajeImpuestoSistema);
            _FTransferenciasProductosAdministrador.formatearParaBusquedaEnvio();
            _FTransferenciasProductosAdministrador.ShowDialog();
            _FTransferenciasProductosAdministrador.Dispose();
        }
        public static void Creditos(object sender, EventArgs e)
        {
            PermisosInterface = PCConfiguracion.ObtenerPermisosInterface(CodigoUsuario, NumeroAgencia, "FProductos");
            if (PermisosInterface.Rows.Count > 0)
            {
                FCreditos fcreditos = new FCreditos(NumeroAgencia, NumeroPC, CodigoUsuario, bool.Parse(PermisosInterface.Rows[0][0].ToString()), bool.Parse(PermisosInterface.Rows[0][1].ToString()), bool.Parse(PermisosInterface.Rows[0][2].ToString()), bool.Parse(PermisosInterface.Rows[0][3].ToString()));
                fcreditos.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usted no tiene ningun permiso asociado para ingresar a esta pantalla.");
            }
        }

        public static void ListarProductosEnTransitoPorPedido(object sender, EventArgs e)
        {
            DataTable DTListarProductosEnTransitoPorPedido = _InventariosProductosCLN.ListarProductosEnTransitoPorPedido(NumeroAgencia);
            FReporteInventarioMercaderiaEnTransito formMercaderiaEnTransito = new FReporteInventarioMercaderiaEnTransito();
            formMercaderiaEnTransito.ListarProductosEnTransitoPorPedido(DTListarProductosEnTransitoPorPedido);
            formMercaderiaEnTransito.ShowDialog();
            formMercaderiaEnTransito.Dispose();
        }

        public static void ListarComprasProductosReportesPorFechasTipo(object sender, EventArgs e)
        {
            FParametrosRangoFechas formParametrosFechas = new FParametrosRangoFechas();
            if(formParametrosFechas.ShowDialog() == DialogResult.OK)
            {
                DataTable DTListarComprasProductosReportesPorFechasTipo = _InventariosProductosCLN.ListarComprasProductosReportesPorFechasTipo(NumeroAgencia, 
                    formParametrosFechas.FechaHoraInicio, formParametrosFechas.FechaHoraFin, true);
                FReporteInventarioMercaderiaEnTransito formMercaderiaEnTransito = new FReporteInventarioMercaderiaEnTransito();
                formMercaderiaEnTransito.ListarComprasProductosReportesPorFechasTipo(DTListarComprasProductosReportesPorFechasTipo, 
                    formParametrosFechas.FechaHoraInicio, formParametrosFechas.FechaHoraFin, true );
                formMercaderiaEnTransito.ShowDialog();
                formMercaderiaEnTransito.Dispose();
            }
            formParametrosFechas.Dispose();
        }

        public static void ListarComprasProductosReportesPorFechasTipo2(object sender, EventArgs e)
        {
            FParametrosRangoFechas formParametrosFechas = new FParametrosRangoFechas();
            if (formParametrosFechas.ShowDialog() == DialogResult.OK)
            {
                DataTable DTListarComprasProductosReportesPorFechasTipo = _InventariosProductosCLN.ListarComprasProductosReportesPorFechasTipo(NumeroAgencia,
                    formParametrosFechas.FechaHoraInicio, formParametrosFechas.FechaHoraFin, false);
                FReporteInventarioMercaderiaEnTransito formMercaderiaEnTransito = new FReporteInventarioMercaderiaEnTransito();
                formMercaderiaEnTransito.ListarComprasProductosReportesPorFechasTipo(DTListarComprasProductosReportesPorFechasTipo,
                    formParametrosFechas.FechaHoraInicio, formParametrosFechas.FechaHoraFin, false);
                formMercaderiaEnTransito.ShowDialog();
                formMercaderiaEnTransito.Dispose();
            }
            formParametrosFechas.Dispose();
        }

        public static void ListarComprasProductosReportesPorFechasProveedor(object sender, EventArgs e)
        {
            FParametrosRangoFechas formParametrosFechas = new FParametrosRangoFechas();
            if (formParametrosFechas.ShowDialog() == DialogResult.OK)
            {
                DataTable DTListarComprasProductosReportesPorFechasTipo = _InventariosProductosCLN.ListarComprasProductosReportesPorFechasProveedor(NumeroAgencia,
                    formParametrosFechas.FechaHoraInicio, formParametrosFechas.FechaHoraFin, true);
                FReporteInventarioMercaderiaEnTransito formMercaderiaEnTransito = new FReporteInventarioMercaderiaEnTransito();
                formMercaderiaEnTransito.ListarComprasProductosReportesPorFechasProveedor(DTListarComprasProductosReportesPorFechasTipo,
                    formParametrosFechas.FechaHoraInicio, formParametrosFechas.FechaHoraFin, true);
                formMercaderiaEnTransito.ShowDialog();
                formMercaderiaEnTransito.Dispose();
            }
            formParametrosFechas.Dispose();
        }

        public static void ListarComprasProductosReportesPorFechasProveedor2(object sender, EventArgs e)
        {
            FParametrosRangoFechas formParametrosFechas = new FParametrosRangoFechas();
            if (formParametrosFechas.ShowDialog() == DialogResult.OK)
            {
                DataTable DTListarComprasProductosReportesPorFechasTipo = _InventariosProductosCLN.ListarComprasProductosReportesPorFechasProveedor(NumeroAgencia,
                    formParametrosFechas.FechaHoraInicio, formParametrosFechas.FechaHoraFin, false);
                FReporteInventarioMercaderiaEnTransito formMercaderiaEnTransito = new FReporteInventarioMercaderiaEnTransito();
                formMercaderiaEnTransito.ListarComprasProductosReportesPorFechasProveedor(DTListarComprasProductosReportesPorFechasTipo,
                    formParametrosFechas.FechaHoraInicio, formParametrosFechas.FechaHoraFin, false);
                formMercaderiaEnTransito.ShowDialog();
                formMercaderiaEnTransito.Dispose();
            }
            formParametrosFechas.Dispose();
        }

        #region Reportes de Ventas
        //---------------------
        public static void ListarVentasProductosReportesPorFechasTipo(object sender, EventArgs e)
        {
            FParametrosRangoFechas formParametrosFechas = new FParametrosRangoFechas();
            if (formParametrosFechas.ShowDialog() == DialogResult.OK)
            {
                DataTable DTListarComprasProductosReportesPorFechasTipo = _InventariosProductosCLN.ListarVentasProductosReportesPorFechasTipo(NumeroAgencia,
                    formParametrosFechas.FechaHoraInicio, formParametrosFechas.FechaHoraFin, true);
                FReporteInventarioMercaderiaEnTransito formMercaderiaEnTransito = new FReporteInventarioMercaderiaEnTransito();
                formMercaderiaEnTransito.ListarVentasProductosReportesPorFechasTipo(DTListarComprasProductosReportesPorFechasTipo,
                    formParametrosFechas.FechaHoraInicio, formParametrosFechas.FechaHoraFin, true);
                formMercaderiaEnTransito.ShowDialog();
                formMercaderiaEnTransito.Dispose();
            }
            formParametrosFechas.Dispose();
        }

        public static void ListarVentasProductosReportesPorFechasTipo2(object sender, EventArgs e)
        {
            FParametrosRangoFechas formParametrosFechas = new FParametrosRangoFechas();
            if (formParametrosFechas.ShowDialog() == DialogResult.OK)
            {
                DataTable DTListarComprasProductosReportesPorFechasTipo = _InventariosProductosCLN.ListarVentasProductosReportesPorFechasTipo(NumeroAgencia,
                    formParametrosFechas.FechaHoraInicio, formParametrosFechas.FechaHoraFin, false);
                FReporteInventarioMercaderiaEnTransito formMercaderiaEnTransito = new FReporteInventarioMercaderiaEnTransito();
                formMercaderiaEnTransito.ListarVentasProductosReportesPorFechasTipo(DTListarComprasProductosReportesPorFechasTipo,
                    formParametrosFechas.FechaHoraInicio, formParametrosFechas.FechaHoraFin, false);
                formMercaderiaEnTransito.ShowDialog();
                formMercaderiaEnTransito.Dispose();
            }
            formParametrosFechas.Dispose();
        }

        public static void ListarVentasProductosReportesPorFechasCliente(object sender, EventArgs e)
        {
            FParametrosRangoFechas formParametrosFechas = new FParametrosRangoFechas();
            if (formParametrosFechas.ShowDialog() == DialogResult.OK)
            {
                DataTable DTListarComprasProductosReportesPorFechasTipo = _InventariosProductosCLN.ListarVentasProductosReportesPorFechasCliente(NumeroAgencia,
                    formParametrosFechas.FechaHoraInicio, formParametrosFechas.FechaHoraFin, true);
                FReporteInventarioMercaderiaEnTransito formMercaderiaEnTransito = new FReporteInventarioMercaderiaEnTransito();
                formMercaderiaEnTransito.ListarVentasProductosReportesPorFechasCliente(DTListarComprasProductosReportesPorFechasTipo,
                    formParametrosFechas.FechaHoraInicio, formParametrosFechas.FechaHoraFin, true);
                formMercaderiaEnTransito.ShowDialog();
                formMercaderiaEnTransito.Dispose();
            }
            formParametrosFechas.Dispose();
        }

        public static void ListarVentasProductosReportesPorFechasCliente2(object sender, EventArgs e)
        {
            FParametrosRangoFechas formParametrosFechas = new FParametrosRangoFechas();
            if (formParametrosFechas.ShowDialog() == DialogResult.OK)
            {
                DataTable DTListarComprasProductosReportesPorFechasTipo = _InventariosProductosCLN.ListarVentasProductosReportesPorFechasCliente(NumeroAgencia,
                    formParametrosFechas.FechaHoraInicio, formParametrosFechas.FechaHoraFin, false);
                FReporteInventarioMercaderiaEnTransito formMercaderiaEnTransito = new FReporteInventarioMercaderiaEnTransito();
                formMercaderiaEnTransito.ListarVentasProductosReportesPorFechasCliente(DTListarComprasProductosReportesPorFechasTipo,
                    formParametrosFechas.FechaHoraInicio, formParametrosFechas.FechaHoraFin, false);
                formMercaderiaEnTransito.ShowDialog();
                formMercaderiaEnTransito.Dispose();
            }
            formParametrosFechas.Dispose();
        }

        public static void ListarVentasProductosReportesPorCreditosFechasCliente(object sender, EventArgs e)
        {
            FParametrosRangoFechas formParametrosFechas = new FParametrosRangoFechas();
            if (formParametrosFechas.ShowDialog() == DialogResult.OK)
            {
                DataTable DTListarComprasProductosReportesPorFechasTipo = _InventariosProductosCLN.ListarVentasProductosReportesPorCreditosFechasCliente(NumeroAgencia,
                    formParametrosFechas.FechaHoraInicio, formParametrosFechas.FechaHoraFin, false);
                FReporteInventarioMercaderiaEnTransito formMercaderiaEnTransito = new FReporteInventarioMercaderiaEnTransito();
                formMercaderiaEnTransito.ListarVentasProductosReportesPorCreditosFechasCliente(DTListarComprasProductosReportesPorFechasTipo,
                    formParametrosFechas.FechaHoraInicio, formParametrosFechas.FechaHoraFin, false);
                formMercaderiaEnTransito.ShowDialog();
                formMercaderiaEnTransito.Dispose();
            }
            formParametrosFechas.Dispose();
        }

        public static void ListarVentasProductosReportesPorCreditosFechasCliente2(object sender, EventArgs e)
        {
            FParametrosRangoFechas formParametrosFechas = new FParametrosRangoFechas();
            if (formParametrosFechas.ShowDialog() == DialogResult.OK)
            {
                DataTable DTListarComprasProductosReportesPorFechasTipo = _InventariosProductosCLN.ListarVentasProductosReportesPorCreditosFechasCliente(NumeroAgencia,
                    formParametrosFechas.FechaHoraInicio, formParametrosFechas.FechaHoraFin, true);
                FReporteInventarioMercaderiaEnTransito formMercaderiaEnTransito = new FReporteInventarioMercaderiaEnTransito();
                formMercaderiaEnTransito.ListarVentasProductosReportesPorCreditosFechasCliente(DTListarComprasProductosReportesPorFechasTipo,
                    formParametrosFechas.FechaHoraInicio, formParametrosFechas.FechaHoraFin, true);
                formMercaderiaEnTransito.ShowDialog();
                formMercaderiaEnTransito.Dispose();
            }
            formParametrosFechas.Dispose();
        } 

        #endregion
        //---------------------

        public static void ListarCompraProductoCuentasPorCobrarReporte(object sender, EventArgs e)
        {
            ComprasProductosCLN _ComprasProductosCLN = new ComprasProductosCLN();
            if (MessageBox.Show("¿Desea que el Informe agrupe la infomración por algún proveedor?", "Informe de Compras", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
            {
                FParametrosRangoFechas formParametrosFechas = new FParametrosRangoFechas();
                if (formParametrosFechas.ShowDialog() == DialogResult.OK)
                {
                    DataTable ListarCompraProductoCuentasPorCobrarReporte = _ComprasProductosCLN.ListarCompraProductoCuentasPorCobrarReporte(NumeroAgencia,
                        null, formParametrosFechas.FechaHoraInicio, formParametrosFechas.FechaHoraFin, null);
                    FReporteCuentasPorPagarCobrarTransacciones formMercaderiaEnTransito = new FReporteCuentasPorPagarCobrarTransacciones();
                    formMercaderiaEnTransito.ListarCompraProductoCuentasPorCobrarReporte(ListarCompraProductoCuentasPorCobrarReporte,
                        formParametrosFechas.FechaHoraInicio, formParametrosFechas.FechaHoraFin);
                    formMercaderiaEnTransito.ShowDialog();
                    formMercaderiaEnTransito.Dispose();
                }
                formParametrosFechas.Dispose();
            }
            else
            {
                FSeleccionFechasReportes formSeleccionParametros = new FSeleccionFechasReportes();
                formSeleccionParametros.cargarDatosFiltro
                    (new ProveedoresCLN().ListarProveedores(), "NombreRazonSocial", "CodigoProveedor");
                formSeleccionParametros.setVisibilidadFiltro(true);
                formSeleccionParametros.LabelFiltro.Text = "Proveedores[Opcional]";
                
                if (formSeleccionParametros.ShowDialog() == DialogResult.OK)
                {
                    DataTable DTListarCompraProductoCuentasPorCobrarReporte = _ComprasProductosCLN.ListarCompraProductoCuentasPorCobrarReporte(NumeroAgencia,
                        null, formSeleccionParametros.FechaInicio, formSeleccionParametros.FechaFin, null);
                    DataTable DTDatosFiltro;
                    if (formSeleccionParametros.SelectedValueFiltro != null)
                    {
                        DTDatosFiltro = DTListarCompraProductoCuentasPorCobrarReporte.Clone();
                        foreach (DataRow DRDatos in DTListarCompraProductoCuentasPorCobrarReporte.Select(" CodigoProveedor = " + formSeleccionParametros.SelectedValueFiltro.ToString(), ""))
                        {
                            DTDatosFiltro.Rows.Add(DRDatos.ItemArray);
                        }
                    }
                    else
                        DTDatosFiltro = DTListarCompraProductoCuentasPorCobrarReporte;

                    FReporteCuentasPorPagarCobrarTransacciones formCuentasPorCobrar = new FReporteCuentasPorPagarCobrarTransacciones();
                    formCuentasPorCobrar.ListarCompraProductoCuentasPorCobrarReportePorProveedor(DTDatosFiltro,
                        formSeleccionParametros.FechaInicio, formSeleccionParametros.FechaFin);
                    formCuentasPorCobrar.ShowDialog();
                    formCuentasPorCobrar.Dispose();
                }

            }
        }


        public static void ListarCompraProductoCuentasPorPagarReporte(object sender, EventArgs e)
        {
            ComprasProductosCLN _ComprasProductosCLN = new ComprasProductosCLN();
            if (MessageBox.Show("¿Desea que el Informe agrupe la infomración por algún proveedor?", "Informe de Compras", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
            {
                FParametrosRangoFechas formParametrosFechas = new FParametrosRangoFechas();
                if (formParametrosFechas.ShowDialog() == DialogResult.OK)
                {
                    DataTable ListarCompraProductoCuentasPorPagarReporte = _ComprasProductosCLN.ListarCompraProductoCuentasPorPagarReporte(NumeroAgencia,
                        null, formParametrosFechas.FechaHoraInicio, formParametrosFechas.FechaHoraFin, null);
                    FReporteCuentasPorPagarCobrarTransacciones formCuentaPorPagar = new FReporteCuentasPorPagarCobrarTransacciones();
                    formCuentaPorPagar.ListarCompraProductoCuentasPorPagarReporte(ListarCompraProductoCuentasPorPagarReporte,
                        formParametrosFechas.FechaHoraInicio, formParametrosFechas.FechaHoraFin);
                    formCuentaPorPagar.ShowDialog();
                    formCuentaPorPagar.Dispose();
                }
                formParametrosFechas.Dispose();
            }
            else
            {
                FSeleccionFechasReportes formSeleccionParametros = new FSeleccionFechasReportes();
                formSeleccionParametros.cargarDatosFiltro(new ProveedoresCLN().ListarProveedores(), "NombreRazonSocial", "CodigoProveedor");
                formSeleccionParametros.setVisibilidadFiltro(true);
                formSeleccionParametros.LabelFiltro.Text = "Proveedores[Opcional]";                
                if (formSeleccionParametros.ShowDialog() == DialogResult.OK)
                {
                    DataTable DTListarCompraProductoCuentasPorPagarReporte = _ComprasProductosCLN.ListarCompraProductoCuentasPorPagarReporte(NumeroAgencia,
                        null, formSeleccionParametros.FechaInicio, formSeleccionParametros.FechaFin, null);
                    DataTable DTDatosFiltro;
                    if (formSeleccionParametros.SelectedValueFiltro != null)
                    {
                        DTDatosFiltro = DTListarCompraProductoCuentasPorPagarReporte.Clone();
                        foreach (DataRow DRDatos in DTListarCompraProductoCuentasPorPagarReporte.Select(" CodigoProveedor = " + formSeleccionParametros.SelectedValueFiltro.ToString(), ""))
                        {
                            DTDatosFiltro.Rows.Add(DRDatos.ItemArray);
                        }
                    }
                    else
                        DTDatosFiltro = DTListarCompraProductoCuentasPorPagarReporte;

                    FReporteCuentasPorPagarCobrarTransacciones formCuentasPorPagar = new FReporteCuentasPorPagarCobrarTransacciones();
                    formCuentasPorPagar.ListarCompraProductoCuentasPorPagarReportePorProveedor(DTDatosFiltro,
                        formSeleccionParametros.FechaInicio, formSeleccionParametros.FechaFin);
                    formCuentasPorPagar.ShowDialog();
                    formCuentasPorPagar.Dispose();
                }

            }
        }


        public static void ListarKardexProductoDetalladoReporte(object sender, EventArgs e)
        {
            FParametrosRangoFechas formParametrosFechas = new FParametrosRangoFechas();
            if (formParametrosFechas.ShowDialog() == DialogResult.OK)
            {
                
                FReporteInventarioMercaderiaEnTransito formMercaderiaEnTransito = new FReporteInventarioMercaderiaEnTransito();
                formMercaderiaEnTransito.ListarKardexProductoDetalladoReporte(NumeroAgencia, _InventariosProductosCLN,
                    formParametrosFechas.FechaHoraInicio, formParametrosFechas.FechaHoraFin);
                formMercaderiaEnTransito.ShowDialog();
                formMercaderiaEnTransito.Dispose();
            }
            formParametrosFechas.Dispose();
        }

        public static void ListarKardexValorado(object sender, EventArgs e)
        {
            FParametrosRangoFechas formParametrosFechas = new FParametrosRangoFechas();
            if (formParametrosFechas.ShowDialog() == DialogResult.OK)
            {
              
                FReporteInventarioMercaderiaEnTransito formMercaderiaEnTransito = new FReporteInventarioMercaderiaEnTransito();
                formMercaderiaEnTransito.ListarKardexValorado(NumeroAgencia, _InventariosProductosCLN,
                    formParametrosFechas.FechaHoraInicio, formParametrosFechas.FechaHoraFin);
                formMercaderiaEnTransito.ShowDialog();
                formMercaderiaEnTransito.Dispose();
            }
            formParametrosFechas.Dispose();
        }

        public static void ListarHistorialInventarioPorFecha(object sender, EventArgs e)
        {
            FParametrosRangoFechas formParametrosFechas = new FParametrosRangoFechas();
            if (formParametrosFechas.ShowDialog() == DialogResult.OK)
            {
                
                FReporteInventarioMercaderiaEnTransito formMercaderiaEnTransito = new FReporteInventarioMercaderiaEnTransito();
                formMercaderiaEnTransito.ListarHistorialInventarioPorFecha(NumeroAgencia, _InventariosProductosCLN,
                    formParametrosFechas.FechaHoraInicio, formParametrosFechas.FechaHoraFin);
                formMercaderiaEnTransito.ShowDialog();
                formMercaderiaEnTransito.Dispose();
            }
            formParametrosFechas.Dispose();
        }

        
        public static void DepositosBancarios(object sender, EventArgs e)
        {
            MessageBox.Show("DepositosBancarios");
        }
        public static void CuentasPorPagar(object sender, EventArgs e)
        {
            PermisosInterface = PCConfiguracion.ObtenerPermisosInterface(CodigoUsuario, NumeroAgencia, "FCuentasPorPagar");
            FCuentasPorPagar fcpp = new FCuentasPorPagar(CodigoUsuario,NumeroAgencia,bool.Parse(PermisosInterface.Rows[0][0].ToString()), bool.Parse(PermisosInterface.Rows[0][1].ToString()), bool.Parse(PermisosInterface.Rows[0][2].ToString()), bool.Parse(PermisosInterface.Rows[0][3].ToString()), bool.Parse(PermisosInterface.Rows[0][4].ToString()));
            fcpp.ShowDialog();
        }
        public static void CuentasPorCobrar(object sender, EventArgs e)
        {
            PermisosInterface = PCConfiguracion.ObtenerPermisosInterface(CodigoUsuario, NumeroAgencia, "FCuentasPorCobrar");
            FCuentasPorCobrar fcpc = new FCuentasPorCobrar(CodigoUsuario, NumeroAgencia, bool.Parse(PermisosInterface.Rows[0][0].ToString()), bool.Parse(PermisosInterface.Rows[0][1].ToString()), bool.Parse(PermisosInterface.Rows[0][2].ToString()), bool.Parse(PermisosInterface.Rows[0][3].ToString()), bool.Parse(PermisosInterface.Rows[0][4].ToString()));
            fcpc.ShowDialog();
        }

        public static void ConfiguracionCuentas(object sender, EventArgs e)
        {
            PermisosInterface = PCConfiguracion.ObtenerPermisosInterface(CodigoUsuario, NumeroAgencia, "FCuentasPorCobrar");
            FConfiguracionCuentas fcc = new FConfiguracionCuentas(CodigoUsuario,
                 bool.Parse(PermisosInterface.Rows[0][0].ToString()), bool.Parse(PermisosInterface.Rows[0][1].ToString()), bool.Parse(PermisosInterface.Rows[0][2].ToString()), bool.Parse(PermisosInterface.Rows[0][3].ToString()), bool.Parse(PermisosInterface.Rows[0][4].ToString()));
            fcc.ShowDialog();
        }
        public static void AsientosContables(object sender, EventArgs e)
        {
            PermisosInterface = PCConfiguracion.ObtenerPermisosInterface(CodigoUsuario, NumeroAgencia, "FAsientosContables");

            FAsientosContables ftransaccion = new FAsientosContables(CodigoUsuario, bool.Parse(PermisosInterface.Rows[0][0].ToString()),
                                                                   bool.Parse(PermisosInterface.Rows[0][1].ToString()),
                                                                   bool.Parse(PermisosInterface.Rows[0][2].ToString()),
                                                                   bool.Parse(PermisosInterface.Rows[0][3].ToString()),
                                                                   bool.Parse(PermisosInterface.Rows[0][4].ToString()));
            ftransaccion.ShowDialog();
        }
        public static void AdministradorCompras(object sender, EventArgs e)
        {
            FCompraProductosBuscador _FCompraProductosBuscador = new FCompraProductosBuscador(NumeroAgencia, NumeroPC, CodigoUsuario);
            //_FCompraProductosBuscador.CargarConfiguracionInicial(NombreMonedaSistema, CodigoMonedaSistema, MascaraMonedaSistema, CodigoMonedaRegion, NombreMonedaRegion, MascaraMonedaRegion, PorcentajeImpuestoSistema);
            _FCompraProductosBuscador.formatearParaBusquedasGeneral();
            _FCompraProductosBuscador.ShowDialog();
        }
        public static void ListaProductosProveedores(object sender, EventArgs e)
        {
            PermisosInterface = PCConfiguracion.ObtenerPermisosInterface(CodigoUsuario, NumeroAgencia, "FProductosEmpresasLista");
            FProductosEmpresasLista _FProductosEmpresasLista = new FProductosEmpresasLista(bool.Parse(PermisosInterface.Rows[0][0].ToString()),
                                                                   bool.Parse(PermisosInterface.Rows[0][1].ToString()),
                                                                   bool.Parse(PermisosInterface.Rows[0][2].ToString()),
                                                                   bool.Parse(PermisosInterface.Rows[0][3].ToString()),
                                                                   bool.Parse(PermisosInterface.Rows[0][4].ToString()));
            _FProductosEmpresasLista.ShowDialog();
            _FProductosEmpresasLista.Dispose();
            
        }
        public static void ImportarListaProveedores(object sender, EventArgs e)
        {
            PermisosInterface = PCConfiguracion.ObtenerPermisosInterface(CodigoUsuario, NumeroAgencia, "FProductosEmpresasLista");
            //FProductosEmpresasListaRegistrar fpelr = new FProductosEmpresasListaRegistrar();
            //fpelr.ShowDialog();
        }
        public static void AdministradorVentas(object sender, EventArgs e)
        {
            FVentasProductosBusqueda _FVentasProductosBusqueda = new FVentasProductosBusqueda(NumeroAgencia, NumeroPC, CodigoUsuario);
            //_FVentasProductosBusqueda.CargarConfiguracionInicial(NombreMonedaSistema, CodigoMonedaSistema, MascaraMonedaSistema, CodigoMonedaRegion, NombreMonedaRegion, MascaraMonedaRegion, PorcentajeImpuestoSistema);
            _FVentasProductosBusqueda.esParaPagarVenta = false;
            _FVentasProductosBusqueda.soloNavegacion = true;
            _FVentasProductosBusqueda.formatearParaBusquedasGeneral();
            _FVentasProductosBusqueda.ShowDialog();
            _FVentasProductosBusqueda.Dispose();
        }
        public static void CotizacionesVentas(object sender, EventArgs e)
        {
            FCotizacionesVentas2 fcotizacionesproductos = new FCotizacionesVentas2(NumeroAgencia, NumeroPC, CodigoUsuario);
            //fcotizacionesproductos.CargarConfiguracionInicial(NombreMonedaSistema, CodigoMonedaSistema, MascaraMonedaSistema, CodigoMonedaRegion, NombreMonedaRegion, MascaraMonedaRegion, PorcentajeImpuestoSistema);
            fcotizacionesproductos.ShowDialog();
            fcotizacionesproductos.Dispose();
        }
        public static void ListadoProductosVentas(object sender, EventArgs e)
        {
            WFADoblones20.FormulariosGestionComercial.FAdministradorDeProductos formAdministrador = new WFADoblones20.FormulariosGestionComercial.FAdministradorDeProductos(NumeroAgencia, CodigoUsuario, NumeroPC);
            formAdministrador.StartPosition = FormStartPosition.CenterScreen;
            //formAdministrador.setCodigoMonedaSistema(CodigoMonedaSistema);
            formAdministrador.ShowDialog();
            formAdministrador.Dispose();
        }
        public static void AdministradorInventarios(object sender, EventArgs e)
        {
            FInventarioProductos finventarioproductos = new FInventarioProductos(NumeroAgencia, NumeroPC);
            finventarioproductos.ShowDialog();
            finventarioproductos.Dispose();
        }
        public static void AdministradorRequerimientosProductos(object sender, EventArgs e)
        {
            FProductosRequeridos _FProductosRequeridos = new FProductosRequeridos(NumeroAgencia);
            _FProductosRequeridos.ShowDialog();
            _FProductosRequeridos.Dispose();
        }
        public static void AdministradorTransferencias(object sender, EventArgs e)
        {
            FTransferenciasProductosAdministrador _FTransferenciasProductosAdministrador = new FTransferenciasProductosAdministrador(NumeroAgencia, NumeroPC, CodigoUsuario, "E");
            //_FTransferenciasProductosAdministrador.CargarConfiguracionInicial(NombreMonedaSistema, CodigoMonedaSistema, MascaraMonedaSistema, CodigoMonedaRegion, NombreMonedaRegion, MascaraMonedaRegion, PorcentajeImpuestoSistema);
            _FTransferenciasProductosAdministrador.formatearParaBusquedasGeneral();
            _FTransferenciasProductosAdministrador.ShowDialog();
            _FTransferenciasProductosAdministrador.Dispose();
        }
        public static void AdministradorContabilidad(object sender, EventArgs e)
        {
            PermisosInterface = PCConfiguracion.ObtenerPermisosInterface(CodigoUsuario, NumeroAgencia, "FAsientosContables");

            FAsientosAdministrador ftransaccion = new FAsientosAdministrador(CodigoUsuario, bool.Parse(PermisosInterface.Rows[0][0].ToString()),
                                                                   bool.Parse(PermisosInterface.Rows[0][1].ToString()),
                                                                   bool.Parse(PermisosInterface.Rows[0][2].ToString()),
                                                                   bool.Parse(PermisosInterface.Rows[0][3].ToString()),
                                                                   bool.Parse(PermisosInterface.Rows[0][4].ToString()));
            ftransaccion.ShowDialog();
        }
        public static void AdministradorCaja(object sender, EventArgs e)
        {
            PermisosInterface = PCConfiguracion.ObtenerPermisosInterface(CodigoUsuario, NumeroAgencia, "FAsientosContables");

            FCajaMovimientos fcajamovimientos = new FCajaMovimientos(CodigoUsuario, NumeroAgencia);
            fcajamovimientos.ShowDialog();
        }
        public static void SeguimientoCompetencia(object sender, EventArgs e)
        {
            MessageBox.Show("SeguimientoCompetencia");
        }
        public static void BalanceGeneral(object sender, EventArgs e)
        {
            PermisosInterface = PCConfiguracion.ObtenerPermisosInterface(CodigoUsuario, NumeroAgencia, "FBalanceGeneral");
            FBalanceGeneral balancegral = new FBalanceGeneral();
            balancegral.ShowDialog();
        }
        public static void BalanceGeneralComparativo(object sender, EventArgs e)
        {
            PermisosInterface = PCConfiguracion.ObtenerPermisosInterface(CodigoUsuario, NumeroAgencia, "FBalanceGeneral");
            FBalanceGeneralComparativo bgc = new FBalanceGeneralComparativo();
            bgc.ShowDialog();
        }
        public static void EstadoResultados(object sender, EventArgs e)
        {
            PermisosInterface = PCConfiguracion.ObtenerPermisosInterface(CodigoUsuario, NumeroAgencia, "FEstadoResultados");
            FEstadoResultados fresultados = new FEstadoResultados();
            fresultados.ShowDialog();
        }
        public static void EstadoResultadosComparativo(object sender, EventArgs e)
        {
            PermisosInterface = PCConfiguracion.ObtenerPermisosInterface(CodigoUsuario, NumeroAgencia, "FEstadoResultados");
            FEstadoResultadosComparativo ferc = new FEstadoResultadosComparativo();
            ferc.ShowDialog();
        }
        public static void LibroDiario(object sender, EventArgs e)
        {
            PermisosInterface = PCConfiguracion.ObtenerPermisosInterface(CodigoUsuario, NumeroAgencia, "FLibroDiario");
            FLibroDiario flibordiario = new FLibroDiario();
            flibordiario.ShowDialog();
        }
        public static void LibroMayores(object sender, EventArgs e)
        {
            PermisosInterface = PCConfiguracion.ObtenerPermisosInterface(CodigoUsuario, NumeroAgencia, "FLibroMayores");
            FLibroMayores flibromayor = new FLibroMayores();
            flibromayor.ShowDialog();
        }
        public static void Paises(object sender, EventArgs e)
        {
            FGeografico fgeografico = new FGeografico();
            fgeografico.seleccionarPestaniaPais();
            fgeografico.ShowDialog();
        }
        public static void Departamentos(object sender, EventArgs e)
        {
            FGeografico fgeografico = new FGeografico();
            fgeografico.seleccionarPestaniaDepartamento();
            fgeografico.ShowDialog();
        }
        public static void Provincias(object sender, EventArgs e)
        {
            FGeografico fgeografico = new FGeografico();
            fgeografico.seleccionarPestaniaProvincia();
            fgeografico.ShowDialog();
        }
        public static void Lugares(object sender, EventArgs e)
        {
            FGeografico fgeografico = new FGeografico();
            fgeografico.seleccionarPestaniaLugar();
            fgeografico.ShowDialog();

        }
        public static void Marcas(object sender, EventArgs e)
        {
            FProductosMarcas fproductosmarcas = new FProductosMarcas();
            fproductosmarcas.ShowDialog();
        }

        public static void FProductosTiposGarantias(object sender, EventArgs e)
        {
            FProductosTiposGarantias formTiposGarantias = new FProductosTiposGarantias();
            formTiposGarantias.ShowDialog();
            
        }
        public static void GastosTiposTransacciones(object sender, EventArgs e)
        {
            FGastosTiposTransacciones formGastoas= new FGastosTiposTransacciones();
            formGastoas.ShowDialog();

        }
        public static void Propiedades(object sender, EventArgs e)
        {
            FProductosPropiedades fproductospropiedades = new FProductosPropiedades();
            fproductospropiedades.ShowDialog();
        }
        public static void AdministradorProductos(object sender, EventArgs e)
        {
            FAdministradorProductos fAdministradorProductos = new FAdministradorProductos(NumeroAgencia, NumeroPC, CodigoUsuario, true, true, true, true, true, RutaDirectorioImagenes);
            fAdministradorProductos.ShowDialog();
        }
        public static void Unidades(object sender, EventArgs e)
        {
            FProductosUnidades fproductosunidades = new FProductosUnidades();
            fproductosunidades.ShowDialog();
        }
        public static void FrecuenciasPagos(object sender, EventArgs e)
        {
            FFrecuenciasPagos ffrecuenciaspagos = new FFrecuenciasPagos();
            ffrecuenciaspagos.ShowDialog();
        }
        public static void MotivosReemplazoDevolucion(object sender, EventArgs e)
        {
            FMotivosReemDevo fmotivosreemdevo = new FMotivosReemDevo();
            fmotivosreemdevo.ShowDialog();
        }
        public static void Bancos(object sender, EventArgs e)
        {
            FBancos fbancos = new FBancos();
            fbancos.ShowDialog();
        }
        public static void Monedas(object sender, EventArgs e)
        {
            FMonedas fmonedas = new FMonedas();
            fmonedas.ShowDialog();

        }
        public static void MonedasFracciones(object sender, EventArgs e)
        {
            FMonedasFracciones _FMonedasFracciones = new FMonedasFracciones();
            _FMonedasFracciones.ShowDialog();
            _FMonedasFracciones.Dispose();
        }
        public static void InicioGestionContable(object sender, EventArgs e)
        {
            FInicioGestion _FInicioGestion = new FInicioGestion();
            _FInicioGestion.ShowDialog();
            _FInicioGestion.Dispose();
        }
        public static void PlanCuentas(object sender, EventArgs e)
        {
            PermisosInterface = PCConfiguracion.ObtenerPermisosInterface(CodigoUsuario, NumeroAgencia, "FPlanCuentas");
            FPlanCuentas formPlanCuentas = new FPlanCuentas(bool.Parse(PermisosInterface.Rows[0][0].ToString()),
                                                                   bool.Parse(PermisosInterface.Rows[0][1].ToString()),
                                                                   bool.Parse(PermisosInterface.Rows[0][2].ToString()),
                                                                   bool.Parse(PermisosInterface.Rows[0][3].ToString()),
                                                                   bool.Parse(PermisosInterface.Rows[0][4].ToString()));
            formPlanCuentas.ShowDialog();
            formPlanCuentas.Dispose();
        }
        public static void AyudaSistema(object sender, EventArgs e)
        {
            MessageBox.Show("AyudaSistema");
        }
        public static void AcercaDe(object sender, EventArgs e)
        {
            MessageBox.Show("AcercaDe");
        }
    }

    public delegate void DFuncionEnlace(object sender, EventArgs e);

    public class MenuDinamico
    {
        MenuStrip MSMenuContenedor;
        DataTable DTMenuUsuarioAgencia;

        public MenuDinamico(MenuStrip MS, DataTable DT)
        {
            this.MSMenuContenedor = new MenuStrip();
            this.DTMenuUsuarioAgencia = new DataTable();

            this.MSMenuContenedor = MS;
            this.DTMenuUsuarioAgencia = DT;
        }

        public void ConstruirMenu()
        {
            ToolStripMenuItem TSMIAux = new ToolStripMenuItem();

            foreach (DataRow FilaActual in DTMenuUsuarioAgencia.Rows)
            {
                if (FilaActual[1].ToString().Trim() != "")
                {
                    TSMIAux = BuscarElementoEnMenu(MSMenuContenedor.Items, FilaActual[3].ToString());
                    if (TSMIAux != null)
                    {
                        if (FilaActual[5].ToString() == "S")
                        {
                            ToolStripSeparator TSSSeparador = new ToolStripSeparator();
                            TSSSeparador.Name = FilaActual[2].ToString();
                            TSSSeparador.Text = FilaActual[4].ToString();

                            TSMIAux.DropDownItems.Add(TSSSeparador);
                        }
                        else
                        {
                            ToolStripMenuItem TSMIElementoMenu = new ToolStripMenuItem();
                            TSMIElementoMenu.Name = FilaActual[2].ToString();
                            TSMIElementoMenu.Text = FilaActual[4].ToString();
                            //TSMIElementoMenu.Image = Image.FromFile(FilaActual[6].ToString());

                            if ((FilaActual[7].ToString().Trim() != "") && (FilaActual[8].ToString().Trim() != "") && (bool.Parse(FilaActual[14].ToString()) == true))
                            {
                                try
                                {
                                    TSMIElementoMenu.Image = Image.FromFile(FilaActual[6].ToString());
                                }
                                catch
                                {
                                    TSMIElementoMenu.Image = Image.FromFile(@"./Iconos/16/000.ico");
                                }
                            }

                            Type t = typeof(FPrincipal);
                            MethodInfo m = t.GetMethod(FilaActual[11].ToString());
                            if (m != null)
                            {
                                DFuncionEnlace od = (DFuncionEnlace)Delegate.CreateDelegate(typeof(DFuncionEnlace), m);
                                TSMIElementoMenu.Click += new EventHandler(od);
                            }

                            TSMIAux.DropDownItems.Add(TSMIElementoMenu);
                        }
                    }
                }
                else
                {
                    ToolStripMenuItem ElementoMenu = new ToolStripMenuItem();
                    ElementoMenu.Name = FilaActual[2].ToString();
                    ElementoMenu.Text = FilaActual[4].ToString();

                    MSMenuContenedor.Items.Add(ElementoMenu);
                }
            }
        }

        private ToolStripMenuItem BuscarElementoEnMenu(ToolStripItemCollection TSIC, string NombreMenu)
        {
            ToolStripMenuItem TSMIElementoBuscado = null;

            foreach (ToolStripItem TSIElementoActual in TSIC)
            {
                if (!(TSIElementoActual is ToolStripSeparator))
                {
                    if (TSIElementoActual.Name.ToUpper().TrimEnd() == NombreMenu.ToUpper().TrimEnd())
                    {
                        TSMIElementoBuscado = (ToolStripMenuItem)TSIElementoActual;
                        return TSMIElementoBuscado;
                    }

                    if (((ToolStripMenuItem)TSIElementoActual).HasDropDownItems)
                    {
                        TSMIElementoBuscado = BuscarElementoEnMenu(((ToolStripMenuItem)TSIElementoActual).DropDown.Items, NombreMenu);
                        if (TSMIElementoBuscado != null)
                        {
                            break;
                        }
                    }
                }
            }
            return TSMIElementoBuscado;
        }
    }


    public class BarraHerramientasDinamica
    {
        ToolStripContainer TSCContenedorBarraHerramientas;
        DataTable DTBarraHerramientasUsuarioAgencia;
        int AnchoFormularioContenedor = 0;
        
        public BarraHerramientasDinamica(ToolStripContainer TSC, DataTable DT, int afc)
        {
            this.TSCContenedorBarraHerramientas = new ToolStripContainer();
            this.DTBarraHerramientasUsuarioAgencia = new DataTable();

            this.TSCContenedorBarraHerramientas = TSC;
            this.DTBarraHerramientasUsuarioAgencia = DT;
            this.AnchoFormularioContenedor = afc;
        }

        public void ReorganizarBarraHerramientas()
        {
            ToolStrip TSAux = new ToolStrip();
            TSCContenedorBarraHerramientas.TopToolStripPanel.SuspendLayout();
            
            /*
            foreach (Control ControlActual in TSCContenedorBarraHerramientas.TopToolStripPanel.Controls)
            {
                Type TipoObjeto = ControlActual.GetType();
                if (TipoObjeto.
                    .Name == FilaActual[8].ToString())
                {
                    TSDestino = (ToolStrip)ControlActual;
                    ExisteControl = true;
                    break;
                }
            }
            */ 
        }


        public void ConstruirBarraHerramientas()
        {
            Point ProximaPosicion = new Point(0, 0);
            bool ExisteControl = false;
            ToolStrip TSDestino = new ToolStrip();
        
            foreach (DataRow FilaActual in DTBarraHerramientasUsuarioAgencia.Rows)
            {
                if ((FilaActual[7].ToString().Trim() != "") && (FilaActual[8].ToString().Trim() != "") && (bool.Parse(FilaActual[14].ToString()) == true))
                {
                    ExisteControl = false;

                    foreach (Control ControlActual in TSCContenedorBarraHerramientas.TopToolStripPanel.Controls)
                    {
                        if (ControlActual.Name == FilaActual[8].ToString())
                        {
                            TSDestino = (ToolStrip)ControlActual;
                            ExisteControl = true;
                            break;
                        }
                    }

                    if (!ExisteControl)
                    {
                        TSDestino = new ToolStrip();
                        TSDestino.Name = FilaActual[8].ToString();
                        TSDestino.Location = ProximaPosicion;
                        ProximaPosicion = new System.Drawing.Point(0, TSDestino.Bottom);
                        //TSCContenedorBarraHerramientas.TopToolStripPanel.SuspendLayout();
                        TSDestino.Parent = TSCContenedorBarraHerramientas.TopToolStripPanel;
                        //TSCContenedorBarraHerramientas.TopToolStripPanel.Controls.Add(TSDestino);

                        //TSCContenedorBarraHerramientas.TopToolStripPanel.ResumeLayout();
                    }

                    ToolStripButton TSBElementoBarraHerramientas = new ToolStripButton();
                    TSBElementoBarraHerramientas.Name = FilaActual[7].ToString();
                    TSBElementoBarraHerramientas.Text = FilaActual[9].ToString();
                    //TSBElementoBarraHerramientas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
                    TSBElementoBarraHerramientas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
                    TSBElementoBarraHerramientas.ImageScaling = ToolStripItemImageScaling.None;

                    //TSBElementoBarraHerramientas.Image = Image.FromFile(Environment.CurrentDirectory + @"\Iconos\22.ico");
                    //TSBElementoBarraHerramientas.Image = Image.FromFile(@"./Iconos/48/411.ico");
                    try
                    {
                        TSBElementoBarraHerramientas.Image = Image.FromFile(FilaActual[10].ToString());
                    }
                    catch
                    {
                        TSBElementoBarraHerramientas.Image = Image.FromFile(@"./Iconos/48/000.ico");
                        //TSBElementoBarraHerramientas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
                    }

                    Type t = typeof(FPrincipal);
                    MethodInfo m = t.GetMethod(FilaActual[11].ToString());
                    if (m != null)
                    {
                        DFuncionEnlace od = (DFuncionEnlace)Delegate.CreateDelegate(typeof(DFuncionEnlace), m);
                        TSBElementoBarraHerramientas.Click += new EventHandler(od);
                    }

                    TSDestino.Items.Add(TSBElementoBarraHerramientas);
                }
            }
        }
    }
}

