using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CLCLN;
using System.Collections;
using CLCLN.GestionComercial;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FProductosBusqueda : Form
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
        VentasProductosProcStoredCLN ventasProductosCLN = null;
        TransaccionesUtilidadesCLN TransaccionUtilidadadesCLN = null;
        InventariosProductosCLN invetariosProductosCLN = null;
        #endregion
        
        #region Datos y DataTable

        DataSet DSdatosVentaTemporal = null;        

        DataTable _DTProductosSeleccionados = null;
        DataTable _DTProductosBusqueda = null;
        DataTable DTProductosDisponibles = null;
        DataTable _DTProductosComboBox = null;

        #endregion
        
        WFADoblones20.Utilitarios.DataGridViewNumericUpDownColumn numericColumn = null;
        DataGridViewTextBoxColumn comboBoxNombresProducto = null;
        
        ArrayList indicesProductosExistenciaInalcanzable = new ArrayList();
        ArrayList ListaCodigoEliminados = new ArrayList();
        public bool TransaccionConfirmada = false;
        bool primeraVez = false;
        private int NumeroAgencia = 1;
        private int NumeroPC;
        int CodigoMonedaSistema = 1;
        bool isProductosComboBoxCargados = false;
        public bool ExistenProductosInalcanzables = false;

        private String BuscarCodigoProducto = "0";
        private String BuscarCodigoFabricante = "0";
        private String BuscarNombreProducto1 = "0";
        private String BuscarNombreProducto2 = "0";
        private String BuscarNombreProducto3 = "0";
        private String BuscarAgencia = "1";
        private char TipoPrecioSeleccionado = '1';
        private String CamposBusqueda = "001001";
        #region Propiedades del Formulario (DataTable)

        public DataTable DTProductosComboBox
        {
            get
            {
                if (_DTProductosComboBox == null)
                    _DTProductosComboBox = new DataTable();
                return _DTProductosComboBox;
            }
            set
            {
                _DTProductosComboBox = value;
            }
        }
        public DataTable DTProductosSeleccionados
        {
            get
            {
                return this._DTProductosSeleccionados;
            }
            set
            {
                this._DTProductosSeleccionados = value;
            }
        }

        public DataTable DTProductosBusqueda
        {
            get
            {
                return this._DTProductosBusqueda;
            }
            set
            {
                this._DTProductosBusqueda = value;
            }
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
        #endregion


        /// <summary>
        /// La Busqueda de productos se Realizara de acuerdo al Tipo de Transacción
        /// 'V' VENTAS ->Restricción de productos cuya existencia no sea lo suficiente
        /// 'C' COMPRAS->Ninguna Restricción 
        /// 'T' COTIZACIONES -> no se debe revisar los productos Especificos
        /// </summary>
        private char TipoTransaccion = 'V';

        public FProductosBusqueda(int NumeroAgencia, int NumeroPC, char TipoTransaccion, int CodigoMonedaSistema)
        {
            InitializeComponent();
            this.TipoTransaccion = TipoTransaccion;
            this.NumeroAgencia = NumeroAgencia;
            this.NumeroPC = NumeroPC;
            this.CodigoMonedaSistema = CodigoMonedaSistema;
            DSdatosVentaTemporal = new DataSet(); 
            cargarCaracterizticasProductos();
            crearTablasTemporales();
                                   

            bdSourceProductosSeleccionados.DataSource = _DTProductosSeleccionados;
            bdnSourceProductos.DataSource = _DTProductosBusqueda.DefaultView;

            dGVProductosBusqueda.DataSource = bdnSourceProductos;            
            //dGVProductosBusqueda.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dGVProductosBusqueda.BorderStyle = BorderStyle.Fixed3D;
            dGVProductosBusqueda.EditMode = DataGridViewEditMode.EditOnEnter;

            
            dGVProductosBusqueda.AutoGenerateColumns = true;
            //Formateo de las Columnas a ser visibles
            
            

            dtGridViewProductosSeleccionados.DataSource = bdSourceProductosSeleccionados;
            dtGridViewProductosSeleccionados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dtGridViewProductosSeleccionados.BorderStyle = BorderStyle.Fixed3D;
            dtGridViewProductosSeleccionados.EditMode = DataGridViewEditMode.EditOnEnter;
            primeraVez = true;


            if (TipoTransaccion == 'C')
            {
                rButtonPrecio2.Visible = false;
                rButtonPrecio3.Visible = false;
                rButtonPrecio4.Visible = false;
                rButtonPrecio5.Visible = false;
                rButtonPrecio6.Visible = false; // 69
                //txtBoxPrecio.Location.X = 69;
                txtBoxPrecio.Location = new Point(69, 14);
                gBoxListadoPrecios.Width = 259;

                label5.Visible = false;
                txtCantidadExistenciaBuscar.Visible = false;

                txtBoxNombreProducto.Width = 610;
                btnOpcionesPrecios.Visible = false;
                

            }

        }




        public void formatearColumnas()
        {
            
            //_CodigoProducto
            dGVProductosBusqueda.Columns[0].Visible = true;
            dGVProductosBusqueda.Columns[0].Width = 74;
            dGVProductosBusqueda.Columns[0].HeaderText = "Código";

            //_NombreProducto
            dGVProductosBusqueda.Columns[1].Visible = true;
            dGVProductosBusqueda.Columns[1].Width = 300;
            dGVProductosBusqueda.Columns[1].HeaderText = "Nombre Producto";

            
            //PrecioUnitarioCompra            
            dGVProductosBusqueda.Columns[2].Width = 105;
            dGVProductosBusqueda.Columns[2].HeaderText = "Precio Compra";

            if (TipoTransaccion == 'V' || TipoTransaccion == 'T')
            {
                dGVProductosBusqueda.Columns[2].Visible = false;
            }
            if (TipoTransaccion == 'C')
            {
                dGVProductosBusqueda.Columns[3].Visible = false;
                dGVProductosBusqueda.Columns[4].Visible = false;
                dGVProductosBusqueda.Columns[5].Visible = false;
                dGVProductosBusqueda.Columns[6].Visible = false;
                dGVProductosBusqueda.Columns[7].Visible = false;
                dGVProductosBusqueda.Columns[8].Visible = false;
                dGVProductosBusqueda.Columns[1].Width = 400;
            }           
            
            
        }

        public void cargarCaracterizticasProductos()
        {                       
            ventasProductosCLN = new VentasProductosProcStoredCLN();
            this.TransaccionUtilidadadesCLN = new TransaccionesUtilidadesCLN();
            this.invetariosProductosCLN = new InventariosProductosCLN();

            DTProductosDisponibles = new DataTable();
            _DTProductosSeleccionados = new DataTable();
            _DTProductosBusqueda = new DataTable();
        }

        public void CargarProductosComboBox()
        {
            DTProductosComboBox = TipoTransaccion == 'C' ? TransaccionUtilidadadesCLN.ListarProductosCodigoNombre(false) : TransaccionUtilidadadesCLN.ListarProductosCodigoNombre(true);
            DTProductosDisponibles = DTProductosComboBox.Copy();
            
            DataColumn[] PrimaryKeyColumnNombreProducto = new DataColumn[1];
            PrimaryKeyColumnNombreProducto[0] = DTProductosDisponibles.Columns["NombreProducto"];
            DTProductosDisponibles.PrimaryKey = PrimaryKeyColumnNombreProducto;

            for (int i = 0; i < DTProductosComboBox.Rows.Count; i++)
            {
                ((DataGridViewComboBoxColumn)(dtGridViewProductosSeleccionados.Columns[1])).Items.Add(DTProductosComboBox.Rows[i]["NombreProducto"].ToString());
            }

        }

        public void crearTablasTemporales()
        {
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

            //DTProductosDisponibles = DTProductosComboBox.Copy();
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = _DTProductosSeleccionados.Columns["Código Producto"];
            _DTProductosSeleccionados.PrimaryKey = PrimaryKeyColumns;

            //DataColumn[] PrimaryKeyColumnNombreProducto = new DataColumn[1];
            //PrimaryKeyColumnNombreProducto[0] = DTProductosDisponibles.Columns["NombreProducto"];
            //DTProductosDisponibles.PrimaryKey = PrimaryKeyColumnNombreProducto;

            _DTProductosSeleccionados.TableName = "ProductosDetalle";
            _DTProductosBusqueda.TableName = "ProductosBusqueda";

            DSdatosVentaTemporal.Tables.Add(_DTProductosSeleccionados);
            DSdatosVentaTemporal.Tables.Add(_DTProductosBusqueda);
            DSdatosVentaTemporal.DataSetName = "Productos";

            //MessageBox.Show("_DTProductosSeleccionados: " + _DTProductosSeleccionados.PrimaryKey.GetLength(0).ToString() + ",  DTProductosDisponibles: " + DTProductosDisponibles.PrimaryKey.GetLength(0).ToString()); 

            //Creacion de la columna de Codigo de Producto
            DataGridViewTextBoxColumn columnaCodigo = new DataGridViewTextBoxColumn();            
            columnaCodigo.Name = "Codigo";
            columnaCodigo.ReadOnly = true;
            columnaCodigo.DataPropertyName = "Código Producto";
            columnaCodigo.Width = 68;
           // columnaCodigo.DefaultCellStyle.NullValue = "Sin Seleccionar";
            //columnaCodigo.DataPropertyName = "_CodigoProducto";            
            //columnaCodigo.ValueMember = "Self";
            


            //-----------Creacion de la Columna Nombre Producto como un ComboBox
            comboBoxNombresProducto = new DataGridViewTextBoxColumn();
            //comboBoxNombresProducto.Items.Add("No Seleccionado");
           // comboBoxNombresProducto.DefaultCellStyle.NullValue = "No Seleccionado";
            comboBoxNombresProducto.Name = "Nombre Producto";
            comboBoxNombresProducto.DataPropertyName = "Nombre Producto";            
            comboBoxNombresProducto.Width = 345;
            comboBoxNombresProducto.ReadOnly = true;
            //comboBoxNombresProducto.DataSource = _DTProductosSeleccionados;
            //comboBoxNombresProducto.DisplayMember = "_NombreProducto";
            //comboBoxNombresProducto.ValueMember = "_CodigoProducto";
            //comboBoxNombresProducto.DisplayMember = "Name";
            //comboBoxNombresProducto.ValueMember = "Self";            
            

            //-----------Creacion de la Columna Cantidad de Venta como un NumericUpDown Component
            numericColumn = new WFADoblones20.Utilitarios.DataGridViewNumericUpDownColumn();
            numericColumn.DecimalPlaces = 0;
            numericColumn.Minimum = 1;
            numericColumn.Maximum = 9999;
            numericColumn.DefaultCellStyle.NullValue = "0";
            numericColumn.HeaderText = "Cantidad";
            numericColumn.Width = 70;
            numericColumn.DataPropertyName = "Cantidad";
            numericColumn.Name = "Cantidad";

            //-----------Creacion de la Columna Precio de Venta como un TextBox Component
            DataGridViewTextBoxColumn columnaPrecio = new DataGridViewTextBoxColumn();
            columnaPrecio.Name = "Precio";
            columnaPrecio.ReadOnly = false;
           // columnaPrecio.DefaultCellStyle.NullValue = "Sin Seleccionar";
            columnaPrecio.DataPropertyName = "Precio";
            columnaPrecio.Width = 70;
            columnaPrecio.DefaultCellStyle.Format = "N2";
            columnaPrecio.DefaultCellStyle.NullValue = "0";            

            //-----------Creacion de la Columna PrecioTotal de Venta como un TextBox Component
            DataGridViewTextBoxColumn columnaPrecioTotal = new DataGridViewTextBoxColumn();
            columnaPrecioTotal.Name = "Precio Total";
            columnaPrecioTotal.ReadOnly = true;
            columnaPrecioTotal.Width = 102;
            columnaPrecioTotal.DataPropertyName = "PrecioTotal";
            columnaPrecioTotal.DefaultCellStyle.Format = "N2";
            columnaPrecioTotal.DefaultCellStyle.NullValue = "0";
          //  columnaPrecioTotal.DefaultCellStyle.NullValue = "Sin Seleccionar";


            //-----------Creacion de la Columna TiempoGarantiaPE de Venta como un TextBox Component
            DataGridViewTextBoxColumn columnaGarantia = new DataGridViewTextBoxColumn();
            columnaGarantia.Name = "Garantia";
            columnaGarantia.ReadOnly = false;
            columnaGarantia.Width = 60;
            columnaGarantia.HeaderText = "Garantia en dias";
            columnaGarantia.DefaultCellStyle.NullValue = "0";
            columnaGarantia.DataPropertyName = "Garantia";

            //-----------Creacion de la Columna de Ayuda, para verificar si un Producto es o no Específico
            DataGridViewCheckBoxColumn columnaProductoEspedifico = new DataGridViewCheckBoxColumn();
            columnaProductoEspedifico.Name = "ProductoEspecífico";
            columnaProductoEspedifico.ReadOnly = false;
            columnaProductoEspedifico.Width = 60;
            columnaProductoEspedifico.DefaultCellStyle.NullValue = "0";
            columnaProductoEspedifico.Visible = false;
            columnaProductoEspedifico.DataPropertyName = "EsProductoEspecifico";

            DataGridViewCheckBoxColumn columnaAgregado = new DataGridViewCheckBoxColumn();
            columnaAgregado.ReadOnly = false;
            columnaAgregado.Width = 60;
            columnaAgregado.DefaultCellStyle.NullValue = false;
            columnaAgregado.Visible = true;
            columnaAgregado.HeaderText = "Es Agregado?";
            columnaAgregado.Width = 100;
            columnaAgregado.DataPropertyName = "VendidoComoAgregado";

            

            dtGridViewProductosSeleccionados.AutoGenerateColumns = false;

            dtGridViewProductosSeleccionados.Columns.Add(columnaCodigo);
            dtGridViewProductosSeleccionados.Columns.Add(comboBoxNombresProducto);
            dtGridViewProductosSeleccionados.Columns.Add(numericColumn);
            dtGridViewProductosSeleccionados.Columns.Add(columnaPrecio);
            dtGridViewProductosSeleccionados.Columns.Add(columnaPrecioTotal);
            dtGridViewProductosSeleccionados.Columns.Add(columnaGarantia);
            dtGridViewProductosSeleccionados.Columns.Add(columnaProductoEspedifico);
            dtGridViewProductosSeleccionados.Columns.Add(columnaAgregado);

            if (TipoTransaccion == 'T')
            {
                DTGridViewProductosSeleccionados.Columns[7].Visible = false;
            }
            else
            {
                DTGridViewProductosSeleccionados.Columns[7].Visible = true;
            }
           
            //ocultar por el momento los productos agregados
            DTGridViewProductosSeleccionados.Columns[7].Visible = false;
        }



        
        private void txtBoxCodigoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                nUpDownCantidad.Focus();
                nUpDownCantidad.Value = 1;
                nUpDownCantidad.Select(0, nUpDownCantidad.ToString().Length);
                
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                dGVProductosBusqueda.Focus();
                dGVProductosBusqueda.Columns[columnaNombreProducto].Selected = true;
                dGVProductosBusqueda.CurrentCell = dGVProductosBusqueda.Rows[0].Cells[columnaNombreProducto];
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.txtBoxNombreProducto.Clear();
            }            
            FProductosBusqueda_KeyDown(sender, e);

        }

        private void txtBoxCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                txtBoxPrecio.Focus();            
        }

        private void FProductosBusqueda_Load(object sender, EventArgs e)
        {
            lblRegistosEncontrados.Text = "Nro de Registros Encontrados : 0";
            toolStripStatusLabel4.Text = "........";
            toolStripStatusLabel2.Text = "........";
            lblPrecioTotal.Text = "";
            if (nuevaVenta)
            {
                
                DTProductosBusqueda.Clear();
                DTProductosSeleccionados.Clear();
                checkNombreProd1_CheckedChanged(sender, e);
                if (primeraVez)
                {
                    
                }
                primeraVez = false;                    
                
                
                //dGVProductosBusqueda.Columns[columnaNombreProducto].Width = 260;               
                TransaccionConfirmada = false;
                nuevaVenta = false;
                ExistenProductosInalcanzables = false;
            }
            if (TipoTransaccion == 'T')
            {
                DTGridViewProductosSeleccionados.Columns[DTGridViewProductosSeleccionados.Columns.Count - 1].Visible = false;
            }
            rButtonPrecio1_CheckedChanged(sender, e);
            DTProductosSeleccionados.RowChanged += new DataRowChangeEventHandler(DTProductosSeleccionados_RowChanged);
            //DTGridViewProductosSeleccionados.CurrentCellDirtyStateChanged += new EventHandler(DTGridViewProductosSeleccionados_CurrentCellDirtyStateChanged);
        }

        void DTProductosSeleccionados_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            cargarPieDetalleResultado();
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
            FProductosBusqueda_KeyDown(sender, e);
        }

        private void dGVProductosBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(Char.IsLetter(e.KeyChar) || Char.IsDigit(e.KeyChar))
            {
                txtBoxNombreProducto.Focus();
                txtBoxNombreProducto.Text = e.KeyChar.ToString();
                txtBoxNombreProducto.SelectionStart = 1;
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
                        else// (dGVProductosBusqueda.CurrentCell.ColumnIndex == 3)
                        {
                            txtBoxPrecio.Text = dGVProductosBusqueda.CurrentRow.Cells[3].Value.ToString();
                            TipoPrecioSeleccionado = '1';
                        }

                        //Habilitar para poder seleccionar los otros 3 Precio mas, 4,5,6
                        //if (dGVProductosBusqueda.CurrentCell.ColumnIndex == 6)
                        //{
                        //    txtBoxPrecio.Text = dGVProductosBusqueda.CurrentRow.Cells[6].Value.ToString();
                        //}
                        //if (dGVProductosBusqueda.CurrentCell.ColumnIndex == 7)
                        //{
                        //    txtBoxPrecio.Text = dGVProductosBusqueda.CurrentRow.Cells[7].Value.ToString();
                        //}
                        //if (dGVProductosBusqueda.CurrentCell.ColumnIndex == 8)
                        //{
                        //    txtBoxPrecio.Text = dGVProductosBusqueda.CurrentRow.Cells[8].Value.ToString();
                        //}
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

                        //Habilitar para poder seleccionar los otros 3 Precio mas, 4,5,6
                        //if (rButtonPrecio4.Checked)
                        //    txtBoxPrecio.Text = dGVProductosBusqueda.CurrentRow.Cells[6].Value.ToString();
                        //if (rButtonPrecio5.Checked)
                        //    txtBoxPrecio.Text = dGVProductosBusqueda.CurrentRow.Cells[7].Value.ToString();
                        //if (rButtonPrecio6.Checked)
                        //    txtBoxPrecio.Text = dGVProductosBusqueda.CurrentRow.Cells[8].Value.ToString();
                    }                        
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {           
            cargarProductoparaVenta();           
        }

        private void nUDPrecio_ValueChanged(object sender, EventArgs e)
        {

        }


        public void cargarProductoparaVenta()
        {
            if (dGVProductosBusqueda.CurrentRow != null)
            {
                string CodigoProductoBusqueda = null;
                try
                {
                    //if (!isProductosComboBoxCargados)
                    //{
                    //    CargarProductosComboBox();
                    //    isProductosComboBoxCargados = true;
                    //}
                    string nombreProducto = dGVProductosBusqueda.Rows[dGVProductosBusqueda.CurrentRow.Index].Cells[columnaNombreProducto].Value.ToString();
                    string codigoProducto = dGVProductosBusqueda.Rows[dGVProductosBusqueda.CurrentRow.Index].Cells[columnaCodigo].Value.ToString().Trim();
                    CodigoProductoBusqueda = codigoProducto;
                    int tiempoGarantia = Int16.Parse(dGVProductosBusqueda.Rows[dGVProductosBusqueda.CurrentRow.Index].Cells[10].Value.ToString());
                    int cantidadExistencia = Int32.Parse(dGVProductosBusqueda.Rows[dGVProductosBusqueda.CurrentRow.Index].Cells[9].Value.ToString());
                    decimal precio = 0;
                    //if(TipoTransaccion == 'V' || TipoTransaccion =='T')
                    //    precio = Decimal.Parse(dGVProductosBusqueda.Rows[dGVProductosBusqueda.CurrentRow.Index].Cells[3].Value.ToString());
                    //if (TipoTransaccion == 'C')
                    //    precio = Decimal.Parse(dGVProductosBusqueda.Rows[dGVProductosBusqueda.CurrentRow.Index].Cells[2].Value.ToString());
                    precio = decimal.Parse(txtBoxPrecio.Text);
                    bool productoEspecifico = Boolean.Parse(dGVProductosBusqueda.Rows[dGVProductosBusqueda.CurrentRow.Index].Cells[11].Value.ToString());
                    bool esAgregado = false;
                    isInsertingModeTableProductosBusqueda = true;
                    // isInserting = true;                    
                    //_DTProductosSeleccionados.Rows.Add(new object[] { codigoProducto, nombreProducto, nUpDownCantidad.Value, precio, nUpDownCantidad.Value * precio, tiempoGarantia, productoEspecifico, esAgregado, cantidadExistencia, 0, 0, TipoPrecioSeleccionado });
                    _DTProductosSeleccionados.Rows.Add(new object[] { codigoProducto, nombreProducto, nUpDownCantidad.Value, precio, nUpDownCantidad.Value * precio, tiempoGarantia, productoEspecifico, esAgregado, cantidadExistencia, nUpDownCantidad.Value, 0, TipoPrecioSeleccionado });
                    
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
                    //dtGVProductosEspecificos.FirstDisplayedScrollingRowIndex = DTProductosEspecificosRecpcion.Rows.IndexOf(FilaProductoEspecifico);
                    DTGridViewProductosSeleccionados.FirstDisplayedScrollingRowIndex = _DTProductosSeleccionados.Rows.Count - 1;
                }
                catch (Exception)
                {
                    MessageBox.Show(this, "No puede Seleccionar un Producto que ya Se encuentra en el Detalle de Productos Seleccionados."+Environment.NewLine+"Seleccione otro Producto.", "Productos Seleccionados Repetidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (!string.IsNullOrEmpty(CodigoProductoBusqueda))
                    {
                        DataRow[] DRProductos = DTProductosSeleccionados.Select("[Código Producto] = '" + CodigoProductoBusqueda + "'");
                        if (DRProductos != null)
                        {
                            int indiceFila = DTProductosSeleccionados.Rows.IndexOf(DRProductos[0]);
                            DTGridViewProductosSeleccionados.CurrentCell = DTGridViewProductosSeleccionados[0, indiceFila];
                            DTGridViewProductosSeleccionados.CurrentRow.Selected = true;
                        }
                    }
                    //throw;
                }
            }
        }
        private void nUDPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cargarProductoparaVenta();
            }
            FProductosBusqueda_KeyDown(sender, e);
        }

        private void dtGridViewProductosSeleccionados_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DTProductosSeleccionados.AcceptChanges();            
            if (!isInsertingModeTableProductosBusqueda && !nuevaVenta)
            {
                if (e.ColumnIndex == 5)
                {
                    //MessageBox.Show("cambio  " + dtGridViewProductosSeleccionados[5, e.RowIndex].Value.ToString());
                    DTProductosSeleccionados.Rows[e.RowIndex][columnaPrecioTotal + 1] = dtGridViewProductosSeleccionados[5, e.RowIndex].Value;
                }
                //Si la Cantidad seleccionada cambio mediante el NumericUpdDownColumn
                if (e.ColumnIndex == 2 && DTProductosSeleccionados.Rows[e.RowIndex].RowState != DataRowState.Deleted  && dtGridViewProductosSeleccionados.CurrentRow.Cells[columnaCantidad].Value != null && dtGridViewProductosSeleccionados.CurrentRow.Cells[columnaPrecioUnitario].Value != null)
                {
                    _DTProductosSeleccionados.Columns[columnaPrecioTotal].ReadOnly = false;                    
                    dtGridViewProductosSeleccionados.CurrentRow.Cells[columnaPrecioTotal].Value = Int16.Parse(dtGridViewProductosSeleccionados.CurrentRow.Cells[columnaCantidad].Value.ToString()) * Decimal.Parse(dtGridViewProductosSeleccionados.CurrentRow.Cells[columnaPrecioUnitario].Value.ToString());

                    DTProductosSeleccionados.Rows[e.RowIndex].BeginEdit();
                    DTProductosSeleccionados.Rows[dtGridViewProductosSeleccionados.CurrentRow.Index][columnaPrecioTotal] = dtGridViewProductosSeleccionados.CurrentRow.Cells[columnaPrecioTotal].Value;
                    DTProductosSeleccionados.Rows[dtGridViewProductosSeleccionados.CurrentRow.Index][columnaCantidad] = dtGridViewProductosSeleccionados.CurrentRow.Cells[columnaCantidad].Value;
                    DTProductosSeleccionados.Rows[dtGridViewProductosSeleccionados.CurrentRow.Index]["CantidadEntregada"] = DTProductosSeleccionados.Rows[dtGridViewProductosSeleccionados.CurrentRow.Index]["Cantidad"];
                    DTProductosSeleccionados.Rows[e.RowIndex].EndEdit();
                    DTProductosSeleccionados.Rows[e.RowIndex].AcceptChanges();
                    _DTProductosSeleccionados.Columns[columnaPrecioTotal].ReadOnly = true;

                }

                //Si se Selecciono Otro Producto del ComboBoxColumn
                if (e.ColumnIndex == 1 && dtGridViewProductosSeleccionados.RowCount >= 1 && dtGridViewProductosSeleccionados.Rows[e.RowIndex].Cells[2].Value != null)
                {
                    try
                    {
                        //MessageBox.Show(dtGridViewProductosSeleccionados[1, e.RowIndex].Value.ToString());
                        int indice = ((DataGridViewComboBoxColumn)(dtGridViewProductosSeleccionados.Columns[1])).Index;
                        //MessageBox.Show(indice.ToString());
                        DataRow fila = DTProductosDisponibles.Rows.Find(dtGridViewProductosSeleccionados[1, e.RowIndex].Value.ToString());
                        if (fila != null)
                        {
                            //MessageBox.Show(fila[0].ToString() + "  " + fila[1].ToString());
                            //Actualizamos el Codigo del Producto
                            dtGridViewProductosSeleccionados.Rows[e.RowIndex].Cells[columnaCodigo].Value = fila[0].ToString();
                            //Actualizamos el Precio del Producto
                            dtGridViewProductosSeleccionados.Rows[e.RowIndex].Cells[columnaPrecioUnitario].Value = fila[2].ToString();
                            //actualizamos el Precio Total de Venta para ese Producto
                            dtGridViewProductosSeleccionados.Rows[e.RowIndex].Cells[columnaPrecioTotal].Value = ((Decimal)(Decimal.Parse(dtGridViewProductosSeleccionados.Rows[e.RowIndex].Cells[columnaPrecioUnitario].Value.ToString()) + Int16.Parse(dtGridViewProductosSeleccionados.Rows[e.RowIndex].Cells[columnaCantidad].Value.ToString()))).ToString();

                            //Actualizamos todo el DataTable de ProductosSeleccionados
                            DTProductosSeleccionados.Rows[e.RowIndex].BeginEdit();
                            DTProductosSeleccionados.Rows[e.RowIndex][columnaCodigo] = fila[0];//codigo Producto
                            DTProductosSeleccionados.Rows[e.RowIndex][columnaNombreProducto] = fila[1];//Nombre del Producto
                            DTProductosSeleccionados.Rows[e.RowIndex][columnaPrecioUnitario] = fila[2];//Precio de Producto                        
                            //DTProductosSeleccionados.Columns[columnaPrecioTotal].ReadOnly = false;
                            DTProductosSeleccionados.Rows[e.RowIndex][columnaPrecioTotal] = Decimal.Parse(((decimal)Decimal.Parse(fila[2].ToString()) * Int16.Parse(DTProductosSeleccionados.Rows[e.RowIndex][2].ToString())).ToString());
                            DTProductosSeleccionados.Rows[e.RowIndex].EndEdit();
                            DTProductosSeleccionados.Rows[e.RowIndex].AcceptChanges();
                            //DTProductosSeleccionados.Columns[columnaPrecioTotal].ReadOnly = true; ;
                            DTGridViewProductosSeleccionados.Update();


                        }
                    }
                    catch (Exception)
                    {
                        
                        //throw;
                    }
                }
                if (dtGridViewProductosSeleccionados[4, e.RowIndex].Value != null)
                {
                    cargarPieDetalleResultado();
                }

                //si ha cambiado el precio del producto para la transacción
                if (e.ColumnIndex == 3 && dtGridViewProductosSeleccionados[3, e.RowIndex].Value != null && !DTGridViewProductosSeleccionados.CurrentRow.IsNewRow && e.ColumnIndex == 3 && dtGridViewProductosSeleccionados[4, e.RowIndex].Value != null)
                {
                    DTProductosSeleccionados.Rows[e.RowIndex].BeginEdit();
                    DTProductosSeleccionados.Rows[dtGridViewProductosSeleccionados.CurrentRow.Index][columnaPrecioUnitario] = dtGridViewProductosSeleccionados.CurrentRow.Cells[columnaPrecioUnitario].Value;
                    DTProductosSeleccionados.Rows[e.RowIndex].AcceptChanges();

                    string CodigoProducto = DTProductosSeleccionados.Rows[e.RowIndex][columnaCodigo].ToString();
                    string TipoPrecioSeleccionado = DTProductosSeleccionados.Rows[e.RowIndex]["NumeroPrecioSeleccionado"].ToString();
                    decimal PrecioEstandar = TransaccionUtilidadadesCLN.ObtenerPrecioRelativoProducto(NumeroAgencia, CodigoProducto, TipoPrecioSeleccionado, false);
                    decimal PrecioNuevo = Decimal.Parse(DTProductosSeleccionados.Rows[e.RowIndex][columnaPrecioUnitario].ToString());
                    decimal PrecioDiferencia = PrecioEstandar - PrecioNuevo;
                    if (PrecioDiferencia > 0)
                    {
                        DTProductosSeleccionados.Rows[e.RowIndex]["PorcentajeDescuento"] = decimal.Round(PrecioDiferencia * 100 / PrecioEstandar, 2);
                        DTProductosSeleccionados.Rows[e.RowIndex]["NumeroPrecioSeleccionado"] = "P";
                    }


                    DTProductosSeleccionados.Columns[columnaPrecioTotal].ReadOnly = false;
                    dtGridViewProductosSeleccionados.Columns[columnaPrecioTotal].ReadOnly = false;
                    DTProductosSeleccionados.Rows[e.RowIndex][columnaPrecioTotal] = Int32.Parse(DTProductosSeleccionados.Rows[e.RowIndex][columnaCantidad].ToString()) * PrecioNuevo;
                    dtGridViewProductosSeleccionados.CurrentRow.Cells[columnaPrecioTotal].Value = DTProductosSeleccionados.Rows[e.RowIndex][columnaPrecioTotal];
                    dtGridViewProductosSeleccionados.Columns[columnaPrecioTotal].ReadOnly = true;
                    DTProductosSeleccionados.Columns[columnaPrecioTotal].ReadOnly = true;
                    
                    // DTProductosSeleccionados.Rows[e.RowIndex]["PorcentajeDescuento"] = 
                }
                //para los Productos que seran incorporados a la transacción como agregados
                if (e.ColumnIndex == 7 && dtGridViewProductosSeleccionados.CurrentRow.Cells[7].Value != null)
                {
                    DTProductosSeleccionados.Rows[dtGridViewProductosSeleccionados.CurrentRow.Index].BeginEdit();
                    if (dtGridViewProductosSeleccionados.CurrentRow.Cells[7].Value.Equals(true))
                    {
                        if (_DTProductosSeleccionados.Rows[dtGridViewProductosSeleccionados.CurrentRow.Index]["EsProductoEspecifico"].Equals(false) && TipoTransaccion == 'V')
                        {
                            if (MessageBox.Show(this, "El Producto que ha Seleccionado aun no ha sido Inventariado como Producto Especifico" + Environment.NewLine + "¿Desea Inventariarlo como Producto Específico para añadir el producto a la Venta como Agregado", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                //mostrar el formulario para el registro de nuevos productos Especificos o registrarlo directamente como producto especifico segun la cantidadCompra
                                //_DTProductosSeleccionados.Rows[dtGridViewProductosSeleccionados.CurrentRow.Index][7] = true;                                
                                dtGridViewProductosSeleccionados.CurrentRow.Cells[columnaPrecioUnitario].Value = 0.00;
                                dtGridViewProductosSeleccionados.CurrentRow.DefaultCellStyle.BackColor = Color.YellowGreen;                                
                            }
                            else
                            {
                                MessageBox.Show(this, "El Producto que ha seleccionado no puede ser vendido como Agregado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                _DTProductosSeleccionados.Rows[dtGridViewProductosSeleccionados.CurrentRow.Index][7] = false;                                
                                return;
                            }
                        }
                        else
                        {
                            _DTProductosSeleccionados.Rows[dtGridViewProductosSeleccionados.CurrentRow.Index]["Precio"] = 0.00;
                            _DTProductosSeleccionados.Columns["PrecioTotal"].ReadOnly = false;
                            _DTProductosSeleccionados.Rows[dtGridViewProductosSeleccionados.CurrentRow.Index]["PrecioTotal"] = 0.00;
                            _DTProductosSeleccionados.Columns["PrecioTotal"].ReadOnly = true;
                            _DTProductosSeleccionados.Rows[dtGridViewProductosSeleccionados.CurrentRow.Index].AcceptChanges();
                            //dtGridViewProductosSeleccionados.CurrentRow.Cells[7].Value = true;
                            dtGridViewProductosSeleccionados.CurrentRow.DefaultCellStyle.BackColor = Color.YellowGreen;
                            //dtGridViewProductosSeleccionados.CurrentRow.Cells[columnaPrecioUnitario].Value = 0.00;
                        }
                    }
                    else
                    {
                        //_DTProductosSeleccionados.Rows[dtGridViewProductosSeleccionados.CurrentRow.Index][7] = false;
                        //dtGridViewProductosSeleccionados.CurrentRow.Cells[7].Value = false;
                        
                        //DataRow filaProductoActual = DTProductosDisponibles.Rows.Find(_DTProductosSeleccionados.Rows[dtGridViewProductosSeleccionados.CurrentRow.Index][columnaNombreProducto]);
                        decimal PrecioNeto = TransaccionUtilidadadesCLN.ObtenerPrecioMinimoDeProducto(NumeroAgencia, _DTProductosSeleccionados.Rows[dtGridViewProductosSeleccionados.CurrentRow.Index][columnaCodigo].ToString());
                        dtGridViewProductosSeleccionados.CurrentRow.Cells[columnaPrecioUnitario].Value = PrecioNeto;
                        dtGridViewProductosSeleccionados.CurrentRow.DefaultCellStyle.BackColor = Color.White;
                    }
                    DTProductosSeleccionados.Rows[dtGridViewProductosSeleccionados.CurrentRow.Index].AcceptChanges();
                }
            }
            
        }


        public void cargarPieDetalleResultado()
        {
            decimal precioTotal = 0;            
            object precio = DTProductosSeleccionados.Compute("sum(PrecioTotal)", "");
            if (decimal.TryParse(precio.ToString(), out precioTotal))
            {
                lblPrecioTotal.Text = precioTotal.ToString();
            }
            else
            {
                lblPrecioTotal.Text = "0.00";
            }
        }

        private void dGVProductosBusqueda_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(dGVProductosBusqueda[e.ColumnIndex, e.RowIndex].Value.ToString());
        }

        private void dGVProductosBusqueda_Leave(object sender, EventArgs e)
        {
            if (isEnterFromTableProductosBusqueda && dGVProductosBusqueda.Rows.Count >= 0 )
            {                
                if (dGVProductosBusqueda.CurrentRow.Index == 0)
                {
                    dGVProductosBusqueda.CurrentCell = dGVProductosBusqueda.Rows[0].Cells[1];
                    dGVProductosBusqueda.Rows[0].Selected = true;
                }
                else
                {
                    dGVProductosBusqueda.CurrentCell = dGVProductosBusqueda.Rows[dGVProductosBusqueda.CurrentRow.Index-1].Cells[1];
                    dGVProductosBusqueda.Rows[dGVProductosBusqueda.CurrentRow.Index].Selected = true;
                }
                
                isEnterFromTableProductosBusqueda = false;                
            }
        }

        private void dGVProductosBusqueda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cargarProductoparaVenta();
        }

        private void dtGridViewProductosSeleccionados_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            isInsertingModeTableProductosBusqueda = false;
            cargarPieDetalleResultado();
        }


        private void dtGridViewProductosSeleccionados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
