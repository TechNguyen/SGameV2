using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGame.Model.Core;

namespace SGame.Model
{
    [Table("RoleOperation")]
    public class RoleOperation : Auditable
    {
        public Guid RoleId { get; set; }

        public Guid OperationId { get; set; }

        public int IsAccess { get; set; }
    }
}
