public class SteelActive(int fyk, double As1) : Steel()
{
    public override double Astot => As1;
    public override SteelType Type => SteelType.Active;

    public override int Fyk => fyk;

    public override int Es => 200000;
}