using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMovies.Migrations
{
    /// <inheritdoc />
    public partial class Movies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CharacterName",
                table: "MovieActors");

            migrationBuilder.AddColumn<int>(
                name: "MovieGenreGenreId",
                table: "MovieGenres",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieGenreMovieId",
                table: "MovieGenres",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_MovieGenreMovieId_MovieGenreGenreId",
                table: "MovieGenres",
                columns: new[] { "MovieGenreMovieId", "MovieGenreGenreId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenres_MovieGenres_MovieGenreMovieId_MovieGenreGenreId",
                table: "MovieGenres",
                columns: new[] { "MovieGenreMovieId", "MovieGenreGenreId" },
                principalTable: "MovieGenres",
                principalColumns: new[] { "MovieId", "GenreId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenres_MovieGenres_MovieGenreMovieId_MovieGenreGenreId",
                table: "MovieGenres");

            migrationBuilder.DropIndex(
                name: "IX_MovieGenres_MovieGenreMovieId_MovieGenreGenreId",
                table: "MovieGenres");

            migrationBuilder.DropColumn(
                name: "MovieGenreGenreId",
                table: "MovieGenres");

            migrationBuilder.DropColumn(
                name: "MovieGenreMovieId",
                table: "MovieGenres");

            migrationBuilder.AddColumn<string>(
                name: "CharacterName",
                table: "MovieActors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
