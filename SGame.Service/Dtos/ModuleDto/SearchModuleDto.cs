using SGame.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.Service.Dtos.ModuleDto
{
    public class SearchModuleDto : SearchBase
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
    }
}
