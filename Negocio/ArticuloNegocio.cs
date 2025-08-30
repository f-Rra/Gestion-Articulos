using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            String consulta = "SELECT Codigo, Nombre, A.Descripcion Descripcion, ImagenUrl, M.Descripcion Marca, C.Descripcion Categoria, A.IdMarca, A.IdCategoria, A.Id, A.Precio " +
                              "FROM Articulos A, Marcas M, Categorias C " +
                              "WHERE M.Id = A.IdMarca AND C.Id = A.IdCategoria";
            try
            {
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.id = (int)datos.Lector["Id"]; 
                    aux.codigo = (string)datos.Lector["Codigo"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];
                    aux.marca = new Marca();
                    aux.marca.id = (int)datos.Lector["IdMarca"];
                    aux.marca.descripcion = (string)datos.Lector["Marca"];
                    aux.categoria = new Categoria();
                    aux.categoria.id = (int)datos.Lector["IdCategoria"];
                    aux.categoria.descripcion = (string)datos.Lector["Categoria"];
                    aux.urlImagen = (string)datos.Lector["ImagenUrl"];
                    aux.precio = (decimal)datos.Lector["Precio"];
                    lista.Add(aux);
                }
                return lista;
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

        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            String consulta = "INSERT INTO Articulos (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) " +
                              "VALUES (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @Precio)";
            try
            {
                datos.setearConsulta(consulta);
                datos.setearParametro("@Codigo", nuevo.codigo);
                datos.setearParametro("@Nombre", nuevo.nombre);
                datos.setearParametro("@Descripcion", nuevo.descripcion);
                datos.setearParametro("@IdMarca", nuevo.marca.id);
                datos.setearParametro("@IdCategoria", nuevo.categoria.id);
                datos.setearParametro("@ImagenUrl", nuevo.urlImagen);
                datos.setearParametro("@Precio", nuevo.precio);
                datos.ejecutarAccion();
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

        public void modificar(Articulo existente)
        {
            AccesoDatos datos = new AccesoDatos();
            String consulta = "UPDATE Articulos " +
                              "SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @ImagenUrl, Precio = @Precio " +
                              "WHERE Id = @Id";
            try
            {
                datos.setearConsulta(consulta);
                datos.setearParametro("@Codigo", existente.codigo);
                datos.setearParametro("@Nombre", existente.nombre);
                datos.setearParametro("@Descripcion", existente.descripcion);
                datos.setearParametro("@IdMarca", existente.marca.id);
                datos.setearParametro("@IdCategoria", existente.categoria.id);
                datos.setearParametro("@ImagenUrl", existente.urlImagen);
                datos.setearParametro("@Precio", existente.precio);
                datos.setearParametro("@Id", existente.id); 
                datos.ejecutarAccion();
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

        public void bajaFisica(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("DELETE FROM Articulos WHERE Id = @ID");
                datos.setearParametro("@ID", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT Codigo, Nombre, A.Descripcion, ImagenUrl, Precio, M.Descripcion Marca, C.Descripcion Categoria, A.IdMarca, A.IdCategoria, A.Id " +
                                  "FROM Articulos A " +
                                  "JOIN Marcas M ON M.Id = A.IdMarca " +
                                  "JOIN Categorias C ON C.Id = A.IdCategoria " +
                                  "WHERE ";
                switch (campo)
                {
                    case "Precio":
                        consulta += "Precio ";
                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += "> @filtro";
                                break;
                            case "Menor a":
                                consulta += "< @filtro";
                                break;
                            default:
                                consulta += "= @filtro";
                                break;
                        }
                        break;
                    case "Nombre":
                        consulta += "Nombre ";
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "LIKE @filtro";
                                filtro = filtro + "%"; 
                                break;
                            case "Termina con":
                                consulta += "LIKE @filtro";
                                filtro = "%" + filtro;
                                break;
                            default:
                                consulta += "LIKE @filtro";
                                filtro = "%" + filtro + "%";
                                break;
                        }
                        break;
                    default:
                        consulta += "Codigo ";
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "LIKE @filtro";
                                filtro = filtro + "%";
                                break;
                            case "Termina con":
                                consulta += "LIKE @filtro";
                                filtro = "%" + filtro;
                                break;
                            default:
                                consulta += "LIKE @filtro";
                                filtro = "%" + filtro + "%";
                                break;
                        }
                        break;
                }
                datos.setearConsulta(consulta);
                datos.setearParametro("@filtro", filtro); 
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.id = Convert.ToInt32(datos.Lector["Id"]);
                    aux.codigo = datos.Lector["Codigo"].ToString();
                    aux.nombre = datos.Lector["Nombre"].ToString();
                    aux.descripcion = datos.Lector["Descripcion"].ToString();
                    aux.marca = new Marca();
                    aux.marca.id = Convert.ToInt32(datos.Lector["IdMarca"]);
                    aux.marca.descripcion = datos.Lector["Marca"].ToString();                       
                    aux.categoria = new Categoria();
                    aux.categoria.id = Convert.ToInt32(datos.Lector["IdCategoria"]);
                    aux.categoria.descripcion = datos.Lector["Categoria"].ToString();
                    aux.urlImagen = datos.Lector["ImagenUrl"].ToString();
                    aux.precio = Convert.ToDecimal(datos.Lector["Precio"]);
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ultimoID()
        {
            AccesoDatos datos = new AccesoDatos();
            String consulta = "SELECT MAX(Id) AS UltimoID FROM Articulos";
            try
            {
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    return (int)datos.Lector["UltimoID"];
                }
                else
                {
                    throw new Exception("No se pudo obtener el ultimo ID");
                }
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
