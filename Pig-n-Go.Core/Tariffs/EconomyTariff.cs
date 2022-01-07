namespace Pig_n_Go.Core.Tariffs
{
    public class EconomyTariff : Tariff
    {
        public override decimal ChargePerLocationUnit
        {
            get => 2;
            init { }
        }
    }
}