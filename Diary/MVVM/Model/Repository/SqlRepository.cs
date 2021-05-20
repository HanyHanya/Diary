using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Diary.MVVM.Model.Repository
{
    public class SqlRepository<T> : IRepository<T> where T : class
    {
        public virtual IEnumerable<T> List
        {
            // AsNoTracking отключает трекер (который следит за изменениями файлов), что слегка ускоряет процесс получения их + предотвращает некоторые конфликты,
            // учитывая что List не предназначен для внесения изменений - для этого используются методы
            get => dbset.AsNoTracking().AsEnumerable();
        }

        protected ApplicationContext db;
        protected DbSet<T> dbset;

        public SqlRepository(ApplicationContext db)
        {
            this.db = db;
            dbset = db.Set<T>(); // Получает сет данного типа из контекста
        }

        public virtual T GetElement(object param)
        {
           return dbset.Find(param);
        }

        public virtual void Create(T item)
        {
            dbset.Add(item);
        }

        public virtual void Update(T item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public virtual void Delete(object param)
        {
            dbset.Remove(GetElement((param)));
        }
    }
}