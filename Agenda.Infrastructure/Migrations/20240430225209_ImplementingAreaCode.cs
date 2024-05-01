using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Agenda.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ImplementingAreaCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CellPhone",
                table: "Contacts");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Contacts",
                type: "VARCHAR",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Contacts",
                type: "VARCHAR",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Contacts",
                type: "VARCHAR",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Contacts",
                type: "VARCHAR",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(11)",
                oldMaxLength: 11);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Contacts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "AreaCodes",
                columns: table => new
                {
                    Code = table.Column<string>(type: "VARCHAR", maxLength: 2, nullable: false),
                    Capital = table.Column<string>(type: "text", nullable: false),
                    FederalUnity = table.Column<string>(type: "VARCHAR", maxLength: 19, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaCodes", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "VARCHAR", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "VARCHAR", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumber",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AreaCode = table.Column<string>(type: "VARCHAR", maxLength: 2, nullable: false),
                    CellPhone = table.Column<string>(type: "VARCHAR", maxLength: 9, nullable: false),
                    ContactId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumber_AreaCodes_AreaCode",
                        column: x => x.AreaCode,
                        principalTable: "AreaCodes",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhoneNumber_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AreaCodes",
                columns: new[] { "Code", "Capital", "FederalUnity" },
                values: new object[,]
                {
                    { "11", "São Paulo", "São Paulo" },
                    { "12", "São Paulo", "São Paulo" },
                    { "13", "São Paulo", "São Paulo" },
                    { "14", "São Paulo", "São Paulo" },
                    { "15", "São Paulo", "São Paulo" },
                    { "16", "São Paulo", "São Paulo" },
                    { "17", "São Paulo", "São Paulo" },
                    { "18", "São Paulo", "São Paulo" },
                    { "19", "São Paulo", "São Paulo" },
                    { "21", "Rio de Janeiro", "Rio de Janeiro" },
                    { "22", "Rio de Janeiro", "Rio de Janeiro" },
                    { "24", "Rio de Janeiro", "Rio de Janeiro" },
                    { "27", "Vitória", "Espírito Santo" },
                    { "28", "Vitória", "Espírito Santo" },
                    { "31", "Belo Horizonte", "Minas Gerais" },
                    { "32", "Belo Horizonte", "Minas Gerais" },
                    { "33", "Belo Horizonte", "Minas Gerais" },
                    { "34", "Belo Horizonte", "Minas Gerais" },
                    { "35", "Belo Horizonte", "Minas Gerais" },
                    { "37", "Belo Horizonte", "Minas Gerais" },
                    { "38", "Belo Horizonte", "Minas Gerais" },
                    { "41", "Curitiba", "Paraná" },
                    { "42", "Curitiba", "Paraná" },
                    { "43", "Curitiba", "Paraná" },
                    { "44", "Curitiba", "Paraná" },
                    { "45", "Curitiba", "Paraná" },
                    { "46", "Curitiba", "Paraná" },
                    { "47", "Florianópolis", "Santa Catarina" },
                    { "48", "Florianópolis", "Santa Catarina" },
                    { "49", "Florianópolis", "Santa Catarina" },
                    { "51", "Porto Alegre", "Rio Grande do Sul" },
                    { "53", "Porto Alegre", "Rio Grande do Sul" },
                    { "54", "Porto Alegre", "Rio Grande do Sul" },
                    { "55", "Porto Alegre", "Rio Grande do Sul" },
                    { "61", "Brasília", "Distrito Federal" },
                    { "62", "Goiânia", "Goiás" },
                    { "63", "Palmas", "Tocantins" },
                    { "64", "Goiânia", "Goiás" },
                    { "65", "Cuiabá", "Mato Grosso" },
                    { "66", "Cuiabá", "Mato Grosso" },
                    { "67", "Campo Grande", "Mato Grosso do Sul" },
                    { "68", "Rio Branco", "Acre" },
                    { "69", "Porto Velho", "Rondônia" },
                    { "71", "Salvador", "Bahia" },
                    { "73", "Salvador", "Bahia" },
                    { "74", "Salvador", "Bahia" },
                    { "75", "Salvador", "Bahia" },
                    { "77", "Salvador", "Bahia" },
                    { "79", "Aracaju", "Sergipe" },
                    { "81", "Recife", "Pernambuco" },
                    { "82", "Maceió", "Alagoas" },
                    { "83", "João Pessoa", "Paraíba" },
                    { "84", "Natal", "Rio Grande do Norte" },
                    { "85", "Fortaleza", "Ceará" },
                    { "86", "Teresina", "Piauí" },
                    { "87", "Recife", "Pernambuco" },
                    { "88", "Fortaleza", "Ceará" },
                    { "89", "Teresina", "Piauí" },
                    { "91", "Belém", "Pará" },
                    { "92", "Manaus", "Amazonas" },
                    { "93", "Belém", "Pará" },
                    { "94", "Belém", "Pará" },
                    { "95", "Boa Vista", "Roraima" },
                    { "96", "Macapá", "Amapá" },
                    { "97", "Manaus", "Amazonas" },
                    { "98", "São Luís", "Maranhão" },
                    { "99", "São Luís", "Maranhão" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[] { new Guid("86236288-10fa-467b-bc9b-21cc0facc89b"), "AEQhFqAVgpgrcsJHuIVbB+Wrb+TmY8XXijmVvfzvjo1bNuaQgsu+XukrY9Sfixi0oQ==", "leandro.abreu" });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_UserId",
                table: "Contacts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumber_AreaCode",
                table: "PhoneNumber",
                column: "AreaCode");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumber_ContactId",
                table: "PhoneNumber",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Users_UserId",
                table: "Contacts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Users_UserId",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "PhoneNumber");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AreaCodes");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_UserId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Contacts");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Contacts",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Contacts",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Contacts",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Contacts",
                type: "character varying(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR",
                oldMaxLength: 11);

            migrationBuilder.AddColumn<long>(
                name: "CellPhone",
                table: "Contacts",
                type: "bigint",
                maxLength: 14,
                nullable: false,
                defaultValue: 0L);
        }
    }
}
