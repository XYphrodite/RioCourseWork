using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RioCourseWork.Migrations
{
    /// <inheritdoc />
    public partial class nn10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_RfIdKeys_RfIdKeyId",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_RfIdKeyId",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "RfIdKeyId",
                table: "Records");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RfIdKeyId",
                table: "Records",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Records_RfIdKeyId",
                table: "Records",
                column: "RfIdKeyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_RfIdKeys_RfIdKeyId",
                table: "Records",
                column: "RfIdKeyId",
                principalTable: "RfIdKeys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
