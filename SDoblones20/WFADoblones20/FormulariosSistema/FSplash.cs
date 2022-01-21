using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CLCLN.GestionComercial;

namespace WFADoblones20.FormulariosSistema
{
    public partial class FSplash : Form
    {
        /*public FSplash()
        {
            InitializeComponent();
        }*/

        public FSplash(int Segundos)
        {
            //
            // Necesario para admitir el diseñador de Windows Forms
            //

            InitializeComponent();

            timer1.Interval = Segundos * 1000;    // pasamos de segundos a milisegundos

            if (!timer1.Enabled)
                timer1.Enabled=true;    // Activamos el Timer si no esta Enabled (Activado)

            //
            // TODO: Agregar código de constructor después de llamar a InitializeComponent
            //
        }

        private void FSplash_Load(object sender, EventArgs e)
        {
            CRVTemporal.Visible = false;
            WFADoblones20.ReportesGestionComercial.CRClientes CRCliente = new WFADoblones20.ReportesGestionComercial.CRClientes();
            CRCliente.SetDataSource(new ClientesCLN().ObtenerCliente(1));
            CRVTemporal.ReportSource = CRCliente;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();     // Se para el timer.
            this.Close();      // Cerramos el formulario.
        }
    }
}