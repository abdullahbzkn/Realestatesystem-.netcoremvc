using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig_createdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutUses",
                columns: table => new
                {
                    HakkimizdaMetni = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AdressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aciklama1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HaritaLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AdressID);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mesaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactID);
                });

            migrationBuilder.CreateTable(
                name: "ContactsUses",
                columns: table => new
                {
                    IletisimMetni = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Entrances",
                columns: table => new
                {
                    Aciklama1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama3 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Galleries",
                columns: table => new
                {
                    IlanlarMetni = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ServiceInfos",
                columns: table => new
                {
                    ServiceInfoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IlanNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceInfos", x => x.ServiceInfoID);
                });

            migrationBuilder.CreateTable(
                name: "ServiceMaps",
                columns: table => new
                {
                    ServiceMapID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mahalle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Koy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ilce = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Il = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceMaps", x => x.ServiceMapID);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KisiAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FotografYolu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamID);
                });

            migrationBuilder.CreateTable(
                name: "WhatWeDos",
                columns: table => new
                {
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KBaslik1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Metin1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KBaslik2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Metin2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KBaslik3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Metin3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KBaslik4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Metin4 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ServicePhotos",
                columns: table => new
                {
                    ServicePhotoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FotografYolu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePhotos", x => x.ServicePhotoID);
                    table.ForeignKey(
                        name: "FK_ServicePhotos_ServiceInfos_ServiceInfoId",
                        column: x => x.ServiceInfoId,
                        principalTable: "ServiceInfos",
                        principalColumn: "ServiceInfoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceHousings",
                columns: table => new
                {
                    ServiceHousingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gorsel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fiyat = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    TapuDurumu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YapininDurumu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Isitma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BinaKatSayisi = table.Column<int>(type: "int", nullable: false),
                    YapininCephesi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YapininSekli = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TuvaletSayisi = table.Column<int>(type: "int", nullable: false),
                    BalkonSayisi = table.Column<int>(type: "int", nullable: false),
                    BanyoSayisi = table.Column<int>(type: "int", nullable: false),
                    SalonSayisi = table.Column<int>(type: "int", nullable: false),
                    OdaSayisi = table.Column<int>(type: "int", nullable: false),
                    KiraGetirisi = table.Column<int>(type: "int", nullable: false),
                    TakasYapilir = table.Column<bool>(type: "bit", nullable: false),
                    KullanimDurumu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YakitTipi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BulunduguKat = table.Column<int>(type: "int", nullable: false),
                    Aidat = table.Column<int>(type: "int", nullable: false),
                    KrediyeUygun = table.Column<bool>(type: "bit", nullable: false),
                    Devren = table.Column<bool>(type: "bit", nullable: false),
                    UzunAciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KonumLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceMapId = table.Column<int>(type: "int", nullable: false),
                    ServiceInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceHousings", x => x.ServiceHousingID);
                    table.ForeignKey(
                        name: "FK_ServiceHousings_ServiceInfos_ServiceInfoId",
                        column: x => x.ServiceInfoId,
                        principalTable: "ServiceInfos",
                        principalColumn: "ServiceInfoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceHousings_ServiceMaps_ServiceMapId",
                        column: x => x.ServiceMapId,
                        principalTable: "ServiceMaps",
                        principalColumn: "ServiceMapID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTerrains",
                columns: table => new
                {
                    ServiceTerrainID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gorsel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fiyat = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    TapuDurumu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KatKarsiligi = table.Column<bool>(type: "bit", nullable: false),
                    KrediyeUygun = table.Column<bool>(type: "bit", nullable: false),
                    TapuParsel = table.Column<int>(type: "int", nullable: false),
                    TapuPafta = table.Column<int>(type: "int", nullable: false),
                    TapuAda = table.Column<int>(type: "int", nullable: false),
                    VadeVarmi = table.Column<int>(type: "int", nullable: false),
                    IzinVerilenKatAdedi = table.Column<int>(type: "int", nullable: false),
                    BelediyeAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TakasYapilir = table.Column<bool>(type: "bit", nullable: false),
                    IskanDurumu = table.Column<bool>(type: "bit", nullable: false),
                    TabanInsaaAlani = table.Column<int>(type: "int", nullable: false),
                    ToplamInsaatAlani = table.Column<int>(type: "int", nullable: false),
                    MaksimumBinaYuksekligi = table.Column<int>(type: "int", nullable: false),
                    UzunAciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KonumLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceMapId = table.Column<int>(type: "int", nullable: false),
                    ServiceInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTerrains", x => x.ServiceTerrainID);
                    table.ForeignKey(
                        name: "FK_ServiceTerrains_ServiceInfos_ServiceInfoId",
                        column: x => x.ServiceInfoId,
                        principalTable: "ServiceInfos",
                        principalColumn: "ServiceInfoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceTerrains_ServiceMaps_ServiceMapId",
                        column: x => x.ServiceMapId,
                        principalTable: "ServiceMaps",
                        principalColumn: "ServiceMapID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHousings_ServiceInfoId",
                table: "ServiceHousings",
                column: "ServiceInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHousings_ServiceMapId",
                table: "ServiceHousings",
                column: "ServiceMapId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePhotos_ServiceInfoId",
                table: "ServicePhotos",
                column: "ServiceInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTerrains_ServiceInfoId",
                table: "ServiceTerrains",
                column: "ServiceInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTerrains_ServiceMapId",
                table: "ServiceTerrains",
                column: "ServiceMapId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutUses");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "ContactsUses");

            migrationBuilder.DropTable(
                name: "Entrances");

            migrationBuilder.DropTable(
                name: "Galleries");

            migrationBuilder.DropTable(
                name: "ServiceHousings");

            migrationBuilder.DropTable(
                name: "ServicePhotos");

            migrationBuilder.DropTable(
                name: "ServiceTerrains");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "WhatWeDos");

            migrationBuilder.DropTable(
                name: "ServiceInfos");

            migrationBuilder.DropTable(
                name: "ServiceMaps");
        }
    }
}
