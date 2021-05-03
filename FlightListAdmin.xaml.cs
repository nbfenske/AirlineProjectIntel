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
    /// Interaction logic for FlightListAdmin.xaml
    /// </summary>
    /// 
    
    public partial class FlightListAdmin : Window
    {
        private bool isAdmin;
        private readonly AdminListModel _model;
        private int nextID = 0;
        public FlightListAdmin()
        {
            InitializeComponent();

            _model = new AdminListModel();
            
            BrushConverter bc = new BrushConverter();
            menuBar.Fill = (Brush)bc.ConvertFrom("#36008D");
            sqlConnect(true);
        }

        public FlightListAdmin(string id, bool admin) : this()
        {
            InitializeComponent();
            isAdmin = admin;
            if(!admin)
            {
                UserType.Text = "User: ";
                AddButton.Visibility = Visibility.Hidden;
                RemoveButton.Visibility = Visibility.Hidden;
            }
            AdminId.Text = id;
        }

        private void sqlConnect(bool normal)
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
                        string cmdText = "select * from flights";
                        
                        if(SearchDate.SelectedDate != null)
                        {
                            string[] t = SearchDate.SelectedDate.Value.ToShortDateString().Split('/');
                            if (OnRadio.IsChecked == true)
                            {
                                cmdText += " where M = " + t[0] + " and D = " + t[1] + " and Y = " + t[2];
                            } else if (AfterRadio.IsChecked == true)
                            {
                                cmdText += " where M >= " + t[0] + " and D >= " + t[1] + " and Y >= " + t[2];
                            }
                        }
                        if(ArrRadio.IsChecked == true)
                        {
                            cmdText += " order by ArrAirport";
                            if(Desc.IsChecked == true)
                            {
                                cmdText += " desc";
                            } else
                            {
                                cmdText += " asc";
                            }
                        } else if (DepRadio.IsChecked == true)
                        {
                            cmdText += " order by DepAirport";
                            if (Desc.IsChecked == true)
                            {
                                cmdText += " desc";
                            }
                            else
                            {
                                cmdText += " asc";
                            }
                        }
                        Console.WriteLine(cmdText);
                        if (normal)
                        {
                            cmd.CommandText = "select * from flights";
                        }
                        else
                        {
                            cmd.CommandText = cmdText;
                        }
                        using (var reader = cmd.ExecuteReader())
                        {
                            Flights.Items.Clear();
                            while (reader.Read())
                            {
                                
                                Console.WriteLine(reader[0].ToString() + " - (" + reader[1].ToString() + ")");
                                Flights.Items.Add("FID#" + reader[0] + ":  " + reader[1].ToString() + "/" + reader[2].ToString() + "/" + reader[3].ToString() + " - " + reader[4].ToString() + " to " + reader[6].ToString());
                                nextID = (int) reader[0] + 1;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                
            }
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            FlightAddition f = new FlightAddition(nextID, AdminId.Text);
            f.Show();
            this.Close();
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            sqlConnect(false);
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            sqlConnect(true);
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            if(Flights.SelectedItem != null)
            {
                Console.WriteLine(Flights.SelectedItem);
                string info = (string)Flights.SelectedItem;
                Console.WriteLine(info.Split('#')[1].Split(':')[0]);
                string id = info.Split('#')[1].Split(':')[0];
                if(isAdmin)
                {
                    FlightAddition f = new FlightAddition(id, AdminId.Text);
                    f.Show();
                } else
                {
                    FlightView f = new FlightView(id, AdminId.Text);
                    f.Show();
                }
                
                
                this.Close();
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            
            if(Flights.SelectedItem != null )
            {
                Console.WriteLine(Flights.SelectedItem);
                string info = (string)Flights.SelectedItem;
                Console.WriteLine(info.Split('#')[1].Split(':')[0]);
                string id = info.Split('#')[1].Split(':')[0];
                try
                {
                    var connstr = "Server=sql5.freesqldatabase.com;Uid=sql5399694;Pwd=4k6zvHCLMV;database=sql5399694";
                    using (var conn = new MySqlConnection(connstr))
                    {
                        conn.Open();
                        Console.WriteLine("connected");
                        using (var cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "DELETE FROM flights WHERE FlightID = " + id;
                            cmd.ExecuteNonQuery();
                            Flights.Items.Clear();
                            sqlConnect(false);
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            } else
            {

            }
        }
    }
}
