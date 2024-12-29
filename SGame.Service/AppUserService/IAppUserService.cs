using SGame.Model.Entity;
using SGame.Service.Common;
using SGame.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGame.Service.Dtos.AppUserDto;
using SGame.Common;


namespace SGame.Service.AppUserService
{
	public interface IAppUserService : IService<AppUser>
	{
		Task<PageList<AppUserDto>?> GetPageList(SearchAppUserDto searchBase);
		Task<AppUser> GetById(Guid Id);
        bool CheckExistUserName(string username, Guid? id = null);
        bool CheckExistEmail(string email, Guid? id = null);
        Task<AppUserDto> GetUserInfo(Guid userId);
    }
}
