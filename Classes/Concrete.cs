public record Concrete(int Fck)
{
    public readonly double Ecs = Math.Round(5600 * Math.Sqrt(Fck), 2);
    public readonly double Ecm0 = Math.Round(22 * Math.Sqrt(Fck), 2);
    public readonly double phitkt0 = 2.5;
    public double Eccff => Ecs / ( 1 + 0.65 * phitkt0);
}   