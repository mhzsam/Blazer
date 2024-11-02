using Application.Dto;
using Domain.Entites;
namespace Application.IService
{
	public interface IRolePermissionService : IBaseService<RolePermission>
	{
		Task<List<RoleWithPermissionDto>?> GetAllByRelationAsync();
	}
}