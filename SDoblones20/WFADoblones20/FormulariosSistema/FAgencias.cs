using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.GestionComercial;
using CLCLN.Sistema;
using WFADoblones20.FormulariosSistema;

namespace WFADoblones20.FormulariosSistema
{
    public partial class FAgencias : Form
    {
        private AgenciasCLN Agencias = new AgenciasCLN();
        private PaisesCLN Paises = new PaisesCLN();
        private DepartamentosCLN Departamentos = new DepartamentosCLN();
        private ProvinciasCLN Provincias = new ProvinciasCLN();
        private LugaresCLN Lugares = new LugaresCLN();
        private DataTable RBAgencias = new DataTable();
        private string TipoOperacion = "";

        public FAgencias(bool PermitirInsertar, bool PermitirEditar, bool PermitirEliminar, bool PermitirNavegar)
        {
            InitializeComponent();

            this.bNuevo.Visible = PermitirInsertar;
            this.bEditar.Visible = PermitirEditar;
            this.bEliminar.Visible = PermitirEliminar;
            this.bCancelar.Visible = (PermitirInsertar || PermitirEditar) ? true: false;
            this.bAceptar.Visible = (PermitirInsertar || PermitirEditar) ? true: false;
            this.bBuscar.Visible = PermitirNavegar;
        }

        private void CargarPaises()
        {
            DataTable DTPaises = new DataTable();
            DTPaises = Paises.ListarPaises();
            cBPais.DataSource = DTPaises.DefaultView;
            cBPais.DisplayMember = "NombrePais";
            cBPais.ValueMember = "CodigoPais";
        }
        
        private void CargarDepartamentos(string CodigoPais)
        {
            DataTable DTDepartamentos = new DataTable();
            DTDepartamentos = Departamentos.ObtenerDepartamentosPorPais(CodigoPais);
            cBDepartamento.DataSource = DTDepartamentos.DefaultView;
            cBDepartamento.DisplayMember = "NombreDepartamento";
            cBDepartamento.ValueMember = "CodigoDepartamento";
        }

        private void CargarProvincias(string CodigoPais, string CodigoDepartamento)
        {
            DataTable DTProvincias = new DataTable();
            DTProvincias = Provincias.ObtenerProvinciasPorDepartamento(CodigoPais, CodigoDepartamento);
            cBProvincia.DataSource = DTProvincias.DefaultView;
            cBProvincia.DisplayMember = "NombreProvincia";
            cBProvincia.ValueMember = "CodigoProvincia";
        }

        private void CargarLugares(string CodigoPais, string CodigoDepartamento, string CodigoProvincia)
        {
            DataTable DTLugares = new DataTable();
            DTLugares = Lugares.ObtenerLugaresPorProvincia(CodigoPais, CodigoDepartamento, CodigoProvincia);
            cBLugar.DataSource = DTLugares.DefaultView;
            cBLugar.DisplayMember = "NombreLugar";
            cBLugar.ValueMember = "CodigoLugar";
        }

        private void CargarAgencias()
        {
            DataTable DTAgencias = new DataTable();
            DTAgencias = Agencias.ListarAgencias();
            cBAgenciaSuperior.DataSource = DTAgencias.DefaultView;
            cBAgenciaSuperior.DisplayMember = "NombreAgencia";
            cBAgenciaSuperior.ValueMember = "NumeroAgencia";
        }


        private void InhabilitarControles(bool Estado)
        {
            tBNumeroAgencia.ReadOnly = Estado; 
            tBNombreAgencia.ReadOnly = Estado;
            cBPais.Enabled = !Estado;
            cBDepartamento.Enabled = !Estado;
            cBProvincia.Enabled = !Estado;
            cBLugar.Enabled = !Estado;
            tBDireccion.ReadOnly = Estado; 
            tBNITAgencia.ReadOnly = Estado;
            tBNumeroSiguienteFactura.ReadOnly = Estado;
            tBNumeroAutorizacion.ReadOnly = Estado;
            tBDIResponsable.ReadOnly = Estado;
            bBuscarResponsable.Enabled = !Estado;
            cBAgenciaSuperior.Enabled = !Estado;
        }

