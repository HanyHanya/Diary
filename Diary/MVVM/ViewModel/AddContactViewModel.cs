using Diary.Core;
using Diary.MVVM.Model.PrimaryModels;
using Diary.MVVM.Model.UnitOfWork;
using Diary.MVVM.View;

namespace Diary.MVVM.ViewModel
{
    class AddContactViewModel : ObservableObject
    {
        string Name { get; set; }
        string Tel { get; set; }
        string Note { get; set; }

        public RelayCommand AddCommand { get; set; }
        public AddContactViewModel(User user)
        {
            AddCommand = new RelayCommand(o =>
            {
                var uow = UnitOfWorkSingleton.Instance;
                uow.Contacts.Create(new Model.PrimaryModels.Contact(Name, Tel, Note, user));//придумать что-то с ID или вкинуть его в identity
                uow.SaveChanges();
                //ThisWindow.Close();
            });
        }
    }
}
