using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sauraav_POE.Core;

namespace Sauraav_POE.MVM.ViewModel
{
     class MainViewModel: ObservableObject
    {
        public RelayCommand homeViewCommand { get; set; }
        public RelayCommand addRecipeViewCommand { get; set; }
        public HomeViewModel homeVM { get; set; }
        public AddRecipeViewModel addRecipeVM { get; set; }

        private object _currentView;

		public object CurrentView
        {
			get { return _currentView; }
			set { _currentView = value; onPropertyChanged(); }
		}

		public MainViewModel() {
            homeVM = new HomeViewModel();
            addRecipeVM = new AddRecipeViewModel();
            CurrentView = homeVM;
            homeViewCommand = new RelayCommand(o => { CurrentView = homeVM; });
            addRecipeViewCommand = new RelayCommand(o => { CurrentView = addRecipeVM; });
        }
    }
}
