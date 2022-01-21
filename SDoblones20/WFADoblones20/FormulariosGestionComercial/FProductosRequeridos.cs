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
    public partial class FProductosRequeridos : Form
    {
        DataTable DTProductosRequeridos;
        InventariosProductosCLN _InventariosProductosCLN;
        int NumeroAgencia;
        public FProductosRequeridos(int NumeroAgencia)
        {
            this.NumeroAgencia = NumeroAgencia;
            InitializeComponent();
        }

        private void FProductosRequeridos_Load(object sender, EventArgs e)
        {
            DGCNombreProducto.Width = 250;
            DGCCodigoProducto.Width = 80;
            _InventariosProductosCLN = new InventariosProductosCLN();
            DTProductosRequeridos = _InventariosProductosCLN.ListarProductosRequeridosPorVentasNoEntregadasCompletamente();
            dtGVProductosRequeridos.DataSource = DTProductosRequeridos;

            new DgvFilterPopup.DgvFilterManager(dtGVProductosRequeridos);

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            FListarProductosRequeridosVentasNoCompletadas _FListarProductosRequeridosVentasNoCompletadas = new FListarProductosRequeridosVentasNoCompletadas(DTProductosRequeridos);
            _FListarProductosRequeridosVentasNoCompletadas.ShowDialog(this);
            _FListarProductosRequeridosVentasNoCompletadas.Dispose();

        }
    }
}
