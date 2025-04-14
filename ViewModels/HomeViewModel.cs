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
        //public ObservableCollection<Title> MostPopularTitles { get; set; } = new();
        private ObservableCollection<Title> _titles;

        public ObservableCollection<Title> Titles
        {
            get => _titles;
            set
            {
                _titles = value;
                OnPropertyChanged(nameof(Titles));
            }
        }

        //public HomeViewModel()
        //{
        //}

        //private void LoadMostPopular()
        //{
        //    using var context = new ImdbContext(); // Replace with your actual DbContext name

        //    var topTitles = context.Titles
        //        .Include(t => t.Rating)
        //        .Include(t => t.Names) // For cast/director names
        //        .Include(t => t.EpisodeTitle)
        //        .Include(t => t.TitleAliases)
        //        .Include(t => t.Genres)
        //        .Include(t => t.NamesNavigation)
        //        .Include(t => t.Names1)
        //        .Include(t => t.EpisodeParentTitles)
        //        .OrderByDescending(t => t.Rating!.AverageRating)
        //        .Where(t => t.Rating != null)
        //        .Take(10)
        //        .ToList();

        //    Titles = new ObservableCollection<Title>(topTitles);
        //    OnPropertyChanged(nameof(Titles));
        //}

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
