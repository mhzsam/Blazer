using Application.IInfrastructure;
using Domain.Entites;
using Infrastructure.Context;
using Infrastructure.Repository.Base;
namespace Infrastructure.Repository
{
	 public class PermissionRepository : Repository<Permission>, IPermissionRepository
	{
		 public PermissionRepository(ApplicationDBContext context) : base(context)
		{
		}
	}
}