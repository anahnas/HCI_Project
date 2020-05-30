using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
//using System.Runtime.Serialization.Formatters.Binary;



namespace HCIProject1._2
{
    [DataContract]
    public class TipResursa : INotifyPropertyChanged//, ISerializable

    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        [DataMember]
        private string _Oznaka="";

        [DataMember]
        private string _Ime="";

        [DataMember]
        private string _Opis="";

        [DataMember]
        private string _ImagePath;

        [DataMember]
        private string _imgUrl;
        [DataMember]
        private ObservableCollection<Resurs> _sadrzaniResursi = new ObservableCollection<Resurs>();

        
       /* public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Ime", _Ime);
            info.AddValue("Opis", _Opis);
            info.AddValue("Oznaka", _Oznaka);
            info.AddValue("ImagePath", _ImagePath);
        }
        //deserijalizacija
        public TipResursa(SerializationInfo info, StreamingContext ctxt)
        {
            _Ime = (string)info.GetValue("Ime", typeof(string));
            _Oznaka = (string)info.GetValue("Oznaka", typeof(string));
            _Opis = (string)info.GetValue("Opis", typeof(string));
            _ImagePath = (string)info.GetValue("ImagePath", typeof(string));
        }*/

        public ObservableCollection<Resurs> SadrzaniResursi
        {
            get
            {
                return _sadrzaniResursi;
            }
            set
            {
                if(value != _sadrzaniResursi)
                {
                    _sadrzaniResursi = value;
                    OnPropertyChanged("SadrzaniResursi");
                }
            }

        }
    

        public string ImeResursa
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

        public string ImagePath
        {

            get
            {
                return _ImagePath;
            } set
            {
                if(value != _ImagePath)
                {
                    _ImagePath = value;
                    OnPropertyChanged("ImagePath");
                }
            }
        }

        public BitmapImage Ikonica
        {
            get
            {
                // if (_imgUrl != null)
                //{
                Uri uri = new Uri(_ImagePath);
                BitmapImage bmpimg = null;
                try
                {
                    bmpimg = new BitmapImage(uri);

                }
                catch (Exception e)
                {

                }
                return bmpimg;
            }
        }
               /* else
                {
                    Console.WriteLine("Nije pronadjena slika!");
                    return new BitmapImage(new Uri("Images/type.png", UriKind.Relative));
                }
            }
            set
            {
                OnPropertyChanged("Ikonica");

            }
        }*/

        public string Ime
        {
            get
            {
                return _Ime;
            }
        }
        /*public TipResursa() { }
        public TipResursa(string oznaka, string ime, string opis, string image)
        {
            this.Oznaka = oznaka;
            this.ImeResursa = ime;
            this.Opis = opis;
            this.ImagePath = image;
        }*/
    }
}
