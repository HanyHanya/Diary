using System.Windows;
using Diary.MVVM.ViewModel;

namespace Diary.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для AddContactWindow.xaml
    /// </summary>
    public partial class AddContactWindow : Window
    {
        public static AddContactWindow Instance { get; internal set; }
        public AddContactWindow()
        {
            InitializeComponent();
            Instance = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
