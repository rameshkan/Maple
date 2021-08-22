using MapleCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleData
{
    public class EFRepository : Repository
    {
        public EFRepository(AppDBContext dbContext) : base(dbContext)
        {
        }

    }
}
