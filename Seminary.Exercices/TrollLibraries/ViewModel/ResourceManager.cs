using System.Collections.Generic;

namespace TrollLibraries.ViewModel
{
    public class ResourceManager
    {
        public Dictionary<string, string> Resources { get; private set; }

        public ResourceManager()
        {
            LoadResourcesFromFile();
        }

        private void LoadResourcesFromFile()
        {
            // Load resources dictionary from an embedded resource in the main assembly
            Resources = new Dictionary<string, string>();
        }

        public ResourceManager(Dictionary<string, string> resources)
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