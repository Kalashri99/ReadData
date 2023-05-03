using System.ComponentModel.DataAnnotations;

namespace datafromexceltryingon3tables.Models
{
    public class CompanyCategory
    {
        [Key]
        public int CompanyCategoryId { get; set; }
        public string CompanyCategoryName { get; set; }
    }
}
