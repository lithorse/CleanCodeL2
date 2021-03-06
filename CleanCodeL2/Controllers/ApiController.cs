﻿using CleanCodeL2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanCodeL2.Controllers
{
    [Produces("application/json")]
    [Route("Api")]
    public class ApiController : Controller
    {
        private IApiRequestSend<Product> _requests;

        public ApiController(IApiRequestSend<Product> requests)
        {
            _requests = requests;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public IEnumerable<Product> GetAllProducts()
        {
            return _requests.GetAllData();
        }

        [HttpPost]
        [Route("AddProduct")]
        public void AddProduct( Product product)
        {
            if (product == null)
            {
                throw new Exception("product cannot be null");
            }
            _requests.AddEntity(product);
        }

        [HttpPost]
        [Route("ModifyProduct")]
        public void ModifyProduct(int id, Product product)
        {
            if (product == null)
            {
                throw new Exception("product cannot be null");
            }
            _requests.ModifyEntity(id, product);
        }

        [HttpPost]
        [Route("DeleteProduct")]
        public void DeleteProduct(Product product)
        {
            if (product == null)
            {
                throw new Exception("product cannot be null");
            }
            _requests.DeleteEntity(product);
        }

        [HttpGet]
        [Route("GetProductsInSection")]
        public IEnumerable<Product> GetProductsInSection(String section)
        {
            if (section == "")
            {
                throw new Exception("section cannot be empty");
            }
            return _requests.GetProductsInSection(section);
        }

        [HttpGet]
        [Route("GetMostExpensiveProduct")]
        public Product GetMostExpensiveProduct()
        {
            return _requests.GetMostExpensiveProduct();
        }
    }
}
