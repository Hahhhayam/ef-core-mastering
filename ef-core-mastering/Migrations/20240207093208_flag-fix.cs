using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ef_core_mastering.Migrations
{
    /// <inheritdoc />
    public partial class flagfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "flag",
                table: "countries",
                type: "text",
                nullable: false,
                oldClrType: typeof(char),
                oldType: "character(1)",
                oldMaxLength: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<char>(
                name: "flag",
                table: "countries",
                type: "character(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
