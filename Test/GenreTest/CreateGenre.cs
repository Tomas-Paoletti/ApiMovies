using System.Threading.Tasks;
using ApiMovies.Application.Interfaces;
using ApiMovies.Infraestructure.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Test.GenreTest
{
    [TestClass]
    public class CreateGenre
    {
        private IGenreService _genreService;

        [TestInitialize]
        public void Setup()
        {
            var mockGenreService = new Mock<IGenreService>();
            mockGenreService.Setup(service => service.CreateGenreAsync(It.IsAny<Genre>()))
                            .ReturnsAsync((Genre genre) => genre);
            _genreService = mockGenreService.Object;
        }

        [TestMethod]
        public async Task CreateGenreAsync()
        {
            // Arrange
            Genre genre = new Genre
            {
                Name = "Action"
            };

            // Act
            var result = await _genreService.CreateGenreAsync(genre);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(genre.Name, result.Name);
        }

        [TestMethod]
        public async Task CreateGenreAsync_WithNullGenre()
        {
            // Arrange
            Genre genre = null;

            // Act
            var result = await _genreService.CreateGenreAsync(genre);

            // Assert
            Assert.IsNull(result);
        }
       
      
    }
}
