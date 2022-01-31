﻿using System;
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
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;       
        }


        private void label2_Click(object sender, EventArgs e)
        {
            Logowanie log_in = new Logowanie();
            Hide();
            log_in.ShowDialog();
            Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Rejestracja rej_in = new Rejestracja();
            Hide();
            rej_in.ShowDialog();
            Close();
        }
    }
}
