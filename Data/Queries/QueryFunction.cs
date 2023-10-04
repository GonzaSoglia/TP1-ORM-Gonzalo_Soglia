using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Queries
{
   public class QueryFunction
   {
        private readonly CineContext _context = new();

        public List<Funcion> GetFuncionByPeliculaId(int peliculaId)
        {
            return _context.Funciones.Where(f => f.PeliculaId == peliculaId).ToList();
        }

        public List<Funcion> GetFuncionBySalaFecha(int salaId, DateTime fecha)
        {
            return _context.Funciones.Where(f => f.SalaId == salaId && f.Fecha == fecha).ToList();
        }

        public List<Funcion> GetFuncionesByDateAndPelicula(int peliculaId, DateTime fecha)
        {
            return _context.Funciones.Where(f => f.Fecha == fecha && f.PeliculaId == peliculaId).Include(f => f.Peliculas)
                                     .Include(f => f.Salas).ToList();
        }

        public List<DateTime> ObtenerFechasFuncionesDisponiblesPorPelicula(int peliculaId)
        {
            return _context.Funciones.Where(f => f.PeliculaId == peliculaId).Select(f => f.Fecha.Date).Distinct().ToList();
        }
   }

}
