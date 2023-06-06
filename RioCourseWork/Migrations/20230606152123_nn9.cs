using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RioCourseWork.Migrations
{
    /// <inheritdoc />
    public partial class nn9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Persons_PersonId",
                table: "Records");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Records",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Persons_PersonId",
                table: "Records",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Persons_PersonId",
                table: "Records");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Records",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Persons_PersonId",
                table: "Records",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");
        }
    }
}
