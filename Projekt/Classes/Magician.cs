using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Projekt 
{
    class Magician : Character, IEquipment
    {
        public string Hat { get; set; }
        public string Wand { get; set; }
        public string Robe { get; set; }
        public string MagicShoes { get; set; }

        public Magician() { }

        public Magician(SexType sex, RaceType race)
        {
            TotalSkills = 20;
            CharacterName = "Magician";
            Hat = FolderPath + CharacterName + @"\\Hat\\1.png";
            Wand = FolderPath + CharacterName + @"\\Wand\\1.png";
            Robe = FolderPath + CharacterName + @"\\Robe\\1.png";
            MagicShoes = FolderPath + CharacterName + @"\\MagicShoes\\1.png";

            if (sex == SexType.Male)
                Sex = "Male";
            if (sex == SexType.Female)
                Sex = "Female";

            if (race != RaceType.Orc)
            {
                Hair = FolderPath + Sex + @"\\Hair\\1.png";
                Eyes = FolderPath + Sex + @"\\Eyes\\1.png";
                Nose = FolderPath + Sex + @"\\Nose\\1.png";
                Mouth = FolderPath + Sex + @"\\Mouth\\1.png";
            }

            switch (race)
            {
                case RaceType.Elf:
                    Race = "Elf";
                    Head = FolderPath + Sex + @"\\ElfHead.png";
                    Body = FolderPath + Sex + @"\\ElfBody.png";
                    break;
                case RaceType.Human:
                    Race = "Human";
                    Head = FolderPath + Sex + @"\\HumanHead.png";
                    Body = FolderPath + Sex + @"\\HumanBody.png";
                    break;
                case RaceType.Orc:
                    Race = "Orc";
                    Head = FolderPath + Sex + @"\\OrcHead.png";
                    Body = FolderPath + Sex + @"\\OrcBody.png";
                    break;
            }
        }

        public void RandEquipment()
        {
            var rand = new Random();
            int[] tab = new int[4];
            for (int i = 0; i < 4; i++)
            {
                tab[i] = rand.Next(1, 10); // losuje od 1 do 9
            }

            Hat = SetPath(Hat, tab[0]);
            Wand = SetPath(Wand, tab[1]);
            Robe = SetPath(Robe, tab[2]);
            MagicShoes = SetPath(MagicShoes, tab[3]);
        }

        public void IncreaseEqComponent(Eq eq)
        {
            switch (eq)
            {
                case Eq.Hat:
                    Hat = IncreasePath(Hat);
                    break;
                case Eq.Wand:
                    Wand = IncreasePath(Wand);
                    break;
                case Eq.Robe:
                    Robe = IncreasePath(Robe);
                    break;
                case Eq.MagicShoes:
                    MagicShoes = IncreasePath(MagicShoes);
                    break;
            }
        }

        public void ReduceEqComponent(Eq eq)
        {
            switch (eq)
            {
                case Eq.Hat:
                    Hat = ReducePath(Hat);
                    break;
                case Eq.Wand:
                    Wand = ReducePath(Wand);
                    break;
                case Eq.Robe:
                    Robe = ReducePath(Robe);
                    break;
                case Eq.MagicShoes:
                    MagicShoes = ReducePath(MagicShoes);
                    break;
            }
        }
    }
}
