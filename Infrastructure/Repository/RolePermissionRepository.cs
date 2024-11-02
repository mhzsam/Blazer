using Application.IInfrastructure;
using Domain.Entites;
using Infrastructure.Context;
using Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repository
{
	public class RolePermissionRepository : Repository<RolePermission>, IRolePermissionRepository
	{
		public RolePermissionRepository(ApplicationDBContext context) : base(context)
		{
		}
		public async Task<List<RolePermission>?> GetAllByRelationAsync()
		{
			DbSet<RolePermission> entity = base.GetEntity();
			IQueryable<RolePermission> query = entity.AsNoTracking().Include(i => i.Role).Include(i => i.Permission);
			return await query.ToListAsync();
		}
	}
}