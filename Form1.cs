namespace ComplexCalculator
{
    public partial class Form1 : Form
    {
        short selection = 0;
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

        private void Calculate(short sw)
        {
            switch(sw)
            {
                case 1:
                    Sum();
                    break;
                case 2:
                    Substract();
                    break;
                case 3:
                    Multiply();
                    break;
                case 4:
                    Divide();
                    break;

            }
        }

        private void Sum()
        {
            double a, b, c, d;
            (a, b, c, d) = Nums();
            double Re = a + c;
            double Im = b + d;
            textBox5.Text = Convert.ToString(Re);
            textBox6.Text = Convert.ToString(Im);
        }

        private void Substract()
        {
            double a, b, c, d;
            (a, b, c, d) = Nums();
            double Re = a - c;
            double Im = b - d;
            textBox5.Text = Convert.ToString(Re);
            textBox6.Text = Convert.ToString(Im);
        }

        private void Multiply()
        {
            double a, b, c, d;
            (a, b, c, d) = Nums();
            double Re = a * c - b * d;
            double Im = b * c + a * d;
            textBox5.Text = Convert.ToString(Re);
            textBox6.Text = Convert.ToString(Im);
        }

        private void Divide()
        {
            double a, b, c, d;
            (a, b, c, d) = Nums();
            double Re = (a * c + b * d) / (c * c + d * d);
            double Im = (b * c - a * d) / (c * c + d * d);
            textBox5.Text = Convert.ToString(Re);
            textBox6.Text = Convert.ToString(Im);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Calculate(selection);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selection = 1;
            label1.Text = "+";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selection = 2;
            label1.Text = "-";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selection = 3;
            label1.Text = "*";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            selection = 4;
            label1.Text = "/";
        }
    }
}