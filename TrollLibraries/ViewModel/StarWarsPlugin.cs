namespace TrollLibraries.ViewModel
{
    public class StarWarsPlugin
    {
        public StarWarsArenaViewModel ArenaViewModel { get; set; }
        
        public StarWarsPlugin() 
        {
        }

        public void Init()
        {
            ArenaViewModel = new StarWarsArenaViewModel();
            ArenaViewModel.Init();
        }
    }
}