using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.Model.Seed
{
    public class InitRoleAdminSeed
    {
        public static void Init(SGameContext context)
        {
            var AccountAdminName = "admin";
            var admin = context.Users.Where(t => t.UserName.Equals(AccountAdminName)).FirstOrDefault();
            if (admin != null)
            {
                var listOperation = context.Operations.ToList();
            }
        }
    }
}
