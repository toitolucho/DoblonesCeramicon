using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CLCAD.DSDoblones20GestionComercialTableAdapters;
using CLCAD;
using System.Data;
using System.Data.SqlClient;

namespace CLCLN.GestionComercial
{
    //[System.ComponentModel.DataObject]
    public class ProductosCLN
    {
        private ProductosTableAdapter _ProductosAdapter = null;
        protected ProductosTableAdapter Adapter
        {
            get
            {
                if (_ProductosAdapter == null)
                    _ProductosAdapter = new ProductosTableAdapter();
                return _ProductosAdapter;
            }
        }

        public ProductosCLN()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool InsertarProducto(string CodigoProducto, string CodigoProductoFabricante, string NombreProducto, string NombreProducto1, string NombreProducto2, int? CodigoMarcaProducto, int CodigoTipoProducto, int CodigoUnidad, string CodigoTipoCalculoInventario, bool LlenarCodigoPE, bool ProductoTangible, bool ProductoSimple, bool CalcularPrecioVenta, decimal RendimientoDeseado1, decimal RendimientoDeseado2, decimal RendimientoDeseado3, string Descripcion, string Observaciones)		
        {
            DSDoblones20GestionComercial.ProductosDataTable Productos = new DSDoblones20GestionComercial.ProductosDataTable();
            DSDoblones20GestionComercial.ProductosRow Producto = Productos.NewProductosRow();

            Producto.CodigoProducto = CodigoProducto;
            Producto.CodigoProductoFabricante = CodigoProductoFabricante;
            Producto.NombreProducto = NombreProducto;
            if (NombreProducto1 == null) Producto.SetNombreProducto1Null();
            else Producto.NombreProducto1 = NombreProducto1;
            if (NombreProducto2 == null) Producto.SetNombreProducto2Null();
            else Producto.NombreProducto2 = NombreProducto2;
            if (CodigoMarcaProducto == null) Producto.SetCodigoMarcaProductoNull();
            else Producto.CodigoMarcaProducto = CodigoMarcaProducto.Value;
            Producto.CodigoTipoProducto = CodigoTipoProducto;
            Producto.CodigoUnidad = CodigoUnidad;
            Producto.CodigoTipoCalculoInventario = CodigoTipoCalculoInventario;
            Producto.LlenarCodigoPE = LlenarCodigoPE;
            Producto.ProductoTangible = ProductoTangible;
            Producto.ProductoSimple = ProductoSimple;
            Producto.CalcularPrecioVenta = CalcularPrecioVenta;
            Producto.RendimientoDeseado1 = RendimientoDeseado1;
            Producto.RendimientoDeseado2 = RendimientoDeseado2;
            Producto.RendimientoDeseado3 = RendimientoDeseado3;
            if (Descripcion == null) Producto.SetDescripcionNull();
            else Producto.Descripcion = Descripcion;
            if (Observaciones == null) Producto.SetObservacionesNull();
            else Producto.Observaciones = Observaciones;
                                                          
            Productos.AddProductosRow(Producto);

            int rowsAffected = Adapter.Update(Productos);
            return rowsAffected == 1;
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool ActualizarProducto(string CodigoProducto, string CodigoProductoFabricante, string NombreProducto, string NombreProducto1, string NombreProducto2, int? CodigoMarcaProducto, int CodigoTipoProducto, int CodigoUnidad, string CodigoTipoCalculoInventario, bool LlenarCodigoPE, bool ProductoTangible, bool ProductoSimple, bool CalcularPrecioVenta, decimal RendimientoDeseado1, decimal RendimientoDeseado2, decimal RendimientoDeseado3, string Descripcion, string Observaciones)		
        {
            DSDoblones20GestionComercial.ProductosDataTable Productos = Adapter.GetDataBy(CodigoProducto);
            if (Productos.Count == 0)
                return false;

            DSDoblones20GestionComercial.ProductosRow Producto = Productos[0];

            Producto.CodigoProducto = CodigoProducto;
            Producto.CodigoProductoFabricante = CodigoProductoFabricante;
            Producto.NombreProducto = NombreProducto;
            if (NombreProducto1 == null) Producto.SetNombreProducto1Null();
            else Producto.NombreProducto1 = NombreProducto1;
            if (NombreProducto2 == null) Producto.SetNombreProducto2Null();
            else Producto.NombreProducto2 = NombreProducto2;
            if (CodigoMarcaProducto == null) Producto.SetCodigoMarcaProductoNull();
            else Producto.CodigoMarcaProducto = CodigoMarcaProducto.Value;
            Producto.CodigoTipoProducto = CodigoTipoProducto;
            Producto.CodigoUnidad = CodigoUnidad;
            Producto.CodigoTipoCalculoInventario = CodigoTipoCalculoInventario;
            Producto.LlenarCodigoPE = LlenarCodigoPE;
            Producto.ProductoTangible = ProductoTangible;
            Producto.ProductoSimple = ProductoSimple;
            Producto.CalcularPrecioVenta = CalcularPrecioVenta;
            Producto.RendimientoDeseado1 = RendimientoDeseado1;
            Producto.RendimientoDeseado2 = RendimientoDeseado2;
            Producto.RendimientoDeseado3 = RendimientoDeseado3;
            if (Descripcion == null) Producto.SetDescripcionNull();
            else Producto.Descripcion = Descripcion;
            if (Observaciones == null) Producto.SetObservacionesNull();
            else Producto.Observaciones = Observaciones;

            int rowsAffected = Adapter.Update(Producto);
            return rowsAffected == 1;
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public bool EliminarProducto(string CodigoProducto)                           	                   	     
        {
            int rowsAffected = Adapter.Delete(CodigoProducto);
            return rowsAffected == 1;
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarProductos()
        {
            return Adapter.GetData();
        }

        public DataTable ListarProductosPorTipoProducto(int CodigoTipoProducto)
        {
            return Adapter.GetDataByListarProductosPorTipoProducto(CodigoTipoProducto);
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ObtenerProducto(string CodigoProducto)
        {
            return Adapter.GetDataBy(CodigoProducto);
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable BuscarProductos(string CodigoAmbitoBusqueda, string TextoABuscar, bool ExactamenteIgual)
        {
            return Adapter.GetDataByBuscarProductos(CodigoAmbitoBusqueda, TextoABuscar, ExactamenteIgual);
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable BuscarProductoInventario(string CodigoProducto, string NombreProducto, int CantidadExistencia)
        {
            /* agregar esto en el DataSet
        public void allowNullColumns()
        {
            this.columnCodigoProducto.AllowDBNull = false;                                
            this.columnCodigoProductoProveedor.AllowDBNull = true;                
            this.columnNombreProducto.AllowDBNull = true;                
            this.columnCodigoTipoProducto.AllowDBNull = true;
            this.columnCodigoUnidad.AllowDBNull = true;
            this.columnCodigoTipoCalculoInventario.AllowDBNull = true;                
            this.columnLlenarCodigoPE.AllowDBNull = true;
            this.columnProductoTangible.AllowDBNull = true;
            this.columnProductoSimple.AllowDBNull = true;
            this.columnCalcularPrecioVenta.AllowDBNull = true;                
        }*/

            return Adapter.GetDataByInventario(CodigoProducto, NombreProducto, CantidadExistencia);
        }

        //[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable ListarProductosReporte()
        {
            ProductosReporteTableAdapter ProductosReporte = new ProductosReporteTableAdapter();
            return ProductosReporte.GetData();
        }

        public string ObtenerCodigoTipoCalculoInventarioProducto(string CodigoProducto)
        {
            return new FuncionesGestionComercial().ObtenerCodigoTipoCalculoInventarioProducto(CodigoProducto);
        }

        public DSDoblones20GestionComercial.ListarProductosRecepcionadosTipoCalculoInventarioDataTable ListarProductosRecepcionadosTipoCalculoInventario(int NumeroAgencia, int NumeroCompraProducto, string ListadoProductos)
        {
            return new ListarProductosRecepcionadosTipoCalculoInventarioTableAdapter().GetData(NumeroAgencia, NumeroCompraProducto, ListadoProductos);
        }

        public string GenerarCodigoProducto(int CodigoTipoProducto, string NombreProducto)
        {
            FuncionesGestionComercial fgc = new FuncionesGestionComercial();
            return fgc.GenerarCodigoProducto(CodigoTipoProducto, NombreProducto);
        }

        public DataTable ListarProductosSimplesLibresPorCodigoProducto(string CodigoProducto, string CodigoProductoComponente)
        {
            return Adapter.GetDataByListarProductosSimplesLibresPorCodigoProducto(CodigoProducto, CodigoProductoComponente);
        }

    }
}
