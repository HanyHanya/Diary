using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Логика взаимодействия для CangeEventWindow.xaml
    /// </summary>
    public partial class CangeEventWindow : Window
    {
        public CangeEventWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text.Length != 0)
            {
                if (Start.Text != null && End.Text != null && StartTime.Text != null && EndTime.Text != null)
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
