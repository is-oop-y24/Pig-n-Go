using Pig_n_Go.Common.Passenger;
using Pig_n_Go.Common.Tariff;
using Pig_n_Go.Core.Order;

namespace Pig_n_Go.Common.Order
{
    public class OrderCreationArguments
    {
        public Route Route { get; init; }
        public PassengerDto Passenger { get; set; }
        public TariffCreationArguments Tariff { get; init; }
    }
}