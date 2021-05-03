using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

// INotifyPropertyChanged
using System.ComponentModel;

using MySql.Data.MySqlClient;

namespace AirlineProjectIntel
{
    class FlightAdditionModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Tile> TileCollectionFCRight;
        public ObservableCollection<Tile> TileCollectionFCLeft;
        private int _numTilesFCRight = 6;
        private int _numTilesFCLeft = 6;
        public ObservableCollection<Tile> TileCollectionERight;
        public ObservableCollection<Tile> TileCollectionELeft;
        private int _numTilesERight = 6;
        private int _numTilesELeft = 6;

        public FlightAdditionModel()
        {
            TileCollectionFCRight = new ObservableCollection<Tile>();
            TileCollectionFCLeft = new ObservableCollection<Tile>();
            TileCollectionERight = new ObservableCollection<Tile>();
            TileCollectionELeft = new ObservableCollection<Tile>();
            resetCapacity();
        }

        public void attemptUpload(bool prev)
        {
            ErrorLabelText = "";
            // these will temporarily store data while we parse for errors
            // we retrieve the data when we are ready for an insert request to the db
            List<string> times = new List<string>();
            List<string> stops = new List<string>();
            List<float> seatInfo = new List<float>();
            List<string> mainInfo = new List<string>();
            // see if we have valid data first, empty lists will show us if we had errors
            getTimes(times);
            getStops(stops);
            getSeatInfo(seatInfo);
            parseTitle(mainInfo);
            /*Console.WriteLine("times:");
            times.ForEach(Console.WriteLine);
            Console.WriteLine("stops:");
            stops.ForEach(Console.WriteLine);
            Console.WriteLine("seating:");
            seatInfo.ForEach(Console.WriteLine);
            Console.WriteLine("flight info:");
            mainInfo.ForEach(Console.WriteLine);*/
            resetCapacity(); // reset seating visualization for visual confirmation

            if(times.Count > 0 && stops.Count > 0 && seatInfo.Count > 0 && mainInfo.Count > 0)
            {
                string[] fc = Enumerable.Repeat("x", Convert.ToInt32(seatInfo[0])).ToArray();
                string[] ec = Enumerable.Repeat("x", Convert.ToInt32(seatInfo[2])).ToArray();
                try
                {
                    var connstr = "Server=sql5.freesqldatabase.com;Uid=sql5399694;Pwd=4k6zvHCLMV;database=sql5399694";
                    using (var conn = new MySqlConnection(connstr))
                    {
                        conn.Open();
                        Console.WriteLine("connected");
                        using (var cmd = conn.CreateCommand())
                        {
                            if(prev)
                            {
                                cmd.CommandText = "UPDATE flights SET M = \"" + mainInfo[1] + "\", D = \"" + mainInfo[2] + "\", Y = \"" + mainInfo[3] + "\", DepAirport = \"" + stops[0] + "\", DepTime = \"" + times[0] + "-" + DepTM + "\", ArrAirport = \"" + stops[1] + "\", ArrTime = \"" + times[1] + "-" + ArrTM + "\", FCNum = \"" + Convert.ToInt32(seatInfo[0]) + "\", FCPrice = \"" + seatInfo[1] + "\", FCSeats = \"" + String.Join(",", fc) + "\", ENum = \"" + Convert.ToInt32(seatInfo[2]) + "\", EPrice = \"" + seatInfo[3] + "\", ESeats = \"" + String.Join(",", ec) + "\" WHERE FlightID = \"" + mainInfo[0] + "\"";
                            }
                            else
                            {
                                cmd.CommandText = String.Format("INSERT INTO flights (M, D, Y, DepAirport, DepTime, ArrAirport, ArrTime, FCNum, FCPrice, FCSeats, ENum, EPrice, ESeats) VALUES (\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\",\"{12}\")", mainInfo[1], mainInfo[2], mainInfo[3], stops[0], times[0] + "-" + DepTM, stops[1], times[1] + "-" + ArrTM, Convert.ToInt32(seatInfo[0]), seatInfo[1], String.Join(",", fc), Convert.ToInt32(seatInfo[2]), seatInfo[3], String.Join(",", ec));
                            }
                            cmd.ExecuteNonQuery();
                            ErrorLabelText = "Successfully uploaded flight #" + mainInfo[0];
                        }
                    }
                }
                catch (Exception e)
                {
                    ErrorLabelText = "Upload Error.";
                }
            }
        }

