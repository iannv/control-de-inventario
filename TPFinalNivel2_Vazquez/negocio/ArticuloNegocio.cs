using dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace negocio
{
    public class ArticuloNegocio
    {
        AccesoDatos datos = new AccesoDatos();

        // Lista los artículos en el DataGridView
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();

            try
            {
                datos.consulta("" +
                    "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, C.Descripcion AS Categoria, " +
                    "M.Descripcion AS Marca, A.Precio FROM ARTICULOS AS A, CATEGORIAS AS C, MARCAS AS M " +
                    "WHERE A.IdCategoria = C.Id AND A.IdMarca = M.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.Id = (int)datos.Lector["Id"];
                    articulo.Codigo = (string)datos.Lector["Codigo"];
                    articulo.Nombre = (string)datos.Lector["Nombre"];
                    articulo.Descripcion = (string)datos.Lector["Descripcion"];
                    articulo.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    articulo.Precio = (decimal)datos.Lector["Precio"];

                    articulo.IdCategoria = new Categoria();
                    articulo.IdCategoria.Descripcion = (string)datos.Lector["Categoria"];

                    articulo.IdMarca = new Marca();
                    articulo.IdMarca.Descripcion = (string)datos.Lector["Marca"];

                    lista.Add(articulo);
                }
                return lista;
            }
            catch (Exception ex) { throw ex; }
            finally { datos.cerrarConexion(); }
        }


        public void agregarArticulo(Articulo articulo)
        {
            try
            {
                datos.consulta("INSERT INTO ARTICULOS(Codigo, Nombre, Descripcion, ImagenUrl, IdCategoria, IdMarca, Precio) " +
                    "VALUES (@codigo, @nombre, @descripcion, @img, @categoria, @marca, @precio)");

                datos.setearParametro("@codigo", articulo.Codigo.ToUpper().Trim());
                datos.setearParametro("@nombre", capitalice(articulo.Nombre.Trim()));
                datos.setearParametro("@descripcion", capitalice(articulo.Descripcion.Trim()));
                datos.setearParametro("@img", articulo.ImagenUrl.Trim());
                datos.setearParametro("@categoria", articulo.IdCategoria.Id);
                datos.setearParametro("@marca", articulo.IdMarca.Id);
                datos.setearParametro("@precio", articulo.Precio);

                datos.ejecutarAccion();
            }
            catch (Exception ex) { throw ex; }
            finally { datos.cerrarConexion(); };
        }


        public void modificarArticulo(Articulo articulo)
        {
            try
            {
                datos.consulta("UPDATE ARTICULOS SET " +
                    "Codigo = @cod, Nombre = @nombre, Descripcion = @desc, ImagenUrl = @img, IdCategoria = @cat, " +
                    "IdMarca = @marca, Precio = @precio " +
                    "WHERE Id = @id");

                datos.setearParametro("@cod", articulo.Codigo.ToUpper().Trim());
                datos.setearParametro("@nombre", capitalice(articulo.Nombre.Trim()));
                datos.setearParametro("@desc", capitalice(articulo.Descripcion.Trim()));
                datos.setearParametro("@img", articulo.ImagenUrl.Trim());
                datos.setearParametro("@cat", articulo.IdCategoria.Id);
                datos.setearParametro("@marca", articulo.IdMarca.Id);
                datos.setearParametro("@precio", articulo.Precio);
                datos.setearParametro("@id", articulo.Id);

                datos.ejecutarAccion();                
            }
            catch (Exception ex) { throw ex; }
        }


        public void verArticulo(int id)
        {
            try
            {
                datos.consulta("SELECT Id, Codigo, Nombre, Descripcion, ImagenUrl, IdMarca, IdCategoria, Precio " +
                    "FROM ARTICULOS WHERE Id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex) { throw ex; }
        }


        public void eliminarArticulo(int id) {
            try
            {
                datos.consulta("DELETE FROM ARTICULOS WHERE Id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch(Exception ex) { throw ex; }
        }


        public List<Articulo> filtrarArticulos(string campo, string criterio, string filtro)
        {
            List <Articulo> listaArticulos = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consultaFiltro = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, C.Descripcion AS Categoria, " +
                    "M.Descripcion AS Marca, A.Precio FROM ARTICULOS AS A, CATEGORIAS AS C, MARCAS AS M " +
                    "WHERE A.IdCategoria = C.Id AND A.IdMarca = M.Id AND ";             


                switch (campo)
                {
                    case "Código":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consultaFiltro += "A.Codigo LIKE '" + filtro + "%'";
                                break;

                            case "Termina con":
                                consultaFiltro += "A.Codigo LIKE '%" + filtro + "'";
                                break;

                            case "Contiene":
                                consultaFiltro += "A.Codigo LIKE '%" + filtro + "%'";
                                break;
                        }
                        break;


                    case "Precio":
                        switch (criterio)
                        {
                            case "Menor a":
                                consultaFiltro += "A.Precio < " + filtro;
                                break;

                            case "Igual a":
                                consultaFiltro += "A.Precio = " + filtro;
                                break;

                            case "Mayor a":
                                consultaFiltro += "A.Precio > " + filtro;
                                break;
                        }
                        break;


                    case "Nombre":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consultaFiltro += "A.Nombre LIKE '" + filtro + "%'";
                                break;

                            case "Termina con":
                                consultaFiltro += "A.Nombre LIKE '%" + filtro + "'";
                                break;

                            case "Contiene":
                                consultaFiltro += "A.Nombre LIKE '%" + filtro + "%'";
                                break;
                        }
                        break;


                    case "Categoría":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consultaFiltro += "C.Descripcion LIKE '" + filtro + "%'";
                                break;

                            case "Termina con":
                                consultaFiltro += "C.Descripcion LIKE '%" + filtro + "'";
                                break;

                            case "Contiene":
                                consultaFiltro += "C.Descripcion LIKE '%" + filtro + "%'";
                                break; ;
                        }
                        break;


                    case "Marca":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consultaFiltro += "M.Descripcion LIKE '" + filtro + "%'";
                                break;

                            case "Termina con":
                                consultaFiltro += "M.Descripcion LIKE '%" + filtro + "'";
                                break;

                            case "Contiene":
                                consultaFiltro += "M.Descripcion LIKE '%" + filtro + "%'";
                                break;
                        }
                        break;
                }

                datos.consulta(consultaFiltro);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.Id = (int)datos.Lector["Id"];
                    articulo.Codigo = (string)datos.Lector["Codigo"];
                    articulo.Nombre = (string)datos.Lector["Nombre"];
                    articulo.Descripcion = (string)datos.Lector["Descripcion"];
                    articulo.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    articulo.Precio = (decimal)datos.Lector["Precio"];

                    articulo.IdCategoria = new Categoria();
                    articulo.IdCategoria.Descripcion = (string)datos.Lector["Categoria"];

                    articulo.IdMarca = new Marca();
                    articulo.IdMarca.Descripcion = (string)datos.Lector["Marca"];

                    listaArticulos.Add(articulo);
                }
                return listaArticulos;
            }
            catch (Exception)
            {
                throw;
            }

        }


        // Método para la primera letra en mayúscula
        private string capitalice(string txt)
        {
            return char.ToUpper(txt[0]) + txt.Substring(1).ToLower();
        }
    }
}
