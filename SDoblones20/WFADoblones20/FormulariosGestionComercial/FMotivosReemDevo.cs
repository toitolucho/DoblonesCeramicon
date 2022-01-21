using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.Sistema;
using System.Collections;
namespace WFADoblones20.FormulariosGestionComercial

{
    public partial class FMotivosReemDevo : Form
    {
        private MotivosReemDevoCLN MotivosReemDevo = new MotivosReemDevoCLN();
        private string TipoOperacion = "";
        private DataTable DTAuxiliar = new DataTable();
        string TipoTransaccion = "V";
        public FMotivosReemDevo()
        {
            InitializeComponent();
        }

        private void FMotivosReemDevo_Load(object sender, EventArgs e)
        {
            bAceptar.Enabled = false;
            bCancelar.Enabled = false;

            InhabilitarControles(true);

            DTAuxiliar = MotivosReemDevo.ListarMotivosReemDevo();
            bSOrigen.DataSource = DTAuxiliar;

            //dGVGrilla.DataSource = DTAuxiliar;
            dGVGrilla.AutoGenerateColumns = false;

            ArrayList ListaEstadosRetorno = new ArrayList();
            //'A','B','R','V','N')),-- 'A' -> Alta, 'B'->Baja, 'R'-> Reparación ,'V'-> Vendido, 'N'->Ninguna
            ListaEstadosRetorno.Add(new EstadoRetornoInventario("A", "ALTA"));
            ListaEstadosRetorno.Add(new EstadoRetornoInventario("B", "BAJA"));
            ListaEstadosRetorno.Add(new EstadoRetornoInventario("R", "REPARACION"));
            ListaEstadosRetorno.Add(new EstadoRetornoInventario("N", "NINGUNO"));            

            cboxEstadoRetornoInventario.DataSource = ListaEstadosRetorno;
            cboxEstadoRetornoInventario.DisplayMember = "DescripcionRetorno";
            cboxEstadoRetornoInventario.ValueMember = "CodigoRetorno";
        }

        private void bCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InhabilitarControles(bool Estado)
        {
            //tBCodigo.ReadOnly = Estado;
            tBNombre.ReadOnly = Estado;
            cboxEstadoRetornoInventario.Enabled = !Estado;
            gBoxTipoTransaccion.Enabled = !Estado;
        }

        private void InicializarControles()
        {
            tBCodigo.Text = "";
            tBNombre.Text = "";
            cboxEstadoRetornoInventario.SelectedIndex = 0;
        }

        private void bNuevo_Click(object sender, EventArgs e)
        {
            TipoOperacion = "I";

            InhabilitarControles(false);
            InicializarControles();
            bNuevo.Enabled = false;
            bEditar.Enabled = false;
            bEliminar.Enabled = false;
            bAceptar.Enabled = true;
            bCancelar.Enabled = true;

            tBNombre.Focus();
        }

        private void bEditar_Click(object sender, EventArgs e)
        {
            TipoOperacion = "E";
            InhabilitarControles(false);
            bNuevo.Enabled = false;
            bEditar.Enabled = false;
            bEliminar.Enabled = false;
            bAceptar.Enabled = true;
            bCancelar.Enabled = true;
        }

