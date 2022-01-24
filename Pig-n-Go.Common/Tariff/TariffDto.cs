using System;

namespace Pig_n_Go.Common.Tariff
{
    public class TariffDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal ChargePerLocationUnit { get; set; }
    }
}
