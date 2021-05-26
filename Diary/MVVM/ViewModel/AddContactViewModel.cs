using Diary.Core;
using Diary.MVVM.Model.PrimaryModels;
using Diary.MVVM.Model.UnitOfWork;
using Diary.MVVM.View;
using System;
using System.Windows;

namespace Diary.MVVM.ViewModel
{
    class AddContactViewModel : ObservableObject
    {
        private string name;
        public string Name 
        {
            get { return name; }
            set { name = value; }
        }
        private string tel;
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        private string note;
        public string Note
        {
            get { return note; }
            set { note = value; }
        }

        public RelayCommand AddCommand { get; set; }
        public AddContactViewModel(User user)
        {
            AddCommand = new RelayCommand(o =>
            {
                try
                {
                    var uow = UnitOfWorkSingleton.Instance;
                    uow.Contacts.Create(new Model.PrimaryModels.Contact(Name, Tel, Note, user));
                    uow.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }
    }
}
