using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HenriksHobbyLager.Database
{
    public static class SqliteDatabaseInitializer
    {
        public static void Initialize()
        {
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();
            }
        }
    }
}
