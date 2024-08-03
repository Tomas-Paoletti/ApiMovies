using ApiMovies.Api.Controllers;
using ApiMovies.Application.Interfaces;
using ApiMovies.Infraestructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.GenreTest
{
    [TestClass]
    public class UpdateGenreTest
    {
        private Mock<IGenreService> _mockGenreService;
        private GenreController _genreController;

        [TestInitialize]
        public void Setup()
        {
            _mockGenreService = new Mock<IGenreService>();
            _genreController = new GenreController(_mockGenreService.Object);
        }

        [TestMethod]
        public async Task UpdateGenreAsync()
        {
            // Arrange
            Genre genre = new Genre
            {
                GenreId = 1,
                Name = "Action"
            };

            _mockGenreService.Setup(service => service.UpdateGenreAsync(It.IsAny<Genre>()))
                             .ReturnsAsync((Genre g) => g);

            // Act
            var result = await _genreController.UpdateGenre(genre) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            var updatedGenre = result.Value as Genre;
            Assert.IsNotNull(updatedGenre);
            Assert.AreEqual(genre.Name, updatedGenre.Name);
        }


        [TestMethod]
        public async Task UpdateGenreAsync_WithNullGenre()
        {
            // Arrange
            Genre genre = null;

            // Act
            var result = await _genreController.UpdateGenre(genre) as BadRequestResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
        }



       
    }
}
