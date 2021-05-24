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
        public string Name { get; set; }
        public RelayCommand AddContactCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand FindContactCommand { get; set; }
        public ObservableCollection<Contact> List { get; set; }

        private Contact _selectedContact;

        public Contact SelectedContact
        {
            get { return _selectedContact; }
            set { _selectedContact = value; OnPropertyChanged(); }
        }

        //Сюда сортировку докинуть 
        //ВЫбор контакта + его удаление и подробное описание. Проще всего сделать докинув кнопку, но она отказывается докидываться
        public ContactListViewModel(User user, AddEventViewModel addEventViewModel = null)
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
                AddContactWindow taskWin = new AddContactWindow()
                {
                    DataContext = new AddContactViewModel(user)
                };
                taskWin.ShowDialog();
                List.Clear();
                foreach (Contact entry in UnitOfWorkSingleton.Instance.Contacts.List)
                {
                    if (entry.UserName == user.UserName)
                    {
                        List.Add(entry);
                    }
                }
            });
            AddCommand = new RelayCommand(o =>
            {
                if (SelectedContact != null)
                {
                    MessageBox.Show("Вот тут дорлжен выбираться контакт и передаваться в окошко к событию, я ебала.");
                    if (addEventViewModel != null)
                        addEventViewModel.Contact = SelectedContact;
                }
                else
                {
                    MessageBox.Show("Выберите контакт");
                }
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
    }
}
