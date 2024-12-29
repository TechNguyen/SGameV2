using SGame.Model.Entity;
using SGame.Repository.Core;
using SGame.Repository.AppUserRoleRepository;
using SGame.Service.Common;
using SGame.Service.Core;
using SGame.Service.Dtos.AppUserRoleDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGame.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace SGame.Service.AppUserRoleService
{
	public class AppUserRoleService : Service<AppUserRole>, IAppUserRoleService
	{
		private readonly IAppUserRoleRepository _AppUserRoleRepository;
		private readonly IHttpContextAccessor _httpContextAccessor;
        public AppUserRoleService(IAppUserRoleRepository AppUserRoleRepository, IHttpContextAccessor httpContextAccessor) : base(AppUserRoleRepository, httpContextAccessor)
        {
            _AppUserRoleRepository = AppUserRoleRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<PageList<AppUserRoleDto>?> GetPageList(SearchAppUserRoleDto searchBase)
		{
			var query = _AppUserRoleRepository.GetQueryable().Select(x => new AppUserRoleDto
			{
			});
			return PageList<AppUserRoleDto>.Create(query, searchBase);
		}

	}
}
