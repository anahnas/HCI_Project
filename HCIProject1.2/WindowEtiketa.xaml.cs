using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for WindowEtiketa.xaml
    /// </summary>
    public partial class WindowEtiketa : Window
    {
        public static Etiketa obradjivanaEtiketa;

        public WindowEtiketa()
        {
            this.DataContext = this;
            Etikete = MainWindow.Etikete;
            obradjivanaEtiketa = null;
            InitializeComponent();
            
            
            PotvrdiEtiketaBtn.IsEnabled = false;

        }
        public WindowEtiketa(Etiketa et)
        {
            this.DataContext = this;
            Etikete = MainWindow.Etikete;
            InitializeComponent();
            obradjivanaEtiketa = et;

            //PotvrdiEtiketaBtn.IsEnabled = false;
            InitializeComponent();
            PotvrdiEtiketaBtn.IsEnabled = false;

            
                xOznaka.Text = et.Oznaka;
                opisPolje.Text = et.Opis;
                ColorPickerPolje.SelectedColor = et.Boja2;
                this.Title = "Izmjena etikete";
            
           

        }
        public ObservableCollection<Etiketa> Etikete
        {
            get;
            set;

        }

        private string _oznaka;
        public string Oznaka
        {
            get
            {
                return _oznaka;
            }
            set
            {
                if (value != _oznaka)
                {
                    _oznaka = value;

                }
            }
        }
        private Color boja;

        public Color Boja2
        {
            get { return boja; }
            set { boja = value; }
        }

        #region dugmencad
        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            if(obradjivanaEtiketa==null)
            {
                Etiketa et = new Etiketa { Oznaka = xOznaka.Text, Opis = opisPolje.Text, Boja2 = (Color)ColorPickerPolje.SelectedColor};
               // Etiketa et = new Etiketa(xOznaka.Text, opisPolje.Text, ColorPickerPolje.ToString());
               // Etiketa et = new Etiketa(xOznaka.Text, opisPolje.Text);
                MainWindow.Etikete.Add(et);
                MessageBox.Show("Uspjesno ste dodali etiketu", "Dodata etiketa", MessageBoxButton.OK);
            } else
            {
                
                obradjivanaEtiketa.Opis = xOznaka.Text;
                obradjivanaEtiketa.Oznaka = opisPolje.Text;
                obradjivanaEtiketa.Boja2 = (Color)ColorPickerPolje.SelectedColor;
                MessageBox.Show("Uspjesno ste izmijenili etiketu", "Izmijenjene etiketa", MessageBoxButton.OK);
            }
            this.Close();
            Application.Current.MainWindow.Show();
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.MainWindow.Show();
        }
        #endregion

        private bool oznakaOK = false;
        private void xOznaka_TextChanged(object sender, TextChangedEventArgs e)
        {

            TextBox tb = (TextBox)sender;
            if (obradjivanaEtiketa != null)
            {
                bool postoji = false;
                foreach (Etiketa etiketaa in MainWindow.Etikete)
                {
                    if (etiketaa.Oznaka.Equals(tb.Text) && !obradjivanaEtiketa.Oznaka.Equals(tb.Text))
                    {
                        postoji = true;
                        break;
                    }

                }
                if (!postoji && tb.Text.Length >= 3)
                {
                    oznakaOK = true;
                }
                else
                {
                    oznakaOK = false;
                }
            }
            else
            {
                var postoji = MainWindow.Etikete.Where(c => c.Oznaka == tb.Text).ToArray();

                if (tb.Text.Length >= 3 && (postoji.Count() == 0))
                {
                    oznakaOK = true;
                }
                else
                {
                    oznakaOK = false;
                }
            }
            if (oznakaOK)
            {
                PotvrdiEtiketaBtn.IsEnabled = true;
            }
            else
            {
                PotvrdiEtiketaBtn.IsEnabled = false;
            }

        }
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            HelpProvider.ShowHelp("prozorE", this);

        }
    }
}
