using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WFADoblones20.ReportesGestionComercial;
using CLCLN.GestionComercial;
using System.IO;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FReportesGestionComercialProductos : Form
    {
        private DataTable OrigenReporteProductos = new DataTable();
        Button btnCerrarReporte;
        public FReportesGestionComercialProductos(DataTable Productos)
        {
            InitializeComponent();
            this.OrigenReporteProductos = Productos;

            btnCerrarReporte = new Button();
            btnCerrarReporte.Click += new EventHandler(btnCerrarReporte_Click);
            this.CancelButton = btnCerrarReporte;
        }

        void btnCerrarReporte_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cRVProductos_Load(object sender, EventArgs e)
        {
            //CRProductos ReporteProductos = new CRProductos();
            CRPruebaImagenes ReporteProductos = new CRPruebaImagenes();
            //ReporteProductos.SetDataSource(OrigenReporteProductos);
            
            CLCAD.DSDoblones20GestionComercial2.ProductosImagenesDataTable DTProductosImagenes = new CLCAD.DSDoblones20GestionComercial2.ProductosImagenesDataTable();
            CLCAD.DSDoblones20GestionComercial2.ProductosImagenesRow DRProductosImagenes = DTProductosImagenes.NewProductosImagenesRow();

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    //get the image file into a stream reader.
                    FileStream FilStr = new FileStream(openFileDialog1.FileName, FileMode.Open);
                    BinaryReader BinRed = new BinaryReader(FilStr);
                    //Adding the values to the columns
                    // adding the image path to the path column
                    //DataRow dr = this.DsImages.Tables["images"].NewRow();
                    DRProductosImagenes.PathImagen = openFileDialog1.FileName;
                    //dr["path"] = this.openFileDialog1.FileName;
                    //Important:
                    // Here you use ReadBytes method to add a byte array of the image stream.
                    //so the image column will hold a byte array.
                    //dr["image"] = BinRed.ReadBytes((int)BinRed.BaseStream.Length);
                    DRProductosImagenes.BinariosImagen = BinRed.ReadBytes((int)BinRed.BaseStream.Length); ;
                    //this.DsImages.Tables["images"].Rows.Add(dr);
                    DTProductosImagenes.Rows.Add(DRProductosImagenes);
                    FilStr.Close();
                    BinRed.Close();
                    //create the report object
                    //DynamicImageExample DyImg = new DynamicImageExample();
                    //// feed the dataset to the report.
                    //DyImg.SetDataSource(this.DsImages);
                    //this.crystalReportViewer1.ReportSource = DyImg;
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message, "Error");
                }

            }

            ReporteProductos.SetDataSource((DataTable)DTProductosImagenes);
            cRVProductos.ReportSource = ReporteProductos;
        }
    }
}
