using SGame.Model.Entity;
using SGame.Service.Common;
using SGame.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGame.Service.Dtos.OperationDto;
using SGame.Common;


namespace SGame.Service.OperationService
{
	public interface IOperationService : IService<Operation>
	{
		Task<PageList<OperationDto>?> GetPageList(SearchOperationDto searchBase);
		Task<Operation> GetById(Guid Id);
	}
}