        private void getSeatInfo(List<float> lst)
        {

            try
            {
                bool error = false;

                if (FCNumText == null)
                {
                    lst.Add(0);
                    FCNumText = "0";
                }
                else
                {
                    lst.Add(float.Parse(FCNumText));
                }
                if (FCPriceText == null)
                {
                    if (FCNumText != "0")
                    {
                        error = true;
                    }
                    else
                    {
                        lst.Add(0);
                        FCPriceText = "0";
                    }
                }
                else
                {
                    lst.Add(float.Parse(FCPriceText));
                }

                if (ENumText == null)
                {
                    lst.Add(0);
                    ENumText = "0";
                }
                else
                {
                    lst.Add(float.Parse(ENumText));
                }
                if (EPriceText == null)
                {
                    if (ENumText != "0")
                    {
                        error = true;
                        
                    }
                    else
                    {
                        lst.Add(0);
                        EPriceText = "0";
                    }
                }
                else
                {
                    
                    lst.Add(float.Parse(EPriceText));
                }
                if (error) // entry error
                {
                    ErrorLabelText += "Enter a price for seating. Specify 0 if you wish to charge $0.\n";
                    lst.Clear(); // we will use an empty list to show an error during collection
                }
            }
            catch // parse error
            {
                ErrorLabelText += "Invalid seating data.\n";
                lst.Clear();
            }
        }

        private void getStops(List<string> lst)
        {
            if(DepStopText != null && ArrStopText != null)
            {
                if(DepStopText != ArrStopText)
                {
                    lst.Add(DepStopText.Split('-')[0]);
                    lst.Add(ArrStopText.Split('-')[0]);
                    lst.ForEach(Console.WriteLine);
                } else
                {
                    ErrorLabelText += "Cannot have trip to/from same airport.\n";
                }
            } else
            {
                ErrorLabelText += "Set an departure and arrive destination.\n";
            }
        }

        private void getTimes(List<string> lst)
        {
            if(DepTimeText != null && ArrTimeText != null)
            {
                try
                {
                    List<int> dep = DepTimeText.Split(':').Select(Int32.Parse).ToList();
                    List<int> arr = ArrTimeText.Split(':').Select(Int32.Parse).ToList();
                    
                    if (dep.Count > 2 || arr.Count > 2)
                    {
                        ErrorLabelText += "Time needs to be entered in form (hours:minutes).\n";
                        
                    } else
                    {
                        lst.Add(DepTimeText);
                        lst.Add(ArrTimeText);
                    }
                }
                catch (Exception e)
                {
                    ErrorLabelText += "Time needs to be entered in form (hours:minutes).\n";
                    lst.Clear();
                }
            } else
            {
                ErrorLabelText += "Arrival/departure time needs to be entered.\n";
            }
        }

        private void parseTitle(List<string> lst)
        {
            try
            {
                string temp = TitleText;
                string[] t = temp.Split(new[] { " for " }, StringSplitOptions.None);
                List<string> date = t[1].Split('/').ToList();
                lst.Add(t[0].Split('#')[1]);
                date.ForEach(lst.Add);
            } catch (Exception e)
            {
                ErrorLabelText = "Critical Title Error. Exit and Retry"; // should not be possible to have a bad parse here, use cannot set title explicitly
            }
            

        }

