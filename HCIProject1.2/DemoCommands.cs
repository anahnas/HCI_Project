using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HCIProject1._2
{
    class DemoCommands
    {
        public static readonly RoutedUICommand ExitDemo = new RoutedUICommand(
            "Exit demo", "ExitDemo",
            typeof(DemoCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Escape)
            }
            );
    }
}
