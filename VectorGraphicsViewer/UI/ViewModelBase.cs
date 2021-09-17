using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace VectorGraphicsViewer.UI
{
    /// <summary>
    /// A class with basic implementation required by all view models
    /// </summary>
    public abstract class ViewModelBase: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
