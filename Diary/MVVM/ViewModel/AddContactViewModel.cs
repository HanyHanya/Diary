using Diary.Core;
using Diary.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.MVVM.ViewModel
{
    class AddContactViewModel : ObservableObject
    {
        public RelayCommand AddCommand { get; set; }
        public AddContactViewModel(AddContactWindow ThisWindow)
        {
            AddCommand = new RelayCommand(o =>
            {
                ThisWindow.Close();
            });
        }
    }
}
