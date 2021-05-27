using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
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
            Regex phRegex = new Regex("^(\\+375|80)(29|25|44|33)(\\d{3})(\\d{2})(\\d{2})$");

            if (Name.Text.Length != 0)
            {
                if(Tel.Text.Length !=0 && phRegex.IsMatch(Tel.Text))
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Номер телефона должен иметь вид +375*********");
                }
            }
            else
            {
                MessageBox.Show("Введите имя");
            }
        }
    }
}
