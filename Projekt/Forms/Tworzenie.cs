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
    public partial class Tworzenie : Form
    {
        protected Character character;
        protected SexType sex = SexType.Male;
        protected RaceType race = RaceType.Elf;
        protected ClassType clas = ClassType.Archer;

        public Tworzenie()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            pictureBox10.Image = Image.FromFile(@"C:\\KreatorPostaci\\Start\\elf.png");
            pictureBox2.Image = Image.FromFile(@"C:\\KreatorPostaci\\Start\\male.png");
            pictureBox11.Image = Image.FromFile(@"C:\\KreatorPostaci\\Start\\archer.png");  
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
            //JESLI DANE ZOSTALY WPROWADZONE POPRAWNIE TO IDZIEMY DALEJ:         
            switch (clas)
            {                
                case ClassType.Archer:   
                    character = new Archer(sex, race);
                    break;
                case ClassType.Magician:
                    character = new Magician(sex, race);
                    break;
                case ClassType.Warrior:
                    character = new Warrior(sex, race);
                    break;
            }
            character.Id = DateT.userId;
            character.Nick = textBox1.Text;
            Tworzenie_1 dalej = new Tworzenie_1(character);
            Hide();
            dalej.ShowDialog();
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e) // PŁEĆ--
        {
            if (sex == SexType.Female)
            {
                sex = SexType.Male;
                pictureBox2.Image = Image.FromFile(@"C:\\KreatorPostaci\\Start\\male.png");
            } 
            else
            {
                sex = SexType.Female;
                pictureBox2.Image = Image.FromFile(@"C:\\KreatorPostaci\\Start\\female.png");
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e) // PŁEĆ++
        {
            if (sex == SexType.Female)
            {
                sex = SexType.Male;
                pictureBox2.Image = Image.FromFile(@"C:\\KreatorPostaci\\Start\\male.png");
            }
            else
            {
                sex = SexType.Female;
                pictureBox2.Image = Image.FromFile(@"C:\\KreatorPostaci\\Start\\female.png");
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e) // RASA--
        {
            switch(race)
            {
                case RaceType.Elf:
                    race = RaceType.Orc;
                    pictureBox10.Image = Image.FromFile(@"C:\\KreatorPostaci\\Start\\orc.png");
                    break;
                case RaceType.Human:
                    race = RaceType.Elf;
                    pictureBox10.Image = Image.FromFile(@"C:\\KreatorPostaci\\Start\\elf.png");
                    break;
                case RaceType.Orc:
                    race = RaceType.Human;
                    pictureBox10.Image = Image.FromFile(@"C:\\KreatorPostaci\\Start\\human.png");
                    break;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e) // RASA++
        {
            switch (race)
            {
                case RaceType.Elf:
                    race = RaceType.Human;
                    pictureBox10.Image = Image.FromFile(@"C:\\KreatorPostaci\\Start\\human.png");
                    break;
                case RaceType.Human:
                    race = RaceType.Orc;
                    pictureBox10.Image = Image.FromFile(@"C:\\KreatorPostaci\\Start\\orc.png");
                    break;
                case RaceType.Orc:
                    race = RaceType.Elf;
                    pictureBox10.Image = Image.FromFile(@"C:\\KreatorPostaci\\Start\\elf.png");
                    break;
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e) // KLASA--
        {
            switch (clas)
            {
                case ClassType.Archer:
                    clas = ClassType.Warrior;
                    pictureBox11.Image = Image.FromFile(@"C:\\KreatorPostaci\\Start\\warrior.png");
                    break;
                case ClassType.Magician:
                    clas = ClassType.Archer;
                    pictureBox11.Image = Image.FromFile(@"C:\\KreatorPostaci\\Start\\archer.png");
                    break;
                case ClassType.Warrior:
                    clas = ClassType.Magician;
                    pictureBox11.Image = Image.FromFile(@"C:\\KreatorPostaci\\Start\\magician.png");
                    break;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e) // KLASA--
        {
            switch (clas)
            {
                case ClassType.Archer:
                    clas = ClassType.Magician;
                    pictureBox11.Image = Image.FromFile(@"C:\\KreatorPostaci\\Start\\magician.png");
                    break;
                case ClassType.Magician:
                    clas = ClassType.Warrior;
                    pictureBox11.Image = Image.FromFile(@"C:\\KreatorPostaci\\Start\\warrior.png");
                    break;
                case ClassType.Warrior:
                    clas = ClassType.Archer;
                    pictureBox11.Image = Image.FromFile(@"C:\\KreatorPostaci\\Start\\archer.png");
                    break;
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            //LOSOWANIE_CHARAKTERU{PLEC, RASA, KLASA}

            Array values1 = Enum.GetValues(typeof(SexType));
            Array values2 = Enum.GetValues(typeof(RaceType));
            Array values3 = Enum.GetValues(typeof(ClassType));            
            var rand = new Random();
            sex = (SexType)values1.GetValue(rand.Next(values1.Length));
            race = (RaceType)values2.GetValue(rand.Next(values2.Length));
            clas = (ClassType)values3.GetValue(rand.Next(values3.Length));
            switch (race)
            {
                case RaceType.Elf:
                    pictureBox10.Image = Image.FromFile(@"C:\\KreatorPostaci\\Start\\elf.png");
                    break;
                case RaceType.Human:
                    pictureBox10.Image = Image.FromFile(@"C:\\KreatorPostaci\\Start\\human.png");
                    break;
                case RaceType.Orc:
                    pictureBox10.Image = Image.FromFile(@"C:\\KreatorPostaci\\Start\\orc.png");
                    break;
            }
            switch (sex)
            {
                case SexType.Male:
                    pictureBox2.Image = Image.FromFile(@"C:\\KreatorPostaci\\Start\\male.png");
                    break;
                case SexType.Female:
                    pictureBox2.Image = Image.FromFile(@"C:\\KreatorPostaci\\Start\\female.png");
                    break;
            }
            switch (clas)
            {
                case ClassType.Archer:
                    pictureBox11.Image = Image.FromFile(@"C:\\KreatorPostaci\\Start\\archer.png");
                    break;
                case ClassType.Magician:
                    pictureBox11.Image = Image.FromFile(@"C:\\KreatorPostaci\\Start\\magician.png");
                    break;
                case ClassType.Warrior:
                    pictureBox11.Image = Image.FromFile(@"C:\\KreatorPostaci\\Start\\warrior.png");
                    break;
            }

        }
    }
}
