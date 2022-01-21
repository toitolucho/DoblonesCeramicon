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
using WFADoblones20.FormulariosContabilidad;

namespace WFADoblones20.FormulariosContabilidad
{
    public partial class FAsientosContables : Form
    {
        private bool permiso0, permiso1, permiso2, permiso3, permiso4;
        private int CodigoUsuario;
        private string FechaBusqueda;
        private string EstadoBusqueda;

        public FAsientosContables()
        {
            InitializeComponent();
        }

        public FAsientosContables(int CodUsuario, bool p0, bool p1, bool p2, bool p3, bool p4)
        {
            InitializeComponent();
            permiso0 = p0;
            permiso1 = p1;
            permiso2 = p2;
            permiso3 = p3;
            permiso4 = p4;
            CodigoUsuario = CodUsuario;
        }

        private void FAsientosContables_Load(object sender, EventArgs e)
        {
            MostrarAsientos("Pendiente");

            btModificar.Enabled = false;
            btVer.Enabled = false;
            btEliminar.Enabled = false;
        }


        private void MostrarAsientos(string Estado)
        {
            AsientosCLN asientos = new AsientosCLN();
            FechaBusqueda = dtpFecha.Value.ToShortDateString();

            if (asientos.ExisteFecha(FechaBusqueda, Estado))
            {
                EstadoBusqueda = Estado;

                if (Estado == "Todos")
                {
                    dgvAsientos.DataSource = asientos.ListarAsientosFecha(DateTime.Parse(FechaBusqueda));
                }
                else
                {
                    dgvAsientos.DataSource = asientos.ListarAsientosFechaEstado(DateTime.Parse(FechaBusqueda), Estado);
                }
            }
            else
            {
                if (FechaBusqueda == DateTime.Today.ToShortDateString() && Estado == "Pendiente")
                    MessageBox.Show("No existen asientos pendientes registrados el día de hoy.", "Sin asientos pendientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("No existen asientos registrados en la fecha y estado seleccionados.", "Fecha inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                dtpFecha.Focus();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            NuevoAsiento();
        }

        private void NuevoAsiento()
        {
            FAsientosDetalle fdac = new FAsientosDetalle(CodigoUsuario, permiso0, permiso1, permiso2, permiso3, permiso4);
            fdac.ShowDialog();
            dgvAsientos.Refresh();
            dgvAsientos.Update();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ModificarAsiento();
        }

        private void ModificarAsiento()
        {
            if (dgvAsientos.SelectedRows.Count == 1)
            {
                if (dgvAsientos.SelectedRows[0].Cells[5].Value.Equals("Confirmado"))
                {
                    MessageBox.Show("No se puede modificar un asiento confirmado. Debe seleccionar un asiento en estado pendiente.", "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (dgvAsientos.SelectedRows[0].Cells[5].Value.Equals("Pendiente"))
                {
                    int NumeroAsiento = (int)dgvAsientos.SelectedRows[0].Cells[0].Value;
                    string Fecha = dgvAsientos.SelectedRows[0].Cells[2].Value.ToString();
                    string Hora = dgvAsientos.SelectedRows[0].Cells[3].Value.ToString();
                    string Glosa = dgvAsientos.SelectedRows[0].Cells[4].Value.ToString();

                    FAsientosDetalle fdac = new FAsientosDetalle(NumeroAsiento, Fecha, Hora, Glosa, CodigoUsuario,
                                                             permiso0, permiso1, permiso2, permiso3, permiso4);
                    if (fdac.ShowDialog() == DialogResult.OK)
                    {
                        if (rbConfirmado.Checked)
                            MostrarAsientos("Confirmado");
                        else if (rbPendiente.Checked)
                            MostrarAsientos("Pendiente");
                        else
                            MostrarAsientos("Todos");
                    }
                }
                else
                    MessageBox.Show("Debe seleccionar un asiento en estado pendiente.", "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un asiento.", "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            EliminarAsiento();
        }

        private void EliminarAsiento()
        {
            if (dgvAsientos.SelectedRows.Count == 1)
            {
                if (dgvAsientos.SelectedRows[0].Cells[5].Value.Equals("Pendiente"))
                {
                    if (MessageBox.Show("¿Desea eliminar el asiento seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int NumeroAsiento = (int)dgvAsientos.SelectedRows[0].Cells[0].Value;

                        AsientosDetalleCLN DetalleAsiento = new AsientosDetalleCLN();
                        DetalleAsiento.EliminarDetalleAsiento(NumeroAsiento);

                        AsientosCLN Asientos = new AsientosCLN();
                        Asientos.EliminarAsiento(NumeroAsiento);

                        MessageBox.Show("Se eliminó el asiento correctamente.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (rbConfirmado.Checked)
                            MostrarAsientos("Confirmado");
                        else if (rbPendiente.Checked)
                            MostrarAsientos("Pendiente");
                        else
                            MostrarAsientos("Todos");
                    }
                }
                else
                    MessageBox.Show("Debe seleccionar un asiento en estado pendiente.", "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un asiento.", "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /*private void dgvAsientos_DoubleClick(object sender, EventArgs e)
        {
            if (dgvAsientos.SelectedRows[0].Cells[4].Value.Equals("Confirmado"))
                VerAsiento();
            else
                ModificarAsiento();
        }*/

        private void asientoSeleccionadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarReporteLibroMayor(true);
        }

        private void MostrarReporteLibroMayor(bool esSimple)
        {
            if (dgvAsientos.RowCount > 0)
            {
                FReporteLibroDiario LibroDiario;

                if (esSimple)
                {
                    LibroDiario = new FReporteLibroDiario(dgvAsientos.SelectedRows[0].Cells[0].Value.ToString());
                    LibroDiario.ShowDialog();
                }
                else
                {
                    if (EstadoBusqueda == "Todos")
                        LibroDiario = new FReporteLibroDiario(FechaBusqueda, FechaBusqueda);
                    else
                        LibroDiario = new FReporteLibroDiario(FechaBusqueda, EstadoBusqueda[0]);
                    LibroDiario.ShowDialog();
                }
            }
            else
                MessageBox.Show("No existe ningún asiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void todosLosAsientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarReporteLibroMayor(false);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            VerAsiento();
        }

        private void VerAsiento()
        {
            if (dgvAsientos.SelectedRows.Count > 0)
            {
                int NumeroAsiento = (int)dgvAsientos.SelectedRows[0].Cells[0].Value;
                string Fecha = dgvAsientos.SelectedRows[0].Cells["dgvcFecha"].Value.ToString();
                string Hora = dgvAsientos.SelectedRows[0].Cells["dgvcHora"].Value.ToString();
                string Glosa = dgvAsientos.SelectedRows[0].Cells["dgvcGlosa"].Value.ToString();

                FAsientosDetalle fdac;

                if (dgvAsientos.SelectedRows[0].Cells["dgvcEstado"].Value.Equals("Confirmado"))
                {
                    //NumeroAsiento = (int)dgvAsientos.SelectedRows[0].Cells[0].Value;

                    fdac = new FAsientosDetalle(NumeroAsiento, Fecha, Hora, Glosa,
                                                            permiso0, permiso1, permiso2, permiso3, permiso4, "Aceptar");
                    fdac.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un asiento.", "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btMostrar_Click(object sender, EventArgs e)
        {
            string aux = string.Empty;

            if (rbConfirmado.Checked)
                aux = "Confirmado";
            else if (rbPendiente.Checked)
                aux = "Pendiente";
            else
                aux = "Todos";
            MostrarAsientos(aux);
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {            
            FAsientosDetalle fad = new FAsientosDetalle(CodigoUsuario, permiso0, permiso1, permiso2, permiso3, permiso4);

            if (fad.ShowDialog() == DialogResult.OK)
            {
                if (rbConfirmado.Checked)
                    MostrarAsientos("Confirmado");
                else if (rbPendiente.Checked)
                    MostrarAsientos("Pendiente");
                else
                    MostrarAsientos("Todos");
            }
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            ModificarAsiento();
        }

        private void btVer_Click(object sender, EventArgs e)
        {
            VerAsiento();
        }

        private void btReporte_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvAsientos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAsientos.SelectedRows.Count == 1)
            {
                btModificar.Enabled = true;
                btVer.Enabled = true;
                btEliminar.Enabled = true;
            }
        }

        private void dgvAsientos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvAsientos.SelectedRows[0].Cells["dgvcEstado"].Value.ToString() == "Pendiente")
            {
                ModificarAsiento();
            }
            else
            {
                VerAsiento();
            }
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {

        }


    }
}

