using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HCIProject1._2
{
    class HelpProvider
    {
        public static string GetHelpKey(DependencyObject obj)
        {
            return obj.GetValue(HelpKeyProperty) as string;
        }
        public static void SetHelpKey(DependencyObject obj, string value)
        {
            obj.SetValue(HelpKeyProperty, value);
        }

        public static readonly DependencyProperty HelpKeyProperty =
            DependencyProperty.RegisterAttached("HelpKey", typeof(string), typeof(HelpProvider), new PropertyMetadata("index", HelpKey));
        private static void HelpKey(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //NOOP
        }

        public static void ShowHelp(string key, WindowEtiketa originator)
        {
            Help hh = new Help(key, originator);
            hh.Show();
        }

        public static void ShowHelp(string key, WindowTip originator)
        {
            Help hh = new Help(key, originator);
            hh.Show();
        }

        public static void ShowHelp(string key, WindowResurs originator)
        {
            Help hh = new Help(key, originator);
            hh.Show();
        }

        

        public static void ShowHelp(string key, MainWindow originator)
        {
            Help hh = new Help(key, originator);
            hh.Show();
        }

        public static void ShowHelp(string key, WindowEtiketaPregled originator)
        {
            Help hh = new Help(key, originator);
            hh.Show();
        }

        public static void ShowHelp(string key, WindowResursPregled originator)
        {
            Help hh = new Help(key, originator);
            hh.Show();
        }

        public static void ShowHelp(string key, WindowTipPregled originator)
        {
            Help hh = new Help(key, originator);
            hh.Show();
        }
    }
}
