using Application.IInfrastructure;
using Application.IService;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
	public class UserService : BaseService<User>, IUserService
	{
		public UserService(IRepository<User> repository) : base(repository)
		{
		}

		public override async Task<User> InsertAsync(User entity)
		{
			List<User>? lstUser = await base.FindByConditionAsync(w => w.MobileNumber == entity.MobileNumber);
			if (lstUser != null || lstUser?.Count > 0)
				throw new Exception("این شماره موبایل موجود است");
			return await base.InsertAsync(entity);
		}
		public override void Update(User entity)
		{
			var lstUser = base.FindByCondition(w => w.MobileNumber == entity.MobileNumber);
			if (lstUser != null && lstUser.Count > 0 && !lstUser.Any(a=>a.Id==entity.Id))
				throw new Exception("این شماره موبایل موجود است");
			base.Update(entity);
		}

	}
}
