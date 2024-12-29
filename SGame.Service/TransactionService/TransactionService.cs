using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SGame.Common;
using SGame.Model.Entity;
using SGame.Repository.Core;
using SGame.Repository.TransactionRepository;
using SGame.Service.Common;
using SGame.Service.Core;
using SGame.Service.Dtos.TransactionDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.Service.TransactionService
{
	public class TransactionService : Service<Transaction>, ITransactionService
	{
		private readonly ITransactionRepository _TransactionRepository;
		private readonly IHttpContextAccessor _httpContextAccessor;
        public TransactionService(ITransactionRepository TransactionRepository, IHttpContextAccessor httpContextAccessor) : base(TransactionRepository, httpContextAccessor)
        {
            _TransactionRepository = TransactionRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<PageList<TransactionDto>?> GetPageList(SearchTransactionDto searchBase)
		{
			var query = _TransactionRepository.GetQueryable().Select(x => new TransactionDto
			{

			});
			return PageList<TransactionDto>.Create(query, searchBase);
		}

		
		public async Task<Transaction> GetById(Guid Id)
		{
			var query = _TransactionRepository.GetQueryable().FirstOrDefaultAsync(t => t.Id == Id);
			return await query;
        }

	}
}
