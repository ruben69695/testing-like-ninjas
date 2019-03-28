using System;
using System.Collections.ObjectModel;

using TrollLibraries.Logger;

namespace TrollLibraries.ViewModel
{
    public class StarWarsArenaViewModel : AbstractViewModel
    {
        public ObservableCollection<Jedi> Jedis { get; private set; }
        public ObservableCollection<Sith> Siths { get; private set; }
        public ObservableCollection<Combat> Combats { get; private set; }

        public string ViewModelTitle => _resourceManager.GetResource("StarWarsTitle");

        private readonly LoggerHelper _logger;
        private readonly StarWarsStorage _storage;
        private readonly ResourceManager _resourceManager;
        
        public StarWarsArenaViewModel()
        {
            _logger = new LoggerHelper(LoggerType.File);
            _storage = new StarWarsStorage();
            _resourceManager = new ResourceManager();
        }

        public override void Init()
        {
            Jedis = new ObservableCollection<Jedi>(_storage.GetJedis());
            Siths = new ObservableCollection<Sith>(_storage.GetSiths());
            Combats = new ObservableCollection<Combat>(_storage.GetCombats());
        }

        public void AddCombat(Jedi jedi, Sith sith)
        {
            if (jedi == null)
                throw new ArgumentNullException(nameof(jedi));
            if (sith == null)
                throw new ArgumentNullException(nameof(sith));
            
            if(Combats == null)
                Combats = new ObservableCollection<Combat>();

            var newCombat = new Combat(jedi, sith); 
            
            _storage.CreateCombat(newCombat);
            _storage.SaveChanges();
            
            Combats.Add(newCombat);
        }

        public void RemoveCombat(Combat combat)
        {
            if(combat == null)
                throw new ArgumentNullException(nameof(combat));

            Combats.Remove(combat);
            
            _storage.RemoveCombat(combat);
            _storage.SaveChanges();
        }
        
    }
}