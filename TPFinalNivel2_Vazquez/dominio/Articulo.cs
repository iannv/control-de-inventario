using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {
        public int Id { get; set; }

        [DisplayName("CODIGO")]
        public string Codigo { get; set; }

        [DisplayName("NOMBRE")]
        public string Nombre { get; set; }

        [DisplayName("DESCRIPCION")]
        public string Descripcion { get; set; }
        public string ImagenUrl { get; set; }

        [DisplayName("CATEGORIA")]
        public Categoria IdCategoria { get; set; }

        [DisplayName("MARCA")]
        public Marca IdMarca { get; set; }

        public decimal Precio { get; set; }

        [DisplayName("PRECIO")]
        public string PrecioFormateado
        {
            get
            {
                return Precio.ToString("C", CultureInfo.CreateSpecificCulture("es-AR"));
            }
        }
    }




}

