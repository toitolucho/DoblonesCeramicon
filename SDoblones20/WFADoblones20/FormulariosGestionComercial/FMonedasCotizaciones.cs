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
    public partial class FMonedasCotizaciones : Form
    {
        private MonedasCLN Monedas = new MonedasCLN();
        private MonedasCotizacionesCLN MonedasCotizaciones = new MonedasCotizacionesCLN();
        private DataTable RBMonedasCotizaciones = new DataTable();

        public FMonedasCotizaciones(bool PermitirInsertar, bool PermitirEditar, bool PermitirEliminar, bool PermitirNavegar)
        {
            InitializeComponent();

            this.bNuevo.Visible = PermitirInsertar;
            this.bEditar.Visible = PermitirEditar;
            this.bEliminar.Visible = PermitirEliminar;
            this.dGVCotizacionesMonedas.Visible = PermitirNavegar;
        }

        private void CargarMonedas()
        {
            DataTable DTMonedas = new DataTable();
            DTMonedas = Monedas.ListarMonedas();
            cBMoneda.DataSource = DTMonedas.DefaultView;
            cBMoneda.DisplayMember = "NombreMoneda";
            cBMoneda.ValueMember = "CodigoMoneda";
        }

        private void CargarMonedasCotizacion()
        {
            DataTable DTMonedasCotizacion = new DataTable();
            DTMonedasCotizacion = Monedas.ListarMonedas();
            cBMonedaCotizacion.DataSource = DTMonedasCotizacion.DefaultView;
            cBMonedaCotizacion.DisplayMember = "NombreMoneda";
            cBMonedaCotizacion.ValueMember = "CodigoMoneda";
            cBMonedaCotizacion.SelectedIndex = 1;
        }

        private void bMostrar_Click(object sender, EventArgs e)
        {
            RBMonedasCotizaciones = MonedasCotizaciones.ListarMonedasCotizacionesPorMoneda(byte.Parse(cBMoneda.SelectedValue.ToString()), byte.Parse(cBMonedaCotizacion.SelectedValue.ToString()), dTPFechaCotizacionInicio.Value, dTPFechaCotizacionFin.Value);
            bSCotizacionesMonedas.DataSource = RBMonedasCotizaciones;
            dGVCotizacionesMonedas.AutoGenerateColumns = false;
        }

        private void FMonedasCotizaciones_Load(object sender, EventArgs e)
        {
            CargarMonedas();
            CargarMonedasCotizacion();
        }

        private void bCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bNuevo_Click(object sender, EventArgs e)
        {
            FMonedasCotizacionesIA fmonedascotizacionesia = new FMonedasCotizacionesIA("I", byte.Parse(cBMoneda.SelectedValue.ToString()), byte.Parse(cBMonedaCotizacion.SelectedValue.ToString()), System.DateTime.Now, 0, 0);
            fmonedascotizacionesia.ShowDialog();
        }

        private void bEditar_Click(object sender, EventArgs e)
        {
            int fila = 0;
            fila = dGVCotizacionesMonedas.CurrentCell.RowIndex;
            if (fila >= 0)
            {
                FMonedasCotizacionesIA fmonedascotizacionesia = new FMonedasCotizacionesIA("E", byte.Parse(RBMonedasCotizaciones.Rows[fila][0].ToString()), byte.Parse(RBMonedasCotizaciones.Rows[fila][2].ToString()), DateTime.Parse(RBMonedasCotizaciones.Rows[fila][1].ToString()), decimal.Parse(RBMonedasCotizaciones.Rows[fila][4].ToString()), decimal.Parse(RBMonedasCotizaciones.Rows[fila][5].ToString()));
                fmonedascotizacionesia.ShowDialog();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna elemento para editarlo");
            }
            bMostrar_Click(bMostrar, e);
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
                int fila = 0;
                fila = dGVCotizacionesMonedas.CurrentCell.RowIndex;
                MonedasCotizaciones.EliminarMonedaCotizacion(byte.Parse(RBMonedasCotizaciones.Rows[fila][0].ToString()), DateTime.Parse(RBMonedasCotizaciones.Rows[fila][2].ToString()), byte.Parse(RBMonedasCotizaciones.Rows[fila][1].ToString()));
                bNuevo.Enabled = true;
                bEditar.Enabled = false;
                bEliminar.Enabled = false;
            }
        }

        private void dGVCotizacionesMonedas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
