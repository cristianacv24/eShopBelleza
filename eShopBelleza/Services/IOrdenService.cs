using eShopBelleza.Models;
using System.Threading.Tasks;

namespace eShopBelleza.Services
{
    public interface IOrdenService
    {
        Task SaveOrden(Orden orden);
    }
}
