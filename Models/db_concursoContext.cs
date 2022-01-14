using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SolucionCacao.Models;

#nullable disable

namespace SolucionCacao.Models
{
    public partial class db_concursoContext : IdentityDbContext
    {
        //private readonly RoleManager<IdentityRole> gestionRol;
        //private readonly UserManager<IdentityUser> gestionUsuario;
        public db_concursoContext()
        {

        }

        public db_concursoContext(DbContextOptions<db_concursoContext> options)
            : base(options)
        {

        }

        //override ayuda a sobreescribir los metodos
        //OnModelCreating es una funcion que se ejecuta cuando se crea la base de datos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*
            const string ADMIN_ID = "777be9c0-aa65-4af8-bd17-11bd9344e575";

            // any guid, but nothing is against to use the same one
            const string ROLE_ID = ADMIN_ID;
            modelBuilder.InsertData(
                table: "IdentityRole",
                columns: new []{"Id","Name","NormalizedName"},
                values: new object[,]
                {{ROLE_ID,"Tecnico", "Tecnico".ToUpper()}}
            );

            var hasher = new PasswordHasher<IdentityUser>();
            modelBuilder.InsertData(
                table: "IdentityUser",
                columns: new[] {"Id","UserName","NormalizedUserName","Email","NormalizedEmail","EmailConfirmed","PasswordHash","SecurityStamp"},
                values: new object[,]
                {
                    {ADMIN_ID, "Tec","Tec","tec@mail.com","tec@mail.com",true,hasher.HashPassword(null, "1234"),string.Empty}
                }
            );
            modelBuilder.InsertData(
                table: "IdentityUserRole",
                columns: new []{"RoleId","UserId"},
                values: new object[,]
                {
                    {"165e6c3a-e52b-4860-b58a-4810c68cd6c4", ADMIN_ID}
                }
            );
            */
            seed(modelBuilder);

        }
        public void seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Propietario>().HasData(
                new Propietario { Cedula = "0123456789", Celular = "0000000001", Id = "90a3-312aa1-31b312-adsda", Nombre = "Jose Espinoza" }
                , new Propietario { Cedula = "0123456710", Celular = "0012000001", Id = Guid.NewGuid().ToString(), Nombre = "Maria Coronel" }
                , new Propietario { Cedula = "0111156789", Celular = "0003400001", Id = Guid.NewGuid().ToString(), Nombre = "Luis Molina" }
                , new Propietario { Cedula = "0123333389", Celular = "0990000001", Id = Guid.NewGuid().ToString(), Nombre = "Alberto Martinez" }
                , new Propietario { Cedula = "0120000789", Celular = "0001000501", Id = Guid.NewGuid().ToString(), Nombre = "Elena Diaz" }
                , new Propietario { Cedula = "0444456789", Celular = "7000800901", Id = Guid.NewGuid().ToString(), Nombre = "Paolo Szyt" }
            );

            modelBuilder.Entity<Tecnico>().HasData(
                new Tecnico { Id = "3123-312321-312312-adsda", Nombres = "Luis Espada", Correo = "luis@mail.com", Cargo = "Tecnico a medio tiempo", Contacto = "0012456001" }
                , new Tecnico { Id = Guid.NewGuid().ToString(), Nombres = "Estefania Ocampos", Correo = "estef@mail.com", Cargo = "Tecnico de planta", Contacto = "0012098001" }
                , new Tecnico { Id = Guid.NewGuid().ToString(), Nombres = "Enrique Muñoz", Correo = "emunioz@mail.com", Cargo = "Tecnico Primario", Contacto = "0012001121" }
                , new Tecnico { Id = Guid.NewGuid().ToString(), Nombres = "Felipe Carcelen", Correo = "feli_carce@mail.com", Cargo = "Tecnico Secundario", Contacto = "9812000001" }
                , new Tecnico { Id = Guid.NewGuid().ToString(), Nombres = "Laura Castillo", Correo = "laura_cas@mail.com", Cargo = "Ayudante", Contacto = "0012006911" }
                , new Tecnico { Id = Guid.NewGuid().ToString(), Nombres = "Pedro Skert", Correo = "skert@mail.com", Cargo = "Pasante", Contacto = "9012444001" }
            );

            modelBuilder.Entity<ZonaEstudio>().HasData(
                new ZonaEstudio { Id = "qwer-312321-312312-adsda", IdPropietario = "90a3-312aa1-31b312-adsda", Lugar = "Portoviejo", Coordenadas = "51° 30' 30'' N; 0° 7' 32'' O", Cultivo = "Cacao", Densidad = 0 }
            );

            modelBuilder.Entity<Ficha>().HasData(
                new Ficha { Id = "WW82-3123kk-312312-a11da", IdTecnico = "3123-312321-312312-adsda", IdZona = "qwer-312321-312312-adsda", Fecha = DateTime.Parse("15/10/2021 19:04"), NombreFicha = "FICHA 1" }
            );
            modelBuilder.Entity<lineaFichas>().HasData(
                new lineaFichas { Id = "qq12-3123kk-312312-adsda", Arbol = 1, Fruto = 2, Incidencia = 23, Severidad = 0, Fecha = DateTime.Parse("15/10/2021 20:04"), IdFicha = "WW82-3123kk-312312-a11da" }
                , new lineaFichas { Id = "qq14-3123kk-312312-adsda", Arbol = 1, Fruto = 3, Incidencia = 17, Severidad = 1, Fecha = DateTime.Parse("18/10/2021 20:04"), IdFicha = "WW82-3123kk-312312-a11da" }
            );

