using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Sauraav_POE.Core
{
    internal class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void onPropertyChanged([CallerMemberName] string name = null)
        { 
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
