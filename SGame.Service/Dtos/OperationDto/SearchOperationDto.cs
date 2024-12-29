using SGame.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.Service.Dtos.OperationDto
{
    public class SearchOperationDto : SearchBase
    {
        public string? Code { get; set; }
        public string? ModuleCode { get; set; }
        public string? Name { get; set; }
    }
}