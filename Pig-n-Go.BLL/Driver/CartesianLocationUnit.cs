namespace Pig_n_Go.Core.Driver
{
    public class CartesianLocationUnit
    {
        public decimal Abscissa { get; init; }
        public decimal Ordinate { get; init; }

        public override string ToString() => $"Cartesian({Abscissa}, {Ordinate})";
    }
}