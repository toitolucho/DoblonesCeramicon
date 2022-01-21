using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLCLN.GestionComercial;
using System.Collections;
using WFADoblones20.Utilitarios;
namespace WFADoblones20.FormulariosGestionComercial
{
    public partial class FGrillaAgrupada : Form
    {


        // remember the column index that was last sorted on
        private int prevColIndex = -1;

        // remember the direction the rows were last sorted on (ascending/descending)
        private ListSortDirection prevSortDirection = ListSortDirection.Ascending;
        public FGrillaAgrupada()
        {
            InitializeComponent();
        }

        private void FGrillaAgrupada_Load(object sender, EventArgs e)
        {
            this.dtGVVentaProductosEspecificos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dtGVVentaProductosEspecificos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtGVVentaProductosEspecificos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;

            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dtGVVentaProductosEspecificos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;

            this.dtGVVentaProductosEspecificos.GridColor = System.Drawing.SystemColors.Control;
            this.dtGVVentaProductosEspecificos.RowTemplate.Height = 19;
            this.dtGVVentaProductosEspecificos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dtGVVentaProductosEspecificos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtGVVentaProductosEspecificos.RowHeadersVisible = false;
            this.dtGVVentaProductosEspecificos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtGVVentaProductosEspecificos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtGVVentaProductosEspecificos.AllowUserToAddRows = false;
            this.dtGVVentaProductosEspecificos.AllowUserToDeleteRows = false;
            this.dtGVVentaProductosEspecificos.AllowUserToResizeRows = true;
            //this.dtGVVentaProductosEspecificos.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.dtGVVentaProductosEspecificos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.dtGVVentaProductosEspecificos.ClearGroups(); 



            InventariosProductosEspecificosCLN inventario = new InventariosProductosEspecificosCLN();
            DataTable DTInventario = inventario.ListarInventariosProductosEspecificos();
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(DTInventario);
            dtGVVentaProductosEspecificos.BindData(dataSet, DTInventario.TableName);

            dtGVVentaProductosEspecificos.GroupTemplate.Column = dtGVVentaProductosEspecificos.Columns[1];
            dtGVVentaProductosEspecificos.Sort(new DataRowComparer(1, ListSortDirection.Ascending));

            //dtGVVentaProductosEspecificos.Rows.Clear();
            //ArrayList listaTiposAgregados = new ArrayList();
            //listaTiposAgregados.Add(new TiposAgregados("O", "Obsequio"));
            //listaTiposAgregados.Add(new TiposAgregados("C", "Compensación"));
            //listaTiposAgregados.Add(new TiposAgregados("R", "Regalo"));
            //listaTiposAgregados.Add(new TiposAgregados("A", "Añadido"));

            //dtGVVentaProductosEspecificos.BindData(null, null);
            //dtGVVentaProductosEspecificos.AllowUserToAddRows = false;
            //dtGVVentaProductosEspecificos.Columns.Clear();
            //DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            //col1.HeaderText = "Columna1";
            //col1.Name = "Numeros";

            //DataGridViewComboBoxColumn colcombo = new DataGridViewComboBoxColumn();
            //colcombo.HeaderText = "comboBox";
            //colcombo.DataSource = listaTiposAgregados;
            //colcombo.ValueMember = "CodigoTipoAgregado";
            //colcombo.DisplayMember = "NombreAgregado";
            //colcombo.Name = "ComboBox";

            //dtGVVentaProductosEspecificos.Columns.AddRange(new DataGridViewColumn[] { col1, colcombo });

            //for (int indice = 0; indice < 10; indice++)
            //{
            //    OutlookStyleControls.OutlookGridRow row = new OutlookStyleControls.OutlookGridRow();
            //    row.CreateCells(dtGVVentaProductosEspecificos, new object[] { "1", "A" });
            //    dtGVVentaProductosEspecificos.Rows.Add(row);
            //}



        }

