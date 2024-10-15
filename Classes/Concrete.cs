public record Concrete(double Fck)
{
    public readonly double Ecs = 5600 * Math.Sqrt(Fck);


}