using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBank.Infrastructure.Migrations
{
    public partial class EliminarTablaMyBanksGlobales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyBanksGlobales");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyBanksGlobales",
                columns: table => new
                {
                    Id = table.Column<int>(
                        type: "integer",
                        nullable: false)
                        .Annotation(
                            "Npgsql:ValueGenerationStrategy",
                            Npgsql.EntityFrameworkCore.PostgreSQL.Metadata.NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),

                    Nombre = table.Column<string>(
                        type: "text",
                        nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyBanksGlobales", x => x.Id);
                });
        }
    }
}