

using SQLite;

namespace ExamenApp2.Models
{
    internal class Proveedor
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Tipo { get; set; }

        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Servicio { get; set; }
        public string Direccion { get; set; }

    }
}
