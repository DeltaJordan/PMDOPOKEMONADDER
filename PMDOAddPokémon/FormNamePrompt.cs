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
    public partial class FormNamePrompt : Form
    {
        public string Result;
        public bool useForAll;

        public FormNamePrompt(int FormNumber)
        {
            InitializeComponent();

            label1.Text = label1.Text.Replace("0", FormNumber.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Result = tbFormName.Text;
            useForAll = checkBox1.Checked;
        }
    }
}
