using SGame.Model;
using SGame.Model.Entity;
using SGame.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.Repository.ModuleRepository
{
	public class ModuleRepository : Repository<Module>, IModuleRepository
	{
		public ModuleRepository(SGameContext preContext) : base(preContext)
		{

		}
	}
}
