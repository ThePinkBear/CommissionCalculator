using System.Windows.Forms.VisualStyles;

namespace CommissionCalculator
{
    public partial class Form1 : Form
    {
        public double Value { get; set; }
        public double TotalValue { get; set; }
        public int Modifier { get; set; } = 1;
        public int AdditionalChars { get; set; } = 1;
        public int AdditionalComplexity1 { get; set; }
        public int AdditionalComplexity2 { get; set; }
        public int AdditionalComplexity3 { get; set; }
        public int Background { get; set; }
        public int IdiotTax { get; set; }
        public int GrayTones { get; set; }


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("All clear!", "Cleared", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                ComplexAddHrSmall.ResetText();
                ComplexAddHrMedium.ResetText();
                ComplexAddHrLarge.ResetText();
                BackGroundAddHrBasic.ResetText();
                BackGroundAddHrDetailed.ResetText();
                BackGroundAddHrElaborate.ResetText();
                BigChangesAddCost.ResetText();
                AdditionalCharacters.ResetText();
                Value = 0;
                TotalValue = 0;
                Modifier = 1;
                AdditionalChars = 1;
                AdditionalComplexity1 = 0;
                AdditionalComplexity2 = 0;
                AdditionalComplexity3 = 0;
                Background = 0;
                IdiotTax = 0;
                GrayTones = 0;
                Calculate();
            }
        }
        private void Calculate()
        {
            TotalValue = ((Value * AdditionalChars) + GrayTones + AdditionalComplexity1 + AdditionalComplexity2 + AdditionalComplexity3 + Background + IdiotTax) * Modifier;
            TotalAmount.Text = TotalValue.ToString();
            DisplayReceipt.Clear();
            var percentage = (Modifier - 1) * 100;
            var display1 = AdditionalChars - 1 == 0 ? "" : $"Extra Characters: {(AdditionalChars - 1).ToString()}\n";
            var display1x = GrayTones == 0 ? "" : $"Sketch gray tones fee: {GrayTones}€\n";
            var display2 = AdditionalComplexity1 == 0 ? "" : $"Design Details S: {AdditionalComplexity1}€\n";
            var display2x = AdditionalComplexity2 == 0 ? "" : $"Design Details M: {AdditionalComplexity2}€\n";
            var display2y = AdditionalComplexity3 == 0 ? "" : $"Design Details L: {AdditionalComplexity3}€\n";
            var display3 = Background == 0 ? "" : $"Background: {Background}€\n";
            var display4 = IdiotTax == 0 ? "" : $"Changes fee: {IdiotTax}€\n";
            var display5 = percentage == 0 ? "" : $"Copyright fees: {percentage}%";

            DisplayReceipt.AppendText($"Base Price: {Value}€\n {display1}{display1x}{display2}{display2x}{display2y}{display3}{display4}{display5}");
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddBust_Price(object sender, EventArgs e)
        {
            Value = 50;
            Calculate();
        }

        private void ShadedHalfBody_Click(object sender, EventArgs e)
        {
            Value = 75;
            Calculate();
        }

        private void ShadedFullBody_Click(object sender, EventArgs e)
        {
            Value = 100;
            Calculate();
        }

        private void FlatBust_Click(object sender, EventArgs e)
        {
            Value = 40;
            Calculate();
        }

        private void FlatHalfBody_Click(object sender, EventArgs e)
        {
            Value = 60;
            Calculate();
        }

        private void FlatFullBody_Click(object sender, EventArgs e)
        {
            Value = 80;
            Calculate();
        }

        private void ScetchBust_Click(object sender, EventArgs e)
        {
            Value = 15;
            Calculate();
        }

        private void ScetchHalfBody_Click(object sender, EventArgs e)
        {
            Value = 20;
            Calculate();
        }

        private void SketchFullBody_Click(object sender, EventArgs e)
        {
            Value = 25;
            Calculate();
        }

        private void TwitchYtTwi_CheckedChanged(object sender, EventArgs e)
        {
            Modifier = 2;
            Calculate();
        }

        private void PatBusiPersonal_CheckedChanged(object sender, EventArgs e)
        {
            Modifier = 3;
            Calculate();
        }

        private void ReproduceSell_CheckedChanged(object sender, EventArgs e)
        {
            Modifier = 4;
            Calculate();
        }

        private void NoAddedPercentage_CheckedChanged(object sender, EventArgs e)
        {
            Modifier = 1;
            Calculate();
        }

        private void AdditionalCharacters_ValueChanged(object sender, EventArgs e)
        {
            AdditionalChars = 1;
            if ((int)AdditionalCharacters.Value == 0)
            {
                Calculate();
            }
            else
            {
                AdditionalChars *= (int)AdditionalCharacters.Value + 1;
                Calculate();
            }
        }

        private void ComplexAddHrSmall_ValueChanged(object sender, EventArgs e)
        {
            AdditionalComplexity1 = 0;
            AdditionalComplexity1 = (int)ComplexAddHrSmall.Value * 10;
            Calculate();
        }

        private void ComplexAddHrMedium_ValueChanged(object sender, EventArgs e)
        {
            AdditionalComplexity2 = 0;
            AdditionalComplexity2 = (int)(ComplexAddHrMedium.Value * 20);
            Calculate();
        }

        private void ComplexAddHrLarge_ValueChanged(object sender, EventArgs e)
        {
            AdditionalComplexity3 = 0;
            AdditionalComplexity3 = (int)((ComplexAddHrLarge.Value * 30));
            Calculate();
        }

        private void BackGroundAddHrBasic_ValueChanged(object sender, EventArgs e)
        {
            Background = 0;
            Background = (int)BackGroundAddHrBasic.Value * 10;
            Calculate();
        }

        private void BackGroundAddHrDetailed_ValueChanged(object sender, EventArgs e)
        {
            Background = 0;
            Background = (int)BackGroundAddHrDetailed.Value * 20;
            Calculate();
        }

        private void BackGroundAddHrElaborate_ValueChanged(object sender, EventArgs e)
        {
            Background = 0;
            Background = ((int)BackGroundAddHrElaborate.Value * 30);
            Calculate();
        }

        private void BigChangesAddCost_TextChanged(object sender, EventArgs e)
        {
            IdiotTax = 0;
            if (String.IsNullOrEmpty(BigChangesAddCost.Text))
            {
                IdiotTax = 0;
                Calculate();
            }
            else
            {
                IdiotTax = Convert.ToInt32(BigChangesAddCost.Text);
                Calculate();
            }
        }

        private void DisplayReceipt_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
               GrayTones = 5;
               Calculate();
            } 
            else
            {
                GrayTones = 0;
                Calculate();
            }
        }
    }
}