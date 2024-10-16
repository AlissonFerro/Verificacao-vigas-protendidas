public record Bean(int b, int h)
{
    public readonly int A = b*h; 
    public readonly int Ieq =b*h*h*h/12;
}