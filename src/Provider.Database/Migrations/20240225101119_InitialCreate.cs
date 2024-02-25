using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Provider.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Height = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstId = table.Column<Guid>(type: "uuid", nullable: false),
                    SecondId = table.Column<Guid>(type: "uuid", nullable: false),
                    Distance = table.Column<double>(type: "double precision", nullable: false),
                    Surface = table.Column<string>(type: "text", nullable: false),
                    MaxSpeed = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tracks_Points_FirstId",
                        column: x => x.FirstId,
                        principalTable: "Points",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tracks_Points_SecondId",
                        column: x => x.SecondId,
                        principalTable: "Points",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AggregatesPoints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PointId = table.Column<Guid>(type: "uuid", nullable: false),
                    TrackId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AggregatesPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AggregatesPoints_Points_PointId",
                        column: x => x.PointId,
                        principalTable: "Points",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AggregatesPoints_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Points",
                columns: new[] { "Id", "Height", "Name" },
                values: new object[,]
                {
                    { new Guid("24a1084a-b81e-4285-802a-9241c8a8cd7d"), 134.0, "Point3" },
                    { new Guid("41737d8b-3ff7-4b41-aac6-70c1e6c44897"), 170.0, "Point6" },
                    { new Guid("57e1853f-48f6-413e-9d6a-4a8f323bad0f"), 124.0, "Point5" },
                    { new Guid("8dc3a5e0-67fc-4f3d-af32-101ce83f75e0"), 157.0, "Point2" },
                    { new Guid("dbf48ff1-831d-4421-b356-fb4a430809de"), 145.0, "Point1" },
                    { new Guid("f307c645-9f56-4d1a-aac0-3f2a94fe02ca"), 206.0, "Point4" }
                });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "Id", "Distance", "FirstId", "MaxSpeed", "SecondId", "Surface" },
                values: new object[,]
                {
                    { new Guid("0fd3b73e-7259-43b5-a971-2835767dbae4"), 0.0, new Guid("dbf48ff1-831d-4421-b356-fb4a430809de"), "SLOW", new Guid("dbf48ff1-831d-4421-b356-fb4a430809de"), "SAND" },
                    { new Guid("4c82ce6f-bd07-4f5d-9cdc-a8e3e44cea57"), 2314.0, new Guid("dbf48ff1-831d-4421-b356-fb4a430809de"), "SLOW", new Guid("8dc3a5e0-67fc-4f3d-af32-101ce83f75e0"), "SAND" },
                    { new Guid("b5ee126c-cc87-4a57-ae34-d2859d300452"), 3472.0, new Guid("24a1084a-b81e-4285-802a-9241c8a8cd7d"), "FAST", new Guid("f307c645-9f56-4d1a-aac0-3f2a94fe02ca"), "ASPHALT" },
                    { new Guid("cfa042c8-6ecc-43d3-bc43-b962fe23b2ff"), 4598.0, new Guid("8dc3a5e0-67fc-4f3d-af32-101ce83f75e0"), "SLOW", new Guid("24a1084a-b81e-4285-802a-9241c8a8cd7d"), "SAND" },
                    { new Guid("d46960ad-70c4-418a-b366-64954356bdc1"), 5927.0, new Guid("57e1853f-48f6-413e-9d6a-4a8f323bad0f"), "FAST", new Guid("41737d8b-3ff7-4b41-aac6-70c1e6c44897"), "ASPHALT" },
                    { new Guid("fbeb73bc-03fd-4fd6-9791-da5068791d1f"), 6672.0, new Guid("f307c645-9f56-4d1a-aac0-3f2a94fe02ca"), "NORMAL", new Guid("57e1853f-48f6-413e-9d6a-4a8f323bad0f"), "GROUND" }
                });

            migrationBuilder.InsertData(
                table: "AggregatesPoints",
                columns: new[] { "Id", "PointId", "TrackId" },
                values: new object[,]
                {
                    { new Guid("08ac37a8-86b7-46be-96bf-10099c300f36"), new Guid("8dc3a5e0-67fc-4f3d-af32-101ce83f75e0"), new Guid("4c82ce6f-bd07-4f5d-9cdc-a8e3e44cea57") },
                    { new Guid("2bab4f81-04bd-43cc-9d65-de432c51c6d4"), new Guid("57e1853f-48f6-413e-9d6a-4a8f323bad0f"), new Guid("fbeb73bc-03fd-4fd6-9791-da5068791d1f") },
                    { new Guid("824fad52-e913-4240-a1a8-fa88ba564f8f"), new Guid("dbf48ff1-831d-4421-b356-fb4a430809de"), new Guid("4c82ce6f-bd07-4f5d-9cdc-a8e3e44cea57") },
                    { new Guid("9d2fbd52-fde2-4b9b-9f0f-7f6da41f3a94"), new Guid("41737d8b-3ff7-4b41-aac6-70c1e6c44897"), new Guid("d46960ad-70c4-418a-b366-64954356bdc1") },
                    { new Guid("e23f2f69-dcfb-4601-b62e-b0ff925f4e3b"), new Guid("f307c645-9f56-4d1a-aac0-3f2a94fe02ca"), new Guid("b5ee126c-cc87-4a57-ae34-d2859d300452") },
                    { new Guid("eb1949ba-097f-4e61-8728-435713d50ca4"), new Guid("24a1084a-b81e-4285-802a-9241c8a8cd7d"), new Guid("cfa042c8-6ecc-43d3-bc43-b962fe23b2ff") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AggregatesPoints_Id",
                table: "AggregatesPoints",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AggregatesPoints_PointId",
                table: "AggregatesPoints",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_AggregatesPoints_TrackId",
                table: "AggregatesPoints",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Points_Id",
                table: "Points",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_FirstId_SecondId",
                table: "Tracks",
                columns: new[] { "FirstId", "SecondId" });

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_SecondId",
                table: "Tracks",
                column: "SecondId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AggregatesPoints");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Points");
        }
    }
}
