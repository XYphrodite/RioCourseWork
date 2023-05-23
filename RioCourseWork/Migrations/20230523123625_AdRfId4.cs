using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RioCourseWork.Migrations
{
    /// <inheritdoc />
    public partial class AdRfId4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Persons_PersonId",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_PersonId",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "RFID",
                table: "Records");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Records",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RFID",
                table: "Records",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Records_PersonId",
                table: "Records",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Persons_PersonId",
                table: "Records",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");
        }
    }
}
