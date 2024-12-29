using SGame.Model;
using SGame.Model.Entity;
using SGame.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.Repository.RoleOperationRepository
{
	public class RoleOperationRepository : Repository<RoleOperation>, IRoleOperationRepository
	{
		public RoleOperationRepository(SGameContext	 preContext) : base(preContext)
		{

		}
	}
}
