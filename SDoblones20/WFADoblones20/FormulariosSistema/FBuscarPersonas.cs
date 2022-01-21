using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN;
using CLCLN.Sistema;

namespace WFADoblones20.FormulariosSistema
{
    public partial class FBuscarPersonas : Form
    {
        private PersonasCLN Personas = new PersonasCLN();
        private DataTable RBPersonas = new DataTable();
        public string DISeleccionado;
        public string NombreCompletoSeleccionado;


        public FBuscarPersonas()
        {
            InitializeComponent();
        }

        private void bBuscar_Click(object sender, EventArgs e)
        {
            /*if (tBTextoBusqueda.Text.Trim() != "")
            {*/
                RBPersonas = Personas.BuscarPersonas(cBBuscarPor.SelectedIndex.ToString(), tBTextoBusqueda.Text, cBBusquedaExacta.Checked);
                bSPersonas.DataSource = RBPersonas;
                dGVResultadoBusquedaPersonas.AutoGenerateColumns = false;

                sSBuscarPersonas.Items[0].Text = "Numero de registros encontrados: " + bSPersonas.Count.ToString();
            /*}
            else
            {
                string Mensaje = "No se pueden realizar ninguna busqueda mientras no defina un cadena de texto valida";
                string Titulo = "Error en la cadena de busqueda";
                MessageBoxButtons Botones = MessageBoxButtons.OK;

                MessageBox.Show(Mensaje, Titulo, Botones);
            }*/
        }

        private void FBuscarPersonas_Load(object sender, EventArgs e)
        {
            cBBuscarPor.SelectedIndex = 4;
        }

        private void dGVResultadoBusquedaPersonas_DoubleClick(object sender, EventArgs e)
        {
            if (dGVResultadoBusquedaPersonas.RowCount >= 1)
            {
                DISeleccionado = dGVResultadoBusquedaPersonas[0, dGVResultadoBusquedaPersonas.CurrentCell.RowIndex].Value.ToString();
                NombreCompletoSeleccionado = dGVResultadoBusquedaPersonas[1, dGVResultadoBusquedaPersonas.CurrentCell.RowIndex].Value.ToString();
                //MessageBox.Show("El di seleccionado es: " + DIPersonaSeleccionado);
                this.Close();
            }
        }

        private void cBBuscarPor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tBTextoBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                bBuscar_Click(bBuscar, e as EventArgs);
            }
        }
       
    }
}
