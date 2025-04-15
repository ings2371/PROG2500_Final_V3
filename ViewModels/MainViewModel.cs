using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDB_final_Project.Commands;
using IMDB_final_Project.Services;
using System.Windows.Input;
using System.Windows;

namespace IMDB_final_Project.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly INavigationService _navigationService;
        private object _currentViewModel;

        public object CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            CurrentViewModel = new HomeViewModel(); //Starting content for the main app at startup
        }

        //the commands to navigate to the pages
        public ICommand NavigateHomeCommand => new RelayCommand(_ => _navigationService.NavigateTo<HomeViewModel>());
        public ICommand NavigateActorCommand => new RelayCommand(_ => _navigationService.NavigateTo<ActorViewModel>());
        public ICommand NavigateMovieCommand => new RelayCommand(_ => _navigationService.NavigateTo<MovieViewModel>());
        public ICommand NavigateGameCommand => new RelayCommand(_ => _navigationService.NavigateTo<GameViewModel>());

        public ICommand GoBackCommand => new RelayCommand(_ => _navigationService.GoBack());

        // Command to close the application
        public ICommand CloseAppCommand => new RelayCommand(_ => Application.Current.Shutdown());

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
