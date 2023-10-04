using Domain.Entities;
namespace Data.Queries
{
    public class QuerySalas
    {
        private readonly CineContext _context = new();
        public List<Sala> GetAllSalas()
        {
            return _context.Salas.ToList();
        }
    }
}
