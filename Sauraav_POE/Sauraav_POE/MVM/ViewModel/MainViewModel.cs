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
        public RelayCommand ViewRecipeViewCommand { get; set; }
        public RelayCommand HomeViewNewViewCommand { get; set; }

        public RelayCommand EditViewViewCommand { get; set; }
        public HomeViewModel HomeVM { get; set; }
        public  AddRecipeViewModel AddRecipeVM { get; set; }
        public ViewRecipeViewModel ViewRecipeVM { get; set; }
        public HomeViewNewViewModel HomeViewNewVM { get; set; }
        public EditRecipeViewModel EditRecipeVM { get; set; }
        private object _currentView;

		public object CurrentView
        {
			get { return _currentView; }
			set { _currentView = value; onPropertyChanged(); }
		}

		public MainViewModel() {
            HomeVM = new HomeViewModel();
            AddRecipeVM = new AddRecipeViewModel();
            ViewRecipeVM = new ViewRecipeViewModel();
            HomeViewNewVM = new HomeViewNewViewModel();
            EditRecipeVM = new EditRecipeViewModel();
            AddRecipeViewCommand = new RelayCommand(o => { CurrentView = AddRecipeVM; });
            HomeViewCommand = new RelayCommand(o => { CurrentView = HomeVM; });
            ViewRecipeViewCommand = new RelayCommand(o => { CurrentView = ViewRecipeVM; });
            HomeViewNewViewCommand = new RelayCommand(o => { CurrentView = HomeViewNewVM; });
            EditViewViewCommand = new RelayCommand(o => { CurrentView = EditRecipeVM; });

            //CurrentView = new HomeViewModel();
            CurrentView = new HomeViewNewViewModel();
        }


    }
}
