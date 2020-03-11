using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 f1 = new Form2();
            f1.Show();
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            textBox1.Focus();
            

        }
        //this is the code for assigning shortcuts to elements (Alt+X, Alt+S etc etc):
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers==Keys.Control && e.KeyCode == Keys.F)
            {
                textBox2.Focus();
            }
        }
        //But the above code doesnt seem to work.
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (textBox1.TextLength < 8)
            {
                int parsedValue;
                if (!int.TryParse(textBox1.Text, out parsedValue) && textBox1.Text!="")
                {
                    button1.Enabled = false;
                    textBox1.Text = "";
                    MessageBox.Show("Error, Student number should only contain numeric values");
                    button4.Enabled = false;
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;


                }
                else
                {
                    button1.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                }
            }
            else if (textBox1.TextLength > 8)
            {
                button1.Enabled = false;
                button4.Enabled = true;
                button3.Enabled = false;
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;
            if (textBox2.TextLength >= 40)
            {
                MessageBox.Show("Error, Name should only be upto 40 characters");
                textBox2.Text = "";
                button4.Enabled = false;
            }
            else if (textBox2.TextLength < 40 && textBox2.TextLength > 0)
            {
                button4.Enabled = true;
            }
            if (int.TryParse(textBox2.Text, out parsedValue))
            {
                MessageBox.Show("Error, Name should only contain alphabets");
                textBox2.Text = "";
                button4.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;
            int parsedValue2;
            bool res = Int32.TryParse(textBox3.Text, out parsedValue);
            bool res2 = Int32.TryParse(textBox1.Text, out parsedValue2);
            if (res2 == true && textBox3.Text!="")
            {
                if (res == true && parsedValue <= 100 && parsedValue >= 0)
                {
                    button2.Enabled = true;
                }
                else
                {
                    button2.Enabled = false;
                    textBox3.Text = "";
                    MessageBox.Show("Error, Enter grades between 0 to 100 only!");
                }
            }
            else if(textBox3.Text != "")
            {
                button2.Enabled = false;
                textBox3.Text = "";
                MessageBox.Show("Error, Student number contains only numbers and it should not be empty!");
                
            }
            if(textBox3.TextLength<=5)
            {
                button4.Enabled = true;
            }
            else
            {
                button4.Enabled = false;
                MessageBox.Show("Error, Grades can only accept upto 5 characters");

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox1.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }      
}

