using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.GestionComercial;
namespace WFADoblones20.FormulariosGestionComercial
{
    
    public partial class FInventarioMercaderiaEnTransito : Form
    {
        InventariosProductosCLN _InventariosProductosCLN;
        DataTable DTInventarioMercaderiaEnTransito;
        private int NumeroAgencia;
        public FInventarioMercaderiaEnTransito(int NumeroAgencia)
        {
            InitializeComponent();
            this.NumeroAgencia = NumeroAgencia;
            _InventariosProductosCLN = new InventariosProductosCLN();
            this.dtGVProductos.AutoGenerateColumns = false;
        }

        private void FInventarioMercaderiaEnTransito_Load(object sender, EventArgs e)
        {
            DTInventarioMercaderiaEnTransito = _InventariosProductosCLN.ListarInventarioMercaderiaEnTransitoFisico(NumeroAgencia);
            dtGVProductos.DataSource = DTInventarioMercaderiaEnTransito;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            FReporteInventarioMercaderiaEnTransito formMercaderiaEnTransito = new FReporteInventarioMercaderiaEnTransito();
             if (rbtnListadoGeneral.Checked)            
                formMercaderiaEnTransito.ListarInventarioMercaderiaEnTransitoFisico(DTInventarioMercaderiaEnTransito);            
             else 
                 formMercaderiaEnTransito.ListarInventarioMercaderiaEnTransito(_InventariosProductosCLN.ListarInventarioMercaderiaEnTransito(NumeroAgencia, !rBtnListadoProductos.Checked), !rBtnListadoProductos.Checked);
             formMercaderiaEnTransito.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
