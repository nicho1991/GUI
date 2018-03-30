using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SimpleDraw.Model
{
    class SimpleDrawModel
    {
        public SolidColorBrush BlueBrush { get;} = new SolidColorBrush(Colors.Aqua);
        public SolidColorBrush RedBrush { get;} = new SolidColorBrush(Colors.Red);
        public SolidColorBrush GreenBrush { get;} = new SolidColorBrush(Colors.Green);

    }
}
