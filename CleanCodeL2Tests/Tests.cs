using System;
using Xunit;
using CleanCodeL2;
using Moq;
using CleanCodeL2.Controllers;
using CleanCodeL2.Models;
using System.Collections.Generic;
using System.Linq;

namespace CleanCodeL2Tests
{
    public class Tests
    {
        private ApiController controller;
        private Mock<IApiRequestSend<Product>> mockService;
        private FakeApiRequestSend fakeApi;

        private Mock<IApiRequestSend<Product>> CreateMockService()
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
            mockService = CreateMockService();
            controller = CreateController();
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
            mockService = CreateMockService();
            controller = CreateController();
            Product product = new Product() { Id = 0, ProductName = "Chair", Price = 99.9, Weight = 10, Section = "F" };

            controller.AddProduct(product);

            mockService.Verify(m => m.AddEntity(product), Times.Once());
        }

        [Fact]
        public void TestsAddProductCannotAddNull()
        {
            mockService = CreateMockService();
            controller = CreateController();
            Product product = null;

            Assert.Throws<Exception>(() => controller.AddProduct(product));
        }

        [Fact]
        public void TestsModifyProductCallsModifyEntity()
        {
            mockService = CreateMockService();
            controller = CreateController();
            Product product = new Product() { Id = 0, ProductName = "Chair", Price = 99.9, Weight = 10, Section = "F" };

            controller.ModifyProduct(0, product);

            mockService.Verify(m => m.ModifyEntity(0, product), Times.Once());
        }

        [Fact]
        public void TestsModifyProductCannotMakeProductNull()
        {
            mockService = CreateMockService();
            controller = CreateController();
            Product product = null;

            Assert.Throws<Exception>(() => controller.ModifyProduct(0, product));
        }

        [Fact]
        public void TestsDeleteProductCallsDeleteEntity()
        {
            mockService = CreateMockService();
            controller = CreateController();
            Product product = new Product() { Id = 0, ProductName = "Chair", Price = 99.9, Weight = 10, Section = "F" };

            controller.DeleteProduct(product);

            mockService.Verify(m => m.DeleteEntity(product), Times.Once());
        }

        [Fact]
        public void TestsDeleteProductCannotDeleteNull()
        {
            mockService = CreateMockService();
            controller = CreateController();
            Product product = null;

            Assert.Throws<Exception>(() => controller.DeleteProduct(product));
        }

        [Fact]
        public void TestsGetProductsInSectionCallsGetProductsInSection()
        {
            mockService = CreateMockService();
            controller = CreateController();

            controller.GetProductsInSection("A");

            mockService.Verify(m => m.GetProductsInSection("A"), Times.Once());
        }

        [Fact]
        public void TestsGetProductsInSectionWithRealSection()
        {
            fakeApi = new FakeApiRequestSend();
            var controller = new ApiController(fakeApi);
            List<Product> expectedProducts = new List<Product>()
            {
                new Product { Id = 1, Price = 32, ProductName = "Table", Section = "B", Weight = 57},
                new Product { Id = 2, Price = 40, ProductName = "Lamp", Section = "B", Weight = 5}
            };

            List<Product> actualProducts = controller.GetProductsInSection("B").ToList();

            Assert.Equal(expectedProducts, actualProducts);
        }

        [Fact]
        public void TestsGetProductsInSectionWithEmptySection()
        {
            fakeApi = new FakeApiRequestSend();
            var controller = new ApiController(fakeApi);

            Assert.Throws<Exception>(() => controller.GetProductsInSection(""));
        }

        [Fact]
        public void TestsGetMostExpensiveProduct()
        {
            fakeApi = new FakeApiRequestSend();
            var controller = new ApiController(fakeApi);
            var expectedProduct = new Product { Id = 2, Price = 40, ProductName = "Lamp", Section = "B", Weight = 5 };

            var actualProduct = controller.GetMostExpensiveProduct();

            Assert.Equal(expectedProduct, actualProduct);
        }

        [Fact]
        public void TestsGetMostExpensiveProductCallsGetMostExpensiveProduct()
        {
            mockService = CreateMockService();
            controller = CreateController();

            controller.GetMostExpensiveProduct();

            mockService.Verify(m => m.GetMostExpensiveProduct(), Times.Once());
        }
    }
}
