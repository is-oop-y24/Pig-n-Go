﻿namespace Pig_n_Go.Core.Tariffs
{
    public class BusinessTariff : BaseTariff
    {
        public override decimal ChargePerLocationUnit
        {
            get => 5;
            init { }
        }
    }
}