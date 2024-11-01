using Domain.Entites;
using Domain.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
	public class UserWithRoleDto : User
	{
		public List<Role> Roles { get; set; }
	}
}
