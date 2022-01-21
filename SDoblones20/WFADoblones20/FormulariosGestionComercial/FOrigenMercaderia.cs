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
    public partial class FOrigenMercaderia : Form
    {
        
        DSDoblones20GestionComercial2.OrigenMercaderiasDataTable DTOrigenMercaderia;
        OrigenMercaderiaCLN _OrigenMercaderiaCLN;
        TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;
        string TipoOperacion = "";
        public bool esParaAgregar = false;
        public byte CodigoOrigenMercaderia { get; set; }
        public FOrigenMercaderia()
        {
            InitializeComponent();
            _OrigenMercaderiaCLN = new OrigenMercaderiaCLN();
            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();

        }



        private void FMediosTransportes_Load(object sender, EventArgs e)
        {

            DGCCodigoOrigenMercaderia.Width = 65;
            DGCNombreOrigenMercaderia.Width = 200;

            DTOrigenMercaderia = _OrigenMercaderiaCLN.ListarOrigenMercaderias();
            bdSourceMediosTransporte.DataSource = DTOrigenMercaderia;
            dtGVOrigenMercaderia.DataSource = bdSourceMediosTransporte;
            DTOrigenMercaderia.CodigoOrigenMercaderiaColumn.ReadOnly = false;

            if (!esParaAgregar)
            {
                if (DTOrigenMercaderia.Count > 0)
                {
                    dtGVOrigenMercaderia.Enabled = true;

                    tBCodigo.Text = DTOrigenMercaderia[0].CodigoOrigenMercaderia.ToString();
                    tBDescripcion.Text = DTOrigenMercaderia[0].Descripcion;
                    tBNombre.Text = DTOrigenMercaderia[0].NombreOrigenMercaderia;
                    habilitarBotones(true, true, true, false, false);

                    dtGVOrigenMercaderia.Rows[0].Selected = true;
                }
                else
                {
                    //dtGVOrigenMercaderia.Enabled = false;
                    habilitarBotones(true, false, false, false, false);
                }
                habilitarCampos(false);
            }
            else
            {
                limpiarCampos();
                tBNombre.Focus();
                habilitarBotones(false, false, false, true, true);
                TipoOperacion = "N";
            }
        }

        public void habilitarCampos(bool habilitar)
        {
            tBDescripcion.ReadOnly = !habilitar;
            tBNombre.ReadOnly = !habilitar;
        }

        public void limpiarCampos()
        {
            tBCodigo.Clear();
            tBDescripcion.Clear();
            tBNombre.Clear();
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
            tBNombre.Focus();
            habilitarBotones(false, false, false, true, true);
        }

        private void bEditar_Click(object sender, EventArgs e)
        {
            TipoOperacion = "E";
            habilitarCampos(true);
            tBNombre.Focus();
            tBNombre.SelectAll();
            habilitarBotones(false, false, false, true, true);
        }

        private void bEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Esta seguro de Eliminar este registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                byte CodigoTipoGasto = DTOrigenMercaderia[dtGVOrigenMercaderia.CurrentRow.Index].CodigoOrigenMercaderia;
                try
                {
                    _OrigenMercaderiaCLN.EliminarOrigenMercaderia(CodigoTipoGasto);
                    DSDoblones20GestionComercial2.OrigenMercaderiasRow DREliminado = DTOrigenMercaderia.FindByCodigoOrigenMercaderia(CodigoTipoGasto);
                    DTOrigenMercaderia[DTOrigenMercaderia.Rows.IndexOf(DREliminado)].Delete();
                    DTOrigenMercaderia.AcceptChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show(this, "No se pudo eliminar el registro. Probablmente esta siendo Utilizado por otros registros del Sistema", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            MessageBox.Show(this, "Registro eliminado correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            habilitarBotones(true, DTOrigenMercaderia.Count > 0 ? true : false, DTOrigenMercaderia.Count > 0 ? true : false, false, false);
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tBNombre.Text.Trim()))
            {
                MessageBox.Show("No Puede dejar el Nombre del Gasto en Blanco");
                tBNombre.Focus();
                tBNombre.SelectAll();
                return;
            }
            try
            {
                if (TipoOperacion == "N")
                {
                    _OrigenMercaderiaCLN.InsertarOrigenMercaderia(tBNombre.Text.Trim(), tBDescripcion.Text.Trim());
                    DTOrigenMercaderia.AddOrigenMercaderiasRow(0, tBNombre.Text.Trim(), tBDescripcion.Text.Trim());
                    CodigoOrigenMercaderia = (byte)_TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("OrigenMercaderia");
                    DTOrigenMercaderia[DTOrigenMercaderia.Count - 1].CodigoOrigenMercaderia = CodigoOrigenMercaderia;

                }
                else if (TipoOperacion == "E")
                {
                    _OrigenMercaderiaCLN.ActualizarOrigenMercaderia(DTOrigenMercaderia[dtGVOrigenMercaderia.CurrentRow.Index].CodigoOrigenMercaderia, tBNombre.Text.Trim(), tBDescripcion.Text.Trim());
                    DTOrigenMercaderia[dtGVOrigenMercaderia.CurrentRow.Index].NombreOrigenMercaderia = tBNombre.Text.Trim();
                    DTOrigenMercaderia[dtGVOrigenMercaderia.CurrentRow.Index].Descripcion = tBDescripcion.Text.Trim();
                    DTOrigenMercaderia.AcceptChanges();

                }
                
                if (esParaAgregar)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Se realizo correctamente la Operación Actual");
                    TipoOperacion = "";
                    habilitarBotones(true, true, true, false, false);
                    habilitarCampos(false);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, "No se Pudo Realizar la Operación Actual", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            if (esParaAgregar)
            {
                this.bCancelar.DialogResult = System.Windows.Forms.DialogResult.None;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            limpiarCampos();
            bdSourceMediosTransporte.MoveLast();
            habilitarBotones(true, DTOrigenMercaderia.Count > 0 ? true : false, DTOrigenMercaderia.Count > 0 ? true : false, false, false);
            habilitarCampos(false);
        }

        private void bCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtGVOrigenMercaderia_SelectionChanged(object sender, EventArgs e)
        {
            if (DTOrigenMercaderia.Count > 0 && dtGVOrigenMercaderia.CurrentRow != null)
            {
                tBCodigo.Text = DTOrigenMercaderia[dtGVOrigenMercaderia.CurrentRow.Index].CodigoOrigenMercaderia.ToString();
                tBDescripcion.Text = DTOrigenMercaderia[dtGVOrigenMercaderia.CurrentRow.Index].IsDescripcionNull() ? "" : DTOrigenMercaderia[dtGVOrigenMercaderia.CurrentRow.Index].Descripcion;
                tBNombre.Text = DTOrigenMercaderia[dtGVOrigenMercaderia.CurrentRow.Index].NombreOrigenMercaderia;
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

        private void FOrigenMercaderia_Shown(object sender, EventArgs e)
        {
            tBNombre.Focus();
        }

    }
}
