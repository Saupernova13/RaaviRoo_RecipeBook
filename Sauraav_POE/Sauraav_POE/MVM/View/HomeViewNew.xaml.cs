//Sauraav Jayrajh
//ST10024620
using Sauraav_POE.Core;
using Sauraav_POE.MVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sauraav_POE.MVM.View
{
    /// <summary>
    /// Interaction logic for HomeViewNew.xaml
    /// </summary>
    public partial class HomeViewNew
    {
        public HomeViewNew()
        {
            InitializeComponent();
        }

        private void openCreateRecipeTab(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this) as MainWindow;
            var mainViewModel = mainWindow.DataContext as MainViewModel;
            mainViewModel.CurrentView = mainViewModel.AddRecipeVM;
        }
    }
}
