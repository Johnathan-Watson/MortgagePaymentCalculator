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

namespace Assignment2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // disabled by default
            btnEnter.IsEnabled = false;
            txtOther.IsEnabled = false;
            txtRate.IsEnabled = false;
        }

        // initializers
        Double _principal = 0.0, _years = 0.0, _rate = 0.0, _monthly, _top, _bottom, _bottom1, _bottom2, _bottom3;

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            // clears all info
            txtPrincipal.Clear();
            txtOther.Clear();
            sldInterest.Value = 0;
            txtRate.Clear();
            txtMorgage.Clear();
        }

        private void sldInterest_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Converts slider value to string and stores in txtRate variable
            txtRate.Text = sldInterest.Value.ToString();
        }

        private void rdo15_Click(object sender, RoutedEventArgs e)
        {
            // 15 years radio button actions
            txtOther.IsEnabled = false;
            btnEnter.IsEnabled = false;
            _years = 15;
            txtOther.Text = _years.ToString();
        }

        private void rdo30_Click(object sender, RoutedEventArgs e)
        {
            // 30 years radio button actions
            txtOther.IsEnabled = false;
            btnEnter.IsEnabled = false;
            _years = 30;
            txtOther.Text = _years.ToString();
        }

        private void rdoOther_Click(object sender, RoutedEventArgs e)
        {
            // Other radio button actions
            txtOther.IsEnabled = true;
            btnEnter.IsEnabled = true;
            txtOther.Clear();

        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            // Enter button parses textbox text into _years double variable
            if (Double.TryParse(txtOther.Text, out _years) && _years >= 1)
            {
                txtOther.IsEnabled = false;
            }

            else
            // Error message if conditions are not met
            {
                txtOther.Text = "INVALID";
            }
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            // Converts textbox text into _principal double variable
            if (Double.TryParse(txtPrincipal.Text, out _principal) && _principal >= 1)
            {
                
            }

            else
            // Error message if conditions are not met
            {
                txtPrincipal.Text = "INVALID";
            }

            // Converts textbox text into _rate double variable
            if (Double.TryParse(txtRate.Text, out _rate) && _rate >= 1)
            {

            }

            else
            // Error message if conditions are not met
            {
                txtRate.Text = "INVALID";

            }

            //MessageBox.Show(_principal.ToString());
            //MessageBox.Show(_years.ToString());
            //MessageBox.Show(_rate.ToString());

            if (_principal >= 1 && _years >= 1 && _rate >= 1)
            // Mortgage calculations performed if conditions are met
            {
                _top = (_principal * _rate) / 1200;
                _bottom1 = 1 + (_rate / 1200);
                _bottom2 = -12 * _years;
                _bottom3 = Math.Pow(_bottom1, _bottom2);
                _bottom = 1 - _bottom3;
                _monthly = _top / _bottom;
                txtMorgage.Text = _monthly.ToString("C");
            }

            else
            // Error message if conditions are not met
            {
                txtMorgage.Text = "TRY AGAIN";
            }
        }

      
    }
}
