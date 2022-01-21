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
    public partial class FProductosBusqueda2 : Form
    {

        #region Constantes y Boleanos Para el Formulario {Columnas, banderas}
        const int AltoNormal = 170;
        const int AltoOpcionesAvanzadas = 80;

        /// <summary>
        /// Numero de Columna[0] que Referencia al Atributo Codigo de la Tabla Productos Seleccionados, para el Datagridview y DataTable
        /// </summary>
        const int columnaCodigo = 0;

        /// <summary>
        /// Numero de Columna[1] que Referencia al Atributo Nombre Producto de la Tabla Productos Seleccionados, para el Datagridview y DataTable
        /// </summary>
        const int columnaNombreProducto = 1;

        /// <summary>
        /// Numero de Columna[2] que Referencia al Atributo Cantidad de la Tabla Productos Seleccionados, para el Datagridview y DataTable
        /// </summary>
        const int columnaCantidad = 2;


        /// <summary>
        /// Numero de Columna[3] que Referencia al Atributo PrecioUnitarioVenta1 de la Tabla Productos Seleccionados, para el Datagridview y DataTable
        /// </summary>
        const int columnaPrecioUnitario = 3;

        /// <summary>
        /// Numero de Columna[4] que Referencia al Atributo Precio Total Calculado de la Tabla Productos Seleccionados, para el Datagridview y DataTable
        /// </summary>
        const int columnaPrecioTotal = 4;

        /// <summary>
        /// Si el ente que se Realizó viene de la Tabla Productos Busquedda
        /// </summary>
        bool isEnterFromTableProductosBusqueda = false;

        /// <summary>
        /// Si la Tabla ProductosBusqueda se encuentra en estado de inserción
        /// </summary>
        bool isInsertingModeTableProductosBusqueda = false;

        ///// <summary>
        ///// Si se Esta insertando
        ///// </summary>
        //bool isInserting = false;

        /// <summary>
        /// Si el Detalle de los productos ha sido Confirmado
        /// </summary>
        public bool detalleConfirmado = false;

        /// <summary>
        /// Si la Seleccion de los productos es para una nueva Venta
        /// </summary>
        public bool nuevaVenta = true;

        /// <summary>
        /// Si el Usuario Seleccionará los productos Especificos que desea Vender
        /// </summary>
        public bool seleccionarProductosEspecificos = false;
        #endregion

        #region Entidades de la Capa Logica de Negocios        
        TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN = null;
        InventariosProductosCLN _InventariosProductosCLN = null;
        MonedasCLN _MonedasCLN = null;
        #endregion

        #region Datos y DataTable

        DataSet DSdatosVentaTemporal = null;

        DataTable _DTProductosSeleccionados = null;
        DataTable _DTProductosBusqueda = null;
        public DataTable DTProductoSeleccionadosCopia = null;
        public DataTable DTProductosBusquedaMonedaSistema = null;
        public DataTable DTProductosSeleccionadosMonedaSistema = null;
        private DataTable _DTVentasProductosTemporalCambioMoneda = null;

        #endregion

              

        ArrayList indicesProductosExistenciaInalcanzable = new ArrayList();
        ArrayList ListaCodigoEliminados = new ArrayList();
        public bool TransaccionConfirmada = false;
        
        private int NumeroAgencia = 1;
        private int NumeroPC;
        int CodigoMonedaSistema = 1;
        decimal PorcentajeImpuestoIVA = 13;
        
        public bool ExistenProductosInalcanzables = false;
        private bool esPrimeraVezFactura = false;
        private bool esPrimeraVezCambioCotizacionMoneda = false;
        public bool sePuedeCambiarCotizacion = true;

        private String BuscarCodigoProducto = "0";
        private String BuscarCodigoFabricante = "0";
        private String BuscarNombreProducto1 = "0";
        private String BuscarNombreProducto2 = "0";
        private String BuscarNombreProducto3 = "0";
        private String BuscarAgencia = "1";
        private char TipoPrecioSeleccionado = '1';
        private String CamposBusqueda = "001001";


        /// <summary>
        /// La Busqueda de productos se Realizara de acuerdo al Tipo de Transacción
        /// 'V' VENTAS ->Restricción de productos cuya existencia no sea lo suficiente
        /// 'C' COMPRAS->Ninguna Restricción 
        /// 'T' COTIZACIONES -> no se debe revisar los productos Especificos
        /// 
        /// </summary>
        private char TipoTransaccion = 'V';
        private bool esSeleccionNueva = true;

        #region Propiedades del Formulario
        public DataTable DTProductosSeleccionados
        {
            get { return _DTProductosSeleccionados; }
            set { this._DTProductosSeleccionados = value; }
        }
        public DataTable DTProductoSeleccionadosCopiaTemporal
        {
            get { return DTProductoSeleccionadosCopia; }
            set { DTProductoSeleccionadosCopia = value; }
        }
        /// <summary>
        /// Label que contiene la información del Numero de Transacción que
        /// se veiene Generando en la Transacción Actual
        /// </summary>
        public ToolStripStatusLabel LabelNumeroTransaccion
        {
            get
            {
                return this.toolStripStatusLabel6;
            }
            set
            {
                this.toolStripStatusLabel6 = value;
            }
        }

        /// <summary>
        /// Persona que Realiza la Transacción, un Cliente o un Proveedor
        /// de acuerdo al tipo de Transacción
        /// </summary>
        public ToolStripStatusLabel LabelNombrePersonaTransaccion
        {
            get
            {
                return this.toolStripStatusLabel8;
            }
            set
            {
                this.toolStripStatusLabel8 = value;
            }
        }

        /// <summary>
        /// Tipo de Transacción que se Realizar: Al Contado o  a Crédito
        /// </summary>
        public ToolStripStatusLabel LabelTipoTransaccion
        {
            get
            {
                return this.toolStripStatusLabel10;
            }
            set
            {
                this.toolStripStatusLabel10 = value;
            }
        }

        /// <summary>
        /// Nombre de la Transacción que se Realizar: Venta, Compra, Cotización
        /// </summary>
        public ToolStripStatusLabel LabelNombreTransaccion
        {
            get
            {
                return this.toolStripStatusLabel5;
            }
            set
            {
                this.toolStripStatusLabel5 = value;
            }
        }


        public Label LabelPrecioTotal
        {
            get
            {
                return this.lblPrecioTotal;
            }
            set
            {
                this.lblPrecioTotal = value;
            }
        }

        public BindingSource BDSourceProductosSeleccionados
        {
            get { return this.bdSourceProductosSeleccionados; }
            set { this.bdSourceProductosSeleccionados = value; }
        }

        public ArrayList ListaCodigosProductosEliminados
        {
            get { return this.ListaCodigoEliminados; }
        }

        public DataGridView DTGridViewProductosSeleccionados
        {
            get { return dtGridViewProductosSeleccionados; }
            set { this.dtGridViewProductosSeleccionados = value; }
        }

        public ComboBox CBoxMonedas
        {
            get { return cBoxMonedaCotizacion; }
            set { cBoxMonedaCotizacion = value; }
        }
        public CheckBox CheckConFactura
        {
            get { return checkConFactura; }
            set { checkConFactura = value; }
        }
        public DataTable DTProductosSeleccionadosCopia2
        {
            get { return DTProductoSeleccionadosCopia; }

        }
        #endregion
        

        public FProductosBusqueda2(int NumeroAgencia, int NumeroPC, char TipoTransaccion, int CodigoMonedaSistema, decimal PorcentajeImpuestoIVA)
        {
            crearTablasTemporales();
            InitializeComponent();
            this.TipoTransaccion = TipoTransaccion;
            this.NumeroAgencia = NumeroAgencia;
            this.NumeroPC = NumeroPC;
            this.CodigoMonedaSistema = CodigoMonedaSistema;
            this.PorcentajeImpuestoIVA = PorcentajeImpuestoIVA;
            DTProductosBusquedaMonedaSistema = _DTProductosBusqueda.Clone();
            
            _InventariosProductosCLN = new InventariosProductosCLN();
            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();   
            _MonedasCLN = new MonedasCLN();
            this.bdSourceProductosSeleccionados.DataSource = _DTProductosSeleccionados;
            _DTProductosSeleccionados.RowDeleted += new DataRowChangeEventHandler(_DTProductosSeleccionados_RowDeleted);
            _DTProductosSeleccionados.RowChanged += new DataRowChangeEventHandler(_DTProductosSeleccionados_RowChanged);
            

            cBoxMonedaCotizacion.DataSource = _MonedasCLN.ListarMonedas();
            cBoxMonedaCotizacion.DisplayMember = "NombreMoneda";
            cBoxMonedaCotizacion.ValueMember = "CodigoMoneda";
            cBoxMonedaCotizacion.SelectedValue = CodigoMonedaSistema;
        }

        void _DTProductosSeleccionados_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            //e.Row["Cantidad"].ToString();
            //if (e.Column.ColumnName == "Precio" && e.Row.RowState == DataRowState.Modified)
            //{
            //    MessageBox.Show("Cantidad Modificada");
            //}

        }

        void _DTProductosSeleccionados_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            if (_DTProductosSeleccionados.Rows.Count == DTProductosSeleccionadosMonedaSistema.Rows.Count)
            {
                int indiceEliminado = _DTProductosSeleccionados.Rows.IndexOf(e.Row);
                DTProductosSeleccionadosMonedaSistema.Rows.RemoveAt(indiceEliminado);
                DTProductosSeleccionadosMonedaSistema.AcceptChanges();

                if (_DTProductosSeleccionados.Rows.Count == 0)
                {
                    checkConFactura.Checked = false;
                    esPrimeraVezFactura = false;
                }
            }
        }

        
        void _DTProductosSeleccionados_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            DataTable DTMonedas = cBoxMonedaCotizacion.DataSource as DataTable;

            lblPrecioTotal.Text = string.IsNullOrEmpty(_DTProductosSeleccionados.Compute("Sum(PrecioTotal)", "").ToString())
                ? " 0.00 " : _DTProductosSeleccionados.Compute("Sum(PrecioTotal)", "").ToString()
                + " " + DTMonedas.Rows[cBoxMonedaCotizacion.SelectedIndex]["MascaraMoneda"].ToString();


        }

        private void FProductosBusqeuda2_Load(object sender, EventArgs e)
        {

        }


        public void crearTablasTemporales()
        {
            DSdatosVentaTemporal = new DataSet();
            _DTProductosSeleccionados = new DataTable();
            _DTProductosBusqueda = new DataTable();
            DataColumn column = new DataColumn();

            column.AllowDBNull = false;
            column.ColumnName = "Código Producto";
            column.Unique = true;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = false;
            _DTProductosSeleccionados.Columns.Add(column);

            column = new DataColumn();
            column.AllowDBNull = false;
            column.ColumnName = "Nombre Producto";
            column.Unique = true;
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = false;
            _DTProductosSeleccionados.Columns.Add(column);


            column = new DataColumn();
            column.ColumnName = "Cantidad";
            column.DataType = Type.GetType("System.Int32");
            _DTProductosSeleccionados.Columns.Add(column);


            column = new DataColumn();
            column.ColumnName = "Precio";
            column.DataType = Type.GetType("System.Decimal");
            column.ReadOnly = false;
            _DTProductosSeleccionados.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "PrecioTotal";
            column.DataType = Type.GetType("System.Decimal");
            column.ReadOnly = false;
            _DTProductosSeleccionados.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "Garantia";
            column.DataType = Type.GetType("System.Int16");
            column.ReadOnly = false;
            _DTProductosSeleccionados.Columns.Add(column);


            column = new DataColumn();
            column.ColumnName = "EsProductoEspecifico";
            column.DataType = Type.GetType("System.Boolean");
            column.ReadOnly = false;
            _DTProductosSeleccionados.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "VendidoComoAgregado";
            column.DataType = Type.GetType("System.Boolean");
            column.ReadOnly = false;
            column.DefaultValue = false;
            _DTProductosSeleccionados.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "CantidadExistencia";
            column.DataType = Type.GetType("System.Int32");
            column.ReadOnly = false;
            column.DefaultValue = 0;
            _DTProductosSeleccionados.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "CantidadEntregada";
            column.DataType = Type.GetType("System.Int32");
            column.ReadOnly = false;
            column.DefaultValue = 0;
            _DTProductosSeleccionados.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "PorcentajeDescuento";
            column.DataType = Type.GetType("System.Decimal");
            column.ReadOnly = false;
            column.DefaultValue = 0;
            _DTProductosSeleccionados.Columns.Add(column);

            //TipoPrecioSeleccionado
            column = new DataColumn();
            column.ColumnName = "NumeroPrecioSeleccionado";
            column.DataType = Type.GetType("System.String");
            column.ReadOnly = false;
            column.DefaultValue = '1';
            _DTProductosSeleccionados.Columns.Add(column);

            //NumeroOrdenInsertado
            column = new DataColumn();
            column.ColumnName = "NumeroOrdenInsertado";
            column.DataType = Type.GetType("System.Int32");
            column.ReadOnly = false;
            column.AutoIncrement = true;
            _DTProductosSeleccionados.Columns.Add(column);

            
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = _DTProductosSeleccionados.Columns["Código Producto"];
            _DTProductosSeleccionados.PrimaryKey = PrimaryKeyColumns;

            

            _DTProductosSeleccionados.TableName = "ProductosDetalle";
            _DTProductosBusqueda.TableName = "ProductosBusqueda";

            DSdatosVentaTemporal.Tables.Add(_DTProductosSeleccionados);
            DSdatosVentaTemporal.Tables.Add(_DTProductosBusqueda);
            DSdatosVentaTemporal.DataSetName = "Productos";
            DTProductoSeleccionadosCopia = _DTProductosSeleccionados.Copy();
            DTProductosSeleccionadosMonedaSistema = _DTProductosSeleccionados.Copy();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtCantidadExistenciaBuscar.Text) && String.IsNullOrEmpty(txtBoxNombreProducto.Text))
            {
                MessageBox.Show(this, "Aun no ha Ingresado los datos Necesarios para realizar la Busqueda" + Environment.NewLine + "Por Favor Proceda a insertarlos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);                
                txtCantidadExistenciaBuscar.Focus();
                txtCantidadExistenciaBuscar.SelectAll();                
                return;
            }
            int CantidadBusqueda = 0;
            if (!String.IsNullOrEmpty(txtCantidadExistenciaBuscar.Text) && Int32.TryParse(txtCantidadExistenciaBuscar.Text, out CantidadBusqueda))
            {
                if (String.IsNullOrEmpty(txtBoxNombreProducto.Text))
                {
                    MessageBox.Show("Aún no ha ingresado el Texto de Busqueda");
                    txtBoxNombreProducto.Focus();
                    txtBoxNombreProducto.SelectAll();
                    return;
                }
                if (TipoTransaccion == 'C') CantidadBusqueda = -1000000;
                _DTProductosBusqueda = _TransaccionesUtilidadesCLN.buscarProductoParaTransaccion(NumeroAgencia, 
                    txtBoxNombreProducto.Text, CantidadBusqueda, CamposBusqueda, cBBusquedaExacta.Checked, 
                    int.Parse(cBoxMonedaCotizacion.SelectedValue.ToString()));
                
                bdnSourceProductos.DataSource = _DTProductosBusqueda;
                lblRegistosEncontrados.Text = "Nro de Registros Encontrados : " + _DTProductosBusqueda.Rows.Count.ToString();
                if (_DTProductosBusqueda.Rows.Count == 0)
                {
                    toolStripStatusLabel2.Text = "";
                    toolStripStatusLabel4.Text = "";
                    txtBoxNombreProducto.Focus();
                    txtBoxPrecio.Text = "0.00";
                    MessageBox.Show(this, "No se Encontro ningún producto con los parametros de entrada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                txtBoxNombreProducto.Focus();
                txtBoxNombreProducto.SelectAll();
            }
            else
            {
                MessageBox.Show("No puede realizar una Busqueda con los parametros Ingresados");
            }
        }

        private void checkCodigoProducto_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCodigoProducto.Checked)
                BuscarCodigoProducto = "1";
            else
                BuscarCodigoProducto = "0";
            CamposBusqueda = BuscarCodigoProducto + BuscarCodigoFabricante + BuscarNombreProducto1 + BuscarNombreProducto2 + BuscarNombreProducto3 + BuscarAgencia;
        }

        private void checkCodigoFabrica_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCodigoFabrica.Checked)
                BuscarCodigoFabricante = "1";
            else
                BuscarCodigoFabricante = "0";
            CamposBusqueda = BuscarCodigoProducto + BuscarCodigoFabricante + BuscarNombreProducto1 + BuscarNombreProducto2 + BuscarNombreProducto3 + BuscarAgencia;
        }

        private void checkNombreProd1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNombreProd1.Checked)
            {
                BuscarNombreProducto1 = "1";
                checkNombreProd2.Checked = false;
                checkNombreProd3.Checked = false;
            }
            else
                BuscarNombreProducto1 = "0";
            CamposBusqueda = BuscarCodigoProducto + BuscarCodigoFabricante + BuscarNombreProducto1 + BuscarNombreProducto2 + BuscarNombreProducto3 + BuscarAgencia;
        }

        private void checkNombreProd2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNombreProd2.Checked)
            {
                BuscarNombreProducto2 = "1";
                checkNombreProd1.Checked = false;
                checkNombreProd3.Checked = false;
            }
            else
                BuscarNombreProducto2 = "0";
            CamposBusqueda = BuscarCodigoProducto + BuscarCodigoFabricante + BuscarNombreProducto1 + BuscarNombreProducto2 + BuscarNombreProducto3 + BuscarAgencia;
        }

        private void checkNombreProd3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNombreProd3.Checked)
            {
                BuscarNombreProducto3 = "1";
                checkNombreProd1.Checked = false;
                checkNombreProd2.Checked = false;
            }
            else
                BuscarNombreProducto3 = "0";
            CamposBusqueda = BuscarCodigoProducto + BuscarCodigoFabricante + BuscarNombreProducto1 + BuscarNombreProducto2 + BuscarNombreProducto3 + BuscarAgencia;            
        }

        private void txtCantidadExistenciaBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click(sender, e as EventArgs);
                if (_DTProductosBusqueda.Rows.Count == 0)
                {
                    txtBoxNombreProducto.Focus();
                    txtBoxNombreProducto.SelectAll();
                    return;
                }
            }
        }

        private void txtCantidadExistenciaBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & (Keys)e.KeyChar != Keys.Enter)
            {
                txtCantidadExistenciaBuscar.SelectionStart = 0;
                txtCantidadExistenciaBuscar.SelectionLength = txtCantidadExistenciaBuscar.Text.Length;
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
                return;
            }
        }

        private void txtBoxNombreProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click(sender, e as EventArgs);
                if (_DTProductosBusqueda.Rows.Count == 0)
                {
                    txtBoxNombreProducto.Focus();
                    txtBoxNombreProducto.SelectAll();
                    return;
                }
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                if (dGVProductosBusqueda.RowCount > 0)
                {
                    dGVProductosBusqueda.Focus();
                    dGVProductosBusqueda.Columns[columnaNombreProducto].Selected = true;
                    dGVProductosBusqueda.CurrentCell = dGVProductosBusqueda.Rows[0].Cells[columnaNombreProducto];
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.txtBoxNombreProducto.Clear();
            }
        }

        private void nUpDownCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBoxPrecio.Focus(); 
        }

        private void rButtonPrecio1_CheckedChanged(object sender, EventArgs e)
        {
            if (rButtonPrecio1.Checked && dGVProductosBusqueda.RowCount > 0)
            {
                txtBoxPrecio.Text = dGVProductosBusqueda.CurrentRow.Cells[3].Value.ToString();
                TipoPrecioSeleccionado = '1';
            }
        }

        private void rButtonPrecio2_CheckedChanged(object sender, EventArgs e)
        {
            if (rButtonPrecio2.Checked && dGVProductosBusqueda.RowCount > 0)
            {
                txtBoxPrecio.Text = dGVProductosBusqueda.CurrentRow.Cells[4].Value.ToString();
                TipoPrecioSeleccionado = '2';
            }
        }

        private void rButtonPrecio3_CheckedChanged(object sender, EventArgs e)
        {
            if (rButtonPrecio3.Checked && dGVProductosBusqueda.RowCount > 0)
            {
                txtBoxPrecio.Text = dGVProductosBusqueda.CurrentRow.Cells[5].Value.ToString();
                TipoPrecioSeleccionado = '3';
            }
        }

        private void txtBoxPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cargarProductoparaVenta();
            }
            FProductosBusqueda2_KeyDown(sender, e);
        }

        private void dGVProductosBusqueda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarProductoparaVenta();
        }

        private void dGVProductosBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                isEnterFromTableProductosBusqueda = true;
                nUpDownCantidad.Focus();
                nUpDownCantidad.Value = 1;
                nUpDownCantidad.Select(0, nUpDownCantidad.ToString().Length);

                //if (dGVProductosBusqueda.Rows.Count > 1)
                //{
                //    dGVProductosBusqueda.Rows[dGVProductosBusqueda.Rows.Count - 2].Selected = true;                    
                //}
            }
            if (e.KeyCode == Keys.Escape)
            {
                txtBoxNombreProducto.Clear();
                txtBoxNombreProducto.Focus();
            }
            FProductosBusqueda2_KeyDown(sender, e);
        }

        private void dGVProductosBusqueda_Leave(object sender, EventArgs e)
        {
            if (isEnterFromTableProductosBusqueda && dGVProductosBusqueda.Rows.Count >= 0)
            {
                if (dGVProductosBusqueda.CurrentRow.Index == 0)
                {
                    dGVProductosBusqueda.CurrentCell = dGVProductosBusqueda.Rows[0].Cells[1];
                    dGVProductosBusqueda.Rows[0].Selected = true;
                }
                else
                {
                    dGVProductosBusqueda.CurrentCell = dGVProductosBusqueda.Rows[dGVProductosBusqueda.CurrentRow.Index - 1].Cells[1];
                    dGVProductosBusqueda.Rows[dGVProductosBusqueda.CurrentRow.Index].Selected = true;
                }

                isEnterFromTableProductosBusqueda = false;
            }
        }

        private void dGVProductosBusqueda_SelectionChanged(object sender, EventArgs e)
        {
            if (dGVProductosBusqueda.Rows.Count > 0)
            {
                if (dGVProductosBusqueda.CurrentRow.Cells[columnaCodigo].Value.ToString().Length > 0)
                    toolStripStatusLabel2.Text = dGVProductosBusqueda.CurrentRow.Cells[columnaCodigo].Value.ToString();

                else
                    toolStripStatusLabel2.Text = "Codigo Inexistente";
                if (dGVProductosBusqueda.CurrentRow.Cells[columnaNombreProducto].Value.ToString().Length > 0)
                    toolStripStatusLabel4.Text = dGVProductosBusqueda.CurrentRow.Cells[columnaNombreProducto].Value.ToString();
                else
                    toolStripStatusLabel4.Text = "Producto Inexistente";
                if (dGVProductosBusqueda.RowCount == 0)
                {
                    txtBoxPrecio.Text = "0.00";
                    return;
                }
                if (TipoTransaccion == 'C')
                {
                    if (dGVProductosBusqueda.CurrentRow.Cells[2].Value.ToString().Length > 0)
                        txtBoxPrecio.Text = dGVProductosBusqueda.CurrentRow.Cells[2].Value.ToString();
                    else
                        txtBoxPrecio.Text = "0.00";
                }
                else if (TipoTransaccion == 'V' || TipoTransaccion == 'T')
                {
                    if (dGVProductosBusqueda.CurrentCell.ColumnIndex > 1 && dGVProductosBusqueda.CurrentCell.ColumnIndex < 9)
                    {
                        if (dGVProductosBusqueda.CurrentCell.ColumnIndex == 4)
                        {
                            txtBoxPrecio.Text = dGVProductosBusqueda.CurrentRow.Cells[4].Value.ToString();
                            TipoPrecioSeleccionado = '2';
                        }
                        else if (dGVProductosBusqueda.CurrentCell.ColumnIndex == 5)
                        {
                            txtBoxPrecio.Text = dGVProductosBusqueda.CurrentRow.Cells[5].Value.ToString();
                            TipoPrecioSeleccionado = '3';
                        }
                        else
                        {
                            txtBoxPrecio.Text = dGVProductosBusqueda.CurrentRow.Cells[3].Value.ToString();
                            TipoPrecioSeleccionado = '1';
                        }                        
                    }
                    else
                    {
                        if (rButtonPrecio1.Checked)
                        {
                            txtBoxPrecio.Text = dGVProductosBusqueda.CurrentRow.Cells[3].Value.ToString();
                            TipoPrecioSeleccionado = '1';
                        }
                        if (rButtonPrecio2.Checked)
                        {
                            txtBoxPrecio.Text = dGVProductosBusqueda.CurrentRow.Cells[4].Value.ToString();
                            TipoPrecioSeleccionado = '2';
                        }
                        if (rButtonPrecio3.Checked)
                        {
                            txtBoxPrecio.Text = dGVProductosBusqueda.CurrentRow.Cells[5].Value.ToString();
                            TipoPrecioSeleccionado = '3';
                        }                        
                    }
                }
            }
        }

        private void FProductosBusqueda2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
                btnConfirmar_Click(sender, e as EventArgs);
            if (e.Control && e.KeyCode == Keys.C)
                btnLimpiar_Click(sender, e as EventArgs);
            if (e.KeyCode == Keys.Escape)
                btnCancelar_Click(sender, e as EventArgs);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            _DTProductosSeleccionados.Clear();
            DTProductoSeleccionadosCopia.Clear();
            DTProductosSeleccionadosMonedaSistema.Clear();
            _DTProductosSeleccionados.AcceptChanges();
            DTProductoSeleccionadosCopia.AcceptChanges();
            DTProductosSeleccionadosMonedaSistema.AcceptChanges();
            lblPrecioTotal.Text = "0.00" ;
            txtBoxNombreProducto.Clear();
            txtBoxNombreProducto.Focus();

            _DTProductosBusqueda.Clear();
            _DTProductosBusqueda.AcceptChanges();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            _DTProductosSeleccionados.AcceptChanges();
            DTProductoSeleccionadosCopia.AcceptChanges();            
            if (TipoTransaccion == 'V' || TipoTransaccion == 'T')
            {
                int indice = 0;
                String ProductosInexistentes = "";                
                
                indicesProductosExistenciaInalcanzable.Clear(); indice = 0;
                foreach (DataRow fila in _DTProductosSeleccionados.Rows)
                {
                    //revisar la existencia de cada producto
                    //if (fila.RowState != DataRowState.Deleted 
                    //    && Int32.Parse(_InventariosProductosCLN.ObtenerInventarioProducto(NumeroAgencia, fila[0].ToString()).Rows[0][2].ToString()) < Int32.Parse(fila[2].ToString()))
                    //{
                    //    indicesProductosExistenciaInalcanzable.Add(indice);
                    //    ProductosInexistentes += "\t " + fila[1].ToString() + "  " + Environment.NewLine;
                    //}
                    //indice++;
                    //DTProductosSeleccionadosMonedaSistema.Rows[_DTProductosSeleccionados.Rows.IndexOf(fila)]["Cantidad"]
                    //    = fila["Cantidad"];
                    //DTProductosSeleccionadosMonedaSistema.Rows[_DTProductosSeleccionados.Rows.IndexOf(fila)]["Garantia"]
                    //    = fila["Garantia"];
                    //DTProductosSeleccionadosMonedaSistema.Rows[_DTProductosSeleccionados.Rows.IndexOf(fila)]["CantidadEntregada"]
                    //    = fila["CantidadEntregada"];
                }
                DTProductosSeleccionadosMonedaSistema.AcceptChanges();
                this.detalleConfirmado = true;
                if (indicesProductosExistenciaInalcanzable.Count > 0 && TipoTransaccion == 'V')
                {
                    if (MessageBox.Show(this, "Existe productos seleccionados cuya Cantidad No es Suficiente en Almacenes :" + Environment.NewLine + ProductosInexistentes + Environment.NewLine + Environment.NewLine + "¿Desea Vender La Cantidad Existente Actualmente en Almacenes?", "Productos Inexistentes", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        int indexLista = 0;
                        int cantidadMinima = 0;
                        for (int i = 0; i < indicesProductosExistenciaInalcanzable.Count; i++)
                        {
                            indexLista = Int16.Parse(indicesProductosExistenciaInalcanzable[i].ToString());
                            //cantidadMinima = Int32.Parse(_InventariosProductosCLN.ObtenerInventarioProducto(NumeroAgencia, _DTProductosSeleccionados.Rows[indexLista][0].ToString()).Rows[0][2].ToString());
                            _DTProductosSeleccionados.Rows[indexLista].BeginEdit();
                            _DTProductosSeleccionados.Rows[indexLista][2] = cantidadMinima > 0 ? cantidadMinima : 1;
                            _DTProductosSeleccionados.Rows[indexLista].AcceptChanges();
                        }                        
                        TransaccionConfirmada = true;
                        this.Hide();
                    }
                    else
                    {
                        if (MessageBox.Show(this, "¿Desea Continuar la Venta con la Cantidad Escogida? Tome en cuenta que debe Reabastecer su Inventario si Continua", "Productos Inalcanzables", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            dtGridViewProductosSeleccionados.Rows[Int32.Parse(indicesProductosExistenciaInalcanzable[0].ToString())].Selected = true;
                            dtGridViewProductosSeleccionados.Columns[2].Selected = true;
                            dtGridViewProductosSeleccionados.CurrentCell = dtGridViewProductosSeleccionados.Rows[Int32.Parse(indicesProductosExistenciaInalcanzable[0].ToString())].Cells[2];
                            dtGridViewProductosSeleccionados.Focus();
                        }
                        else
                        {
                            ExistenProductosInalcanzables = true;
                            TransaccionConfirmada = true;
                            this.Hide();
                        }

                    }
                }
                else
                {                    
                    TransaccionConfirmada = true;
                    this.Hide();
                }

            }

            if (TipoTransaccion == 'C')
            {
                TransaccionConfirmada = true;
                this.Hide();
            }

            if (TipoTransaccion == 'T')
            {
                TransaccionConfirmada = true;
                this.Hide();
            }
            _DTProductosSeleccionados.AcceptChanges();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _DTProductosSeleccionados.Clear();
            DTProductoSeleccionadosCopia.Clear();
            _DTProductosSeleccionados.AcceptChanges();
            DTProductoSeleccionadosCopia.AcceptChanges();
            this.Hide();
            this.detalleConfirmado = false;
        }
        /// <summary>
        /// Comprueba que el Precio introducido no sea menor al Precio Neto de Venta
        /// </summary>
        /// <param name="CodigoProducto">Nombre del Producto</param>
        /// <param name="precio_a_Validar">Precio al que se quiere vender el producto</param>
        /// <returns></returns>
        public bool isPrecioAceptable(String CodigoProducto, decimal precio_a_Validar)
        {
            decimal PrecioNeto = 0;
            PrecioNeto = _TransaccionesUtilidadesCLN.ObtenerPrecioMinimoDeProducto(NumeroAgencia, CodigoProducto);
            return precio_a_Validar < PrecioNeto ? false : true;
        }

        public void cargarProductoparaVenta()
        {
            if (dGVProductosBusqueda.CurrentRow != null)
            {
                string CodigoProductoBusqueda = null;
                try
                {
                    string nombreProducto = dGVProductosBusqueda.Rows[dGVProductosBusqueda.CurrentRow.Index].Cells["DGCNombreProducto"].Value.ToString();
                    string codigoProducto = dGVProductosBusqueda.Rows[dGVProductosBusqueda.CurrentRow.Index].Cells["DGCCodigoProducto"].Value.ToString().Trim();
                    CodigoProductoBusqueda = codigoProducto;
                    int tiempoGarantia = Int16.Parse(dGVProductosBusqueda.Rows[dGVProductosBusqueda.CurrentRow.Index].Cells["DGCTiempoGarantiaProducto"].Value.ToString());
                    int cantidadExistencia = Int32.Parse(dGVProductosBusqueda.Rows[dGVProductosBusqueda.CurrentRow.Index].Cells["DGCCantidadExistencia"].Value.ToString()); 
                    decimal precio = 0;
                    //if(TipoTransaccion == 'V' || TipoTransaccion =='T')
                    //    precio = Decimal.Parse(dGVProductosBusqueda.Rows[dGVProductosBusqueda.CurrentRow.Index].Cells[3].Value.ToString());
                    //if (TipoTransaccion == 'C')
                    //    precio = Decimal.Parse(dGVProductosBusqueda.Rows[dGVProductosBusqueda.CurrentRow.Index].Cells[2].Value.ToString());
                    //DGCPrecioUnitarioVenta1

                    precio = decimal.Parse(dGVProductosBusqueda.CurrentRow.Cells["DGCPrecioUnitarioVenta" +
                        (!checkConFactura.Checked ?
                        TipoPrecioSeleccionado.ToString()
                        : (int.Parse(TipoPrecioSeleccionado.ToString()) + 3).ToString())].Value.ToString());

                    //precio = decimal.Parse(
                    //    _DTProductosBusqueda.Rows[dGVProductosBusqueda.CurrentRow.Index][
                    //    !checkConFactura.Checked ?
                    //    "PrecioUnitarioVenta" + TipoPrecioSeleccionado
                    //    : "PrecioUnitarioVenta" + (int.Parse(TipoPrecioSeleccionado.ToString()) + 3).ToString()].ToString());
                        
                        
                    bool productoEspecifico = Boolean.Parse(dGVProductosBusqueda.Rows[dGVProductosBusqueda.CurrentRow.Index].Cells["DGCEsProductoEspecifico"].Value.ToString());
                    bool esAgregado = false;



                    isInsertingModeTableProductosBusqueda = true;
                    // isInserting = true;                    
                    //_DTProductosSeleccionados.Rows.Add(new object[] { codigoProducto, nombreProducto, nUpDownCantidad.Value, precio, nUpDownCantidad.Value * precio, tiempoGarantia, productoEspecifico, esAgregado, cantidadExistencia, 0, 0, TipoPrecioSeleccionado });
                    _DTProductosSeleccionados.Rows.Add(new object[] { codigoProducto, nombreProducto, 
                            nUpDownCantidad.Value, precio, nUpDownCantidad.Value * precio, 
                            tiempoGarantia, productoEspecifico, 
                            esAgregado, cantidadExistencia, 
                            nUpDownCantidad.Value, 0, 
                            TipoPrecioSeleccionado });
                    _DTProductosSeleccionados.AcceptChanges();



                    if ((TipoTransaccion == 'V') || (TipoTransaccion == 'T'))
                    {
                        DTProductosBusquedaMonedaSistema = _TransaccionesUtilidadesCLN.buscarProductoParaTransaccion(NumeroAgencia,
                            codigoProducto, 0, "100001", true, CodigoMonedaSistema);

                        DTProductosSeleccionadosMonedaSistema.Rows.Add(new object[]{
                                codigoProducto, nombreProducto, nUpDownCantidad.Value, 
                                DTProductosBusquedaMonedaSistema.Rows[0]["PrecioUnitarioVenta" +TipoPrecioSeleccionado.ToString()],
                                decimal.Parse(DTProductosBusquedaMonedaSistema.Rows[0]["PrecioUnitarioVenta" +TipoPrecioSeleccionado.ToString()].ToString())
                                * nUpDownCantidad.Value , tiempoGarantia, productoEspecifico,
                                esAgregado, cantidadExistencia, nUpDownCantidad.Value, 0, TipoPrecioSeleccionado
                        });

                        DTProductosBusquedaMonedaSistema.AcceptChanges();
                    }


                    if ((TipoTransaccion == 'V' || TipoTransaccion == 'T') && !isPrecioAceptable(codigoProducto, precio))
                    {
                        

                        

                        if (MessageBox.Show(this, "El Precio Introducido del Producto " + nombreProducto + ", es Menor al monto de venta Registrado en Inventario." + Environment.NewLine + " ¿Está Seguro de Vender el Producto a este Precio?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            //DTGridViewProductosSeleccionados.CurrentCell.Value = DTGridViewProductosSeleccionados.CurrentCell.form
                            dtGridViewProductosSeleccionados.Rows[dtGridViewProductosSeleccionados.Rows.Count - 1].Cells[columnaPrecioUnitario].Value = dGVProductosBusqueda.Rows[dGVProductosBusqueda.CurrentRow.Index].Cells[3].Value;
                            dtGridViewProductosSeleccionados.CurrentCell = dtGridViewProductosSeleccionados[columnaPrecioUnitario, dtGridViewProductosSeleccionados.RowCount - 1];
                            dtGridViewProductosSeleccionados.BeginEdit(true);
                        }
                        else
                        {
                            dtGridViewProductosSeleccionados.CurrentCell = dtGridViewProductosSeleccionados[columnaNombreProducto, dtGridViewProductosSeleccionados.RowCount - 1];
                            dtGridViewProductosSeleccionados.CurrentCell.ErrorText = "Ha Dedicido Vender este Producto a un precio Menor al Registrado en Inventarios";
                            txtBoxNombreProducto.Focus();
                            txtBoxNombreProducto.SelectAll();
                        }
                    }
                    else
                    {
                        txtBoxNombreProducto.Focus();
                        txtBoxNombreProducto.SelectAll();
                    }                    
                    dtGridViewProductosSeleccionados.FirstDisplayedScrollingRowIndex = _DTProductosSeleccionados.Rows.Count - 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "No puede Seleccionar un Producto que ya Se encuentra en el Detalle de Productos Seleccionados." 
                        + Environment.NewLine + "Seleccione otro Producto. O probablemente ocurrio la siguiente Excepcion " + ex.Message,
                        "Productos Seleccionados Repetidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (!string.IsNullOrEmpty(CodigoProductoBusqueda))
                    {
                        DataRow[] DRProductos = _DTProductosSeleccionados.Select("[Código Producto] = '" + CodigoProductoBusqueda + "'");
                        if (DRProductos != null)
                        {
                            int indiceFila = _DTProductosSeleccionados.Rows.IndexOf(DRProductos[0]);
                            dtGridViewProductosSeleccionados.CurrentCell = dtGridViewProductosSeleccionados[0, indiceFila];
                            dtGridViewProductosSeleccionados.CurrentRow.Selected = true;
                        }
                    }
                    //throw;
                }
            }
        }

        private void dtGridViewProductosSeleccionados_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //dtGridViewProductosSeleccionados.CurrentCell.ErrorText = "";            
            if (dtGridViewProductosSeleccionados.Rows[e.RowIndex].IsNewRow) { return; }
            bool esAgregadoProductoSeleccionado = false;            
            esAgregadoProductoSeleccionado = Boolean.Parse(_DTProductosSeleccionados.Rows[e.RowIndex][7].ToString());
            int CantidadNuevaDeEntrega;
            decimal PrecioNuevo = 0;
            this.dtGridViewProductosSeleccionados.Rows[e.RowIndex].ErrorText = "";
            if (this.dtGridViewProductosSeleccionados.Rows[e.RowIndex].IsNewRow) { return; }

            if (this.dtGridViewProductosSeleccionados.IsCurrentCellDirty)
            {
                switch (this.dtGridViewProductosSeleccionados.Columns[e.ColumnIndex].Name)
                {

                    case "DGCCantidadSeleccionada": 
                        if (e.FormattedValue.ToString().Trim().Length < 1)
                        {
                            this.dtGridViewProductosSeleccionados.Rows[e.RowIndex].ErrorText = "   La Cantidad es necesaria y no puede estar vacia.";
                            e.Cancel = true;
                        }
                        else if (!int.TryParse(e.FormattedValue.ToString(), out CantidadNuevaDeEntrega) || CantidadNuevaDeEntrega <= 0)
                        {
                            this.dtGridViewProductosSeleccionados.Rows[e.RowIndex].ErrorText = "   La Cantidad debe ser un entero positivo.";
                            e.Cancel = true;
                            return;
                        }
                        break;
                    case "DGCPrecioUnitario":
                        if (e.FormattedValue.ToString().Trim().Length < 1)
                        {
                            this.dtGridViewProductosSeleccionados.Rows[e.RowIndex].ErrorText = "   El Precio es necesario y no puede estar vacio.";
                            e.Cancel = true;
                        }
                        else if (!decimal.TryParse(e.FormattedValue.ToString(), out PrecioNuevo) || PrecioNuevo <= 0)
                        {
                            this.dtGridViewProductosSeleccionados.Rows[e.RowIndex].ErrorText = "   El precio debe ser un entero positivo.";
                            e.Cancel = true;
                            return;
                        }

                        if (!esAgregadoProductoSeleccionado
                            //&& dtGridViewProductosSeleccionados.CurrentCell.ErrorText.Trim().Length == 0 
                            && (TipoTransaccion == 'V' || TipoTransaccion == 'T'))
                        {
                            //decimal precioCambiado = Decimal.Parse(dtGridViewProductosSeleccionados.CurrentRow.Cells[columnaPrecioUnitario].Value.ToString());
                            decimal precioCambiado = Decimal.Parse(e.FormattedValue.ToString());
                            string CodigoProducto = dtGridViewProductosSeleccionados.CurrentRow.Cells[columnaCodigo].Value.ToString();
                            string NombreProducto = dtGridViewProductosSeleccionados.CurrentRow.Cells[columnaNombreProducto].Value.ToString();
                            if (!isPrecioAceptable(CodigoProducto, precioCambiado))
                            {
                                if (MessageBox.Show(this, "El Precio Introducido del Producto " + NombreProducto + ", es Menor al monto de venta Registrado en Inventario." + Environment.NewLine + " ¿Está Seguro de Vender el Producto a este Precio?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                {
                                    e.Cancel = true;
                                    return;
                                }
                                else
                                {
                                    dtGridViewProductosSeleccionados.CurrentCell.ErrorText = "Ha Dedicido Vender este Producto a un precio Menor al Registrado en Inventarios";
                                    dtGridViewProductosSeleccionados.CurrentRow.ErrorText = "Ha Dedicido Vender este Producto a un precio Menor al Registrado en Inventarios";
                                    e.Cancel = false;
                                }
                            }
                            else
                            {
                                dtGridViewProductosSeleccionados.CurrentCell.ErrorText = "";
                            }

                        }
                        else
                        {
                            dtGridViewProductosSeleccionados.CurrentCell.ErrorText = "";
                        }

                        break;
                }

            }
        }

        private void dtGridViewProductosSeleccionados_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            _DTProductosSeleccionados.AcceptChanges();
            if (_DTProductosSeleccionados.Rows.Count > 0 && dtGridViewProductosSeleccionados.CurrentCell != null)
            {
                if (e.ColumnIndex == 5)
                {
                    //MessageBox.Show("cambio  " + dtGridViewProductosSeleccionados[5, e.RowIndex].Value.ToString());
                    _DTProductosSeleccionados.Rows[e.RowIndex][columnaPrecioTotal + 1] = dtGridViewProductosSeleccionados[5, e.RowIndex].Value;
                }
                //Si la Cantidad seleccionada cambio mediante el NumericUpdDownColumn
                if (e.ColumnIndex == 2 &&
                    _DTProductosSeleccionados.Rows[e.RowIndex].RowState != DataRowState.Deleted
                    && dtGridViewProductosSeleccionados.CurrentRow.Cells[columnaCantidad].Value != null
                    && dtGridViewProductosSeleccionados.CurrentRow.Cells[columnaPrecioUnitario].Value != null)
                {
                    dtGridViewProductosSeleccionados.CurrentRow.Cells[columnaPrecioTotal].Value = Int32.Parse(dtGridViewProductosSeleccionados.CurrentRow.Cells[columnaCantidad].Value.ToString()) * Decimal.Parse(dtGridViewProductosSeleccionados.CurrentRow.Cells[columnaPrecioUnitario].Value.ToString());

                    _DTProductosSeleccionados.Rows[e.RowIndex].BeginEdit();
                    _DTProductosSeleccionados.Rows[dtGridViewProductosSeleccionados.CurrentRow.Index][columnaPrecioTotal] = dtGridViewProductosSeleccionados.CurrentRow.Cells[columnaPrecioTotal].Value;
                    _DTProductosSeleccionados.Rows[dtGridViewProductosSeleccionados.CurrentRow.Index][columnaCantidad] = dtGridViewProductosSeleccionados.CurrentRow.Cells[columnaCantidad].Value;
                    _DTProductosSeleccionados.Rows[dtGridViewProductosSeleccionados.CurrentRow.Index]["CantidadEntregada"] = _DTProductosSeleccionados.Rows[dtGridViewProductosSeleccionados.CurrentRow.Index]["Cantidad"];
                    _DTProductosSeleccionados.Rows[e.RowIndex].EndEdit();
                    _DTProductosSeleccionados.Rows[e.RowIndex].AcceptChanges();
                    

                }

                //si ha cambiado el precio del producto para la transacción
                if (e.ColumnIndex == 3 && dtGridViewProductosSeleccionados[3, e.RowIndex].Value != null 
                    && !dtGridViewProductosSeleccionados.CurrentRow.IsNewRow && e.ColumnIndex == 3 
                    && dtGridViewProductosSeleccionados[4, e.RowIndex].Value != null)
                {

                    string CodigoProducto = _DTProductosSeleccionados.Rows[e.RowIndex][columnaCodigo].ToString();
                    string TipoPrecioSeleccionado = _DTProductosSeleccionados.Rows[e.RowIndex]["NumeroPrecioSeleccionado"].ToString();
                    decimal PrecioEstandar = _TransaccionesUtilidadesCLN.ObtenerPrecioRelativoProducto(NumeroAgencia, CodigoProducto, TipoPrecioSeleccionado, checkConFactura.Checked);
                    decimal PrecioNuevo = Decimal.Parse(_DTProductosSeleccionados.Rows[e.RowIndex][columnaPrecioUnitario].ToString());

                    decimal PrecioDiferencia = PrecioEstandar - PrecioNuevo;
                    if (PrecioDiferencia > 0)
                    {
                        _DTProductosSeleccionados.Rows[e.RowIndex]["PorcentajeDescuento"] = decimal.Round(PrecioDiferencia * 100 / PrecioEstandar, 2);
                        _DTProductosSeleccionados.Rows[e.RowIndex]["NumeroPrecioSeleccionado"] = "P";
                        dtGridViewProductosSeleccionados[DGCPrecioUnitario.Index, e.RowIndex].ErrorText = "Ha Dedicido Vender este Producto a un precio Menor al Registrado en Inventarios";
                    }
                    else if (PrecioDiferencia < 0)
                    {
                        _DTProductosSeleccionados.Rows[e.RowIndex]["NumeroPrecioSeleccionado"] = "P";
                    }
                                        
                    dtGridViewProductosSeleccionados.Columns[columnaPrecioTotal].ReadOnly = false;
                    _DTProductosSeleccionados.Rows[e.RowIndex][columnaPrecioTotal] = Int32.Parse(_DTProductosSeleccionados.Rows[e.RowIndex][columnaCantidad].ToString()) * PrecioNuevo;
                    dtGridViewProductosSeleccionados.Columns[columnaPrecioTotal].ReadOnly = true;
                    actualizarPrecioModificado(e.RowIndex);


                }
                //_DTProductosSeleccionados.AcceptChanges();
            }
        }

        public void actualizarPrecioModificado(int FilaModificada)
        {            
            int CodigoMonedaSeleccionada = int.Parse(cBoxMonedaCotizacion.SelectedValue.ToString());
            bool conFactura = checkConFactura.Checked;
            decimal PrecioModificado = decimal.Parse(_DTProductosSeleccionados.Rows[FilaModificada]["Precio"].ToString());
            if (CodigoMonedaSeleccionada == CodigoMonedaSistema)
            {
                if (!conFactura)
                    DTProductosSeleccionadosMonedaSistema.Rows[FilaModificada]["Precio"] = PrecioModificado;
                else
                    DTProductosSeleccionadosMonedaSistema.Rows[FilaModificada]["Precio"] = PrecioModificado / ( 1 + (PorcentajeImpuestoIVA / 100));
            }
            else
            {
                decimal FactorCambioCotizacion = _TransaccionesUtilidadesCLN.ObtenerFactorCambioCotizacion(CodigoMonedaSistema,
                _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor(), CodigoMonedaSeleccionada);
                if (FactorCambioCotizacion <= -1)
                    FactorCambioCotizacion = _TransaccionesUtilidadesCLN.ObtenerFactorCambioCotizacion(CodigoMonedaSistema,
                    null, CodigoMonedaSeleccionada);
                decimal PrecioCambiadoFactor = PrecioModificado / FactorCambioCotizacion;

                if (conFactura)
                    DTProductosSeleccionadosMonedaSistema.Rows[FilaModificada]["Precio"] = PrecioCambiadoFactor / (1 + (PorcentajeImpuestoIVA / 100));
                else
                    DTProductosSeleccionadosMonedaSistema.Rows[FilaModificada]["Precio"] = PrecioCambiadoFactor;
            }

            DTProductosSeleccionadosMonedaSistema.Rows[FilaModificada].AcceptChanges();
        }


        public void cambiarMonedaPreciosFacturaBackup()
        {
            if (dtGridViewProductosSeleccionados.RowCount > 0)
            {                
                DataSet DSTemporal = new DataSet("Productos");
                DataTable DTProductosPreciosActualizados = DTProductosSeleccionadosMonedaSistema.Copy();
                DTProductosPreciosActualizados.Columns["Código Producto"].ColumnName = "CodigoProducto";
                DTProductosPreciosActualizados.PrimaryKey = null;
                DTProductosPreciosActualizados.Constraints.Clear();
                int i = 0;
                while (DTProductosPreciosActualizados.Columns.Count != 5)
                {
                    DataColumn DTColumnaX = DTProductosPreciosActualizados.Columns[i];
                    if (DTColumnaX.ColumnName.CompareTo("Precio") != 0
                        && DTColumnaX.ColumnName.CompareTo("PrecioTotal") != 0
                        && DTColumnaX.ColumnName.CompareTo("Cantidad") != 0
                        && DTColumnaX.ColumnName.CompareTo("NumeroPrecioSeleccionado") != 0
                        && DTColumnaX.ColumnName.CompareTo("CodigoProducto") != 0)
                    {
                        DTProductosPreciosActualizados.Columns.Remove(DTColumnaX);
                    }
                    else
                        i++;
                }
                DSTemporal.Tables.Add(DTProductosPreciosActualizados);
                string CadenaXML = DSTemporal.GetXml();
                if (int.Parse(cBoxMonedaCotizacion.SelectedValue.ToString()) == CodigoMonedaSistema)
                {
                    if (checkConFactura.Checked)
                    {
                        DTProductosPreciosActualizados = _TransaccionesUtilidadesCLN.CambiarMonedaProductosDetalleTransaccion(
                            NumeroAgencia, CodigoMonedaSistema, checkConFactura.Checked, CadenaXML);
                        foreach (DataRow DTProductoPrecio in DTProductosPreciosActualizados.Rows)
                        {
                            _DTProductosSeleccionados.Rows[DTProductosPreciosActualizados.Rows.IndexOf(DTProductoPrecio)]["Precio"]
                                = DTProductoPrecio["Precio"];
                            _DTProductosSeleccionados.Rows[DTProductosPreciosActualizados.Rows.IndexOf(DTProductoPrecio)]["PrecioTotal"]
                                = decimal.Parse(DTProductoPrecio["Precio"].ToString()) *
                                int.Parse(DTProductosSeleccionados.Rows[DTProductosPreciosActualizados.Rows.IndexOf(DTProductoPrecio)]["Cantidad"].ToString());
                        }
                    }
                    else
                    {
                        //_DTProductosSeleccionados = DTProductosSeleccionadosMonedaSistema.Copy();
                        //_DTProductosSeleccionados.RowChanged += new DataRowChangeEventHandler(_DTProductosSeleccionados_RowChanged);
                        foreach (DataRow DRFilaBackup in DTProductosSeleccionadosMonedaSistema.Rows)
                        {
                            //dtGridViewProductosSeleccionados["DGCPrecioUnitario", DTProductosSeleccionadosMonedaSistema.Rows.IndexOf(DRFilaBackup)].Value = DRFilaBackup["Precio"];
                            _DTProductosSeleccionados.Rows[DTProductosSeleccionadosMonedaSistema.Rows.IndexOf(DRFilaBackup)]["Precio"]
                                = DRFilaBackup["Precio"];
                            _DTProductosSeleccionados.Rows[DTProductosSeleccionadosMonedaSistema.Rows.IndexOf(DRFilaBackup)]["PrecioTotal"]
                                = decimal.Parse(DRFilaBackup["Precio"].ToString()) *
                                int.Parse(DTProductosSeleccionados.Rows[DTProductosSeleccionadosMonedaSistema.Rows.IndexOf(DRFilaBackup)]["Cantidad"].ToString());
                        }
                        DTProductosSeleccionados.AcceptChanges();
                    }
                }
                else
                {
                    DTProductosPreciosActualizados = _TransaccionesUtilidadesCLN.CambiarMonedaProductosDetalleTransaccion(
                        NumeroAgencia, int.Parse(cBoxMonedaCotizacion.SelectedValue.ToString()), checkConFactura.Checked, CadenaXML);
                    foreach (DataRow DTProductoPrecio in DTProductosPreciosActualizados.Rows)
                    {
                        _DTProductosSeleccionados.Rows[DTProductosPreciosActualizados.Rows.IndexOf(DTProductoPrecio)]["Precio"]
                            = DTProductoPrecio["Precio"];
                        _DTProductosSeleccionados.Rows[DTProductosPreciosActualizados.Rows.IndexOf(DTProductoPrecio)]["PrecioTotal"]
                            = decimal.Parse(DTProductoPrecio["Precio"].ToString()) *
                                int.Parse(DTProductosSeleccionados.Rows[DTProductosPreciosActualizados.Rows.IndexOf(DTProductoPrecio)]["Cantidad"].ToString());
                    }
                }
                _DTProductosSeleccionados.AcceptChanges();
                bdSourceProductosSeleccionados.DataSource = _DTProductosSeleccionados;
            }
        }


        private void dtGridViewProductosSeleccionados_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dtGridViewProductosSeleccionados.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            _DTProductosSeleccionados.AcceptChanges();            
            DTProductoSeleccionadosCopia.AcceptChanges();
            if (_DTProductosSeleccionados.Rows.Count == 0)
            {
                checkConFactura.Checked = false;
                esPrimeraVezFactura = false;
            }
            
        }

        private void dGVProductosBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsDigit(e.KeyChar))
            {
                txtBoxNombreProducto.Focus();
                txtBoxNombreProducto.Text = e.KeyChar.ToString();
                txtBoxNombreProducto.SelectionStart = 1;
            }
        }

        private void cBoxMonedaCotizacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxNombreProducto.Text) || dGVProductosBusqueda.RowCount > 0)
            {
                btnBuscar_Click(btnBuscar, e);
            }
            esPrimeraVezCambioCotizacionMoneda = true;
            if(sePuedeCambiarCotizacion)
                cambiarMonedaPreciosFacturaBackup();
        }

        
        public void cambiarMonedaFacturaPrecios()
        {
            if (dtGridViewProductosSeleccionados.RowCount > 0)
            {

                DataSet DSTemporal = new DataSet("Productos");
                DataTable DTProductosPreciosActualizados = DTProductoSeleccionadosCopia.Copy();
                DTProductosPreciosActualizados.PrimaryKey = null;
                DTProductosPreciosActualizados.Constraints.Clear();
                int i = 0;
                while (DTProductosPreciosActualizados.Columns.Count != 2)
                {
                    DataColumn DTColumnaX = DTProductosPreciosActualizados.Columns[i];
                    if (DTColumnaX.ColumnName.CompareTo("Precio") != 0 && DTColumnaX.ColumnName.CompareTo("PrecioTotal") != 0)
                    {
                        DTProductosPreciosActualizados.Columns.Remove(DTColumnaX);
                    }
                    else
                        i++;
                }
                DSTemporal.Tables.Add(DTProductosPreciosActualizados);

                if (int.Parse(cBoxMonedaCotizacion.SelectedValue.ToString()) == CodigoMonedaSistema)
                {
                    if (checkConFactura.Checked)
                    {
                        DTProductosPreciosActualizados = _TransaccionesUtilidadesCLN.CambiarMonedaProductosDetalleTransaccion(
                            NumeroAgencia, CodigoMonedaSistema, checkConFactura.Checked, DTProductosPreciosActualizados.DataSet.GetXml());
                        foreach (DataRow DTProductoPrecio in DTProductosPreciosActualizados.Rows)
                        {
                            _DTProductosSeleccionados.Rows[DTProductosPreciosActualizados.Rows.IndexOf(DTProductoPrecio)]["Precio"]
                                = DTProductoPrecio["Precio"];
                            _DTProductosSeleccionados.Rows[DTProductosPreciosActualizados.Rows.IndexOf(DTProductoPrecio)]["PrecioTotal"]
                                = DTProductoPrecio["PrecioTotal"];
                        }
                    }
                    else
                    {
                        _DTProductosSeleccionados = DTProductoSeleccionadosCopia.Copy();
                        _DTProductosSeleccionados.RowChanged +=new DataRowChangeEventHandler(_DTProductosSeleccionados_RowChanged);
                        _DTProductosSeleccionados.RowDeleted += new DataRowChangeEventHandler(_DTProductosSeleccionados_RowDeleted);
                    }
                }
                else
                {
                    DTProductosPreciosActualizados = _TransaccionesUtilidadesCLN.CambiarMonedaProductosDetalleTransaccion(
                        NumeroAgencia, int.Parse(cBoxMonedaCotizacion.SelectedValue.ToString()), checkConFactura.Checked, DTProductosPreciosActualizados.DataSet.GetXml());
                    foreach (DataRow DTProductoPrecio in DTProductosPreciosActualizados.Rows)
                    {
                        _DTProductosSeleccionados.Rows[DTProductosPreciosActualizados.Rows.IndexOf(DTProductoPrecio)]["Precio"]
                            = DTProductoPrecio["Precio"];
                        _DTProductosSeleccionados.Rows[DTProductosPreciosActualizados.Rows.IndexOf(DTProductoPrecio)]["PrecioTotal"]
                            = DTProductoPrecio["PrecioTotal"];
                    }
                }
                _DTProductosSeleccionados.AcceptChanges();
                bdSourceProductosSeleccionados.DataSource = _DTProductosSeleccionados;
            }
        }

        private void checkConFactura_CheckedChanged(object sender, EventArgs e)
        {
            //esPrimeraVezFactura = true;
            //cambiarMonedaFacturaPrecios(); 
            if(sePuedeCambiarCotizacion)
                cambiarMonedaPreciosFacturaBackup();
        }

        public void inhabilitarControlesParaCotizacion(bool estado)
        {
            btnBuscar.Enabled = !estado;
            txtBoxNombreProducto.Enabled = !estado;
            txtBoxPrecio.Enabled = !estado;
            btnAceptar.Enabled = !estado;
            cBoxMonedaCotizacion.Enabled = !estado;
            checkConFactura.Enabled = !estado;
            this.dtGridViewProductosSeleccionados.Enabled = !estado;
        }

        public void habilitarEvento()
        {
            _DTProductosSeleccionados.RowChanged+=new DataRowChangeEventHandler(_DTProductosSeleccionados_RowChanged);
            _DTProductosSeleccionados.RowDeleted += new DataRowChangeEventHandler(_DTProductosSeleccionados_RowDeleted);
        }

        public void limpiarControles()
        {
            checkCodigoFabrica.Checked = false;
            checkCodigoProducto.Checked = false;
            checkNombreProd1.Checked = true;
            checkNombreProd2.Checked = false;
            checkNombreProd3.Checked = false;
            txtBoxNombreProducto.Clear();
            txtBoxPrecio.Clear();
            nUpDownCantidad.Value = 1;
            rButtonPrecio1.Checked = true;
            txtCantidadExistenciaBuscar.Text = "1";
            toolStripStatusLabel2.Text = "";
            toolStripStatusLabel4.Text = "";
            checkConFactura.Checked = false;
            cBoxMonedaCotizacion.SelectedValue = CodigoMonedaSistema;
            _DTProductosBusqueda.Clear();
            //this._DTProductosSeleccionados.Clear();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            cargarProductoparaVenta();
        }

        private void btnRestablecerPrecios_Click(object sender, EventArgs e)
        {
            if (dtGridViewProductosSeleccionados.RowCount > 0)
            {

                DataSet DSTemporal = new DataSet("Productos");
                //DataTable DTProductosPreciosActualizados = DTProductosSeleccionadosMonedaSistema.Copy();
                //DTProductosPreciosActualizados.PrimaryKey = null;
                //DTProductosPreciosActualizados.Constraints.Clear();
                //DTProductosPreciosActualizados.Columns.Remove(DTProductosPreciosActualizados.Columns["Nombre Producto"]);
                //DTProductosPreciosActualizados.Columns["Codigo Producto"].ColumnName = "CodigoProducto";

                DataTable DTProductosPreciosActualizados = new DataTable("ProductosDetalle");
                DataColumn DCCodigoProducto = new DataColumn("Código Producto", Type.GetType("System.String"));                
                DataColumn DCCantidad = new DataColumn("Cantidad", Type.GetType("System.Int32"));
                DataColumn DCPrecioSeleccionado = new DataColumn("NumeroPrecioSeleccionado", Type.GetType("System.String"));
                DTProductosPreciosActualizados.Columns.AddRange(new DataColumn[]{DCCodigoProducto, DCCantidad, DCPrecioSeleccionado});

                foreach (DataRow DRFilaAntigua in DTProductosSeleccionadosMonedaSistema.Rows)
                {
                    DTProductosPreciosActualizados.ImportRow(DRFilaAntigua);
                }

                DTProductosPreciosActualizados.Columns[0].ColumnName = "CodigoProducto";
                DTProductosPreciosActualizados.AcceptChanges();

                DSTemporal.Tables.Add(DTProductosPreciosActualizados);

                checkConFactura.Checked = false;
                CBoxMonedas.SelectedValue = CodigoMonedaSistema;

                //MessageBox.Show(DTProductosPreciosActualizados.Columns[0].ColumnName + " " + DTProductosPreciosActualizados.Rows[0][0].ToString() + " " + DTProductosPreciosActualizados.Rows.Count.ToString());
                CLCAD.DSDoblones20GestionComercial2.ReestablecerMonedaProductosDetalleTransaccionDataTable
                    DTProductosReestablecidos = _TransaccionesUtilidadesCLN.ReestablecerMonedaProductosDetalleTransaccion(
                    NumeroAgencia, DSTemporal.GetXml());


                foreach (CLCAD.DSDoblones20GestionComercial2.ReestablecerMonedaProductosDetalleTransaccionRow
                    DRProductoReestablecido in DTProductosReestablecidos)
                {
                    _DTProductosSeleccionados.Rows[DTProductosReestablecidos.Rows.IndexOf(DRProductoReestablecido)]["Precio"] = 
                        DTProductosSeleccionadosMonedaSistema.Rows[DTProductosReestablecidos.Rows.IndexOf(DRProductoReestablecido)]["Precio"] =
                        DRProductoReestablecido.Precio;
                    _DTProductosSeleccionados.Rows[DTProductosReestablecidos.Rows.IndexOf(DRProductoReestablecido)]["PrecioTotal"] =
                        DTProductosSeleccionadosMonedaSistema.Rows[DTProductosReestablecidos.Rows.IndexOf(DRProductoReestablecido)]["PrecioTotal"] =
                        DRProductoReestablecido.PrecioTotal *
                        int.Parse(_DTProductosSeleccionados.Rows[DTProductosReestablecidos.Rows.IndexOf(DRProductoReestablecido)]["Cantidad"].ToString());
                }

                _DTProductosSeleccionados.AcceptChanges();
                bdSourceProductosSeleccionados.DataSource = _DTProductosSeleccionados;
            }

        }

        private void FProductosBusqueda2_Shown(object sender, EventArgs e)
        {
            sePuedeCambiarCotizacion = true;
            DataTable DTMonedas = cBoxMonedaCotizacion.DataSource as DataTable;

            lblPrecioTotal.Text = string.IsNullOrEmpty(_DTProductosSeleccionados.Compute("Sum(PrecioTotal)", "").ToString())
                ? " 0.00 " : _DTProductosSeleccionados.Compute("Sum(PrecioTotal)", "").ToString()
                + " " + DTMonedas.Rows[cBoxMonedaCotizacion.SelectedIndex]["MascaraMoneda"].ToString();
        }

        private void btnInventarios_Click(object sender, EventArgs e)
        {
            FInventarioProductos formInventarioProductos = new FInventarioProductos(NumeroAgencia, NumeroPC);
            formInventarioProductos.ShowDialog(this);
            formInventarioProductos.Dispose();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            //FAgregarEditarProducto formProductos = new FAgregarEditarProducto(true, false, false, true);
            ////formProductos.habilitarNuevoRegistroProducto(e);
            //formProductos.ShowDialog(this);
            //formProductos.Dispose();
        }
    }
}
