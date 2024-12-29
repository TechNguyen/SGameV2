using SGame.Model.Entity;
using SGame.Service.Common;
using SGame.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGame.Service.Dtos.AppRoleDto;
using SGame.Common;

namespace SGame.Service.AppRoleService
{
	public interface IAppRoleService : IService<AppRole>
	{
		Task<PageList<AppRoleDto>?> GetPageList(SearchAppRoleDto searchBase);
		Task<AppRole> GetById(Guid Id);
	}
}
