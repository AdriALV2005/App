using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using App1.Models;
using System.Threading.Tasks;

namespace App1.Data
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;

        public SQLiteHelper(string dbPath)
        {
            //-------------------------------------------
            if (String.IsNullOrEmpty(dbPath))
            {
                throw new ArgumentException("Ruta de base de datos no puede ser nula o vacía");
            }
            //---------------------------------------------
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<tarea>().Wait();
        }

        // Método para guardar tarea
        public Task<int> SaveTareasAsync(tarea tar)
        {
            if (tar.IdTarea != 0)
            {
                return db.UpdateAsync(tar);
            }
            else
            {
                return db.InsertAsync(tar);
            }
        }

        // Método para obtener todas las tareas
        public Task<List<tarea>> GetTareasAsync()
        {
            return db.Table<tarea>().ToListAsync();
        }

        // Método para obtener una tarea por su IdTarea
        public Task<tarea> GetTareaAsync(int IdTarea)
        {
            return db.Table<tarea>().Where(a => a.IdTarea == IdTarea).FirstOrDefaultAsync();
        }
    }
}



