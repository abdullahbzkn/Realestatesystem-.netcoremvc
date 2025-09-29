using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class dbsonhal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WhatWeDoID",
                table: "WhatWeDos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "GalleryID",
                table: "Galleries",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "EntranceID",
                table: "Entrances",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ContactUsID",
                table: "ContactsUses",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AboutUsID",
                table: "AboutUses",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WhatWeDos",
                table: "WhatWeDos",
                column: "WhatWeDoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Galleries",
                table: "Galleries",
                column: "GalleryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entrances",
                table: "Entrances",
                column: "EntranceID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactsUses",
                table: "ContactsUses",
                column: "ContactUsID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AboutUses",
                table: "AboutUses",
                column: "AboutUsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WhatWeDos",
                table: "WhatWeDos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Galleries",
                table: "Galleries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entrances",
                table: "Entrances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactsUses",
                table: "ContactsUses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AboutUses",
                table: "AboutUses");

            migrationBuilder.DropColumn(
                name: "WhatWeDoID",
                table: "WhatWeDos");

            migrationBuilder.DropColumn(
                name: "GalleryID",
                table: "Galleries");

            migrationBuilder.DropColumn(
                name: "EntranceID",
                table: "Entrances");

            migrationBuilder.DropColumn(
                name: "ContactUsID",
                table: "ContactsUses");

            migrationBuilder.DropColumn(
                name: "AboutUsID",
                table: "AboutUses");
        }
    }
}
