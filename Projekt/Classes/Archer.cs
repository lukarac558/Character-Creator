using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Archer : Character, IEquipment
    {
        public string Cap { get; set; }
        public string Arch { get; set; }
        public string LightArmor { get; set; }
        public string LightShoes { get; set; }

        public Archer() { }

        public Archer(SexType sex, RaceType race)
        {
            CharacterName = "Archer";
            TotalSkills = 20;
            Cap =  FolderPath + CharacterName + @"\\Cap\\1.png";
            Arch = FolderPath + CharacterName + @"\\Arch\\1.png";
            LightArmor = FolderPath + CharacterName + @"\\LightArmor\\1.png";
            LightShoes = FolderPath + CharacterName + @"\\LightShoes\\1.png";

            if(sex == SexType.Male)
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

            Cap = SetPath(Cap, tab[0]);
            Arch = SetPath(Arch, tab[1]);
            LightArmor = SetPath(LightArmor, tab[2]); 
            LightShoes = SetPath(LightShoes, tab[3]);
        } // done

        public void IncreaseEqComponent(Eq eq)
        {
            switch (eq)
            {
                case Eq.Cap:
                    Cap = IncreasePath(Cap);
                    break;
                case Eq.Arch:
                    Arch = IncreasePath(Arch);
                    break;
                case Eq.LightArmor:
                    LightArmor = IncreasePath(LightArmor);
                    break;
                case Eq.LightShoes:
                    LightShoes = IncreasePath(LightShoes);
                    break;
            }

        } // done

        public void ReduceEqComponent(Eq eq)
        {
            switch (eq)
            {
                case Eq.Cap:
                    Cap = ReducePath(Cap);
                    break;
                case Eq.Arch:
                    Arch = ReducePath(Arch);
                    break;
                case Eq.LightArmor:
                    LightArmor = ReducePath(LightArmor);
                    break;
                case Eq.LightShoes:
                    LightShoes = ReducePath(LightShoes);
                    break;
            }

        } // done
    }
}
