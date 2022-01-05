namespace Pig_n_Go.Driver.Tariffs
{
    public class ComfortTariff : TariffBase
    {
        public override decimal ChargePerLocationUnit
        { 
            get => 3;
        }
    }
}