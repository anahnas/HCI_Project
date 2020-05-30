using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for WindowResurs.xaml
    /// </summary>
    public partial class WindowResurs : Window, INotifyPropertyChanged
    {
        private bool mojaSlika = false;
        public static Resurs obradjivani;

        private MainWindow mains;

        //da se ne doda dok ne bude sve OK
        private bool oznakaOK = false;
        private bool imeOK = false;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private Image _MojaSlika;
        private string _path;
        public WindowResurs() //konstruktor
        {

            this.DataContext = this;
            this.TipoviResursa = MainWindow.TipoviResursa;
            this.Resursi = MainWindow.Resursi;
            this.Etikete = MainWindow.Etikete;
           
            //image.Source = new BitmapImage(new Uri("Images/resources.png", UriKind.Relative));
            
            NekorisceneEtikete = new ObservableCollection<Etiketa>();
            IskorisceneEtikete = new ObservableCollection<Etiketa>();

            foreach (Etiketa et in MainWindow.Etikete)
            {
                NekorisceneEtikete.Add(et);

            }
            InitializeComponent();
            tip.SelectedIndex = 0;
            tip_SelectionChanged(null, null);
            PotvrdiBtn.IsEnabled = false;
            TipResursa temp = (TipResursa)tip.SelectedItem;
            Path = temp.ImagePath;
            obradjivani = null;
        }

        public WindowResurs(Resurs r, MainWindow mw)
        {
            mains = mw;
            this.DataContext = this;
            this.TipoviResursa = MainWindow.TipoviResursa;
            this.Etikete = MainWindow.Etikete;
            NekorisceneEtikete = new ObservableCollection<Etiketa>();

            IskorisceneEtikete = r.Etikete;

            foreach (Etiketa et in MainWindow.Etikete)
            {
                NekorisceneEtikete.Add(et);

            }

            foreach (Etiketa et in r.Etikete)
            {
                NekorisceneEtikete.Remove(et);

            }
            obradjivani = r;
            InitializeComponent();
            

            //preuzimanje parametara od resursa
            xOznaka.Text = r.Oznaka;
            xIme.Text = r.Ime;
            xOpis.Text = r.Opis;
            comboFrekv.SelectedIndex = r.Frekvencijaa;
            comboJedinica.SelectedIndex = r.JedinicaMjere;
            if (r.Eksploatacija == 1) //DA
            {
                eksploatacijaDA.IsChecked = true;
            } else if (r.Eksploatacija == -1)//ne
            {
                eksploatacijaNE.IsChecked = true;
            }
            if (r.StrateskaVaznost == 1)//da
            {
                StrateskaDa.IsChecked = true;
            } else if (r.StrateskaVaznost == -1)//ne
            {
                StrateskaNe.IsChecked = true;
            }
            if (r.Obnovljiv == 1)//da
            {
                ObnovljivDA.IsChecked = true;
            } else if (r.Obnovljiv == -1)//ne
            {
                ObnovljivNE.IsChecked = true;
            }
            xCijena.Text = r.Cijena;
            xDateField.SelectedDate = DateTime.Now;
            Path = r.imagePath;

            image.Source = new BitmapImage(new Uri(Path));
            mojaSlika = true;

            tip_SelectionChanged(null, null);
            PotvrdiBtn.IsEnabled = true;
            tip.SelectedItem = r.TipResursa;
            this.Title = "Izmjena resursa";

        }


        public Image MyImage
        {
            get
            {
                return _MojaSlika;
            }
            set
            {
                _MojaSlika = value;
                OnPropertyChanged("MyImage_Changed");
            }
        }
        private DateTime datum;
        public DateTime Datum
        {
            get
            {
                return datum;
            }

            set
            {
                if (value != datum)
                {
                    datum = value;
                    OnPropertyChanged("Datum");
                }
            }
        }

        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                if (value != _path)
                {
                    _path = value;
                    OnPropertyChanged("Path");
                }
            }
        }
        private string _ime;
        public string Ime
        {
            get
            {
                return _ime;
            }
            set
            {
                if (value != _ime)
                {
                    _ime = value;
                    OnPropertyChanged("Ime");
                }
            }
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
                    OnPropertyChanged("Oznaka");
                }
            }
        }
    



        private ObservableCollection<Resurs> mojiResursi = new ObservableCollection<Resurs>();
        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            int eksploatacija;
            if(eksploatacijaDA.IsChecked==true)
            {
                eksploatacija = 1;
            } else
            {
                eksploatacija = -1;
            }
            int obnovljiv;
            if(ObnovljivDA.IsChecked==true)
            {
                obnovljiv = 1;
            }
            else
            {
                obnovljiv = -1;
            }

            int strateskavaz;
            if(StrateskaDa.IsChecked==true)
            {
                strateskavaz = 1;

            }
            else
            {
                strateskavaz = -1;
            }
            DateTime d = datum;
            if (xDateField.SelectedDate == null)
            {
                MessageBox.Show("Datum ne smije biti prazan", "Unos resursa");
                return;
            }

            if ((DateTime)xDateField.SelectedDate < DateTime.Now)
            {
                datum = (DateTime)xDateField.SelectedDate;
            }
            else
            {
                MessageBox.Show("Ne možete odabrati datum koji nije bio!", "Unos resursa");
                return;
            }
            if (obradjivani==null)
            {
                Resurs temp = new Resurs
                {
                    Ime = xIme.Text,
                    Oznaka = xOznaka.Text,
                    Opis = xOpis.Text,
                    Frekvencijaa = comboFrekv.SelectedIndex,
                    JedinicaMjere = comboJedinica.SelectedIndex,
                    StrateskaVaznost = strateskavaz,
                    Eksploatacija = eksploatacija,
                    Obnovljiv = obnovljiv,

                    Cijena = xCijena.Text,
                    Datum = datum,
                    imagePath = image.Source.ToString(),
                    Etikete = IskorisceneEtikete,
                    TipResursa = (TipResursa)tip.SelectedItem
                 };
                //obradjivani.imagePath = image.Source.ToString();
               // Etikete = IskorisceneEtikete;
                TipResursa dodat = (TipResursa)tip.SelectedItem;
                //Resurs novi = new Resurs(xOznaka.Text, xIme.Text, xOpis.Text, image.Source.ToString(), xDateField.ToString(), xCijena.Text, comboFrekv.SelectedIndex, comboJedinica.SelectedIndex, obnovljiv, strateskavaz, eksploatacija, dodat);
                //TipResursa dodat = (TipResursa)tip.SelectedItem;
                //MainWindow.Resursi.Add(temp);
                //dodat.SadrzaniResursi.Add(temp); !!!!!!
                foreach(TipResursa tr in TipoviResursa)
                {
                    if (dodat.Oznaka.Equals(tr.Oznaka))
                    {
                        tr.SadrzaniResursi.Add(temp);
                    }
                }
                MainWindow.Resursi.Add(temp);
                MessageBox.Show("Uspjesno dodat resurs!", "Resurs", MessageBoxButton.OK);

            }
            else //ZA IZMJENU
            {
                obradjivani.Ime = xIme.Text;
                obradjivani.Oznaka = xOznaka.Text;
                obradjivani.Opis = xOpis.Text;
                obradjivani.Frekvencijaa = comboFrekv.SelectedIndex;
                obradjivani.JedinicaMjere = comboJedinica.SelectedIndex;
                obradjivani.Obnovljiv = obnovljiv;
                obradjivani.Eksploatacija = eksploatacija;
                obradjivani.StrateskaVaznost = strateskavaz;
                //obradjivani.DatumOtkrivanja = xDateField.ToString();
                obradjivani.Datum = datum;
                obradjivani.imagePath = image.Source.ToString();
                obradjivani.Cijena = xCijena.Text;
                obradjivani.Etikete = IskorisceneEtikete;
                obradjivani.TipResursa.SadrzaniResursi.Remove(obradjivani);
                obradjivani.TipResursa = (TipResursa)tip.SelectedItem;
                obradjivani.TipResursa.SadrzaniResursi.Add(obradjivani);


                mains.xTree.ItemsSource = null;
                mains.xTree.ItemsSource = TipoviResursa;

                MessageBox.Show("Uspjesno izmijenjen resurs!", "Resurs", MessageBoxButton.OK);


            }
            this.Close();
        }

        private void DodajUKoriscene_Click(object sender, RoutedEventArgs e)
        {
            if (NeupotrebljeneEtikete.SelectedValue != null)
            {
                Etiketa et = (Etiketa)NeupotrebljeneEtikete.SelectedValue;
                IskorisceneEtikete.Add(et);
                NekorisceneEtikete.Remove(et);
            }
        }

        private void DodajUNeiskoriscene_Click(object sender, RoutedEventArgs e)
        {
            if (UpotrebljeneEtikete.SelectedValue != null)
            {
                Etiketa et = (Etiketa)UpotrebljeneEtikete.SelectedValue;
                NekorisceneEtikete.Add(et);
                IskorisceneEtikete.Remove(et);
            }
        }

        private void btnOdaberi_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Odaberite sliku";
            op.Filter = "Podržani formati|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                image.Source = new BitmapImage(new Uri(op.FileName));
                Path = op.FileName;
                mojaSlika = true;
            }
        }
        private void btnOdbaci_Click(object sender, RoutedEventArgs e)
        {
            if (tip.SelectedValue != null)
            {
                TipResursa tippp = (TipResursa)tip.SelectedValue;
                image.Source = tippp.Ikonica;
                mojaSlika = false;
                Path = tippp.ImagePath;
            }
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.MainWindow.Show();
        }

        private void tip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tip.SelectedValue != null && image != null && mojaSlika == false)
            {
                TipResursa type = (TipResursa)tip.SelectedValue;
                image.Source = type.Ikonica;
                Path = type.ImagePath;
            }
        }

        private void xOznaka_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (obradjivani != null)
            {
                bool postoji = false;

                foreach (Resurs r in MainWindow.Resursi)
                {
                    if (r.Oznaka.Equals(tb.Text) && !obradjivani.Oznaka.Equals(tb.Text))
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
                var postoji = MainWindow.Resursi.Where(c => c.Oznaka == tb.Text).ToArray();

                if (tb.Text.Length >= 3 && (postoji.Count() == 0))
                {
                    oznakaOK = true;
                }
                else
                {
                    oznakaOK = false;
                }
            }

            if (oznakaOK && imeOK)
            {
                PotvrdiBtn.IsEnabled = true;
            }
            else
            {
                PotvrdiBtn.IsEnabled = false;
            }
        }
        private void xIme_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (tb.Text.Length < 3)
            {
                imeOK = false;
            }
            else
            {
                imeOK = true;
            }

            if (oznakaOK && imeOK)
            {
                PotvrdiBtn.IsEnabled = true;
            }
            else
            {
                PotvrdiBtn.IsEnabled = false;
            }

        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            HelpProvider.ShowHelp("prozorR", this);

        }
        public ObservableCollection<TipResursa> TipoviResursa
        {
            get;
            set;
        }

        public ObservableCollection<Resurs> Resursi
        {
            get;
            set;
        }

        public ObservableCollection<Etiketa> Etikete
        {
            get;
            set;
        }

        public ObservableCollection<Etiketa> NekorisceneEtikete
        {
            get;
            set;
        }
        public ObservableCollection<Etiketa> IskorisceneEtikete
        {
            get;
            set;
        }
    }
}
