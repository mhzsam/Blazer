using Application.IInfrastructure;
using Application.IService;
using Domain.Entites;
namespace Application.Service
{
	 public class PermissionService : BaseService<Permission>, IPermissionService
	{
		 public PermissionService(IRepository<Permission> repository) : base(repository)
		{
		}
	}
}