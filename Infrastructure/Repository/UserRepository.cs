using Application.IInfrastructure;
using Domain.Entites;
using Infrastructure.Context;
using Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
	{
		public UserRepository(ApplicationDBContext context) : base(context)
		{
		}
	}
}
