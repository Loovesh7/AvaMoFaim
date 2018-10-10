using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoFaimWebService.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AlterColumn<byte[]>(
                name: "Logo",
                table: "Restaurants",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<string>(
                name: "Logo",
                table: "Restaurants",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldNullable: true);
        }
    }
}
