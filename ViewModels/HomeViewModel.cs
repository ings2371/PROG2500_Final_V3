using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB_final_Project.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using IMDB_final_Project.Data;
using Microsoft.EntityFrameworkCore;


namespace IMDB_final_Project.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Title> _titles;

        //collection of Title
        public ObservableCollection<Title> Titles
        {
            get => _titles;
            set
            {
                _titles = value;
                OnPropertyChanged(nameof(Titles));
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
