
using System.ComponentModel;

namespace SimpleDraw
{

    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        
    }
}
