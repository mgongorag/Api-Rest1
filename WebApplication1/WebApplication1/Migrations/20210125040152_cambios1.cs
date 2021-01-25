using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class cambios1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_TypeOfNotifications_idType",
                table: "Notification");

            migrationBuilder.DropTable(
                name: "TypeOfNotifications");

            migrationBuilder.CreateTable(
                name: "TypeOfNotification",
                columns: table => new
                {
                    idType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    message = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    state = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfNotification", x => x.idType);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_TypeOfNotification_idType",
                table: "Notification",
                column: "idType",
                principalTable: "TypeOfNotification",
                principalColumn: "idType",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_TypeOfNotification_idType",
                table: "Notification");

            migrationBuilder.DropTable(
                name: "TypeOfNotification");

            migrationBuilder.CreateTable(
                name: "TypeOfNotifications",
                columns: table => new
                {
                    idType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    message = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfNotifications", x => x.idType);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_TypeOfNotifications_idType",
                table: "Notification",
                column: "idType",
                principalTable: "TypeOfNotifications",
                principalColumn: "idType",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
