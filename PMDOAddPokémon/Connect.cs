using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PMDOAddPokémon
{
    public partial class Connect : Form
    {

        MySqlConnection Connection = null;
        PokeInfo winInfoEntry;

        public Connect()
        {
            InitializeComponent();
#if DEBUG

            tbUser.Text = "root";
            tbPass.Text = "1234";
            button2.Visible = true;

#endif



        }

        private void AddPoke_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = @"server=" + tbIP.Text + @";userid=" + tbUser.Text + @";
            password=" + tbPass.Text + @";database=" + tbDBName.Text;

            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string stm = "SELECT VERSION()";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                string version = Convert.ToString(cmd.ExecuteScalar());
                Console.WriteLine("MySQL version : {0}", version);

            }

            catch
            {
                MessageBox.Show("There was an error with your query. Please check your internet connection and make sure you entered the info right.");
                return;
            }

            finally
            {
                if (conn != null)
                {
                    conn.Close();
                    Connection = conn;
                    tbDBName.ReadOnly = true;
                    tbIP.ReadOnly = true;
                    tbPass.ReadOnly = true;
                    tbPort.ReadOnly = true;
                    tbUser.ReadOnly = true;
                    winInfoEntry = new PokeInfo(conn);
                    winInfoEntry.Show();
                }
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (winInfoEntry != null)
            {
                winInfoEntry.Close();
            }

            tbDBName.ReadOnly = false;
            tbIP.ReadOnly = false;
            tbPass.ReadOnly = false;
            tbPort.ReadOnly = false;
            tbUser.ReadOnly = false;
            btnDisconnect.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Connection != null)
            {
                MySqlConnection conn = Connection;
                string badValue = ((char)0x0022).ToString();
                for (int i = 0; i < 6; i++)
                {
                    badValue += badValue;
                }
                string id = badValue + "dicks/*! 0/0";
                string pass = "*/ ";
                id = id.Replace("\'", "\'\'");
                id = id.Replace("\\", "");
                string stm = "SELECT * FROM `title` WHERE id = '" + id + "' AND message = '" + pass + "'";
                MessageBox.Show(stm);
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
