using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using CLCLN;
using CLCLN.Contabilidad;

namespace WFADoblones20.FormulariosContabilidad
{
    public partial class FAsientosDetalle : Form
    {
        private class ValoresOriginales
        {
            private decimal debe;
            private decimal haber;

            public ValoresOriginales()
            { }

            public ValoresOriginales(decimal Debe, decimal Haber)
            {
                debe = Debe;
                haber = Haber;
            }

            public decimal GetDebe
            {
                get
                {
                    return debe;
                }
            }

            public decimal GetHaber
            {
                get
                {
                    return haber;
                }
            }
        }

        private DataGridViewTextBoxEditingControl tb;
        private AutoCompleteStringCollection acscNumeroCuentas, acscNombreCuentas;
        private Color colorInactivo;


        private bool permiso0, permiso1, permiso2, permiso3, permiso4;
        private int NumeroAsiento;
        private int CodigoUsuario;
        private string[] FechaHora;

        private Hashtable origenvals;
        private decimal MontoOrigen;

        public int GetNumeroAsiento
        {
            get
            {
                return NumeroAsiento;
            }
        }

        public FAsientosDetalle()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor para registrar nuevo asiento
        /// </summary>
        /// <param name="CodigoUsuario"></param>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        public FAsientosDetalle(int CodUsuario, bool p0, bool p1, bool p2, bool p3, bool p4)
        {
            InitializeComponent();

            CodigoUsuario = CodUsuario;
            mtbFecha.ReadOnly = true;
            //mtbFecha.Text = DateTime.Today.ToShortDateString();
            FuncionesContabilidad fc = new FuncionesContabilidad();
            FechaHora = fc.FechaHora().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            mtbHora.ReadOnly = true;
            mtbFecha.Text = FechaHora[0];
            lbEstado.Text = "Pendiente";
            btAceptar.Text = "Registrar";
            AsientosCLN Asientos = new AsientosCLN();
            int UltimoNumeroAsiento = Asientos.ObtenerUltimoNumeroAsiento() + 1;
            tbNumeroAsiento.Text = UltimoNumeroAsiento.ToString();

            permiso0 = p0;
            permiso1 = p1;
            permiso2 = p2;
            permiso3 = p3;
            permiso4 = p4;
        }




        /// <summary>
        /// Constructor para registrar nuevo asiento con cuentas configuradas
        /// </summary>
        /// <param name="CodigoUsuario"></param>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        public FAsientosDetalle(int CodUsuario, bool p0, bool p1, bool p2, bool p3, bool p4, int NumeroConfiguracion)
        {
            InitializeComponent();

            CodigoUsuario = CodUsuario;
            mtbFecha.ReadOnly = true;
            //mtbFecha.Text = DateTime.Today.ToShortDateString();
            FuncionesContabilidad fc = new FuncionesContabilidad();
            FechaHora = fc.FechaHora().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            mtbHora.ReadOnly = true;
            mtbFecha.Text = FechaHora[0];
            lbEstado.Text = "Pendiente";
            btAceptar.Text = "Registrar";
            AsientosCLN Asientos = new AsientosCLN();
            int UltimoNumeroAsiento = Asientos.ObtenerUltimoNumeroAsiento() + 1;
            tbNumeroAsiento.Text = UltimoNumeroAsiento.ToString();

            CargarCadenasAutocompletado();

            DataTable dt = new CuentasConfiguracionCLN().ListarPorNumero(NumeroConfiguracion);
            int n = dt.Rows.Count;
            string numcta = string.Empty;
            for (int i = 0; i < n; i++)
            {
                dgvDetalleAsiento.Rows.Add();
                numcta = dt.Rows[i]["NumeroCuentaConfiguracion"].ToString();                    
                dgvDetalleAsiento.Rows[i].Cells["dgvcNumeroCuenta"].Value = numcta;
                dgvDetalleAsiento.Rows[i].Cells["dgvcNombreCuenta"].Value = CheckarNumeroCuenta(numcta);
            }

            n = dgvDetalleAsiento.RowCount;
            dgvDetalleAsiento.Rows[n - 1].Cells["dgvcDebe"].Value = null;

            permiso0 = p0;
            permiso1 = p1;
            permiso2 = p2;
            permiso3 = p3;
            permiso4 = p4;
        }



