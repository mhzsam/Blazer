
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites
{
    public class Permission : BaseEntity
    {
        public string PageName { get; set; }       
        
    }
}
