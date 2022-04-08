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
                case 5:
                    Power();
                    break;
                case 6:
                    Root();
                    break;

            }
        }

        private void Sum()
        {
            double a, b, c, d;
            (a, b, c, d) = Nums();
            double Re = a + c;
            double Im = b + d;
            textBox6.Text = Convert.ToString(Re);
            textBox5.Text = Convert.ToString(Im);
        }

        private void Substract()
        {
            double a, b, c, d;
            (a, b, c, d) = Nums();
            double Re = a - c;
            double Im = b - d;
            textBox6.Text = Convert.ToString(Re);
            textBox5.Text = Convert.ToString(Im);
        }

        private void Multiply()
        {
            double a, b, c, d;
            (a, b, c, d) = Nums();
            double Re = a * c - b * d;
            double Im = b * c + a * d;
            textBox6.Text = Convert.ToString(Re);
            textBox5.Text = Convert.ToString(Im);
        }

        private void Divide()
        {
            double a, b, c, d;
            (a, b, c, d) = Nums();
            double Re = (a * c + b * d) / (c * c + d * d);
            double Im = (b * c - a * d) / (c * c + d * d);
            textBox6.Text = Convert.ToString(Re);
            textBox5.Text = Convert.ToString(Im);
        }

        private (double, double) ToTrig()
        {
            double Re = Convert.ToDouble(textBox1.Text);
            double Im = Convert.ToDouble(textBox2.Text);
            double Abs = Math.Sqrt(Math.Pow(Re, 2) + Math.Pow(Im, 2));
            double arg_cos = Re / Abs;
            double arg_sin = Im / Abs;
            double asin = Math.Asin(arg_sin);
            asin = asin * 180 / Math.PI;
            if(arg_sin > 0 && arg_cos < 0)
            {
                asin += 90;
            }
            else if(arg_sin <= 0 && arg_cos < 0)
            {
                asin = -asin;
                asin += 180;
            }
            else if(arg_sin < 0 && arg_cos >= 0)
            {
                asin += 360;
            }

            double Arg = asin;
            return (Abs, Arg);
        }

        private (double, double) ToCanon(double Abs, double Arg)
        {
            double pi_Arg = (Arg / 180) * Math.PI;
            double cos_v = Math.Cos(pi_Arg);
            double sin_v = Math.Sin(pi_Arg);
            double Real = Abs * cos_v;
            double Imag = Abs * sin_v;
            return (Real, Imag);
        }

        private void Power()
        {
            double z_abs, z_arg;
            (z_abs, z_arg) = ToTrig();
            double pow = Convert.ToDouble(textBox3.Text);
            z_abs = Math.Pow(z_abs, pow);
            z_arg *= pow;
            z_arg %= 360;
            double a, b;
            (a, b) = ToCanon(z_abs, z_arg);
            textBox5.Text = Convert.ToString(Math.Round(a, 2));
            textBox6.Text = Convert.ToString(Math.Round(b, 2));
        }

        private void Root()
        {
            double z_abs, z_arg;
            (z_abs, z_arg) = ToTrig();

            double root_deg = Convert.ToDouble(textBox3.Text);
            double root_abs = Math.Pow(z_abs, 1.0 / root_deg);
            uint udeg = Convert.ToUInt32(root_deg);
            double[] rtArg = new double[udeg];
            double[] rtA = new double[udeg];
            double[] rtB = new double[udeg];

            for (uint i = 0; i < udeg; i++)
            {
                rtArg[i] = (z_arg + 360 * i) / root_deg;
            }
            for (uint i = 0; i < udeg; i++)
            {
                (rtA[i], rtB[i]) = ToCanon(z_abs, rtArg[i]);
            }

            textBox5.Clear();
            textBox6.Clear();
            for (uint i = 0; i < udeg; i++)
            {
                textBox5.AppendText(Convert.ToString(Math.Round(rtA[i], 2)));
                textBox5.AppendText(Environment.NewLine);
                textBox6.AppendText(Convert.ToString(Math.Round(rtB[i], 2)));
                textBox6.AppendText(Environment.NewLine);
            }
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

        private void button5_Click(object sender, EventArgs e)
        {
            selection = 5;
            label1.Text = "^";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            selection = 6;
            label1.Text = "\u221A";
        }
    }
}