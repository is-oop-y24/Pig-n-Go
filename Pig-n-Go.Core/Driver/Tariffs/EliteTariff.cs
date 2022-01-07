namespace Pig_n_Go.Core.Driver.Tariffs
{
    public class EliteTariff : TariffBase
    {
        public override decimal ChargePerLocationUnit
        {
            get => 7;
            init { }
        }
    }
}