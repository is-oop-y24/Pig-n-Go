namespace Pig_n_Go.Core.Tariffs
{
    public class EconomyTariff : BaseTariff
    {
        public override decimal ChargePerLocationUnit
        {
            get => 2;
            init { }
        }
    }
}