//                dtGridViewProductosSeleccionados.Rows.RemoveAt(dtGridViewProductosSeleccionados.CurrentRow.Index);
                //bindingNavigatorDeleteItem_Click(sender, e as EventArgs);
                DTProductosSeleccionados.Rows[bdSourceProductosSeleccionados.Position].Delete();
                cargarPieDetalleResultado();
            }
            FProductosBusqueda_KeyDown(sender, e);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            _DTProductosSeleccionados.Clear();
            lblPrecioTotal.Text = "0.00";
            txtBoxNombreProducto.Clear();
            txtBoxNombreProducto.Focus();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //DataTable DeleteTable = DTProductosSeleccionados.GetChanges(DataRowState.Deleted);
            _DTProductosSeleccionados.AcceptChanges();
            int cantidadAgregados=0;
            cantidadAgregados = 0;

            cantidadAgregados = int.Parse(_DTProductosSeleccionados.Compute("count(VendidoComoAgregado)", "VendidoComoAgregado = true").ToString());
            //foreach (DataRow fila in _DTProductosSeleccionados.Rows)
            //{
            //    if(fila[7].Equals(true))
            //        cantidadAgregados++;                
            //}
            if (cantidadAgregados == _DTProductosSeleccionados.Rows.Count && _DTProductosSeleccionados.Rows.Count != 0)
            {
                MessageBox.Show(this, "No puede Realizar una transacción en la que los productos sean todos Agregados", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.FProductosBusqueda_Shown(sender, e);
                return;
            }
            if (TipoTransaccion == 'V')
            {
                int indice = 0;
                String ProductosInexistentes = "";
                int existeProductosEspecificos = 0;
                //existeProductosEspecificos = _DTVentasProductosDetalle.Compute("sum(PrecioTotal)", filtro);
                if (_DTProductosSeleccionados.Rows.Count > 0)
                    existeProductosEspecificos = int.Parse(_DTProductosSeleccionados.Compute("count(EsProductoEspecifico)", "EsProductoEspecifico = true").ToString());


                //------------------------------------------ PARA LA REVISIÓN DE PRODUCTOS ESPECIFICOS
                //if (existeProductosEspecificos > 0)
                //{
                //    if (MessageBox.Show(this, "Existen Algunos Productos Seleccionados que son Considerados Productos Especificos" + Environment.NewLine + "Si Desea que El sistema se Encargue de Escogerlos automáticamente para la Venta, Seleccione 'Aceptar'," + Environment.NewLine + "Caso Contrario, Seleccione 'Cancelar', para que Usted Proceda a Seleccionar los Productos Específicos" + Environment.NewLine + "que Desea Vender", "Existen Productos Específicos", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                //    {
                //        seleccionarProductosEspecificos = false;
                //    }
                //    else
                //    {
                //        seleccionarProductosEspecificos = true;
                //    }
                //}
                //------------------------------------------ 

                seleccionarProductosEspecificos = false;

                indicesProductosExistenciaInalcanzable.Clear(); indice = 0;
                foreach (DataRow fila in _DTProductosSeleccionados.Rows)
                {
                    ////revisar la existencia de cada producto
                    //if (fila.RowState != DataRowState.Deleted && Int32.Parse(invetariosProductosCLN.ObtenerInventarioProducto(NumeroAgencia, fila[0].ToString()).Rows[0][2].ToString()) < Int32.Parse(fila[2].ToString()))
                    //{
                    //    indicesProductosExistenciaInalcanzable.Add(indice);
                    //    ProductosInexistentes += "\t " + fila[1].ToString() + "  " + Environment.NewLine;
                    //}
                    //indice++;
                }
                //this.detalleConfirmado = true;
                //if (indicesProductosExistenciaInalcanzable.Count > 0)
                ////{
                //    if (MessageBox.Show(this, "Existe productos seleccionados cuya Cantidad No es Suficiente en Almacenes :" + Environment.NewLine + ProductosInexistentes + Environment.NewLine + Environment.NewLine + "¿Desea Vender La Cantidad Existente Actualmente en Almacenes?", "Productos Inexistentes", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                //    {
                //        int indexLista = 0;
                //        int cantidadMinima = 0;
                //        for (int i = 0; i < indicesProductosExistenciaInalcanzable.Count; i++)
                //        {
                //            indexLista = Int16.Parse(indicesProductosExistenciaInalcanzable[i].ToString());
                //            cantidadMinima = Int16.Parse(invetariosProductosCLN.ObtenerInventarioProducto(NumeroAgencia, _DTProductosSeleccionados.Rows[indexLista][0].ToString()).Rows[0][2].ToString());
                //            _DTProductosSeleccionados.Rows[indexLista].BeginEdit();
                //            _DTProductosSeleccionados.Rows[indexLista][2] = cantidadMinima > 0 ? cantidadMinima : 1;
                //            _DTProductosSeleccionados.Rows[indexLista].AcceptChanges();
                //        }
                //        registrarProductosEspecificosSeleccionados();
                //        TransaccionConfirmada = true;                        
                //        this.Hide();
                //    }
                //    else
                //    {
                //        if (MessageBox.Show(this, "¿Desea Continuar la Venta con la Cantidad Escogida? Tome en cuenta que debe Reabastecer su Inventario si Continua", "Productos Inalcanzables", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                //        {
                //            DTGridViewProductosSeleccionados.Rows[Int16.Parse(indicesProductosExistenciaInalcanzable[0].ToString())].Selected = true;
                //            this.FProductosBusqueda_Shown(sender, e);
                //            DTGridViewProductosSeleccionados.Columns[2].Selected = true;
                //            DTGridViewProductosSeleccionados.CurrentCell = DTGridViewProductosSeleccionados.Rows[Int16.Parse(indicesProductosExistenciaInalcanzable[0].ToString())].Cells[2];
                //            DTGridViewProductosSeleccionados.Focus();
                //        }
                //        else
                //        {
                //            ExistenProductosInalcanzables = true;
                //            TransaccionConfirmada = true;
                //            this.Hide();
                //        }
                        
                //    }                    
                //}
                //else
                //{
                //    registrarProductosEspecificosSeleccionados();
                //    TransaccionConfirmada = true;
                //    this.Hide();
                //}
                
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
            DTProductosSeleccionados.AcceptChanges();
        }

        public void registrarProductosEspecificosSeleccionados()
        {
            InventariosProductosEspecificosCLN inventarioProductosEspecificos = new InventariosProductosEspecificosCLN();
            foreach (DataRow fila in _DTProductosSeleccionados.Rows)
            {
                //if (fila["EsProductoEspecifico"].ToString().CompareTo("0") == 0 && fila["VendidoComoAgregado"].Equals(true))
                if (fila["EsProductoEspecifico"].Equals(false) && fila["VendidoComoAgregado"].Equals(true))
                {
                    string[] CodigosGenerar = inventarioProductosEspecificos.ObtenerListadoCodigoProductoEspecificoGenerado(fila[0].ToString(), Int16.Parse(fila["Cantidad"].ToString()),"-","I").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < CodigosGenerar.Length-1; i++)
                    {
                        int longitudCodigo = fila[0].ToString().Trim().Length;
                        string CodigoEspecifico = fila[0].ToString().Trim() + '-' + CodigosGenerar[i + 1].Trim().Substring(longitudCodigo + 1).Trim();
                        inventarioProductosEspecificos.InsertarInventarioProductoEspecifico(NumeroAgencia, fila[0].ToString(), CodigoEspecifico, Int32.Parse(fila[5].ToString()), DateTime.Now.AddMonths(1), "C", "A");
                    }
                    fila.BeginEdit();
                    fila["EsProductoEspecifico"] = true;
                    fila.AcceptChanges();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _DTProductosSeleccionados.Clear();
            this.Hide();
            this.detalleConfirmado = false;
        }


        

        /// <summary>
        /// Cuando se Vuelve a mostrar el Formulario de Productos Seleccionados, es necesario
        /// volver a cargar los datos en el DataGridViewProductosSeleccionados, debido
        /// a que por alguna razón pierden sus valores ->  <strong> REVISAR!!!!!</strong>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FProductosBusqueda_Shown(object sender, EventArgs e)
        {
            if (this.DTProductosSeleccionados.Rows.Count > 0 && DTGridViewProductosSeleccionados[0, 0].Value == null)
            {
                checkNombreProd1.Checked = true;
                checkNombreProd1_CheckedChanged(sender, e);
                for (int indice = 0; indice < this.DTProductosSeleccionados.Rows.Count; indice++)
                {
                    DTGridViewProductosSeleccionados.Rows[indice].Cells[columnaCodigo].Value = this.DTProductosSeleccionados.Rows[indice][columnaCodigo];
                    DTGridViewProductosSeleccionados.Rows[indice].Cells[columnaNombreProducto].Value = this.DTProductosSeleccionados.Rows[indice][columnaNombreProducto];
                    DTGridViewProductosSeleccionados.Rows[indice].Cells[columnaCantidad].Value = this.DTProductosSeleccionados.Rows[indice][columnaCantidad];
                    DTGridViewProductosSeleccionados.Rows[indice].Cells[columnaPrecioUnitario].Value = this.DTProductosSeleccionados.Rows[indice][columnaPrecioUnitario];
                    DTGridViewProductosSeleccionados.Rows[indice].Cells[columnaPrecioTotal].Value = this.DTProductosSeleccionados.Rows[indice][columnaPrecioTotal];
                    DTGridViewProductosSeleccionados.Rows[indice].Cells[columnaPrecioTotal+1].Value = this.DTProductosSeleccionados.Rows[indice][columnaPrecioTotal+1];
                    DTGridViewProductosSeleccionados.Rows[indice].Cells[columnaPrecioTotal + 2].Value = this.DTProductosSeleccionados.Rows[indice][columnaPrecioTotal + 2];
                    DTGridViewProductosSeleccionados.Rows[indice].Cells[columnaPrecioTotal + 3].Value = this.DTProductosSeleccionados.Rows[indice][columnaPrecioTotal + 3];
                    if (DTGridViewProductosSeleccionados.Rows[indice].Cells[columnaPrecioTotal + 3].Value.Equals(true))
                        DTGridViewProductosSeleccionados.Rows[indice].DefaultCellStyle.BackColor = Color.YellowGreen;
                    else
                        DTGridViewProductosSeleccionados.Rows[indice].DefaultCellStyle.BackColor = Color.White;
                }
                
            }           
            this.txtBoxNombreProducto.Clear();            
            this.txtCantidadExistenciaBuscar.Text = "1";
            formatearColumnas();
            cargarPieDetalleResultado();
        }

        private void FProductosBusqueda_FormClosing(object sender, FormClosingEventArgs e)
        {
            string MensajeAlerta = "";
            string CaptionAlerta = "";

            switch (TipoTransaccion)
            {
                case 'V':
                    {
                        MensajeAlerta = "Existen Productos Seleccionados" + Environment.NewLine + "¿Desea Cancelar la Selección de los Productos y la Venta de los mismos?";
                        CaptionAlerta = "Venta de Productos";
                        break;
                    }
                case 'C':
                    {
                        MensajeAlerta = "Existen Productos Seleccionados" + Environment.NewLine + "¿Desea Cancelar la Selección de los Productos y la Compra de los mismos?";
                        CaptionAlerta = "Compra de Productos";                        
                        break;
                    }
                case 'T':
                    {
                        MensajeAlerta = "Existen Productos Seleccionados" + Environment.NewLine + "¿Desea Cancelar la Selección de los Productos y la Cotización de los mismos?";
                        CaptionAlerta = "Cotización de Productos";
                        break;
                    }
                default:
                    {
                        MensajeAlerta = "Existen Productos Seleccionados" + Environment.NewLine + "¿Desea Cancelar la Selección de los Productos y la Transacción Actual?";
                        CaptionAlerta = "Transacción de Productos";
                        break;
                    }
                    
            }

            if (this.DTGridViewProductosSeleccionados.Rows.Count > 0  && !TransaccionConfirmada)
            {
                if (MessageBox.Show(this, MensajeAlerta,CaptionAlerta,MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this._DTProductosSeleccionados.Clear();
                }
                else
                {
                    btnConfirmar_Click(sender, e as EventArgs);
                    e.Cancel = true;
                    return;
                }
            }
        }


        private void dtGridViewProductosSeleccionados_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ThrowException)
            {
                return;
            }
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

        private void FProductosBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
                btnConfirmar_Click(sender, e as EventArgs);
            if (e.Control && e.KeyCode == Keys.C)
                btnLimpiar_Click(sender, e as EventArgs);
            if (e.KeyCode == Keys.Escape)
                btnCancelar_Click(sender, e as EventArgs);
        }


        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            //DataTable DeleteTable = DTProductosSeleccionados.GetChanges(DataRowState.Deleted);
            //DataView dv = new DataView(DTProductosSeleccionados,null, null, DataViewRowState.Deleted);
            //DataTable dt = dv.ToTable(); 
            DTProductosSeleccionados.AcceptChanges();
            cargarPieDetalleResultado();
            if (DTProductosSeleccionados.Rows.Count == 0)
                lblPrecioTotal.Text = "0.00";
        }

        private void dtGridViewProductosSeleccionados_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dtGridViewProductosSeleccionados_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtGridViewProductosSeleccionados.CurrentCell is DataGridViewCheckBoxCell)
            {
                dtGridViewProductosSeleccionados.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

        }

        private void dtGridViewProductosSeleccionados_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            dtGridViewProductosSeleccionados.CurrentCell.ErrorText = "";
            //bool esAgregadoProductoSeleccionado = Boolean.Parse(dtGridViewProductosSeleccionados[columnaPrecioTotal + 2, e.RowIndex].FormattedValue.ToString());
            //esAgregadoProductoSeleccionado = Boolean.Parse(dtGridViewProductosSeleccionados[columnaPrecioTotal + 2, e.RowIndex].Value.ToString());
            if (dtGridViewProductosSeleccionados.Rows[e.RowIndex].IsNewRow) { return; }
            bool esAgregadoProductoSeleccionado = false;
            //cuando se considera el producto como Agregado    
            if (DTProductosSeleccionados.Rows[e.RowIndex].RowState != DataRowState.Deleted)
            {
                esAgregadoProductoSeleccionado = Boolean.Parse(_DTProductosSeleccionados.Rows[e.RowIndex][7].ToString());
                switch (e.ColumnIndex)
                {
                    case columnaCantidad:
                        int newInteger;
                        if (!int.TryParse(e.FormattedValue.ToString(), out newInteger) || newInteger < 0)
                        {
                            e.Cancel = true;
                            dtGridViewProductosSeleccionados.CurrentCell.ErrorText = "No puede Ingresar Cantidades Negativas";
                        }
                        break;


                    case columnaPrecioUnitario:
                        decimal newDecimal;
                        if (!decimal.TryParse(e.FormattedValue.ToString(), out newDecimal) || newDecimal <= 0)
                        {
                            e.Cancel = true;
                            dtGridViewProductosSeleccionados.CurrentCell.ErrorText = "No puede Ingresar Cantidades Negativas";

                        }//_DTProductosSeleccionados.Rows[e.RowIndex][columnaPrecioTotal+2].Equals(false)
                        //dtGridViewProductosSeleccionados.Rows[dtGridViewProductosSeleccionados.Rows.Count - 1].Cells[columnaPrecioTotal + 2].Value = esAgregadoProductoSeleccionado ;                    
                        if (!esAgregadoProductoSeleccionado && dtGridViewProductosSeleccionados.CurrentCell.ErrorText.Trim().Length == 0 && (TipoTransaccion == 'V' || TipoTransaccion == 'T'))
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
                                }
                                else
                                {
                                    e.Cancel = false;
                                    dtGridViewProductosSeleccionados.CurrentCell.ErrorText = "Ha Dedicido Vender este Producto a un precio Menor al Registrado en Inventarios";
                                }
                            }

                        }
                        break;
                }
            }
            
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
            PrecioNeto = TransaccionUtilidadadesCLN.ObtenerPrecioMinimoDeProducto(NumeroAgencia, CodigoProducto);
            return precio_a_Validar < PrecioNeto ? false : true;
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtCantidadExistenciaBuscar.Text) && String.IsNullOrEmpty(txtBoxNombreProducto.Text))
            {
                MessageBox.Show(this, "Aun no ha Ingresado los datos Necesarios para realizar la Busqueda" + Environment.NewLine + "Por Favor Proceda a insertarlos.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (String.IsNullOrEmpty(txtBoxNombreProducto.Text))
                {
                    txtBoxNombreProducto.Focus();
                    txtBoxNombreProducto.SelectAll();
                }
                else
                {
                    txtCantidadExistenciaBuscar.Focus();
                    txtCantidadExistenciaBuscar.SelectAll();
                }
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
                _DTProductosBusqueda = TransaccionUtilidadadesCLN.buscarProductoParaTransaccion(NumeroAgencia, txtBoxNombreProducto.Text, CantidadBusqueda, CamposBusqueda, cBBusquedaExacta.Checked, CodigoMonedaSistema);
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
                txtBoxNombreProducto.SelectAll();
            }
            else
            {
                MessageBox.Show("No puede realizar una Busqueda con los parametros Ingresados");
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

        private void rButtonPrecio4_CheckedChanged(object sender, EventArgs e)
        {
            //if (rButtonPrecio4.Checked && dGVProductosBusqueda.RowCount > 0)
            //{
            //    txtBoxPrecio.Text = dGVProductosBusqueda.CurrentRow.Cells[6].Value.ToString();
            //}
        }

        private void rButtonPrecio5_CheckedChanged(object sender, EventArgs e)
        {
            //if (rButtonPrecio5.Checked && dGVProductosBusqueda.RowCount > 0)
            //{
            //    txtBoxPrecio.Text = dGVProductosBusqueda.CurrentRow.Cells[7].Value.ToString();
            //}
        }

        private void rButtonPrecio6_CheckedChanged(object sender, EventArgs e)
        {
            //if (rButtonPrecio6.Checked && dGVProductosBusqueda.RowCount > 0)
            //{
            //    txtBoxPrecio.Text = dGVProductosBusqueda.CurrentRow.Cells[8].Value.ToString();
            //}
        }

        private void preciosSinFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DTGridViewProductosBusqueda.Columns["DGCPrecioUnitarioVenta1"].Visible = !DTGridViewProductosBusqueda.Columns["DGCPrecioUnitarioVenta1"].Visible;
            DTGridViewProductosBusqueda.Columns["DGCPrecioUnitarioVenta2"].Visible = !DTGridViewProductosBusqueda.Columns["DGCPrecioUnitarioVenta2"].Visible;
            DTGridViewProductosBusqueda.Columns["DGCPrecioUnitarioVenta3"].Visible = !DTGridViewProductosBusqueda.Columns["DGCPrecioUnitarioVenta3"].Visible;
        }

        private void preciosConFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DTGridViewProductosBusqueda.Columns["DGCPrecioUnitarioVenta4"].Visible = !DTGridViewProductosBusqueda.Columns["DGCPrecioUnitarioVenta4"].Visible;
            DTGridViewProductosBusqueda.Columns["DGCPrecioUnitarioVenta5"].Visible = !DTGridViewProductosBusqueda.Columns["DGCPrecioUnitarioVenta5"].Visible;
            DTGridViewProductosBusqueda.Columns["DGCPrecioUnitarioVenta6"].Visible = !DTGridViewProductosBusqueda.Columns["DGCPrecioUnitarioVenta6"].Visible;
        }

        public void inhabilitarControlesParaCotizacion(bool estado)
        {
            btnBuscar.Enabled = !estado;
            txtBoxNombreProducto.Enabled = !estado;
            txtBoxPrecio.Enabled = !estado;
            btnAceptar.Enabled = !estado;
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
            //this._DTProductosSeleccionados.Clear();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            //FAgregarEditarProducto formProductos = new FAgregarEditarProducto(true, false, false, true);
            ////formProductos.habilitarNuevoRegistroProducto(e);
            //formProductos.ShowDialog(this);
            //formProductos.Dispose();
        }

        private void btnInventarios_Click(object sender, EventArgs e)
        {
            FInventarioProductos formInventarioProductos = new FInventarioProductos(NumeroAgencia, NumeroPC);
            formInventarioProductos.ShowDialog(this);
            formInventarioProductos.Dispose();
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

        private void cBBusquedaExacta_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}