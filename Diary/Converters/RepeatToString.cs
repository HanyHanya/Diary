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
    public class RepeatToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                RepeatMode mode = (RepeatMode)value;
                if (mode == RepeatMode.DoNotRepeat)
                {
                    return "Не повторять";
                }
                else if (mode == RepeatMode.RepeatDaily)
                {
                    return "Ежедневно";
                }
                else if (mode == RepeatMode.RepeatMonthly)
                {
                    return "Ежемесячно";
                }
                else if (mode == RepeatMode.RepeatTwiceAWeek)
                {
                    return "Раз в две недели";
                }
                else if (mode == RepeatMode.RepeatWeekly)
                {
                    return "Еженедельно";
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
                if (mode == "Не повторять")
                {
                    return RepeatMode.DoNotRepeat;
                }
                else if (mode == "Ежедневно")
                {
                    return RepeatMode.RepeatDaily;
                }
                else if (mode == "Ежемесячно")
                {
                    return RepeatMode.RepeatMonthly;
                }
                else if (mode == "Раз в две недели")
                {
                    return RepeatMode.RepeatTwiceAWeek;
                }
                else if (mode == "Еженедельно")
                {
                    return RepeatMode.RepeatWeekly;
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
