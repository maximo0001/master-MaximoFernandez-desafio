namespace WebApplication1.Models
{
    public class Venta
    {
        public int IdUsuario { get; set; }
        public List<Producto> Productos { get; set; }
        public string Comentarios { get; set; }
    }
}
