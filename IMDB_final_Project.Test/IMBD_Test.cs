using Microsoft.VisualStudio.TestTools.UnitTesting;
using IMDB_final_Project.ViewModels;
using IMDB_final_Project.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;

namespace IMDB_final_Project.Tests
{
    [TestClass]
    public class BasicPageViewModelTests
    {
        // Test that HomeViewModel correctly stores and returns assigned titles
        [TestMethod]
        public void HomeViewModel_Titles_InitializesAndStoresCorrectly()
        {
            var vm = new HomeViewModel();
            var titles = new ObservableCollection<Title>
            {
                new Title { OriginalTitle = "The Matrix" },
                new Title { OriginalTitle = "Inception" }
            };

            vm.Titles = titles;

            Assert.AreEqual(2, vm.Titles.Count);
            Assert.AreEqual("The Matrix", vm.Titles[0].OriginalTitle);
        }
        // Test that HomeViewModel triggers PropertyChanged when Titles is set
        [TestMethod]
        public void HomeViewModel_RaisesPropertyChanged_OnTitlesSet()
        {
            var vm = new HomeViewModel();
            bool propertyChanged = false;

            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "Titles")
                    propertyChanged = true;
            };

            vm.Titles = new ObservableCollection<Title> { new Title { OriginalTitle = "Sample" } };

            Assert.IsTrue(propertyChanged);
        }
        // Test that ActorViewModel filters names correctly based on search text
        [TestMethod]
        public void ActorViewModel_SearchText_FiltersCorrectly()
        {
            var vm = new ActorViewModel();
            vm.Names = new ObservableCollection<Name>
            {
                new Name { PrimaryName = "Tom Cruise" },
                new Name { PrimaryName = "Emma Stone" },
                new Name { PrimaryName = "Tom Hardy" }
            };

            vm.SearchText = "Tom";

            Assert.AreEqual(2, vm.FilteredNames.Count);
        }
        // Test that ActorViewModel limits FilteredNames to 30 items even with more input
        [TestMethod]
        public void ActorViewModel_FilteredNames_LimitedTo30Items()
        {
            var vm = new ActorViewModel();
            var longList = Enumerable.Range(1, 100)
                .Select(i => new Name { PrimaryName = $"Name {i}" })
                .ToList();

            vm.Names = new ObservableCollection<Name>(longList);
            vm.SearchText = ""; // Trigger no-filter load

            Assert.AreEqual(30, vm.FilteredNames.Count);
        }
        // Test that MovieViewModel correctly filters titles that match a given search string
        [TestMethod]
        public void MovieViewModel_SearchText_MatchesMultipleTitles()
        {
            var vm = new MovieViewModel();
            vm.Titles = new ObservableCollection<Title>
            {
                new Title { OriginalTitle = "Dune" },
                new Title { OriginalTitle = "Dunkirk" },
                new Title { OriginalTitle = "Tenet" }
            };

            vm.SearchText = "Du";

            Assert.AreEqual(2, vm.FilteredTitles.Count);
        }
        // Test that MovieViewModel returns all titles if search text is empty
        [TestMethod]
        public void MovieViewModel_FilteredTitles_ClearsWhenSearchEmpty()
        {
            var vm = new MovieViewModel();
            vm.Titles = new ObservableCollection<Title>
            {
                new Title { OriginalTitle = "Oppenheimer" },
                new Title { OriginalTitle = "Barbie" }
            };

            vm.SearchText = ""; // Empty triggers top 30

            Assert.AreEqual(2, vm.FilteredTitles.Count);
        }
        // Test that GameViewModel filters games based on lowercase search string
        [TestMethod]
        public void GameViewModel_Search_ReturnsExpectedResults()
        {
            var vm = new GameViewModel();
            vm.Games = new ObservableCollection<Title>
            {
                new Title { OriginalTitle = "Halo Infinite" },
                new Title { OriginalTitle = "God of War" },
                new Title { OriginalTitle = "Forza Horizon" }
            };

            vm.SearchText = "halo";

            Assert.AreEqual(1, vm.FilteredGames.Count);
            Assert.AreEqual("Halo Infinite", vm.FilteredGames[0].OriginalTitle);
        }
        // Test that GameViewModel shows all games if search is empty
        [TestMethod]
        public void GameViewModel_FilteredGames_EmptySearchShowsAll()
        {
            var vm = new GameViewModel();
            var games = new ObservableCollection<Title>
            {
                new Title { OriginalTitle = "Cyberpunk 2077" },
                new Title { OriginalTitle = "Elden Ring" }
            };

            vm.Games = games;
            vm.SearchText = ""; // No filter

            Assert.AreEqual(2, vm.FilteredGames.Count);
        }
    }
}
