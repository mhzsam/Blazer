using Application.IInfrastructure;
using Application.Interface;
using Application.IService;
using BlazerTest.Helper;
using Domain.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazerTest.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class Test : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IUserService _userService;
		private readonly IRoleService _roleService;
		private readonly IUserRoleService _userRoleService;

		public Test(IUnitOfWork unitOfWork, IUserService userService, IRoleService roleService, IUserRoleService userRoleService)
		{
			_unitOfWork = unitOfWork;
			_userService = userService;
			_roleService = roleService;
			_userRoleService = userRoleService;
		}

		[HttpGet("test1")]
		public async Task Test1()
		{
            var pages = PageFinder.GetAllBlazorPages();
            try
			{
			    await	_unitOfWork.BeginTransactionAsync();

				var ff = (await _userService.GetAllAsync()).Select(s => Convert.ToInt32(s.Password)).Max();
				await _userService.InsertAsync(new User { FirstName = "bb", LastName = "dd", MobileNumber = "09120198177", Password = (ff + 1).ToString() });

				var lst = await _userRoleService.GetAsync(1);
				Role? gg = lst.Role;

				await _unitOfWork.SaveAndCommitAsync();
			}
			catch (Exception ex)
			{
				await _unitOfWork.RollbackAsync();
				throw new Exception(ex.Message);
			}
		}

	}
}
