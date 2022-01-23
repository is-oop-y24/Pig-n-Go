namespace Pig_n_Go.BLL.Driver
{
    public class CartesianLocationUnit
    {
        public decimal Abscissa { get; init; }
        public decimal Ordinate { get; init; }

        public override string ToString() => $"Cartesian({Abscissa}, {Ordinate})";
    }
}