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

namespace DAT601_Project
{
    public partial class gameLobby : Form
    {
        MySqlConnection connBuilderGL = new MySqlConnection("database=datassessment;datasource=localhost;username=root;password=Rorukz123");
        MySqlDataAdapter adapterLogin;
        DataTable tableLogin = new DataTable();

        public gameLobby()
        {
            InitializeComponent();
        }

        private void listBox2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            adapterLogin = new MySqlDataAdapter("CALL retrieveOnline()", connBuilderGL);
            adapterLogin.Fill(tableLogin);
            gameLobbyTxtBox1.DataSource = tableLogin;
            gameLobbyTxtBox1.DisplayMember = "PlayerID";
            gameLobbyTxtBox1.DisplayMember = "PlayerName";
            gameLobbyTxtBox1.ValueMember = "playerLocation";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            MainGame g1 = new MainGame();
            g1.ShowDialog(); // Shows Form2
        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                {
                    const string message =
                        "Are you sure that you would like to close the game?";
                    const string caption = "Exiting Game";
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

                    
                    if (result == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            adminControl a1 = new adminControl();
                a1.ShowDialog();
        }   

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
