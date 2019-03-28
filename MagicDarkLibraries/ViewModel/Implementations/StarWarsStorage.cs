using System;
using System.Collections.Generic;
using System.Drawing;
using MagicDarkLibraries.Logger;
using MagicDarkLibraries.ViewModel.Interfaces;
using MagicDarkLibraries.ViewModel.Classes;

namespace MagicDarkLibraries.ViewModel.Implementations
{
    public class StarWarsStorage : IStarWarsStorage
    {
        private readonly ILogger _logger;

        public StarWarsStorage(ILogger logger)
        {
            _logger = logger;
        }

        public IEnumerable<Jedi> GetJedis()
        {
            var bag = new Jedi[] { };
            try
            {
                Console.WriteLine("Accessing to the database to retrieve the information");
                bag = new[]
                {
                    new Jedi() { IntergalacticBoard = "123", Name = "Obi Wan", LightSaberColor = Color.SlateBlue },
                    new Jedi() { IntergalacticBoard = "456", Name = "Rahm Kota", LightSaberColor = Color.SlateBlue },
                    new Jedi() { IntergalacticBoard = "789", Name = "Shaak Ti", LightSaberColor = Color.LimeGreen },
                    new Jedi() { IntergalacticBoard = "19034", Name = "Starkiller", LightSaberColor = Color.DarkBlue }
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                
                // Return the empty list but not null
                return bag;
            }

            return bag;
        }

        public IEnumerable<Sith> GetSiths()
        {
            var bag = new Sith[] { };
            try
            {
                Console.WriteLine("Accessing to the database to retrieve the information");
                bag = new[]
                {
                    new Sith() { IntergalacticBoard = "101112", Name = "Darth Vader", LightSaberColor = Color.Red, DeathStarPass = "124" }, 
                    new Sith() { IntergalacticBoard = "111113", Name = "El emperador Palpatin", LightSaberColor = Color.Red, DeathStarPass = "1"}, 
                    new Sith() { IntergalacticBoard = "101114", Name = "Kylo Ren", LightSaberColor = Color.Red, DeathStarPass = "12456"}
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                
                // Return the empty list but not null
                return bag;
            }
            return bag;
        }
        
        public IEnumerable<Combat> GetCombats()
        {
            var bag = new Combat[] { };
            try
            {
                Console.WriteLine("Accessing to the database to retrieve the information");
                bag = new[]
                {
                    new Combat
                    (
                        new Jedi() { IntergalacticBoard = "19034", Name = "Starkiller", LightSaberColor = Color.DarkBlue },
                        new Sith() { IntergalacticBoard = "101112", Name = "Darth Vader", LightSaberColor = Color.Red, DeathStarPass = "124" }
                    )
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                
                // Return the empty list but not null
                return bag;
            }
            return bag;
        }

        public void CreateCombat(Combat combat)
        {
            // Create combat in the database in a transaction...
        }

        public void RemoveCombat(Combat combat)
        {
            // Remove combat in the database in a transaction....
        }

        public void SaveChanges()
        {
            // Save changes in the database, closing the current opened transaction
          
        }

    }
}