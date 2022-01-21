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
namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FIngresarCodigoProductoEspecificoParaAlmacenes : Form
    {        
        
        #region Campos o Atributos de la Clase Formulario
        private DataTable _DTProductosEspecificosTemporal;
        private DataTable _DTProductosEspecificosAgregadosTemporal;        
        private DataTable _DatosTransaccion;
        private TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;
        private int NumeroAgencia;
        private string _MascarMoneda = "";
        
        private ArrayList listaTiposAgregados = new ArrayList();
        private string CodigoProductoAnterior = "";
        public bool ProductosAceptados = false;
        public bool generadosPorSistema = false;
        #endregion

        #region Constantes
        private const int AnchoProductosEspecificos = 550;
        private const int AnchoProductosEspecificosAgregados = 697;
        private const int AlturaDatosProductosEspecificos = 70;
        private const int AlturaDatosProductosEspecificosAgregados = 111;
        #endregion

        #region Propiedades Formulario
        public DataTable DTProductosEspecificosTemporal
        {            
            get
            {
                if (_DTProductosEspecificosTemporal == null)
                    _DTProductosEspecificosTemporal = new DataTable();
                return _DTProductosEspecificosTemporal;
            }
            set
            {
                this._DTProductosEspecificosTemporal = value;
            }
        }
        public DataTable DTProductosEspecificosAgregdosTemporal
        {
            get
            {
                if (_DTProductosEspecificosAgregadosTemporal == null)
                    _DTProductosEspecificosAgregadosTemporal = new DataTable();
                return _DTProductosEspecificosAgregadosTemporal;
            }
            set
            {
                this._DTProductosEspecificosAgregadosTemporal = value;
            }
        }
        public DataTable DTDatosTransaccion
        {
            get
            {
                return _DatosTransaccion;
            }
            set{
                this._DatosTransaccion = value;
            }
        }

        public string MascaraMoneda
        {
            get { return _MascarMoneda; }
            set { this._MascarMoneda = value; }
        }
        #endregion

        public FIngresarCodigoProductoEspecificoParaAlmacenes(int NumeroAgencia)
        {
            InitializeComponent();
            this.NumeroAgencia = NumeroAgencia;
            listaTiposAgregados.Add(new TiposAgregados("P", "Promoción"));
            listaTiposAgregados.Add(new TiposAgregados("B", "Bonificación"));
            listaTiposAgregados.Add(new TiposAgregados("C", "Compensación"));
            listaTiposAgregados.Add(new TiposAgregados("O", "Obsequio"));
            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();

            cBoxTipoAgregado.DataSource = listaTiposAgregados;
            cBoxTipoAgregado.ValueMember = "CodigoTipoAgregado";
            cBoxTipoAgregado.DisplayMember = "NombreAgregado";

            DGCCodigoTipoAgregado.DataSource = listaTiposAgregados;
            DGCCodigoTipoAgregado.ValueMember = "CodigoTipoAgregado";
            DGCCodigoTipoAgregado.DisplayMember = "NombreAgregado";

            /*this.cBoxTipoAgregado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cBoxTipoAgregado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;*/
            (DGCCodigoTipoAgregado as DataGridViewComboBoxColumn).AutoComplete = true;           

            dtGVProductosEspecificosSeleccionados.Visible = true;
            
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxCodigoEspecifico.Text))
            {
                MessageBox.Show(this, "No Puede Ingresar Valores nulos dentro del Código Específico de un Producto, Proceda a llenar los datos correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoxCodigoEspecifico.Focus();
                return;
            }
            string CodigoProducto = "-1";
            string CodigoProductoEspecifico = txtBoxCodigoEspecifico.Text;
            int TiempoGarantiaPE = (int) nUDTiempoGarantia.Value;


            if (!_TransaccionesUtilidadesCLN.ExisteCodigoProductoEspecificoEnInventario(NumeroAgencia, CodigoProductoEspecifico))
            {
                MessageBox.Show(this, "El Código Espécifico ingresado, no se encuentra disponible en inventario", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoxCodigoEspecifico.Focus();
                txtBoxCodigoEspecifico.SelectAll();
                return;
            }           

            if (String.IsNullOrEmpty(CodigoProductoAnterior))
            {
                CodigoProductoAnterior = CodigoProducto;
            }

            if (CodigoProductoEspecifico.Contains(CodigoProductoAnterior))
            {
                CodigoProducto = CodigoProductoAnterior;
            }
            else
            {
                CodigoProducto = _TransaccionesUtilidadesCLN.ObtenerCodigoProductoPorCodigoProductoEspecifico(NumeroAgencia, CodigoProductoEspecifico);
                CodigoProductoAnterior = CodigoProducto;
            }
            DataRow FilaProductoEscogido = DTDatosTransaccion.Rows.Find(CodigoProducto);
            if (FilaProductoEscogido == null)
            {
                MessageBox.Show(this, "El Producto que ha ingresado (" + CodigoProducto.Trim() + "), No se encuentra Registrado en la Venta que se lleva actualmente; porfavor, cancele toda la transacción o edite la misma, para agregar el producto Ingresado", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                return;
            }

            if (cBoxTipoAgregado.Visible)
            {
                DataRow FilaEnGrilla = DTProductosEspecificosAgregdosTemporal.Rows.Find(CodigoProductoEspecifico);
                if (FilaEnGrilla != null)
                {
                    dtGVProductosEspecificosSeleccionados.ClearSelection();
                    int IndiceGrilla = DTProductosEspecificosAgregdosTemporal.Rows.IndexOf(FilaEnGrilla);
                    dtGVProductosEspecificosSeleccionados.CurrentCell = dtGVProductosEspecificosSeleccionados[0, IndiceGrilla];
                    dtGVProductosEspecificosSeleccionados.Rows[IndiceGrilla].Selected = true;                    
                    return;
                }
            }
            else
            {
                DataRow FilaEnGrilla = DTProductosEspecificosTemporal.Rows.Find(CodigoProductoEspecifico);
                if (FilaEnGrilla != null)
                {
                    int IndiceGrilla = DTProductosEspecificosTemporal.Rows.IndexOf(FilaEnGrilla);
                    dtGVProductosEspecificosSeleccionados.Rows[IndiceGrilla].Selected = true;
                    return;
                }
            }

            if (cBoxTipoAgregado.Visible) // ingreso de solo Productos Agregados
            {
                DateTime FechaHoraVencimientoPE;
                decimal PrecioUnitario;
                string CodigoTipoAgregado;

                FechaHoraVencimientoPE = dtPickerTiempoGarantia.Value;
                if (Decimal.TryParse(txtBoxPrecioUnitario.Text.Substring(0,txtBoxPrecioUnitario.Text.Length-MascaraMoneda.Length), out PrecioUnitario))
                {
                    CodigoTipoAgregado = cBoxTipoAgregado.SelectedValue.ToString();
                }
                else
                {
                    MessageBox.Show(this, "El Precio ingresado no es Correcto, no se encuentra registrado de esa manera en inventario." +Environment.NewLine+"Probablemente escribio mal sus datos, Por Favor Proceda a corregirlo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBoxPrecioUnitario.Focus();
                    txtBoxPrecioUnitario.SelectAll();
                    return;
                }

                DataRow filaAgregado = DTProductosEspecificosAgregdosTemporal.NewRow();
                filaAgregado.BeginEdit();
                filaAgregado["CodigoProducto"] = CodigoProducto;
                filaAgregado["CodigoProductoEspecifico"] = CodigoProductoEspecifico;
                filaAgregado["TiempoGarantiaPE"] = TiempoGarantiaPE;
                filaAgregado["FechaHoraVencimientoPE"] = FechaHoraVencimientoPE;
                filaAgregado["PrecioUnitario"] = PrecioUnitario;
                filaAgregado["CodigoTipoAgregado"] = CodigoTipoAgregado;                
                DTProductosEspecificosAgregdosTemporal.Rows.Add(filaAgregado);
                filaAgregado.AcceptChanges();
                sortDataTable(DTProductosEspecificosAgregdosTemporal);

                int indiceNuevo = DTProductosEspecificosAgregdosTemporal.Rows.IndexOf(DTProductosEspecificosAgregdosTemporal.Rows.Find(CodigoProductoEspecifico));
                dtGVProductosEspecificosSeleccionados.CurrentCell = dtGVProductosEspecificosSeleccionados[0, indiceNuevo];
                dtGVProductosEspecificosSeleccionados.CurrentRow.Selected = true;


            }
            else //ingreso de solo Productos Especificos
            {
                DataRow filaEspecifico = DTProductosEspecificosTemporal.NewRow();
                filaEspecifico.BeginEdit();
                filaEspecifico["CodigoProducto"] = CodigoProducto;
                filaEspecifico["CodigoProductoEspecifico"] = CodigoProductoEspecifico;
                filaEspecifico["TiempoGarantiaPE"] = TiempoGarantiaPE;                
                DTProductosEspecificosTemporal.Rows.Add(filaEspecifico);
                filaEspecifico.AcceptChanges();
                sortDataTable(DTProductosEspecificosTemporal);

                int indiceNuevo = DTProductosEspecificosTemporal.Rows.IndexOf(DTProductosEspecificosTemporal.Rows.Find(CodigoProductoEspecifico));
                dtGVProductosEspecificosSeleccionados.CurrentCell = dtGVProductosEspecificosSeleccionados[0, indiceNuevo];
                dtGVProductosEspecificosSeleccionados.CurrentRow.Selected = true;
                System.Media.SystemSounds.Asterisk.Play();
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtBoxCodigoEspecifico.Clear();
            nUDTiempoGarantia.Value = 0;
            cBoxTipoAgregado.SelectedIndex = 3;
            dtPickerTiempoGarantia.Value = DateTime.Now.AddMonths(3);
            txtBoxPrecioUnitario.Text = "0";
            txtBoxCodigoEspecifico.Focus();
        }

        public void formatearEstiloProductosEspecificos()
        {
            if (DTProductosEspecificosTemporal.Columns.Count == 0)
            {
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
                
                DataColumn DCTiempoGarantia = new DataColumn();
                DCTiempoGarantia.DataType = Type.GetType("System.Int16");
                DCTiempoGarantia.DefaultValue = 0;
                DCTiempoGarantia.ColumnName = "TiempoGarantiaPE";

                DTProductosEspecificosTemporal.Columns.AddRange(new DataColumn[] { DCCodigoProducto, DCCodigoProductoEspecifico, DCTiempoGarantia });

                DTProductosEspecificosTemporal.PrimaryKey = null;
                DataColumn[] PrimaryKeyColumns = new DataColumn[1];
                PrimaryKeyColumns[0] = DTProductosEspecificosTemporal.Columns["CodigoProductoEspecifico"];
                DTProductosEspecificosTemporal.PrimaryKey = PrimaryKeyColumns;
                //CodigoProductoAnterior =
                for (int i = 0; i < DTDatosTransaccion.Rows.Count; i++ )
                {
                    //if (filaDatos["EsProductoEspecifico"].Equals(true) && filaDatos["VendidoComoAgregado"].Equals(false))
                    if (DTDatosTransaccion.Rows[i]["EsProductoEspecifico"].Equals(true) && DTDatosTransaccion.Rows[i]["VendidoComoAgregado"].Equals(false))
                    {
                        CodigoProductoAnterior = DTDatosTransaccion.Rows[i]["CodigoProducto"].ToString().Trim();
                        break;
                    }

                }
            }

            ////t.PrimaryKey.Clear(t.PrimaryKey, 0, 1)

            //if (DTDatosTransaccion.Columns.Contains("Código Producto") && DTDatosTransaccion.Columns.CanRemove(DTDatosTransaccion.Columns["Código Producto"]))
            //{
            DTDatosTransaccion.PrimaryKey = null;
            DataColumn[] PrimaryKeyColumnsDTDatosTransaccion = new DataColumn[1];

            PrimaryKeyColumnsDTDatosTransaccion[0] = DTDatosTransaccion.Columns["CodigoProducto"];
            DTDatosTransaccion.PrimaryKey = PrimaryKeyColumnsDTDatosTransaccion;
            //}            
            visibilidadComponentes(false);
            dtGVProductosEspecificosSeleccionados.DataSource = DTProductosEspecificosTemporal;
        }
        public void formatearEstiloProductosEspecificosAgregados()
        {
            if (DTProductosEspecificosAgregdosTemporal.Columns.Count == 0)
            {
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

                DataColumn DCTiempoGarantia = new DataColumn();
                DCTiempoGarantia.DataType = Type.GetType("System.Int16");
                DCTiempoGarantia.DefaultValue = 0;
                DCTiempoGarantia.ColumnName = "TiempoGarantiaPE";

                DataColumn DCCodigoTipoAgregado = new DataColumn();
                DCCodigoTipoAgregado.DataType = Type.GetType("System.String");
                DCCodigoTipoAgregado.ColumnName = "CodigoTipoAgregado";
                DCCodigoTipoAgregado.DefaultValue = "O";

                DataColumn DCFechaValidez = new DataColumn();
                DCFechaValidez.DataType = Type.GetType("System.DateTime");
                DCFechaValidez.ColumnName = "FechaHoraVencimientoPE";
                DCFechaValidez.DefaultValue = DateTime.Now;


                DataColumn DCPrecioUnitario = new DataColumn();
                DCPrecioUnitario.DataType = Type.GetType("System.Decimal");
                DCPrecioUnitario.ColumnName = "PrecioUnitario";
                DCPrecioUnitario.DefaultValue = 0.00;


                DTProductosEspecificosAgregdosTemporal.Columns.AddRange(new DataColumn[] { 
                    DCCodigoProducto, DCCodigoProductoEspecifico, DCTiempoGarantia,DCCodigoTipoAgregado, DCFechaValidez,DCPrecioUnitario });

                DTProductosEspecificosAgregdosTemporal.PrimaryKey = null;
                DataColumn[] PrimaryKeyColumns = new DataColumn[1];
                PrimaryKeyColumns[0] = DTProductosEspecificosAgregdosTemporal.Columns["CodigoProductoEspecifico"];
                DTProductosEspecificosAgregdosTemporal.PrimaryKey = PrimaryKeyColumns;

                
            }
            DTDatosTransaccion.PrimaryKey = null;
            DataColumn[] PrimaryKeyColumnsDTDatosTransaccion = new DataColumn[1];

            PrimaryKeyColumnsDTDatosTransaccion[0] = DTDatosTransaccion.Columns["CodigoProducto"];
            DTDatosTransaccion.PrimaryKey = PrimaryKeyColumnsDTDatosTransaccion;

            visibilidadComponentes(true);
            dtGVProductosEspecificosSeleccionados.DataSource = DTProductosEspecificosAgregdosTemporal;
        }

        public void visibilidadComponentes(bool isAgregado)
        {
            this.Width = isAgregado ? AnchoProductosEspecificosAgregados : AnchoProductosEspecificos;
            //gBoxIngresoDatos.Height = isAgregado ? AlturaDatosProductosEspecificosAgregados : AnchoProductosEspecificos;
            lblAgregadoPor.Visible = isAgregado;
            lblFechaVencimiento.Visible = isAgregado;
            lblPrecioUnitario.Visible = isAgregado;
            cBoxTipoAgregado.Visible = isAgregado;
            txtBoxPrecioUnitario.Visible = isAgregado;
            dtPickerTiempoGarantia.Visible = isAgregado;

            if (dtGVProductosEspecificosSeleccionados.Columns.Count <= 0)
            {
                dtGVProductosEspecificosSeleccionados.Columns.Clear();
                this.dtGVProductosEspecificosSeleccionados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.DGCCodigoProducto,
                this.DGCCodigoProductoEspecifico,
                this.DGCTiempoGarantiaPE,
                this.DGCFechaHoraVencimientoPE,
                this.DGCPrecioUnitario,
                this.DGCCodigoTipoAgregado});
            }

            dtGVProductosEspecificosSeleccionados.DataSource = DTProductosEspecificosTemporal;
            dtGVProductosEspecificosSeleccionados.Columns["DGCCodigoProducto"].Visible = true;
            dtGVProductosEspecificosSeleccionados.Columns["DGCCodigoProductoEspecifico"].Visible = true;
            dtGVProductosEspecificosSeleccionados.Columns["DGCTiempoGarantiaPE"].Visible = true;
            dtGVProductosEspecificosSeleccionados.Columns["DGCFechaHoraVencimientoPE"].Visible = isAgregado;
            dtGVProductosEspecificosSeleccionados.Columns["DGCPrecioUnitario"].Visible = isAgregado;
            dtGVProductosEspecificosSeleccionados.Columns["DGCCodigoTipoAgregado"].Visible = isAgregado;
            dtGVProductosEspecificosSeleccionados.Visible = true;
        }

        public void sortDataTable(DataTable DTProductos)
        {
            DTProductos.DefaultView.Sort = "CodigoProducto ASC";
        }

        private void txtBoxCodigoEspecifico_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxCodigoEspecifico.Text.Length == 30 && checkBox1.Checked) 
            {
                btnAnadir_Click(sender, e);
            }
        }

        private void txtBoxPrecioUnitario_Enter(object sender, EventArgs e)
        {
            if (txtBoxPrecioUnitario.Text.Trim().Contains(MascaraMoneda))
            {
                txtBoxPrecioUnitario.Select(0, txtBoxPrecioUnitario.Text.Trim().Length - MascaraMoneda.Length);
            }
            else
            {
                txtBoxPrecioUnitario.SelectAll();
            }
        }

        private void txtBoxPrecioUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & (Keys)e.KeyChar != Keys.Enter & e.KeyChar != ',')
            {
                txtBoxPrecioUnitario_Enter(sender, e as EventArgs);
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
                return;
            }
        }

        private void txtBoxPrecioUnitario_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxPrecioUnitario.Text.Contains('.'))
                txtBoxPrecioUnitario.Text.Replace('.', ',');            

            if (!txtBoxPrecioUnitario.Text.Trim().Contains(MascaraMoneda))
            {
                txtBoxPrecioUnitario.Text += " " + MascaraMoneda;
            }

        }

        private void txtBoxPrecioUnitario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txtBoxPrecioUnitario_Enter(sender, e as EventArgs);
            }
        }

        private void btnCancelarTodo_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show(this, "¿Esta Seguro de Cancelar la Introducción de los Productos Especificos?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ProductosAceptados = false;
                MessageBox.Show("Ha decidido cancelar la Operación actual de ingreso de Códigos Específicos. El Sistema se encargara de Seleccionarlos por usted");
                this.Hide();
            }
            else
            {
                if (cBoxTipoAgregado.Visible)
                {
                    object cantidadTotalProductos = DTDatosTransaccion.Compute("sum(CantidadVenta)", "VendidoComoAgregado = true");
                    int TotalProductos = Int32.Parse(cantidadTotalProductos.ToString());
                    if (DTProductosEspecificosAgregdosTemporal.Rows.Count < TotalProductos)
                    {
                        MessageBox.Show("Aun no ha Terminado de Ingresar todos los Productos Especificos Agregados");
                    }
                }
                else
                {
                    object cantidadTotalProductos = DTDatosTransaccion.Compute("sum(CantidadEntregada)", "EsProductoEspecifico = true");
                    int TotalProductos = Int32.Parse(cantidadTotalProductos.ToString());
                    if (DTProductosEspecificosTemporal.Rows.Count < TotalProductos)
                    {
                        MessageBox.Show("Aun no ha Terminado de Ingresar todos los Productos Especificos");
                    }
                }
                
            }
            
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            /*object NumeroAgregados = _DTVentasProductosDetalleTemporal.Compute("count(VendidoComoAgregado)", "VendidoComoAgregado = true");
            object NumeroEspecficos = _DTVentasProductosDetalleTemporal.Compute("count(EsProductoEspecifico)", "EsProductoEspecifico = 1");*/            

            int cantidad = 0;
            object cantidadPorProducto;
            string CodigoProducto = "";
            string condicion = "";
            int CantidadInsertadaActualmentePorProducto = 0;
            bool cerrarVentanaSatisfactoriamente = true;
            if (cBoxTipoAgregado.Visible)
            {                
                sortDataTable(DTProductosEspecificosAgregdosTemporal);
                foreach (DataRow filaDatos in DTDatosTransaccion.Rows)
                {
                    if (filaDatos["VendidoComoAgregado"].Equals(true))
                    {
                        cantidad = Int32.Parse(filaDatos["CantidadVenta"].ToString());
                        CodigoProducto = filaDatos["CodigoProducto"].ToString().Trim();
                        condicion = "CodigoProducto = '" + CodigoProducto + "'";
                        cantidadPorProducto = DTProductosEspecificosAgregdosTemporal.Compute("count(CodigoProducto)", condicion);
                        if (Int32.TryParse(cantidadPorProducto.ToString(), out CantidadInsertadaActualmentePorProducto))
                        {
                            if (cantidad != CantidadInsertadaActualmentePorProducto)
                            {
                                string NombreProducto = filaDatos["NombreProducto"].ToString().Trim();
                                MessageBox.Show(this, "La Cantidad especificada(" + CantidadInsertadaActualmentePorProducto.ToString() + ") para la transacción del Producto " + NombreProducto + ", no Coincide con la cantidad (" + cantidad.ToString() + ") de Productos Ingresados para realizar la Transacción " + Environment.NewLine + "Procesada a Terminar de Ingresar toda la Cantidad Requerida", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                }
            }
            else
            {
                sortDataTable(DTProductosEspecificosTemporal);
                foreach (DataRow filaDatos in DTDatosTransaccion.Rows)
                {
                    if (filaDatos["EsProductoEspecifico"].Equals(true) && filaDatos["VendidoComoAgregado"].Equals(false))
                    {
                        cantidad = Int32.Parse(filaDatos["CantidadEntregada"].ToString());
                        CodigoProducto = filaDatos["CodigoProducto"].ToString().Trim();
                        condicion = "CodigoProducto  = '" + CodigoProducto + "'";
                        cantidadPorProducto = DTProductosEspecificosTemporal.Compute("Count(CodigoProducto)", condicion);
                        if (Int32.TryParse(cantidadPorProducto.ToString(), out CantidadInsertadaActualmentePorProducto))
                        {
                            if (cantidad != CantidadInsertadaActualmentePorProducto)
                            {
                                string NombreProducto = filaDatos["NombreProducto"].ToString().Trim();
                                MessageBox.Show(this, "La Cantidad especificada de Entrega para la transacción del Producto " + NombreProducto +"["+CodigoProducto+"]"+ " es :" + CantidadInsertadaActualmentePorProducto.ToString() + ", La cual No coincide con la cantidad Ingresada Actualmente :" + cantidad.ToString() + " para su Entrega. " + Environment.NewLine + "Procesada a Terminar de Ingresar toda la Cantidad Requerida", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            if (CantidadInsertadaActualmentePorProducto > cantidad)
                            {
                                string NombreProducto = filaDatos["NombreProducto"].ToString().Trim();
                                if (MessageBox.Show(this, "La Cantidad Ingresada del Producto " + NombreProducto + "es " + CantidadInsertadaActualmentePorProducto.ToString() + ", La cual supera la cantidad que se requiere en la transacción." + Environment.NewLine + "¿ Desea Actualizar la Transacción con la Cantidad Ingresada Actualmente ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    //actualizar la cantidad vendida
                                    filaDatos.BeginEdit();
                                    filaDatos["Cantidad"] = CantidadInsertadaActualmentePorProducto;
                                    filaDatos.AcceptChanges();
                                }
                                else
                                {
                                    MessageBox.Show(this, "Seleccione el Código Especifico del Producto que desea Eliminar y vuelva a confirmar la Selección de los Productos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    cerrarVentanaSatisfactoriamente = false;
                                }
                            }
                        }
                    }
                    
                }
            }
            if (cerrarVentanaSatisfactoriamente)
            {
                ProductosAceptados = true;
                this.Hide();
            }
        }

        private void FIngresarCodigoProductoEspecifico_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = true;
            //if (generadosPorSistema)
            //{                
            //    this.Hide();
            //    return;
            //}
            //if (MessageBox.Show(this, "¿Está seguro de Cancelar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    this.Hide();                
            //}            

            if (!ProductosAceptados && MessageBox.Show(this, "¿Está seguro de Cancelar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            

        }

        private void btnGenerardoPorSistema_Click(object sender, EventArgs e)
        {
            ProductosAceptados = false;
            generadosPorSistema = true;
            this.Close();
        }

        private void FIngresarCodigoProductoEspecifico_Shown(object sender, EventArgs e)
        {
            dtGVProductosEspecificosSeleccionados.Columns.Clear();
            this.dtGVProductosEspecificosSeleccionados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCCodigoProducto,
            this.DGCCodigoProductoEspecifico,
            this.DGCTiempoGarantiaPE,
            this.DGCFechaHoraVencimientoPE,
            this.DGCPrecioUnitario,
            this.DGCCodigoTipoAgregado});
            ProductosAceptados = false;
            generadosPorSistema = false;
            btnCancelar_Click(sender, e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtGVProductosEspecificosSeleccionados.CurrentRow != null && dtGVProductosEspecificosSeleccionados.RowCount > 0)
            {
                if (cBoxTipoAgregado.Visible) // para los Agregados
                {
                    DTProductosEspecificosAgregdosTemporal.Rows[dtGVProductosEspecificosSeleccionados.CurrentRow.Index].Delete();
                    DTProductosEspecificosAgregdosTemporal.AcceptChanges();
                }
                else // para los Especificos
                {
                    DTProductosEspecificosTemporal.Rows[dtGVProductosEspecificosSeleccionados.CurrentRow.Index].Delete();
                    DTProductosEspecificosTemporal.AcceptChanges();
                }
            }
        }

        private void txtBoxCodigoEspecifico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnAnadir_Click(btnAnadir, e as EventArgs);
            }
        }
    }
}
