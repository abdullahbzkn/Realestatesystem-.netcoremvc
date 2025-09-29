using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class photosınıfıayrıldı : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicePhotos");

            migrationBuilder.CreateTable(
                name: "ServiceHousingPhotos",
                columns: table => new
                {
                    ServiceHousingPhotoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FotografYolu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceHousingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceHousingPhotos", x => x.ServiceHousingPhotoID);
                    table.ForeignKey(
                        name: "FK_ServiceHousingPhotos_ServiceHousings_ServiceHousingId",
                        column: x => x.ServiceHousingId,
                        principalTable: "ServiceHousings",
                        principalColumn: "ServiceHousingID");
                });

            migrationBuilder.CreateTable(
                name: "ServiceTerrainPhotos",
                columns: table => new
                {
                    ServiceTerrainPhotoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FotografYolu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceTerrainId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTerrainPhotos", x => x.ServiceTerrainPhotoID);
                    table.ForeignKey(
                        name: "FK_ServiceTerrainPhotos_ServiceTerrains_ServiceTerrainId",
                        column: x => x.ServiceTerrainId,
                        principalTable: "ServiceTerrains",
                        principalColumn: "ServiceTerrainID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHousingPhotos_ServiceHousingId",
                table: "ServiceHousingPhotos",
                column: "ServiceHousingId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTerrainPhotos_ServiceTerrainId",
                table: "ServiceTerrainPhotos",
                column: "ServiceTerrainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceHousingPhotos");

            migrationBuilder.DropTable(
                name: "ServiceTerrainPhotos");

            migrationBuilder.CreateTable(
                name: "ServicePhotos",
                columns: table => new
                {
                    ServicePhotoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceHousingId = table.Column<int>(type: "int", nullable: true),
                    ServiceTerrainId = table.Column<int>(type: "int", nullable: true),
                    FotografYolu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePhotos", x => x.ServicePhotoID);
                    table.ForeignKey(
                        name: "FK_ServicePhotos_ServiceHousings_ServiceHousingId",
                        column: x => x.ServiceHousingId,
                        principalTable: "ServiceHousings",
                        principalColumn: "ServiceHousingID");
                    table.ForeignKey(
                        name: "FK_ServicePhotos_ServiceTerrains_ServiceTerrainId",
                        column: x => x.ServiceTerrainId,
                        principalTable: "ServiceTerrains",
                        principalColumn: "ServiceTerrainID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServicePhotos_ServiceHousingId",
                table: "ServicePhotos",
                column: "ServiceHousingId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePhotos_ServiceTerrainId",
                table: "ServicePhotos",
                column: "ServiceTerrainId");
        }
    }
}
