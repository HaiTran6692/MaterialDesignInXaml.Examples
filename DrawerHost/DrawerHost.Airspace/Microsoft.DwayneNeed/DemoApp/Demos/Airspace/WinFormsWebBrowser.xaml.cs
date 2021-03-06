using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms.Integration;

namespace DemoApp.Demos.Airspace
{
    /// <summary>
    /// Interaction logic for WinFormsWebBrowser.xaml
    /// </summary>
    public partial class WinFormsWebBrowser : Grid
    {
        public WinFormsWebBrowser()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            WindowsFormsHost.EnableWindowsFormsInterop();

            InitializeComponent();
            TheHost.PropertyMap.Remove("Background");

            Address.SelectedIndex = 0;
        }

        private void GoClicked(object sender, RoutedEventArgs e)
        {
            if (Address != null)
            {
                string address = Address.Text;
                if (!String.IsNullOrWhiteSpace(address))
                {
                    Navigate(address);
                }
            }
        }

        private void AddressSelectionChanged(object sender, RoutedEventArgs e)
        {
            string address = Address.SelectedValue as string;
            if (address != null)
            {
                Navigate(address);
            }
        }

        private void Navigate(string address)
        {
            if (!address.StartsWith("http://"))
            {
                address = "http://" + address;
            }

            TheWebBrowser.Url = new Uri(address);
        }
    }
}
