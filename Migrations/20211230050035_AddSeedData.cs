using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolucionCacao.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*
            var hasher = new PasswordHasher<IdentityUser>();
            
            migrationBuilder.AlterColumn<string>(
                name: "Usuario",
                table: "Logins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Logins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isPersistent",
                table: "Logins",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", "7f34e60b-fcba-4bc0-bab0-1a848b487fc8", "Admin", "ADMIN" });
            
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", 0, "0fe07e95-e0aa-40de-aca0-fdf9893f24ac", "admin@mail.com", true, false, null, "admin@mail.com", "Admin", hasher.HashPassword(null, "1234"), null, false, "", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Propietarios",
                columns: new[] { "Id", "Cedula", "Celular", "Nombre" },
                values: new object[,]
                {
                    { "90a3-312aa1-31b312-adsda", "0123456789", "0000000001", "Jose Espinoza" },
                    { "ed9dc571-6a49-434d-8d9f-3927beadea9f", "0123456710", "0012000001", "Maria Coronel" },
                    { "a4ae3658-de7f-434d-9429-e8ae84abf5c4", "0111156789", "0003400001", "Luis Molina" },
                    { "80d54a31-2db1-4be9-97e2-0dd88494220c", "0123333389", "0990000001", "Alberto Martinez" },
                    { "090b9a9a-3787-45b5-aa6e-9d45db2b4b1d", "0120000789", "0001000501", "Elena Diaz" },
                    { "99d857fe-55bf-4f05-8711-25bfd74c304e", "0444456789", "7000800901", "Paolo Szyt" }
                });

            migrationBuilder.InsertData(
                table: "Tecnicos",
                columns: new[] { "Id", "Cargo", "Contacto", "Correo", "Nombres" },
                values: new object[,]
                {
                    { "3123-312321-312312-adsda", "Tecnico a medio tiempo", "0012456001", "luis@mail.com", "Luis Espada" },
                    { "3040fca8-7aa5-4cc6-b0e7-41fbb061076d", "Tecnico de planta", "0012098001", "estef@mail.com", "Estefania Ocampos" },
                    { "13836003-4260-479e-ac51-26cd53478f31", "Tecnico Primario", "0012001121", "emunioz@mail.com", "Enrique Muñoz" },
                    { "284bc133-945c-4c88-8555-6cd61008e140", "Tecnico Secundario", "9812000001", "feli_carce@mail.com", "Felipe Carcelen" },
                    { "e9c6739e-a05e-4396-87e6-541b763e0b9e", "Ayudante", "0012006911", "laura_cas@mail.com", "Laura Castillo" },
                    { "659d91a1-1c89-4191-b8f8-9d46f0ac814f", "Pasante", "9012444001", "skert@mail.com", "Pedro Skert" }
                });

            migrationBuilder.InsertData(
                table: "lineaFichas",
                columns: new[] { "Id", "Arbol", "Fecha", "Fruto", "IdFicha", "Incidencia", "Severidad" },
                values: new object[,]
                {
                    { "qq12-3123kk-312312-adsda", 1, new DateTime(2021, 10, 15, 20, 4, 0, 0, DateTimeKind.Unspecified), 2, "WW82-3123kk-312312-a11da", 23, 0 },
                    { "qq14-3123kk-312312-adsda", 1, new DateTime(2021, 10, 18, 20, 4, 0, 0, DateTimeKind.Unspecified), 3, "WW82-3123kk-312312-a11da", 17, 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", "a18be9c0-aa65-4af8-bd17-00bd9344e575" });

            migrationBuilder.InsertData(
                table: "ZonaEstudios",
                columns: new[] { "Id", "Coordenadas", "Cultivo", "Densidad", "IdPropietario", "Lugar", "NombrePropietario" },
                values: new object[] { "qwer-312321-312312-adsda", "51° 30' 30'' N; 0° 7' 32'' O", "Cacao", 0, "90a3-312aa1-31b312-adsda", "Portoviejo", null });

            migrationBuilder.InsertData(
                table: "Fichas",
                columns: new[] { "Id", "Fecha", "IdTecnico", "IdZona", "NombreFicha", "lineaFichasId" },
                values: new object[] { "WW82-3123kk-312312-a11da", new DateTime(2021, 10, 15, 19, 4, 0, 0, DateTimeKind.Unspecified), "3123-312321-312312-adsda", "qwer-312321-312312-adsda", "FICHA 1", null });
            */
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /*
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", "a18be9c0-aa65-4af8-bd17-00bd9344e575" });

            migrationBuilder.DeleteData(
                table: "Fichas",
                keyColumn: "Id",
                keyValue: "WW82-3123kk-312312-a11da");

            migrationBuilder.DeleteData(
                table: "Propietarios",
                keyColumn: "Id",
                keyValue: "090b9a9a-3787-45b5-aa6e-9d45db2b4b1d");

            migrationBuilder.DeleteData(
                table: "Propietarios",
                keyColumn: "Id",
                keyValue: "80d54a31-2db1-4be9-97e2-0dd88494220c");

            migrationBuilder.DeleteData(
                table: "Propietarios",
                keyColumn: "Id",
                keyValue: "99d857fe-55bf-4f05-8711-25bfd74c304e");

            migrationBuilder.DeleteData(
                table: "Propietarios",
                keyColumn: "Id",
                keyValue: "a4ae3658-de7f-434d-9429-e8ae84abf5c4");

            migrationBuilder.DeleteData(
                table: "Propietarios",
                keyColumn: "Id",
                keyValue: "ed9dc571-6a49-434d-8d9f-3927beadea9f");

            migrationBuilder.DeleteData(
                table: "Tecnicos",
                keyColumn: "Id",
                keyValue: "13836003-4260-479e-ac51-26cd53478f31");

            migrationBuilder.DeleteData(
                table: "Tecnicos",
                keyColumn: "Id",
                keyValue: "284bc133-945c-4c88-8555-6cd61008e140");

            migrationBuilder.DeleteData(
                table: "Tecnicos",
                keyColumn: "Id",
                keyValue: "3040fca8-7aa5-4cc6-b0e7-41fbb061076d");

            migrationBuilder.DeleteData(
                table: "Tecnicos",
                keyColumn: "Id",
                keyValue: "659d91a1-1c89-4191-b8f8-9d46f0ac814f");

            migrationBuilder.DeleteData(
                table: "Tecnicos",
                keyColumn: "Id",
                keyValue: "e9c6739e-a05e-4396-87e6-541b763e0b9e");

            migrationBuilder.DeleteData(
                table: "lineaFichas",
                keyColumn: "Id",
                keyValue: "qq12-3123kk-312312-adsda");

            migrationBuilder.DeleteData(
                table: "lineaFichas",
                keyColumn: "Id",
                keyValue: "qq14-3123kk-312312-adsda");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575");

            migrationBuilder.DeleteData(
                table: "Tecnicos",
                keyColumn: "Id",
                keyValue: "3123-312321-312312-adsda");

            migrationBuilder.DeleteData(
                table: "ZonaEstudios",
                keyColumn: "Id",
                keyValue: "qwer-312321-312312-adsda");

            migrationBuilder.DeleteData(
                table: "Propietarios",
                keyColumn: "Id",
                keyValue: "90a3-312aa1-31b312-adsda");

            migrationBuilder.DropColumn(
                name: "isPersistent",
                table: "Logins");

            migrationBuilder.AlterColumn<string>(
                name: "Usuario",
                table: "Logins",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Logins",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

                */
        }
    }
}
