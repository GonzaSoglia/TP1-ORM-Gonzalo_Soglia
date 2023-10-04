using Data.Queries;
using Domain.Entities;
namespace Application.Validations
{
    public class ValidationFunction
    {
        private readonly QueryFunction _queryFunciones = new();

        public void MostrarPeliculasConFunciones(List<Pelicula> peliculas)
        {
            foreach (Pelicula pelicula in peliculas)
            {
                List<Funcion> funciones = _queryFunciones.GetFuncionByPeliculaId(pelicula.PeliculaId);
                string estadoPelicula = "";

                if (funciones.Count == 0)
                {
                    estadoPelicula = " (Próximo estreno)";
                }

                Console.WriteLine("      " + pelicula.PeliculaId + ". " + pelicula.Titulo + estadoPelicula);
            }
        }

        public void MostrarListaFunciones(List<Funcion> funciones)
        {
            foreach (Funcion funcion in funciones)
            {
                Console.WriteLine("\n     Numero de Funcion: " + funcion.FuncionId + "     Fecha: " + funcion.Fecha.ToShortDateString() +
                                    "     Horario: " + funcion.Horario + "     Sala: " + funcion.SalaId);
            }
        }

        public bool HorarioDisponible(int salaId, DateTime fecha, TimeSpan horario)
        {
            List<Funcion> listaFunciones = _queryFunciones.GetFuncionBySalaFecha(salaId, fecha);

            foreach (Funcion funcion in listaFunciones)
            {
                TimeSpan diferencia = horario - funcion.Horario;
                if (diferencia.TotalMinutes < 150 && diferencia.TotalMinutes > 150)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
