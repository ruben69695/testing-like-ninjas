using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TrollLibraries.ViewModel
{
    public class Character : INotifyPropertyChanged
    {
        private string _name;
        private string _intergalacticBoard;

        public string Name
        {
            get => _name;
            set
            {
                _name = value; 
                OnPropertyChanged(nameof(Name));
            }
        }
        public string IntergalacticBoard
        {
            get => _intergalacticBoard;
            set
            {
                _intergalacticBoard = value;
                OnPropertyChanged(nameof(IntergalacticBoard));
            }
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