using Application.Dto;
using Application.IInfrastructure;
using Application.IService;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
	public class UserRoleService : BaseService<UserRole>, IUserRoleService
	{
		private readonly IUserRoleRepository _repository;

		public UserRoleService(IUserRoleRepository repository) : base(repository)
		{
			_repository = repository;
		}
		public async Task<List<UserWithRoleDto>?> GetAllByRelationAsync()
		{
			var result= await _repository.GetAllByRelationAsync();
			return result.GroupBy(s => s.UserId).Select(g =>
			{
				return new UserWithRoleDto
				{
					Id = g.Key,
					FirstName = g.FirstOrDefault()?.user?.FirstName,
					LastName = g.FirstOrDefault()?.user?.LastName,
					MobileNumber = g.FirstOrDefault()?.user?.MobileNumber,
					Roles = g.Select(user => user.Role)?
				  .Distinct()?
				  .ToList()
				};
			}).ToList();
		}
	}
}
