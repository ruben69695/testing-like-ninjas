
using System.Drawing;

namespace TrollLibraries.ViewModel
{
    public class Jedi : Character, IPowerForce
    {
        private Color _lightSaberColor;

        public Color LightSaberColor
        {
            get => _lightSaberColor;
            set
            {
                _lightSaberColor = value;
                OnPropertyChanged(nameof(LightSaberColor));
            }
        }
    }
}