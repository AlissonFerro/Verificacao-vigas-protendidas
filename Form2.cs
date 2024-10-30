namespace Verificacao;

public class Form2 : Form
{
    public Concrete concrete;
    public SteelPassive steelPassive;
    public SteelActive steelActive;
    public Force force;
    public Bean bean;
    public Process process;
    private TextBox inptHBean;
    private TextBox inptBBean;
    private TextBox inptYcBean;
    private TextBox inptGapBean;
    private TextBox txbAsPassivo;
    private TextBox txbAsPassivo2;
    private TextBox inptYf;
    private TextBox inptYp;
    private TextBox inptPinit;
    private TextBox inptYs1;
    private TextBox inptYs2;
    private TextBox inptAsActive;
    private TextBox inptNext;
    private TextBox inptMext;
    private TextBox inptK0;
    private TextBox inptEr0;
    private PictureBox pb;
    private FlowLayoutPanel main;
    private FlowLayoutPanel divResults;
    private Label title;

    public int? ConcreteSelected =>
        cbClasseConcreto.SelectedItem != null
            ? int.TryParse(cbClasseConcreto.SelectedItem.ToString(), out int result) ? result : (int?)null
            : null;

    public int? SteelSelected =>
        cbClasseAcoPassive.SelectedItem != null
            ? int.TryParse(cbClasseAcoPassive.SelectedItem.ToString(), out int result) ? result : (int?)null
            : null;
    public event EventHandler OnSelectedChange
    {
        add => cbClasseConcreto.SelectedIndexChanged += value;
        remove => cbClasseConcreto.SelectedIndexChanged -= value;
    }

    ComboBox cbClasseConcreto = new()
    {
        DropDownStyle = ComboBoxStyle.DropDownList
    };

    ComboBox cbClasseAcoPassive = new()
    {
        DropDownStyle = ComboBoxStyle.DropDownList
    };

    ComboBox cbClasseAcoActive = new()
    {
        DropDownStyle = ComboBoxStyle.DropDownList,
        Width = 250
    };
    public Form2()
    {
        WindowState = FormWindowState.Maximized;
        FormBorderStyle = FormBorderStyle.SizableToolWindow;

        main = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.TopDown,
            Dock = DockStyle.Fill,
            Padding = new Padding(40)
        };

        Controls.Add(main);

        var divClasseConcreto = new FlowLayoutPanel
        {
            Width = 500,
            Height = 50,
            FlowDirection = FlowDirection.LeftToRight
        };

        main.Controls.Add(divClasseConcreto);

        var lbClasseConcreto = new Label
        {
            Width = 200,
            Text = "Classe do Concreto"
        };

        var divClasseAco = new FlowLayoutPanel
        {
            Width = 500,
            Height = 50,
            FlowDirection = FlowDirection.LeftToRight
        };

        FlowLayoutPanel divClasseAcoActive = new()
        {
            Width = 500,
            Height = 200,
            FlowDirection = FlowDirection.LeftToRight
        };
        Label lblClasseAcoActive = new()
        {
            Text = "Classe do Aço Protendido",
            Width = 200
        };

        var lblClasseAco = new Label
        {
            Width = 200,
            Text = "Classe do Aço Passivo"
        };

