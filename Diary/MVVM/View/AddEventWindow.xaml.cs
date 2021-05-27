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
            if(Name.Text.Length != 0)
            {
                if (Start.Text.Length != 0 && End.Text.Length != 0 && StartTime.Text.Length != 0 && EndTime.Text.Length != 0)
                {
                    if (Repeat.Text.Length != 0 && Remind.Text.Length != 0)
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Выберите режимы повотрения и напоминания");
                    }
                }
                else
                {
                    MessageBox.Show("Введите даты начала и окончания");
                }
            }
            else
            {
                MessageBox.Show("Введите название события");
            }
        }
    }
}
