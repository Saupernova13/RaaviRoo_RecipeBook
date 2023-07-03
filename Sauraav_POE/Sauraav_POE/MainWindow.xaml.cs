//Sauraav Jayrajh
//ST10024620
using Sauraav_POE_Part_2;
using System.Collections.Generic;
using System.Windows;

namespace Sauraav_POE
{
    public partial class MainWindow : Window
    {
        //List handles storage multiple recipes, actice recipe keeps current recipe in memory
        public static List<RecipeComplete> allRecipes = new List<RecipeComplete>();
        public static List<RecipeComplete> menu = new List<RecipeComplete>();
        public static List<List<RecipeComplete>> theMenu = new List<List<RecipeComplete>>();

        //$"\n\nYou currently have {allRecipes.Count} recipe(s) in your recipe book.\n"
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
