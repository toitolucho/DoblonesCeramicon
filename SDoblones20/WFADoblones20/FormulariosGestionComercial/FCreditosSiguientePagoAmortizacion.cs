using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.GestionComercial;


namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FCreditosSiguientePagoAmortizacion : Form
    {
        private CreditosCuotasPagosCLN CreditosCuotasPagos = new CreditosCuotasPagosCLN();

        int NumeroCredito = 0;
        string NombreDeudor = "";
        string Garante1 = "";
        string Garante2 = "";
        string Garante3 = "";
        string Garante4 = "";
        string Garante5 = "";
        string SistemaAmortizacion = "";
        decimal Monto = 0.0m;
        string TipoFrecuenciaPagos = "";
        int NumeroPagos = 0;
        decimal InteresAnual = 0.0m;
        int NumeroCuota = 0;
        DateTime FechaCuota = DateTime.Now;
        string DIDepositante = "";
        string NombreDepositante = "";
        decimal Cuota = 0.0m;
        string NombreMedioPago = "";
        string Moneda = "";
        string Deposito = "";
        int NumeroAgenciaPago = 0;
        int CodigoUsuarioPago = 0;
        public bool CuotaPagada = false;

        private decimal CuotaAmortizacion;
        private decimal CuotaInteres;
        private decimal TotalAmortizado;
        private decimal SaldoAdeudado;
        private decimal TotalPagado;

        public FCreditosSiguientePagoAmortizacion()
        {
            InitializeComponent();
        }


        public FCreditosSiguientePagoAmortizacion(int NumeCred, string NombDeud, string Gar1, string Gar2, string Gar3, string Gar4, string Gar5,
                string SistAmor, decimal Mont, string TipoFrecPago, int NumePago, decimal InteAnua, int NumeCuot, DateTime FechCuot,
                decimal Cuot, string Mone, int NumeAgenPago, int CodiUsuaPago, 
                decimal CuotAmor, decimal CuotInte, decimal TotaAmor, decimal SaldAdeu, decimal TotaPaga)
        {
            InitializeComponent();

            this.NumeroCredito = NumeCred;
            this.NombreDeudor = NombDeud;
            this.Garante1 = Gar1;
            this.Garante2 = Gar2;
            this.Garante3 = Gar3;
            this.Garante4 = Gar4;
            this.Garante5 = Gar5;
            this.SistemaAmortizacion = SistAmor;
            this.Monto = Mont;
            this.TipoFrecuenciaPagos = TipoFrecPago;
            this.NumeroPagos = NumePago;
            this.InteresAnual = InteAnua;
            this.NumeroCuota = NumeCuot;
            this.FechaCuota = FechCuot;
            this.DIDepositante = "";
            this.NombreDepositante = "";
            this.Cuota = Cuot;
            this.NombreMedioPago = "";
            this.Moneda = Mone;
            this.Deposito = "";
            this.NumeroAgenciaPago = NumeAgenPago;
            this.CodigoUsuarioPago = CodiUsuaPago;
            this.CuotaAmortizacion = CuotAmor;
            this.CuotaInteres = CuotInte;
            this.TotalAmortizado = TotaAmor;
            this.SaldoAdeudado = SaldAdeu;
            this.TotalPagado = TotaPaga;

            this.CuotaPagada = false;
            CargarMediosPagos();
            InicializarControles();
        }

        private void CargarMediosPagos()
        {
            ArrayList MediosPagos = new ArrayList();
            MediosPagos.Add(new MedioPago("E", "EFECTIVO"));
            MediosPagos.Add(new MedioPago("C", "CHEQUE"));
            MediosPagos.Add(new MedioPago("D", "DEPOSITO"));
            
            cBMedioPago.DataSource = MediosPagos;
            cBMedioPago.DisplayMember = "NombreMedioPago";
            cBMedioPago.ValueMember = "CodigoMedioPago";
        }

        private void InicializarControles()
        {
            tBNumeroCredito.Text = NumeroCredito.ToString();
            tBNumeroCuota.Text = NumeroCuota.ToString();
            tBFechaProgramadaPago.Text = FechaCuota.ToShortDateString();
            tBCuota.Text = Cuota.ToString();
            tBCuotaAmortizacion.Text = CuotaAmortizacion.ToString();
            tBCuotaInteres.Text = CuotaInteres.ToString();
            tBTotalAmortizado.Text = TotalAmortizado.ToString();
            tBSaldoAdeudado.Text = SaldoAdeudado.ToString();
            tBTotalPagado.Text = TotalPagado.ToString();
            tBNumeroAgencia.Text = NumeroAgenciaPago.ToString();
            tBCodigoUsuario.Text = CodigoUsuarioPago.ToString();
            lMoneda.Text = Moneda;
            cBMedioPago.SelectedIndex = 0;
            
        }

        private void FCreditoPagoAmortizacionNuevo_Load(object sender, EventArgs e)
        {

        }

        private void cBMedioPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cBMedioPago.SelectedIndex)
            {
                case 0:
                    lNumeroCuentaDeposito.Text = "";
                    lNumeroCuentaDeposito.Visible = false;
                    tBNumeroCuentaBancoDeposito.Visible = false;
                    break;
                case 1:
                    lNumeroCuentaDeposito.Text = "Número cheque";
                    lNumeroCuentaDeposito.Visible = true;
                    tBNumeroCuentaBancoDeposito.Visible = true;
                    break;
                case 2:
                    lNumeroCuentaDeposito.Text = "Número deposito";
                    lNumeroCuentaDeposito.Visible = true;
                    tBNumeroCuentaBancoDeposito.Visible = true;
                    break;
            }
                
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            string Mensaje = "Esta seguro que desea realizar la operacion de pago de cuota de amortización de este credito, le recordamos que la operacion es irreversible.";
            string Titulo = "Confimarción pago amortizacion";
            MessageBoxButtons Botones = MessageBoxButtons.YesNo;
            MessageBoxIcon Icono = MessageBoxIcon.Exclamation;
            DialogResult result;

            result = MessageBox.Show(Mensaje, Titulo, Botones, Icono);

            if (result == DialogResult.Yes)
            {

                try
                {
                    CreditosCuotasPagos.InsertarCreditoCuotaPago(NumeroCredito, NumeroCuota, Cuota, cBMedioPago.SelectedValue.ToString(), tBNumeroCuentaBancoDeposito.Text, tBDIPersonaPago.Text, tBNombreCompletoPersonaPago.Text, NumeroAgenciaPago, CodigoUsuarioPago);
                                     
                    string Deposito = "";

                    DIDepositante = tBDIPersonaPago.Text;
                    NombreDepositante = tBNombreCompletoPersonaPago.Text;
                    Cuota = decimal.Parse(tBCuota.Text);
                    Moneda = lMoneda.Text;
                    if (cBMedioPago.SelectedIndex > 0)
                    {
                        Deposito = "Con deposito bancario Nº " + tBNumeroCuentaBancoDeposito.Text;
                    }
                    NombreMedioPago = cBMedioPago.Text;
                    
                    CuotaPagada = true;

                    Mensaje = "¿Desea imprimir la boleta de pago de cuota?.";
                    Titulo = "Confimarción impresión boleta pado";
                    Botones = MessageBoxButtons.YesNo;
                    Icono = MessageBoxIcon.Exclamation;

                    result = MessageBox.Show(Mensaje, Titulo, Botones, Icono);
                    if (result == DialogResult.Yes)
                    {
                        FReporteCreditosReciboPagoCuota frCreditosReciboPagoCuota = new FReporteCreditosReciboPagoCuota(NumeroCredito, NombreDeudor, Garante1, Garante2, Garante3, Garante4, Garante5,
                        SistemaAmortizacion, Monto, TipoFrecuenciaPagos, NumeroPagos, InteresAnual, NumeroCuota, FechaCuota, DIDepositante, NombreDepositante, Cuota, NombreMedioPago,
                        Moneda, Deposito, NumeroAgenciaPago, CodigoUsuarioPago);
                   
                        frCreditosReciboPagoCuota.ShowDialog();
                        frCreditosReciboPagoCuota.Dispose();
                    }

                    this.Close();

                }
                catch (Exception)
                {
                    //MessageBox.Show("Error." + e.ToString());
                    MessageBox.Show("Error.");
                }
                
            }
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
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
}
