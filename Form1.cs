namespace Verificacao;

public partial class Form1 : Form
{
    ComboBox comboBoxConcreto = new ComboBox();
    Button buttonSelected = new Button();
    public Form1()
    {
        InitializeComponent();
        comboBoxConcreto.Items.Add("C25");
        comboBoxConcreto.Items.Add("C30");
        comboBoxConcreto.Items.Add("C35");
        comboBoxConcreto.Items.Add("C40");
        comboBoxConcreto.Items.Add("C45");
        comboBoxConcreto.Items.Add("C50");

        comboBoxConcreto.Location = new Point(20, 20);
        comboBoxConcreto.Size = new Size(100,20);

        this.Controls.Add(comboBoxConcreto);

        this.buttonSelected.Location = new Point(100,20);
        this.buttonSelected.Text = "Verificação";
        this.buttonSelected.Size = new Size(100,20);
        this.buttonSelected.Click += new EventHandler(this.Button1_Click);

        this.Controls.Add(buttonSelected);
    }

    private void Button1_Click(object sender, EventArgs e)
    {
        var selectedItem = comboBoxConcreto.SelectedItem;
        MessageBox.Show("Concreto classe " + selectedItem?.ToString());        
    }
}
