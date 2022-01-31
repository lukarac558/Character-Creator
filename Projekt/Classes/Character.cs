using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public abstract class Character
    {
        public readonly string FolderPath = @"C:\\KreatorPostaci\\";
        public int Id { get; set; }
        public string CharacterName { get; set; }
        public string Nick { get; set; }
        public string Race { get; set; }
        public string Sex { get; set; }
        public int TotalSkills { get; set; }
        public int Life { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intellect { get; set; }
        public string Head { get; set; }
        public string Body { get; set; }
        public string Hair { get; set; }
        public string Eyes { get; set; }
        public string Nose { get; set; }
        public string Mouth { get; set; }

        public void RandFace()
        {
            var rand = new Random();
            int[] tab = new int[4];
            for (int i = 0; i < 4; i++)
            {
                tab[i] = rand.Next(1, 10);
            }

            switch (Sex)
            {
                case "Female":
                    Hair = SetPath(Hair,tab[0]);
                    Eyes = SetPath(Eyes,tab[1]);
                    Nose = SetPath(Nose,tab[2]);
                    Mouth = SetPath(Mouth,tab[3]);
                    break;
                case "Male":
                    Hair = SetPath(Hair,tab[0]);
                    Eyes = SetPath(Eyes,tab[1]);
                    Nose = SetPath(Nose,tab[2]);
                    Mouth = SetPath(Mouth,tab[3]);
                    break;
            }
        } // done

        public void IncreaseFaceElement(HeadElement el)
        {                 
                    switch(el)
                    {
                        case HeadElement.Hair:
                            Hair = IncreasePath(Hair);
                            break;
                        case HeadElement.Eyes:
                            Eyes = IncreasePath(Eyes);
                            break;
                        case HeadElement.Nose:
                            Nose = IncreasePath(Nose);
                            break;
                        case HeadElement.Mouth:
                            Mouth = IncreasePath(Mouth);
                            break;
                    }           
        } // done

        public void ReduceFaceElement(HeadElement el)
        {
            switch (el)
            {
                case HeadElement.Hair:
                    Hair = ReducePath(Hair);
                    break;
                case HeadElement.Eyes:
                    Eyes = ReducePath(Eyes);
                    break;
                case HeadElement.Nose:
                    Nose = ReducePath(Nose);
                    break;
                case HeadElement.Mouth:
                    Mouth = ReducePath(Mouth);
                    break;
            }
        }  // done

        public void RandSkills()
        {
            Life = 0;
            Strength = 0;
            Dexterity = 0;
            Intellect = 0;
            var rand = new Random();
            TotalSkills = 20;
            for(int i=0;i<20;i++)
            {
                switch(rand.Next(0, 4))
                {
                    case 0:
                        Life++;
                        break;
                    case 1:
                        Strength++;
                        break;
                    case 2:
                        Dexterity++;
                        break;
                    case 3:
                        Intellect++;
                        break;
                }
            }
            TotalSkills = 0;
        } // // done

        public void AddSkillPoint(SkillType skill)
        {
            TotalSkills = 20 - (Life + Strength + Dexterity + Intellect);
            if (TotalSkills > 0)
            {
                switch (skill)
                {
                    case SkillType.Life:
                        Life++;
                        TotalSkills--;
                        break;
                    case SkillType.Strength:
                        Strength++;
                        TotalSkills--;
                        break;
                    case SkillType.Dexterity:
                        Dexterity++;
                        TotalSkills--;
                        break;
                    case SkillType.Intellect:
                        Intellect++;
                        TotalSkills--;
                        break;
                }
            }
        }  // done (można przerobić na enum)

        public void SubstractSkillPoint(SkillType skill)
        {
            switch (skill)
            {
                case SkillType.Life:
                    if (Life > 0)
                    { 
                        Life--;
                        TotalSkills++;
                    }
                    break;
                case SkillType.Strength:
                    if (Strength > 0)
                    {
                        Strength--;
                        TotalSkills++;
                    }
                    break;
                case SkillType.Dexterity:
                    if (Dexterity > 0)
                    {
                        Dexterity--;
                        TotalSkills++;
                    }
                    break;
                case SkillType.Intellect:
                    if (Intellect > 0)
                    {
                        Intellect--;
                        TotalSkills++;
                    }
                    break;
            }
        } // done (można przerobić na enum)

        protected string IncreasePath(string word)
        {
            char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            string str;
            int index, tmp1, tmp2;

            do
            {
                str = word;
                index = str.IndexOfAny(numbers);
                tmp1 = str[index];
                if (tmp1 == 57)
                {
                    tmp2 = 49;
                }
                else
                {
                    tmp2 = tmp1 + 1;
                }
                word = str.Replace(Convert.ToChar(tmp1), Convert.ToChar(tmp2));
            } while (!File.Exists(word));

            return word;
        }
        protected string ReducePath(string word)
        {
            char[] numbers = { '0', '1', '2', '3', '4' , '5', '6', '7', '8', '9' };
            string str;
            int index, tmp1, tmp2;

            do
            {
                str = word;
                index = str.IndexOfAny(numbers);
                tmp1 = str[index];
                if (tmp1 == 49)
                {
                    tmp2 = 57;
                }
                else
                {
                    tmp2 = tmp1 - 1;
                }
                word = str.Replace(Convert.ToChar(tmp1), Convert.ToChar(tmp2));
            } while (!File.Exists(word));

            return word;
        }
        protected string SetPath(string word, int index)
        {
            char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            string str;
            int tmp, indx;
            str = word;
            indx = str.IndexOfAny(numbers);
            tmp = str[indx];
            word = str.Replace(Convert.ToChar(tmp), Convert.ToChar(index+48));

            while (!File.Exists(word))
            {
                word = ReducePath(word);
            }

            return word;
        }

    }
}
