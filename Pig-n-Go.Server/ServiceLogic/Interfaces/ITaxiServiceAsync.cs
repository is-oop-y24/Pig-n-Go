using System.Threading.Tasks;
using Pig_n_Go.Order;

namespace Pig_n_Go
{
    public interface ITaxiServiceAsync
    {
        Task HandleOrderAsync(OrderModel order);
        Task StopSearchAsync(OrderModel order);
        Task FinishOrderAsync(OrderModel order);
        Task EsteemDriverAsync(OrderModel order);
    }
}