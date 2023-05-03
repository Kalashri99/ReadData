using System.ComponentModel.DataAnnotations;

namespace datafromexceltryingon3tables.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        //public ArPoc ArPoc { get; set; }
    }
}
