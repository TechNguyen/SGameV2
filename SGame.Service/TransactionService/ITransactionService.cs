using SGame.Model.Entity;
using SGame.Service.Common;
using SGame.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGame.Service.Dtos.TransactionDto;
using SGame.Common;


namespace SGame.Service.TransactionService
{
	public interface ITransactionService : IService<Transaction>
	{
		Task<PageList<TransactionDto>?> GetPageList(SearchTransactionDto searchBase);
		Task<Transaction> GetById(Guid Id);
	}
}
