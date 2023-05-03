
using excel = Microsoft.Office.Interop.Excel;

using datafromexceltryingon3tables.Models;
using datafromexceltryingon3tables.Repo;
using Microsoft.EntityFrameworkCore;


namespace datafromexceltryingon3tables
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Aging> Agings { get; set; }
        public DbSet<ArPOC> ArPocs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Band> Bands { get; set; }
        public DbSet<BusinessUnit> BusinessUnits { get; set; }
        public DbSet<CompanyCategory> companyCategories { get; set; }
        public DbSet<MasterTable> MasterTables { get; set; }


/*

        public static void SeedData(ApplicationDbContext _context)
        {
            string filePath = @"C:\Users\kalashri_patil\Downloads\creditControl.xlsx";
            excel.Application excel = new();
            excel.Workbook workbook = excel.Workbooks.Open(filePath);
            excel.Worksheet worksheet = (excel.Worksheet)workbook.Worksheets[1];

            // Get the used range of the worksheet
            excel.Range usedRange = worksheet.UsedRange;

            // Get the number of rows and columns in the worksheet
            int rowCount = usedRange.Rows.Count;
            int colCount = usedRange.Columns.Count;

            // Loop through the columns
            for (int row = 7; row <= rowCount; row++) // assuming the first row is a header row
            {
                // Map the data to the Table1Model
                var arPoc = new ArPOC
                {
                    PocName = ((excel.Range)worksheet.Cells[row, 1]).Value.ToString()
                    // Property2 = worksheet.Cells[row, table1Column2Index].Value.ToString(),
                    // ...
                };

                // Check if the data already exists in the database
                var existingTable1Model = _context.ArPocs.FirstOrDefault(t => t.PocName == arPoc.PocName);
                if (existingTable1Model != null)
                {
                    // Update the existing record in the database
                    existingTable1Model.PocName = arPoc.PocName;

                    // ...
                }
                else
                {
                    // Insert a new record into the Table1 table
                    _context.ArPocs.Add(arPoc);
                }
                _context.SaveChanges();

                // Close the workbook and release the resources
                workbook.Close();
                excel.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
            }
            /*
            using (var package = new ExcelPackage(new FileInfo(@"D:\Credit Control Tracker ExcelSheet.xlsb")))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                // Get the first worksheet in the Excel file
                var worksheet = package.Workbook.Worksheets.First();

                // Define the column indexes for each table
                int table1Column1Index = 1; // example column index
                int table1Column2Index = 2; // example column index
                int table2Column1Index = 3; // example column index
                int table2Column2Index = 4; // example column index

                // Iterate through the rows in the worksheet
                for (int row = 7; row <= worksheet.Dimension.End.Row; row++) // assuming the first row is a header row
                {
                    // Map the data to the Table1Model
                    var arpoc = new ArPOC
                    {
                        PocName = worksheet.Cells[row, 1].Value.ToString(),

                        // ...
                    };

                    // Check if the data already exists in the database
                    var existingTable1Model = context.ArPocs.FirstOrDefault(t => t.PocName == arpoc.PocName);
                    if (existingTable1Model != null)
                    {
                        // Update the existing record in the database
                        existingTable1Model.PocName = arpoc.PocName;

                    }
                    else
                    {
                        // Insert a new record into the Table1 table
                        context.ArPocs.Add(arpoc);
                    }

                    // Map the data to the Table2Model
                    var aging = new Aging
                    {
                        _180Days = worksheet.Cells[row, 15].Value.ToString(),
                        _120180Days = worksheet.Cells[row, 16].Value.ToString(),
                        // ...
                        _90120Days = worksheet.Cells[row, 17].Value.ToString(),

                        // Table1Model = table1Model // set the foreign key relationship to the Table1Model
                    };

                    // Check if the data already exists in the database
                    /*
                    var existingTable2Model = context.Agings.FirstOrDefault(t => t. == table2Model.Id);
                    if (existingTable2Model != null)
                    {
                        // Update the existing record in the database
                        existingTable2Model.Property1 = table2Model.Property1;
                        existingTable2Model.Property2 = table2Model.Property2;
                        // ...
                    }
                    else
                    {
                        // Insert a new record into the Table2 table
                        dbContext.Table2Models.Add(table2Model);
                    }
                    
                    context.Agings.Add(aging);

                    // Save changes to the database
                    context.SaveChanges();
                }
            }
        }

        }
  */  
    }
}
          








    
    
