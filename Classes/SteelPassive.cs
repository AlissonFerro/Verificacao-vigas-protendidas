
public class SteelPassive(int fyk, double as1, double as2) : Steel()
{
    public override double Astot => as1 + as2;
    public override SteelType Type => SteelType.Passive;
    public override int Fyk => fyk * 10;
    public override int Es => 210;
    public double As1 => as1;
    public double As2 => as2;

}