using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt
{
    public partial class Rejestracja : Form
    {
        public Rejestracja()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            label5.BackColor = Color.Transparent;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Start cofanie = new Start();
            Hide();
            cofanie.ShowDialog();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox2.Text;
            if (textBox1.Text.Length < 3 && textBox2.Text.Length < 3)
            {
                MessageBox.Show("Twoje dane sa za krótkie.");
                return;
            }
            if (textBox1.Text.Length < 3)
            {
                MessageBox.Show("Twoj login jest za krótki.");
                return;
            }
            if (textBox2.Text.Length < 3)
            {
                MessageBox.Show("Twoje hasło jest za krótkie.");
                return;
            }
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Hasła się nie zgadzają.");
                return;
            }
            if (textBox2.Text == textBox1.Text)
            {
                MessageBox.Show("Hasło nie może być takie same jak login.");
                return;
            }
            if(textBox1.Text.Any(char.IsWhiteSpace))
            {
                MessageBox.Show("Login nie może zawierać spacji.");
                return;
            }
            if(textBox2.Text.Any(char.IsWhiteSpace))
            {
                MessageBox.Show("Hasło nie moze zawierać spacji.");
                return;
            }
            if (text.Any(char.IsDigit) && text.Any(char.IsLetter) && text.Any(char.IsUpper)) 
            {
                progressBar1.Value = 100;
                progressBar1.ForeColor = Color.Green;
                label5.Text = "Mocne";
                label5.ForeColor = Color.Green;                 
            }
            else if(text.Any(char.IsDigit) && text.Any(char.IsLetter))
            {
                progressBar1.Value = 70;
                progressBar1.ForeColor = Color.Yellow;
                label5.Text = "Średnie";
                label5.ForeColor = Color.Yellow;
            }
            else if (text.Any(char.IsDigit))
            {
                progressBar1.Value = 30;
                progressBar1.ForeColor = Color.Red;
                label5.Text = "Słabe";
                label5.ForeColor = Color.Red;
            }
               
           
            DateT.Register(textBox1.Text, textBox2.Text);            
            Start cofanie = new Start();
            Hide();
            cofanie.ShowDialog();
            Close();
            Thread.Sleep(1000);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (!DateT.IfExists(textBox1.Text))
                MessageBox.Show("Podany login jest zajęty.");
            else
                MessageBox.Show("Podany login jest dostępny.");
        }

        private void label5_Click(object sender, EventArgs e)
        {
           
        }
    }
}
