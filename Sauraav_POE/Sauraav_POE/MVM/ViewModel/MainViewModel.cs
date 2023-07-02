using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sauraav_POE.Core;

namespace Sauraav_POE.MVM.ViewModel
{
     public class MainViewModel: ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand AddRecipeViewCommand { get; set; }
        public HomeViewModel HomeVM { get; set; }
        public  AddRecipeViewModel AddRecipeVM { get; set; }
        private object _currentView;

		public object CurrentView
        {
			get { return _currentView; }
			set { _currentView = value; onPropertyChanged(); }
		}

		public MainViewModel() {
            HomeVM = new HomeViewModel();
            AddRecipeVM = new AddRecipeViewModel();
            AddRecipeViewCommand = new RelayCommand(o => { CurrentView = AddRecipeVM; });
            HomeViewCommand = new RelayCommand(o => { CurrentView = HomeVM; });
            CurrentView = new HomeViewModel();
        }


    }
}
