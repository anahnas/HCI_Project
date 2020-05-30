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
using System.Windows.Navigation;
using System.Windows.Shapes;
// Used for writing to a file
using System.IO;

using System.Threading;
using System.Xml;
using System.Runtime.Serialization;


namespace HCIProject1._2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.DataContext = this;
            var path = "C:\\Users\\DT User\\Desktop\\Test\\test1.xml";
            load(path);
            //za tipove
            /*XmlSerializer deserializerTipovi = new XmlSerializer(typeof(ObservableCollection<TipResursa>));
            FileStream fsTipovi = File.Open(@"C:\\Users\\DT User\\Desktop\\Test\\test1.xml", FileMode.Append);
            fsTipovi.Close();

            using (FileStream fsTipovi1 = File.OpenRead(@"C:\\Users\\DT User\\Desktop\\Test\\test1.xml"))
            {
                if (fsTipovi1.Length != 0)
                    TipoviResursa = (ObservableCollection<TipResursa>)deserializerTipovi.Deserialize(fsTipovi1);
            }

             //resursi cuvanje
             XmlSerializer deserializerResursi = new XmlSerializer(typeof(ObservableCollection<Resurs>));
             FileStream fsResursi = File.Open(@"C:\\Users\\DT User\\Desktop\\Test\\test3.xml", FileMode.Append);
             fsResursi.Close();

             using (FileStream fsResursi1 = File.OpenRead(@"C:\\Users\\DT User\\Desktop\\Test\\test3.xml"))
             {
                 if (fsResursi1.Length != 0)
                     Resursi = (ObservableCollection<Resurs>)deserializerResursi.Deserialize(fsResursi1);
             }

            //etikete cuvanje

            XmlSerializer deserializerEtikete = new XmlSerializer(typeof(ObservableCollection<Etiketa>));
            FileStream fsEtikete = File.Open(@"C:\\Users\\DT User\\Desktop\\Test\\test2.xml", FileMode.Append);
            fsEtikete.Close();

            using (FileStream fsEtikete1= File.OpenRead(@"C:\\Users\\DT User\\Desktop\\Test\\test2.xml"))
            {
                if (fsEtikete1.Length != 0)
                    Etikete = (ObservableCollection<Etiketa>)deserializerEtikete.Deserialize(fsEtikete1);
            }*/


            InitializeComponent();
            TipoviResursa = new ObservableCollection<TipResursa>();
            Resursi = new ObservableCollection<Resurs>();
            Etikete = new ObservableCollection<Etiketa>();
            naMapi = new ObservableCollection<Resurs>();
            if(TipoviResursa.Count==0)
            {
                DodajResursButton.IsEnabled = false;
            }
            this.Closed += new EventHandler(MainWindow_Closed);
        }

       void MainWindow_Closed(object sender, EventArgs e)
        {
            var path = "C:\\Users\\DT User\\Desktop\\Test\\test1.xml";
            save(path);

        }

        public void load(String path)
        {
            if(File.Exists(path) == false)
            {
                Etikete = new ObservableCollection<Etiketa>();
                TipoviResursa = new ObservableCollection<TipResursa>();
                Resursi = new ObservableCollection<Resurs>();
                naMapi = new ObservableCollection<Resurs>();
                return;
            }
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                if(fs.Length == 0)
                {
                    Etikete = new ObservableCollection<Etiketa>();
                    TipoviResursa = new ObservableCollection<TipResursa>();
                    Resursi = new ObservableCollection<Resurs>();
                    naMapi = new ObservableCollection<Resurs>();
                    return;
                }
                DataContractSerializer dcs = new DataContractSerializer(typeof(Listice));
                XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                Listice ap = (Listice)dcs.ReadObject(reader);

                Etikete = ap.Etikete;
                TipoviResursa = ap.TipoviResursa;
                Resursi = ap.Resursi;
                naMapi = ap.naMapi;

                fs.Close();
            }
        }

        public void save(String path)
        {
            if (MessageBox.Show("Da li zelite da sacuvate podatke?", "Izlaz iz programa", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    Listice ap = new Listice();
                    ap.Etikete = Etikete;
                    ap.TipoviResursa = TipoviResursa;
                    ap.Resursi = Resursi;
                    ap.naMapi = naMapi;
                    var serializer = new DataContractSerializer(ap.GetType(), null, 0x7FFF, false, true, null);
                    serializer.WriteObject(fs, ap);
                    fs.Close();
                }
            }
        }

        private void sacuvajTip_Click(object sender, RoutedEventArgs e)
        {
            /*using (Stream fs = new FileStream(@"C:\Users\DT User\Desktop\Test\test1.xml", FileMode.Create, FileAccess.Write,
                FileShare.None))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<TipResursa>));
                serializer.Serialize(fs, TipoviResursa);
            }*/


            MessageBox.Show("Uspešno ste sačuvali tipove!", "Čuvanje tipova", MessageBoxButton.OK);
        }

        private void sacuvajResurs_Click(object sender, RoutedEventArgs e)
        {
            /*using (Stream fs = new FileStream(@"C:\Users\DT User\Desktop\Test\test3.xml", FileMode.Create, FileAccess.Write,
                FileShare.None))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Resurs>));
                serializer.Serialize(fs, Resursi);
            }*/


            MessageBox.Show("Uspešno ste sačuvali resurse!", "Čuvanje resursa", MessageBoxButton.OK);
        }

        private void sacuvajEtiketu_Click(object sender, RoutedEventArgs e)
        {
           /* using (Stream fs = new FileStream(@"C:\Users\DT User\Desktop\Test\test2.xml", FileMode.Create, FileAccess.Write,
                FileShare.None))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Etiketa>));
                serializer.Serialize(fs,  Etikete);
            }*/


            MessageBox.Show("Uspešno ste sačuvali etikete!", "Čuvanje etiketa", MessageBoxButton.OK);
        }

        #region Precice
        private void DodajResurs_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void DodajResurs_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            WindowResurs resurs = new WindowResurs();
            resurs.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            resurs.ShowDialog();
        }
        private void DodajTip_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void DodajTip_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            WindowTip resurs = new WindowTip();
            resurs.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            resurs.ShowDialog();
        }

        private void DodajEtiketu_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void DodajEtiketu_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            WindowEtiketa resurs = new WindowEtiketa();
            resurs.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            resurs.ShowDialog();
        }

        private void Izlaz_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Izlaz_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void PregledResursa_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void PregledResursa_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            WindowResursPregled resurs = new WindowResursPregled(this);
            resurs.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            resurs.ShowDialog();
        }
        private void PregledTipova_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void PregledTipova_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            WindowTipPregled resurs = new WindowTipPregled(this);
            resurs.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            resurs.ShowDialog();
        }

        private void PregledEtiketa_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void PregledEtiketa_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            WindowEtiketaPregled resurs = new WindowEtiketaPregled();
            resurs.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            resurs.ShowDialog();
        }



        #endregion

        #region Dugmici
        private void dodajTip_Click(object sender, RoutedEventArgs e)
        {
            WindowTip novi = new WindowTip(this);
            novi.ShowDialog();
        }

        private void pregledTip_Click(object sender, RoutedEventArgs e)
        {
            WindowTipPregled wtp = new WindowTipPregled(this);
            wtp.ShowDialog();
        }



        private void dodajResurs_Click(object sender, RoutedEventArgs e)
        {
            WindowResurs novi = new WindowResurs();
            novi.ShowDialog();
        }

        private void pregledResurs_Click(object sender, RoutedEventArgs e)
        {
            WindowResursPregled novi = new WindowResursPregled(this);
            novi.ShowDialog();
        }

        private void dodajEtiketu_Click(object sender, RoutedEventArgs e)
        {
            WindowEtiketa et = new WindowEtiketa();
            et.ShowDialog();
        }

        private void pregledEtiketa_Click(object sender, RoutedEventArgs e)
        {
            WindowEtiketaPregled et = new WindowEtiketaPregled();
            et.ShowDialog();
        }
        #endregion

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            HelpProvider.ShowHelp("MainWindow", this);
        }
        private void Pomoc_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Pristupu pomoci za koriscenje ove aplikacije vrsi se pomocu F1 dugmeta, takodje, pri otvaranju bilo kog dijaloga takodje " +
                "mozete pristupiti pomoci sa F1 za vise detalja o bas tom dijalogu!", "Pomoc", MessageBoxButton.OK);
        }


        private void Zatvori_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Tree_DoubleClick(object sender, RoutedEventArgs e)
        {
            if (xTree.SelectedItem is Resurs)
            {
                Resurs uv = (Resurs)xTree.SelectedItem;
                WindowResurs w1 = new WindowResurs(uv, this);
                w1.ShowDialog();
            }
            else if (xTree.SelectedItem is TipResursa)
            {
                TipResursa tv = (TipResursa)xTree.SelectedItem;
                WindowTip w2 = new WindowTip(tv, this);
                w2.ShowDialog();
            }
        }

        public void Mapa_DoubleClick(object sender, RoutedEventArgs e)
        {
            if (NaMapi.SelectedItem is Resurs)
            {
                Resurs uv = (Resurs)NaMapi.SelectedItem;
                WindowResurs w1 = new WindowResurs(uv, this);
                w1.ShowDialog();

            }
        }




        #region Podaci
        public static ObservableCollection<TipResursa> TipoviResursa
        {
            get;
            set;
        }

        public static ObservableCollection<Resurs> Resursi
        {
            get;
            set;
        }
        public static ObservableCollection<Etiketa> Etikete
        {
            get;
            set;
        }
        public static ObservableCollection<Resurs> naMapi
        {
            get;
            set;
        }


        #endregion

        #region Drag and Drop
        private Point startPoint = new Point();
        private Boolean isDragging = false;

        //sluzi da se preuzme pocetna tacka kada se klikne negdje, ista moze i za mapu i za drvo
        private void Tree_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        //da ne bih morala da komplikujem kao oni da bih nasla TreeViewItem + njihovo cak i ne radi ako je redefinisan 
        //prikaz cvorova u drvetu
        private void TreeViewItem_OnItemSelected(object sender, RoutedEventArgs e)
        {
            xTree.Tag = e.OriginalSource;
        }

        //za drag iz drva. zapocinje drag ako je neko kliknuo na item u drvetu i vuce ga
        private void Tree_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && !isDragging)
            {
                Point position = e.GetPosition(null);
                if (Math.Abs(position.X - startPoint.X) > SystemParameters.MinimumHorizontalDragDistance || Math.Abs(position.Y - startPoint.Y) > SystemParameters.MinimumVerticalDragDistance)
                {
                    StartDrag(e);
                }
            }
        }
        //poziva se iz one iznad. Ovde je zapravo posao
        private void StartDrag(MouseEventArgs e)
        {
            //obavezno if! tipovi se ne mogu dragovati, a ovako ako je neko slucajno kliknuo negde na drvo ne moze ni to
            if (xTree.SelectedItem is Resurs)
            {
                isDragging = true;

                Resurs selectedItem = (Resurs)xTree.SelectedItem;
                TreeViewItem tvi = xTree.Tag as TreeViewItem;
                // Initialize the drag & drop operation                
                DataObject dragData = new DataObject("resursDrag", selectedItem);
                if (isDragging == true)
                    DragDrop.DoDragDrop(tvi, dragData, DragDropEffects.Move);
                //ovde se dodje tek kada se spusti objekat
                isDragging = false;
            }
        }

        //ovo sluzi za pokretanje draga sa mape
        private void NaMapi_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && !isDragging)
            {
                Point position = e.GetPosition(null);
                if (Math.Abs(position.X - startPoint.X) > SystemParameters.MinimumHorizontalDragDistance || Math.Abs(position.Y - startPoint.Y) > SystemParameters.MinimumVerticalDragDistance)
                {
                    StartDragMap(e);
                }
            }
        }

        //funkcija koja zapravo pokrene drag sa mape
        private void StartDragMap(MouseEventArgs e)
        {
            if (NaMapi.SelectedItem is Resurs) //zbog null, ako je neko krenuo da vuce po mapi bezveze
            {
                isDragging = true;
                Resurs selectedItem = (Resurs)NaMapi.SelectedItem;
                ListBoxItem lwi = (ListBoxItem)NaMapi.ItemContainerGenerator.ContainerFromItem(selectedItem);
                // Initialize the drag & drop operation
                DataObject dragData = new DataObject("resursDrag", selectedItem);
                if (isDragging == true)
                    DragDrop.DoDragDrop(lwi, dragData, DragDropEffects.Move);
                isDragging = false;
            }
        }

        //ovo sluzi da prikaze da se na mapu moze spustiti objekat
        private void NaMapi_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("resursDrag") && e.Source== sender) //ni slucajno od njih e.source == sender dodati. Onda ne moze po mapi da se pomijera
            {
                e.Effects = DragDropEffects.None;
            }

        }

        //ovo sluzi da se prikaze da se na drvo moze spustiti objekat
        private void Tree_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("resursDrag"))
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void Tree_DragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("resursDrag"))
            {
                e.Effects = DragDropEffects.None;
                e.Handled = true;
            }
            else //ova komplikacija je da se resursi ne mogu uzeti iz drveta i vratiti u drvo, jer je glupo
            {
                Resurs uv = e.Data.GetData("resursDrag") as Resurs;
                if (uv.Point.X == -1)
                {
                    e.Effects = DragDropEffects.None;
                    e.Handled = true;
                }
            }
        }

        //ubacuje resurs sa drveta na mapu

        private void NaMapi_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("resursDrag"))
            {

                Resurs uv = e.Data.GetData("resursDrag") as Resurs;
                naMapi.Add(uv);
                Console.WriteLine("Dropovan " + uv.Ime);
                uv.Point = e.GetPosition(NaMapi);
                /*if (!naMapi.Contains(uv))
                {
                    
                    naMapi.Add(uv);
                }*/
                //observable vezana za listu iz mape
                Image lbl = new Image();
                lbl.Source = uv.Ikonica;
                lbl.ToolTip = "ana promeni me";

                Canvas.SetLeft(lbl, uv.Point.X);
                Canvas.SetTop(lbl, uv.Point.Y);

                NaMapi.ItemsSource = naMapi;
                Console.WriteLine(naMapi.Count);
                isDragging = false;
            }
        }

        private void Tree_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("resursDrag"))
            {
                Resurs uv = e.Data.GetData("resursDrag") as Resurs;
                //one sve f-je iznad samo mijenjaju mis da korisnik vidi da ne moze drop, a ako ipak drop, ovo sprjecava efekat 
                //kod mene je point(-1,-1) ako nesto nije na mapi             
                Console.WriteLine("Tree Drop");
                NaMapi.ItemsSource = naMapi;
                naMapi.Remove(uv);//observable vezana za listu iz mape
                Console.WriteLine("Obrisan: " + naMapi.Count);
                uv.Point = new Point(-1, -1);
                isDragging = false;
            }
        }





        #endregion
        #region Demo
        private void demo_Begin(object sender, RoutedEventArgs e)
        {
            demoMode = true;
            Point p = dodajTipDugme.PointToScreen(new Point(0d, 0d));
            p.X += 20;
            p.Y += 10;

            LinearSmoothMove(p, 100);

            WindowTip w2 = new WindowTip(this);
            w2.Show();
            Thread.Sleep(500);
            Application.Current.Dispatcher?.BeginInvoke(new Action(() => {

                w2.beginDemo();
            }));


        }


        public void LinearSmoothMove(Point newPosition, int steps)
        {
            if (demoMode)
            {
                Point start = Win32.GetMousePosition();
                Point iterPoint = start;

                // Find the slope of the line segment defined by start and newPosition
                Point slope = new Point(newPosition.X - start.X, newPosition.Y - start.Y);

                // Divide by the number of steps
                slope.X = slope.X / steps;
                slope.Y = slope.Y / steps;

                // Move the mouse to each iterative point.
                for (int i = 0; i < steps; i++)
                {
                    if (!demoMode)
                    {
                        return;
                    }
                    iterPoint = new Point(iterPoint.X + slope.X, iterPoint.Y + slope.Y);
                    Win32.SetCursorPos((int)iterPoint.X, (int)iterPoint.Y);
                    Thread.Sleep(20);
                }

                // Move the mouse to the final destination.
                Win32.SetCursorPos((int)newPosition.X, (int)newPosition.Y);
            }
        }
        private Boolean demoMode = false;

        private void ExitDemo_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (demoMode == true)
            {
                e.CanExecute = true;
            }
        }

        private void ExitDemo_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            demoMode = false;
        }

        #endregion
    }
}
