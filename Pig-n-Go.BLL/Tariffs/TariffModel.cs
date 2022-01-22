using System;

namespace Pig_n_Go.Core.Tariffs
{
    public class TariffModel
    {
        public Guid Id { get; private init; }
        public string Name { get; set; }
        public decimal ChargePerLocationUnit { get; init; }
    }
}
