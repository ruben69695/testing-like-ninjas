using System.Collections.Generic;
using MagicDarkLibraries.ViewModel.Classes;

namespace MagicDarkLibraries.ViewModel.Interfaces
{
    public interface IStarWarsStorage : IStorage
    {
        IEnumerable<Jedi> GetJedis();
        IEnumerable<Sith> GetSiths();
        IEnumerable<Combat> GetCombats();
        void CreateCombat(Combat combat);
        void RemoveCombat(Combat combat);
        
    }
}