        private void CargarCadenasAutocompletado()
        {
            PlanCuentasCLN PlanCuentas = new PlanCuentasCLN();
            DataTable DTPlanCuentas = new DataTable();

            DTPlanCuentas = PlanCuentas.ListarPlanCuentasSimple();

            if (DTPlanCuentas.Rows.Count > 0)
            {
                acscNumeroCuentas = new AutoCompleteStringCollection();
                acscNombreCuentas = new AutoCompleteStringCollection();

                int n = DTPlanCuentas.Rows.Count;

                for (int i = 0; i < n; i++)
                {
                    acscNumeroCuentas.Add(DTPlanCuentas.Rows[i][0].ToString());
                    acscNombreCuentas.Add(DTPlanCuentas.Rows[i][1].ToString());
                }
            }
            else
            {
                MessageBox.Show("No existe registros en el Plan de Cuentas.\nNo se puede registrar asientos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
        }

        /// <summary>
        /// Constructor para modificar
        /// </summary>
        /// <param name="NumAsiento"></param>
        /// <param name="Fecha"></param>
        /// <param name="Hora"></param>
        /// <param name="Glosa"></param>
        /// <param name="CodigoUsuario"></param>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        public FAsientosDetalle(int NumAsiento, string Fecha, string Hora, string Glosa, int CodUsuario,
                                        bool p0, bool p1, bool p2, bool p3, bool p4)
        {
            InitializeComponent();
            tbNumeroAsiento.Text = NumAsiento.ToString();
            mtbFecha.ReadOnly = false;
            Fecha = Fecha.Remove(10);
            mtbFecha.Text = Fecha;
            mtbHora.ReadOnly = false;
            DateTime dt = DateTime.Parse(Hora);
            mtbHora.Text = dt.ToShortTimeString().Remove(5);
            lbEstado.Text = "Pendiente";
            btAceptar.Text = "Modificar";
            tbGlosa.Text = Glosa;
            CodigoUsuario = CodUsuario;

            CargarCadenasAutocompletado();

            AsientosDetalleCLN DetalleAsiento = new AsientosDetalleCLN();
            DataTable DTDetalleAsiento = new DataTable();
            DTDetalleAsiento = DetalleAsiento.ObtenerAsientosDetalle(NumAsiento);
            int n = DTDetalleAsiento.Rows.Count;
            dgvDetalleAsiento.Rows.Add(n);
            for (int i = 0; i < n; i++)
            {
                dgvDetalleAsiento.Rows[i].Cells["dgvcNumeroCuenta"].Value = DTDetalleAsiento.Rows[i]["NumeroCuenta"].ToString();
                dgvDetalleAsiento.Rows[i].Cells["dgvcNombreCuenta"].Value = CheckarNumeroCuenta(DTDetalleAsiento.Rows[i]["NumeroCuenta"].ToString());
                dgvDetalleAsiento.Rows[i].Cells["dgvcDebe"].Value = DTDetalleAsiento.Rows[i]["Debe"].ToString();
                dgvDetalleAsiento.Rows[i].Cells["dgvcHaber"].Value = DTDetalleAsiento.Rows[i]["Haber"].ToString();
            }
            
            permiso0 = p0;
            permiso1 = p1;
            permiso2 = p2;
            permiso3 = p3;
            permiso4 = p4;

            CalcularTotales();
        }

        /// <summary>
        /// Constructor para modificar para cuentas cobrar/pagar
        /// </summary>
        /// <param name="NumAsiento"></param>
        /// <param name="Fecha"></param>
        /// <param name="Hora"></param>
        /// <param name="Glosa"></param>
        /// <param name="CodigoUsuario"></param>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        public FAsientosDetalle(int NumAsiento, string Fecha, string Hora, string Glosa, int CodUsuario,
                                        bool p0, bool p1, bool p2, bool p3, bool p4, decimal Monto, bool EsPorCobrar)
        {
            InitializeComponent();
            tbNumeroAsiento.Text = NumAsiento.ToString();
            mtbFecha.ReadOnly = false;
            Fecha = Fecha.Remove(10);
            mtbFecha.Text = Fecha;
            mtbHora.ReadOnly = false;
            DateTime dt = DateTime.Parse(Hora);
            mtbHora.Text = dt.ToShortTimeString().Remove(5);
            lbEstado.Text = "Pendiente";
            btAceptar.Text = "Modificar";
            tbGlosa.Text = Glosa;
            CodigoUsuario = CodUsuario;

            lbMonto.Enabled = true;
            lbMonto.Visible = true;
            tbMonto.Enabled = false;
            tbMonto.Visible = true;
            btAnadir.Enabled = false;
            btAnadir.Visible = true;

            MontoOrigen = Monto;

            tbMonto.Text = Monto.ToString("F2");

            if (EsPorCobrar)
                lbMonto.Text = "Monto acumulado Cuentas X Cobrar: " + Monto.ToString("F2");
            else
                lbMonto.Text = "Monto acumulado Cuentas X Pagar: " + Monto.ToString("F2");

            CargarCadenasAutocompletado();

            AsientosDetalleCLN DetalleAsiento = new AsientosDetalleCLN();
            DataTable DTDetalleAsiento = new DataTable();
            DTDetalleAsiento = DetalleAsiento.ObtenerAsientosDetalle(NumAsiento);
            int n = DTDetalleAsiento.Rows.Count;
            dgvDetalleAsiento.Rows.Add(n);

            origenvals = new Hashtable();
            
            for (int i = 0; i < n; i++)
            {
                dgvDetalleAsiento.Rows[i].Cells["dgvcNumeroCuenta"].Value = DTDetalleAsiento.Rows[i]["NumeroCuenta"].ToString();
                dgvDetalleAsiento.Rows[i].Cells["dgvcNombreCuenta"].Value = CheckarNumeroCuenta(DTDetalleAsiento.Rows[i]["NumeroCuenta"].ToString());
                dgvDetalleAsiento.Rows[i].Cells["dgvcDebe"].Value = DTDetalleAsiento.Rows[i]["Debe"].ToString();
                dgvDetalleAsiento.Rows[i].Cells["dgvcHaber"].Value = DTDetalleAsiento.Rows[i]["Haber"].ToString();
                origenvals.Add(i, new ValoresOriginales(decimal.Parse(DTDetalleAsiento.Rows[i]["Debe"].ToString()), decimal.Parse(DTDetalleAsiento.Rows[i]["Haber"].ToString())));
            }

            permiso0 = p0;
            permiso1 = p1;
            permiso2 = p2;
            permiso3 = p3;
            permiso4 = p4;            

            CalcularTotales();
        }

