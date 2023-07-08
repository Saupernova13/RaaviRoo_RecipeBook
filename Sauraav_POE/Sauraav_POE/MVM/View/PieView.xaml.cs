//Sauraav Jayrajh
//ST10024620
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

namespace Sauraav_POE.MVM.View
{

    public partial class PieView 
    {
        public List<List<RecipeComplete>> menus = new List<List<RecipeComplete>>();
        public static List<string> Names = new List<string>();
        public List<RecipeComplete> listRecipe;
        public int parser=0;
        public PieView()
        {
            listRecipe = MainWindow.allRecipes;
            InitializeComponent();
            Names= AddMenuPie.Names;
            Label formLabel = new Label()
            {
                Name = $"formLabel",
                Content = $"Menus:",
                Foreground = Brushes.White,
                Margin = new Thickness(0, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                FontSize = 20
            };
            viewMenuList_StackPnl.Children.Add(formLabel);
            viewMenuList_StackPnl.Children.Add(GenerateAddButton());
            for (int i = 0; i < Names.Count; i++)
            {
                addLists(i);
            }
            menus = AddMenuPie.menus;
        }

        public Border GenerateAddButton()
        {
            Border border = new Border();
            border.BorderThickness = new Thickness(1);
            border.CornerRadius = new CornerRadius(5);
            border.Height = 150;
            border.Width = 150;
            border.HorizontalAlignment = HorizontalAlignment.Left;
            border.VerticalAlignment = VerticalAlignment.Center;
            DrawingBrush brush = new DrawingBrush();
            brush.Viewport = new Rect(0, 0, 8, 8);
            brush.ViewportUnits = BrushMappingMode.Absolute;
            brush.TileMode = TileMode.Tile;
            border.Margin = new Thickness(13, 10, 0, 10);
            DrawingGroup drawingGroup = new DrawingGroup();
            GeometryDrawing geometryDrawing = new GeometryDrawing();
            geometryDrawing.Brush = Brushes.White;
            GeometryGroup geometryGroup = new GeometryGroup();
            geometryGroup.Children.Add(new RectangleGeometry(new Rect(0, 0, 50, 50)));
            geometryGroup.Children.Add(new RectangleGeometry(new Rect(50, 50, 50, 50)));
            geometryDrawing.Geometry = geometryGroup;
            drawingGroup.Children.Add(geometryDrawing);
            brush.Drawing = drawingGroup;
            border.BorderBrush = brush;
            Grid grid = new Grid();
            grid.Height = 150;
            grid.Width = 150;
            TextBlock textBlock = new TextBlock();
            textBlock.Text = "+";
            textBlock.Foreground = Brushes.White;
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            textBlock.Margin = new Thickness(0, 0, 0, 20);
            textBlock.FontSize = 50;
            grid.Children.Add(textBlock);
            border.Child = grid;
            grid.PreviewMouseLeftButtonDown += Border_PreviewMouseLeftButtonDown;
            return border;
        }

        public void addLists(int n)
        {
            StackPanel stackPanelSteps = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(0)
            };
            Label menuNameLabel = new Label()
            {
                Name = $"menuNameLabel_{n}",
                Content = $"Menu: {Names[n]}",
                Foreground = Brushes.White,
                Margin = new Thickness(0, 8, 0, 0),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            Rectangle rectangle = new Rectangle()
            {
                Fill = new SolidColorBrush(Color.FromArgb(154, 49, 28, 37)),
                Height = 40,
                Width = 500,
                RadiusX = 10,
                RadiusY = 10,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(0, 0, 0, 0)
            };
            rectangle.MouseLeftButtonDown += (sender, e) =>
            {
                PieGraphViewer pgv = new PieGraphViewer(menus[n]);
                pgv.Show();
            };
            Grid grid = new Grid()
            {
                Margin = new Thickness(10)
            };
            grid.Children.Add(rectangle);
            grid.Children.Add(menuNameLabel);
            stackPanelSteps.Children.Add(grid);
            viewMenuList_StackPnl.Children.Add(stackPanelSteps);
        }

        private void Border_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Border || e.OriginalSource is TextBlock)
            {
                AddMenuPie amp = new AddMenuPie(menus);
                amp.Show();
            }
        }
    }
}
