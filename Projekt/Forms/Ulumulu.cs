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
    public partial class Ulumulu : Form
    {
        protected Character character;

        public Ulumulu()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }
        public Ulumulu(Character character)
        {
            InitializeComponent();            
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.character = character;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tworzenie_3 dalej = new Tworzenie_3(character);
            Hide();
            dalej.ShowDialog();
            Close();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Tworzenie_1 powrot = new Tworzenie_1(character);
            Hide();
            powrot.ShowDialog();
            Close();
        }
    }
}
