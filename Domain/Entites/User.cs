using Domain.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
	public class User : BaseEntity
	{
		
		[MaxLength(100)]
		[Required(ErrorMessage = "نام الزامی است")]
		public string FirstName { get; set; }

		[MaxLength(100)]
		[Required(ErrorMessage = "فامیلی الزامی است")]
		public string LastName { get; set; }

		[MobileNumberAttribute]
		[Required(ErrorMessage = "شماره موبایل الزامی است ")]
		[MaxLength(11)]
		public string MobileNumber { get; set; }
		public byte[]? Avatar { get; set; }

		[Required(ErrorMessage = "رمز عبور الزامی است ")]
		public string? Password { get; set; }
	}
}
