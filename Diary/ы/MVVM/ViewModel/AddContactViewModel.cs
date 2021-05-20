using Diary.Core;
using Diary.MVVM.View;

namespace Diary.MVVM.ViewModel
{
    class AddContactViewModel : ObservableObject
    {
        public RelayCommand AddCommand { get; set; }
        public AddContactViewModel(AddContactWindow ThisWindow)
        {
            AddCommand = new RelayCommand(o =>
            {
                ThisWindow.Close();
            });
        }
    }
}
