namespace Pig_n_Go.Core.Tariffs
{
    public class BusinessTariff : Tariff
    {
        public override decimal ChargePerLocationUnit
        {
            get => 5;
            init { }
        }
    }
}