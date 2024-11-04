public record Force(double next, double mext){
  public double Next => next * 1e3;
  public double Mext => mext * 1e6;
}