using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.Contabilidad;
using CLCLN.Sistema;
using WFADoblones20.FormulariosContabilidad;

namespace WFADoblones20.FormulariosContabilidad
{
    public partial class FMonedasFracciones : Form
    {
        public FMonedasFracciones()
        {
            InitializeComponent();
        }

        private void FMonedasFracciones_Load(object sender, EventArgs e)
        {
            CargarComboBoxes();
        }

        private void CargarComboBoxes()
        {
            MonedasCLN monedas = new MonedasCLN();
            DataTable dt = new DataTable();

            dt = monedas.ListarMonedas();

            cbMonedas.DataSource = dt.DefaultView;
            cbMonedas.ValueMember = "CodigoMoneda";
            cbMonedas.DisplayMember = "NombreMoneda";

            if (cbMonedas.Items.Count > 0)
                cbMonedas.SelectedIndex = 0;
        }

        private void cbMonedas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMonedas.SelectedIndex > -1)
                CargarMonedasFracciones();
        }

        private void CargarMonedasFracciones()
        {
            MonedasFraccionesCLN fraccion = new MonedasFraccionesCLN();
            DataTable dt = new DataTable();

            int n;
            if (int.TryParse(cbMonedas.SelectedValue.ToString(), out n))
            {
                dt = fraccion.ListarMonedasFracciones(n.ToString());
                dgvMonedasFracciones.DataSource = dt;
            }
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void Eliminar()
        {
            if (dgvMonedasFracciones.SelectedCells.Count == 1)
            {
                if (MessageBox.Show("¿Desea eliminar el registro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MonedasFraccionesCLN mf = new MonedasFraccionesCLN();
                    int i = dgvMonedasFracciones.SelectedCells[0].RowIndex;
                    mf.Eliminar(dgvMonedasFracciones.Rows[i].Cells["dgvcCodigoMonedaFraccion"].Value.ToString());
                    MessageBox.Show("Se ha eliminado el registro de manera exitosa", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarMonedasFracciones();
                }
            }
        }

        private void btNueva_Click(object sender, EventArgs e)
        {
            Nueva();
        }

        private void Nueva()
        {
            if (cbMonedas.SelectedIndex > -1)
            {
                FMonedasFraccionesNueva fmfn = new FMonedasFraccionesNueva(cbMonedas.SelectedValue.ToString());

                if (fmfn.ShowDialog() == DialogResult.OK)
                {
                    CargarMonedasFracciones();
                }
            }
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            if (dgvMonedasFracciones.SelectedCells.Count == 1)
                Modificar();
        }

        private void Modificar()
        {
            int i = dgvMonedasFracciones.SelectedCells[0].RowIndex;
            FMonedasFraccionesNueva fmfn = new FMonedasFraccionesNueva(dgvMonedasFracciones.Rows[i].Cells["dgvcCodigoMoneda"].Value.ToString(), dgvMonedasFracciones.Rows[i].Cells["dgvcCodigoMonedaFraccion"].Value.ToString(), dgvMonedasFracciones.Rows[i].Cells["dgvcValor"].Value.ToString());

            if (fmfn.ShowDialog() == DialogResult.OK)
            {
                CargarMonedasFracciones();
            }
        }

        private void dgvMonedasFracciones_DoubleClick(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        



    }
}
