namespace Pig_n_Go.BLL.Driver
{
    public class CartesianLocationUnit
    {
        public decimal Abscissa { get; set; }
        public decimal Ordinate { get; set; }

        public override string ToString() => $"Cartesian({Abscissa}, {Ordinate})";
    }
}