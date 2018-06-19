using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanCodeL2.Models
{
    public interface IApiRequestSend<T>
    {
        IEnumerable<T> GetAllData();

        void AddEntity(T product);

        void ModifyEntity(int id, T product);

        void DeleteEntity(T product);

        IEnumerable<T> GetProductsInSection(string section);

        Product GetMostExpensiveProduct();
    }
}
