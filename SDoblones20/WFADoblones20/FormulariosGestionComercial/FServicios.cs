using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCAD.DSDoblones20GestionComercial2TableAdapters;
using CLCAD;
using CLCLN.GestionComercial;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FServicios : Form
    {
        ServiciosCLN _ServiciosCLN;
        TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;
        DSDoblones20GestionComercial2.ServiciosDataTable DTServicios;
        DSDoblones20GestionComercial2.ServiciosRow DRServicios;

        public int NumeroServicio { get; set; }
        public string TipoOperacion = "";
        bool esParaInsertar = false;

        public FServicios()
        {
            InitializeComponent();

            _ServiciosCLN = new ServiciosCLN();
            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();
            DTServicios = _ServiciosCLN.ObtenerServicio(-1);
            bindingSourceServicio.DataSource = DTServicios;
            dtGVServicios.DataSource = bindingSourceServicio;
        }

        private void FServicios_Load(object sender, EventArgs e)
        {
            txtBoxCodigoServicio.DataBindings.Add(new Binding("Text", bindingSourceServicio, "CodigoServicio"));
            txtBoxDescripcion.DataBindings.Add(new Binding("Text", bindingSourceServicio, "Descripcion"));
            txtBoxNombreServicio.DataBindings.Add(new Binding("Text", bindingSourceServicio, "NombreServicio"));
            txtBoxPrecioServicio.DataBindings.Add(new Binding("Text", bindingSourceServicio, "PrecioUnitario"));
            cBoxNombreServicio.DataBindings.Add(new Binding("SelectedValue", bindingSourceServicio, "CodigoTipoServicio"));

            cBoxNombreServicio.DataSource = TiposServicios.getListaServicios();
            cBoxNombreServicio.DisplayMember = TiposServicios.DisplayMember;
            cBoxNombreServicio.ValueMember = TiposServicios.ValueMember;
        }

        public void habilitarCampos(bool habilitar)
        {
            txtBoxNombreServicio.ReadOnly = !habilitar;
            txtBoxPrecioServicio.ReadOnly = !habilitar;
            txtBoxDescripcion.ReadOnly = !habilitar;
            cBoxNombreServicio.Enabled = habilitar;
        }

        public void limpiarCampos()
        {
            txtBoxNombreServicio.Text = String.Empty;
            txtBoxPrecioServicio.Text = String.Empty;
            txtBoxDescripcion.Text = String.Empty;
            txtBoxCodigoServicio.Text = String.Empty;
            cBoxNombreServicio.SelectedIndex = -1;
        }

        public void habilitarBotones(bool aceptar, bool cancelar, bool eliminar, bool editar, bool nuevo)
        {
            this.bAceptar.Enabled = aceptar;
            this.bCancelar.Enabled = cancelar;
            this.bEliminar.Enabled = eliminar;
            this.bEditar.Enabled = editar;
            this.bNuevo.Enabled = nuevo;
        }

        private void FServicios_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!String.IsNullOrEmpty(TipoOperacion) && (bAceptar.Enabled)
                && MessageBox.Show(this, "Existen Operaciones Pendientes, ¿Se encuentra seguro de Cancelar la Operación?", "Servicios", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No
                )

                e.Cancel = true;
        }

        private void FServicios_Shown(object sender, EventArgs e)
        {
            limpiarCampos();
            habilitarCampos(false);
            if (esParaInsertar)
            {
                tabControl1.Controls[1].Enabled = false;
            }
            else
            {
                DTServicios = _ServiciosCLN.ListarServicios();
                bindingSourceServicio.DataSource = DTServicios;
                dtGVServicios.DataSource = bindingSourceServicio;
                bindingSourceServicio.MoveLast();
                lblCantidadServicios.Text = "Cantidad de Registros :" + DTServicios.Count.ToString();
                DTServicios.RowDeleted += new DataRowChangeEventHandler(DTServicios_RowDeleted);
                DTServicios.RowChanged += new DataRowChangeEventHandler(DTServicios_RowChanged);
            }
            habilitarBotones(false , false, DTServicios.Count != 0, DTServicios.Count != 0, true);
        }

        void DTServicios_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            lblCantidadServicios.Text = "Cantidad de Registros :" + DTServicios.Count.ToString();
        }

        void DTServicios_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            lblCantidadServicios.Text = "Cantidad de Registros :" + DTServicios.Count.ToString();
        }

        private void bNuevo_Click(object sender, EventArgs e)
        {
            dtGVServicios.ClearSelection();
            TipoOperacion = "N";
            limpiarCampos();
            habilitarCampos(true);
            habilitarBotones(true, true, false, false, false);
            tabControl1.Controls[1].Enabled = false;
        }

        private void bEditar_Click(object sender, EventArgs e)
        {            
            TipoOperacion = "E";            
            habilitarCampos(true);
            habilitarBotones(true, true, false, false, false);
            tabControl1.Controls[1].Enabled = false;
        }

        private void bEliminar_Click(object sender, EventArgs e)
        {
            if (DTServicios.Count != 0 &&
                dtGVServicios.CurrentCell != null)
            {
                if (MessageBox.Show(this, "¿Se encuentra seguro de eliminar este registro?", "Servicios", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                try
                {
                    NumeroServicio = DTServicios[bindingSourceServicio.Position].CodigoServicio;
                    _ServiciosCLN.EliminarServicio(NumeroServicio);
                    DTServicios.Rows.RemoveAt(bindingSourceServicio.Position);

                    DTServicios.AcceptChanges();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(this, "Ocurio la siguiente Excepcion : \r\n" + Ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                habilitarBotones(false, false, DTServicios.Count != 0, DTServicios.Count != 0, true);
            }
            else
                MessageBox.Show(this, "Aún no tiene ningún registro seleccionado para eliminarlo", "Servicios", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (validarDatos())
            {
                try
                {
                    string NombreServicio, Descripcion, CodigoTipo;
                    decimal PrecioUnitario = 0;

                    NombreServicio = txtBoxNombreServicio.Text.Trim();
                    CodigoTipo = cBoxNombreServicio.SelectedValue.ToString();
                    Descripcion = txtBoxDescripcion.Text;
                    PrecioUnitario = Decimal.Parse(txtBoxPrecioServicio.Text);

                    if (TipoOperacion == "N")
                    {
                        _ServiciosCLN.InsertarServicio(NombreServicio, CodigoTipo, PrecioUnitario, Descripcion);
                        DTServicios.Rows.Add(new object[] { _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("Servicios"), NombreServicio, CodigoTipo, PrecioUnitario, Descripcion });
                    }
                    else
                        _ServiciosCLN.ActualizarServicio(DTServicios[bindingSourceServicio.Position].CodigoServicio, NombreServicio, CodigoTipo, PrecioUnitario, Descripcion);

                    DTServicios.AcceptChanges();

                    habilitarCampos(false);
                    habilitarBotones(false, false, true, true, true);
                    tabControl1.Controls[1].Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Ocurrio la siguiente Excepción " + ex.Message,
                        "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                }
            }
        }

        public bool validarDatos()
        {
            if (String.IsNullOrEmpty(txtBoxNombreServicio.Text))
            {
                errorProvider1.SetError(txtBoxNombreServicio, "Aún no ha ingresado el nombre del Servicio");
                return false;
            }

            if (cBoxNombreServicio.SelectedIndex == -1)
            {
                errorProvider1.SetError(cBoxNombreServicio, "Aún no ha seleccionado un tipo de Servicio");
                return false;
            }

            decimal PrecioUnitario = 0;
            if (!decimal.TryParse(txtBoxPrecioServicio.Text, out PrecioUnitario))
            {
                errorProvider1.SetError(txtBoxPrecioServicio, "El Precio que ha ingresado no es Correcto, o Probablemente aún no ingresado un Precio");
                return false;
            }
            return true;
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            tabControl1.Controls[1].Enabled = true;
            if (TipoOperacion == "N")
            {
                limpiarCampos();
                bindingSourceServicio.ResumeBinding();
                bindingSourceServicio.MoveLast();
                
            }
            else
                DTServicios.RejectChanges();
            TipoOperacion = "";
            habilitarBotones(false, false, DTServicios.Count != 0, DTServicios.Count != 0, true);
            habilitarCampos(false);
            
        }

        private void bCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtGVServicios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }
    }

    public  class TiposServicios
    {
        public string CodigoTipoServicio { get; set; }
        public string NombreTipoServicio { get; set; }
        public static string ValueMember { get { return "CodigoTipoServicio"; } }
        public static string DisplayMember { get { return "NombreTipoServicio"; } }

        public TiposServicios() { }
        public TiposServicios(string CodigoTipo, string NombreTipo)
        {
            this.CodigoTipoServicio = CodigoTipo;
            this.NombreTipoServicio = NombreTipo;
        }

        public static List<TiposServicios> getListaServicios()
        {
            List<TiposServicios> listaTiposServicios = new List<TiposServicios>();
            listaTiposServicios.Add(new TiposServicios("L", "Realiza Dentro de la empresa"));
            listaTiposServicios.Add(new TiposServicios("D", "Realiza a Domicilio"));
            return listaTiposServicios;
        }
    }
}
