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
    public partial class Usuwanie : Form
    {
        protected List<Character> lista;
        protected int flaga=0;

        public Usuwanie()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            lista = DateT.Load();

            if (lista.Count == 1)
                label2.Text = lista[0].Nick;

            if (lista.Count == 2)
            {
                label2.Text = lista[0].Nick;
                label3.Text = lista[1].Nick;
            }            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = Image.FromFile(lista[0].Head);
            if (lista[0].Race != "Orc")
            {
                pictureBox15.Visible = true;
                pictureBox12.Visible = true;
                pictureBox13.Visible = true;
                pictureBox14.Visible = true;
                pictureBox11.Image = Image.FromFile(lista[0].Head);
                pictureBox15.Image = Image.FromFile(lista[0].Hair);
                pictureBox12.Image = Image.FromFile(lista[0].Eyes);
                pictureBox13.Image = Image.FromFile(lista[0].Nose);
                pictureBox14.Image = Image.FromFile(lista[0].Mouth);
            }
            else
            {
                pictureBox15.Visible = false;
                pictureBox12.Visible = false;
                pictureBox13.Visible = false;
                pictureBox14.Visible = false;
            }
            flaga = 2;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            pictureBox11.Image = Image.FromFile(lista[1].Head);
            if (lista[1].Race != "Orc")
            {
                pictureBox15.Visible = true;
                pictureBox12.Visible = true;
                pictureBox13.Visible = true;
                pictureBox14.Visible = true;
                pictureBox15.Image = Image.FromFile(lista[1].Hair);
                pictureBox12.Image = Image.FromFile(lista[1].Eyes);
                pictureBox13.Image = Image.FromFile(lista[1].Nose);
                pictureBox14.Image = Image.FromFile(lista[1].Mouth);
            }
            else
            {
                pictureBox15.Visible = false;
                pictureBox12.Visible = false;
                pictureBox13.Visible = false;
                pictureBox14.Visible = false;
            }
            flaga = 3;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Powitanie cofanie = new Powitanie();
            Hide();
            cofanie.ShowDialog();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Chcesz napewna usunac postac ?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (flaga == 2)
                    DateT.DeletePerson(lista[0]);
                if (flaga == 3)
                    DateT.DeletePerson(lista[1]);
            }
            else
                return;

            Powitanie cofanie = new Powitanie();
            Hide();
            cofanie.ShowDialog();
            Close();
        }
    }
}
