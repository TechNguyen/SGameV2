using SGame.Service.Common;
using SGame.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGame.Service.Dtos.RoleOperationDto;
using SGame.Model;
using SGame.Common;


namespace SGame.Service.RoleOperationService
{
	public interface IRoleOperationService : IService<RoleOperation>
	{
		Task<PageList<RoleOperationDto>?> GetPageList(SearchRoleOperationDto searchBase);
		Task<RoleOperation> GetById(Guid Id);
	}
}
