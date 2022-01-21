using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.Sistema;
using CLCLN.Contabilidad;
using CLCLN.GestionComercial;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FProductosEmpresasLista : Form
    {
        private bool permiso0, permiso1, permiso2, permiso3, permiso4;
        private string NombreProvedor;

        public FProductosEmpresasLista(bool p0, bool p1, bool p2, bool p3, bool p4)
        {
            InitializeComponent();
            permiso0 = p0;
            permiso1 = p1;
            permiso2 = p2;
            permiso3 = p3;
            permiso4 = p4;
        }

        private void FProductosEmpresasLista_Load(object sender, EventArgs e)
        {
            CargarComboBoxes();
        }

        private void CargarComboBoxes()
        {
            ProductosEmpresasListaCLN proveedores = new ProductosEmpresasListaCLN();
            DataTable dt = new DataTable();

            dt = proveedores.ListarProveedores();

            tscbEmpresas.ComboBox.DataSource = dt.DefaultView;
            tscbEmpresas.ComboBox.DisplayMember = "NombreRazonSocial";
            tscbEmpresas.ComboBox.ValueMember = "CodigoProveedor";
        }

        private void tsbtImportar_Click(object sender, EventArgs e)
        {
            ImportarHojaExcel();
        }

        private void ImportarHojaExcel()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            
            ofd.Multiselect = false;
            ofd.RestoreDirectory = true;
            ofd.Filter = "Todos los documentos de Excel|*.xls;*.xlsx|Documentos de Excel 2003, XP|*.xls|Documentos de Excel 2007|*xlsx";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                new FProductosEmpresasListaRegistrar(ofd.FileName).ShowDialog();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MostrarLista();
        }

        private void MostrarLista()
        {
            if (tscbEmpresas.SelectedIndex > -1)
            {
                ProductosEmpresasListaCLN productoslista = new ProductosEmpresasListaCLN();
                int codproveedor = int.Parse(tscbEmpresas.ComboBox.SelectedValue.ToString());

                NombreProvedor = tscbEmpresas.ComboBox.SelectedItem.ToString();

                dgvProductosEmpresasLista.DataSource = null;
                dgvProductosEmpresasLista.DataSource = productoslista.ListarProductosEmpresasListaProveedor(codproveedor);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tscbEmpresas.Focus();
                tscbEmpresas.SelectAll();
            }
        }

        private void dgvProductosEmpresasLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MostrarListaDetalle();
        }

        private void MostrarListaDetalle()
        {
            if (dgvProductosEmpresasLista.SelectedRows.Count > 0)
            {
                ProductosEmpresasListaDetalleCLN listadetalle = new ProductosEmpresasListaDetalleCLN();
                //int numerolista = int.Parse(dgvProductosEmpresasLista.SelectedRows[0].Cells[0].Value.ToString()); NumeroLista
                int numerolista = int.Parse((dgvProductosEmpresasLista.DataSource as DataTable).Rows[dgvProductosEmpresasLista.CurrentRow.Index]["NumeroLista"].ToString());

                lbListaDetalleInfo.Text += "   Proveedor: " + NombreProvedor + "   Fecha: " + dgvProductosEmpresasLista.SelectedRows[0].Cells[3].Value.ToString();

                dgvProductosEmpresasListaDetalle.DataSource = null;
                dgvProductosEmpresasListaDetalle.DataSource = listadetalle.ListarProductosEmpresasListaDetalleNumeroLista(numerolista);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento para ver su detalle.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dgvProductosEmpresasLista.Focus();
            }
        }

        private void btMostrarDetalle_Click(object sender, EventArgs e)
        {
            MostrarListaDetalle();
        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Limpiar toda la tabla?.", "Limpiar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dgvProductosEmpresasLista.DataSource = null;                
            }
        }

        private void btImprimirListaDetalle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Limpiar toda la tabla?.", "Limpiar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lbListaDetalleInfo.Text = "Información";
                dgvProductosEmpresasListaDetalle.DataSource = null;
            }
        }
    }
}
