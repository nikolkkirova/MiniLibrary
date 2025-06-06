using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniLibrary.Migrations
{
    /// <inheritdoc />
    public partial class ConvertStatusToEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
migrationBuilder.AddColumn<int>(
                name: "StatusTemp",
                table: "Book",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql(@"
                UPDATE Book SET StatusTemp = 0 WHERE Status = N'Да се прочете';
                UPDATE Book SET StatusTemp = 1 WHERE Status = N'Чета в момента';
                UPDATE Book SET StatusTemp = 2 WHERE Status = N'Прочетена';
            ");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "StatusTemp",
                table: "Book",
                newName: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
migrationBuilder.AddColumn<string>(
                name: "StatusTemp",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.Sql(@"
                UPDATE Book SET StatusTemp = N'Да се прочете' WHERE Status = 0;
                UPDATE Book SET StatusTemp = N'Чета в момента' WHERE Status = 1;
                UPDATE Book SET StatusTemp = N'Прочетена' WHERE Status = 2;
            ");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "StatusTemp",
                table: "Book",
                newName: "Status");
        }
    }
}
