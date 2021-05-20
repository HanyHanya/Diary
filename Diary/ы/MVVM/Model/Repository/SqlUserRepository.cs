using System.Collections.Generic;
using System.Data.Entity;
using Diary.MVVM.Model.PrimaryModels;

namespace Diary.MVVM.Model.Repository
{
    public class SqlUserRepository : SqlRepository<User>
    {
        public SqlUserRepository(ApplicationContext db) : base(db)
        {
        }

        public override IEnumerable<User> List => dbset.AsNoTracking().Include(x => x.Tasks).Include(x => x.Events).Include(x=>x.Contacts);
    }
}