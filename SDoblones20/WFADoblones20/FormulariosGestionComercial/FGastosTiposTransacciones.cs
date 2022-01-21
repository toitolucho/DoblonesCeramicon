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
    public partial class FGastosTiposTransacciones : Form
    {
        DSDoblones20GestionComercial.GastosTiposTransaccionesDataTable DTGastosTipos;
        GastosTiposTransaccionesCLN _GastosTiposTransaccionesCLN;
        TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;
        string TipoOperacion = "";
        bool esParaAgregar = false;
        public FGastosTiposTransacciones()
        {
            InitializeComponent();
            _GastosTiposTransaccionesCLN = new GastosTiposTransaccionesCLN();
            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();
            
        }

        

        private void FGastosTiposTransacciones_Load(object sender, EventArgs e)
        {

            DGCCodigoGastosTipos.Width = 65;
            DGCNombreGasto.Width = 200;

            DTGastosTipos = _GastosTiposTransaccionesCLN.ListarGastosTiposTransacciones();
            bdSourceGastosTipos.DataSource = DTGastosTipos;
            dtGVGastosTipos.DataSource = bdSourceGastosTipos;
            DTGastosTipos.CodigoGastosTiposColumn.ReadOnly = false;
            //txtBoxCodigoTipoGasto.DataBindings.Add(new Binding("Text", bdSourceGastosTipos, "CodigoGastosTipos", true));
            //txtBoxDescripcionTipoGasto.DataBindings.Add(new Binding("Text", bdSourceGastosTipos, "DescripcionGasto", true));
            //txtBoxNombreTipoGasto.DataBindings.Add(new Binding("Text", bdSourceGastosTipos, "NombreGasto", true));



            if (!esParaAgregar)
            {
                if (DTGastosTipos.Count > 0)
                {
                    dtGVGastosTipos.Enabled = true;

                    txtBoxCodigoTipoGasto.Text = DTGastosTipos[0].CodigoGastosTipos.ToString();
                    txtBoxDescripcionTipoGasto.Text = DTGastosTipos[0].DescripcionGasto;
                    txtBoxNombreTipoGasto.Text = DTGastosTipos[0].NombreGasto;
                    habilitarBotones(true, true, true, false, false);

                    dtGVGastosTipos.Rows[0].Selected = true;
                }
                else
                {
                    //dtGVGastosTipos.Enabled = false;
                    habilitarBotones(true, false, false, false, false);
                }
                habilitarCampos(false);
            }
            else
            {
                limpiarCampos();
                txtBoxNombreTipoGasto.Focus();                
            }
        }

        public void habilitarCampos(bool habilitar)
        {
            txtBoxDescripcionTipoGasto.ReadOnly = !habilitar;
            txtBoxNombreTipoGasto.ReadOnly = !habilitar;
        }

        public void limpiarCampos()
        {
            txtBoxCodigoTipoGasto.Clear();
            txtBoxDescripcionTipoGasto.Clear();
            txtBoxNombreTipoGasto.Clear();
        }

        public void habilitarBotones(bool nuevo, bool editar, bool eliminar, bool guardar, bool cancelar)
        {
            this.bNuevo.Enabled = nuevo;
            this.bEditar.Enabled = editar;
            this.bEliminar.Enabled = eliminar;
            this.bAceptar.Enabled = guardar;
            this.bCancelar.Enabled = cancelar;
        }

        private void bNuevo_Click(object sender, EventArgs e)
        {
            TipoOperacion = "N";
            habilitarCampos(true);
            limpiarCampos();
            txtBoxNombreTipoGasto.Focus();
            habilitarBotones(false, false, false, true, true);            
        }

        private void bEditar_Click(object sender, EventArgs e)
        {
            TipoOperacion = "E";
            habilitarCampos(true);
            txtBoxNombreTipoGasto.Focus();
            txtBoxNombreTipoGasto.SelectAll();
            habilitarBotones(false, false, false, true, true);
        }

        private void bEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Esta seguro de Eliminar este registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int CodigoTipoGasto = DTGastosTipos[dtGVGastosTipos.CurrentRow.Index].CodigoGastosTipos;
                try
                {
                    _GastosTiposTransaccionesCLN.EliminarGastoTipoTransaccion(CodigoTipoGasto);
                     DSDoblones20GestionComercial.GastosTiposTransaccionesRow DREliminado = DTGastosTipos.FindByCodigoGastosTipos(CodigoTipoGasto);
                    DTGastosTipos[DTGastosTipos.Rows.IndexOf(DREliminado)].Delete();
                    DTGastosTipos.AcceptChanges();
                }
                catch (Exception )
                {
                    MessageBox.Show(this, "No se pudo eliminar el registro. Probablmente esta siendo Utilizado por otros registros del Sistema", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                }
            }
            MessageBox.Show(this, "Registro eliminado correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            habilitarBotones(true, DTGastosTipos.Count > 0 ? true : false, DTGastosTipos.Count > 0 ? true : false, false, false);
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxNombreTipoGasto.Text.Trim()))
            {
                MessageBox.Show("No Puede dejar el Nombre del Gasto en Blanco");
                txtBoxNombreTipoGasto.Focus();
                txtBoxNombreTipoGasto.SelectAll();
                return;
            }            
            try
            {
                if (TipoOperacion == "N")
                {
                    _GastosTiposTransaccionesCLN.InsertarGastoTipoTransaccion(txtBoxNombreTipoGasto.Text.Trim(), txtBoxDescripcionTipoGasto.Text.Trim());
                    DTGastosTipos.AddGastosTiposTransaccionesRow(txtBoxNombreTipoGasto.Text.Trim(), txtBoxDescripcionTipoGasto.Text.Trim());
                    int indice = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("GastosTiposTransacciones");
                    DTGastosTipos[DTGastosTipos.Count - 1].CodigoGastosTipos = indice;
                    
                }
                else if (TipoOperacion == "E")
                {                    
                    _GastosTiposTransaccionesCLN.ActualizarGastoTipoTransaccion(DTGastosTipos[dtGVGastosTipos.CurrentRow.Index].CodigoGastosTipos, txtBoxNombreTipoGasto.Text.Trim(), txtBoxDescripcionTipoGasto.Text.Trim());
                    DTGastosTipos[dtGVGastosTipos.CurrentRow.Index].NombreGasto = txtBoxNombreTipoGasto.Text.Trim();
                    DTGastosTipos[dtGVGastosTipos.CurrentRow.Index].DescripcionGasto = txtBoxDescripcionTipoGasto.Text.Trim();
                    DTGastosTipos.AcceptChanges();
                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, "No se Pudo Realizar la Operación Actual", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);                    
            }

            MessageBox.Show("Se realizo correctamente la Operación Actual");
            TipoOperacion = "";
            habilitarBotones(true, true, true, false, false);
            habilitarCampos(false);
            if (esParaAgregar)
                this.Close();
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            bdSourceGastosTipos.MoveLast();
            habilitarBotones(true, DTGastosTipos.Count > 0 ? true : false, DTGastosTipos.Count > 0 ? true : false, false, false);
            habilitarCampos(false);
        }

        private void bCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtGVGastosTipos_SelectionChanged(object sender, EventArgs e)
        {
            if (DTGastosTipos.Count > 0 && dtGVGastosTipos.CurrentRow != null) 
            {
                txtBoxCodigoTipoGasto.Text = DTGastosTipos[dtGVGastosTipos.CurrentRow.Index].CodigoGastosTipos.ToString();
                txtBoxDescripcionTipoGasto.Text = DTGastosTipos[dtGVGastosTipos.CurrentRow.Index].DescripcionGasto;
                txtBoxNombreTipoGasto.Text = DTGastosTipos[dtGVGastosTipos.CurrentRow.Index].NombreGasto;
            }
        }

        public void habilitarOpcionesParaInsercion(EventArgs evento)
        {
            tabControl1.SelectedTab = tabPage1;
            tabControl1.Controls[1].Enabled = false;
            bEditar.Visible = false;
            bEliminar.Visible = false;
            esParaAgregar = true;
            bNuevo_Click(bNuevo, evento);
        }
        
    }
}
