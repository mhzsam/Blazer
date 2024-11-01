
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class UserRole : BaseEntity
    {
		
		public int RoleId { get; set; }
        public virtual Role? Role { get; set; }
        public int UserId { get; set; }
        public virtual User? user { get; set; }

    }
}
