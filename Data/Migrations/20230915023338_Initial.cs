using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.GeneroId);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    SalaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.SalaId);
                });

            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sinopsis = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Trailer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.PeliculaId);
                    table.ForeignKey(
                        name: "FK_Peliculas_Generos_Genero",
                        column: x => x.Genero,
                        principalTable: "Generos",
                        principalColumn: "GeneroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funciones",
                columns: table => new
                {
                    FuncionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeliculaId = table.Column<int>(type: "int", nullable: false),
                    SalaId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horario = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funciones", x => x.FuncionId);
                    table.ForeignKey(
                        name: "FK_Funciones_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "PeliculaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funciones_Salas_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Salas",
                        principalColumn: "SalaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuncionId = table.Column<int>(type: "int", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Funciones_FuncionId",
                        column: x => x.FuncionId,
                        principalTable: "Funciones",
                        principalColumn: "FuncionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "GeneroId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Acción" },
                    { 2, "Aventuras" },
                    { 3, "Ciencia Ficción" },
                    { 4, "Comedia" },
                    { 5, "Documental" },
                    { 6, "Drama" },
                    { 7, "Fantasía" },
                    { 8, "Musical" },
                    { 9, "Suspense" },
                    { 10, "Terror" }
                });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "SalaId", "Capacidad", "Nombre" },
                values: new object[,]
                {
                    { 1, 5, "Sala 2D" },
                    { 2, 15, "Sala 3D" },
                    { 3, 35, "Sala 4D" }
                });

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "PeliculaId", "Genero", "Poster", "Sinopsis", "Titulo", "Trailer" },
                values: new object[,]
                {
                    { 1, 1, "https://arepavolatil.com/wp-content/uploads/2023/02/john-wick-4-poster.jpg", "El marqués Vincent de Gramont pretende matar a John Wick para afianzar su poder en la Orden Suprema. Sin embargo, John tratará de adelantarse a cada uno de sus movimientos hasta lograr enfrentarse cara a cara con su peor enemigo.", "John Wick IV", "https://www.youtube.com/embed/yjRHZEUamCc?si=feS8hy6UFtyiwahq" },
                    { 2, 1, "https://www.eltiempo.com/files/image_1200_680/uploads/2023/04/20/644146fceb8d1.jpeg", "Don Toretto y sus familias se enfrentan al peor enemigo imaginable, uno llegado desde el pasado con sed de venganza, dispuesto a cualquier cosa con tal de destruir todo aquello que Dom ama.", "Rapidos y Furiosos X", "https://www.youtube.com/embed/O5BOxn8Go8U?si=2LMMbvPew0ZmVlTi" },
                    { 3, 2, "https://pics.filmaffinity.com/avatar_the_way_of_water-722646748-mmed.jpg", "Jake Sully vive con su nueva familia en el planeta de Pandora. Cuando una amenaza conocida regresa, Jake debe trabajar con Neytiri y el ejército de la raza na'vi para proteger su planeta.", "Avatar: El sentido del agua", "https://www.youtube.com/embed/O5BOxn8Go8U?si=2LMMbvPew0ZmVlTi" },
                    { 4, 2, "https://cloudfront-us-east-1.images.arcpublishing.com/infobae/VW6GWH7SPFG67A4SJP3E7KVBTI.jpeg", "Jake Sully vive con su nueva familia en el planeta de Pandora. Cuando una amenaza conocida regresa, Jake debe trabajar con Neytiri y el ejército de la raza na'vi para proteger su planeta.", "Doctor Strange en el Multiverso de la Locura", "https://www.youtube.com/embed/O5BOxn8Go8U?si=2LMMbvPew0ZmVlTi" },
                    { 5, 3, "https://pics.filmaffinity.com/e_t_the_extra_terrestrial-391240254-mmed.jpg", "Un niño de nueve años que se encuentra con un extraterrestre y decide esconderlo en su casa.", "E.T", "https://www.youtube.com/embed/F8QgAwuxXtg?si=PnsNohdGF6f4tQge" },
                    { 6, 3, "https://pics.filmaffinity.com/m3gan-570441440-mmed.jpg", "Gemma, diseñadora de una muñeca de inteligencia artificial extraordinaria, se convierte en la tutora legal de una niña. Abrumada por la responsabilidad, cede su educación y protección a la muñeca, sin saber que las consecuencias serán terribles.", "M3GAN", "https://www.youtube.com/embed/e_6JPqOCH3c?si=VITogE6iQ3LLyfSh" },
                    { 7, 4, "https://pics.filmaffinity.com/esperando_la_carroza-675954190-mmed.jpg", "La confusión invade a una familia luego de que Mamá Cora, una anciana de 80 años, desaparece. Aunque algunos creen que ha muerto, nada es tan sencillo como parece.", "Esperando la Carroza", "https://www.youtube.com/embed/KIgOuEPQZsU?si=-NNrCoNipnMrhEWd" },
                    { 8, 4, "https://www.themoviedb.org/t/p/original/fNtqD4BTFj0Bgo9lyoAtmNFzxHN.jpg", "Después de ser expulsada de Barbieland por no ser una muñeca de aspecto perfecto, Barbie parte hacia el mundo humano para encontrar la verdadera felicidad.", "Barbie", "https://www.youtube.com/embed/eUP3hlBel5I?si=vrtvNdeEqn7ZedaC" },
                    { 9, 5, "https://pbs.twimg.com/media/FZ-GbuTXkAAqKKf.jpg", "Odisea cinematográfica a través de la obra creativa y musical de David Bowie.", "Moonage Daydream", "https://www.youtube.com/embed/2y9ttNYwzg0?si=buGYf09pjCtP6eYR" },
                    { 10, 5, "https://pics.filmaffinity.com/Pamela_una_historia_de_amor-650476834-large.jpg", "La propia Pamela Anderson narra la historia de su ascenso a la fama y sus turbulentos romances", "Pamela: Una historia de amor", "https://www.youtube.com/embed/WrIW0HU3R14?si=wOkPqY_CLMEflpj7" },
                    { 11, 6, "https://pics.filmaffinity.com/Los_Fabelman-540992417-large.jpg", "A una temprana edad, Sam, el primogénito de la familia Fabelman, desarrolla una gran inquietud por grabar películas. Armado con una cámara de 8mm, él y sus amigos filman desde hazañas bélicas hasta épicos westerns.", "Los Fabelman", "https://www.youtube.com/embed/PSpWKovHFf8?si=M9hjYJlFKDaSWCq5" },
                    { 12, 6, "https://pics.filmaffinity.com/knock_at_the_cabin-261379789-mmed.jpg", "Una familia de tres está de vacaciones en una cabaña remota, pero de repente cuatro extraños los toman como rehenes y les exigen que sacrifiquen a uno de los suyos para evitar el apocalipsis.", "Llaman a la puerta", "https://www.youtube.com/embed/2WLz2b0Namw?si=z8Q45TO4ionRUGdp" },
                    { 13, 7, "https://es.web.img2.acsta.net/pictures/14/04/30/11/55/592219.jpg", "Harry Potter se ha quedado huérfano y vive en casa de sus abominables tíos y el insoportable primo Dudley. Harry se siente muy triste y solo, hasta que un buen día recibe una carta que cambiará su vida para siempre.", "Harry Potter y la piedra filosofal", "https://www.youtube.com/embed/nnuRYwGw9bo?si=7zi9AM5R-mmziw39" },
                    { 14, 7, "https://ih1.redbubble.net/image.3323103114.2171/flat,750x,075,f-pad,750x1000,f8f8f8.jpg", "Sarah debe recorrer un laberinto para rescatar a su hermano pequeño, que ha sido secuestrado por unos duendes y está en manos del poderoso rey Jareth. La niña descubre inmediatamente que ha llegado a un lugar donde las cosas no son lo que parecen.", "Laberinto", "https://www.youtube.com/embed/geOjNXOKGbg?si=FPpp50_WLFs3CJOY" },
                    { 15, 8, "https://www.themoviedb.org/t/p/original/hk8InjdOf5EHCmPZxVyW8wlGLHr.jpg", "Troy y Gabriela se conocen en un karaoke durante las vacaciones. Troy es una estrella de baloncesto, y Gabriela es la nueva estudiante. Al volver al colegio, se presentan al casting para el musical de la escuela, pero deben superar varios obstáculos.", "High School Musical", "https://www.youtube.com/embed/d3fxIvliIj4?si=heWVh0h3MyIlySle" },
                    { 16, 8, "https://pics.filmaffinity.com/High_School_Musical_2_TV-318249736-large.jpg", "El curso ha terminado y Troy Bolton, la superestrella del equipo de baloncesto de East High School, la inteligente Gabriella Montez y el resto de los Wildcats se preparan para disfrutar del verano más emocionante de sus vidas.", "High School Musical II", "https://www.youtube.com/embed/PUeR2kRYQns?si=KNiy-R1g8ILgyf_R" },
                    { 17, 9, "https://pics.filmaffinity.com/paradise-726881551-mmed.jpg", "En el futuro, una nueva tecnología revolucionaria permite transferir años de vida de una persona a otra. Cuando una mujer tiene que renunciar a 40 años de su vida para pagar una deuda, su marido busca desesperadamente la forma de recuperarlos.", "Paradise", "https://www.youtube.com/embed/EikCPQ7Zc8U?si=ZoUs9Ll1uba1VVek" },
                    { 18, 9, "https://pics.filmaffinity.com/4x4-367646500-mmed.jpg", "Una camioneta 4x4 está estacionada en la vereda en un barrio como tantos de Buenos Aires. Un chico entra en ella para robar. La situación es desesperante: está encerrado. Alguien desde afuera tiene el control de la 4x4, y parece tener un plan.", "4x4", "https://www.youtube.com/embed/2ZAxzP4cfCI?si=h4Xe_zamVzxD8qM0" },
                    { 19, 10, "https://upload.wikimedia.org/wikipedia/commons/1/18/Eraserhead.jpg", "Henry Spencer y su novia tienen un hijo no humano, más bien un pequeño reptil. Henrry pasa todo el día intentando que el bebé deje de hacer travesuras por el apartamento.", "EraserHead", "https://www.youtube.com/embed/7WAzFWu2tVw?si=EQTNGStyfabnI12i" },
                    { 20, 10, "https://www.clarin.com/2019/07/30/YatePclIG_720x0__1.jpg", "Un grupo de estudiantes universitarios se aventuran en Black Hills Forest en Maryland para descubrir los misterios que envuelven la desaparición de Heather, la hermana de James Donahue.", "El proyecto Blair Witch", "https://www.youtube.com/embed/877jKnEMZb4?si=VNqCwhI2eoboJNQn" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_PeliculaId",
                table: "Funciones",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_SalaId",
                table: "Funciones",
                column: "SalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Peliculas_Genero",
                table: "Peliculas",
                column: "Genero");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FuncionId",
                table: "Tickets",
                column: "FuncionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Funciones");

            migrationBuilder.DropTable(
                name: "Peliculas");

            migrationBuilder.DropTable(
                name: "Salas");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}
