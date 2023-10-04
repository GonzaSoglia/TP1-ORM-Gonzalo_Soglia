﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(CineContext))]
    partial class CineContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Funcion", b =>
                {
                    b.Property<int>("FuncionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FuncionId"), 1L, 1);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("Horario")
                        .HasColumnType("time");

                    b.Property<int>("PeliculaId")
                        .HasColumnType("int");

                    b.Property<int>("SalaId")
                        .HasColumnType("int");

                    b.HasKey("FuncionId");

                    b.HasIndex("PeliculaId");

                    b.HasIndex("SalaId");

                    b.ToTable("Funciones", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Genero", b =>
                {
                    b.Property<int>("GeneroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GeneroId"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("GeneroId");

                    b.ToTable("Generos", (string)null);

                    b.HasData(
                        new
                        {
                            GeneroId = 1,
                            Nombre = "Acción"
                        },
                        new
                        {
                            GeneroId = 2,
                            Nombre = "Aventuras"
                        },
                        new
                        {
                            GeneroId = 3,
                            Nombre = "Ciencia Ficción"
                        },
                        new
                        {
                            GeneroId = 4,
                            Nombre = "Comedia"
                        },
                        new
                        {
                            GeneroId = 5,
                            Nombre = "Documental"
                        },
                        new
                        {
                            GeneroId = 6,
                            Nombre = "Drama"
                        },
                        new
                        {
                            GeneroId = 7,
                            Nombre = "Fantasía"
                        },
                        new
                        {
                            GeneroId = 8,
                            Nombre = "Musical"
                        },
                        new
                        {
                            GeneroId = 9,
                            Nombre = "Suspense"
                        },
                        new
                        {
                            GeneroId = 10,
                            Nombre = "Terror"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Pelicula", b =>
                {
                    b.Property<int>("PeliculaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PeliculaId"), 1L, 1);

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<string>("Poster")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Sinopsis")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Trailer")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PeliculaId");

                    b.HasIndex("Genero");

                    b.ToTable("Peliculas", (string)null);

                    b.HasData(
                        new
                        {
                            PeliculaId = 1,
                            Genero = 1,
                            Poster = "https://arepavolatil.com/wp-content/uploads/2023/02/john-wick-4-poster.jpg",
                            Sinopsis = "El marqués Vincent de Gramont pretende matar a John Wick para afianzar su poder en la Orden Suprema. Sin embargo, John tratará de adelantarse a cada uno de sus movimientos hasta lograr enfrentarse cara a cara con su peor enemigo.",
                            Titulo = "John Wick IV",
                            Trailer = "https://www.youtube.com/embed/yjRHZEUamCc?si=feS8hy6UFtyiwahq"
                        },
                        new
                        {
                            PeliculaId = 2,
                            Genero = 1,
                            Poster = "https://www.eltiempo.com/files/image_1200_680/uploads/2023/04/20/644146fceb8d1.jpeg",
                            Sinopsis = "Don Toretto y sus familias se enfrentan al peor enemigo imaginable, uno llegado desde el pasado con sed de venganza, dispuesto a cualquier cosa con tal de destruir todo aquello que Dom ama.",
                            Titulo = "Rapidos y Furiosos X",
                            Trailer = "https://www.youtube.com/embed/O5BOxn8Go8U?si=2LMMbvPew0ZmVlTi"
                        },
                        new
                        {
                            PeliculaId = 3,
                            Genero = 2,
                            Poster = "https://pics.filmaffinity.com/avatar_the_way_of_water-722646748-mmed.jpg",
                            Sinopsis = "Jake Sully vive con su nueva familia en el planeta de Pandora. Cuando una amenaza conocida regresa, Jake debe trabajar con Neytiri y el ejército de la raza na'vi para proteger su planeta.",
                            Titulo = "Avatar: El sentido del agua",
                            Trailer = "https://www.youtube.com/embed/O5BOxn8Go8U?si=2LMMbvPew0ZmVlTi"
                        },
                        new
                        {
                            PeliculaId = 4,
                            Genero = 2,
                            Poster = "https://cloudfront-us-east-1.images.arcpublishing.com/infobae/VW6GWH7SPFG67A4SJP3E7KVBTI.jpeg",
                            Sinopsis = "Jake Sully vive con su nueva familia en el planeta de Pandora. Cuando una amenaza conocida regresa, Jake debe trabajar con Neytiri y el ejército de la raza na'vi para proteger su planeta.",
                            Titulo = "Doctor Strange en el Multiverso de la Locura",
                            Trailer = "https://www.youtube.com/embed/O5BOxn8Go8U?si=2LMMbvPew0ZmVlTi"
                        },
                        new
                        {
                            PeliculaId = 5,
                            Genero = 3,
                            Poster = "https://pics.filmaffinity.com/e_t_the_extra_terrestrial-391240254-mmed.jpg",
                            Sinopsis = "Un niño de nueve años que se encuentra con un extraterrestre y decide esconderlo en su casa.",
                            Titulo = "E.T",
                            Trailer = "https://www.youtube.com/embed/F8QgAwuxXtg?si=PnsNohdGF6f4tQge"
                        },
                        new
                        {
                            PeliculaId = 6,
                            Genero = 3,
                            Poster = "https://pics.filmaffinity.com/m3gan-570441440-mmed.jpg",
                            Sinopsis = "Gemma, diseñadora de una muñeca de inteligencia artificial extraordinaria, se convierte en la tutora legal de una niña. Abrumada por la responsabilidad, cede su educación y protección a la muñeca, sin saber que las consecuencias serán terribles.",
                            Titulo = "M3GAN",
                            Trailer = "https://www.youtube.com/embed/e_6JPqOCH3c?si=VITogE6iQ3LLyfSh"
                        },
                        new
                        {
                            PeliculaId = 7,
                            Genero = 4,
                            Poster = "https://pics.filmaffinity.com/esperando_la_carroza-675954190-mmed.jpg",
                            Sinopsis = "La confusión invade a una familia luego de que Mamá Cora, una anciana de 80 años, desaparece. Aunque algunos creen que ha muerto, nada es tan sencillo como parece.",
                            Titulo = "Esperando la Carroza",
                            Trailer = "https://www.youtube.com/embed/KIgOuEPQZsU?si=-NNrCoNipnMrhEWd"
                        },
                        new
                        {
                            PeliculaId = 8,
                            Genero = 4,
                            Poster = "https://www.themoviedb.org/t/p/original/fNtqD4BTFj0Bgo9lyoAtmNFzxHN.jpg",
                            Sinopsis = "Después de ser expulsada de Barbieland por no ser una muñeca de aspecto perfecto, Barbie parte hacia el mundo humano para encontrar la verdadera felicidad.",
                            Titulo = "Barbie",
                            Trailer = "https://www.youtube.com/embed/eUP3hlBel5I?si=vrtvNdeEqn7ZedaC"
                        },
                        new
                        {
                            PeliculaId = 9,
                            Genero = 5,
                            Poster = "https://pbs.twimg.com/media/FZ-GbuTXkAAqKKf.jpg",
                            Sinopsis = "Odisea cinematográfica a través de la obra creativa y musical de David Bowie.",
                            Titulo = "Moonage Daydream",
                            Trailer = "https://www.youtube.com/embed/2y9ttNYwzg0?si=buGYf09pjCtP6eYR"
                        },
                        new
                        {
                            PeliculaId = 10,
                            Genero = 5,
                            Poster = "https://pics.filmaffinity.com/Pamela_una_historia_de_amor-650476834-large.jpg",
                            Sinopsis = "La propia Pamela Anderson narra la historia de su ascenso a la fama y sus turbulentos romances",
                            Titulo = "Pamela: Una historia de amor",
                            Trailer = "https://www.youtube.com/embed/WrIW0HU3R14?si=wOkPqY_CLMEflpj7"
                        },
                        new
                        {
                            PeliculaId = 11,
                            Genero = 6,
                            Poster = "https://pics.filmaffinity.com/Los_Fabelman-540992417-large.jpg",
                            Sinopsis = "A una temprana edad, Sam, el primogénito de la familia Fabelman, desarrolla una gran inquietud por grabar películas. Armado con una cámara de 8mm, él y sus amigos filman desde hazañas bélicas hasta épicos westerns.",
                            Titulo = "Los Fabelman",
                            Trailer = "https://www.youtube.com/embed/PSpWKovHFf8?si=M9hjYJlFKDaSWCq5"
                        },
                        new
                        {
                            PeliculaId = 12,
                            Genero = 6,
                            Poster = "https://pics.filmaffinity.com/knock_at_the_cabin-261379789-mmed.jpg",
                            Sinopsis = "Una familia de tres está de vacaciones en una cabaña remota, pero de repente cuatro extraños los toman como rehenes y les exigen que sacrifiquen a uno de los suyos para evitar el apocalipsis.",
                            Titulo = "Llaman a la puerta",
                            Trailer = "https://www.youtube.com/embed/2WLz2b0Namw?si=z8Q45TO4ionRUGdp"
                        },
                        new
                        {
                            PeliculaId = 13,
                            Genero = 7,
                            Poster = "https://es.web.img2.acsta.net/pictures/14/04/30/11/55/592219.jpg",
                            Sinopsis = "Harry Potter se ha quedado huérfano y vive en casa de sus abominables tíos y el insoportable primo Dudley. Harry se siente muy triste y solo, hasta que un buen día recibe una carta que cambiará su vida para siempre.",
                            Titulo = "Harry Potter y la piedra filosofal",
                            Trailer = "https://www.youtube.com/embed/nnuRYwGw9bo?si=7zi9AM5R-mmziw39"
                        },
                        new
                        {
                            PeliculaId = 14,
                            Genero = 7,
                            Poster = "https://ih1.redbubble.net/image.3323103114.2171/flat,750x,075,f-pad,750x1000,f8f8f8.jpg",
                            Sinopsis = "Sarah debe recorrer un laberinto para rescatar a su hermano pequeño, que ha sido secuestrado por unos duendes y está en manos del poderoso rey Jareth. La niña descubre inmediatamente que ha llegado a un lugar donde las cosas no son lo que parecen.",
                            Titulo = "Laberinto",
                            Trailer = "https://www.youtube.com/embed/geOjNXOKGbg?si=FPpp50_WLFs3CJOY"
                        },
                        new
                        {
                            PeliculaId = 15,
                            Genero = 8,
                            Poster = "https://www.themoviedb.org/t/p/original/hk8InjdOf5EHCmPZxVyW8wlGLHr.jpg",
                            Sinopsis = "Troy y Gabriela se conocen en un karaoke durante las vacaciones. Troy es una estrella de baloncesto, y Gabriela es la nueva estudiante. Al volver al colegio, se presentan al casting para el musical de la escuela, pero deben superar varios obstáculos.",
                            Titulo = "High School Musical",
                            Trailer = "https://www.youtube.com/embed/d3fxIvliIj4?si=heWVh0h3MyIlySle"
                        },
                        new
                        {
                            PeliculaId = 16,
                            Genero = 8,
                            Poster = "https://pics.filmaffinity.com/High_School_Musical_2_TV-318249736-large.jpg",
                            Sinopsis = "El curso ha terminado y Troy Bolton, la superestrella del equipo de baloncesto de East High School, la inteligente Gabriella Montez y el resto de los Wildcats se preparan para disfrutar del verano más emocionante de sus vidas.",
                            Titulo = "High School Musical II",
                            Trailer = "https://www.youtube.com/embed/PUeR2kRYQns?si=KNiy-R1g8ILgyf_R"
                        },
                        new
                        {
                            PeliculaId = 17,
                            Genero = 9,
                            Poster = "https://pics.filmaffinity.com/paradise-726881551-mmed.jpg",
                            Sinopsis = "En el futuro, una nueva tecnología revolucionaria permite transferir años de vida de una persona a otra. Cuando una mujer tiene que renunciar a 40 años de su vida para pagar una deuda, su marido busca desesperadamente la forma de recuperarlos.",
                            Titulo = "Paradise",
                            Trailer = "https://www.youtube.com/embed/EikCPQ7Zc8U?si=ZoUs9Ll1uba1VVek"
                        },
                        new
                        {
                            PeliculaId = 18,
                            Genero = 9,
                            Poster = "https://pics.filmaffinity.com/4x4-367646500-mmed.jpg",
                            Sinopsis = "Una camioneta 4x4 está estacionada en la vereda en un barrio como tantos de Buenos Aires. Un chico entra en ella para robar. La situación es desesperante: está encerrado. Alguien desde afuera tiene el control de la 4x4, y parece tener un plan.",
                            Titulo = "4x4",
                            Trailer = "https://www.youtube.com/embed/2ZAxzP4cfCI?si=h4Xe_zamVzxD8qM0"
                        },
                        new
                        {
                            PeliculaId = 19,
                            Genero = 10,
                            Poster = "https://upload.wikimedia.org/wikipedia/commons/1/18/Eraserhead.jpg",
                            Sinopsis = "Henry Spencer y su novia tienen un hijo no humano, más bien un pequeño reptil. Henrry pasa todo el día intentando que el bebé deje de hacer travesuras por el apartamento.",
                            Titulo = "EraserHead",
                            Trailer = "https://www.youtube.com/embed/7WAzFWu2tVw?si=EQTNGStyfabnI12i"
                        },
                        new
                        {
                            PeliculaId = 20,
                            Genero = 10,
                            Poster = "https://www.clarin.com/2019/07/30/YatePclIG_720x0__1.jpg",
                            Sinopsis = "Un grupo de estudiantes universitarios se aventuran en Black Hills Forest en Maryland para descubrir los misterios que envuelven la desaparición de Heather, la hermana de James Donahue.",
                            Titulo = "El proyecto Blair Witch",
                            Trailer = "https://www.youtube.com/embed/877jKnEMZb4?si=VNqCwhI2eoboJNQn"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Sala", b =>
                {
                    b.Property<int>("SalaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SalaId"), 1L, 1);

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SalaId");

                    b.ToTable("Salas", (string)null);

                    b.HasData(
                        new
                        {
                            SalaId = 1,
                            Capacidad = 5,
                            Nombre = "Sala 2D"
                        },
                        new
                        {
                            SalaId = 2,
                            Capacidad = 15,
                            Nombre = "Sala 3D"
                        },
                        new
                        {
                            SalaId = 3,
                            Capacidad = 35,
                            Nombre = "Sala 4D"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Ticket", b =>
                {
                    b.Property<Guid>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FuncionId")
                        .HasColumnType("int");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TicketId");

                    b.HasIndex("FuncionId");

                    b.ToTable("Tickets", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Funcion", b =>
                {
                    b.HasOne("Domain.Entities.Pelicula", "Peliculas")
                        .WithMany("Funciones")
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Sala", "Salas")
                        .WithMany("Funciones")
                        .HasForeignKey("SalaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Peliculas");

                    b.Navigation("Salas");
                });

            modelBuilder.Entity("Domain.Entities.Pelicula", b =>
                {
                    b.HasOne("Domain.Entities.Genero", "Generos")
                        .WithMany("Peliculas")
                        .HasForeignKey("Genero")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Generos");
                });

            modelBuilder.Entity("Domain.Entities.Ticket", b =>
                {
                    b.HasOne("Domain.Entities.Funcion", "Funciones")
                        .WithMany("Tickets")
                        .HasForeignKey("FuncionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funciones");
                });

            modelBuilder.Entity("Domain.Entities.Funcion", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Domain.Entities.Genero", b =>
                {
                    b.Navigation("Peliculas");
                });

            modelBuilder.Entity("Domain.Entities.Pelicula", b =>
                {
                    b.Navigation("Funciones");
                });

            modelBuilder.Entity("Domain.Entities.Sala", b =>
                {
                    b.Navigation("Funciones");
                });
#pragma warning restore 612, 618
        }
    }
}
