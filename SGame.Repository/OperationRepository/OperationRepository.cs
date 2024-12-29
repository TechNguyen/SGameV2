using SGame.Model;
using SGame.Model.Entity;
using SGame.Model;
using SGame.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.Repository.OperationRepository
{
	public class OperationRepository : Repository<Operation>, IOperationRepository
	{
		public OperationRepository(SGameContext preContext) : base(preContext)
		{

		}
	}
}
