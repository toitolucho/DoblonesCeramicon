using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.Sistema;
using CLCLN.GestionComercial;
using CLCLN.Contabilidad;
using WFADoblones20.FormulariosContabilidad;
using System.Data.OleDb;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FProductosEmpresasListaRegistrar : Form
    {

        public FProductosEmpresasListaRegistrar()
        {
            InitializeComponent();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.RestoreDirectory = true;
            ofd.Filter = "Todos los documentos de Excel|*.xls;*.xlsx";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                CargarHojaExcel(ofd.FileName);
                CargarComboBoxes();
            }
            else
            {
                this.Close();
            }
        }

        public FProductosEmpresasListaRegistrar(string DireccionArchivo)
        {
            InitializeComponent();
            CargarHojaExcel(DireccionArchivo);
            CargarComboBoxes();
        }

        private void CargarComboBoxes()
        {
            ProveedoresCLN proveedores = new ProveedoresCLN();
            DataTable dt = new DataTable();

            dt = proveedores.ListarProveedores();
            
            cbEmpresas.DataSource = dt.DefaultView;
            cbEmpresas.DisplayMember = "NombreRazonSocial";
            cbEmpresas.ValueMember = "CodigoProveedor";
        }

        private void CargarHojaExcel(string HojaExcel)
        {
            OleDbConnection oledbconexion = new OleDbConnection();
            OleDbCommand oledbcomando = new OleDbCommand();
            OleDbDataAdapter oledbda = new OleDbDataAdapter();
            DataSet dsExcel = new DataSet();

            oledbconexion.ConnectionString = ("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + HojaExcel + ";Extended Properties=\"Excel 12.0;HDR=YES\"");
            oledbconexion.Open();
            oledbcomando.CommandText = "SELECT * FROM [Hoja1$]";
            oledbcomando.Connection = oledbconexion;
            oledbda.SelectCommand = oledbcomando;

            // Llenar el DataSet
            oledbda.Fill(dsExcel);

            //cerrar la conexion
            oledbconexion.Close();

            dgvProductosEmpresasListaDetalle.DataSource = dsExcel.Tables[0];


            //Se llenan los combo boxes
            int n = dgvProductosEmpresasListaDetalle.Columns.Count;
            
            for (int i = 0; i < n; i++)
            {
                cbCodigo.Items.Add(dgvProductosEmpresasListaDetalle.Columns[i].HeaderText);
                cbNombre.Items.Add(dgvProductosEmpresasListaDetalle.Columns[i].HeaderText);
                cbDescripcion.Items.Add(dgvProductosEmpresasListaDetalle.Columns[i].HeaderText);
                cbPrecio.Items.Add(dgvProductosEmpresasListaDetalle.Columns[i].HeaderText);
            }

            cbCodigo.Items.Add("<Vacío>");
            cbNombre.Items.Add("<Vacío>");
            cbDescripcion.Items.Add("<Vacío>");
            cbPrecio.Items.Add("<Vacío>");

            n = cbCodigo.Items.Count;

            if (n > 1)
                cbCodigo.SelectedIndex = 0;
            if (n > 2)
                cbNombre.SelectedIndex = 1;
            if (n > 3)
                cbDescripcion.SelectedIndex = 2;
            if (n > 4)
                cbPrecio.SelectedIndex = 3;

        }

        private void FProductosEmpresasListaRegistrar_Load(object sender, EventArgs e)
        {

        }

        private void btRegistrar_Click(object sender, EventArgs e)
        {
            Registrar();
        }

        private void Registrar()
        {
            if (dgvProductosEmpresasListaDetalle.RowCount > 0)
            {
                if (cbEmpresas.SelectedIndex > -1)
                {
                    if (!ErroresColumnas())
                    {
                        if (!ErroresCodigo())
                        {
                            if (!ErroresPrecio())
                            {
                                ProductosEmpresasListaCLN productoslista = new ProductosEmpresasListaCLN();
                                ProductosEmpresasListaDetalleCLN productoslistadetalle = new ProductosEmpresasListaDetalleCLN();

                                productoslista.InsertarProductosEmpresasLista(int.Parse(cbEmpresas.SelectedValue.ToString()), tbDescripcion.Text, dtpFecha.Value);

                                int n = dgvProductosEmpresasListaDetalle.RowCount;
                                int numerolista = productoslista.UltimoNumeroLista();

                                int indiceCodigo, indiceNombre, indiceDescripcion, indicePrecio;

                                indiceCodigo = cbCodigo.SelectedIndex;
                                indiceNombre = cbNombre.SelectedIndex;
                                if (cbDescripcion.SelectedItem.ToString() == "<Vacío>" || cbDescripcion.SelectedIndex < 0)
                                    indiceDescripcion = -1;
                                else
                                    indiceDescripcion = cbDescripcion.SelectedIndex;
                                indicePrecio = cbPrecio.SelectedIndex;

                                string codigoproducto = string.Empty;
                                string nombreproducto = string.Empty;
                                string descripcionproducto = string.Empty;
                                decimal precioproducto = 0;

                                for (int i = 0; i < n; i++)
                                {
                                    codigoproducto = dgvProductosEmpresasListaDetalle.Rows[i].Cells[indiceCodigo].Value.ToString();
                                    nombreproducto = dgvProductosEmpresasListaDetalle.Rows[i].Cells[indiceNombre].Value.ToString();
                                    if (indiceDescripcion > -1)
                                    {
                                        if (dgvProductosEmpresasListaDetalle.Rows[i].Cells[indiceDescripcion].Value != null)
                                            descripcionproducto = dgvProductosEmpresasListaDetalle.Rows[i].Cells[indiceDescripcion].Value.ToString();
                                        else
                                            descripcionproducto = string.Empty;
                                    }
                                    precioproducto = decimal.Parse(dgvProductosEmpresasListaDetalle.Rows[i].Cells[indicePrecio].Value.ToString());
                                    precioproducto = decimal.Parse(precioproducto.ToString("F2"));

                                    productoslistadetalle.InsertarProductosEmpresasListaDetalle(numerolista, codigoproducto, nombreproducto, descripcionproducto, precioproducto);
                                }

                                MessageBox.Show("Registro reailizado exitosamente.", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                if (chbImprimir.Checked)
                                {
                                    new FReporteProductosEmpresasListaDetalle(numerolista).ShowDialog();
                                }

                                this.Close();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbEmpresas.Focus();
                    cbEmpresas.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("La tabla está vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool ErroresColumnas()
        {
            bool respuesta = false;
            List<int> IndicesComboBoxes = new List<int>();
            int n = cbCodigo.Items.Count - 1;

            //Comprobamos q los campos principales no esten vacios
            if (cbCodigo.SelectedIndex == n)
            {
                MessageBox.Show("No se puede asignar una columna vacía al campo Código.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbCodigo.Focus();
                cbCodigo.SelectAll();
                respuesta = true;
            }
            else if (cbNombre.SelectedIndex == n)
            {
                MessageBox.Show("No se puede asignar una columna vacía al campo Nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbNombre.Focus();
                cbNombre.SelectAll();
                respuesta = true;
            }
            else if (cbPrecio.SelectedIndex == n)
            {
                MessageBox.Show("No se puede asignar una columna vacía al campo Precio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbPrecio.Focus();
                cbPrecio.SelectAll();
                respuesta = true;
            }
            else
            {
                //Comprobamos que no existan duplicados de asigancion de columnas

                if (!IndicesComboBoxes.Contains(cbCodigo.SelectedIndex))
                    IndicesComboBoxes.Add(cbCodigo.SelectedIndex);
                else
                {
                    MessageBox.Show("Existe duplicidad en la asiganción del campo Código.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbCodigo.Focus();
                    cbCodigo.SelectAll();
                    respuesta = true;
                }

                if (!IndicesComboBoxes.Contains(cbNombre.SelectedIndex))
                    IndicesComboBoxes.Add(cbNombre.SelectedIndex);
                else
                {
                    MessageBox.Show("Existe duplicidad en la asiganción del campo Nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbNombre.Focus();
                    cbNombre.SelectAll();
                    respuesta = true;
                }

                if (!IndicesComboBoxes.Contains(cbPrecio.SelectedIndex))
                    IndicesComboBoxes.Add(cbPrecio.SelectedIndex);
                else
                {
                    MessageBox.Show("Existe duplicidad en la asiganción del campo Precio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbPrecio.Focus();
                    cbPrecio.SelectAll();
                    respuesta = true;
                }
            }


            return respuesta;
        }

        private bool ErroresCodigo()
        {
            List<string> codigos = new List<string>();
            bool respuesta = false;
            string aux = string.Empty;
            int indice = cbCodigo.SelectedIndex;

            int n = dgvProductosEmpresasListaDetalle.RowCount;

            for (int i = 0; i < n; i++)
            {
                aux = dgvProductosEmpresasListaDetalle.Rows[i].Cells[indice].Value.ToString();

                if (!codigos.Contains(aux))
                    codigos.Add(aux);
                else
                {
                    MessageBox.Show("Existe duplicidad en la columna Código.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dgvProductosEmpresasListaDetalle.Rows[i].Cells[indice].Selected = true;
                    respuesta = true;
                    break;
                }
            }

            return respuesta;
        }

        private bool ErroresPrecio()
        {
            bool respuesta = false;

            int n = dgvProductosEmpresasListaDetalle.RowCount;
            int indice = cbPrecio.SelectedIndex;
            decimal precio = 0;

            for (int i = 0; i < n; i++)
            {
                try
                {
                    precio = decimal.Parse(dgvProductosEmpresasListaDetalle.Rows[i].Cells[indice].Value.ToString());
                }
                catch
                {
                    MessageBox.Show("Un elemento de la columna Precio no tiene el formato correcto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dgvProductosEmpresasListaDetalle.Rows[i].Cells[indice].Selected = true;
                    respuesta = true;
                    break;
                }                
            }

            return respuesta;
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}