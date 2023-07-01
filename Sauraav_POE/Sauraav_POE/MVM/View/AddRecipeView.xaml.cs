using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddRecipeView.xaml
    /// </summary>
    public partial class AddRecipeView : UserControl
    {
        public AddRecipeView()
        {
            InitializeComponent();
        }

        private void describeRecipe_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            describeRecipe.Document.Blocks.Clear();
            describeRecipe.Foreground = Brushes.White;  
        }

        private void ingredientQuantityTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            onlyNumbers(sender, e);
        }

        private void numberOfStepsTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            onlyNumbers(sender, e);
        }

        private void servingSizeTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            onlyNumbers(sender, e);
        }

        public static void onlyNumbers(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Recipe Added!");
        }
    }
}
