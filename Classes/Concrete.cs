public record Concrete(int Fck)
{
    public readonly double Ecs = Math.Round(5600 * Math.Sqrt(Fck), 2);

}   