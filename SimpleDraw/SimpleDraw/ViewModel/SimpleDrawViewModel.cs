
using System;
using System.ComponentModel;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using BMICalculator.ViewModel;
using SimpleDraw.Annotations;
using SimpleDraw.Model;

namespace SimpleDraw
{
    public class ViewModelLocator
    {
        public SimpleDrawViewModel SimpleDrawViewModel => new SimpleDrawViewModel();
    }
    public class SimpleDrawViewModel : BaseViewModel
    {
        SimpleDrawModel simpleModel = new SimpleDrawModel();
        public string Test { get; set; }

        public SolidColorBrush BlueBrush
        {
            get => simpleModel.BlueBrush;
        }

        public SolidColorBrush GreenBrush
        {
            get => simpleModel.GreenBrush;
        }

        public SolidColorBrush RedBrush
        {
            get => simpleModel.RedBrush;
        }

        public SolidColorBrush CurrentBrush { get; set; }

        public int ColorIndex { get; set; }
        public SimpleDrawViewModel()
        {
            Task.Run(async () =>
            {
                int i = 0;
                while (true)
                {
                    await Task.Delay(200);
                    Test = (i++).ToString();
                    
                }
            });
        }

        private ICommand _ChangeColorCommand;

        public ICommand ChangeColorCommand
        {
            get
            {
                return _ChangeColorCommand ??
                       (_ChangeColorCommand = new RelayCommand<object>(ChangeColor, ChangeColorCanExecute));
            }
        }

        private void ChangeColor(object parameter)
        {
            
        }

        private bool ChangeColorCanExecute(object parameter)
        {
            return true;
        }

    }
}
