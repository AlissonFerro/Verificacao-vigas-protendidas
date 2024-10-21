namespace Verificacao;

public class Form2 : Form
{
    public Concrete concrete;
    public SteelPassive steelPassive;
    public SteelActive steelActive;
    public Force force;
    public Bean bean;
    public TextBox inptHBean;
    public TextBox inptBBean;
    public TextBox inptYcBean;
    public TextBox inptGapBean;

    public int? ConcreteSelected =>
        cbClasseConcreto.SelectedItem != null
            ? int.TryParse(cbClasseConcreto.SelectedItem.ToString(), out int result) ? result : (int?)null
            : null;

    public int? SteelSelected =>
        cbClasseAco.SelectedItem != null
            ? int.TryParse(cbClasseAco.SelectedItem.ToString(), out int result) ? result : (int?)null
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

    ComboBox cbClasseAco = new ComboBox
    {
        DropDownStyle = ComboBoxStyle.DropDownList
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
            Width = 400,
            Height = 50,
            FlowDirection = FlowDirection.LeftToRight,
        };
        main.Controls.Add(divClasseConcreto);

        var lbClasseConcreto = new Label
        {
            Width = 200,
            Text = "Classe do Concreto"
        };

        var divClasseAco = new FlowLayoutPanel
        {
            Width = 400,
            Height = 50,
            FlowDirection = FlowDirection.LeftToRight,
        };

        var lblClasseAco = new Label
        {
            Width = 200,
            Text = "Classe do Aço Passivo"
        };

        var divAlturaViga = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.TopDown,
            Width = 80,
            BackColor = Color.Red
        };

        var divBaseViga = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.TopDown,
            Width = 100,
            BackColor = Color.Yellow
        };

        var divPropriedadesViga = new FlowLayoutPanel
        {
            Width = 800,
            Height = 400,
            FlowDirection = FlowDirection.LeftToRight
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
            Width = 40
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
            Width = 40
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

        var txbAsPassivo = new TextBox
        {
            Width = 100
        };

        var txbAsPassivo2 = new TextBox
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
            Text = "yc da viga",
            Margin = new Padding(50, 0, 0, 0)
        };

        inptYcBean = new TextBox
        {
            Width = 100
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

        var divDimensoesViga = new FlowLayoutPanel
        {
            Width = 800,
            FlowDirection = FlowDirection.LeftToRight
        };

        var divButton = new FlowLayoutPanel
        {
            Width = 400,
        };

        Button buttonCalc = new Button
        {
            Text = "Calcular",
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

        divPropriedadesViga.Controls.Add(divDimensoesViga);


        divPropriedadesViga.Controls.Add(lblYc);
        divPropriedadesViga.Controls.Add(inptYcBean);


        main.Controls.Add(divClasseAco);
        main.Controls.Add(divPropriedadesViga);

        divClasseConcreto.Controls.Add(lbClasseConcreto);
        divClasseConcreto.Controls.Add(cbClasseConcreto);

        divClasseAco.Controls.Add(lblClasseAco);
        divClasseAco.Controls.Add(cbClasseAco);
        
        main.Controls.Add(divButton);

        cbClasseConcreto.SelectedIndexChanged += (e, s) =>
        {
            if (ConcreteSelected.HasValue)
            {
                this.concrete = new Concrete((int)ConcreteSelected);
            }
        };

        cbClasseAco.SelectedIndexChanged += (e, s) => {

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

            cbClasseAco.Items.Add(25);
            cbClasseAco.Items.Add(50);
            cbClasseAco.Items.Add(60);

            cbClasseAco.SelectedIndex = 1;
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

    private void click_buttonCalc(object sender, EventArgs e)
    {
        // double YcBean = double.Parse(this.);
        // MessageBox.Show(HBean.ToString());
        // MessageBox.Show(BBean.ToString());
        // bean = new Bean()
    }
}