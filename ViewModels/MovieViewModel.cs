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
    public class MovieViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Title> _titles;
        private ObservableCollection<Title> _filteredTitles;
        private string _searchText;

        public ObservableCollection<Title> Titles
        {
            get => _titles;
            set { 
                _titles = value;
                OnPropertyChanged(nameof(Titles));
                FilterTitle();
            }
        }

        public ObservableCollection<Title> FilteredTitles
        {
            get => _filteredTitles;
            set
            {
                _filteredTitles = value;
                OnPropertyChanged(nameof(FilteredTitles));
            }
        }

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

        private void FilterTitle()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                FilteredTitles = new ObservableCollection<Title>(_titles.Take(30));
            }
            else
            {
                FilteredTitles = new ObservableCollection<Title>(
                    _titles.Where(t => t.OriginalTitle.ToLower().Contains(SearchText.ToLower())).Take(30)
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
