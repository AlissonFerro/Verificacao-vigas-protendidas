public record Beam(int b, int h, int yc, double gap, double k0, double er0)
{
    public readonly int Ac = b*h; 
    public readonly double K0 = k0; 
    public readonly double Ieq = b * MathF.Pow(h, 3)/12;
    public readonly double Er0 = er0;
    public readonly double Gap = gap;
    public readonly int Yc = yc;
    public readonly int Ytop = h/2;
    public readonly int Ybottom = -h/2;
}