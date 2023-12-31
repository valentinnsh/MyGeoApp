﻿using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSchools : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "schools",
                schema: "geo_data",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "text", nullable: false),
                    location = table.Column<Point>(type: "geometry", nullable: false),
                    addresscomment = table.Column<string>(name: "address_comment", type: "text", nullable: true),
                    mailindex = table.Column<string>(name: "mail_index", type: "text", nullable: true),
                    district = table.Column<string>(type: "text", nullable: true),
                    cityid = table.Column<long>(name: "city_id", type: "bigint", nullable: false),
                    okrug = table.Column<string>(type: "text", nullable: true),
                    region = table.Column<string>(type: "text", nullable: true),
                    country = table.Column<string>(type: "text", nullable: true),
                    workinghours = table.Column<string>(name: "working_hours", type: "text", nullable: true),
                    timezone = table.Column<string>(type: "text", nullable: true),
                    rating = table.Column<double>(type: "double precision", nullable: true),
                    twogisurl = table.Column<string>(name: "two_gis_url", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schools", x => x.id);
                    table.ForeignKey(
                        name: "FK_schools_cities_city_id",
                        column: x => x.cityid,
                        principalSchema: "geo_data",
                        principalTable: "cities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_schools_city_id",
                schema: "geo_data",
                table: "schools",
                column: "city_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "schools",
                schema: "geo_data");
        }
    }
}
