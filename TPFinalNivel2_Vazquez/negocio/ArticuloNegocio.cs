using dominio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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

                    //articulo.Precio = Math.Round(Convert.ToDecimal(datos.Lector["Precio"]), 2);

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
                datos.consulta("INSERT INTO ARTICULOS(Codigo, Nombre, Descripcion, ImagenUrl, IdCategoria, IdMarca, Precio) VALUES (@codigo, @nombre, @descripcion, @img, @categoria, @marca, @precio)");
                datos.setearParametro("@codigo", articulo.Codigo);
                datos.setearParametro("@nombre", articulo.Nombre);
                datos.setearParametro("@descripcion", articulo.Descripcion);
                datos.setearParametro("@img", articulo.ImagenUrl);
                datos.setearParametro("@categoria", articulo.IdCategoria.Id);
                datos.setearParametro("@marca", articulo.IdMarca.Id);
                datos.setearParametro("@precio", articulo.Precio);
                datos.ejecutarAccion();
            }
            catch (Exception ex) { throw ex; }
            finally { datos.cerrarConexion(); };
        }




        public void modificarArticulo(int id)
        {

        }


        public void eliminarArticulo(int id) { }
    }
}
