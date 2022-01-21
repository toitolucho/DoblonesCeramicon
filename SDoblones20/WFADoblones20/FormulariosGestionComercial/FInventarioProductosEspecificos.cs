using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using CLCLN;
using CLCLN.GestionComercial;
using System.Threading;
namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FInventarioProductosEspecificos : Form
    {
        private const int LargoGrilla = 243;
        private const int LargoPanelDatosEntrada = 73;

        private ArrayList listadoFormasAdquision = new ArrayList();
        private ArrayList listadoEstados = new ArrayList();
        private ArrayList listadoFormasAdquisionCopy = new ArrayList();
        private ArrayList listadoEstadosCopy = new ArrayList();
        DataTable _DTProductosEspecificosTemporal = null;
        DataTable _DTInventarioProductos = null;
        DataTable _DTInventarioProductosEspecificos = null;
        DataTable _DTInventarioProductosEspecificosBackup = null;
        private int _NumeroAgencia;
        private string _CodigoProducto;
        private string _NombreProducto;
        private InventariosProductosCLN _InventarioProductosCLN;
        private InventariosProductosEspecificosCLN _InventarioProductosEspecificosCLN;       
        private List<int> listadoPocionesEstadosCambiados = new List<int>();        
        private int Cantidad_a_Generar = -1;
        private bool CodigosGenerados = false;
        private bool eventHookedUp = true;
        public bool MostrarHistorial = false;
        public bool IngresoCodigosHabilitado = false;
        private bool ingresoManualCodigo = true;
        public bool codigosPEGeneradosTodos = false;
        private const int CantidadMaximaDeGeneracionCodigosPE = 363;

        #region Propiedades del Formulario para un Determinado Especifico
        public int NumeroAgencia
        {
            get
            {
                return _NumeroAgencia;
            }
            set
            {
                _NumeroAgencia = value;
            }
        }

        public string CodigoProducto
        {
            get
            {
                return _CodigoProducto;
            }
            set
            {
                _CodigoProducto = value;
            }
        }

        public string NombreProducto
        {
            get
            {
                return _NombreProducto;
            }
            set
            {
                _NombreProducto = value;
            }
        }
#endregion
        public FInventarioProductosEspecificos()
        {
            InitializeComponent();
            cargarOpciones_de_Inicio();
        }

        public FInventarioProductosEspecificos(int NumeroAgencia, string CodigoProducto, string NombreProducto)
        {
            this._NumeroAgencia = NumeroAgencia;
            this._CodigoProducto = CodigoProducto;
            this._NombreProducto = NombreProducto;
            InitializeComponent();
            cargarOpciones_de_Inicio();
            
        }



        void checkboxHabilitarEdicionCodigoEspecificos_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.ingresoManualCodigo && checkHabilitarColumna.Checked)
            {
                if (MessageBox.Show(this, "Usted Opto por la opción de Generación de Codigos Especificos automatica realizada por el sistema." + Environment.NewLine + " Si Opta usted por habilitar esta opción Tome en cuenta de no Repetir Codigos Especificos " + Environment.NewLine + "¿Esta Seguro de Habilitar la Edición de la Columna de Codigos Especificos?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    CodigoProductoEspecifico.ReadOnly = false;
                    checkHabilitarColumna.Enabled = false;
                    ingresoManualCodigo = true;
                    IngresoCodigosHabilitado = true;
                }                
            }
        }
        

        public void cargarOpciones_de_Inicio()
        {
            cargarValoresIniciales();
            _InventarioProductosCLN = new InventariosProductosCLN();
            _InventarioProductosEspecificosCLN = new InventariosProductosEspecificosCLN();            

            
            //Forma de Adquisición
            this.CodigoFormaAdquisicion.DataSource = listadoFormasAdquision;
            this.CodigoFormaAdquisicion.ValueMember = "CodigoFormaAdquisicion";
            this.CodigoFormaAdquisicion.DisplayMember = "NombreFormaAdquisicion";

            this.cBoxModoAdquision.DataSource = listadoFormasAdquision;
            this.cBoxModoAdquision.ValueMember = "CodigoFormaAdquisicion";
            this.cBoxModoAdquision.DisplayMember = "NombreFormaAdquisicion";

            this.cBoxFormaAdquisicion.DataSource = listadoFormasAdquisionCopy;
            this.cBoxFormaAdquisicion.ValueMember = "CodigoFormaAdquisicion";
            this.cBoxFormaAdquisicion.DisplayMember = "NombreFormaAdquisicion";


            //Estados del producto Especifico
            this.CodigoEstado.DataSource = listadoEstados;
            this.CodigoEstado.ValueMember = "CodigoEstado";
            this.CodigoEstado.DisplayMember = "NombreEstado";            

            this.cBoxEstado.DataSource = listadoEstados;
            this.cBoxEstado.ValueMember = "CodigoEstado";
            this.cBoxEstado.DisplayMember = "NombreEstado";            

            cBoxEstadoGrilla.DataSource = listadoEstadosCopy;
            this.cBoxEstadoGrilla.ValueMember = "CodigoEstado";
            this.cBoxEstadoGrilla.DisplayMember = "NombreEstado";

            _DTProductosEspecificosTemporal = new DataTable();
            _DTProductosEspecificosTemporal.Locale = System.Globalization.CultureInfo.InvariantCulture;

            _DTInventarioProductos = new DataTable();
            _DTInventarioProductos.Locale = System.Globalization.CultureInfo.InvariantCulture;
            

            _DTInventarioProductosEspecificos = new DataTable();
            _DTInventarioProductosEspecificos.Locale = System.Globalization.CultureInfo.InvariantCulture;

            _DTInventarioProductosEspecificosBackup = new DataTable();
            crearColumnasParaDataTable();

            bdSourceProductosEspecificos.DataSource = _DTProductosEspecificosTemporal;
            dtGVNuevosProductosEspecificos.DataSource = bdSourceProductosEspecificos;
            dtGVNuevosProductosEspecificos.EditMode = DataGridViewEditMode.EditOnEnter;
            this.dtGVNuevosProductosEspecificos.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);
            
            dtGVNuevosProductosEspecificos.DefaultValuesNeeded += new DataGridViewRowEventHandler(dataGridView1_DefaultValuesNeeded);

            CodigoProductoEspecifico.ReadOnly = true;            

            pnlDatosEspecificos.Visible = false;
            dtGVHistorialProductosEspecificos.Height += LargoPanelDatosEntrada;
            dtGVNuevosProductosEspecificos.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dtGVNuevosProductosEspecificos_EditingControlShowing);
        }

        void dtGVNuevosProductosEspecificos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //solo me interesa validar la columna 2 
            if (this.dtGVNuevosProductosEspecificos.CurrentCell.ColumnIndex == 0)
            {
                if (!this.eventHookedUp)
                {
                    e.Control.KeyDown += this.Cell_KeyDown;                    
                    this.eventHookedUp = true;
                }
            }
            else
            {
                e.Control.KeyDown -= this.Cell_KeyDown;
                this.eventHookedUp = false;
            }
        }

        private void Cell_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                MessageBox.Show("Navegando");
        }

        void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            //throw new NotImplementedException();
            e.Row.Cells[0].Value = "";
            e.Row.Cells[1].Value = 1;
            e.Row.Cells[2].Value = DateTime.Now;
            e.Row.Cells[3].Value = "C";
            e.Row.Cells[4].Value = "A";
        }



        public void crearColumnasParaDataTable()
        {
            
            DataColumn DCCodigoProductoEspecifico = new DataColumn();
            DCCodigoProductoEspecifico.DataType = Type.GetType("System.String");
            DCCodigoProductoEspecifico.AllowDBNull = false;
            DCCodigoProductoEspecifico.Unique = true;
            DCCodigoProductoEspecifico.DefaultValue = "000-0000-1";
            DCCodigoProductoEspecifico.ColumnName = "CodigoProductoEspecifico";
            
            DataColumn DCTiempoGarantia = new DataColumn();
            DCTiempoGarantia.DataType = Type.GetType("System.Int16");
            DCTiempoGarantia.DefaultValue = 0;
            DCTiempoGarantia.ColumnName = "TiempoGarantiaPECompra";

            DataColumn DCFechaValidez = new DataColumn();
            DCFechaValidez.DataType = Type.GetType("System.DateTime");
            DCFechaValidez.ColumnName = "FechaHoraVencimientoPE";
            DCFechaValidez.DefaultValue = DateTime.Now;
                        
            DataColumn DCTipoAdquision = new DataColumn();
            DCTipoAdquision.DataType = Type.GetType("System.String");
            DCTipoAdquision.ColumnName = "CodigoFormaAdquisicion";
            DCTipoAdquision.DefaultValue = "C";

            DataColumn DCEstado = new DataColumn();
            DCEstado.DataType = Type.GetType("System.String");
            DCEstado.ColumnName = "CodigoEstado";
            DCEstado.DefaultValue = "A";

            _DTProductosEspecificosTemporal.Columns.Add(DCCodigoProductoEspecifico);
            _DTProductosEspecificosTemporal.Columns.Add(DCTiempoGarantia);
            _DTProductosEspecificosTemporal.Columns.Add(DCFechaValidez);
            _DTProductosEspecificosTemporal.Columns.Add(DCTipoAdquision);
            _DTProductosEspecificosTemporal.Columns.Add(DCEstado);

            _DTProductosEspecificosTemporal.PrimaryKey = null;
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = _DTProductosEspecificosTemporal.Columns["CodigoProductoEspecifico"];
            _DTProductosEspecificosTemporal.PrimaryKey = PrimaryKeyColumns;

            CodigoProductoEspecifico.DefaultCellStyle.NullValue = "00000000000000";

        }

        public void cargarValoresIniciales()
        {
            listadoFormasAdquision.Add(new FormaAdquisicionProductoEspecifico("C", "COMPRADO"));
            listadoFormasAdquision.Add(new FormaAdquisicionProductoEspecifico("A", "AGREGADO"));
            listadoFormasAdquision.Add(new FormaAdquisicionProductoEspecifico("D", "DONADO"));
            listadoFormasAdquision.Add(new FormaAdquisicionProductoEspecifico("P", "PRESTADO"));
            listadoFormasAdquision.Add(new FormaAdquisicionProductoEspecifico("T", "TRANSFERIDO"));

            listadoEstados.Add(new EstadoProductoEspecifico("A", "DISPONIBLE"));
            listadoEstados.Add(new EstadoProductoEspecifico("B", "DE BAJA"));
            listadoEstados.Add(new EstadoProductoEspecifico("R", "EN MANTIMIENTO"));
            //listadoEstados.Add(new EstadoProductoEspecifico("V", "VENDIDO"));


            listadoFormasAdquisionCopy.Add(new FormaAdquisicionProductoEspecifico("C", "COMPRADO"));
            listadoFormasAdquisionCopy.Add(new FormaAdquisicionProductoEspecifico("A", "AGREGADO"));
            listadoFormasAdquisionCopy.Add(new FormaAdquisicionProductoEspecifico("D", "DONADO"));
            listadoFormasAdquisionCopy.Add(new FormaAdquisicionProductoEspecifico("P", "PRESTADO"));
            listadoFormasAdquisionCopy.Add(new FormaAdquisicionProductoEspecifico("T", "TRANSFERIDO"));

            listadoEstadosCopy.Add(new EstadoProductoEspecifico("A", "DISPONIBLE"));
            listadoEstadosCopy.Add(new EstadoProductoEspecifico("B", "DE BAJA"));
            listadoEstadosCopy.Add(new EstadoProductoEspecifico("R", "EN MANTIMIENTO"));
        }





        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtGVNuevosProductosEspecificos.BeginEdit(true);
        }


        void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                //txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
                txtbox.KeyDown += new KeyEventHandler(txtbox_KeyDown);

            }

        }

        void txtbox_KeyDown(object sender, KeyEventArgs e)
        {
            //if ((e.Control && e.KeyCode == Keys.A) || e.KeyCode == Keys.Insert || e.KeyCode == Keys.F1)
            //if(e.KeyCode == Keys.F1)
            //{
            //    bdSourceProductosEspecificos.AddNew();
            //}
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //if (_DTProductosEspecificosTemporal.Rows.Count > 0 && !ingresoManualCodigo)
            //{
            //    string dato = _DTProductosEspecificosTemporal.Rows[e.RowIndex][0].ToString();
            //    dtGVNuevosProductosEspecificos.Rows[e.RowIndex].Cells[0].Value = _DTProductosEspecificosTemporal.Rows[e.RowIndex][0];
            //    dtGVNuevosProductosEspecificos.Rows[e.RowIndex].Cells[1].Value = _DTProductosEspecificosTemporal.Rows[e.RowIndex][1];
            //    dtGVNuevosProductosEspecificos.Rows[e.RowIndex].Cells[2].Value = _DTProductosEspecificosTemporal.Rows[e.RowIndex][2];
            //    dtGVNuevosProductosEspecificos.Rows[e.RowIndex].Cells[3].Value = _DTProductosEspecificosTemporal.Rows[e.RowIndex][3];
            //    dtGVNuevosProductosEspecificos.Rows[e.RowIndex].Cells[4].Value = _DTProductosEspecificosTemporal.Rows[e.RowIndex][4];
            //}
            //if (ingresoManualCodigo)
            //{

            //}
            
        }


        public void GenerarCodigos()
        {
            _DTProductosEspecificosTemporal.Clear();            
            int cantExitente = 0;
            if (Cantidad_a_Generar > 0) //si existe alguna restricción en la generación de codigos Especificos
            {
                cantExitente = Cantidad_a_Generar;
            }
            else //No se ha registrado aún productos especificos despues de la ultima adqusición, y no existen los mismos
            {
                cantExitente = Int32.Parse(_DTInventarioProductos.Rows[0]["CantidadExistencia"].ToString());
            }
            //btnGenerarCodigos.Enabled = false;
            if (cantExitente > CantidadMaximaDeGeneracionCodigosPE)
            {
                if (MessageBox.Show(this, "La Cantidad Estandar de Generación es :" + CantidadMaximaDeGeneracionCodigosPE.ToString() + ", Este proceso puede Tardar mucho y Se tendrá que realizar por Partes" + Environment.NewLine + "¿Esta Seguro de Generar esa cantidad de Productos Especificos?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    FIngresoCantidadProductoEspecifico fingresoCantidad = new FIngresoCantidadProductoEspecifico();
                    fingresoCantidad.ShowDialog(this);
                    cantExitente = fingresoCantidad.Cantidad;
                    fingresoCantidad.Dispose();
                }
                else
                {
                    btnGenerarCodigos.Enabled = true;
                    return;
                }
            }
            
            string Codigos = _InventarioProductosEspecificosCLN.ObtenerListadoCodigoProductoEspecificoGenerado(_CodigoProducto, cantExitente, tsTxtBoxComodin.Text.Trim(), "I");
            string[] Listado_de_Codigos = Codigos.Split(new char[] { ',' });//, StringSplitOptions.RemoveEmptyEntries);

            string codigoExpecifico;
            int tamanioComodin = tsTxtBoxComodin.Text.Trim().Length;
            int tamanioCodigoProducto = CodigoProducto.Trim().Length;
            for (int i = 0; i < cantExitente; i++)
            {                
                DataRow filaNueva = _DTProductosEspecificosTemporal.NewRow();
                codigoExpecifico = Listado_de_Codigos[i + 1].Trim().Substring(tamanioCodigoProducto+tamanioComodin,20-(tamanioCodigoProducto+tamanioComodin));
                if (generarConCodigoProductoToolStripMenuItem.Checked)
                    filaNueva[0] = CodigoProducto.Trim() + tsTxtBoxComodin.Text.Trim() + codigoExpecifico.Trim();
                else
                    filaNueva[0] = Listado_de_Codigos[i + 1].Trim();
                filaNueva[1] = 0;
                filaNueva[2] = DateTime.Now;
                filaNueva[3] = "C";
                filaNueva[4] = "A";                
                _DTProductosEspecificosTemporal.Rows.Add(filaNueva);
                filaNueva.AcceptChanges();
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {            
            GenerarCodigos();
            CodigosGenerados = true;            
        }

        private void ConfirmarAlmacenamientoCodigosEspecificos_Click(object sender, EventArgs e)
        {
            if (dtGVNuevosProductosEspecificos.RowCount == 0)
            {                
                MessageBox.Show(this, "Aún no ha ingresado ningún Código Especifico", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }


            int indicePosibleIngresoErroneo = 0;
            int indiceErroneo = 0, cantidad = 0;
            //(dtGVNuevosProductosEspecificos[4, indice].Value.Equals("B") || dtGVNuevosProductosEspecificos[4, indice].Value.Equals("R") || dtGVNuevosProductosEspecificos[4, indice].Value.Equals("V"))
            
            object contadorBajas = _DTProductosEspecificosTemporal.Compute("count(CodigoEstado)", "CodigoEstado = 'B'");
            object contadorMantenimiento = _DTProductosEspecificosTemporal.Compute("count(CodigoEstado)", "CodigoEstado = 'R'");
            if (Int32.Parse(contadorBajas.ToString()) > 0 || Int32.Parse(contadorMantenimiento.ToString())>0)
            {
                if (MessageBox.Show(this, "Exiten algunos Productos a los cuales decidío darlos de 'Baja' o enviarlos a 'Mantenimiento'. Puede cancelar la operacion y corregir sus Estados (No)" + Environment.NewLine + "¿Esta Seguro que Desea Continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    foreach (DataRow filaErronea in _DTProductosEspecificosTemporal.Rows)
                    {
                        if(filaErronea["CodigoEstado"].Equals("B") || filaErronea["CodigoEstado"].Equals("R"))
                        {
                            indicePosibleIngresoErroneo = _DTProductosEspecificosTemporal.Rows.IndexOf(filaErronea);
                            break;
                        }
                    }
                    dtGVNuevosProductosEspecificos.ClearSelection();
                    dtGVNuevosProductosEspecificos.Rows[indicePosibleIngresoErroneo].Selected = true;
                    return;
                }
            }

            bool existioError = false;            
           
            
            //desde aqui, todo ha sido aceptado correctamente y se procede a realizar el registro!
            _DTProductosEspecificosTemporal.AcceptChanges();
            string CodigoProductoEspecificoInicio = _DTProductosEspecificosTemporal.Rows[0]["CodigoProductoEspecifico"].ToString();
            string CodigoProductoEspecificoFin = _DTProductosEspecificosTemporal.Rows[_DTProductosEspecificosTemporal.Rows.Count - 1]["CodigoProductoEspecifico"].ToString();
            ProgressBar1.Step = 200 / dtGVNuevosProductosEspecificos.RowCount;
            foreach (DataGridViewRow fila in dtGVNuevosProductosEspecificos.Rows)
            {
      
                string codigoEspecifico = fila.Cells[0].Value.ToString().Trim();
                int tiempoGarantia = Int32.Parse(fila.Cells[1].Value.ToString());
                DateTime fecha = DateTime.Parse(fila.Cells[2].Value.ToString());
                string tipoAdquisicion = fila.Cells[3].Value.ToString();
                string estado = fila.Cells[4].Value.ToString();
                indiceErroneo = fila.Index;
                try
                {
                    _InventarioProductosEspecificosCLN.InsertarInventarioProductoEspecifico(_NumeroAgencia, _CodigoProducto, codigoEspecifico, tiempoGarantia, fecha, tipoAdquisicion, estado);                    
                    ProgressBar1.PerformStep();                    
                    switch (Char.Parse(estado))
                    {
                        case 'B':
                        case 'R':
                        case 'V':
                            _InventarioProductosCLN.ActualizarCantidadExistenciaEnInventarios(NumeroAgencia, CodigoProducto, 1, false);
                            cantidad++;//cuantos Productos Especificos han sido registrados como No Disponibles para la Venta, porque estan de Baja, en reparación, o vendidos
                            break;
                        default:
                            break;
                    }                    
                }
                
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Probablemente ya Ingreso algún Producto Especifico dentro del sistema, Por favor corríjalo. Ocurrio la siguiente Excepcion " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);                                        
                    existioError = true;
                    break;
                }
                
                
            }
            ProgressBar1.Step = 2;
            if (cantidad  > 0)
            {
                txtBoxCantidadExistencia.Text = (Int32.Parse(txtBoxCantidadExistencia.Text)- cantidad).ToString();                
            }

            if (existioError)
            {
                for (int i = 0; i < indiceErroneo; i++)
                {
                    _DTProductosEspecificosTemporal.Rows[0].Delete();
                    _DTProductosEspecificosTemporal.AcceptChanges();
                }
                dtGVNuevosProductosEspecificos.Rows[0].Selected = true;
                dtGVNuevosProductosEspecificos.Rows[0].Cells[0].ErrorText = "Este Código ya Se encuentra Registrado dentro de la Base de Datos";
                _DTInventarioProductosEspecificos = _InventarioProductosEspecificosCLN.ListarInventariosProductosEspecificosPorProducto(NumeroAgencia, CodigoProducto);
                bdSourceHistorialProductosEspecificos.DataSource = _DTInventarioProductosEspecificos;
                Cantidad_a_Generar -= indiceErroneo ;

                lblCantidadFaltante.Text = Cantidad_a_Generar.ToString();
                ProgressBar1.Value = 100 * Cantidad_a_Generar / Int32.Parse(this.lblCantidadRegistrada.Text)*2;


                return;
            }

            if (dtGVNuevosProductosEspecificos.RowCount == Cantidad_a_Generar)
            {
                IngresoCodigosHabilitado = false;
                ingresoManualCodigo = false;
                Cantidad_a_Generar = 0;
                _InventarioProductosCLN.ActualizarPEInventariadoInventarioProducto(NumeroAgencia, CodigoProducto, true, true);
                this.codigosPEGeneradosTodos = true;
                btnConfirmar.Enabled = false;
                    
            }
            else
            {
                Cantidad_a_Generar -= dtGVNuevosProductosEspecificos.RowCount;
                IngresoCodigosHabilitado = true;
                ingresoManualCodigo = true;
                btnGenerarCodigos.Enabled = true;
            }

            
            
            MessageBox.Show(this, "Se Ingresaron correctamente los Códigos Especificos", this.Text,MessageBoxButtons.OK, MessageBoxIcon.Information);
            int cantidadAnterior = Int32.Parse(lblCantidadFaltante.Text);
            int cantidadRegistrada = Int32.Parse(lblCantidadRegistrada.Text);
            lblCantidadFaltante.Text = (cantidadAnterior - dtGVNuevosProductosEspecificos.RowCount).ToString();
            lblCantidadRegistrada.Text = (cantidadRegistrada + dtGVNuevosProductosEspecificos.RowCount).ToString();
            //ProgressBar1.Value = 100 * (cantidadAnterior - cantidad) / (Int32.Parse(lblCantidadRegistrada.Text))*2;
            tabControl1.SelectedIndex = 1;

            _DTProductosEspecificosTemporal.AcceptChanges();            
            _DTProductosEspecificosTemporal.Clear();
            _DTInventarioProductosEspecificos.Clear();
            _DTInventarioProductosEspecificos = _InventarioProductosEspecificosCLN.ListarInventariosProductosEspecificosPorProducto(NumeroAgencia, CodigoProducto);
            
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = _DTInventarioProductosEspecificos.Columns["Código Específico"];
            _DTInventarioProductosEspecificos.PrimaryKey = PrimaryKeyColumns;

            _DTInventarioProductosEspecificosBackup = _DTInventarioProductosEspecificos.Copy();

            bdSourceHistorialProductosEspecificos.DataSource = _DTInventarioProductosEspecificos;
            dtGVHistorialProductosEspecificos.AutoGenerateColumns = false;
            dtGVHistorialProductosEspecificos.DataSource = bdSourceHistorialProductosEspecificos;
            

            //seleccionamos los productos recientemente ingresados
            DataRow FilaInicio = _DTInventarioProductosEspecificos.Rows.Find(CodigoProductoEspecificoInicio);
            DataRow FilaFin = _DTInventarioProductosEspecificos.Rows.Find(CodigoProductoEspecificoFin);
            if (FilaInicio != null && FilaFin != null)
            {
                int indiceInicio = _DTInventarioProductosEspecificos.Rows.IndexOf(FilaInicio);
                int indiceFin = _DTInventarioProductosEspecificos.Rows.IndexOf(FilaFin);
                for (int i = indiceInicio; i <= indiceFin; i++)
                {
                    _DTInventarioProductosEspecificos.Rows[i]["Imprimir"] = true;
                }
                _DTInventarioProductosEspecificos.AcceptChanges();
            }
        }


        public bool RevisarDuplicados(Object valor_A_Revisar)
        {
            for (int i = 0; i < dtGVNuevosProductosEspecificos.Rows.Count - 1; i++)
            {
                if (dtGVNuevosProductosEspecificos[0, i].Value.Equals(valor_A_Revisar))
                {
                    return true;
                }
            }
            return false;
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            //if (RevisarDuplicados(e.FormattedValue))
            //{
            //    MessageBox.Show(this, "No Puede Ingresar Codigos Repetidos", "Inventario de Productos Especificos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.dataGridView1.EditingControl.Text = "";
            //    e.Cancel = true;
            //}
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (_DTProductosEspecificosTemporal.Rows.Count > 0)
            {
                string dato = _DTProductosEspecificosTemporal.Rows[dtGVNuevosProductosEspecificos.CurrentRow.Index][0].ToString() + ",  Tiempo de Garantia " + _DTProductosEspecificosTemporal.Rows[dtGVNuevosProductosEspecificos.CurrentRow.Index][1].ToString() + _DTProductosEspecificosTemporal.Rows[dtGVNuevosProductosEspecificos.CurrentRow.Index][2].ToString();
                MessageBox.Show(dato);
            }
            else if (dtGVNuevosProductosEspecificos.CurrentRow.Cells[0].Value != null)
            {
                string dato = dtGVNuevosProductosEspecificos.CurrentRow.Cells[0].Value.ToString() + ",  Tiempo de Garantia " + dtGVNuevosProductosEspecificos.CurrentRow.Cells[1].Value.ToString() + dtGVNuevosProductosEspecificos.CurrentRow.Cells[2].Value.ToString();
                MessageBox.Show(dato);
            }
            
        }



        private void FInventarioProductosEspecificos_Load(object sender, EventArgs e)
        {

            ToolTip toolTip1 = new ToolTip();

            // Mandamos el Tiempo que aparecera eventualmente el Cuadro de Ayuda o Toop Tip Text.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Hacemo que siempre se muestre la Ayuda
            toolTip1.ShowAlways = true;

            // Enviamos el correspondiente mensaje a cada uno de los componentes
            toolTip1.SetToolTip(this.checkHabilitarColumna, "Habilitar la Edición de Esta columna");
            toolTip1.SetToolTip(this.checkImprimirTodos, "Seleccionar Todos los Productos para Imprimirlos");
            toolTip1.SetToolTip(this.dtPickerFechaVencimiento, "Despliegue el Botón para realizar el cambio de Fecha a todas las Filas Actuales");
            toolTip1.SetToolTip(this.cBoxFormaAdquisicion, "Despliegue el Botón para realizar el cambio de la Forma en que se Adquiere el producto a todas las Filas Actuales");
            toolTip1.SetToolTip(this.cBoxEstadoGrilla, "Despliegue el Botón para realizar el cambio del Estado de todas las Filas Actuales");

            bdNavHistorialProductosEspecificos.Visible = true;
            _DTProductosEspecificosTemporal.Clear();
            //_DTInventarioProductos = _InventarioProductosCLN.ObtenerInventarioProducto(_NumeroAgencia, _CodigoProducto);
            _DTInventarioProductosEspecificos = _InventarioProductosEspecificosCLN.ListarInventariosProductosEspecificosPorProducto(_NumeroAgencia, _CodigoProducto);

            _DTInventarioProductosEspecificos.PrimaryKey = null;
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = _DTInventarioProductosEspecificos.Columns["Código Específico"];
            _DTInventarioProductosEspecificos.PrimaryKey = PrimaryKeyColumns;

            

            _DTInventarioProductosEspecificosBackup = _DTInventarioProductosEspecificos.Copy();

            listadoPocionesEstadosCambiados.Clear();


            this.txtBoxNombreProducto.Text = _NombreProducto;
            this.txtBoxCodigoProducto.Text = _CodigoProducto;
            int cantidadExistencia = Int32.Parse(_DTInventarioProductos.Rows[0]["CantidadExistencia"].ToString());
            this.txtBoxCantidadExistencia.Text = cantidadExistencia.ToString();
            ProgressBar1.Value = 0;

            bdSourceHistorialProductosEspecificos.DataSource = _DTInventarioProductosEspecificos.DefaultView;            
            if (MostrarHistorial)
            {
                btnGenerarCodigos.Enabled = false;
                tabControl1.SelectedIndex = 1;
                btnGenerarCodigos.Enabled = false;
                ingresoManualCodigo = false;
                IngresoCodigosHabilitado = false;
            }
            else
            {
                tabControl1.Controls[0].Enabled = true;
                tabControl1.SelectedIndex = 0;
                _DTProductosEspecificosTemporal.Clear();
                string Condicion = "[Estado Actual] = 'DISPONIBLE'";
                object cantidadProductosEspecificos = _DTInventarioProductosEspecificos.Compute("count([Código Específico])", Condicion);
                if (cantidadProductosEspecificos != null)
                {
                    int cantidadProdEsp = Int32.Parse(cantidadProductosEspecificos.ToString());
                    Cantidad_a_Generar = cantidadExistencia - cantidadProdEsp;

                    
                    lblCantidadFaltante.Text = Cantidad_a_Generar.ToString();
                    lblCantidadRegistrada.Text = cantidadProdEsp.ToString();
                    //ProgressBar1.Value = 100 * cantidadProdEsp / cantidadExistencia;
                    if (cantidadProdEsp == 0 && Cantidad_a_Generar > 0)
                    {
                        //para que se generaren todos los codigos de Invnetarios existente
                        //Cantidad_a_Generar = -1;
                        if (MessageBox.Show(this, "Probablemente no realizó el Registro completo de los Productos especificos en la" + Environment.NewLine + "Ultima Adquisición que hizo de este producto." + Environment.NewLine + "¿Desea que el Sistema Se Encargue de Generarlos por usted, o Lo Hará Manualmente?", "Generación de Productos Específicos", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {                            
                            btnGenerarCodigos.Enabled = true;
                            ingresoManualCodigo = false;
                            CodigoProductoEspecifico.ReadOnly = true;
                            IngresoCodigosHabilitado = true;
                            bindingNavigatorAddNewItem.Visible = false;
                            checkHabilitarColumna.Visible = true;
                            checkHabilitarColumna.Enabled = true;
                            btnConfirmar.Enabled = false;
                        }
                        else
                        {
                            //deshabilitar Botón de generación de Productos
                            ingresoManualCodigo = true;
                            btnGenerarCodigos.Enabled = false;
                            CodigoProductoEspecifico.ReadOnly = false;
                            bindingNavigatorAddNewItem.Visible = cantidadExistencia > 0 ? true : false;
                            IngresoCodigosHabilitado = true;
                            bindingNavigatorAddNewItem.Visible = true;
                            checkHabilitarColumna.Visible = false;
                            checkHabilitarColumna.Enabled = false;
                            btnConfirmar.Enabled = true;
                        }
                    }
                    else
                    {
                        if (cantidadExistencia > cantidadProdEsp)
                        {
                            if (MessageBox.Show(this, "Ya existen Códigos Especificos Registrados para Este Producto, sin embargo no todos fueron Generados," + Environment.NewLine + " ¿Desea que el Sistema se Encargue de Generarlos por usted? ", "Generación de Productos Específicos", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                tabControl1.SelectedIndex = 0;
                                btnGenerarCodigos.Enabled = true;
                                ingresoManualCodigo = false;
                                CodigoProductoEspecifico.ReadOnly = true;
                                IngresoCodigosHabilitado = true;
                                bindingNavigatorAddNewItem.Visible = false;
                                checkHabilitarColumna.Visible = true;
                                checkHabilitarColumna.Enabled = true;
                                btnConfirmar.Enabled = false;
                            }
                            else
                            {
                                tabControl1.SelectedIndex = 1;
                                btnGenerarCodigos.Enabled = false;
                                bindingNavigatorAddNewItem.Enabled = true;
                                ingresoManualCodigo = true;
                                IngresoCodigosHabilitado = true;
                                CodigoProductoEspecifico.ReadOnly = false;
                                bindingNavigatorAddNewItem.Visible = cantidadExistencia == 0 ? false : true;
                                checkHabilitarColumna.Visible = false;
                                checkHabilitarColumna.Enabled = false;
                                btnConfirmar.Enabled = true;
                            }                            
                        }
                        else if (cantidadProdEsp > cantidadExistencia)
                        {
                            //PENDIENTES
                            tabControl1.SelectedIndex = 1;
                            tabControl1.Controls[0].Enabled = false;
                            if (MessageBox.Show(this, "Existen algunas Incoherencias: La Cantidad Actual de Existencia del productos es nula! o es Menor a la Cantidad de Productos Especificos Registrados," + Environment.NewLine+ " sin embargo aún existen Codigos Especificos Disponibles." + Environment.NewLine + "Porfavor Corrijalos!!" + Environment.NewLine + "¿Desea que el Sistema se Encargue de Poner de Baja estos Productos?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                //poner de baja todos los productos incoherentes
                            }
                            else
                            {
                                //el usuario se encarga de seleccionar que productos debe poner de baja
                            }

                        }
                        else
                        {
                            ProgressBar1.Value = ProgressBar1.Maximum;
                            tabControl1.SelectedIndex = 1;
                            tabControl1.Controls[0].Enabled = false;
                        }
                    }
                }
                CodigosGenerados = true;
                bdSourceProductosEspecificos.ResumeBinding();
                bindingNavigatorAddNewItem.Visible = cantidadExistencia > 0 ? true : false;
            }
            pnlDatosEspecificos.Visible = false;
            btnConfirmar.Enabled = true;
            //txtBoxGarantia.DataBindings.Add(new Binding("Text", bdSourceHistorialProductosEspecificos, "[Tiempo de Garantía]"));
            //dTimePickeVencimiento.DataBindings.Add(new Binding("Value", bdSourceHistorialProductosEspecificos, "[Fecha de Vencimiento]"));
            //bdSourceProductosEspecificos.DataSource = _DTProductosEspecificosTemporal;
            //dataGridView1.DataSource = bdSourceProductosEspecificos;
        }

        /// <summary>
        /// Cargamos el historial de Productos Especificos para este producto
        /// </summary>
        protected void cargarDatosRegistrados()
        {
            CodigosGenerados = false;            
            bdSourceProductosEspecificos.DataSource = _DTInventarioProductosEspecificos;
            dtGVNuevosProductosEspecificos.DataSource = bdSourceProductosEspecificos;
            foreach (DataGridViewRow fila in dtGVNuevosProductosEspecificos.Rows)
            {
                fila.Cells[0].Value = _DTInventarioProductosEspecificos.Rows[fila.Index]["CodigoProductoEspecifico"];
                fila.Cells[1].Value = _DTInventarioProductosEspecificos.Rows[fila.Index]["TiempoGarantiaPECompra"];
                fila.Cells[2].Value = _DTInventarioProductosEspecificos.Rows[fila.Index]["FechaHoraVencimientoPE"];
                fila.Cells[3].Value = _DTInventarioProductosEspecificos.Rows[fila.Index]["CodigoFormaAdquisicion"];
                fila.Cells[4].Value = _DTInventarioProductosEspecificos.Rows[fila.Index]["CodigoEstado"];
            }
        }

        private void btnGenerarCodigos_Click(object sender, EventArgs e)
        {

                if (btnGenerarCodigos.Enabled)
                {
                    btnGenerarCodigos.Enabled = false;
                    GenerarCodigos();
                }
                else
                {
                    MessageBox.Show("No Puede Genearar doz Veces el Código Especifico");
                }
                btnConfirmar.Enabled = true;
        }

        private void modificarFilaActualToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            if (dtGVHistorialProductosEspecificos.CurrentRow.Cells[4].Value.Equals("DISPONIBLE") || dtGVHistorialProductosEspecificos.CurrentRow.Cells[4].Value.Equals("EN MANTIMIENTO"))
            {                
                txtBoxGarantia.Text = dtGVHistorialProductosEspecificos[1, dtGVHistorialProductosEspecificos.CurrentRow.Index].Value.ToString();
                dTimePickeVencimiento.Value = DateTime.Parse(dtGVHistorialProductosEspecificos[2, dtGVHistorialProductosEspecificos.CurrentRow.Index].Value.ToString());
                cBoxEstado.SelectedValue = "A";
                cBoxModoAdquision.SelectedValue = "C";
                dtGVHistorialProductosEspecificos.Height -= LargoPanelDatosEntrada;
                pnlDatosEspecificos.Visible = true;
                txtBoxGarantia.Focus();
                lblProductoEspecifico.Text = "Codigo Producto Especifico : " + dtGVHistorialProductosEspecificos[0, dtGVHistorialProductosEspecificos.CurrentRow.Index].Value.ToString();
            }
            else
            {
                MessageBox.Show(this, "No puede Modificar los Valores del Producto Especifico, cuando el Mismo ya ha sido Vendido o ha sido dado de Baja", "Inventario de Productos Específicos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void guardarCambiosFilaActualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pnlDatosEspecificos.Visible)
            {
                _DTInventarioProductosEspecificos.Rows[dtGVHistorialProductosEspecificos.CurrentRow.Index][1] = Int32.Parse(txtBoxGarantia.Text);
                _DTInventarioProductosEspecificos.Rows[dtGVHistorialProductosEspecificos.CurrentRow.Index][2] = dTimePickeVencimiento.Value;
                _DTInventarioProductosEspecificos.Rows[dtGVHistorialProductosEspecificos.CurrentRow.Index][3] = cBoxModoAdquision.SelectedValue;
                _DTInventarioProductosEspecificos.Rows[dtGVHistorialProductosEspecificos.CurrentRow.Index][4] = cBoxEstado.SelectedValue;
                _DTInventarioProductosEspecificos.Rows[dtGVHistorialProductosEspecificos.CurrentRow.Index].AcceptChanges();

                dtGVHistorialProductosEspecificos[1, dtGVHistorialProductosEspecificos.CurrentRow.Index].Value = txtBoxGarantia.Text;
                dtGVHistorialProductosEspecificos[2, dtGVHistorialProductosEspecificos.CurrentRow.Index].Value = dTimePickeVencimiento.Value;
                switch (Char.Parse(cBoxModoAdquision.SelectedValue.ToString()))
                {
                    case 'A':
                        dtGVHistorialProductosEspecificos[3, dtGVHistorialProductosEspecificos.CurrentRow.Index].Value = "AGREGADO";
                        break;
                    case 'C':
                        dtGVHistorialProductosEspecificos[3, dtGVHistorialProductosEspecificos.CurrentRow.Index].Value = "COMPRADO";
                        break;
                    case 'D':
                        dtGVHistorialProductosEspecificos[3, dtGVHistorialProductosEspecificos.CurrentRow.Index].Value = "DONADO";
                        break;
                    case 'P':
                        dtGVHistorialProductosEspecificos[3, dtGVHistorialProductosEspecificos.CurrentRow.Index].Value = "PRESTADO";
                        break;
                    case 'T':
                        dtGVHistorialProductosEspecificos[3, dtGVHistorialProductosEspecificos.CurrentRow.Index].Value = "TRANSFERIDO";
                        break;
                    default:
                        break;
                }
                switch (Char.Parse(cBoxEstado.SelectedValue.ToString()))
                {
                    case 'A':
                        dtGVHistorialProductosEspecificos[4, dtGVHistorialProductosEspecificos.CurrentRow.Index].Value = "DISPONIBLE";
                        break;
                    case 'B':
                        dtGVHistorialProductosEspecificos[4, dtGVHistorialProductosEspecificos.CurrentRow.Index].Value = "DE BAJA";
                        break;
                    case 'R':
                        dtGVHistorialProductosEspecificos[4, dtGVHistorialProductosEspecificos.CurrentRow.Index].Value = "EN MANTIMIENTO";
                        break;
                    case 'V':
                        dtGVHistorialProductosEspecificos[4, dtGVHistorialProductosEspecificos.CurrentRow.Index].Value = "VENDIDO";
                        break;
                    default:
                        break;
                }
                if (!listadoPocionesEstadosCambiados.Contains(dtGVHistorialProductosEspecificos.CurrentRow.Index))
                {
                    listadoPocionesEstadosCambiados.Add(dtGVHistorialProductosEspecificos.CurrentRow.Index);
                }

                pnlDatosEspecificos.Visible = false;
                dtGVHistorialProductosEspecificos.Height += LargoPanelDatosEntrada;
            }
            else
                MessageBox.Show("Aun no ha Realizado un Cambio");
            
        }

        private void cancelarCambiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _DTInventarioProductosEspecificos = _DTInventarioProductosEspecificosBackup.Copy();
            bdSourceHistorialProductosEspecificos.DataSource = _DTInventarioProductosEspecificos;
            dtGVHistorialProductosEspecificos.EndEdit();
            bdSourceHistorialProductosEspecificos.EndEdit();
            listadoPocionesEstadosCambiados.Clear();
        }

        private void BtnGuardarCambiosHistorial_Click(object sender, EventArgs e)
        {
            string codigoEspecifico;
            int TiempoGarantia;
            DateTime FechaVencimiento;
            string TipoAdquisicion;
            string codigoEstado;
            //Guardar cambios
            if (listadoPocionesEstadosCambiados.Count > 0)
            {
                int indice = 0;
                for (int i = 0; i < listadoPocionesEstadosCambiados.Count; i++)
                {
                    indice = listadoPocionesEstadosCambiados[i];
                    codigoEspecifico = _DTInventarioProductosEspecificos.Rows[indice][0].ToString().Trim();
                    TiempoGarantia = Int32.Parse(_DTInventarioProductosEspecificos.Rows[indice][1].ToString().Trim());
                    FechaVencimiento = DateTime.Parse(_DTInventarioProductosEspecificos.Rows[indice][2].ToString().Trim());
                    TipoAdquisicion = _DTInventarioProductosEspecificos.Rows[indice][3].ToString().Trim();
                    if (TipoAdquisicion.CompareTo("AGREGADO") == 0)
                        TipoAdquisicion = "A";
                    else if (TipoAdquisicion.CompareTo("COMPRADO") == 0)
                        TipoAdquisicion = "C";
                    else if (TipoAdquisicion.CompareTo("DONADO") == 0)
                        TipoAdquisicion = "D";
                    else if (TipoAdquisicion.CompareTo("TRANSFERIDO") == 0)
                        TipoAdquisicion = "T";
                    else
                        TipoAdquisicion = "P";

                    codigoEstado = _DTInventarioProductosEspecificos.Rows[indice][4].ToString().Trim();
                    if (codigoEstado.CompareTo("DISPONIBLE") == 0)
                    {
                        codigoEstado = "A";
                    }
                    else if (codigoEstado.CompareTo("DE BAJA") == 0)
                        codigoEstado = "B";
                    else if (codigoEstado.CompareTo("EN MANTIMIENTO") == 0)
                    {
                        codigoEstado = "R";
                    }
                    else
                        codigoEstado = "V";
                    _InventarioProductosEspecificosCLN.ActualizarInventarioProductoEspecifico(NumeroAgencia, CodigoProducto, codigoEspecifico, TiempoGarantia, FechaVencimiento, TipoAdquisicion, codigoEstado);
                    if (!_DTInventarioProductosEspecificos.Rows[indice][4].Equals(_DTInventarioProductosEspecificosBackup.Rows[indice][4]))
                    {
                        switch (Char.Parse(codigoEstado))
                        {
                            case 'A':
                                _InventarioProductosCLN.ActualizarCantidadExistenciaEnInventarios(NumeroAgencia, CodigoProducto, 1, true);
                                break;
                            case 'B':
                                if (_DTInventarioProductosEspecificosBackup.Rows[indice][4].ToString().CompareTo("DISPONIBLE") == 0)
                                    _InventarioProductosCLN.ActualizarCantidadExistenciaEnInventarios(NumeroAgencia, CodigoProducto, 1, false);
                                break;
                            case 'R':
                                _InventarioProductosCLN.ActualizarCantidadExistenciaEnInventarios(NumeroAgencia, CodigoProducto, 1, false);
                                break;
                            case 'V':
                                _InventarioProductosCLN.ActualizarCantidadExistenciaEnInventarios(NumeroAgencia, CodigoProducto, 1, false);
                                break;
                            default:
                                break;
                        }
                    }
                    MessageBox.Show(this, "Se Realizaron Correctamente los Cambios", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                listadoPocionesEstadosCambiados.Clear();
                //_DTInventarioProductos = _InventarioProductosCLN.ObtenerInventarioProducto(NumeroAgencia, CodigoProducto);
                //_DTInventarioProductosEspecificosBackup = _InventarioProductosEspecificosCLN.ListarInventariosProductosEspecificosPorProducto(NumeroAgencia, CodigoProducto);
                //txtBoxCantidadExistencia.Text = _DTInventarioProductos.Rows[0][2].ToString();
                //Cantidad_a_Generar = Cantidad_a_Generar - Int32.Parse(txtBoxCantidadExistencia.Text);
            }
            else
            {
                MessageBox.Show(this, "Aún no ha Realizado ningun Cambio" + Environment.NewLine + "Si Desea Guardar algun Cambio, Procesada a Realizar Alguno", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            
            string CodigoBusqueda = txtBosTextoBusqueda.Text.Trim();
            if (CodigoBusqueda != "" && CodigoBusqueda != null)
            {                
                DataRow Fila = _DTInventarioProductosEspecificos.Rows.Find(CodigoBusqueda);
                if (Fila != null)
                {
                    //int IndiceEncontrado = bdSourceHistorialProductosEspecificos.Find("Código Específico", CodigoBusqueda);
                    //if (IndiceEncontrado != -1)
                    //    bdSourceHistorialProductosEspecificos.Position = IndiceEncontrado;
                    int IndiceEncontrado = _DTInventarioProductosEspecificos.Rows.IndexOf(Fila);
                    bdSourceHistorialProductosEspecificos.Position = IndiceEncontrado;
                    dtGVHistorialProductosEspecificos.ClearSelection();
                    dtGVHistorialProductosEspecificos.Rows[IndiceEncontrado].Selected = true;
                }
                else if (MessageBox.Show(this, "No se encuentra El código Ingresado, ¿Desea seguir Buscando?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    txtBosTextoBusqueda.Focus();
                    txtBosTextoBusqueda.SelectAll();
                }
            }
            else
            {
                MessageBox.Show(this, "No Puede buscar Cadenas Vacias, Ingrese un Código a Buscar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBosTextoBusqueda.Clear();
                txtBosTextoBusqueda.Focus();
                
            }
            
        }

        private void txtBosTextoBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                toolStripButton1_Click_1(sender, e as EventArgs);
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            dtGVNuevosProductosEspecificos.CurrentCell = dtGVNuevosProductosEspecificos[0, dtGVNuevosProductosEspecificos.RowCount - 1];
            dtGVNuevosProductosEspecificos.BeginEdit(true);
            //string Condicion = "[Estado Actual] = 'DISPONIBLE'";
            //object cantidadProductosEspecificos = _DTInventarioProductosEspecificos.Compute("count([Código Específico])", Condicion);
            //if (cantidadProductosEspecificos != null)
            //{
            //    int cantidadProdEsp = Int32.Parse(cantidadProductosEspecificos.ToString());

            //}
            
            //MessageBox.Show(dtGVNuevosProductosEspecificos.RowCount.ToString()+",  "+cantidadProductosEspecificos.ToString());
            if (Cantidad_a_Generar == dtGVNuevosProductosEspecificos.RowCount)
            {
                bindingNavigatorAddNewItem.Visible = false;
            }
        }

        private void dtGVNuevosProductosEspecificos_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            MessageBox.Show("Usuario terminó de agregar Fila");
        }


        private void AgregarValoresDTProductosEspecificosTemporal(DataGridViewCellEventArgs e)
        {
            if (dtGVNuevosProductosEspecificos.RowCount > 0 && !dtGVNuevosProductosEspecificos.IsCurrentRowDirty && dtGVNuevosProductosEspecificos[0, e.RowIndex].Value != null)
            {                
                if (_DTProductosEspecificosTemporal.Rows.Find(dtGVNuevosProductosEspecificos[0, e.RowIndex].Value) == null )
                {
                    
                    //DataRow fila = _DTProductosEspecificosTemporal.NewRow();
                    //fila[0] = dtGVNuevosProductosEspecificos[0, e.RowIndex].Value;
                    //fila[1] = dtGVNuevosProductosEspecificos[1, e.RowIndex].Value;
                    //fila[2] = dtGVNuevosProductosEspecificos[2, e.RowIndex].Value;
                    //fila[3] = dtGVNuevosProductosEspecificos[3, e.RowIndex].Value;
                    //fila[4] = dtGVNuevosProductosEspecificos[4, e.RowIndex].Value;
                    //_DTProductosEspecificosTemporal.Rows.Add(fila);
                    //fila.AcceptChanges();
                    DataRow fila_x_Defecto = _DTProductosEspecificosTemporal.Rows.Find("______-1");
                    if (fila_x_Defecto != null)
                    {
                        //_DTProductosEspecificosTemporal.Rows.Remove(fila_x_Defecto);
                        fila_x_Defecto.BeginEdit();
                        fila_x_Defecto[0]=dtGVNuevosProductosEspecificos[0, e.RowIndex].Value;
                        fila_x_Defecto[1] = dtGVNuevosProductosEspecificos[1, e.RowIndex].Value;
                        fila_x_Defecto[2] = dtGVNuevosProductosEspecificos[2, e.RowIndex].Value;
                        fila_x_Defecto[3] = dtGVNuevosProductosEspecificos[3, e.RowIndex].Value;
                        fila_x_Defecto[4] = dtGVNuevosProductosEspecificos[4, e.RowIndex].Value;
                        fila_x_Defecto.AcceptChanges();
                    }
                }
                else
                {
                    //_DTProductosEspecificosTemporal.Rows[e.RowIndex][0] = dtGVNuevosProductosEspecificos[0, e.RowIndex].Value;
                    _DTProductosEspecificosTemporal.Rows[e.RowIndex][1] = dtGVNuevosProductosEspecificos[1, e.RowIndex].Value;
                    _DTProductosEspecificosTemporal.Rows[e.RowIndex][2] = dtGVNuevosProductosEspecificos[2, e.RowIndex].Value;
                    _DTProductosEspecificosTemporal.Rows[e.RowIndex][3] = dtGVNuevosProductosEspecificos[3, e.RowIndex].Value;
                    _DTProductosEspecificosTemporal.Rows[e.RowIndex][4] = dtGVNuevosProductosEspecificos[4, e.RowIndex].Value;
                }
            }
        }


        private void dtGVNuevosProductosEspecificos_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            dtGVNuevosProductosEspecificos.EndEdit();
            //AgregarValoresDTProductosEspecificosTemporal(e);
        }

        //private void dtGVNuevosProductosEspecificos_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if(e.KeyCode == Keys.Tab)
        //        MessageBox.Show("Navegando");
        //}


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IngresoCodigosHabilitado && tabControl1.SelectedIndex == 0)
            {
                MessageBox.Show("No puede Ingresar a Esta Pestaña Momentaneamente, Probablemente, Todos Los Codigos Especificos ya Fueron Generados");
                tabControl1.SelectedIndex = 1;
                return;
            }
        }

        private void dtGVNuevosProductosEspecificos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) // si han terminado de editar la columna del codigo Especifico
            {
                if (ingresoManualCodigo && IngresoCodigosHabilitado && dtGVNuevosProductosEspecificos.RowCount > 0 && dtGVNuevosProductosEspecificos.CurrentRow.Cells[0].Value != null && generarConCodigoProductoToolStripMenuItem.Checked)
                {
                    string codigoEspecificoActual = dtGVNuevosProductosEspecificos.CurrentRow.Cells[0].Value.ToString().Trim();
                    if (!codigoEspecificoActual.Contains(CodigoProducto.Trim()))
                    {
                        int tamanioCodigoActual = codigoEspecificoActual.Length;
                        int tamanioCodigoProducto = CodigoProducto.Trim().Length;
                        int tamanioComodin = tsTxtBoxComodin.Text.Trim().Length;
                        string TextoComodin = tsTxtBoxComodin.Text.Trim();
                        if (caracterVaciosinSeparaciónToolStripMenuItem.Checked)
                        {
                            tamanioComodin = 0;
                            TextoComodin = "";

                        }
                        if ((tamanioCodigoActual + tamanioCodigoProducto + tamanioComodin) > 20)
                        {
                            dtGVNuevosProductosEspecificos.CurrentRow.Cells[0].Value = CodigoProducto.Trim() + TextoComodin + codigoEspecificoActual.Substring(0, codigoEspecificoActual.Length - ((tamanioComodin + tamanioCodigoProducto + tamanioCodigoActual) - 20));                            
                        }
                        else
                        {
                            dtGVNuevosProductosEspecificos.CurrentRow.Cells[0].Value = CodigoProducto.Trim() + TextoComodin + codigoEspecificoActual;
                        }
                    }
                }
                //dtGVNuevosProductosEspecificos.Rows[e.RowIndex].ErrorText = String.Empty;
                if (dtGVNuevosProductosEspecificos.CurrentRow != null)
                    dtGVNuevosProductosEspecificos.CurrentRow.Cells[0].Value = dtGVNuevosProductosEspecificos.CurrentRow.Cells[0].Value.ToString().ToUpper();
            }
            
        }

        //private void dtGVNuevosProductosEspecificos_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        //{
        //    //DataGridViewElementStates state = e.StateChanged;
        //    //string msg = String.Format("Row {0}, Column {1}, {2}",
        //    //    e.Cell.RowIndex, e.Cell.ColumnIndex, e.StateChanged);
        //    //MessageBox.Show(msg, "Cell State Changed");
        //    if (e.StateChanged == DataGridViewElementStates.Selected)
        //        e.Cell.Selected = false;

        //}

        private void dtGVNuevosProductosEspecificos_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dtGVNuevosProductosEspecificos.CurrentCell.Value == null)
            {
                switch (e.ColumnIndex)
                {
                    case 0:
                        dtGVNuevosProductosEspecificos[0, e.RowIndex].Value = "00000000";
                        break;
                    case 1:
                        dtGVNuevosProductosEspecificos[1, e.RowIndex].Value = 0;
                        break;
                    case 2:
                        dtGVNuevosProductosEspecificos[2, e.RowIndex].Value = DateTime.Now;
                        break;
                    case 3:
                        dtGVNuevosProductosEspecificos[3, e.RowIndex].Value = "C";
                        break;
                    case 4:
                        dtGVNuevosProductosEspecificos[4, e.RowIndex].Value = "A";
                        break;
                    default:
                        break;
                }
                dtGVNuevosProductosEspecificos.EndEdit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this._DTInventarioProductosEspecificos.Clear();
            this._DTProductosEspecificosTemporal.Clear();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dtGVNuevosProductosEspecificos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(this,"Problablemente ingresó un Código Producto Específico  repetido, o sus Datos fueron mal Introducidos"+Environment.NewLine+"Por Favor Proceda a Corregirlos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //dtGVNuevosProductosEspecificos.CurrentCell = dtGVNuevosProductosEspecificos[e.ColumnIndex, e.RowIndex];
            //dtGVNuevosProductosEspecificos.BeginEdit(true);
            e.Cancel = false;
        }

        private void dtGVNuevosProductosEspecificos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            
            if (dtGVNuevosProductosEspecificos.Columns[e.ColumnIndex].Name == "CodigoProductoEspecifico")
            {
                if (e.FormattedValue == null && String.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    dtGVNuevosProductosEspecificos.Rows[e.RowIndex].ErrorText = "El Código de Producto Específico no puede ser Nulo";
                    e.Cancel = true;
                }                
                DataRow fila = _DTProductosEspecificosTemporal.Rows.Find(e.FormattedValue.ToString());                
                if (fila != null ) // si El producto Existe
                {
                    int indiceFila = _DTProductosEspecificosTemporal.Rows.IndexOf(fila);
                    if (indiceFila != e.RowIndex)
                    {
                        dtGVNuevosProductosEspecificos.Rows[e.RowIndex].ErrorText = "El Código de Producto Específico no puede ser Repetido";
                        e.Cancel = false;
                    }                    
                }
            }

            if (dtGVNuevosProductosEspecificos.Columns[e.ColumnIndex].Name == "TiempoGarantiaPECompra")
            {
                if (e.FormattedValue == null && String.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    dtGVNuevosProductosEspecificos.Rows[e.RowIndex].ErrorText = "El tiempo de Garantía no puede ser Nulo";
                    e.Cancel = true;
                }
                int cantidad = 0;
                if (!Int32.TryParse(e.FormattedValue.ToString(), out cantidad))
                {
                    dtGVNuevosProductosEspecificos.Rows[e.RowIndex].ErrorText = "El tiempo de Garantía es un valor númerico, no puede Ingresar caracteres";
                    e.Cancel = true;
                }
            }


            //MessageBox.Show(_DTProductosEspecificosTemporal.Rows[_DTProductosEspecificosTemporal.Rows.Count - 1][0].ToString());
        }

        private void bdSourceProductosEspecificos_AddingNew(object sender, AddingNewEventArgs e)
        {
            //MessageBox.Show("Se añade uno, Cantidad " + dtGVNuevosProductosEspecificos.RowCount.ToString());
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (dtGVNuevosProductosEspecificos.RowCount < Cantidad_a_Generar && bindingNavigatorAddNewItem.Visible == false)
            {
                bindingNavigatorAddNewItem.Visible = true;
            }
            _DTProductosEspecificosTemporal.AcceptChanges();
        }

        private void btnImprimirCodProEspecifico_Click(object sender, EventArgs e)
        {
            DataTable DTTemporalCodigosProductosEspecifcos = new DataTable();
            DataColumn DCNombreProducto = new DataColumn();
            DCNombreProducto.DataType = Type.GetType( "System.String");
            DCNombreProducto.ColumnName = "NombreProducto";

            DataColumn DCCodigoProducto = new DataColumn();
            DCCodigoProducto.DataType = Type.GetType("System.String");
            DCCodigoProducto.ColumnName = "CodigoProducto";

            DataColumn DCCodigoProductoEspecifico = new DataColumn();
            DCCodigoProductoEspecifico.DataType = Type.GetType("System.String");
            DCCodigoProductoEspecifico.ColumnName = "CodigoProductoEspecifico";

            DTTemporalCodigosProductosEspecifcos.Columns.AddRange(new DataColumn[] {DCNombreProducto,DCCodigoProducto,DCCodigoProductoEspecifico });
            object cantidadImpresion = _DTInventarioProductosEspecificos.Compute("count(Imprimir)", "Imprimir = true");
            if (cantidadImpresion.Equals(0))
            {
                MessageBox.Show(this,"Aún no ha Seleccionado un determinado Código Específico a Imprimir"+Environment.NewLine +"Puede Seleccionar la impresión de todos, haciendo click en la columna 'Imprimir?', sobre el pequeño cuadro check",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Exclamation );
                return;
            }
            DTTemporalCodigosProductosEspecifcos.TableName = "CodigosProductosEspecificosReporte";            

            for (int i = 0; i < dtGVHistorialProductosEspecificos.Rows.Count; i++)
            {
                if (_DTInventarioProductosEspecificos.Rows[i]["Imprimir"].Equals(true) || _DTInventarioProductosEspecificos.Rows[i]["Imprimir"].Equals("true"))
                {
                    DataRow FilaNueva = DTTemporalCodigosProductosEspecifcos.NewRow();
                    FilaNueva["NombreProducto"] = txtBoxNombreProducto.Text.Trim();
                    FilaNueva["CodigoProducto"] = txtBoxCodigoProducto.Text.Trim();
                    FilaNueva["CodigoProductoEspecifico"] = _DTInventarioProductosEspecificos.Rows[i][0];

                    DTTemporalCodigosProductosEspecifcos.Rows.Add(FilaNueva);
                    FilaNueva.AcceptChanges();
                }                    
            }
            DataTable DTDatosAgencia = new CLCLN.Sistema.AgenciasCLN().ListarDatosAgenciasParaTransaccionesReportes(NumeroAgencia);
            FReporteCompraProductosGeneral ReporteCompraproductosForm = new FReporteCompraProductosGeneral(DTDatosAgencia, DTTemporalCodigosProductosEspecifcos, true);
            ReporteCompraproductosForm.Show();
        }

        private void caracterVaciosinSeparaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void checkImprimirTodos_CheckedChanged(object sender, EventArgs e)
        {
            bool EstadoImpresionCheckEspecificos = checkImprimirTodos.Checked;
            for (int i = 0; i < dtGVHistorialProductosEspecificos.RowCount; i++)
            {
                dtGVHistorialProductosEspecificos[5, i].Value = EstadoImpresionCheckEspecificos;
            }
            dtGVHistorialProductosEspecificos.EndEdit();
        }

        private void dateTimePicker1_DropDown(object sender, EventArgs e)
        {
            dtPickerFechaVencimiento.Location = new Point(dtPickerFechaVencimiento.Location.X - 120, dtPickerFechaVencimiento.Location.Y);
            dtPickerFechaVencimiento.Width = 120;
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            //dtPickerFechaVencimiento.Location = new Point(416 , 31);
            dtPickerFechaVencimiento.Location = new Point(dtPickerFechaVencimiento.Location.X + 120, dtPickerFechaVencimiento.Location.Y);
            dtPickerFechaVencimiento.Width = 19;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (_DTProductosEspecificosTemporal != null)
            {
                foreach (DataRow fila in _DTProductosEspecificosTemporal.Rows)
                    fila["FechaHoraVencimientoPE"] = dtPickerFechaVencimiento.Value;
                _DTProductosEspecificosTemporal.AcceptChanges();
            }            
        }

        private void cBoxFormaAdquisicion_DropDown(object sender, EventArgs e)
        {
            cBoxFormaAdquisicion.Location = new Point(cBoxFormaAdquisicion.Location.X - 120, cBoxFormaAdquisicion.Location.Y);
            cBoxFormaAdquisicion.Width = 120;
        }

        private void cBoxFormaAdquisicion_DropDownClosed(object sender, EventArgs e)
        {
            cBoxFormaAdquisicion.Location = new Point(cBoxFormaAdquisicion.Location.X + 120, cBoxFormaAdquisicion.Location.Y);
            cBoxFormaAdquisicion.Width = 19;
        }

        private void cBoxFormaAdquisicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_DTProductosEspecificosTemporal != null)
            {
                foreach (DataRow fila in _DTProductosEspecificosTemporal.Rows)
                    fila["CodigoFormaAdquisicion"] = cBoxFormaAdquisicion.SelectedValue;
                _DTProductosEspecificosTemporal.AcceptChanges();
            }            
        }

        private void cBoxEstadoGrilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_DTProductosEspecificosTemporal != null)
            {
                foreach (DataRow fila in _DTProductosEspecificosTemporal.Rows)
                    fila["CodigoEstado"] = cBoxEstadoGrilla.SelectedValue;
                _DTProductosEspecificosTemporal.AcceptChanges();
            } 
        }

        private void cBoxEstadoGrilla_DropDown(object sender, EventArgs e)
        {
            cBoxEstadoGrilla.Location = new Point(cBoxEstadoGrilla.Location.X - 100, cBoxEstadoGrilla.Location.Y);
            cBoxEstadoGrilla.Width = 100;
        }

        private void cBoxEstadoGrilla_DropDownClosed(object sender, EventArgs e)
        {
            cBoxEstadoGrilla.Location = new Point(cBoxEstadoGrilla.Location.X + 100, cBoxEstadoGrilla.Location.Y);
            cBoxEstadoGrilla.Width = 19;
        }

        private void txtBosTextoBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBosTextoBusqueda.Text.Trim().Length == 30)
                toolStripButton1_Click_1(sender, e as EventArgs);
        }

        private void txtBosTextoBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                toolStripButton1_Click_1(sender, e as EventArgs);
            }
        }


        private int m_nPosition = 0;

        // main code of the form removed for readability

        public int Position
        {
            get
            {
                return m_nPosition;
            }

            set
            {
                m_nPosition = value;
            }
        }

        public void UpdateProgressPosition()
        {
            ProgressBar1.Value = m_nPosition;
        }

        private void txtBoxGarantia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (((Keys)e.KeyChar)) != Keys.Back)
            {
                e.Handled = true;
                System.Media.SystemSounds.Beep.Play();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            pnlDatosEspecificos.Visible = false;
            dtGVHistorialProductosEspecificos.Height += LargoPanelDatosEntrada;
        }

        private void elimarCodigoEspecificoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtGVHistorialProductosEspecificos.CurrentRow.Cells[4].Value.Equals("DISPONIBLE") || dtGVHistorialProductosEspecificos.CurrentRow.Cells[4].Value.Equals("EN MANTIMIENTO"))
            {
                string CodigoProductoEspecificoSeleccionado = _DTInventarioProductosEspecificos.Rows[dtGVHistorialProductosEspecificos.CurrentRow.Index][DGCCodigoEspecífico.Index].ToString();
                //MessageBox.Show("Codigo "+ CodigoProducto +",  Especifico " + CodigoProductoEspecificoSeleccionado);
                if (MessageBox.Show(this, "Se encuentra seguro de Eliminar el Codigo Especifico " + CodigoProductoEspecificoSeleccionado + " correspondiente al Codigo " + CodigoProducto, "Eliminar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                try 
	            {
                    _InventarioProductosEspecificosCLN.EliminarInventarioProductoEspecifico(NumeroAgencia, CodigoProducto, CodigoProductoEspecificoSeleccionado);
                    _DTInventarioProductosEspecificos.Rows.Remove(_DTInventarioProductosEspecificos.Rows[dtGVHistorialProductosEspecificos.CurrentRow.Index]);
                    _DTInventarioProductos.AcceptChanges();
	            }
	            catch (Exception ex)
	            {
		            MessageBox.Show(this,"No se pudo eliminar el Código Específico, ocurrio la siguiente excepción " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
	            }
            }
            else
            {
                MessageBox.Show(this, "No puede Modificar los Valores del Producto Especifico, cuando el Mismo ya ha sido Vendido o ha sido dado de Baja", "Inventario de Productos Específicos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FInventarioProductosEspecificos_Resize(object sender, EventArgs e)
        {
            //checkHabilitarColumna.Location = new Point(checkHabilitarColumna.Location.Y, dtGVNuevosProductosEspecificos.Columns[0].Width + 10);
            //dtPickerFechaVencimiento.Location = new Point(dtGVNuevosProductosEspecificos.Columns[2].HeaderCell.ContentBounds.Location.X, dtPickerFechaVencimiento.Location.Y);

            int acumuladorAncho = 0;
            for (int i = 0; i < dtGVNuevosProductosEspecificos.Columns.Count; i++)
            {
                acumuladorAncho += dtGVNuevosProductosEspecificos.Columns[i].Width;
                if(i == 0)
                    checkHabilitarColumna.Location = new Point(-15 + acumuladorAncho, checkHabilitarColumna.Location.Y);
                if(i == 2)
                    dtPickerFechaVencimiento.Location = new Point(-15 + acumuladorAncho, dtPickerFechaVencimiento.Location.Y);
                if(i == 3) 
                    cBoxFormaAdquisicion.Location = new Point(-15 + acumuladorAncho, cBoxFormaAdquisicion.Location.Y);
                if (i == 4) 
                    cBoxEstadoGrilla.Location = new Point(-15 + acumuladorAncho, cBoxEstadoGrilla.Location.Y);
                        
            }
        }



    }

    public class ProgressDialog
    {
        private Thread m_thread;
        private FInventarioProductosEspecificos m_form = null;
        private ManualResetEvent m_eventFormCreated = new ManualResetEvent(false);

        public ProgressDialog(int nLimit)
        {
            m_thread = new Thread(new ThreadStart(ThreadFunction));
            m_thread.Start();
            m_eventFormCreated.WaitOne();
        }

        public int Position
        {
            set
            {
                m_form.Position = value;
                m_form.Invoke(new MethodInvoker(m_form.UpdateProgressPosition));
            }

            get
            {
                return m_form.Position;
            }
        }

        public void Close()
        {
            m_form.Invoke(new MethodInvoker(m_form.Close));
        }

        private void ThreadFunction()
        {
            m_form = new FInventarioProductosEspecificos();
            m_form.HandleCreated += new EventHandler(m_form_HandleCreated);
            m_form.ShowDialog();
        }

        private void m_form_HandleCreated(object sender, EventArgs args)
        {
            m_eventFormCreated.Set();
        }
    }


    public class FormaAdquisicionProductoEspecifico
    {
        private string _CodigoFormaAdquisicion;
        private string _NombreFormaAdquisicion;

        public string CodigoFormaAdquisicion
        {
            get
            {
                return _CodigoFormaAdquisicion;
            }
            set
            {
                _CodigoFormaAdquisicion = value;
            }
        }

        public string NombreFormaAdquisicion
        {
            get
            {
                return _NombreFormaAdquisicion;
            }
            set
            {
                _NombreFormaAdquisicion = value;
            }
        }
        public FormaAdquisicionProductoEspecifico(string codigo, string nombre)
        {
            this._CodigoFormaAdquisicion = codigo;
            this._NombreFormaAdquisicion = nombre;
        }
        

    }

    public class EstadoProductoEspecifico
    {
        private string _CodigoEstado;
        private string _NombreEstado;

        public string CodigoEstado
        {
            get
            {
                return _CodigoEstado;
            }
            set
            {
                _CodigoEstado = value;
            }
        }

        public string NombreEstado
        {
            get
            {
                return _NombreEstado;
            }
            set
            {
                _NombreEstado = value;
            }
        }

        public EstadoProductoEspecifico(string codigo, string nombre)
        {
            this._CodigoEstado = codigo;
            this._NombreEstado = nombre;
        }



        
    }


    
    /*
     private bool eventHookedUp;  
 
private void grdMyGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)  
{  
    //I just want to pick up on changes to column 2  
    if (this.grdMyGrid.CurrentCell.ColumnIndex == 2)  
    {  
        if (!this.eventHookedUp)  
        {  
            e.Control.KeyDown += this.Cell_KeyDown;  
            this.eventHookedUp = true;  
        }  
    }  
    else 
    {  
        e.Control.KeyDown -= this.Cell_KeyDown;
        this.eventHookedUp = false;
    }
}
private void Cell_KeyDown(object sender, KeyEventArgs e)  
{  
   //Your code  
}*/
}