        private void outlookGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 && e.ColumnIndex >= 0)
            {
                ListSortDirection direction = ListSortDirection.Ascending;
                if (e.ColumnIndex == prevColIndex) // reverse sort order
                    direction = prevSortDirection == ListSortDirection.Descending ? ListSortDirection.Ascending : ListSortDirection.Descending;

                // remember the column that was clicked and in which direction is ordered
                prevColIndex = e.ColumnIndex;
                prevSortDirection = direction;

                // set the column to be grouped
                dtGVVentaProductosEspecificos.GroupTemplate.Column = dtGVVentaProductosEspecificos.Columns[e.ColumnIndex];
                dtGVVentaProductosEspecificos.Sort(new DataRowComparer(e.ColumnIndex, direction));
                //dtGVVentaProductosEspecificos.Sort(dtGVVentaProductosEspecificos.Columns[e.ColumnIndex], direction);
                //sort the grid (based on the selected view)
                //switch (View)
                //{
                //    case "BoundContactInfo":
                //        //dtGVVentaProductosEspecificos.Sort(new ContactInfoComparer(e.ColumnIndex, direction));
                //        break;
                //    case "BoundCategory":

                //        break;
                //    case "BoundInvoices":
                //        dtGVVentaProductosEspecificos.Sort(new DataRowComparer(e.ColumnIndex, direction));
                //        break;
                //    case "BoundQuarterly":
                //        // this is an example of overriding the default behaviour of the
                //        // Group object. Instead of using the DefaultGroup behavious, we
                //        // use the AlphabeticGroup, so items are grouped together based on
                //        // their first character:
                //        // all items starting with A or a will be put in the same group.
                //        IOutlookGridGroup prevGroup = dtGVVentaProductosEspecificos.GroupTemplate;

                //        if (e.ColumnIndex == 0) // execption when user pressed the customer name column
                //        {
                //            // simply override the GroupTemplate to use before sorting
                //            dtGVVentaProductosEspecificos.GroupTemplate = new OutlookGridAlphabeticGroup();
                //            dtGVVentaProductosEspecificos.GroupTemplate.Collapsed = prevGroup.Collapsed;
                //        }

                //        // set the column to be grouped
                //        // this must always be done before sorting
                //        dtGVVentaProductosEspecificos.GroupTemplate.Column = dtGVVentaProductosEspecificos.Columns[e.ColumnIndex];

                //        // execute the sort, arrange and group function
                //        dtGVVentaProductosEspecificos.Sort(new DataRowComparer(e.ColumnIndex, direction));

                //        //after sorting, reset the GroupTemplate back to its default (if it was changed)
                //        // this is needed just for this demo. We do not want the other
                //        // columns to be grouped alphabetically.
                //        dtGVVentaProductosEspecificos.GroupTemplate = prevGroup;
                //        break;
                //    default: //UnboundContactInfo
                //        dtGVVentaProductosEspecificos.Sort(dtGVVentaProductosEspecificos.Columns[e.ColumnIndex], direction);
                //        break;
                //}
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtGVVentaProductosEspecificos.ClearGroups();
        }


    }
    public class DataRowComparer : IComparer
    {
        ListSortDirection direction;
        int columnIndex;

        public DataRowComparer(int columnIndex, ListSortDirection direction)
        {
            this.columnIndex = columnIndex;
            this.direction = direction;
        }

        #region IComparer Members

        public int Compare(object x, object y)
        {

            DataRow obj1 = (DataRow)x;
            DataRow obj2 = (DataRow)y;
            return string.Compare(obj1[columnIndex].ToString(), obj2[columnIndex].ToString()) * (direction == ListSortDirection.Ascending ? 1 : -1);
        }
        #endregion
    }

    //public class TiposAgregados
    //{
    //    private string _CodigoTipoAgregado;
    //    public string CodigoTipoAgregado
    //    {
    //        get { return _CodigoTipoAgregado; }
    //        set { this._CodigoTipoAgregado = value; }
    //    }

    //    private string _NombreAgregado;
    //    public string NombreAgregado
    //    {
    //        get { return _NombreAgregado; }
    //        set { this._NombreAgregado = value; }
    //    }


    //    public TiposAgregados(string codigo, string nombre)
    //    {
    //        this._CodigoTipoAgregado = codigo;
    //        this._NombreAgregado = nombre;
    //    }
    //}

}
