using Application.IInfrastructure;
using Domain.Entites;
using Infrastructure.Context;
using Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
	public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
	{

		public UserRoleRepository(ApplicationDBContext context) : base(context)
		{
		}

		public async Task<List<UserRole>?> GetAllByRelationAsync()
		{
			DbSet<UserRole> entity = base.GetEntity();
			IQueryable<UserRole> query = entity.AsNoTracking().Include(i => i.Role).Include(i => i.user);
			return await query.ToListAsync();
		}
	}
}
