//Sauraav Jayrajh
//ST10024620
using Sauraav_POE_Part_2;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Sauraav_POE
{
    public partial class MainWindow : Window
    {
        public static List<RecipeComplete> allRecipes = new List<RecipeComplete>();
        public static List<RecipeComplete> menu = new List<RecipeComplete>();
        public static bool justStarted = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Kill_Program(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
