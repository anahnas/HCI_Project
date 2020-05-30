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
    /// Interaction logic for WindowResursPregled.xaml
    /// </summary>
    public partial class WindowResursPregled : Window
    {

        private MainWindow mains;
        public WindowResursPregled(MainWindow mw)
        {
            mains = mw;
            InitializeComponent();
            this.DataContext = this;

            //ucitavanje
            Resursi = MainWindow.Resursi;
            TipoviResursa = MainWindow.TipoviResursa;

            //pretraga
            resursSakrivenoIme = new ObservableCollection<Resurs>();
            resursSakriveniOpis = new ObservableCollection<Resurs>();
            resursSakrivenaOznaka = new ObservableCollection<Resurs>();

            selectedIndex = -1;

            Closing += OnWindowClosing;

        }

        private int selectedIndex; //selektivano u dataGridu

        #region Dodavanje
        private void dodajAkcija(object sender, RoutedEventArgs e)
        {
            WindowResurs novi = new WindowResurs();
            novi.ShowDialog();
        }

        #endregion
        #region Brisanje
        private void obrisiAkcija(object sender, RoutedEventArgs e)
        {
            Resurs resurcic = (Resurs)dgrMain.SelectedItem;
            //Ako brisem resurs, uklonicu je i iz tipova koji nju sadrze
            foreach (TipResursa tr in MainWindow.TipoviResursa)
            {
                foreach (Resurs r in tr.SadrzaniResursi)
                {
                    if(r == resurcic)
                    {
                        tr.SadrzaniResursi.Remove(r);
                        break;
                    }

                }
 

            }
            MainWindow.Resursi.Remove(resurcic);
            if(MainWindow.naMapi.Contains(resurcic))
            {
                MainWindow.naMapi.Remove(resurcic);
            }


        }
        #endregion
        private void dgrMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ((DataGrid)sender).SelectedIndex;
            selectedIndex = index;
        }

        private void Izmijeni_Click(object sender, RoutedEventArgs e)
        {
            if ((Resurs)dgrMain.SelectedItem == null)
            {
                MessageBox.Show("MORATE SELEKTOVATI RESURS", "UPOZORENJE", MessageBoxButton.OKCancel);
            }
            else { 
                Resurs selektovani = (Resurs)dgrMain.SelectedItem;
                WindowResurs izmjenica = new WindowResurs(selektovani, mains);
                izmjenica.ShowDialog();
            }
        }

        private void Ponisti_Click(object sender, RoutedEventArgs e)
        {

            if (resursSakrivenoIme.Count != 0)
            {
                foreach (Resurs tip in resursSakrivenoIme)
                {
                    Resursi.Add(tip);

                }
                for (int i = resursSakrivenoIme.Count - 1; i >= 0; i--)
                {
                    resursSakrivenoIme.RemoveAt(i);

                }
            }
            if (resursSakriveniOpis.Count != 0)
            {
                foreach (Resurs item in resursSakriveniOpis)
                {
                    Resursi.Add(item);

                }
                for (int i = resursSakriveniOpis.Count - 1; i >= 0; i--)
                {
                    resursSakriveniOpis.RemoveAt(i);

                }
            }
            if (resursSakrivenaOznaka.Count != 0)
            {
                foreach (Resurs item in resursSakrivenaOznaka)
                {
                    Resursi.Add(item);

                }
                for (int i = resursSakrivenaOznaka.Count - 1; i >= 0; i--)
                {
                    resursSakrivenaOznaka.RemoveAt(i);

                }
            }
        }

        #region Pretrazi
        private void Pretraga_Click_R(object sender, RoutedEventArgs e)
        {
            String text = xIme.Text;

            if (text.Equals(""))
            {
                for (int i = 0; i < resursSakrivenoIme.Count; i++)
                {
                    Resursi.Add(resursSakrivenoIme[i]);

                }
                foreach (Resurs resurs in Resursi)
                {
                    resursSakrivenoIme.Remove(resurs);

                }

            } else
            {
                Console.WriteLine("evo meeeeeee");
                for (int i = 0; i < Resursi.Count; i++)
                {
                    bool b = Resursi[i].Ime.Contains(text);
                    if (!b)
                    {
                        Console.WriteLine("Ne sadrzi");
                        resursSakrivenoIme.Add(Resursi[i]);
                    }
                }
                foreach (Resurs r in resursSakrivenoIme)
                {
                    Resursi.Remove(r);

                }
                for (int i = 0; i < resursSakrivenoIme.Count; i++)
                {
                    bool b = resursSakrivenoIme[i].Ime.Contains(text);
                    if (b)
                    {
                        Resursi.Add(resursSakrivenoIme[i]);
                    }

                }
                foreach (Resurs r in Resursi)
                {
                    resursSakrivenoIme.Remove(r);

                }

            }
            text = xOpis.Text;
            if (text.Equals(""))
            {
                for (int i = 0; i < resursSakriveniOpis.Count; i++)
                {
                    Resursi.Add(resursSakriveniOpis[i]);
                }
                foreach (Resurs r in Resursi)
                {
                    resursSakriveniOpis.Remove(r);

                }
            }
            else
            {
                for (int i = 0; i < Resursi.Count; i++)
                {
                    bool b = Resursi[i].Opis.Contains(text);
                    if (!b)
                    {
                        resursSakriveniOpis.Add(Resursi[i]);
                    }

                }
                foreach (Resurs r in resursSakriveniOpis)
                {
                    Resursi.Remove(r);

                }
                for (int i = 0; i < resursSakriveniOpis.Count; i++)
                {
                    bool b = resursSakriveniOpis[i].Opis.Contains(text);
                    if (b)
                    {
                        Resursi.Add(resursSakriveniOpis[i]);
                    }

                }
                foreach (Resurs r in Resursi)
                {
                    resursSakriveniOpis.Remove(r);

                }

            }
            text = xOznaka.Text;
            if (text.Equals(""))
            {
                for (int i = 0; i < resursSakrivenaOznaka.Count; i++)
                {
                    Resursi.Add(resursSakrivenaOznaka[i]);

                }
                foreach (Resurs r in Resursi)
                {
                    resursSakrivenaOznaka.Remove(r);

                }
            }
            else
            {
                for (int i = 0; i < Resursi.Count; i++)
                {
                    bool b = Resursi[i].Oznaka.Contains(text);
                    if (!b)
                    {
                        resursSakrivenaOznaka.Add(Resursi[i]);
                    }

                }
                foreach (Resurs r in resursSakrivenaOznaka)
                {
                    Resursi.Remove(r);

                }
                for (int i = 0; i < resursSakrivenaOznaka.Count; i++)
                {
                    bool b = resursSakrivenaOznaka[i].Oznaka.Contains(text);
                    if (b)
                    {
                        Resursi.Add(resursSakrivenaOznaka[i]);
                    }
                }
                foreach (Resurs r in Resursi)
                {
                    resursSakrivenaOznaka.Remove(r);

                }
            }
        }
        #endregion

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            HelpProvider.ShowHelp("prozorTP", this);

        }

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            if (resursSakrivenoIme.Count != 0)
            {
                foreach (Resurs r in resursSakrivenoIme)
                {
                    Resursi.Add(r);

                }
            }
            if (resursSakrivenoIme.Count != 0)
            {
                foreach (Resurs tip in resursSakrivenoIme)
                {
                    Resursi.Add(tip);

                }
            }
            if (resursSakriveniOpis.Count != 0)
            {
                foreach (Resurs tip in resursSakriveniOpis)
                {
                    Resursi.Add(tip);

                }

            }
            if (resursSakrivenaOznaka.Count != 0)
            {
                foreach (Resurs tip in resursSakrivenaOznaka)
                {
                    Resursi.Add(tip);

                }
            }

        }

        #region Kolecije

        public ObservableCollection<Resurs> Resursi
        {
            get;
            set;
        }
        public static ObservableCollection<TipResursa> TipoviResursa
        {
            get;
            set;
        }

        public ObservableCollection<Resurs> resursSakrivenoIme
        {
            get;
            set;
        }

        public ObservableCollection<Resurs> resursSakrivenaOznaka
        {
            get;
            set;
        }
        public ObservableCollection<Resurs> resursSakriveniOpis
        {
            get;
            set;
        }

        #endregion
    }

}
