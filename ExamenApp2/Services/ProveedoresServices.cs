

using ExamenApp2.Models;
using SQLite;

namespace ExamenApp2.Services
{
    public class ProveedoresServices
    {
        private readonly SQLiteConnection _dbConnection;

        public ProveedoresServices()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Proveedor.db3");
            _dbConnection = new SQLiteConnection(dbPath);
            _dbConnection.CreateTable<Proveedor>();
        }

        public List<Proveedor> GetAll()
        {
            return _dbConnection.Table<Proveedor>().ToList();
        }

        public int Insert(Proveedor proveedor)
        {
            return _dbConnection.Insert(proveedor);
        }

        public int Update(Proveedor proveedor)
        {
            return _dbConnection.Update(proveedor);
        }

        public int Delete(Proveedor proveedor)
        {
            return _dbConnection.Delete(proveedor);
        }
    }
}
