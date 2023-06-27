using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class relationshipchanged1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Projects_ProjectId1",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ProjectId1",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ProjectId1",
                table: "Tasks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId1",
                table: "Tasks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectId1",
                table: "Tasks",
                column: "ProjectId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Projects_ProjectId1",
                table: "Tasks",
                column: "ProjectId1",
                principalTable: "Projects",
                principalColumn: "ProjectId");
        }
    }
}
