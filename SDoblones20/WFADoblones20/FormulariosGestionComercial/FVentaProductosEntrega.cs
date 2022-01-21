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

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FVentaProductosEntrega : Form
    {
        DataTable DTVentasProductosDetalle;
        DataTable DTVentasProductosDetalleCopy;
        DataTable DTVentasProductosDetalleActual;
        DataTable _DTProductosEspecificosSeleccionadosPorUsuarioTemporal;
        DataTable _DTProductosEspecificosTemporal;
        VentasProductosCLN _VentasProductosCLN;
        int NumeroAgencia;
        int NumeroVentaProducto;
        bool usuarioSeleccionaEspecifico = false;        
        InventariosProductosEspecificosCLN InventarioProductoEspecificoCLN;
        DataSet DSProductosEspecificos;
        VentasProductosEspecificosCLN VentaProductosEspecificosCLN;
        string EstadoVentaActual_deEntrega;
        FReporteVentaProductosReciboEntregados ReporteProductosEntregados;
        TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;
        bool esNecesarioLlenarPE = false;
        bool conProductosEspecificos = false;
        bool confirmacionTotal = true;
        public bool OperacionConfirmada = false;
        public bool permitirDeshabilitar = false;
        string TipoOperacion = "C"; //'C'->Confirmación de Entrega de Productos,  'M'->Mostrar solo Productos
        DateTime FechaHoraEntrega;

        public string CodigoEstadoVenta { get; set; }

        public FVentaProductosEntrega(int NumeroAgencia, int NumeroVentaProducto)
        {
            InitializeComponent();
            this.NumeroAgencia = NumeroAgencia;
            this.NumeroVentaProducto = NumeroVentaProducto;

            _VentasProductosCLN = new VentasProductosCLN();
            InventarioProductoEspecificoCLN = new InventariosProductosEspecificosCLN();
            VentaProductosEspecificosCLN = new VentasProductosEspecificosCLN();
            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();
            dtGVProductos.AutoGenerateColumns = false;
            DSProductosEspecificos = new DataSet();
            dtGVProductos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            FechaHoraEntrega = _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor();
        }
        public void confirmarEntregaInstitucional()
        {
            try
            {
                bool esPosible = _VentasProductosCLN.EsPosibleConcluirEntregaDeProductos(NumeroAgencia, NumeroVentaProducto, "A");
                if (esPosible)
                {
                    _TransaccionesUtilidadesCLN.ActualizarInventarioProductosVentas(NumeroAgencia, NumeroVentaProducto);
                    _VentasProductosCLN.ActualizarCodigoEstadoVenta(NumeroAgencia, NumeroVentaProducto, "D");//la mandamos como YA ENTREGADA Y se encuentra en confianza
                }
                else
                {
                    MessageBox.Show(this, "No puede realizar ninguna operación sobre esta venta, debido a que la cantidad de entrega de productos sobrepasa a la cantidad de Existencia en Inventarios"
                        + Environment.NewLine + "Probablemente se realizó la entrega de los correspondientes Productos a esta venta en otra venta"
                        + Environment.NewLine + "Puede proceder a modificar la venta actual o esperar al reabastecimiento de Almacenes para la entrega actual", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    btnConfirmarEntregaTotal.Enabled = false;
                    btnReporte.Enabled = false;
                    btnEntregaParcial.Enabled = false;
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se Pudo actualizar correctamente la entrega de Productos al cargar la misma");
            }
        }

        private void FVentaProductosEntrega_Load(object sender, EventArgs e)
        {
            lblEstado.Text = "_____";
            lblFechaVenta.Text = "_____";
            lblNumeroVenta.Text = "_____";

            DTVentasProductosDetalle = _VentasProductosCLN.ListarVentaProductosDetalleParaAlmacenes(NumeroAgencia, NumeroVentaProducto);
            DTVentasProductosDetalleCopy = DTVentasProductosDetalle.Copy();
            dtGVProductos.DataSource = DTVentasProductosDetalle;

            
            CodigoEstadoVenta = _TransaccionesUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(NumeroAgencia, NumeroVentaProducto, "V");
            if (CodigoEstadoVenta == "T" || CodigoEstadoVenta == "P")
            {
                btnConfirmar.Visible = true;
                btnEntregaParcial.Visible = false;
                btnConfirmarEntregaTotal.Visible = false;
                btnReporte.Visible = false;
                checkEdición.Visible = false;

                dtGVProductos.Columns["DGCCantidadEntregada"].HeaderText = "A Entregar";
            }
            else
            {
                btnConfirmar.Visible = false;
                btnEntregaParcial.Visible = true;
                btnConfirmarEntregaTotal.Visible = true;
                btnReporte.Visible = true;
                checkEdición.Visible = true;
                dtGVProductos.Columns["DGCCantidadEntregada"].HeaderText = "Entregados";
            }

            conProductosEspecificos = DTVentasProductosDetalle.Compute("count(EsProductoEspecifico)", "EsProductoEspecifico = true").ToString().CompareTo("0") == 0 ? false : true;

            DGCCodigoProducto.Width = 75;
            DGCNombreProducto.Width = 300;            
            EstadoVentaActual_deEntrega = _VentasProductosCLN.obtenerEstadoVentaFinalizadaParaAlmacenes(NumeroAgencia, NumeroVentaProducto);
            esNecesarioLlenarPE = this._TransaccionesUtilidadesCLN.esNecesarioLlenarProductosEspecificos(NumeroAgencia, NumeroVentaProducto);

           
            switch (EstadoVentaActual_deEntrega)
            {
                case "P"://Se registro completamente los PE pero su entrega y completación está pendiente, ES UNA ENTREGA POR PARTES, en este caso el usuario aunmenta la cantidad que quiere antregar ahora                    
                    btnConfirmarEntregaTotal.Enabled = true;
                    btnEntregaParcial.Enabled = true;
                    lblEstado.Text = "Entrega Parcial (Completar Entrega)";
                    break;
                case "T"://Se Entrego los productos y sus registro de PE esta completo
                    btnConfirmarEntregaTotal.Enabled = false;
                    btnEntregaParcial.Enabled = false;
                    checkEdición.Enabled = false;
                    lblEstado.Text = "Entrega Completa (Imprimir Recibo de Conformidad)";
                    break;
                case "E"://en este caso se debe proceder a llenar los PE para su entrega inmediata e imprimir recibo de conformidad
                    btnConfirmarEntregaTotal.Enabled = true;
                    btnEntregaParcial.Enabled = false;
                    lblEstado.Text = "Registro Códigos Especificos (Seleccionar Productos Específicos)";
                    break;
                case "C"://Combinacion de casos, ni se ha registrado en totalidad sus PE y ni su entrega esta completa, ES UNA ENTREGA POR PARTES, la 2da o nsima parte de entrega
                    btnConfirmarEntregaTotal.Enabled = true;
                    btnEntregaParcial.Enabled = true;
                    lblEstado.Text = "Registro de Códigos Específicos y Entrega Incompleta";
                    break;
                default :
                    lblEstado.Text = "No se puede Realizar Operaciones";
                    break;
            }

            if (esNecesarioLlenarPE)
            {
                //checkEdición.Enabled = false;
                int cantidadVendida = int.Parse(DTVentasProductosDetalle.Compute("sum(CantidadVenta)","").ToString());
                int cantidadEntregada = int.Parse(DTVentasProductosDetalle.Compute("sum(CantidadEntregada)", "").ToString());
                if(cantidadVendida == cantidadEntregada)
                    btnConfirmarEntregaTotal.Enabled = true;
                else
                    btnConfirmarEntregaTotal.Enabled = false;
            }

            lblNumeroVenta.Text = NumeroVentaProducto.ToString();
            DateTime HoraServidor = _TransaccionesUtilidadesCLN.ObtenerFechaHoraServidor();
            lblFechaVenta.Text = HoraServidor.ToShortTimeString() + " " + HoraServidor.ToShortDateString();

            formatearGrillaProductosEspecificos();
            _DTProductosEspecificosTemporal = VentaProductosEspecificosCLN.ListarVentasProductosEspecificosParaVenta(NumeroAgencia, NumeroVentaProducto);
            cargarDatosProductosEspecificos();

            if (permitirDeshabilitar)
                DeshabilitarBotones();
        }

        public void DeshabilitarBotones()
        {
            btnEntregaParcial.Enabled = false;
            btnConfirmarEntregaTotal.Enabled = false;
            btnReporte.Enabled = false;
            checkEdición.Enabled = false;
            btnConfirmar.Enabled = false;
            lblEstado.Text = "No puede Realizar Ninguna operación sobre esta Venta (Existencia Insuficiente)";
        }

        private void dtGVProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.Value != null) && (e.ColumnIndex == 4) && (Int32.Parse(e.Value.ToString()) > 0))
            {
                dtGVProductos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Bisque;
                dtGVProductos.Rows[e.RowIndex].Cells[0].Style.Font = new Font(e.CellStyle.Font.FontFamily, 7, FontStyle.Bold);
                dtGVProductos.Rows[e.RowIndex].Cells[1].Style.Font = new Font(e.CellStyle.Font.FontFamily, 7, FontStyle.Bold);
            }
            // 
            if (TipoOperacion == "M")
            {
                if ((e.Value != null) && (e.ColumnIndex == DGCCantidadEntregada.Index || e.ColumnIndex == DGCCantidadExistencia.Index) && (int.Parse(dtGVProductos["DGCCantidadEntregada", e.RowIndex].Value.ToString()) > int.Parse(dtGVProductos["DGCCantidadExistencia", e.RowIndex].Value.ToString())))
                {
                    e.CellStyle.BackColor = Color.LightCoral;
                }
            }
            else
            {
                if ((e.Value != null) && (e.ColumnIndex == DGCCantidadFaltante.Index || e.ColumnIndex == DGCCantidadExistencia.Index) && (int.Parse(dtGVProductos["DGCCantidadFaltante", e.RowIndex].Value.ToString()) > int.Parse(dtGVProductos["DGCCantidadExistencia", e.RowIndex].Value.ToString())))
                {
                    e.CellStyle.BackColor = Color.LightCoral;
                }
            }
        }

        

        public DataTable getDTProductosEspecificosGenerados()
        {
            DataTable DTproductosEspecificos = null;
            return DTproductosEspecificos;
        }

        public void crearColumnasDTProductosEspecificos()
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
            DCTiempoGarantia.DataType = Type.GetType("System.Int16");
            DCTiempoGarantia.DefaultValue = 0;
            DCTiempoGarantia.ColumnName = "TiempoGarantiaPE";

            DataColumn DCDespachado = new DataColumn();
            DCDespachado.DataType = Type.GetType("System.Boolean");
            DCDespachado.DefaultValue = false;
            DCDespachado.ColumnName = "EspecificoDespachado";


            _DTProductosEspecificosTemporal = new DataTable();

            _DTProductosEspecificosTemporal.Columns.Add(DCNombreProducto);
            _DTProductosEspecificosTemporal.Columns.Add(DCCodigoProducto);
            _DTProductosEspecificosTemporal.Columns.Add(DCCodigoProductoEspecifico);
            _DTProductosEspecificosTemporal.Columns.Add(DCTiempoGarantia);
            _DTProductosEspecificosTemporal.Columns.Add(DCDespachado);

            _DTProductosEspecificosTemporal.PrimaryKey = null;
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = _DTProductosEspecificosTemporal.Columns["CodigoProductoEspecifico"];
            _DTProductosEspecificosTemporal.PrimaryKey = PrimaryKeyColumns;
        }

        
        public bool generarProductosEspecificos(bool generacionCompleta)
        {
            //if (_DTProductosEspecificosTemporal.TableName.CompareTo("") == 0)
            crearColumnasDTProductosEspecificos();
            _DTProductosEspecificosTemporal.Clear();

            DTVentasProductosDetalleActual = DTVentasProductosDetalle.Copy();
            //if (!generacionCompleta && !esNecesarioLlenarPE)
            if (!esNecesarioLlenarPE)
            {
                int CantidadEntregar = 0;
                int CantidadEntregarAnterior = 0;
                int indice = 0;
                foreach (DataRow filaActual in DTVentasProductosDetalle.Rows)
                {
                    CantidadEntregar = int.Parse(DTVentasProductosDetalle.Rows[indice]["CantidadEntregada"].ToString());
                    CantidadEntregarAnterior = int.Parse(DTVentasProductosDetalleCopy.Rows[indice]["CantidadEntregada"].ToString());
                    DTVentasProductosDetalleActual.Rows[indice]["CantidadEntregada"] = CantidadEntregar - CantidadEntregarAnterior;
                    indice++;
                }
                DTVentasProductosDetalleActual.AcceptChanges();
            }                     
            if (DTVentasProductosDetalleActual.Compute("sum(CantidadEntregada)", "EsProductoEspecifico = true").ToString().Equals("0"))
            {                
                return false;
            }

            FIngresarCodigoProductoEspecificoParaAlmacenes fingresarCodigosProductosespecficos = new FIngresarCodigoProductoEspecificoParaAlmacenes(NumeroAgencia);
            fingresarCodigosProductosespecficos.DTDatosTransaccion = DTVentasProductosDetalleActual;
            fingresarCodigosProductosespecficos.formatearEstiloProductosEspecificos();
            fingresarCodigosProductosespecficos.ShowDialog(this);
            _DTProductosEspecificosSeleccionadosPorUsuarioTemporal = fingresarCodigosProductosespecficos.DTProductosEspecificosTemporal.Copy();
            if (!fingresarCodigosProductosespecficos.ProductosAceptados && fingresarCodigosProductosespecficos.generadosPorSistema)
            {
                usuarioSeleccionaEspecifico = false;
            }
            else if (!fingresarCodigosProductosespecficos.ProductosAceptados && !fingresarCodigosProductosespecficos.generadosPorSistema)
            {
                return false;
            }
            else if (fingresarCodigosProductosespecficos.ProductosAceptados && fingresarCodigosProductosespecficos.generadosPorSistema)
            {
                usuarioSeleccionaEspecifico = false;
            }
            else 
            {
                usuarioSeleccionaEspecifico = true;
            }
            int indiceActual = 0;
            //this.DGViewProductosSeleccionados.Sort(this.DGViewProductosSeleccionados.Columns[0], ListSortDirection.Ascending);
            foreach (DataRow fila in DTVentasProductosDetalleActual.Rows)
            {
                if (fila["EsProductoEspecifico"].Equals(true) && fila["VendidoComoAgregado"].Equals(false))
                {
                    string CodigoProducto;
                    string CodigoProductoEspecifico;
                    string NombreProducto;
                    int CantidadEntregada = 0; //Cantidad                    
                    int TiempoGarantiaPE = 0; //TiempoGarantiaPE
                    string[] listadoCodigosProductosEspecificosInventariados = null;

                    CodigoProducto = fila["CodigoProducto"].ToString();
                    NombreProducto = fila["NombreProducto"].ToString();
                    TiempoGarantiaPE = 0;
                    CantidadEntregada = Int16.Parse(fila["CantidadEntregada"].ToString());

                    if (!usuarioSeleccionaEspecifico)
                        listadoCodigosProductosEspecificosInventariados = InventarioProductoEspecificoCLN.ListarCodigosProductosEspecificosExistentes(NumeroAgencia, CodigoProducto, CantidadEntregada).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < CantidadEntregada; i++)
                    {
                        if (!usuarioSeleccionaEspecifico && i == listadoCodigosProductosEspecificosInventariados.Length)
                        {
                            if (MessageBox.Show(this, "No existe la cantidad de productos Especificos registrados en Inventario, Se Procedera a Realizar la Entrega de Productos existentes Actualmente" + Environment.NewLine + "Si desea entregar la cantidad existente, reabastecer su Inventario y registrar los Códigos de los Productos Especificos" + Environment.NewLine + "¿Desea Continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                break;
                            }
                            else
                            {
                                return false;
                            }
                        }

                        DataRow nuevoProductoEspecifico = _DTProductosEspecificosTemporal.NewRow();
                        if (usuarioSeleccionaEspecifico)
                        {
                            CodigoProductoEspecifico = _DTProductosEspecificosSeleccionadosPorUsuarioTemporal.Rows[indiceActual]["CodigoProductoEspecifico"].ToString().Trim();
                            TiempoGarantiaPE = Int32.Parse(_DTProductosEspecificosSeleccionadosPorUsuarioTemporal.Rows[indiceActual]["TiempoGarantiaPE"].ToString().Trim());
                        }
                        else
                        {
                            CodigoProductoEspecifico = listadoCodigosProductosEspecificosInventariados[i].Trim();
                        }
                        nuevoProductoEspecifico["NombreProducto"] = NombreProducto;
                        nuevoProductoEspecifico["CodigoProducto"] = CodigoProducto;
                        nuevoProductoEspecifico["CodigoProductoEspecifico"] = CodigoProductoEspecifico;
                        nuevoProductoEspecifico["TiempoGarantiaPE"] = TiempoGarantiaPE;
                        nuevoProductoEspecifico["EspecificoDespachado"] = true;
                        _DTProductosEspecificosTemporal.Rows.Add(nuevoProductoEspecifico);
                        nuevoProductoEspecifico.AcceptChanges();
                        indiceActual++;
                    }
                }
            }
            _DTProductosEspecificosTemporal.AcceptChanges();
            if (_DTProductosEspecificosTemporal.Rows.Count > 0)
            {
                string CodigoProducto = "";
                string NombreProducto = "";                
                string CodigoProductoEspecifico = "";
                int TiempoGarantiaPE = 0;    
                
                for (int i = 0; i < _DTProductosEspecificosTemporal.Rows.Count; i++)
                {
                    DataRow fila = _DTProductosEspecificosTemporal.Rows[i];

                    NombreProducto = fila[0].ToString();
                    CodigoProducto = fila[1].ToString();
                    CodigoProductoEspecifico = fila[2].ToString();
                    TiempoGarantiaPE = Int32.Parse(fila[3].ToString());
                    VentaProductosEspecificosCLN.InsertarVentaProductoEspecifico(NumeroAgencia, NumeroVentaProducto, CodigoProducto, CodigoProductoEspecifico, TiempoGarantiaPE, false, FechaHoraEntrega);
                    
                }
            }
            cargarDatosProductosEspecificos();
            return true;
        }

        public void cargarDatosProductosEspecificos()
        {
            if (_DTProductosEspecificosTemporal != null && _DTProductosEspecificosTemporal.Rows.Count > 0)
            {
                DSProductosEspecificos.Tables.Clear();
                DSProductosEspecificos.Tables.Add(_DTProductosEspecificosTemporal);
                dtGVProductosEspecificos.BindData(DSProductosEspecificos, _DTProductosEspecificosTemporal.TableName);
                dtGVProductosEspecificos.GroupTemplate.Column = dtGVProductosEspecificos.Columns[0];
                ListSortDirection direction = ListSortDirection.Ascending;
                dtGVProductosEspecificos.Sort(new DataRowComparer(0, direction));
            }
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

                    case "DGCCantidadEntregada":
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
                            int CantidadVendida = int.Parse(this.dtGVProductos.Rows[e.RowIndex].Cells["DGCCantidadVenta"].Value.ToString());
                            int existenciaInventario = int.Parse(this.dtGVProductos.Rows[e.RowIndex].Cells["DGCCantidadExistencia"].Value.ToString());
                            int CantidadAnteriorEntrega = int.Parse(this.dtGVProductos.Rows[e.RowIndex].Cells["DGCCantidadEntregada"].Value.ToString());
                            if (CantidadNuevaDeEntrega <= CantidadVendida)
                            {
                                if (CantidadAnteriorEntrega <= CantidadNuevaDeEntrega)
                                {
                                    int CantidadNueva = CantidadNuevaDeEntrega - CantidadAnteriorEntrega;
                                    if (CantidadNueva > existenciaInventario)
                                    {
                                        this.dtGVProductos.Rows[e.RowIndex].ErrorText = "   No puede entregar una cantidad que no puede Ser abastecida por Almacenes";
                                        e.Cancel = true;
                                    }
                                }
                                else
                                {
                                    this.dtGVProductos.Rows[e.RowIndex].ErrorText = "   No puede entregar una cantidad menor a la Cantidad Entregada Anteriormente";
                                    e.Cancel = true;
                                }
                                
                            }
                            else
                            {
                                this.dtGVProductos.Rows[e.RowIndex].ErrorText = "   No puede entregar una cantidad superior a la Cantidad Vendida.";                                
                                e.Cancel = true;
                            }                            
                        }
                        
                        //MessageBox.Show("Valor a Validar " + e.FormattedValue.ToString() + ",  Valor Anterior " + this.dtGVProductos.Rows[e.RowIndex].Cells["DGCCantidadExistencia"].Value.ToString());
                        break;


                }

            }
        }

        private void dtGVProductos_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            bool bHaveError = false;
            string sErrorMsg_RequiredFields = string.Empty;
            int newInteger;

            if (this.dtGVProductos.IsCurrentRowDirty)
            {
                System.Windows.Forms.DataGridViewRow oDGVR = this.dtGVProductos.Rows[e.RowIndex];


                if (oDGVR.Cells["DGCCantidadEntregada"].Value.ToString().Trim().Length < 1)
                {
                    sErrorMsg_RequiredFields += "   La Cantidad a entregar es necesaria y no puede estar vacia." + Environment.NewLine;
                    bHaveError = true;
                }
                else if (!int.TryParse(oDGVR.Cells["DGCCantidadEntregada"].Value.ToString(), out newInteger) || newInteger < 0)
                {
                    sErrorMsg_RequiredFields += "    La Cantidad a entregar debe ser un entero positivo." + Environment.NewLine;
                    bHaveError = true;
                }               

                if (bHaveError)
                {
                    oDGVR.ErrorText = sErrorMsg_RequiredFields;                    
                    e.Cancel = true;
                }

            }
        }

        private void dtGVProductos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.KeyPress -= new KeyPressEventHandler(txtbox_KeyPress);
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
            }
        }
        void txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                if (dtGVProductos.CurrentRow != null)
                {
                    dtGVProductos.EndEdit();
                }
            }
        }

        private void checkEdición_CheckedChanged(object sender, EventArgs e)
        {
            DGCCantidadEntregada.ReadOnly = !checkEdición.Checked;
        }

        public void formatearGrillaProductosEspecificos()
        {
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dtGVProductosEspecificos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtGVProductosEspecificos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;

            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dtGVProductosEspecificos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;

            this.dtGVProductosEspecificos.GridColor = System.Drawing.SystemColors.Control;
            this.dtGVProductosEspecificos.RowTemplate.Height = 19;
            this.dtGVProductosEspecificos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dtGVProductosEspecificos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtGVProductosEspecificos.RowHeadersVisible = false;
            this.dtGVProductosEspecificos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtGVProductosEspecificos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtGVProductosEspecificos.AllowUserToAddRows = false;
            this.dtGVProductosEspecificos.AllowUserToDeleteRows = false;
            this.dtGVProductosEspecificos.AllowUserToResizeRows = true;
            //this.dtGVVentaProductosEspecificos.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.dtGVProductosEspecificos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dtGVProductosEspecificos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGVProductosEspecificos.ClearGroups(); 


        }

        private void btnConfirmarInstitucional_Click(object sender, EventArgs e)
        {
            //confirmarEntregaInstitucional();


            try
            {
                confirmacionTotal = false;
                bool esPosible = _VentasProductosCLN.EsPosibleConcluirEntregaDeProductos(NumeroAgencia, NumeroVentaProducto, "A");
                if (esPosible)
                {
                    //string CodigoEstadoActualVenta = "";
                    //CodigoEstadoActualVenta = _TransaccionesUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(NumeroAgencia, NumeroVentaProducto, "V");
                    if (esNecesarioLlenarPE)
                    {
                        if (generarProductosEspecificos(false))
                        {
                            if (DTVentasProductosDetalle.Compute("sum(CantidadVenta)", "").ToString().CompareTo(DTVentasProductosDetalle.Compute("sum(CantidadEntregada)", "").ToString()) == 0)
                            {
                                
                                if (_TransaccionesUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(NumeroAgencia, NumeroVentaProducto, "V").Equals("P"))
                                {
                                    _VentasProductosCLN.ActualizarCodigoEstadoVenta(NumeroAgencia, NumeroVentaProducto, "F");
                                    confirmacionTotal = true;
                                }
                                else
                                {
                                    _VentasProductosCLN.ActualizarCodigoEstadoVenta(NumeroAgencia, NumeroVentaProducto, "C");                                    
                                }
                            }
                            else
                            {
                                if (_TransaccionesUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(NumeroAgencia, NumeroVentaProducto, "V").Equals("P"))
                                    _VentasProductosCLN.ActualizarCodigoEstadoVenta(NumeroAgencia, NumeroVentaProducto, "E");
                                else
                                    _VentasProductosCLN.ActualizarCodigoEstadoVenta(NumeroAgencia, NumeroVentaProducto, "D");
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "Ocurrio un Error al Momento de la solicitud de llenado de Productos Especificos, No se puede Continuar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            OperacionConfirmada = true;
                            return;
                        }
                    }
                    else
                    {
                        
                        if (DTVentasProductosDetalle.Compute("sum(CantidadVenta)", "").ToString().CompareTo(DTVentasProductosDetalle.Compute("sum(CantidadEntregada)", "").ToString()) == 0)
                        {
                            if (_TransaccionesUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(NumeroAgencia, NumeroVentaProducto, "V").Equals("P"))
                            {
                                _VentasProductosCLN.ActualizarCodigoEstadoVenta(NumeroAgencia, NumeroVentaProducto, "F");
                                confirmacionTotal = true;
                            }
                            else
                                _VentasProductosCLN.ActualizarCodigoEstadoVenta(NumeroAgencia, NumeroVentaProducto, "C");
                        }
                        else
                        {
                            if (_TransaccionesUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(NumeroAgencia, NumeroVentaProducto, "V").Equals("P"))
                                _VentasProductosCLN.ActualizarCodigoEstadoVenta(NumeroAgencia, NumeroVentaProducto, "E");
                            else
                                _VentasProductosCLN.ActualizarCodigoEstadoVenta(NumeroAgencia, NumeroVentaProducto, "D");
                        }
                    }

                    _TransaccionesUtilidadesCLN.ActualizarInventarioProductosVentas(NumeroAgencia, NumeroVentaProducto);
                    OperacionConfirmada = true;                   
                    conProductosEspecificos = true;
                    btnReporte_Click(sender, e);
                    btnConfirmar.Enabled = false;

                }
                else
                {
                    MessageBox.Show(this, "No puede realizar ninguna operación sobre esta venta, debido a que la cantidad de entrega de productos sobrepasa a la cantidad de Existencia en Inventarios"
                        + Environment.NewLine + "Probablemente se realizó la entrega de los correspondientes Productos a esta venta en otra venta"
                        + Environment.NewLine + "Puede proceder a modificar la venta actual o esperar al reabastecimiento de Almacenes para la entrega actual", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    btnConfirmarEntregaTotal.Enabled = false;
                    btnReporte.Enabled = false;
                    btnEntregaParcial.Enabled = false;
                    OperacionConfirmada = false;
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se Pudo actualizar correctamente la entrega de Productos al cargar la misma");
            }
        }        
        private void btnEntregaParcial_Click(object sender, EventArgs e)
        {
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
                switch (EstadoVentaActual_deEntrega)
                {
                    case "C":
                        if (MessageBox.Show(this, "Debe seleccionar los Productos Especificos para esta Venta, luego se Procedera a la Entrega del Recibo de conformidad al Cliente e igualar la Cantidad de Entrega Faltante." + Environment.NewLine + "¿Desea Continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //Mostrar Ventana de Productos Especificos
                            //Preguntar si fue concluido Satisfactoriamente 
                            string CodigoProducto = "";
                            int CantidadEntrega = 0;
                            if (!generarProductosEspecificos(false))
                            {
                                int cantidadEspecificos = int.Parse(DTVentasProductosDetalleActual.Compute("count(EsProductoEspecifico)", "EsProductoEspecifico = true").ToString());
                                if (cantidadEspecificos == DTVentasProductosDetalle.Rows.Count)
                                {
                                    MessageBox.Show(this, "La Cantidad de Ingreso de los Productos Especificos es Nula o Cero y no ha seleccionado Ningun Producto Específico, No puede continuar con la Operación", "Sin Selección de Productos Específicos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); ;
                                    OperacionConfirmada = false;
                                    return;
                                }
                            }
                            foreach (DataRow filaProducto in DTVentasProductosDetalle.Rows)
                            {
                                CodigoProducto = filaProducto["CodigoProducto"].ToString();
                                CantidadEntrega = int.Parse(filaProducto["CantidadEntregada"].ToString());
                                try
                                {
                                    _VentasProductosCLN.ActualizarVentaProductosDetalleCantidadRequerida(NumeroAgencia, NumeroVentaProducto, CodigoProducto, CantidadEntrega, FechaHoraEntrega);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("No se puedo Actualizar Satisfactoriamente, Ocurrio el Siguiente Error " + ex.Message);
                                }
                            }
                            btnReporte_Click(sender, e);
                        }
                        break;
                    case "P": //Pendiente
                        if (MessageBox.Show(this, "Se Procederá con la correspondiente actualización de entrega de la nueva cantidad ingresada" + Environment.NewLine + "¿Desea Continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string CodigoProducto = "";
                            int CantidadEntrega = 0;
                            foreach (DataRow filaProducto in DTVentasProductosDetalle.Rows)
                            {
                                CodigoProducto = filaProducto["CodigoProducto"].ToString();
                                CantidadEntrega = int.Parse(filaProducto["CantidadEntregada"].ToString());
                                try
                                {
                                    _VentasProductosCLN.ActualizarVentaProductosDetalleCantidadRequerida(NumeroAgencia, NumeroVentaProducto, CodigoProducto, CantidadEntrega, FechaHoraEntrega);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("No se puedo Actualizar Satisfactoriamente, Ocurrio el Siguiente Error " + ex.Message);
                                }
                            }
                            btnReporte_Click(sender, e);
                        }
                        break;
                    default:
                        MessageBox.Show("No puede Confirmar esta Venta, Consulte con su Administrador");
                        break;
                }
                if (DTVentasProductosDetalle.Compute("sum(CantidadVenta)", "").ToString().CompareTo(DTVentasProductosDetalle.Compute("sum(CantidadEntregada)", "").ToString()) == 0)
                {
                    if (_TransaccionesUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(NumeroAgencia, NumeroVentaProducto, "V").Equals("P"))
                        _VentasProductosCLN.ActualizarCodigoEstadoVenta(NumeroAgencia, NumeroVentaProducto, "F");
                    else
                        _VentasProductosCLN.ActualizarCodigoEstadoVenta(NumeroAgencia, NumeroVentaProducto, "C");
                }
                OperacionConfirmada = true;
            }
        }        
        private void btnConfirmarEntrega_Click(object sender, EventArgs e)
        {
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
                        btnReporte_Click(sender, e);
                    }
                    break;
                case "E":
                    if (esNecesarioLlenarPE)
                        MessageBox.Show("Debe seleccionar los Productos Especificos que va a entregar para esta Venta");
                    //Mostrar Ventana de Productos Especificos
                    if (!generarProductosEspecificos(true))
                    {
                        //MessageBox.Show("La Cantidad de Ingreso de los Productos Especificos es Nula o Cero");   
                        MessageBox.Show(this, "La Cantidad de Ingreso de los Productos Especificos es Nula o Cero y no ha seleccionado Ningun Producto Específico, No puede continuar con la Operación", "Sin Selección de Productos Específicos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); ;
                        return;
                    }
                    // _TransaccionesUtilidadesCLN.ActualizarInventarioProductosEspecficosVendidos(NumeroAgencia, NumeroVentaProducto);
                    CodigoEstadoVenta = _TransaccionesUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(NumeroAgencia, NumeroVentaProducto, "V");
                    //if (CodigoEstadoVenta == "D")
                    //    _TransaccionesUtilidadesCLN.ActualizarInventarioProductosVentas(NumeroAgencia, NumeroVentaProducto);
                    //else
                    _TransaccionesUtilidadesCLN.ActualizarInventarioProductosEspecficosVendidos(NumeroAgencia, NumeroVentaProducto);
                    btnReporte_Click(sender, e);
                    break;
                case "T":
                    btnReporte_Click(sender, e);
                    break;
                case "C":
                    if (MessageBox.Show(this, "El sistema se encargará de Completar e igualar las cantidades de entrega. " + Environment.NewLine + "¿Está seguro de Continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (DataRow fila in DTVentasProductosDetalle.Rows)
                        {
                            fila["CantidadEntregada"] = fila["CantidadVenta"];
                        }
                        DTVentasProductosDetalle.AcceptChanges();
                        if (!generarProductosEspecificos(true))
                        {
                            MessageBox.Show(this, "La Cantidad de Ingreso de los Productos Especificos es Nula o Cero y no ha seleccionado Ningun Producto Específico, No puede continuar con la Operación", "Sin Selección de Productos Específicos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); ;
                            OperacionConfirmada = false;
                            return;
                        }
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
                        btnReporte_Click(sender, e);
                    }
                    break;
                default:
                    MessageBox.Show("No puede Confirmar esta Venta, Consulte con su Administrador");
                    break;
            }
            OperacionConfirmada = true;
            if (_TransaccionesUtilidadesCLN.ObtenerCodigoEstadoActualTransacciones(NumeroAgencia, NumeroVentaProducto, "V").Equals("P"))
                _VentasProductosCLN.ActualizarCodigoEstadoVenta(NumeroAgencia, NumeroVentaProducto, "F");
            else //if (_VentasProductosCLN.ObtenerVentaProducto(NumeroAgencia, NumeroVentaProducto).Rows[0]["CodigoTipoVenta"].Equals("T"))
                _VentasProductosCLN.ActualizarCodigoEstadoVenta(NumeroAgencia, NumeroVentaProducto, "C");
        }
        private void btnReporte_Click(object sender, EventArgs e)
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
                DTVentasProductosDetalleCopy.Columns["CantidadFaltante"].ReadOnly = checkEdición.Checked;
                DTVentasProductosDetalleCopy.AcceptChanges();
                ReporteProductosEntregados = new FReporteVentaProductosReciboEntregados(DTVentasProductosDetalleCopy, "ISPE");
            }


            ReporteProductosEntregados.ShowDialog(this);
            checkEdición.Enabled = false;
            btnConfirmarEntregaTotal.Enabled = false;
            btnEntregaParcial.Enabled = false;
            btnReporte.Enabled = false;

        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        //private void dtGVProductos_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        //{

        //    bool bHaveError = false;
        //    string sErrorMsg_RequiredFields = string.Empty;
        //    int newInteger;

        //    if (this.dtGVProductos.IsCurrentRowDirty)
        //    {
        //        System.Windows.Forms.DataGridViewRow oDGVR = this.dtGVProductos.Rows[e.RowIndex];

        //        if (oDGVR.Cells["FirstName"].Value.ToString().Trim().Length < 1)
        //        {
        //            sErrorMsg_RequiredFields += "   First name is required." + Environment.NewLine;
        //            bHaveError = true;
        //        }

        //        if (oDGVR.Cells["Age"].Value.ToString().Trim().Length < 1)
        //        {
        //            sErrorMsg_RequiredFields += "   Age is required." + Environment.NewLine;
        //            bHaveError = true;
        //        }
        //        else if (!int.TryParse(oDGVR.Cells["Age"].Value.ToString(), out newInteger) || newInteger < 0)
        //        {
        //            sErrorMsg_RequiredFields += "   Age must be a number." + Environment.NewLine;
        //            bHaveError = true;
        //        }


        //        if (oDGVR.Cells["IsActive"].Value.ToString() == string.Empty)
        //        {
        //            sErrorMsg_RequiredFields += "   Active Status is required." + Environment.NewLine;
        //            bHaveError = true;
        //        }

        //        if (bHaveError)
        //        {
        //            oDGVR.ErrorText = sErrorMsg_RequiredFields;
        //            e.Cancel = true;
        //        }

        //    }

        //}

        //private void dtGVProductos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        //{
        //    int newInteger;            
        //    this.dtGVProductos.Rows[e.RowIndex].ErrorText = ""; 

        //    // No cell validation for new rows. New rows are validated on Row Validation.
        //    if (this.dtGVProductos.Rows[e.RowIndex].IsNewRow) { return; }

        //    if (this.dtGVProductos.IsCurrentCellDirty)
        //    {
        //        switch (this.dtGVProductos.Columns[e.ColumnIndex].Name)
        //        {
        //            case "FirstName":
        //                if (e.FormattedValue.ToString().Trim().Length < 1)
        //                {
        //                    e.Cancel = true;
        //                    this.dtGVProductos.Rows[e.RowIndex].ErrorText = "   First name is required.";
        //                }
        //                break;

        //            case "Age":
        //                if (e.FormattedValue.ToString().Trim().Length < 1)
        //                {
        //                    e.Cancel = true;
        //                    this.dtGVProductos.Rows[e.RowIndex].ErrorText = "   Age is required.";
        //                }
        //                else if (!int.TryParse(e.FormattedValue.ToString(), out newInteger) || newInteger < 0)
        //                {
        //                    e.Cancel = true;
        //                    this.dtGVProductos.Rows[e.RowIndex].ErrorText = "   Age must be a positive number.";
        //                }
        //                break;

        //            case "IsActive":
        //                if ((CheckState)e.FormattedValue == CheckState.Indeterminate)
        //                {
        //                    e.Cancel = true;
        //                    this.dtGVProductos.Rows[e.RowIndex].ErrorText = "   Active status is required.";
        //                }
        //                break;
        //        }
        //    }
        //}


    }
}
