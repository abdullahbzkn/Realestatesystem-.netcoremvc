using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class dbupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceHousings_ServiceInfos_ServiceInfoId",
                table: "ServiceHousings");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceHousings_ServiceMaps_ServiceMapId",
                table: "ServiceHousings");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicePhotos_ServiceInfos_ServiceInfoId",
                table: "ServicePhotos");

            migrationBuilder.DropIndex(
                name: "IX_ServicePhotos_ServiceInfoId",
                table: "ServicePhotos");

            migrationBuilder.DropColumn(
                name: "ServiceInfoId",
                table: "ServicePhotos");

            migrationBuilder.DropColumn(
                name: "IlanNo",
                table: "ServiceInfos");

            migrationBuilder.AddColumn<int>(
                name: "ServiceHousingId",
                table: "ServicePhotos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceTerrainId",
                table: "ServicePhotos",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "YapininSekli",
                table: "ServiceHousings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "YapininDurumu",
                table: "ServiceHousings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "YapininCephesi",
                table: "ServiceHousings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "YakitTipi",
                table: "ServiceHousings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UzunAciklama",
                table: "ServiceHousings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "TuvaletSayisi",
                table: "ServiceHousings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "TapuDurumu",
                table: "ServiceHousings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "TakasYapilir",
                table: "ServiceHousings",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "ServiceHousings",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceMapId",
                table: "ServiceHousings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceInfoId",
                table: "ServiceHousings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SalonSayisi",
                table: "ServiceHousings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OdaSayisi",
                table: "ServiceHousings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "KullanimDurumu",
                table: "ServiceHousings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "KrediyeUygun",
                table: "ServiceHousings",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "KonumLink",
                table: "ServiceHousings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "KiraGetirisi",
                table: "ServiceHousings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Isitma",
                table: "ServiceHousings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Gorsel",
                table: "ServiceHousings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "Devren",
                table: "ServiceHousings",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "BulunduguKat",
                table: "ServiceHousings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BinaKatSayisi",
                table: "ServiceHousings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BanyoSayisi",
                table: "ServiceHousings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BalkonSayisi",
                table: "ServiceHousings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Aidat",
                table: "ServiceHousings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePhotos_ServiceHousingId",
                table: "ServicePhotos",
                column: "ServiceHousingId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePhotos_ServiceTerrainId",
                table: "ServicePhotos",
                column: "ServiceTerrainId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceHousings_ServiceInfos_ServiceInfoId",
                table: "ServiceHousings",
                column: "ServiceInfoId",
                principalTable: "ServiceInfos",
                principalColumn: "ServiceInfoID");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceHousings_ServiceMaps_ServiceMapId",
                table: "ServiceHousings",
                column: "ServiceMapId",
                principalTable: "ServiceMaps",
                principalColumn: "ServiceMapID");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicePhotos_ServiceHousings_ServiceHousingId",
                table: "ServicePhotos",
                column: "ServiceHousingId",
                principalTable: "ServiceHousings",
                principalColumn: "ServiceHousingID");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicePhotos_ServiceTerrains_ServiceTerrainId",
                table: "ServicePhotos",
                column: "ServiceTerrainId",
                principalTable: "ServiceTerrains",
                principalColumn: "ServiceTerrainID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceHousings_ServiceInfos_ServiceInfoId",
                table: "ServiceHousings");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceHousings_ServiceMaps_ServiceMapId",
                table: "ServiceHousings");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicePhotos_ServiceHousings_ServiceHousingId",
                table: "ServicePhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicePhotos_ServiceTerrains_ServiceTerrainId",
                table: "ServicePhotos");

            migrationBuilder.DropIndex(
                name: "IX_ServicePhotos_ServiceHousingId",
                table: "ServicePhotos");

            migrationBuilder.DropIndex(
                name: "IX_ServicePhotos_ServiceTerrainId",
                table: "ServicePhotos");

            migrationBuilder.DropColumn(
                name: "ServiceHousingId",
                table: "ServicePhotos");

            migrationBuilder.DropColumn(
                name: "ServiceTerrainId",
                table: "ServicePhotos");

            migrationBuilder.AddColumn<int>(
                name: "ServiceInfoId",
                table: "ServicePhotos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IlanNo",
                table: "ServiceInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "YapininSekli",
                table: "ServiceHousings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "YapininDurumu",
                table: "ServiceHousings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "YapininCephesi",
                table: "ServiceHousings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "YakitTipi",
                table: "ServiceHousings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UzunAciklama",
                table: "ServiceHousings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TuvaletSayisi",
                table: "ServiceHousings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TapuDurumu",
                table: "ServiceHousings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "TakasYapilir",
                table: "ServiceHousings",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "ServiceHousings",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ServiceMapId",
                table: "ServiceHousings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ServiceInfoId",
                table: "ServiceHousings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SalonSayisi",
                table: "ServiceHousings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OdaSayisi",
                table: "ServiceHousings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KullanimDurumu",
                table: "ServiceHousings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "KrediyeUygun",
                table: "ServiceHousings",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KonumLink",
                table: "ServiceHousings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KiraGetirisi",
                table: "ServiceHousings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Isitma",
                table: "ServiceHousings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gorsel",
                table: "ServiceHousings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Devren",
                table: "ServiceHousings",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BulunduguKat",
                table: "ServiceHousings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BinaKatSayisi",
                table: "ServiceHousings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BanyoSayisi",
                table: "ServiceHousings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BalkonSayisi",
                table: "ServiceHousings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Aidat",
                table: "ServiceHousings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServicePhotos_ServiceInfoId",
                table: "ServicePhotos",
                column: "ServiceInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceHousings_ServiceInfos_ServiceInfoId",
                table: "ServiceHousings",
                column: "ServiceInfoId",
                principalTable: "ServiceInfos",
                principalColumn: "ServiceInfoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceHousings_ServiceMaps_ServiceMapId",
                table: "ServiceHousings",
                column: "ServiceMapId",
                principalTable: "ServiceMaps",
                principalColumn: "ServiceMapID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicePhotos_ServiceInfos_ServiceInfoId",
                table: "ServicePhotos",
                column: "ServiceInfoId",
                principalTable: "ServiceInfos",
                principalColumn: "ServiceInfoID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
