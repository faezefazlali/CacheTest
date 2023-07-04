using CacheTest.Common.DTOs.Common;
using CashTest.Controllers;
using Microsoft.AspNetCore.Mvc;


namespace UnitTest
{
    public class BookControllerTest : IClassFixture<BookController>
    {
        private readonly BookController _controller;
        public BookControllerTest(BookController controller)
        {
            _controller = controller;
        }

        [Fact]
        public void GetBookReturnsOkResult()
        {
            int id = 100;
            // Act
            var okResult = _controller.GetById(id) as OkObjectResult;

            // Assert
            Assert.IsType<BookDTO>(okResult.Value);
            Assert.Equal(id, (okResult.Value as BookDTO).Id);
        }
    }
}
