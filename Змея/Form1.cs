using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Змея
{
    public partial class Form1 : Form
    {
        Game game;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            game?.Stop();
            game = new Game(this);
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            game?.Sendkey(e.KeyCode);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            game?.Stop();
        }
    }
}
