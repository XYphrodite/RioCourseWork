using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RioCourseWork.Migrations
{
    /// <inheritdoc />
    public partial class nn3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RfIdKeys_PersonId",
                table: "RfIdKeys");

            migrationBuilder.CreateIndex(
                name: "IX_RfIdKeys_PersonId",
                table: "RfIdKeys",
                column: "PersonId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RfIdKeys_PersonId",
                table: "RfIdKeys");

            migrationBuilder.CreateIndex(
                name: "IX_RfIdKeys_PersonId",
                table: "RfIdKeys",
                column: "PersonId");
        }
    }
}
