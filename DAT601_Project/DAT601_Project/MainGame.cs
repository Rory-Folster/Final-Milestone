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
    public partial class MainGame : Form
    {

        public MainGame()
        {
            InitializeComponent();
        }

        private void pictureBox36_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                const string message =
                    "Are you sure that you would like to close the form?";
                const string caption = "Form Closing";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

                // If the yes button was pressed ...
                if (result == DialogResult.Yes)
                {
                    this.Close();
                    gameLobby f2 = new gameLobby();
                    f2.ShowDialog(); // Shows Form2

                }
            }
        }

        private void button1_Click(object sender, EventArgs e) //shows inventory
        {
            Inventory i1 = new Inventory();
            i1.ShowDialog();
        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox50_Click(object sender, EventArgs e)
        {

            
        }

        private void MainGame_Load(object sender, EventArgs e)
        {

        }
    }
}
