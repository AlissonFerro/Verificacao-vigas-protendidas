using System.Numerics;

public class Process(Concrete concrete, SteelActive steelActive, SteelPassive steelPassive, Bean bean, Force force)
{
  readonly Concrete Concrete = concrete;
  readonly SteelActive SteelActive = steelActive;
  readonly SteelPassive SteelPassive = steelPassive;
  Bean Beam => bean;
  Force Force => force;
  public readonly double AlfAs = steelPassive.Es / concrete.Eccff;
  public double AlfAp => SteelActive.Es / Concrete.Eccff;

  public double As1e => (AlfAs - 1) * SteelPassive.As1;
  public double As2e => (AlfAs - 1) * SteelPassive.As2;
  public double A0 => Beam.Ac + As1e + As2e - Beam.Gap;
  public double B0 => (Beam.b * Beam.h * Beam.yc) + (As1e * SteelActive.Ys1) + (As2e * SteelActive.Ys2) - (Beam.Gap * SteelActive.Yf);
  public double I0 =>
    Beam.Ieq + Beam.Ac * Beam.yc * Beam.Yc + As1e * SteelActive.Ys1 * SteelActive.Ys1 + As2e * SteelActive.Ys2 * SteelActive.Ys2 - Beam.Gap * SteelActive.Yf * SteelActive.Yf;

  public double K { get; set; }
  public double Epr { get; set; }
  public double Epinit { get; set; }
  public double SigmaTop { get; set; }
  public double SigmaBottom { get; set; }
  public void ProcessMatrix()
  {
    double[,] Mf0 = {
      {I0, B0},
      {B0, A0}
    };
    double scalar = 1 / (Concrete.Eccff * (A0 * I0 - Math.Pow(B0, 2)));

    double[,] Fk = MultiplyByScalar(Mf0, scalar);
    double Pi1000 = Math.PI * 1000;

    double[] Rext = [Force.Next * 1e3, Force.Mext * 1e6];
    double epinit = Pi1000 / (SteelActive.Astot * SteelActive.Es);
    double[] fpinit = [Pi1000, -1 * SteelActive.Yp];
    double[,] e0 = MultVectorByMatrix(SubVectores(Rext, fpinit), Fk);

    double epr = e0[0, 0];
    double k = e0[1, 0];

    K = k;
    Epr = epr;
    Epinit = epinit;

    double [,] e0Top = MultiplyByScalar(e0, 1 - bean.Ytop);
    double [,] e0Bottom = MultiplyByScalar(e0, 1- bean.Ybottom);

    double [,] sigTop = MultiplyByScalar(e0Top, Concrete.Ecs);
    double [,] sigBottom = MultiplyByScalar(e0Bottom, Concrete.Ecs);
    
    SigmaTop = sigTop[0,0];
    SigmaBottom = sigBottom[0,0];

    // double [] fcrk = [Beam.Ac * Concrete.Ecm0 - B0 * Beam.K0, B0 * Concrete.Ecm0 + Beam.Ieq * Beam.K0];

    // double fcr = Fc0 * Ec0 * ;

    // double ek = Fk*(Rext - fcr + fcsk - fpinit + fprelk + fcpinit);

  }

  public static double[,] MultVectorByMatrix(double[] vector, double[,] matrix)
  {
    int vectorLength = vector.Length;
    int matrixCols = matrix.GetLength(1);

    if (vectorLength != matrix.GetLength(0))
      throw new ArgumentException("O número de linhas da matriz deve ser igual ao comprimento do vetor.");    

    double[,] result = new double[vectorLength, matrixCols];

    for (int j = 0; j < matrixCols; j++)
    {
      for (int i = 0; i < vectorLength; i++)
      {
        result[i, j] = vector[i] * matrix[i, j];
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
}