using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WFADoblones20.FormulariosSistema;
using WFADoblones20.Librerias;
using System.Reflection;
using CrystalDecisions.Shared;
namespace WFADoblones20
{
  
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>

        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new WFADoblones20.FormulariosGestionComercial.FTransferenciaProductosRecepcionEnvioPE(1, 1, "PRO100", "E", "producto prueba", 15));
            //Application.Run(new WFADoblones20.FormulariosGestionComercial.FVentaProductosAdministradorEntregas(1,1));
            //Application.Run(new WFADoblones20.FormulariosGestionComercial.FAdministradorDeProductos(1));            
            //Application.Run(new WFADoblones20.FormulariosGestionComercial.FVentasServicios(1, 1, 1));
            //Application.Run(new WFADoblones20.FormulariosGestionComercial.FProductosBusqueda2(1, 1, 'V', 2, 13));
            //Application.Run(new WFADoblones20.FormulariosGestionComercial.FComprasProductosCuentasPorPagar(1, 1, 1));
            

            //WFADoblones20.Utilitarios.Ticket.verEjemplo();
            //Application.Run(new FPrincipal());

            /*LeerALS LeerALS = new LeerALS("Doblones20.als");
            if (LeerALS.exito)
                Application.Run(new FPrincipal());
            else
            {
                MessageBox.Show("Usted no puede ejecutar esta aplicacion en esta estación de trabajo, por no contar con una llave de acceso, comuniquese con la empresa QuarkBit al celular 72888725, para solicitar una licencia para este equipo.");
                Application.Exit();                
            }*/


            AppDomain.CurrentDomain.AssemblyLoad += new AssemblyLoadEventHandler(ShowAssemblies);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            //Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            //Application.ThreadExit += new EventHandler(Application_ThreadExit);

            FSplashHilos.IniciarSplash(Application.StartupPath + @"\Imagenes\splash.png", System.Drawing.Color.FromArgb(255, 255, 255));


            forcarCargadoAssembliesCrystalReports();

            FSplashHilos.CloseSplash();

            AppDomain.CurrentDomain.AssemblyLoad -= ShowAssemblies;
            try
            {
                Application.Run(new FPrincipal());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se cierra Doblones20 debido a que ocurrió la siguiente Excepción " + ex.Message);
            }
            //Application.Run(new WFADoblones20.FormulariosGestionComercial.FInventarioMercaderiaEnTransito(1));
        }

        static void Application_ThreadExit(object sender, EventArgs e)
        {
            MessageBox.Show("Se cierra el Doblones 20");
        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            MessageBox.Show("Se cierra el Doblones 20");
        }

        /// <summary>
        /// Metodo que se encarga de caputar todos los Assemblies que se estan cargando
        /// al ejecutar la aplicación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ShowAssemblies(object sender, AssemblyLoadEventArgs e)
        {
            // Almacenamos los Assemblies dentro de la Cola que se encuentra dentro de Nuestro Formulario Splash

            FSplashHilos.ColaAssembliesCargados.Enqueue(e.LoadedAssembly.GetName().Name);
        }


        /// <summary>
        /// Metodo que se encarga de crear el Componente CrystalReportViewer para forzar
        /// el cargado de los assemblies de Crystal
        /// 
        /// </summary>
        public static void forcarCargadoAssembliesCrystalReports()
        {
            CrystalDecisions.Windows.Forms.CrystalReportViewer CRVClientes = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            CRVClientes.Visible = false;
            WFADoblones20.ReportesGestionComercial.CRClientes CRCliente = new WFADoblones20.ReportesGestionComercial.CRClientes();
            CLCAD.DSDoblones20GestionComercial.ClientesDataTable DTClientes = new CLCAD.DSDoblones20GestionComercial.ClientesDataTable();
            DTClientes.AddClientesRow("ANONIMOA", "ANINIMO", "C", "000001", "01", "01", "01", "01", "DIRECCION", "6454645", "POR AHIS", "PRUEBA", "A", 1);
            DTClientes.AcceptChanges();
            CRCliente.SetDataSource((System.Data.DataTable)DTClientes);
            CRVClientes.ReportSource = CRCliente;

        }
    }

    
}
