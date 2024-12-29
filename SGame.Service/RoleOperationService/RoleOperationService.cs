using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SGame.Common;
using SGame.Model;
using SGame.Repository.Core;
using SGame.Repository.RoleOperationRepository;
using SGame.Service.Common;
using SGame.Service.Core;
using SGame.Service.Dtos.RoleOperationDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.Service.RoleOperationService
{
	public class RoleOperationService : Service<RoleOperation>, IRoleOperationService
	{
		private readonly IRoleOperationRepository _RoleOperationRepository;

		private readonly IHttpContextAccessor _httpContextAccessor;
        public RoleOperationService(IRoleOperationRepository RoleOperationRepository, IHttpContextAccessor httpContextAccessor) : base(RoleOperationRepository, httpContextAccessor)
        {
            _RoleOperationRepository = RoleOperationRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<PageList<RoleOperationDto>?> GetPageList(SearchRoleOperationDto searchBase)
		{
			var query = _RoleOperationRepository.GetQueryable().Select(x => new RoleOperationDto
			{
				RoleId = x.RoleId,
				OperationId = x.OperationId,
				IsAccess = x.IsAccess
			});
			return PageList<RoleOperationDto>.Create(query, searchBase);
		}

		
		public async Task<RoleOperation> GetById(Guid Id)
		{
			var query = _RoleOperationRepository.GetQueryable().FirstOrDefaultAsync(t => t.Id == Id);
			return await query;
        }

	}
}
