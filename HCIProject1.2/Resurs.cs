using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Runtime.Serialization;
//using System.Runtime.Serialization.Formatters.Binary;

namespace HCIProject1._2
{
    [DataContract]
    public class Resurs : INotifyPropertyChanged//, ISerializable
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

       /* public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Opis", _Opis);
            info.AddValue("Oznaka", _Oznaka);
            info.AddValue("Ime", _Ime);
            info.AddValue("Frekvencija", _Frekvencija);
            info.AddValue("JedinicaMjere", _JedinicaMjere);
            info.AddValue("Cijena", _Cijena);
            info.AddValue("imagePath", _imagePath);
            info.AddValue("Obnovljiv", obnovljiv);
            info.AddValue("StrateskaVaznost", strateskaVaznost);
            info.AddValue("Eksploatacija", eksploatacija);
            info.AddValue("Datum", datum);
            info.AddValue("TipResursa", _tipResursa);


        }
        //deserijalizacija
        public Resurs(SerializationInfo info, StreamingContext ctxt)
        {
            _Oznaka = (string)info.GetValue("Oznaka", typeof(string));
            _Opis = (string)info.GetValue("Opis", typeof(string));
            _Ime = (string)info.GetValue("Ime", typeof(string));
            _Frekvencija = (int)info.GetValue("Frekvencija", typeof(int));
            _JedinicaMjere = (int)info.GetValue("JedinicaMjere", typeof(int));
            _Cijena = (int)info.GetValue("Cijena", typeof(int));
            _imagePath = (string)info.GetValue("imagePath", typeof(string));
            obnovljiv = (int)info.GetValue("Obnovljiv", typeof(int));
            strateskaVaznost = (int)info.GetValue("StrateskaVaznost", typeof(int));
            eksploatacija = (int)info.GetValue("Eksploatacija", typeof(int));
            datum = (string)info.GetValue("Datum", typeof(string));
            _tipResursa = (TipResursa)info.GetValue("TipResursa", typeof(TipResursa));
        }*/
        

        // public enum frekvencija { RIJEDAK = 0, CEST = 1, UNIVERZALAN = 2 };
        // public enum jedinicaMjere { MERICA = 0, BAREL = 1, TONA = 2, KILOGRAM = 3 };
        [DataMember]
        private string _Oznaka = "";
        [DataMember]
        private string _Ime = "";
        [DataMember]
        private string _Opis = "";
        [DataMember]
        private TipResursa _tipResursa;
        // private frekvencija frekv = 0;
        // private jedinicaMjere jedinica = 0;
        [DataMember]
        private int _Frekvencija;
        [DataMember]
        private int _JedinicaMjere;
        [DataMember]
        private int _Cijena;
        //private ImageSource ikonica;
        [DataMember]
        private string _imgUrl;
        [DataMember]
        private string _imagePath;
        [DataMember]
        private int obnovljiv;
        [DataMember]
        private int strateskaVaznost;
        [DataMember]
        private int eksploatacija;
        [DataMember]
        private string datum;
        [DataMember]
        public DateTime datumOtkrivanja = DateTime.Today;
        [DataMember]
        private Point _point;
        [DataMember]
        private ObservableCollection<Etiketa> _etikete;

        public DateTime Datum
        {
            get { return datumOtkrivanja; }

            set
            {
                if (value != datumOtkrivanja)
                {
                    datumOtkrivanja = value;
                    OnPropertyChanged("Datum");
                }
            }
        }


        public ObservableCollection<Etiketa> Etikete
        {
            get
            {
                return _etikete;
            }
            set
            {
                _etikete = value;
            }
        }
        public Point Point
        {
            get
            {
                return _point;
            }
            set
            {
                if (value != _point)
                {
                    _point = value;
                    OnPropertyChanged("Point");
                }
            }
        }

