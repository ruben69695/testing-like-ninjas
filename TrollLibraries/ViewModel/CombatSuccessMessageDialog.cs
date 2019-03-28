using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace TrollLibraries.ViewModel
{
    public class CombatSuccessMessageDialog : INotifyPropertyChanged
    {
        private readonly ResourceManager _resourceManager;
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
            _resourceManager = new ResourceManager();
        }

        public void ShowDialog()
        {
            Title = _resourceManager.GetResource("RemoveCombatTitle");
            Message = _resourceManager.GetResource("MessageRemoveCombat");
            Image = Encoding.ASCII.GetBytes(_resourceManager.GetResource("RemoveCombatSuccessImage"));
            
            // Show Message to the user...
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