        public void resetCapacity()
        {
            int fcCapacity;
            int eCapacity;
            
            try
            {
                if(FCNumText == null)
                {
                    fcCapacity = 0;
                    FCNumText = "0";
                } else
                {
                    fcCapacity = int.Parse(FCNumText);
                }
                if(ENumText == null)
                {
                    eCapacity = 0;
                    ENumText = "0";
                } else
                {
                    eCapacity = int.Parse(ENumText);
                }

                if(fcCapacity >= 0 && eCapacity >= 0)
                {
                    int totalCapacity = fcCapacity + eCapacity;
                    CapacityText = totalCapacity.ToString();
                    resetSeating(fcCapacity, _numTilesFCLeft, _numTilesFCRight, TileCollectionFCLeft, TileCollectionFCRight);
                    resetSeating(eCapacity, _numTilesELeft, _numTilesERight, TileCollectionELeft, TileCollectionERight);
                } else
                {
                    ErrorLabelText += "Negative seating not allowed.\n";
                }
            } catch (Exception e) {
                ErrorLabelText += "Enter a *whole* number for the seating capacity value(s).\n";
            }
            
            
        }
        private void resetSeating(int capacity, int left, int right, ObservableCollection<Tile> lCollection, ObservableCollection<Tile> rCollection)
        {
            left = 0;
            right = 0;
            while (capacity / 6 >= 1)
            {
                left += 3;
                right += 3;
                capacity -= 6;
            }
            if (capacity > 3)
            {
                left += 3;
                right += (capacity % 3);
            }
            else
            {
                left += capacity;
            }

            rCollection.Clear();
            lCollection.Clear();
            for (int i = 0; i < right; i++)
            {
                rCollection.Add(new Tile() { TileBrush = Brushes.Black, TileLabel = "", TileName = i.ToString() });
            }
            for (int i = 0; i < left; i++)
            {
                lCollection.Add(new Tile() { TileBrush = Brushes.Black, TileLabel = "", TileName = i.ToString() });
            }
        }

        public void getSeatingChart(string[] fcSeating, string[] eSeating)
        {
            TileCollectionFCLeft.Clear();
            TileCollectionFCRight.Clear();
            TileCollectionELeft.Clear();
            TileCollectionERight.Clear();

            ObservableCollection<Tile> temp = TileCollectionFCLeft;
            int count = 0;
            for (int i = 0; i < fcSeating.Length; i++)
            {
                Console.WriteLine(fcSeating[i] == "x");
                if(fcSeating[i] == "x")
                {
                    temp.Add(new Tile() { TileBrush = Brushes.White, TileLabel = "", TileName = "F" + i.ToString() });
                }
                else if (eSeating[i] == AdminIDText)
                {
                    temp.Add(new Tile() { TileBrush = Brushes.Red, TileLabel = "", TileName = "E" + i.ToString() });
                } else
                {
                    temp.Add(new Tile() { TileBrush = Brushes.Black, TileLabel = "", TileName = "F" + i.ToString() });
                }
                count++;
                if(count == 3)
                {
                    if(temp == TileCollectionFCLeft)
                    {
                        temp = TileCollectionFCRight;
                    } else
                    {
                        temp = TileCollectionFCLeft;
                    }
                    count = 0;
                }
            }

            temp = TileCollectionELeft;
            count = 0;
            for (int i = 0; i < eSeating.Length; i++)
            {
                Console.WriteLine(eSeating[i]);
                if (eSeating[i] == "x")
                {
                    temp.Add(new Tile() { TileBrush = Brushes.White, TileLabel = "", TileName = "E" + i.ToString() });
                }
                else if (eSeating[i] == AdminIDText)
                {
                    temp.Add(new Tile() { TileBrush = Brushes.Red, TileLabel = "", TileName = "E" + i.ToString() });
                }
                else
                {
                    temp.Add(new Tile() { TileBrush = Brushes.Black, TileLabel = "", TileName = "E" + i.ToString() });
                }
                count++;
                if (count == 3)
                {
                    if (temp == TileCollectionELeft)
                    {
                        temp = TileCollectionERight;
                    }
                    else
                    {
                        temp = TileCollectionELeft;
                    }
                    count = 0;
                }
            }
        }

