using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.GestionComercial;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FProductosUnidades : Form
    {
        private ProductosUnidadesCLN ProductosUnidades = new ProductosUnidadesCLN();
        private string TipoOperacion = "";
        private DataTable DTAuxiliar = new DataTable();
        public decimal? CodigoUnidadActual = 0m;

        public FProductosUnidades()
        {
            InitializeComponent();
            tBCodigo.ReadOnly = true;
        }

        private void bCerrar_Click(object sender, EventArgs e)
        {
            if (tBCodigo.Text.Length > 0)
            {
                CodigoUnidadActual = int.Parse(tBCodigo.Text);
            }
            this.Close();
        }

        private void InhabilitarControles(bool Estado)
        {
            //tBCodigo.ReadOnly = Estado;
            tBNombre.ReadOnly = Estado;
            
        }

        private void InicializarControles()
        {
            tBCodigo.Text = "";
            tBNombre.Text = "";
            
        }

        private void bNuevo_Click(object sender, EventArgs e)
        {
            TipoOperacion = "I";
            
            InhabilitarControles(false);
            InicializarControles();
            bNuevo.Enabled = false;
            bEditar.Enabled = false;
            bEliminar.Enabled = false;
            bAceptar.Enabled = true;
            bCancelar.Enabled = true;
            tBNombre.Focus();
        }

        private void bEditar_Click(object sender, EventArgs e)
        {
            if (tBCodigo.Text.Length <= 0)
            {
                MessageBox.Show("No se puede editar puesto que no eligió ningún registro para hacerlo");
                bNuevo.Focus();
                return;
            }
            TipoOperacion = "E";
            InhabilitarControles(false);
            bNuevo.Enabled = false;
            bEditar.Enabled = false;
            bEliminar.Enabled = false;
            bAceptar.Enabled = true;
            bCancelar.Enabled = true;
         
        }

        private void bEliminar_Click(object sender, EventArgs e)
        {
            if (tBCodigo.Text.Length <= 0)
            {
                MessageBox.Show("No se puede eliminar puesto que no eligió ningún registro para hacerlo");
                bNuevo.Focus();
                return;
            }
            string Mensaje = "Esta seguro que desea eliminar el registro actual?, recuerde que una vez aceptada la operación es irreversible.";
            string Titulo = "Confimarción eliminación registro";
            MessageBoxButtons Botones = MessageBoxButtons.YesNo;
            MessageBoxIcon Icono = MessageBoxIcon.Exclamation;
            DialogResult result;

            result = MessageBox.Show(Mensaje, Titulo, Botones, Icono);

            if (result == DialogResult.Yes)
            {
                if (tBCodigo.Text == "")
                {
                    MessageBox.Show("No se ha seleccionado ningun registro para eliminar");

                }
                else
                {
                    ProductosUnidades.EliminarProductoUnidad(int.Parse(tBCodigo.Text));
                    DTAuxiliar = ProductosUnidades.ListarProductosUnidades();
                    bSOrigen.DataSource = DTAuxiliar;
                }
                InhabilitarControles(true);
                InicializarControles();
                bNuevo.Enabled = true;
                bEditar.Enabled = true;
                bEliminar.Enabled = true;
                bAceptar.Enabled = false;
                bCancelar.Enabled = false;
                
            }
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            if (tBNombre.Text.Length <= 0)
            {
                MessageBox.Show("Debe introducir un Nombre para completar la operación de registro");
                tBNombre.Focus();
                return;
            }
            
            if (TipoOperacion == "I")
            {
                ProductosUnidades.InsertarProductoUnidad(tBNombre.Text, ref CodigoUnidadActual);
                tBCodigo.Text = CodigoUnidadActual.ToString(); 
            }

            if (TipoOperacion == "E")
            {
                
                if (tBCodigo.Text == "")
                {
                    MessageBox.Show("No se ha seleccionado ningún registro para editar");

                }
                else
                {
                    ProductosUnidades.ActualizarProductoUnidad(int.Parse(tBCodigo.Text), tBNombre.Text);
                }
            }
            DTAuxiliar = ProductosUnidades.ListarProductosUnidades();
            bSOrigen.DataSource = DTAuxiliar;
            InhabilitarControles(true);
            //InicializarControles();
            bNuevo.Enabled = true;
            bEditar.Enabled = true;
            bEliminar.Enabled = true;
            bAceptar.Enabled = false;
            bCancelar.Enabled = false;
            
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            
            InicializarControles();
            InhabilitarControles(true);
            bNuevo.Enabled = true;
            bEditar.Enabled = true;
            bEliminar.Enabled = true;
            bAceptar.Enabled = false;
            bCancelar.Enabled = false;
           
        }

        private void dGVGrilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = 0;
            fila = dGVGrilla.CurrentCell.RowIndex;
            if (fila >= 0)
            {
                tBCodigo.Text = DTAuxiliar.Rows[fila][0].ToString();
                tBNombre.Text = DTAuxiliar.Rows[fila][1].ToString();
                //tBDescripcion.Text = DTAuxiliar.Rows[fila][2].ToString();
            }
            else
            {
                MessageBox.Show("No existe ningún registro registro para seleccionarlo");
            }
        }

      
        private void FProductosUnidades_Load(object sender, EventArgs e)
        {
            bAceptar.Enabled = false;
            bCancelar.Enabled = false;
            InhabilitarControles(true);

            DTAuxiliar = ProductosUnidades.ListarProductosUnidades();
            bSOrigen.DataSource = DTAuxiliar;

            //dGVGrilla.DataSource = DTAuxiliar;
            dGVGrilla.AutoGenerateColumns = false;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dGVGrilla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarValoresDeGrillaAControles();
            tabControl1.SelectedIndex = 0;
        }

        private void CargarValoresDeGrillaAControles()
        {
            int fila = 0;
            fila = dGVGrilla.CurrentCell.RowIndex;
            if (fila >= 0)
            {
                tBCodigo.Text = DTAuxiliar.Rows[fila][0].ToString();
                tBNombre.Text = DTAuxiliar.Rows[fila][1].ToString();
                //tBDescripcion.Text = DTAuxiliar.Rows[fila][2].ToString();
            }
            else
            {
                MessageBox.Show("No existe elementos para seleccionar");
                InhabilitarControles(true);
                InicializarControles();
                
            }
        }
    }
}
