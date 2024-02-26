using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leo.ControleCertificacoes.Core.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Department = table.Column<string>(type: "TEXT", nullable: true),
                    NumberOfCertifieds = table.Column<int>(type: "INTEGER", nullable: false),
                    Code = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Certifieds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Expiration = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Code = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certifieds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certifieds_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Code", "Department", "Name", "NumberOfCertifieds" },
                values: new object[] { new Guid("e1e7e405-4690-42e8-8423-dd9ecd389bc7"), 1, "Manutenção", "Employee 1", 1 });

            migrationBuilder.InsertData(
                table: "Certifieds",
                columns: new[] { "Id", "Code", "Description", "EmployeeId", "Expiration", "Name" },
                values: new object[] { new Guid("a4679709-46fc-4fe4-92bc-b227354abaa7"), 1, "Descrição 1", new Guid("e1e7e405-4690-42e8-8423-dd9ecd389bc7"), new DateOnly(2024, 2, 26), "Certified 1" });

            migrationBuilder.CreateIndex(
                name: "IX_Certifieds_Code",
                table: "Certifieds",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Certifieds_EmployeeId",
                table: "Certifieds",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Code",
                table: "Employees",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certifieds");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
