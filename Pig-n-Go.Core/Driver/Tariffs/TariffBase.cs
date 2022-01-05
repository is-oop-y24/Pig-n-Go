using System;

namespace Pig_n_Go.Driver.Tariffs
{
    public abstract class TariffBase
    {
        public Guid Id { get; private init; } = Guid.NewGuid();
        public abstract decimal ChargePerLocationUnit { get; init; }
    }
}