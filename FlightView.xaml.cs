﻿using System;
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
    /// Interaction logic for FlightView.xaml
    /// </summary>
    public partial class FlightView : Window
    {
        private string lastSelected;
        private readonly FlightAdditionModel _model;
        private bool prev = false;
        private List<string> airports = new List<string>();
        public FlightView()
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
            
        }

        public FlightView(string id, string admin) : this()
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
                    string a = "";
                    string b = "";
                    using (var cmd = conn.CreateCommand())
                    {
                        
                        cmd.CommandText = "select * from flights where FlightID = " + id;
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine(reader[0].ToString() + " - (" + reader[1].ToString() + ")");
                                _model.TitleText = "Flight #" + reader[0].ToString() + " for " + reader[1].ToString() + "/" + reader[2].ToString() + "/" + reader[3].ToString();

                                //string[] t1 = reader[5].ToString().Split('-');
                                _model.DepTimeText = reader[5].ToString();
                                //_model.DepTM = t1[1];
                                //string[] t2 = reader[7].ToString().Split('-');
                                _model.ArrTimeText = reader[7].ToString();
                                //_model.ArrTM = t2[1];

                                _model.FCNumText = reader[8].ToString();
                                _model.FCPriceText = reader[9].ToString();
                                _model.ENumText = reader[11].ToString();
                                _model.EPriceText = reader[12].ToString();
                                a = reader[10].ToString();
                                b = reader[13].ToString();
                                
                                _model.DepStopText = reader[4].ToString();
                                _model.ArrStopText = reader[6].ToString();
                                
                            }
                        }
                    }
                    _model.getSeatingChart(a.Split(','), b.Split(','));
                }

            }
            catch (Exception ex)
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

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FlightListAdmin f = new FlightListAdmin(_model.AdminIDText, false);
            f.Show();
            this.Close();
        }

        private void Reserve_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(lastSelected);
            _model.attemptReservation(lastSelected, false);
        }
        private void Seat_Click(object sender, RoutedEventArgs e)
        {
            var selectedButton = e.OriginalSource as FrameworkElement;
            if (selectedButton != null)
            {
                var currentTile = selectedButton.DataContext as Tile;
                Console.WriteLine(currentTile.TileName);
                if (_model.attemptReservation(currentTile.TileName, true))
                {
                    if (currentTile.TileBrush == Brushes.White)
                    {
                        currentTile.TileBrush = Brushes.Red;
                    }
                    else if (currentTile.TileBrush == Brushes.Red)
                    {
                        currentTile.TileBrush = Brushes.White;
                    }
                }
                lastSelected = currentTile.TileName;


            }
        }
    }
}
