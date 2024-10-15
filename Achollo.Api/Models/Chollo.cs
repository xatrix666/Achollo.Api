namespace Achollo.Api.Models
{
    public class Chollo
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioOriginal { get; set; }
        public decimal PrecioDescuento { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
