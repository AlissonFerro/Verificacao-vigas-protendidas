public class Process(Concrete concrete, SteelActive steelActive, SteelPassive steelPassive, Bean bean)
{
  Concrete Concrete => concrete;
  SteelActive SteelActive => steelActive;
  SteelPassive SteelPassive => steelPassive;
  Bean Bean => bean;
  public double AlfAs => SteelPassive.Es/Concrete.Ecs;
  public double AlfAp => SteelActive.Es/Concrete.Ecs;

  public double As1e => (AlfAs-1)*SteelPassive.As1;
  public double As2e => (AlfAs-1)*SteelPassive.As2;
  public double A0 => Bean.Ac + As1e + As2e - Bean.Gap;
  public double B0 => (Bean.b*Bean.h*Bean.yc)+(As1e*SteelActive.Ys1)+(As2e*SteelActive.Ys2)-(Bean.Gap*SteelActive.Yf);
  public double I0 => 
    Bean.Ieq + Bean.Ac * Bean.yc * Bean.Yc + As1e * SteelActive.Ys1 * SteelActive.Ys1 + As2e * SteelActive.Ys2 * SteelActive.Ys2 - Bean.Gap * SteelActive.Yf * SteelActive.Yf; 

  public void ProcessMatrix(){
      double[][] Mf0 = [[I0, B0],[B0, A0]];
      // F0 = (1/(Ec *(A0*I0-B0^2)))*MF0;

      // double F0 = 1/(Concrete.Ecs * this.A0*this.I0-this.B0*this.B0) * Mf0;
  }

};

