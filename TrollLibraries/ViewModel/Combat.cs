using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TrollLibraries.ViewModel
{
    public class Combat : INotifyPropertyChanged
    {
        private Jedi _jedi;
        private Sith _sith;

        public Jedi Jedi
        {
            get => _jedi;
            set
            {
                _jedi = value;
                OnPropertyChanged(nameof(Jedi));
            }
        }

        public Sith Sith
        {
            get => _sith;
            set
            {
                _sith = value;
                OnPropertyChanged(nameof(Sith));
            }
        }

        public Combat(Jedi jedi, Sith sith)
        {
            Jedi = jedi;
            Sith = sith;
        }

        #region INotifyPropertyChanged Implementation
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        #endregion
    }
}