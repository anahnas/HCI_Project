using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace HCIProject1._2
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]
    public class JavaScriptControlHelper
    {
        private WindowEtiketa prozorE;
        private WindowTip prozorT;
        private WindowResurs prozorR;
        private MainWindow prozor;
        private WindowTipPregled prozorTPT;
        private WindowResursPregled prozorTP;
        private WindowEtiketaPregled prozorTPE;

        public JavaScriptControlHelper(WindowEtiketa w)
        {
            this.prozorE = w;
        }
        public JavaScriptControlHelper(WindowTip w)
        {
            this.prozorT = w;
        }
        public JavaScriptControlHelper(WindowResurs w)
        {
            this.prozorR = w;
        }

        public JavaScriptControlHelper(WindowResursPregled w)
        {
            this.prozorTP = w;
        }
        public JavaScriptControlHelper(WindowEtiketaPregled w)
        {
            this.prozorTPE = w;
        }
        public JavaScriptControlHelper(WindowTipPregled w)
        {
            this.prozorTPT = w;
        }

        public JavaScriptControlHelper(MainWindow w)
        {
            this.prozor = w;
        }




    }
}
