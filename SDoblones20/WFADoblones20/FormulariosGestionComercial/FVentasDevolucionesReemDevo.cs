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
    public partial class FVentasDevolucionesReemDevo : Form
    {
        private int _CodigoCliente;       
        private int _NumeroAgencia;
        private int NumeroDevolucion = 0;
        private int NumeroVenta = 0;
        private string TipoTransaccionDevolucion = "V";

        DataTable DTProductosReemDevo;
        DataTable DTProductosReemDevoDetalle;
        DataTable DTProductosReemDevoTemporal;
        DataTable DTProductosReemDevoDetalleTemporal;
        DataTable DTProductosEntregados;
        DataTable DTProductosBusqueda;
        DataTable DTProductosEntregadosBackup;
        DataTable DTProductosBusquedaBackup;
        DataTable DTMotivosReemDevo;

        DataSet DSVentaProductosDevoluciones = new DataSet();

        TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;
        VentasProductosReemDevoCLN _VentasProductosReemDevoCLN;
        VentasProductosEspecificosReemDevoCLN _VentasProductosEspecificosReemDevoCLN;
        CLCLN.Sistema.MotivosReemDevoCLN _MotivosReemDevoCLN;
        
        VentasProductosCLN _VentasProductosCLN;

        FBuscarTransaccion formBuscarTransaccion;
        DataRow filaInsertar = null;
        string CamposBusqueda = "001001";

        #region Propiedades Formularios
        public int CodigoCliente
        {
            get { return this._CodigoCliente; }
            set { this._CodigoCliente = value; }
        }

        public int NumeroAgencia
        {
            get { return this._NumeroAgencia; }
            set { this._NumeroAgencia = value; }
        }
        #endregion

        /// <summary>
        /// Esté codigo solo se utiliza en el caso de que hay devolución sin reemplazo
        /// y se devuelve directamente el dinero que se cancelo para la venta o devolución
        /// </summary>
        private const string CodigoProductoComodin = "-------------01";
        private const string CodigoProductoEspecificoComodin = "------------------01";

        public FVentasDevolucionesReemDevo( int NumeroAgencia, int CodigoCliente)
        {
            this._CodigoCliente = CodigoCliente;
            this._NumeroAgencia = NumeroAgencia;
            InitializeComponent();

            DTProductosReemDevo = new DataTable();
            DTProductosReemDevoDetalle = new DataTable();
            DTProductosReemDevoTemporal = new DataTable();
            DTProductosReemDevoDetalleTemporal = new DataTable();
            DTProductosEntregados = new DataTable();
            DTProductosBusqueda = new DataTable();
            DTMotivosReemDevo = new DataTable();
            DTProductosEntregadosBackup = new DataTable();
            DTProductosBusquedaBackup = new DataTable();

            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();
            _VentasProductosReemDevoCLN = new VentasProductosReemDevoCLN();
            _VentasProductosEspecificosReemDevoCLN = new VentasProductosEspecificosReemDevoCLN();
            _VentasProductosCLN = new VentasProductosCLN();
            _MotivosReemDevoCLN = new CLCLN.Sistema.MotivosReemDevoCLN();

            crearColumnasDataTableProductosReemDevo();

            formBuscarTransaccion = new FBuscarTransaccion(NumeroAgencia);
            this.cBoxBuscarProductosPor.SelectedIndex = 2;
            this.cBoxBuscarPorEntregados.SelectedIndex = 2;

            habilitarBotonesDevolucion(true, false, false, false, false, false, true, false, false);
            txtBoxObservaciones.Enabled = false;
            habilitarGroupBoxDevoluciones(false, false, false, false, false, false, false);
        }

        public void crearColumnasDataTableProductosReemDevo()
        {
            DataColumn DCCodigoMotivoReemDevo = new DataColumn();
            DCCodigoMotivoReemDevo.ColumnName = "CodigoMotivoReemDevo";
            //DCCodigoMotivoReemDevo.AllowDBNull = false;            
            DCCodigoMotivoReemDevo.DataType = Type.GetType("System.String");

            DataColumn DCCodigoProductoDevo = new DataColumn();
            DCCodigoProductoDevo.ColumnName = "CodigoProductoDevo";
            DCCodigoProductoDevo.AllowDBNull = false;            
            DCCodigoProductoDevo.DataType = Type.GetType("System.String");

            DataColumn DCCodigoProductoCambio = new DataColumn();
            DCCodigoProductoCambio.ColumnName = "CodigoProductoCambio";
            DCCodigoProductoCambio.AllowDBNull = false;            
            DCCodigoProductoCambio.DataType = Type.GetType("System.String");
            DCCodigoProductoCambio.DefaultValue = CodigoProductoComodin;

            DataColumn DCCodigoProductoEspeDevo = new DataColumn();
            DCCodigoProductoEspeDevo.ColumnName = "CodigoProductoEspeDevo";
            DCCodigoProductoEspeDevo.AllowDBNull = false;
            DCCodigoProductoEspeDevo.Unique = true;
            DCCodigoProductoEspeDevo.DataType = Type.GetType("System.String");

            DataColumn DCCodigoProductoEspeCambio = new DataColumn();
            DCCodigoProductoEspeCambio.ColumnName = "CodigoProductoEspeCambio";
            DCCodigoProductoEspeCambio.AllowDBNull = false;
            DCCodigoProductoEspeCambio.Unique = true;
            DCCodigoProductoEspeCambio.DataType = Type.GetType("System.String");
            DCCodigoProductoEspeCambio.DefaultValue = CodigoProductoEspecificoComodin;

            DataColumn DCNombreProductoDevo = new DataColumn();
            DCNombreProductoDevo.ColumnName = "NombreProductoDevo";
            DCNombreProductoDevo.AllowDBNull = false;            
            DCNombreProductoDevo.DataType = Type.GetType("System.String");

            DataColumn DCNombreProductoCambio = new DataColumn();
            DCNombreProductoCambio.ColumnName = "NombreProductoCambio";
            DCNombreProductoCambio.AllowDBNull = false;            
            DCNombreProductoCambio.DataType = Type.GetType("System.String");

            DataColumn DCTiempoGarantiaPE = new DataColumn();
            DCTiempoGarantiaPE.ColumnName = "TiempoGarantiaPE";
            DCTiempoGarantiaPE.DataType = Type.GetType("System.Int32");
            DCTiempoGarantiaPE.DefaultValue = 0;

            DataColumn DCFechaHoraVencimientoPE = new DataColumn();
            DCFechaHoraVencimientoPE.ColumnName = "FechaHoraVencimientoPE";
            DCFechaHoraVencimientoPE.DataType = Type.GetType("System.DateTime");
            DCFechaHoraVencimientoPE.DefaultValue = DateTime.Now.AddMonths(4);

            DataColumn DCMontoDevolucion = new DataColumn();
            DCMontoDevolucion.ColumnName = "MontoDevolucion";
            DCMontoDevolucion.DataType = Type.GetType("System.Decimal");
            DCMontoDevolucion.DefaultValue = 0.00;

            DataColumn DCCodigoTipoReemDevo = new DataColumn();
            DCCodigoTipoReemDevo.ColumnName = "CodigoTipoReemDevo";
            DCCodigoTipoReemDevo.DataType = Type.GetType("System.String");
            DCCodigoTipoReemDevo.DefaultValue = "R";

            DataColumn DCPrecioUnitarioPECambio = new DataColumn();
            DCPrecioUnitarioPECambio.ColumnName = "PrecioUnitarioPECambio";
            DCPrecioUnitarioPECambio.DataType = Type.GetType("System.Decimal");
            DCPrecioUnitarioPECambio.DefaultValue = 0.00;

            DataColumn DCFechaHoraReemDevoCambio = new DataColumn();
            DCFechaHoraReemDevoCambio.ColumnName = "FechaHoraReemDevoCambio";
            DCFechaHoraReemDevoCambio.DataType = Type.GetType("System.DateTime");
            DCFechaHoraReemDevoCambio.DefaultValue = DateTime.Now;

            DataColumn DCObservacionesReemDevoCambio = new DataColumn();
            DCObservacionesReemDevoCambio.ColumnName = "ObservacionesReemDevoCambio";
            DCObservacionesReemDevoCambio.DataType = Type.GetType("System.String");

            DTProductosReemDevoDetalleTemporal.Columns.AddRange(new DataColumn[] { 
                DCCodigoProductoCambio,
                DCCodigoProductoEspeCambio,
                DCNombreProductoCambio,
                DCCodigoProductoDevo,
                DCCodigoProductoEspeDevo,
                DCNombreProductoDevo,
                DCTiempoGarantiaPE,
                DCFechaHoraVencimientoPE,
                DCPrecioUnitarioPECambio,
                DCMontoDevolucion,
                DCCodigoMotivoReemDevo,
                DCCodigoTipoReemDevo,
                DCFechaHoraReemDevoCambio,
                DCObservacionesReemDevoCambio
            });

            
        }

        private void devoluciónAnteriorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //formBuscarTransaccion.
        }

        private void ventaProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formBuscarTransaccion.formatearEstiloParaVentas();
            formBuscarTransaccion.ShowDialog(this);

            NumeroVenta = formBuscarTransaccion.NumeroTransaccion;

            //DTProductosEntregados = _TransaccionesUtilidadesCLN.BuscarProductoTransaccionVentaDevolucion(NumeroAgencia, NumeroVenta, "0", "", "V", false);
            //DTProductosEntregados.PrimaryKey = null;
            //DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            //PrimaryKeyColumns[0] = DTProductosEntregados.Columns["Código Específico"];
            //DTProductosEntregados.PrimaryKey = PrimaryKeyColumns;


            bdSourceProductosEntregados.DataSource = DTProductosEntregados;

            if (DTProductosEntregados.Rows.Count == 0)
            {
                MessageBox.Show(this,"Revise bien sus Datos. No se realizó Ninguna venta de Productos Especificos en esta Transacción",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            DTProductosEntregadosBackup = DTProductosEntregados.Copy();
            if (!DSVentaProductosDevoluciones.Tables.Contains(DTProductosEntregados.TableName))
                DSVentaProductosDevoluciones.Tables.Add(DTProductosEntregados);


            dtGVProductosEntregados.DataSource = bdSourceProductosEntregados;                        
            habilitarBotonesOpcionInsertado(true, false, false, false);            
            habilitarGroupBoxDevoluciones(true, true, false, false, false, false, false);
            
        }

        /// <summary>
        /// Habilita los distintos botones que se encargan de las acciones dentro de una Devolución
        /// </summary>
        /// <param name="nuevaDevolucion">Habilitar una Nueva Devolución</param>
        /// <param name="cancelar">Cancelar la Devolución que se lleva actualmente</param>
        /// <param name="anular">Anular una Devolución que ha sido Inicializada y se encuentra en estado 'Iniciado'</param>
        /// <param name="aceptar">Aceptar la Devolución y guardar cambios dentro de la Base de Datos, y habilitar para comcluir o finalizar la misma</param>
        /// <param name="finalizar">Finalizar completamente el proceso para la entrega de productos</param>
        /// <param name="busquedasParaNuevaDevolucion">Botones que permiten buscar distintas transacciones para basarnos enla mismas e iniciar una nueva Devolución</param>
        /// <param name="busquedaVisualizar">boton para habilitar la busqueda de una Devolución ya realizada y solo mostrar su datos</param>
        /// <param name="verReportes">Ver los Distintos Reportes</param>
        /// <param name="opcionesAnadirEdicion">Panel que se encarga de la edición e insertado de las opciones de edición</param>
        public void habilitarBotonesDevolucion(bool nuevaDevolucion,  bool cancelar, bool anular, bool aceptar, bool finalizar, bool busquedasParaNuevaDevolucion, bool busquedaVisualizar, bool verReportes, bool opcionesAnadirEdicion)
        {
            this.devoluciónAnteriorToolStripMenuItem.Enabled = busquedaVisualizar;
            this.ventaProductosAgregadosToolStripMenuItem.Enabled = busquedasParaNuevaDevolucion;
            this.ventaProductosToolStripMenuItem.Enabled = busquedasParaNuevaDevolucion;
            this.devoluciónToolStripMenuItem.Enabled = busquedasParaNuevaDevolucion;

            this.btnNuevaDevolucion.Enabled = nuevaDevolucion;
            this.btnCancelarDevolucion.Enabled = cancelar;
            this.btnAnularDeovlucion.Enabled = anular;
            this.btnAceptarDevolucion.Enabled = aceptar;
            this.btnFinalizarDevolucion.Enabled = finalizar;
            this.pnlAgrupadorProductosIzquierda.Visible = opcionesAnadirEdicion;
        }

        /// <summary>
        /// Habilitar los Botones de Edición e Insertado cuando una Devolución ha sido iniciada
        /// </summary>
        /// <param name="nuevo">Nuevo Producto a Devolver o Intercambiar</param>
        /// <param name="cancelar">Cancelar el Producto Seleccionado</param>
        /// <param name="aceptar">Aceptar el Producto Seleccionado</param>
        /// <param name="eliminar">Eliminar el Producto Seleccionado</param>
        public void habilitarBotonesOpcionInsertado(bool nuevo, bool cancelar, bool aceptar, bool eliminar)
        {
            this.btnNuevo.Enabled = nuevo;
            this.btnCancelar.Enabled = cancelar;
            this.btnAceptar.Enabled = aceptar;
            this.btnEliminar.Enabled = eliminar;
        }

        /// <summary>
        /// habilitar los GroupBox de Acuerdo a la operación que se lleva a cabo
        /// </summary>
        /// <param name="groupCardinalidad">habilitar la selecciona de tipo de cardinalidad en la devolucion</param>
        /// <param name="groupTipoCambio">habilitar que cambio se realizará en la Devolución</param>
        /// <param name="groupPatronBusquedaEntregados"> habilitar la opciones de busqueda de un transacción ya realizada, para basarse en la misma</param>
        /// <param name="groupPatronBusquedaIntercambio">habilitar las opciones de busqueda de los productos por los cuales se intercambiara un producto(s)</param>
        /// <param name="groupDetalleDevolucion">Para la Grilla que contiene el Detalle de la Devolución que se lleva o la que se carga de la Base de Datos de una ya realizada</param>
        /// <param name="groupBusquedaEntregadosDetalle">Grilla de los Productos que se encontraron de una Transacción ya hecha para escoger uno</param>
        /// <param name="groupBusquedaIntercambioDetalle">Grilla de los prodcutos posibles que pueden reemplazar un producto ya entregado</param>
        public void habilitarGroupBoxDevoluciones(bool groupCardinalidad, bool groupTipoCambio, bool groupPatronBusquedaEntregados, bool groupPatronBusquedaIntercambio, bool groupDetalleDevolucion, bool groupBusquedaEntregadosDetalle, bool groupBusquedaIntercambioDetalle)
        {
            gboxCardinalidad.Enabled = groupCardinalidad;
            gBoxTipoCambio.Enabled = groupTipoCambio;

            gBoxPatronBusquedaProductosIntercambio.Enabled = groupPatronBusquedaIntercambio;
            gBoxPatronBusquedaEntregados.Enabled = groupPatronBusquedaEntregados;

            gBoxProductosReemplazadosDevueltosDetalle.Enabled = groupDetalleDevolucion;

            gBoxTransaccionBusquedaDetalle.Enabled = groupBusquedaEntregadosDetalle;
            gBoxProductoBuxquedaReempladoDetalle.Enabled = groupBusquedaIntercambioDetalle;
            
            
        }

        /// <summary>
        /// habilitar las opciones de Busqueda
        /// </summary>
        /// <param name="groupPatronBusquedaEntregados"> habilitar la opciones de busqueda de un transacción ya realizada, para basarse en la misma</param>
        /// <param name="groupPatronBusquedaIntercambio">habilitar las opciones de busqueda de los productos por los cuales se intercambiara un producto(s)</param>        
        /// <param name="groupBusquedaEntregadosDetalle">Grilla de los Productos que se encontraron de una Transacción ya hecha para escoger uno</param>
        /// <param name="groupBusquedaIntercambioDetalle">Grilla de los prodcutos posibles que pueden reemplazar un producto ya entregado</param>
        public void habilitarGroupboxOpcionesSeleccionBusqueda(bool groupPatronBusquedaEntregados, bool groupPatronBusquedaIntercambio,  bool groupBusquedaEntregadosDetalle, bool groupBusquedaIntercambioDetalle)
        {
            gBoxPatronBusquedaProductosIntercambio.Enabled = groupPatronBusquedaIntercambio;
            gBoxPatronBusquedaEntregados.Enabled = groupPatronBusquedaEntregados;

            gBoxTransaccionBusquedaDetalle.Enabled = groupBusquedaEntregadosDetalle;
            gBoxProductoBuxquedaReempladoDetalle.Enabled = groupBusquedaIntercambioDetalle;
        }

        /// <summary>
        /// habilitar los GroupBox de Acuerdo a la operación que se lleva a cabo
        /// </summary>
        /// <param name="groupCardinalidad">habilitar la selecciona de tipo de cardinalidad en la devolucion</param>
        /// <param name="groupTipoCambio">habilitar que cambio se realizará en la Devolución</param>
        public void habilitarGroupBoxTipoCardinalidad(bool groupCardinalidad, bool groupTipoCambio)
        {
            gboxCardinalidad.Enabled = groupCardinalidad;
            gBoxTipoCambio.Enabled = groupTipoCambio;
        }

        public void habilitarCamposEdicion(bool habilitar)
        {

        }

        public void cargarDatosDevolucion(int NumDevolucion)
        {
            DTProductosReemDevoDetalle.Clear();
            DTProductosReemDevoDetalle = _TransaccionesUtilidadesCLN.ListarDetalleDeVentaProductosReemDevo(NumeroAgencia, NumDevolucion);
            bdSourceProductosEntregadosDevueltos.DataSource = DTProductosReemDevoDetalle;
        }

        private void btnBuscarBuscados_Click(object sender, EventArgs e)
        {
            DTProductosBusqueda = _TransaccionesUtilidadesCLN.BuscarProductosParaTransaccionDevolucionReem(NumeroAgencia, txtTextoProductosBusqueda.Text, 0, checkTextoIdenticoBusqueda.Checked, CamposBusqueda);
            if (DTProductosBusqueda.Rows.Count == 0)
                DTProductosBusqueda.Clear();
            bdSourceProductosBusqueda.DataSource = DTProductosBusqueda;
        }

        private void cBoxBuscarProductosPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cBoxBuscarProductosPor.SelectedIndex)
            {
                case 0:
                    CamposBusqueda = "100001";
                    break;
                case 1:
                    CamposBusqueda = "010001";
                    break;
                case 2:
                    CamposBusqueda = "001001";
                    break;
                case 3:
                    CamposBusqueda = "000101";
                    break;
                case 4:
                    CamposBusqueda = "000011";
                    break;
            }
        }

        private void btnNuevaDevolucion_Click(object sender, EventArgs e)
        {
            DTProductosBusqueda.Clear();
            DTProductosEntregados.Clear();
            DTProductosReemDevoDetalleTemporal.Clear();
            DTProductosReemDevoTemporal.Clear();

            habilitarBotonesDevolucion(false, true, false, true, false, true, false, false, true);
            habilitarBotonesOpcionInsertado(false, false, false, false);
            habilitarGroupBoxDevoluciones(false, false, false, false, false, false, false);
            txtBoxObservaciones.Enabled = true;

            NumeroDevolucion = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("VentasProductosReemDevo");
            if (NumeroDevolucion == 0) NumeroDevolucion = 1;
            if (NumeroDevolucion > 1)
                NumeroDevolucion++;

            lblEstadoDevolucion.Text = "INICIADA";
            lblFechaDevolucion.Text = DateTime.Now.ToShortDateString() +" " +DateTime.Now.ToShortTimeString();
            lblNumeroDevolucion.Text = NumeroDevolucion.ToString();
            lblNumeroVenta.Text = NumeroVenta.ToString();

            bdSourceProductosEntregadosDevueltos.DataSource = DTProductosReemDevoDetalleTemporal;
            gBoxProductosReemplazadosDevueltosDetalle.Enabled = true;

        }

        private void btnCancelarDevolucion_Click(object sender, EventArgs e)
        {
            habilitarBotonesDevolucion(true, false, false, false, false, false, true, true, false);
            habilitarBotonesOpcionInsertado(false, false, false, false);
            habilitarGroupBoxDevoluciones(false, false, false, false, false, false, false);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            habilitarBotonesOpcionInsertado(false, true, true, false);
            if (rbtnUnoAUno.Checked)
            {
                habilitarGroupboxOpcionesSeleccionBusqueda(true, false, true, false);
            }
            if (rbtnUnoPorMuchos.Checked)
            {
                habilitarGroupboxOpcionesSeleccionBusqueda(true, false, true, false);
            }
            if (rbtnMuchosPorUno.Checked)
            {
                habilitarGroupboxOpcionesSeleccionBusqueda(false, true, false, true);
            }
            if (rbtnSinDevoNiCambio.Checked)
            {
                habilitarGroupboxOpcionesSeleccionBusqueda(true, false, true, false);
            }
            habilitarGroupBoxTipoCardinalidad(false, false);
        }

        private void btnBuscarEntregados_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtBoxTextoBusquedaEntregados.Text))
            {
                MessageBox.Show(this, "Aun no ha Insertado un Texto para Buscar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBoxTextoBusquedaEntregados.Focus();
            }
            else
            {
                //DTProductosEntregados = _TransaccionesUtilidadesCLN.BuscarProductoTransaccionVentaDevolucion(NumeroAgencia, NumeroVenta, cBoxBuscarPorEntregados.SelectedIndex.ToString(), txtBoxTextoBusquedaEntregados.Text.Trim(), TipoTransaccionDevolucion, checkTextoIdenticoEntregados.Checked);
                if (DTProductosEntregados.Rows.Count == 0)
                {
                    MessageBox.Show(this, "No se encontro ningun producto con la descripción insertada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DTProductosEntregados = DTProductosEntregadosBackup.Copy();
                    return;
                }

                bdSourceProductosEntregados.DataSource = DTProductosEntregados;
                if (!DSVentaProductosDevoluciones.Tables.Contains(DTProductosEntregados.TableName))
                    DSVentaProductosDevoluciones.Tables.Add(DTProductosEntregados);


                dtGVProductosEntregados.DataSource = bdSourceProductosEntregados;                                            
                
            }
        }

        private void btnAnadirEntregados_Click(object sender, EventArgs e)
        {

            /*CodigoMotivoReemDevo
            CodigoProductoDevo
            CodigoProductoCambio
            CodigoProductoEspeDevo
            CodigoProductoEspeCambio
            NombreProductoDevo
            NombreProductoCambio
            TiempoGarantiaPE
            FechaHoraVencimientoPE
            MontoDevolucion
            CodigoTipoReemDevo
            PrecioUnitarioPECambio
            FechaHoraReemDevoCambio
            ObservacionesReemDevoCambio
             */
            if (rbtnUnoAUno.Checked)
            {
                filaInsertar = DTProductosReemDevoDetalleTemporal.NewRow();
                filaInsertar["CodigoProductoDevo"] = dtGVProductosEntregados.CurrentRow.Cells[0].Value;
                filaInsertar["CodigoProductoEspeDevo"] = dtGVProductosEntregados.CurrentRow.Cells[1];
                filaInsertar["NombreProductoDevo"] = dtGVProductosEntregados.CurrentRow.Cells[2];

                treeViewProductos.Nodes.Add(dtGVProductosEntregados.CurrentRow.Cells[0].Value.ToString(), dtGVProductosEntregados.CurrentRow.Cells[2].Value.ToString());

                habilitarGroupboxOpcionesSeleccionBusqueda(false, true, false, true);
            }
            if (rbtnUnoPorMuchos.Checked)
            {
                
            }
            if (rbtnMuchosPorUno.Checked)
            {
                
            }
            if (rbtnSinDevoNiCambio.Checked)
            {
                
            }
        }

        private void btnAnadirBuscados_Click(object sender, EventArgs e)
        {
            if (rbtnUnoAUno.Checked)
            {
                filaInsertar["CodigoProductoCambio"] = dtGVProductosBusqueda.CurrentRow.Cells[0].Value;
                filaInsertar["CodigoProductoEspeCambio"] = dtGVProductosBusqueda.CurrentRow.Cells[0].Value;
                filaInsertar["NombreProductoCambio"] = dtGVProductosBusqueda.CurrentRow.Cells[0].Value;

                DTProductosReemDevoDetalleTemporal.Rows.Add(filaInsertar);
                filaInsertar.AcceptChanges();
            }
            if (rbtnUnoPorMuchos.Checked)
            {

            }
            if (rbtnMuchosPorUno.Checked)
            {

            }
            if (rbtnSinDevoNiCambio.Checked)
            {

            }
        }

    }
}
