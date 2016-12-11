using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMDOAddPokémon
{
    public partial class MoveLevelPrompt : Form
    {
        public int Result;
        public MoveLevelPrompt(string PokeName, string MoveName)
        {
            InitializeComponent();

            label1.Text = label1.Text.Replace("POKE", PokeName).Replace("MOVE", MoveName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Result = (int)numericUpDown1.Value;
        }
    }
}
