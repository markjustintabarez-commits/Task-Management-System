using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]))
            {
                e.Handled = true; 
            }

            if ((e.KeyChar == System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]) &&
                ((sender as TextBox).Text.IndexOf(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]) > -1))
            {
                e.Handled = true; 
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void priceText_TextChanged(object sender, EventArgs e)
        {
            FormatCurrency(sender as TextBox);
        }

        private bool TextisValid(string text)
        {
            Regex money = new Regex(@"^\$(\d{1,3}(\,\d{3})*|(\d+))(\.\d{2})?$");
            return money.IsMatch(text);
        }

        private bool _formattingCurrency;

        private void FormatCurrency(TextBox tb)
        {
            if (tb == null)
                return;
            if (_formattingCurrency)
                return;
            try
            {
                _formattingCurrency = true;
                string value = tb.Text.Replace(",", "")
                    .Replace("$", "").Replace(".", "").TrimStart('0');
                decimal ul;
                if (decimal.TryParse(value, out ul))
                {
                    ul /= 100;
                    tb.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C2}", ul);
                    tb.Select(tb.Text.Length, 0);
                }
                bool goodToGo = TextisValid(tb.Text);
                if (!goodToGo)
                {
                    tb.Text = "$0.00";
                    tb.Select(tb.Text.Length, 0);
                }
            }
            finally
            {
                _formattingCurrency = false;
            }
        }

        private void itemCostText_TextChanged(object sender, EventArgs e)
        {
            FormatCurrency(sender as TextBox);
        }

        private void salesTaxText_TextChanged(object sender, EventArgs e)
        {
            FormatCurrency(sender as TextBox);
        }

        private void shippingText_TextChanged(object sender, EventArgs e)
        {
            FormatCurrency(sender as TextBox);
        }

        private void handlingText_TextChanged(object sender, EventArgs e)
        {
            FormatCurrency(sender as TextBox);
        }

        private void totalText_TextChanged(object sender, EventArgs e)
        {
            FormatCurrency(sender as TextBox);
        }
    }
}



