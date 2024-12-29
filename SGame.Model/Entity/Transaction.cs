using SGame.Model.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.Model.Entity
{
    [Table("Transaction")]
    public class Transaction : Auditable
    {
        public Guid? UserID { get; set; }
        public double Amount { get; set; }
        public int GoldenAdded { get; set; }
        public int Status { get; set; }
        
    }
}
