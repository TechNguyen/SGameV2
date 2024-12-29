using SGame.Model.Entity;
using SGame.Service.Common;
using SGame.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGame.Service.Dtos.AppUserRoleDto;
using SGame.Common;


namespace SGame.Service.AppUserRoleService
{
	public interface IAppUserRoleService : IService<AppUserRole>
	{
		Task<PageList<AppUserRoleDto>?> GetPageList(SearchAppUserRoleDto searchBase);

	}
}
