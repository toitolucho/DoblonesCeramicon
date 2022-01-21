using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCAD;
using CLCLN.GestionComercial;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FProductosTiposGarantias : Form
    {
        DSDoblones20GestionComercial2.ProductosTiposGarantiasDataTable DTTiposGarantias;
        ProductosTiposGarantiasCLN _ProductosTiposGarantiasCLN;
        TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;
        string TipoOperacion = "";
        public FProductosTiposGarantias()
        {
            InitializeComponent();

            _ProductosTiposGarantiasCLN = new ProductosTiposGarantiasCLN();
            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();
            DTTiposGarantias = new DSDoblones20GestionComercial2.ProductosTiposGarantiasDataTable();

            DTTiposGarantias = _ProductosTiposGarantiasCLN.ListarProductosTiposGarantias();
            bindingSourceTiposGarantias.DataSource = DTTiposGarantias;

            habilitarControles(false);
            habilitarBotones(true, false, false, false, false);
            tabControl1.SelectedTab = tabPageDatos;

        }

        public void cargarTipoGarantia(int CodigoTipoGarantia)
        {
            DSDoblones20GestionComercial2.ProductosTiposGarantiasDataTable DTAuxiliar;
            DTAuxiliar = _ProductosTiposGarantiasCLN.ObtenerProductoTipoGarantia(CodigoTipoGarantia);
            if (DTAuxiliar.Count >= 0)
            {
                txtBoxCodigo.Text = DTAuxiliar[0].CodigoTipoGarantia.ToString();
                txtBoxNombre.Text = DTAuxiliar[0].NombreTipoGarantia;
                txtBoxDescripcion.Text = DTAuxiliar[0].IsDescripcionNull() ? "" : DTAuxiliar[0].Descripcion;

                habilitarBotones(true, true, false, false, true);
                tabControl1.SelectedTab = tabPageDatos;
            }
            else
            {
                habilitarControles(false);
                habilitarBotones(true, false, false, false, false);
            }
        }

        public void habilitarControles(bool estadoHabilitacion)
        {
            this.txtBoxDescripcion.ReadOnly = !estadoHabilitacion;
            this.txtBoxNombre.ReadOnly = !estadoHabilitacion;
        }

        public void habilitarBotones(bool nuevo, bool editar, bool cancelar, bool aceptar, bool eliminar)
        {
            this.bNuevo.Enabled = nuevo;
            this.bEditar.Enabled = editar;
            this.bCancelar.Enabled = cancelar;
            this.bAceptar.Enabled = aceptar;
            this.bEliminar.Enabled = eliminar;
        }

        public void limpiarControles()
        {
            this.txtBoxCodigo.Text = "";
            this.txtBoxDescripcion.Text = "";
            this.txtBoxNombre.Text = "";
        }
        private void bNuevo_Click(object sender, EventArgs e)
        {
            limpiarControles();
            habilitarControles(true);
            habilitarBotones(false, false, true, true, false);
            txtBoxNombre.Focus();
            TipoOperacion = "N";
        }

        private void bEditar_Click(object sender, EventArgs e)
        {
            TipoOperacion = "E";
            habilitarControles(true);
            habilitarBotones(false, false, true, true, false);
            txtBoxNombre.Focus();
        }

        private void bEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Se encuentra seguro de eliminar el Registor Actual?", "Registro de Tipos de Garantias", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            try
            {
                int CodigoTipoGarantia = -1;
                if (int.TryParse(txtBoxCodigo.Text, out CodigoTipoGarantia))
                {
                    _ProductosTiposGarantiasCLN.EliminarProductoTipoGarantia(CodigoTipoGarantia);
                    if (DTTiposGarantias.FindByCodigoTipoGarantia((byte)CodigoTipoGarantia) != null)
                    {
                        DTTiposGarantias.Rows.Remove(DTTiposGarantias.FindByCodigoTipoGarantia((byte)CodigoTipoGarantia));
                    }
                    limpiarControles();
                    MessageBox.Show(this, "Se Elimino correctamente el Registro Actual", "Tipos de Garantias", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Ocurrió la Siguiente Excepción " + ex.Message, "Tipos de Garantias", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBoxNombre.Text))
            {
                try
                {
                    int CodigoTipoGarantia = -1;
                    if (TipoOperacion == "N")
                    {
                        _ProductosTiposGarantiasCLN.InsertarProductoTipoGarantia(txtBoxNombre.Text, txtBoxDescripcion.Text);
                        CodigoTipoGarantia = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("ProductosTiposGarantias");
                        txtBoxCodigo.Text = CodigoTipoGarantia.ToString();
                        DTTiposGarantias.AddProductosTiposGarantiasRow((byte)CodigoTipoGarantia, txtBoxNombre.Text, txtBoxDescripcion.Text);
                        DTTiposGarantias.AcceptChanges();
                        
                    }
                    else if (TipoOperacion == "E" && int.TryParse(txtBoxCodigo.Text, out CodigoTipoGarantia))
                    {
                        _ProductosTiposGarantiasCLN.ActualizarProductoTipoGarantia(CodigoTipoGarantia, txtBoxNombre.Text, txtBoxDescripcion.Text);
                        DSDoblones20GestionComercial2.ProductosTiposGarantiasRow TipoGarantia = DTTiposGarantias.FindByCodigoTipoGarantia((byte)CodigoTipoGarantia);
                        TipoGarantia.NombreTipoGarantia = txtBoxNombre.Text;
                        TipoGarantia.Descripcion = txtBoxDescripcion.Text;
                        TipoGarantia.AcceptChanges();
                        DTTiposGarantias.AcceptChanges();

                    }
                    habilitarControles(false);
                    habilitarBotones(true, true, false, false, true);
                    
                    MessageBox.Show(this, "Se Actualizó correctamente el Registro Actual", "Tipos de Garantias", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Ocurrió la Siguiente Excepción " + ex.Message, "Tipos de Garantias", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                }
            }
            else
            {
                MessageBox.Show(this, "No puede dejar en Blanco el Nombre", "Tipos de Garantias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            if (DTTiposGarantias.Count > 0 && dtGVTiposGarantias.CurrentCell != null)
            {
                cargarTipoGarantia(DTTiposGarantias[dtGVTiposGarantias.CurrentCell.RowIndex].CodigoTipoGarantia);
            }
            else
            {
                limpiarControles();
                habilitarBotones(true, false, false, false, false);
                habilitarControles(false);
            }
        }

        private void bCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtGVTiposGarantias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtGVTiposGarantias.CurrentCell != null)
            {
                cargarTipoGarantia(DTTiposGarantias[e.RowIndex].CodigoTipoGarantia);
            }
        }
    }
}
