using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using MagicDarkLibraries.ViewModel.Interfaces;

namespace MagicDarkLibraries.ViewModel.Implementations
{
    public class CombatSuccessMessageDialog : IDialogSuccess, INotifyPropertyChanged
    {
        private readonly ResourcesManager _resourcesManager;
        private string _title;
        private string _message;
        private byte[] _image;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public byte[] Image
        {
            get => _image;
            set
            {
                _image = value;
                OnPropertyChanged(nameof(Image));
            }
        }
        
        public CombatSuccessMessageDialog()
        {
            _resourcesManager = new ResourcesManager();
        }

        public void ShowDialog()
        {
            Title = _resourcesManager.GetResource("RemoveCombatTitle");
            Message = _resourcesManager.GetResource("MessageRemoveCombat");
            Image = Encoding.ASCII.GetBytes(_resourcesManager.GetResource("RemoveCombatSuccessImage"));
            
            // Show Message to the user...
        }
        
        #region INotifyPropertyChanged Implementation
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        #endregion
        
    }
}