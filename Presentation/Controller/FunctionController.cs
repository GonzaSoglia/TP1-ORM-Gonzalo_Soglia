using Application.Services;
using Domain.Entities;
namespace Presentation.Controller
{
    public class FunctionController
    {
        private readonly FunctionService _funcionesService = new();

        public List<Funcion> GetFuncionByPelicula()
        {
            try
            {
                return _funcionesService.GetFuncionByPelicula();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener funciones por pelicula: " + ex.Message);
            }
        }
        public List<Funcion> GetFuncionByFecha()
        {
            try
            {
                return _funcionesService.GetFuncionByFecha();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener funciones por fecha" + ex.Message);
            }
        }
        public Funcion PostFuncion()
        {
            try
            {
                return _funcionesService.RegistrarFuncion();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al crear funcion: " + ex.Message);
            }
        }
    }
}