            /*modelBuilder.Entity<Login>().HasData(
                new Login {Id = Guid.NewGuid().ToString(), Usuario="Admin", Cargo="Admin", Password="1234"}
            );*/

            const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            // any guid, but nothing is against to use the same one
            const string ROLE_ID = ADMIN_ID;
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = ROLE_ID, Name = "Admin", NormalizedName = "Admin".ToUpper() }
            );

            var hasher = new PasswordHasher<IdentityUser>();
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = ADMIN_ID,
                    UserName = "Admin",
                    NormalizedUserName = "Admin",
                    Email = "admin@mail.com",
                    NormalizedEmail = "admin@mail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "1234"),
                    SecurityStamp = string.Empty
                }
            );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>{ RoleId = ROLE_ID, UserId = ADMIN_ID}
            );
        }
        public virtual DbSet<Ficha> Fichas { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Propietario> Propietarios { get; set; }
        public virtual DbSet<Tecnico> Tecnicos { get; set; }
        public virtual DbSet<ZonaEstudio> ZonaEstudios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=db_cacao;Integrated Security=True;");
                //optionsBuilder.UseInMemoryDatabase(databaseName: "testDB");
            }
        }

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Ficha>(entity =>
            {
                entity.ToTable("ficha");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Arbol).HasColumnName("ARBOL");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("FECHA");

                entity.Property(e => e.Fruto).HasColumnName("FRUTO");

                entity.Property(e => e.IdTecnico).HasColumnName("ID_TECNICO");

                entity.Property(e => e.IdZona).HasColumnName("ID_ZONA");

                entity.Property(e => e.Incidencia).HasColumnName("INCIDENCIA");

                entity.Property(e => e.Severidad).HasColumnName("SEVERIDAD");

                entity.HasOne(d => d.IdTecnicoNavigation)
                    .WithMany(p => p.Fichas)
                    .HasForeignKey(d => d.IdTecnico)
                    .HasConstraintName("FK_ficha_tecnico");

                entity.HasOne(d => d.IdZonaNavigation)
                    .WithMany(p => p.Fichas)
                    .HasForeignKey(d => d.IdZona)
                    .HasConstraintName("FK_ficha_zonaEstudio");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("login");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Cargo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CARGO");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("CONTRASEÑA");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO");
            });

            modelBuilder.Entity<Propietario>(entity =>
            {
                entity.ToTable("propietario");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CEDULA");

                entity.Property(e => e.Celular)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CELULAR");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<Tecnico>(entity =>
            {
                entity.ToTable("tecnico");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Cargo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CARGO");

                entity.Property(e => e.Contacto)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("CONTACTO");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CORREO");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRES");
            });

            modelBuilder.Entity<ZonaEstudio>(entity =>
            {
                entity.ToTable("zonaEstudio");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Coordenadas)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("COORDENADAS");

                entity.Property(e => e.Cultivo)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("CULTIVO");

                entity.Property(e => e.Densidad).HasColumnName("DENSIDAD");

                entity.Property(e => e.IdPropietario).HasColumnName("ID_PROPIETARIO");

                entity.Property(e => e.Lugar)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("LUGAR");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        */
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Ficha>(entity =>
            {
                entity.ToTable("ficha");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Arbol).HasColumnName("ARBOL");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("FECHA");

                entity.Property(e => e.Fruto).HasColumnName("FRUTO");

                entity.Property(e => e.IdTecnico).HasColumnName("ID_TECNICO");

                entity.Property(e => e.IdZona).HasColumnName("ID_ZONA");

                entity.Property(e => e.Incidencia).HasColumnName("INCIDENCIA");

                entity.Property(e => e.Severidad).HasColumnName("SEVERIDAD");

                entity.HasOne(d => d.IdTecnicoNavigation)
                    .WithMany(p => p.Fichas)
                    .HasForeignKey(d => d.IdTecnico)
                    .HasConstraintName("FK_ficha_tecnico");

                entity.HasOne(d => d.IdZonaNavigation)
                    .WithMany(p => p.Fichas)
                    .HasForeignKey(d => d.IdZona)
                    .HasConstraintName("FK_ficha_zonaEstudio");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("login");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Cargo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CARGO");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("CONTRASEÑA");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO");
            });

            modelBuilder.Entity<Propietario>(entity =>
            {
                entity.ToTable("propietario");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CEDULA");

                entity.Property(e => e.Celular)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CELULAR");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<Tecnico>(entity =>
            {
                entity.ToTable("tecnico");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Cargo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CARGO");

                entity.Property(e => e.Contacto)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("CONTACTO");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CORREO");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRES");
            });

            modelBuilder.Entity<ZonaEstudio>(entity =>
            {
                entity.ToTable("zonaEstudio");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Coordenadas)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("COORDENADAS");

                entity.Property(e => e.Cultivo)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("CULTIVO");

                entity.Property(e => e.Densidad).HasColumnName("DENSIDAD");

                entity.Property(e => e.IdPropietario).HasColumnName("ID_PROPIETARIO");

                entity.Property(e => e.Lugar)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("LUGAR");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        */
        public DbSet<SolucionCacao.Models.lineaFichas> lineaFichas { get; set; }
    }
}
