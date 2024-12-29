using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.Service.Dtos.ModuleDto
{
    public class ModuleDto
    {
        public string Code { get; set; }
        public string Name { set; get; }
        public int Order { get; set; }
        public bool IsShow { get; set; }
        public string Icon { get; set; }
        public string ClassCss { get; set; }
        public string StyleCss { get; set; }
        public string Link { get; set; }

        public string? Id { get; set; }
    }
}
