using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str1 = num1Box.Text.Trim();
            string str2 = num2Box.Text.Trim();
            try
            {
                int num1 = Convert.ToInt32(str1);
                int num2 = Convert.ToInt32(str2);

                switch (comboBox1.Text)
                {
                    case "+":
                        resultBox.Text = (num1 + num2).ToString();
                        break;
                    case "-":
                        resultBox.Text = (num1 - num2).ToString();
                        break;
                    case "*":
                        resultBox.Text = (num1 * num2).ToString();
                        break;
                    case "/":
                        resultBox.Text = ((double)num1 / num2).ToString();
                        break;
                }
            }
            catch(FormatException){
                MessageBox.Show("Number Invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                num1Box.Text = string.Empty;
                num2Box.Text = string.Empty;
                num1Box.Focus();
            }
            catch(OverflowException){
                MessageBox.Show("Number Overflow!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                num1Box.Text = string.Empty;
                num2Box.Text = string.Empty;
                num1Box.Focus();
            }

            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            num1Box.Text = string.Empty;
            num2Box.Text = string.Empty;
            resultBox.Text = string.Empty;
            num1Box.Focus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

    }
}
