using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public void ChangeValue([CallerMemberName] string propName = "")
        {
            if (!string.IsNullOrEmpty(propName))
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            }

        }
    }
}
