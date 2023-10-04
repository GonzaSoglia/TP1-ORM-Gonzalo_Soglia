using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CineContext : DbContext
    {
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Funcion> Funciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-AVFQTFN\SQLEXPRESS;Database=CineGBA;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(p => p.GeneroId);

                entity.Property(p => p.Nombre).HasMaxLength(50).IsRequired();

                entity.ToTable("Generos");
            });

            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.HasKey(p => p.PeliculaId);

                entity.Property(p => p.Titulo).HasMaxLength(50).IsRequired();
                entity.Property(p => p.Sinopsis).HasMaxLength(255).IsRequired();
                entity.Property(p => p.Poster).HasMaxLength(100).IsRequired();
                entity.Property(p => p.Trailer).HasMaxLength(100).IsRequired();
                entity.Property(p => p.Genero).IsRequired();

                entity.HasOne(p => p.Generos).WithMany(g => g.Peliculas).HasForeignKey(p => p.Genero);

                entity.ToTable("Peliculas");

            });

            modelBuilder.Entity<Funcion>(entity =>
            {
                entity.HasKey(f => f.FuncionId);

                entity.Property(f => f.PeliculaId).IsRequired();
                entity.Property(f => f.SalaId).IsRequired();
                entity.Property(f => f.Fecha).IsRequired();
                entity.Property(f => f.Horario).IsRequired();

                entity.HasOne(p => p.Peliculas).WithMany(f => f.Funciones).HasForeignKey(p => p.PeliculaId);
                entity.HasOne(s => s.Salas).WithMany(f => f.Funciones).HasForeignKey(p => p.SalaId);

                entity.ToTable("Funciones");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(t => t.TicketId);
                entity.Property(t => t.FuncionId).IsRequired();
                entity.Property(t => t.Usuario).HasMaxLength(50).IsRequired();

                entity.HasOne(t => t.Funciones).WithMany(f => f.Tickets).HasForeignKey(t => t.FuncionId);
                entity.ToTable("Tickets");
            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.HasKey(s => s.SalaId);

                entity.Property(s => s.Capacidad).IsRequired();
                entity.Property(s => s.Nombre).HasMaxLength(50).IsRequired();

                entity.ToTable("Salas");
            });

            modelBuilder.Entity<Genero>().HasData(
                new Genero { GeneroId = 1, Nombre = "Acción" },
                new Genero { GeneroId = 2, Nombre = "Aventuras" },
                new Genero { GeneroId = 3, Nombre = "Ciencia Ficción" },
                new Genero { GeneroId = 4, Nombre = "Comedia" },
                new Genero { GeneroId = 5, Nombre = "Documental" },
                new Genero { GeneroId = 6, Nombre = "Drama" },
                new Genero { GeneroId = 7, Nombre = "Fantasía" },
                new Genero { GeneroId = 8, Nombre = "Musical" },
                new Genero { GeneroId = 9, Nombre = "Suspense" },
                new Genero { GeneroId = 10, Nombre = "Terror" }
            );

            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.HasData(new Pelicula
                {
                    PeliculaId = 1,
                    Titulo = "John Wick IV",
                    Sinopsis = "El marqués Vincent de Gramont pretende matar a John Wick para afianzar su poder en la Orden Suprema. Sin embargo, John tratará de adelantarse a cada uno de sus movimientos hasta lograr enfrentarse cara a cara con su peor enemigo.",
                    Poster = "https://arepavolatil.com/wp-content/uploads/2023/02/john-wick-4-poster.jpg",
                    Trailer = "https://www.youtube.com/embed/yjRHZEUamCc?si=feS8hy6UFtyiwahq",
                    Genero = 1
                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 2,
                    Titulo = "Rapidos y Furiosos X",
                    Sinopsis = "Don Toretto y sus familias se enfrentan al peor enemigo imaginable, uno llegado desde el pasado con sed de venganza, dispuesto a cualquier cosa con tal de destruir todo aquello que Dom ama.",
                    Poster = "https://www.eltiempo.com/files/image_1200_680/uploads/2023/04/20/644146fceb8d1.jpeg",
                    Trailer = "https://www.youtube.com/embed/O5BOxn8Go8U?si=2LMMbvPew0ZmVlTi",
                    Genero = 1
                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 3,
                    Titulo = "Avatar: El sentido del agua",
                    Sinopsis = "Jake Sully vive con su nueva familia en el planeta de Pandora. Cuando una amenaza conocida regresa, Jake debe trabajar con Neytiri y el ejército de la raza na'vi para proteger su planeta.",
                    Poster = "https://pics.filmaffinity.com/avatar_the_way_of_water-722646748-mmed.jpg",
                    Trailer = "https://www.youtube.com/embed/O5BOxn8Go8U?si=2LMMbvPew0ZmVlTi",
                    Genero = 2
                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 4,
                    Titulo = "Doctor Strange en el Multiverso de la Locura",
                    Sinopsis = "Jake Sully vive con su nueva familia en el planeta de Pandora. Cuando una amenaza conocida regresa, Jake debe trabajar con Neytiri y el ejército de la raza na'vi para proteger su planeta.",
                    Poster = "https://cloudfront-us-east-1.images.arcpublishing.com/infobae/VW6GWH7SPFG67A4SJP3E7KVBTI.jpeg",
                    Trailer = "https://www.youtube.com/embed/O5BOxn8Go8U?si=2LMMbvPew0ZmVlTi",
                    Genero = 2
                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 5,
                    Titulo = "E.T",
                    Sinopsis = "Un niño de nueve años que se encuentra con un extraterrestre y decide esconderlo en su casa.",
                    Poster = "https://pics.filmaffinity.com/e_t_the_extra_terrestrial-391240254-mmed.jpg",
                    Trailer = "https://www.youtube.com/embed/F8QgAwuxXtg?si=PnsNohdGF6f4tQge",
                    Genero = 3
                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 6,
                    Titulo = "M3GAN",
                    Sinopsis = "Gemma, diseñadora de una muñeca de inteligencia artificial extraordinaria, se convierte en la tutora legal de una niña. Abrumada por la responsabilidad, cede su educación y protección a la muñeca, sin saber que las consecuencias serán terribles.",
                    Poster = "https://pics.filmaffinity.com/m3gan-570441440-mmed.jpg",
                    Trailer = "https://www.youtube.com/embed/e_6JPqOCH3c?si=VITogE6iQ3LLyfSh",
                    Genero = 3
                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 7,
                    Titulo = "Esperando la Carroza",
                    Sinopsis = "La confusión invade a una familia luego de que Mamá Cora, una anciana de 80 años, desaparece. Aunque algunos creen que ha muerto, nada es tan sencillo como parece.",
                    Poster = "https://pics.filmaffinity.com/esperando_la_carroza-675954190-mmed.jpg",
                    Trailer = "https://www.youtube.com/embed/KIgOuEPQZsU?si=-NNrCoNipnMrhEWd",
                    Genero = 4
                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 8,
                    Titulo = "Barbie",
                    Sinopsis = "Después de ser expulsada de Barbieland por no ser una muñeca de aspecto perfecto, Barbie parte hacia el mundo humano para encontrar la verdadera felicidad.",
                    Poster = "https://www.themoviedb.org/t/p/original/fNtqD4BTFj0Bgo9lyoAtmNFzxHN.jpg",
                    Trailer = "https://www.youtube.com/embed/eUP3hlBel5I?si=vrtvNdeEqn7ZedaC",
                    Genero = 4
                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 9,
                    Titulo = "Moonage Daydream",
                    Sinopsis = "Odisea cinematográfica a través de la obra creativa y musical de David Bowie.",
                    Poster = "https://pbs.twimg.com/media/FZ-GbuTXkAAqKKf.jpg",
                    Trailer = "https://www.youtube.com/embed/2y9ttNYwzg0?si=buGYf09pjCtP6eYR",
                    Genero = 5
                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 10,
                    Titulo = "Pamela: Una historia de amor",
                    Sinopsis = "La propia Pamela Anderson narra la historia de su ascenso a la fama y sus turbulentos romances",
                    Poster = "https://pics.filmaffinity.com/Pamela_una_historia_de_amor-650476834-large.jpg",
                    Trailer = "https://www.youtube.com/embed/WrIW0HU3R14?si=wOkPqY_CLMEflpj7",
                    Genero = 5
                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 11,
                    Titulo = "Los Fabelman",
                    Sinopsis = "A una temprana edad, Sam, el primogénito de la familia Fabelman, desarrolla una gran inquietud por grabar películas. Armado con una cámara de 8mm, él y sus amigos filman desde hazañas bélicas hasta épicos westerns.",
                    Poster = "https://pics.filmaffinity.com/Los_Fabelman-540992417-large.jpg",
                    Trailer = "https://www.youtube.com/embed/PSpWKovHFf8?si=M9hjYJlFKDaSWCq5",
                    Genero = 6
                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 12,
                    Titulo = "Llaman a la puerta",
                    Sinopsis = "Una familia de tres está de vacaciones en una cabaña remota, pero de repente cuatro extraños los toman como rehenes y les exigen que sacrifiquen a uno de los suyos para evitar el apocalipsis.",
                    Poster = "https://pics.filmaffinity.com/knock_at_the_cabin-261379789-mmed.jpg",
                    Trailer = "https://www.youtube.com/embed/2WLz2b0Namw?si=z8Q45TO4ionRUGdp",
                    Genero = 6
                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 13,
                    Titulo = "Harry Potter y la piedra filosofal",
                    Sinopsis = "Harry Potter se ha quedado huérfano y vive en casa de sus abominables tíos y el insoportable primo Dudley. Harry se siente muy triste y solo, hasta que un buen día recibe una carta que cambiará su vida para siempre.",
                    Poster = "https://es.web.img2.acsta.net/pictures/14/04/30/11/55/592219.jpg",
                    Trailer = "https://www.youtube.com/embed/nnuRYwGw9bo?si=7zi9AM5R-mmziw39",
                    Genero = 7
                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 14,
                    Titulo = "Laberinto",
                    Sinopsis = "Sarah debe recorrer un laberinto para rescatar a su hermano pequeño, que ha sido secuestrado por unos duendes y está en manos del poderoso rey Jareth. La niña descubre inmediatamente que ha llegado a un lugar donde las cosas no son lo que parecen.",
                    Poster = "https://ih1.redbubble.net/image.3323103114.2171/flat,750x,075,f-pad,750x1000,f8f8f8.jpg",
                    Trailer = "https://www.youtube.com/embed/geOjNXOKGbg?si=FPpp50_WLFs3CJOY",
                    Genero = 7
                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 15,
                    Titulo = "High School Musical",
                    Sinopsis = "Troy y Gabriela se conocen en un karaoke durante las vacaciones. Troy es una estrella de baloncesto, y Gabriela es la nueva estudiante. Al volver al colegio, se presentan al casting para el musical de la escuela, pero deben superar varios obstáculos.",
                    Poster = "https://www.themoviedb.org/t/p/original/hk8InjdOf5EHCmPZxVyW8wlGLHr.jpg",
                    Trailer = "https://www.youtube.com/embed/d3fxIvliIj4?si=heWVh0h3MyIlySle",
                    Genero = 8
                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 16,
                    Titulo = "High School Musical II",
                    Sinopsis = "El curso ha terminado y Troy Bolton, la superestrella del equipo de baloncesto de East High School, la inteligente Gabriella Montez y el resto de los Wildcats se preparan para disfrutar del verano más emocionante de sus vidas.",
                    Poster = "https://pics.filmaffinity.com/High_School_Musical_2_TV-318249736-large.jpg",
                    Trailer = "https://www.youtube.com/embed/PUeR2kRYQns?si=KNiy-R1g8ILgyf_R",
                    Genero = 8
                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 17,
                    Titulo = "Paradise",
                    Sinopsis = "En el futuro, una nueva tecnología revolucionaria permite transferir años de vida de una persona a otra. Cuando una mujer tiene que renunciar a 40 años de su vida para pagar una deuda, su marido busca desesperadamente la forma de recuperarlos.",
                    Poster = "https://pics.filmaffinity.com/paradise-726881551-mmed.jpg",
                    Trailer = "https://www.youtube.com/embed/EikCPQ7Zc8U?si=ZoUs9Ll1uba1VVek",
                    Genero = 9
                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 18,
                    Titulo = "4x4",
                    Sinopsis = "Una camioneta 4x4 está estacionada en la vereda en un barrio como tantos de Buenos Aires. Un chico entra en ella para robar. La situación es desesperante: está encerrado. Alguien desde afuera tiene el control de la 4x4, y parece tener un plan.",
                    Poster = "https://pics.filmaffinity.com/4x4-367646500-mmed.jpg",
                    Trailer = "https://www.youtube.com/embed/2ZAxzP4cfCI?si=h4Xe_zamVzxD8qM0",
                    Genero = 9
                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 19,
                    Titulo = "EraserHead",
                    Sinopsis = "Henry Spencer y su novia tienen un hijo no humano, más bien un pequeño reptil. Henrry pasa todo el día intentando que el bebé deje de hacer travesuras por el apartamento.",
                    Poster = "https://upload.wikimedia.org/wikipedia/commons/1/18/Eraserhead.jpg",
                    Trailer = "https://www.youtube.com/embed/7WAzFWu2tVw?si=EQTNGStyfabnI12i",
                    Genero = 10
                });
                entity.HasData(new Pelicula
                {
                    PeliculaId = 20,
                    Titulo = "El proyecto Blair Witch",
                    Sinopsis = "Un grupo de estudiantes universitarios se aventuran en Black Hills Forest en Maryland para descubrir los misterios que envuelven la desaparición de Heather, la hermana de James Donahue.",
                    Poster = "https://www.clarin.com/2019/07/30/YatePclIG_720x0__1.jpg",
                    Trailer = "https://www.youtube.com/embed/877jKnEMZb4?si=VNqCwhI2eoboJNQn",
                    Genero = 10
                });

            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.HasData(new Sala
                {
                    SalaId = 1,
                    Capacidad = 5,
                    Nombre = "Sala 2D"

                });
                entity.HasData(new Sala
                {
                    SalaId = 2,
                    Capacidad = 15,
                    Nombre = "Sala 3D"

                });

                entity.HasData(new Sala
                {
                    SalaId = 3,
                    Capacidad = 35,
                    Nombre = "Sala 4D"

                });

            });
        }
    }
}




        


              



        


