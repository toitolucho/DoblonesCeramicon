using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.GestionComercial;
using CLCAD;
namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FTransferenciasProductosEspecificosEnvioRecepcion : Form
    {

        private int NumeroAgencia;
        private int NumeroTransferencia;
        private string CodigoTipoEnvioRecepcion;
        public DataTable DTProductosEspecificosEnvio;
        public CLCAD.DSDoblones20GestionComercial2.ListarCodigosEspecificosFaltantesRecepcionDataTable DTProductosEspecificosRecpcion;
        string DescripcionProducto;
        int CantidadEnvio = 0;
        public Boolean OperacionConfirmada = false;
        string CodigoProducto;
        public DateTime? FechaHoraEnvio { get; set; }

        TransferenciasProductosEspecificosCLN _TransferenciasProductosEspecificosCLN;
        TransaccionesUtilidadesCLN _TransaccionesUtilidadesCLN;
        InventariosProductosEspecificosCLN _InventariosProductosEspecificosCLN;

        public FTransferenciasProductosEspecificosEnvioRecepcion(int NumeroAgencia, int NumeroTransferencia, string CodigoTipoEnvioRecepcion, string CodigoProducto)
        {
            InitializeComponent();
            this.NumeroAgencia = NumeroAgencia;
            this.NumeroTransferencia = NumeroTransferencia;
            this.CodigoTipoEnvioRecepcion = CodigoTipoEnvioRecepcion;
            this.CodigoProducto = CodigoProducto;
            dtGVProductosEspecificos.ReadOnly = false;
            DGCCodigoEspecifico.ReadOnly = true;
            _TransferenciasProductosEspecificosCLN = new TransferenciasProductosEspecificosCLN();
            _TransaccionesUtilidadesCLN = new TransaccionesUtilidadesCLN();
            _InventariosProductosEspecificosCLN = new InventariosProductosEspecificosCLN();

            dtGVProductosEspecificos.AutoGenerateColumns = false;
            //para el autoscroll
            //dataGridView1.FirstDisplayedScrollingRowIndex += 1;
        }

        private void FTransferenciasProductosEspecificosEnvioRecepcion_Load(object sender, EventArgs e)
        {
            if (CodigoTipoEnvioRecepcion == "E")//ENVIO DE PRODUCTOS
            {
                habilitarOpcionesEnvio();

                DataColumn DCCodigoProductoEspecifico = new DataColumn("CodigoProductoEspecifico", Type.GetType("System.String"));
                DCCodigoProductoEspecifico.AllowDBNull = false;
                DCCodigoProductoEspecifico.Unique = true;
                DTProductosEspecificosEnvio.Columns.Add(DCCodigoProductoEspecifico);
                DTProductosEspecificosEnvio.PrimaryKey = new DataColumn[] { DCCodigoProductoEspecifico };

                
                DTProductosEspecificosEnvio.TableNewRow += new DataTableNewRowEventHandler(DTProductosEspecificosEnvio_TableNewRow);
                DTProductosEspecificosEnvio.RowDeleted += new DataRowChangeEventHandler(DTProductosEspecificosEnvio_RowDeleted);

                dtGVProductosEspecificos.DataSource = DTProductosEspecificosEnvio;

            }
            else//RECEPCION DE PRODUCTOS
            {
                habilitarOpcionesRecepcion();
                DTProductosEspecificosRecpcion = _TransferenciasProductosEspecificosCLN.ListarCodigosEspecificosFaltantesRecepcion(NumeroAgencia, NumeroTransferencia, CodigoProducto, FechaHoraEnvio);
                dtGVProductosEspecificos.DataSource = DTProductosEspecificosRecpcion;
            }
        }

        void DTProductosEspecificosEnvio_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            if (DTProductosEspecificosEnvio.Rows.Count < CantidadEnvio)
            {
                txtCodigoEspecifico.Enabled = true;
                btnAnadir.Enabled = true;
            }
        }

        void DTProductosEspecificosEnvio_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            if (DTProductosEspecificosEnvio.Rows.Count == CantidadEnvio)
            {
                txtCodigoEspecifico.Enabled = false;
                btnAnadir.Enabled = false;
            }
        }

        public void habilitarOpcionesRecepcion()
        {
            btnAnadir.Visible = false;
            btnCancelar.Visible = true;
            btnCompletar.Visible = false;
            btnConfirmar.Visible = true;
            btnEliminar.Visible = false;
            DGCSeleccionar.Visible = true;
            checkForzarSeleccion.Visible = true;


        }

        public void habilitarOpcionesEnvio()
        {
            btnAnadir.Visible = true;
            btnCancelar.Visible = true;
            btnCompletar.Visible = true;
            btnConfirmar.Visible = true;
            btnEliminar.Visible = true;
            DGCSeleccionar.Visible = false;
            checkForzarSeleccion.Visible = false;
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Se encarga de ingresar un Codigo Especifico
        /// dentro de la Grilla, con sus respectivas validaciaones
        /// </summary>
        /// <param name="CodigoProductoEspecifico"></param>
        public void validarIngresoCodigoProductoEspecifico(string CodigoProductoEspecifico)
        {
            //si no se encuentra ya en el DataTable
            DataRow FilaProductoEspecifico = DTProductosEspecificosEnvio.Rows.Find(CodigoProductoEspecifico);
            if (FilaProductoEspecifico == null)
            {
                try
                {
                    bool PEInventariado = _TransaccionesUtilidadesCLN.ExisteCodigoProductoEspecificoEnInventario(NumeroAgencia, CodigoProductoEspecifico);
                    //SI EL CODIGO PRODUCTO ESPECIFICO SE ENCUENTRA INVENTARIADO
                    if (PEInventariado)
                    {
                        string CodigoProductoPorPE = _TransaccionesUtilidadesCLN.ObtenerCodigoProductoPorCodigoProductoEspecifico(NumeroAgencia, CodigoProductoEspecifico);
                        //SI EL CODIGO PRODUCTO ESPECIFICO pertenece a este producto
                        if (CodigoProductoPorPE.Trim().CompareTo(CodigoProducto.Trim()) == 0)
                        {
                            DTProductosEspecificosEnvio.Rows.Add(new object[] { CodigoProductoEspecifico });
                            dtGVProductosEspecificos.CurrentCell = dtGVProductosEspecificos[0, DTProductosEspecificosEnvio.Rows.Count - 1];

                        }
                        else //PE NO PERTENECE A ESTE PRODUCTO
                        {
                            MessageBox.Show(this, "El Codigo Especifico ingresado no pertenece al producto " + DescripcionProducto + "\r\nNo puede Ingresar este codigo",
                                "Codigo Ingresado Erroneo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "El Codigo Especifico ingresado no se encuentra Registrado ",
                                "Codigo Ingresado Erroneo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio la siguiente Excepcion " + ex.Message);
                }
            }
            else
            {
                int indice = DTProductosEspecificosEnvio.Rows.IndexOf(FilaProductoEspecifico);
                dtGVProductosEspecificos.CurrentCell = dtGVProductosEspecificos[0,indice];
                dtGVProductosEspecificos.CurrentRow.ErrorText = "Código ya Ingresado";
            }
        }

        /// <summary>
        /// Selecciona el Producto Especifico que
        /// se encuentra en la Grilla
        /// </summary>
        /// <param name="CodigoProductoEspecifico"></param>
        public void seleccionarCodigoProducoEspecifico(string CodigoProductoEspecifico)
        {
            CLCAD.DSDoblones20GestionComercial2.ListarCodigosEspecificosFaltantesRecepcionRow FilaProductoEspecifico;
            FilaProductoEspecifico = DTProductosEspecificosRecpcion.FindByCodigoProductoEspecifico(CodigoProductoEspecifico);
            if (FilaProductoEspecifico != null)
            {
                FilaProductoEspecifico.Entregado = true;
                FilaProductoEspecifico.AcceptChanges();

                dtGVProductosEspecificos.CurrentCell = dtGVProductosEspecificos[0, DTProductosEspecificosRecpcion.Rows.IndexOf(FilaProductoEspecifico)];
                dtGVProductosEspecificos.FirstDisplayedScrollingRowIndex = DTProductosEspecificosRecpcion.Rows.IndexOf(FilaProductoEspecifico);
            }
            else
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCodigoEspecifico, "No se Encuentra el Codigo Ingresado, revise sus datos");
                txtCodigoEspecifico.Focus();
                txtCodigoEspecifico.SelectAll();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (CodigoTipoEnvioRecepcion == "R")
            {
                int CantidadSeleccionada = int.Parse(DTProductosEspecificosRecpcion.Compute("count(CodigoProductoEspecifico)", "Entregado = true").ToString());
                if (CantidadSeleccionada != DTProductosEspecificosRecpcion.Count)
                {
                    
                    DialogResult Respuesta = MessageBox.Show(this, "No ha confimado completamente la cantidad de Selección de los Codigos Especificos\r\n¿Desea continuar aún Asi?", "Confirmación Incompleta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Respuesta == DialogResult.No)
                    {
                        return;
                    }                    
                }                
            }
            else
            {
                int CantidadIngresada = DTProductosEspecificosEnvio.Rows.Count;
                if(CantidadEnvio != CantidadIngresada)
                {
                    MessageBox.Show(this, "No ha confimado completamente el ingreso de los Codigos Especificos", "Confirmación Incompleta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            DTProductosEspecificosRecpcion.AcceptChanges();
            OperacionConfirmada = true;
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtGVProductosEspecificos.RowCount > 0)
            {
                int indice = dtGVProductosEspecificos.CurrentCell.RowIndex;
                DTProductosEspecificosEnvio.Rows.RemoveAt(indice);
                DTProductosEspecificosEnvio.AcceptChanges();

            }
            else
            {
                MessageBox.Show("No existe ningun Item a eliminar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Se encuentra seguro de cancelar la operación actual?", "Cancelar Operación Actual", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                OperacionConfirmada = false;
                this.Close();
            }
        }

        private void btnCompletar_Click(object sender, EventArgs e)
        {
            if (CodigoTipoEnvioRecepcion == "E")
            {
                DTProductosEspecificosEnvio.Clear();
                DTProductosEspecificosEnvio = _InventariosProductosEspecificosCLN.ListarCodigosProductosEspecificosParaTransferenciaEnvio(NumeroAgencia, CodigoProducto, CantidadEnvio);
            }
        }

        private void FTransferenciasProductosEspecificosEnvioRecepcion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!OperacionConfirmada && MessageBox.Show(this, "¿Se encuentra seguro de cancelar la operación sin haber " + ((CodigoTipoEnvioRecepcion == "R") ? "Seleccionado " : "Ingresado") + "los codigos especificos?", "Operación cancelada", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        public void seleccionarNuevamenteProductosActualizados(DataTable DTProductosRecepcionEspecificos)
        {
            if(this.DTProductosEspecificosRecpcion == null)
            {
                DTProductosEspecificosRecpcion = _TransferenciasProductosEspecificosCLN.ListarCodigosEspecificosFaltantesRecepcion(NumeroAgencia, NumeroTransferencia, CodigoProducto, FechaHoraEnvio);
                dtGVProductosEspecificos.DataSource = DTProductosEspecificosRecpcion;
            }
            if (this.DTProductosEspecificosRecpcion != null && this.DTProductosEspecificosRecpcion.Count > 0)
            {
                foreach (DataRow DRProductoEspecifico in DTProductosRecepcionEspecificos.Select("CodigoProducto ='" + CodigoProducto + "'"))
                {
                    this.DTProductosEspecificosRecpcion.FindByCodigoProductoEspecifico(DRProductoEspecifico["CodigoProductoEspecifico"].ToString()).Entregado = true;
                }
            }
        }

        public int getCantidadSeleccionada()
        {
            return int.Parse(DTProductosEspecificosRecpcion.Compute("count(CodigoProductoEspecifico)", "Entregado = true").ToString());
        }

        private void checkForzarSeleccion_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
