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
using WFADoblones20.FormulariosGestionComercial;
using CLCAD;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FVentasProductosEntregar2 : Form
    {
        CLCAD.DSDoblones20GestionComercial.ListarVentaProductosDetalleParaAlmacenesDataTable DTVentasProductosDetalle;
        CLCAD.DSDoblones20GestionComercial.ListarVentaProductosDetalleParaAlmacenesDataTable DTVentasProductosDetalleCopy;
        DataTable DTVentasProductosDetalleActual;
        DataTable _DTProductosEspecificosSeleccionadosPorUsuarioTemporal;
        DataTable _DTProductosEspecificosTemporal;
        DataTable _DTProductosDetalleEntrega;

        DataSet DSProductosEspecificos;
        
        int NumeroAgencia;
        int NumeroVentaProducto;
        int CodigoUsuario;
        
        InventariosProductosEspecificosCLN InventarioProductoEspecificoCLN;
        VentasProductosCLN _VentasProductosCLN;
        TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;
        VentasProductosEspecificosCLN VentaProductosEspecificosCLN;
                
        FReporteVentaProductosReciboEntregados ReporteProductosEntregados;
        FIngresarCantidad formIngresarCantidad;
        FTransferenciaProductosRecepcionEnvioPE _FTransferenciaProductosRecepcionEnvioPE;

        bool esNecesarioLlenarPE = false;
        bool usuarioSeleccionaEspecifico = false;
        bool conProductosEspecificos = false;
        bool confirmacionTotal = true;
        public bool OperacionConfirmada = false;
        public bool permitirDeshabilitar = false;
        string TipoOperacion = "C"; //'C'->Confirmación de Entrega de Productos,  'M'->Mostrar solo Productos
        string EstadoVentaActual_deEntrega;

        public string CodigoEstadoVenta { get; set; }
        Font fuenteDefecto;
        DateTime FechaHoraEntrega;
        public FVentasProductosEntregar2(int NumeroAgencia, int NumeroVentaProducto, int CodigoUsuario)
        {
            InitializeComponent();
            this.NumeroAgencia = NumeroAgencia;
            this.NumeroVentaProducto = NumeroVentaProducto;
            this.CodigoUsuario = CodigoUsuario;
            _VentasProductosCLN = new VentasProductosCLN();
            InventarioProductoEspecificoCLN = new InventariosProductosEspecificosCLN();
            VentaProductosEspecificosCLN = new VentasProductosEspecificosCLN();
            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();

            dtGVDetalleProductosEntrega.AutoGenerateColumns = false;
            dtGVProductosEntregaEspecificos.AutoGenerateColumns = false;
            dtGVProductosEntregar.AutoGenerateColumns = false;

            DSProductosEspecificos = new DataSet();

            crearColumnasDTProductos();
            dtGVProductosEntregar.DataSource = _DTProductosDetalleEntrega;
            dtGVProductosEntregaEspecificos.DataSource = _DTProductosEspecificosTemporal;
            formIngresarCantidad = new FIngresarCantidad();
            fuenteDefecto = dtGVDetalleProductosEntrega.Font;
            FechaHoraEntrega = _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor();
        }

        public void crearColumnasDTProductos()
        {

            DataColumn DCNombreProducto = new DataColumn();
            DCNombreProducto.DataType = Type.GetType("System.String");
            DCNombreProducto.ColumnName = "NombreProducto";
            DCNombreProducto.ReadOnly = false;
            DCNombreProducto.DefaultValue = " ";

            DataColumn DCCodigoProducto = new DataColumn();
            DCCodigoProducto.DataType = Type.GetType("System.String");
            DCCodigoProducto.ColumnName = "CodigoProducto";
            DCCodigoProducto.ReadOnly = false;
            DCCodigoProducto.DefaultValue = " ";

            DataColumn DCCodigoProductoEspecifico = new DataColumn();
            DCCodigoProductoEspecifico.DataType = Type.GetType("System.String");
            DCCodigoProductoEspecifico.AllowDBNull = false;
            DCCodigoProductoEspecifico.Unique = true;
            DCCodigoProductoEspecifico.DefaultValue = "______-1";
            DCCodigoProductoEspecifico.ColumnName = "CodigoProductoEspecifico";

            DataColumn DCTiempoGarantia = new DataColumn();
            DCTiempoGarantia.DataType = Type.GetType("System.Int32");
            DCTiempoGarantia.DefaultValue = 0;
            DCTiempoGarantia.AllowDBNull = true;
            DCTiempoGarantia.ColumnName = "TiempoGarantiaPE";

            //DataColumn DCDespachado = new DataColumn();
            //DCDespachado.DataType = Type.GetType("System.Boolean");
            //DCDespachado.DefaultValue = false;
            //DCDespachado.ColumnName = "EspecificoDespachado";


            _DTProductosEspecificosTemporal = new DataTable("ProductosEspecificosDetalleEntrega");

            _DTProductosEspecificosTemporal.Columns.Add(DCCodigoProducto);
            _DTProductosEspecificosTemporal.Columns.Add(DCNombreProducto);            
            _DTProductosEspecificosTemporal.Columns.Add(DCCodigoProductoEspecifico);
            _DTProductosEspecificosTemporal.Columns.Add(DCTiempoGarantia);
            //_DTProductosEspecificosTemporal.Columns.Add(DCDespachado);

            _DTProductosEspecificosTemporal.PrimaryKey = null;
            DataColumn[] PrimaryKeyColumns = new DataColumn[2];
            PrimaryKeyColumns[0] = _DTProductosEspecificosTemporal.Columns["CodigoProducto"];
            PrimaryKeyColumns[1] = _DTProductosEspecificosTemporal.Columns["CodigoProductoEspecifico"];            
            _DTProductosEspecificosTemporal.PrimaryKey = PrimaryKeyColumns;
            _DTProductosEspecificosTemporal.DefaultView.Sort = "CodigoProducto ASC";


            _DTProductosDetalleEntrega = new DataTable("ProductosDetalleEntrega");
            DCCodigoProducto = new DataColumn("CodigoProducto", Type.GetType("System.String"));
            DCNombreProducto = new DataColumn("NombreProducto", Type.GetType("System.String"));
            _DTProductosDetalleEntrega.Columns.AddRange(new DataColumn[] { DCCodigoProducto, DCNombreProducto, new DataColumn("CantidadNuevaEntrega", Type.GetType("System.Int32")) });

            _DTProductosDetalleEntrega.PrimaryKey = new DataColumn[] { _DTProductosDetalleEntrega.Columns["CodigoProducto"] };


            DSProductosEspecificos = new DataSet("VentaProductosEntrega");
            DSProductosEspecificos.Tables.AddRange(new DataTable[]{_DTProductosEspecificosTemporal, _DTProductosDetalleEntrega});
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.OperacionConfirmada = false;
            this.Close();
        }

        private void FVentasProductosEntregar2_Load(object sender, EventArgs e)
        {
            lblEstado.Text = "_____";
            lblFechaVenta.Text = "_____";
            lblNumeroVenta.Text = "_____";

            DTVentasProductosDetalle = (CLCAD.DSDoblones20GestionComercial.ListarVentaProductosDetalleParaAlmacenesDataTable)_VentasProductosCLN.ListarVentaProductosDetalleParaAlmacenes(NumeroAgencia, NumeroVentaProducto);
            DataColumn DTCantidadNueva = new DataColumn("CantidadNuevaEntrega", Type.GetType("System.Int32"));
            DTCantidadNueva.DefaultValue = 0;            
            DTVentasProductosDetalle.Columns.Add(DTCantidadNueva);            
            DTVentasProductosDetalle.Columns.Add("Seleccionar", Type.GetType("System.Boolean"));            
            DTVentasProductosDetalle.AcceptChanges();


            DTVentasProductosDetalleCopy = (CLCAD.DSDoblones20GestionComercial.ListarVentaProductosDetalleParaAlmacenesDataTable)DTVentasProductosDetalle.Copy();
            dtGVDetalleProductosEntrega.DataSource = DTVentasProductosDetalle;

            CodigoEstadoVenta = _TransaccionesUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(NumeroAgencia, NumeroVentaProducto, "V");
            //if (CodigoEstadoVenta == "T" || CodigoEstadoVenta == "P")
            //{
                
            //    this.btnConfirmarEntrega.Visible = true;
            //    this.btnConfirmarParcial.Visible = false;
            //    this.btnConfirmarTodo.Visible = false;
            //    this.btnForzarConfirmacion.Visible = false;
            //    this.DGCSeleccionar.Visible = false;
            //    this.DGCNuevaCantidad.ReadOnly = true;
            //}
            //else
            //{
            //    this.btnConfirmarEntrega.Visible = false;
            //    this.btnConfirmarParcial.Visible = true;
            //    this.btnConfirmarTodo.Visible = true;
            //    this.btnForzarConfirmacion.Visible = true;
            //    this.DGCSeleccionar.Visible = true;                
            //    //dtGVProductos.Columns["DGCCantidadEntregada"].HeaderText = "Entregados";
            //}

            conProductosEspecificos = DTVentasProductosDetalle.Compute("count(EsProductoEspecifico)", "EsProductoEspecifico = true").ToString().CompareTo("0") == 0 ? false : true;

           
            EstadoVentaActual_deEntrega = _VentasProductosCLN.obtenerEstadoVentaFinalizadaParaAlmacenes(NumeroAgencia, NumeroVentaProducto);
            esNecesarioLlenarPE = this._TransaccionesUtilidadesCLN.esNecesarioLlenarProductosEspecificos(NumeroAgencia, NumeroVentaProducto);


            switch (EstadoVentaActual_deEntrega)
            {
                case "P"://Se registro completamente los PE pero su entrega y completación está pendiente, ES UNA ENTREGA POR PARTES, en este caso el usuario aunmenta la cantidad que quiere antregar ahora                    
                    this.btnForzarConfirmacion.Enabled = true;
                    this.btnConfirmarParcial.Enabled = true;
                    this.btnConfirmarTodo.Enabled = true;
                    DGCSeleccionar.ReadOnly = false;
                    DGCNuevaCantidad.ReadOnly = false;
                    lblEstado.Text = "Entrega Parcial (Completar Entrega)";
                    break;
                case "T"://Se Entrego los productos y sus registro de PE esta completo
                    this.btnForzarConfirmacion.Enabled = false;
                    this.btnConfirmarParcial.Enabled = false;
                    this.btnConfirmarTodo.Enabled = false;
                    lblEstado.Text = "Entrega Completa (Imprimir Recibo de Conformidad)";
                    DGCSeleccionar.ReadOnly = true;
                    DGCNuevaCantidad.ReadOnly = true;
                    break;
                case "E"://en este caso se debe proceder a llenar los PE para su entrega inmediata e imprimir recibo de conformidad
                    this.btnForzarConfirmacion.Enabled = true;
                    this.btnConfirmarParcial.Enabled = true;
                    this.btnConfirmarTodo.Enabled = true;
                    lblEstado.Text = "Registro Códigos Especificos (Seleccionar Productos Específicos)";
                    DGCSeleccionar.ReadOnly = true;
                    DGCNuevaCantidad.ReadOnly = true;
                    break;
                case "C"://Combinacion de casos, ni se ha registrado en totalidad sus PE y ni su entrega esta completa, ES UNA ENTREGA POR PARTES, la 2da o nsima parte de entrega
                    this.btnForzarConfirmacion.Enabled = true;
                    this.btnConfirmarParcial.Enabled = true;
                    this.btnConfirmarTodo.Enabled = true;
                    lblEstado.Text = "Registro de Códigos Específicos y Entrega Incompleta";
                    DGCSeleccionar.ReadOnly = false;
                    DGCNuevaCantidad.ReadOnly = false;
                    break;
                default:
                    lblEstado.Text = "No se puede Realizar Operaciones";
                    this.btnConfirmarEntrega.Visible = false;
                    this.btnConfirmarParcial.Visible = false;
                    this.btnConfirmarTodo.Visible = false;
                    this.btnForzarConfirmacion.Visible = false;
                    DGCSeleccionar.ReadOnly = true;
                    DGCNuevaCantidad.ReadOnly = true;
                    break;
            }

            if (CodigoEstadoVenta == "T" || CodigoEstadoVenta == "P")
            {

                this.btnConfirmarEntrega.Visible = true;
                this.btnConfirmarParcial.Visible = false;
                this.btnConfirmarTodo.Visible = false;
                this.btnForzarConfirmacion.Visible = false;
                this.DGCSeleccionar.Visible = false;
                this.DGCNuevaCantidad.ReadOnly = true;
                //this.DGCCantidadEntregada.HeaderText = "Cant Comprometida a Entregar";
            }
            else
            {
                this.btnConfirmarEntrega.Visible = false;
                this.btnConfirmarParcial.Visible = true;
                this.btnConfirmarTodo.Visible = true;
                this.btnForzarConfirmacion.Visible = true;
                this.DGCSeleccionar.Visible = true;
                //dtGVProductos.Columns["DGCCantidadEntregada"].HeaderText = "Entregados";
            }
            //if (esNecesarioLlenarPE)
            //{
            //    //checkEdición.Enabled = false;
            //    int cantidadVendida = int.Parse(DTVentasProductosDetalle.Compute("sum(CantidadVenta)", "").ToString());
            //    int cantidadEntregada = int.Parse(DTVentasProductosDetalle.Compute("sum(CantidadEntregada)", "").ToString());
            //    if (cantidadVendida == cantidadEntregada)
            //        btnConfirmarEntregaTotal.Enabled = true;
            //    else
            //        btnConfirmarEntregaTotal.Enabled = false;
            //}

            lblNumeroVenta.Text = NumeroVentaProducto.ToString();
            DateTime HoraServidor = _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor();
            lblFechaVenta.Text = HoraServidor.ToShortTimeString() + " " + HoraServidor.ToShortDateString();

            
            //_DTProductosEspecificosTemporal = VentaProductosEspecificosCLN.ListarVentasProductosEspecificosParaVenta(NumeroAgencia, NumeroVentaProducto);
            

            //if (permitirDeshabilitar)
            //    DeshabilitarBotones();
        }

        public void cargarDatosTemporalesAGrilla()
        {
            foreach (CLCAD.DSDoblones20GestionComercial.ListarVentaProductosDetalleParaAlmacenesRow DRProductosListado in DTVentasProductosDetalle.Select("Seleccionar = true"))
            {//CantidadNuevaEntrega
                dtGVDetalleProductosEntrega.Rows[DTVentasProductosDetalle.Rows.IndexOf(DRProductosListado)].Selected = true;

                int CantidadNuevaEntrega = int.Parse(DRProductosListado["CantidadNuevaEntrega"].ToString());
                if (_DTProductosDetalleEntrega.Rows.Find(DRProductosListado.CodigoProducto) == null)
                {

                    if (DRProductosListado.EsProductoEspecifico)
                    {
                        //mostrar Ventana que pide los productos Especificos a vender
                        _FTransferenciaProductosRecepcionEnvioPE = new FTransferenciaProductosRecepcionEnvioPE(NumeroAgencia, -1, DRProductosListado.CodigoProducto, "E", DRProductosListado.NombreProducto, CantidadNuevaEntrega);                        
                        _FTransferenciaProductosRecepcionEnvioPE.ShowDialog();
                        if (!_FTransferenciaProductosRecepcionEnvioPE.OperacionConfirmada)
                        {
                            if (MessageBox.Show(this, "No ingreso los Códigos Especificos del producto " + DRProductosListado.NombreProducto
                                + "¿Desea Cancelar completamente la Operación Actual?", "Selección de Codigos Especificos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                _DTProductosEspecificosTemporal.Clear();
                                _DTProductosEspecificosTemporal.AcceptChanges();

                                _DTProductosDetalleEntrega.Clear();
                                _DTProductosDetalleEntrega.AcceptChanges();
                            }
                            return;
                        }

                        else
                        {
                            int i = 0;
                            foreach (DataRow DTProductoEspecifico in _FTransferenciaProductosRecepcionEnvioPE.DTProductosEspecificos.Select("Seleccionar = true"))
                            {
                                _DTProductosEspecificosTemporal.Rows.Add(new object[] { DRProductosListado.CodigoProducto, i == 0 ? DRProductosListado.NombreProducto : String.Empty, DTProductoEspecifico["CodigoProductoEspecifico"], DRProductosListado["TiempoGarantiaVenta"] });
                                i++;
                            }
                        }
                    }

                    try
                    {
                        _DTProductosDetalleEntrega.Rows.Add(new object[] { DRProductosListado.CodigoProducto, DRProductosListado.NombreProducto, CantidadNuevaEntrega });
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(this, "El Codigo Especifico ingresado ya se encuentra dentro de la lista, los mismos no deben repetirse", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                

                

            }
        }

        private void btnConfirmarEntrega_Click(object sender, EventArgs e)
        {
            foreach (CLCAD.DSDoblones20GestionComercial.ListarVentaProductosDetalleParaAlmacenesRow DRProductosListado in DTVentasProductosDetalle.Rows)
            {
                DRProductosListado["CantidadNuevaEntrega"] = DRProductosListado.CantidadEntregada;
                DRProductosListado["Seleccionar"] = true;
            }
            DTVentasProductosDetalle.AcceptChanges();
            cargarDatosTemporalesAGrilla();

            if (DTVentasProductosDetalle.Count != _DTProductosDetalleEntrega.Rows.Count)
            {
                MessageBox.Show(this, "No ha terminado de confirmar todos los productos", "Confirmación incompleta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show(this, "¿Se encuentra seguro de confirmar la entrega de los productos seleccionados?", "Confirmación de entrega de Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                confirmacionTotal = false;
                bool esPosible = _VentasProductosCLN.EsPosibleConcluirEntregaDeProductos(NumeroAgencia, NumeroVentaProducto, "A");
                if (esPosible)
                {



                    //string CodigoEstadoActualVenta = "";
                    //CodigoEstadoActualVenta = _TransaccionesUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(NumeroAgencia, NumeroVentaProducto, "V");
                    foreach (DataRow DRProductoEspecifico in _DTProductosEspecificosTemporal.Rows)
                    {
                        VentaProductosEspecificosCLN.InsertarVentaProductoEspecifico(NumeroAgencia, NumeroVentaProducto, DRProductoEspecifico["CodigoProducto"].ToString(),
                                                                                    DRProductoEspecifico["CodigoProductoEspecifico"].ToString(),
                                                                                    int.Parse(DRProductoEspecifico["TiempoGarantiaPE"].ToString()), false, FechaHoraEntrega);
                    }                    

                    if (DTVentasProductosDetalle.Compute("sum(CantidadVenta)", "").ToString().CompareTo(DTVentasProductosDetalle.Compute("sum(CantidadEntregada)", "").ToString()) == 0)
                    {
                        if (_TransaccionesUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(NumeroAgencia, NumeroVentaProducto, "V").Equals("P"))
                        {
                            _VentasProductosCLN.ActualizarCodigoEstadoVenta(NumeroAgencia, NumeroVentaProducto, "F");
                            confirmacionTotal = true;
                            _TransaccionesUtilidadesCLN.InsertarAsientosTransacciones(CodigoUsuario,
                                    "Asiento Contable Correspondiente a Numero de Venta Producto " + NumeroVentaProducto.ToString(),
                                    "C", NumeroVentaProducto, "V", NumeroAgencia);
                        }
                        else
                        {
                            _VentasProductosCLN.ActualizarCodigoEstadoVenta(NumeroAgencia, NumeroVentaProducto, "C");
                            _TransaccionesUtilidadesCLN.InsertarAsientosTransacciones(CodigoUsuario,
                                    "Asiento Contable Correspondiente a Numero de Venta Producto " + NumeroVentaProducto.ToString(),
                                    "C", NumeroVentaProducto, "V", NumeroAgencia);
                        }
                    }
                    else
                    {
                        if (_TransaccionesUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(NumeroAgencia, NumeroVentaProducto, "V").Equals("P"))
                            _VentasProductosCLN.ActualizarCodigoEstadoVenta(NumeroAgencia, NumeroVentaProducto, "E");
                        else
                            _VentasProductosCLN.ActualizarCodigoEstadoVenta(NumeroAgencia, NumeroVentaProducto, "D");
                    }
                   

                    _TransaccionesUtilidadesCLN.ActualizarInventarioProductosVentas(NumeroAgencia, NumeroVentaProducto);
                    OperacionConfirmada = true;
                    conProductosEspecificos = true;
                    mostrarReporte();
                    btnConfirmarEntrega.Enabled = false;

                }
                else
                {
                    MessageBox.Show(this, "No puede realizar ninguna operación sobre esta venta, debido a que la cantidad de entrega de productos sobrepasa a la cantidad de Existencia en Inventarios"
                        + Environment.NewLine + "Probablemente se realizó la entrega de los correspondientes Productos a esta venta en otra venta"
                        + Environment.NewLine + "Puede proceder a modificar la venta actual o esperar al reabastecimiento de Almacenes para la entrega actual", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    btnConfirmarTodo.Enabled = false;                    
                    btnConfirmarParcial.Enabled = false;
                    OperacionConfirmada = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se Pudo actualizar correctamente la entrega de Productos al cargar la misma, debido a que ocurrió la siguiente Excepción "
                    + ex.Message);
            }
        }

        public void mostrarReporte()
        {
            DataTable DTProductosEntregados;
            if (confirmacionTotal && conProductosEspecificos)
            {
                DTProductosEntregados = _VentasProductosCLN.ListarVentaProductosDetalleConEspecificosCompletaParaAlmacenes(NumeroAgencia, NumeroVentaProducto);
                ReporteProductosEntregados = new FReporteVentaProductosReciboEntregados(DTProductosEntregados, "CCPE");
                if (EstadoVentaActual_deEntrega == "T")
                {
                    string CodigoEstadoVentaActual = _TransaccionesUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(NumeroAgencia, NumeroVentaProducto, "V").ToString();
                    if (CodigoEstadoVentaActual.CompareTo("F") != 0)
                    {
                        if (_TransaccionesUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(NumeroAgencia, NumeroVentaProducto, "V").Equals("P"))
                            _VentasProductosCLN.ActualizarCodigoEstadoVenta(NumeroAgencia, NumeroVentaProducto, "F");
                        else// if (_VentasProductosCLN.ObtenerVentaProducto(NumeroAgencia, NumeroVentaProducto).Rows[0]["CodigoTipoVenta"].Equals("T"))
                            _VentasProductosCLN.ActualizarCodigoEstadoVenta(NumeroAgencia, NumeroVentaProducto, "C");
                    }
                }
                _VentasProductosCLN.ActualizarProductoEspecificoEntregadoEnVentas(NumeroAgencia, NumeroVentaProducto);
            }
            else if (confirmacionTotal && !conProductosEspecificos)
            {
                DTProductosEntregados = _VentasProductosCLN.ListarVentaProductosDetalleParaAlmacenes(NumeroAgencia, NumeroVentaProducto);
                ReporteProductosEntregados = new FReporteVentaProductosReciboEntregados(DTProductosEntregados, "CSPE");
                if (EstadoVentaActual_deEntrega == "T")
                {
                    string CodigoEstadoVentaActual = _TransaccionesUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(NumeroAgencia, NumeroVentaProducto, "V").ToString();
                    if (CodigoEstadoVentaActual.CompareTo("F") != 0)
                    {
                        if (_TransaccionesUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(NumeroAgencia, NumeroVentaProducto, "V").Equals("P"))
                            _VentasProductosCLN.ActualizarCodigoEstadoVenta(NumeroAgencia, NumeroVentaProducto, "F");
                        else //if (_VentasProductosCLN.ObtenerVentaProducto(NumeroAgencia, NumeroVentaProducto).Rows[0]["CodigoTipoVenta"].Equals("T"))
                        {
                            _VentasProductosCLN.ActualizarCodigoEstadoVenta(NumeroAgencia, NumeroVentaProducto, "C");
                            //_TransaccionesUtilidadesCLN.ActualizarInventarioProductosVentas(NumeroAgencia, NumeroVentaProducto);
                        }
                    }
                }
            }
            else if (!confirmacionTotal && conProductosEspecificos)
            {
                DTProductosEntregados = _VentasProductosCLN.ListarVentaProductosDetalleConEspecificosPorPartesParaAlmacenes(NumeroAgencia, NumeroVentaProducto);
                int CantidadAnterior = 0;
                int CantidadActual = 0;
                int indice = 0;
                string CodigoProducto = "";
                int indiceEncontrado = -1;
                DTProductosEntregados.Columns["CantidadEntregadaAnterior"].ReadOnly = false;
                DTProductosEntregados.Columns["CantidadEntregada"].ReadOnly = false;
                foreach (DataRow Filaproducto in DTVentasProductosDetalle.Rows)
                {
                    if (!Filaproducto["EsProductoEspecifico"].Equals(true))
                    {
                        CantidadAnterior = int.Parse(DTVentasProductosDetalleCopy.Rows[indice]["CantidadEntregada"].ToString());
                        CodigoProducto = DTVentasProductosDetalleCopy.Rows[indice]["CodigoProducto"].ToString();
                        CantidadActual = int.Parse(DTVentasProductosDetalle.Rows[indice]["CantidadEntregada"].ToString());
                        for (int i = 0; i < DTProductosEntregados.Rows.Count; i++)
                        {
                            if (DTProductosEntregados.Rows[i]["CodigoProducto"].ToString().CompareTo(CodigoProducto) == 0)
                            {
                                indiceEncontrado = i;
                                break;
                            }
                        }

                        DTProductosEntregados.Rows[indiceEncontrado]["CantidadEntregadaAnterior"] = CantidadAnterior;
                        DTProductosEntregados.Rows[indiceEncontrado]["CantidadEntregada"] = CantidadActual - CantidadAnterior;
                    }

                    if (Filaproducto["EsProductoEspecifico"].Equals(true) && Filaproducto.RowState == DataRowState.Unchanged)
                    {
                        CantidadAnterior = int.Parse(DTVentasProductosDetalleCopy.Rows[indice]["CantidadEntregada"].ToString());
                        CodigoProducto = DTVentasProductosDetalleCopy.Rows[indice]["CodigoProducto"].ToString();
                        CantidadActual = int.Parse(DTVentasProductosDetalle.Rows[indice]["CantidadEntregada"].ToString());
                        for (int i = 0; i < DTProductosEntregados.Rows.Count; i++)
                        {
                            if (DTProductosEntregados.Rows[i]["CodigoProducto"].ToString().CompareTo(CodigoProducto) == 0)
                            {
                                indiceEncontrado = i;
                                break;
                            }
                        }

                        DTProductosEntregados.Rows[indiceEncontrado]["CantidadEntregadaAnterior"] = CantidadAnterior;
                        DTProductosEntregados.Rows[indiceEncontrado]["CantidadEntregada"] = CantidadActual - CantidadAnterior;
                    }
                    indice++;
                }
                ReporteProductosEntregados = new FReporteVentaProductosReciboEntregados(DTProductosEntregados, "ICPE");
                _VentasProductosCLN.ActualizarProductoEspecificoEntregadoEnVentas(NumeroAgencia, NumeroVentaProducto);
            }
            else if (!confirmacionTotal && !conProductosEspecificos)
            {
                DTVentasProductosDetalleCopy.Columns.Add("CantidadEntregadaAnterior", Type.GetType("System.Int32"));
                DTVentasProductosDetalleCopy.Columns["CantidadFaltante"].ReadOnly = false;
                foreach (DataRow FilaEntrega in DTVentasProductosDetalle.Rows)
                {
                    DTVentasProductosDetalleCopy.Rows[DTVentasProductosDetalle.Rows.IndexOf(FilaEntrega)]["CantidadEntregadaAnterior"] = DTVentasProductosDetalleCopy.Rows[DTVentasProductosDetalle.Rows.IndexOf(FilaEntrega)]["CantidadEntregada"];
                    DTVentasProductosDetalleCopy.Rows[DTVentasProductosDetalle.Rows.IndexOf(FilaEntrega)]["CantidadEntregada"] = int.Parse(FilaEntrega["CantidadEntregada"].ToString()) - int.Parse(DTVentasProductosDetalleCopy.Rows[DTVentasProductosDetalle.Rows.IndexOf(FilaEntrega)]["CantidadEntregada"].ToString());
                    DTVentasProductosDetalleCopy.Rows[DTVentasProductosDetalle.Rows.IndexOf(FilaEntrega)]["CantidadFaltante"] = int.Parse(FilaEntrega["CantidadVenta"].ToString()) - int.Parse(FilaEntrega["CantidadEntregada"].ToString());
                }//CantidadVendida
                DTVentasProductosDetalleCopy.Columns["CantidadFaltante"].ReadOnly = true;
                DTVentasProductosDetalleCopy.AcceptChanges();
                ReporteProductosEntregados = new FReporteVentaProductosReciboEntregados(DTVentasProductosDetalleCopy, "ISPE");
            }


            ReporteProductosEntregados.ShowDialog(this);            
            btnConfirmarTodo.Enabled = false;
            btnConfirmarParcial.Enabled = false;            
        }

        private void btnConfirmarParcial_Click(object sender, EventArgs e)
        {
            if (_DTProductosDetalleEntrega.Rows.Count == 0)
            {
                MessageBox.Show(this, "Aún no ha seleccionado los productos que desea entregar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show(this, "¿Se encuentra seguro de confirmar la entrega de los productos seleccionados?", "Confirmación de entrega de Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            
            bool esPosible = _VentasProductosCLN.EsPosibleConcluirEntregaDeProductos(NumeroAgencia, NumeroVentaProducto, "D");
            bool confirmacionUsuario = true;
            confirmacionTotal = false;
            if (!esPosible)
            {
                if (MessageBox.Show(this, "Es posible que no pueda entregar completamente todos los productos debido a la inexistencia Total de lo requerido.." + Environment.NewLine + "Solo se actualizará los productos cuya existencia en inventario abastesca a lo requerido, ¿Desea Continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    confirmacionUsuario = true;
                }
                else
                    return;
            }
            if (confirmacionUsuario)
            {
                DTVentasProductosDetalle.AcceptChanges();
                DateTime FechaHoraEntrega = _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor();               
                foreach (DataRow DRProductoEspecifico in _DTProductosEspecificosTemporal.Rows)
                {
                    VentaProductosEspecificosCLN.InsertarVentaProductoEspecifico(NumeroAgencia, NumeroVentaProducto, DRProductoEspecifico["CodigoProducto"].ToString(),
                                                                                DRProductoEspecifico["CodigoProductoEspecifico"].ToString(),
                                                                                int.Parse(DRProductoEspecifico["TiempoGarantiaPE"].ToString()), false, FechaHoraEntrega);
                }                

                foreach (DataRow DRProductoEntrega in _DTProductosDetalleEntrega.Rows)
                {
                    try
                    {
                        int CantidadNuevaRegistro = int.Parse(DRProductoEntrega["CantidadNuevaEntrega"].ToString()) + DTVentasProductosDetalle.FindByCodigoProducto(DRProductoEntrega["CodigoProducto"].ToString()).CantidadEntregada;

                        _VentasProductosCLN.ActualizarVentaProductosDetalleCantidadRequerida(NumeroAgencia, NumeroVentaProducto, DRProductoEntrega["CodigoProducto"].ToString(), CantidadNuevaRegistro, FechaHoraEntrega);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se puedo Actualizar Satisfactoriamente, Ocurrio el Siguiente Error " + ex.Message);
                    }
                }
                mostrarReporte();

                if (DTVentasProductosDetalle.Compute("sum(CantidadVenta)", "").ToString().CompareTo(DTVentasProductosDetalle.Compute("sum(CantidadEntregada)", "").ToString()) == 0)
                {
                    if (_TransaccionesUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(NumeroAgencia, NumeroVentaProducto, "V").Equals("P"))
                    {
                        _VentasProductosCLN.ActualizarCodigoEstadoVenta(NumeroAgencia, NumeroVentaProducto, "F");
                        _TransaccionesUtilidadesCLN.InsertarAsientosTransacciones(CodigoUsuario,
                                    "Asiento Contable Correspondiente a Numero de Venta Producto " + NumeroVentaProducto.ToString(),
                                    "C", NumeroVentaProducto, "V", NumeroAgencia);
                    }
                    else
                    {
                        _VentasProductosCLN.ActualizarCodigoEstadoVenta(NumeroAgencia, NumeroVentaProducto, "C");
                        _TransaccionesUtilidadesCLN.InsertarAsientosTransacciones(CodigoUsuario,
                                    "Asiento Contable Correspondiente a Numero de Venta Producto " + NumeroVentaProducto.ToString(),
                                    "C", NumeroVentaProducto, "V", NumeroAgencia);
                    }
                }
                OperacionConfirmada = true;
            }
        }

        private void dtGVDetalleProductosEntrega_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dtGVDetalleProductosEntrega.RowCount > 0 && dtGVDetalleProductosEntrega.CurrentCell != null)
            {
                if (e.ColumnIndex == DGCSeleccionar.Index)
                {
                    string CodigoProducto = "", NombreProducto = "";
                    int CantidadEnvio = 0, CantidadMaximaEnvio = 0;

                    CodigoProducto = DTVentasProductosDetalle[e.RowIndex].CodigoProducto;
                    NombreProducto = DTVentasProductosDetalle[e.RowIndex].NombreProducto;                    
                    CantidadMaximaEnvio = DTVentasProductosDetalle[e.RowIndex].CantidadVenta - int.Parse(DTVentasProductosDetalle[e.RowIndex]["CantidadRealEntregada"].ToString());

                    //Agrega el producto a la Lista de Productos de Entrega
                    if (dtGVDetalleProductosEntrega[e.ColumnIndex, e.RowIndex].Value.Equals(true))
                    {
                        formIngresarCantidad.Cantidad = CantidadMaximaEnvio;
                        formIngresarCantidad.ShowDialog();
                        if (formIngresarCantidad.OperacionConfirmada)
                        {
                            CantidadEnvio = formIngresarCantidad.Cantidad;
                            if (CantidadEnvio > CantidadMaximaEnvio)
                            {
                                MessageBox.Show(this, "La cantidad ingresada supera a la cantidad maxima posible de entrega para esta venta", "Cantidad no Valida", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                DTVentasProductosDetalle[e.RowIndex].RejectChanges();
                                return;
                            }
                            
                            if (_DTProductosDetalleEntrega.Rows.Find(CodigoProducto) == null)
                            {
                                if (DTVentasProductosDetalle[e.RowIndex].EsProductoEspecifico)
                                {
                                    _FTransferenciaProductosRecepcionEnvioPE = new FTransferenciaProductosRecepcionEnvioPE(NumeroAgencia, -1, CodigoProducto, "E", NombreProducto, CantidadEnvio);
                                    _FTransferenciaProductosRecepcionEnvioPE.ShowDialog();
                                    if (!_FTransferenciaProductosRecepcionEnvioPE.OperacionConfirmada)
                                    {
                                        DTVentasProductosDetalle[e.RowIndex].RejectChanges();
                                        return;

                                    }
                                    else
                                    {
                                        int i = 0;
                                        foreach (DSDoblones20GestionComercial2.ListarCodigosProductosEspecificosTransferenciasRow FilaEspecifico
                                            in (DSDoblones20GestionComercial2.ListarCodigosProductosEspecificosTransferenciasRow[])
                                            _FTransferenciaProductosRecepcionEnvioPE.DTProductosEspecificos.Select("Seleccionar = true"))
                                        {
                                            _DTProductosEspecificosTemporal.Rows.Add(new object[] { CodigoProducto, ((i == 0) ? NombreProducto : String.Empty), FilaEspecifico.CodigoProductoEspecifico, DTVentasProductosDetalle[e.RowIndex]["TiempoGarantiaVenta"] });
                                            i++;
                                        }
                                        _DTProductosEspecificosTemporal.AcceptChanges();
                                    }

                                }

                                _DTProductosDetalleEntrega.Rows.Add(new object[] { CodigoProducto, NombreProducto, CantidadEnvio });
                                _DTProductosDetalleEntrega.AcceptChanges();


                                DTVentasProductosDetalle[e.RowIndex]["CantidadNuevaEntrega"] = CantidadEnvio;                                
                            }
                        }
                        else
                        {
                            DTVentasProductosDetalle[e.RowIndex].RejectChanges();
                        }

                    }
                    else//quitar de la lista
                    {
                        DataRow DRProductosEliminar = _DTProductosDetalleEntrega.Rows.Find(CodigoProducto);
                        if (DRProductosEliminar != null)
                        {
                            //if (MessageBox.Show(this, "¿Esta seguro de Cancelar el Envio del Producto " + NombreProducto + "?", "Elimiar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            //{
                            //    //DTTransferenciaProductosDetalle[e.RowIndex].RejectChanges();
                            //    dtGVDetalleProductosEntrega[e.ColumnIndex, e.RowIndex].Value = true;
                            //    return;
                            //}

                            DataRow[] DRProductosEspecificosEliminar = _DTProductosEspecificosTemporal.Select("CodigoProducto = '" + CodigoProducto + "'");
                            if (DRProductosEspecificosEliminar != null)
                                foreach (DataRow DRProductoEspecifico in DRProductosEspecificosEliminar)
                                    DRProductoEspecifico.Delete();
                            DRProductosEliminar.Delete();

                            _DTProductosEspecificosTemporal.AcceptChanges();
                            _DTProductosDetalleEntrega.AcceptChanges();
                        }                        
                    }
                }


            }
        }

        private void dtGVDetalleProductosEntrega_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtGVDetalleProductosEntrega.IsCurrentCellDirty && dtGVDetalleProductosEntrega.CurrentCell.ColumnIndex == DGCSeleccionar.Index)
            {
                dtGVDetalleProductosEntrega.CommitEdit(DataGridViewDataErrorContexts.Commit);
            } 
        }

        private void dtGVProductosEntregaEspecificos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (_DTProductosEspecificosTemporal.Rows.Count > 0)
            {

                if (dtGVProductosEntregaEspecificos.Rows[e.RowIndex].Cells[DGCNombreProductoPE.Index].Value != null && !dtGVProductosEntregaEspecificos.Rows[e.RowIndex].Cells[DGCNombreProductoPE.Index].Value.Equals(""))
                {
                    dtGVProductosEntregaEspecificos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Bisque;
                    dtGVProductosEntregaEspecificos.Rows[e.RowIndex].Cells["DGCNombreProductoPE"].Style.Font = new Font(fuenteDefecto.Name, fuenteDefecto.Size, FontStyle.Bold);
                }
            }
        }

        private void dtGVProductosEntregar_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dtGVProductosEntregar.RowCount > 0 && dtGVProductosEntregar.CurrentCell != null)
            {
                if (e.ColumnIndex == DGCNuevaCantidad.Index)
                {
                    int NuevaCantidadEnvio = (int)dtGVProductosEntregar[e.ColumnIndex, e.RowIndex].Value;
                    string CodigoProducto = _DTProductosDetalleEntrega.Rows[e.RowIndex]["CodigoProducto"].ToString();
                    CLCAD.DSDoblones20GestionComercial.ListarVentaProductosDetalleParaAlmacenesRow DRProductoSeleccionado
                        = DTVentasProductosDetalle.FindByCodigoProducto(CodigoProducto);

                    int CantidadAnterior = int.Parse(_DTProductosEspecificosTemporal.Compute("count(CodigoProducto)", "CodigoProducto = '" + CodigoProducto + "'").ToString());
                    if (DRProductoSeleccionado.EsProductoEspecifico)
                    {
                        _FTransferenciaProductosRecepcionEnvioPE = new FTransferenciaProductosRecepcionEnvioPE(NumeroAgencia, -1, CodigoProducto, "E", DRProductoSeleccionado.NombreProducto, NuevaCantidadEnvio);
                        _FTransferenciaProductosRecepcionEnvioPE.DTProductosEspecificosSeleccionados = _DTProductosEspecificosTemporal;
                        _FTransferenciaProductosRecepcionEnvioPE.ShowDialog(this);
                        if (_FTransferenciaProductosRecepcionEnvioPE.OperacionConfirmada)
                        {
                            foreach (DataRow DRCodigoEspecificoAntiguo in _DTProductosEspecificosTemporal.Select("CodigoProducto ='" + CodigoProducto + "'"))
                            {
                                DRCodigoEspecificoAntiguo.Delete();
                            }
                            _DTProductosEspecificosTemporal.AcceptChanges();

                            int indice = 0;
                            foreach (DataRow DRCodigoEspecificoNuevo in _FTransferenciaProductosRecepcionEnvioPE.DTProductosEspecificos.Select("Seleccionar = true"))
                            {
                                _DTProductosEspecificosTemporal.Rows.Add(new object[] { CodigoProducto, (indice == 0 ? DRProductoSeleccionado.NombreProducto : String.Empty), DRCodigoEspecificoNuevo["CodigoProductoEspecifico"], DRProductoSeleccionado["TiempoGarantiaVenta"] });
                                indice++;
                            }

                            _DTProductosEspecificosTemporal.AcceptChanges();

                            DRProductoSeleccionado["CantidadNuevaEntrega"] = NuevaCantidadEnvio;
                            DRProductoSeleccionado.AcceptChanges();
                        }
                        else
                        {
                            _DTProductosDetalleEntrega.Rows[e.RowIndex].RejectChanges();
                        }
                    }                    
                }
                
            }
        }

        private void dtGVProductosEntregar_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int CantidadNuevaDeEntrega;            
            this.dtGVProductosEntregar.Rows[e.RowIndex].ErrorText = "";            
            if (this.dtGVProductosEntregar.Rows[e.RowIndex].IsNewRow) { return; }

            if (this.dtGVProductosEntregar.IsCurrentCellDirty)
            {
                switch (this.dtGVProductosEntregar.Columns[e.ColumnIndex].Name) 
                {

                    case "DGCNuevaCantidad":
                        if (e.FormattedValue.ToString().Trim().Length < 1)
                        {
                            this.dtGVProductosEntregar.Rows[e.RowIndex].ErrorText = "   La Cantidad a entregar es necesaria y no puede estar vacia.";
                            e.Cancel = true;
                        }
                        else if (!int.TryParse(e.FormattedValue.ToString(), out CantidadNuevaDeEntrega) || CantidadNuevaDeEntrega <= 0)
                        {
                            this.dtGVProductosEntregar.Rows[e.RowIndex].ErrorText = "   La Cantidad a entregar debe ser un entero positivo.";
                            e.Cancel = true;
                            return;
                        }

                        if (int.TryParse(e.FormattedValue.ToString(), out CantidadNuevaDeEntrega))
                        {
                            string CodigoProducto = _DTProductosDetalleEntrega.Rows[e.RowIndex]["CodigoProducto"].ToString();
                            CLCAD.DSDoblones20GestionComercial.ListarVentaProductosDetalleParaAlmacenesRow DRProductovalidar =
                                DTVentasProductosDetalle.FindByCodigoProducto(CodigoProducto);

                            if (CantidadNuevaDeEntrega > (DRProductovalidar.CantidadVenta - int.Parse(DRProductovalidar["CantidadRealEntregada"].ToString())))
                            {
                                this.dtGVProductosEntregar.Rows[e.RowIndex].ErrorText = "   No puede entregar una cantidad superior a la Cantidad Maxima Posible de Entrega (" + 
                                    (DRProductovalidar.CantidadVenta - int.Parse(DRProductovalidar["CantidadRealEntregada"].ToString())).ToString()+")";
                                e.Cancel = true;
                            }
                        }
                        break;                    

                }

            }
        }

        private void btnConfirmarTodo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Se encuentra seguro de confirmar la entrega de los productos seleccionados?", "Confirmación de entrega de Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            bool esPosible = _VentasProductosCLN.EsPosibleConcluirEntregaDeProductos(NumeroAgencia, NumeroVentaProducto, "D");
            if ((!esPosible && EstadoVentaActual_deEntrega != "P") || !esPosible)
            {
                MessageBox.Show(this, "No puede realizar la entrega Total de Productos de esta Venta." + Environment.NewLine + "No existe la cantidad suficiente en Inventarios para realizar su Entrega completa", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            confirmacionTotal = true;
            DateTime FechaHoraEntrega = _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor();
            switch (EstadoVentaActual_deEntrega)
            {
                case "P": //Pendiente
                    if (MessageBox.Show(this, "Se Procedera a la Entrega del Recibo de conformidad al Cliente e igualar las Cantidad de Entrega Faltante." + Environment.NewLine + "¿Desea Continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string CodigoProducto = "";
                        int CantidadEntrega = 0;
                        foreach (DataRow filaProducto in DTVentasProductosDetalle.Rows)
                        {
                            CodigoProducto = filaProducto["CodigoProducto"].ToString();
                            CantidadEntrega = int.Parse(filaProducto["CantidadVenta"].ToString());
                            try
                            {
                                _VentasProductosCLN.ActualizarVentaProductosDetalleCantidadRequerida(NumeroAgencia, NumeroVentaProducto, CodigoProducto, CantidadEntrega, FechaHoraEntrega);
                                filaProducto["CantidadEntregada"] = filaProducto["CantidadVenta"];
                                filaProducto.AcceptChanges();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("No se puedo Actualizar Satisfactoriamente, Ocurrio el Siguiente Error " + ex.Message);
                                filaProducto.RejectChanges();
                            }
                        }
                        mostrarReporte();
                    }
                    break;
                case "E":
                    if (esNecesarioLlenarPE)
                        MessageBox.Show("Debe seleccionar los Productos Especificos que va a entregar para esta Venta");
                    cargarDatosTemporalesAGrilla();
                    if (_DTProductosDetalleEntrega.Rows.Count != DTVentasProductosDetalle.Count)
                    {
                        MessageBox.Show(this, "No ha confirmado en su Totalidad la selección de Codigos especificos para su Entrega", "Selección incompleta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    foreach (DataRow DRProductoEspecifico in _DTProductosEspecificosTemporal.Rows)
                    {
                        VentaProductosEspecificosCLN.InsertarVentaProductoEspecifico(NumeroAgencia, NumeroVentaProducto, DRProductoEspecifico["CodigoProducto"].ToString(),
                                                                                    DRProductoEspecifico["CodigoProductoEspecifico"].ToString(),
                                                                                    int.Parse(DRProductoEspecifico["TiempoGarantiaPE"].ToString()), false, FechaHoraEntrega);
                    } 
                    CodigoEstadoVenta = _TransaccionesUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(NumeroAgencia, NumeroVentaProducto, "V");                    
                    _TransaccionesUtilidadesCLN.ActualizarInventarioProductosEspecficosVendidos(NumeroAgencia, NumeroVentaProducto);
                    mostrarReporte();
                    break;
                case "T":
                    mostrarReporte();
                    break;
                case "C":
                    if (MessageBox.Show(this, "El sistema se encargará de Completar e igualar las cantidades de entrega. " + Environment.NewLine + "¿Está seguro de Continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (CLCAD.DSDoblones20GestionComercial.ListarVentaProductosDetalleParaAlmacenesRow DRProductosListado in DTVentasProductosDetalle.Rows)
                        {
                            DRProductosListado["CantidadNuevaEntrega"] = DRProductosListado.CantidadVenta - int.Parse(DRProductosListado["CantidadRealEntregada"].ToString());
                            DRProductosListado["Seleccionar"] = true;
                        }
                        DTVentasProductosDetalle.AcceptChanges();
                        cargarDatosTemporalesAGrilla();
                        if (_DTProductosDetalleEntrega.Rows.Count != DTVentasProductosDetalle.Count)
                        {
                            MessageBox.Show(this, "No ha confirmado en su Totalidad la selección de Codigos especificos para su Entrega", "Selección incompleta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        foreach (DataRow DRProductoEspecifico in _DTProductosEspecificosTemporal.Rows)
                        {
                            VentaProductosEspecificosCLN.InsertarVentaProductoEspecifico(NumeroAgencia, NumeroVentaProducto, DRProductoEspecifico["CodigoProducto"].ToString(),
                                                                                        DRProductoEspecifico["CodigoProductoEspecifico"].ToString(),
                                                                                        int.Parse(DRProductoEspecifico["TiempoGarantiaPE"].ToString()), false, FechaHoraEntrega);
                        } 
                        foreach (CLCAD.DSDoblones20GestionComercial.ListarVentaProductosDetalleParaAlmacenesRow DRProductosListado in DTVentasProductosDetalle.Rows)
                        {
                            DRProductosListado["CantidadNuevaEntrega"] = DRProductosListado.CantidadVenta;
                            DRProductosListado["Seleccionar"] = true;
                            try
                            {
                                _VentasProductosCLN.ActualizarVentaProductosDetalleCantidadRequerida(NumeroAgencia, NumeroVentaProducto, DRProductosListado.CodigoProducto, DRProductosListado.CantidadVenta, FechaHoraEntrega);
                                
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("No se puedo Actualizar Satisfactoriamente, Ocurrio el Siguiente Error " + ex.Message);                                
                            }
                        }
                        mostrarReporte();                        
                    }
                    break;
                default:
                    MessageBox.Show("No puede Confirmar esta Venta, Consulte con su Administrador");
                    break;
            }
            OperacionConfirmada = true;
            if (_TransaccionesUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(NumeroAgencia, NumeroVentaProducto, "V").Equals("P"))
            {
                _VentasProductosCLN.ActualizarCodigoEstadoVenta(NumeroAgencia, NumeroVentaProducto, "F");
                _TransaccionesUtilidadesCLN.InsertarAsientosTransacciones(CodigoUsuario,
                                    "Asiento Contable Correspondiente a Numero de Venta Producto " + NumeroVentaProducto.ToString(),
                                    "C", NumeroVentaProducto, "V", NumeroAgencia);
            }
            else
            {
                _VentasProductosCLN.ActualizarCodigoEstadoVenta(NumeroAgencia, NumeroVentaProducto, "C");
                _TransaccionesUtilidadesCLN.InsertarAsientosTransacciones(CodigoUsuario,
                                    "Asiento Contable Correspondiente a Numero de Venta Producto " + NumeroVentaProducto.ToString(),
                                    "C", NumeroVentaProducto, "V", NumeroAgencia);
            }
        }

        private void dtGVDetalleProductosEntrega_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.Value != null) && (e.ColumnIndex == DGCCantidadEntregada.Index || e.ColumnIndex == DGCCantidadExistencia.Index) && (int.Parse(dtGVDetalleProductosEntrega["DGCCantidadEntregada", e.RowIndex].Value.ToString()) > int.Parse(dtGVDetalleProductosEntrega["DGCCantidadExistencia", e.RowIndex].Value.ToString())))
            {
                e.CellStyle.BackColor = Color.LightCoral;
            }
        }

        
    }
}
