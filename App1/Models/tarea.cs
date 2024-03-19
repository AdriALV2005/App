using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App1.Models
{
    public class tarea
    {
        [PrimaryKey, AutoIncrement]
        public int IdTarea { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }

    }


}
