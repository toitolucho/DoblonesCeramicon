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
using System.Collections;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FBusquedaProductosVendidos : Form
    {
        FProductosEspecificosDevolucion formProductosEspecificosDevolucion = new FProductosEspecificosDevolucion();
        private DataTable DTProductosBuscados = null;
        private DataTable _DTProductosDetalleSeleccionados = null;
        private DataTable _DTProductosDetalleEspecificosSeleccionados = null;
        private DataTable DTMotivoReemDevo = null;        
        private bool isEnterFromTableProductosBusqueda = false;
        Font fuenteDefecto;
        ArrayList listaMotivosReemDevo = new ArrayList();
        private bool operacionConfirmada;
        public bool OperacionConfirmada
        {
            get
            {
                return this.operacionConfirmada;
            }
        }
        private MotivosReemDevoCLN _MotivosReemDevoCLN = new MotivosReemDevoCLN();
        public DataTable DTProductosDetalleSeleccionados
        {
            get {
                if (_DTProductosDetalleSeleccionados == null)
                    _DTProductosDetalleSeleccionados = new DataTable();
                return _DTProductosDetalleSeleccionados;  
            }
            set
            {
                _DTProductosDetalleSeleccionados = value;
            }
        }
        public DataTable DTProductosDetalleEspecificosSeleccionados
        {
            get {
                if (_DTProductosDetalleEspecificosSeleccionados == null)
                    _DTProductosDetalleEspecificosSeleccionados = new DataTable();
                return _DTProductosDetalleEspecificosSeleccionados;
            }
            set
            {
                _DTProductosDetalleEspecificosSeleccionados = value;
            }
        }


        private TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();
        private int NumeroAgencia;
        private int NumeroTransaccion;
        private string TipoTransaccion;
        public FBusquedaProductosVendidos(int NumeroAgencia, int numeroTransaccion, string TipoTransaccion)
        {
            InitializeComponent();
            this.NumeroAgencia = NumeroAgencia;
            this.NumeroTransaccion = numeroTransaccion;
            this.TipoTransaccion = TipoTransaccion;

            crearTablasTemporales();
            dtGVProductos.AutoGenerateColumns = false;

            dtGVProductosBusqueda.DataSource = DTProductosBuscados;
            dtGVProductos.DataSource = DTProductosDetalleSeleccionados.DefaultView;
            dtGVProductosEspecificos.DataSource = DTProductosDetalleEspecificosSeleccionados;

            dtGVProductosBusqueda.AutoGenerateColumns = false;
            dtGVProductos.AutoGenerateColumns = false;
            dtGVProductosEspecificos.AutoGenerateColumns = false;

            DTMotivoReemDevo = _MotivosReemDevoCLN.ListarMotivosReemDevo(TipoTransaccion);
            

            cBoxMotivoDevolucion.DataSource = DTMotivoReemDevo;
            cBoxMotivoDevolucion.ValueMember = "CodigoMotivoReemDevo";
            cBoxMotivoDevolucion.DisplayMember = "NombreMotivoReemDevo";


            foreach (DataRow fila in DTMotivoReemDevo.Rows)
                listaMotivosReemDevo.Add(new MotivoReemDevo(fila));

            DGVCodigoMotivoReemDevo.DataSource = listaMotivosReemDevo;
            //DGVCodigoMotivoReemDevo.DataSource = DTMotivoReemDevo;
            DGVCodigoMotivoReemDevo.ValueMember = "CodigoMotivoReemDevo";
            DGVCodigoMotivoReemDevo.DisplayMember = "NombreMotivoReemDevo";
            DGVCodigoMotivoReemDevo.DataPropertyName = "CodigoMotivoReemDevo";

            dtGVProductos.Columns.Add(DGVCodigoMotivoReemDevo);

            cBoxBuscarPor.SelectedIndex = 2;
            txtBoxTextoBusqueda.Focus();

            fuenteDefecto = dtGVProductosEspecificos.DefaultCellStyle.Font;


            DTProductosDetalleSeleccionados.RowChanged += new DataRowChangeEventHandler(DTProductosDetalleSeleccionados_RowChanged);
            DTProductosDetalleEspecificosSeleccionados.RowChanged += new DataRowChangeEventHandler(DTProductosDetalleEspecificosSeleccionados_RowChanged);

            DTProductosDetalleEspecificosSeleccionados.DefaultView.Sort = "CodigoProducto ASC";
        }

        void DTProductosDetalleEspecificosSeleccionados_RowChanged(object sender, DataRowChangeEventArgs e)
        {
                        
        }

        void DTProductosDetalleSeleccionados_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            object MontoTotal = DTProductosDetalleSeleccionados.Compute("sum(PrecioTotal)", "");
            txtBoxMontoDevolucion.Text = MontoTotal.ToString();
        }

        public DataTable convertirCodigoMotivo_a_Descricpion()
        {
            DataTable DTProductosDetalleSeleccionadosTemp = DTProductosDetalleSeleccionados.Copy();            
            string DescripcionMotivoReemDevo = "";
            foreach (DataRow fila in DTProductosDetalleSeleccionadosTemp.Rows)
            {
                DescripcionMotivoReemDevo = DTMotivoReemDevo.Rows.Find(fila["CodigoMotivoReemDevo"])["NombreMotivoReemDevo"].ToString();
                fila["NombreMotivoReemDevo"] = DescripcionMotivoReemDevo;
            }
            
            return DTProductosDetalleSeleccionadosTemp;
        }

        public void crearTablasTemporales()
        {
            DataColumn DCCodigoProducto1 = new DataColumn();
            DCCodigoProducto1.AllowDBNull = false;
            DCCodigoProducto1.ColumnName = "CodigoProducto";
            DCCodigoProducto1.Unique = true;
            DCCodigoProducto1.DataType = Type.GetType("System.String");
            DCCodigoProducto1.ReadOnly = true;

            DataColumn DCNombreProducto1 = new DataColumn();
            DCNombreProducto1.AllowDBNull = false;
            DCNombreProducto1.ColumnName = "NombreProducto";
            DCNombreProducto1.Unique = true;
            DCNombreProducto1.DataType = Type.GetType("System.String");
            DCNombreProducto1.ReadOnly = true;

            DataColumn DCCantidadDevuelta = new DataColumn();
            DCCantidadDevuelta.AllowDBNull = false;
            DCCantidadDevuelta.ColumnName = "CantidadDevuelta";
            DCCantidadDevuelta.Unique = false;
            DCCantidadDevuelta.DataType = Type.GetType("System.Int32"); 
            DCCantidadDevuelta.ReadOnly = false;
            DCCantidadDevuelta.DefaultValue = 1;

            DataColumn DCPrecioUnitarioDevolucion = new DataColumn();
            DCPrecioUnitarioDevolucion.AllowDBNull = false;
            DCPrecioUnitarioDevolucion.ColumnName = "PrecioUnitarioDevolucion";
            DCPrecioUnitarioDevolucion.Unique = false;
            DCPrecioUnitarioDevolucion.DataType = Type.GetType("System.Decimal");
            DCPrecioUnitarioDevolucion.ReadOnly = false;
            DCPrecioUnitarioDevolucion.DefaultValue = 0;

            DataColumn DCMotiivoDevolucion = new DataColumn();
            DCMotiivoDevolucion.AllowDBNull = true;
            DCMotiivoDevolucion.ColumnName = "CodigoMotivoReemDevo";
            DCMotiivoDevolucion.Unique = false;
            DCMotiivoDevolucion.DataType = Type.GetType("System.Int32");
            DCMotiivoDevolucion.ReadOnly = false;

            //NombreMotivoReemDevo

            DataColumn DCNombreMotivoReemDevo = new DataColumn();
            DCNombreMotivoReemDevo.AllowDBNull = true;
            DCNombreMotivoReemDevo.ColumnName = "NombreMotivoReemDevo";
            DCNombreMotivoReemDevo.Unique = false;
            DCNombreMotivoReemDevo.DataType = Type.GetType("System.String");
            DCNombreMotivoReemDevo.ReadOnly = false;

            DataColumn DCEsproductoEspecifico = new DataColumn();
            DCEsproductoEspecifico.AllowDBNull = true;
            DCEsproductoEspecifico.ColumnName = "EsProductoEspecifico";
            DCEsproductoEspecifico.Unique = false;
            DCEsproductoEspecifico.DataType = Type.GetType("System.Boolean");
            DCEsproductoEspecifico.ReadOnly = false;
            DCEsproductoEspecifico.DefaultValue = false;

            DTProductosDetalleSeleccionados.Columns.AddRange(new DataColumn[] { DCNombreProducto1, DCCodigoProducto1, DCCantidadDevuelta, DCPrecioUnitarioDevolucion, DCMotiivoDevolucion, DCNombreMotivoReemDevo, DCEsproductoEspecifico });
            DTProductosDetalleSeleccionados.Columns.Add("PrecioTotal", typeof(decimal), "CantidadDevuelta*PrecioUnitarioDevolucion");
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = DTProductosDetalleSeleccionados.Columns["CodigoProducto"];
            DTProductosDetalleSeleccionados.PrimaryKey = PrimaryKeyColumns;



            
            DataColumn DCCodigoProducto2 = new DataColumn();
            DCCodigoProducto2.AllowDBNull = false;
            DCCodigoProducto2.ColumnName = "CodigoProducto";
            DCCodigoProducto2.Unique = false;
            DCCodigoProducto2.DataType = Type.GetType("System.String");
            DCCodigoProducto2.ReadOnly = false;

            DataColumn DCCodigoProductoEspecifico = new DataColumn();
            DCCodigoProductoEspecifico.AllowDBNull = false;
            DCCodigoProductoEspecifico.ColumnName = "CodigoProductoEspecifico";
            DCCodigoProductoEspecifico.Unique = true;
            DCCodigoProductoEspecifico.DataType = Type.GetType("System.String");
            DCCodigoProductoEspecifico.ReadOnly = true;

            DataColumn DCNombreProducto2 = new DataColumn();
            DCNombreProducto2.AllowDBNull = false;
            DCNombreProducto2.ColumnName = "NombreProducto";
            DCNombreProducto2.Unique = false;
            DCNombreProducto2.DataType = Type.GetType("System.String");
            DCNombreProducto2.ReadOnly = false;

            DataColumn DCPrecioUnitarioPE = new DataColumn();
            DCPrecioUnitarioPE.AllowDBNull = false;
            DCPrecioUnitarioPE.ColumnName = "PrecioUnitarioDevolucionPE";
            DCPrecioUnitarioPE.Unique = false;
            DCPrecioUnitarioPE.DataType = Type.GetType("System.Decimal");
            DCPrecioUnitarioPE.ReadOnly = false;
            
            DTProductosDetalleEspecificosSeleccionados.Columns.AddRange(new DataColumn[] { DCNombreProducto2, DCCodigoProducto2, DCCodigoProductoEspecifico, DCPrecioUnitarioPE });
            DataColumn[] PrimaryKeyColumns2 = new DataColumn[1];
            PrimaryKeyColumns2[0] = DTProductosDetalleEspecificosSeleccionados.Columns["CodigoProductoEspecifico"];
            DTProductosDetalleEspecificosSeleccionados.PrimaryKey = PrimaryKeyColumns2;
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtBoxTextoBusqueda.Text))
            {
                MessageBox.Show("Aun no ingresado un texto para Buscar");
                txtBoxTextoBusqueda.Focus();
                txtBoxTextoBusqueda.SelectAll();
                return;
            }

            DTProductosBuscados = _TransaccionesUtilidadesCLN.BuscarProductoTransaccionDevolucion(NumeroAgencia, NumeroTransaccion, cBoxBuscarPor.SelectedIndex.ToString(), txtBoxTextoBusqueda.Text.Trim(),TipoTransaccion, checkExactamenteIgual.Checked);
            dtGVProductosBusqueda.DataSource = DTProductosBuscados;
            lblNroRegistroEncontrados.Text = "Nro Registros Encontrados : " + DTProductosBuscados.Rows.Count.ToString();
            txtBoxTextoBusqueda.Focus();
            txtBoxTextoBusqueda.SelectAll();

            if (DTProductosBuscados.Rows.Count == 0)
                MessageBox.Show(this, "No se Encontró ningún producto con la Descripción provista", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            agregarProducto();
        }


        public void agregarProducto()
        {
            if (dtGVProductosBusqueda.CurrentRow != null && dtGVProductosBusqueda.RowCount > 0)
            {                
                string CodigoProducto = dtGVProductosBusqueda.CurrentRow.Cells[0].Value.ToString();

                if(!_TransaccionesUtilidadesCLN.EsPosibleDevolucionProductoGarantia(NumeroAgencia, NumeroTransaccion,  CodigoProducto, TipoTransaccion) &&                
                    MessageBox.Show(this,"Probablmente El Producto que usted ha seleccionado para su Devolucion no tiene Garantia o la misma ha expirado. ¿Desea aún asi registrar la Devolución?", "Garantia Expirada para Devolucion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                        return;
                }
                string NombreProducto = dtGVProductosBusqueda.CurrentRow.Cells[1].Value.ToString();
                int cantidad = (int)nUDCantidad.Value;
                object CodigoMotivo = cBoxMotivoDevolucion.SelectedValue;
                decimal PrecioUnitario = Decimal.Parse(txtBoxPrecio.Text);
                bool EsProductoEspecifico = bool.Parse(DTProductosBuscados.Rows[dtGVProductosBusqueda.CurrentRow.Index]["EsProductoEspecifico"].ToString());

                DataRow NuevaFila = DTProductosDetalleSeleccionados.NewRow();
                NuevaFila["CodigoProducto"] = CodigoProducto;
                NuevaFila["NombreProducto"] = NombreProducto;
                NuevaFila["CantidadDevuelta"] = cantidad;
                NuevaFila["PrecioUnitarioDevolucion"] = PrecioUnitario;
                NuevaFila["CodigoMotivoReemDevo"] = CodigoMotivo;
                NuevaFila["EsProductoEspecifico"] = EsProductoEspecifico;
                try
                {
                    DTProductosDetalleSeleccionados.Rows.Add(NuevaFila);
                }
                catch (Exception ex)
                {
                    if (MessageBox.Show(this, "Existio un error al querer agregar el Producto Seleccionado a la Devolución." + Environment.NewLine + "Probablemente ya fue seleccionado para su Devolución" + Environment.NewLine + " ¿ Desea ver el Motivo por el cúal se Causo el Error ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) 
                    {
                        MessageBox.Show(ex.Message);
                    }
                    return;
                }
                NuevaFila.AcceptChanges();

                //object EsProductoEspecifico = DTProductosBuscados.Rows[dtGVProductosBusqueda.CurrentRow.Index]["EsProductoEspecifico"];
                if (EsProductoEspecifico)
                {
                    formProductosEspecificosDevolucion.formatearOpcionesIniciales(NumeroAgencia, NumeroTransaccion, CodigoProducto, TipoTransaccion, cantidad);
                    formProductosEspecificosDevolucion.Darformato(NombreProducto);
                    formProductosEspecificosDevolucion.ShowDialog();

                    if (!formProductosEspecificosDevolucion.OperacionConfirmada)
                    {
                        MessageBox.Show(this, "No Puede Realizar la Devolución de Este Producto, sin haber primero Seleccionado que productos Especifico devolverá" + Environment.NewLine + "Vuelva a Insertar el Producto y Seleccione que productos Devolverá", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DTProductosDetalleSeleccionados.Rows.Remove(NuevaFila);
                        DTProductosDetalleSeleccionados.AcceptChanges();
                    }
                    else
                    {
                        DataTable DTEspecificos = formProductosEspecificosDevolucion.DTProductosEspecifcos;
                        int indice = 0;
                        foreach (DataRow fila in DTEspecificos.Rows)
                        {
                            if (fila["Devolver"].Equals(true))
                            {
                                DataRow NuevoEspecifico = DTProductosDetalleEspecificosSeleccionados.NewRow();
                                if (indice == 0)
                                {                                    
                                    NuevoEspecifico["NombreProducto"] = NombreProducto;
                                }
                                else
                                {                                    
                                    NuevoEspecifico["NombreProducto"] = "";
                                }
                                NuevoEspecifico["CodigoProducto"] = CodigoProducto;
                                NuevoEspecifico["CodigoProductoEspecifico"] = fila["CodigoProductoEspecifico"];
                                NuevoEspecifico["PrecioUnitarioDevolucionPE"] = fila["PrecioDevolucion"];

                                DTProductosDetalleEspecificosSeleccionados.Rows.Add(NuevoEspecifico);
                                indice++;
                            }
                            
                        }
                        object Promedio = DTEspecificos.Compute("avg(PrecioDevolucion)", "Devolver = true");
                        NuevaFila.BeginEdit();
                        NuevaFila["PrecioUnitarioDevolucion"] = Decimal.Round((decimal)Promedio, 2);
                        NuevaFila.AcceptChanges();                        
                    }
                }

                object MontoTotal = DTProductosDetalleSeleccionados.Compute("sum(PrecioTotal)", "");
                txtBoxMontoDevolucion.Text = MontoTotal.ToString();


            }
        }

        private void dtGVProductosBusqueda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            agregarProducto();
        }

        private void dtGVProductosBusqueda_SelectionChanged(object sender, EventArgs e)
        {
            if(dtGVProductosBusqueda.RowCount > 0 && dtGVProductosBusqueda.CurrentCell != null)
            {
                nUDCantidad.Maximum = Int32.Parse(dtGVProductosBusqueda.CurrentRow.Cells["DGVLimiteCantidadPosibleDevolucion"].Value.ToString());
                txtBoxPrecio.Text = dtGVProductosBusqueda.CurrentRow.Cells["DGVPrecioUnitarioBusqueda"].Value.ToString();
            }
        }

        private void txtBoxTextoBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click(sender, e as EventArgs);
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up && dtGVProductosBusqueda.RowCount > 0)
            {
                dtGVProductosBusqueda.Focus();
                dtGVProductosBusqueda.ClearSelection();
                if (e.KeyCode == Keys.Down)
                {
                    dtGVProductosBusqueda.Rows[0].Selected = true;
                }
                else
                {
                    dtGVProductosBusqueda.Rows[dtGVProductos.RowCount - 1].Selected = true;
                }
                    
            }
        }

        private void txtBoxTextoBusqueda_Enter(object sender, EventArgs e)
        {
            txtBoxTextoBusqueda.SelectAll();
        }

        private void dtGVProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                isEnterFromTableProductosBusqueda = true;
                cBoxMotivoDevolucion.Focus();                
            }
        }

        

        private void nUDCantidad_Enter(object sender, EventArgs e)
        {
            nUDCantidad.Select(0, nUDCantidad.Value.ToString().Length);
        }

        private void nUDCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBoxPrecio.Focus();
            }
        }

        private void txtBoxPrecio_Enter(object sender, EventArgs e)
        {
            if(txtBoxPrecio.SelectionLength != txtBoxPrecio.Text.Length)
                txtBoxPrecio.SelectAll();
        }

        private void txtBoxPrecio_KeyDown(object sender, KeyEventArgs e)
        {            
            if (e.KeyCode == Keys.Enter)
            {
                agregarProducto();
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up && dtGVProductosBusqueda.RowCount > 0)
            {
                dtGVProductosBusqueda.Focus();
                dtGVProductosBusqueda.ClearSelection();
                if (e.KeyCode == Keys.Down)
                {
                    dtGVProductosBusqueda.Rows[0].Selected = true;
                }
                else
                {
                    dtGVProductosBusqueda.Rows[dtGVProductos.RowCount - 1].Selected = true;
                }

            }
        }

        private void dtGVProductosEspecificos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //if (DTProductosDetalleEspecificosSeleccionados.Rows.Count > 0)
            //{

            //    if (dtGVProductosEspecificos.Rows[e.RowIndex].Cells[0].Value != null && !dtGVProductosEspecificos.Rows[e.RowIndex].Cells[0].Value.Equals(""))
            //    {
            //        dtGVProductosEspecificos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Bisque;
            //        dtGVProductosEspecificos.Rows[e.RowIndex].Cells[0].Style.Font = new Font(fuenteDefecto.Name, fuenteDefecto.Size, FontStyle.Bold);                    
            //        dtGVProductosEspecificos.Rows[e.RowIndex].Cells[2].Style.Font = new Font(fuenteDefecto.Name, fuenteDefecto.Size, FontStyle.Bold);
            //    }
            //}
        }

        private void FBusquedaProductosVendidos_Shown(object sender, EventArgs e)
        {
            txtBoxTextoBusqueda.Focus();
        }

        private void txtBoxPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & (Keys)e.KeyChar != Keys.Enter & e.KeyChar != ',')
            {                
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
                return;
            }
        }

        private void dtGVProductosBusqueda_Leave(object sender, EventArgs e)
        {
            if (isEnterFromTableProductosBusqueda && dtGVProductosBusqueda.Rows.Count >= 0)
            {
                if (dtGVProductosBusqueda.CurrentRow.Index == 0)
                {
                    isEnterFromTableProductosBusqueda = false;
                    dtGVProductosBusqueda.CurrentCell = dtGVProductosBusqueda.Rows[0].Cells[1];
                    dtGVProductosBusqueda.Rows[0].Selected = true;                    
                }
                else
                {
                    dtGVProductosBusqueda.CurrentCell = dtGVProductosBusqueda.Rows[dtGVProductosBusqueda.CurrentRow.Index - 1].Cells[1];
                    dtGVProductosBusqueda.Rows[dtGVProductosBusqueda.CurrentRow.Index].Selected = true;
                    isEnterFromTableProductosBusqueda = false;
                }

                
            }
        }

        private void cBoxMotivoDevolucion_DropDownClosed(object sender, EventArgs e)
        {
            nUDCantidad.Focus();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (DTProductosDetalleSeleccionados.Rows.Count == 0)
            {
                if (MessageBox.Show(this, "Aún no ha seleccionado un Producto para ser Devuelto." + Environment.NewLine + " ¿ Desea Cancelar la operacion y continuar buscando un producto a devolver ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    operacionConfirmada = false;
                    this.Close();
                    return;
                }
            }

            DataTable DTProductosBuscadosTemporal;
            int LimiteCantidadPosibleDevolucion = 0;
            int CantidadDevuelta = 0;
            foreach (DataRow FilaProducto in DTProductosDetalleSeleccionados.Rows)
            {
                DTProductosBuscadosTemporal = _TransaccionesUtilidadesCLN.BuscarProductoTransaccionDevolucion(NumeroAgencia, NumeroTransaccion, "0", FilaProducto["CodigoProducto"].ToString() ,TipoTransaccion, true);
                if (DTProductosBuscadosTemporal.Rows.Count > 0)
                {
                    LimiteCantidadPosibleDevolucion = int.Parse(DTProductosBuscadosTemporal.Rows[0]["LimiteCantidadPosibleDevolucion"].ToString());
                    CantidadDevuelta = int.Parse(FilaProducto["CantidadDevuelta"].ToString());
                    if (CantidadDevuelta > LimiteCantidadPosibleDevolucion)
                    {
                        if (MessageBox.Show(this, "No puede Realizar el retorno de una Cantidad que supere a la cantidad que se Otorgo en la transacción" + Environment.NewLine
                            + " para el Producto " + FilaProducto["NombreProducto"].ToString().Trim() +". ¿Desea que el Sistema Corrija la Cantidad la Cantidad Maxima posible de Retorno?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            FilaProducto["CantidadDevuelta"] = LimiteCantidadPosibleDevolucion;
                        }
                        dtGVProductos.ClearSelection();
                        dtGVProductos.Rows[ DTProductosDetalleSeleccionados.Rows.IndexOf(FilaProducto) ].Selected = true;
                        dtGVProductos.FirstDisplayedScrollingRowIndex = DTProductosDetalleSeleccionados.Rows.IndexOf(FilaProducto);
                        return;
                    }
                }
            }

            llenarEspeciosBlancoProductosEspecificos();
            operacionConfirmada = true;            
            this.Close();
        }


        public void llenarEspeciosBlancoProductosEspecificos()
        {
            if (DTProductosDetalleEspecificosSeleccionados.Rows.Count > 0)
            {
                object codigosBlancos = DTProductosDetalleEspecificosSeleccionados.Compute("count(NombreProducto)", " NombreProducto = '' ");
                if (!codigosBlancos.Equals(0))
                {
                    for (int i = 0; i < DTProductosDetalleEspecificosSeleccionados.Rows.Count; i++)
                    {
                        if (String.IsNullOrEmpty(DTProductosDetalleEspecificosSeleccionados.Rows[i]["NombreProducto"].ToString()))
                        {
                            //DTProductosDetalleEspecificosSeleccionados.Rows[i]["CodigoProducto"] = DTProductosDetalleEspecificosSeleccionados.Rows[i - 1]["CodigoProducto"];
                            DTProductosDetalleEspecificosSeleccionados.Rows[i]["NombreProducto"] = DTProductosDetalleEspecificosSeleccionados.Rows[i - 1]["NombreProducto"];
                        }
                    }
                }
            }
        }

        private void FBusquedaProductosVendidos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!operacionConfirmada && DTProductosDetalleSeleccionados.Rows.Count > 0)
            {
                if (MessageBox.Show(this, "Tiene Productos seleccionados para ser devueltos." + Environment.NewLine + "¿ Desea confirmar la Transacción en este Estado ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    operacionConfirmada = false;
                    e.Cancel = true;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            DTProductosDetalleSeleccionados.AcceptChanges();
            bool EsProductoEspecifico = bool.Parse(DTProductosBuscados.Rows[dtGVProductos.CurrentRow.Index]["EsProductoEspecifico"].ToString());
            string CodigoProducto = DTProductosDetalleSeleccionados.Rows[dtGVProductos.CurrentRow.Index]["CodigoProducto"].ToString();
            int cantidad = int.Parse(DTProductosDetalleSeleccionados.Rows[dtGVProductos.CurrentRow.Index]["CantidadDevuelta"].ToString());
            string NombreProducto = DTProductosDetalleSeleccionados.Rows[dtGVProductos.CurrentRow.Index]["NombreProducto"].ToString();            
            if (EsProductoEspecifico)
            {                
                formProductosEspecificosDevolucion.formatearOpcionesEdicion(NumeroAgencia, NumeroTransaccion, CodigoProducto, TipoTransaccion, cantidad, DTProductosDetalleEspecificosSeleccionados);
                formProductosEspecificosDevolucion.Darformato(NombreProducto);
                formProductosEspecificosDevolucion.ShowDialog();

                if (!formProductosEspecificosDevolucion.OperacionConfirmada)
                {
                    MessageBox.Show(this, "No Puede Realizar la Devolución de Este Producto, sin haber primero Seleccionado que productos Especifico devolverá" + Environment.NewLine + "Vuelva a Insertar el Producto y Seleccione que productos Devolverá", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DTProductosDetalleSeleccionados.Rows.Remove(DTProductosBuscados.Rows[dtGVProductosBusqueda.CurrentRow.Index]);
                    DTProductosDetalleSeleccionados.AcceptChanges();
                }
                else
                {
                    DataTable DTEspecificos = formProductosEspecificosDevolucion.DTProductosEspecifcos;
                    
                    foreach (DataRow fila in DTEspecificos.Rows)
                    {
                        if (fila["Devolver"].Equals(true))
                        {

                            DataRow FilaBuscada = DTProductosDetalleEspecificosSeleccionados.Rows.Find(fila["CodigoProductoEspecifico"].ToString());
                            if (FilaBuscada == null)
                            {                                
                                DataRow NuevoEspecifico = DTProductosDetalleEspecificosSeleccionados.NewRow();
                                NuevoEspecifico["CodigoProducto"] = CodigoProducto;
                                NuevoEspecifico["NombreProducto"] = "";
                                NuevoEspecifico["CodigoProductoEspecifico"] = fila["CodigoProductoEspecifico"];
                                NuevoEspecifico["PrecioUnitarioDevolucionPE"] = fila["PrecioDevolucion"];
                                DTProductosDetalleEspecificosSeleccionados.Rows.Add(NuevoEspecifico);                            
                            }
                            
                        }

                    }
                    object Promedio = DTEspecificos.Compute("avg(PrecioDevolucion)", "Devolver = true");
                    DTProductosDetalleSeleccionados.Rows[dtGVProductosBusqueda.CurrentRow.Index].BeginEdit();
                    DTProductosDetalleSeleccionados.Rows[dtGVProductosBusqueda.CurrentRow.Index]["PrecioUnitarioDevolucion"] = Decimal.Round((decimal)Promedio, 2);
                    DTProductosDetalleSeleccionados.Rows[dtGVProductosBusqueda.CurrentRow.Index].AcceptChanges();
                }
            }

            object MontoTotal = DTProductosDetalleSeleccionados.Compute("sum(PrecioTotal)", "");
            txtBoxMontoDevolucion.Text = MontoTotal.ToString();
        }

        private void dtGVProductosEspecificos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DTProductosDetalleEspecificosSeleccionados.Rows.Count > 0)
            {

                if (dtGVProductosEspecificos.Rows[e.RowIndex].Cells[0].Value != null && !dtGVProductosEspecificos.Rows[e.RowIndex].Cells[0].Value.Equals(""))
                {
                    dtGVProductosEspecificos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Bisque;
                    dtGVProductosEspecificos.Rows[e.RowIndex].Cells["DGVNombreProductoEspecifico"].Style.Font = new Font(fuenteDefecto.Name, fuenteDefecto.Size, FontStyle.Bold);                    
                }
            }
        }

        private void FBusquedaProductosVendidos_Load(object sender, EventArgs e)
        {

        }
                
    }


    public class MotivoReemDevo
    {
        private int _CodigoMotivoReemDevo;
        public int CodigoMotivoReemDevo
        {
            get { return _CodigoMotivoReemDevo; }
            set { this._CodigoMotivoReemDevo = value; }
        }

        private string _NombreMotivoReemDevo;
        public string NombreMotivoReemDevo
        {
            get { return _NombreMotivoReemDevo; }
            set { _NombreMotivoReemDevo = value; }
        }


        public MotivoReemDevo(int codigo, string descripcion)
        {
            this._CodigoMotivoReemDevo = codigo;
            this._NombreMotivoReemDevo = descripcion;
        }


        public MotivoReemDevo(DataRow fila)
        {
            this._CodigoMotivoReemDevo = Int32.Parse(fila[0].ToString());
            this._NombreMotivoReemDevo = fila[1].ToString();
        }
    }
}
