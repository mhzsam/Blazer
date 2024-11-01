using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Helper
{
	public class MobileNumberAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{

			if (value == null)
			{
				return new ValidationResult("شماره موبایل الزامی است.");
			}

			var phoneNumber = value.ToString()?.Trim();

			var regex = new Regex(@"^(09\d{9})$");

			if (!regex.IsMatch(phoneNumber))
			{
				return new ValidationResult("شماره موبایل باید 11 رقمی و با پیش شماره 09 آغاز شود.");
			}
			if (phoneNumber.Length != 11)
			{
				return new ValidationResult("شماره موبایل باید  11 رقمی باشد.");
			}

			return ValidationResult.Success;
		}
	}
}
