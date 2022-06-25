using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registro_Pronto.Migrations
{
    public partial class TerceiraMigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Records",
                newName: "Begin");

            migrationBuilder.AddColumn<long>(
                name: "Code",
                table: "Records",
                type: "BIGINT",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "Records",
                type: "DATETIME",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "End",
                table: "Records");

            migrationBuilder.RenameColumn(
                name: "Begin",
                table: "Records",
                newName: "Time");
        }
    }
}
