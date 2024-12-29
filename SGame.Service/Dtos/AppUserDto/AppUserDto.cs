using SGame.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.Service.Dtos.AppUserDto
{
    public class AppUserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public List<string> lstRoles { get; set; }
        public string token { get; set; }
        public int Gender { get; set; }

        public string Address { get; set; }

        public string FullName { get; set; }
    }
}
