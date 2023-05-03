namespace datafromexceltryingon3tables.Models
{
    public class ArPOC
    {

        public int ArPOCId { get; set; }

        public string PocName { get; set; } = null!;

        public virtual ICollection<MasterTable> MasterTables { get; set; } = new List<MasterTable>();
    }
}
