using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;

namespace HCIProject1._2
{
    [DataContract]
    public class Listice
    {
        [DataMember]
        public ObservableCollection<TipResursa> TipoviResursa
        {
            get;
            set;
        }
        [DataMember]
        public ObservableCollection<Etiketa> Etikete
        {
            get;
            set;
        }
        [DataMember]
        public ObservableCollection<Resurs> Resursi
        {
            get;
            set;
        }
        [DataMember]
        public ObservableCollection<Resurs> naMapi
        {
            get;
            set;
    
        }


    }
}
