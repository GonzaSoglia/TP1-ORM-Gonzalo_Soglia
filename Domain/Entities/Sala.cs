namespace Domain.Entities
{
    public class Sala
    {
        public int SalaId { get; set;}
        public int Capacidad { get; set;}
        public string Nombre {get;set;}
        public List <Funcion> Funciones { get; set; }
    }
}