        public string Ime
        {
            get
            {
                return _Ime;
            }
            set
            {
                if (value != _Ime)
                {
                    _Ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }

        public string Oznaka
        {
            get
            {
                return _Oznaka;
            }
            set
            {
                if (value != _Oznaka)
                {
                    _Oznaka = value;
                    OnPropertyChanged("Oznaka");
                }
            }
        }

        public string imagePath
        {
            get
            {
                return _imgUrl;
            }
            set
            {
                if (value != _imgUrl)
                {
                    _imgUrl = value;
                    OnPropertyChanged("imagePath");
                    Ikonica = null;
                }
            }
        }
        public BitmapImage Ikonica
        {
            get
            {
                if (_imgUrl != null)
                {
                    BitmapImage bmpimg = null;
                    try
                    {
                        Uri uri = new Uri(_imgUrl);

                        bmpimg = new BitmapImage(uri);

                    }
                    catch (Exception e)
                    {

                    }
                    return bmpimg;
                }
                else
                {
                    Console.WriteLine("Nije pronadjena slika!");
                    return new BitmapImage(new Uri("Images/resources.png", UriKind.Relative));

                }

            }
            set
            {
                OnPropertyChanged("Ikonica");
            }
        }

        public string Opis
        {
            get
            {
                return _Opis;
            }
            set
            {
                if (value != _Opis)
                {
                    _Opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }

        public string Cijena
        {
            get
            {
                return _Cijena.ToString();
            } set
            {
                if (!value.Equals(""))
                {
                    if (Int32.Parse(value) != _Cijena)
                    {
                        _Cijena = Int32.Parse(value);
                        OnPropertyChanged("Cijena");
                    }
                }
            }
        }

        public TipResursa TipResursa
        {
            get
            {
                return _tipResursa;
            }
            set
            {
                if(value!=_tipResursa)
                {
                    _tipResursa = value;
                    OnPropertyChanged("TipResursa");
                }
            }
        }
         public int Frekvencijaa
         {
             get
             {
                 return _Frekvencija;
             }
             set
             {
                 if (value != _Frekvencija)
                 {
                     _Frekvencija = value;
                     OnPropertyChanged("Frekvencijaa");
                 }
             }
         }
 
        public int JedinicaMjere
        {
            get
            {
                return _JedinicaMjere;
            }
            set
            {
                if (value != _JedinicaMjere)
                {
                    _JedinicaMjere = value;
                    OnPropertyChanged("Jedinicaa");
                }
            }

        }



        public int Obnovljiv
        {
            get
            {
                return obnovljiv;
            }
            set
            {
                if (value != obnovljiv)
                {
                    obnovljiv = value;
                    OnPropertyChanged("Obnovljiv");
                }
            }
        }

        public int StrateskaVaznost
        {
            get
            {
                return strateskaVaznost;
            }
            set
            {
                if (value != strateskaVaznost)
                {
                    strateskaVaznost = value;
                    OnPropertyChanged("StrateskaVaznost");
                }
            }
        }

        public int Eksploatacija
        {
            get
            {
                return eksploatacija;
            }
            set
            {
                if (value != eksploatacija)
                {
                    eksploatacija = value;
                    OnPropertyChanged("Eksploatacija");
                }
            }
        }

       /* public string DatumOtkrivanja
        {
            get
            {
                if (!datum.Equals(""))
                {
                    string[] splitovano = datum.Split(' ');
                    return splitovano[0];
                }
                else
                {
                    return "Nema";
                }
            }
            set
            {
                if (value != datum)
                {
                    datum = value;
                    OnPropertyChanged("DatumOtkrivanja");
                }
            }
        }*/


       /* public Resurs() { }
        public Resurs(string oznaka, string ime, string opis, string ikonica, string datum, string cijena, int frekv, int jed, int obn, int strat, int eksp, TipResursa tipp)
        {
            this.Oznaka = oznaka;
            this.Opis = opis;
            this.Ime = ime;
            this.imagePath = ikonica;
            this.DatumOtkrivanja = datum;
            this.Cijena = cijena;
            this.Frekvencijaa = frekv;
            this.JedinicaMjere = jed;
            this.Obnovljiv = obn;
            this.StrateskaVaznost = strat;
            this.Eksploatacija = eksp;
            this.TipResursa = tipp;

        }*/

    }
}
