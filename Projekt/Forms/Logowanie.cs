using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt
{
    public partial class Logowanie : Form
    {
        public Logowanie()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
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
            //TUTAJ MA BYĆ FUNKCJA SPRAWDZAJĄCA CZY DANE ZOSTAŁY POPRAWNIE WPROWADZONE, JEŚLI TAK TO:
            try
            {
                DateT.Login(textBox1.Text, textBox2.Text);
            }
            catch(Exception)
            {
                MessageBox.Show("Wprowadzono błędne dane.", "Błąd logowania", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;            
            }
 
            Powitanie witam = new Powitanie();
            Hide();
            witam.ShowDialog();
            Close();           
        }
    }
}
