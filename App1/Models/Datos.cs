    using SQLite;
using System;

namespace App1.Models
{
    public class Datos
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public string Categoria { get; set; }
        public string Color { get; set; }

        public Datos()
        {

        }

    }
}
