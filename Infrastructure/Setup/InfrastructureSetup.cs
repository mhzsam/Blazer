using Application.IInfrastructure;
using Application.Interface;
using Infrastructure.Context;
using Infrastructure.Repository;
using Infrastructure.Repository.Base;
using Infrastructure.Repository.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.SetUp
{
	public static class InfrastructureSetup
	{
		public static void AddInfrastructureService(this IServiceCollection services)
		{
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			services.AddScoped<IRoleRepository, RoleRepository>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IUserRoleRepository, UserRoleRepository>();
			services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
			services.AddScoped<IPermissionRepository, PermissionRepository>();

		}
		public static void AddApplicationDBContext(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<ApplicationDBContext>(options =>
			{

				options.UseLazyLoadingProxies()
					   .UseSqlServer(connectionString);
				options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
			});

		}
	}
}
