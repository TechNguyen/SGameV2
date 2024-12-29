using SGame.Model;
using SGame.Model.Entity;
using SGame.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.Repository.AppRoleRepository
{
	public class AppRoleRepository : Repository<AppRole>, IAppRoleRepository
	{
		public AppRoleRepository(SGameContext preContext) : base(preContext)
		{

		}
	}
}
