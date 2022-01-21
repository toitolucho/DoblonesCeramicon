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
    public partial class FVentasProductosReemDevo : Form
    {
        #region DataTables del Formulario
        private DataTable DTVentasProductosDevoluciones = null;
        
        private DataTable DTVentasProductosDevolucionesDetalle = null;
        private DataTable DTVentasProductosDevolucionesDetalleTemporal = null;
        private DataTable DTVentasProductosDevolucionesEspecificos = null;
        private DataTable DTVentasProductosDevolucionesEspecificosTemporal = null;

        private DataTable DTVentasProductosReemplazos = null;        
        private DataTable DTVentasProductosReemplazosDetalle = null;
        private DataTable DTVentasProductosReemplazosDetalleTemporal = null;
        private DataTable DTVentasProductosReemplazosEspecificos = null;
        private DataTable DTVentasProductosReemplazosEspecificosTemporal = null;

        private DataTable DTVentasProductosDevolucionesReemplazos = null;        
        private DataTable DTVentasProductosDevolucionesReemplazosDetalle = null;
        private DataTable DTVentasProductosDevolucionesReemplazosDetalleTemporal = null;
        private DataTable DTVentasProductosDevolucionesReemplazosDetalleCompleto = null;

        private DataTable DTVentasproductosDevoDisponiblesBackup = null;
        private DataTable DTVentasproductosReemDisponiblesBackup = null;
        private DataTable DTVentasproductosDevoDisponibles = null;
        private DataTable DTVentasproductosReemDisponibles = null;

        private DataTable DTUsuario = null;

        #endregion

        #region Atributos de la Capa del Negocio
        private VentasProductosDevolucionesCLN _VentasProductosDevolucionesCLN;
        private VentasProductosDevolucionesDetalleCLN _VentasProductosDevolucionesDetalleCLN;
        private VentasProductosDevolucionesEspecificosCLN _VentasProductosDevolucionesEspecificosCLN;
        private TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;
        private VentasProductosReemplazoCLN _VentasProductosReemplazoCLN;
        private VentasProductosReemplazoDetalleCLN _VentasProductosReemplazoDetalleCLN;
        private VentasProductosReemplazoEspecificosCLN _VentasProductosReemplazoEspecificosCLN;
        private VentasProductosReemplazoDevolucionesCLN _VentasProductosReemplazoDevolucionesCLN;
        private VentasProductosReemplazoDevolucionesDetalleCLN _VentasProductosReemplazoDevolucionesDetalleCLN;

        private UsuariosCLN _UsuariosCLN;
        #endregion


        private int NumeroAgencia;
        private int NumeroPC;
        private int CodigoUsuario;
        private int NumeroDevolucion;
        private int NumeroTransaccion;
        private int NumeroReemplazo;
        private int NumeroReemDevo;

        private string MascaraMoneda = "Bs";
        private int CantidadProductosEspecificos = 0;
        private Color ColorResaltado = Color.Bisque;
        private DataSet DSDevoluciones = new DataSet();
        private DataSet DSReemplazos = new DataSet();
        private bool usuarioSeleccionaEspecifico = false;
        private Font fuenteDefecto;

        string cardinalidad = "1x1";  // 1x1  Mx1  Mx1
        public FVentasProductosReemDevo(int NumeroAgencia, int NumeroPC, int CodigoUsuario)
        {
            InitializeComponent();
            this.NumeroAgencia = NumeroAgencia;
            this.NumeroPC = NumeroPC;
            this.CodigoUsuario = CodigoUsuario;

            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();
            _VentasProductosDevolucionesCLN = new VentasProductosDevolucionesCLN();
            _VentasProductosDevolucionesDetalleCLN = new VentasProductosDevolucionesDetalleCLN();
            _VentasProductosDevolucionesEspecificosCLN = new VentasProductosDevolucionesEspecificosCLN();
            _VentasProductosReemplazoCLN = new VentasProductosReemplazoCLN();
            _VentasProductosReemplazoDetalleCLN = new VentasProductosReemplazoDetalleCLN();
            _VentasProductosReemplazoEspecificosCLN = new VentasProductosReemplazoEspecificosCLN();
            _VentasProductosReemplazoDevolucionesCLN = new VentasProductosReemplazoDevolucionesCLN();
            _VentasProductosReemplazoDevolucionesDetalleCLN = new VentasProductosReemplazoDevolucionesDetalleCLN();
            _UsuariosCLN = new UsuariosCLN();

            dtGVDevolucionesProductosDetalle.DataSource = DTVentasProductosDevolucionesDetalle;
            //dtGVDevolucionesProductosEspecificos.DataSource = DTVentasProductosDevolucionesEspecificos;ç
            formatearEstiloGrilla(this.dtGVDevolucionesProductosEspecificos);
            formatearEstiloGrilla(this.dtVGReemplazoProductosEspecificosAgrupados);

            dtGVDevolucionesProductosDetalle.AutoGenerateColumns = false;
            dtGVDevolucionesProductosEspecificos.AutoGenerateColumns = false;

            formatearTablasProductosReemplazos();
            fuenteDefecto = this.dtGVReemplazoProductosDetalle.Font;
        }


        public void formatearTablasProductosReemplazos()
        {
            //Productos Especificos
            DataColumn DCCodigoProducto = new DataColumn();
            DCCodigoProducto.DataType = Type.GetType("System.String");
            DCCodigoProducto.ColumnName = "CodigoProducto";
            DCCodigoProducto.ReadOnly = true;
            DCCodigoProducto.DefaultValue = " ";

            DataColumn DCCodigoProductoEspecifico = new DataColumn();
            DCCodigoProductoEspecifico.DataType = Type.GetType("System.String");
            DCCodigoProductoEspecifico.AllowDBNull = false;
            DCCodigoProductoEspecifico.Unique = true;
            DCCodigoProductoEspecifico.DefaultValue = "______-1";
            DCCodigoProductoEspecifico.ColumnName = "CodigoProductoEspecifico";

            DataColumn DCNombreProducto1 = new DataColumn();
            DCNombreProducto1.DataType = Type.GetType("System.String");
            DCNombreProducto1.AllowDBNull = true;
            DCNombreProducto1.Unique = false;
            DCNombreProducto1.DefaultValue = " ";
            DCNombreProducto1.ColumnName = "NombreProducto";

            DataColumn DCTiempoGarantiaPE = new DataColumn();
            DCTiempoGarantiaPE.DataType = Type.GetType("System.Int16");
            DCTiempoGarantiaPE.DefaultValue = 0;
            DCTiempoGarantiaPE.ColumnName = "TiempoGarantiaPE";

            DataColumn DCPrecioUnitarioReemplazoPE = new DataColumn();
            DCPrecioUnitarioReemplazoPE.DataType = Type.GetType("System.Decimal");
            DCPrecioUnitarioReemplazoPE.DefaultValue = 0;
            DCPrecioUnitarioReemplazoPE.ColumnName = "PrecioUnitarioReemplazoPE";


            DataColumn DCFechaHoraVencimientoPE = new DataColumn();
            DCFechaHoraVencimientoPE.DataType = Type.GetType("System.DateTime"); 
            DCFechaHoraVencimientoPE.DefaultValue = DateTime.Now.AddMonths(3);
            DCFechaHoraVencimientoPE.ColumnName = "FechaHoraVencimientoPE";

            DTVentasProductosReemplazosEspecificosTemporal = new DataTable();
            DTVentasProductosReemplazosEspecificosTemporal.Columns.AddRange(new DataColumn[] { DCCodigoProducto, DCCodigoProductoEspecifico, DCNombreProducto1, DCPrecioUnitarioReemplazoPE, DCTiempoGarantiaPE, DCFechaHoraVencimientoPE });

            DTVentasProductosReemplazosEspecificosTemporal.PrimaryKey = null;
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = DTVentasProductosReemplazosEspecificosTemporal.Columns["CodigoProductoEspecifico"];
            DTVentasProductosReemplazosEspecificosTemporal.PrimaryKey = PrimaryKeyColumns;


            
            //--------------- Productos Detalle
            DataColumn DCCodigoProducto2 = new DataColumn();
            DCCodigoProducto2.DataType = Type.GetType("System.String");
            DCCodigoProducto2.ColumnName = "CodigoProducto";
            DCCodigoProducto2.ReadOnly = true;
            DCCodigoProducto2.DefaultValue = " ";
            DCCodigoProducto2.AllowDBNull = false;

            DataColumn DCNombreProducto2 = new DataColumn();
            DCNombreProducto2.DataType = Type.GetType("System.String");
            DCNombreProducto2.AllowDBNull = false;
            DCNombreProducto2.Unique = true;
            DCNombreProducto2.DefaultValue = " ";
            DCNombreProducto2.ColumnName = "NombreProducto";

            DataColumn DCCantidadDevuelta = new DataColumn();
            DCCantidadDevuelta.DataType = Type.GetType("System.Int32");            
            DCCantidadDevuelta.Unique = false;
            DCCantidadDevuelta.DefaultValue = "1";
            DCCantidadDevuelta.ColumnName = "CantidadDevuelta";

            DataColumn DCPrecioUnitarioReemplazo = new DataColumn();
            DCPrecioUnitarioReemplazo.DataType = Type.GetType("System.Decimal");
            DCPrecioUnitarioReemplazo.DefaultValue = 0;
            DCPrecioUnitarioReemplazo.ColumnName = "PrecioUnitarioReemplazo";

            DataColumn DCTiempoGarantia = new DataColumn();
            DCTiempoGarantia.DataType = Type.GetType("System.Int16");
            DCTiempoGarantia.DefaultValue = 0;
            DCTiempoGarantia.ColumnName = "TiempoGarantia";
            
            DataColumn DCFechaHoraVencimiento = new DataColumn();
            DCFechaHoraVencimiento.DataType = Type.GetType("System.DateTime");            
            DCFechaHoraVencimiento.DefaultValue = DateTime.Now.AddMonths(3);
            DCFechaHoraVencimiento.ColumnName = "FechaHoraVencimiento";

            DTVentasProductosReemplazosDetalleTemporal = new DataTable();
            DTVentasProductosReemplazosDetalleTemporal.Columns.AddRange(new DataColumn[] { DCCodigoProducto2, DCNombreProducto2, DCCantidadDevuelta, DCPrecioUnitarioReemplazo, DCTiempoGarantia, DCFechaHoraVencimiento });

            DTVentasProductosReemplazosDetalleTemporal.PrimaryKey = null;
            DataColumn[] PrimaryKeyColumns2 = new DataColumn[1];
            PrimaryKeyColumns2[0] = DTVentasProductosReemplazosDetalleTemporal.Columns["CodigoProducto"];
            DTVentasProductosReemplazosDetalleTemporal.PrimaryKey = PrimaryKeyColumns2;


            // Detalle Reemplazo y Devoluciones

            DataColumn DCCodigoProductoDevo = new DataColumn();
            DCCodigoProductoDevo.DataType = Type.GetType("System.String");
            DCCodigoProductoDevo.ColumnName = "CodigoProductoDevolucion";
            DCCodigoProductoDevo.ReadOnly = true;
            DCCodigoProductoDevo.DefaultValue = " ";

            DataColumn DCNombreProductoDevo = new DataColumn();
            DCNombreProductoDevo.DataType = Type.GetType("System.String");
            DCNombreProductoDevo.ColumnName = "NombreProductoDevolucion";
            DCNombreProductoDevo.ReadOnly = true;
            DCNombreProductoDevo.DefaultValue = " ";

            DataColumn DCPrecioTotalDevo = new DataColumn();
            DCPrecioTotalDevo.DataType = Type.GetType("System.Decimal");
            DCPrecioTotalDevo.ColumnName = "MontoTotalDevolucion";
            DCPrecioTotalDevo.ReadOnly = true;
            DCPrecioTotalDevo.AllowDBNull = true;
            
            
            DataColumn DCCodigoProductoReem = new DataColumn();
            DCCodigoProductoReem.DataType = Type.GetType("System.String");
            DCCodigoProductoReem.ColumnName = "CodigoProductoReemplazo";
            DCCodigoProductoReem.ReadOnly = true;
            DCCodigoProductoReem.DefaultValue = " ";

            DataColumn DCNombreProductoReem = new DataColumn();
            DCNombreProductoReem.DataType = Type.GetType("System.String");
            DCNombreProductoReem.ColumnName = "NombreProductoReemplazo";
            DCNombreProductoReem.ReadOnly = true;
            DCNombreProductoReem.DefaultValue = " ";

            DataColumn DCPrecioTotalReem = new DataColumn();
            DCPrecioTotalReem.DataType = Type.GetType("System.Decimal");
            DCPrecioTotalReem.ColumnName = "MontoTotalReemplazo";
            DCPrecioTotalReem.ReadOnly = true;
            DCPrecioTotalReem.AllowDBNull = true;

            DTVentasProductosDevolucionesReemplazosDetalleTemporal = new DataTable();
            DTVentasProductosDevolucionesReemplazosDetalleTemporal.Columns.AddRange(new DataColumn[] { DCCodigoProductoDevo, DCNombreProductoDevo, DCPrecioTotalDevo, DCCodigoProductoReem, DCNombreProductoReem, DCPrecioTotalReem });
            DTVentasProductosDevolucionesReemplazosDetalleTemporal.Columns.Add("PrecioTotal", typeof(decimal));
            DTVentasProductosDevolucionesReemplazosDetalleCompleto = DTVentasProductosDevolucionesReemplazosDetalleTemporal.Clone();
        }


        public void cargarDatosDevolucion(int numDevolucion)
        {
            DTVentasProductosDevoluciones = _VentasProductosDevolucionesCLN.ObtenerVentaProductoDevolucion(NumeroAgencia, NumeroDevolucion);
            DTVentasProductosDevolucionesDetalle = _VentasProductosDevolucionesDetalleCLN.ListarVentasProductosDevolucionesParaDevolucion(NumeroAgencia, NumeroDevolucion);
            DTVentasProductosDevolucionesEspecificos = _VentasProductosDevolucionesEspecificosCLN.ListarVentasProductosDevolucionesEspecificosParaDevolucionesEspecificos(NumeroAgencia, NumeroDevolucion);

            dtGVDevolucionesProductosDetalle.DataSource = DTVentasProductosDevolucionesDetalle;


            if (DTVentasProductosDevoluciones.Rows.Count > 0)
            {
                DTVentasProductosDevolucionesDetalle.Columns.Add("PrecioTotal", typeof(decimal), "CantidadDevuelta*PrecioUnitarioDevolucion");

                lblCodigoUsuario.Text = DTVentasProductosDevoluciones.Rows[0]["CodigoUsuario"].ToString();
                string EstadoDevolucion = DTVentasProductosDevoluciones.Rows[0]["CodigoEstadoDevolucion"].ToString();
                lblFechaDevolucion.Text = DTVentasProductosDevoluciones.Rows[0]["FechaHoraSolicitudReemDevo"].ToString();
                lblNumeroDevolucion.Text = DTVentasProductosDevoluciones.Rows[0]["NumeroDevolucion"].ToString();
                lblNumeroVenta.Text = DTVentasProductosDevoluciones.Rows[0]["NumeroVentaProducto"].ToString();
                txtBoxObservaciones.Text = DTVentasProductosDevoluciones.Rows[0]["ObservacionesSolicitudReemDevo"].ToString();
                NumeroTransaccion = Int32.Parse(DTVentasProductosDevoluciones.Rows[0]["NumeroVentaProducto"].ToString());

                cMenuObservaciones.Enabled = true;
                lblDatosUsuario.Text = obtenerNombreCompletoUsuario(int.Parse(lblCodigoUsuario.Text));
                switch (EstadoDevolucion[0])
                {
                    case 'A':
                        lblEstadoDevolucion.Text = "ANULADA";
                        progressBarDevolucion.Value = 100;
                        habilitarBotonesDevolucion(true, false, false, false, false, true, "D");
                        break;
                    case 'I':
                        lblEstadoDevolucion.Text = "INICIADA";
                        progressBarDevolucion.Value = 50;
                        habilitarBotonesDevolucion(true, false, false, true, true, true, "D");
                        break;
                    case 'F':
                        lblEstadoDevolucion.Text = "FINALIZADA";
                        progressBarDevolucion.Value = 100;
                        habilitarBotonesDevolucion(true, false, false, false, false, true, "D");
                        break;
                    case 'C':
                        lblEstadoDevolucion.Text = "CANCELADA";
                        progressBarDevolucion.Value = 0;
                        habilitarBotonesDevolucion(true, false, false, false, false, true, "D");
                        break;
                    default:
                        lblEstadoDevolucion.Text = "NINGUNA";
                        progressBarDevolucion.Value = 0;
                        habilitarBotonesDevolucion(true, false, false, false, false, false, "D");
                        break;
                }

                if (!DSDevoluciones.Tables.Contains(DTVentasProductosDevolucionesEspecificos.TableName))
                    DSDevoluciones.Tables.Add(DTVentasProductosDevolucionesEspecificos);
                dtGVDevolucionesProductosEspecificos.BindData(DSDevoluciones, DTVentasProductosDevolucionesEspecificos.TableName);
                if (DTVentasProductosDevolucionesEspecificos.Rows.Count > 0)
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


                object PrecioProductoTemporal = DTVentasProductosDevolucionesDetalle.Compute("sum(PrecioTotal)", "");
                object PrecioEspecificos = DTVentasProductosDevolucionesEspecificos.Compute("sum(PrecioUnitarioDevolucionPE)", "");

                txtBoxMontoTotalDevolucion.Text = PrecioProductoTemporal.ToString();
                txtBoxTotalParcialEspecifico.Text = String.IsNullOrEmpty(PrecioEspecificos.ToString()) ? "0.00" : PrecioEspecificos.ToString();
                txtBoxTotalParcial.Text = PrecioProductoTemporal.ToString();

                NumeroReemplazo = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("VentasProductosReemplazo");                
                cargarDatosReemplazo(NumeroReemplazo, numDevolucion);
            }
            else
            {
                lblCodigoUsuario.Text = string.Empty;                
                lblFechaDevolucion.Text = string.Empty;
                lblNumeroDevolucion.Text = string.Empty;
                lblNumeroVenta.Text = string.Empty;
                txtBoxObservaciones.Text = string.Empty;
                lblDatosUsuario.Text = string.Empty;
                lblEstadoDevolucion.Text = string.Empty;
                progressBarDevolucion.Value = 0;
                cMenuObservaciones.Enabled = false;
            }
            
        }

        public void cargarDatosReemplazo(int numReemplazo, int numDevolucion)
        {
            dtVGReemplazoProductosEspecificos.Visible = false;
            dtVGReemplazoProductosEspecificos.Dock = DockStyle.None;

            dtVGReemplazoProductosEspecificosAgrupados.Visible = true;
            dtVGReemplazoProductosEspecificosAgrupados.Dock = DockStyle.Fill;

            DTVentasProductosReemplazos = _VentasProductosReemplazoCLN.ObtenerVentaProductoReemplazo(NumeroAgencia, numReemplazo, numDevolucion);
            if (DTVentasProductosReemplazos.Rows.Count > 0)
            {
                lblCodigoUsuarioReem.Text = DTVentasProductosReemplazos.Rows[0]["CodigoUsuario"].ToString();
                lblFechaReemplazo.Text = DTVentasProductosReemplazos.Rows[0]["FechaHoraSolicitudReemplazo"].ToString();
                txtBoxObservacionesReem.Text = DTVentasProductosReemplazos.Rows[0]["ObservacionesReemplazo"].ToString();
                lblDatosUsuarioReem.Text = obtenerNombreCompletoUsuario(int.Parse(DTVentasProductosReemplazos.Rows[0]["CodigoUsuario"].ToString()));

                switch (DTVentasProductosReemplazos.Rows[0]["CodigoEstadoReemplazo"].ToString()[0])
                {
                    case 'A':
                        lblEstadoReemplazo.Text = "ANULADA";
                        habilitarBotonesDevolucion(true, false, false, false, false, true, "R");
                        progressBarReem.Value = 100;
                        break;
                    case 'I':
                        lblEstadoReemplazo.Text = "INICIADA";
                        progressBarReem.Value = 50;
                        habilitarBotonesDevolucion(true, false, false, true, true, true, "R");
                        break;
                    case 'F':
                        lblEstadoReemplazo.Text = "FINALIZADA";
                        progressBarReem.Value = 100;
                        habilitarBotonesDevolucion(true, false, false, false, false, true, "R");
                        break;
                    case 'C':
                        lblEstadoReemplazo.Text = "CANCELADA";
                        progressBarReem.Value = 0;
                        habilitarBotonesDevolucion(true, false, false, false, false, true, "R");
                        break;
                    default:
                        lblEstadoReemplazo.Text = "NINGUNA";
                        progressBarReem.Value = 0;
                        habilitarBotonesDevolucion(true, false, false, false, false, true, "R");
                        break;
                }                

                DTVentasProductosReemplazosDetalle = _VentasProductosReemplazoDetalleCLN.ListarVentasProductosReemplazoDetalleParaReemplazo(NumeroAgencia, numReemplazo);                                
                dtGVReemplazoProductosDetalle.DataSource = DTVentasProductosReemplazosDetalle;

                //DTVentasProductosDevolucionesDetalle.Columns.Add("PrecioTotal", typeof(decimal), "CantidadDevuelta*PrecioUnitarioDevolucion");
                DTVentasProductosReemplazosDetalle.Columns.Add("PrecioTotal", typeof(decimal), "CantidadDevuelta*PrecioUnitarioReemplazo");

                DTVentasProductosReemplazosEspecificos = _VentasProductosReemplazoEspecificosCLN.ListarVentasProductosReemplazoEspecificosParaReemplazo(NumeroAgencia, numReemplazo);


                if (!DSReemplazos.Tables.Contains(DTVentasProductosReemplazosEspecificos.TableName))
                    DSReemplazos.Tables.Add(DTVentasProductosReemplazosEspecificos);
                dtVGReemplazoProductosEspecificosAgrupados.BindData(DSReemplazos, DTVentasProductosReemplazosEspecificos.TableName);
                if (DTVentasProductosReemplazosEspecificos.Rows.Count > 0)
                {
                    dtVGReemplazoProductosEspecificosAgrupados.GroupTemplate.Column = dtVGReemplazoProductosEspecificosAgrupados.Columns[2];
                    ListSortDirection direction = ListSortDirection.Ascending;
                    dtVGReemplazoProductosEspecificosAgrupados.Sort(new DataRowComparer(0, direction));

                    dtVGReemplazoProductosEspecificosAgrupados.Columns[0].Width = 75;
                    dtVGReemplazoProductosEspecificosAgrupados.Columns[1].Width = 150;
                    dtVGReemplazoProductosEspecificosAgrupados.Columns[2].Width = 300;
                    dtVGReemplazoProductosEspecificosAgrupados.Columns[3].Width = 135;
                    dtVGReemplazoProductosEspecificosAgrupados.Columns[4].Width = 95;
                    dtVGReemplazoProductosEspecificosAgrupados.Columns[5].Width = 100;

                    dtVGReemplazoProductosEspecificosAgrupados.Columns[0].HeaderText = "Código";
                    dtVGReemplazoProductosEspecificosAgrupados.Columns[1].HeaderText = "Cód. Específico";
                    dtVGReemplazoProductosEspecificosAgrupados.Columns[2].HeaderText = "Nombre Producto";
                    dtVGReemplazoProductosEspecificosAgrupados.Columns[3].HeaderText = "Precio Unit. PE";
                    dtVGReemplazoProductosEspecificosAgrupados.Columns[4].HeaderText = "T. Garantía";
                    dtVGReemplazoProductosEspecificosAgrupados.Columns[5].HeaderText = "Fecha Venc.";
                }


                object PrecioProductoTemporal = DTVentasProductosReemplazosDetalle.Compute("sum(PrecioTotal)", "");
                object PrecioEspecificos = DTVentasProductosReemplazosEspecificos.Compute("sum(PrecioUnitarioReemplazoPE)", "");


                txtBoxPrecioParcialReem.Text = String.IsNullOrEmpty(PrecioProductoTemporal.ToString()) ? "0.00 " + MascaraMoneda : PrecioProductoTemporal.ToString() + " " + MascaraMoneda;
                txtBoxPrecioEspecificosReem.Text = String.IsNullOrEmpty(PrecioEspecificos.ToString()) ? "0.00 " + MascaraMoneda : PrecioEspecificos.ToString() + " " + MascaraMoneda;
                txtBoxPrecioTotalReem.Text = String.IsNullOrEmpty(PrecioProductoTemporal.ToString()) ? "0.00 " + MascaraMoneda : PrecioProductoTemporal.ToString() + " " + MascaraMoneda;


                if (lblEstadoDevolucion.Text.CompareTo("FINALIZADA") == 0)
                {
                    //tPageReemplazo.set
                    //tControlGeneral.TabPages[1].IsAccessible = true;
                    tControlGeneral.Controls[1].Enabled = true;
                }
                else
                {
                    tControlGeneral.Controls[1].Enabled = false;
                    tControlGeneral.Controls[2].Enabled = false;
                    //tControlGeneral.TabPages[1].IsAccessible = false;
                    //tControlGeneral.TabPages[2].IsAccessible = false;
                }
                NumeroReemDevo = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("VentasProductosReemplazoDevoluciones");
                cargarDatosReemDevo(NumeroReemDevo, NumeroReemplazo);
            }

            else
            {
                lblCodigoUsuarioReem.Text = string.Empty;
                lblFechaReemplazo.Text = string.Empty;                                
                txtBoxObservacionesReem.Text = string.Empty;
                lblDatosUsuarioReem.Text = string.Empty;
                lblEstadoReemplazo.Text = string.Empty;
                progressBarReem.Value = 0;
                lblDatosUsuarioReem.Text = string.Empty;
            }

        }

        public void cargarDatosReemDevo(int numReemDevo, int numReemplazo)
        {
            DTVentasProductosDevolucionesReemplazos = _VentasProductosReemplazoDevolucionesCLN.ObtenerVentaProductoReemplazoDevolucion(NumeroAgencia, numReemDevo, numReemplazo);
            if (DTVentasProductosDevolucionesReemplazos.Rows.Count > 0)
            {
                lblCodigoUsuarioReemDevo.Text = DTVentasProductosDevolucionesReemplazos.Rows[0]["CodigoUsuario"].ToString();
                lblFechaReemDevo.Text = DTVentasProductosDevolucionesReemplazos.Rows[0]["FechaHoraSolicitudReemDevo"].ToString();
                txtBoxObservacionesReemDevo.Text = DTVentasProductosDevolucionesReemplazos.Rows[0]["ObservacionesReemDevo"].ToString();
                lblDatosUsuarioReemDevo.Text = obtenerNombreCompletoUsuario(Int32.Parse(DTVentasProductosDevolucionesReemplazos.Rows[0]["CodigoUsuario"].ToString()));

                string codigoEstado = DTVentasProductosDevolucionesReemplazos.Rows[0]["CodigoEstadoReemplazoDevo"].ToString();

                switch (codigoEstado[0])
                {
                    case 'A':
                        lblCodigoEstadoReemDevo.Text = "ANULADA";
                        progressBarReemDevo.Value = 100;
                        habilitarBotonesDevolucion(true, false, false, false, false, true, "RD");
                        break;
                    case 'I':
                        lblCodigoEstadoReemDevo.Text = "INICIADA";
                        progressBarReemDevo.Value = 50;
                        habilitarBotonesDevolucion(true, false, false, true, true, true, "RD");
                        break;
                    case 'F':
                        lblCodigoEstadoReemDevo.Text = "FINALIZADA";
                        progressBarReemDevo.Value = 100;
                        habilitarBotonesDevolucion(true, false, false, false, false, true, "RD");
                        break;
                    case 'C':
                        lblCodigoEstadoReemDevo.Text = "CANCELADA";
                        progressBarReemDevo.Value = 0;
                        habilitarBotonesDevolucion(true, false, false, false, false, true, "RD");
                        break;
                    default:
                        lblCodigoEstadoReemDevo.Text = "NINGUNA";
                        progressBarReemDevo.Value = 0;
                        habilitarBotonesDevolucion(true, false, false, false, false, true, "RD");
                        break;
                }    
                

                DTVentasProductosDevolucionesReemplazosDetalle = _VentasProductosReemplazoDevolucionesDetalleCLN.ListarVentasProductosReemplazoDevolucionesDetalleParaReemplazoDevoluciones(NumeroAgencia, numReemDevo);
                dtGVProductosReemDevo.DataSource = DTVentasProductosDevolucionesReemplazosDetalle;
            }
            else
            {
                lblCodigoUsuarioReemDevo.Text = string.Empty;
                lblFechaReemDevo.Text = string.Empty;
                txtBoxObservacionesReemDevo.Text = string.Empty;
                lblDatosUsuarioReemDevo.Text = string.Empty;
                lblCodigoEstadoReemDevo.Text = string.Empty;
                progressBarReemDevo.Value = 0;
                lblDatosUsuarioReemDevo.Text = string.Empty;
            }
        }

        private void FVentasProductosReemDevo_Load(object sender, EventArgs e)
        {
            dtVGReemplazoProductosEspecificos.Visible = true;
            dtVGReemplazoProductosEspecificos.Dock = DockStyle.Fill;

            dtVGReemplazoProductosEspecificosAgrupados.Visible = false;
            dtVGReemplazoProductosEspecificosAgrupados.Dock = DockStyle.None;

            habilitarBotonesDevolucion(true, false, false, false, false, true, "D");
            habilitarBotonesDevolucion(true, false, false, false, false, true, "R");
            habilitarBotonesDevolucion(true, false, false, false, false, true, "RD");
            NumeroDevolucion = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("VentasProductosDevoluciones");
            cargarDatosDevolucion(NumeroDevolucion);            
            habilitarSubBotonesReemDevo(false, false, false, false);
            checkedLBoxProductosDevueltos.Enabled = false;
            checkedLBoxProductosReemplazo.Enabled = false;            
            
            habilitarOpcionesReemDevo(false);

            tStripOperacionesReemplazos.Visible = true;
            toolStrip4.Visible = true;
            toolStrip2.Visible = true;
        }

        private void btnNuevaDevolucion_Click(object sender, EventArgs e)
        {
            habilitarBotonesDevolucion(false, true, true, false, false, false,"D");
            NumeroDevolucion = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("VentasProductosDevoluciones");
            lblNumeroDevolucion.Text = NumeroDevolucion.ToString();            
            lblEstadoDevolucion.Text = "INICIADA";
            lblFechaDevolucion.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            progressBarDevolucion.Value = 50;
            lblNumeroVenta.Text = "Ninguna";

            FBuscarTransaccion formBuscarTransaccion = new FBuscarTransaccion(NumeroAgencia);
            formBuscarTransaccion.formatearEstiloParaVentas();
            formBuscarTransaccion.ShowDialog(this);
            NumeroTransaccion = formBuscarTransaccion.NumeroTransaccion;

            lblNumeroVenta.Text = NumeroTransaccion.ToString();

            FBusquedaProductosVendidos fBusquedaProductosVendidos = new FBusquedaProductosVendidos(NumeroAgencia, NumeroTransaccion,"V");
            fBusquedaProductosVendidos.ShowDialog(this);

            if (fBusquedaProductosVendidos.OperacionConfirmada)
            {
                DTVentasProductosDevolucionesDetalleTemporal = fBusquedaProductosVendidos.convertirCodigoMotivo_a_Descricpion();
                dtGVDevolucionesProductosDetalle.DataSource = DTVentasProductosDevolucionesDetalleTemporal;

                DTVentasProductosDevolucionesEspecificosTemporal = fBusquedaProductosVendidos.DTProductosDetalleEspecificosSeleccionados;
                if (!DSDevoluciones.Tables.Contains(DTVentasProductosDevolucionesEspecificosTemporal.TableName))
                    DSDevoluciones.Tables.Add(DTVentasProductosDevolucionesEspecificosTemporal);
                dtGVDevolucionesProductosEspecificos.BindData(DSDevoluciones, DTVentasProductosDevolucionesEspecificosTemporal.TableName);
                if (DTVentasProductosDevolucionesEspecificosTemporal.Rows.Count > 0)
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


                object PrecioProductoTemporal = DTVentasProductosDevolucionesDetalleTemporal.Compute("sum(PrecioTotal)", "");
                object PrecioEspecificos = DTVentasProductosDevolucionesEspecificosTemporal.Compute("sum(PrecioUnitarioDevolucionPE)", "");

                txtBoxMontoTotalDevolucion.Text = PrecioProductoTemporal.ToString();
                txtBoxTotalParcialEspecifico.Text = String.IsNullOrEmpty(PrecioEspecificos.ToString()) ? "0.00" : PrecioEspecificos.ToString();
                txtBoxTotalParcial.Text = PrecioProductoTemporal.ToString();

                lblDatosUsuario.Text = obtenerNombreCompletoUsuario(CodigoUsuario);
            }
            
        }


        public void formatearEstiloGrilla( OutlookStyleControls.OutlookGrid Grilla)
        {
            Grilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                       

            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            Grilla.DefaultCellStyle = dataGridViewCellStyle2;
            Grilla.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;

            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            Grilla.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;

            Grilla.GridColor = System.Drawing.SystemColors.Control;
            Grilla.RowTemplate.Height = 19;
            Grilla.BackgroundColor = System.Drawing.SystemColors.Window;
            Grilla.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            Grilla.RowHeadersVisible = false;
            Grilla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            Grilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Grilla.AllowUserToAddRows = false;
            Grilla.AllowUserToDeleteRows = false;
            Grilla.AllowUserToResizeRows = true;
            //this.dtGVDevolucionesProductosEspecificos.EditMode = DataGridViewEditMode.EditProgrammatically;
            Grilla.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            Grilla.ClearGroups();  
        }

        private void btnAceptarDevolucion_Click(object sender, EventArgs e)
        {
            DateTime FechaHoraSolicitudReemDevo = _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor();
            try
            {
                _VentasProductosDevolucionesCLN.InsertarVentaProductoDevolucion(NumeroAgencia, NumeroTransaccion , "I", CodigoUsuario, FechaHoraSolicitudReemDevo, txtBoxObservaciones.Text, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,"No se Pudo insertar la Devolución actual " +Environment.NewLine + ex.Message);
                return;
            }
            NumeroDevolucion = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("VentasProductosDevoluciones");


            int CodigoMotivoReemDevo = 0;
            string CodigoProducto = "";
            int CantidadDevuelta = 0;
            decimal PrecioUnitarioDevolucion = 0;
            string CodigoProductoEspecifico = "";
            decimal PrecioUnitarioDevolucionPE = 0;
            foreach(DataRow fila in DTVentasProductosDevolucionesDetalleTemporal.Rows)
            {
                CodigoMotivoReemDevo = Int32.Parse(fila["CodigoMotivoReemDevo"].ToString());
                CodigoProducto = fila["CodigoProducto"].ToString();
                CantidadDevuelta = Int32.Parse(fila["CantidadDevuelta"].ToString());
                PrecioUnitarioDevolucion = Decimal.Parse(fila["PrecioUnitarioDevolucion"].ToString());

                try
                {
                    _VentasProductosDevolucionesDetalleCLN.InsertarVentaProductoDevolucionDetalle(NumeroAgencia, NumeroDevolucion, CodigoMotivoReemDevo, CodigoProducto, CantidadDevuelta, PrecioUnitarioDevolucion);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Ocurrio un erro al momento de insertar el Detalle de Devolución debido a " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;                    
                }

            }

            foreach (DataRow fila in DTVentasProductosDevolucionesEspecificosTemporal.Rows)
            {
                CodigoProducto = fila["CodigoProducto"].ToString();
                CodigoProductoEspecifico = fila["CodigoProductoEspecifico"].ToString();
                PrecioUnitarioDevolucionPE = Decimal.Parse(fila["PrecioUnitarioDevolucionPE"].ToString());

                try
                {
                    _VentasProductosDevolucionesEspecificosCLN.InsertarVentaProductoDevolucionEspecifico(NumeroAgencia, NumeroDevolucion, CodigoProducto, CodigoProductoEspecifico, PrecioUnitarioDevolucionPE);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Ocurrio un erro al momento de insertar el Detalle de Devolución debido a " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;                                        
                }
            }
            lblFechaDevolucion.Text = FechaHoraSolicitudReemDevo.ToShortDateString() +" " + FechaHoraSolicitudReemDevo.ToShortTimeString();
            habilitarBotonesDevolucion(true, false, false, true, true, true, "D");
            NumeroDevolucion = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("VentasProductosDevoluciones");
            cargarDatosDevolucion(NumeroDevolucion);
            if (MessageBox.Show(this, "Se INICIO correctamente la Devolución." + Environment.NewLine + " ¿Desea Finalizar la Devolución? ", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //finalizar transacción
                btnFinalizarDevolucion_Click(sender, e);
            }

            
        }

        public void habilitarSubBotonesReemDevo(bool nuevo, bool cancelar, bool aceptar, bool eliminar)
        {
            btnNuevo.Enabled = nuevo;
            btnCancelar.Enabled = cancelar;
            btnAceptar.Enabled = aceptar;
            btnEliminar.Enabled = eliminar;
        }

        public void habilitarBotonesDevolucion(bool nuevo, bool cancelar, bool aceptar, bool finalizar, bool anular, bool reporte, string TipoTransaccionLocal)
        {
            if (TipoTransaccionLocal.CompareTo("D") == 0)
            {
                btnNuevaDevolucion.Enabled = nuevo;
                btnCancelarDevolucion.Enabled = cancelar;
                btnAceptarDevolucion.Enabled = aceptar;
                btnFinalizarDevolucion.Enabled = finalizar;
                btnAnularDevolucion.Enabled = anular;
                btnReporteDevolucion.Enabled = reporte;
            }
            if (TipoTransaccionLocal.CompareTo("R") == 0)
            {
                btnNuevoReemplazo.Enabled = nuevo;
                btnCancelarReemplazo.Enabled = cancelar;
                btnAceptarReemplazo.Enabled = aceptar;
                btnFinalizarReemplazo.Enabled = finalizar;
                btnAnularReemplazo.Enabled = anular;
                btnReporteReemplazo.Enabled = reporte;
            }
            if (TipoTransaccionLocal.CompareTo("RD") == 0)
            {
                btnNuevoReemDevo.Enabled = nuevo;
                btnCancelarReemDevo.Enabled = cancelar;
                btnAceptarReemDevo.Enabled = aceptar;
                btnFinalizarReemDevo.Enabled = finalizar;
                btnAnularReemDevo.Enabled = anular;
                btnReporteReemDevo.Enabled = reporte;
            }
        }

        private void btnCancelarDevolucion_Click(object sender, EventArgs e)
        {
            NumeroDevolucion = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("VentasProductosDevoluciones");
            cargarDatosDevolucion(NumeroDevolucion);
            habilitarBotonesDevolucion(true, false, false, false, false, true, "D");
        }

        private void btnFinalizarDevolucion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Una vez Finalizada la Devolución, se debe hacer la entrega de los Productos seleccionados a ser devueltos, sin vuelta atrás" + Environment.NewLine +"¿ Desea Finalizar la Devolución ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _TransaccionesUtilidadesCLN.ActualizarInventarioProductosDevoluciones(NumeroAgencia, NumeroDevolucion, "V");
                    _TransaccionesUtilidadesCLN.InsertarAsientosTransacciones(CodigoUsuario,
                                    "Asiento Contable Correspondiente a Numero de Devolucion de Envio " + NumeroDevolucion.ToString(),
                                    "C", NumeroDevolucion, "D", NumeroAgencia);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "No se Pudo Finalizar la Transaccion debido a que no se pudo Actualizar inventarios y :" + ex.Message, "Erro en Devolución", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                try
                {
                    _VentasProductosDevolucionesCLN.FinalizarAnularVentaProductoDevolucion(NumeroAgencia, NumeroDevolucion, "F", _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "No se Pudo Finalizar la Transaccion debido a :" + ex.Message, "Erro en Devolución", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                lblEstadoDevolucion.Text = "FINALIZADA";
                progressBarDevolucion.Value = progressBarDevolucion.Maximum;

                habilitarBotonesDevolucion(true, false, false, false, false, true, "D");
            }
        }

        private void btnAnularDevolucion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿ Está seguro de Anular la Devolución ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {                
                try
                {
                    _VentasProductosDevolucionesCLN.FinalizarAnularVentaProductoDevolucion(NumeroAgencia, NumeroDevolucion, "A", _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "No se Pudo Anular la Transaccion debido a :" + ex.Message, "Erro en Devolución", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                lblEstadoDevolucion.Text = "ANULADA";
                progressBarDevolucion.Value = progressBarDevolucion.Maximum;

                habilitarBotonesDevolucion(true, false, false, false, false, true, "D");
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
            formBuscarTransaccion.formatearEstiloParaVentasDevoluciones();
            formBuscarTransaccion.ShowDialog(this);
            NumeroDevolucion = formBuscarTransaccion.NumeroTransaccion;            
            if (NumeroDevolucion > 0)
            {
                DSDevoluciones.Tables.Clear();
                DSReemplazos.Tables.Clear();
                cargarDatosDevolucion(NumeroDevolucion);
            }
            else
            {
                MessageBox.Show("No se encontro ningun registro con la descripción dada");
            }
            
            formBuscarTransaccion.Dispose();
        }

        private void btnNuevoReemplazo_Click(object sender, EventArgs e)
        {
            dtVGReemplazoProductosEspecificos.Visible = true;
            dtVGReemplazoProductosEspecificos.Dock = DockStyle.Fill;

            dtVGReemplazoProductosEspecificosAgrupados.Visible = false;
            dtVGReemplazoProductosEspecificosAgrupados.Dock = DockStyle.None;

            DTVentasProductosReemplazosDetalleTemporal.Clear();
            DTVentasProductosReemplazosEspecificosTemporal.Clear();
            tControlGeneral.SelectedTab = tPageDevoluciones;
            //REVISAR AUMENTAR EL CODIGO DE MONEDA ACTUAL
            FProductosBusqueda fproductosBusqueda = new FProductosBusqueda(NumeroAgencia, NumeroPC, 'V', 1);
            //REVISAR
            fproductosBusqueda.DTGridViewProductosSeleccionados.Columns[fproductosBusqueda.DTGridViewProductosSeleccionados.Columns.Count - 1].Visible = false;
            DataTable Temporal = fproductosBusqueda.DTProductosSeleccionados;
            fproductosBusqueda.ShowDialog(this);

            if (fproductosBusqueda.DTProductosSeleccionados.Rows.Count == 0)
            {
                btnCancelarReemplazo_Click(sender, e);
                return;
            }
            if (fproductosBusqueda.seleccionarProductosEspecificos)
            {
                //tControlGeneral.SelectedIndex = 1;
                usuarioSeleccionaEspecifico = true;
            }
            if (fproductosBusqueda.detalleConfirmado)
            {
                this.txtBoxPrecioParcialReem.Text = fproductosBusqueda.LabelPrecioTotal.Text + " " + MascaraMoneda;
                this.tControlGeneral.SelectedIndex = 2;
            }

            foreach (DataRow filaProducto in Temporal.Rows)
            {
                DataRow FilaNueva = DTVentasProductosReemplazosDetalleTemporal.NewRow();

                FilaNueva["CodigoProducto"] = filaProducto["Código Producto"];
                FilaNueva["NombreProducto"] = filaProducto["Nombre Producto"];
                FilaNueva["CantidadDevuelta"] = filaProducto["Cantidad"];
                FilaNueva["PrecioUnitarioReemplazo"] = filaProducto["Precio"];
                FilaNueva["TiempoGarantia"] = filaProducto["Garantia"];
                FilaNueva["FechaHoraVencimiento"] = DateTime.Now.AddMonths(3);


                DTVentasProductosReemplazosDetalleTemporal.Rows.Add(FilaNueva);
                FilaNueva.AcceptChanges();
            }
            if (!DTVentasProductosReemplazosDetalleTemporal.Columns.Contains("PrecioTotal"))
                DTVentasProductosReemplazosDetalleTemporal.Columns.Add("PrecioTotal", typeof(decimal), "CantidadDevuelta*PrecioUnitarioReemplazo");
            
            if (verificarProductosEspecificos(Temporal))
            {
                generarDetalleVentaProductosEspecificos(Temporal);                
            }

            object TotalTemporalReemplazo = DTVentasProductosReemplazosDetalleTemporal.Compute("sum(PrecioTotal)", "");
            object TotalTemporalEspecficos = DTVentasProductosReemplazosEspecificosTemporal.Compute("sum(PrecioUnitarioReemplazoPE)", "");

            txtBoxPrecioParcialReem.Text = (String.IsNullOrEmpty(TotalTemporalReemplazo.ToString())) ? "0.00 "+ MascaraMoneda : TotalTemporalReemplazo.ToString()+" " + MascaraMoneda;
            txtBoxPrecioEspecificosReem.Text = (String.IsNullOrEmpty(TotalTemporalEspecficos.ToString())) ? "0.00 " + MascaraMoneda : TotalTemporalEspecficos.ToString() + " " + MascaraMoneda;
            txtBoxPrecioTotalReem.Text = (String.IsNullOrEmpty(TotalTemporalReemplazo.ToString())) ? "0.00 " + MascaraMoneda : TotalTemporalReemplazo.ToString() + " " + MascaraMoneda;

            
            dtGVReemplazoProductosDetalle.DataSource = DTVentasProductosReemplazosDetalleTemporal;
            dtVGReemplazoProductosEspecificos.DataSource = DTVentasProductosReemplazosEspecificosTemporal;


            if (DTVentasProductosReemplazosEspecificosTemporal.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in dtVGReemplazoProductosEspecificos.Rows)
                {
                    if (fila.Cells[0].Value != null && !fila.Cells["DGVNombreProductoReem"].Value.Equals(""))
                    {
                        fila.DefaultCellStyle.BackColor = Color.Bisque;
                        fila.Cells["DGVNombreProductoReem"].Style.Font = new Font(fuenteDefecto.Name, fuenteDefecto.Size, FontStyle.Bold);
                        fila.Cells["DGVCodigoProductoReem"].Style.Font = new Font(fuenteDefecto.Name, fuenteDefecto.Size, FontStyle.Bold);
                    }                
                }
            }

            tControlGeneral.SelectedTab = tPageReemplazo;

            habilitarBotonesDevolucion(false, true, true, false, false, false, "R");
        }


        public void generarDetalleVentaProductosEspecificos(DataTable _DTVentasProductosDetalleTemporal)
        {
            string[] listadoCodigosProductosEspecificosInventariados = null;
            DataTable _DTProductosEspecificosSeleccionadosPorUsuarioTemporal = null;
            InventariosProductosEspecificosCLN _InventarioProductoEspecificoCLN = new InventariosProductosEspecificosCLN();
            if (usuarioSeleccionaEspecifico)
            {
                FIngresarCodigoProductoEspecifico fingresarCodigosProductosespecficos = new FIngresarCodigoProductoEspecifico(NumeroAgencia);
                fingresarCodigosProductosespecficos.DTDatosTransaccion = _DTVentasProductosDetalleTemporal;
                fingresarCodigosProductosespecficos.formatearEstiloProductosEspecificos();
                fingresarCodigosProductosespecficos.ShowDialog(this);
                _DTProductosEspecificosSeleccionadosPorUsuarioTemporal = fingresarCodigosProductosespecficos.DTProductosEspecificosTemporal.Copy();
                if (!fingresarCodigosProductosespecficos.ProductosAceptados)
                {
                    usuarioSeleccionaEspecifico = false;
                }
            }
            if (CantidadProductosEspecificos > 0)
            {
               
                int indiceActual = 0;
                foreach (DataRow fila in _DTVentasProductosDetalleTemporal.Rows)
                {
                    if (fila["EsProductoEspecifico"].Equals(true) && fila["VendidoComoAgregado"].Equals(false))
                    {
                        string CodigoProducto;
                        string CodigoProductoEspecifico;
                        string NombreProducto;
                        int cantidad = 0; //Cantidad                    
                        int TiempoGarantiaPE = 0; //TiempoGarantiaPE                        
                        decimal PrecioUnitarioReemplazoPE = 0;

                        CodigoProducto = fila["Código Producto"].ToString();
                        NombreProducto = fila["Nombre Producto"].ToString();
                        TiempoGarantiaPE = Int16.Parse(fila["Garantia"].ToString());
                        cantidad = Int16.Parse(fila["Cantidad"].ToString());
                        PrecioUnitarioReemplazoPE = decimal.Parse(fila["Precio"].ToString());

                        if (!usuarioSeleccionaEspecifico)
                            listadoCodigosProductosEspecificosInventariados = _InventarioProductoEspecificoCLN.ListarCodigosProductosEspecificosExistentes(NumeroAgencia, CodigoProducto, cantidad).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < cantidad; i++)
                        {

                            //CodigoProductoEspecifico = _DTProductosEspecificosSeleccionados.Rows[indice]["CodigoProductoEspecifico"].ToString();
                            if (!usuarioSeleccionaEspecifico && i == listadoCodigosProductosEspecificosInventariados.Length)
                            {
                                if (MessageBox.Show(this, "No existe la cantidad de productos Especificos registrados en Inventario, Se Procedera a Realizar la venta con los existentes Actualmente" + Environment.NewLine + "Si desea vender la cantidad existente, proceda a Cancelar la Venta y registrar los Códigos de los Productos Especificos" + Environment.NewLine + "¿Desea Continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {                                    
                                    break;
                                }
                                else return;
                            }

                            DataRow nuevoProductoEspecifico = DTVentasProductosReemplazosEspecificosTemporal.NewRow();
                            if (usuarioSeleccionaEspecifico)
                            {
                                CodigoProductoEspecifico = _DTProductosEspecificosSeleccionadosPorUsuarioTemporal.Rows[indiceActual]["CodigoProductoEspecifico"].ToString().Trim();
                                TiempoGarantiaPE = Int32.Parse(_DTProductosEspecificosSeleccionadosPorUsuarioTemporal.Rows[indiceActual]["TiempoGarantiaPE"].ToString().Trim());
                            }
                            else
                            {
                                CodigoProductoEspecifico = listadoCodigosProductosEspecificosInventariados[i].Trim();
                            }                           
                            if (i == 0)
                            {
                                nuevoProductoEspecifico["NombreProducto"] = NombreProducto;
                                nuevoProductoEspecifico["CodigoProducto"] = CodigoProducto;
                            }
                            else
                            {
                                nuevoProductoEspecifico["NombreProducto"] = "";
                                nuevoProductoEspecifico["CodigoProducto"] = "";
                            }
                            nuevoProductoEspecifico["CodigoProductoEspecifico"] = CodigoProductoEspecifico;
                            nuevoProductoEspecifico["TiempoGarantiaPE"] = TiempoGarantiaPE;
                            nuevoProductoEspecifico["PrecioUnitarioReemplazoPE"] = PrecioUnitarioReemplazoPE;
                            nuevoProductoEspecifico["FechaHoraVencimientoPE"] = DateTime.Now.AddMonths(3);
                            
                            DTVentasProductosReemplazosEspecificosTemporal.Rows.Add(nuevoProductoEspecifico);
                            nuevoProductoEspecifico.AcceptChanges();
                            indiceActual++;
                        }
                    }
                }                                
            }
        }


        public void habilitarOpcionesReemDevo(bool habilitado)
        {
            treeViewProductos.Enabled = habilitado;
            txtBoxObservacionesReemDevo.Enabled = habilitado;            
        }

        public bool verificarProductosEspecificos(DataTable _DTProductosEspecificosTemporal)
        {

            object NumeroEspecficos = _DTProductosEspecificosTemporal.Compute("count(EsProductoEspecifico)", "EsProductoEspecifico = true");
            if (!NumeroEspecficos.Equals(0))
            {
                CantidadProductosEspecificos = Int32.Parse(NumeroEspecficos.ToString());
                return true;    
            }
            else
            {
                return false;
            }
            
        }
        private void resaltarFilaProductoSeleccionado(DataGridViewRow fila, bool resaltar)
        {
            if (resaltar)
            {
                fila.DefaultCellStyle.BackColor = ColorResaltado;
            }
            else
            {
                fila.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void btnAnularReemplazo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿ Está seguro de Anular El Reemplazo de Productos ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {                    
                    _VentasProductosReemplazoCLN.FinalizarAnularVentasProductoReemplazo(NumeroAgencia, NumeroReemplazo, "A", _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "No se logró Anular satisfactoriament la Transaccion debido a :" + ex.Message, "Erro en Devolución", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                lblEstadoReemplazo.Text = "ANULADA";
                progressBarReem.Value = progressBarReem.Maximum;

                habilitarBotonesDevolucion(true, false, false, false, false, true, "D");
            }
        }

        private void dgVGReemplazoProductosEspecificos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //if (DTVentasProductosReemplazosEspecificosTemporal.Rows.Count > 0)
            //{
            //    if (dgVGReemplazoProductosEspecificos.Rows[e.RowIndex].Cells[0].Value != null && !dgVGReemplazoProductosEspecificos.Rows[e.RowIndex].Cells["DGVNombreProductoReem"].Value.Equals(""))
            //    {
            //        MessageBox.Show("Pintando");
            //        dgVGReemplazoProductosEspecificos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Bisque;
            //        dgVGReemplazoProductosEspecificos.Rows[e.RowIndex].Cells["DGVNombreProductoReem"].Style.Font = new Font(fuenteDefecto.Name, fuenteDefecto.Size, FontStyle.Bold);
            //        dgVGReemplazoProductosEspecificos.Rows[e.RowIndex].Cells["DGVCodigoProductoReem"].Style.Font = new Font(fuenteDefecto.Name, fuenteDefecto.Size, FontStyle.Bold);
            //    }
            //}
        }

        private void btnAceptarReemplazo_Click(object sender, EventArgs e)
        {
            string CodigoProducto = "";
            int CantidadDevuelta = 0;
            decimal PrecioUnitarioReemplazo;
            int TiempoGarantia = 0;
            DateTime FechaHoraVencimiento;
            string CodigoProductoEspecifico;

            int NumeroDevolucion = (DTVentasProductosDevoluciones.Rows.Count > 0) ? Int32.Parse(DTVentasProductosDevoluciones.Rows[0]["NumeroDevolucion"].ToString()) : this.NumeroDevolucion;
            DateTime FechaHoraSolicitudReemplazo = _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor();
            string ObservacionesReemplazo = txtBoxObservacionesReem.Text;


            if (DTVentasProductosReemplazosDetalleTemporal.Rows.Count > 0)
            {
                try
                {
                    _VentasProductosReemplazoCLN.InsertarVentaProductoReemplazo(NumeroAgencia, NumeroDevolucion, "I", CodigoUsuario, FechaHoraSolicitudReemplazo, ObservacionesReemplazo);
                    NumeroReemplazo = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("VentasProductosReemplazo");

                    foreach (DataRow fila in DTVentasProductosReemplazosDetalleTemporal.Rows)
                    {
                        CodigoProducto = fila["CodigoProducto"].ToString();
                        CantidadDevuelta = int.Parse(fila["CantidadDevuelta"].ToString());
                        PrecioUnitarioReemplazo = decimal.Parse(fila["PrecioUnitarioReemplazo"].ToString());
                        TiempoGarantia = int.Parse(fila["TiempoGarantia"].ToString());
                        FechaHoraVencimiento = DateTime.Parse(fila["FechaHoraVencimiento"].ToString());                        

                        _VentasProductosReemplazoDetalleCLN.InsertarVentaProductoReemplazoDetalle(NumeroAgencia, NumeroReemplazo, CodigoProducto, CantidadDevuelta, PrecioUnitarioReemplazo, TiempoGarantia, FechaHoraSolicitudReemplazo);

                    }
                    string CodigoProductoTemporal = "";
                    foreach (DataRow filaEspecifico in DTVentasProductosReemplazosEspecificosTemporal.Rows)
                    {
                        CodigoProductoTemporal = filaEspecifico["CodigoProducto"].ToString();
                        CodigoProductoEspecifico = filaEspecifico["CodigoProductoEspecifico"].ToString();
                        PrecioUnitarioReemplazo = Decimal.Parse(filaEspecifico["PrecioUnitarioReemplazoPE"].ToString());
                        TiempoGarantia = Int32.Parse(filaEspecifico["TiempoGarantiaPE"].ToString());
                        FechaHoraVencimiento = DateTime.Parse(filaEspecifico["FechaHoraVencimientoPE"].ToString());

                        if (CodigoProductoTemporal != "")
                        {
                            CodigoProducto = CodigoProductoTemporal;
                        }

                        _VentasProductosReemplazoEspecificosCLN.InsertarVentaProductoReemplazoEspecifico(NumeroAgencia, NumeroReemplazo, CodigoProducto, CodigoProductoEspecifico, PrecioUnitarioReemplazo, TiempoGarantia, FechaHoraVencimiento);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "No se pudo concluir satisfactoriamente la transacción, debido a " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;                    
                }

                
            }
            habilitarBotonesDevolucion(true, false, false, true, true, true, "R");
            NumeroReemplazo = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("VentasProductosReemplazo");
            cargarDatosReemplazo(NumeroReemplazo, NumeroDevolucion);
            if (MessageBox.Show(this, "Se INICIO correctamente la Seleccion de Productos que serán de Reemplazo." + Environment.NewLine + " ¿Desea Finalizar el Reemplazo? ", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //finalizar transacción
                btnFinalizarReemplazo_Click(sender, e);
            }            
        }

        private void btnFinalizarReemplazo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Una vez Finalizada el Reemplazo de Productos por una Devolución, se debe Escoger y Seleccionar que Productos Seleccionado para Reemplazo, deben reemplazar a los productos Devueltos" + Environment.NewLine + "¿ Desea Finalizar la Devolución ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {                    
                    _TransaccionesUtilidadesCLN.ActualizarInventarioProductosReemplazo(NumeroAgencia, NumeroReemplazo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "No se Pudo Finalizar la Transaccion debido a que no se pudo Actualizar inventarios y :" + ex.Message, "Erro en Devolución", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                try
                {                    
                    _VentasProductosReemplazoCLN.FinalizarAnularVentasProductoReemplazo(NumeroAgencia, NumeroReemplazo, "F", _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "No se Pudo Finalizar la Transaccion debido a :" + ex.Message, "Erro en Reemplazo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                lblEstadoReemplazo.Text = "FINALIZADA";
                progressBarReem.Value = progressBarReem.Maximum;

                habilitarBotonesDevolucion(true, false, false, false, false, true, "R");
            }

        }

        private void btnCancelarReemplazo_Click(object sender, EventArgs e)
        {
            //NumeroReemplazo = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceVenta("VentasProductosReemplazo");
            txtBoxPrecioEspecificosReem.Text = "0.00";
            txtBoxPrecioParcialReem.Text = "0.00";
            txtBoxPrecioTotalReem.Text = "0.00";
            DTVentasProductosReemplazosDetalleTemporal.Clear();
            DTVentasProductosReemplazosEspecificosTemporal.Clear();
            cargarDatosDevolucion(NumeroDevolucion);
            habilitarBotonesDevolucion(true, false, false, false, false, true, "R");
        }

        private void btnNuevoReemDevo_Click(object sender, EventArgs e)
        {
            DTVentasproductosDevoDisponibles = _VentasProductosReemplazoDevolucionesCLN.ObtenerProductosDevolucionesDisponbiles(NumeroAgencia, NumeroDevolucion, NumeroReemplazo);
            DTVentasproductosReemDisponibles = _VentasProductosReemplazoDevolucionesCLN.ObtenerProductosReemplazosDisponbiles(NumeroAgencia, NumeroDevolucion, NumeroReemplazo);

            DTVentasproductosDevoDisponiblesBackup = DTVentasproductosDevoDisponibles.Copy();
            DTVentasproductosReemDisponiblesBackup = DTVentasproductosReemDisponibles.Copy();

            //checkedLBoxProductosDevueltos.DataSource = DTVentasproductosDevoDisponibles;
            //checkedLBoxProductosDevueltos.DisplayMember = "NombreProducto";
            //checkedLBoxProductosDevueltos.ValueMember = "CodigoProducto";

            foreach (DataRow filaDevueltos in DTVentasproductosDevoDisponibles.Rows)
            {
                checkedLBoxProductosDevueltos.Items.Add(filaDevueltos["NombreProducto"]);
            }
            foreach (DataRow filaReemplazos in DTVentasproductosReemDisponibles.Rows)
            {
                checkedLBoxProductosReemplazo.Items.Add(filaReemplazos["NombreProducto"]);
            }

            //checkedLBoxProductosReemplazo.DataSource = DTVentasproductosReemDisponibles;
            //checkedLBoxProductosReemplazo.DisplayMember = "NombreProducto";
            //checkedLBoxProductosReemplazo.ValueMember = "CodigoProducto";

            habilitarSubBotonesReemDevo(true, false, false, false);
            habilitarOpcionesReemDevo(true);

            rbtnUnoAUno.Enabled = true;
            rbtnUnoPorMuchos.Enabled = true;
            rbtnMuchosPorUno.Enabled = true;

            dtGVProductosReemDevo.DataSource = DTVentasProductosDevolucionesReemplazosDetalleTemporal;
            habilitarBotonesDevolucion(false, true, true, false, false, false, "RD");
        }

        private void txtBoxBuscarCodReemplazo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            rbtnUnoAUno.Enabled = false;
            rbtnUnoPorMuchos.Enabled = false;
            rbtnMuchosPorUno.Enabled = false;

            if (rbtnUnoAUno.Checked)
            {
                cardinalidad = "1x1";
            }

            if (rbtnUnoPorMuchos.Checked)
            {
                cardinalidad = "1xM";
            }

            if (rbtnMuchosPorUno.Checked)
            {
                cardinalidad = "Mx1";
            }

            habilitarSubBotonesReemDevo(false, true, true, false);

            checkedLBoxProductosDevueltos.Enabled = true;
            checkedLBoxProductosReemplazo.Enabled = true;
            
        }



        private void checkedLBoxProductosDevueltos_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cardinalidad == "1x1" || cardinalidad == "1xM")
            {
                if (checkedLBoxProductosDevueltos.CheckedItems.Count > 1)
                {
                    if (checkedLBoxProductosDevueltos.GetItemChecked(checkedLBoxProductosDevueltos.SelectedIndex))
                    {
                        checkedLBoxProductosDevueltos.SetItemChecked(checkedLBoxProductosDevueltos.SelectedIndex, false);
                        return;
                    }

                }
            }
        }


        private void checkedLBoxProductosReemplazo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cardinalidad == "1x1" || cardinalidad == "Mx1")
            {
                if (checkedLBoxProductosReemplazo.CheckedItems.Count > 1)
                {
                    if (checkedLBoxProductosReemplazo.SelectedIndex != -1 && checkedLBoxProductosReemplazo.GetItemChecked(checkedLBoxProductosReemplazo.SelectedIndex))
                        checkedLBoxProductosReemplazo.SetItemChecked(checkedLBoxProductosReemplazo.SelectedIndex, false);
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (checkedLBoxProductosDevueltos.CheckedItems.Count == 0 || checkedLBoxProductosReemplazo.CheckedItems.Count == 0)
            {
                MessageBox.Show(this, "Aún no ha seleccionado un producto a Devolver y su correspondiente reemplazo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string CodigoProductoDevolucion = "";
            string NombreProductoDevolucion = "";
            decimal MontoTotalDevolucion = 0;
            string CodigoProductoReemplazo = "";
            string NombreProductoReemplazo = "";
            decimal MontoTotalReemplazo = 0;
            int indice = 0, indiceAux = 0;
            switch( cardinalidad )
            {
                case "1x1" :
                    DataRow filaDevo = DTVentasproductosDevoDisponibles.Rows[checkedLBoxProductosDevueltos.CheckedIndices[0]];                    
                    CodigoProductoDevolucion = filaDevo["CodigoProducto"].ToString().Trim();
                    MontoTotalDevolucion = Decimal.Parse(filaDevo["PrecioTotal"].ToString());
                    NombreProductoDevolucion = filaDevo["NombreProducto"].ToString().Trim();
                    DTVentasproductosDevoDisponibles.Rows.Remove(filaDevo);
                    checkedLBoxProductosDevueltos.Items.RemoveAt(checkedLBoxProductosDevueltos.CheckedIndices[0]);


                    DataRow filaReem = DTVentasproductosReemDisponibles.Rows[checkedLBoxProductosReemplazo.CheckedIndices[0]];
                    CodigoProductoReemplazo = filaReem["CodigoProducto"].ToString().Trim();
                    MontoTotalReemplazo = Decimal.Parse(filaReem["PrecioTotal"].ToString());
                    NombreProductoReemplazo = filaReem["NombreProducto"].ToString().Trim();
                    DTVentasproductosReemDisponibles.Rows.Remove(filaReem);
                    checkedLBoxProductosReemplazo.Items.RemoveAt(checkedLBoxProductosReemplazo.CheckedIndices[0]);

                    DataRow FilaNueva = DTVentasProductosDevolucionesReemplazosDetalleCompleto.NewRow();
                    DataRow FilaNuevaTemp = DTVentasProductosDevolucionesReemplazosDetalleTemporal.NewRow();

                    FilaNueva["CodigoProductoDevolucion"] = CodigoProductoDevolucion;
                    FilaNueva["NombreProductoDevolucion"] = NombreProductoDevolucion;
                    FilaNueva["MontoTotalDevolucion"] = MontoTotalDevolucion;
                    FilaNueva["CodigoProductoReemplazo"] = CodigoProductoReemplazo;
                    FilaNueva["NombreProductoReemplazo"] = NombreProductoReemplazo;
                    FilaNueva["MontoTotalReemplazo"] = MontoTotalReemplazo;
                    DTVentasProductosDevolucionesReemplazosDetalleCompleto.Rows.Add(FilaNueva);
                    FilaNueva.AcceptChanges();

                    FilaNuevaTemp["CodigoProductoDevolucion"] = CodigoProductoDevolucion;
                    FilaNuevaTemp["NombreProductoDevolucion"] = NombreProductoDevolucion;
                    FilaNuevaTemp["MontoTotalDevolucion"] = MontoTotalDevolucion;
                    FilaNuevaTemp["CodigoProductoReemplazo"] = CodigoProductoReemplazo;
                    FilaNuevaTemp["NombreProductoReemplazo"] = NombreProductoReemplazo;
                    FilaNuevaTemp["MontoTotalReemplazo"] = MontoTotalReemplazo;
                    FilaNuevaTemp["PrecioTotal"] = MontoTotalReemplazo - MontoTotalDevolucion;
                    DTVentasProductosDevolucionesReemplazosDetalleTemporal.Rows.Add(FilaNuevaTemp);
                    FilaNuevaTemp.AcceptChanges();

                    TreeNode Nodo = treeViewProductos.Nodes.Add(CodigoProductoDevolucion, NombreProductoDevolucion);
                    Nodo.Nodes.Add(CodigoProductoDevolucion, NombreProductoDevolucion);
                    break;
                case "1xM":
                    decimal PrecioTotalReem = 0;
                    if (checkedLBoxProductosReemplazo.CheckedItems.Count == 1)
                    {
                        if (MessageBox.Show(this, "Seleccionó la Opcion de Devolver un Producto por Varios" + Environment.NewLine + "¿ Desea continuar en esta situación (1x1)? ", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            cardinalidad = "1x1";
                            btnAceptar_Click(sender, e);
                            return;
                        }
                        else
                            return;
                    }
                    DataRow filaDevo2 = DTVentasproductosDevoDisponibles.Rows[checkedLBoxProductosDevueltos.CheckedIndices[0]];
                    CodigoProductoDevolucion = filaDevo2["CodigoProducto"].ToString().Trim();
                    MontoTotalDevolucion = Decimal.Parse(filaDevo2["PrecioTotal"].ToString());
                    NombreProductoDevolucion = filaDevo2["NombreProducto"].ToString().Trim();
                    DTVentasproductosDevoDisponibles.Rows.Remove(filaDevo2);
                    checkedLBoxProductosDevueltos.Items.RemoveAt(checkedLBoxProductosDevueltos.CheckedIndices[0]);
                    //dtGVProductosReemDevo.Rows[dtGVProductosReemDevo.RowCount - 1].DefaultCellStyle.BackColor = ColorResaltado;


                    TreeNode Nodo2 = null;
                    indice = 0;
                    while (checkedLBoxProductosReemplazo.CheckedIndices.Count > 0)
                    //for (int indice = 0; indice < checkedLBoxProductosReemplazo.CheckedIndices.Count; indice++ )
                    {
                        DataRow filaReem2 = DTVentasproductosReemDisponibles.Rows[checkedLBoxProductosReemplazo.CheckedIndices[0]];
                        CodigoProductoReemplazo = filaReem2["CodigoProducto"].ToString().Trim();
                        MontoTotalReemplazo = Decimal.Parse(filaReem2["PrecioTotal"].ToString());
                        NombreProductoReemplazo = filaReem2["NombreProducto"].ToString().Trim();
                        DTVentasproductosReemDisponibles.Rows.Remove(filaReem2);
                        checkedLBoxProductosReemplazo.Items.RemoveAt(checkedLBoxProductosReemplazo.CheckedIndices[0]);                      

                        DataRow FilaNueva2 = DTVentasProductosDevolucionesReemplazosDetalleCompleto.NewRow();
                        DataRow FilaNuevaTemp2 = DTVentasProductosDevolucionesReemplazosDetalleTemporal.NewRow();

                        FilaNueva2["CodigoProductoDevolucion"] = CodigoProductoDevolucion;
                        FilaNueva2["NombreProductoDevolucion"] = NombreProductoDevolucion;
                        FilaNueva2["MontoTotalDevolucion"] = MontoTotalDevolucion;
                        FilaNueva2["CodigoProductoReemplazo"] = CodigoProductoReemplazo;
                        FilaNueva2["NombreProductoReemplazo"] = NombreProductoReemplazo;
                        FilaNueva2["MontoTotalReemplazo"] = MontoTotalReemplazo;
                        DTVentasProductosDevolucionesReemplazosDetalleCompleto.Rows.Add(FilaNueva2);
                        FilaNueva2.AcceptChanges();


                        FilaNuevaTemp2["CodigoProductoDevolucion"] = CodigoProductoDevolucion;
                        FilaNuevaTemp2["NombreProductoDevolucion"] = NombreProductoDevolucion;                        
                        FilaNuevaTemp2["CodigoProductoReemplazo"] = CodigoProductoReemplazo;
                        FilaNuevaTemp2["NombreProductoReemplazo"] = NombreProductoReemplazo;
                        FilaNuevaTemp2["MontoTotalReemplazo"] = MontoTotalReemplazo;
                        
                        if (indice == 0)
                        {
                            Nodo2 = treeViewProductos.Nodes.Add(CodigoProductoDevolucion, NombreProductoDevolucion);
                            FilaNuevaTemp2["MontoTotalDevolucion"] = MontoTotalDevolucion;                            
                            indiceAux = DTVentasProductosDevolucionesReemplazosDetalleTemporal.Rows.Count;
                        }
                        
                        DTVentasProductosDevolucionesReemplazosDetalleTemporal.Rows.Add(FilaNuevaTemp2);
                        FilaNuevaTemp2.AcceptChanges();
                        Nodo2.Nodes.Add(CodigoProductoReemplazo, NombreProductoReemplazo);
                        indice++;
                        PrecioTotalReem += MontoTotalReemplazo;
                    }
                    //FilaNuevaTemp2["PrecioTotal"] = MontoTotalReemplazo - MontoTotalDevolucion;
                    DTVentasProductosDevolucionesReemplazosDetalleTemporal.Rows[indiceAux]["PrecioTotal"] = PrecioTotalReem - MontoTotalDevolucion;
                    DTVentasProductosDevolucionesReemplazosDetalleTemporal.Rows[indiceAux].AcceptChanges();
                    dtGVProductosReemDevo.Rows[indiceAux].DefaultCellStyle.BackColor = ColorResaltado;
                    break;
                case "Mx1":
                    decimal PrecioTotalDevo = 0;
                    if (checkedLBoxProductosDevueltos.CheckedItems.Count == 1)
                    {
                        if (MessageBox.Show(this, "Seleccionó la Opcion de Devolver varios Productos a cambio de Uno, sin embargo, solo ha seleccionado 1 Producto" + Environment.NewLine + "¿ Desea continuar en esta situación (1x1)? ", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            cardinalidad = "1x1";
                            btnAceptar_Click(sender, e);
                            return;
                        }
                        else
                            return;
                    }
                    DataRow filaReem3 = DTVentasproductosReemDisponibles.Rows[checkedLBoxProductosReemplazo.CheckedIndices[0]];
                    CodigoProductoReemplazo = filaReem3["CodigoProducto"].ToString().Trim();
                    MontoTotalReemplazo = Decimal.Parse(filaReem3["PrecioTotal"].ToString());
                    NombreProductoReemplazo = filaReem3["NombreProducto"].ToString().Trim();
                    DTVentasproductosReemDisponibles.Rows.Remove(filaReem3);
                    checkedLBoxProductosReemplazo.Items.RemoveAt(checkedLBoxProductosReemplazo.CheckedIndices[0]);

                    TreeNode Nodo3 = null;
                    indice = 0;
                    while(checkedLBoxProductosDevueltos.CheckedIndices.Count > 0)
                    //for (int indice = 0; indice < checkedLBoxProductosDevueltos.CheckedIndices.Count; indice++)
                    {
                        DataRow filaDevo3 = DTVentasproductosDevoDisponibles.Rows[checkedLBoxProductosDevueltos.CheckedIndices[0]];
                        CodigoProductoDevolucion = filaDevo3["CodigoProducto"].ToString().Trim();
                        MontoTotalDevolucion = Decimal.Parse(filaDevo3["PrecioTotal"].ToString());
                        NombreProductoDevolucion = filaDevo3["NombreProducto"].ToString().Trim();
                        DTVentasproductosDevoDisponibles.Rows.Remove(filaDevo3);
                        checkedLBoxProductosDevueltos.Items.RemoveAt(checkedLBoxProductosDevueltos.CheckedIndices[0]);

                        DataRow FilaNueva3 = DTVentasProductosDevolucionesReemplazosDetalleCompleto.NewRow();
                        DataRow FilaNuevaTemp3 = DTVentasProductosDevolucionesReemplazosDetalleTemporal.NewRow();

                        FilaNueva3["CodigoProductoDevolucion"] = CodigoProductoDevolucion;
                        FilaNueva3["NombreProductoDevolucion"] = NombreProductoDevolucion;
                        FilaNueva3["MontoTotalDevolucion"] = MontoTotalDevolucion;
                        FilaNueva3["CodigoProductoReemplazo"] = CodigoProductoReemplazo;
                        FilaNueva3["NombreProductoReemplazo"] = NombreProductoReemplazo;
                        FilaNueva3["MontoTotalReemplazo"] = MontoTotalReemplazo;
                        DTVentasProductosDevolucionesReemplazosDetalleCompleto.Rows.Add(FilaNueva3);
                        FilaNueva3.AcceptChanges();


                        FilaNuevaTemp3["CodigoProductoDevolucion"] = CodigoProductoDevolucion;
                        FilaNuevaTemp3["NombreProductoDevolucion"] = NombreProductoDevolucion;
                        FilaNuevaTemp3["CodigoProductoReemplazo"] = CodigoProductoReemplazo;
                        FilaNuevaTemp3["NombreProductoReemplazo"] = NombreProductoReemplazo;
                        FilaNuevaTemp3["MontoTotalDevolucion"] = MontoTotalDevolucion;
                        if (indice == 0)
                        {
                            Nodo3 = treeViewProductos.Nodes.Add(CodigoProductoReemplazo, NombreProductoReemplazo);                            
                            FilaNuevaTemp3["MontoTotalReemplazo"] = MontoTotalReemplazo;
                            indiceAux = DTVentasProductosDevolucionesReemplazosDetalleTemporal.Rows.Count;
                        }

                        DTVentasProductosDevolucionesReemplazosDetalleTemporal.Rows.Add(FilaNuevaTemp3);
                        FilaNuevaTemp3.AcceptChanges();
                        Nodo3.Nodes.Add(CodigoProductoDevolucion, NombreProductoDevolucion);

                        PrecioTotalDevo += MontoTotalDevolucion;
                        indice++;
                    }

                    DTVentasProductosDevolucionesReemplazosDetalleTemporal.Rows[indiceAux]["PrecioTotal"] = MontoTotalReemplazo - PrecioTotalDevo;
                    DTVentasProductosDevolucionesReemplazosDetalleTemporal.Rows[indiceAux].AcceptChanges();
                    dtGVProductosReemDevo.Rows[indiceAux].DefaultCellStyle.BackColor = ColorResaltado;

                    break;                    
            }

            if (checkedLBoxProductosDevueltos.Items.Count > 0 && checkedLBoxProductosReemplazo.Items.Count > 0)
            {
                habilitarSubBotonesReemDevo(true, false, false, true);
                rbtnMuchosPorUno.Enabled = true;
                rbtnUnoAUno.Enabled = true;
                rbtnUnoPorMuchos.Enabled = true;
            }
            else
            {
                habilitarSubBotonesReemDevo(false, false, false, true);
            }
            checkedLBoxProductosDevueltos.Enabled = false;
            checkedLBoxProductosReemplazo.Enabled = false;
            txtBoxMontoTotalReemDevo.Text = DTVentasProductosDevolucionesReemplazosDetalleTemporal.Compute("sum(PrecioTotal)", "").ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            checkedLBoxProductosDevueltos.Enabled = false;
            checkedLBoxProductosReemplazo.Enabled = false;

            checkedLBoxProductosDevueltos.ClearSelected();
            checkedLBoxProductosReemplazo.ClearSelected();

            while (checkedLBoxProductosDevueltos.CheckedItems.Count > 0)
                checkedLBoxProductosDevueltos.SetItemChecked(checkedLBoxProductosDevueltos.CheckedIndices[0], false);

            while (checkedLBoxProductosReemplazo.CheckedItems.Count > 0)
                checkedLBoxProductosReemplazo.SetItemChecked(checkedLBoxProductosReemplazo.CheckedIndices[0], false);

            rbtnMuchosPorUno.Enabled = true;
            rbtnUnoAUno.Enabled = true;
            rbtnUnoPorMuchos.Enabled = true;

            habilitarSubBotonesReemDevo(true, false, false, true);
        }

        private void txtBoxBuscarCodDevuelto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (String.IsNullOrEmpty(txtBoxBuscarCodDevuelto.Text.Trim()))
                {
                    MessageBox.Show(this, "Aun no Ingresado correctamente un cóigo a Buscar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string CodigoProducto = txtBoxBuscarCodDevuelto.Text.Trim();

                DataRow FilaEncontrada = DTVentasproductosDevoDisponibles.Rows.Find(CodigoProducto);
                if (FilaEncontrada != null)
                {
                    int indiceEncontrado = DTVentasproductosDevoDisponibles.Rows.IndexOf(FilaEncontrada);
                    checkedLBoxProductosDevueltos.SetItemChecked(indiceEncontrado, true);
                }
                else
                {
                    if (MessageBox.Show(this, "No se encontró el Código que introducio" + Environment.NewLine + "¿Desea seguir Buscando?", this.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        txtBoxBuscarCodDevuelto.Focus();
                        txtBoxBuscarCodDevuelto.SelectAll();
                    }
                }
            }
        }

        private void txtBoxBuscarCodReemplazo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (String.IsNullOrEmpty(txtBoxBuscarCodReemplazo.Text.Trim()))
                {
                    MessageBox.Show(this, "Aun no Ingresado correctamente un cóigo a Buscar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string CodigoProducto = txtBoxBuscarCodReemplazo.Text.Trim();

                DataRow FilaEncontrada = DTVentasproductosReemDisponibles.Rows.Find(CodigoProducto);
                if (FilaEncontrada != null)
                {
                    int indiceEncontrado = DTVentasproductosReemDisponibles.Rows.IndexOf(FilaEncontrada);
                    checkedLBoxProductosReemplazo.SetItemChecked(indiceEncontrado, true);
                }
                else
                {
                    if (MessageBox.Show(this, "No se encontró el Código que introducio" + Environment.NewLine + "¿Desea seguir Buscando?", this.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        txtBoxBuscarCodReemplazo.Focus();
                        txtBoxBuscarCodReemplazo.SelectAll();
                    }
                }
            }
        }

        private void btnAceptarReemDevo_Click(object sender, EventArgs e)
        {
            if (checkedLBoxProductosReemplazo.Items.Count > 0)
            {
                MessageBox.Show(this,"No puede Continuar con la Transacción sin haber seleccionado todos los Productos que reemplazaran a los productos devueltos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string CodigoProductoDevolucion = "";
            decimal MontoTotalDevolucion = 0;
            string CodigoProductoReemplazo = "";
            decimal MontoTotalReemplazo = 0;

            int NumeroReem = DTVentasProductosReemplazos != null && DTVentasProductosReemplazos.Rows.Count > 0 ? Int32.Parse(DTVentasProductosReemplazos.Rows[0]["NumeroReemplazo"].ToString()) : NumeroReemplazo;
            DateTime FechaHoraSolicitudReemDevo = _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor();
            string ObservacionesReemDevo = txtBoxObservacionesReemDevo.Text.Trim();
            int NumAgenciaDevo = DTVentasProductosDevoluciones.Rows.Count > 0 ? Int32.Parse(DTVentasProductosDevoluciones.Rows[0]["NumeroAgencia"].ToString()) : this.NumeroAgencia;
            int NumAgenciaReem = DTVentasProductosReemplazos.Rows.Count > 0 ? Int32.Parse(DTVentasProductosReemplazos.Rows[0]["NumeroAgencia"].ToString()) : NumeroAgencia;

            if (DTVentasProductosDevolucionesReemplazosDetalleTemporal.Rows.Count > 0)
            {
                try
                {
                    _VentasProductosReemplazoDevolucionesCLN.InsertarVentaProductoReemplazoDevolucion(NumeroAgencia, "I", CodigoUsuario, FechaHoraSolicitudReemDevo, ObservacionesReemDevo, NumeroReem);

                    NumeroReemDevo = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("VentasProductosReemplazoDevoluciones");

                    foreach (DataRow fila in DTVentasProductosDevolucionesReemplazosDetalleCompleto.Rows)
                    {
                        CodigoProductoDevolucion = fila["CodigoProductoDevolucion"].ToString();
                        MontoTotalDevolucion = Decimal.Parse(fila["MontoTotalDevolucion"].ToString());
                        CodigoProductoReemplazo = fila["CodigoProductoReemplazo"].ToString();
                        MontoTotalReemplazo = Decimal.Parse(fila["MontoTotalReemplazo"].ToString());
                        
                        //_VentasProductosReemplazoDetalleCLN.InsertarVentaProductoReemplazoDetalle(NumeroAgencia, NumeroReemplazo, CodigoProducto, CantidadDevuelta, PrecioUnitarioReemplazo, TiempoGarantia, FechaHoraSolicitudReemplazo);
                        _VentasProductosReemplazoDevolucionesDetalleCLN.InsertarVentaProductoReemplazoDevolucionDetalle(NumeroAgencia, NumeroReemDevo, NumAgenciaDevo, NumeroDevolucion, CodigoProductoDevolucion, MontoTotalDevolucion, NumAgenciaReem, NumeroReemplazo, CodigoProductoReemplazo, MontoTotalReemplazo);

                    }                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "No se pudo concluir satisfactoriamente la transacción, debido a " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


            }
            habilitarBotonesDevolucion(true, false, false, true, true, true, "RD");
            //NumeroReemDevo = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceVenta("VentasProductosReemplazoDevoluciones");
            if (MessageBox.Show(this, "Se INICIO correctamente la Seleccion de Productos que corresponden a la devolución." + Environment.NewLine + " ¿Desea Finalizar La Selección de Productos devueltos por su correspondiente Reemplazo? ", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //finalizar transacción
                btnFinalizarReemDevo_Click(sender, e);
            }

            
        }

        private void btnFinalizarReemDevo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Una vez Finalizada la Devolucion con Reemplazo de Productos, Se entregará los correspondientes productos y serán retirados de Inventario sin Vuelta Atrás" + Environment.NewLine + "¿ Desea Finalizar la Devolución con Reemplazo ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {                
                try
                {
                   // _VentasProductosReemplazoCLN.FinalizarAnularVentasProductoReemplazo(NumeroAgencia, NumeroReemplazo, "F", _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor());
                    _VentasProductosReemplazoDevolucionesCLN.FinalizarAnularVentasProductosReemplazoDevolucion(NumeroAgencia, NumeroReemDevo, "F", _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "No se Pudo Finalizar la Transaccion debido a :" + ex.Message, "Erro en Reemplazo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                lblFechaReemDevo.Text = "FINALIZADA";
                progressBarReemDevo.Value = progressBarReemDevo.Maximum;

                habilitarBotonesDevolucion(true, false, false, false, false, true, "RD");
            }
        }

        private void btnCancelarReemDevo_Click(object sender, EventArgs e)
        {
            checkedLBoxProductosDevueltos.Items.Clear();
            checkedLBoxProductosReemplazo.Items.Clear();

            habilitarSubBotonesReemDevo(false, false, false, false);

            treeViewProductos.Nodes.Clear();

            DTVentasProductosDevolucionesReemplazosDetalleCompleto.Clear();
            DTVentasProductosDevolucionesReemplazosDetalleTemporal.Clear();

            txtBoxMontoTotalReemDevo.Text = "0.00 " + MascaraMoneda;
            habilitarOpcionesReemDevo(false);

            habilitarBotonesDevolucion(true, false, false, false, false, true, "RD");
        }

        private void tControlGeneral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnAceptarDevolucion.Enabled)
            {
                MessageBox.Show("No puede cambiar de Pestaña mientras no termine la Transacción actual");
                tControlGeneral.SelectedTab = tPageDevoluciones;
                return;
            }
            if (btnAceptarReemplazo.Enabled)
            {                
                MessageBox.Show("No puede cambiar de Pestaña mientras no termine la Transacción actual");
                tControlGeneral.SelectedTab = tPageReemplazo;
                return;
            }

            if (btnAceptarReemDevo.Enabled)
            {
                //Controls[0].Enabled
                MessageBox.Show("No puede cambiar de Pestaña mientras no termine la Transacción actual");
                tControlGeneral.SelectedTab = tPageReemDevo;
                return;
            }
        }

        private void btnReporteDevolucion_Click(object sender, EventArgs e)
        {
            VentasProductosCLN _VentasProductosCLN = new VentasProductosCLN();
            DataTable ventas = _VentasProductosCLN.ListarVentaProductoReporte(NumeroAgencia, NumeroTransaccion);

            DataTable devoluciones = _VentasProductosDevolucionesCLN.ListarVentaDevolucionReporte(NumeroAgencia, NumeroDevolucion);
            DataTable productos = _VentasProductosDevolucionesDetalleCLN.ListarVentasProductosDevolucionesParaDevolucion(NumeroAgencia, NumeroDevolucion);
            DataTable productosEspecificos = _VentasProductosDevolucionesEspecificosCLN.ListarVentasProductosDevolucionesEspecificosParaDevolucionesEspecificos(NumeroAgencia, NumeroDevolucion);

            FReporteVentaProductosDevoluciones formReporte = new FReporteVentaProductosDevoluciones(ventas, devoluciones, productos, productosEspecificos);
            formReporte.Show();

        }

        private void btnReporteReemDevo_Click(object sender, EventArgs e)
        {
            DataTable DTVentasProductosReemDevo = _VentasProductosReemplazoDevolucionesCLN.ListadoVentasProductosDevolucionesReemplazoReporte(NumeroAgencia, NumeroReemDevo);
            DataTable DTVentasProductosReemDevoDetalle = _VentasProductosReemplazoDevolucionesDetalleCLN.ListarVentasProductosDevolucionesReemplazoDetalleReporte(NumeroAgencia, NumeroReemDevo);

            FReporteVentaProductosDevolucioneReemplazo formReemplazoDevoluciones = new FReporteVentaProductosDevolucioneReemplazo(DTVentasProductosReemDevo, DTVentasProductosReemDevoDetalle);
            formReemplazoDevoluciones.Show();
        }

        private void btnReporteReemplazo_Click(object sender, EventArgs e)
        {
            DataTable DTVentasReemplazo = _VentasProductosReemplazoCLN.ListarVentaProductoReemplazoReporte(NumeroAgencia, NumeroReemplazo);
            DataTable DTProductosReemplazo = _VentasProductosReemplazoDetalleCLN.ListarVentasProductosReemplazoDetalleParaReemplazo(NumeroAgencia, NumeroReemplazo);
            DataTable DTProductosEspecificosReemplazo = _VentasProductosReemplazoEspecificosCLN.ListarVentasProductosReemplazoEspecificosParaReemplazo(NumeroAgencia, NumeroReemplazo);

            FReporteVentaProductoReemplazo formReporte = new FReporteVentaProductoReemplazo(DTVentasReemplazo, DTProductosReemplazo, DTProductosEspecificosReemplazo);
            formReporte.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            VentasProductosCLN _VentasProductosCLN = new VentasProductosCLN();
            DataTable DTVentasProductosReemDevoDetalle = _VentasProductosReemplazoDevolucionesDetalleCLN.ListarVentasProductosDevolucionesReemplazoDetalleReporte(NumeroAgencia, NumeroReemDevo);
            DataTable ventas = _VentasProductosCLN.ListarVentaProductoReporte(NumeroAgencia, NumeroTransaccion);
            DataTable devoluciones = _VentasProductosDevolucionesCLN.ListarVentaDevolucionReporte(NumeroAgencia, NumeroDevolucion);
            DataTable productos = _VentasProductosDevolucionesDetalleCLN.ListarVentasProductosDevolucionesParaDevolucion(NumeroAgencia, NumeroDevolucion);

            FReporteDevolucionGeneral formReporte = new FReporteDevolucionGeneral(ventas, devoluciones, productos, DTVentasProductosReemDevoDetalle);
            formReporte.Show();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FObservacionesTransaccionesModificacion _FObservacionesTransaccionesModificacion = new FObservacionesTransaccionesModificacion("D", CodigoUsuario, NumeroAgencia, NumeroDevolucion);
            _FObservacionesTransaccionesModificacion.TxtBoxObservaciones.Text = txtBoxObservaciones.Text;
            if (_FObservacionesTransaccionesModificacion.ShowDialog() == DialogResult.OK)
                txtBoxObservaciones.Text = _FObservacionesTransaccionesModificacion.TxtBoxObservaciones.Text;
        }


       
        
    }
}