        /// <summary>
        /// Constructor para ver
        /// </summary>
        /// <param name="NumAsiento"></param>
        /// <param name="Fecha"></param>
        /// <param name="Hora"></param>
        /// <param name="Glosa"></param>
        /// <param name="CodigoUsuario"></param>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        public FAsientosDetalle(int NumAsiento, string Fecha, string Hora, string Glosa,
                                        bool p0, bool p1, bool p2, bool p3, bool p4, string Aceptar)
        {
            InitializeComponent();
            tbNumeroAsiento.Text = NumAsiento.ToString();
            mtbFecha.ReadOnly = true;
            Fecha = Fecha.Remove(10);
            mtbFecha.Text = Fecha;
            mtbHora.ReadOnly = true;
            mtbHora.Text = Hora;
            lbEstado.Text = "Confirmado";
            btAceptar.Text = Aceptar;
            tbGlosa.Text = Glosa;
            tbGlosa.ReadOnly = true;


            AsientosDetalleCLN DetalleAsiento = new AsientosDetalleCLN();
            DataTable DTDetalleAsiento = new DataTable();
            DTDetalleAsiento = DetalleAsiento.ObtenerAsientosDetalle(NumAsiento);
            dgvDetalleAsiento.DataSource = DTDetalleAsiento.DefaultView;
            
            permiso0 = p0;
            permiso1 = p1;
            permiso2 = p2;
            permiso3 = p3;
            permiso4 = p4;

            CalcularTotales();

            dgvDetalleAsiento.AllowUserToAddRows = false;
            dgvDetalleAsiento.AllowUserToDeleteRows = false;
            dgvDetalleAsiento.ReadOnly = true;
        }


