namespace Verificacao;

public class Form2 : Form
{
    public Concrete concrete;
    public SteelPassive steelPassive;
    public SteelActive steelActive;
    public Force force;
    public Bean bean;
    private TextBox inptHBean;
    private TextBox inptBBean;
    private TextBox inptYcBean;
    private TextBox inptGapBean;
    private TextBox txbAsPassivo;
    private TextBox txbAsPassivo2;
    private TextBox inptYf;
    private TextBox inptPi;

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

    ComboBox cbClasseConcreto = new ComboBox
    {
        DropDownStyle = ComboBoxStyle.DropDownList
    };

    ComboBox cbClasseAcoPassive = new ComboBox
    {
        DropDownStyle = ComboBoxStyle.DropDownList
    };

    ComboBox cbClasseAcoActive = new ComboBox
    {
        DropDownStyle = ComboBoxStyle.DropDownList,
    };
    public Form2()
    {
        WindowState = FormWindowState.Maximized;
        FormBorderStyle = FormBorderStyle.SizableToolWindow;

        var main = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.TopDown,
            Dock = DockStyle.Fill,
            Padding = new Padding(40),
        };
        Controls.Add(main);

        var divClasseConcreto = new FlowLayoutPanel
        {
            Width = 450,
            Height = 50,
            FlowDirection = FlowDirection.LeftToRight,
            BackColor = Color.Yellow
        };

        main.Controls.Add(divClasseConcreto);

        var lbClasseConcreto = new Label
        {
            Width = 200,
            Text = "Classe do Concreto"
        };

        var divClasseAco = new FlowLayoutPanel
        {
            Width = 450,
            Height = 50,
            FlowDirection = FlowDirection.LeftToRight,
            BackColor = Color.Blue
        };

