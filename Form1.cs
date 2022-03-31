namespace ComplexCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private (double, double, double, double) Nums()
        {
            double Re1 = Convert.ToDouble(textBox1.Text);
            double Im1 = Convert.ToDouble(textBox2.Text);
            double Re2 = Convert.ToDouble(textBox3.Text);
            double Im2 = Convert.ToDouble(textBox4.Text);
            return (Re1, Im1, Re2, Im2);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a, b, c, d;
            (a,b,c,d) = Nums();
        }
    }
}