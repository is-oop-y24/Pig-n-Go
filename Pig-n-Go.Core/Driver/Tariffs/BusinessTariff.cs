namespace Pig_n_Go.Driver.Tariffs
{
    public class BusinessTariff : TariffBase
    {
        public override decimal ChargePerLocationUnit
        { 
            get => 5;
            set { }
        }
    }
}