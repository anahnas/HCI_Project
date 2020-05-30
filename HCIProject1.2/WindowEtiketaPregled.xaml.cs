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
//using System.Runtime.Serialization;
//using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;

namespace HCIProject1._2
{
    /// <summary>
    /// Interaction logic for WindowEtiketaPregled.xaml
    /// </summary>
    public partial class WindowEtiketaPregled : Window
    {
        #region Konstruktor
        public WindowEtiketaPregled()
        {

            InitializeComponent();
            this.DataContext = this;

           

            //pretraga
            //ime mi je ustvari opis bilo mi je mrsko ispravljati
            sakriveneEtiketeIme = new ObservableCollection<Etiketa>();
            sakriveneEtiketeOznaka = new ObservableCollection<Etiketa>();

            //ucitavanje
            Etikete = MainWindow.Etikete;

            Closing += OnWindowsClosing;

        }
        #endregion
        #region Kolekcije
        public ObservableCollection<Etiketa> Etikete
        {
            get;
            set;
        }

        public ObservableCollection<Etiketa> sakriveneEtiketeIme
        {
            get;
            set;
        }
        public ObservableCollection<Etiketa> sakriveneEtiketeOznaka
        {
            get;
            set;
        }

        #endregion

        #region Dugmici
        private void dodaj_Click(object sender, RoutedEventArgs e)
        {
            WindowEtiketa ett = new WindowEtiketa();
            ett.ShowDialog();
        }

        private void obrisi_Click(object sender, RoutedEventArgs e)
        {
            Etiketa etik = (Etiketa)dgrMainEtiketa.SelectedItem;

            bool postoji = false;

            foreach (Resurs re in MainWindow.Resursi)
            {
                foreach (Etiketa etiketaa in re.Etikete)
                {
                    if(etiketaa.Oznaka == etik.Oznaka)
                    {
                        Console.Write("Postoji!");
                        postoji = true;
                        break;
                    }

                }

            } if(postoji)
            {
                MessageBox.Show("Pojavljuje se etiketa", "op", MessageBoxButton.OK);
                foreach (Resurs resurss in MainWindow.Resursi)
                {
                    resurss.Etikete.Remove(etik);
                }
                MainWindow.Etikete.Remove(etik);
                
            } else
            {
                MainWindow.Etikete.Remove(etik);
            }
        }

        private void izmijeni_Click(object sender, RoutedEventArgs e)
        {
            if ((Etiketa)dgrMainEtiketa.SelectedItem == null)
            {
                MessageBox.Show("MORA SE SELEKTOVATI ETIKETA", "UPOZORENJE", MessageBoxButton.OKCancel);

            }
            else
            {

                Etiketa selektovana = (Etiketa)dgrMainEtiketa.SelectedItem;
                WindowEtiketa izmjena = new WindowEtiketa(selektovana);
                izmjena.ShowDialog();
            }
            
        }

        private void Pretrazi_Click_2(object sender, RoutedEventArgs e)
        {
            //ime je ustv opis bilo mi je mrsko svugdje mijenjat kopirala sam iz tipa
            String text = xIme.Text;
            Console.WriteLine(text);

            if (text.Equals(""))
            {
                for (int i = 0; i < sakriveneEtiketeIme.Count; i++)
                {
                    Etikete.Add(sakriveneEtiketeIme[i]);

                }
                foreach (Etiketa eti in Etikete)
                {
                    sakriveneEtiketeIme.Remove(eti);

                }
            }
            else
            {
                Console.WriteLine("evo meeeeeee");
                for (int i = 0; i < Etikete.Count; i++)
                {
                    bool b = Etikete[i].Opis.Contains(text);
                    if (!b)
                    {
                        //Console.WriteLine("Ne sadrzi");
                        sakriveneEtiketeIme.Add(Etikete[i]);
                    }
                }
                foreach (Etiketa tip in sakriveneEtiketeIme)
                {
                    Etikete.Remove(tip);

                }
                for (int i = 0; i < sakriveneEtiketeIme.Count; i++)
                {
                    bool b = sakriveneEtiketeIme[i].Opis.Contains(text);
                    if (b)
                    {
                        Etikete.Add(sakriveneEtiketeIme[i]);
                    }

                }
                foreach (Etiketa tip in Etikete)
                {
                    sakriveneEtiketeIme.Remove(tip);

                }
            }
            
            text = xOznaka.Text;
            if (text.Equals(""))
            {
                for (int i = 0; i < sakriveneEtiketeOznaka.Count; i++)
                {
                    Etikete.Add(sakriveneEtiketeOznaka[i]);

                }
                foreach (Etiketa tip in Etikete)
                {
                    sakriveneEtiketeOznaka.Remove(tip);

                }
            }
            else
            {
                for (int i = 0; i < Etikete.Count; i++)
                {
                    bool b = Etikete[i].Oznaka.Contains(text);
                    if (!b)
                    {
                        sakriveneEtiketeOznaka.Add(Etikete[i]);
                    }

                }
                foreach (Etiketa tip in sakriveneEtiketeOznaka)
                {
                    Etikete.Remove(tip);

                }
                for (int i = 0; i < sakriveneEtiketeOznaka.Count; i++)
                {
                    bool b = sakriveneEtiketeOznaka[i].Oznaka.Contains(text);
                    if (b)
                    {
                        Etikete.Add(sakriveneEtiketeOznaka[i]);
                    }
                }
                foreach (Etiketa tip in Etikete)
                {
                    sakriveneEtiketeOznaka.Remove(tip);

                }
            }
        }

        private void Ponisti_Click(object sender, RoutedEventArgs e)
        {
            if(sakriveneEtiketeIme.Count !=0 )
            {
                foreach (Etiketa etiketa in sakriveneEtiketeIme)
                {
                    Etikete.Add(etiketa);

                }
                for (int i = sakriveneEtiketeIme.Count-1; i >=0; i--)
                {
                    sakriveneEtiketeIme.RemoveAt(i);

                }

            }
            if(sakriveneEtiketeOznaka.Count != 0)
            {
                foreach (Etiketa etiketa in sakriveneEtiketeOznaka)
                {
                    Etikete.Add(etiketa);

                }
                for (int i = sakriveneEtiketeOznaka.Count-1; i >= 0; i--)
                {
                    sakriveneEtiketeOznaka.RemoveAt(i);

                }
            }
        }
        #endregion
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
       
                HelpProvider.ShowHelp("prozorTPE", this);
            
        }

        #region Zatvaranje prozora
        public void OnWindowsClosing(object sender, CancelEventArgs e)
        {
            if (sakriveneEtiketeIme.Count != 0)
            {
                foreach (Etiketa eti in sakriveneEtiketeIme)
                {
                    Etikete.Add(eti);
                }
            }
            if (sakriveneEtiketeOznaka.Count != 0)
            {
                foreach (Etiketa eti in sakriveneEtiketeOznaka)
                {
                    Etikete.Add(eti);
                }
            }

        }
        #endregion
    }
}
