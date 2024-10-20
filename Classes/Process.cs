public class Process(Concrete concrete, SteelActive steelActive, SteelPassive steelPassive, Bean bean, Force force)
{
  Concrete Concrete => concrete;
  SteelActive SteelActive => steelActive;
  SteelPassive SteelPassive => steelPassive;
  Bean Bean => bean;
  Force Force => force;
  public double AlfAs => SteelPassive.Es / Concrete.Ecs;
  public double AlfAp => SteelActive.Es / Concrete.Ecs;

  public double As1e => (AlfAs - 1) * SteelPassive.As1;
  public double As2e => (AlfAs - 1) * SteelPassive.As2;
  public double A0 => Bean.Ac + As1e + As2e - Bean.Gap;
  public double B0 => (Bean.b * Bean.h * Bean.yc) + (As1e * SteelActive.Ys1) + (As2e * SteelActive.Ys2) - (Bean.Gap * SteelActive.Yf);
  public double I0 =>
    Bean.Ieq + Bean.Ac * Bean.yc * Bean.Yc + As1e * SteelActive.Ys1 * SteelActive.Ys1 + As2e * SteelActive.Ys2 * SteelActive.Ys2 - Bean.Gap * SteelActive.Yf * SteelActive.Yf;

  public void ProcessMatrix()
  {
    double[,] Mf0 = {
      {I0, B0},
      {B0, A0}
    };

    double scalar = 1 / (Concrete.Ecs * this.A0 * this.I0 - this.B0 * this.B0);

    double[,] F0 = MultiplyByScalar(Mf0, scalar);
    double Pi1000 = Math.PI * 1000;

    double[] Rext = [Force.Next * 1e3, Force.Mext * 1e6];
    double epinit = Pi1000 / (SteelActive.Astot * SteelActive.Es);
    double[] fpinit = [Pi1000, -1 * SteelActive.Yp];
    double[,] e0 = MultVectorByMatrix(SubVectores(Rext, fpinit), F0);
    double epr = e0[1,1];
    double k = e0[2,1];
    
  }

  public static double[,] MultVectorByMatrix(double[] vector, double[,] matrix)
  {
    int length = vector.Length;
    int lengthMatrix = matrix.GetLength(0);
    double[,] result = new double[length, lengthMatrix];

    for(int i = 0; i < length; i++)
    {
      for(int j = 0; j < lengthMatrix; j++)
      {
        result[i,j] = vector[i] * matrix[i,j];
      }
    }
    return result;
  }

  private static double[] SubVectores(double[] vector1, double[] vector2)
  {
    int length = vector1.Length;
    int length2 = vector2.Length;

    if (length != length2)
      throw new ArgumentException("Os vetores devem ter o mesmo tamanho.");

    double[] result = new double[length];

    for (int i = 0; i < length; i++)
    {
      result[i] = vector1[i] - vector2[i];
    }

    return result;
  }

  private static double[,] MultiplyByScalar(double[,] matrix, double scalar)
  {
    int rows = matrix.GetLength(0);
    int cols = matrix.GetLength(1);
    double[,] result = new double[rows, cols];

    for (int i = 0; i < rows; i++)
    {
      for (int j = 0; j < cols; j++)
      {
        result[i, j] = matrix[i, j] * scalar;
      }
    }

    return result;
  }
};

