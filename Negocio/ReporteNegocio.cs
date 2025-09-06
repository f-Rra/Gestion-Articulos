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
        /// <summary>
        /// Obtiene las estadísticas generales del sistema usando la vista vw_EstadisticasGenerales
        /// </summary>
        /// <returns>DataTable con estadísticas generales</returns>
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

        /// <summary>
        /// Obtiene el inventario completo usando la vista vw_ArticulosCompletos
        /// </summary>
        /// <returns>DataTable con todos los artículos activos</returns>
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

        /// <summary>
        /// Obtiene estadísticas de inventario agrupadas por categoría usando la vista vw_InventarioPorCategoria
        /// </summary>
        /// <returns>DataTable con estadísticas por categoría</returns>
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

        /// <summary>
        /// Obtiene estadísticas de inventario agrupadas por marca usando la vista vw_InventarioPorMarca
        /// </summary>
        /// <returns>DataTable con estadísticas por marca</returns>
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

        /// <summary>
        /// Ejecuta el procedimiento almacenado SP_ReporteInventarioGeneral que devuelve múltiples conjuntos de datos
        /// </summary>
        /// <returns>DataSet con múltiples tablas de reporte</returns>
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

        /// <summary>
        /// Obtiene artículos filtrados por rango de precios usando el procedimiento SP_ReporteArticulosPorPrecio
        /// </summary>
        /// <param name="precioMinimo">Precio mínimo del rango</param>
        /// <param name="precioMaximo">Precio máximo del rango</param>
        /// <returns>DataTable con artículos en el rango de precios especificado</returns>
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

        /// <summary>
        /// Obtiene lista de artículos con bajo stock usando procedimiento almacenado
        /// </summary>
        /// <param name="stockMinimo">Nivel mínimo de stock para considerar como bajo</param>
        /// <returns>DataTable con artículos de bajo stock</returns>
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

        /// <summary>
        /// Obtiene lista de artículos sin stock usando procedimiento almacenado
        /// </summary>
        /// <returns>DataTable con artículos sin stock</returns>
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

        /// <summary>
        /// Obtiene estadísticas de stock por categoría
        /// </summary>
        /// <returns>DataTable con estadísticas de stock por categoría</returns>
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

        /// <summary>
        /// Obtiene estadísticas de stock por marca
        /// </summary>
        /// <returns>DataTable con estadísticas de stock por marca</returns>
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

        /// <summary>
        /// Obtiene los artículos más caros del inventario
        /// </summary>
        /// <param name="cantidad">Cantidad de artículos a obtener (top N)</param>
        /// <returns>DataTable con los artículos más caros</returns>
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

        /// <summary>
        /// Obtiene los artículos más baratos del inventario
        /// </summary>
        /// <param name="cantidad">Cantidad de artículos a obtener (top N)</param>
        /// <returns>DataTable con los artículos más baratos</returns>
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
