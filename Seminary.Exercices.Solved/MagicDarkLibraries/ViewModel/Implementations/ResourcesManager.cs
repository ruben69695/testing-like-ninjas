using System.Collections.Generic;
using MagicDarkLibraries.ViewModel.Interfaces;

namespace MagicDarkLibraries.ViewModel.Implementations
{
    public class ResourcesManager : IResources
    {
        public Dictionary<string, string> Resources { get; private set; }

        public ResourcesManager()
        {
            LoadResourcesFromFile();
        }

        private void LoadResourcesFromFile()
        {
            // Load resources dictionary from an embedded resource in the main assembly
            Resources = new Dictionary<string, string>();
        }

        public ResourcesManager(Dictionary<string, string> resources)
        {
            Resources = resources;
        }

        public string GetResource(string key)
        {
            var data = string.Empty;

            if (Resources.ContainsKey(key))
                data = Resources[key];
            
            return data;
        }
    }
}