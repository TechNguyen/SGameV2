using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGame.Model.Entity;
using SGame.Model;

namespace SGame.Model.Seed
{
    public class InitAccountSeed
    {
        private readonly SGameContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly ILogger<InitAccountSeed> _logger;

        public InitAccountSeed(SGameContext context,
        UserManager<AppUser> userManager,
        RoleManager<AppRole> roleManager,
        ILogger<InitAccountSeed> logger)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }
        public async Task InitAsync()
        {
            var AccountAdminName = "admin";
            var AccountAdminPassword = "12345678A@";
            var userAdmin = _context.AppUser.FirstOrDefault(x => x.UserName.Equals(AccountAdminName));
            if (userAdmin == null)
            {
                var user = new AppUser
                {
                    UserName = AccountAdminName,
                    Address = string.Empty,
                    Avatar = string.Empty,
                    CreateBy = string.Empty,
                    CreatedDate = DateTime.Now,
                    CreateID = Guid.NewGuid(),
                    Email = string.Empty,  
                    FullName = "Quản trị hệ thống",
                    TypeAccount = "Bussiness User"
                };
                if (!await _roleManager.RoleExistsAsync("admin"))
                {
                    await _roleManager.CreateAsync(new AppRole { Name = "admin", NormalizedName = "ADMIN" });
                }
                var password = new PasswordHasher<AppUser>();
                var hashed = password.HashPassword(user, AccountAdminPassword);
                user.PasswordHash = hashed;
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "admin");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        _logger.LogError(error.Description);
                    }
                }
            }
            await _context.SaveChangesAsync();
        }
    }
}
