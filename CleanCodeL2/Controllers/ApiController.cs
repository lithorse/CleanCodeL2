using CleanCodeL2.Models;
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
            _requests.AddEntity(product);
        }

        [HttpPost]
        [Route("ModifyProduct")]
        public void ModifyProduct(int id, Product product)
        {
            _requests.ModifyEntity(id, product);
        }

        [HttpPost]
        [Route("DeleteProduct")]
        public void DeleteProduct(Product product)
        {
            _requests.DeleteEntity(product);
        }
    }
}
