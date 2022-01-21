using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.Sistema;
using CLCLN.GestionComercial;
namespace WFADoblones20.FormulariosSistema
{
    public partial class FIAInterfacesSistemas : Form
    {
        private int _CodigoInterfaz = -1;
        private string _NombreInterfaz = "";
        private string _TextoInterfaz = "";
        private string _CodigoTipoInterfaz = "";
        private char TipoAccion = 'I';
        public bool accionCompletada = false;
        SistemasInterfacesCLN _SistemasInterfacesCLN = new SistemasInterfacesCLN();
        TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();

        public int CodigoInterfaz
        {
            get {
                return _CodigoInterfaz;
            }            

        }
        public string NombreInterfaz
        {
            get
            {
                return _TextoInterfaz;
            }
        }
        public string TextoInterfaz
        {
            get
            {
                return _TextoInterfaz;
            }
        }
        public string CodigoTipoInterfaz
        {
            get
            {
                return _CodigoTipoInterfaz;
            }
        }

        public FIAInterfacesSistemas(int codigo, string nombre, string texto, string tipo, char TipoAccion)
        {
            InitializeComponent();
            this._CodigoInterfaz = codigo;
            this._NombreInterfaz = nombre;
            this._TextoInterfaz = texto;
            this._CodigoTipoInterfaz = tipo;
            this.TipoAccion = TipoAccion;
            System.Collections.ArrayList listaTiposInterfaces = new System.Collections.ArrayList();
            listaTiposInterfaces.Add(new TiposInterfaces("G", "Uso general"));
            listaTiposInterfaces.Add(new TiposInterfaces("P", "Uso personalizado"));

            cBoxTipoInterfaz.DataSource = listaTiposInterfaces;
            cBoxTipoInterfaz.ValueMember = "CodigoTipoInterface";
            cBoxTipoInterfaz.DisplayMember = "NombreTipoInterface";

            if (TipoAccion == 'I')
            {
                txtBoxCodigo.Text = _TransaccionesUtilidadesCLN.ObtenerUltimoIndiceTabla("SistemaInterfaces").ToString();
                txtBoxNombre.Clear();
                txtBoxTexto.Clear();
                cBoxTipoInterfaz.SelectedIndex = 0;
                cBoxTipoInterfaz.Focus(); 
                habilitarCampos(true);
            }
            if (TipoAccion == 'E')
            {
                txtBoxNombre.Text = nombre;
                txtBoxCodigo.Text = codigo.ToString();
                txtBoxTexto.Text = texto;
                cBoxTipoInterfaz.SelectedValue = tipo;
                habilitarCampos(true);
            }

            this.FormClosing += new FormClosingEventHandler(FIAInterfacesSistemas_FormClosing);
        }

        void FIAInterfacesSistemas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!accionCompletada)
            {
                if (MessageBox.Show(this, "Aun no ha confirmado la operación actual ¿Desea cancelar la misma?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                    cBoxTipoInterfaz.Focus();
                }

            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            _CodigoInterfaz = Int32.Parse(txtBoxCodigo.Text);
            _NombreInterfaz = txtBoxNombre.Text;
            _TextoInterfaz = txtBoxTexto.Text;
            _CodigoTipoInterfaz = cBoxTipoInterfaz.SelectedValue.ToString();

            try
            {
                if (TipoAccion == 'I')
                    _SistemasInterfacesCLN.InsertarSistemaInteraz(NombreInterfaz, TextoInterfaz, CodigoTipoInterfaz);
                if (TipoAccion == 'E')
                    _SistemasInterfacesCLN.ActualizarSistemaInteraz((byte)CodigoInterfaz, NombreInterfaz, TextoInterfaz, CodigoTipoInterfaz);
                MessageBox.Show("Se realizó correctamente la Operación");
                accionCompletada = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio el Siguiente error :" + ex.Message);
                accionCompletada = false;
            }
            habilitarCampos(false);
            this.Hide();
        }

        private void FIAInterfacesSistemas_Load(object sender, EventArgs e)
        {

        }

        public void habilitarCampos(bool habilitado)
        {
            this.cBoxTipoInterfaz.Enabled = habilitado;
            this.txtBoxNombre.Enabled = habilitado;
            this.txtBoxTexto.Enabled = habilitado;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            accionCompletada = false;
            this.Hide();
        }
    }

    public class TiposInterfaces
    {
        private string _CodigoTipoInterface;
        private string _NombreTipoInterface;

        public string CodigoTipoInterface
        {
            get { return _CodigoTipoInterface; }
            set { _CodigoTipoInterface = value; }
        }

        public string NombreTipoInterface
        {
            get { return _NombreTipoInterface; }
            set { _NombreTipoInterface = value; }
        }

        public TiposInterfaces(string CodigoTipoInterface, string NombreTipoInterface)
        {
            this._NombreTipoInterface = NombreTipoInterface;
            this._CodigoTipoInterface = CodigoTipoInterface;
        }
    }
}
