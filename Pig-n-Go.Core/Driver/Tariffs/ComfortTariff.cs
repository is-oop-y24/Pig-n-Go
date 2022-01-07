namespace Pig_n_Go.Core.Driver.Tariffs
{
    public class ComfortTariff : TariffBase
    {
        public override decimal ChargePerLocationUnit
        {
            get => 3;
            init { }
        }
    }
}