using System;
using System.Collections.Generic;

namespace datafromexceltryingon3tables.Models;

public partial class Band
{
    public int BandId { get; set; }

    public string BandName { get; set; } = null!;

    public virtual ICollection<MasterTable> MasterTables { get; set; } = new List<MasterTable>();
}
