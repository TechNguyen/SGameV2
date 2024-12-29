using SGame.Model;
using SGame.Model.Entity;
using SGame.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.Repository.AppUserRoleRepository
{
	public class AppUserRoleRepository : Repository<AppUserRole>, IAppUserRoleRepository
	{
		public AppUserRoleRepository(SGameContext preContext) : base(preContext)
		{

		}
	}
}
