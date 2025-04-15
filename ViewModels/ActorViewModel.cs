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
    public class ActorViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Name> _names;
        private ObservableCollection<Name> _filterednames;
        private string _searchText;

        public ObservableCollection<Name> Names
        {
            get => _names;
            set
            {
                _names = value;
                OnPropertyChanged(nameof(Names));
                FilterNames();
            }
        }

        public ObservableCollection<Name> FilteredNames
        {
            get => _filterednames;
            set
            {
                _filterednames = value;
                OnPropertyChanged(nameof(FilteredNames));
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
                FilterNames();
            }
        }

        //this is the search filter that filters by PrimaryName
        private void FilterNames()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                FilteredNames = new ObservableCollection<Name>(_names.Take(30));
            }
            else
            {
                FilteredNames = new ObservableCollection<Name>(
                    _names.Where(t => t.PrimaryName.ToLower().Contains(SearchText.ToLower())).Take(30)
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
