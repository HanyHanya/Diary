﻿using Diary.Core;
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

        public Contact _contact { get; set; }

        public RelayCommand ChangeCommand { get; set; }
        public RelayCommand DelCommand { get; set; }
        public ChangeContactViewModel(Contact contact, ContactListViewModel ContactListVM)
        {
            _contact = contact;
            Name = _contact.Name;
            Tel = _contact.TelNum;
            Note = _contact.Notes;
            ChangeCommand = new RelayCommand(o =>       //игнорирует
            {
                var uow = UnitOfWorkSingleton.Instance;
                _contact.Name = Name;
                _contact.Notes = Note;
                _contact.TelNum = Tel;
                uow.SaveChanges();
                ContactListVM.RefreshContactList();
            });
            DelCommand = new RelayCommand(o =>
            {
                var uow = UnitOfWorkSingleton.Instance;
                uow.Contacts.Delete(contact.Id);
                ContactListVM.RefreshContactList();
                uow.SaveChanges();
            });
        }
    }   
}
