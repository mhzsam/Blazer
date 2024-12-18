﻿using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IInfrastructure
{
	public interface IUserRoleRepository : IRepository<UserRole>
	{
		Task<List<UserRole>?> GetAllByRelationAsync();
	}
}
