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

namespace Sauraav_POE
{

    public partial class PieGraphViewer : Window
    {
        public PieGraphViewer(List<RecipeComplete> menuToGraph)
        {
            InitializeComponent();
        }

        private void exitPage(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
