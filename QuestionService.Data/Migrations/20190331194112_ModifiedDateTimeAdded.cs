using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace QuestionService.Data.Migrations
{
    public partial class ModifiedDateTimeAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Questions",
                newName: "CreatedDateTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "Questions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "CreatedDateTime",
                table: "Questions",
                newName: "DateTime");
        }
    }
}
