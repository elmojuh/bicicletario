using BicicletarioAPI.Application;
using BicicletarioAPI.Domain;
using BicicletarioAPI.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BicicletarioAPI.Tests
{
    public class BicicletasControllerTests
    {
        [Fact]
        public void Get_ReturnsOkResult_WithBicicleta()
        {
            // Arrange
            var mockService = new Mock<BicicletaService>();
            var testBicicleta = new Bicicleta { Id = 1, Modelo = "Mountain Bike" };
            mockService.Setup(service => service.ObterBicicleta(1)).Returns(testBicicleta);
            
            var controller = new BicicletasController(mockService.Object);

            // Act
            var result = controller.Get(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Bicicleta>(okResult.Value);
            Assert.Equal(testBicicleta, returnValue);
        }
    }
}