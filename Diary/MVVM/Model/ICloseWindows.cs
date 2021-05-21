using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.MVVM.Model
{
    interface ICloseWindows
    {
        Action Close { get; set; }
    }
}
