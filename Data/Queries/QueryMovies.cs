using Domain.Entities;
namespace Data.Queries
{
    public class QueryMovies
    {      
        private readonly CineContext _context = new();

        public Pelicula GetPeliculaById(int peliculaId)
        {
            return _context.Peliculas.Where(l => l.PeliculaId == peliculaId).FirstOrDefault();
        }
        public List<Pelicula> GetAllPeliculas()
        {
            return _context.Peliculas.ToList();
        }
    }
}

