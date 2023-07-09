//Sauraav Jayrajh
//ST10024620
using Sauraav_POE_Part_2;
using System.Collections.Generic;
using System;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;

namespace Sauraav_POE
{
    public partial class MainWindow : Window
    {
        public static List<RecipeComplete> allRecipes = new List<RecipeComplete>();
        public static List<RecipeComplete> menu = new List<RecipeComplete>();
        public static bool justStarted = true;
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Create a DispatcherTimer
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // Update every second

            // Handle the Tick event
            timer.Tick += Timer_Tick;

            // Start the timer
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update the active time
            activeTimeTextBlock.Text = DateTime.Now.ToString("HH:mm:ss");
        }


        private void Kill_Program(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
