using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using MySql.Data.MySqlClient;

namespace AirlineProjectIntel
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Error_Label.Text = "";
            bool valid = true;
            if(passwordText.Text != "" && passwordText.Text != null && usernameText.Text != "" && usernameText.Text != null ) {
                if(passwordText.Text == password2Text.Text)
                {
                    try
                    {
                        var connstr = "Server=sql5.freesqldatabase.com;Uid=sql5399694;Pwd=4k6zvHCLMV;database=sql5399694";
                        using (var conn = new MySqlConnection(connstr))
                        {
                            conn.Open();
                            Console.WriteLine("connected");
                            using (var cmd = conn.CreateCommand())
                            {
                                cmd.CommandText = "select * from passengers where username =\"" + usernameText.Text + "\"";
                                using (var reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        Console.WriteLine(reader[0].ToString() + " - (" + reader[1].ToString() + ")");
                                        if ((string)reader[3] == passwordText.Text)
                                        {
                                            Error_Label.Text = "Account already exists.";
                                            valid = false;
                                        }
                                    }
                                   
                                }
                                
                            }
                            // if no existing account, go ahead and add these credentials to db
                            if (valid)
                            {
                                using (var cmd = conn.CreateCommand())
                                {
                                    cmd.CommandText = String.Format("INSERT INTO passengers (username, password) VALUES (\"{0}\",\"{1}\")", usernameText.Text, passwordText.Text);
                                    cmd.ExecuteNonQuery();
                                    Error_Label.Text = "Account created, you may now return to login.";
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Error_Label.Text = "Error creating account.";
                    }
                } else
                {
                    Error_Label.Text = "Passwords don't match.";
                }
            } else
            {
                Error_Label.Text = "Missing fields";
            }
        }
    }
}
