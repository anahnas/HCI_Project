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
    /// Interaction logic for WindowTipPregled.xaml
    /// </summary>
    public partial class WindowTipPregled : Window
    {
        /*[System.ComponentModel.Browsable(false)]
        public System.Windows.Forms.DialogResult DialogResult { get; set; }*/
        private MainWindow mwin;
        private Boolean pokrenutaPretraga;
        private int selectedIndex;
        public WindowTipPregled(MainWindow mw)
        {
            InitializeComponent();
            this.DataContext = this;
            //ucitavanje
            resursiTip = MainWindow.TipoviResursa;
            //pretraga
            resursiTipSakrivenoIme = new ObservableCollection<TipResursa>();
            resursiTipSakrivenaOznaka = new ObservableCollection<TipResursa>();
            resursiTipSakriveniOpis = new ObservableCollection<TipResursa>();
            //onemogucavanje dodavanja, kad nema tipova
            mwin = mw;

            pokrenutaPretraga = false;

            Closing += OnWindowClosing;


        }

        public ObservableCollection<TipResursa> resursiTip
        {
            get;
            set;

        }
        public ObservableCollection<TipResursa> resursiTipSakrivenoIme
        {
            get;
            set;

        }

        public ObservableCollection<TipResursa> resursiTipSakrivenaOznaka
        {
            get;
            set;

        }

        public ObservableCollection<TipResursa> resursiTipSakriveniOpis
        {
            get;
            set;

        }


        private void dodajAkcija(object sender, RoutedEventArgs e)
        {
            WindowTip wtip = new WindowTip();
            wtip.Show();
            this.Close();
        }

        private void obrisiAkcija(object sender, RoutedEventArgs e)
        {
            // DialogResult result = MessageBox.Show("Da li ste sigurni da zelite da obrisete tip resurusa?", "Brisanje tipa resursa", MessageBoxButton.YesNoCancel);
            MessageBox.Show("Da li ste sigurni da zelite da obrisete tip resurusa?", "Brisanje tipa resursa", MessageBoxButton.YesNoCancel);

            TipResursa tr = (TipResursa)dgrMainTip.SelectedItem;
            List<Resurs> resursSaTipom = MainWindow.Resursi.Where(m => m.TipResursa.Equals(tr)).ToList();
            if (resursSaTipom.Count != 0)
            {
                MessageBox.Show("Da li ste sigurni da zelite da obrisete tip koji se koristi kod bar jednog resursa?", "Brisanje tipa resursa", MessageBoxButton.YesNoCancel);
                
                foreach (Resurs r in resursSaTipom)
                {
                    MainWindow.Resursi.Remove(r);
                    if (MainWindow.naMapi.Contains(r))
                    {
                        MainWindow.naMapi.Remove(r);

                    }

                }
                MainWindow.TipoviResursa.Remove(tr);
            } else
            {
                MainWindow.TipoviResursa.Remove(tr);
            }
            if(MainWindow.TipoviResursa.Count == 0)
            {
                mwin.DodajResursButton.IsEnabled = false;
            }

        } 

        private void Pretrazi_Click(object sender, RoutedEventArgs e)
        {

            //Console.WriteLine("Kliknuto pretrazi");
            String text = xIme.Text;
            Console.WriteLine(text);

            if(text.Equals(""))
            {
                for (int i = 0; i < resursiTipSakrivenoIme.Count; i++)
                {
                    resursiTip.Add(resursiTipSakrivenoIme[i]);

                }
                foreach (TipResursa tipResursa in resursiTip)
                {
                    resursiTipSakrivenoIme.Remove(tipResursa);

                }
            }
            else
            {
                Console.WriteLine("evo meeeeeee");
                for (int i = 0; i < resursiTip.Count; i++)
                {
                    bool b = resursiTip[i].Ime.Contains(text);
                    if(!b)
                    {
                        //Console.WriteLine("Ne sadrzi");
                        resursiTipSakrivenoIme.Add(resursiTip[i]);
                    }
                }
                foreach (TipResursa tip in resursiTipSakrivenoIme)
                {
                    resursiTip.Remove(tip);

                }
                for (int i = 0; i < resursiTipSakrivenoIme.Count; i++)
                {
                    bool b = resursiTipSakrivenoIme[i].Ime.Contains(text);
                    if(b)
                    {
                        resursiTip.Add(resursiTipSakrivenoIme[i]);
                    }

                }
                foreach (TipResursa tip in resursiTip)
                {
                    resursiTipSakrivenoIme.Remove(tip);

                }
            }
            text = xOpis.Text;//opis ovdjee
            if (text.Equals(""))
            {
                for (int i = 0; i < resursiTipSakriveniOpis.Count; i++)
                {
                    resursiTip.Add(resursiTipSakriveniOpis[i]);
                }
                foreach (TipResursa tip in resursiTip)
                {
                    resursiTipSakriveniOpis.Remove(tip);

                }
            } else
            {
                for (int i = 0; i < resursiTip.Count; i++)
                {
                    bool b = resursiTip[i].Opis.Contains(text);
                    if(!b)
                    {
                        resursiTipSakriveniOpis.Add(resursiTip[i]);
                    }

                }
                foreach (TipResursa tip in resursiTipSakriveniOpis)
                {
                    resursiTip.Remove(tip);

                }
                for (int i = 0; i < resursiTipSakriveniOpis.Count; i++)
                {
                    bool b = resursiTipSakriveniOpis[i].Opis.Contains(text);
                    if(b)
                    {
                        resursiTip.Add(resursiTipSakriveniOpis[i]);
                    }

                }
                foreach (TipResursa tip in resursiTip)
                {
                    resursiTipSakriveniOpis.Remove(tip);

                }
            }
            text = xOznaka.Text;
            if(text.Equals(""))
            {
                for (int i = 0; i < resursiTipSakrivenaOznaka.Count; i++)
                {
                    resursiTip.Add(resursiTipSakrivenaOznaka[i]);

                }
                foreach (TipResursa tip in resursiTip)
                {
                    resursiTipSakrivenaOznaka.Remove(tip);

                }
            } else
            {
                for (int i = 0; i < resursiTip.Count; i++)
                {
                    bool b = resursiTip[i].Oznaka.Contains(text);
                    if(!b)
                    {
                        resursiTipSakrivenaOznaka.Add(resursiTip[i]);
                    }

                }
                foreach (TipResursa tip in resursiTipSakrivenaOznaka)
                {
                    resursiTip.Remove(tip);

                }
                for (int i = 0; i < resursiTipSakrivenaOznaka.Count; i++)
                {
                    bool b = resursiTipSakrivenaOznaka[i].Oznaka.Contains(text);
                    if(b)
                    {
                        resursiTip.Add(resursiTipSakrivenaOznaka[i]);
                    }
                }
                foreach (TipResursa tip in resursiTip)
                {
                    resursiTipSakrivenaOznaka.Remove(tip);

                }
            }
        }
        
        private void Ponisti_Click(object sender, RoutedEventArgs e)
        {
            if (resursiTipSakrivenoIme.Count != 0)
            {
                foreach (TipResursa tip in resursiTipSakrivenoIme)
                {
                    resursiTip.Add(tip);

                }
                for (int i = resursiTipSakrivenoIme.Count - 1; i >= 0; i--)
                {
                    resursiTipSakrivenoIme.RemoveAt(i);

                }
            }
                if(resursiTipSakriveniOpis.Count != 0)
                {
                    foreach (TipResursa item in resursiTipSakriveniOpis)
                    {
                        resursiTip.Add(item);

                    }
                    for (int i = resursiTipSakriveniOpis.Count-1; i >= 0; i--)
                    {
                        resursiTipSakriveniOpis.RemoveAt(i);

                    }
                }
                if (resursiTipSakrivenaOznaka.Count != 0)
                {
                    foreach (TipResursa item in resursiTipSakrivenaOznaka)
                    {
                        resursiTip.Add(item);

                    }
                    for (int i = resursiTipSakrivenaOznaka.Count - 1; i >= 0; i--)
                    {
                        resursiTipSakrivenaOznaka.RemoveAt(i);

                    }
                }

        }
        

        //metoda koja sluzi da mi fltriranje i pretraga ne obrisu tipove :@
        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            if(resursiTipSakrivenoIme.Count != 0)
            {
                foreach (TipResursa tip in resursiTipSakrivenoIme)
                {
                    resursiTip.Add(tip);

                }
            }
            if(resursiTipSakrivenoIme.Count != 0)
            {
                foreach (TipResursa tip in resursiTipSakrivenoIme)
                {
                    resursiTip.Add(tip);

                }
            }
            if(resursiTipSakriveniOpis.Count != 0)
            {
                foreach (TipResursa tip in resursiTipSakriveniOpis)
                {
                    resursiTip.Add(tip);

                }
               
            }
            if(resursiTipSakrivenaOznaka.Count != 0)
            {
                foreach (TipResursa tip in resursiTipSakrivenaOznaka)
                {
                    resursiTip.Add(tip);

                }
            }
        }
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            HelpProvider.ShowHelp("prozorTPT", this);

        }


        private void Izmijeni_Click(object sender, RoutedEventArgs e)
        {
            if ((TipResursa)dgrMainTip.SelectedItem == null)
            {
                MessageBox.Show("MORATE SELEKTOVATI TIP", "UPOZORENJE", MessageBoxButton.OKCancel);
            }
            else
            {
                TipResursa izabrani = (TipResursa)dgrMainTip.SelectedItem;

                WindowTip izmenaTipa = new WindowTip(izabrani, mwin);
                izmenaTipa.ShowDialog();
            }
        }
    }

   
}
