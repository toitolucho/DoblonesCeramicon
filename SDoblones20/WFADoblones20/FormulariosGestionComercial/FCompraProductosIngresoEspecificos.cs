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

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FCompraProductosIngresoEspecificos : Form
    {
        public string CodigoProducto{ get;set; }
        public int CantidadGenerar { get; set; }
        private string NombreProducto;
        DataTable _DTProductosEspecificos;
        string CodigoProductoEspecifico = "";
        TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;
        InventariosProductosEspecificosCLN _InventariosProductosEspecificosCLN;
        public bool OperacionConfirmada { get; set; }
        public ArrayList ListadoProductosEspecificosEliminados { get; set; }


        public DataTable DTProductosEspecificos
        {
            get { return _DTProductosEspecificos; }
            set { _DTProductosEspecificos = value; }
        }

        public FCompraProductosIngresoEspecificos(string CodigoProducto, int CantidadGenerar, string NombreProducto)
        {
            InitializeComponent();
            this.CodigoProducto = CodigoProducto;
            this.CantidadGenerar = CantidadGenerar; 
            this.NombreProducto = NombreProducto;

            crearTablaProductosEspecificos();
            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();
            _InventariosProductosEspecificosCLN = new InventariosProductosEspecificosCLN();
            OperacionConfirmada = false;

            ListadoProductosEspecificosEliminados = new ArrayList();
            ListadoProductosEspecificosEliminados.Clear();
            
        }

        

        public void crearTablaProductosEspecificos()
        {
            _DTProductosEspecificos = new DataTable();

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

            _DTProductosEspecificos.Columns.AddRange(new DataColumn[] { 
                    DCCodigoProductoEspecifico, DCTiempoGarantia, DCFechaValidez});

            _DTProductosEspecificos.PrimaryKey = null;
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = _DTProductosEspecificos.Columns["CodigoProductoEspecifico"];
            _DTProductosEspecificos.PrimaryKey = PrimaryKeyColumns;

        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtBoxCodigoProductoEspecifico.Text.Trim()))
            {
                MessageBox.Show(this, "No puede ingresar un código vacio", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            CodigoProductoEspecifico = txtBoxCodigoProductoEspecifico.Text.Trim();
            int TiempoGarantiaPE = 0;
            DateTime FechaHoraVencimientoPE = DateTime.Now.AddMonths(3);

            if(_TransaccionesUtilidadesCLN.ExisteCodigoProductoEspecificoInventario(CodigoProducto, CodigoProductoEspecifico))
            {
                MessageBox.Show(this, "El código que esta ingresando ya se encuentra registrado en el Sistema", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            DataRow FilaCodigoEncontrado = _DTProductosEspecificos.Rows.Find(CodigoProductoEspecifico);
            if (FilaCodigoEncontrado != null)
            {
                dtGVproductosEspecificos.ClearSelection();
                dtGVproductosEspecificos.Rows[_DTProductosEspecificos.Rows.IndexOf(FilaCodigoEncontrado)].Selected = true;
            }
            else
            {
                TiempoGarantiaPE = (int) nUDtiempoGarantia.Value;
                FechaHoraVencimientoPE = dateTimePicker1.Value;

                DataRow FilaNueva = _DTProductosEspecificos.NewRow();
                FilaNueva["CodigoProductoEspecifico"] = CodigoProductoEspecifico;
                FilaNueva["TiempoGarantiaPE"] = TiempoGarantiaPE;
                FilaNueva["FechaHoraVencimientoPE"] = FechaHoraVencimientoPE;
                
                _DTProductosEspecificos.Rows.Add(FilaNueva);
                FilaNueva.AcceptChanges();

                int indiceNuevo = DTProductosEspecificos.Rows.IndexOf(DTProductosEspecificos.Rows.Find(CodigoProductoEspecifico));
                try
                {
                    dtGVproductosEspecificos.CurrentCell = dtGVproductosEspecificos[0, indiceNuevo];
                    dtGVproductosEspecificos.CurrentRow.Selected = true;
                    dtGVproductosEspecificos.FirstDisplayedScrollingRowIndex = DTProductosEspecificos.Rows.Count - 1;
                }
                catch (Exception )
                {
                    
                }
            }
            System.Media.SystemSounds.Asterisk.Play();
            txtBoxCodigoProductoEspecifico.Focus();
            txtBoxCodigoProductoEspecifico.SelectAll();
        }

        private void dtGVproductosEspecificos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (_DTProductosEspecificos.Rows.Count == CantidadGenerar)
            {
                txtBoxCodigoProductoEspecifico.Enabled = false;
                btnAnadir.Enabled = false;
            }

        }

        private void dtGVproductosEspecificos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (_DTProductosEspecificos.Rows.Count < CantidadGenerar)
            {
                txtBoxCodigoProductoEspecifico.Enabled = true;
                btnAnadir.Enabled = true;
            }
        }

        private void btnCompletar_Click(object sender, EventArgs e)
        {
            string[] ListadoCodigosEspecificos = _InventariosProductosEspecificosCLN.ObtenerListadoCodigoProductoEspecificoGenerado(CodigoProducto, CantidadGenerar, "-", "I").Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries);
            string CodigoProductoEspecifico = "";
            foreach (string codigoEspecifico in ListadoCodigosEspecificos)
            {
                if (!string.IsNullOrEmpty(codigoEspecifico.Trim()))
                {
                    DataRow FilaNueva = _DTProductosEspecificos.NewRow();
                    //codigoExpecifico = Listado_de_Codigos[i + 1].Trim().Substring(tamanioCodigoProducto + tamanioComodin, 20 - (tamanioCodigoProducto + tamanioComodin));
                    CodigoProductoEspecifico = CodigoProducto.Trim() + "-" + codigoEspecifico.Trim().Substring(CodigoProducto.Trim().Length + 1, 20 - (CodigoProducto.Trim().Length + 1));

                    if (DTProductosEspecificos.Rows.Find(CodigoProductoEspecifico) == null)
                    {
                        FilaNueva["CodigoProductoEspecifico"] = CodigoProductoEspecifico;
                        FilaNueva["TiempoGarantiaPE"] = (int)nUDtiempoGarantia.Value;
                        FilaNueva["FechaHoraVencimientoPE"] = dateTimePicker1.Value;

                        _DTProductosEspecificos.Rows.Add(FilaNueva);
                        FilaNueva.AcceptChanges();
                    }                    
                }
            }
            btnCompletar.Enabled = false;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            OperacionConfirmada = false;
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (dtGVproductosEspecificos.RowCount == CantidadGenerar)
            {
                OperacionConfirmada = true;
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "No Puede aún confirmar esta operación ya que aun no ha confirmado de llenar todos los códigos Especificos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                OperacionConfirmada = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtGVproductosEspecificos.RowCount > 0 && dtGVproductosEspecificos.CurrentRow != null)
            {
                if (MessageBox.Show(this, "¿Esta seguro de eliminar este registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ListadoProductosEspecificosEliminados.Add(_DTProductosEspecificos.Rows[dtGVproductosEspecificos.CurrentRow.Index]["CodigoProductoEspecifico"].ToString());
                    _DTProductosEspecificos.Rows[dtGVproductosEspecificos.CurrentRow.Index].Delete();
                    _DTProductosEspecificos.AcceptChanges();
                }
            }
        }

        private void FCompraProductosIngresoEspecificos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!OperacionConfirmada)
            {
                if (MessageBox.Show(this, "Aun no ha Confirmado el registro. ¿Desea continuar y cancelar la operación?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void txtBoxCodigoProductoEspecifico_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxCodigoProductoEspecifico.Text.Trim().Length == 30)
                btnAnadir_Click(btnAnadir, e);
        }

        private void txtBoxCodigoProductoEspecifico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAnadir_Click(btnAnadir, e);
            }
            else if (e.KeyCode == Keys.Up && dtGVproductosEspecificos.Rows.Count > 0)
            {
                dtGVproductosEspecificos.Focus();
                dtGVproductosEspecificos.Rows[dtGVproductosEspecificos.Rows.Count - 1].Selected = true;
            }
            else if (e.KeyCode == Keys.Down && dtGVproductosEspecificos.Rows.Count > 0)
            {
                dtGVproductosEspecificos.Focus();
                dtGVproductosEspecificos.Rows[0].Selected = true;
            }
        }

        private void dtGVproductosEspecificos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsDigit(e.KeyChar))
            {
                txtBoxCodigoProductoEspecifico.Focus();
                txtBoxCodigoProductoEspecifico.SelectAll();
                txtBoxCodigoProductoEspecifico.Text = e.KeyChar.ToString();
                txtBoxCodigoProductoEspecifico.SelectionStart = txtBoxCodigoProductoEspecifico.Text.Length;
            }
        }


        public void deshabilitarInsercion()
        {
            txtBoxCodigoProductoEspecifico.Enabled = false;
            btnAnadir.Enabled = false;
        }

        private void FCompraProductosIngresoEspecificos_Load(object sender, EventArgs e)
        {
            dtGVproductosEspecificos.AutoGenerateColumns = false;
            bindingSource1.DataSource = DTProductosEspecificos;
            dtGVproductosEspecificos.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;
            lblCodigoProducto.Text = "Producto :" + NombreProducto.Trim() +"("+CodigoProducto.Trim().ToUpper()+")";
        }

        private void dtGVproductosEspecificos_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.ColumnIndex == DGCFechaHoraVencimientoPE.Index)
                e.Value = DateTime.Now;
            if (e.ColumnIndex == DGCTiempoGarantiaPE.Index)
                e.Value = 0;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            _DTProductosEspecificos.AcceptChanges();
        }
        
    }
}
