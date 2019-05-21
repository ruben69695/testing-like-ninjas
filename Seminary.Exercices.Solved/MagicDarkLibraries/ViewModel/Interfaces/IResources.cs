using System.Collections.Generic;

namespace MagicDarkLibraries.ViewModel.Interfaces
{
    public interface IResources
    {
        Dictionary<string, string> Resources { get; }
        string GetResource(string key);
    }
}