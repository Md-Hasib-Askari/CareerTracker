using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareerTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedUserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreferredJobTitlesJson",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "PreferredJobTypesJson",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "PreferredLocationsJson",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "SkillsJson",
                table: "UserProfiles");

            migrationBuilder.AddColumn<List<string>>(
                name: "PreferredJobTitles",
                table: "UserProfiles",
                type: "text[]",
                nullable: false);

            migrationBuilder.AddColumn<List<string>>(
                name: "PreferredJobTypes",
                table: "UserProfiles",
                type: "text[]",
                nullable: false);

            migrationBuilder.AddColumn<List<string>>(
                name: "PreferredLocations",
                table: "UserProfiles",
                type: "text[]",
                nullable: false);

            migrationBuilder.AddColumn<List<string>>(
                name: "Skills",
                table: "UserProfiles",
                type: "text[]",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreferredJobTitles",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "PreferredJobTypes",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "PreferredLocations",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "Skills",
                table: "UserProfiles");

            migrationBuilder.AddColumn<string>(
                name: "PreferredJobTitlesJson",
                table: "UserProfiles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PreferredJobTypesJson",
                table: "UserProfiles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PreferredLocationsJson",
                table: "UserProfiles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SkillsJson",
                table: "UserProfiles",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
