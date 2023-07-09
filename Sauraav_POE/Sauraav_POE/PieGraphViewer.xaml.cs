//Sauraav Jayrajh
//ST10024620
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Sauraav_POE_Part_2;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

    public partial class PieGraphViewer : Window
    {
        public static List<RecipeComplete> currentMenu = new List<RecipeComplete>();
        public PieGraphViewer(List<RecipeComplete> menuToGraph)
        {
            int StarchyFoods = 0;
            int FruitsAndVeg = 0;
            int DryBeans = 0;
            int Chicken = 0;
            int Milk = 0;
            int Fats = 0;
            int Water = 0;
            InitializeComponent();
            currentMenu = menuToGraph;
            for (int i = 0; i < currentMenu.Count; i++)
            {
                for (int j = 0; j < currentMenu[i].ingredients.Count; j++)
                {
                    switch (currentMenu[i].ingredients[j].foodGroup)
                    {
                        case "Starchy foods":
                            StarchyFoods++;
                            break;
                        case "Vegetables and fruits":
                            FruitsAndVeg++;
                            break;
                        case "Dry beans, peas, lentils and soy":
                            DryBeans++;
                            break;
                        case "Chicken, fish, meat and eggs":
                            Chicken++;
                            break;
                        case "Milk and dairy products":
                            Milk++;
                            break;
                        case "Fats and oils":
                            Fats++;
                            break;
                        case "Water":
                            Water++;
                            break;
                        default: break;
                    }
                }
            }

            SeriesCollection = new SeriesCollection
    {
        new PieSeries
        {
            Title= "Starchy foods",
            Values= new ChartValues<ObservableValue> { new ObservableValue(StarchyFoods) },
            Fill = (Brush)new BrushConverter().ConvertFrom("#F90C71"),
            DataLabels= true
        },

        new PieSeries
        {
            Title= "Vegetables and fruits",
            Values= new ChartValues<ObservableValue> { new ObservableValue(FruitsAndVeg) },
              Fill = (Brush)new BrushConverter().ConvertFrom("#D80A63"),
            DataLabels= true
        },

        new PieSeries
        {
            Title= "Dry beans, peas, lentils and soya",
            Values= new ChartValues<ObservableValue> { new ObservableValue(DryBeans) },
                Fill = (Brush)new BrushConverter().ConvertFrom("#B60854"),
            DataLabels= true
        },
        new PieSeries
        {
            Title= "Chicken, fish, meat and eggs",
            Values= new ChartValues<ObservableValue> { new ObservableValue(Chicken) },
                Fill = (Brush)new BrushConverter().ConvertFrom("#950646"),
            DataLabels= true
        },

        new PieSeries
        {
            Title= "Milk and dairy products",
            Values= new ChartValues<ObservableValue> { new ObservableValue(Milk) },
                Fill = (Brush)new BrushConverter().ConvertFrom("#730437"),
            DataLabels= true
        },

        new PieSeries
        {
            Title= "Fats and oil",
            Values= new ChartValues<ObservableValue> { new ObservableValue(Fats) },
                Fill = (Brush)new BrushConverter().ConvertFrom("#520229"),
            DataLabels= true
        },
         new PieSeries
        {
            Title= "Water",
            Values= new ChartValues<ObservableValue> { new ObservableValue(Water) },
                Fill = (Brush)new BrushConverter().ConvertFrom("#30001A"),
            DataLabels= true
        }
    };

            DataContext = this;
        }


        public SeriesCollection SeriesCollection { get; set; }
        private void exitPage(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PieChart_Loaded(object sender, RoutedEventArgs e)
        {

        }

    }

}
