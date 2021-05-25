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
    public class RemindToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                NotificationMode mode = (NotificationMode)value;
                if (mode == NotificationMode.DoNotNotify)
                {
                    return "Не напоминать";
                }
                else if (mode == NotificationMode.NotifyDayBefore)
                {
                    return "За день";
                }
                else if (mode == NotificationMode.NotifyHourBefore)
                {
                    return "за час";
                }
                else if (mode == NotificationMode.NotifyThreeDaysBefore)
                {
                    return "За три дня";
                }
                else if (mode == NotificationMode.NotifyThreeHoursBefore)
                {
                    return "За три часа";
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
                string mode = (string)value;
                if (mode == "Не напоминать")
                {
                    return NotificationMode.DoNotNotify;
                }
                else if (mode == "За день")
                {
                    return NotificationMode.NotifyDayBefore;
                }
                else if (mode == "за час")
                {
                    return NotificationMode.NotifyHourBefore;
                }
                else if (mode == "За три дня")
                {
                    return NotificationMode.NotifyThreeDaysBefore;
                }
                else if (mode == "За три часа")
                {
                    return NotificationMode.NotifyThreeHoursBefore;
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
