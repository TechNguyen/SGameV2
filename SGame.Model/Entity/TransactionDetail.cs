using SGame.Model.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.Model.Entity
{
    [Table("TransactionDetail")]
    public class TransactionDetail : Auditable
    {
        public Guid TransactionId { get; set; }
        public string Content { get; set; }
    }
}
