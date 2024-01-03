using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastrecture.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "rolles",
                columns: table => new
                {
                    IdRolle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRolle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rolles", x => x.IdRolle);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ville = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobInTech = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.IdUser);
                });

           

            migrationBuilder.CreateTable(
                name: "userRolles",
                columns: table => new
                {
                    IDRolleUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRolle = table.Column<int>(type: "int", nullable: false),
                    RolleIdRolle = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    userIdUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRolles", x => x.IDRolleUser);
                    table.ForeignKey(
                        name: "FK_userRolles_rolles_RolleIdRolle",
                        column: x => x.RolleIdRolle,
                        principalTable: "rolles",
                        principalColumn: "IdRolle",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userRolles_users_userIdUser",
                        column: x => x.userIdUser,
                        principalTable: "users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

           

            migrationBuilder.CreateIndex(
                name: "IX_userRolles_RolleIdRolle",
                table: "userRolles",
                column: "RolleIdRolle");

            migrationBuilder.CreateIndex(
                name: "IX_userRolles_userIdUser",
                table: "userRolles",
                column: "userIdUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.DropTable(
                name: "userRolles");

            migrationBuilder.DropTable(
                name: "rolles");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
