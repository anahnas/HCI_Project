using System;
using System.Collections.Generic;
using System.IO;
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

namespace HCIProject1._2
{
    /// <summary>
    /// Interaction logic for Help.xaml
    /// </summary>
    public partial class Help : Window
    {

        private JavaScriptControlHelper ch;

        public Help(string key, WindowEtiketa originator)
        {
            InitializeComponent();
            string curDir = Directory.GetCurrentDirectory();
            string path = String.Format("C:\\Users\\DT User\\Desktop\\AnaTomicHCI1.2AW\\HCIProject1.2\\HCIProject1.2\\HCIProject1.2\\Help\\{0}.htm", key);
            if (!File.Exists(path))
            {
                key = "error";
            }
            Uri u = new Uri(String.Format("C:\\Users\\DT User\\Desktop\\AnaTomicHCI1.2AW\\HCIProject1.2\\HCIProject1.2\\HCIProject1.2\\Help\\{0}.htm", key));
            ch = new JavaScriptControlHelper(originator);
            wbHelp.ObjectForScripting = ch;
            wbHelp.Navigate(u);
        }

        public Help(string key, WindowTip originator)
        {
            InitializeComponent();
            string curDir = Directory.GetCurrentDirectory();
            string path = String.Format("C:\\Users\\DT User\\Desktop\\AnaTomicHCI1.2AW\\HCIProject1.2\\HCIProject1.2\\HCIProject1.2\\Help\\{0}.htm", key);
            if (!File.Exists(path))
            {
                key = "error";
            }
            Uri u = new Uri(String.Format("C:\\Users\\DT User\\Desktop\\AnaTomicHCI1.2AW\\HCIProject1.2\\HCIProject1.2\\HCIProject1.2\\Help\\{0}.htm", key));
            ch = new JavaScriptControlHelper(originator);
            wbHelp.ObjectForScripting = ch;
            wbHelp.Navigate(u);
        }
        public Help(string key, WindowResurs originator)
        {
            InitializeComponent();
            string curDir = Directory.GetCurrentDirectory();
            string path = String.Format("C:\\Users\\DT User\\Desktop\\AnaTomicHCI1.2AW\\HCIProject1.2\\HCIProject1.2\\HCIProject1.2\\Help\\{0}.htm", key);
            if (!File.Exists(path))
            {
                key = "error";
            }
            Uri u = new Uri(String.Format("C:\\Users\\DT User\\Desktop\\AnaTomicHCI1.2AW\\HCIProject1.2\\HCIProject1.2\\HCIProject1.2\\Help\\{0}.htm", key));
            ch = new JavaScriptControlHelper(originator);
            wbHelp.ObjectForScripting = ch;
            wbHelp.Navigate(u);
        }

        public Help(string key, MainWindow originator)
        {
            InitializeComponent();
            string curDir = Directory.GetCurrentDirectory();
            string path = String.Format("C:\\Users\\DT User\\Desktop\\AnaTomicHCI1.2AW\\HCIProject1.2\\HCIProject1.2\\HCIProject1.2\\Help\\{0}.htm", key);
            if (!File.Exists(path))
            {
                key = "error";
            }
            Uri u = new Uri(String.Format("C:\\Users\\DT User\\Desktop\\AnaTomicHCI1.2AW\\HCIProject1.2\\HCIProject1.2\\HCIProject1.2\\Help\\{0}.htm", key));
            ch = new JavaScriptControlHelper(originator);
            wbHelp.ObjectForScripting = ch;
            wbHelp.Navigate(u);
        }
        public Help(string key, WindowEtiketaPregled originator)
        {
            InitializeComponent();
            string curDir = Directory.GetCurrentDirectory();
            string path = String.Format("C:\\Users\\DT User\\Desktop\\AnaTomicHCI1.2AW\\HCIProject1.2\\HCIProject1.2\\HCIProject1.2\\Help\\{0}.htm", key);
            if (!File.Exists(path))
            {
                key = "error";
            }
            Uri u = new Uri(String.Format("C:\\Users\\DT User\\Desktop\\AnaTomicHCI1.2AW\\HCIProject1.2\\HCIProject1.2\\HCIProject1.2\\Help\\{0}.htm", key));
            ch = new JavaScriptControlHelper(originator);
            wbHelp.ObjectForScripting = ch;
            wbHelp.Navigate(u);
        }

        public Help(string key, WindowResursPregled originator)
        {
            InitializeComponent();
            string curDir = Directory.GetCurrentDirectory();
            string path = String.Format("C:\\Users\\DT User\\Desktop\\AnaTomicHCI1.2AW\\HCIProject1.2\\HCIProject1.2\\HCIProject1.2\\Help\\{0}.htm", key);
            if (!File.Exists(path))
            {
                key = "error";
            }
            Uri u = new Uri(String.Format("C:\\Users\\DT User\\Desktop\\AnaTomicHCI1.2AW\\HCIProject1.2\\HCIProject1.2\\HCIProject1.2\\Help\\{0}.htm", key));
            ch = new JavaScriptControlHelper(originator);
            wbHelp.ObjectForScripting = ch;
            wbHelp.Navigate(u);
        }
        public Help(string key, WindowTipPregled originator)
        {
            InitializeComponent();
            string curDir = Directory.GetCurrentDirectory();
            string path = String.Format("C:\\Users\\DT User\\Desktop\\AnaTomicHCI1.2AW\\HCIProject1.2\\HCIProject1.2\\HCIProject1.2\\Help\\{0}.htm", key);
            if (!File.Exists(path))
            {
                key = "error";
            }
            Uri u = new Uri(String.Format("C:\\Users\\DT User\\Desktop\\AnaTomicHCI1.2AW\\HCIProject1.2\\HCIProject1.2\\HCIProject1.2\\Help\\{0}.htm", key));
            ch = new JavaScriptControlHelper(originator);
            wbHelp.ObjectForScripting = ch;
            wbHelp.Navigate(u);
        }
        private void BrowseBack_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((wbHelp != null) && (wbHelp.CanGoBack));
        }

        private void BrowseBack_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            wbHelp.GoBack();
        }

        private void BrowseForward_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((wbHelp != null) && (wbHelp.CanGoForward));
        }

        private void BrowseForward_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            wbHelp.GoForward();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void wbHelp_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
        }



    }
}
