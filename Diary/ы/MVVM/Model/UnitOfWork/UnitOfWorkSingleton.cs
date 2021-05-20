using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.MVVM.Model.UnitOfWork
{
    public static class UnitOfWorkSingleton
    {
        private static object locker = new object();
        private static IUnitOfWork instance;
        public static IUnitOfWork Instance
        { 
            get
            {
               lock(locker)
               {
                   // if instance != null return instance, else ...
                   return instance ?? (instance = new UnitOfWorkEF());
               }
            }
        }

    }
}
