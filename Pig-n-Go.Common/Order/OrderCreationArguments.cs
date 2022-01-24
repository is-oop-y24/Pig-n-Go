using Pig_n_Go.BLL.Order;
using Pig_n_Go.Common.Passenger;
using Pig_n_Go.Common.Tariff;

namespace Pig_n_Go.Common.Order
{
    public class OrderCreationArguments
    {
        public Route Route { get; set; }
        public PassengerDto Passenger { get; set; }
        public TariffDto Tariff { get; set; }
    }
}