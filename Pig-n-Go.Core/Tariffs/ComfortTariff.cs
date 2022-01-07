namespace Pig_n_Go.Core.Tariffs
{
    public class ComfortTariff : Tariff
    {
        public override decimal ChargePerLocationUnit
        {
            get => 3;
            init { }
        }
    }
}