using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SolucionCacao.Models
{
    public partial class db_concursoContext : DbContext
    {
        public db_concursoContext()
        {
        }

        public db_concursoContext(DbContextOptions<db_concursoContext> options)
            : base(options)
        {
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=db_concurso;Integrated Security=True;");
            }
        }

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

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
