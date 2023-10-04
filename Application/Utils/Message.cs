namespace Application.Utils
{
    public static class Message
    {       
        public const string CarteleraMessage = "\n     - Películas disponibles en cartelera:\n";
        public const string PeliculasDisponibles = "\n     -  Películas disponibles:\n";
        public const string SalasDisponibles = "\n     - Salas disponibles: \n";
        public const string ConsultarFuncionPeliculaId = "\n     - Ingrese el número de Pelicula que desea consultar funciones disponibles: ";
        public const string PeliculaId = "\n     - Ingrese el número de Película que desea registrar en la función: ";
        public const string SalaId = "\n     - Ingrese el número de Sala en la que desea registrar la función: ";
        public const string Año = "\n     - Ingrese el Año (ej. 2023): ";
        public const string Mes = "\n     - Ingrese el Mes (1-12): ";
        public const string Dia = "\n     - Ingrese el Día (1-31): ";
        public const string Hora = "\n     - Ingrese la Hora (0-23): ";
        public const string Minuto = "\n     - Ingrese los Minutos (0-59): ";   
        public const string PeliculaInvalida = "\n     * ERROR : El número de Pelicula ingresado es inválido. Intente nuevamente.";
        public const string SalaInvalida = "\n     * ERROR : El número de Sala ingresado es inválida. Intente nuevamente";
        public const string HoraInvalida = "\n     * ERROR : Hora inválida. Intente nuevamente";
        public const string MinutoInvalido = "\n     * ERROR : Minutos inválidos. Intente nuevamente";  
        public const string ErrorNoHaySalas = "\n     * ERROR : No hay salas disponibles para registrar funciones.";
        public const string ErrorNoHayPeliculas = "\n     * ERROR : No hay películas disponibles para registrar funciones.";
        public const string PeliculaSinFunciones = "\n      * ERROR : La película ingresada no tiene funciones disponibles en este momento.";
        public const string PeliculaNoExisteError = "\n     * ERROR : El número de pelicula ingresado no existe. Intente nuevamente.";
        public const string ErrorSalaNoExiste = "\n     * ERROR : El número de Sala ingresado no existe. Intente nuevamente.";             
        public const string FuncionCreada = "\n      Función creada satisfactoriamente!";     
        public const string PresioneEnter = "\n     - Presione ENTER para regresar al menú principal...";
        public static void LimpiarConsola()
        {
            Console.WriteLine(Message.PresioneEnter);
            Console.ReadLine();
            Console.Clear();
        }
    }
}
