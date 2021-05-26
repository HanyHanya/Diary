using System.Collections.Generic;
using System.Data.Entity;
using Diary.MVVM.Model.PrimaryModels;

namespace Diary.MVVM.Model.Repository
{
    public class SqlEventRepository : SqlRepository<Event>
    {
        public SqlEventRepository(ApplicationContext db) : base(db)
        {
        }

        public override IEnumerable<Event> List => dbset.AsNoTracking().Include(x => x.User);


    }
}