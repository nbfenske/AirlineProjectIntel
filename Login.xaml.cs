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

namespace AirlineProjectIntel
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly LoginModel _model;
        public Login()
        {
            InitializeComponent();

            // make it so the user cannot resize the window
            this.ResizeMode = ResizeMode.NoResize;

            // create an instance of our Model
            _model = new LoginModel();

            //set data binding context to our model
            DataContext = _model;

            BrushConverter bc = new BrushConverter();
            menuBar.Fill = (Brush)bc.ConvertFrom("#36008D");
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Register r = new Register();
            r.Show();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string result = _model.checkCredentials();
            if (result[0] == '#')
            {
                _model.ErrorLabelText = result;
                if(result.Substring(1) == "True")
                {
                    FlightListAdmin f = new FlightListAdmin(_model.UsernameText, true);
                    f.Show();
                    this.Close();
                } else
                {
                    FlightListAdmin f = new FlightListAdmin(_model.UsernameText, false);
                    f.Show();
                    this.Close();
                }
                /*MainWindow w = new MainWindow();
                w.Show();
                this.Close();*/
            } else
            {
                _model.ErrorLabelText = result;
            }
                
        }
    }
}
