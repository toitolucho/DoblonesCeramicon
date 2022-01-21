using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using CLCLN.GestionComercial;

namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FAgregarEditarProductoImagen : Form
    {
        public string RutaArchivoImagen = "";
        public string NombreImagen = "";
        
        public FAgregarEditarProductoImagen()
        {
            InitializeComponent();
            this.RutaArchivoImagen = "";
            this.NombreImagen = "";
            InicializarControles();
        }

        public FAgregarEditarProductoImagen(string RutaArchivoImagen, string NombreImagen)
        {
            InitializeComponent();
            
            this.RutaArchivoImagen = RutaArchivoImagen;
            this.NombreImagen = NombreImagen;

            InicializarControles();
        }

        private void InicializarControles()
        {
            tBRutaArchivoImagen.Text = this.RutaArchivoImagen;
            if (this.RutaArchivoImagen.Length > 0)
            {

            }

            if (this.RutaArchivoImagen.Length > 0 && File.Exists(this.RutaArchivoImagen))
            {
                Image AuxImage2 = Image.FromFile(this.RutaArchivoImagen);
                MemoryStream AuxMemoryStream2 = new MemoryStream();

                AuxImage2.Save(AuxMemoryStream2, ImageFormat.Png);

                pBImagenProducto.Image = Image.FromStream(AuxMemoryStream2);
                AuxImage2.Dispose();
            }
            else
            {
                pBImagenProducto.Image = null;
            }




            tBNombreImagen.Text = this.NombreImagen;
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tBRutaArchivoImagen.Text.Trim()))
            {
                MessageBox.Show("No puede dejar sin llevar el campo correspondiente al valor de la propiedad");
                return;
            }
            else
            {
                this.RutaArchivoImagen = tBRutaArchivoImagen.Text;
                this.NombreImagen = tBNombreImagen.Text;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void bBuscarImagen_Click(object sender, EventArgs e)
        {
            string ImagenActual = tBRutaArchivoImagen.Text;
            //Definimos los filtros de archivos a permitir, en este caso imagenes
            oFDImagen.Filter = "Archivos BMP (*.bmp)|*.bmp|Archivos GIF (*.gif)|*.gif|Archivos JGP (*.jpg)|*.jpg|Archivo PNG (*.png)|*.png|All (*.*)|*.* ";
            ///Establece que filtro se mostrará por defecto en este caso, 3=jpg
            oFDImagen.FilterIndex = 3;
            ///Esto aparece en el Nombre del archivo a seleccionar, se puede quitar no es fundamental
            oFDImagen.FileName = "Seleccione una imagen";
            //El titulo de la Ventana....
            oFDImagen.Title = "Imagen del producto";
            //El directorio que por defecto al abrir, para cada contrapleca del Path colocar \\ C:\\Fotitos\\Wizard y así sucesivamente
            //oFDImagen.InitialDirectory = Application.ExecutablePath;

            if (oFDImagen.ShowDialog() == DialogResult.OK)
            {
                /// Si esto se cumple, capturamos la propiedad File Name y la guardamos en la variable Garrobito
                this.RutaArchivoImagen = oFDImagen.FileName;
                pBImagenProducto.Image = new Bitmap(this.RutaArchivoImagen);
                tBRutaArchivoImagen.Text = oFDImagen.FileName;

                //if (ImagenActual != tBRutaArchivoImagen.Text)
                //    CambioHuellaDactilar = true;
            }
        }

       
    }
}
