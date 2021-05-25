using Diary.Core;
using Diary.MVVM.Model.PrimaryModels;
using Diary.MVVM.Model.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.MVVM.ViewModel
{
    class ChangeContactViewModel : ObservableObject
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }
        private string tel;
        public string Tel
        {
            get { return tel; }
            set { tel = value; OnPropertyChanged(); }
        }
        private string note;
        public string Note
        {
            get { return note; }
            set { note = value; OnPropertyChanged(); }
        }

        public RelayCommand CangeCommand { get; set; }
        public ChangeContactViewModel(Contact contact, ContactListViewModel ContactListVM)
        {
           CangeCommand = new RelayCommand(o =>
            {
                var uow = UnitOfWorkSingleton.Instance;
                contact.Name = Name;
                contact.Notes = Note;
                contact.TelNum = Tel;
                uow.SaveChanges();
                ContactListVM.RefreshContactList();
            });
        }
    }   
}
