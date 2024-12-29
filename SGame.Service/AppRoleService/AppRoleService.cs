using SGame.Model.Entity;
using SGame.Repository.Core;
using SGame.Repository.AppRoleRepository;
using SGame.Service.Common;
using SGame.Service.Core;
using SGame.Service.Dtos.AppRoleDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGame.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace SGame.Service.AppRoleService
{
	public class AppRoleService : Service<AppRole>, IAppRoleService
	{
		private readonly IAppRoleRepository _AppRoleRepository;
		private readonly IHttpContextAccessor _httpContextAccessor;
        public AppRoleService(IAppRoleRepository AppRoleRepository, IHttpContextAccessor httpContextAccessor) : base(AppRoleRepository,httpContextAccessor)
        {
            _AppRoleRepository = AppRoleRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<PageList<AppRoleDto>?> GetPageList(SearchAppRoleDto searchBase)
		{
			var query = _AppRoleRepository.GetQueryable().Select(x => new AppRoleDto
			{
			
			});
			return PageList<AppRoleDto>.Create(query, searchBase);
		}

		
		public async Task<AppRole> GetById(Guid Id)
		{
			var query = _AppRoleRepository.GetQueryable().FirstOrDefaultAsync(t => t.Id == Id);
			return await query;
        }

	}
}
