using Microsoft.AspNetCore.Mvc;
using ClinicaSanFelipeWEB.Models;
using ClinicaSanFelipeWEB.Servicios;

namespace ClinicaSanFelipeWEB.Controllers;

public class HomeController : Controller
{
    private readonly IServicioAPI _servicioApi;

    public HomeController(IServicioAPI servicioApi)
    {
        _servicioApi = servicioApi;
    }

    public async Task<IActionResult> Index()
    {
        List<Producto> lista = await _servicioApi.Lista();

        return View(lista);
    }

    public async Task<IActionResult> Producto(int idProducto)
    {
        Producto modeloProducto = new Producto();
        ViewBag.Accion = "Nuevo producto";
        if (idProducto != 0)
        {
            modeloProducto = await _servicioApi.Obtener(idProducto);
            ViewBag.Accion = "Editar producto";
        }

        return View(modeloProducto);
    }

    [HttpPost]
    public async Task<IActionResult> Guardar(Producto producto)
    {
        return (producto.IdProducto == 0 ? (await _servicioApi.Guardar(producto)) :
            (await _servicioApi.Editar(producto))) ? RedirectToAction("Index") : NoContent();
    }
}

