using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Pig_n_Go.BLL.Driver;
using Pig_n_Go.Common.Driver;
using Pig_n_Go.Common.Order;
using Pig_n_Go.Common.Tariff;

namespace DriverClient.Tools
{
    public class DriverRequestService : IDriverRequestService
    {
        public async Task<DriverDto> Register(DriverInfo driverInfo)
        {
            var creationArgs = new DriverCreationArguments
            {
                DriverInfo = driverInfo
            };

            HttpResponseMessage response;
            using (var httpClient = new HttpClient())
            {
                response = await httpClient.PostAsJsonAsync("http://localhost:5001/drivers/add", creationArgs);   
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception("Http request error.");

            return await response.Content.ReadFromJsonAsync<DriverDto>();
        }

        public async Task<DriverDto> Login(Guid driverId)
        {
            HttpResponseMessage response;
            using (var httpClient = new HttpClient())
            {
                response =
                    await httpClient.GetAsync($"https://localhost:5001/drivers/get?driverId={driverId}");
            }
            
            if (!response.IsSuccessStatusCode)
                throw new Exception("Http request error.");

            return await response.Content.ReadFromJsonAsync<DriverDto>();
        }

        public async Task<OrderDto> AcceptOrder(Guid driverId, Guid orderId)
        {
            HttpResponseMessage response;
            using (var httpClient = new HttpClient())
            {
                response =
                    await httpClient.GetAsync($"https://localhost:5001/drivers/accept/order?driverId={driverId}&orderId={orderId}");
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception("Http request error.");

            return await response.Content.ReadFromJsonAsync<OrderDto>();
        }

        public async Task FinishOrder(Guid orderId)
        {
            HttpResponseMessage response;
            using (var httpClient = new HttpClient())
            {
                response =
                    await httpClient.GetAsync($"https://localhost:5001/orders/finish?orderId={orderId}");
            }
            
            if (!response.IsSuccessStatusCode)
                throw new Exception("Http request error.");
        }

        public async Task<TariffDto[]> GetTariffs()
        {
            HttpResponseMessage response;
            using (var httpClient = new HttpClient())
            {
                response =
                    await httpClient.GetAsync($"https://localhost:5001/tariffs/all");
            }
            
            if (!response.IsSuccessStatusCode)
                throw new Exception("Http request error.");

            Console.WriteLine(await response.Content.ReadAsStringAsync());
            
            return await response.Content.ReadFromJsonAsync<TariffDto[]>();
        }

        public async Task GoOnline(Guid driverId, Guid tariffId)
        {
            HttpResponseMessage response;
            Console.WriteLine(driverId);
            Console.WriteLine(tariffId);
            using (var httpClient = new HttpClient())
            {
                response =
                    await httpClient.GetAsync($"https://localhost:5001/drivers/go-online?driverId={driverId}&tariffId={tariffId}");
            }
            
            if (!response.IsSuccessStatusCode)
                throw new Exception("Http request error.");
        }
    }
}