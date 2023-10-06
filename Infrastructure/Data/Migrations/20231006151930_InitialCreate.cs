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
                table: "role",
                columns: new[] { "ID_RolPK", "Nombre" },
                values: new object[,]
                {
                    { 1, "Administrator" },
                    { 2, "Manager" },
                    { 3, "Employee" }
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
