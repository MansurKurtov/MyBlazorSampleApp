using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Entity.Migrations
{
    public partial class OperatorsTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_providers",
                table: "providers");

            migrationBuilder.RenameTable(
                name: "providers",
                newName: "adm_providers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_adm_providers",
                table: "adm_providers",
                column: "id");

            migrationBuilder.CreateTable(
                name: "adm_operators",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_operators", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adm_operators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_adm_providers",
                table: "adm_providers");

            migrationBuilder.RenameTable(
                name: "adm_providers",
                newName: "providers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_providers",
                table: "providers",
                column: "id");
        }
    }
}
