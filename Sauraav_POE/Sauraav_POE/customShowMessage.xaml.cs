//Sauraav Jayrajh
//ST10024620
using Sauraav_POE.MVM.View;
using Sauraav_POE.Windows;
using Sauraav_POE_Part_2;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Sauraav_POE
{
    public partial class customShowMessage : Window
    {
        public static bool isNull = false;
        public static addIng_Step closeThis;
        public RecipeComplete currentRecipe;
        public customShowMessage(string windowName, string WindowDetails, addIng_Step closeWindow = null, RecipeComplete passRecipe = null)
        {
            currentRecipe = passRecipe;
            InitializeComponent();
            CreateUIElements(windowName, WindowDetails);
            if (!(closeWindow == null))
            {
                isNull = false;
                closeThis = closeWindow;
            }
            else
            {
                isNull = true;
            }
        }

        private void CreateUIElements(string windowName, string WindowDetails)
        {
            Border outerBorder = new Border();
            outerBorder.Background = new SolidColorBrush(Color.FromRgb(49, 28, 37));
            outerBorder.CornerRadius = new CornerRadius(15);
            this.Content = outerBorder;
            Border innerBorder = new Border();
            innerBorder.Background = new SolidColorBrush(Color.FromRgb(101, 57, 76));
            innerBorder.CornerRadius = new CornerRadius(20);
            innerBorder.Margin = new Thickness(10);
            outerBorder.Child = innerBorder;
            Grid grid = new Grid();
            innerBorder.Child = grid;
            Button button = new Button();
            button.Margin = new Thickness(315, 166, 10, 10);
            button.Style = (Style)FindResource("ModernButton");
            button.Content = "OK";
            button.Click += OK_Click;
            Rectangle rectangle = new Rectangle();
            rectangle.Fill = new SolidColorBrush(Color.FromArgb(154, 49, 28, 37));
            rectangle.Margin = new Thickness(0, 39, 0, 188);
            Label label = new Label();
            label.Content = windowName;
            label.FontSize = 20;
            label.Margin = new Thickness(10, 0, 257, 196);
            label.Foreground = Brushes.White;
            TextBlock textBlock = new TextBlock();
            textBlock.Foreground = Brushes.White;
            textBlock.FontSize = 15;
            textBlock.Text = WindowDetails;
            textBlock.Margin = new Thickness(15, 54, 15, 69);
            grid.Children.Add(button);
            grid.Children.Add(rectangle);
            grid.Children.Add(label);
            grid.Children.Add(textBlock);
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.allRecipes.Add(currentRecipe);
            this.Close();
            if (!isNull)
            {
                closeThis.Close();
            }
        }
    }
}
