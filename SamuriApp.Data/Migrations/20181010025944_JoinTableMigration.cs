using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuriApp.Data.Migrations
{
    public partial class JoinTableMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samuris_Battles_BattleId",
                table: "Samuris");

            migrationBuilder.DropIndex(
                name: "IX_Samuris_BattleId",
                table: "Samuris");

            migrationBuilder.DropColumn(
                name: "BattleId",
                table: "Samuris");

            migrationBuilder.CreateTable(
                name: "SamuriBattle",
                columns: table => new
                {
                    SamuriId = table.Column<int>(nullable: false),
                    BattleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SamuriBattle", x => new { x.BattleId, x.SamuriId });
                    table.ForeignKey(
                        name: "FK_SamuriBattle_Battles_BattleId",
                        column: x => x.BattleId,
                        principalTable: "Battles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SamuriBattle_Samuris_SamuriId",
                        column: x => x.SamuriId,
                        principalTable: "Samuris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SamuriBattle_SamuriId",
                table: "SamuriBattle",
                column: "SamuriId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SamuriBattle");

            migrationBuilder.AddColumn<int>(
                name: "BattleId",
                table: "Samuris",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Samuris_BattleId",
                table: "Samuris",
                column: "BattleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Samuris_Battles_BattleId",
                table: "Samuris",
                column: "BattleId",
                principalTable: "Battles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
