using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.Contabilidad;
using WFADoblones20.FormulariosContabilidad;

namespace WFADoblones20
{
    public partial class FCajaMovimientos : Form
    {
        private int CodigoUsuario;
        private FuncionesContabilidad _FuncionesContabilidad;
        private int NumeroAgencia;
        private CajaMovimientosCLN CajaMovimientos;
        public FCajaMovimientos(int CodUsuario, int NumeroAgencia)
        {
            InitializeComponent();
            CajaMovimientos = new CajaMovimientosCLN();
            _FuncionesContabilidad = new FuncionesContabilidad();
            CodigoUsuario = CodUsuario;
            this.NumeroAgencia = NumeroAgencia;
            CargarMediosPagos();
        }

        private void IniciarCaja()
        {
            FuncionesContabilidad funciones = new FuncionesContabilidad();
            dtpFecha.Value = DateTime.Parse(funciones.FechaHora());

            FCajaEntradaSalida fces = new FCajaEntradaSalida(CodigoUsuario, lbFechaActual.Text, true);
            if (fces.ShowDialog() == DialogResult.OK)
            {
                btCajaEntrada.Enabled = true;
                btCajaSalida.Enabled = true;
                btIniciarCaja.Enabled = false;
                btnCerrarManejoCaja.Enabled = true;
                Mostrar();
            }

        }

        private void FCajaManejo_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Parse(new FuncionesContabilidad().FechaHora().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0]);

            lbFechaActual.Text = dt.ToLongDateString();

            if (CajaAbierta())
            {
                btIniciarCaja.Enabled = false;
                btCajaEntrada.Enabled = true;
                btCajaSalida.Enabled = true;
                btnCerrarManejoCaja.Enabled = true;
                //btArqueo.Enabled = true;
                Mostrar();
            }
            else
            {
                btCajaEntrada.Enabled = false;
                btCajaSalida.Enabled = false;
                btIniciarCaja.Enabled = true;
                btnCerrarManejoCaja.Enabled = false;
                //btArqueo.Enabled = false;
            }

