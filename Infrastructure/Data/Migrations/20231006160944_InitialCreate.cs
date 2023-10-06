using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Especie",
                columns: table => new
                {
                    ID_EspeciePK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especie", x => x.ID_EspeciePK);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Laboratorio",
                columns: table => new
                {
                    ID_LaboratorioPK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratorio", x => x.ID_LaboratorioPK);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Propietario",
                columns: table => new
                {
                    ID_PropietarioPK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CorreoElectronico = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propietario", x => x.ID_PropietarioPK);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    ID_ProveedorPK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.ID_ProveedorPK);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    ID_RolPK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.ID_RolPK);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoMovimiento",
                columns: table => new
                {
                    ID_TipoFK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMovimiento", x => x.ID_TipoFK);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    ID_UsuarioPK = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CorreoElectronico = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Contraseña = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccessToken = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RefreshToken = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.ID_UsuarioPK);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Veterinario",
                columns: table => new
                {
                    ID_VeterinarioPK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CorreoElectronico = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Especialidad = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinario", x => x.ID_VeterinarioPK);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Raza",
                columns: table => new
                {
                    ID_RazaPK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ID_EspecieFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raza", x => x.ID_RazaPK);
                    table.ForeignKey(
                        name: "FK_Raza_Especie_ID_EspecieFK",
                        column: x => x.ID_EspecieFK,
                        principalTable: "Especie",
                        principalColumn: "ID_EspeciePK",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Medicamento",
                columns: table => new
                {
                    ID_MedicamentoPK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CantidadDisponible = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<float>(type: "float", nullable: false),
                    ID_LaboratorioFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamento", x => x.ID_MedicamentoPK);
                    table.ForeignKey(
                        name: "FK_Medicamento_Laboratorio_ID_LaboratorioFk",
                        column: x => x.ID_LaboratorioFk,
                        principalTable: "Laboratorio",
                        principalColumn: "ID_LaboratorioPK",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MovimientoMedicamento",
                columns: table => new
                {
                    ID_MovMedPK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ID_TipoFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientoMedicamento", x => x.ID_MovMedPK);
                    table.ForeignKey(
                        name: "FK_MovimientoMedicamento_TipoMovimiento_ID_TipoFK",
                        column: x => x.ID_TipoFK,
                        principalTable: "TipoMovimiento",
                        principalColumn: "ID_TipoFK",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RolesUsuarios",
                columns: table => new
                {
                    ID_RolPK = table.Column<int>(type: "int", nullable: false),
                    ID_UsuarioPK = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesUsuarios", x => new { x.ID_RolPK, x.ID_UsuarioPK });
                    table.ForeignKey(
                        name: "FK_RolesUsuarios_role_ID_RolPK",
                        column: x => x.ID_RolPK,
                        principalTable: "role",
                        principalColumn: "ID_RolPK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolesUsuarios_user_ID_UsuarioPK",
                        column: x => x.ID_UsuarioPK,
                        principalTable: "user",
                        principalColumn: "ID_UsuarioPK",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Mascota",
                columns: table => new
                {
                    ID_MascotaPK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ID_PropietarioFK = table.Column<int>(type: "int", nullable: false),
                    ID_RazaFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascota", x => x.ID_MascotaPK);
                    table.ForeignKey(
                        name: "FK_Mascota_Propietario_ID_PropietarioFK",
                        column: x => x.ID_PropietarioFK,
                        principalTable: "Propietario",
                        principalColumn: "ID_PropietarioPK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mascota_Raza_ID_RazaFK",
                        column: x => x.ID_RazaFK,
                        principalTable: "Raza",
                        principalColumn: "ID_RazaPK",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MedicamentosProveedores",
                columns: table => new
                {
                    ID_proveedorPK = table.Column<int>(type: "int", nullable: false),
                    ID_MedicamentoPK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicamentosProveedores", x => new { x.ID_proveedorPK, x.ID_MedicamentoPK });
                    table.ForeignKey(
                        name: "FK_MedicamentosProveedores_Medicamento_ID_MedicamentoPK",
                        column: x => x.ID_MedicamentoPK,
                        principalTable: "Medicamento",
                        principalColumn: "ID_MedicamentoPK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicamentosProveedores_Proveedor_ID_proveedorPK",
                        column: x => x.ID_proveedorPK,
                        principalTable: "Proveedor",
                        principalColumn: "ID_ProveedorPK",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DetalleMovimiento",
                columns: table => new
                {
                    ID_ProductoPK = table.Column<int>(type: "int", nullable: false),
                    ID_MovMedPK = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<float>(type: "float", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleMovimiento", x => new { x.ID_ProductoPK, x.ID_MovMedPK });
                    table.ForeignKey(
                        name: "FK_DetalleMovimiento_Medicamento_ID_ProductoPK",
                        column: x => x.ID_ProductoPK,
                        principalTable: "Medicamento",
                        principalColumn: "ID_MedicamentoPK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleMovimiento_MovimientoMedicamento_ID_MovMedPK",
                        column: x => x.ID_MovMedPK,
                        principalTable: "MovimientoMedicamento",
                        principalColumn: "ID_MovMedPK",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cita",
                columns: table => new
                {
                    Id_Cita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Motivo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ID_MascotaFk = table.Column<int>(type: "int", nullable: false),
                    ID_VeterinarioFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cita", x => x.Id_Cita);
                    table.ForeignKey(
                        name: "FK_Cita_Mascota_ID_MascotaFk",
                        column: x => x.ID_MascotaFk,
                        principalTable: "Mascota",
                        principalColumn: "ID_MascotaPK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cita_Veterinario_ID_VeterinarioFk",
                        column: x => x.ID_VeterinarioFk,
                        principalTable: "Veterinario",
                        principalColumn: "ID_VeterinarioPK",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TratamientoMedico",
                columns: table => new
                {
                    ID_TratamientoPk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Dosis = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaAdministracion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Observaciones = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ID_MedicamentoFk = table.Column<int>(type: "int", nullable: false),
                    ID_CitaFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TratamientoMedico", x => x.ID_TratamientoPk);
                    table.ForeignKey(
                        name: "FK_TratamientoMedico_Cita_ID_CitaFk",
                        column: x => x.ID_CitaFk,
                        principalTable: "Cita",
                        principalColumn: "Id_Cita",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TratamientoMedico_Medicamento_ID_MedicamentoFk",
                        column: x => x.ID_MedicamentoFk,
                        principalTable: "Medicamento",
                        principalColumn: "ID_MedicamentoPK",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Especie",
                columns: new[] { "ID_EspeciePK", "Nombre" },
                values: new object[,]
                {
                    { 1, "felina" },
                    { 2, "reptil" },
                    { 3, "ave" }
                });

            migrationBuilder.InsertData(
                table: "Laboratorio",
                columns: new[] { "ID_LaboratorioPK", "Direccion", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "centro comercial unicó", "Genfar", 123 },
                    { 2, "los alamos", "MK", 456 },
                    { 3, "Avenida siempre viva", "La Santé", 789 }
                });

            migrationBuilder.InsertData(
                table: "Propietario",
                columns: new[] { "ID_PropietarioPK", "CorreoElectronico", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Propietario1@gmail.com", "Propietario1", 1234 },
                    { 2, "Propietario2@gmail.com", "Propietario2", 1234 },
                    { 3, "Propietario3@gmail.com", "Propietario3", 1234 }
                });

            migrationBuilder.InsertData(
                table: "Veterinario",
                columns: new[] { "ID_VeterinarioPK", "CorreoElectronico", "Nombre", "Telefono", "Especialidad" },
                values: new object[,]
                {
                    { 1, "veterinarioa@gmail.com", "VeterinarioA", 123, "Cirujano Vascular" },
                    { 2, "veterinariob@gmail.com", "Veterinario1V", 456, "Fisioterapia" },
                    { 3, "veterinarioc@gmail.com", "Veterinario1C", 7890, "Oftalmología" }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "ID_RolPK", "Nombre" },
                values: new object[,]
                {
                    { 1, "Administrator" },
                    { 2, "Manager" },
                    { 3, "Employee" }
                });

            migrationBuilder.InsertData(
                table: "Medicamento",
                columns: new[] { "ID_MedicamentoPK", "ID_LaboratorioFk", "Nombre", "Precio", "CantidadDisponible" },
                values: new object[,]
                {
                    { 1, 3, "Ampicilina", 12500f, 14 },
                    { 2, 3, "Hidrocortizona", 5500f, 50 },
                    { 3, 3, "Lorataina", 3300f, 30 },
                    { 4, 2, "Diclofenalco", 7800f, 114 },
                    { 5, 2, "Fluoxetina", 15500f, 150 },
                    { 6, 2, "Acetamenophen", 4400f, 130 },
                    { 7, 1, "Ibuprofeno", 10500f, 114 },
                    { 8, 1, "Omeprazol", 3500f, 10 },
                    { 9, 1, "Naproxeno", 6500f, 430 }
                });

            migrationBuilder.InsertData(
                table: "Raza",
                columns: new[] { "ID_RazaPK", "ID_EspecieFK", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "tigre" },
                    { 2, 1, "jaguar" },
                    { 3, 1, "león" },
                    { 4, 2, "Cocodrilo" },
                    { 5, 2, "serpiente" },
                    { 6, 2, "dinosaurio" },
                    { 7, 3, "aguilas" },
                    { 8, 3, "Patos" },
                    { 9, 3, "Kiwis" }
                });

            migrationBuilder.InsertData(
                table: "Mascota",
                columns: new[] { "ID_MascotaPK", "FechaNacimiento", "ID_RazaFK", "Nombre", "ID_PropietarioFK" },
                values: new object[,]
                {
                    { 1, new DateTime(771, 4, 6, 11, 9, 44, 345, DateTimeKind.Local).AddTicks(8980), 6, "Barnie", 1 },
                    { 2, new DateTime(2023, 9, 6, 11, 9, 44, 345, DateTimeKind.Local).AddTicks(8998), 7, "Kus", 2 },
                    { 3, new DateTime(2023, 5, 29, 11, 9, 44, 345, DateTimeKind.Local).AddTicks(9003), 2, "Draco", 2 },
                    { 4, new DateTime(2023, 9, 26, 11, 9, 44, 345, DateTimeKind.Local).AddTicks(9004), 8, "Picote", 2 },
                    { 5, new DateTime(2021, 10, 6, 11, 9, 44, 345, DateTimeKind.Local).AddTicks(9005), 1, "Aquiles", 3 },
                    { 6, new DateTime(2023, 10, 1, 11, 9, 44, 345, DateTimeKind.Local).AddTicks(9006), 5, "Peter", 3 }
                });

            migrationBuilder.InsertData(
                table: "Cita",
                columns: new[] { "Id_Cita", "Fecha", "ID_MascotaFk", "Motivo", "ID_VeterinarioFk" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 12, 15, 9, 44, 341, DateTimeKind.Local).AddTicks(9184), 4, "vacunacion", 2 },
                    { 2, new DateTime(2023, 3, 31, 15, 9, 44, 341, DateTimeKind.Local).AddTicks(9208), 5, "infeccion", 2 },
                    { 3, new DateTime(2023, 4, 22, 15, 9, 44, 341, DateTimeKind.Local).AddTicks(9210), 4, "infeccion", 1 },
                    { 4, new DateTime(2023, 7, 5, 11, 9, 44, 341, DateTimeKind.Local).AddTicks(9211), 3, "infeccion", 2 },
                    { 5, new DateTime(2022, 12, 5, 12, 9, 44, 341, DateTimeKind.Local).AddTicks(9212), 5, "vacunacion", 2 },
                    { 6, new DateTime(2022, 10, 8, 13, 9, 44, 341, DateTimeKind.Local).AddTicks(9215), 5, "terapia", 2 },
                    { 7, new DateTime(2022, 10, 22, 9, 9, 44, 341, DateTimeKind.Local).AddTicks(9217), 3, "terapia", 2 },
                    { 8, new DateTime(2023, 9, 20, 14, 9, 44, 341, DateTimeKind.Local).AddTicks(9218), 5, "infeccion", 1 },
                    { 9, new DateTime(2023, 2, 2, 15, 9, 44, 341, DateTimeKind.Local).AddTicks(9219), 3, "infeccion", 1 },
                    { 10, new DateTime(2023, 2, 23, 15, 9, 44, 341, DateTimeKind.Local).AddTicks(9221), 2, "vacunacion", 2 },
                    { 11, new DateTime(2023, 8, 24, 9, 9, 44, 341, DateTimeKind.Local).AddTicks(9222), 2, "vacunacion", 1 },
                    { 12, new DateTime(2022, 12, 16, 11, 9, 44, 341, DateTimeKind.Local).AddTicks(9223), 1, "vacunacion", 2 },
                    { 13, new DateTime(2023, 9, 4, 10, 9, 44, 341, DateTimeKind.Local).AddTicks(9225), 1, "infeccion", 1 },
                    { 14, new DateTime(2023, 2, 4, 9, 9, 44, 341, DateTimeKind.Local).AddTicks(9226), 4, "infeccion", 2 },
                    { 15, new DateTime(2023, 3, 8, 10, 9, 44, 341, DateTimeKind.Local).AddTicks(9227), 3, "vacunacion", 2 },
                    { 16, new DateTime(2023, 5, 7, 10, 9, 44, 341, DateTimeKind.Local).AddTicks(9228), 3, "terapia", 2 },
                    { 17, new DateTime(2022, 11, 16, 10, 9, 44, 341, DateTimeKind.Local).AddTicks(9229), 5, "vacunacion", 2 },
                    { 18, new DateTime(2023, 4, 5, 13, 9, 44, 341, DateTimeKind.Local).AddTicks(9232), 5, "vacunacion", 1 },
                    { 19, new DateTime(2023, 1, 7, 12, 9, 44, 341, DateTimeKind.Local).AddTicks(9233), 3, "infeccion", 1 },
                    { 20, new DateTime(2022, 12, 8, 12, 9, 44, 341, DateTimeKind.Local).AddTicks(9234), 2, "terapia", 2 },
                    { 21, new DateTime(2023, 1, 4, 13, 9, 44, 341, DateTimeKind.Local).AddTicks(9235), 2, "vacunacion", 1 },
                    { 22, new DateTime(2023, 3, 31, 14, 9, 44, 341, DateTimeKind.Local).AddTicks(9236), 5, "terapia", 2 },
                    { 23, new DateTime(2023, 2, 2, 10, 9, 44, 341, DateTimeKind.Local).AddTicks(9238), 4, "infeccion", 1 },
                    { 24, new DateTime(2023, 8, 18, 15, 9, 44, 341, DateTimeKind.Local).AddTicks(9239), 4, "infeccion", 1 },
                    { 25, new DateTime(2023, 5, 15, 15, 9, 44, 341, DateTimeKind.Local).AddTicks(9240), 3, "infeccion", 2 },
                    { 26, new DateTime(2023, 4, 19, 9, 9, 44, 341, DateTimeKind.Local).AddTicks(9242), 3, "vacunacion", 1 },
                    { 27, new DateTime(2023, 3, 24, 15, 9, 44, 341, DateTimeKind.Local).AddTicks(9243), 3, "terapia", 1 },
                    { 28, new DateTime(2023, 6, 10, 10, 9, 44, 341, DateTimeKind.Local).AddTicks(9244), 5, "vacunacion", 1 },
                    { 29, new DateTime(2023, 9, 7, 10, 9, 44, 341, DateTimeKind.Local).AddTicks(9245), 4, "terapia", 1 },
                    { 30, new DateTime(2023, 8, 11, 10, 9, 44, 341, DateTimeKind.Local).AddTicks(9247), 4, "infeccion", 2 },
                    { 31, new DateTime(2023, 6, 18, 15, 9, 44, 341, DateTimeKind.Local).AddTicks(9248), 3, "terapia", 2 },
                    { 32, new DateTime(2023, 2, 17, 9, 9, 44, 341, DateTimeKind.Local).AddTicks(9249), 3, "infeccion", 2 },
                    { 33, new DateTime(2023, 7, 10, 11, 9, 44, 341, DateTimeKind.Local).AddTicks(9250), 2, "vacunacion", 2 },
                    { 34, new DateTime(2023, 5, 26, 10, 9, 44, 341, DateTimeKind.Local).AddTicks(9253), 4, "terapia", 2 },
                    { 35, new DateTime(2023, 8, 24, 10, 9, 44, 341, DateTimeKind.Local).AddTicks(9254), 1, "terapia", 1 },
                    { 36, new DateTime(2022, 11, 23, 10, 9, 44, 341, DateTimeKind.Local).AddTicks(9255), 3, "infeccion", 1 },
                    { 37, new DateTime(2022, 12, 26, 15, 9, 44, 341, DateTimeKind.Local).AddTicks(9256), 1, "terapia", 1 },
                    { 38, new DateTime(2023, 7, 30, 11, 9, 44, 341, DateTimeKind.Local).AddTicks(9258), 2, "terapia", 2 },
                    { 39, new DateTime(2023, 6, 15, 11, 9, 44, 341, DateTimeKind.Local).AddTicks(9259), 5, "infeccion", 2 },
                    { 40, new DateTime(2023, 1, 25, 9, 9, 44, 341, DateTimeKind.Local).AddTicks(9260), 5, "infeccion", 2 },
                    { 41, new DateTime(2023, 7, 31, 10, 9, 44, 341, DateTimeKind.Local).AddTicks(9262), 4, "terapia", 1 },
                    { 42, new DateTime(2023, 5, 13, 15, 9, 44, 341, DateTimeKind.Local).AddTicks(9263), 5, "infeccion", 1 },
                    { 43, new DateTime(2023, 7, 5, 10, 9, 44, 341, DateTimeKind.Local).AddTicks(9264), 3, "infeccion", 1 },
                    { 44, new DateTime(2023, 4, 13, 15, 9, 44, 341, DateTimeKind.Local).AddTicks(9265), 4, "terapia", 1 },
                    { 45, new DateTime(2023, 3, 1, 15, 9, 44, 341, DateTimeKind.Local).AddTicks(9267), 3, "terapia", 2 },
                    { 46, new DateTime(2023, 1, 4, 9, 9, 44, 341, DateTimeKind.Local).AddTicks(9268), 1, "vacunacion", 2 },
                    { 47, new DateTime(2023, 5, 10, 12, 9, 44, 341, DateTimeKind.Local).AddTicks(9295), 4, "infeccion", 2 },
                    { 48, new DateTime(2023, 5, 31, 13, 9, 44, 341, DateTimeKind.Local).AddTicks(9296), 5, "vacunacion", 2 },
                    { 49, new DateTime(2023, 9, 9, 13, 9, 44, 341, DateTimeKind.Local).AddTicks(9297), 1, "terapia", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cita_ID_MascotaFk",
                table: "Cita",
                column: "ID_MascotaFk");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_ID_VeterinarioFk",
                table: "Cita",
                column: "ID_VeterinarioFk");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleMovimiento_ID_MovMedPK",
                table: "DetalleMovimiento",
                column: "ID_MovMedPK");

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_ID_PropietarioFK",
                table: "Mascota",
                column: "ID_PropietarioFK");

            migrationBuilder.CreateIndex(
                name: "IX_Mascota_ID_RazaFK",
                table: "Mascota",
                column: "ID_RazaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamento_ID_LaboratorioFk",
                table: "Medicamento",
                column: "ID_LaboratorioFk");

            migrationBuilder.CreateIndex(
                name: "IX_MedicamentosProveedores_ID_MedicamentoPK",
                table: "MedicamentosProveedores",
                column: "ID_MedicamentoPK");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoMedicamento_ID_TipoFK",
                table: "MovimientoMedicamento",
                column: "ID_TipoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Raza_ID_EspecieFK",
                table: "Raza",
                column: "ID_EspecieFK");

            migrationBuilder.CreateIndex(
                name: "IX_RolesUsuarios_ID_UsuarioPK",
                table: "RolesUsuarios",
                column: "ID_UsuarioPK");

            migrationBuilder.CreateIndex(
                name: "IX_TratamientoMedico_ID_CitaFk",
                table: "TratamientoMedico",
                column: "ID_CitaFk");

            migrationBuilder.CreateIndex(
                name: "IX_TratamientoMedico_ID_MedicamentoFk",
                table: "TratamientoMedico",
                column: "ID_MedicamentoFk");

            migrationBuilder.CreateIndex(
                name: "IX_user_Nombre",
                table: "user",
                column: "Nombre",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleMovimiento");

            migrationBuilder.DropTable(
                name: "MedicamentosProveedores");

            migrationBuilder.DropTable(
                name: "RolesUsuarios");

            migrationBuilder.DropTable(
                name: "TratamientoMedico");

            migrationBuilder.DropTable(
                name: "MovimientoMedicamento");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "Cita");

            migrationBuilder.DropTable(
                name: "Medicamento");

            migrationBuilder.DropTable(
                name: "TipoMovimiento");

            migrationBuilder.DropTable(
                name: "Mascota");

            migrationBuilder.DropTable(
                name: "Veterinario");

            migrationBuilder.DropTable(
                name: "Laboratorio");

            migrationBuilder.DropTable(
                name: "Propietario");

            migrationBuilder.DropTable(
                name: "Raza");

            migrationBuilder.DropTable(
                name: "Especie");
        }
    }
}
