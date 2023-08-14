using System.ComponentModel.DataAnnotations;

namespace ClinicaSanFelipeWEB.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string? DescripcionProducto { get; set; }
        //[Range(0.01, double.MaxValue, ErrorMessage = "El precio de compra debe ser mayor a 0.")]
        public double PrecioCompra { get; set; }
        public DateTime FechaLote { get; set; }
        public DateTime FecRegistro { get; set; }
    }
}

