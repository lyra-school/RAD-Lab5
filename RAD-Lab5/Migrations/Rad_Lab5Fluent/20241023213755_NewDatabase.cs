using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RAD_Lab5.Migrations.Rad_Lab5Fluent
{
    /// <inheritdoc />
    public partial class NewDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FluentUser",
                columns: table => new
                {
                    UniqueIdentifier = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentUser", x => x.UniqueIdentifier);
                    table.CheckConstraint("CK_Biography", "DATALENGTH([LastName]) >= 100");
                    table.CheckConstraint("CK_FirstName", "DATALENGTH([FirstName]) >= 5");
                    table.CheckConstraint("CK_LastName", "DATALENGTH([LastName]) >= 4");
                });

            migrationBuilder.CreateTable(
                name: "Biography",
                columns: table => new
                {
                    UniqueIdentifier = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<int>(type: "int", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biography", x => x.UniqueIdentifier);
                    table.ForeignKey(
                        name: "FK_Biography_FluentUser_UniqueIdentifier",
                        column: x => x.UniqueIdentifier,
                        principalTable: "FluentUser",
                        principalColumn: "UniqueIdentifier",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Biography");

            migrationBuilder.DropTable(
                name: "FluentUser");
        }
    }
}
