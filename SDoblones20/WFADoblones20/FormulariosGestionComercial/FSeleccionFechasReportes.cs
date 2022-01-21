using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FSeleccionFechasReportes : Form
    {
        public object SelectedValueFiltro
        {
            get {return cBoxFiltro.SelectedValue; }
        }
        public DateTime FechaInicio
        {
            get { return dateTimePicker1.Value; }
        }
        public DateTime FechaFin
        {
            get { return dateTimePicker2.Value; }
        }
        public FSeleccionFechasReportes()
        {
            InitializeComponent();
        }
        public void setVisibilidadFiltro(bool estadoVisible)
        {
            lblFiltro.Visible = gBoxFiltro.Visible = cBoxFiltro.Visible = estadoVisible;
        }
        public Label LabelFiltro
        {
            get { return this.lblFiltro; }
        }
        public void cargarDatosFiltro(DataTable DTFiltro, string DisplayMember, string ValueMember)
        {
            cBoxFiltro.DataSource = DTFiltro;
            cBoxFiltro.DisplayMember = DisplayMember;
            cBoxFiltro.ValueMember = ValueMember;
            cBoxFiltro.SelectedIndex = -1;     
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Button btnAccion = sender as Button;
            this.DialogResult = btnAccion.Equals(btnAceptar) ? DialogResult.OK : DialogResult.Cancel;
        }
    }

}
