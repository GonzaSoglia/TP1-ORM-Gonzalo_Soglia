using Application.Utils;
namespace Application.Validations
{
    public class Validation
    {
        public static bool Fecha(out DateTime fecha)
        {
            int año, mes;
            int añoActual = DateTime.Now.Year;

            do
            {
                Console.Write(Message.Año);
                if (int.TryParse(Console.ReadLine(), out año))
                {
                    if (año >= añoActual && año <= 2025)
                    {
                        break;
                    }
                    else if (año > 2025)
                    {
                        Console.WriteLine("\n     No se permite ingresar años después de 2024.");
                    }
                    else
                    {
                        Console.WriteLine("\n     Año inválido. Debe ser igual o posterior al año actual (" + añoActual + ").");
                    }
                }
                else
                {
                    Console.WriteLine("\n     Año inválido. Ingrese un número válido.");
                }
            } while (true);

            do
            {
                Console.Write(Message.Mes);
                if (int.TryParse(Console.ReadLine(), out mes) && mes >= 1 && mes <= 12)
                {
                    break;
                }
                Console.WriteLine("\n     Mes inválido.");
            } while (true);

            int maxDiasEnMes = DateTime.DaysInMonth(año, mes);

            do
            {
                Console.Write(Message.Dia);
                if (int.TryParse(Console.ReadLine(), out int dia) && dia >= 1 && dia <= maxDiasEnMes)
                {
                    fecha = new DateTime(año, mes, dia);

                    if (fecha >= DateTime.Now)
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("\n     Fecha inválida. Debe ser igual o posterior a la fecha actual.");
                    }
                }
                else
                {
                    Console.WriteLine("\n     Día inválido.");
                }
            }while (true);
        }

        public static bool Horario(string hora, string minuto, out TimeSpan horario)
        {
            int horas, minutos;
            do
            {
                Console.Write(hora);
                if (int.TryParse(Console.ReadLine(), out horas) && horas >= 0 && horas <= 23)
                {
                    break;
                }
                Console.WriteLine(Message.HoraInvalida);
            } while (true);

            do
            {
                Console.Write(minuto);
                if (int.TryParse(Console.ReadLine(), out minutos) && minutos >= 0 && minutos <= 59)
                {
                    break;
                }
                Console.WriteLine(Message.MinutoInvalido);
            } while (true);

            horario = new TimeSpan(horas, minutos, 0);
            return true;
        }
    }
}
