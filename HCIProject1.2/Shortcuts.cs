using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HCIProject1._2
{
    public static class Shortcuts
    {
        public static readonly RoutedUICommand DodajResurs = new RoutedUICommand(
            "Resurs",
            "DodajResurs",
            typeof(Shortcuts),
            new InputGestureCollection()
            {
                new KeyGesture(Key.R, ModifierKeys.Control)
            });

        public static readonly RoutedUICommand DodajTip = new RoutedUICommand(
            "TipResursa",
            "DodajTip",
            typeof(Shortcuts),
            new InputGestureCollection()
            {
                new KeyGesture(Key.T, ModifierKeys.Control)
            });

        public static readonly RoutedUICommand DodajEtiketu = new RoutedUICommand(
          "Etiketa",
          "DodajEtiketu",
          typeof(Shortcuts),
          new InputGestureCollection()
          {
                new KeyGesture(Key.E, ModifierKeys.Control)
          });

        public static readonly RoutedUICommand Izlaz = new RoutedUICommand(
            "Izlaz",
            "Izlaz",
            typeof(Shortcuts),
            new InputGestureCollection()
            {
                new KeyGesture(Key.F4, ModifierKeys.Alt)
            });

            public static readonly RoutedUICommand PregledR = new RoutedUICommand(
            "PregledResursa",
            "PregledResursa",
            typeof(Shortcuts),
            new InputGestureCollection()
            {
                new KeyGesture(Key.P, ModifierKeys.Control)
            });

            public static readonly RoutedUICommand PregledT = new RoutedUICommand(
            "PregledT",
            "PregledTipova",
            typeof(Shortcuts),
            new InputGestureCollection()
            {
                new KeyGesture(Key.L, ModifierKeys.Control)
            });

           public static readonly RoutedUICommand PregledE = new RoutedUICommand(
           "PregledE",
           "PregledEtiketa",
           typeof(Shortcuts),
           new InputGestureCollection()
           {
                new KeyGesture(Key.V, ModifierKeys.Control)
           });






    }
}
