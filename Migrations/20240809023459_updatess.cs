using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataServe.Migrations
{
    /// <inheritdoc />
    public partial class updatess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_TravelPackages_TravelPackagesPackageId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_TravelPackagesPackageId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "TravelPackages");

            migrationBuilder.DropColumn(
                name: "TravelPackagesPackageId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "TravelPackages",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "PackageId",
                table: "TravelPackages",
                newName: "Id");

            migrationBuilder.AddColumn<bool>(
                name: "FreeCancellation",
                table: "TravelPackages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReserveNow",
                table: "TravelPackages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FreeCancellation",
                table: "TravelPackages");

            migrationBuilder.DropColumn(
                name: "ReserveNow",
                table: "TravelPackages");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "TravelPackages",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TravelPackages",
                newName: "PackageId");

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "TravelPackages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TravelPackagesPackageId",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_TravelPackagesPackageId",
                table: "Reviews",
                column: "TravelPackagesPackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_TravelPackages_TravelPackagesPackageId",
                table: "Reviews",
                column: "TravelPackagesPackageId",
                principalTable: "TravelPackages",
                principalColumn: "PackageId");
        }
    }
}