        FlowLayoutPanel divClasseAcoActive = new FlowLayoutPanel
        {
            Width = 450,
            Height = 50, 
            FlowDirection = FlowDirection.LeftToRight,
            BackColor = Color.Red
        };
        Label lblClasseAcoActive = new Label
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
            Width = 100,
            BackColor = Color.Aqua
        };

        var divBaseViga = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.TopDown,
            Width = 100,
            BackColor = Color.Yellow
        };

        var divPropriedadesViga = new FlowLayoutPanel
        {
            Width = 450,
            Height = 400,
            FlowDirection = FlowDirection.LeftToRight,
            BackColor = Color.Yellow
        };

        var lblBaseViga = new Label
        {
            Text = "B viga em mm",
            Width = 100
        };

        var lblAlturaViga = new Label
        {
            Text = "h viga em mm",
            Width = 100
        };

        this.inptBBean = new TextBox
        {
            Width = 100
        };

        this.inptBBean.KeyPress += (s,e) => 
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        };

        this.inptHBean = new TextBox
        {
            Width = 100
        };

        
        this.inptHBean.KeyPress += (s,e) => 
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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
            Width = 100
        };

        txbAsPassivo2 = new TextBox
        {
            Width = 100
        };

        
        txbAsPassivo.KeyPress += (s,e) => 
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        };

        txbAsPassivo2.KeyPress += (s,e) => 
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
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
            Width = 100
        };

        Label txtYfBean = new Label
        {
            Text = "yf da Viga",
        };

        
        inptYcBean.KeyPress += (s,e) => 
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        };

        Label txtGapBean = new Label
        {
            Text = "Furo na viga mm²"
        };

        inptGapBean = new TextBox
        {
            Width = 100
        };

        ToolTip toolTipGap = new ToolTip();
        toolTipGap.SetToolTip(txtGapBean, "Caso não possua furo coloque 0");
        toolTipGap.SetToolTip(inptGapBean, "Caso não possua furo coloque 0");

        var divDimensoesViga = new FlowLayoutPanel
        {
            Width = 450,
            FlowDirection = FlowDirection.LeftToRight,
            BackColor = Color.Azure
        };

        var divButton = new FlowLayoutPanel
        {
            Width = 450,
        };

        Button buttonCalc = new Button
        {
            Text = "Calcular",
            Width = 446
        };

        inptYf = new TextBox
        {
            Width = 100
        };

        inptYf.KeyPress += (s, e) => 
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        };
        
        Label lblPi = new Label
        {
            Text = "Força de Protensão aplicada"
        };

        inptPi = new TextBox
        {
            Width = 150,
            PlaceholderText = "em KN"
        };

        divButton.Controls.Add(buttonCalc);

        divDimensoesViga.Controls.Add(lblBaseViga);
        divDimensoesViga.Controls.Add(inptBBean);

        divDimensoesViga.Controls.Add(lblAlturaViga);
        divDimensoesViga.Controls.Add(inptHBean);

        divDimensoesViga.Controls.Add(txtGapBean);
        divDimensoesViga.Controls.Add(inptGapBean);

        divPropriedadesViga.Controls.Add(lblAsPassivo);
        divPropriedadesViga.Controls.Add(txbAsPassivo);

        divPropriedadesViga.Controls.Add(lblAsPassivo2);
        divPropriedadesViga.Controls.Add(txbAsPassivo2);
        
        divClasseAcoActive.Controls.Add(lblClasseAcoActive);
        divClasseAcoActive.Controls.Add(cbClasseAcoActive);

        divClasseAcoActive.Controls.Add(lblPi);
        divClasseAcoActive.Controls.Add(inptPi);

        divPropriedadesViga.Controls.Add(divDimensoesViga);

        divPropriedadesViga.Controls.Add(lblYc);
        divPropriedadesViga.Controls.Add(inptYcBean);

        divPropriedadesViga.Controls.Add(txtYfBean);    
        divPropriedadesViga.Controls.Add(inptYf);

        divPropriedadesViga.Controls.Add(txtGapBean);
        divPropriedadesViga.Controls.Add(inptGapBean);

        main.Controls.Add(divClasseAco);
        main.Controls.Add(divPropriedadesViga);
        main.Controls.Add(divClasseAcoActive);

        divClasseConcreto.Controls.Add(lbClasseConcreto);
        divClasseConcreto.Controls.Add(cbClasseConcreto);

        divClasseAco.Controls.Add(lblClasseAco);
        divClasseAco.Controls.Add(cbClasseAcoPassive);
        
        main.Controls.Add(divButton);

        cbClasseConcreto.SelectedIndexChanged += (e, s) =>
        {
            if (ConcreteSelected.HasValue)
            {
                this.concrete = new Concrete((int)ConcreteSelected);
            }
        };

        cbClasseAcoPassive.SelectedIndexChanged += (e, s) => {

            if(SteelSelected.HasValue)
            {
                this.steelPassive = new SteelPassive(
                    (int)SteelSelected,
                            (double)(txbAsPassivo.Text != null
                        ? double.TryParse(txbAsPassivo.Text.ToString(), out double result) ? result : (double?) 0.00
                        : 0.00),
                        (double)(txbAsPassivo2.Text != null
                        ? double.TryParse(txbAsPassivo2.Text.ToString(), out double res)? res : (double?) 0.00
                        : 0.00)); 
            }
         };

        Load += (s, e) =>
        {
            cbClasseConcreto.DataSource =
                Enumerable.Range(0, 6)
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

    private void StartBean()
    {
        int HBean = int.Parse(inptHBean.Text.ToString());
        int BBean = int.Parse(inptBBean.Text.ToString());
        int YcBean = int.Parse(inptYcBean.Text.ToString());
        double GapBean = double.Parse(inptGapBean.Text.ToString());

        this.bean = new Bean(BBean, HBean, YcBean, GapBean);
    }

    private void StartSteelPassive()
    {
        int fyk = int.Parse(SteelSelected.ToString());
        int As1 = int.Parse(txbAsPassivo.Text.ToString());
        int As2 = int.Parse(txbAsPassivo2.Text.ToString());
        this.steelPassive = new SteelPassive(fyk, As1, As2);
    }

    private void click_buttonCalc(object sender, EventArgs e)
    {
        try
        {
            StartBean();
            StartSteelPassive();
        } catch 
        {
            MessageBox.Show("Falha ao processar, verifique os dados inseridos");
        }
    }
}