        public bool attemptReservation(string seatId, bool probe)
        {
            if(seatId == null)
            {
                return false;
            }
            ErrorLabelText = "Selected seat " + seatId + "\n";
            bool first = false; //first class or economy?
            if(seatId[0] == 'F')
            {
                first = true; 
            }
            try
            {
                var connstr = "Server=sql5.freesqldatabase.com;Uid=sql5399694;Pwd=4k6zvHCLMV;database=sql5399694";
                using (var conn = new MySqlConnection(connstr))
                {
                    conn.Open();
                    Console.WriteLine("connected");
                    string[] t;
                    using (var cmd = conn.CreateCommand())
                    {

                        cmd.CommandText = "select * from flights where FlightID = " + TitleText.Split(new[] { " for " }, StringSplitOptions.None)[0].Split('#')[1]; ;
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (first)
                                {
                                    t = reader[10].ToString().Split(',');
                                } else
                                {
                                    t = reader[13].ToString().Split(',');
                                }
                                if(t[Convert.ToInt32( seatId.Substring(1))] == "x")
                                {
                                    if (!probe)
                                    {
                                        t[Convert.ToInt32(seatId.Substring(1))] = AdminIDText;
                                        updateSeat(first, t);
                                    }
                                    
                                    return true;
                                } else
                                {
                                    getSeatingChart(reader[10].ToString().Split(','), reader[13].ToString().Split(','));
                                    ErrorLabelText += "Seat not available, someone may have reserved it since you opened this window.\n";
                                    return false;
                                }
                                

                            }
                        }
                    }
                    
                }

            }
            catch (Exception ex)
            {

            }
            return false;
        }

        private void updateSeat(bool first, string[] t)
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
                        if (first)
                        {
                            cmd.CommandText = "UPDATE flights SET FCSeats = \"" + String.Join(",", t) + "\" WHERE FlightID = \"" + TitleText.Split(new[] { " for " }, StringSplitOptions.None)[0].Split('#')[1] + "\"";
                        }
                        else
                        {
                            cmd.CommandText = "UPDATE flights SET ESeats = \"" + String.Join(",", t) + "\" WHERE FlightID = \"" + TitleText.Split(new[] { " for " }, StringSplitOptions.None)[0].Split('#')[1] + "\"";
                        }
                        Console.WriteLine(cmd.CommandText);
                        cmd.ExecuteNonQuery();
                        ErrorLabelText = "Successful reservation.";
                    }
                }
            }
            catch (Exception e)
            {
                ErrorLabelText = "Reservation Error.";
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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

        private String _fcNumText = "12";
        public String FCNumText
        {
            get { return _fcNumText; }
            set
            {
                _fcNumText = value;
                OnPropertyChanged("FCNumText");
            }
        }

        private String _eNumText = "12";
        public String ENumText
        {
            get { return _eNumText; }
            set
            {
                _eNumText = value;
                OnPropertyChanged("ENumText");
            }
        }

        private String _fcPriceText;
        public String FCPriceText
        {
            get { return _fcPriceText; }
            set
            {
                _fcPriceText = value;
                OnPropertyChanged("FCPriceText");
            }
        }

        private String _ePriceText;
        public String EPriceText
        {
            get { return _ePriceText; }
            set
            {
                _ePriceText = value;
                OnPropertyChanged("EPriceText");
            }
        }

        private String _capacityText = "24";
        public String CapacityText
        {
            get { return _capacityText; }
            set
            {
                _capacityText = value;
                OnPropertyChanged("CapacityText");
            }
        }

        private String _depStopText;
        public String DepStopText
        {
            get { return _depStopText; }
            set
            {
                _depStopText = value;
                OnPropertyChanged("DepStopText");
            }
        }

        private String _arrStopText;
        public String ArrStopText
        {
            get { return _arrStopText; }
            set
            {
                _arrStopText = value;
                OnPropertyChanged("ArrStopText");
            }
        }

        private String _depTimeText;
        public String DepTimeText
        {
            get { return _depTimeText; }
            set
            {
                _depTimeText = value;
                OnPropertyChanged("DepTimeText");
            }
        }

        private String _arrTimeText;
        public String ArrTimeText
        {
            get { return _arrTimeText; }
            set
            {
                _arrTimeText = value;
                OnPropertyChanged("ArrTimeText");
            }
        }

        private String _depTM;
        public String DepTM
        {
            get { return _depTM; }
            set
            {
                _depTM = value;
                OnPropertyChanged("DepTM");
            }
        }

        private String _arrTM;
        public String ArrTM
        {
            get { return _arrTM; }
            set
            {
                _arrTM = value;
                OnPropertyChanged("ArrTM");
            }
        }

        private String _titleText = "Flight #A3052 for 4/28/2021";
        public String TitleText
        {
            get { return _titleText;  }
            set
            {
                _titleText = value;
                OnPropertyChanged("TitleText");
            }
        }

        private String _adminIDText;
        public String AdminIDText
        {
            get { return _adminIDText; }
            set
            {
                _adminIDText = value;
                OnPropertyChanged("AdminIDText");
            }
        }
    }
}
