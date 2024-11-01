using Application.IInfrastructure;
using Application.IService;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
	public class RoleService : BaseService<Role>, IRoleService
	{
		public RoleService(IRepository<Role> repository) : base(repository)
		{
		}
	}
}
