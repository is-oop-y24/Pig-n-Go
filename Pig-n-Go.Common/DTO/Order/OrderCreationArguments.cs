using Pig_n_Go.Core.Order;
using Pig_n_Go.Core.Tariffs;

namespace Pig_n_Go.Common.DTO.Order
{
    public class OrderCreationArguments
    {
        public Route Route { get; init; }
        public TariffModel Tariff { get; init; }
    }
}