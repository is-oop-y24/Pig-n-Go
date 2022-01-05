namespace Pig_n_Go.Driver.Tariffs
{
    public class EconomyTariff : TariffBase
    {
        public override decimal ChargePerLocationUnit
        {
            get => 2;
            init { }
        }
    }
}