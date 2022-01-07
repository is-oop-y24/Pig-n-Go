using System;
using System.Threading.Tasks;

namespace Pig_n_Go.BLL.Services
{
    public interface ITaxiServiceAsync
    {
        Task HandleOrderAsync(Guid orderId);
        Task StopSearchAsync(Guid orderId);
        Task FinishOrderAsync(Guid orderId);
        Task EsteemDriverAsync(Guid orderId);
    }
}