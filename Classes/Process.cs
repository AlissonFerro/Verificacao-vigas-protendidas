public class Process(Concrete concrete, SteelActive steelActive, SteelPassive steelPassive, Beam beam, Force force)
{
  readonly Concrete Concrete = concrete;
  readonly SteelActive SteelActive = steelActive;
  readonly SteelPassive SteelPassive = steelPassive;
  Beam Beam => beam;
  Force Force => force;
  public readonly double AlfEs = steelPassive.Es / (concrete.Eccff / 1000);
  public double AlfEp => SteelActive.Es / (Concrete.Eccff / 1000);

  public double As1e => (AlfEs - 1) * SteelPassive.As1;
  public double As2e => (AlfEs - 1) * SteelPassive.As2;
  public double Ak => Beam.Ac + As1e + As2e - Beam.Gap;
  public double Bk => (Beam.Ac * Beam.yc) + (As1e * SteelActive.Ys2) + (As2e * SteelActive.Ys2) - (Beam.Gap * SteelActive.Yf);
  public double Ik =>
    Beam.Ieq + (Beam.Ac * Math.Pow(Beam.yc, 2)) + (As1e * Math.Pow(SteelActive.Ys1, 2)) + (As2e * Math.Pow(SteelActive.Ys2, 2)) - Beam.Gap * Math.Pow(SteelActive.Yf, 2);

  public double K { get; set; }
  public double Epr { get; set; }
  public double Epinit { get; set; }
  public double SigmaTop { get; set; }
  public double SigmaBottom { get; set; }
  public void Execute()
  {
    MessageBox.Show(Ak.ToString("E2"), "AK");
    MessageBox.Show(Bk.ToString("E2"), "BK");
    MessageBox.Show(Ik.ToString("E2"), "IK");

    double[,] Mfk = {
      {Ik, Bk},
      {Bk, Ak}
    };
    double FkScalar = 1 / (Concrete.Eccff * (Ak * Ik - Math.Pow(Bk, 2)));

    double[,] Fk = MultiplyByScalar(Mfk, FkScalar);
    double[] Rext = [Force.Next, Force.Mext];

    // Efeito da fluência
    double Ac = Beam.Ac - SteelPassive.Astot - SteelActive.Astot;
    double Bc = Beam.Ac*Beam.Yc - SteelPassive.As1*SteelActive.Ys1 - SteelActive.Astot * SteelActive.Ys1;
    double Ic = Beam.Ieq - SteelPassive.As1 * SteelActive.Ys1 - SteelActive.Astot*Math.Pow(SteelActive.Yp, 2);
    double [] fcrk = [Ac * Concrete.Ecm0 - Bc * Beam.K0, Bc * Concrete.Ecm0 + Ic * Beam.K0];
    double Fc0 = Concrete.phitkt0 * (0.65-1) / (1+0.65*Concrete.phitkt0);

    double FcrkcScalar = Fc0 * Concrete.Ecs;
    double[] Fcrkc = MultiplyVectorByScalar(fcrk, FcrkcScalar);

    double fcskScalar = Concrete.Eccff * Concrete.Ecs;
    double[] fcskVector = [Ac, -Bc];

    double[] fcsk = MultiplyVectorByScalar(fcskVector, fcskScalar);

    double[] Fpinit = [SteelActive.Pi, -SteelActive.Yp * SteelActive.Pi];

    double[] Fprel = [SteelActive.Pi * 0.0459, -SteelActive.Yp * SteelActive.Pi];

    double[] fcp = [0,0];
    double[] ekVector = SomaVectores(SomaVectores(SubVectores(SomaVectores(SubVectores(Rext, Fcrkc), fcsk), Fpinit), Fprel),fcp);
    double[,] Ek = MultVectorByMatrix(ekVector, Fk);

    double[] E0 = [Beam.Er0, Beam.K0];

    double defEkTop = Ek[0,0] - Beam.Ytop * Ek[1,1];
    double defEkBottom = Ek[0,0] - Beam.Ybottom * Ek[1,1];
    
    double SigmaBottom0 = -9.55;
    double SigmaTop0 = -0.822;

    double epsonEcs = -600 * 1e-6;

    SigmaTop = Concrete.Eccff * (defEkTop - epsonEcs) + Fc0 * SigmaTop0;
    SigmaBottom = Concrete.Eccff * (defEkBottom - epsonEcs) + Fc0 * SigmaBottom0;

    // double EkTop = Erk

    // double SigmaTop = Concrete.Eccff;

    // double epinit = Pi1000 / (SteelActive.Astot * SteelActive.Es);
    // double[] fpinit = [Pi1000, -1 * SteelActive.Yp];
    // double[,] e0 = MultVectorByMatrix(SubVectores(Rext, fpinit), Fk);

    // double epr = e0[0, 0];
    // double k = e0[1, 0];

    // K = k;
    // Epr = epr;
    // Epinit = epinit;

    // double [,] e0Top = MultiplyByScalar(e0, 1 - beam.Ytop);
    // double [,] e0Bottom = MultiplyByScalar(e0, 1- beam.Ybottom);

    // double [,] sigTop = MultiplyByScalar(e0Top, Concrete.Ecs);
    // double [,] sigBottom = MultiplyByScalar(e0Bottom, Concrete.Ecs);
    
    // SigmaTop = sigTop[0,0];
    // SigmaBottom = sigBottom[0,0];

    // double fcr = Fc0 * Ec0 * ;

    // double ek = Fk*(Rext - fcr + fcsk - fpinit + fprelk + fcpinit);

  }
  

  public static double[] MultiplyVectorByScalar(double[] vector, double scalar)
  {
    int length = vector.Length;
    double[] result = new double[length];

    for(int i = 0; i < length; i++)
    {
      result[i] = scalar * vector[i];
    }
    return result;
  }

  public static double[,] MultVectorByMatrix(double[] vector, double[,] matrix)
  {
    int vectorLength = vector.Length;
    int matrixCols = matrix.GetLength(0);

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

  private static double[] SomaVectores(double[] vector1, double[] vector2)
  {
    int length = vector1.Length;
    int length2 = vector2.Length;

    if(length != length2)
      throw new ArgumentException("Os vetores devem ter o mesmo tamanho");

    double[] result = new double[length];

    for (int i = 0; i < length; i++)
    {
      result[i] = vector1[i] + vector2[i];
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