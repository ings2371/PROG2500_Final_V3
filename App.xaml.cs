using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Controls.Primitives;
using IMDB_final_Project.Data;
using IMDB_final_Project.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using IMDB_final_Project.Services;
using IMDB_final_Project.Models;

namespace IMDB_final_Project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            ConfiureService(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            LoadData();

            var mainViewModel = ServiceProvider.GetRequiredService<MainViewModel>();
            var navigationService = ServiceProvider.GetRequiredService<INavigationService>() as NavigationService;
            navigationService.SetMainViewModel(mainViewModel);

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfiureService(IServiceCollection services)
        {

            services.AddDbContext<ImdbContext>(options =>
            {
                options.UseSqlServer(ConfigurationManager.ConnectionStrings["IMDBConn"].ConnectionString);
            });

            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<ActorViewModel>();
            services.AddSingleton<MovieViewModel>();
            services.AddSingleton<GameViewModel>();

            //Register other services and viewmodels here
        }

        private void LoadData()
        {
            try
            {
                using (var scope = ServiceProvider.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<ImdbContext>();
                    var movieViewModel = scope.ServiceProvider.GetRequiredService<MovieViewModel>();
                    var homeViewModel = scope.ServiceProvider.GetRequiredService<HomeViewModel>();
                    var actorViewModel = scope.ServiceProvider.GetRequiredService<ActorViewModel>();
                    var gameViewModel = scope.ServiceProvider.GetRequiredService<GameViewModel>();

                    var topTitles = dbContext.Titles
                        .Include(t => t.Rating)
                        .Where(t => t.Rating != null && (t.IsAdult == false || t.IsAdult == null))
                        .OrderByDescending(t => t.Rating.AverageRating)
                        .Take(10)
                        .ToList();

                    var titleRatings = dbContext.Titles.Include(t => t.Rating).ToList();

                    var videoGames = dbContext.Titles
                        .Include(t => t.Rating)
                        .Where(t => t.TitleType == "videoGame" && (t.IsAdult == false || t.IsAdult == null))
                        .OrderByDescending(t => t.Rating!.AverageRating)
                        .Take(50)
                        .ToList();

                    homeViewModel.Titles = new ObservableCollection<Title>(topTitles);
                    movieViewModel.Titles = new ObservableCollection<Title>(titleRatings);
                    actorViewModel.Names = new ObservableCollection<Name>(dbContext.Names.Take(1000).ToList());
                    gameViewModel.Games = new ObservableCollection<Title>(videoGames);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Startup failed: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }

}
