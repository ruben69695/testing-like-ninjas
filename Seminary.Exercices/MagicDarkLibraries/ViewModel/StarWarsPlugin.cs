using MagicDarkLibraries.Logger;
using MagicDarkLibraries.ViewModel.Implementations;

namespace MagicDarkLibraries.ViewModel
{
    public class StarWarsPlugin
    {
        public AbstractViewModel ArenaViewModel { get; set; }
        
        public StarWarsPlugin() 
        {
        }

        public void Init()
        {
            var fileLogger = new FileLogger();
            var storage = new StarWarsStorage(fileLogger);
            var resourcesManager = new ResourcesManager();
            var successDialog = new CombatSuccessMessageDialog();
            
            ArenaViewModel = new StarWarsArenaViewModel(storage, resourcesManager, successDialog);
            ArenaViewModel.Init();
        }
    }
}