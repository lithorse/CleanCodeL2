using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanCodeL2.Models
{
    public class ApiRequestSend : IApiRequestSend<Product>
    {
        public void AddEntity(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(Product product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllData()
        {
            throw new NotImplementedException();
        }

        public void ModifyEntity(int id, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
