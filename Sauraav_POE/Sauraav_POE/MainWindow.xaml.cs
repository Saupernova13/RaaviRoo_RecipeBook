using Sauraav_POE.Windows;
using Sauraav_POE_Part_2;
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

namespace Sauraav_POE
{
    public partial class MainWindow : Window
    {
        //List handles storage multiple recipes, actice recipe keeps current recipe in memory
        public static List<RecipeComplete> allRecipes = new List<RecipeComplete>();
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
