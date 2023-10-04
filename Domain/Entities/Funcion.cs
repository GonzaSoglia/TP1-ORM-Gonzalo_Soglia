﻿namespace Domain.Entities
{
    public class Funcion
    {
        public int FuncionId { get; set; }
        public int PeliculaId { get; set; }
        public int SalaId { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Horario { get; set; }
        public Pelicula Peliculas { get; set;}
        public Sala Salas {get; set;}
        public List<Ticket> Tickets {get; set;}      
    }
}
