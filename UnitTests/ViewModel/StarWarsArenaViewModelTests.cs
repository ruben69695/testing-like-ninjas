using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MagicDarkLibraries.Logger;
using MagicDarkLibraries.ViewModel;
using MagicDarkLibraries.ViewModel.Classes;
using MagicDarkLibraries.ViewModel.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace TestingLikeNinjas.UnitTests.ViewModel
{
    [TestFixture]
    public class StarWarsArenaViewModelTests
    {
        private StarWarsArenaViewModel _vm;
        private IResources _resourcesMock;
        private IDialog _successDialogMock;
        private IStarWarsStorage _storageMock;

        [SetUp]
        public void Setup()
        {
            _storageMock = Substitute.For<IStarWarsStorage>();
            _resourcesMock = Substitute.For<IResources>();
            _successDialogMock = Substitute.For<IDialog>();
            
            _vm = new StarWarsArenaViewModel(_storageMock, _resourcesMock, _successDialogMock);

            _storageMock.GetJedis().Returns(GetJedisMock());
            _storageMock.GetSiths().Returns(GetSithsMock());
            _storageMock.GetCombats().Returns(GetCombats());
            
            _vm.Init();
        }
        
        #region Tests

        [Test]
        public void ViewModelTitle_PropertyGetter_ShouldReturnTheViewModelTitle()
        {
            _resourcesMock.GetResource("StarWarsTitle").Returns("Fake title");
            
            Assert.That(_vm.ViewModelTitle, Is.EqualTo("Fake title"));
        }

        [Test]
        public void AddCombat_MethodCall_ShouldAddNewCombatToTheList()
        {
            var jedi = _vm.Jedis[0];
            var sith = _vm.Siths[0];
            
            _vm.AddCombat(jedi, sith);
            
            Assert.That(_vm.Combats.Any(x => x.Jedi == jedi && x.Sith == sith), Is.True);
        }

        [Test]
        public void AddCombat_MethodCall_ShouldCallSaveChanges()
        {
            var jedi = _vm.Jedis[0];
            var sith = _vm.Siths[0];
            
            _vm.AddCombat(jedi, sith);
            
            _storageMock.Received().SaveChanges();
        }

        [Test]
        public void AddCombat_MethodCall_ShouldCallCreateCombat()
        {
            var jedi = _vm.Jedis[0];
            var sith = _vm.Siths[0];
            
            _vm.AddCombat(jedi, sith);
            
            _storageMock.Received().CreateCombat(Arg.Any<Combat>());
        }

        [Test]
        public void AddCombat_MethodCall_ShouldCallSuccessShowDialog()
        {
            var jedi = _vm.Jedis[0];
            var sith = _vm.Siths[0];
            
            _vm.AddCombat(jedi, sith);
            
            _successDialogMock.Received().ShowDialog();  
        }

        [Test]
        public void AddCombat_PassNullJediParameter_ShouldThrowAnArgumentNullException()
        {
            Assert.That(() =>
            {
                var sith = _vm.Siths[0];
                _vm.AddCombat(null, sith);
            }, Throws.ArgumentNullException);
        }

        [Test]
        public void AddCombat_PassNullSithParameter_ShouldThrowAnArgumentNullException()
        {
            Assert.That(() =>
            {
                var jedi = _vm.Jedis[0];
                _vm.AddCombat(jedi, null);
            }, Throws.ArgumentNullException);
        }
        
        [Test]
        public void RemoveCombat_PassNullParameter_ShouldThrowAnArgumentNullException()
        {
            Assert.That(() =>
            {
                _vm.RemoveCombat(null);
            }, Throws.ArgumentNullException);
        }

        [Test]
        public void RemoveCombat_MethodCall_ShouldRemoveTheCombat()
        {
            var combatToRemove = _vm.Combats[0];
            
            _vm.RemoveCombat(combatToRemove);
            
            Assert.That(_vm.Combats.Contains(combatToRemove), Is.False);
        }

        [Test]
        public void RemoveCombat_MethodCall_ShouldRemoveItFromStorage()
        {
            var combatToRemove = _vm.Combats[0];
            
            _vm.RemoveCombat(combatToRemove);
            
            _storageMock.Received().RemoveCombat(Arg.Any<Combat>());
        }

        [Test]
        public void RemoveCombat_MethodCall_ShouldRemoveItFromStorageAndSaveChanges()
        {
            var combatToRemove = _vm.Combats[0];
            
            _vm.RemoveCombat(combatToRemove);
            
            _storageMock.Received().SaveChanges();
        }

        [Test]
        public void RemoveCombat_MethodCall_ShouldRemoveItAndShowSuccessDialog()
        {
            var combatToRemove = _vm.Combats[0];
            
            _vm.RemoveCombat(combatToRemove);
            
            _successDialogMock.Received().ShowDialog();
        }
        
        
        #endregion

        #region Private members

        private IEnumerable<Jedi> GetJedisMock()
        {
            return new[]
            {
                new Jedi() {IntergalacticBoard = "123", Name = "Obi Wan", LightSaberColor = Color.SlateBlue},
                new Jedi() {IntergalacticBoard = "456", Name = "Rahm Kota", LightSaberColor = Color.SlateBlue},
                new Jedi() {IntergalacticBoard = "789", Name = "Shaak Ti", LightSaberColor = Color.LimeGreen},
                new Jedi() {IntergalacticBoard = "19034", Name = "Starkiller", LightSaberColor = Color.DarkBlue}
            };
        }

        private IEnumerable<Sith> GetSithsMock()
        {
            return new[]
            {
                new Sith()
                {
                    IntergalacticBoard = "101112", Name = "Darth Vader", LightSaberColor = Color.Red,
                    DeathStarPass = "124"
                },
                new Sith()
                {
                    IntergalacticBoard = "111113", Name = "El emperador Palpatin", LightSaberColor = Color.Red,
                    DeathStarPass = "1"
                },
                new Sith()
                {
                    IntergalacticBoard = "101114", Name = "Kylo Ren", LightSaberColor = Color.Red,
                    DeathStarPass = "12456"
                }
            };
        }

        private IEnumerable<Combat> GetCombats()
        {
            return new[]
            {
                new Combat
                (
                    new Jedi() {IntergalacticBoard = "19034", Name = "Starkiller", LightSaberColor = Color.DarkBlue},
                    new Sith()
                    {
                        IntergalacticBoard = "101112", Name = "Darth Vader", LightSaberColor = Color.Red,
                        DeathStarPass = "124"
                    }
                )
            };
        }

        #endregion

    }
}