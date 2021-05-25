using Diary.MVVM.Model.PrimaryModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Diary.Converters
{
    public class StatusToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                Status status = (Status)value;
                if (status == Status.NotStarted)
                {
                    return "Не начато";
                }
                else if (status == Status.InProcess)
                {
                    return "В процессе";
                }
                else if (status == Status.Started)
                {
                    return "Начато";
                }
                else if (status == Status.Finished)
                {
                    return "Завершено";
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string status = (string)value;
                if (status == "Не начато")
                {
                    return Status.NotStarted;
                }
                else if (status == "Начато")
                {
                    return Status.Started;
                }
                else if (status == "В процессе")
                {
                    return Status.InProcess;
                }
                else if (status == "Завершено")
                {
                    return Status.Finished;
                }
                else
                {
                    return null;
                }
            }
            else
                return null;
        }
    }
}
