using Application.Utils;
using Presentation.Controller;
namespace Presentation
{    
    public class Menu
    {
        private readonly FunctionController _funcionController = new();

        public void Init()
        {
            bool continuar = true;

            while (continuar)
            {
                Banner.MenuPrincipal();
                string opcion = Console.ReadLine() ?? string.Empty;

                switch (opcion)
                {
                    case "1":
                    {
                            _funcionController.GetFuncionByPelicula();
                            break;
                    }
                    case "2":
                    { 
                            _funcionController.GetFuncionByFecha();
                            break;
                    }
                    case "3":
                    { 
                            _funcionController.PostFuncion();
                            break;
                    }
                    case "4":
                    {
                            Console.WriteLine("\n     Usted está saliendo del programa\n" +
                                              "\n     Hasta luego...");
                            continuar = false;
                            break;
                    }
                    default:
                    {
                            Console.Clear();
                            break;
                    }
                }
            }
        }
    }
}
