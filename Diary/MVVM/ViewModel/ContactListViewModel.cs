using Diary.Core;
using Diary.MVVM.View;
using Diary.MVVM.Model.PrimaryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Diary.MVVM.Model.UnitOfWork;

namespace Diary.MVVM.ViewModel
{
    class ContactListViewModel : ObservableObject
    {
        public RelayCommand AddContactCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public ObservableCollection<Contact> List { get; set; }
        public Contact SelectedContact { get; set; }

        public ContactListViewModel(User user)
        {
            List = new ObservableCollection<Contact>();
            foreach (Contact entry in UnitOfWorkSingleton.Instance.Contacts.List)
            {
                if (entry.UserName == user.UserName)
                {
                    List.Add(entry);
                }
            }

            AddContactCommand = new RelayCommand(o =>
            {
                new AddContactWindow().ShowDialog();
            });
            AddCommand = new RelayCommand(o =>
            {

            });
        }
    }
}
