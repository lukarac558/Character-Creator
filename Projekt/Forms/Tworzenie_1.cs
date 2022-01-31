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
    public partial class Tworzenie_1 : Form
    {
        protected Character character;

        public Tworzenie_1()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        public Tworzenie_1(Character character)
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.character = character;
            label5.Text = Convert.ToString(character.Strength);
            label6.Text = Convert.ToString(character.Life);
            label7.Text = Convert.ToString(character.Dexterity);
            label8.Text = Convert.ToString(character.Intellect);
            label9.Text = Convert.ToString(character.TotalSkills);
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //JESLI DANE ZOSTALY WPROWADZONE POPRAWNIE TO IDZIEMY DALEJ:
            if (character.Race != "Orc")
            {
                Tworzenie_2 dalej = new Tworzenie_2(character);
                Hide();
                dalej.ShowDialog();
                Close();
            }
            else
            { 
                Ulumulu dalej = new Ulumulu(character);
                Hide();
                dalej.ShowDialog();
                Close();
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Tworzenie cofanie = new Tworzenie();
            Hide();
            cofanie.ShowDialog();
            Close();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            //LOSOWANIE_STATYSTYK
            character.RandSkills();
            label5.Text = Convert.ToString(character.Strength);
            label6.Text = Convert.ToString(character.Life);
            label7.Text = Convert.ToString(character.Dexterity);
            label8.Text = Convert.ToString(character.Intellect);
            label9.Text = Convert.ToString(character.TotalSkills);
        }

        private void pictureBox5_Click(object sender, EventArgs e) // SIŁA--
        {
            character.SubstractSkillPoint(SkillType.Strength);
            label5.Text = Convert.ToString(character.Strength);
            label9.Text = Convert.ToString(character.TotalSkills);
        }

        private void pictureBox4_Click(object sender, EventArgs e) // SIŁA++
        {
            character.AddSkillPoint(SkillType.Strength);
            label5.Text = Convert.ToString(character.Strength);
            label9.Text = Convert.ToString(character.TotalSkills);

        }

        private void pictureBox6_Click(object sender, EventArgs e) // WYTRZYMAŁOŚĆ--
        {
            character.SubstractSkillPoint(SkillType.Life);
            label6.Text = Convert.ToString(character.Life);
            label9.Text = Convert.ToString(character.TotalSkills);
        }

        private void pictureBox1_Click(object sender, EventArgs e) // WYTRZYMAŁOŚĆ++
        {
            character.AddSkillPoint(SkillType.Life);
            label6.Text = Convert.ToString(character.Life);
            label9.Text = Convert.ToString(character.TotalSkills);
        }

        private void pictureBox7_Click(object sender, EventArgs e) // ZRĘCZNOŚĆ--
        {
            character.SubstractSkillPoint(SkillType.Dexterity);
            label7.Text = Convert.ToString(character.Dexterity);
            label9.Text = Convert.ToString(character.TotalSkills);
        }

        private void pictureBox2_Click(object sender, EventArgs e) // ZRĘCZNOŚĆ++
        {
            character.AddSkillPoint(SkillType.Dexterity);
            label7.Text = Convert.ToString(character.Dexterity);
            label9.Text = Convert.ToString(character.TotalSkills);
        }

        private void pictureBox8_Click(object sender, EventArgs e) // INTELEKT--
        {
            character.SubstractSkillPoint(SkillType.Intellect);
            label8.Text = Convert.ToString(character.Intellect);
            label9.Text = Convert.ToString(character.TotalSkills);
        }

        private void pictureBox3_Click(object sender, EventArgs e) // INTELEKT++
        {
            character.AddSkillPoint(SkillType.Intellect);
            label8.Text = Convert.ToString(character.Intellect);
            label9.Text = Convert.ToString(character.TotalSkills);
        }
    }
}
