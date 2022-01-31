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
    public partial class Tworzenie_3 : Form
    {
        protected Character character;
        public Tworzenie_3()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        public Tworzenie_3(Character character)
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.character = character;
            switch (character.CharacterName)

            {
                case "Archer":
                    pictureBox14.Image = Image.FromFile((character as Archer).Arch);
                    pictureBox12.Image = Image.FromFile((character as Archer).Cap);
                    pictureBox13.Image = Image.FromFile((character as Archer).LightArmor);
                    pictureBox9.Image = Image.FromFile((character as Archer).LightShoes);
                    break;
                case "Magician":
                    pictureBox14.Image = Image.FromFile((character as Magician).Wand);
                    pictureBox12.Image = Image.FromFile((character as Magician).Hat);
                    pictureBox13.Image = Image.FromFile((character as Magician).Robe);
                    pictureBox9.Image = Image.FromFile((character as Magician).MagicShoes);
                    break;
                case "Warrior":
                    pictureBox14.Image = Image.FromFile((character as Warrior).Club);
                    pictureBox12.Image = Image.FromFile((character as Warrior).Helm);
                    pictureBox13.Image = Image.FromFile((character as Warrior).HeavyArmor);
                    pictureBox9.Image = Image.FromFile((character as Warrior).Boots);
                    break;
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            if (character.Race != "Orc")
            {
                Tworzenie_2 cofanie = new Tworzenie_2(character);
                Hide();
                cofanie.ShowDialog();
                Close();
            }
            else
            {
                Tworzenie_1 cofanie = new Tworzenie_1(character);
                Hide();
                cofanie.ShowDialog();
                Close();
            }
        }
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            (character as IEquipment).RandEquipment();

            switch (character.CharacterName)
            {
                case "Archer":
                    pictureBox14.Image = Image.FromFile((character as Archer).Arch);
                    pictureBox12.Image = Image.FromFile((character as Archer).Cap);
                    pictureBox13.Image = Image.FromFile((character as Archer).LightArmor);
                    pictureBox9.Image = Image.FromFile((character as Archer).LightShoes);
                    break;
                case "Magician":
                    pictureBox14.Image = Image.FromFile((character as Magician).Wand);
                    pictureBox12.Image = Image.FromFile((character as Magician).Hat);
                    pictureBox13.Image = Image.FromFile((character as Magician).Robe);
                    pictureBox9.Image = Image.FromFile((character as Magician).MagicShoes);
                    break;
                case "Warrior":
                    pictureBox14.Image = Image.FromFile((character as Warrior).Club);
                    pictureBox12.Image = Image.FromFile((character as Warrior).Helm);
                    pictureBox13.Image = Image.FromFile((character as Warrior).HeavyArmor);
                    pictureBox9.Image = Image.FromFile((character as Warrior).Boots);
                    break;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e) // BRON--
        {
            switch (character.CharacterName)
            {
                case "Archer":
                    (character as IEquipment).ReduceEqComponent(Eq.Arch);
                    pictureBox14.Image = Image.FromFile((character as Archer).Arch);
                    break;
                case "Magician":
                    (character as IEquipment).ReduceEqComponent(Eq.Wand);
                    pictureBox14.Image = Image.FromFile((character as Magician).Wand);
                    break;
                case "Warrior":
                    (character as IEquipment).ReduceEqComponent(Eq.Club);
                    pictureBox14.Image = Image.FromFile((character as Warrior).Club);
                    break;
            }     
        }

        private void pictureBox4_Click(object sender, EventArgs e) // BRON++
        {
            switch (character.CharacterName)
            {
                case "Archer":
                    (character as IEquipment).IncreaseEqComponent(Eq.Arch);
                    pictureBox14.Image = Image.FromFile((character as Archer).Arch);
                    break;
                case "Magician":
                    (character as IEquipment).IncreaseEqComponent(Eq.Wand);
                    pictureBox14.Image = Image.FromFile((character as Magician).Wand);
                    break;
                case "Warrior":
                    (character as IEquipment).IncreaseEqComponent(Eq.Club);
                    pictureBox14.Image = Image.FromFile((character as Warrior).Club);
                    break;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) // HELM--
        {
            switch (character.CharacterName)
            {
                case "Archer":
                    (character as IEquipment).ReduceEqComponent(Eq.Cap);
                    pictureBox12.Image = Image.FromFile((character as Archer).Cap);
                    break;
                case "Magician":
                    (character as IEquipment).ReduceEqComponent(Eq.Hat);
                    pictureBox12.Image = Image.FromFile((character as Magician).Hat);
                    break;
                case "Warrior":
                    (character as IEquipment).ReduceEqComponent(Eq.Helm);
                    pictureBox12.Image = Image.FromFile((character as Warrior).Helm);
                    break;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e) // HELM++
        {
            switch (character.CharacterName)
            {
                case "Archer":
                    (character as IEquipment).IncreaseEqComponent(Eq.Cap);
                    pictureBox12.Image = Image.FromFile((character as Archer).Cap);
                    break;
                case "Magician":
                    (character as IEquipment).IncreaseEqComponent(Eq.Hat);
                    pictureBox12.Image = Image.FromFile((character as Magician).Hat);
                    break;
                case "Warrior":
                    (character as IEquipment).IncreaseEqComponent(Eq.Helm);
                    pictureBox12.Image = Image.FromFile((character as Warrior).Helm);
                    break;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e) // ZBROJA--
        {
            switch (character.CharacterName)
            {
                case "Archer":
                    (character as IEquipment).ReduceEqComponent(Eq.LightArmor);
                    pictureBox13.Image = Image.FromFile((character as Archer).LightArmor);
                    break;
                case "Magician":
                    (character as IEquipment).ReduceEqComponent(Eq.Robe);
                    pictureBox13.Image = Image.FromFile((character as Magician).Robe);
                    break;
                case "Warrior":
                    (character as IEquipment).ReduceEqComponent(Eq.HeavyArmor);
                    pictureBox13.Image = Image.FromFile((character as Warrior).HeavyArmor);
                    break;
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e) // ZBROJA++
        {
            switch (character.CharacterName)
            {
                case "Archer":
                    (character as IEquipment).IncreaseEqComponent(Eq.LightArmor);
                    pictureBox13.Image = Image.FromFile((character as Archer).LightArmor);
                    break;
                case "Magician":
                    (character as IEquipment).IncreaseEqComponent(Eq.Robe);
                    pictureBox13.Image = Image.FromFile((character as Magician).Robe);
                    break;
                case "Warrior":
                    (character as IEquipment).IncreaseEqComponent(Eq.HeavyArmor);
                    pictureBox13.Image = Image.FromFile((character as Warrior).HeavyArmor);
                    break;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e) // BUTY--
        {
            switch (character.CharacterName)
            {
                case "Archer":
                    (character as IEquipment).ReduceEqComponent(Eq.LightShoes);
                    pictureBox9.Image = Image.FromFile((character as Archer).LightShoes);
                    break;
                case "Magician":
                    (character as IEquipment).ReduceEqComponent(Eq.MagicShoes);
                    pictureBox9.Image = Image.FromFile((character as Magician).MagicShoes);
                    break;
                case "Warrior":
                    (character as IEquipment).ReduceEqComponent(Eq.Boots);
                    pictureBox9.Image = Image.FromFile((character as Warrior).Boots);
                    break;
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e) // BUTY++
        {
            switch (character.CharacterName)
            {
                case "Archer":
                    (character as IEquipment).IncreaseEqComponent(Eq.LightShoes);
                    pictureBox9.Image = Image.FromFile((character as Archer).LightShoes);
                    break;
                case "Magician":
                    (character as IEquipment).IncreaseEqComponent(Eq.MagicShoes);
                    pictureBox9.Image = Image.FromFile((character as Magician).MagicShoes);
                    break;
                case "Warrior":
                    (character as IEquipment).IncreaseEqComponent(Eq.Boots);
                    pictureBox9.Image = Image.FromFile((character as Warrior).Boots);
                    break;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DateT.AddPerson(character);
            Powitanie cofanie = new Powitanie();
            Hide();
            cofanie.ShowDialog();
            Close();
        }
    }
}
