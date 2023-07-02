using Sauraav_POE.Windows;
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
using System.Windows.Shapes;

namespace Sauraav_POE
{
    /// <summary>
    /// Interaction logic for customShowMessage.xaml
    /// </summary>
    public partial class customShowMessage : Window
    {
        public static addIng_Step closeThis;
        public customShowMessage(addIng_Step closeWindow)
        {
            InitializeComponent();
            closeThis = closeWindow;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            closeThis.Close();

        }
    }
}
