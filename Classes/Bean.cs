public record Bean(int b, int h, int yc)
{
    public readonly int Ac = b*h; 
    public readonly int Ieq = (b*h^3)/12;
    public int Yc => yc;
    public int Ytop => h/2;
    public int Ybottom => -h/2;
}