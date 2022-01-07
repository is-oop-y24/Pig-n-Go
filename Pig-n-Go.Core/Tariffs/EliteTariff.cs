namespace Pig_n_Go.Core.Tariffs
{
    public class EliteTariff : Tariff
    {
        public override decimal ChargePerLocationUnit
        {
            get => 7;
            init { }
        }
    }
}