        public FAsientosDetalle(string Estado, int NumAsiento, string Fecha, string Hora, string Glosa,
                                        bool p0, bool p1, bool p2, bool p3, bool p4)
        {
            InitializeComponent();
            tbNumeroAsiento.Text = NumAsiento.ToString();
            mtbFecha.ReadOnly = true;
            Fecha = Fecha.Remove(10);
            mtbFecha.Text = Fecha;
            mtbHora.ReadOnly = true;
            mtbHora.Text = Hora;
            lbEstado.Text = Estado;
            btAceptar.Text = "Aceptar";
            tbGlosa.Text = Glosa;
            tbGlosa.ReadOnly = true;


            AsientosDetalleCLN DetalleAsiento = new AsientosDetalleCLN();
            DataTable DTDetalleAsiento = new DataTable();
            DTDetalleAsiento = DetalleAsiento.ObtenerAsientosDetalle(NumAsiento);
            dgvDetalleAsiento.DataSource = DTDetalleAsiento.DefaultView;

            permiso0 = p0;
            permiso1 = p1;
            permiso2 = p2;
            permiso3 = p3;
            permiso4 = p4;

            CalcularTotales();

            dgvDetalleAsiento.AllowUserToAddRows = false;
            dgvDetalleAsiento.AllowUserToDeleteRows = false;
            dgvDetalleAsiento.ReadOnly = true;
        }


        public void AjustarGrilla()
        {
            dgvcNumeroCuenta.Width = 100;
            dgvcNombreCuenta.Width = dgvDetalleAsiento.Width - 180;
        }

        private void FAsientosComtablesDetalle_Load(object sender, EventArgs e)
        {
            AjustarGrilla();
            CargarCadenasAutocompletado();
            tb = new DataGridViewTextBoxEditingControl();
            colorInactivo = tbDiferencia.BackColor;

            mtbFecha.Text = DateTime.Now.ToShortDateString();
        }


