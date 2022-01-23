using System;

namespace Pig_n_Go.Common.DTO.Tariff
{
    public class TariffDto
    {
        public Guid Id { get; private init; }
        public string Name { get; set; }
        public decimal ChargePerLocationUnit { get; init; }
    }
}
