using System;
using ClinicaSanFelipeWEB.Models;

namespace ClinicaSanFelipeWEB.Servicios
{
	public interface IServicioAPI
	{
		Task<List<Producto>> Lista();
		Task<Producto> Obtener(int idProducto);
		Task<bool> Guardar(Producto producto);
        Task<bool> Editar(Producto producto);
        Task<bool> Eliminar(int idProducto);
    }
}

