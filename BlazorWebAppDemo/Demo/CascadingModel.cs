using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BlazorWebAppDemo.Demo
{
    public class CascadingModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public string _someText = string.Empty;

        public string SomeText
        {
            get { return _someText; }
            set
            {
                _someText = value;
                OnPropertyChanged();
            }
        }

        //on every change of the property, it is going to notify any listeners to that change
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}


