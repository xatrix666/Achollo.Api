namespace Achollo.Api.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Chollo> Chollos { get; set; }
    }
}
