using System.Threading.Tasks;
using Pig_n_Go.Core.Order;

namespace Pig_n_Go.DAL.Services
{
    public interface ITaxiServiceAsync
    {
        Task HandleOrderAsync(OrderModel order);
        Task StopSearchAsync(OrderModel order);
        Task FinishOrderAsync(OrderModel order);
        Task EsteemDriverAsync(OrderModel order);
    }
}