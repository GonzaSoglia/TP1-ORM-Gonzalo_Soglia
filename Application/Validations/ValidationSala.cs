using Application.Utils;
using Data.Queries;
using Domain.Entities;
namespace Application.Validations
{
    public class ValidationSala
    { 
        private readonly QuerySalas _querySalas = new();

        public void MostrarSalas()
        {
            List<Sala> salasDisponibles = _querySalas.GetAllSalas();
            if (salasDisponibles.Count == 0)
            {
                Console.WriteLine(Message.ErrorNoHaySalas);
            }
            else
            {
                Console.WriteLine(Message.SalasDisponibles);
                foreach (Sala sala in salasDisponibles)
                {
                    Console.WriteLine("      Sala: " + sala.SalaId);
                }
            }
        }

        public bool ValidarSala(string promt, out int salaId)
        {
            List<Sala> salas = _querySalas.GetAllSalas();
            do
            {
                Console.Write(promt);
                string inputSala = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(inputSala, out salaId))
                {
                    if (ExisteSala(salas, salaId))
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine(Message.ErrorSalaNoExiste);
                    }
                }
                else
                {
                    Console.WriteLine(Message.SalaInvalida);
                }
            } while (true);
        }

        public static bool ExisteSala(List<Sala> salas, int salaId)
        {
            foreach (Sala sala in salas)
            {
                if (sala.SalaId == salaId)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

