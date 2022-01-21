using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.Sistema;
namespace WFADoblones20.FormulariosSistema
{
    public partial class FSistemasInterfaces : Form
    {

        CLCLN.Sistema.SistemasInterfacesCLN _SistemasInterfacesCLN = null;
        DataTable DTSistemasInterfaces = null;
        
        public FSistemasInterfaces()
        {
            InitializeComponent();
            _SistemasInterfacesCLN = new SistemasInterfacesCLN();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTextoBusqueda.Text))
            {
                MessageBox.Show("Aun no ha ingresado un Parametro de Busqueda");
                txtTextoBusqueda.Focus();
                txtTextoBusqueda.SelectAll();
                return;
            }

            DTSistemasInterfaces = _SistemasInterfacesCLN.BuscarSistemasInterfaz(cBoxBuscarPor.SelectedIndex.ToString(), txtTextoBusqueda.Text, checkExactamenteIgual.Checked);
            if (DTSistemasInterfaces.Rows.Count > 0)
            {
                dtGVListadoInterfaces.DataSource = DTSistemasInterfaces;
                habilitarBotones(true, true, true, true);
                toolStripStatusLabel2.Text = DTSistemasInterfaces.Rows.Count.ToString();
            }
            else
            {
                MessageBox.Show("no se encontraron registro con la descripción dada");
                habilitarBotones(true, false, true, false);
                toolStripStatusLabel2.Text = "0";
            }
            txtTextoBusqueda.Focus();
            txtTextoBusqueda.SelectAll();
        }

        public void habilitarBotones(bool nuevo, bool eliminar, bool reporte, bool editar)
        {
            this.btnEditar.Enabled = editar;
            this.btnEliminar.Enabled = eliminar;
            this.btnNuevo.Enabled = nuevo;
            this.btnReporte.Enabled = reporte;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FIAInterfacesSistemas finsertarSistema = new FIAInterfacesSistemas(-1, null, null, null, 'I');
            finsertarSistema.ShowDialog(this);            
            finsertarSistema.Dispose();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            DataGridViewCellEventArgs es;
            if (dtGVListadoInterfaces.RowCount > 0)
                es = new DataGridViewCellEventArgs(dtGVListadoInterfaces.CurrentCell.ColumnIndex, dtGVListadoInterfaces.CurrentCell.RowIndex);
            else
            {
                es = new DataGridViewCellEventArgs(-1, -1);
            }
            dtGVListadoInterfaces_CellDoubleClick(sender, es);           
        }

        private void dtGVListadoInterfaces_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int codigo = int.Parse( DTSistemasInterfaces.Rows[e.RowIndex]["CodigoInterface"].ToString());
            string NombreInterface = DTSistemasInterfaces.Rows[e.RowIndex]["NombreInterface"].ToString();
            string TextoInterface = DTSistemasInterfaces.Rows[e.RowIndex]["TextoInterface"].ToString();
            string CodigoTipoInterface = DTSistemasInterfaces.Rows[e.RowIndex]["CodigoTipoInterface"].ToString();

            FIAInterfacesSistemas finsertarSistema = new FIAInterfacesSistemas(codigo, NombreInterface, TextoInterface, CodigoTipoInterface, 'E');
            finsertarSistema.ShowDialog(this);
            if (finsertarSistema.accionCompletada)
            {
                DataRow filaEncontrada = DTSistemasInterfaces.Rows.Find(codigo);
                if (filaEncontrada != null)
                {
                    filaEncontrada["CodigoInterface"] = finsertarSistema.CodigoInterfaz;
                    filaEncontrada["NombreInterface"] = finsertarSistema.NombreInterfaz;
                    filaEncontrada["TextoInterface"] = finsertarSistema.TextoInterfaz;
                    filaEncontrada["CodigoTipoInterface"] = finsertarSistema.CodigoTipoInterfaz;

                    filaEncontrada.AcceptChanges();
                    DTSistemasInterfaces.AcceptChanges();
                }
            }
            finsertarSistema.Dispose();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dtGVListadoInterfaces.RowCount > 0 && dtGVListadoInterfaces.CurrentRow != null)
            {
                byte CodigoInterface = byte.Parse(DTSistemasInterfaces.Rows[dtGVListadoInterfaces.CurrentCell.RowIndex]["CodigoInterface"].ToString());
                try
                {
                    if (_SistemasInterfacesCLN.EliminarSistemaInteraz(CodigoInterface))
                    {
                        DataRow filaElimnar = DTSistemasInterfaces.Rows.Find(CodigoInterface);
                        if (filaElimnar != null)
                            DTSistemasInterfaces.Rows.Remove(filaElimnar);
                        DTSistemasInterfaces.AcceptChanges();
                        MessageBox.Show("Se eliminó correctamente el registro");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocururrio el Siguiente Error " + ex.Message);                    
                }
            }
        }
    }
}
