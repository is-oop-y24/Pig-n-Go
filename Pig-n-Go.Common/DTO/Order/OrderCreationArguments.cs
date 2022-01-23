using Pig_n_Go.Common.DTO.Tariff;
using Pig_n_Go.Core.Order;

namespace Pig_n_Go.Common.DTO.Order
{
    public class OrderCreationArguments
    {
        public Route Route { get; init; }
        public TariffCreationArguments Tariff { get; init; }
    }
}