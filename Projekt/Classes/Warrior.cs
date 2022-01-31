using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Warrior : Character, IEquipment
    {
        public string Helm { get; set; }
        public string Club { get; set; }
        public string HeavyArmor { get; set; }
        public string Boots { get; set; }

        public Warrior() { }

        public Warrior(SexType sex, RaceType race)
        {
            CharacterName = "Warrior";
            TotalSkills = 20;
            Helm = FolderPath + CharacterName + @"\\Helm\\1.png";
            Club = FolderPath + CharacterName + @"\\Club\\1.png";
            HeavyArmor = FolderPath + CharacterName + @"\\HeavyArmor\\1.png";
            Boots = FolderPath + CharacterName + @"\\Boots\\1.png";

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

            Helm = SetPath(Helm, tab[0]);
            Club = SetPath(Club, tab[1]);
            HeavyArmor = SetPath(HeavyArmor, tab[2]);
            Boots = SetPath(Boots, tab[3]);
        }

        public void IncreaseEqComponent(Eq eq)
        {
            switch (eq)
            {
                case Eq.Helm:
                    Helm = IncreasePath(Helm);
                    break;
                case Eq.Club:
                    Club = IncreasePath(Club);
                    break;
                case Eq.HeavyArmor:
                    HeavyArmor = IncreasePath(HeavyArmor);
                    break;
                case Eq.Boots:
                    Boots = IncreasePath(Boots);
                    break;
            }
        }

        public void ReduceEqComponent(Eq eq)
        {
            switch (eq)
            {
                case Eq.Helm:
                    Helm = ReducePath(Helm);
                    break;
                case Eq.Club:
                    Club = ReducePath(Club);
                    break;
                case Eq.HeavyArmor:
                    HeavyArmor = ReducePath(HeavyArmor);
                    break;
                case Eq.Boots:
                    Boots = ReducePath(Boots);
                    break;
            }
        }
    }
}
