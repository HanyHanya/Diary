using System.Collections.Generic;

namespace Diary.MVVM.Model.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> List { get; }
        T GetElement(object param);
        void Create(T item);
        void Update(T item);
        void Delete(object param);
    }
}
