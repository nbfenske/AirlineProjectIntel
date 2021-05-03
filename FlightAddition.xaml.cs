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
using System.Windows.Navigation;
using System.Windows.Shapes;

using MySql.Data.MySqlClient;

namespace AirlineProjectIntel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FlightAddition : Window
    {
        private readonly FlightAdditionModel _model;
        private bool prev = false;
        private List<string> airports = new List<string>();
        public FlightAddition()
        {
            InitializeComponent();

            // make it so the user cannot resize the window
            this.ResizeMode = ResizeMode.NoResize;

            // create an instance of our Model
            _model = new FlightAdditionModel();

            //set data binding context to our model
            DataContext = _model;

            BrushConverter bc = new BrushConverter();
            menuBar.Fill = (Brush)bc.ConvertFrom("#36008D");
            // create an observable collection. this collection
            // contains the tiles the represent the *four* (two sides per seat type) seating sections
            MyItemsControl_FCRight.ItemsSource = _model.TileCollectionFCRight;
            MyItemsControl_FCLeft.ItemsSource = _model.TileCollectionFCLeft;

            MyItemsControl_ERight.ItemsSource = _model.TileCollectionERight;
            MyItemsControl_ELeft.ItemsSource = _model.TileCollectionELeft;
            sqlConnect();
        }

        public FlightAddition(int id, string admin): this()
        {
            _model.TitleText = "Flight #" + id.ToString() + " for " + "1/1/2021";
            _model.AdminIDText = admin;
        }

        public FlightAddition(string id, string admin) : this()
        {
            _model.AdminIDText = admin;
            prev = true; // let us know this window represents a previously made flight
            try
            {
                var connstr = "Server=sql5.freesqldatabase.com;Uid=sql5399694;Pwd=4k6zvHCLMV;database=sql5399694";
                using (var conn = new MySqlConnection(connstr))
                {
                    conn.Open();
                    Console.WriteLine("connected");
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from flights where FlightID = " + id;
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine(reader[0].ToString() + " - (" + reader[1].ToString() + ")");
                                _model.TitleText = "Flight #" + reader[0].ToString() + " for " + reader[1].ToString() + "/" + reader[2].ToString() + "/" + reader[3].ToString();

                                string[] t1 = reader[5].ToString().Split('-');
                                _model.DepTimeText = t1[0];
                                _model.DepTM = t1[1];
                                string[] t2 = reader[7].ToString().Split('-');
                                _model.ArrTimeText = t2[0];
                                _model.ArrTM = t2[1];

                                _model.FCNumText = reader[8].ToString();
                                _model.FCPriceText = reader[9].ToString();
                                _model.ENumText = reader[11].ToString();
                                _model.EPriceText = reader[12].ToString();
                                _model.resetCapacity();

                                airports.ForEach(delegate (string airport)
                                {
                                    if(airport.IndexOf(reader[4].ToString()) == 0)
                                    {
                                        _model.DepStopText = airport;
                                    }
                                    if(airport.IndexOf(reader[6].ToString()) == 0)
                                    {
                                        _model.ArrStopText = airport;
                                    }
                                });
                            }
                        }
                    }
                }
            } catch (Exception ex)
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

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            _model.ErrorLabelText = "";
            _model.resetCapacity();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FlightListAdmin f = new FlightListAdmin(_model.AdminIDText, true);
            f.Show();
            this.Close();
        }

        private void Upload_Click(object sender, RoutedEventArgs e)
        {
            _model.attemptUpload(prev);
        }

        private void sqlConnect()
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
                        cmd.CommandText = "select * from airports";
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine(reader[0].ToString() + " - (" + reader[1].ToString() + ")");
                                airports.Add(reader[0].ToString() + " - (" + reader[1].ToString() + ")");
                                DAirportBox.Items.Add(reader[0].ToString() + " - (" + reader[1].ToString() + ")");
                                AAirportBox.Items.Add(reader[0].ToString() + " - (" + reader[1].ToString() + ")");
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                _model.ErrorLabelText = e.ToString();
            }
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // ... Get DatePicker reference.
            var picker = sender as DatePicker;
            string[] temp = _model.TitleText.Split(new[] { " for " }, StringSplitOptions.None);
            // ... Get nullable DateTime from SelectedDate.
            DateTime? date = picker.SelectedDate;
            if (date != null)
            {
                // ... No need to display the time.
                _model.TitleText = temp[0] + " for " + date.Value.ToShortDateString();
            }
        }
    }
}
