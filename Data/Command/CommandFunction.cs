using Domain.Entities;
namespace Data.Command
{
    public class CommandFunction
    {
        private readonly CineContext _context = new ();

        public Funcion CreateFunction(int peliculaId, int salaId, DateTime fecha, TimeSpan horario)
        {
            Funcion funcion = new ()
            {
                PeliculaId = peliculaId,
                SalaId = salaId,
                Fecha = fecha.Date,
                Horario = horario
            };
            try
            {
                _context.Funciones.Add(funcion);
                _context.SaveChanges();
                return funcion;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error" + ex.Message);
                return funcion;
            }            
        }
    }
}
