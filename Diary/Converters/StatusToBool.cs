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
    class StatusToBool : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                Status status = (Status)value;
                if(status == Status.Finished)
                {
                    return true;
                }
                else if (status == Status.InProcess)
                {
                    return false;
                }
                else 
                    return null;
            }
            else
                return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                bool status = (bool)value;
                if (status)
                {
                    return Status.Finished;
                }
                else if (!status)
                {
                    return Status.InProcess;
                }
                else
                    return null;
            }
            else
                return null;
        }
    }
}
