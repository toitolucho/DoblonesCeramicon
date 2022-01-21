using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN;
using CLCLN.Contabilidad;

namespace WFADoblones20.FormulariosContabilidad
{
    public partial class FConceptos : Form
    {
        private bool p0, p1, p2, p3, p4;

        public FConceptos(bool P0, bool P1, bool P2, bool P3, bool P4)
        {
            InitializeComponent();

            p0 = P0;
            p1 = P1;
            p2 = P2;
            p3 = P3;
            p4 = P4;

            CargarTabla();
        }

        private void CargarTabla()
        {
            ConceptosCLN conceptos = new ConceptosCLN();
            DataTable dt = conceptos.ListarConceptos();

            dgvConceptos.DataSource = dt;
        }

        private void dgvConceptos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvConceptos.SelectedCells.Count == 1)
            {
                btEliminar.Enabled = true;
                btActualizar.Enabled = true;
            }
            else
            {
                btEliminar.Enabled = false;
                btActualizar.Enabled = false;
            }
        }

        private void FConceptos_Load(object sender, EventArgs e)
        {

        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void Nuevo()
        {
            FConcepto fc = new FConcepto();
            if (fc.ShowDialog() == DialogResult.OK)
            {
                CargarTabla();
            }
        }

        private void Eliminar()
        {
            if (MessageBox.Show("¿Desea eliminar el registro seleccioando?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ConceptosCLN conceptos = new ConceptosCLN();
                int NumConcepto = int.Parse(dgvConceptos.SelectedRows[0].Cells["dgvcNumeroConcepto"].Value.ToString());
                conceptos.EliminarConcepto(NumConcepto);
                CargarTabla();
            }
        }

        private void Actualizar()
        {
            int NumConcepto = int.Parse(dgvConceptos.SelectedRows[0].Cells["dgvcNumeroConcepto"].Value.ToString());
            string NomConcepto = dgvConceptos.SelectedRows[0].Cells["dgvcConcepto"].Value.ToString();
            FConcepto fc = new FConcepto(NumConcepto, NomConcepto);

            if (fc.ShowDialog() == DialogResult.OK)
            {
                CargarTabla();
            }
        }



    }
}

