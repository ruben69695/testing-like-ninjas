using System.Drawing;

namespace TrollLibraries.ViewModel
{
    public class Sith : Character, ISaberFighter
    {
        private Color _lightSaberColor;
        private string _deathStarPass;

        public string DeathStarPass
        {
            get => _deathStarPass;
            set
            {
                _deathStarPass = value;
                OnPropertyChanged(nameof(DeathStarPass));
            }
        }
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