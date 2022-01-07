namespace Pig_n_Go.Core.Driver.Tariffs
{
    public class BusinessTariff : TariffBase
    {
        public override decimal ChargePerLocationUnit
        {
            get => 5;
            init { }
        }
    }
}