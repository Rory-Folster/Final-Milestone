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

    public partial class welcomeScreen : Form
    {
        public static gameLobby openGL;
        private bool usernameCorrect = true;

        public welcomeScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder connBuilderLogin = new MySqlConnectionStringBuilder();
            connBuilderLogin.Add("Database", "datassessment");
            connBuilderLogin.Add("Data Source", "localhost");
            connBuilderLogin.Add("User Id", "root");
            connBuilderLogin.Add("Password", "Rorukz123");

            if (usernameCorrect) { 
            string _username = textBox3.Text;
            string userExist = "Username exists. Please enter your password.";
            string userNoExist = "Username was not found in the database. \n Would you like to create an account?";
            string caption1 = "Username was found";
            string caption2 = "Username was not found";

            string checkUsername = "CALL checkUsername(@username)";


                using (MySqlConnection connection = new MySqlConnection(connBuilderLogin.ConnectionString))
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(checkUsername, connection))
                    {
                        cmd.Parameters.AddWithValue("@Username", _username);
                        var result = Convert.ToInt32(cmd.ExecuteScalar());
                        if (result > 0)
                        {
                            var userResult1 = MessageBox.Show(userExist, caption1, MessageBoxButtons.OK, MessageBoxIcon.Information); //If username was found
                            if (userResult1 == DialogResult.OK)
                            {
                                textBox4.Visible = true;
                                label4.Visible = true;
                                usernameCorrect = false;
                            }

                        }
                        else
                        {
                            var userResult2 = MessageBox.Show(userNoExist, caption2, MessageBoxButtons.YesNo, MessageBoxIcon.Information); //If username was not found
                            if (userResult2 == DialogResult.Yes)
                            {
                                welcomeScreen mainForm = new welcomeScreen();
                                mainForm.Close();
                                Registration _registration = new Registration();
                                _registration.ShowDialog();

                            }
                            textBox3.Clear();
                        }
                    }
                    connection.Close();
                }
            }
            else if (!usernameCorrect)
            {
                string caption3 = "Password was correct";
                string caption4 = "Password was incorrect";
                string _password = textBox4.Text;
            string checkPassword = "CALL checkPassword(@password)";
            string passwordCorrect = "The password you entered was correct. \n You will now be taken to the game lobby.";
            string passwordIncorrect = "The password you have entered was incorrect, please try again.";

                using (MySqlConnection connection = new MySqlConnection(connBuilderLogin.ConnectionString))
                {
                    connection.Open();
                    using (MySqlCommand cmd1 = new MySqlCommand(checkPassword, connection))
                    {
                        cmd1.Parameters.AddWithValue("@password", _password);
                        var result1 = Convert.ToInt32(cmd1.ExecuteScalar());
                        if (result1 > 0)
                        {
                            var passResult1 = MessageBox.Show(passwordCorrect, caption3, MessageBoxButtons.OK, MessageBoxIcon.Information); //password was correct
                            if (passResult1 == DialogResult.OK)
                            {
                                welcomeScreen.openGL = new gameLobby();
                                openGL.ShowDialog();

                                this.Hide();
                            }

                        }
                        else
                        {
                            var passResult2 = MessageBox.Show(passwordIncorrect, caption4, MessageBoxButtons.OK, MessageBoxIcon.Information); //password was incorrect
                            if (passResult2 == DialogResult.OK)
                            {
                                textBox4.Clear();
                            }
                        }
                    }
                    connection.Close();
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
          

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void welcomeScreen_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
    }

