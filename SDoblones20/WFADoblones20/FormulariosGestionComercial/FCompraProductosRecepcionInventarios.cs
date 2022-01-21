using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.GestionComercial;
using System.Collections;
using WFADoblones20.FormulariosContabilidad;
using CLCLN.Sistema;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FCompraProductosRecepcionInventarios : Form
    {
        TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;
        InventariosProductosCLN _InventariosProductosCLN;
        InventariosProductosEspecificosCLN _InventariosProductosEspecificosCLN;
        ComprasProductosDetalleCLN _ComprasProductosDetalleCLN;
        CompraProductosGastosDetalleCLN _CompraProductosGastosDetalleCLN;
        ComprasProductosDetalleEntregaCLN _ComprasProductosDetalleEntregaCLN;
        ComprasProductosCLN _ComprasProductosCLN;
        ComprasProductosEspecificosCLN _ComprasProductosEspecificosCLN;

        bool llenadoConfirmadoPE = false;
        bool existeGastos = false;
        DataTable DTProductosEspecificos;
        DataTable DTProductosRecepcion = new DataTable();
        DataTable DTCompraProductosRecepcionSeleccionados;
        DataTable DTCompraProductosRecepcionHistorial;
        Font fuenteDefecto;
        ArrayList ListaCodigoSeleccionadosOpciones = new ArrayList();
        public int NumeroAgencia{get; set;}
        private int NumeroPC = 0;
        private int CodigoUsuario;
        public int NumeroCompraProducto { get; set; }
        public bool OperacionConfirmada = false;
        public Button btnCerrarFormulario;
        public FCompraProductosRecepcionInventarios(int NumeroAGencia, int NumeroPC, int NumeroCompraProducto, int CodigoUsuario)
        {
            InitializeComponent();
            this.NumeroAgencia = NumeroAGencia;
            this.NumeroPC = NumeroPC;
            this.NumeroCompraProducto = NumeroCompraProducto;
            this.CodigoUsuario = CodigoUsuario;
            this.btnCerrarFormulario = new Button();
            this.CancelButton = btnCerrarFormulario;
            btnCerrarFormulario.Click += new EventHandler(btnCerrarFormulario_Click);
            crearTablas();

            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();
            _InventariosProductosCLN = new InventariosProductosCLN();
            _InventariosProductosEspecificosCLN = new InventariosProductosEspecificosCLN();
            _ComprasProductosDetalleCLN = new ComprasProductosDetalleCLN();
            _CompraProductosGastosDetalleCLN = new CompraProductosGastosDetalleCLN();
            _ComprasProductosDetalleEntregaCLN = new ComprasProductosDetalleEntregaCLN();
            _ComprasProductosCLN = new ComprasProductosCLN();
            _ComprasProductosEspecificosCLN = new ComprasProductosEspecificosCLN();

            dtGVProductos.AutoGenerateColumns = false;
            dtGVProductosEspecificos.AutoGenerateColumns = false;

            

            fuenteDefecto = dtGVProductosEspecificos.DefaultCellStyle.Font;

            DGCCodigoProductoPE.DataPropertyName = "CodigoProducto";
            DGCNombreProductoPE.DataPropertyName = "NombreProducto";
            DGCCodigoProductoEspecifico.DataPropertyName = "CodigoProductoEspecifico";
            DGCFechaHoraVencimientoPE.DataPropertyName = "FechaHoraVencimientoPE";
            DGCTiempoGarantiaPE.DataPropertyName = "TiempoGarantiaPE";

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        void btnCerrarFormulario_Click(object sender, EventArgs e)
        {
            OperacionConfirmada = false;
            this.Close();
        }

        private void FCompraProductosRecepcionInventarios_Load(object sender, EventArgs e)
        {
            DGCCodigoProducto.Width = 85;
            DGCNombreProducto.Width = 250;

            DGCCodigoProductoPE.Width = 85;
            DGCNombreProductoPE.Width = 250;

            DTProductosRecepcion = _ComprasProductosDetalleCLN.ListarCompraProductosDetalleEntregados(NumeroAgencia, NumeroCompraProducto, true);
            DataColumn DCNuevaCantidad = new DataColumn("NuevaCantidad");
            DCNuevaCantidad.DataType = Type.GetType("System.Int32");
            DCNuevaCantidad.DefaultValue = 0;
            DTProductosRecepcion.Columns.Add(DCNuevaCantidad);
            

            DTProductosRecepcion.Columns["CantidadFaltante"].ReadOnly = true;
            DTProductosRecepcion.Columns["CantidadFaltante"].Expression = "CantidadCompra - ( CantidadRecepcionada + NuevaCantidad)";

             dtGVProductos.DataSource = DTProductosRecepcion.DefaultView;
            dtGVProductosEspecificos.DataSource = DTProductosEspecificos;
            
            DTProductosEspecificos.DefaultView.Sort = "CodigoProducto ASC";

            existeGastos = _CompraProductosGastosDetalleCLN.ExisteGastosParaCompra(NumeroAgencia, NumeroCompraProducto);
            checkExistenGastos.Checked = existeGastos;
            gBoxTipoCalculoInventario.Enabled = existeGastos;
            
        }

        public void crearTablas()
        {
            DTProductosEspecificos = new DataTable();

            DataColumn DCCodigoProducto = new DataColumn();
            DCCodigoProducto.DataType = Type.GetType("System.String");
            DCCodigoProducto.AllowDBNull = false;
            DCCodigoProducto.Unique = false;
            DCCodigoProducto.DefaultValue = "";
            DCCodigoProducto.ColumnName = "CodigoProducto";

            DataColumn DCNombreProducto = new DataColumn();
            DCNombreProducto.DataType = Type.GetType("System.String");
            DCNombreProducto.AllowDBNull = false;
            DCNombreProducto.Unique = false;
            DCNombreProducto.DefaultValue = "";
            DCNombreProducto.ColumnName = "NombreProducto";

            DataColumn DCCodigoProductoEspecifico = new DataColumn();
            DCCodigoProductoEspecifico.DataType = Type.GetType("System.String");
            DCCodigoProductoEspecifico.AllowDBNull = false;
            DCCodigoProductoEspecifico.Unique = true;
            DCCodigoProductoEspecifico.DefaultValue = "______-1";
            DCCodigoProductoEspecifico.ColumnName = "CodigoProductoEspecifico";

            DataColumn DCTiempoGarantia = new DataColumn();
            DCTiempoGarantia.DataType = Type.GetType("System.Int16");
            DCTiempoGarantia.DefaultValue = 0;
            DCTiempoGarantia.ColumnName = "TiempoGarantiaPE";

            DataColumn DCFechaValidez = new DataColumn();
            DCFechaValidez.DataType = Type.GetType("System.DateTime");
            DCFechaValidez.ColumnName = "FechaHoraVencimientoPE";
            DCFechaValidez.DefaultValue = DateTime.Now;

            DTProductosEspecificos.Columns.AddRange(new DataColumn[] { DCNombreProducto, DCCodigoProducto,
                    DCCodigoProductoEspecifico, DCTiempoGarantia, DCFechaValidez});

            DTProductosEspecificos.PrimaryKey = null;
            DataColumn[] PrimaryKeyColumns = new DataColumn[2];
            PrimaryKeyColumns[0] = DTProductosEspecificos.Columns["CodigoProducto"];
            PrimaryKeyColumns[1] = DTProductosEspecificos.Columns["CodigoProductoEspecifico"];
            DTProductosEspecificos.PrimaryKey = PrimaryKeyColumns;
        }

        private void dtGVProductos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int CantidadNuevaDeEntrega;

            this.dtGVProductos.Rows[e.RowIndex].ErrorText = "";

            // No cell validation for new rows. New rows are validated on Row Validation.
            if (this.dtGVProductos.Rows[e.RowIndex].IsNewRow) { return; }

            if (this.dtGVProductos.IsCurrentCellDirty)
            {
                switch (this.dtGVProductos.Columns[e.ColumnIndex].Name)
                {

                    case "DGCNuevaCantidad":
                        if (e.FormattedValue.ToString().Trim().Length < 1)
                        {
                            this.dtGVProductos.Rows[e.RowIndex].ErrorText = "   La Cantidad a entregar es necesaria y no puede estar vacia.";
                            e.Cancel = true;
                        }
                        else if (!int.TryParse(e.FormattedValue.ToString(), out CantidadNuevaDeEntrega) || CantidadNuevaDeEntrega < 0)
                        {
                            this.dtGVProductos.Rows[e.RowIndex].ErrorText = "   La Cantidad a entregar debe ser un entero positivo.";
                            e.Cancel = true;
                        }

                        if (int.TryParse(e.FormattedValue.ToString(), out CantidadNuevaDeEntrega))
                        {
                            int CantidadComprada = int.Parse(this.dtGVProductos.Rows[e.RowIndex].Cells["DGCCantidadCompra"].Value.ToString());                            
                            int CantidadRecepcionada = int.Parse(this.dtGVProductos.Rows[e.RowIndex].Cells["DGCCantidadRecepcionada"].Value.ToString());
                            if (CantidadNuevaDeEntrega > (CantidadComprada - CantidadRecepcionada))
                            {
                                this.dtGVProductos.Rows[e.RowIndex].ErrorText = "   No puede entregar una cantidad superior a la Cantidad Requerida de Recepción.";
                                e.Cancel = true;
                            }                            
                        }
                        break;


                }

            }
        }

        private void dtGVProductos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //DTProductosRecepcion.AcceptChanges();
            if (dtGVProductos.RowCount > 0 && dtGVProductos.CurrentRow != null && e.ColumnIndex == DGCNuevaCantidad.Index)
            {
                string CodigoProducto = DTProductosRecepcion.Rows[e.RowIndex]["CodigoProducto"].ToString();
                string NombreProducto = DTProductosRecepcion.Rows[e.RowIndex]["NombreProducto"].ToString();
                bool EsProductoEspecifico = bool.Parse(DTProductosRecepcion.Rows[e.RowIndex]["EsProductoEspecifico"].ToString());

                if (EsProductoEspecifico)
                {
                    object CantidadProductoRegistrado = DTProductosEspecificos.Compute("count(CodigoProducto)", "CodigoProducto = '" + CodigoProducto + "'");
                    int CantidadMaxima = int.Parse(DTProductosRecepcion.Rows[e.RowIndex]["CantidadCompra"].ToString()) - int.Parse(DTProductosRecepcion.Rows[e.RowIndex]["CantidadRecepcionada"].ToString());
                    int CantidadNueva = int.Parse(DTProductosRecepcion.Rows[e.RowIndex]["NuevaCantidad"].ToString());

                    if (CantidadNueva > CantidadMaxima)
                    {
                        if (MessageBox.Show(this, "No puede Recepcionar una Cantidad que supera a lo especificado dentro de la compra incluyendo ya las partes ingresadas para este Producto"
                            + Environment.NewLine + " ¿Desea que el Sistema actualize a la Cantidad Recomendable Tope de Recepción? "
                            , this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DTProductosRecepcion.Rows[e.RowIndex]["NuevaCantidad"] = CantidadMaxima;
                            DTProductosRecepcion.Rows[e.RowIndex].AcceptChanges();
                            CantidadNueva = CantidadMaxima;
                        }
                        else
                        {
                            DTProductosRecepcion.Rows[e.RowIndex].RejectChanges();
                            dtGVProductos.CurrentCell = dtGVProductos["DGCNuevaCantidad", e.RowIndex];
                            dtGVProductos.BeginEdit(true);
                            llenadoConfirmadoPE = false;
                        }
                    }

                    if (CantidadProductoRegistrado.Equals(0))
                    {
                        FCompraProductosIngresoEspecificos _FCompraProductosIngresoEspecificos = new FCompraProductosIngresoEspecificos(CodigoProducto, CantidadNueva, NombreProducto);
                        _FCompraProductosIngresoEspecificos.ShowDialog();
                        if (_FCompraProductosIngresoEspecificos.OperacionConfirmada)
                        {
                            int indice = 0;
                            foreach (DataRow FilaNueva in _FCompraProductosIngresoEspecificos.DTProductosEspecificos.Rows)
                            {
                                DataRow DRNuevoEspecifico = DTProductosEspecificos.NewRow();
                                if (indice == 0)
                                    DRNuevoEspecifico["NombreProducto"] = NombreProducto;
                                DRNuevoEspecifico["CodigoProducto"] = CodigoProducto;
                                DRNuevoEspecifico["CodigoProductoEspecifico"] = FilaNueva["CodigoProductoEspecifico"];
                                DRNuevoEspecifico["TiempoGarantiaPE"] = FilaNueva["TiempoGarantiaPE"];
                                DRNuevoEspecifico["FechaHoraVencimientoPE"] = FilaNueva["FechaHoraVencimientoPE"];

                                DTProductosEspecificos.Rows.Add(DRNuevoEspecifico);
                                DRNuevoEspecifico.AcceptChanges();
                                indice++;

                            }
                            llenadoConfirmadoPE = true;
                        }
                        else
                        {
                            DTProductosRecepcion.Rows[e.RowIndex].RejectChanges();
                            dtGVProductos.CurrentCell = dtGVProductos["DGCNuevaCantidad", e.RowIndex];
                            dtGVProductos.BeginEdit(true);
                            llenadoConfirmadoPE = false;
                        }
                        //_FCompraProductosIngresoEspecificos.Dispose();
                    }
                    else
                    {
                        FCompraProductosIngresoEspecificos _FCompraProductosIngresoEspecificos = new FCompraProductosIngresoEspecificos(CodigoProducto, CantidadNueva, NombreProducto);
                        DataRow[] DRProductosEspecificosPorProductos = DTProductosEspecificos.Select("CodigoProducto = '" + CodigoProducto + "'");

                        foreach (DataRow DRProductoEspecifico in DRProductosEspecificosPorProductos)
                        {
                            DataRow DRNuevoProductoEspecifico = _FCompraProductosIngresoEspecificos.DTProductosEspecificos.NewRow();
                            DRNuevoProductoEspecifico["CodigoProductoEspecifico"] = DRProductoEspecifico["CodigoProductoEspecifico"];
                            DRNuevoProductoEspecifico["TiempoGarantiaPE"] = DRProductoEspecifico["TiempoGarantiaPE"];
                            DRNuevoProductoEspecifico["FechaHoraVencimientoPE"] = DRProductoEspecifico["FechaHoraVencimientoPE"];

                            _FCompraProductosIngresoEspecificos.DTProductosEspecificos.Rows.Add(DRNuevoProductoEspecifico);
                            DRNuevoProductoEspecifico.AcceptChanges();
                        }

                        

                        int CantidadRegistrada = int.Parse(CantidadProductoRegistrado.ToString());
                        if (CantidadNueva > CantidadRegistrada) // se Adicionan mas Productos
                        {
                            _FCompraProductosIngresoEspecificos.ShowDialog();
                            if (_FCompraProductosIngresoEspecificos.OperacionConfirmada)
                            {
                                foreach (DataRow DRProductoNuevo in _FCompraProductosIngresoEspecificos.DTProductosEspecificos.Rows)
                                {
                                    if (DTProductosEspecificos.Rows.Find(new object[] { CodigoProducto, DRProductoNuevo["CodigoProductoEspecifico"] }) == null)
                                    {
                                        DataRow DRNuevoEspecifico = DTProductosEspecificos.NewRow();
                                        DRNuevoEspecifico["CodigoProducto"] = CodigoProducto;
                                        DRNuevoEspecifico["CodigoProductoEspecifico"] = DRProductoNuevo["CodigoProductoEspecifico"];
                                        DRNuevoEspecifico["TiempoGarantiaPE"] = DRProductoNuevo["TiempoGarantiaPE"];
                                        DRNuevoEspecifico["FechaHoraVencimientoPE"] = DRProductoNuevo["FechaHoraVencimientoPE"];

                                        DTProductosEspecificos.Rows.Add(DRNuevoEspecifico);
                                        DRNuevoEspecifico.AcceptChanges();
                                    }
                                }
                                llenadoConfirmadoPE = true;
                            }
                            else
                            {
                                DTProductosRecepcion.Rows[e.RowIndex].RejectChanges();
                                dtGVProductos.CurrentCell = dtGVProductos["DGCNuevaCantidad", e.RowIndex];
                                dtGVProductos.BeginEdit(true);
                                llenadoConfirmadoPE = false;
                            }
                        }
                        else // Cuando disminuyen la cantidad, se debe eliminar codigos especificos
                        {                            
                            MessageBox.Show("Debe Seleccionar los productos Específicos que desea eliminar");
                            _FCompraProductosIngresoEspecificos.ShowDialog();
                            if (_FCompraProductosIngresoEspecificos.OperacionConfirmada && _FCompraProductosIngresoEspecificos.ListadoProductosEspecificosEliminados.Count > 0)
                            {
                                foreach (string codEspecifico in _FCompraProductosIngresoEspecificos.ListadoProductosEspecificosEliminados)
                                {
                                    DataRow DRProductoEliminar = DTProductosEspecificos.Rows.Find(new object[] { CodigoProducto, codEspecifico });
                                    if (DRProductoEliminar != null)
                                        DTProductosEspecificos.Rows[DTProductosEspecificos.Rows.IndexOf(DRProductoEliminar)].Delete();

                                }
                                llenadoConfirmadoPE = true;
                            }
                            else
                            {
                                DTProductosRecepcion.Rows[e.RowIndex].RejectChanges();
                                dtGVProductos.CurrentCell = dtGVProductos["DGCNuevaCantidad", e.RowIndex];
                                dtGVProductos.BeginEdit(true);
                                llenadoConfirmadoPE = false;
                            }
                        }
                        //_FCompraProductosIngresoEspecificos.Dispose();
                    }
                    DTProductosRecepcion.AcceptChanges();
                    DTProductosEspecificos.AcceptChanges();
                }
            }
        }

        private void dtGVProductosEspecificos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DTProductosRecepcion.Rows.Count > 0)
            {

                if (dtGVProductosEspecificos.Rows[e.RowIndex].Cells[0].Value != null && !dtGVProductosEspecificos.Rows[e.RowIndex].Cells[0].Value.Equals(""))
                {
                    dtGVProductosEspecificos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Bisque;
                    dtGVProductosEspecificos.Rows[e.RowIndex].Cells["DGCNombreProductoPE"].Style.Font = new Font(fuenteDefecto.Name, fuenteDefecto.Size, FontStyle.Bold);
                }
            }
        }



        private void btnConfirmarTodo_Click(object sender, EventArgs e)
        {
            ////QUITAR
            //DataTable DTProductosDetalleEntrega2 = this.DTProductosRecepcion.Copy();
            //DTProductosDetalleEntrega2.TableName = "ProductosDetalleEntrega";
            //DataSet DSProductosEntrega2 = new DataSet("Productos");
            //DSProductosEntrega2.Tables.Add(DTProductosDetalleEntrega2);
            //DTProductosDetalleEntrega2.Columns.Remove(DTProductosDetalleEntrega2.Columns["NombreProducto"]);
            //string XML = DTProductosDetalleEntrega2.DataSet.GetXml();
            //Clipboard.SetText(XML);
            //return;
            ////QUITAR

            Button btnSeleccionado = sender as Button;
            if (btnSeleccionado.Name.CompareTo("btnForzarFinalizacion") == 0)
            {
                if (MessageBox.Show(this, "Esta apunto de Recepcionar una Orden de Compra INCOMPLETA, tome en cuenta que la confirmación de la operación es Irreversible y generará una Cuenta por Cobrar a su Proveedor ¿Desea continuar en estas condiciones?",
                    "Confirmación Incompleta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                
            }
            else
            {
                if (MessageBox.Show(this, "¿Está seguro de recepcionar los productos de esta Orden de Compra?", "Confirmación de Recepción de mercaderia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }            
            
            
            string listadoProductos = "";
            DateTime FechaHoraRecepcion = _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor();
            Decimal MontoIncrementoProrrateo = 0;

            if (btnSeleccionado.Name.CompareTo("btnConfirmarTodo") == 0)
            {
                foreach (DataRow DRFilaProducto in DTProductosRecepcion.Rows)
                {
                    //DRFilaProducto["NuevaCantidad"] = int.Parse(DRFilaProducto["CantidadCompra"].ToString()) - int.Parse(DRFilaProducto["CantidadRecepcionada"].ToString());
                    dtGVProductos.Rows[DTProductosRecepcion.Rows.IndexOf(DRFilaProducto)].Cells["DGCNuevaCantidad"].Value = int.Parse(DRFilaProducto["CantidadCompra"].ToString()) - int.Parse(DRFilaProducto["CantidadRecepcionada"].ToString());
                    if (!llenadoConfirmadoPE && DRFilaProducto["EsProductoEspecifico"].Equals(true))
                    {
                        MessageBox.Show(this, "No se puede realizar la confirmación completa, Debido a que aún no ha ingresado los Códigos Específicos de los Productos", "Ingreso incompleto de Códigos Especificos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        DRFilaProducto.RejectChanges();
                        return;
                    }
                    DRFilaProducto.AcceptChanges();
                }
                listadoProductos = "";
            }
            else
            {                
                if (DTProductosRecepcion.Compute("sum(NuevaCantidad)", "").ToString().Equals("0"))
                {
                    MessageBox.Show(this, "Aún no ha ingresado un cantidad nueva de ingreso para la recepción del listado de productos Actual", "Cantidades Minimas no ingresadas", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }

                int cantidad = 0;
                foreach (DataRow DRFilaProducto in DTProductosRecepcion.Rows)
                {
                    cantidad = int.Parse(DRFilaProducto["NuevaCantidad"].ToString());
                    if (cantidad > 0)
                        listadoProductos += "'" + DRFilaProducto["CodigoProducto"].ToString().Trim() + "',";
                }
                listadoProductos = listadoProductos.Substring(0, listadoProductos.Length - 1);
                
            }

            

            FCompraProductosGastosListado _FCompraProductosGastosListado;
            CLCAD.DSDoblones20GestionComercial.ListarProductosRecepcionadosTipoCalculoInventarioDataTable DTProductosSeleccionados;



            _FCompraProductosGastosListado = new FCompraProductosGastosListado(NumeroAgencia, NumeroCompraProducto, listadoProductos);
            _FCompraProductosGastosListado.DTProductosRecepcion = this.DTProductosRecepcion;
            if (existeGastos)
            {

                //Debemos seleccionar a que recepcion aplicará los gastos que existen actualmente
                //incluso en el caso de que no hay aún una recepción alguna, debe seleccionarce la actual Recepción
                //mostrarFormulario
                if (MessageBox.Show(this, "Existen gastos Registrados para esta Recepción ¿Desea Aplicar los mismos en la Actualización de su Inventario?", "Existencia de gastos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    FCompraProductosSeleccionActualizarPrecios formCompraProductosSeleccionRecepcion = new FCompraProductosSeleccionActualizarPrecios(NumeroAgencia, NumeroPC, NumeroCompraProducto, FechaHoraRecepcion);
                    formCompraProductosSeleccionRecepcion.DTProductosRecepcionReciente = DTProductosRecepcion;
                    formCompraProductosSeleccionRecepcion.ShowDialog();
                    if (!formCompraProductosSeleccionRecepcion.OperacionConfirmada)
                    {
                        MessageBox.Show(this, "No selecciono ni una recepción de Productos para aplicar los Gastos actuales", "Selección incompleta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        DTProductosRecepcion.RejectChanges();
                        return;
                    }

                    DTCompraProductosRecepcionSeleccionados = formCompraProductosSeleccionRecepcion.DTListadoFechas;
                    DTCompraProductosRecepcionHistorial = formCompraProductosSeleccionRecepcion.DTCompraProductosRecepcionHistorial;

                    _FCompraProductosGastosListado.setTablasCalculoPrecioIncremento(DTCompraProductosRecepcionSeleccionados, DTCompraProductosRecepcionHistorial);
                    if (rBtnGastosProrrateados.Checked)
                    {
                        _FCompraProductosGastosListado.formatearParaCompraConGastosRepartidos();
                    }
                    else if (rBtnPersonalizado.Checked)
                    {
                        _FCompraProductosGastosListado.formatearParaCompraConGastosPersonalizados();
                    }
                    else if (rbtnTablas.Checked)
                    {
                        //para el uso de Tablas
                    }

                }
                else
                {
                    _FCompraProductosGastosListado.formatearParaCompraSinGastos();
                }                
            }
            else
            {
                _FCompraProductosGastosListado.formatearParaCompraSinGastos();                
            }
            
            _FCompraProductosGastosListado.ShowDialog(this);
            if (_FCompraProductosGastosListado.OperacionConfirmada)
            {

                //Generamos una cuenta por cobrar al proveedor, debido a que la recepción de merecaderia
                //es incompleta                
                if ((btnSeleccionado.Name.CompareTo("btnForzarFinalizacion") == 0) && !DTProductosRecepcion.Compute("sum(CantidadFaltante)", "").ToString().Equals("0"))
                {
                    FCuentasPorCobrarNuevo _FCuentasPorCobrarNuevo = new FCuentasPorCobrarNuevo(CodigoUsuario, NumeroAgencia, true, true, true, true, true);
                    //_FCuentasPorCobrarNuevo.cargarDatosParaCompraACredito(""
                    DataTable DTCompraProductos = _ComprasProductosCLN.ObtenerCompraProducto(NumeroAgencia, NumeroCompraProducto);
                    if (DTCompraProductos.Rows.Count > 0)
                    {
                        //ProductosDetalleEntrega
                        DataTable DTProductosDetalleEntrega = this.DTProductosRecepcion.Copy();
                        DTProductosDetalleEntrega.TableName = "ProductosDetalleEntrega";
                        DataSet DSProductosEntrega = new DataSet("Productos");
                        DSProductosEntrega.Tables.Add(DTProductosDetalleEntrega);
                        DTProductosDetalleEntrega.Columns.Remove(DTProductosDetalleEntrega.Columns["NombreProducto"]);
                        Decimal MontoTotalCobro = _TransaccionesUtilidadesCLN.ObtenerMontoTotalRealCobroCompraProductosIncompleta(NumeroAgencia, NumeroCompraProducto, DTProductosDetalleEntrega.DataSet.GetXml());

                        if (MontoTotalCobro > 0)
                        {

                            DataTable VariablesConfiguracionSistemaGC;
                            PCsConfiguracionesCLN PCConfiguracion = new PCsConfiguracionesCLN();
                            VariablesConfiguracionSistemaGC = PCConfiguracion.ObtenerConfiguracionSistemaParaTransaccionesGC(NumeroPC);

                            byte CodigoMonedaSistema = byte.Parse(VariablesConfiguracionSistemaGC.Rows[0][3].ToString());

                            _FCuentasPorCobrarNuevo.cargarDatosParaCompra("RECEPCION INCOMPLETA DE MERCADERIA POR COMPRAS A CREDITO",
                                int.Parse(DTCompraProductos.Rows[0]["CodigoProveedor"].ToString()),
                                //int.Parse(DTCompraProductos.Rows[0]["CodigoMoneda"].ToString()),
                                CodigoMonedaSistema,
                                //"DOLARES",
                                MontoTotalCobro, MontoTotalCobro,
                                "La correspondiente Cuenta por Cobrar pertenece a la Orden de Compra Nro " + NumeroCompraProducto.ToString() +", debido a la entrega incompleta de productos");

                            if (_FCuentasPorCobrarNuevo.ShowDialog(this) != DialogResult.OK)
                            {
                                MessageBox.Show(this, "No ha aceptado la opción de creación de una cuenta por Cobrar a su proveedor", "Cuenta Por Cobrar Rechazada", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                        }
                    }
                }

                bool aplicarGastos = _FCompraProductosGastosListado.ChecUtilizarGastosActuales.Checked;
                try
                {
                    DTProductosSeleccionados = _FCompraProductosGastosListado.DTProductosRecepcionados;
                    
                    int CantidadNueva;
                    string CodigoProducto, FilaCodigoProductoOpcion = "";

                    ListaCodigoSeleccionadosOpciones.Clear();
                    foreach (DataRow DRProducto in DTProductosRecepcion.Rows)
                    {
                        CantidadNueva = int.Parse(DRProducto["NuevaCantidad"].ToString());

                        if (CantidadNueva > 0)
                        {
                            CodigoProducto = DRProducto["CodigoProducto"].ToString();
                            CLCAD.DSDoblones20GestionComercial.ListarProductosRecepcionadosTipoCalculoInventarioRow FilaProductoTipoCalculo = DTProductosSeleccionados.FindByCodigoProducto(CodigoProducto);

                            if (FilaProductoTipoCalculo["ActualizarPrecioVenta"].Equals(true))
                            {
                                FilaCodigoProductoOpcion += CodigoProducto.Trim() + ";" + (FilaProductoTipoCalculo["ActualizarPrecioVenta"].Equals(true) ? "1" : "0") + (FilaProductoTipoCalculo["Promedio"].Equals(true) ? "1" : "0") + (FilaProductoTipoCalculo["UltimaRecepcion"].Equals(true) ? "1" : "0") + "|";
                            }
                            else
                            {
                                FilaCodigoProductoOpcion += CodigoProducto.Trim() + ";" + "000" + "|";
                            }

                            //ListaCodigoSeleccionadosOpciones.Add(CodigoProducto + ";" + (FilaProductoTipoCalculo.ActualizarPrecioVenta ? "1" : "0") + (FilaProductoTipoCalculo.Promedio ? "1" : "0") + (FilaProductoTipoCalculo.UltimaRecepcion ? "1" : "0") + "|");


                            _ComprasProductosDetalleEntregaCLN.InsertarCompraProductoDetalleEntrega(NumeroAgencia, NumeroCompraProducto, CodigoProducto, CantidadNueva, FechaHoraRecepcion);

                             
                            //REVISAR
                            //Quitar estas opciones en caso de que haya casos en que no se debe llevar
                            // un historial de la recepción de productos
                            //if (!existeGastos && rBtnGastosRepartidos.Checked)
                            //{
                            //    _InventariosProductosCLN.InsertarInventarioProductosCantidadesComprasHistorial(NumeroAgencia, NumeroCompraProducto, CodigoProducto, FechaHoraRecepcion, CantidadNueva, FilaProductoTipoCalculo.PrecioUnitarioCompra);
                            //}
                            //if (rBtnPersonalizado.Checked && existeGastos && aplicarGastos)
                            //{
                            //    _InventariosProductosCLN.InsertarInventarioProductosCantidadesComprasHistorial(NumeroAgencia, NumeroCompraProducto, CodigoProducto, FechaHoraRecepcion, CantidadNueva, FilaProductoTipoCalculo.PrecioUnitarioCompra + decimal.Parse(FilaProductoTipoCalculo["MontoGastoProducto"].ToString()));
                            //}
                            //if (rBtnPersonalizado.Checked && existeGastos && !aplicarGastos)
                            //{
                            //    _InventariosProductosCLN.InsertarInventarioProductosCantidadesComprasHistorial(NumeroAgencia, NumeroCompraProducto, CodigoProducto, FechaHoraRecepcion, CantidadNueva, FilaProductoTipoCalculo.PrecioUnitarioCompra);
                            //}
                            if (!rBtnGastosProrrateados.Checked)
                            {
                                //hay que aumentar el monto que se adquiere por el gasto y dividirla por la cantidad , siempre y cuando sea recepción completa
                                //FilaProductoTipoCalculo["ActualizarPrecioVenta"].Equals(true)
                                //FilaProductoTipoCalculo["Promedio"].Equals(true) 
                                //FilaProductoTipoCalculo["UltimaRecepcion"].Equals(true)
                                if (aplicarGastos && rBtnPersonalizado.Checked)
                                {
                                    _InventariosProductosCLN.InsertarInventarioProductosCantidadesComprasHistorial(NumeroAgencia, NumeroCompraProducto, CodigoProducto, FechaHoraRecepcion, CantidadNueva, FilaProductoTipoCalculo.PrecioUnitarioCompra + decimal.Parse(FilaProductoTipoCalculo["MontoGastoProducto"].ToString()));
                                }
                                else //para cualquier otro caso
                                {
                                    _InventariosProductosCLN.InsertarInventarioProductosCantidadesComprasHistorial(NumeroAgencia, NumeroCompraProducto, CodigoProducto, FechaHoraRecepcion, CantidadNueva, FilaProductoTipoCalculo.PrecioUnitarioCompra);
                                }
                            }
                            if (rBtnGastosProrrateados.Checked)
                            {
                                if((existeGastos && !aplicarGastos)
                                    || (!existeGastos && !aplicarGastos)
                                    || (!existeGastos &&  aplicarGastos)
                                    )
                                    _InventariosProductosCLN.InsertarInventarioProductosCantidadesComprasHistorial(NumeroAgencia, NumeroCompraProducto, CodigoProducto, FechaHoraRecepcion, CantidadNueva, FilaProductoTipoCalculo.PrecioUnitarioCompra);
                                
                            }

                            if (DRProducto["EsProductoEspecifico"].Equals(true))
                            {
                                string CodigoProductoEspecifico;
                                int TiempoGarantiaPE;
                                DateTime FechaHoraVencimientoPE;
                                DataRow[] DRProductosEspecificos = DTProductosEspecificos.Select(" CodigoProducto = '" + CodigoProducto.Trim() + "'");
                                foreach (DataRow DRProductoPE in DRProductosEspecificos)
                                {
                                    CodigoProductoEspecifico = DRProductoPE["CodigoProductoEspecifico"].ToString();
                                    TiempoGarantiaPE = int.Parse(DRProductoPE["TiempoGarantiaPE"].ToString());
                                    FechaHoraVencimientoPE = DateTime.Parse(DRProductoPE["FechaHoraVencimientoPE"].ToString());

                                    _ComprasProductosEspecificosCLN.InsertarCompraProductoEspecifico(NumeroAgencia, NumeroCompraProducto, CodigoProducto, CodigoProductoEspecifico, TiempoGarantiaPE, FechaHoraVencimientoPE, FechaHoraRecepcion);
                                    _InventariosProductosEspecificosCLN.InsertarInventarioProductoEspecifico(NumeroAgencia, CodigoProducto, CodigoProductoEspecifico, TiempoGarantiaPE, FechaHoraVencimientoPE, "C", "A");
                                }
                            }

                        }
                    }

                    FilaCodigoProductoOpcion = FilaCodigoProductoOpcion.Substring(0, FilaCodigoProductoOpcion.Length - 1);

                    

                    if (existeGastos && aplicarGastos && rBtnGastosProrrateados.Checked)
                    {//Actualizamos a la ultima recepcion, todos los gastos existentes actualmente
                        //FilaProductoTipoCalculo["ActualizarPrecioVenta"].Equals(true)
                        //FilaProductoTipoCalculo["Promedio"].Equals(true) 
                        //FilaProductoTipoCalculo["UltimaRecepcion"].Equals(true)
                        MontoIncrementoProrrateo = decimal.Parse(DTProductosSeleccionados[0]["MontoGastoProducto"].ToString());
                        if(DTCompraProductosRecepcionSeleccionados.Rows.Count == 1
                            && DTCompraProductosRecepcionSeleccionados.Rows[0]["Seleccionar"].Equals(true))
                            _InventariosProductosCLN.InsertarInventarioProductosCantidadesComprasHistorialAplicandoGastos(NumeroAgencia, NumeroCompraProducto, FechaHoraRecepcion);
                        else
                            _InventariosProductosCLN.InsertarInventarioProductosCantidadesComprasHistorialAplicandoGastosConMonto(NumeroAgencia, NumeroCompraProducto, FechaHoraRecepcion, MontoIncrementoProrrateo);
                    }

                    _TransaccionesUtilidadesCLN.ActualizarInventarioProductosCompras(NumeroAgencia, NumeroCompraProducto, FilaCodigoProductoOpcion);

                    //cargar el Reporte
                    cargarReportePorPartes(FechaHoraRecepcion);
                    if (aplicarGastos)
                    {
                        _CompraProductosGastosDetalleCLN.ActualizarCompraProductosGastosDetalleGeneral(NumeroAgencia, NumeroCompraProducto);
                    }

                    if (btnSeleccionado.Name.CompareTo("btnConfirmarTodo") == 0)
                    {
                        _ComprasProductosCLN.ActualizarCodigoEstadoCompra(NumeroAgencia, NumeroCompraProducto, "F", null);
                        _TransaccionesUtilidadesCLN.InsertarAsientosTransacciones(CodigoUsuario,
                                    "Asiento Contable Correspondiente a Nuemro de Compra " + NumeroCompraProducto.ToString(),
                                    "C", NumeroCompraProducto, "C", NumeroAgencia);
                    }
                    else
                    {

                        if (btnSeleccionado.Name.CompareTo("btnConfirmarParcialmente") == 0)
                        {
                            if (DTProductosRecepcion.Compute("sum(CantidadFaltante)", "").ToString().Equals("0"))
                            {
                                _ComprasProductosCLN.ActualizarCodigoEstadoCompra(NumeroAgencia, NumeroCompraProducto, "F", null);
                                _TransaccionesUtilidadesCLN.InsertarAsientosTransacciones(CodigoUsuario,
                                    "Asiento Contable Correspondiente a Nuemro de Compra " + NumeroCompraProducto.ToString(),
                                    "C", NumeroCompraProducto, "C", NumeroAgencia);
                            }
                            else
                            {
                                _ComprasProductosCLN.ActualizarCodigoEstadoCompra(NumeroAgencia, NumeroCompraProducto, "D", null);
                            }
                        }
                        else if (btnSeleccionado.Name.CompareTo("btnForzarFinalizacion") == 0)
                        {
                            if (DTProductosRecepcion.Compute("sum(CantidadFaltante)", "").ToString().Equals("0"))
                            {
                                _ComprasProductosCLN.ActualizarCodigoEstadoCompra(NumeroAgencia, NumeroCompraProducto, "F", null);
                                _TransaccionesUtilidadesCLN.InsertarAsientosTransacciones(CodigoUsuario,
                                    "Asiento Contable Correspondiente a Nuemro de Compra " + NumeroCompraProducto.ToString(),
                                    "C", NumeroCompraProducto, "C", NumeroAgencia);                           
                            }
                            else
                            {
                                _ComprasProductosCLN.ActualizarCodigoEstadoCompra(NumeroAgencia, NumeroCompraProducto, "X", null);
                                /*aqui serciorarse de que la cuenta por cobrar exista*/

                                _TransaccionesUtilidadesCLN.InsertarAsientosTransacciones(CodigoUsuario,
                                   "Asiento Contable Correspondiente a Nuemro de Compra " + NumeroCompraProducto.ToString(),
                                   "C", NumeroCompraProducto, "C", NumeroAgencia);
                            }
                        }
                        
                    }
            
                    
                    MessageBox.Show(this, "Se realizó correctamente la recepción de Productos", "Recepción de Mercadería", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DTProductosRecepcion = _ComprasProductosDetalleCLN.ListarCompraProductosDetalleEntregados(NumeroAgencia, NumeroCompraProducto, true);
                    DTProductosEspecificos.Clear();
                    btnConfirmarParcialmente.Enabled = false;
                    btnConfirmarTodo.Enabled = false;
                    btnForzarFinalizacion.Enabled = false;
                    dtGVProductos.Enabled = false;
                    OperacionConfirmada = true;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio la siguiente Excepción : \r\n" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("La Operación ha sido Cancelada");
            }
            
        }

        public void cargarReportePorPartes(DateTime FechaHoraRecepcion)
        {
            DataTable DTCompraProductos = _ComprasProductosCLN.ListarCompraProductoReporte(NumeroAgencia, NumeroCompraProducto);
            DataTable DTCompraProductosGastos = _ComprasProductosCLN.ListarCompraProductosGastosRecepcionPartesReportes(NumeroAgencia, NumeroCompraProducto, false);
            DataTable DTCompraProductosRecepcion = _ComprasProductosCLN.ListarProductosRecepcionadosPorFechaReporte(NumeroAgencia, NumeroCompraProducto, FechaHoraRecepcion);

            FReporteCompraProductosRecepcion _FReporteCompraProductosRecepcion = new FReporteCompraProductosRecepcion(DTCompraProductos, DTCompraProductosRecepcion, DTCompraProductosGastos, false);
            _FReporteCompraProductosRecepcion.ShowDialog(this);
            _FReporteCompraProductosRecepcion.Dispose();
        }

        private void dtGVProductos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("error");
            e.Cancel = true;
            e.ThrowException = false;
        }

        private void FCompraProductosRecepcionInventarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!OperacionConfirmada && MessageBox.Show(this, "No ha confirmado la Operación Actual. ¿Desea Cancelar la Operación?", "Recepción de Mercadería", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }


        public bool esRecepcionCompleta()
        {
            //int CantidadTotalCompra = 0, CantidadTotalRecepcionada = 0, CantidadTotalRecepcionActual = 0;
            //CantidadTotalCompra = (int)DTProductosRecepcion.Compute("sum(CantidadCompra)", "");
            //CantidadTotalRecepcionada = (int)DTProductosRecepcion.Compute("sum(CantidadCompra)", "");
            //CantidadTotalRecepcionActual = (int)DTProductosRecepcion.Compute("sum(CantidadCompra)", "");

            //return (CantidadTotalCompra == (CantidadTotalRecepcionActual + CantidadTotalRecepcionada));
            return DTProductosRecepcion.Compute("sum(CantidadFaltante)", "").ToString().Equals("0");
        }

    }
}
