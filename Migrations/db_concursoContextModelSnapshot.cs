﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SolucionCacao.Models;

namespace SolucionCacao.Migrations
{
    [DbContext(typeof(db_concursoContext))]
    partial class db_concursoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                            ConcurrencyStamp = "7f34e60b-fcba-4bc0-bab0-1a848b487fc8",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "0fe07e95-e0aa-40de-aca0-fdf9893f24ac",
                            Email = "admin@mail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@mail.com",
                            NormalizedUserName = "Admin",
                            PasswordHash = "AQAAAAEAACcQAAAAEPCPfe+Qux8KEPyIvFYyN4t/ufcyu1JENHUwaxCLs20G+LdRPbFhMoxhmy17pAVfpA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                            RoleId = "a18be9c0-aa65-4af8-bd17-00bd9344e575"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SolucionCacao.Models.Ficha", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("Fecha")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("IdTecnico")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdZona")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NombreFicha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lineaFichasId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("IdTecnico");

                    b.HasIndex("IdZona");

                    b.HasIndex("lineaFichasId");

                    b.ToTable("Fichas");

                    b.HasData(
                        new
                        {
                            Id = "WW82-3123kk-312312-a11da",
                            Fecha = new DateTime(2021, 10, 15, 19, 4, 0, 0, DateTimeKind.Unspecified),
                            IdTecnico = "3123-312321-312312-adsda",
                            IdZona = "qwer-312321-312312-adsda",
                            NombreFicha = "FICHA 1"
                        });
                });

            modelBuilder.Entity("SolucionCacao.Models.Login", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Cargo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isPersistent")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("SolucionCacao.Models.Propietario", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Propietarios");

                    b.HasData(
                        new
                        {
                            Id = "90a3-312aa1-31b312-adsda",
                            Cedula = "0123456789",
                            Celular = "0000000001",
                            Nombre = "Jose Espinoza"
                        },
                        new
                        {
                            Id = "ed9dc571-6a49-434d-8d9f-3927beadea9f",
                            Cedula = "0123456710",
                            Celular = "0012000001",
                            Nombre = "Maria Coronel"
                        },
                        new
                        {
                            Id = "a4ae3658-de7f-434d-9429-e8ae84abf5c4",
                            Cedula = "0111156789",
                            Celular = "0003400001",
                            Nombre = "Luis Molina"
                        },
                        new
                        {
                            Id = "80d54a31-2db1-4be9-97e2-0dd88494220c",
                            Cedula = "0123333389",
                            Celular = "0990000001",
                            Nombre = "Alberto Martinez"
                        },
                        new
                        {
                            Id = "090b9a9a-3787-45b5-aa6e-9d45db2b4b1d",
                            Cedula = "0120000789",
                            Celular = "0001000501",
                            Nombre = "Elena Diaz"
                        },
                        new
                        {
                            Id = "99d857fe-55bf-4f05-8711-25bfd74c304e",
                            Cedula = "0444456789",
                            Celular = "7000800901",
                            Nombre = "Paolo Szyt"
                        });
                });

            modelBuilder.Entity("SolucionCacao.Models.Tecnico", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contacto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tecnicos");

                    b.HasData(
                        new
                        {
                            Id = "3123-312321-312312-adsda",
                            Cargo = "Tecnico a medio tiempo",
                            Contacto = "0012456001",
                            Correo = "luis@mail.com",
                            Nombres = "Luis Espada"
                        },
                        new
                        {
                            Id = "3040fca8-7aa5-4cc6-b0e7-41fbb061076d",
                            Cargo = "Tecnico de planta",
                            Contacto = "0012098001",
                            Correo = "estef@mail.com",
                            Nombres = "Estefania Ocampos"
                        },
                        new
                        {
                            Id = "13836003-4260-479e-ac51-26cd53478f31",
                            Cargo = "Tecnico Primario",
                            Contacto = "0012001121",
                            Correo = "emunioz@mail.com",
                            Nombres = "Enrique Muñoz"
                        },
                        new
                        {
                            Id = "284bc133-945c-4c88-8555-6cd61008e140",
                            Cargo = "Tecnico Secundario",
                            Contacto = "9812000001",
                            Correo = "feli_carce@mail.com",
                            Nombres = "Felipe Carcelen"
                        },
                        new
                        {
                            Id = "e9c6739e-a05e-4396-87e6-541b763e0b9e",
                            Cargo = "Ayudante",
                            Contacto = "0012006911",
                            Correo = "laura_cas@mail.com",
                            Nombres = "Laura Castillo"
                        },
                        new
                        {
                            Id = "659d91a1-1c89-4191-b8f8-9d46f0ac814f",
                            Cargo = "Pasante",
                            Contacto = "9012444001",
                            Correo = "skert@mail.com",
                            Nombres = "Pedro Skert"
                        });
                });

            modelBuilder.Entity("SolucionCacao.Models.ZonaEstudio", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Coordenadas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cultivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Densidad")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("IdPropietario")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Lugar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombrePropietario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdPropietario");

                    b.ToTable("ZonaEstudios");

                    b.HasData(
                        new
                        {
                            Id = "qwer-312321-312312-adsda",
                            Coordenadas = "51° 30' 30'' N; 0° 7' 32'' O",
                            Cultivo = "Cacao",
                            Densidad = 0,
                            IdPropietario = "90a3-312aa1-31b312-adsda",
                            Lugar = "Portoviejo"
                        });
                });

            modelBuilder.Entity("SolucionCacao.Models.lineaFichas", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Arbol")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime?>("Fecha")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int?>("Fruto")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("IdFicha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Incidencia")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("Severidad")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("lineaFichas");

                    b.HasData(
                        new
                        {
                            Id = "qq12-3123kk-312312-adsda",
                            Arbol = 1,
                            Fecha = new DateTime(2021, 10, 15, 20, 4, 0, 0, DateTimeKind.Unspecified),
                            Fruto = 2,
                            IdFicha = "WW82-3123kk-312312-a11da",
                            Incidencia = 23,
                            Severidad = 0
                        },
                        new
                        {
                            Id = "qq14-3123kk-312312-adsda",
                            Arbol = 1,
                            Fecha = new DateTime(2021, 10, 18, 20, 4, 0, 0, DateTimeKind.Unspecified),
                            Fruto = 3,
                            IdFicha = "WW82-3123kk-312312-a11da",
                            Incidencia = 17,
                            Severidad = 1
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SolucionCacao.Models.Ficha", b =>
                {
                    b.HasOne("SolucionCacao.Models.Tecnico", "IdTecnicoNavigation")
                        .WithMany("Fichas")
                        .HasForeignKey("IdTecnico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SolucionCacao.Models.ZonaEstudio", "IdZonaNavigation")
                        .WithMany("Fichas")
                        .HasForeignKey("IdZona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SolucionCacao.Models.lineaFichas", null)
                        .WithMany("Fichas")
                        .HasForeignKey("lineaFichasId");

                    b.Navigation("IdTecnicoNavigation");

                    b.Navigation("IdZonaNavigation");
                });

            modelBuilder.Entity("SolucionCacao.Models.ZonaEstudio", b =>
                {
                    b.HasOne("SolucionCacao.Models.Propietario", "propietario")
                        .WithMany()
                        .HasForeignKey("IdPropietario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("propietario");
                });

            modelBuilder.Entity("SolucionCacao.Models.Tecnico", b =>
                {
                    b.Navigation("Fichas");
                });

            modelBuilder.Entity("SolucionCacao.Models.ZonaEstudio", b =>
                {
                    b.Navigation("Fichas");
                });

            modelBuilder.Entity("SolucionCacao.Models.lineaFichas", b =>
                {
                    b.Navigation("Fichas");
                });
#pragma warning restore 612, 618
        }
    }
}
