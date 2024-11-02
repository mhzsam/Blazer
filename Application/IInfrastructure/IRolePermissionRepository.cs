using Domain.Entites;

namespace Application.IInfrastructure
{
	public interface IRolePermissionRepository : IRepository<RolePermission>
	{
		Task<List<RolePermission>?> GetAllByRelationAsync();
	}
}