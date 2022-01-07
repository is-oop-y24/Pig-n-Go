namespace Pig_n_Go.Core.Tariffs
{
    public class ComfortTariff : BaseTariff
    {
        public override decimal ChargePerLocationUnit
        {
            get => 3;
            init { }
        }
    }
}