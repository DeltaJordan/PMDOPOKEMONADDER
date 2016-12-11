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
            catch (MySqlException ex)
            {
                MessageBox.Show("There was an error with your query. Please check your internet connection and make sure you entered the info right.");
            }
            finally
            {
                if (conn != null)
                {
                    Connection = conn;
                    tbDBName.ReadOnly = true;
                    tbIP.ReadOnly = true;
                    tbPass.ReadOnly = true;
                    tbPort.ReadOnly = true;
                    tbUser.ReadOnly = true;
                    winInfoEntry = new PokeInfo(conn);
                    winInfoEntry.Show();
                    btnDisconnect.Show();
                }
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (winInfoEntry != null)
            {
                winInfoEntry.Close();
            }
            if (Connection != null)
            {
                Connection.Close();
            }

            tbDBName.ReadOnly = false;
            tbIP.ReadOnly = false;
            tbPass.ReadOnly = false;
            tbPort.ReadOnly = false;
            tbUser.ReadOnly = false;
            btnDisconnect.Hide();
        }
    }
}
