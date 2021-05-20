using System.Windows;
using Diary.MVVM.ViewModel;

namespace Diary.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для AddEventWindow.xaml
    /// </summary>
    public partial class AddEventWindow : Window
    {
        public static AddEventWindow Instance { get; internal set; }
        public AddEventWindow()
        {
            Instance = this;
            InitializeComponent();
            DataContext = new AddEventViewModel(this);
        }
    }
}
