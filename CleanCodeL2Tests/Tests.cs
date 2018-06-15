using System;
using Xunit;
using CleanCodeL2;
using Moq;
using CleanCodeL2.Controllers;
using CleanCodeL2.Models;
using System.Collections.Generic;

namespace CleanCodeL2Tests
{
    public class Tests
    {
        private ApiController controller;
        private Mock<IApiRequestSend<Product>> mockService;

        private Mock CreateMockService()
        {
            return mockService = new Mock<IApiRequestSend<Product>>();
        }

        private ApiController CreateController()
        {
            return controller = new ApiController(mockService.Object);
        }

        [Fact]
        public void TestsGetAllProductsCallsGetAllData()
        {
            CreateMockService();
            CreateController();

            var response = controller.GetAllProducts();

            mockService.Verify(m => m.GetAllData(), Times.Once());
        }

        [Fact]
        public void TestsGetAllDataCanReturnProducts()
        {
            CreateMockService();
            CreateController();
            List<Product> products = new List<Product>()
            {
                new Product { Id = 0, Price = 12, ProductName = "Chair", Section = "A", Weight = 91},
                new Product { Id = 1, Price = 32, ProductName = "Table", Section = "B", Weight = 57}
            };

            mockService.Setup(m => m.GetAllData()).Returns(products);

            var response = controller.GetAllProducts();

            Assert.Equal(products, response);
        }

        [Fact]
        public void TestsAddProductCallsAddEntity()
        {
            CreateMockService();
            CreateController();
            Product product = new Product() { Id = 0, ProductName = "Chair", Price = 99.9, Weight = 10, Section = "F" };

            controller.AddProduct(product);

            mockService.Verify(m => m.AddEntity(product), Times.Once());
        }

        [Fact]
        public void TestsModifyProductCallsModifyEntity()
        {
            CreateMockService();
            CreateController();
            Product product = new Product() { Id = 0, ProductName = "Chair", Price = 99.9, Weight = 10, Section = "F" };

            controller.ModifyProduct(0, product);

            mockService.Verify(m => m.ModifyEntity(0, product), Times.Once());
        }

        [Fact]
        public void TestsDeleteProductCallsDeleteEntity()
        {
            CreateMockService();
            CreateController();
            Product product = new Product() { Id = 0, ProductName = "Chair", Price = 99.9, Weight = 10, Section = "F" };

            controller.DeleteProduct(product);

            mockService.Verify(m => m.DeleteEntity(product), Times.Once());
        }
    }
}
