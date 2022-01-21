using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.Sistema;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FMonedas : Form
    {
        private MonedasCLN Monedas = new MonedasCLN();
        private string TipoOperacion = "";
        private DataTable DTAuxiliar = new DataTable();
        public FMonedas()
        {
            InitializeComponent();
        }

        private void FMonedas_Load(object sender, EventArgs e)
        {
            bAceptar.Enabled = false;
            bCancelar.Enabled = false;
            tBMascara.ReadOnly = true;
            InhabilitarControles(true);

            DTAuxiliar = Monedas.ListarMonedas();
            bSOrigen.DataSource = DTAuxiliar;

            //dGVGrilla.DataSource = DTAuxiliar;
            dGVGrilla.AutoGenerateColumns = false;
        }

        private void bCerrar_Click(object sender, EventArgs e)
        {
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
            tBMascara.Text = "";
            InhabilitarControles(false);
            InicializarControles();
            bNuevo.Enabled = false;
            bEditar.Enabled = false;
            bEliminar.Enabled = false;
            bAceptar.Enabled = true;
            bCancelar.Enabled = true;
            tBMascara.ReadOnly = false;
            tBNombre.Focus();
        }

        private void bEditar_Click(object sender, EventArgs e)
        {
            TipoOperacion = "E";
            InhabilitarControles(false);
            bNuevo.Enabled = false;
            bEditar.Enabled = false;
            bEliminar.Enabled = false;
            bAceptar.Enabled = true;
            bCancelar.Enabled = true;
            tBMascara.ReadOnly = false;
        }

        private void bEliminar_Click(object sender, EventArgs e)
        {
            string Mensaje = "Esta seguro que desea eliminar el registro actual, recuerde que una vez aceptada la operacion es irreversible.";
            string Titulo = "Confimarción eliminación registro";
            MessageBoxButtons Botones = MessageBoxButtons.YesNo;
            MessageBoxIcon Icono = MessageBoxIcon.Exclamation;
            DialogResult result;

            result = MessageBox.Show(Mensaje, Titulo, Botones, Icono);

            if (result == DialogResult.Yes)
            {
                if (tBCodigo.Text == "")
                {
                    MessageBox.Show("No se ha seleccionado ningún elemento para eliminarlo");

                }
                else
                {
                    Monedas.EliminarMoneda(byte.Parse(tBCodigo.Text));
                    DTAuxiliar = Monedas.ListarMonedas();
                    bSOrigen.DataSource = DTAuxiliar;
                }
                InhabilitarControles(true);
                InicializarControles();
                bNuevo.Enabled = true;
                bEditar.Enabled = true;
                bEliminar.Enabled = true;
                bAceptar.Enabled = false;
                bCancelar.Enabled = false;
                tBMascara.ReadOnly = true;
                tBMascara.Text = "";
            }
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            if (TipoOperacion == "I")
            {
                Monedas.InsertarMoneda(tBNombre.Text, tBMascara.Text);
            }

            if (TipoOperacion == "E")
            {
                
                if (tBCodigo.Text == "")
                {
                    MessageBox.Show("No se ha seleccionado ningún elemento para editarlo");

                }
                else
                {
                    Monedas.ActualizarMoneda(byte.Parse(tBCodigo.Text), tBNombre.Text, tBMascara.Text);
                }
            }
            DTAuxiliar = Monedas.ListarMonedas();
            bSOrigen.DataSource = DTAuxiliar;
            InhabilitarControles(true);
            InicializarControles();
            bNuevo.Enabled = true;
            bEditar.Enabled = true;
            bEliminar.Enabled = true;
            bAceptar.Enabled = false;
            bCancelar.Enabled = false;
            tBMascara.ReadOnly = true;
            tBMascara.Text = "";
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            if (TipoOperacion == "I")
                InicializarControles();
            InhabilitarControles(true);
            bNuevo.Enabled = true;
            bEditar.Enabled = true;
            bEliminar.Enabled = true;
            bAceptar.Enabled = false;
            bCancelar.Enabled = false;
            tBMascara.ReadOnly = true;
        }

        private void dGVGrilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = 0;
            fila = dGVGrilla.CurrentCell.RowIndex;
            if (fila >= 0)
            {
                tBCodigo.Text = DTAuxiliar.Rows[fila][0].ToString();
                tBNombre.Text = DTAuxiliar.Rows[fila][1].ToString();
                tBMascara.Text = DTAuxiliar.Rows[fila][2].ToString();
                /*FMonedasCotizacionesIA fmonedascotizacionesia = new FMonedasCotizacionesIA("E", byte.Parse(RBMonedasCotizaciones.Rows[fila][0].ToString()), byte.Parse(RBMonedasCotizaciones.Rows[fila][2].ToString()), DateTime.Parse(RBMonedasCotizaciones.Rows[fila][1].ToString()), decimal.Parse(RBMonedasCotizaciones.Rows[fila][4].ToString()), decimal.Parse(RBMonedasCotizaciones.Rows[fila][5].ToString()));
                fmonedascotizacionesia.ShowDialog();*/
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna elemento para editarlo");
            }
        }

        private void tBNombre_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tBNombre_Validating(object sender, CancelEventArgs e)
        {

        }
    }
}
