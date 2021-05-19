using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.MVVM.Model.UnitOfWork
{
    public static class UnitOfWorkSingleton
    {
        static object locker = new object();
        static private IUnitOfWork instance;
        static public IUnitOfWork Instance
        { 
            get
            {
               lock(locker)
                {
                    if (instance == null)
                        instance = new UnitOfWorkEF();
                    return instance;
                }
            }
        }

    }
}
