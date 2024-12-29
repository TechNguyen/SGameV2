using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.Model.Entity
{
    public class AppUser : IdentityUser<Guid>
    {
        public override Guid Id { get; set; }
        public override string UserName { get; set; }
        public override string Email { get; set; }
        public override string? PhoneNumber { get; set; }
        public int Gender { get; set; }
        public virtual string? Address { get; set; }

        [StringLength(250)]
        public virtual string? FullName { get; set; }
        public string? Avatar { get; set; }
        public string TypeAccount { get; set; }

        /// <summary>
        /// time tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        public string? CreateBy { get; set; }
        public Guid? CreateID { get; set; }

        /// <summary>
        /// time update
        /// </summary>
        public DateTime? UpdatedDate { get; set; }
        public string? UpdateBy { get; set; }
        public Guid? UpdatedID { get; set; }

        /// <summary>
        /// DELETE
        /// </summary>
        public bool? IsDelete { get; set; }

        public DateTime? DeleteTime { get; set; }
        public Guid? DeleteId { get; set; }

       
    }

    public class AppUserRole : IdentityUserRole<Guid>
    {

    }
    public class AppRole : IdentityRole<Guid>
    {

    }
    public class AppClaim : IdentityUserClaim<Guid>
    {

    }
    public class AppLogin : IdentityUserLogin<Guid>
    {

    }
    public class AppRoleClaim : IdentityRoleClaim<Guid>
    {

    }
    public class AppUserToken : IdentityUserToken<Guid>
    {

    }


}
