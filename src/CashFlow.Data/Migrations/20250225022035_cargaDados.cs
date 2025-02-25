using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CashFlow.Data.Migrations
{
    /// <inheritdoc />
    public partial class cargaDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountingEntries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
                    CreationUserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountingEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountingEntries_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountingEntries_Users_CreationUserId",
                        column: x => x.CreationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Code", "Description", "Name" },
                values: new object[,]
                {
                    { 1L, "A001", "", "Folha de Pagamento" },
                    { 2L, "A002", "", "Fornecedores" },
                    { 3L, "A002", "", "Projetos" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[] { 1L, "usuario@teste.com", "Usuário", "Teste", "$2a$11$dLz4QhENG15WV9QwudMCSebbfaZkZ./25EPMG4QhxEZPbkYKemD0u" });

            migrationBuilder.InsertData(
                table: "AccountingEntries",
                columns: new[] { "Id", "AccountId", "Amount", "CreationUserId", "Description", "EntryDate", "Type" },
                values: new object[,]
                {
                    { 1L, 1L, 100m, 1L, "Teste", new DateTime(2025, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2L, 1L, 100m, 1L, "Teste", new DateTime(2025, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 3L, 1L, 100m, 1L, "Teste", new DateTime(2025, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4L, 1L, 100m, 1L, "Teste", new DateTime(2025, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 5L, 1L, 100m, 1L, "Teste", new DateTime(2025, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountingEntries_AccountId",
                table: "AccountingEntries",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountingEntries_CreationUserId",
                table: "AccountingEntries",
                column: "CreationUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountingEntries");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
