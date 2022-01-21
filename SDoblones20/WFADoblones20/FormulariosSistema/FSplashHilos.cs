#region Using Directives
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
#endregion
namespace WFADoblones20.FormulariosSistema
{
    public delegate void DelegateCloseSplash();

    public partial class FSplashHilos : Form
    {
        /// <summary>
        /// Cola que se encarga de Almacenar todos los Assemblies que se van Cargando
        /// </summary>
        public static Queue<string> ColaAssembliesCargados = new Queue<string>();
        private Label lblLibrerias = new Label();
        System.Windows.Forms.Timer timerLibrerias = new System.Windows.Forms.Timer();

        #region Constructor
        /// <summary>
        /// Formulario Splash que se encarga de mostrar la Imagen (TRANSPARENTE)de Inicio de la aplicación
        /// y Cargar los Assemblies que se cargan al Ejecutar la misma
        /// </summary>
        /// <param name="RutaArchivoImagen">Ruta del Archivo Imagen</param>
        /// <param name="ColorTransparencia">Color de Fondo que debe ser considerado Transparente en la Imagen a mostrar</param>
        public FSplashHilos(String RutaArchivoImagen, Color ColorTransparencia)
        {
            Debug.Assert(RutaArchivoImagen != null && RutaArchivoImagen.Length > 0,
                "A proporcinado una Directorio no Valido para el Cargado de la Imagen del Splash");
            // ====================================================================================
            // Configuramos el Formularios
            // ==================================================================================== 
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.TopMost = true;

            // Volvemos el Formularios Splash Transparente
            this.TransparencyKey = this.BackColor;

            // Enganchamos los Eventos
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SplashForm_KeyUp);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SplashForm_Paint);
            this.MouseDown += new MouseEventHandler(SplashForm_MouseClick);

            
            //Cargamos la Imagen en un BitMap y la volvemos Transparente
            Imagen_BitMap = new Bitmap(RutaArchivoImagen);

            if (Imagen_BitMap == null)
                throw new Exception("No se Pudo Cargar el Archivo de Imagen  " + RutaArchivoImagen);
            Imagen_BitMap.MakeTransparent(ColorTransparencia);

            // Readecuamos el Tamaño del Formulario al Tamaño de la Imagen
            this.Width = Imagen_BitMap.Width;
            this.Height = Imagen_BitMap.Height;

            // Centramos el Formulario
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Cursor = System.Windows.Forms.Cursors.AppStarting;


            // Ejecutamos el Hilo de Ejecución
            Delegado_Cerrar_Splash = new DelegateCloseSplash(InternalCloseSplash);


            //para visualizar los assemblies
            lblLibrerias = new Label();
            lblLibrerias.Location = new Point(25, 25);
            lblLibrerias.Size = new Size(new Point(100, 20));
            lblLibrerias.BackColor = System.Drawing.Color.Transparent;
            lblLibrerias.AutoSize = true;
            this.Controls.Add(lblLibrerias);
            timerLibrerias = new System.Windows.Forms.Timer();
            timerLibrerias.Enabled = true;
            timerLibrerias.Start();
            timerLibrerias.Tick += new EventHandler(timerLibrerias_Tick);

        }

        void timerLibrerias_Tick(object sender, EventArgs e)
        {
            while (ColaAssembliesCargados.Count > 0)
            {
                lblLibrerias.Text = "Cargando " + ColaAssembliesCargados.Dequeue() + " ...";                
                lblLibrerias.Update();
            }

        }
        #endregion // Constructor

        #region Public methods
        // Este sector puede ser utilizado para Cuadros de Dialogos(ACERCA DE)
        public static void ShowModal(String RutaArchivoImagen2, Color ColTransparencia)
        {
            RutaArchivoImagen = RutaArchivoImagen2;
            Color_Transparencia = ColTransparencia;
            EjecutarHiloSplash();
        }
        
        /// <summary>
        /// Metodo que se encarga Inicializar el Splash con el Hilo de Ejección
        /// llamar a este metodo con la Ruta de la Imagen
        /// y el Color que debe ser Transparente
        /// </summary>
        /// <param name="RutaArchivoImagen2">Ruta Archivo</param>
        /// <param name="ColTransparencia">Color de Transparencia</param>
        public static void IniciarSplash(String RutaArchivoImagen2, Color ColTransparencia)
        {
            RutaArchivoImagen = RutaArchivoImagen2;
            Color_Transparencia = ColTransparencia;
            
            //Creamos e Iniciamos el Hilo de Ejecución del Splash
            Thread HiloEjecuciónSplash = new Thread(new ThreadStart(EjecutarHiloSplash));
            HiloEjecuciónSplash.Start();
        }
                
        /// <summary>
        /// Ejecutar este metodo al final de la inicialización de la aplicaciónb
        /// para cerrar el Formulario Splash
        /// </summary>
        public static void CloseSplash()
        {
            if (InstanciaSplashHilos != null)
                InstanciaSplashHilos.Invoke(InstanciaSplashHilos.Delegado_Cerrar_Splash);

        }
        #endregion // Metodos Publicos

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            Imagen_BitMap.Dispose();
            base.Dispose(disposing);
            InstanciaSplashHilos = null;
        }
        #endregion // Dispose

        #region Ejecución del Hilo
        //Ejecutar esta función para cerrar y liberar memoria del Hilo
        void InternalCloseSplash()
        {
            this.Close();
            this.Dispose();
        }
        // this is called by the new thread to show the splash screen
        private static void EjecutarHiloSplash()
        {
            InstanciaSplashHilos = new FSplashHilos(RutaArchivoImagen, Color_Transparencia);
            InstanciaSplashHilos.TopMost = false;
            InstanciaSplashHilos.ShowDialog();
        }
        #endregion // Multithreading code

        #region Event Handlers

        void SplashForm_MouseClick(object sender, MouseEventArgs e)
        {
            //this.InternalCloseSplash();
        }

        private void SplashForm_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawImage(Imagen_BitMap, 0, 0);
        }

        private void SplashForm_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.InternalCloseSplash();
        }
        #endregion // Event Handlers

        #region Private variables
        private static FSplashHilos InstanciaSplashHilos;
        private static String RutaArchivoImagen;
        private static Color Color_Transparencia;
        private Bitmap Imagen_BitMap;
        private DelegateCloseSplash Delegado_Cerrar_Splash;
        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SplashForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.Name = "SplashForm";
            this.ResumeLayout(false);

        }
    }
}