        private void bEliminar_Click(object sender, EventArgs e)
        {
            string Mensaje = "Esta seguro que desea eliminar el registro actual, recuerde que una vez aceptada la operacion es irreversible.";
            string Titulo = "Confimarción eliminación registro";
            MessageBoxButtons Botones = MessageBoxButtons.YesNo;
            MessageBoxIcon Icono = MessageBoxIcon.Exclamation;
            DialogResult result;

            result = MessageBox.Show(Mensaje, Titulo, Botones, Icono);

            if (result == DialogResult.Yes)
            {
                if (tBCodigo.Text == "")
                {
                    MessageBox.Show("No se ha seleccionado ningun elemento para eliminarlo");

                }
                else
                {
                    MotivosReemDevo.EliminarMotivoReemDevo(int.Parse(tBCodigo.Text));
                    DTAuxiliar = MotivosReemDevo.ListarMotivosReemDevo();
                    bSOrigen.DataSource = DTAuxiliar;
                }
                InhabilitarControles(true);
                InicializarControles();
                bNuevo.Enabled = true;
                bEditar.Enabled = true;
                bEliminar.Enabled = true;
                bAceptar.Enabled = false;
                bCancelar.Enabled = false;
            }
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            if (rBtnCompra.Checked)
                TipoTransaccion = "C";
            else if (rBtnDevolucion.Checked)
                TipoTransaccion = "D";
            else if (rBtnVenta.Checked)
                TipoTransaccion = "V";

            if (TipoOperacion == "I")
            {                
                MotivosReemDevo.InsertarMotivoReemDevo(tBNombre.Text, cboxEstadoRetornoInventario.SelectedValue.ToString(),TipoTransaccion); 

            }

            if (TipoOperacion == "E")
            {
                
                if (tBCodigo.Text == "")
                {
                    MessageBox.Show("No se ha seleccionado ningún elemento para editarlo");

                }
                else
                {
                    MotivosReemDevo.ActualizarMotivoReemDevo(int.Parse(tBCodigo.Text), tBNombre.Text, cboxEstadoRetornoInventario.SelectedValue.ToString(), TipoTransaccion);
                }
            }
            DTAuxiliar = MotivosReemDevo.ListarMotivosReemDevo();
            bSOrigen.DataSource = DTAuxiliar;
            InhabilitarControles(true);
            InicializarControles();
            bNuevo.Enabled = true;
            bEditar.Enabled = true;
            bEliminar.Enabled = true;
            bAceptar.Enabled = false;
            bCancelar.Enabled = false;
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            if (TipoOperacion == "I")
                InicializarControles();
            InhabilitarControles(true);
            bNuevo.Enabled = true;
            bEditar.Enabled = true;
            bEliminar.Enabled = true;
            bAceptar.Enabled = false;
            bCancelar.Enabled = false;
        }

        private void dGVGrilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = 0;
            fila = dGVGrilla.CurrentCell.RowIndex;
            if (fila >= 0)
            {
                tBCodigo.Text = DTAuxiliar.Rows[fila][0].ToString();
                tBNombre.Text = DTAuxiliar.Rows[fila][1].ToString();
                cboxEstadoRetornoInventario.SelectedValue = DTAuxiliar.Rows[e.RowIndex]["EstadoRetornoInventario"];
                switch (DTAuxiliar.Rows[e.RowIndex]["TipoTransaccion"].ToString())
                {
                    case "D":
                        rBtnDevolucion.Checked = true;
                        break;
                    case "C":
                        rBtnCompra.Checked = true;
                        break;
                    case "V":
                        rBtnVenta.Checked = true;
                        break;
                }
                /*FMonedasCotizacionesIA fmonedascotizacionesia = new FMonedasCotizacionesIA("E", byte.Parse(RBMonedasCotizaciones.Rows[fila][0].ToString()), byte.Parse(RBMonedasCotizaciones.Rows[fila][2].ToString()), DateTime.Parse(RBMonedasCotizaciones.Rows[fila][1].ToString()), decimal.Parse(RBMonedasCotizaciones.Rows[fila][4].ToString()), decimal.Parse(RBMonedasCotizaciones.Rows[fila][5].ToString()));
                fmonedascotizacionesia.ShowDialog();*/
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna elemento para editarlo");
            }
        }
    }


    public class EstadoRetornoInventario
    {
        private string _CodigoRetorno;
        public string CodigoRetorno
        {
            get { return _CodigoRetorno; }
            set { _CodigoRetorno = value; }
        }

        private string _DescripcionRetorno;
        public string DescripcionRetorno
        {
            get { return _DescripcionRetorno; }
            set { _DescripcionRetorno = value; }
        }

        public EstadoRetornoInventario(string codigo, string descripcion)
        {
            this.CodigoRetorno = codigo;
            this.DescripcionRetorno = descripcion;
        }

    }
}
