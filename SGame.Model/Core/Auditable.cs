using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.Model.Core
{
    public abstract class Auditable : Entity, IAuditable
    {
        [ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set; }
        [MaxLength(255)]
        [ScaffoldColumn(false)]
        public string? CreatedBy { get; set; }
        public Guid? CreatedID { get; set; }
        [ScaffoldColumn(false)]
        public DateTime UpdatedDate { get; set; }
        public Guid? UpdatedID { get; set; }
        [MaxLength(255)]
        [ScaffoldColumn(false)]
        public string? UpdatedBy { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? DeleteTime { get; set; }
        public Guid? DeleteId { get; set; }
        [MaxLength(255)]
        [ScaffoldColumn(false)]
        public string? DeleteBy { get; set; }
    }
}
