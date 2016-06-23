using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCore.DB
{
    public class UserInfoContext : DbContext
    {
        public DbSet<UserInfo> Users { get; set; }
    }
}
