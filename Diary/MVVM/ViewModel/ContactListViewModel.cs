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
using System.Windows;

namespace Diary.MVVM.ViewModel
{
    class ContactListViewModel : ObservableObject
    {
        private string name;
        public string Name 
        { 
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }
        public RelayCommand AddContactCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand FindContactCommand { get; set; }
        public RelayCommand ChangeContactCommand { get; set; }
        public ObservableCollection<Contact> List { get; set; }
        User _user { get; set; }

        private Contact _selectedContact;

        public Contact SelectedContact
        {
            get { return _selectedContact; }
            set { _selectedContact = value; OnPropertyChanged(); }
        }

        //доступ к окну ChangeContactWindow, передавать SelectedContact
        //Сюда сортировку докинуть 
        //ВЫбор контакта + его удаление и подробное описание. Проще всего сделать докинув кнопку, но она отказывается докидываться
        public ContactListViewModel(User user, AddEventViewModel addEventViewModel)
        {
            _user = user;
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
                AddContactWindow taskWin = new AddContactWindow()
                {
                    DataContext = new AddContactViewModel(user)
                };
                taskWin.ShowDialog();
                RefreshContactList();
            });
            AddCommand = new RelayCommand(o =>
            {
                if (SelectedContact != null)
                {
                    if (addEventViewModel != null)
                        addEventViewModel.Contact = SelectedContact;
                }
                else
                {
                    MessageBox.Show("Выберите контакт");
                }
            });
            ChangeContactCommand = new RelayCommand(o =>
            {
                ChangeContactWindow taskWin = new ChangeContactWindow()
                {
                    DataContext = new ChangeContactViewModel(SelectedContact, this)
                };
                taskWin.ShowDialog();
            });
            FindContactCommand = new RelayCommand(o =>
            {
                var uow = UnitOfWorkSingleton.Instance;
                foreach (Contact entry in List)
                {
                    if (entry.Name == Name)
                    {
                        List.Clear();
                        List.Add(entry);
                        break;
                    }
                    
                }
                if(List.Count != 1 )
                {
                    MessageBox.Show("Контакт не найден");
                }

            });
        }
        public void RefreshContactList()
        {
            List.Clear();
            foreach (Contact entry in UnitOfWorkSingleton.Instance.Contacts.List)
            {
                if (entry.UserName == _user.UserName)
                {
                    List.Add(entry);
                }
            }
        }
    }
}
