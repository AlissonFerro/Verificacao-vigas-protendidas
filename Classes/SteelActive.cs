public class SteelActive(
    int fyk, 
    double As1,
    double pi, 
    double ys1, 
    double ys2, 
    double yf, 
    double yp
) : Steel()
{
    public override double Astot => As1;
    public override SteelType Type => SteelType.Active;

    public override int Fyk => fyk * 10;

    public override int Es => 200;
    public double Pi => pi;    
    public double Ys1 => ys1;
    public double Ys2 => ys2;
    public double Yf => yf;
    public double Yp => yp;
}