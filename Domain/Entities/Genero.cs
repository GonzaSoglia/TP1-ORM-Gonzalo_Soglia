namespace Domain.Entities
{
    public class Genero
    {
        public int GeneroId { get; set; }
        public string Nombre { get; set; }
        public List <Pelicula> Peliculas { get; set; }
    }
}
