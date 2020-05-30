using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Runtime.Serialization;
//using System.Runtime.Serialization.Formatters.Binary;


namespace HCIProject1._2
{
    [DataContract]
    public class Etiketa : INotifyPropertyChanged//, ISerializable
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
        private string _Oznaka;
        [DataMember]
        private string _Boja;
        [DataMember]
        private string _Opis;
        [DataMember]
        private Color boja;

        /*public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            
            info.AddValue("Opis", _Opis);
            info.AddValue("Oznaka", _Oznaka);
        }
        //deserijalizacija
        public Etiketa(SerializationInfo info, StreamingContext ctxt)
        {
            _Oznaka = (string)info.GetValue("Oznaka", typeof(string));
            _Opis = (string)info.GetValue("Opis", typeof(string));
        }*/

        /*public Etiketa(string oznaka, string opis, string boja)
        {
            this.Oznaka = oznaka;
            this.Opis = opis;
            this.BojaString = boja;
        }*/
        public Etiketa(string oznaka, string opis)
        {
            this.Oznaka = oznaka;
            this.Opis = opis;
            
        }
        public Etiketa() { }


       
        [Browsable(false)]
        public string Oznaka
        {
            get
            {
                return _Oznaka;
            }
            set
            {
                if (_Oznaka != value)
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
                if (_Opis != value)
                {
                    _Opis = value;
                    OnPropertyChanged("Opis");

                }
            }
        }
        public Color Boja2
        {
            get { return boja; }

            set
            {
                if (value != boja)
                {
                    boja = value;
                    OnPropertyChanged("Boja");
                }

            }
        }

        public Brush Boja
        {
            get
            {
                BrushConverter bc = new BrushConverter();
                return (Brush)bc.ConvertFrom(_Boja);
            }
        }


        public Color BojaBrush
        {
            get
            {
                ColorConverter cc = new ColorConverter();
                return (Color)cc.ConvertFrom(_Boja);
            }
            set
            {
                _Boja = value.ToString();
            }
        }

        public String BojaString
        {
            get
            {
                return _Boja;
            }
            set
            {
                if (value != _Boja)
                {
                    _Boja = value;
                    OnPropertyChanged("Boja");
                }
            }
        }
    }
}
