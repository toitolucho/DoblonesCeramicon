using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN;
using CLCLN.Contabilidad;
using CLCLN.Sistema;
using WFADoblones20.FormulariosContabilidad;

namespace WFADoblones20.FormulariosContabilidad
{
    public partial class FCajaEntradaSalida : Form
    {
        private int CodigoUsuario;
        //private bool EntradaCaja;
        private TextBox tbValidar;        
        private Hashtable tablasubdetalles;
        private int indicefila;
        private DataTable DTFraccionesMonedas;

        public FCajaEntradaSalida(int CodUsuario, bool EsEntrada, string Fecha)
        {
            InitializeComponent();

            CodigoUsuario = CodUsuario;
            dtpFecha.Value = DateTime.Parse(Fecha);

            //EntradaCaja = EsEntrada;

            if (EsEntrada)
            {
                tbDescripcion.Text = "Entrada de Caja por concepto de";
            }
            else
            {
                this.Text = "Salida de caja";
                tbDescripcion.Text = "Salida de Caja por concepto de";
            }
            dgvMonedasFracciones.AutoGenerateColumns = false;
                
        }

        public FCajaEntradaSalida(int CodUsuario, string Fecha, bool EsInicioCaja)
        {
            InitializeComponent();

            CodigoUsuario = CodUsuario;
            dtpFecha.Value = DateTime.Parse(Fecha);
            if (EsInicioCaja)
            {
                tbDescripcion.Text = "Inicio de caja de fecha de " + Fecha;
                this.Text = "Inicio de caja";
            }
            else
            {
                tbDescripcion.Text = "Cierre de caja de fecha de " + Fecha;
                this.Text = "Cierre de caja";
            }
            dgvMonedasFracciones.AutoGenerateColumns = false;
            //MonedasFraccionesCLN monedas = new MonedasFraccionesCLN();
            //monedas.ActualizarMonedasFraccionesRestante();
        }

       



        private void FEntradaSalidaCaja_Load(object sender, EventArgs e)
        {
            CargarComboBoxes();
            CargarMediosPagos();
            decimal d = 0;
            tbImporte.Text = d.ToString("F2");
            cbMoneda.SelectedIndex = cbMonedaPrincipal.SelectedIndex;
            tbValidar = new TextBox();
            tablasubdetalles = new Hashtable();
            indicefila = -1;
            dgvMonedasFracciones.AutoGenerateColumns = false;
        }

        private void CargarComboBoxes()
        {
            MonedasCLN monedas = new MonedasCLN();
            DataTable dt = new DataTable();

            dt = monedas.ListarMonedas();

            cbMoneda.DataSource = dt.DefaultView;
            cbMoneda.ValueMember = "CodigoMoneda";
            cbMoneda.DisplayMember = "NombreMoneda";

            DataTable dt2 = new DataTable();

            dt2 = monedas.ListarMonedas();

            cbMonedaPrincipal.DataSource = dt2.DefaultView;
            cbMonedaPrincipal.ValueMember = "CodigoMoneda";
            cbMonedaPrincipal.DisplayMember = "NombreMoneda";

            if (cbMoneda.Items.Count > 0)
                cbMoneda.SelectedIndex = 0;
            if (cbMonedaPrincipal.Items.Count > 0)
                cbMonedaPrincipal.SelectedIndex = 0;
        }

        private void CargarMediosPagos()
        {
            ArrayList MediosPagos = new ArrayList();
            MediosPagos.Add(new MedioPago("E", "EFECTIVO"));
            MediosPagos.Add(new MedioPago("C", "CHEQUE"));
            MediosPagos.Add(new MedioPago("D", "DEPOSITO"));

            cbTipoPago.DataSource = MediosPagos;
            cbTipoPago.DisplayMember = "NombreMedioPago";
            cbTipoPago.ValueMember = "CodigoMedioPago";
        }