        private void InicializarControles()
        {
            tBNumeroAgencia.Text = "";
            tBNombreAgencia.Text = "";
            cBPais.SelectedIndex = -1;
            cBDepartamento.SelectedIndex = -1;
            cBProvincia.SelectedIndex = -1;
            cBLugar.SelectedIndex = -1;
            tBDireccion.Text = "";
            tBNITAgencia.Text = "";
            tBNumeroSiguienteFactura.Text = "";
            tBNumeroAutorizacion.Text = "";
            tBDIResponsable.Text = "";
            cBAgenciaSuperior.SelectedIndex = -1;
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
            bBuscar.Enabled = false;
            bReportes.Enabled = false;

            tBNombreAgencia.Focus();
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
            bBuscar.Enabled = false;
            bReportes.Enabled = false;
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
                Agencias.EliminarAgencia(int.Parse(tBNumeroAgencia.Text));
                InhabilitarControles(true);
                InicializarControles();
                bNuevo.Enabled = true;
                bEditar.Enabled = false;
                bEliminar.Enabled = false;
                bAceptar.Enabled = false;
                bCancelar.Enabled = false;
                bBuscar.Enabled = true;
                bReportes.Enabled = false;

            }
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            string CodigoPais = null;
            string CodigoDepartamento = null;
            string CodigoProvincia = null;
            string CodigoLugar = null;
            string DIResponsable = null;
            int NumeroAgenciaSuperior = 0;

            if (cBPais.SelectedIndex > -1)
                CodigoPais = cBPais.SelectedValue.ToString();

            if (cBDepartamento.SelectedIndex > -1)
                CodigoDepartamento = cBDepartamento.SelectedValue.ToString();

            if (cBProvincia.SelectedIndex > -1)
                CodigoProvincia = cBProvincia.SelectedValue.ToString();

            if (cBLugar.SelectedIndex > -1)
                CodigoLugar = cBLugar.SelectedValue.ToString();

            if (tBDIResponsable.Text.Trim().Length > 0)
                DIResponsable = tBDIResponsable.Text;
            else
            {
                string Mensaje = "No ingreso el Document Identificativo del responsable.";
                string Titulo = "Verificación responsable agencia";
                MessageBoxButtons Botones = MessageBoxButtons.OK;
                MessageBoxIcon Icono = MessageBoxIcon.Warning;

                MessageBox.Show(Mensaje, Titulo, Botones, Icono);
                return;
            }

            if (cBAgenciaSuperior.SelectedIndex > -1)
                NumeroAgenciaSuperior = int.Parse(cBAgenciaSuperior.SelectedValue.ToString());


            if (TipoOperacion == "I")
            {
                Agencias.InsertarAgencia(tBNombreAgencia.Text, CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLugar, tBDireccion.Text, tBNITAgencia.Text, int.Parse(tBNumeroSiguienteFactura.Text), tBNumeroAutorizacion.Text, tBDIResponsable.Text, NumeroAgenciaSuperior);
                //Proveedores.InsertarProveedor(tBNombreRazonSocial.Text, tBNombreRepresentante.Text, CodigoTipoProveedor, tBNITProveedor.Text, CodigoBanco, tBNumeroCuenta.Text, CodigoMoneda, tBNombreOrdenCheque.Text, CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLugar, tBDireccion.Text, tBTelefono.Text, tBFax.Text, tBCasilla.Text, tBEmail.Text, tBObservaciones.Text, cBProveedorActivo.Checked, 1);

            }

            if (TipoOperacion == "E")
            {
                Agencias.ActualizarAgencia(int.Parse(tBNumeroAgencia.Text), tBNombreAgencia.Text, CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLugar, tBDireccion.Text, tBNITAgencia.Text, int.Parse(tBNumeroSiguienteFactura.Text), tBNumeroAutorizacion.Text, tBDIResponsable.Text, NumeroAgenciaSuperior);
                //Proveedores.ActualizarProveedor(int.Parse(tBCodigoProveedor.Text), tBNombreRazonSocial.Text, tBNombreRepresentante.Text, CodigoTipoProveedor, tBNITProveedor.Text, CodigoBanco, tBNumeroCuenta.Text, CodigoMoneda, tBNombreOrdenCheque.Text, CodigoPais, CodigoDepartamento, CodigoProvincia, CodigoLugar, tBDireccion.Text, tBTelefono.Text, tBFax.Text, tBCasilla.Text, tBEmail.Text, tBObservaciones.Text, cBProveedorActivo.Checked, 1);
            }

            InhabilitarControles(true);
            bNuevo.Enabled = true;
            bEditar.Enabled = true;
            bEliminar.Enabled = true;
            bAceptar.Enabled = false;
            bCancelar.Enabled = false;
            bBuscar.Enabled = true;
            bReportes.Enabled = true;
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            TipoOperacion = "";
            InicializarControles();
            InhabilitarControles(true);
            bNuevo.Enabled = true;
            bEditar.Enabled = false;
            bEliminar.Enabled = false;
            bAceptar.Enabled = false;
            bCancelar.Enabled = false;

            bBuscar.Enabled = true;
            bReportes.Enabled = false;

        }

