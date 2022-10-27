namespace Productos.Entity
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public float Precio { get; set; }
        public int Stock { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
