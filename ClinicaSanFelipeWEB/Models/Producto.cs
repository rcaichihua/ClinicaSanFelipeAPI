namespace ClinicaSanFelipeWEB.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public double PrecioCompra { get; set; }
        public double PrecioVenta { get; set; }
        public DateTime FechaLote { get; set; }
        public DateTime FecRegistro { get; set; }
    }
}

