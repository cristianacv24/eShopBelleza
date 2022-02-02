using eShopBelleza.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace eShopBelleza.Services
{
    public interface IProductService
    {
        Task<ObservableCollection<Product>> GetProducts();

        Task UpdateProductStockBy(int id, int stock);
    }
}
