using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    idGender = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.idGender);
                });

            migrationBuilder.CreateTable(
                name: "ImagePost",
                columns: table => new
                {
                    idImage = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagePost", x => x.idImage);
                });

            migrationBuilder.CreateTable(
                name: "ListFriend",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false),
                    idFriend = table.Column<int>(type: "int", nullable: false),
                    dateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    state = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListFriend", x => new { x.idUser, x.idFriend });
                });

            migrationBuilder.CreateTable(
                name: "TypeOfNotifications",
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
                    table.PrimaryKey("PK_TypeOfNotifications", x => x.idType);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfPost",
                columns: table => new
                {
                    idTypeOfPost = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    typePost = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfPost", x => x.idTypeOfPost);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    idUSer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    birthday = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    idGenter = table.Column<int>(type: "int", nullable: false),
                    username = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isVerificate = table.Column<bool>(type: "bit", nullable: false),
                    dateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastSession = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.idUSer);
                    table.ForeignKey(
                        name: "FK_User_Gender_idGenter",
                        column: x => x.idGenter,
                        principalTable: "Gender",
                        principalColumn: "idGender",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    idPost = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    state = table.Column<bool>(type: "bit", nullable: false),
                    idTypePost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.idPost);
                    table.ForeignKey(
                        name: "FK_Post_TypeOfPost_idTypePost",
                        column: x => x.idTypePost,
                        principalTable: "TypeOfPost",
                        principalColumn: "idTypeOfPost",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_User_idUser",
                        column: x => x.idUser,
                        principalTable: "User",
                        principalColumn: "idUSer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    idNotification = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    isRead = table.Column<bool>(type: "bit", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idType = table.Column<int>(type: "int", nullable: false),
                    idPost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.idNotification);
                    table.ForeignKey(
                        name: "FK_Notification_Post_idPost",
                        column: x => x.idPost,
                        principalTable: "Post",
                        principalColumn: "idPost",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notification_TypeOfNotifications_idType",
                        column: x => x.idType,
                        principalTable: "TypeOfNotifications",
                        principalColumn: "idType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notification_idPost",
                table: "Notification",
                column: "idPost");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_idType",
                table: "Notification",
                column: "idType");

            migrationBuilder.CreateIndex(
                name: "IX_Post_idTypePost",
                table: "Post",
                column: "idTypePost");

            migrationBuilder.CreateIndex(
                name: "IX_Post_idUser",
                table: "Post",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_User_idGenter",
                table: "User",
                column: "idGenter");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagePost");

            migrationBuilder.DropTable(
                name: "ListFriend");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "TypeOfNotifications");

            migrationBuilder.DropTable(
                name: "TypeOfPost");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Gender");
        }
    }
}
