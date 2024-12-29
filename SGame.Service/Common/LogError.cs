using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre_English.Service.Common
{
    public static class LogError
    {

        //LLog error when register
        public static List<string> LogingError(IdentityResult lstError)
        {
            List<string> errors = new List<string>();
            if (lstError.Errors != null && lstError.Errors?.Count() > 0)
            {
                foreach (var err in lstError.Errors)
                {
                    errors.Add(err.Description);
                }
            } 
            return errors;
        }
    }
}
