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
    public partial class FConfiguracionCuentas : Form
    {
        private string NombreConf, DescConf;
        private int indicefila;

        private bool permiso0, permiso1, permiso2, permiso3, permiso4;
        CLCAD.DSDoblones20Contabilidad.ListarConfiguracionesCuentasDetallePorNumeroConfiguracionDHDataTable DTCuentasConfiguracion;
        TipoDebeHaber tipoDebeHaber;

        public FConfiguracionCuentas(int CodUsuario, bool p0, bool p1, bool p2, bool p3, bool p4)
        {
            InitializeComponent();

            permiso0 = p0;
            permiso1 = p1;
            permiso2 = p2;
            permiso3 = p3;
            permiso4 = p4;

            tipoDebeHaber = new TipoDebeHaber();
            DTCuentasConfiguracion = new CLCAD.DSDoblones20Contabilidad.ListarConfiguracionesCuentasDetallePorNumeroConfiguracionDHDataTable();
            DTCuentasConfiguracion.TipoCuentaDebeHaberColumn.ReadOnly = false;
            dgvcTipo.DataSource = tipoDebeHaber.obtenerLista();
            dgvcTipo.DisplayMember = tipoDebeHaber.DisplayMember;
            dgvcTipo.ValueMember = tipoDebeHaber.ValueMember;
            dgvcTipo.DataPropertyName = tipoDebeHaber.ValueMember;
        }

        private void FConfiguracionCuentas_Load(object sender, EventArgs e)
        {
            btModificar.Enabled = false;
            btEliminar.Enabled = false;
            btCancel.Enabled = false;
            btAnadir.Enabled = false;
            btQuitar.Enabled = false;
            btAceptar.Enabled = false;
            btCancelar.Enabled = false;
            dgvCuentas.Enabled = false;


            CargarPlanCuentas();
            CargarConfiguracionesCuentas();
        }

        private void CargarPlanCuentas()
        {
            PlanCuentasCLN cuentas = new PlanCuentasCLN();
            dgvCuentas.DataSource = cuentas.ListarPlanCuentasSimple();

            if (dgvCuentas.RowCount == 0)
            {
                MessageBox.Show("No existen registros en el Plan de Cuentas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CargarConfiguracionesCuentas()
        {
            dgvTipos.Rows.Clear();

            ConfiguracionesTransaccionesCuentasCLN cuentas = new ConfiguracionesTransaccionesCuentasCLN();
            DataTable dt = cuentas.ListarConfiguracionesTransaccionesCuentas();

            int n = dt.Rows.Count;

            for (int i = 0; i < n; i++)
            {
                dgvTipos.Rows.Add();
                dgvTipos.Rows[i].Cells["dgvcNumConf"].Value = dt.Rows[i]["NumeroConfiguracion"].ToString();
                dgvTipos.Rows[i].Cells["dgvcNombreConf"].Value = dt.Rows[i]["NombreConfiguracion"].ToString();
                dgvTipos.Rows[i].Cells["dgvcDescConf"].Value = dt.Rows[i]["DescripcionConfiguracion"].ToString();
            }



        }

        private void CargarCuentasConfiguracion(string Numero)        
        {
            //dgvConfCuentas.Rows.Clear();
            DTCuentasConfiguracion.Clear(); 

            CuentasConfiguracionCLN cuentas = new CuentasConfiguracionCLN();
            //DataTable dt = cuentas.ListarPorNumero(int.Parse(Numero));

            //int n = dt.Rows.Count;

            //for (int i = 0; i < n; i++)
            //{
            //    dgvConfCuentas.Rows.Add();
            //    dgvConfCuentas.Rows[i].Cells["dgvcNumConfCta"].Value = dt.Rows[i]["NumeroConfiguracion"].ToString();
            //    dgvConfCuentas.Rows[i].Cells["dgvcNumCtaConf"].Value = dt.Rows[i]["NumeroCuentaConfiguracion"].ToString();
            //    dgvConfCuentas.Rows[i].Cells["dgvcNomCtaConf"].Value = dt.Rows[i]["NombreCuenta"].ToString();
            //    dgvConfCuentas.Rows[i].Cells["DGCPorcentajeMontoTotalDH"].Value = dt.Rows[i]["PorcentajeMontoTotalDH"].ToString();
            //    if (dt.Rows[i]["TipoCuentaDebeHaber"].ToString() == "D")
            //        dgvConfCuentas.Rows[i].Cells["dgvcTipo"].Value = "Debe";
            //    else
            //        dgvConfCuentas.Rows[i].Cells["dgvcTipo"].Value = "Haber";
            //}

            DTCuentasConfiguracion = (CLCAD.DSDoblones20Contabilidad.ListarConfiguracionesCuentasDetallePorNumeroConfiguracionDHDataTable)cuentas.ListarPorNumero(int.Parse(Numero));
            DTCuentasConfiguracion.RowChanged += new DataRowChangeEventHandler(DTCuentasConfiguracion_RowChanged);
            dgvConfCuentas.DataSource = DTCuentasConfiguracion;
        }

        void DTCuentasConfiguracion_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            lblMontoTotalDEBE.Text = "Monto Total DEBE   = " + DTCuentasConfiguracion.Compute("sum(PorcentajeMontoTotalDH)", "TipoCuentaDebeHaber = 'D'").ToString();
            lblMontoTotalHABER.Text = "Monto Total HABER = " + DTCuentasConfiguracion.Compute("sum(PorcentajeMontoTotalDH)", "TipoCuentaDebeHaber = 'H'").ToString();
        }

        private void dgvTipos_SelectionChanged(object sender, EventArgs e)
        {
            if (btNuevo.Text == "Nuevo")
            {
                if (dgvTipos.ReadOnly)
                {
                    if (dgvTipos.SelectedCells.Count == 0)
                    {
                        btModificar.Enabled = false;
                        btEliminar.Enabled = false;
                        btAceptar.Enabled = false;
                    }
                    else
                    {
                        btModificar.Enabled = true;
                        btEliminar.Enabled = true;
                        btAceptar.Enabled = true;
                    }
                }
            }
        }

        private void dgvTipos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!dgvTipos.ReadOnly)
            {
                    if (e.ColumnIndex == 1)
                    {
                        if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
                        {
                            MessageBox.Show("El Nombre no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            e.Cancel = true;
                        }
                    }
            }
        }

        private void dgvTipos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (dgvTipos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    dgvTipos.Rows.RemoveAt(e.RowIndex);
                    dgvTipos.ReadOnly = true;
                    if (btNuevo.Text != "Nuevo")
                    {
                        btNuevo.Text = "Nuevo";
                        btCancel.Enabled = false;
                        if (dgvTipos.SelectedCells.Count == 1)
                        {
                            btModificar.Enabled = true;
                            btEliminar.Enabled = true;
                        }
                        else
                        {
                            btModificar.Enabled = true;
                            btEliminar.Enabled = true;
                        }
                    }
                }
            }
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void Nuevo()
        {
            if (btNuevo.Text == "Nuevo")
            {
                btNuevo.Text = "Registrar";
                btModificar.Enabled = false;
                btAceptar.Enabled = false;
                dgvConfCuentas.Enabled = false;
                btEliminar.Enabled = false;
                btCancel.Enabled = true;

                dgvTipos.Rows.Add();
                int n = dgvTipos.RowCount - 1;
                dgvTipos.ReadOnly = false;
                dgvTipos.Rows[n].Cells[1].Selected = true;
                dgvTipos.BeginEdit(true);
            }
            else
            {
                ConfiguracionesTransaccionesCuentasCLN cuentas = new ConfiguracionesTransaccionesCuentasCLN();
                string desc = string.Empty;

                int n = dgvTipos.RowCount - 1;
                if (dgvTipos.Rows[n].Cells[2].Value != null)
                    desc = dgvTipos.Rows[n].Cells[2].Value.ToString();

                cuentas.InsertarConfiguracionesTransaccionesCuentas(dgvTipos.Rows[n].Cells[1].Value.ToString(), "C","I",desc);
                btAceptar.Enabled = true;
                dgvConfCuentas.Enabled = true;
                dgvTipos.ReadOnly = true;                
                btNuevo.Text = "Nuevo";
                btModificar.Enabled = true;
                btEliminar.Enabled = true;
                btCancel.Enabled = false;
                CargarConfiguracionesCuentas();
            }
        }

        private void Modificar()
        {
            if (btModificar.Text == "Modificar")
            {
                indicefila = dgvTipos.SelectedCells[0].RowIndex;
                NombreConf = dgvTipos.Rows[indicefila].Cells["dgvcNombreConf"].Value.ToString();
                DescConf = dgvTipos.Rows[indicefila].Cells["dgvcDescConf"].Value.ToString();

                btModificar.Text = "Registrar";
                dgvTipos.ReadOnly = false;
                dgvTipos.BeginEdit(true);
                btNuevo.Enabled = false;
                btEliminar.Enabled = false;
                btCancel.Enabled = true;
            }
            else
            {
                ConfiguracionesTransaccionesCuentasCLN cuentas = new ConfiguracionesTransaccionesCuentasCLN();
                //int n = dgvTipos.SelectedCells[0].RowIndex;
                string desc = string.Empty;
                if (dgvTipos.Rows[indicefila].Cells["dgvcDescConf"].Value != null)
                    desc = dgvTipos.Rows[indicefila].Cells["dgvcDescConf"].Value.ToString();
                cuentas.ActualizarConfiguracionesTransaccionesCuentas(int.Parse(dgvTipos.Rows[indicefila].Cells["dgvcNumConf"].Value.ToString()), dgvTipos.Rows[indicefila].Cells["dgvcNombreConf"].Value.ToString(),
                    "V","E",desc);

                NombreConf = string.Empty;
                DescConf = string.Empty;
                indicefila = -1;
                dgvTipos.ReadOnly = true;
                btNuevo.Enabled = true;
                btEliminar.Enabled = true;
                btCancel.Enabled = false;
                btModificar.Text = "Modificar";

                CargarConfiguracionesCuentas();
            }
        }

        private void Eliminar()
        {
            if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ConfiguracionesTransaccionesCuentasCLN cuentas = new ConfiguracionesTransaccionesCuentasCLN();
                int n = dgvTipos.SelectedCells[0].RowIndex;
                cuentas.EliminarConfiguracionesTransaccionesCuentas(int.Parse(dgvTipos.Rows[n].Cells["dgvcNumConf"].Value.ToString()));

                CargarConfiguracionesCuentas();
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            if (btNuevo.Text == "Registrar")
            {
                int n = dgvTipos.SelectedCells[0].RowIndex;
                dgvTipos.Rows.RemoveAt(n);
                dgvTipos.ReadOnly = true;
                if (btNuevo.Text != "Nuevo")
                {
                    btNuevo.Text = "Nuevo";
                    btCancel.Enabled = false;
                }
            }
            else if (!btNuevo.Enabled)
            {
                dgvTipos.EndEdit();

                dgvTipos.Rows[indicefila].Cells["dgvcNombreConf"].Value = NombreConf;
                dgvTipos.Rows[indicefila].Cells["dgvcDescConf"].Value = DescConf;

                dgvTipos.ReadOnly = true;
                indicefila = -1;
                NombreConf = string.Empty;
                DescConf = string.Empty;
                btNuevo.Enabled = true;
                btModificar.Text = "Modificar";
                btEliminar.Enabled = true;
                btCancel.Enabled = false;
            }
        }

        private void dgvTipos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(!btNuevo.Enabled)
            {
                if (e.RowIndex != indicefila)
                {
                    dgvTipos.EndEdit();

                    dgvTipos.Rows[indicefila].Cells["dgvcNombreConf"].Value = NombreConf;
                    dgvTipos.Rows[indicefila].Cells["dgvcDescConf"].Value = DescConf;

                    dgvTipos.ReadOnly = true;
                    indicefila = -1;
                    NombreConf = string.Empty;
                    DescConf = string.Empty;
                    btNuevo.Enabled = true;
                    btModificar.Text = "Modificar";
                    btEliminar.Enabled = true;
                    btCancel.Enabled = false;
                }
            }
            else if (!dgvTipos.ReadOnly)
                dgvTipos.BeginEdit(true);
            else if (dgvTipos.SelectedCells.Count == 1)
            {
                int n = dgvTipos.SelectedCells[0].RowIndex;
                if (dgvTipos.Rows[n].Cells["dgvcNumConf"].Value != null)
                {
                    CargarCuentasConfiguracion(dgvTipos.Rows[n].Cells["dgvcNumConf"].Value.ToString());
                }
            }
            
        }

        private void dgvTipos_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (btAceptar.Text == "Modificar")
            {
                dgvTipos.Enabled = false;
                btAceptar.Text = "Registrar";
                btCancelar.Enabled = true;
                dgvCuentas.Enabled = true;
                btAnadir.Enabled = true;
                btQuitar.Enabled = true;
                DGCPorcentajeMontoTotalDH.ReadOnly = false;
                dgvcTipo.ReadOnly = false;
            }
            else
            {
                
                if (dgvConfCuentas.RowCount > 1)
                {
                    string CadenaMontoTotalDebe = DTCuentasConfiguracion.Compute("sum(PorcentajeMontoTotalDH)", "TipoCuentaDebeHaber = 'D'").ToString();
                    string CadenaMontoTotalHaber = DTCuentasConfiguracion.Compute("sum(PorcentajeMontoTotalDH)", "TipoCuentaDebeHaber = 'H'").ToString();
                    if (string.IsNullOrEmpty(CadenaMontoTotalDebe))
                    {
                        MessageBox.Show(this, "Aún no ha seleccionado ninguna cuenta para el DEBE", "Validación de Porcentajes",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (string.IsNullOrEmpty(CadenaMontoTotalHaber))
                    {
                        MessageBox.Show(this, "Aún no ha seleccionado ninguna cuenta para el HABER", "Validación de Porcentajes",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    decimal PorcentajeTotalDebe = decimal.Parse(CadenaMontoTotalDebe);
                    decimal PorcentajeTotalHaber = decimal.Parse(CadenaMontoTotalHaber);

                    if(PorcentajeTotalHaber != PorcentajeTotalDebe)
                    {
                        MessageBox.Show(this, "El Porcentaje Total tanto del DEBE como del HABER no igualan sus cantidades", "Validación de Porcentajes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (PorcentajeTotalDebe > 100)
                    {
                        MessageBox.Show(this, "El Porcentaje Total de las cuentas del DEBE superan el 100%", "Validación de Porcentajes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (PorcentajeTotalDebe < 100)
                    {
                        MessageBox.Show(this, "El Porcentaje Total de las cuentas del DEBE no suman el 100%", "Validación de Porcentajes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (PorcentajeTotalHaber > 100)
                    {
                        MessageBox.Show(this, "El Porcentaje Total de las cuentas del HABER superan el 100%", "Validación de Porcentajes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (PorcentajeTotalHaber < 100)
                    {
                        MessageBox.Show(this, "El Porcentaje Total de las cuentas del HABER no suman el 100%", "Validación de Porcentajes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }



                    int m = dgvTipos.SelectedCells[0].RowIndex;
                    int numero = int.Parse(dgvTipos.Rows[m].Cells["dgvcNumConf"].Value.ToString());

                    CuentasConfiguracionCLN cuentas = new CuentasConfiguracionCLN();
                    cuentas.EliminarCuentasConfiguracion(numero);
                    int n = dgvConfCuentas.RowCount;                    
                    /*bool PorcentajeCorrecto = true;

                    for (int j = 0; j < n; j++)
                    {
                        if (dgvConfCuentas.Rows[j].Cells["dgvcPorcentaje"].Value != null)
                        {
                            if (decimal.Parse(dgvConfCuentas.Rows[j].Cells["dgvcPorcentaje"].Value.ToString()) > 0)
                                PorcentajeCorrecto = true;
                            else
                                PorcentajeCorrecto = false;
                        }
                        else
                            PorcentajeCorrecto = false;
                    }

                    if (PorcentajeCorrecto)
                    {*/

                        for (int i = 0; i < n; i++)
                        {
                            //cuentas.InsertarCuentasConfiguracion(numero, dgvConfCuentas.Rows[i].Cells["dgvcNumCtaConf"].Value.ToString(), dgvConfCuentas.Rows[i].Cells["dgvcTipo"].Value.ToString()[0], 10);
                            cuentas.InsertarCuentasConfiguracion(DTCuentasConfiguracion[i].NumeroConfiguracion, DTCuentasConfiguracion[i].NumeroCuentaConfiguracion, DTCuentasConfiguracion[i].TipoCuentaDebeHaber[0],
                                DTCuentasConfiguracion[i].PorcentajeMontoTotalDH);
                        }

                        MessageBox.Show("Registro correcto.", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvTipos.Enabled = true;
                        btAceptar.Text = "Modificar";
                        btCancelar.Enabled = false;
                        dgvCuentas.Enabled = false;
                        btAnadir.Enabled = false;
                        btQuitar.Enabled = false;

                        dgvcTipo.ReadOnly = true;
                        /*dgvcPorcentaje.ReadOnly = true;
                    }
                    else
                    {
                        MessageBox.Show("Alguno de los Porcentajes tiene un valor erróneo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }*/
                }
                else
                {
                    MessageBox.Show("Deben existir al menos 2 cuentas en la lista de Configuración de Cuentas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private bool YaEstaEnLista(string NumCta)
        {
            bool respuesta = false;

            int n = dgvConfCuentas.RowCount;
            for (int i = 0; i < n; i++)
            {
                if (dgvConfCuentas.Rows[i].Cells["dgvcNumCtaConf"].Value.ToString() == NumCta)
                {
                    respuesta = true;
                    break;
                }
            }

            return respuesta;
        }

        private void btAnadir_Click(object sender, EventArgs e)
        {
            if (dgvCuentas.SelectedRows.Count == 1)
            {
                string NumeroCuentaConfiguracion= dgvCuentas.SelectedRows[0].Cells["dgvcNumCta"].Value.ToString();
                int NumeroConfiguracion = int.Parse(this.dgvTipos.CurrentRow.Cells["dgvcNumConf"].Value.ToString());
                if (DTCuentasConfiguracion.FindByNumeroConfiguracionNumeroCuentaConfiguracion(NumeroConfiguracion, NumeroCuentaConfiguracion) == null)
                {
                    DTCuentasConfiguracion.AddListarConfiguracionesCuentasDetallePorNumeroConfiguracionDHRow(NumeroConfiguracion,
                        NumeroCuentaConfiguracion, dgvCuentas.SelectedRows[0].Cells["dgvcNomCta"].Value.ToString(),
                        "H", 0);
                    DTCuentasConfiguracion.AcceptChanges();
                    //if (dgvCuentas.RowCount > 0)
                    //{
                    //    dgvCuentas.CurrentCell = dgvCuentas[0, (dgvCuentas.CurrentCell.RowIndex + 1 <= dgvCuentas.RowCount) ?
                    //        dgvCuentas.CurrentCell.RowIndex + 1 : dgvCuentas.RowCount - 1];
                    //    dgvCuentas.CurrentRow.Selected = true;
                    //}
                }
                else
                {
                    MessageBox.Show("La cuenta seleccionada ya se encuentra en las Cuentas Configuradas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                //if (!YaEstaEnLista(NumCta))
                //{
                //    dgvConfCuentas.Rows.Add();
                //    int n = dgvConfCuentas.RowCount - 1;
                //    dgvConfCuentas.Rows[n].Cells["dgvcNumCtaConf"].Value = NumCta;
                //    dgvConfCuentas.Rows[n].Cells["dgvcNomCtaConf"].Value = dgvCuentas.SelectedRows[0].Cells["dgvcNomCta"].Value.ToString();
                //    //dgvConfCuentas.Rows[n].Cells["dgvcPorcentaje"].Value = 100;
                //    dgvConfCuentas.Rows[n].Cells["dgvcTipo"].Value = "Debe";
                //}
                //else
                //{
                //    MessageBox.Show("La cuenta seleccionada ya se encuentra en las Cuentas Configuradas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}

                
            }
        }

        private void btQuitar_Click(object sender, EventArgs e)
        {
            if (dgvConfCuentas.SelectedRows.Count == 1)
            {                
                int n = dgvConfCuentas.SelectedRows[0].Index;
                //MessageBox.Show(dgvConfCuentas.Rows[n].Cells["dgvcTipo"].Value.GetType().ToString());
                dgvConfCuentas.Rows.RemoveAt(n);
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            int n = dgvTipos.SelectedCells[0].RowIndex;
            string numero = dgvTipos.Rows[n].Cells["dgvcNumConf"].Value.ToString();

            btAceptar.Text = "Modificar";
            btCancelar.Enabled = false;
            btAnadir.Enabled = false;
            btQuitar.Enabled = false;
            dgvCuentas.Enabled = false;            

            CargarCuentasConfiguracion(numero);

            dgvTipos.Enabled = true;
        }

        private void lnklbPlanCuentas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FPlanCuentas pc = new FPlanCuentas(permiso0, permiso1, permiso2, permiso3, permiso4);
            pc.ShowDialog();
            CargarPlanCuentas();
        }

        private void dgvConfCuentas_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            decimal CantidadNuevaDePorcentaje;
            this.dgvConfCuentas.Rows[e.RowIndex].ErrorText = "";
            if (this.dgvConfCuentas.Rows[e.RowIndex].IsNewRow) { return; }

            if (this.dgvConfCuentas.IsCurrentCellDirty) 
            {
                switch (this.dgvConfCuentas.Columns[e.ColumnIndex].Name)
                {

                    case "DGCPorcentajeMontoTotalDH":
                        if (e.FormattedValue.ToString().Trim().Length < 1)
                        {
                            this.dgvConfCuentas.Rows[e.RowIndex].ErrorText = "   La Cantidad de Porcentaje es necesaria y no puede estar vacia.";
                            e.Cancel = true;
                        }
                        else if (!decimal.TryParse(e.FormattedValue.ToString(), out CantidadNuevaDePorcentaje) || CantidadNuevaDePorcentaje <= 0)
                        {
                            this.dgvConfCuentas.Rows[e.RowIndex].ErrorText = "   La Cantidad de Porcentaje debe ser un entero positivo.";
                            e.Cancel = true;
                            return;
                        }
                        else if (CantidadNuevaDePorcentaje > 100)
                        {
                            this.dgvConfCuentas.Rows[e.RowIndex].ErrorText = "   La Cantidad de Porcentaje no debe superar el 100%.";
                            e.Cancel = true;
                            return;
                        }
                        
                        break;

                }

            }
        }

    }

    class TipoDebeHaber
    {
        public string TipoCuentaDebeHaber { get; set; }
        public string NombreTipoCuentaDebeHaber { get; set; }
        public string ValueMember { get { return "TipoCuentaDebeHaber"; } }
        public string DisplayMember { get { return "NombreTipoCuentaDebeHaber"; } }

        public TipoDebeHaber()
        {
        }
        public TipoDebeHaber(string TipoCuentaDebeHaber, string NombreTipoCuentaDebeHaber)
        {
            this.TipoCuentaDebeHaber = TipoCuentaDebeHaber;
            this.NombreTipoCuentaDebeHaber = NombreTipoCuentaDebeHaber;
        }

        public List<TipoDebeHaber> obtenerLista()
        {
            List<TipoDebeHaber> listaDebeHaber = new List<TipoDebeHaber>();
            listaDebeHaber.Add(new TipoDebeHaber("D","DEBE"));
            listaDebeHaber.Add(new TipoDebeHaber("H", "HABER"));
            return listaDebeHaber;
        }

    }
}