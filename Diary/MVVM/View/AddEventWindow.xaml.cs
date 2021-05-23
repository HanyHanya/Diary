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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
