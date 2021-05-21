using Diary.Core;
using Diary.MVVM.Model.PrimaryModels;
using Diary.MVVM.Model.UnitOfWork;
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
        string Name { get; set; }
        string Note { get; set; }
        DateTime? Start { get; set; }
        DateTime? End { get; set; }
        Contact contact { get; set; }
        //string ContactName { get; set; }
        Status status { get; set; }
        RepeatMode repeat { get; set; }
        NotificationMode notification { get; set; }


        public RelayCommand AddCommand { get; set; }
        public RelayCommand AddContactCommand { get; set; }

        public AddEventViewModel(User user)
        {
            AddCommand = new RelayCommand(o =>
            {
                var uow = UnitOfWorkSingleton.Instance;
                uow.Events.Create(new Model.PrimaryModels.Event(Name, Start, End, Note, Status.InProcess, user, contact, RepeatMode.DoNotRepeat, NotificationMode.DoNotNotify));
                uow.SaveChanges();
                //ThisWindow.Close();
            });
            AddContactCommand = new RelayCommand(o =>
            {
                new ContactListWindow().ShowDialog();
            });
        }
    }
}
