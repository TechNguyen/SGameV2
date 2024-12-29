using SGame.Model.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.Model.Entity
{
    [Table("Operation")]
    public class Operation : Auditable
    {
        [Required]
        public string ModuleCode { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        [Required]
        [StringLength(250)]
        public string URL { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public bool IsShow { get; set; }
        public int Order { get; set; }
    }
}
