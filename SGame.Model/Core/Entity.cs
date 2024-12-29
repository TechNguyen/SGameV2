using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.Model.Core
{
    [PrimaryKey(nameof(Id))]
    public class Entity : BaseEntity , IEntity
    {
        public virtual Guid Id { get; set; }
    }
}
