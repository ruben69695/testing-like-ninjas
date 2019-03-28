using System;
using System.Collections.ObjectModel;

using MagicDarkLibraries.Logger;
using MagicDarkLibraries.ViewModel.Interfaces;
using MagicDarkLibraries.ViewModel.Classes;

namespace MagicDarkLibraries.ViewModel
{
    public class StarWarsArenaViewModel : AbstractViewModel
    {
        public ObservableCollection<Jedi> Jedis { get; private set; }
        public ObservableCollection<Sith> Siths { get; private set; }
        public ObservableCollection<Combat> Combats { get; private set; }

        public string ViewModelTitle => _resources.GetResource("StarWarsTitle");

        private readonly IStarWarsStorage _storage;
        private readonly IResources _resources;
        private readonly IDialog _successDialog;
        
        public StarWarsArenaViewModel(IStarWarsStorage storage, IResources resources, IDialog successDialog)
        {
            _storage = storage;
            _resources = resources;
            _successDialog = successDialog;
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
            _successDialog.ShowDialog();
            
            Combats.Add(newCombat);
        }

        public void RemoveCombat(Combat combat)
        {
            if(combat == null)
                throw new ArgumentNullException(nameof(combat));

            Combats.Remove(combat);
            
            _storage.RemoveCombat(combat);
            _storage.SaveChanges();
            _successDialog.ShowDialog();
        }
        
    }
}