        /// <summary>
        /// Revisa que los valores debe y haber sean números y que las cuentas esten correctas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDetalleAsiento_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex > 1)
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
            else
            {
                string aux;

                if (e.ColumnIndex == 0)
                {
                    if (dgvDetalleAsiento.Rows[e.RowIndex].Cells[0].Value != null)
                    {
                        aux = CheckarNumeroCuenta(dgvDetalleAsiento.Rows[e.RowIndex].Cells[0].Value.ToString());
                        if (aux == "0")
                        {
                            MessageBox.Show("El número de cuenta no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dgvDetalleAsiento.Rows[e.RowIndex].Cells[0].Value = null;
                        }
                        else
                            dgvDetalleAsiento.Rows[e.RowIndex].Cells[1].Value = aux;
                    }
                }
                else
                {
                    if (dgvDetalleAsiento.Rows[e.RowIndex].Cells[1].Value != null)
                    {
                        aux = CheckarNombreCuenta(dgvDetalleAsiento.Rows[e.RowIndex].Cells[1].Value.ToString());
                        if (aux == "0")
                        {
                            MessageBox.Show("El nombre de cuenta no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dgvDetalleAsiento.Rows[e.RowIndex].Cells[1].Value = null;
                        }
                        else
                            dgvDetalleAsiento.Rows[e.RowIndex].Cells[0].Value = aux;
                    }
                }
            }

        }

        private string CheckarNumeroCuenta(string NumCuenta)
        {
            string respuesta = "0";
            if (acscNombreCuentas != null)
            {
                if (acscNumeroCuentas.Contains(NumCuenta))
                    respuesta = acscNombreCuentas[acscNumeroCuentas.IndexOf(NumCuenta)];                
            }
            return respuesta;
        }

        private string CheckarNombreCuenta(string NomCuenta)
        {
            string respuesta = "0";
            if (acscNombreCuentas.Contains(NomCuenta))
                respuesta = acscNumeroCuentas[acscNombreCuentas.IndexOf(NomCuenta)];
            return respuesta;
        }

        /// <summary>
        /// Calcula las sumas del debe y el haber
        /// </summary>
        private void CalcularTotales()
        {
            decimal sumaDebe = 0, sumaHaber = 0, diferencia = 0;

            int aux = dgvDetalleAsiento.RowCount - 1;

            for (int i = 0; i < aux; i++)
            {
                if (dgvDetalleAsiento.Rows[i].Cells[2].Value != null)
                    sumaDebe += decimal.Parse(dgvDetalleAsiento.Rows[i].Cells[2].Value.ToString());
                if (dgvDetalleAsiento.Rows[i].Cells[3].Value != null)
                    sumaHaber += decimal.Parse(dgvDetalleAsiento.Rows[i].Cells[3].Value.ToString());
            }

            tbTotalDebe.Text = sumaDebe.ToString();
            tbTotalHaber.Text = sumaHaber.ToString();

            diferencia = Math.Abs(sumaDebe - sumaHaber);

            if (diferencia != 0)
                tbDiferencia.BackColor = Color.Red;
            else
                tbDiferencia.BackColor = colorInactivo;

            tbDiferencia.Text = diferencia.ToString("F2");
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (btAceptar.Text == "Aceptar")
            {
                if (chbReporte.Checked)
                {
                    FReporteLibroDiario libroDiario = new FReporteLibroDiario(tbNumeroAsiento.Text);
                    libroDiario.ShowDialog();
                }
                this.Close();
            }
            else if (!HayErrores())
            {
                AsientosCLN Asientos = new AsientosCLN();
                AsientosDetalleCLN DetalleAsiento = new AsientosDetalleCLN();
                FEstadoAsiento fea = new FEstadoAsiento();
                string EstadoAsiento = string.Empty;

                if (btAceptar.Text == "Registrar")
                {  
                    if (fea.ShowDialog() == DialogResult.OK)
                    {
                        if (fea.EstadoConfirmado())
                            EstadoAsiento = "Confirmado";
                        else
                            EstadoAsiento = "Pendiente";

                        FuncionesContabilidad fc = new FuncionesContabilidad();
                        FechaHora = fc.FechaHora().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        if (FechaHora.Length == 3)
                        {
                            if (FechaHora[2] == "p.m.")
                            {
                                string[] numerohora = FechaHora[1].Split(new char[] { ':' });
                                int numhora = int.Parse(numerohora[0].ToString());
                                numhora += 12;
                                string horaaux = numhora.ToString() + ":" + numerohora[1] + ":" + numerohora[2];
                                FechaHora[1] = horaaux;
                            }
                        }

                        Asientos.InsertarAsientos(CodigoUsuario, FechaHora[0], FechaHora[1], tbGlosa.Text, EstadoAsiento);

                        int aux = dgvDetalleAsiento.RowCount - 1;
                        decimal debeAux, haberAux;
                        NumeroAsiento = Asientos.ObtenerUltimoNumeroAsiento();

                        for (int i = 0; i < aux; i++)
                        {
                            if (dgvDetalleAsiento.Rows[i].Cells[2].Value == null)
                                debeAux = 0;
                            else
                                debeAux = decimal.Parse(dgvDetalleAsiento.Rows[i].Cells[2].Value.ToString());
                            if (dgvDetalleAsiento.Rows[i].Cells[3].Value == null)
                                haberAux = 0;
                            else
                                haberAux = decimal.Parse(dgvDetalleAsiento.Rows[i].Cells[3].Value.ToString());


                            DetalleAsiento.InsertarDetalleAsiento(NumeroAsiento, dgvDetalleAsiento.Rows[i].Cells[0].Value.ToString(), debeAux, haberAux);
                        }

                        MessageBox.Show("Se realizo el registro de manera existosa.", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (chbReporte.Checked)
                        {
                            FReporteLibroDiario libroDiario = new FReporteLibroDiario(tbNumeroAsiento.Text);
                            libroDiario.ShowDialog();
                        }
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else if (btAceptar.Text == "Modificar")
                {
                    if (fea.ShowDialog() == DialogResult.OK)
                    {
                        if (fea.EstadoConfirmado())
                            EstadoAsiento = "Confirmado";
                        else
                            EstadoAsiento = "Pendiente";

                        NumeroAsiento = int.Parse(tbNumeroAsiento.Text);

                        Asientos.ActualizarAsientos(NumeroAsiento,
                                                    CodigoUsuario,
                                                    mtbFecha.Text, mtbHora.Text, tbGlosa.Text,
                                                    EstadoAsiento);


                        DetalleAsiento.EliminarDetalleAsiento(NumeroAsiento);

                        int aux = dgvDetalleAsiento.RowCount - 1;

                        for (int i = 0; i < aux; i++)
                        {
                            DetalleAsiento.InsertarDetalleAsiento(NumeroAsiento,
                                                                    dgvDetalleAsiento.Rows[i].Cells[0].Value.ToString(),
                                                                    decimal.Parse(dgvDetalleAsiento.Rows[i].Cells[2].Value.ToString()),
                                                                    decimal.Parse(dgvDetalleAsiento.Rows[i].Cells[3].Value.ToString()));
                        }

                        MessageBox.Show("Se realizo el registro de manera existosa.", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (chbReporte.Checked)
                        {
                            FReporteLibroDiario libroDiario = new FReporteLibroDiario(tbNumeroAsiento.Text);
                            libroDiario.ShowDialog();
                        }
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
        }


        private bool HayErrores()
        {
            bool respuesta = false;

            bool errorMinimoCuentas = false;
            bool errorSumasDesiguales = false;
            bool errorGlosa = false;
            bool errorCuentas = false;

            int aux = dgvDetalleAsiento.RowCount;

            if (aux > 2)
            {
                if (tbTotalDebe.Text == tbTotalHaber.Text)
                    errorSumasDesiguales = false;
                else
                {
                    MessageBox.Show("Las sumas del Debe y el Haber con coinciden. Revise los montos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    errorSumasDesiguales = true;
                }

                if (tbGlosa.Text.Length > 8)
                    errorGlosa = false;
                else
                {
                    MessageBox.Show("La glosa es demasiada corta.\nSe sugiere que sea mayor a 8 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    errorGlosa = true;
                }

                int n = dgvDetalleAsiento.RowCount - 1;
                for (int i = 0; i < n; i++)
                {
                    if (dgvDetalleAsiento.Rows[i].Cells[0].Value == null || dgvDetalleAsiento.Rows[i].Cells[1].Value == null)
                    {
                        MessageBox.Show("Existe errores en las cuentas. Revise el número y nombre de las cuentas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        errorCuentas = true;
                        break;
                    }
                }

            }
            else
                MessageBox.Show("Deben existir al menos 2 cuentas distintas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            if (errorSumasDesiguales || errorMinimoCuentas || errorGlosa || errorCuentas)
                respuesta = true;

            return respuesta;
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDetalleAsiento_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvDetalleAsiento.SelectedCells[0].ColumnIndex < 2)
            {
                tb = (DataGridViewTextBoxEditingControl)e.Control;
                tb.AutoCompleteMode = AutoCompleteMode.Suggest;
                tb.AutoCompleteSource = AutoCompleteSource.CustomSource;

                if (dgvDetalleAsiento.SelectedCells[0].ColumnIndex == 0)
                {
                    tb.AutoCompleteCustomSource = acscNumeroCuentas;
                    tb.MaxLength = 13;

                    tb.KeyUp += new KeyEventHandler(tb_KeyUp);
                }
                else if (dgvDetalleAsiento.SelectedCells[0].ColumnIndex == 1)
                {
                    tb.AutoCompleteCustomSource = acscNombreCuentas;
                    tb.MaxLength = 250;
                }
            }
            else
            {
                tb.AutoCompleteCustomSource = null;
            }

            tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
        }

        void tb_KeyUp(object sender, KeyEventArgs e)
        {
            if (dgvDetalleAsiento.SelectedCells[0].ColumnIndex == 0)
            {
                if (e.KeyData != Keys.Back)
                {
                    int n = tb.Text.Length;

                    switch (n)
                    {
                        case 1:
                        case 3:
                        case 6:
                        case 9:
                            tb.AppendText("-");
                            break;
                    }
                }
            }
        }

        void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvDetalleAsiento.SelectedCells[0].ColumnIndex == 0)
            {
                if (!Char.IsNumber(e.KeyChar) & e.KeyChar != '-'& (Keys)e.KeyChar != Keys.Back & (Keys)e.KeyChar != Keys.Enter)
                {
                    e.Handled = true;
                    tb.SelectAll();
                    System.Media.SystemSounds.Beep.Play();
                }
            }
            else if (dgvDetalleAsiento.SelectedCells[0].ColumnIndex > 1)
            {
                if (!Char.IsNumber(e.KeyChar) & e.KeyChar != ',' & e.KeyChar != '.' & (Keys)e.KeyChar != Keys.Back & (Keys)e.KeyChar != Keys.Enter)
                {
                    e.Handled = true;
                    tb.SelectAll();
                    System.Media.SystemSounds.Beep.Play();
                }
            }
        }

        private void dgvDetalleAsiento_SizeChanged(object sender, EventArgs e)
        {
            AjustarGrilla();
        }

        private void lnklbPlanCuentas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FPlanCuentas pc = new FPlanCuentas(permiso0, permiso1, permiso2, permiso3, permiso4);
            pc.ShowDialog();
            CargarCadenasAutocompletado();
        }

        private void tbMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & (Keys)e.KeyChar != Keys.Enter & e.KeyChar != ',' & e.KeyChar != '.')
            {
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void tbMonto_Leave(object sender, EventArgs e)
        {
            decimal montodinero;
            if (decimal.TryParse(tbMonto.Text, out montodinero))
            {
                if (montodinero <= MontoOrigen)
                {
                    tbMonto.Text = montodinero.ToString("F2");
                }
                else
                {
                    MessageBox.Show("El monto a añadir no puede superar al monto acumulado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbMonto.Focus();
                    tbMonto.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("Monto inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbMonto.Focus();
                tbMonto.SelectAll();
            }
        }

        private void dgvDetalleAsiento_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (origenvals != null)
            {
                if (e.ColumnIndex > 1)
                {
                    if (origenvals.Count > 0)
                    {
                        tbMonto.Enabled = true;
                        btAnadir.Enabled = true;

                        if (origenvals.ContainsKey(e.RowIndex))
                        {
                            ValoresOriginales vals = new ValoresOriginales();
                            vals = (ValoresOriginales)origenvals[e.RowIndex];
                            toolStripStatusLabel1.Text = "Valores originales: Debe = " + vals.GetDebe.ToString() + " | Haber = " + vals.GetHaber.ToString();
                        }
                    }
                    else
                    {
                        tbMonto.Enabled = false;
                        btAnadir.Enabled = false;
                    }
                }
                else
                {
                    toolStripStatusLabel1.Text = "Seleccionar fila para editarla";
                }
            }
        }

        private void btAnadir_Click(object sender, EventArgs e)
        {
            decimal suma = decimal.Parse(dgvDetalleAsiento.SelectedCells[0].Value.ToString());
            suma += decimal.Parse(tbMonto.Text);
            dgvDetalleAsiento.SelectedCells[0].Value = suma;
            CalcularTotales();
        }

    }
}
