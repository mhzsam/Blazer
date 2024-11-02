using Application.Dto;
using Application.IInfrastructure;
using Application.IService;
using Domain.Entites;

namespace Application.Service
{
	public class RolePermissionService : BaseService<RolePermission>, IRolePermissionService
	{
		private readonly IRolePermissionRepository _repository;
		public RolePermissionService(IRolePermissionRepository repository) : base(repository)
		{
			_repository = repository;
		}

		public async Task<List<RoleWithPermissionDto>?> GetAllByRelationAsync()
		{
			var result = await _repository.GetAllByRelationAsync();
			return result.GroupBy(s => s.RoleId).Select(g =>
			{
				return new RoleWithPermissionDto
				{
					Id = g.Key,
					RoleName = g.FirstOrDefault()?.Role?.RoleName,
					Permissions = g.Select(r => r.Permission)?
				  .Distinct()?
				  .ToList()
				};
			}).ToList();
		}
	}
}