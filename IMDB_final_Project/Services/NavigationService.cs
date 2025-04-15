using IMDB_final_Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB_final_Project.Services
{
    public interface INavigationService
    {
        void NavigateTo<TViewModel>() where TViewModel : class;
        void GoBack();
    }

    public class NavigationService : INavigationService
    {
        private MainViewModel _mainViewModel;
        private readonly IServiceProvider _serviceProvider;
        private readonly Stack<object> _navigationStack = new Stack<object>();

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void SetMainViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public void NavigateTo<TViewModel>() where TViewModel : class
        {
            var viewModel = _serviceProvider.GetService(typeof(TViewModel)) as TViewModel;
            if (viewModel != null)
            {
                _navigationStack.Push(viewModel);
                // Logic to update the current view with the new ViewModel
                _mainViewModel.CurrentViewModel = viewModel;
            }
        }

        public void GoBack()
        {
            if (_navigationStack.Count > 1)
            {
                _navigationStack.Pop();
                var viewModel = _navigationStack.Peek();
                // Logic to update the current view with the previous ViewModel
                _mainViewModel.CurrentViewModel = viewModel;
            }
        }
    }
}
