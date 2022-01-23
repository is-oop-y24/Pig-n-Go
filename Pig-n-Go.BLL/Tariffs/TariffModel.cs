using System;

namespace Pig_n_Go.BLL.Tariffs
{
    public class TariffModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal ChargePerLocationUnit { get; init; }
    }
}
