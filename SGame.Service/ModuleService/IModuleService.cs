using SGame.Model.Entity;
using SGame.Service.Common;
using SGame.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGame.Service.Dtos.ModuleDto;
using SGame.Common;


namespace SGame.Service.ModuleService
{
	public interface IModuleService : IService<Module>
	{
		Task<PageList<ModuleDto>?> GetPageList(SearchModuleDto searchBase);
		Task<Module> GetById(Guid Id);
        Task<ModuleDto> CheckByCode(string code);
    }
}
