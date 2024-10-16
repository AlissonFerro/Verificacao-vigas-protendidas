namespace Verificacao;

public class Form2 : Form
{
    public Concrete concrete;
    
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
            BackColor = Color.Blue,
        };
        Controls.Add(main);

        var divClasseConcreto = new FlowLayoutPanel
        {
            Width = 400,
            Height = 50,
            FlowDirection = FlowDirection.LeftToRight,
            BackColor = Color.Red
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
            BackColor = Color.Yellow
        };

        var lblClasseAco = new Label
        {
            Width = 200,
            Text = "Classe do Aço Passivo"
        };

        var divDimensoesViga = new FlowLayoutPanel
        {
            Width = 400,
            Height = 400,
            FlowDirection = FlowDirection.LeftToRight,
            BackColor = Color.Aqua
        };

        main.Controls.Add(divClasseAco);
        main.Controls.Add(divDimensoesViga);
        divClasseConcreto.Controls.Add(lbClasseConcreto);
        divClasseConcreto.Controls.Add(cbClasseConcreto);
        divClasseAco.Controls.Add(lblClasseAco);
        divClasseAco.Controls.Add(cbClasseAco);

        cbClasseConcreto.SelectedIndexChanged += (e, s) => {
            if(ConcreteSelected.HasValue){
                this.concrete = new Concrete((int)ConcreteSelected);
                MessageBox.Show(this.concrete.Ecs.ToString());
            }
        };
        cbClasseAco.SelectedIndexChanged += (e, s) => {};

        Load += (s, e) =>
        {
            cbClasseConcreto.DataSource =
                Enumerable.Range(0, 6)
                .Select(i => 25 + 5 * i)
                .ToList();
            
            cbClasseAco.Items.Add(25);
            cbClasseAco.Items.Add(50);
            cbClasseAco.Items.Add(60);
        };


    }
}