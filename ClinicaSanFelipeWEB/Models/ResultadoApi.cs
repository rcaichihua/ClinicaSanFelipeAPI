using System;
namespace ClinicaSanFelipeWEB.Models
{
	public class ResultadoApi
	{
		public string mensaje { get; set; }
		public List<Producto> lista { get; set; }
		public Producto producto { get; set; }
	}
}

