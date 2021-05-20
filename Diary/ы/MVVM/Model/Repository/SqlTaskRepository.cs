using System.Collections.Generic;
using System.Data.Entity;
using Diary.MVVM.Model.PrimaryModels;
namespace Diary.MVVM.Model.Repository
{
    public class SqlTaskRepository : SqlRepository<Task> 
    {
        public SqlTaskRepository(ApplicationContext db) : base(db)
        {
        }

        public override IEnumerable<Task> List => dbset.AsNoTracking().Include(x => x.User);
    }
}