        private void bBuscar_Click(object sender, EventArgs e)
        {
            FBuscarAgencias fBuscarAgencias = new FBuscarAgencias();
            fBuscarAgencias.ShowDialog();
            int NumeroAgencia = fBuscarAgencias.NumeroAgencia;

            RBAgencias = Agencias.ObtenerAgencia(NumeroAgencia);

            if (RBAgencias.Rows.Count > 0)
            {
                tBNumeroAgencia.Text = RBAgencias.Rows[0][0].ToString();
                tBNombreAgencia.Text = RBAgencias.Rows[0][1].ToString();
                if ((RBAgencias.Rows[0][2].ToString() != null) && (RBAgencias.Rows[0][2].ToString() != ""))
                    cBPais.SelectedValue = RBAgencias.Rows[0][2].ToString();
                else
                    cBPais.SelectedIndex = -1;
                if ((RBAgencias.Rows[0][3].ToString() != null) && (RBAgencias.Rows[0][3].ToString() != ""))
                    cBDepartamento.SelectedValue = RBAgencias.Rows[0][3].ToString();
                else
                    cBDepartamento.SelectedIndex = -1;
                if ((RBAgencias.Rows[0][4].ToString() != null) && (RBAgencias.Rows[0][4].ToString() != ""))
                    cBProvincia.SelectedValue = RBAgencias.Rows[0][4].ToString();
                else
                    cBProvincia.SelectedIndex = -1;
                if ((RBAgencias.Rows[0][5].ToString() != null) && (RBAgencias.Rows[0][5].ToString() != ""))
                    cBLugar.SelectedValue = RBAgencias.Rows[0][5].ToString();
                else
                    cBLugar.SelectedIndex = -1;
                tBDireccion.Text = RBAgencias.Rows[0][6].ToString();
                tBNITAgencia.Text = RBAgencias.Rows[0][7].ToString();
                tBNumeroSiguienteFactura.Text = RBAgencias.Rows[0][8].ToString();
                tBNumeroAutorizacion.Text = RBAgencias.Rows[0][9].ToString();
                tBDIResponsable.Text = RBAgencias.Rows[0][10].ToString();
                if ((RBAgencias.Rows[0][11].ToString() != null) && (RBAgencias.Rows[0][11].ToString() != ""))
                    cBAgenciaSuperior.SelectedValue = int.Parse(RBAgencias.Rows[0][11].ToString()) ;
                else
                    cBAgenciaSuperior.SelectedIndex = -1;

                bNuevo.Enabled = true;
                bEditar.Enabled = true;
                bEliminar.Enabled = true;
                bAceptar.Enabled = false;
                bCancelar.Enabled = false;
                bBuscar.Enabled = true;
                bReportes.Enabled = true;

            }
            else
            {
                InhabilitarControles(true);
                InicializarControles();
                bNuevo.Enabled = true;
                bEditar.Enabled = false;
                bEliminar.Enabled = false;
                bAceptar.Enabled = false;
                bCancelar.Enabled = false;
                bBuscar.Enabled = true;
                bReportes.Enabled = false;
            }
        }

        private void bCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bBuscarDeudor_Click(object sender, EventArgs e)
        {
            BuscarPersona(tBDIResponsable, tBNombreCompletoResponsable);
        }

        private void BuscarPersona(TextBox tbDI, TextBox tbNombreCompleto)
        {
            string DIP = "";
            string NCP = "";
            FBuscarPersonas fBuscarPersonas = new FBuscarPersonas();
            fBuscarPersonas.ShowDialog();
            DIP = fBuscarPersonas.DISeleccionado;
            NCP = fBuscarPersonas.NombreCompletoSeleccionado;
            if ((DIP == null) || (DIP == ""))
            {
                MessageBox.Show("No ha seleccionado ninguna persona");
            }
            else
            {
                tbDI.Text = DIP;
                tbNombreCompleto.Text = NCP;
            }
        }

        private void FAgencias_Load(object sender, EventArgs e)
        {
            CargarPaises();
            CargarAgencias();

            InhabilitarControles(true);
            InicializarControles();

            bNuevo.Enabled = true;
            bEditar.Enabled = false;
            bEliminar.Enabled = false;
            bAceptar.Enabled = false;
            bCancelar.Enabled = false;
            bBuscar.Enabled = true;
            bReportes.Enabled = false;
        }

        private void cBPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBPais.SelectedIndex >= 0)
                CargarDepartamentos(cBPais.SelectedValue.ToString());
        }

        private void cBDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBDepartamento.SelectedIndex >= 0)
                CargarProvincias(cBPais.SelectedValue.ToString(), cBDepartamento.SelectedValue.ToString());
        }

        private void cBProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBProvincia.SelectedIndex >= 0)
                CargarLugares(cBPais.SelectedValue.ToString(), cBDepartamento.SelectedValue.ToString(), cBProvincia.SelectedValue.ToString());
        }
    }
}
