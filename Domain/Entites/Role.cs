
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites
{
    public class Role: BaseEntity
	{
		

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "مقدار نقش الزامی است ")]
        [MaxLength(50)]
        public string RoleName { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
    }
}
