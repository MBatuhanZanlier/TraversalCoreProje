using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class feature2_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Post3ImageUrl",
                table: "Features2",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Post2Name",
                table: "Features2",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "Post2Description",
                table: "Features2",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "FeatureId",
                table: "Features2",
                newName: "Feature2Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Features2",
                newName: "Post3ImageUrl");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Features2",
                newName: "Post2Name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Features2",
                newName: "Post2Description");

            migrationBuilder.RenameColumn(
                name: "Feature2Id",
                table: "Features2",
                newName: "FeatureId");
        }
    }
}