            CargarMediosPagos();
        }

        private bool CajaAbierta()
        {
            CajaMovimientosCLN caja = new CajaMovimientosCLN();
            FuncionesContabilidad funciones = new FuncionesContabilidad();
            dtpFecha.Value = DateTime.Parse(funciones.FechaHora());

            if (caja.ExisteCajaMovimientosEstado("A", dtpFecha.Value.ToShortDateString()))
                return true;
            else
                return false;
        }

        /*private void CargarTabla()
        {
            CajaMovimientosCLN caja = new CajaMovimientosCLN();
            DataTable dt = new DataTable();

            if (cbTipo.SelectedIndex > -1)
            {
                if (cbTipo.SelectedIndex == 0)
                {
                    dt = caja.ListarCajaMovimientosFecha(dtpFecha.Value);
                    if (dt.Rows.Count > 0)
                        dgvCaja.DataSource = dt.DefaultView;
                }
            }
        }*/

        private void btCajaEntrada_Click(object sender, EventArgs e)
        {
            RegistrarEntrada();
        }

        private void RegistrarEntrada()
        {
            FCajaEntradaSalida fces = new FCajaEntradaSalida(CodigoUsuario, true, lbFechaActual.Text);
            if (fces.ShowDialog() == DialogResult.OK)
            {
                Mostrar();
            }
        }

        private void btMostrarCajaMovimiento_Click(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void Mostrar()
        {
            CajaMovimientosCLN caja = new CajaMovimientosCLN();
            DataTable dt = new DataTable();

            switch (cbTipo.SelectedIndex)
            {
                case 0:
                    dt = caja.ListarCajaMovimientosFechaTipo(dtpFecha.Value, "E");
                    break;
                case 1:
                    dt = caja.ListarCajaMovimientosFechaTipo(dtpFecha.Value, "C");
                    break;
                case 2:
                    dt = caja.ListarCajaMovimientosFechaTipo(dtpFecha.Value, "D");
                    break;
                case 3:
                    dt = caja.ListarCajaMovimientosFecha(dtpFecha.Value);
                    break;
            }

            if (dt.Rows[dt.Rows.Count - 1]["Estado"].Equals("C"))
            {
                btCajaEntrada.Enabled = false;
                btCajaSalida.Enabled = false;
                btIniciarCaja.Enabled = true;
                btnCerrarManejoCaja.Enabled = false;
            }
            if (dt.Rows.Count > 0)
                dgvCaja.DataSource = dt.DefaultView;
        }

        private void btCajaSalida_Click(object sender, EventArgs e)
        {

        }

        private void RegistrarSalida()
        {
            FCajaEntradaSalida fces = new FCajaEntradaSalida(CodigoUsuario, false, lbFechaActual.Text);
            if (fces.ShowDialog() == DialogResult.OK)
            {
                Mostrar();
            }
        }

        //private void Arqueo()
        //{
        //    /*FuncionesContabilidad funciones = new FuncionesContabilidad();
        //    dtpFecha.Value = DateTime.Parse(funciones.ObtenerFechaHora());*/

        //    FCajaArqueoSeleccionarMoneda fc = new FCajaArqueoSeleccionarMoneda();
        //    fc.ShowDialog();
        //}

        private void dgvCaja_DoubleClick(object sender, EventArgs e)
        {

        }
        
        private void btMostrarCajaMovimiento_Click_1(object sender, EventArgs e)
        {
            Mostrar();
        }





        private void CargarMediosPagos()
        {
            ArrayList MediosPagos = new ArrayList();
            MediosPagos.Add(new MedioPago("E", "EFECTIVO"));
            MediosPagos.Add(new MedioPago("C", "CHEQUE"));
            MediosPagos.Add(new MedioPago("D", "DEPOSITO"));
            MediosPagos.Add(new MedioPago("T", "TODOS"));

            cbTipo.DataSource = MediosPagos;
            cbTipo.DisplayMember = "NombreMedioPago";
            cbTipo.ValueMember = "CodigoMedioPago";
        }


        public class MedioPago
        {
            private string CodMedPag;
            private string NomMedPag;

            public MedioPago(string CodigoMedioPago, string NombreMedioPago)
            {
                this.CodMedPag = CodigoMedioPago;
                this.NomMedPag = NombreMedioPago;
            }

            public string CodigoMedioPago
            {
                get
                {
                    return CodMedPag;
                }
            }

            public string NombreMedioPago
            {

                get
                {
                    return NomMedPag;
                }
            }
        }

        private void btIniciarCaja_Click_1(object sender, EventArgs e)
        {
            string Mensaje = _FuncionesContabilidad.ObtenerUltimaFechaMovimientoCierre();
            if (string.IsNullOrEmpty(Mensaje))
            {
                IniciarCaja();
            }
            else
            {
                if (MessageBox.Show(this, Mensaje + "¿Desea Iniciar Caja con el Saldo anterior a dicha fecha?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    _FuncionesContabilidad.AbrirCajaMovimiento();
                    Mostrar();
                    btCajaEntrada.Enabled = true;
                    btCajaSalida.Enabled = true;
                    btIniciarCaja.Enabled = false;
                    btnCerrarManejoCaja.Enabled = true;
                }
                else
                    IniciarCaja();

                
            }
        }

        private void btImprimirTodo_Click(object sender, EventArgs e)
        {
            if (dgvCaja.RowCount > 0)
            {
                string Fecha = dgvCaja.Rows[0].Cells["dgvcFechaHora"].Value.ToString();
                FReporteCajaMovimientosComprobante rcm = new FReporteCajaMovimientosComprobante(DateTime.Parse(Fecha));
                rcm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No se tiene registrado ningún movimiento de caja.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btCajaEntrada_Click_1(object sender, EventArgs e)
        {
            RegistrarEntrada();
        }

        private void btCajaSalida_Click_1(object sender, EventArgs e)
        {
            RegistrarSalida();
        }

        private void btnCerrarManejoCaja_Click(object sender, EventArgs e)
        {
            FuncionesContabilidad funciones = new FuncionesContabilidad();
            dtpFecha.Value = DateTime.Parse(funciones.FechaHora());

            FCajaEntradaSalida fces = new FCajaEntradaSalida(CodigoUsuario, lbFechaActual.Text, false);
            if (fces.ShowDialog() == DialogResult.OK)
            {
                btCajaEntrada.Enabled = false;
                btCajaSalida.Enabled = false;
                btIniciarCaja.Enabled = true;
                btnCerrarManejoCaja.Enabled = false;
                Mostrar();
            }
        }

        private void btnReporteMovimiento_Click(object sender, EventArgs e)
        {
            DataTable DTListarMovimientoCajaReporte = CajaMovimientos.ListarMovimientoCajaReporte(NumeroAgencia,
                dtpFecha.Value, dtpFecha.Value);
            DataTable DTApertura = CajaMovimientos.ListarMovimientoCajaFraccionesReporte(dtpFecha.Value, dtpFecha.Value, "A");
            DataTable DTCierre = CajaMovimientos.ListarMovimientoCajaFraccionesReporte(dtpFecha.Value, dtpFecha.Value, "C");
            DataTable DTListarResumenCajaMovimientoReporte = CajaMovimientos.ListarResumenCajaMovimientoReporte(NumeroAgencia,
                dtpFecha.Value, dtpFecha.Value);

            FReporteContabilidad formReporteMovimiento = new FReporteContabilidad();
            formReporteMovimiento.ListarMovimientoCajaReporte(DTListarMovimientoCajaReporte, DTApertura, DTCierre, DTListarResumenCajaMovimientoReporte);
            formReporteMovimiento.ShowDialog();
            formReporteMovimiento.Dispose();
        }

    }
}
