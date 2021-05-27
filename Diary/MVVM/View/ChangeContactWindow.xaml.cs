using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Diary.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для ChangeContactWindow.xaml
    /// </summary>
    public partial class ChangeContactWindow : Window
    {
        public ChangeContactWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Regex phRegex = new Regex("^(\\+375|80)(29|25|44|33)(\\d{3})(\\d{2})(\\d{2})$");

            if (Name.Text.Length != 0)
            {
                if (Tel.Text.Length != 0 && phRegex.IsMatch(Tel.Text))
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Номер телефона должен иметь вид +37529*******");
                }
            }
            else
            {
                MessageBox.Show("Введите имя");
            }
        }
    }
}
