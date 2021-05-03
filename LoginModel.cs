using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// INotifyPropertyChanged
using System.ComponentModel;

using MySql.Data.MySqlClient;

namespace AirlineProjectIntel
{

    class LoginModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public LoginModel()
        {

        }

        public string checkCredentials()
        {
            if (UsernameText != null && PasswordText != null)
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
                            cmd.CommandText = "select * from passengers where username =\"" + UsernameText + "\"";
                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine(reader[0].ToString() + " - (" + reader[1].ToString() + ")");
                                    if((string) reader[3] == PasswordText)
                                    {
                                        
                                        return "#" + reader[1].ToString();
                                    }
                                }
                                return "No account associated with username/password.";
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    return "Error validating credentials";
                }
            }
            return "Blank username and/or password.";
        }
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private String _usernameText;
        public String UsernameText
        {
            get { return _usernameText; }
            set
            {
                _usernameText = value;
                OnPropertyChanged("UsernameText");
            }
        }

        private String _passwordText;
        public String PasswordText
        {
            get { return _passwordText; }
            set
            {
                _passwordText = value;
                OnPropertyChanged("PasswordText");
            }
        }

        private String _errorLabelText;
        public String ErrorLabelText
        {
            get { return _errorLabelText; }
            set
            {
                _errorLabelText = value;
                OnPropertyChanged("ErrorLabelText");
            }
        }
    }
}
