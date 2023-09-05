using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApliVentas.BD.Data.Entity
{
    public class PrecioFinal
    {
        public int id { get; set; }
        public Producto Producto { get; set; }

        [Required(ErrorMessage = "La fecha del dia a cargar el producto debe ser OBLIGATORIO")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en el Nombre del Deposito")]
        public DateTime fecha { get; set; }

        [Required(ErrorMessage = "EL precio final debe ser OBLIGATORIO")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en el Nombre del Deposito")]
        public int precioFinal { get; set; }

        public List<Producto> ProductoList { get; set; }
    }

    
}
