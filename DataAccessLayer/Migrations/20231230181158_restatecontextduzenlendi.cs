using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class restatecontextduzenlendi : Migration
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
                name: "FK_ServicePhotos_ServiceHousings_ServiceHousingId",
                table: "ServicePhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicePhotos_ServiceTerrains_ServiceTerrainId",
                table: "ServicePhotos");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceTerrainId",
                table: "ServicePhotos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ServiceHousingId",
                table: "ServicePhotos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
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
                name: "FK_ServicePhotos_ServiceHousings_ServiceHousingId",
                table: "ServicePhotos",
                column: "ServiceHousingId",
                principalTable: "ServiceHousings",
                principalColumn: "ServiceHousingID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicePhotos_ServiceTerrains_ServiceTerrainId",
                table: "ServicePhotos",
                column: "ServiceTerrainId",
                principalTable: "ServiceTerrains",
                principalColumn: "ServiceTerrainID",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.AlterColumn<int>(
                name: "ServiceTerrainId",
                table: "ServicePhotos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceHousingId",
                table: "ServicePhotos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
