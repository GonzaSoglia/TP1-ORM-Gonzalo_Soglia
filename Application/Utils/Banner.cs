namespace Application.Utils
{
    public static class Banner
    {
        public static void MenuPrincipal()
        {
            Console.WriteLine("");
            Console.WriteLine("    ╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("    ║                                            Bienvenido a CINE-GBA                                             ║");
            Console.WriteLine("    ╠══════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("    ║                                                                                                              ║");
            Console.WriteLine("    ║  - Elija una de las siguientes opciones:                                                                     ║");
            Console.WriteLine("    ║                                                                                                              ║");
            Console.WriteLine("    ║  (1) Ver Funciones disponibles por pelicula.                                                                 ║");
            Console.WriteLine("    ║  (2) Ver Funciones disponibles por fecha.                                                                    ║");
            Console.WriteLine("    ║  (3) Registrar Función.                                                                                      ║");
            Console.WriteLine("    ║  (4) Salir.                                                                                                  ║");
            Console.WriteLine("    ║                                                                                                              ║");
            Console.WriteLine("    ╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
        }
        public static void Cartelera()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("    ╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("    ║                                            Cartelera de CINE-GBA                                             ║");
            Console.WriteLine("    ╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine("");
        }
        public static void FuncionesPelicula()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("    ╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("    ║                                           Funciones de la PELICULA                                           ║");
            Console.WriteLine("    ╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
        }
        public static void RegistrarFuncion()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("    ╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("    ║                                            Registrar nueva FUNCIÓN                                           ║");
            Console.WriteLine("    ╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
        }
    }
}


