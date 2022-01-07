using System;

namespace Pig_n_Go.Core.Tariffs
{
    public abstract class BaseTariff
    {
        public Guid Id { get; private init; } = Guid.NewGuid();
        public abstract decimal ChargePerLocationUnit { get; init; }
    }
}