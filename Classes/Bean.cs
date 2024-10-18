public record Bean(int b, int h, int yc, double gap)
{
    public readonly int Ac = b*h; 
    public readonly int Ieq = (b*h^3)/12;
    public double Gap => gap;
    public int Yc => yc;
    public int Ytop => h/2;
    public int Ybottom => -h/2;
}