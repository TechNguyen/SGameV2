using SGame.Model;
using SGame.Model.Entity;
using SGame.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.Repository.AppUserRepository
{
	public class AppUserRepository : Repository<AppUser>, IAppUserRepository
	{
		public AppUserRepository(SGameContext preContext) : base(preContext)
		{

		}
	}
}
