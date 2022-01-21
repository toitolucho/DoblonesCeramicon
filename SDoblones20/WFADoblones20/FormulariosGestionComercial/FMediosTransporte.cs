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
    public partial class FMediosTransporte : Form
    {
        DSDoblones20GestionComercial2.MediosTransportesDataTable DTMediosTransportes;
        MedioTransporteCLN _MedioTransporteCLN;
        TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;
        string TipoOperacion = "";
        public bool esParaAgregar = false;
        public byte CodigoMedioTransporte { get; set; }
        public FMediosTransporte()
        {
            InitializeComponent();
            _MedioTransporteCLN = new MedioTransporteCLN();
            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();

        }



        private void FMediosTransportes_Load(object sender, EventArgs e)
        {

            DGCCodigoMedioTransporte.Width = 65;
            DGCNombreMedioTransporte.Width = 200;

            DTMediosTransportes = _MedioTransporteCLN.ListarMedioTransportes();
            bdSourceMediosTransporte.DataSource = DTMediosTransportes;
            dtGVMedioTransporte.DataSource = bdSourceMediosTransporte;
            DTMediosTransportes.CodigoMedioTransporteColumn.ReadOnly = false;
            
            if (!esParaAgregar)
            {
                if (DTMediosTransportes.Count > 0)
                {
                    dtGVMedioTransporte.Enabled = true;

                    tBCodigo.Text = DTMediosTransportes[0].CodigoMedioTransporte.ToString();
                    tBDescripcion.Text = DTMediosTransportes[0].Descripcion; 
                    tBNombre.Text = DTMediosTransportes[0].NombreMedioTransporte;
                    habilitarBotones(true, true, true, false, false);

                    dtGVMedioTransporte.Rows[0].Selected = true;
                }
                else
                {
                    //dtGVMedioTransporte.Enabled = false;
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
                byte CodigoTipoGasto = DTMediosTransportes[dtGVMedioTransporte.CurrentRow.Index].CodigoMedioTransporte;
                try
                {
                    _MedioTransporteCLN.EliminarMedioTransporte(CodigoTipoGasto);
                    DSDoblones20GestionComercial2.MediosTransportesRow DREliminado = DTMediosTransportes.FindByCodigoMedioTransporte(CodigoTipoGasto);
                    DTMediosTransportes[DTMediosTransportes.Rows.IndexOf(DREliminado)].Delete();
                    DTMediosTransportes.AcceptChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show(this, "No se pudo eliminar el registro. Probablmente esta siendo Utilizado por otros registros del Sistema", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            MessageBox.Show(this, "Registro eliminado correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            habilitarBotones(true, DTMediosTransportes.Count > 0 ? true : false, DTMediosTransportes.Count > 0 ? true : false, false, false);
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
                    _MedioTransporteCLN.InsertarMedioTransporte(tBNombre.Text.Trim(), tBDescripcion.Text.Trim());
                    DTMediosTransportes.AddMediosTransportesRow(0,tBNombre.Text.Trim(), tBDescripcion.Text.Trim());
                    CodigoMedioTransporte = (byte)_TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("MedioTransporte");
                    DTMediosTransportes[DTMediosTransportes.Count - 1].CodigoMedioTransporte = CodigoMedioTransporte;


                }
                else if (TipoOperacion == "E")
                {
                    _MedioTransporteCLN.ActualizarMedioTransporte(DTMediosTransportes[dtGVMedioTransporte.CurrentRow.Index].CodigoMedioTransporte, tBNombre.Text.Trim(), tBDescripcion.Text.Trim());
                    DTMediosTransportes[dtGVMedioTransporte.CurrentRow.Index].NombreMedioTransporte= tBNombre.Text.Trim();
                    DTMediosTransportes[dtGVMedioTransporte.CurrentRow.Index].Descripcion = tBDescripcion.Text.Trim();
                    DTMediosTransportes.AcceptChanges();

                }

                if (esParaAgregar)
                {
                    this.bCerrar.DialogResult = System.Windows.Forms.DialogResult.None;
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
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
                return;
            }
            limpiarCampos();
            bdSourceMediosTransporte.MoveLast();
            habilitarBotones(true, DTMediosTransportes.Count > 0 ? true : false, DTMediosTransportes.Count > 0 ? true : false, false, false);
            habilitarCampos(false);
        }

        private void bCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtGVMedioTransporte_SelectionChanged(object sender, EventArgs e)
        {
            if (DTMediosTransportes.Count > 0 && dtGVMedioTransporte.CurrentRow != null)
            {
                tBCodigo.Text = DTMediosTransportes[dtGVMedioTransporte.CurrentRow.Index].CodigoMedioTransporte.ToString();
                tBDescripcion.Text = DTMediosTransportes[dtGVMedioTransporte.CurrentRow.Index].IsDescripcionNull() ? "" : DTMediosTransportes[dtGVMedioTransporte.CurrentRow.Index].Descripcion; 
                tBNombre.Text = DTMediosTransportes[dtGVMedioTransporte.CurrentRow.Index].NombreMedioTransporte;
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

        private void FMediosTransporte_Shown(object sender, EventArgs e)
        {
            tBNombre.Focus();
        }

    }
}
