using SGame.Model;
using SGame.Model.Entity;
using SGame.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.Repository.TransactionRepository
{
	public class TransactionRepository : Repository<Transaction>, ITransactionRepository
	{
		public TransactionRepository(SGameContext preContext) : base(preContext)
		{

		}
	}
}
