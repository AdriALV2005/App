using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

//Hacer referencias al modelo
using App1.Models;

namespace App1.ViewModels
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using App1.Rest;
    using App1.Models;
    public class ViewModels
    {
        // Método para obtener los datos de la vista desde la API
        public async Task<List<Datos>> DatosVista()
        {
            RestService restService = new RestService();
            string vista = await restService.Get("http://192.168.1.37:81/apirest/datos/vista");
            List<Datos> datos = JsonConvert.DeserializeObject<List<Datos>>(vista);
            return datos;
        }

        // Método para crear nuevos datos en la API
        public async Task<string> CrearDatos(string titulo, string descripcion, DateTime fecha, string estado, string categoria, string color)
        {
            RestService restService = new RestService();
            var dataObject = new
            {
                Titulo = titulo,
                Descripcion = descripcion,
                Fecha = fecha,
                Estado = estado,
                Categoria = categoria,
                Color = color
            };
            string jsonData = JsonConvert.SerializeObject(dataObject);
            return await restService.Post("http://192.168.1.37:81/apirest/datos/nuevo/", jsonData);
        }

        // Método para buscar datos en la API por ID
        public async Task<List<Datos>> BuscarDatos(int id)
        {
            RestService restService = new RestService();
            string vista = await restService.Get($"http://192.168.1.37:81/apirest/datos/buscar/{id}");
            List<Datos> datos = JsonConvert.DeserializeObject<List<Datos>>(vista);
            return datos;
        }

        // Método para editar datos en la API
        public async Task<string> EditarDatos(int id, string titulo, string descripcion, DateTime fecha, string estado, string categoria, string color)
        {
            RestService restService = new RestService();
            var dataObject = new
            {
                Id = id,
                Titulo = titulo,
                Descripcion = descripcion,
                Fecha = fecha,
                Estado = estado,
                Categoria = categoria,
                Color = color
            };
            string jsonData = JsonConvert.SerializeObject(dataObject);
            return await restService.Put($"http://192.168.1.37:81/apirest/datos/editar/{id}", jsonData);
        }

        // Método para eliminar datos en la API por ID
        public async Task<string> EliminarDatos(int id)
        {
            RestService restService = new RestService();
            return await restService.Delete($"/datos/eliminar/{id}");
        }
    }
}