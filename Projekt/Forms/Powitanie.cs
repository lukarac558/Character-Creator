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
    public partial class Powitanie : Form
    {
        protected List<Character> lista;
        public Powitanie()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            lista = DateT.Load();
            if(lista.Count == 0)
                MessageBox.Show("Brak postaci do podglądu.");
            else
            {
                Podglad pod = new Podglad();
                Hide();
                pod.ShowDialog();
                Close();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            lista = DateT.Load();
            if (lista.Count == 2)
                MessageBox.Show("Utworzono już maksymalną ilość postaci.");
            else
            {
                Tworzenie twor = new Tworzenie();
                Hide();
                twor.ShowDialog();
                Close();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            lista = DateT.Load();
            if (lista.Count == 0)
                MessageBox.Show("Brak postaci do usunięcia.");
            else
            {
                Usuwanie usun = new Usuwanie();
                Hide();
                usun.ShowDialog();
                Close();
            }
        }


        private void label5_Click(object sender, EventArgs e)
        {
            Start usun = new Start();
            Hide();
            usun.ShowDialog();
            Close();
        }
    }
}
