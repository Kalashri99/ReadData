using System.ComponentModel.DataAnnotations;

namespace datafromexceltryingon3tables.Models
{
    public class BusinessUnit
    {
        [Key]
        public int BusinessUnitId { get; set; }
        public string BuName { get; set; }
        public string newBuName { get; set; }
        //public ICollection<ArPoc> ArPocs { get; set; }

    }
}
