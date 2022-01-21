using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.Contabilidad;

namespace WFADoblones20.FormulariosContabilidad
{
    public partial class FInicioGestion : Form
    {
        public FInicioGestion()
        {
            InitializeComponent();
        }

        private void FInicioGestion_Load(object sender, EventArgs e)
        {
            CargarPlanCuentas();
        }

        private void CargarPlanCuentas()
        {
            PlanCuentasCLN cuentas = new PlanCuentasCLN();
            DataTable dt = new DataTable();
            dt = cuentas.ListarPlanCuentasSimpleAPC();
            dgvDetalleAsiento.DataSource = dt.DefaultView;
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            Registrar();
        }

        private void Registrar()
        {
            AsientosCLN Asientos = new AsientosCLN();
            int UltimoNumeroAsiento = Asientos.ObtenerUltimoNumeroAsiento();
            UltimoNumeroAsiento++;

            AsientosDetalleCLN DetalleAsiento = new AsientosDetalleCLN();
            FEstadoAsiento fea = new FEstadoAsiento();
            string EstadoAsiento = string.Empty;

            Asientos.InsertarAsientos(0, DateTime.Today.ToShortDateString(), DateTime.Now.ToLongTimeString(), tbGlosa.Text, "Confirmado");

            int aux = dgvDetalleAsiento.RowCount - 1;
            decimal debeAux, haberAux;

            for (int i = 0; i < aux; i++)
            {

                if (dgvDetalleAsiento.Rows[i].Cells[0].Value == null)
                    debeAux = 0;
                else
                    debeAux = decimal.Parse(dgvDetalleAsiento.Rows[i].Cells[0].Value.ToString());

                if (dgvDetalleAsiento.Rows[i].Cells[1].Value == null)
                    haberAux = 0;
                else
                    haberAux = decimal.Parse(dgvDetalleAsiento.Rows[i].Cells[1].Value.ToString());


                DetalleAsiento.InsertarDetalleAsiento(UltimoNumeroAsiento, dgvDetalleAsiento.Rows[i].Cells[2].Value.ToString(), debeAux, haberAux);
            }

            MessageBox.Show("Se realizo el registro de manera existosa.", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dgvDetalleAsiento_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1)
            {
                if (dgvDetalleAsiento.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    decimal MontoDecimal;
                    if (decimal.TryParse(dgvDetalleAsiento.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out MontoDecimal))
                    {
                        dgvDetalleAsiento.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = MontoDecimal.ToString("F2");
                        CalcularTotales();
                    }
                    else
                    {
                        MessageBox.Show("El tipo de dato no es valido, revise si el monto es correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dgvDetalleAsiento.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0,00";
                    }
                }
            }
        }

        private void CalcularTotales()
        {
            decimal sumaDebe = 0, sumaHaber = 0;

            int aux = dgvDetalleAsiento.RowCount - 1;

            for (int i = 0; i < aux; i++)
            {
                if (dgvDetalleAsiento.Rows[i].Cells[0].Value != null)
                    sumaDebe += decimal.Parse(dgvDetalleAsiento.Rows[i].Cells[0].Value.ToString());
                if (dgvDetalleAsiento.Rows[i].Cells[1].Value != null)
                    sumaHaber += decimal.Parse(dgvDetalleAsiento.Rows[i].Cells[1].Value.ToString());
            }

            tbTotalDebe.Text = sumaDebe.ToString();
            tbTotalHaber.Text = sumaHaber.ToString();

        }

        private void FInicioGestion_SizeChanged(object sender, EventArgs e)
        {
            AjustarGrilla();
        }

        public void AjustarGrilla()
        {
            dgvcNumeroCuenta.Width = 120;
            dgvcNombreCuenta.Width = dgvDetalleAsiento.Width - 196;
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
