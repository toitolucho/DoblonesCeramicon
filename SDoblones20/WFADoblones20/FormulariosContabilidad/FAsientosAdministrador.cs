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
    public partial class FAsientosAdministrador : Form
    {
        private int CodigoUsuario;
        private bool p0, p1, p2, p3, p4;

        public FAsientosAdministrador(int CodUsuario, bool P0, bool P1, bool P2, bool P3, bool P4)
        {
            InitializeComponent();

            CodigoUsuario = CodUsuario;
            p0 = P0;
            p1 = P1;
            p2 = P2;
            p3 = P3;
            p4 = P4;
        }

        private void chbAl_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAl.Checked)
            {
                dtpAl.Enabled = true;
            }
            else
            {
                dtpAl.Enabled = false;
            }
        }

        private void FAsientosAdministrador_Load(object sender, EventArgs e)
        {
            cbEstado.SelectedIndex = 2;
            btEliminar.Enabled = false;
            btModificar.Enabled = false;
            btVer.Enabled = false;

            AsientosCLN asiento = new AsientosCLN();
            FuncionesContabilidad funcion = new FuncionesContabilidad();
            dgvAsientos.DataSource = asiento.ListarAsientosFechaEstado(DateTime.Parse(funcion.FechaHora()), "Pendiente");

        }

        private void btNuevo_Enter(object sender, EventArgs e)
        {
            tslbHint.Text = "Registra un nuevo asiento";
        }

        private void btEliminar_Enter(object sender, EventArgs e)
        {
            tslbHint.Text = "Elimina el asiento seleccionado";
        }

        private void btModificar_Enter(object sender, EventArgs e)
        {
            tslbHint.Text = "Modifica un asiento seleccionado";
        }

        private void btVer_Enter(object sender, EventArgs e)
        {
            tslbHint.Text = "Mustra el detalle del asiento seleccionado";
        }

        private void tbBuscar_Enter(object sender, EventArgs e)
        {
            tslbHint.Text = "Busca un asiento por Número, Nombre de Cuenta o Glosa";
        }

        private void cbEstado_Enter(object sender, EventArgs e)
        {
            tslbHint.Text = "Selecciona el estado de los asientos";
        }

        private void btBuscar_Enter(object sender, EventArgs e)
        {
            tslbHint.Text = "Realiza una búsqueda con los criterios dados";
        }

        private void dgvAsientos_Enter(object sender, EventArgs e)
        {
            tslbHint.Text = "Doble clic para Modificar o Ver un asiento";
        }

        private void dgvAsientos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAsientos.SelectedRows.Count == 1)
            {
                if (dgvAsientos.SelectedRows[0].Cells["dgvcEstado"].Value.ToString() == "Confirmado")
                {
                    btEliminar.Enabled = false;
                    btModificar.Enabled = false;
                    btVer.Enabled = true;
                }
                else if (dgvAsientos.SelectedRows[0].Cells["dgvcEstado"].Value.ToString() == "Pendiente")
                {
                    btEliminar.Enabled = true;
                    btModificar.Enabled = true;
                    btVer.Enabled = true;
                }
            }
            else
            {
                btEliminar.Enabled = false;
                btModificar.Enabled = false;
                btVer.Enabled = false;
            }
        }

        private void dgvAsientos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvAsientos.SelectedRows.Count == 1)
            {
                if (dgvAsientos.SelectedRows[0].Cells["dgvcEstado"].Value.ToString() == "Confirmado")
                {
                    btEliminar.Enabled = false;
                    btModificar.Enabled = false;
                    btVer.Enabled = true;
                }
                else if (dgvAsientos.SelectedRows[0].Cells["dgvcEstado"].Value.ToString() == "Pendiente")
                {
                    btEliminar.Enabled = true;
                    btModificar.Enabled = true;
                    btVer.Enabled = true;
                }
            }
            else
            {
                btEliminar.Enabled = false;
                btModificar.Enabled = false;
                btVer.Enabled = false;
            }
        }

        private void Nuevo()
        {
            FAsientosDetalle fad = new FAsientosDetalle(CodigoUsuario, p0, p1, p2, p3, p4);
            if (fad.ShowDialog() == DialogResult.OK)
            {
                Actualizar();
            }
            
        }

        private void Eliminar()
        {
            if (MessageBox.Show("¿Desea eliminar el asiento seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int NumeroAsiento = int.Parse(dgvAsientos.SelectedRows[0].Cells["dgvcNumAsiento"].Value.ToString());

                AsientosDetalleCLN DetalleAsiento = new AsientosDetalleCLN();
                DetalleAsiento.EliminarDetalleAsiento(NumeroAsiento);

                AsientosCLN Asientos = new AsientosCLN();
                Asientos.EliminarAsiento(NumeroAsiento);

                MessageBox.Show("Se eliminó el asiento correctamente.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Modificar()
        {
            if (dgvAsientos.SelectedRows[0].Cells["dgvcEstado"].Value.Equals("Pendiente"))
            {
                int NumeroAsiento = int.Parse(dgvAsientos.SelectedRows[0].Cells["dgvcNumAsiento"].Value.ToString());
                string Fecha = dgvAsientos.SelectedRows[0].Cells["dgvcFecha"].Value.ToString();
                string Hora = dgvAsientos.SelectedRows[0].Cells["dgvcHora"].Value.ToString();
                string Glosa = dgvAsientos.SelectedRows[0].Cells["dgvcGlosa"].Value.ToString();

                FAsientosDetalle fdac = new FAsientosDetalle(NumeroAsiento, Fecha, Hora, Glosa, CodigoUsuario,
                                                         p0, p1, p2, p3, p4);
                if (fdac.ShowDialog() == DialogResult.OK)
                {
                    Actualizar();
                }
            }
        }

        private void Ver()
        {
            int NumeroAsiento = int.Parse(dgvAsientos.SelectedRows[0].Cells["dgvcNumAsiento"].Value.ToString());
            string Fecha = dgvAsientos.SelectedRows[0].Cells["dgvcFecha"].Value.ToString();
            string Hora = dgvAsientos.SelectedRows[0].Cells["dgvcHora"].Value.ToString();
            string Glosa = dgvAsientos.SelectedRows[0].Cells["dgvcGlosa"].Value.ToString();
            string Estado = dgvAsientos.SelectedRows[0].Cells["dgvcEstado"].Value.ToString();

            FAsientosDetalle fad = new FAsientosDetalle(Estado, NumeroAsiento, Fecha, Hora, Glosa, p0, p1, p2, p3, p4);
            fad.ShowDialog();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            string criterio;

            try
            {
                if (tbBuscar.Text != string.Empty)
                {
                    criterio = tbBuscar.Text.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries)[0];
                }
                else
                {
                    criterio = string.Empty;
                }

                AsientosCLN asientos = new AsientosCLN();
                DataTable dt = new DataTable();

                if (chbAl.Checked)
                {
                    if (dtpDel.Value < dtpAl.Value)
                    {
                        if (cbEstado.SelectedIndex < 2)
                        {
                            dt = asientos.ListarAsientosBusqueda(criterio, dtpDel.Value, dtpAl.Value, cbEstado.SelectedItem.ToString());
                        }
                        else
                        {
                            dt = asientos.ListarAsientosBusqueda(criterio, dtpDel.Value, dtpAl.Value);
                        }

                        MessageBox.Show("Resultados encontrados: " + dt.Rows.Count.ToString());

                        dgvAsientos.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("La primera fecha no puede ser mayor a la segunda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtpDel.Focus();
                    }
                }
                else
                {
                    if (cbEstado.SelectedIndex < 2)
                    {
                        dt = asientos.ListarAsientosBusqueda(criterio, dtpDel.Value, dtpDel.Value, cbEstado.SelectedItem.ToString());
                    }
                    else
                    {
                        dt = asientos.ListarAsientosBusqueda(criterio, dtpDel.Value, dtpDel.Value);
                    }

                    MessageBox.Show("Resultados encontrados: " + dt.Rows.Count.ToString());

                    dgvAsientos.DataSource = dt;
                }
            }
            catch (IndexOutOfRangeException)
            {
                tbBuscar.Text = string.Empty;
                Buscar();
            }
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void Actualizar()
        {
            Buscar();
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btVer_Click(object sender, EventArgs e)
        {
            Ver();
        }


    }
}
