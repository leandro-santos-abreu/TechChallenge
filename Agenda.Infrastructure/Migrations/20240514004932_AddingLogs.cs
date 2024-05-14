using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agenda.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("86236288-10fa-467b-bc9b-21cc0facc89b"));

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp", nullable: false),
                    LogLevel = table.Column<string>(type: "VARCHAR", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "VARCHAR", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[] { new Guid("85107773-8036-4724-93f0-bce49ad9f09b"), "AEQhFqAVgpgrcsJHuIVbB+Wrb+TmY8XXijmVvfzvjo1bNuaQgsu+XukrY9Sfixi0oQ==", "leandro.abreu" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("85107773-8036-4724-93f0-bce49ad9f09b"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[] { new Guid("86236288-10fa-467b-bc9b-21cc0facc89b"), "AEQhFqAVgpgrcsJHuIVbB+Wrb+TmY8XXijmVvfzvjo1bNuaQgsu+XukrY9Sfixi0oQ==", "leandro.abreu" });
        }
    }
}
