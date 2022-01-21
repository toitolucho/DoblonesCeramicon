using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.GestionComercial;
using CLCAD;
using System.Globalization;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FCompraProductosGastosListado : Form
    {
        CompraProductosGastosDetalleCLN _CompraProductosGastosDetalleCLN;
        ProductosCLN _ProductosCLN;
        InventariosProductosCLN _InventariosProductosCLN;

        public DSDoblones20GestionComercial.ListarProductosRecepcionadosTipoCalculoInventarioDataTable DTProductosRecepcionados { get; set; }
        public DSDoblones20GestionComercial.ListarProductoGastosComprasDataTable DTProductosGastos { get; set; }
        /// <summary>
        /// Tabla que hace referencia al Formulario 'FCompraProductosRecepcionInventarios'  a la Tabla DTProductosRecepcion
        /// que contiene el Listado de Productos que pueden ser recepcionados, para listar la posible Actualización
        /// de inventarios de acuerdo a la Cantidad que se recepciona, generalmente lo utilizaremos cuando
        /// no existan gastos y calcularemos su Monto de Actualización bajo el TipoCalculoInventario,
        /// tomando en cuenta aquellas tuplas que tienen una NuevaCantidad > 0
        /// </summary>
        public DataTable DTProductosRecepcion { get; set; }
        DataTable DTCompraProductosRecepcionSeleccionados = null;
        DataTable DTCompraProductosRecepcionHistorial = null;
        DataSet DSProductosActualizacion;
        public DSDoblones20GestionComercial2.ListarProductosActualizacionNuevosPreciosDataTable DTListarProductosActualizacionNuevosPrecios;
        DataTable DTProductosGastosXML;
        

        public int NumeroAgencia { get; set; }
        public int NumeroCompraProducto { get; set; }
        string TipoCalculoPrecio = "";
        string ListadoProductos;
        decimal MontoTotalGasto = 0;
        public bool OperacionConfirmada = false;

        public CheckBox ChecUtilizarGastosActuales
        {
            get { return this.checkUtilizarGastosActuales; }
            set { this.checkUtilizarGastosActuales = value; }
        }

        public FCompraProductosGastosListado(int NumeroAgencia, int NumeroCompraProducto, string ListadoProductos)
        {
            InitializeComponent();
            this.NumeroAgencia = NumeroAgencia;
            this.NumeroCompraProducto = NumeroCompraProducto;
            this.ListadoProductos = ListadoProductos;

            _CompraProductosGastosDetalleCLN = new CompraProductosGastosDetalleCLN();
            _ProductosCLN = new ProductosCLN();
            _InventariosProductosCLN = new InventariosProductosCLN();

            dtGVGastos.AutoGenerateColumns = false;
            dtGVProductos.AutoGenerateColumns = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            DSProductosActualizacion = new DataSet("Productos");
            
            dtGVProductos.CurrentCellDirtyStateChanged += new EventHandler(dtGVProductos_CurrentCellDirtyStateChanged);

        }

        public void setTablasCalculoPrecioIncremento(DataTable DTCompraProductosRecepcionSeleccionados,
            DataTable DTCompraProductosRecepcionHistorial)
        {
            this.DTCompraProductosRecepcionSeleccionados = DTCompraProductosRecepcionSeleccionados;
            this.DTCompraProductosRecepcionHistorial = DTCompraProductosRecepcionHistorial;
        }

        public void CalcularPreciosIncrementosProrrateo()
        {            
            int CantidadProductosRecepcionados = 0;           
            DateTime FechaRecepcion;

            foreach (DataRow FilaFechaRecepcion in DTCompraProductosRecepcionSeleccionados.Select("Seleccionar = true"))
            {
                FechaRecepcion = DateTime.Parse(FilaFechaRecepcion["FechaRecepcion"].ToString());
                foreach (DataRow FilaHistorialRecepcion in DTCompraProductosRecepcionHistorial.Select("FechaHoraEntrega >= #" + FechaRecepcion.ToString(DateTimeFormatInfo.InvariantInfo) +
                "# and FechaHoraEntrega < #" + FechaRecepcion.AddSeconds(1).ToString(DateTimeFormatInfo.InvariantInfo) +"#"))
                {
                    CantidadProductosRecepcionados += (int)FilaHistorialRecepcion["CantidadEntregada"];
                }
            }
                
            decimal MontoIndividualIncremento = MontoTotalGasto / CantidadProductosRecepcionados;

            foreach(DataRow FilaProducton in DTProductosRecepcionados.Rows)
            {
                FilaProducton["MontoGastoProducto"] = Math.Round(MontoIndividualIncremento,2);
            }
            DTProductosRecepcionados.AcceptChanges();
            DGCMontoGastoProducto.Visible = true;
            DGCMontoGastoProducto.ReadOnly = true;
        }

        public void CalcularPreciosIncrementoPersonalizado()
        {
            int CantidadProductosRecepcionados = 0;           
            DateTime FechaRecepcion;
            foreach(DataRow FilaProductos in DTProductosRecepcionados.Rows )
            {
                CantidadProductosRecepcionados = 0;           
                foreach (DataRow FilaFechaRecepcion in DTCompraProductosRecepcionSeleccionados.Select("Seleccionar = true"))
                {
                    FechaRecepcion = DateTime.Parse(FilaFechaRecepcion["FechaRecepcion"].ToString());
                    foreach (DataRow FilaHistorialRecepcion in DTCompraProductosRecepcionHistorial.Select("FechaHoraEntrega >= #" + FechaRecepcion.ToString(DateTimeFormatInfo.InvariantInfo) +
                    "# and FechaHoraEntrega < #" + FechaRecepcion.AddSeconds(1).ToString(DateTimeFormatInfo.InvariantInfo) +"# AND CodigoProducto = '" + FilaProductos["CodigoProducto"].ToString() + "'" ))
                    {
                        CantidadProductosRecepcionados += (int)FilaHistorialRecepcion["CantidadEntregada"];
                    }
                }
                FilaProductos["MontoGastoProducto"] = Math.Round(Decimal.Parse(FilaProductos["MontoGastoProducto"].ToString()) / CantidadProductosRecepcionados, 2);
            }

            DTProductosRecepcionados.AcceptChanges();
        }


        public void crearTablaXML()
        {
            DTProductosGastosXML = new DataTable("ProductosHistorial");
            DSProductosActualizacion.Tables.Add(DTProductosGastosXML);
            DTProductosGastosXML.Columns.Add(new DataColumn("CodigoProducto", Type.GetType("System.String")));
            DTProductosGastosXML.Columns.Add(new DataColumn("CantidadRecepcion", Type.GetType("System.Int32")));
            DTProductosGastosXML.Columns.Add(new DataColumn("MontoGastoIncremento", Type.GetType("System.Decimal")));
            DTProductosGastosXML.Columns.Add(new DataColumn("PrecioUnitarioCompra", Type.GetType("System.Decimal")));


            int CantidadProductosRecepcionados = 0;
            DateTime FechaRecepcion;

            if (DTCompraProductosRecepcionSeleccionados != null && DTCompraProductosRecepcionSeleccionados.Rows.Count > 0)
            {
                foreach (DataRow FilaProductos in DTProductosRecepcionados.Rows)
                {
                    CantidadProductosRecepcionados = 0;
                    foreach (DataRow FilaFechaRecepcion in DTCompraProductosRecepcionSeleccionados.Select("Seleccionar = true"))
                    {
                        FechaRecepcion = DateTime.Parse(FilaFechaRecepcion["FechaRecepcion"].ToString());
                        foreach (DataRow FilaHistorialRecepcion in DTCompraProductosRecepcionHistorial.Select("FechaHoraEntrega >= #" + FechaRecepcion.ToString(DateTimeFormatInfo.InvariantInfo) +
                        "# and FechaHoraEntrega < #" + FechaRecepcion.AddSeconds(1).ToString(DateTimeFormatInfo.InvariantInfo) + "# AND CodigoProducto = '" + FilaProductos["CodigoProducto"].ToString() + "'"))
                        {
                            CantidadProductosRecepcionados += (int)FilaHistorialRecepcion["CantidadEntregada"];
                        }
                    }
                    //FilaProductos["MontoGastoProducto"] = Math.Round(Decimal.Parse(FilaProductos["MontoGastoProducto"].ToString()) / CantidadProductosRecepcionados, 2);

                    DTProductosGastosXML.Rows.Add(new object[] { FilaProductos["CodigoProducto"], CantidadProductosRecepcionados, FilaProductos["MontoGastoProducto"], FilaProductos["PrecioUnitarioCompra"] });
                }
            }
            else
            {
                foreach (DataRow FilaProductos in DTProductosRecepcion.Select("NuevaCantidad > 0"))
                {
                    DTProductosGastosXML.Rows.Add(new object[] { FilaProductos["CodigoProducto"], FilaProductos["NuevaCantidad"], 0, -1 });
                }
                TipoCalculoPrecio = "R";
            }            

            DTProductosGastosXML.AcceptChanges();


        }

        void dtGVProductos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtGVProductos.IsCurrentCellDirty && dtGVProductos.CurrentCell.ColumnIndex != DGCMontoGastoProducto.Index)
            { 
                dtGVProductos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        
        private void FCompraProductosGastosListado_Load(object sender, EventArgs e)
        {
            DGCNombreGasto.Width = 600;
            DGCNombreProducto.Width = 300;

            //listar Gastos por las Compras
            DTProductosGastos = _CompraProductosGastosDetalleCLN.ListarProductoGastosCompras(NumeroAgencia, NumeroCompraProducto);
            //Listar Productos Seleccionados y el Detalle del tipo de Producto
            DTProductosRecepcionados = _ProductosCLN.ListarProductosRecepcionadosTipoCalculoInventario(NumeroAgencia, NumeroCompraProducto, ListadoProductos);

            //Agregamos columnas al Listado de Productos
            DataColumn DTColunm = new DataColumn("ActualizarPrecioVenta", Type.GetType("System.Boolean"));
            DTColunm.DefaultValue = true;
            DTProductosRecepcionados.Columns.Add(DTColunm);

            DTColunm = new DataColumn("Promedio", Type.GetType("System.Boolean"));
            DTColunm.DefaultValue = false;
            DTProductosRecepcionados.Columns.Add(DTColunm);

            DTColunm = new DataColumn("UltimaRecepcion", Type.GetType("System.Boolean"));
            DTColunm.DefaultValue = false;
            DTProductosRecepcionados.Columns.Add(DTColunm);

            DTColunm = new DataColumn("MontoGastoProducto", Type.GetType("System.Decimal"));
            DTColunm.DefaultValue = 0;
            DTProductosRecepcionados.Columns.Add(DTColunm);
            

            dtGVGastos.DataSource = DTProductosGastos;
            dtGVProductos.DataSource = DTProductosRecepcionados;

            //decimal MontoIncrementoPorGastos = 0;
            //int CantidadTotalProductos = 0;
            if (DTProductosGastos.Count > 0)
            {
                MontoTotalGasto = decimal.Parse(DTProductosGastos.Compute("sum(MontoPagoGasto)", "").ToString());
                //if (TipoCalculoPrecio == "R")
                //{
                //    CantidadTotalProductos = (int)DTProductosRecepcionados.Compute("sum()","");
                //    //MontoIncrementoPorGastos = 
                //}
                
            }
            txtMontoTotalGastos.Text = MontoTotalGasto.ToString();

            if (TipoCalculoPrecio == "R" && DTCompraProductosRecepcionHistorial != null && DTCompraProductosRecepcionSeleccionados != null)
                CalcularPreciosIncrementosProrrateo();

            DTProductosRecepcionados.RowChanged += new DataRowChangeEventHandler(DTProductosRecepcionados_RowChanged);
            //CantidadRecepcion para cuando se tenga que enviar para calcular los precios nuevos
            crearTablaXML();
            dtGVGastosActualizacion.AutoGenerateColumns = false;
            string cadenaXML = DTProductosGastosXML.DataSet.GetXml();
            DTListarProductosActualizacionNuevosPrecios = _InventariosProductosCLN.ListarProductosActualizacionNuevosPrecios(NumeroAgencia, NumeroCompraProducto, cadenaXML, TipoCalculoPrecio);
            DTListarProductosActualizacionNuevosPrecios.PrecioUnitarioVenta1Column.Expression = "(PrecioCompraCalculado * PorcentajeUtilidad1 /100) + PrecioCompraCalculado";
            DTListarProductosActualizacionNuevosPrecios.PrecioUnitarioVenta2Column.Expression = "(PrecioCompraCalculado * PorcentajeUtilidad2 /100) + PrecioCompraCalculado";
            DTListarProductosActualizacionNuevosPrecios.PrecioUnitarioVenta3Column.Expression = "(PrecioCompraCalculado * PorcentajeUtilidad3 /100) + PrecioCompraCalculado";            

            dtGVGastosActualizacion.DataSource = DTListarProductosActualizacionNuevosPrecios;


        }

        void DTProductosRecepcionados_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            if (TipoCalculoPrecio == "P")
            {
                
                decimal MontoPersonalizadoGasto = decimal.Parse(DTProductosRecepcionados.Compute("sum(MontoGastoProducto)","").ToString());
                decimal MontoDiferencia = MontoTotalGasto - MontoPersonalizadoGasto;

                if (MontoDiferencia > 0)
                {
                    txtBoxMontoRestantePersonalizado.ForeColor = Color.Gold;
                }
                else
                {
                    if (MontoDiferencia < 0)
                    {
                        txtBoxMontoRestantePersonalizado.ForeColor = Color.Red;
                    }
                    else // MontoDiferencia == 0
                    {
                        this.txtBoxMontoRestantePersonalizado.ForeColor = System.Drawing.Color.GreenYellow;
                    }
                }
                txtBoxMontoRestantePersonalizado.Text = MontoDiferencia.ToString();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            OperacionConfirmada = false;
            this.Hide();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (TipoCalculoPrecio == "P" && checkUtilizarGastosActuales.Checked)
            {
                decimal MontoDiferencia = MontoTotalGasto - decimal.Parse(DTProductosRecepcionados.Compute("sum(MontoGastoProducto)", "").ToString());
                if (MontoDiferencia != 0)
                {
                    MessageBox.Show(this, "No puede Confirmar aún esta recepción de esta Orden Compra, \n\rdebido a que aun no ha terminado de igualar las cantidades de gastos", "Recepción de Mercadería", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }

                if (DTCompraProductosRecepcionHistorial != null && DTCompraProductosRecepcionSeleccionados != null)
                {
                    CalcularPreciosIncrementoPersonalizado();
                }
            }

            OperacionConfirmada = true;
            this.Hide();
        }

        private void FCompraProductosGastosListado_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!OperacionConfirmada)
            {
                if(MessageBox.Show(this, "¿Esta Seguro de Cancelar la Operación Actual?", "Recepción de Productos a Almacenes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        public void formatearParaCompraConGastosPersonalizados()
        {
            label1.Visible = true;
            label2.Visible = true;
            txtBoxMontoRestantePersonalizado.Visible = true;
            txtMontoTotalGastos.Visible = true;
            pnlDetallePreciosGastos.Visible = true;
            DGCMontoGastoProducto.Visible = true;
            TipoCalculoPrecio = "P";
        }

        public void formatearParaCompraConGastosRepartidos()
        {
            TipoCalculoPrecio = "R";
        }
        public void formatearParaCompraSinGastos()
        {
            lblMensaje.Text = "Debe seleccionar a que Productos aplicará el Tipo de Calculo para su Actualización en inventario con los respectivos precios de Venta";
            groupBox2.Visible = false;
            gBoxProductos.Dock = DockStyle.Fill;
            DGCPromedio.Visible = false;
            DGCUltimaRecepcion.Visible = false;
            DGCMontoGastoProducto.Visible = false;
            TipoCalculoPrecio = "";
            if (checkUtilizarGastosActuales == null)
                checkUtilizarGastosActuales = new CheckBox();
            checkUtilizarGastosActuales.Checked = false;
            checkUtilizarGastosActuales.Enabled = false;

        }

        private void dtGVProductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DTProductosRecepcionados.AcceptChanges();
            if (dtGVProductos.RowCount > 0 && dtGVProductos.CurrentRow != null)
            {
                if (DTProductosRecepcionados.Rows[e.RowIndex] != null && DTProductosRecepcionados[e.RowIndex]["ActualizarPrecioVenta"].Equals(true))
                {
                    if (e.ColumnIndex == DGCPromedio.Index && DTProductosRecepcionados[e.RowIndex]["Promedio"].Equals(true))
                    {
                        DTProductosRecepcionados.Rows[e.RowIndex]["UltimaRecepcion"] = false;
                    }

                    else if (e.ColumnIndex == DGCUltimaRecepcion.Index && DTProductosRecepcionados[e.RowIndex]["UltimaRecepcion"].Equals(true))
                    {
                        DTProductosRecepcionados[e.RowIndex]["Promedio"] = false;
                    }
                }
                else if (DTProductosRecepcionados.Rows[e.RowIndex] != null && DTProductosRecepcionados[e.RowIndex]["ActualizarPrecioVenta"].Equals(false))
                {
                    DTProductosRecepcionados[e.RowIndex]["Promedio"] = false;
                    DTProductosRecepcionados[e.RowIndex]["UltimaRecepcion"] = false;
                }
            }
        }

        private void dtGVProductos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("error" + e.Exception);
            e.Cancel = false;
            e.ThrowException = false;
        }

        private void dtGVProductos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (DTProductosRecepcionados != null && DTProductosRecepcionados.Count > 0)
                DTProductosRecepcionados.AcceptChanges();

            //DTProductosRecepcionados.AcceptChanges();
            if (dtGVProductos.RowCount > 0 && dtGVProductos.CurrentRow != null)
            {
                if (DTProductosRecepcionados.Rows[e.RowIndex] != null && DTProductosRecepcionados[e.RowIndex]["ActualizarPrecioVenta"].Equals(true))
                {
                    if (e.ColumnIndex == DGCPromedio.Index && DTProductosRecepcionados[e.RowIndex]["Promedio"].Equals(true))
                    {
                        DTProductosRecepcionados.Rows[e.RowIndex]["UltimaRecepcion"] = false;
                    }

                    else if (e.ColumnIndex == DGCUltimaRecepcion.Index && DTProductosRecepcionados[e.RowIndex]["UltimaRecepcion"].Equals(true))
                    {
                        DTProductosRecepcionados[e.RowIndex]["Promedio"] = false;
                    }
                }
                else if (DTProductosRecepcionados.Rows[e.RowIndex] != null && DTProductosRecepcionados[e.RowIndex]["ActualizarPrecioVenta"].Equals(false))
                {
                    DTProductosRecepcionados[e.RowIndex]["Promedio"] = false;
                    DTProductosRecepcionados[e.RowIndex]["UltimaRecepcion"] = false;
                }
            }
        }

        private void checUtilizarGastosActuales_CheckedChanged(object sender, EventArgs e)
        {
            if (checkUtilizarGastosActuales.Checked)
            {
                DGCPromedio.Visible = true;
                DGCUltimaRecepcion.Visible = true;
                if (TipoCalculoPrecio == "R")//repartido
                {
                    pnlDetallePreciosGastos.Visible = false;
                }
                else if (TipoCalculoPrecio == "P") // personalizado
                {
                    pnlDetallePreciosGastos.Visible = true;
                }
            }
            else
            {
                DGCPromedio.Visible = true;
                DGCUltimaRecepcion.Visible = true;

                DGCPromedio.Visible = false;
                DGCUltimaRecepcion.Visible = false;
                DGCMontoGastoProducto.Visible = false;
                pnlDetallePreciosGastos.Visible = false;


                foreach (DataRow FilaProductos in DTProductosRecepcionados.Rows)
                {
                    FilaProductos["Promedio"] = false;
                    FilaProductos["UltimaRecepcion"] = false;
                }
                DTProductosRecepcionados.AcceptChanges();
            }
        }

        private void dtGVProductos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            decimal MongoGastoProducto;

            this.dtGVProductos.Rows[e.RowIndex].ErrorText = "";

            // No cell validation for new rows. New rows are validated on Row Validation.
            if (this.dtGVProductos.Rows[e.RowIndex].IsNewRow) { return; }

            if (this.dtGVProductos.IsCurrentCellDirty)
            {
                switch (this.dtGVProductos.Columns[e.ColumnIndex].Name)
                {

                    case "DGCMontoGastoProducto":
                        if (e.FormattedValue.ToString().Trim().Length < 1)
                        {
                            this.dtGVProductos.Rows[e.RowIndex].ErrorText = "   El Monto de Gasto por Recepción de Productos es necesario y no puede estar vacia.";
                            e.Cancel = true;
                        }
                        else if (!decimal.TryParse(e.FormattedValue.ToString(), out MongoGastoProducto) || MongoGastoProducto < 0)
                        {
                            this.dtGVProductos.Rows[e.RowIndex].ErrorText = "   El Monto de Gasto por Recepción de Productos Debe ser Positivo";
                            e.Cancel = true;
                        }
                       
                        break;


                }

            }
        }

        private void checkUtilizarGastosActuales_CheckedChanged(object sender, EventArgs e)
        {
            if (TipoCalculoPrecio == "P")
            {
                DGCMontoGastoProducto.Visible = !DGCMontoGastoProducto.Visible;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1 && TipoCalculoPrecio =="P")
            {
                DTProductosRecepcionados.AcceptChanges();
                foreach (DataRow DRProductosRecepcionados in DTProductosRecepcionados.Rows)
                {
                    DTProductosGastosXML.Rows[DTProductosRecepcionados.Rows.IndexOf(DRProductosRecepcionados)]["MontoGastoIncremento"] = DRProductosRecepcionados["MontoGastoProducto"];
                }
                DTListarProductosActualizacionNuevosPrecios = _InventariosProductosCLN.ListarProductosActualizacionNuevosPrecios(NumeroAgencia, NumeroCompraProducto, DTProductosGastosXML.DataSet.GetXml(), TipoCalculoPrecio);
                dtGVGastosActualizacion.DataSource = DTListarProductosActualizacionNuevosPrecios;
            }
        }

    }
}
