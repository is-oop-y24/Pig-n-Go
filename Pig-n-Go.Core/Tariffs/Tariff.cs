using System;

namespace Pig_n_Go.Core.Tariffs
{
    public abstract class Tariff
    {
        public Guid Id { get; private init; }
        public abstract decimal ChargePerLocationUnit { get; init; }
    }
}
