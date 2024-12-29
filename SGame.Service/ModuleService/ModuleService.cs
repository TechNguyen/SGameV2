using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SGame.Common;
using SGame.Model.Entity;
using SGame.Repository.Core;
using SGame.Repository.ModuleRepository;
using SGame.Service.Common;
using SGame.Service.Core;
using SGame.Service.Dtos.ModuleDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.Service.ModuleService
{
	public class ModuleService : Service<Module>, IModuleService
	{
		private readonly IModuleRepository _ModuleRepository;
		private readonly IHttpContextAccessor _httpContextAccessor;
        public ModuleService(IModuleRepository ModuleRepository, IHttpContextAccessor httpContextAccessor) : base(ModuleRepository, httpContextAccessor)
        {
            _ModuleRepository = ModuleRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<PageList<ModuleDto>?> GetPageList(SearchModuleDto searchBase)
		{
			var query = _ModuleRepository.GetQueryable()
				.Where(x => x.IsDelete == null || (x.IsDelete.HasValue && !x.IsDelete.Value))
				.Select(x => new ModuleDto
			{
				Code = x.Code,
				ClassCss = x.ClassCss,
				Link = x.Link,
				Icon = x.Icon,
				Id = x.Id.ToString(),
				Name = x.Name,
				IsShow = x.IsShow,
				Order = x.Order,
				StyleCss = x.StyleCss
			});

			if (searchBase != null)
			{
				if (!string.IsNullOrEmpty(searchBase.Code))
				{
					query = query.Where(x => x.Code.Equals(searchBase.Code));
				}
				if (!string.IsNullOrEmpty(searchBase.Name))
				{
                    query = query.Where(x => x.Name.Contains(searchBase.Name));
				}
			}

			query = query.OrderBy(x => x.Order);
			return PageList<ModuleDto>.Create(query, searchBase);
		}

		public async Task<ModuleDto> CheckByCode(string code)
		{
			var query = _ModuleRepository.GetQueryable().Where(x => x.Code.Equals(code))
				.Select(x => new ModuleDto
				{
					Id = x.Id.ToString(),
					Code = x.Code,
					StyleCss = x.StyleCss,
					ClassCss = x.ClassCss,
					Link = x.Link,
					Icon = x.Icon,
					IsShow = x.IsShow,
					Name = x.Name,
					Order = x.Order
				})
				.FirstOrDefaultAsync();
			return await query;
		}


		public async Task<Module> GetById(Guid Id)
		{
			var query = _ModuleRepository.GetQueryable().FirstOrDefaultAsync(t => t.Id == Id);
			return await query;
        }

	}
}
