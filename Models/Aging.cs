namespace datafromexceltryingon3tables.Models
{
    public class Aging
    {
        public int AgingId { get; set; }

        public string? _180Days { get; set; }

        public string? _120180Days { get; set; }

        public string? _90120Days { get; set; }

        public string? _6090Days { get; set; }

        public string? _3060Days { get; set; }

        public string? _030Days { get; set; }

        public string? NotDue { get; set; }

        public string? UnappliedReceiptsReconcialiationPending { get; set; }

        public string? GrandTotal { get; set; }

        public virtual ICollection<MasterTable> MasterTables { get; set; } = new List<MasterTable>();
    }
}
