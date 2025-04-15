using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB_final_Project.Models;

namespace IMDB_final_Project.ViewModels
{
    public class GameViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Title> _game;
        private ObservableCollection<Title> _filteredGame;
        private string _searchText;

        public ObservableCollection<Title> Games
        {
            get => _game;
            set
            {
                _game = value;
                OnPropertyChanged(nameof(Games));
                FilterTitle();
            }
        }

        public ObservableCollection<Title> FilteredGames
        {
            get => _filteredGame;
            set
            {
                _filteredGame = value;
                OnPropertyChanged(nameof(FilteredGames));
            }
        }

        //search text for filter
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                FilterTitle();
            }
        }

        //this is the search filter that filters by OriginalTitle
        private void FilterTitle()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                FilteredGames = new ObservableCollection<Title>(_game.Take(30));
            }
            else
            {
                FilteredGames = new ObservableCollection<Title>(
                    _game.Where(t => t.OriginalTitle.ToLower().Contains(SearchText.ToLower())).Take(30)
                );
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
