using System.Drawing;
using MagicDarkLibraries.ViewModel.Interfaces;

namespace MagicDarkLibraries.ViewModel.Classes
{
    public class Jedi : Character, ISaberFighter
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