//Saurav Jayrajh
//ST10024620
using Sauraav_POE.MVM.View;
using Sauraav_POE.MVM.ViewModel;
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
    public partial class AddMenuPie : Window
    {
        ////Public variables needed in class
        public static List<List<RecipeComplete>> menus = new List<List<RecipeComplete>>();
        public List<RecipeComplete> currentMenu = new List<RecipeComplete>();
        public static List<string> Names = new List<string>();
        public List<CheckBox> checkBoxes = new List<CheckBox>();

        ////Method to initiate the class
        public AddMenuPie(List<List<RecipeComplete>> passMenu)
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            menus = passMenu;
            for (int i = 0; i < MainWindow.allRecipes.Count; i++)
            {
                addLists(i);
            }
        }

        ////Method to exit
        private void exitPage(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        ////Method to add list elements to the UI
        public void addLists(int n)
        {
            StackPanel stackPanelSteps = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(0)
            };

            StackPanel contentPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                VerticalAlignment = VerticalAlignment.Center
            };
            CheckBox checkBox = new CheckBox()
            {
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(10, 0, 8, 0)
            };
            checkBoxes.Add(checkBox);
            Label recipeNameLabel = new Label()
            {
                Name = $"recipeNameLabel_{n}",
                Content = $"Recipe No.{n + 1}: {(MainWindow.allRecipes[n]?.recipeName ?? "")}",
                Foreground = Brushes.White,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left
            };

            contentPanel.Children.Add(checkBox);
            contentPanel.Children.Add(recipeNameLabel);

            Rectangle rectangle = new Rectangle()
            {
                Fill = new SolidColorBrush(Color.FromArgb(154, 49, 28, 37)),
                Height = 40,
                Width = 500,
                RadiusX = 10,
                RadiusY = 10,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
            };
          

            Grid grid = new Grid()
            {
                Margin = new Thickness(10)
            };
            grid.Children.Add(rectangle);
            grid.Children.Add(contentPanel); // Add the content panel instead of the label

            stackPanelSteps.Children.Add(grid);
            viewRecipesList_StackPnl.Children.Add(stackPanelSteps);
        }

        ////Method to save details of the menu
        private void saveMenuDetals(object sender, RoutedEventArgs e)
        {
            int counter = 0;
            for (int i = 0; i < checkBoxes.Count; i++)
            {
                if (checkBoxes[i].IsChecked == true) { counter++; }
            }
            if (counter > 0)
            {
                if (!((menuNameTextBox.Text.Equals("")) || (menuNameTextBox.Text.Equals(null))))
                {
                    Names.Add(menuNameTextBox.Text);
                    for (int i = 0; i < checkBoxes.Count; i++)
                    {
                        if (checkBoxes[i].IsChecked == true)
                        {
                            currentMenu.Add(MainWindow.allRecipes[i]);
                        }
                    }
                    menus.Add(currentMenu);
                    customShowMessage csm = new customShowMessage("Success", "This menu has been saved!");
                    csm.Show();

                }
                else
                {
                    customShowMessage csm = new customShowMessage("Error", "Please ENTER in the NAME for the\nMenu!");
                    csm.Show();
                }
            }
            else
            {
                customShowMessage csm = new customShowMessage("Error", "Please SELECT at least one recipe to include\nin your Menu!");
                csm.Show();
            }

        }

        ////Method to keep window on top
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Topmost = true;
        }

        ////Method to select all recipes
        private void selectAllMenuDetals(object sender, RoutedEventArgs e)
        {
            foreach (var c in checkBoxes)
            {
                c.IsChecked = !c.IsChecked;
            }
        }
    }
}