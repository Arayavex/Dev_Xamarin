using AppAmigos.v2.Model;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppAmigos.v2.Data
{
    //Operaciones basicas de un CRUD
    public class AmigosDatabase
    {
        //Definimos la conexion asincrona a SQLite
        private readonly SQLiteAsyncConnection database;

        //Constructor de la clase que recibe un String con una ruta de donde se encuentra el archivo de la DB
        public AmigosDatabase(string dbPath)
        {
            //Se hace una nueva instancia de SQLiteAsyncConnection y se le pasa por parametro la ruta
            database = new SQLiteAsyncConnection(dbPath);

            //Metodo para Crear una tabla en este caso llamada 'Amigos' y ademas Wait() es un metodo para llevar a cabo la inicializacion
            database.CreateTableAsync<Amigos>().Wait();
        }

        //Metodo asincrono que devuelve todos los registros de la tabla Amigos (todos los amigos)
        public async Task<List<Amigos>> GetItemsAsync()
        {
            //Query a la DB para que devuelva todos los datos de la Tabla Amigos y los convierte a una lista con ToListAsync()
            return await database.Table<Amigos>().ToListAsync();
        }

        //Metodo para obtener un unico item que obtiene como parametro el id del amigo
        public Task<Amigos> GetItemAsync(int id)
        {
            return database.Table<Amigos>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();//retorna el primer elemento o el que este por default
        }

        //Guardar elementos en la base de datos que recibe un objeto Amigo 
        public Task<int> SaveItemAsync(Amigos item)
        {
            //Si el ID del item no es igual a cero (que ya tiene un id asignado)
            if (item.ID != 0)
            {
                //se actualiza
                return database.UpdateAsync(item);
            }
            //De lo contrario
            else
            {
                //Se inserta un nuevo registro
                return database.InsertAsync(item);
            }
        }

        //Metodo para Borrar un elemento que recibe un Amigo
        public Task<int> DeleteItemAsync(Amigos item)
        {
            //Borra el objeto que recibio
            return database.DeleteAsync(item);
        }
    }
}
