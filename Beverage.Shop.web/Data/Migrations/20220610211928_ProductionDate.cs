using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beverage.Shop.web.Data.Migrations
{
    public partial class ProductionDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ProductionDate",
                table: "Drinks",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductionDate",
                table: "Drinks");
        }
    }
}
