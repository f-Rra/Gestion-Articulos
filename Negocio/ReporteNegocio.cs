using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ReporteNegocio
    {
        public DataTable obtenerEstadisticasGenerales()
        {
            AccesoDatos datos = new AccesoDatos();
            DataTable tabla = new DataTable();
            try
            {
                datos.setearConsulta("SELECT * FROM vw_EstadisticasGenerales");
                datos.ejecutarLectura();
                tabla.Load(datos.Lector);
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public DataTable obtenerInventarioCompleto()
        {
            AccesoDatos datos = new AccesoDatos();
            DataTable tabla = new DataTable();
            try
            {
                // Seleccionar columnas incluyendo Stock y EstadoStock
                datos.setearConsulta(@"SELECT 
                    Codigo, 
                    Nombre, 
                    Descripcion, 
                    Marca, 
                    Categoria, 
                    Precio,
                    Stock,
                    EstadoStock
                FROM vw_ArticulosCompletos 
                ORDER BY Nombre");
                datos.ejecutarLectura();
                tabla.Load(datos.Lector);
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public DataTable obtenerInventarioPorCategoria()
        {
            AccesoDatos datos = new AccesoDatos();
            DataTable tabla = new DataTable();
            try
            {
                datos.setearConsulta("SELECT * FROM vw_InventarioPorCategoria ORDER BY CantidadArticulos DESC");
                datos.ejecutarLectura();
                tabla.Load(datos.Lector);
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public DataTable obtenerInventarioPorMarca()
        {
            AccesoDatos datos = new AccesoDatos();
            DataTable tabla = new DataTable();
            try
            {
                datos.setearConsulta("SELECT * FROM vw_InventarioPorMarca ORDER BY CantidadArticulos DESC");
                datos.ejecutarLectura();
                tabla.Load(datos.Lector);
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public DataSet obtenerReporteInventarioGeneral()
        {
            AccesoDatos datos = new AccesoDatos();
            DataSet dataSet = new DataSet();
            try
            {
                datos.setearConsulta("SP_ReporteInventarioGeneral");
                datos.setearTipoComando(CommandType.StoredProcedure);
                datos.ejecutarLectura();
                
                // Cargar primera tabla - Estadísticas Generales
                DataTable tablaEstadisticas = new DataTable("EstadisticasGenerales");
                tablaEstadisticas.Load(datos.Lector);
                dataSet.Tables.Add(tablaEstadisticas);
                
                // Avanzar al siguiente resultado - Por Categoría
                if (datos.Lector.NextResult())
                {
                    DataTable tablaTipoCategoria = new DataTable("TipoReporteCategoria");
                    tablaTipoCategoria.Load(datos.Lector);
                    dataSet.Tables.Add(tablaTipoCategoria);
                }
                
                // Avanzar al siguiente resultado - Datos por Categoría
                if (datos.Lector.NextResult())
                {
                    DataTable tablaCategorias = new DataTable("InventarioPorCategoria");
                    tablaCategorias.Load(datos.Lector);
                    dataSet.Tables.Add(tablaCategorias);
                }
                
                // Avanzar al siguiente resultado - Por Marca
                if (datos.Lector.NextResult())
                {
                    DataTable tablaTipoMarca = new DataTable("TipoReporteMarca");
                    tablaTipoMarca.Load(datos.Lector);
                    dataSet.Tables.Add(tablaTipoMarca);
                }
                
                // Avanzar al siguiente resultado - Datos por Marca
                if (datos.Lector.NextResult())
                {
                    DataTable tablaMarcas = new DataTable("InventarioPorMarca");
                    tablaMarcas.Load(datos.Lector);
                    dataSet.Tables.Add(tablaMarcas);
                }
                
                return dataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public DataTable obtenerArticulosPorRangoPrecio(decimal precioMinimo, decimal precioMaximo)
        {
            AccesoDatos datos = new AccesoDatos();
            DataTable tabla = new DataTable();
            try
            {
                datos.setearConsulta("SP_ReporteArticulosPorPrecio");
                datos.setearTipoComando(CommandType.StoredProcedure);
                datos.setearParametro("@PrecioMinimo", precioMinimo);
                datos.setearParametro("@PrecioMaximo", precioMaximo);
                datos.ejecutarLectura();
                tabla.Load(datos.Lector);
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public DataTable obtenerArticulosBajoStock(int stockMinimo = 5)
        {
            AccesoDatos datos = new AccesoDatos();
            DataTable tabla = new DataTable();
            try
            {
                datos.setearConsulta("SP_ArticulosBajoStock");
                datos.setearTipoComando(CommandType.StoredProcedure);
                datos.setearParametro("@StockMinimo", stockMinimo);
                datos.ejecutarLectura();
                tabla.Load(datos.Lector);
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public DataTable obtenerArticulosSinStock()
        {
            AccesoDatos datos = new AccesoDatos();
            DataTable tabla = new DataTable();
            try
            {
                datos.setearConsulta("SP_ArticulosSinStock");
                datos.setearTipoComando(CommandType.StoredProcedure);
                datos.ejecutarLectura();
                tabla.Load(datos.Lector);
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public DataTable obtenerEstadisticasStockPorCategoria()
        {
            AccesoDatos datos = new AccesoDatos();
            DataTable tabla = new DataTable();
            try
            {
                datos.setearConsulta(@"SELECT 
                    c.Descripcion as Categoria,
                    COUNT(a.Id) as TotalArticulos,
                    SUM(a.Stock) as StockTotal,
                    AVG(CAST(a.Stock as FLOAT)) as StockPromedio,
                    COUNT(CASE WHEN a.Stock = 0 THEN 1 END) as ArticulosSinStock,
                    COUNT(CASE WHEN a.Stock <= 5 THEN 1 END) as ArticulosBajoStock
                FROM ARTICULOS a
                INNER JOIN CATEGORIAS c ON a.IdCategoria = c.Id
                WHERE a.Estado = 1 AND c.Estado = 1
                GROUP BY c.Descripcion
                ORDER BY StockTotal DESC");
                datos.ejecutarLectura();
                tabla.Load(datos.Lector);
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public DataTable obtenerEstadisticasStockPorMarca()
        {
            AccesoDatos datos = new AccesoDatos();
            DataTable tabla = new DataTable();
            try
            {
                datos.setearConsulta(@"SELECT 
                    m.Descripcion as Marca,
                    COUNT(a.Id) as TotalArticulos,
                    SUM(a.Stock) as StockTotal,
                    AVG(CAST(a.Stock as FLOAT)) as StockPromedio,
                    COUNT(CASE WHEN a.Stock = 0 THEN 1 END) as ArticulosSinStock,
                    COUNT(CASE WHEN a.Stock <= 5 THEN 1 END) as ArticulosBajoStock
                FROM ARTICULOS a
                INNER JOIN MARCAS m ON a.IdMarca = m.Id
                WHERE a.Estado = 1 AND m.Estado = 1
                GROUP BY m.Descripcion
                ORDER BY StockTotal DESC");
                datos.ejecutarLectura();
                tabla.Load(datos.Lector);
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public DataTable obtenerArticulosMasCaros(int cantidad = 10)
        {
            AccesoDatos datos = new AccesoDatos();
            DataTable tabla = new DataTable();
            try
            {
                datos.setearConsulta($"SELECT TOP {cantidad} * FROM vw_ArticulosCompletos ORDER BY Precio DESC");
                datos.ejecutarLectura();
                tabla.Load(datos.Lector);
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public DataTable obtenerArticulosMasBaratos(int cantidad = 10)
        {
            AccesoDatos datos = new AccesoDatos();
            DataTable tabla = new DataTable();
            try
            {
                datos.setearConsulta($"SELECT TOP {cantidad} * FROM vw_ArticulosCompletos ORDER BY Precio ASC");
                datos.ejecutarLectura();
                tabla.Load(datos.Lector);
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
