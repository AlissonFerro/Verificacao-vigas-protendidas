public record Bean(int b, int h, int yc, double gap)
{
    public readonly int Ac = b*h; 
    public readonly float Ieq = b * MathF.Pow(h, 3)/12;
    public readonly double Gap = gap;
    public readonly int Yc = yc;
    public readonly int Ytop = h/2;
    public readonly int Ybottom = -h/2;
}