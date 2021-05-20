using Diary.Core;
using Diary.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.MVVM.ViewModel
{
    class AddEventViewModel : ObservableObject
    {
        public RelayCommand AddCommand { get; set; }
        public RelayCommand AddContactCommand { get; set; }

        public AddEventViewModel(AddEventWindow ThisWindow)
        {
            AddCommand = new RelayCommand(o =>
            {
                ThisWindow.Close();
            });
            AddContactCommand = new RelayCommand(o =>
            {
                new ContactListWindow().ShowDialog();
            });
        }
    }
}
