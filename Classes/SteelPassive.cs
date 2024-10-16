
public class SteelPassive(int fyk, double As1, double As2) : Steel()
{
    public override double Astot => As1 + As2;
    public override SteelType Type => SteelType.Passive;
    public override int Fyk => fyk;
    public override int Es => 210000;

}