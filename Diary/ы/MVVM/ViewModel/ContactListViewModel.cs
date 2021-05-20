using Diary.Core;
using Diary.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.MVVM.ViewModel
{
    class ContactListViewModel : ObservableObject
    {
        public RelayCommand AddContactCommand { get; set; }
        public RelayCommand AddCommand { get; set; }

        public ContactListViewModel(ContactListWindow ThisWindow)
        {
            AddContactCommand = new RelayCommand(o =>
            {
                new AddContactWindow().ShowDialog();
            });
            AddCommand = new RelayCommand(o =>
            {
                ThisWindow.Close();
            });
        }
    }
}
