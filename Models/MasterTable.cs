using System.ComponentModel.DataAnnotations;

namespace datafromexceltryingon3tables.Models
{
    public class MasterTable
    {
        [Key]
        public string InvoiceId{ get; set; }
        /*
        [Required]
        [Unique]
        public string InviceId { get; set; }
        */
        public int AgingId { get; set; }

        public int ArPOCId { get; set; }
        public int BusinessUnitId { get; set; }
        public int ClientId { get; set; }
        public int CompanyCategoryId { get; set; }
        public int BandId { get; set; }

        public ArPOC ArPoc { get; set; }
        public Aging aging { get; set; }  
        public BusinessUnit businessUnit { get; set; }  
        public Client client { get; set; }  
        public CompanyCategory companyCategory { get; set; }  
        public Band band { get; set; }  
        
    }
}
