using Application.Utils;
using Data.Queries;
using Domain.Entities;
namespace Application.Validations
{
    public class ValidationMovies
    {
        private readonly QueryMovies _queryPeliculas = new();

        public void MostrarPeliculas()
        {
            List<Pelicula> peliculas = _queryPeliculas.GetAllPeliculas();
            if (peliculas.Count == 0)
            {
                Console.WriteLine(Message.ErrorNoHayPeliculas);
            }
            else
            {
                Console.WriteLine(Message.PeliculasDisponibles);
                foreach (Pelicula pelicula in peliculas)
                {
                    Console.WriteLine("     " + pelicula.PeliculaId + ". " + pelicula.Titulo);
                }
            }
        }

        public bool ValidarPelicula(string prompt, out int peliculaId)
        {
            List<Pelicula> peliculas = _queryPeliculas.GetAllPeliculas();
            do
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? string.Empty;

                if (int.TryParse(input, out peliculaId))
                {
                    if (ExistePelicula(peliculas, peliculaId))
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine(Message.PeliculaNoExisteError);
                    }
                }
                else
                {
                    Console.WriteLine(Message.PeliculaInvalida);
                }
            } while (true);
        }

        public static bool ExistePelicula(List<Pelicula> peliculas, int peliculaId)
        {
            foreach (Pelicula pelicula in peliculas)
            {
                if (pelicula.PeliculaId == peliculaId)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
