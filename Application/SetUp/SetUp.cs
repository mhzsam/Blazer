
using Application.IService;
using Application.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Application.SetUp
{
	public static class SetUp
	{
		public static void AddAllApplicationServices(this IServiceCollection services)
		{
			services.AddMemoryCache();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IUserRoleService, UserRoleService>();
			services.AddScoped<IRoleService, RoleService>();
			//services.AddSingleton(typeof(Mapper<>));

		}


	}
}