        var divAlturaViga = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.TopDown,
            Width = 100
        };

        var divBaseViga = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.TopDown,
            Width = 100
        };

        var divPropriedadesViga = new FlowLayoutPanel
        {
            Width = 500,
            Height = 300,
            FlowDirection = FlowDirection.LeftToRight
        };

        FlowLayoutPanel divForcas = new()
        {
            Width = 500,
            FlowDirection = FlowDirection.LeftToRight
        };

        var lblBaseViga = new Label
        {
            Text = "B viga",
            Width = 100
        };

        var lblAlturaViga = new Label
        {
            Text = "h viga",
            Width = 100
        };

        this.inptBBean = new TextBox
        {
            Width = 100,
            PlaceholderText = "Em mm"
        };

        this.inptBBean.KeyPress += (s, e) =>
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        };

        this.inptHBean = new TextBox
        {
            Width = 100,
            PlaceholderText = "Em mm"
        };


        this.inptHBean.KeyPress += (s, e) =>
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        };

        var lblAsPassivo = new Label
        {
            Text = "As1"
        };
        var lblAsPassivo2 = new Label
        {
            Text = "As2"
        };

        txbAsPassivo = new TextBox
        {
            Width = 100,
            PlaceholderText = "Em mm²"
        };

        txbAsPassivo2 = new TextBox
        {
            Width = 100,
            PlaceholderText = "Em mm²"
        };


        txbAsPassivo.KeyPress += (s, e) =>
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        };

        txbAsPassivo2.KeyPress += (s, e) =>
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        };

        var lblYc = new Label
        {
            Text = "yc da viga"
        };

        inptYcBean = new TextBox
        {
            Width = 100,
            PlaceholderText = "Em mm"
        };

        Label txtYfBean = new()
        {
            Text = "yf da Viga",
        };


        inptYcBean.KeyPress += (s, e) =>
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        };

        Label txtGapBean = new()
        {
            Text = "Furo na viga",
            Width = 100,
        };

        inptGapBean = new TextBox
        {
            Width = 100,
            PlaceholderText = "Em mm²"
        };

        ToolTip toolTipGap = new();
        toolTipGap.SetToolTip(txtGapBean, "Caso não possua furo coloque 0");
        toolTipGap.SetToolTip(inptGapBean, "Caso não possua furo coloque 0");

        var divDimensoesViga = new FlowLayoutPanel
        {
            Width = 500,
            FlowDirection = FlowDirection.LeftToRight
        };

        var divButton = new FlowLayoutPanel
        {
            Width = 500,
        };

        Button buttonCalc = new()
        {
            Text = "Calcular",
            Width = 496
        };

        inptYf = new TextBox
        {
            Width = 100,
            PlaceholderText = "Em mm"
        };

        inptYf.KeyPress += (s, e) =>
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        };

        Label lblAsActive = new()
        {
            Text = "Área de aço de protensão",
            Width = 200
        };

        inptAsActive = new TextBox
        {
            Width = 100,
            PlaceholderText = "Em mm²",
        };

        Label lblPi = new()
        {
            Text = "Força de Protensão inicial",
            Width = 200
        };

        inptPinit = new TextBox
        {
            Width = 100,
            PlaceholderText = "em KN"
        };

        Label lblYp = new()
        {
            Text = "Altura do Yp",
            Width = 200
        };

        inptYp = new TextBox
        {
            Width = 100,
            PlaceholderText = "Em mm"
        };

        Label lblYs1 = new()
        {
            Text = "Altura ys1",
            Width = 200
        };

        inptYs1 = new TextBox
        {
            Width = 100,
            PlaceholderText = "Em mm"
        };

        Label lblYs2 = new()
        {
            Text = "Altura ys2",
            Width = 200
        };

        inptYs2 = new TextBox
        {
            Width = 100,
            PlaceholderText = "Em mm"
        };

        Label lblNext = new()
        {
            Text = "Força Normal",
            Width = 200
        };

        inptNext = new TextBox
        {
            Width = 100,
            PlaceholderText = "Em KN"
        };

        Label lblMext = new()
        {
            Text = "Momento Fletor",
            Width = 200
        };

        inptMext = new TextBox
        {
            Width = 100,
            PlaceholderText = "Em KN*cm"
        };

        pb = new PictureBox
        {
            Dock = DockStyle.Fill,
            Height = 200
        };

        FlowLayoutPanel divVoid = new()
        {
            Height = 300,
            Width = 500

        };

        Label lblK0 = new Label
        {
            Text = "K t0",
            Width = 100
        };

        inptK0 = new TextBox
        {
            Width = 100,

        };

        Label lblEr0 = new Label
        {
            Text = "E t0",
            Width = 100
        };

        inptEr0 = new TextBox 
        {
            Width = 100,
            PlaceholderText = "Em mm"
        };

        divForcas.Controls.Add(lblNext);
        divForcas.Controls.Add(inptNext);

        divForcas.Controls.Add(lblMext);
        divForcas.Controls.Add(inptMext);

        divButton.Controls.Add(buttonCalc);


        divDimensoesViga.Controls.Add(lblBaseViga);
        divDimensoesViga.Controls.Add(inptBBean);

        divDimensoesViga.Controls.Add(lblAlturaViga);
        divDimensoesViga.Controls.Add(inptHBean);

        divDimensoesViga.Controls.Add(pb);

        divDimensoesViga.Controls.Add(txtGapBean);
        divDimensoesViga.Controls.Add(inptGapBean);

        divPropriedadesViga.Controls.Add(lblAsPassivo);
        divPropriedadesViga.Controls.Add(txbAsPassivo);

        divPropriedadesViga.Controls.Add(lblAsPassivo2);
        divPropriedadesViga.Controls.Add(txbAsPassivo2);

        divPropriedadesViga.Controls.Add(lblK0);
        divPropriedadesViga.Controls.Add(inptK0);

        divPropriedadesViga.Controls.Add(lblEr0);
        divPropriedadesViga.Controls.Add(inptEr0);

        divClasseAcoActive.Controls.Add(lblClasseAcoActive);
        divClasseAcoActive.Controls.Add(cbClasseAcoActive);

        divClasseAcoActive.Controls.Add(lblAsActive);
        divClasseAcoActive.Controls.Add(inptAsActive);

        divClasseAcoActive.Controls.Add(lblPi);
        divClasseAcoActive.Controls.Add(inptPinit);

        divClasseAcoActive.Controls.Add(lblYp);
        divClasseAcoActive.Controls.Add(inptYp);

        divClasseAcoActive.Controls.Add(lblYs1);
        divClasseAcoActive.Controls.Add(inptYs1);

        divClasseAcoActive.Controls.Add(lblYs2);
        divClasseAcoActive.Controls.Add(inptYs2);

        divPropriedadesViga.Controls.Add(divDimensoesViga);

        divPropriedadesViga.Controls.Add(lblYc);
        divPropriedadesViga.Controls.Add(inptYcBean);

        divPropriedadesViga.Controls.Add(txtYfBean);
        divPropriedadesViga.Controls.Add(inptYf);

        divPropriedadesViga.Controls.Add(txtGapBean);
        divPropriedadesViga.Controls.Add(inptGapBean);

        divClasseConcreto.Controls.Add(lbClasseConcreto);
        divClasseConcreto.Controls.Add(cbClasseConcreto);

        divClasseAco.Controls.Add(lblClasseAco);
        divClasseAco.Controls.Add(cbClasseAcoPassive);

        main.Controls.Add(divClasseAco);
        main.Controls.Add(divPropriedadesViga);
        main.Controls.Add(divClasseAcoActive);
        main.Controls.Add(divForcas);
        main.Controls.Add(divButton);
        main.Controls.Add(divVoid);
        main.Controls.Add(title);
        main.Controls.Add(pb);

        cbClasseConcreto.SelectedIndexChanged += (e, s) =>
        {
            if (ConcreteSelected.HasValue)
            {
                this.concrete = new Concrete((int)ConcreteSelected);
            }
        };

        cbClasseAcoPassive.SelectedIndexChanged += (e, s) =>
        {

            if (SteelSelected.HasValue)
            {
                this.steelPassive = new SteelPassive(
                    (int)SteelSelected,
                            (double)(txbAsPassivo.Text != null
                        ? double.TryParse(txbAsPassivo.Text.ToString(), out double result) ? result : (double?)0.00
                        : 0.00),
                        (double)(txbAsPassivo2.Text != null
                        ? double.TryParse(txbAsPassivo2.Text.ToString(), out double res) ? res : (double?)0.00
                        : 0.00));
            }
        };

        Load += (s, e) =>
        {
            cbClasseConcreto.DataSource =
                Enumerable.Range(0, 5)
                .Select(i => 30 + 5 * i)
                .ToList();

            cbClasseAcoPassive.Items.Add(25);
            cbClasseAcoPassive.Items.Add(50);
            cbClasseAcoPassive.Items.Add(60);

            cbClasseAcoPassive.SelectedIndex = 1;

            cbClasseAcoActive.Items.Add("CP 145 RB");
            cbClasseAcoActive.Items.Add("CP 150 RB");
            cbClasseAcoActive.Items.Add("CP 170 RB");
            cbClasseAcoActive.Items.Add("CP 175 RB");
            cbClasseAcoActive.Items.Add("CP 190 RB");
            cbClasseAcoActive.Items.Add("CP 210 RB");
            cbClasseAcoActive.Items.Add("CP 220 RB");
            cbClasseAcoActive.Items.Add("CP 230 RB");
            cbClasseAcoActive.Items.Add("CP 240 RB");

            cbClasseAcoActive.SelectedIndex = 0;
        };

        buttonCalc.Click += (s, e) => click_buttonCalc(s, e);
    }

    private void RenderGraph(PictureBox pb)
    {
        title = new Label
        {
            Text = "Tensões no Concreto",
            Size = new Size(500, 25),
        };
        Width = pb.Width;
        Height = pb.Height;

        Bitmap bmp = new(Width, Height);
        using Graphics g = Graphics.FromImage(bmp);
        g.Clear(Color.White);

        using Pen pen = new(Color.Gray, 1);
        using Pen pen1 = new(Color.Red, 1);
        PointF pointY = new(pb.Width / 2, 0);
        PointF pointY2 = new(pb.Width / 2, pb.Height);

        PointF pointStart = new((float)(pb.Width / 2 - process.SigmaTop * 5), 0);
        PointF pointEnd = new((float)(pb.Width / 2 - process.SigmaBottom * 5), pb.Height);

        g.DrawLine(pen, pointY, pointY2);
        g.DrawLine(pen1, pointStart, pointEnd);
        pb.Image = bmp;
        pb.Refresh();
    }

    private void ShowResults()
    {
        this.divResults = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.LeftToRight,
            Width = 500,
        };

        Label lblK = new()
        {
            Text = "Top = " + process.SigmaTop.ToString("F2") + " MPa",
            Width = 150
        };

        Label lblEpr = new()
        {
            Text = "Bottom = " + process.SigmaBottom.ToString("F2") + " MPa",
            Width = 150
        };
        divResults.Controls.Add(lblK);
        divResults.Controls.Add(lblEpr);
        main.Controls.Add(divResults);
    }

    private void StartBean()
    {
        int HBean = int.Parse(inptHBean.Text.ToString());
        int BBean = int.Parse(inptBBean.Text.ToString());
        int YcBean = int.Parse(inptYcBean.Text.ToString());
        double GapBean = double.Parse(inptGapBean.Text.ToString());
        double K0 = double.Parse(inptK0.Text.ToString()) * 1e6;
        double er0 = double.Parse(inptEr0.Text.ToString()) * 1e6;
        this.bean = new Bean(BBean, HBean, YcBean, GapBean, K0, er0);
    }

    private void StartSteelPassive()
    {
        int fyk = int.Parse(SteelSelected.ToString()!);
        int As1 = int.Parse(txbAsPassivo.Text.ToString());
        int As2 = int.Parse(txbAsPassivo2.Text.ToString());
        this.steelPassive = new SteelPassive(fyk, As1, As2);
    }

    private void StartConcrete()
    {
        int fck = int.Parse(cbClasseConcreto.Text.ToString());
        this.concrete = new Concrete(fck);
    }

    private void StartSteelActive()
    {
        string fykString = cbClasseAcoActive.Text.ToString();
        string[] fykSplit = fykString.Split(" ");
        int fyk = int.Parse(fykSplit[1]);
        int As = int.Parse(inptAsActive.Text.ToString());
        int Yf = int.Parse(inptYf.Text.ToString());
        int ys1 = int.Parse(inptYs1.Text.ToString());
        int ys2 = int.Parse(inptYs2.Text.ToString());
        int yp = int.Parse(inptYp.Text.ToString());
        int Pi = int.Parse(inptPinit.Text.ToString());
        this.steelActive = new SteelActive(fyk, As, Pi, ys1, ys2, Yf, yp);
    }
    private void StartForces()
    {
        int N = int.Parse(inptNext.Text.ToString());
        int M = int.Parse(inptMext.Text.ToString());
        this.force = new Force(N, M);
    }
    private void click_buttonCalc(object sender, EventArgs e)
    {
        if (divResults != null)
        {
            main.Controls.Remove(divResults);
        }
        try
        {
            StartConcrete();
            StartBean();
            StartSteelPassive();
            StartSteelActive();
            StartForces();
        }
        catch (Exception err)
        {
            // MessageBox.Show("Falha ao iniciar, verifique os dados inseridos");
            MessageBox.Show(err.Message.ToString());
            return;
        }
        try
        {
            process = new Process(concrete, steelActive, steelPassive, bean, force);
            process.ProcessMatrix();
            ShowResults();
            RenderGraph(pb);
        }
        catch (Exception err)
        {
            MessageBox.Show(err.Message.ToString());
            return;
        }
    }
}