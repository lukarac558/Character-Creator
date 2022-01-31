using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Projekt
{
    public class DateT
    {
        public static int userId = -1;

        private readonly static string connectionString = "Server=localhost;Port=3306;Database=kreatorpostaci;" +
            "Uid=root;TreatTinyAsBoolean=false;Connection Timeout = 120";    
        private DateT() { }

        private static DateT instance;

        public static DateT GetInstance()
        {
            if (instance == null)
            {
                instance = new DateT();
            }
            return instance;
        }

        protected static string GenerateMd5Hash(string input)
        {
            var x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            var computeHash = Encoding.UTF8.GetBytes(input);
            computeHash = x.ComputeHash(computeHash);
            var stringBuilder = new StringBuilder();
            foreach (var itme in computeHash)
            {
                stringBuilder.Append(itme.ToString("x2").ToLower());
            }
            return stringBuilder.ToString();
        }
        public static void Login(string login, string password)
        {
                var conn = new MySqlConnection(connectionString);
                conn.Open();

                string zapytanie = "SELECT Id FROM logreg WHERE Login='" + login + "' AND Password='" + GenerateMd5Hash(password) + "'";
                MySqlCommand mySqlCommand = new MySqlCommand(zapytanie, conn);
                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                reader.Read();

                if (Convert.ToInt32(reader[0].ToString()) < 0)
                {
                    MessageBox.Show("Niepoprawny login lub hasło.");
                    return;
                }
                else
                    userId = Convert.ToInt32(reader[0].ToString());

                conn.Close();
        }

        public static List<Character> Load()
        {
            try
            {
                var characterList = new List<Character>();
                string zapytanie;
                var conn = new MySqlConnection(connectionString);
                MySqlCommand mySqlCommand1;
                MySqlDataReader reader;
                var listaCharacte = new List<Character>();
                conn.Open();

                if (userId == -1)
                    throw new Exception("Nie zalogowano do zadnego konta");

                zapytanie = "SELECT COUNT(Id_Person) FROM person WHERE Id_User=" + userId;
                mySqlCommand1 = new MySqlCommand(zapytanie, conn);
                reader = mySqlCommand1.ExecuteReader();
                reader.Read();   // sprawdzenie ile osoba posiada postaci 
                int count_person = Int32.Parse(reader[0].ToString());
                reader.Close();
                string za = "SELECT Character_Name FROM person WHERE Id_User=" + userId;
                mySqlCommand1 = new MySqlCommand(za, conn);
                reader = mySqlCommand1.ExecuteReader();

                string[] pomocnicza = new string[count_person];
                for (int j = 0; j < count_person; j++)
                {
                    reader.Read();
                    pomocnicza[j] = reader[0].ToString();
                }

                reader.Close();
                zapytanie = "SELECT Nick,Sex,Race,Life,Strength,Dexterity,Intellect" +
                            ",Path1,Path2,Path3,Path4,Path5,Path6,Path7,Path8,Path9,Path10 FROM person WHERE Id_User=" + userId;
                var mySqlCommand = new MySqlCommand(zapytanie, conn);

                MySqlDataReader mySqlData = mySqlCommand.ExecuteReader();
                for (int i = 0; i < count_person; i++)
                {
                    mySqlData.Read();

                    if (pomocnicza[i] == "Warrior")
                    {
                        var PWa = new Warrior
                        {
                            Nick = mySqlData[0].ToString(),
                            Sex = mySqlData[1].ToString(),
                            Race = mySqlData[2].ToString(),
                            Life = Int32.Parse(mySqlData[3].ToString()),
                            Strength = Int32.Parse(mySqlData[4].ToString()),
                            Dexterity = Int32.Parse(mySqlData[5].ToString()),
                            Intellect = Int32.Parse(mySqlData[6].ToString()),
                            Helm = mySqlData[7].ToString(),
                            Club = mySqlData[8].ToString(),
                            HeavyArmor = mySqlData[9].ToString(),
                            Boots = mySqlData[10].ToString(),
                            Hair = mySqlData[11].ToString(),
                            Eyes = mySqlData[12].ToString(),
                            Nose = mySqlData[13].ToString(),
                            Mouth = mySqlData[14].ToString(),
                            Body = mySqlData[15].ToString(),
                            Head = mySqlData[16].ToString(),
                            Id = userId
                        };

                        characterList.Add(PWa);
                    }

                    if (pomocnicza[i] == "Magician")
                    {
                        var PMag = new Magician
                        {
                            Nick = mySqlData[0].ToString(),
                            Sex = (mySqlData[1].ToString()),
                            Race = mySqlData[2].ToString(),
                            Life = Int32.Parse(mySqlData[3].ToString()),
                            Strength = Int32.Parse(mySqlData[4].ToString()),
                            Dexterity = Int32.Parse(mySqlData[5].ToString()),
                            Intellect = Int32.Parse(mySqlData[6].ToString()),
                            Hat = mySqlData[7].ToString(),
                            Wand = mySqlData[8].ToString(),
                            Robe = mySqlData[9].ToString(),
                            MagicShoes = mySqlData[10].ToString(),
                            Hair = mySqlData[11].ToString(),
                            Eyes = mySqlData[12].ToString(),
                            Nose = mySqlData[13].ToString(),
                            Mouth = mySqlData[14].ToString(),
                            Body = mySqlData[15].ToString(),
                            Head = mySqlData[16].ToString(),
                            Id = userId
                        };

                        characterList.Add(PMag);
                    }

                    if (pomocnicza[i] == "Archer")
                    {
                        var PArcher = new Archer
                        {
                            Nick = mySqlData[0].ToString(),
                            Sex = mySqlData[1].ToString(),
                            Race = mySqlData[2].ToString(),
                            Life = Int32.Parse(mySqlData[3].ToString()),
                            Strength = Int32.Parse(mySqlData[4].ToString()),
                            Dexterity = Int32.Parse(mySqlData[5].ToString()),
                            Intellect = Int32.Parse(mySqlData[6].ToString()),
                            Cap = mySqlData[7].ToString(),
                            Arch = mySqlData[8].ToString(),
                            LightArmor = mySqlData[9].ToString(),
                            LightShoes = mySqlData[10].ToString(),
                            Hair = mySqlData[11].ToString(),
                            Eyes = mySqlData[12].ToString(),
                            Nose = mySqlData[13].ToString(),
                            Mouth = mySqlData[14].ToString(),
                            Body = mySqlData[15].ToString(),
                            Head = mySqlData[16].ToString(),
                            Id = userId
                        };

                        characterList.Add(PArcher);
                    }
                }
                reader.Close();
                conn.Close();

                return characterList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            var lista = new List<Character>();
            return lista;
        }

        public static void Register(string login, string password)
        {
            var conn = new MySqlConnection(connectionString);
            try
            {               
                conn.Open();
                string zapytanie = "SELECT COUNT(logreg.Id) FROM logreg WHERE Login='" + login + "'";
                MySqlCommand mySqlCommand = new MySqlCommand(zapytanie, conn);
                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                reader.Read();
                string zmienna = reader[0].ToString();

                if (Int32.Parse(zmienna) != 0)
                {
                    MessageBox.Show("Istnieje konto ");
                    return;
                }
                reader.Close();

                zapytanie = "INSERT INTO logreg (Login,Password) VALUES ('" + login + "','" + GenerateMd5Hash(password) + "')";
                mySqlCommand = new MySqlCommand(zapytanie, conn);
                reader = mySqlCommand.ExecuteReader();
                reader.Read();
                reader.Close();

                zapytanie = "SELECT Id FROM logreg WHERE Login='" + login + "' AND Password='" + GenerateMd5Hash(password) + "'";
                mySqlCommand = new MySqlCommand(zapytanie, conn);
                reader = mySqlCommand.ExecuteReader();
                reader.Read();
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public static void AddPerson(Character p1)
        {
            string zapytanie;

            try
            {
                var conn = new MySqlConnection(connectionString);
                MySqlCommand mySqlCommand;
                MySqlDataReader reader;
                conn.Open();

                if (p1 is Archer)
                {
                    zapytanie = "INSERT INTO person (Id_User,Nick,Character_Name,Sex,Race,Life,Strength,Dexterity,Intellect," +
                    "Path1,Path2,Path3,Path4,Path5,Path6,Path7,Path8,Path9,Path10) VALUES (" + userId + ",'" + p1.Nick +
                    "','" + "Archer" + "','" + p1.Sex + "','" + p1.Race + "'," + p1.Life + "," + p1.Strength + "," + p1.Dexterity + "," +
                    p1.Intellect + ",'" + (p1 as Archer).Cap + "','" + (p1 as Archer).Arch + "','" + (p1 as Archer).LightArmor + "','" +
                    (p1 as Archer).LightShoes + "','" + (p1 as Archer).Hair + "','" + (p1 as Archer).Eyes + "','" + (p1 as Archer).Nose + "','" +
                    (p1 as Archer).Mouth + "','" + (p1 as Archer).Body + "','" + (p1 as Archer).Head + "')";

                    mySqlCommand = new MySqlCommand(zapytanie, conn);
                    reader = mySqlCommand.ExecuteReader();
                    reader.Read();
                    reader.Close();
                }
                if (p1 is Warrior)
                {
                    zapytanie = "INSERT INTO person (Id_User,Nick,Character_Name,Sex,Race,Life,Strength,Dexterity,Intellect," +
                     "Path1,Path2,Path3,Path4,Path5,Path6,Path7,Path8,Path9,Path10) VALUES (" + userId + ",'" + p1.Nick +
                     "','" + "Warrior" + "','" + p1.Sex + "','" + p1.Race + "'," + p1.Life + "," + p1.Strength + "," + p1.Dexterity + "," +
                     p1.Intellect + ",'" + (p1 as Warrior).Helm + "','" + (p1 as Warrior).Club + "','" + (p1 as Warrior).HeavyArmor + "','" +
                     (p1 as Warrior).Boots + "','" + (p1 as Warrior).Hair + "','" + (p1 as Warrior).Eyes + "','" + (p1 as Warrior).Nose + "','" +
                     (p1 as Warrior).Mouth + "','" + (p1 as Warrior).Body + "','" + (p1 as Warrior).Head + "')";

                    mySqlCommand = new MySqlCommand(zapytanie, conn);
                    reader = mySqlCommand.ExecuteReader();
                    reader.Read();
                    reader.Close();
                }
                if (p1 is Magician)
                {
                    zapytanie = "INSERT INTO person (Id_User,Nick,Character_Name,Sex,Race,Life,Strength,Dexterity,Intellect," +
                    "Path1,Path2,Path3,Path4,Path5,Path6,Path7,Path8,Path9,Path10) VALUES (" + userId + ",'" + p1.Nick +
                    "','" + "Magician" + "','" + p1.Sex + "','" + p1.Race + "'," + p1.Life + "," + p1.Strength + "," + p1.Dexterity + "," +
                    p1.Intellect + ",'" + (p1 as Magician).Hat + "','" + (p1 as Magician).Wand + "','" + (p1 as Magician).Robe + "','" +
                    (p1 as Magician).MagicShoes + "','" + (p1 as Magician).Hair + "','" + (p1 as Magician).Eyes + "','" + (p1 as Magician).Nose + "','" +
                    (p1 as Magician).Mouth + "','" + (p1 as Magician).Body + "','" + (p1 as Magician).Head + "')";

                    mySqlCommand = new MySqlCommand(zapytanie, conn);
                    reader = mySqlCommand.ExecuteReader();
                    reader.Read();
                    reader.Close();
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public static bool IfExists(string login)
        {
            try
            {
                int zmienna;
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                string zapytanie = "SELECT COUNT(Login) FROM logreg WHERE Login='" + login + "'";
                MySqlCommand mySqlCommand = new MySqlCommand(zapytanie, conn);
                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                reader.Read();
                zmienna = Convert.ToInt32(reader[0].ToString());
                reader.Close();
                conn.Close();

                if (zmienna == 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return false;
        }      

        public static void LogOut()
        {
            userId = -1;
        }
        public static void DeletePerson(Character p1)
        {
            try
            {
                var conn = new MySqlConnection(connectionString);
                conn.Open();
                string zapytanie;
                MySqlCommand mySqlCommand;
                MySqlDataReader reader;

                zapytanie = "DELETE FROM person WHERE Nick='" + p1.Nick + "'";
                mySqlCommand = new MySqlCommand(zapytanie, conn);
                reader = mySqlCommand.ExecuteReader();
                reader.Read();
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static bool NickFree(string nick)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();

                string zapytanie = "SELECT COUNT(Nick) FROM person WHERE Nick='" + nick + "'";
                MySqlCommand mySqlCommand = new MySqlCommand(zapytanie, conn);
                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                reader.Read();
                conn.Close();

                if (Convert.ToInt32(reader[0].ToString()) != 0)
                {
                    MessageBox.Show("Podana Nazwa Postaci juz istnieje ");
                    return false;
                }
                else
                    return true;               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return true;
        }
    }
}