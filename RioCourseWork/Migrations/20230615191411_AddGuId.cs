using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RioCourseWork.Migrations
{
    /// <inheritdoc />
    public partial class AddGuId : Migration
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

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonId",
                table: "RfIdKeys",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId1",
                table: "Records",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Persons",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Records_PersonId1",
                table: "Records",
                column: "PersonId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Persons_PersonId1",
                table: "Records",
                column: "PersonId1",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Persons_PersonId1",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_PersonId1",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "PersonId1",
                table: "Records");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "RfIdKeys",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Persons",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Records_PersonId",
                table: "Records",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Persons_PersonId",
                table: "Records",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
