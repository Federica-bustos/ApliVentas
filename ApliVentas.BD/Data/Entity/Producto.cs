using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApliVentas.BD.Data.Entity
{
    public class Producto
    {
        public int id { get; set; }

        [Required(ErrorMessage = "EL Nombre del producto debe ser OBLIGATORIO")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en el Nombre del Deposito")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "EL Precio del Producto debe ser OBLIGATORIO")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 15 caracteres en el Precio del Producto")]
        public string precioProducto { get; set; }

    }
}
