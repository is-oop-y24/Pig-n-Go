using System;

namespace Pig_n_Go.Driver.Tariffs
{
    public abstract class TariffBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public abstract decimal ChargePerLocationUnit { get; set; }
    }
}