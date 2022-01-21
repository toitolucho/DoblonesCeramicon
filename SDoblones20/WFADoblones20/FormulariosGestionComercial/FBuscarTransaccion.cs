using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN;
using CLCLN.GestionComercial;
namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FBuscarTransaccion : Form
    {
        private DataTable _DTListadoTransaccion = null;
        private TransaccionesUtilidadesCLN OperacionesTransacciones = null;
        private char TipoTransaccion = ' ';
        private int NumeroAgencia;
        public int NumeroTransaccion;
        private string _CodigoEstadoTransaccion = null;

        #region Propiedades Formulario
        public string CodigoEstadoTransaccion
        {
            get
            {
                return _CodigoEstadoTransaccion;
            }
            set
            {
                _CodigoEstadoTransaccion = value;
            }
        }
        public DataTable DTListadoTransaccion
        {
            get
            {
                return _DTListadoTransaccion;
            }
        }

        public ComboBox CBoxBusquedaPor
        {
            get
            {
                return cBoxBuscarPor;
            }
        }

        public Button BtnLimpiar
        {
            get
            {
                return btnLimpiar;
            }
        }

        public Label LabelNumeroTransacciones
        {
            get
            {
                return lblNroTransaccion;
            }
        }

        public ToolStripStatusLabel LabelNumeroRegistro
        {
            get
            {
                return lblNumeroRegistros;
            }
        }
        #endregion

        public void formatearEstiloParaVentas()
        {
            txtBoxNumeroTransaccion.Clear();
            txtBoxTextoBusqueda.Clear();
            this.lblNroTransaccion.Text = "Numero de Venta";
            this.cBoxBuscarPor.Items.Clear();
            this.cBoxBuscarPor.Items.Add("Nombre Cliente");
            this.cBoxBuscarPor.Items.Add("NIT Cliente");
            this.cBoxBuscarPor.Items.Add("Nombre Producto");
            this.cBoxBuscarPor.Items.Add("Observaciones");
            this.cBoxBuscarPor.SelectedIndex = 0;
            TipoTransaccion = 'V';
            formatearColumnas();
        }

        public void formatearEstiloParaVentasServicios()
        {
            txtBoxNumeroTransaccion.Clear();
            txtBoxTextoBusqueda.Clear();
            this.lblNroTransaccion.Text = "Numero de Venta Servicio";
            this.cBoxBuscarPor.Items.Clear();
            this.cBoxBuscarPor.Items.Add("Nombre Cliente");
            this.cBoxBuscarPor.Items.Add("NIT Cliente");
            this.cBoxBuscarPor.Items.Add("Nombre Servicio");
            this.cBoxBuscarPor.Items.Add("Observaciones");
            this.cBoxBuscarPor.SelectedIndex = 0;
            TipoTransaccion = 'S';
            formatearColumnas();
        }

        public void formatearEstiloParaCotizaciones()
        {
            txtBoxNumeroTransaccion.Clear();
            txtBoxTextoBusqueda.Clear();
            this.lblNroTransaccion.Text = "Numero de Cotización";
            this.cBoxBuscarPor.Items.Clear();
            this.cBoxBuscarPor.Items.Add("Nombre Cliente");
            this.cBoxBuscarPor.Items.Add("NIT Cliente");
            this.cBoxBuscarPor.Items.Add("Nombre Producto");
            this.cBoxBuscarPor.Items.Add("Observaciones");
            this.cBoxBuscarPor.SelectedIndex = 0;
            TipoTransaccion = 'T';
            formatearColumnas();
        }

        public void formatearEstiloParaCompras()
        {
            txtBoxNumeroTransaccion.Clear();
            txtBoxTextoBusqueda.Clear();
            this.lblNroTransaccion.Text = "Numero de Compra";
            this.cBoxBuscarPor.Items.Clear();
            this.cBoxBuscarPor.Items.Add("Nombre Proveedor");
            this.cBoxBuscarPor.Items.Add("NIT Proveedor");
            this.cBoxBuscarPor.Items.Add("Nombre Producto");
            this.cBoxBuscarPor.Items.Add("Observaciones");
            this.cBoxBuscarPor.SelectedIndex = 0;
            TipoTransaccion = 'C';
            formatearColumnas();
        }

        public void formatearEstiloParaTransferencias()
        {
            txtBoxNumeroTransaccion.Clear();
            txtBoxTextoBusqueda.Clear();
            this.lblNroTransaccion.Text = "Numero de Transferencia";
            this.cBoxBuscarPor.Items.Clear();
            this.cBoxBuscarPor.Items.Add("Nombre Agencia Receptora");
            this.cBoxBuscarPor.Items.Add("NIT Agencia Receptora");
            this.cBoxBuscarPor.Items.Add("Nombre Producto");
            this.cBoxBuscarPor.Items.Add("Observaciones");
            this.cBoxBuscarPor.SelectedIndex = 0;
            TipoTransaccion = 'F';
            formatearColumnas();
        }

        public void formatearEstiloParaVentasDevoluciones()
        {
            txtBoxNumeroTransaccion.Clear();
            txtBoxTextoBusqueda.Clear();
            this.lblNroTransaccion.Text = "Numero de Devolución de Venta";
            this.cBoxBuscarPor.Items.Clear();
            this.cBoxBuscarPor.Items.Add("Nombre Cliente");
            this.cBoxBuscarPor.Items.Add("NIT Cliente");
            this.cBoxBuscarPor.Items.Add("Nombre Producto");
            this.cBoxBuscarPor.Items.Add("Observaciones");
            this.cBoxBuscarPor.SelectedIndex = 0;
            TipoTransaccion = 'D';
            formatearColumnas();
        }


        public void formatearEstiloParaComprasDevoluciones()
        {
            txtBoxNumeroTransaccion.Clear();
            txtBoxTextoBusqueda.Clear();
            this.lblNroTransaccion.Text = "Numero de Devolución de Compra";
            this.cBoxBuscarPor.Items.Clear();
            this.cBoxBuscarPor.Items.Add("Nombre Proveedor");
            this.cBoxBuscarPor.Items.Add("NIT Proveedor");
            this.cBoxBuscarPor.Items.Add("Nombre Producto");
            this.cBoxBuscarPor.Items.Add("Observaciones");
            this.cBoxBuscarPor.SelectedIndex = 0;
            TipoTransaccion = 'P';
            formatearColumnas();
        }

        public FBuscarTransaccion(int NumeroAgencia)
        {
            InitializeComponent();
            this.NumeroAgencia = NumeroAgencia;
            _DTListadoTransaccion = new DataTable();
            OperacionesTransacciones = new TransaccionesUtilidadesCLN();
            bdSourceTransacciones.DataSource = _DTListadoTransaccion;
            dtGVTransacciones.AutoGenerateColumns = true;
            dateTimePicker1.Value = new DateTime(DateTime.Now.Year, 1, 1);
            
        }


        public void formatearColumnas()
        {
            switch (TipoTransaccion)
            {
                case 'V':
                    {
                        _DTListadoTransaccion = OperacionesTransacciones.BuscarVentasProductos(cBoxBuscarPor.SelectedIndex.ToString(), txtBoxTextoBusqueda.Text.Trim(), NumeroAgencia, -10, dateTimePicker1.Value, dateTimePicker2.Value, checkTextoIdentico.Checked, CodigoEstadoTransaccion);
                        bdSourceTransacciones.DataSource = _DTListadoTransaccion;
                        break;
                    }
                case 'S':
                    {
                        _DTListadoTransaccion = OperacionesTransacciones.BuscarVentasServicios(cBoxBuscarPor.SelectedIndex.ToString(), txtBoxTextoBusqueda.Text.Trim(), NumeroAgencia, -10, dateTimePicker1.Value, dateTimePicker2.Value, checkTextoIdentico.Checked, CodigoEstadoTransaccion);
                        bdSourceTransacciones.DataSource = _DTListadoTransaccion;
                        break;
                    }
                case 'T':
                    {
                        _DTListadoTransaccion = OperacionesTransacciones.BuscarVentasCotizacionProductos(cBoxBuscarPor.SelectedIndex.ToString(), txtBoxTextoBusqueda.Text.Trim(), NumeroAgencia, -10, dateTimePicker1.Value, dateTimePicker2.Value, checkTextoIdentico.Checked, CodigoEstadoTransaccion);
                        bdSourceTransacciones.DataSource = _DTListadoTransaccion;
                        break;
                    }
                case 'C':
                    {
                        _DTListadoTransaccion = OperacionesTransacciones.BuscarComprasProductos(cBoxBuscarPor.SelectedIndex.ToString(), txtBoxTextoBusqueda.Text.Trim(), NumeroAgencia, -10, dateTimePicker1.Value, dateTimePicker2.Value, checkTextoIdentico.Checked, CodigoEstadoTransaccion);
                        bdSourceTransacciones.DataSource = _DTListadoTransaccion;
                        break;
                    }
                case 'D':
                    {
                        _DTListadoTransaccion = OperacionesTransacciones.BuscarVentasDevolucionesProductos(cBoxBuscarPor.SelectedIndex.ToString(), txtBoxTextoBusqueda.Text.Trim(), NumeroAgencia, -10, dateTimePicker1.Value, dateTimePicker2.Value, checkTextoIdentico.Checked, CodigoEstadoTransaccion);
                        bdSourceTransacciones.DataSource = _DTListadoTransaccion;
                        break;
                    }
                case 'P':
                    {
                        _DTListadoTransaccion = OperacionesTransacciones.BuscarComprasDevolucionesProductos(cBoxBuscarPor.SelectedIndex.ToString(), txtBoxTextoBusqueda.Text.Trim(), NumeroAgencia, -10, dateTimePicker1.Value, dateTimePicker2.Value, checkTextoIdentico.Checked, CodigoEstadoTransaccion);
                        bdSourceTransacciones.DataSource = _DTListadoTransaccion;
                        break;
                    }
                case 'F':
                    {
                        _DTListadoTransaccion = OperacionesTransacciones.BuscarTransferenciasProductos(cBoxBuscarPor.SelectedIndex.ToString(), txtBoxTextoBusqueda.Text.Trim(), NumeroAgencia, -10, dateTimePicker1.Value, dateTimePicker2.Value, checkTextoIdentico.Checked, CodigoEstadoTransaccion);
                        bdSourceTransacciones.DataSource = _DTListadoTransaccion;
                        break;
                    }
                default:
                    break;
            }
            dtGVTransacciones.DataSource = bdSourceTransacciones;
            dtGVTransacciones.AutoGenerateColumns = true;            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBoxNumeroTransaccion.Clear();
            txtBoxTextoBusqueda.Clear();
            this._DTListadoTransaccion.Clear();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                this.NumeroTransaccion = Int32.Parse(dtGVTransacciones[1, dtGVTransacciones.CurrentCell.RowIndex].Value.ToString());
            }
            catch (Exception)
            {                
                
            } 
            this.Hide();
        }

        private void dtGVTransacciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.NumeroTransaccion = Int32.Parse(dtGVTransacciones[1, e.RowIndex].Value.ToString());
            }
            catch (Exception)
            {
                
                
            }
        }


        private void dtGVTransacciones_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.NumeroTransaccion = Int32.Parse(dtGVTransacciones[1, dtGVTransacciones.CurrentCell.RowIndex].Value.ToString());
            }
            catch (Exception)
            {
                
                
            }
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtBoxNumeroTransaccion.Text.Trim()) && String.IsNullOrEmpty(txtBoxTextoBusqueda.Text))
            {
                MessageBox.Show(this, "Aun no ha ingresado un Texto a Buscar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                _DTListadoTransaccion.Clear();
                int NumeroTransaccion = -1;
                if (txtBoxNumeroTransaccion.Text.Trim().Length > 0 && txtBoxNumeroTransaccion.Text != null)
                {
                    NumeroTransaccion = Int32.Parse(txtBoxNumeroTransaccion.Text);
                }

                switch (TipoTransaccion)
                {
                    case 'V':
                        {
                            _DTListadoTransaccion = OperacionesTransacciones.BuscarVentasProductos(cBoxBuscarPor.SelectedIndex.ToString(), txtBoxTextoBusqueda.Text.Trim(), NumeroAgencia, NumeroTransaccion, dateTimePicker1.Value, dateTimePicker2.Value, checkTextoIdentico.Checked, CodigoEstadoTransaccion);
                            bdSourceTransacciones.DataSource = _DTListadoTransaccion;
                            break;
                        }
                    case 'S':
                        {
                            _DTListadoTransaccion = OperacionesTransacciones.BuscarVentasServicios(cBoxBuscarPor.SelectedIndex.ToString(), txtBoxTextoBusqueda.Text.Trim(), NumeroAgencia, NumeroTransaccion, dateTimePicker1.Value, dateTimePicker2.Value, checkTextoIdentico.Checked, CodigoEstadoTransaccion);
                            bdSourceTransacciones.DataSource = _DTListadoTransaccion;
                            break;
                        }
                    case 'T':
                        {
                            _DTListadoTransaccion = OperacionesTransacciones.BuscarVentasCotizacionProductos(cBoxBuscarPor.SelectedIndex.ToString(), txtBoxTextoBusqueda.Text.Trim(), NumeroAgencia, NumeroTransaccion, dateTimePicker1.Value, dateTimePicker2.Value, checkTextoIdentico.Checked, CodigoEstadoTransaccion);
                            bdSourceTransacciones.DataSource = _DTListadoTransaccion;
                            break;
                        }
                    case 'C':
                        {
                            _DTListadoTransaccion = OperacionesTransacciones.BuscarComprasProductos(cBoxBuscarPor.SelectedIndex.ToString(), txtBoxTextoBusqueda.Text.Trim(), NumeroAgencia, NumeroTransaccion, dateTimePicker1.Value, dateTimePicker2.Value, checkTextoIdentico.Checked, CodigoEstadoTransaccion);
                            bdSourceTransacciones.DataSource = _DTListadoTransaccion;
                            break;
                        }
                    case 'D':
                        {
                            _DTListadoTransaccion = OperacionesTransacciones.BuscarVentasDevolucionesProductos(cBoxBuscarPor.SelectedIndex.ToString(), txtBoxTextoBusqueda.Text.Trim(), NumeroAgencia, NumeroTransaccion, dateTimePicker1.Value, dateTimePicker2.Value, checkTextoIdentico.Checked, CodigoEstadoTransaccion);
                            bdSourceTransacciones.DataSource = _DTListadoTransaccion;
                            break;
                        }
                    case 'P':
                        {
                            _DTListadoTransaccion = OperacionesTransacciones.BuscarComprasDevolucionesProductos(cBoxBuscarPor.SelectedIndex.ToString(), txtBoxTextoBusqueda.Text.Trim(), NumeroAgencia, NumeroTransaccion, dateTimePicker1.Value, dateTimePicker2.Value, checkTextoIdentico.Checked, CodigoEstadoTransaccion);
                            bdSourceTransacciones.DataSource = _DTListadoTransaccion;
                            break;
                        }
                    case 'F':
                        {
                            _DTListadoTransaccion = OperacionesTransacciones.BuscarTransferenciasProductos(cBoxBuscarPor.SelectedIndex.ToString(), txtBoxTextoBusqueda.Text.Trim(), NumeroAgencia, NumeroTransaccion, dateTimePicker1.Value, dateTimePicker2.Value, checkTextoIdentico.Checked, CodigoEstadoTransaccion);
                            bdSourceTransacciones.DataSource = _DTListadoTransaccion;
                            break;
                        }
                    default:
                        break;
                }
                if (_DTListadoTransaccion.Rows.Count == 0)
                    _DTListadoTransaccion.Rows.Clear();
                statusStrip1.Items[0].Text = "Numero de registros encontrados: " + bdSourceTransacciones.Count.ToString();
                if (txtBoxNumeroTransaccion.Focused)
                    txtBoxNumeroTransaccion.SelectAll();
                else if (txtBoxTextoBusqueda.Focused)
                    txtBoxTextoBusqueda.SelectAll();
            }
        }

        private void FBuscarTransaccion_Load(object sender, EventArgs e)
        {
            dtGVTransacciones.Columns[0].Width = 105;
            dtGVTransacciones.Columns[0].HeaderText = "Nro Agencia";
            

            dtGVTransacciones.Columns[1].Width = 105;
            switch (TipoTransaccion)
            {
                case 'V':
                    dtGVTransacciones.Columns[1].HeaderText = "Nro Venta";
                    dtGVTransacciones.Columns[3].HeaderText = "Cliente";
                    break;
                case 'S':
                    dtGVTransacciones.Columns[1].HeaderText = "Nro Venta Serv";
                    dtGVTransacciones.Columns[3].HeaderText = "Cliente";
                    break;
                case 'C':
                    dtGVTransacciones.Columns[1].HeaderText = "Nro Compra";
                    dtGVTransacciones.Columns[3].HeaderText = "Proveedor";
                    break;
                case 'T':
                    dtGVTransacciones.Columns[1].HeaderText = "Nro Cotización";
                    dtGVTransacciones.Columns[3].HeaderText = "Cliente";
                    break;
                case 'D':
                    dtGVTransacciones.Columns[1].HeaderText = "Nro Devolución";
                    dtGVTransacciones.Columns[3].HeaderText = "Cliente";
                    break;
                case 'P':
                    dtGVTransacciones.Columns[1].HeaderText = "Nro Devolución";
                    dtGVTransacciones.Columns[3].HeaderText = "Proveedor";
                    break;
                case 'F':
                    dtGVTransacciones.Columns[1].HeaderText = "Nro Transferencia";
                    dtGVTransacciones.Columns[3].HeaderText = "Agencia Receptora";
                    break;
                default: 
                    break;                    
            }


            dtGVTransacciones.Columns[2].Width = 100;
            dtGVTransacciones.Columns[2].HeaderText = "Fecha";
            
            dtGVTransacciones.Columns[3].Width = 300;

            //dtGVTransacciones.Columns[4].Width = 300;
            //dtGVTransacciones.Columns[4].HeaderText = "Producto";

        }

        private void txtBoxTextoBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e as EventArgs);
            }
        }

        private void txtBoxNumeroTransaccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & (Keys)e.KeyChar != Keys.Enter)
            {
                e.Handled = true;
                txtBoxNumeroTransaccion.SelectionStart = 0;
                txtBoxNumeroTransaccion.SelectionLength = txtBoxNumeroTransaccion.Text.Length;
                return;
            }
        }

        private void ocultarColumnaNumeroAgenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dtGVTransacciones.Columns[0].Visible = !dtGVTransacciones.Columns[0].Visible;
        }

        private void ocultarNumeroTransacciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dtGVTransacciones.Columns[1].Visible = !dtGVTransacciones.Columns[1].Visible;
        }

        private void ocultarFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dtGVTransacciones.Columns[2].Visible = !dtGVTransacciones.Columns[2].Visible;
        }

        private void ocultarColumnaNombreProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //dtGVTransacciones.Columns[4].Visible = !dtGVTransacciones.Columns[4].Visible;
        }

    }
}
