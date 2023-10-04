using Application.Utils;
using Application.Validations;
using Data.Command;
using Data.Queries;
using Domain.Entities;
namespace Application.Services
{
    public class FunctionService
    {
        private readonly QueryFunction _queryFunciones = new();
        private readonly QueryMovies _queryPeliculas = new();
        private readonly CommandFunction _funcionCommand = new();
        private readonly ValidationMovies _validationPeliculaService = new();
        private readonly ValidationSala _validationSala = new();
        private readonly ValidationFunction _validationFuncion = new();
        public List<Funcion> GetFuncionByPelicula()
        {
            List<Funcion> funcionesDisponibles = new();

            while (true)
            {
                List<Pelicula> peliculas = _queryPeliculas.GetAllPeliculas();
                Banner.Cartelera();
                Console.WriteLine(Message.CarteleraMessage);
                _validationFuncion.MostrarPeliculasConFunciones(peliculas);

                bool encontradasFunciones;
                while (true)
                {
                    if (_validationPeliculaService.ValidarPelicula(Message.ConsultarFuncionPeliculaId, out int peliculaId))
                    {
                        Pelicula pelicula = _queryPeliculas.GetPeliculaById(peliculaId);
                        List<Funcion> funciones = _queryFunciones.GetFuncionByPeliculaId(peliculaId);

                        if (funciones.Count == 0)
                        {
                            Console.WriteLine("\n      Película: " + pelicula.Titulo);
                            Console.WriteLine(Message.PeliculaSinFunciones);
                        }
                        else
                        {
                            encontradasFunciones = true;
                            Banner.FuncionesPelicula();
                            Console.WriteLine("\n     Película: " + pelicula.Titulo);
                            _validationFuncion.MostrarListaFunciones(funciones);
                            funcionesDisponibles.AddRange(funciones);
                            break;
                        }
                    }
                }
                if (encontradasFunciones)
                {
                    Message.LimpiarConsola();
                    return funcionesDisponibles; 
                }
            }
        }
        public List<Funcion> GetFuncionByFecha()
        {
            Console.Clear();
            Banner.Cartelera();
            Console.WriteLine("\n     Películas en cartelera:\n");

            List<Pelicula> peliculas = _queryPeliculas.GetAllPeliculas();

            if (peliculas.Count == 0)
            {
                Console.WriteLine("\n     No hay películas disponibles en este momento.");
                return new List<Funcion>();
            }

            bool mostrarLista = true;

            while (true)
            {
                if (mostrarLista)
                {
                    _validationFuncion.MostrarPeliculasConFunciones(peliculas);
                }

                if (_validationPeliculaService.ValidarPelicula(Message.ConsultarFuncionPeliculaId, out int peliculaId))
                {
                    var peliculaSeleccionada = _queryPeliculas.GetPeliculaById(peliculaId);

                    var fechasDisponibles = _queryFunciones.ObtenerFechasFuncionesDisponiblesPorPelicula(peliculaId);

                    if (fechasDisponibles.Count > 0)
                    {
                        MostrarFechasDisponibles(peliculaSeleccionada, fechasDisponibles);

                        DateTime fechaSeleccionada = ObtenerFechaValidaDesdeLista(fechasDisponibles);

                        Console.WriteLine("\n     Funciones disponibles para: " + peliculaSeleccionada.Titulo + "\n");

                        List<Funcion> funcionesDisponibles = ConsultarFuncionesPorIdYFecha(peliculaId, fechaSeleccionada);

                        return funcionesDisponibles;
                    }
                    else
                    {
                        Console.WriteLine("\n      Actualmente no hay funciones disponibles para la película " + peliculaSeleccionada.Titulo);
                        mostrarLista = false;
                    }
                }
                else
                {
                    Console.WriteLine("     Película inválida. Por favor, intente nuevamente.");
                }
            }
        }
        private static void MostrarFechasDisponibles(Pelicula peliculaSeleccionada, List<DateTime> fechasDisponibles)
        {
            Console.Clear();
            Banner.FuncionesPelicula();
            Console.WriteLine("\n     Fecha de las funciones disponibles para la película \"" + peliculaSeleccionada.Titulo + "\":\n");
            foreach (var fecha in fechasDisponibles)
            {
                Console.WriteLine("     - " + fecha.ToString("yyyy-MM-dd"));
            }
        }
        private static DateTime ObtenerFechaValidaDesdeLista(List<DateTime> fechasDisponibles)
        {
            while (true)
            {
                Console.Write("\n     Ingrese la fecha en formato (yyyy-MM-dd) de la función que desea consultar: ");
                string fechaInput = Console.ReadLine() ?? string.Empty;

                if (DateTime.TryParse(fechaInput, out DateTime fechaSeleccionada))
                {
                    if (fechasDisponibles.Contains(fechaSeleccionada))
                    {
                        return fechaSeleccionada;
                    }
                    else
                    {
                        Console.WriteLine("\n     No hay funciones en la fecha ingresada. Por favor, intente nuevamente.");
                    }
                }
                else
                {
                    Console.WriteLine("\n     Error: Por favor, ingrese una fecha válida con formato aaaa-MM-dd.");
                }
            }
        }
        private List<Funcion> ConsultarFuncionesPorIdYFecha(int peliculaId, DateTime fechaSeleccionada)
        {
            List<Funcion> funcionesDisponibles = _queryFunciones.GetFuncionesByDateAndPelicula(peliculaId, fechaSeleccionada);

            if (funcionesDisponibles.Count > 0)
            {
                foreach (var funcion in funcionesDisponibles)
                {
                    Console.WriteLine("     - Num de Función: " + funcion.FuncionId +
                                      "     Fecha: " + funcion.Fecha.ToString("yyyy-MM-dd") +
                                      "     Hora: " + funcion.Horario +
                                      "     Sala: " + funcion.Salas.SalaId + "\n");
                }
                Message.LimpiarConsola();
            }
            else
            {
                Console.WriteLine("     No se encontraron funciones disponibles para la película y fecha ingresada.");
            }

            return funcionesDisponibles;
        }
        public Funcion RegistrarFuncion()
        {
            Funcion funcionCreada;
            while (true)
            {
                Banner.RegistrarFuncion();

                _validationSala.MostrarSalas();

                _ = _validationSala.ValidarSala(Message.SalaId, out int salaId);

                _validationPeliculaService.MostrarPeliculas();

                _ = _validationPeliculaService.ValidarPelicula(Message.PeliculaId, out int peliculaId);

                if (!Validation.Fecha(out DateTime fecha))
                {
                    Message.LimpiarConsola();
                    continue;
                }

                if (!Validation.Horario(Message.Hora, Message.Minuto, out TimeSpan horario))
                {
                    Message.LimpiarConsola();
                    continue;
                }

                if (_validationFuncion.HorarioDisponible(salaId, fecha, horario))
                {
                    funcionCreada = _funcionCommand.CreateFunction(peliculaId, salaId, fecha, horario);
                    Console.WriteLine(Message.FuncionCreada);
                    Message.LimpiarConsola();
                    break;
                }
            }
            return funcionCreada;
        }
    }
}
