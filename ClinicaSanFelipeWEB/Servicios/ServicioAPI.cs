using ClinicaSanFelipeWEB.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ClinicaSanFelipeWEB.Servicios
{
	public class ServicioAPI:IServicioAPI
	{
		private static string? _baseUrl;

		public ServicioAPI()
		{
			var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
			_baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
		}

        public async Task<List<Producto>> Lista()
        {
            List<Producto> lista = new List<Producto>();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.GetAsync("Producto");

            if (response.IsSuccessStatusCode)
            {
                var jsonRespuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(jsonRespuesta);
                lista = resultado.lista;
            }

            return lista;
        }

        public async Task<Producto> Obtener(int idProducto)
        {
            Producto producto = new Producto();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.GetAsync($"Producto/{idProducto}");

            if (response.IsSuccessStatusCode)
            {
                var jsonRespuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoApi>(jsonRespuesta);
                producto = resultado.producto;
            }

            return producto;
        }

        public async Task<bool> Guardar(Producto producto)
        {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync($"Producto", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Editar(Producto producto)
        {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync($"Producto", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Eliminar(int idProducto)
        {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.DeleteAsync($"Producto/{idProducto}");

            return response.IsSuccessStatusCode;
        } 
    }
}

