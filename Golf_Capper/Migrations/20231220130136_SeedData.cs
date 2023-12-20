using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Golf_Capper.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Golfers",
                columns: new[] { "GolferId", "FirstName", "Handicap", "LastName" },
                values: new object[] { 1, "Almar", 12, "Egilsson" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Address", "City", "Zip" },
                values: new object[] { 1, "Hvaleyrarbraut", "Hafnarfjörður", 220 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "CoursePar", "LocationId", "NumberOfHoles" },
                values: new object[] { 1, "Hvaleyrarvöllur", 71, 1, 18 });

            migrationBuilder.InsertData(
                table: "CourseHolePars",
                columns: new[] { "CourseHoleParId", "CourseId", "HoleNumber", "Par" },
                values: new object[] { 1, 1, 1, 4 });

            migrationBuilder.InsertData(
                table: "GamesPlayed",
                columns: new[] { "GamePlayedId", "CourseId", "GolferId", "LoadedFromDatabase" },
                values: new object[] { 1, 1, 1, new DateTime(2023, 12, 20, 13, 1, 35, 974, DateTimeKind.Local).AddTicks(7006) });

            migrationBuilder.InsertData(
                table: "Scores",
                columns: new[] { "ScoreId", "GamePlayedId", "Hole", "Strokes" },
                values: new object[] { 1, 1, 1, 4 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CourseHolePars",
                keyColumn: "CourseHoleParId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "ScoreId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GamesPlayed",
                keyColumn: "GamePlayedId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Golfers",
                keyColumn: "GolferId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 1);
        }
    }
}