        private void tbImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & e.KeyChar != ',' & e.KeyChar != '.' & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
            }
            else if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (tbImporte.Text.Contains(e.KeyChar))
                {
                    e.Handled = true;
                    System.Media.SystemSounds.Beep.Play();
                }
            }
        }

        private void tbImporte_Leave(object sender, EventArgs e)
        {
            if (tbImporte.Text == string.Empty)
                tbImporte.Text = "0";

            tbImporte.Text = decimal.Parse(tbImporte.Text).ToString("F2");
            tbPago.Text = tbImporte.Text;
        }

        private void dgvMonedasFracciones_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvcCantidad.Index ==  e.ColumnIndex)
            {
                if (dgvMonedasFracciones.Rows[e.RowIndex].Cells["dgvcCantidad"].Value != null)
                {
                    int Cantidad;
                    if (int.TryParse(dgvMonedasFracciones.Rows[e.RowIndex].Cells["dgvcCantidad"].Value.ToString(), out Cantidad))
                    {
                        dgvMonedasFracciones.Rows[e.RowIndex].Cells["dgvcCantidad"].Value = Cantidad.ToString();
                        dgvMonedasFracciones.Rows[e.RowIndex].Cells["dgvcMultiplicado"].Value = decimal.Parse(dgvMonedasFracciones.Rows[e.RowIndex].Cells["dgvcValor"].Value.ToString()) * Cantidad;
                    }
                    else
                    {
                        //MessageBox.Show("El tipo de dato no es valido, revise si el monto es correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dgvMonedasFracciones.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
                        dgvMonedasFracciones.Rows[e.RowIndex].Cells["dgvcCantidad"].Value = Cantidad.ToString();
                        dgvMonedasFracciones.Rows[e.RowIndex].Cells["dgvcMultiplicado"].Value = decimal.Parse(dgvMonedasFracciones.Rows[e.RowIndex].Cells["dgvcValor"].Value.ToString()) * Cantidad;
                        //DTFraccionesMonedas.AcceptChanges();
                    }
                }
            }
        }

        private void dgvMonedasFracciones_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {           
            int CantidadNueva;            
            this.dgvMonedasFracciones.Rows[e.RowIndex].ErrorText = "";
            this.dgvMonedasFracciones.Rows[e.RowIndex].Cells["dgvcCantidad"].ErrorText = "";

            // No cell validation for new rows. New rows are validated on Row Validation.
            if (this.dgvMonedasFracciones.Rows[e.RowIndex].IsNewRow) { return; }

            if (this.dgvMonedasFracciones.IsCurrentCellDirty)
            {
                switch (this.dgvMonedasFracciones.Columns[e.ColumnIndex].Name)
                {

                    case "dgvcCantidad":
                        if (e.FormattedValue.ToString().Trim().Length < 1)
                        {
                            this.dgvMonedasFracciones.Rows[e.RowIndex].Cells["dgvcCantidad"].ErrorText = "   La Cantidad es necesaria y no puede estar vacia.";
                            this.dgvMonedasFracciones.Rows[e.RowIndex].ErrorText = "   La Cantidad es necesaria y no puede estar vacia.";
                            e.Cancel = true;
                        }
                        else if (!int.TryParse(e.FormattedValue.ToString(), out CantidadNueva) || CantidadNueva < 0)
                        {
                            this.dgvMonedasFracciones.Rows[e.RowIndex].Cells["dgvcCantidad"].ErrorText = "   La Cantidad a debe ser un entero positivo.";
                            this.dgvMonedasFracciones.Rows[e.RowIndex].ErrorText = "   La Cantidad a debe ser un entero positivo.";
                            e.Cancel = true;
                            return;
                        }                       
                        break;
                  
                }

            }
        }

        private void dgvMonedasFracciones_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            tbValidar.KeyPress += new KeyPressEventHandler(tbValidar_KeyPress);
        }

        void tbValidar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvMonedasFracciones.SelectedCells[0].ColumnIndex == 3)
            {
                if (!Char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & (Keys)e.KeyChar != Keys.Enter)
                {
                    e.Handled = true;
                    tbValidar.SelectAll();
                    System.Media.SystemSounds.Beep.Play();
                }
            }
        }

        private void CalcularSumatoria()
        {
            int n = dgvMonedasFracciones.RowCount;
            decimal sum = 0;
            decimal valor = 0;
            int multiplicador = 0;

            for (int i = 0; i < n; i++)
            {
                if (dgvMonedasFracciones.Rows[i].Cells["dgvcCantidad"].Value != null)
                {
                    valor = decimal.Parse(dgvMonedasFracciones.Rows[i].Cells["dgvcValor"].Value.ToString());
                    multiplicador = int.Parse(dgvMonedasFracciones.Rows[i].Cells["dgvcCantidad"].Value.ToString());
                    sum += valor * multiplicador;
                }
            }
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            Registrar();
        }

        private void Registrar()
        {
            decimal Importe = 0;
            if ((tbImporte.Text != string.Empty || tbDescripcion.Text != string.Empty)
                && decimal.TryParse(tbImporte.Text, out Importe) && Importe > 0)
            {
                CajaMovimientosCLN caja = new CajaMovimientosCLN();

                DateTime Fecha = DateTime.Parse(new FuncionesContabilidad().FechaHora());
                string Descripcion = tbDescripcion.Text;

                string Estado;
                string TipoMovimiento = string.Empty;
                decimal Debe, Haber;

                if (this.Text == "Inicio de caja")
                {
                    Estado = "A";
                    TipoMovimiento = "E";
                    Debe = decimal.Parse(tbImporte.Text);
                    Haber = decimal.Parse("0");
                }
                else if (this.Text == "Cierre de caja")
                {
                    Estado = "C";
                    TipoMovimiento = "E";
                    Debe = decimal.Parse(tbImporte.Text);
                    Haber = decimal.Parse("0");
                }
                else
                {
                    Estado = "0";
                    if (this.Text == "Entrada de caja")
                    {
                        Debe = decimal.Parse(tbImporte.Text);
                        Haber = decimal.Parse("0");
                    }
                    else
                    {
                        Debe = decimal.Parse("0");
                        Haber = decimal.Parse(tbImporte.Text);
                    }
                }

                if (cbMoneda.SelectedIndex > -1)
                {
                    byte CodigoMoneda = byte.Parse(cbMonedaPrincipal.SelectedValue.ToString());
                    string MedioPago = cbTipoPago.SelectedValue.ToString();

                    caja.InsertarCajaMovimiento(CodigoMoneda, MedioPago, CodigoUsuario, Fecha, Descripcion, Estado, Debe, Haber);                    

                    int NumeroMovimiento = caja.ObtenerUltimoNumeroMovimiento();
                    caja.ActualizarMontoTotalDesdeDetalleFraccionado(1, NumeroMovimiento);

                    CajaMovimientosDetalleCLN cajadetalle;
                    int n = dgvDetalle.RowCount;
                    string TipoDePago = string.Empty;
                    string CodigoMonedaFraccion = string.Empty;
                    int n2, indicetabla;
                    List<SubDetalle> milista = null;

                    for (int i = 0; i < n; i++)
                    {
                        TipoDePago = dgvDetalle.Rows[i].Cells["dgvcTipoPagoCodigo"].Value.ToString();

                        if (TipoDePago == "E")
                        {
                            indicetabla = int.Parse(dgvDetalle.Rows[i].Cells["dgvcIndiceFila"].Value.ToString());
                            milista = (List<SubDetalle>)tablasubdetalles[indicetabla];
                            n2 = milista.Count;

                            for (int j = 0; j < n2; j++)
                            {
                                cajadetalle = new CajaMovimientosDetalleCLN();
                                cajadetalle.Insertar(NumeroMovimiento, milista[j].codigo, milista[j].cantidad, milista[j].numeroserie);
                            }
                        }
                        else
                        {
                            cajadetalle = new CajaMovimientosDetalleCLN();
                            cajadetalle.Insertar(NumeroMovimiento, dgvDetalle.Rows[i].Cells["dgvcNumeroCuenta"].Value.ToString(), 1, string.Empty);
                        }
                    }

                    MessageBox.Show("Registro completado con exito", "Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    

                    if (chbImprimir.Checked)
                    {
                        FReporteCajaMovimientosComprobante freporte = new FReporteCajaMovimientosComprobante(NumeroMovimiento.ToString());
                        freporte.ShowDialog();
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una moneda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbMoneda.Focus();
                }
            }
            else
            {
                MessageBox.Show("Debe llenar los campos de Importe y Descripción", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbDescripcion.Focus();
            }

        }

        private void cbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMoneda.SelectedIndex > -1)
            {
                CargarMonedasFracciones();
                if (!tbPago.Enabled)
                    tbPago.Enabled = true;
                tbPago.Text = lblSumaTotal.Text = tbImporte.Text = "0,00";
            }
        }

        private void CargarMonedasFracciones()
        {
            MonedasFraccionesCLN fraccion = new MonedasFraccionesCLN();
            

            int n;
            if (int.TryParse(cbMoneda.SelectedValue.ToString(), out n))
            {
                DTFraccionesMonedas = fraccion.ListarMonedasFracciones(n.ToString());
                dgvMonedasFracciones.DataSource = DTFraccionesMonedas;

                DataColumn DRCantidad = new DataColumn("Cantidad", Type.GetType("System.Int32"));
                DRCantidad.DefaultValue = 0;

                DataColumn DRTotal = new DataColumn("Total", Type.GetType("System.Decimal"));

                DTFraccionesMonedas.Columns.Add(DRCantidad);
                DTFraccionesMonedas.Columns.Add(DRTotal);

                DTFraccionesMonedas.RowChanging += new DataRowChangeEventHandler(DTFraccionesMonedas_RowChanged);
                
            }
        }

        void DTFraccionesMonedas_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            object MontoTotal = DTFraccionesMonedas.Compute("Sum(Total)", "");
            decimal SumaTotal = 0;
            if (decimal.TryParse(MontoTotal.ToString(), out SumaTotal))
            {
                tbPago.Text = lblSumaTotal.Text = tbImporte.Text = MontoTotal.ToString();
            }
            else
                tbPago.Text = lblSumaTotal.Text = tbImporte.Text = "0,00";
        }

        
        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        

        private void btAnadir_Click(object sender, EventArgs e)
        {
            decimal monto = 0;
            if (!decimal.TryParse(tbPago.Text, out monto))
            {
                MessageBox.Show("Debe introducir un Monto de Pago Valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbPago.Focus();
                tbPago.SelectAll();
                return;
            }
            if (monto <= 0)
            {
                MessageBox.Show("Debe introducir un Monto de Pago mayor a cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbPago.Focus();
                tbPago.SelectAll();
                return;
            }
            if (tbPago.Text != string.Empty)
            {
                if (cbTipoPago.SelectedIndex == 0)//Si el pago es en EFECTIVO
                {
                    if (dgvMonedasFracciones.RowCount > 0 && tbPago.Text != string.Empty)
                    {
                        AnadirADetalle();
                    }
                    else
                    {
                        MessageBox.Show("No se encuentra cortes para la moneda seleccionada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cbMoneda.Focus();
                    }
                }
                else
                {
                    if (tbNumeroCuenta.Text != string.Empty)
                    {
                        AnadirADetalle();
                    }
                    else
                    {
                        MessageBox.Show("Debe introducir un número de cheque/depósito válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tbNumeroCuenta.Focus();
                        tbNumeroCuenta.SelectAll();
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe introducir una suma de Pago válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbPago.Focus();
                tbPago.SelectAll();
            }
        }

        private void btRemover_Click(object sender, EventArgs e)
        {
            RemoverDeDetalle();
        }

        private void AnadirADetalle()
        {
            string[] nuevafila = new string[7];
            DataRowView drvMoneda = (DataRowView)cbMoneda.SelectedItem;
            MedioPago drvTipoPago = (MedioPago)cbTipoPago.SelectedItem;

            indicefila++;

            nuevafila[0] = drvTipoPago.CodigoMedioPago;
            nuevafila[1] = drvTipoPago.NombreMedioPago; 
            //nuevafila[2] = tbNumeroCuenta.Text;
            nuevafila[3] = drvMoneda.Row["CodigoMoneda"].ToString();
            nuevafila[4] = drvMoneda.Row["NombreMoneda"].ToString();
            nuevafila[5] = tbPago.Text;
            nuevafila[6] = indicefila.ToString();
            
            if (cbTipoPago.SelectedIndex == 0)
            {
                nuevafila[2] = string.Empty;
                dgvDetalle.Rows.Add(nuevafila);

                List<SubDetalle> subdetalles;
                int n = dgvMonedasFracciones.RowCount;
                subdetalles = new List<SubDetalle>();

                for (int i = 0; i < n; i++)
                {
                    int cantidad;
                    string numeroserie = string.Empty;

                    if (dgvMonedasFracciones.Rows[i].Cells["dgvcCantidad"].Value != null)
                    {
                        if (int.TryParse(dgvMonedasFracciones.Rows[i].Cells["dgvcCantidad"].Value.ToString(), out cantidad))
                        {
                            if (cantidad > 0)
                            {
                                decimal corte = decimal.Parse(dgvMonedasFracciones.Rows[i].Cells["dgvcValor"].Value.ToString());
                                if (dgvMonedasFracciones.Rows[i].Cells["dgvcNumeroSerie"].Value != null)
                                    numeroserie = dgvMonedasFracciones.Rows[i].Cells["dgvcNumeroSerie"].Value.ToString();
                                string codigomonfracc = dgvMonedasFracciones.Rows[i].Cells["dgvcCodigoMonedaFraccion"].Value.ToString();

                                subdetalles.Add(new SubDetalle(corte, cantidad, numeroserie, codigomonfracc));
                            }
                        }
                    }
                }

                tablasubdetalles.Add(indicefila, subdetalles);
                MostrarASubDetalle(indicefila);
            }
            else
            {
                nuevafila[2] = tbNumeroCuenta.Text;
                dgvDetalle.Rows.Add(nuevafila);
            }

        }

        private void MostrarASubDetalle(int indice)
        {
            if (tablasubdetalles.ContainsKey(indice))
            {
                List<SubDetalle> lista = (List<SubDetalle>)tablasubdetalles[indice];
                dgvSubDetalle.Rows.Clear();

                int n = lista.Count;
                SubDetalle subd = null;
                string[] objetos = new string[4];

                for (int i = 0; i < n; i++)
                {
                    subd = (SubDetalle)lista[i];

                    objetos[0] = subd.corte.ToString();
                    objetos[1] = subd.cantidad.ToString();
                    objetos[2] = subd.numeroserie;
                    objetos[3] = subd.codigo;

                    dgvSubDetalle.Rows.Add(objetos);
                }
            }
        }

        private void RemoverDeDetalle()
        {
            if (dgvDetalle.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("¿Desea remover la fila seleccionada del Detalle?", "Remover", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int indice = int.Parse(dgvDetalle.SelectedRows[0].Cells["dgvcIndiceFila"].Value.ToString());
                    tablasubdetalles.Remove(indice);
                    dgvDetalle.Rows.RemoveAt(indice);
                    dgvSubDetalle.Rows.Clear();
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ninguna fila del Detalle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tbPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & e.KeyChar != ',' & e.KeyChar != '.' & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
            }
            else if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (tbPago.Text.Contains(e.KeyChar))
                {
                    e.Handled = true;
                    System.Media.SystemSounds.Beep.Play();
                }
            }
        }

        private void tbPago_Leave(object sender, EventArgs e)
        {
            if (tbPago.Text == string.Empty)
                tbPago.Text = "0";

            tbPago.Text = decimal.Parse(tbPago.Text).ToString("F2");
        }

        private void cbTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbTipoPago.SelectedIndex)
            {
                case 0:
                    lbCuentaPago.Text = "";
                    lbCuentaPago.Enabled = false;
                    tbNumeroCuenta.Enabled = false;
                    dgvMonedasFracciones.Enabled = true;
                    break;
                case 1:
                    lbCuentaPago.Text = "Nº cheque:";
                    lbCuentaPago.Enabled = true;
                    tbNumeroCuenta.Enabled = true;
                    dgvMonedasFracciones.Enabled = false;
                    break;
                case 2:
                    lbCuentaPago.Text = "Nº depósito:";
                    lbCuentaPago.Enabled = true;
                    tbNumeroCuenta.Enabled = true;
                    dgvMonedasFracciones.Enabled = false;
                    break;
            }
        }
       

        private void btRemoverTodo_Click(object sender, EventArgs e)
        {
            RemoverTodo();
        }

        private void RemoverTodo()
        {
            if (MessageBox.Show("¿Desea remover todas las filas del Detalle?", "Remover", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dgvDetalle.Rows.Clear();
                dgvSubDetalle.Rows.Clear();
                tablasubdetalles.Clear();
            }
        }

        private void dgvDetalle_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            MostrarASubDetalle(int.Parse(dgvDetalle.Rows[e.RowIndex].Cells["dgvcIndiceFila"].Value.ToString()));
        }



        private class SubDetalle
        {
            private decimal cort;
            private int cant;
            private string numserie;
            private string cod;

            public SubDetalle(decimal corte, int cantidad, string numeroserie, string codigo)
            {
                cort = corte;
                cant = cantidad;
                numserie = numeroserie;
                cod = codigo;
            }

            public decimal corte
            {
                get
                {
                    return cort;
                }
            }

            public int cantidad
            {
                get
                {
                    return cant;
                }
            }

            public string numeroserie
            {
                get
                {
                    return numserie;
                }
            }

            public string codigo
            {
                get
                {
                    return cod;
                }
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

        private void cbMonedaPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMoneda.SelectedIndex > -1)
                tbImporte.Enabled = true;
            else
                tbImporte.Enabled = false;
        }

        private void lnlbAdministrarFracciones_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new FMonedasFracciones().ShowDialog();
            CargarMonedasFracciones();
            tbPago.Text = lblSumaTotal.Text = tbImporte.Text = "0,00";
        }



    }
}
