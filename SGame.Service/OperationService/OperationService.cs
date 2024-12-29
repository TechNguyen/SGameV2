using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SGame.Common;
using SGame.Model.Entity;
using SGame.Repository.Core;
using SGame.Repository.OperationRepository;
using SGame.Service.Common;
using SGame.Service.Core;
using SGame.Service.Dtos.OperationDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.Service.OperationService
{
	public class OperationService : Service<Operation>, IOperationService
	{
		private readonly IOperationRepository _OperationRepository;
		private readonly IHttpContextAccessor _httpContextAccessor;
        public OperationService(IOperationRepository OperationRepository, IHttpContextAccessor httpContextAccessor) : base(OperationRepository, httpContextAccessor)
        {
            _OperationRepository = OperationRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<PageList<OperationDto>?> GetPageList(SearchOperationDto searchBase)
		{
			var query = _OperationRepository.GetQueryable().Select(x => new OperationDto
			{
				Name = x.Name,
				Code = x.Code,
				ModuleCode = x.ModuleCode,
				IsShow = x.IsShow,
				Order = x.Order
			});

			if (searchBase != null)
			{
				if (!string.IsNullOrEmpty(searchBase.Name))
				{
					query = query.Where(x => x.Name.Contains(searchBase.Name));
				}
				if (!string.IsNullOrEmpty(searchBase.Code))
				{
					query = query.Where(x => x.Code.Equals(searchBase.Code));
				}
				if (!string.IsNullOrEmpty(searchBase.ModuleCode))
				{
					query = query.Where(x => x.ModuleCode.Equals(searchBase.ModuleCode));
				}
			}
			return PageList<OperationDto>.Create(query, searchBase);
		}

		
		public async Task<Operation> GetById(Guid Id)
		{
			var query = _OperationRepository.GetQueryable().FirstOrDefaultAsync(t => t.Id == Id);
			return await query;
        }

	}
}
