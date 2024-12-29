using SGame.Model.Entity;
using SGame.Repository.Core;
using SGame.Repository.AppUserRepository;
using SGame.Service.Common;
using SGame.Service.Core;
using SGame.Service.Dtos.AppUserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SGame.Common;
using Microsoft.EntityFrameworkCore;

namespace SGame.Service.AppUserService
{
	public class AppUserService : Service<AppUser>, IAppUserService
	{
		private readonly IAppUserRepository _AppUserRepository;
		private readonly IHttpContextAccessor _httpContextAccessor;
        public AppUserService(IAppUserRepository AppUserRepository, IHttpContextAccessor httpContextAccessor) : base(AppUserRepository, httpContextAccessor)
        {
            _AppUserRepository = AppUserRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public bool CheckExistUserName(string username, Guid? id = null)
        {
            return _AppUserRepository.GetQueryable().Where(t => t.UserName != null && t.UserName.Equals(username) && (id.HasValue ? t.Id != id : true)).Any();
        }
        public bool CheckExistEmail(string email, Guid? id = null)
        {
            return _AppUserRepository.GetAll().Where(x => x.Email != null && x.Email.ToLower().Equals(email.ToLower()) && (id.HasValue ? x.Id != id : true)).Any();
        }

        public async Task<AppUserDto> GetUserInfo(Guid userId)
        {
            var q = await (from appUserTbl in _AppUserRepository.GetQueryable()
                           where appUserTbl.Id == userId
                           select new AppUserDto
                           {
                               Id = appUserTbl.Id,
                               UserName = appUserTbl.UserName,
                               Email = appUserTbl.Email,
                               PhoneNumber = appUserTbl.PhoneNumber,
                               Gender = appUserTbl.Gender,
                               Address = appUserTbl.Address,
                               FullName = appUserTbl.FullName,
                           }).FirstOrDefaultAsync();

            return q;

        }

        public async Task<PageList<AppUserDto>?> GetPageList(SearchAppUserDto searchBase)
		{
			var query = _AppUserRepository.GetQueryable().Select(x => new AppUserDto
			{
			
			});
			return PageList<AppUserDto>.Create(query, searchBase);
		}

		
		public async Task<AppUser> GetById(Guid Id)
		{
			var query = _AppUserRepository.GetQueryable().FirstOrDefaultAsync(t => t.Id == Id);
			return await query;
        }

	}
}
