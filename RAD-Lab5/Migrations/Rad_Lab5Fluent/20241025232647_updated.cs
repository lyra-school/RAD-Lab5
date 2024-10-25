using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RAD_Lab5.Migrations.Rad_Lab5Fluent
{
    /// <inheritdoc />
    public partial class updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Biography",
                table: "FluentUser");

            migrationBuilder.DropCheckConstraint(
                name: "CK_FirstName",
                table: "FluentUser");

            migrationBuilder.DropCheckConstraint(
                name: "CK_LastName",
                table: "FluentUser");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "FluentUser",
                newName: "user_age");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "FluentUser",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "FluentUser",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Biography",
                table: "Biography",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user_age",
                table: "FluentUser",
                newName: "Age");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "FluentUser",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "FluentUser",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Biography",
                table: "Biography",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Biography",
                table: "FluentUser",
                sql: "DATALENGTH([LastName]) >= 100");

            migrationBuilder.AddCheckConstraint(
                name: "CK_FirstName",
                table: "FluentUser",
                sql: "DATALENGTH([FirstName]) >= 5");

            migrationBuilder.AddCheckConstraint(
                name: "CK_LastName",
                table: "FluentUser",
                sql: "DATALENGTH([LastName]) >= 4");
        }
    }
}
