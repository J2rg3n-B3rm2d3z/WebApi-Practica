namespace Tiendaapi.Modelo
{
    public class Mproducto
    {
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; } // => del tipo small money
    }
}
