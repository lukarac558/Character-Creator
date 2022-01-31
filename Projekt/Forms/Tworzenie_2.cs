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
    public partial class Tworzenie_2 : Form
    {
        protected Character character;

        public Tworzenie_2()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        public Tworzenie_2(Character character)
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.character = character;
            pictureBox11.Image = Image.FromFile(character.Head);
                pictureBox12.Image = Image.FromFile(character.Eyes);
                pictureBox13.Image = Image.FromFile(character.Nose);
                pictureBox14.Image = Image.FromFile(character.Mouth);
                pictureBox15.Image = Image.FromFile(character.Hair);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //JESLI DANE ZOSTALY WPROWADZONE POPRAWNIE TO IDZIEMY DALEJ:
            Tworzenie_3 dalej = new Tworzenie_3(character);
            Hide();
            dalej.ShowDialog();
            Close();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Tworzenie_1 cofanie = new Tworzenie_1(character);
            Hide();
            cofanie.ShowDialog();
            Close();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            //LOSOWANIE_TWARZY
            character.RandFace();
            pictureBox11.Image = Image.FromFile(character.Head);
            pictureBox12.Image = Image.FromFile(character.Eyes);
            pictureBox13.Image = Image.FromFile(character.Nose);
            pictureBox14.Image = Image.FromFile(character.Mouth);
            pictureBox15.Image = Image.FromFile(character.Hair);
        }

        private void pictureBox6_Click(object sender, EventArgs e) // WŁOSY--
        {
            character.ReduceFaceElement(HeadElement.Hair);
            pictureBox15.Image = Image.FromFile(character.Hair);
        }

        private void pictureBox4_Click(object sender, EventArgs e) // WŁOSY++
        {
            character.IncreaseFaceElement(HeadElement.Hair);
            pictureBox15.Image = Image.FromFile(character.Hair);
        }

        private void pictureBox1_Click(object sender, EventArgs e) // OCZY--
        {
            character.ReduceFaceElement(HeadElement.Eyes);
            pictureBox12.Image = Image.FromFile(character.Eyes);
        }

        private void pictureBox5_Click(object sender, EventArgs e) // OCZY++
        {
            character.IncreaseFaceElement(HeadElement.Eyes);
            pictureBox12.Image = Image.FromFile(character.Eyes);
        }

        private void pictureBox2_Click(object sender, EventArgs e) // NOS--
        {
            character.ReduceFaceElement(HeadElement.Nose);
            pictureBox13.Image = Image.FromFile(character.Nose);
        }

        private void pictureBox7_Click(object sender, EventArgs e) // NOS++
        {
            character.IncreaseFaceElement(HeadElement.Nose);
            pictureBox13.Image = Image.FromFile(character.Nose);
        }

        private void pictureBox3_Click(object sender, EventArgs e) // USTA--
        {
            character.ReduceFaceElement(HeadElement.Mouth);
            pictureBox14.Image = Image.FromFile(character.Mouth);            
        }

        private void pictureBox8_Click(object sender, EventArgs e) // USTA++
        {
            character.IncreaseFaceElement(HeadElement.Mouth);
            pictureBox14.Image = Image.FromFile(character.Mouth);
        }
    }
}
