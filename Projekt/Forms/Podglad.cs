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
    public partial class Podglad : Form
    {
        protected List<Character> lista;
        public Podglad()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            lista = DateT.Load();

            if (lista.Count == 1)
            {
                label2.Text = lista[0].Nick;
            }
            else if (lista.Count == 2)
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
            
             if (lista[0] is Archer)
             {
                 pictureBox1.Image = Image.FromFile((lista[0] as Archer).Cap); // Hełm
                 pictureBox2.Image = Image.FromFile((lista[0] as Archer).Arch); // Broń
                 pictureBox3.Image = Image.FromFile((lista[0] as Archer).LightArmor); // Szata
                 pictureBox4.Image = Image.FromFile((lista[0] as Archer).LightShoes); // Buty
                 
             }
             if (lista[0] is Warrior)
             {
                 pictureBox1.Image = Image.FromFile((lista[0] as Warrior).Helm); // Hełm
                 pictureBox2.Image = Image.FromFile((lista[0] as Warrior).Club); // Broń
                 pictureBox3.Image = Image.FromFile((lista[0] as Warrior).HeavyArmor); // Szata
                 pictureBox4.Image = Image.FromFile((lista[0] as Warrior).Boots); // Buty
                 
             }
             if (lista[0] is Magician)
             {
                 pictureBox1.Image = Image.FromFile((lista[0] as Magician).Hat); // Hełm
                 pictureBox2.Image = Image.FromFile((lista[0] as Magician).Wand); // Broń
                 pictureBox3.Image = Image.FromFile((lista[0] as Magician).Robe); // Szata
                 pictureBox4.Image = Image.FromFile((lista[0] as Magician).MagicShoes); // Buty
            }             
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

            if (lista[1] is Archer)
            {
                pictureBox1.Image = Image.FromFile((lista[1] as Archer).Cap); // Hełm
                pictureBox2.Image = Image.FromFile((lista[1] as Archer).Arch); // Broń
                pictureBox3.Image = Image.FromFile((lista[1] as Archer).LightArmor); // Szata
                pictureBox4.Image = Image.FromFile((lista[1] as Archer).LightShoes); // Buty

            }
            if (lista[1] is Warrior)
            {
                pictureBox1.Image = Image.FromFile((lista[1] as Warrior).Helm); // Hełm
                pictureBox2.Image = Image.FromFile((lista[1] as Warrior).Club); // Broń
                pictureBox3.Image = Image.FromFile((lista[1] as Warrior).HeavyArmor); // Szata
                pictureBox4.Image = Image.FromFile((lista[1] as Warrior).Boots); // Buty

            }
            if (lista[1] is Magician)
            {
                pictureBox1.Image = Image.FromFile((lista[1] as Magician).Hat); // Hełm
                pictureBox2.Image = Image.FromFile((lista[1] as Magician).Wand); // Broń
                pictureBox3.Image = Image.FromFile((lista[1] as Magician).Robe); // Szata
                pictureBox4.Image = Image.FromFile((lista[1] as Magician).MagicShoes); // Buty
            }

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Powitanie cofanie = new Powitanie();
            Hide();
            cofanie.ShowDialog();
            Close();
        }
    }
}
