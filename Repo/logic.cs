using excel = Microsoft.Office.Interop.Excel;

using datafromexceltryingon3tables.Models;
using Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;
using DataTable = System.Data.DataTable;
using System.Data;

namespace datafromexceltryingon3tables.Repo
{
    public class logic
    {
        ApplicationDbContext _context;

        public logic(ApplicationDbContext context)
        {
            this._context = context;
        }

        public string SeedData()
        {
            /*
            string filePath = @"C:\Users\kalashri_patil\Downloads\creditControl.xlsx";
       
            Application excel = new Application();
            Workbook workbook = excel.Workbooks.Open(filePath);
            Worksheet worksheet = workbook.ActiveSheet;

            // Get the used range of the worksheet
            Range usedRange = worksheet.UsedRange;

            // Get the number of rows and columns in the worksheet
            int rowCount = usedRange.Rows.Count;
            int colCount = usedRange.Columns.Count;

   

            // Loop through the rows
            for (int row = 7; row <= rowCount; row++)
            {
                
                    // Get the cell value
                    var cellValue = ((Range)worksheet.Cells[row, 1]).Value;
                    if (cellValue != null)
                        cellValue = cellValue.ToString();
                    else
                        cellValue = " ";

                    // Map the data to the ArPOC model
                    var arPoc = new ArPOC
                    {
                        PocName = cellValue
                        // add other properties here...
                    };

                    // Check if the data already exists in the database
                    var existingArPoc = _context.ArPocs.FirstOrDefault(t => t.PocName == arPoc.PocName);
                    if (existingArPoc != null)
                    {
                        // Update the existing record in the database
                        existingArPoc.PocName = arPoc.PocName;
                        // update other properties here...
                    }
                    else
                    {
                        // Insert a new record into the ArPOC table
                        _context.ArPocs.Add(arPoc);
                    }
                
                _context.SaveChanges();
            }


            // Save changes to the database


            // Close the workbook and release the resources
            workbook.Close();
            excel.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
            */

            string filePath = @"D:\creditControl.xlsx";
            Application excel = new Application();
            Workbook workbook = excel.Workbooks.Open(filePath);
            Worksheet worksheet = workbook.ActiveSheet;

            // Get the used range of the worksheet
            Range usedRange = worksheet.UsedRange;

            // Get the number of rows and columns in the worksheet
            int rowCount = usedRange.Rows.Count;
            int colCount = usedRange.Columns.Count;
            var dataTable = new DataTable();
            for (int col = 1; col <= colCount; col++)
            {
                string columnName = ((Range)worksheet.Cells[6, col]).Value.ToString();
                dataTable.Columns.Add(columnName);
            }

            // Loop through the rows
            for (int row = 7; row <= 124; row++) // assuming the first row is a header row
            {
                // Create a new DataRow
                DataRow dataRow = dataTable.NewRow();

                // Loop through the columns
                for (int col = 1; col <= colCount; col++)
                {
                    // Get the value in the current cell
                    var value = ((Range)usedRange.Cells[row, col]).Value;

                    // Set the value in the corresponding column of the DataRow
                    dataRow[col - 1] = value;
                }

                // Add the DataRow to the DataTable
                dataTable.Rows.Add(dataRow);
            }

            // Close the workbook and release the resources

            workbook.Close();
            excel.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);

            foreach (DataRow row in dataTable.Rows)
            {
                string pocName=row[1].ToString();
                int arPocId=AddArPoc(pocName);
                int agingId = AddAging(row[15].ToString(), row[16].ToString(), row[17].ToString(), row[18].ToString(), row[19].ToString()
                    , row[20].ToString(), row[21].ToString(), row[22].ToString(), row[23].ToString());
                int clientId=AddClient(row[3].ToString());
                int BussinessUnitId = AddBussinessUnit(row[7].ToString(), row[4].ToString());
                int CompanyCategoryId = AddCompanyCategory(row[10].ToString());
                int BandId = AddBandId(row[8].ToString());


                /*
                var arPoc = new ArPOC
                {
                    PocName = pocName
                    // add other properties here...
                };

                // Check if the data already exists in the database
                var existingArPoc = _context.ArPocs.FirstOrDefault(t => t.PocName == arPoc.PocName);
                if (existingArPoc == null)
                {

                    // Insert a new record into the ArPOC table
                    _context.ArPocs.Add(arPoc);
                    _context.SaveChanges();
                    arPocId = arPoc.ArPOCId;
                    

                }
                else
                    arPocId = existingArPoc.ArPOCId;
                

                var aging = new Aging {
                    _180Days = row[15].ToString(),
                    _120180Days = row[16].ToString(),
                   _90120Days = row[17].ToString(),
                    _6090Days = row[18].ToString(),
                    _3060Days = row[19].ToString(),
                    _030Days = row[20].ToString(),
                    NotDue = row[21].ToString(),
                    UnappliedReceiptsReconcialiationPending = row[22].ToString(),
                    GrandTotal = row[23].ToString(),


                };
                _context.Agings.Add(aging);
                _context.SaveChanges();
                */
                var existingMaster = _context.MasterTables.FirstOrDefault(m=>m.InvoiceId==row[0].ToString());
                if (existingMaster == null)
                {
                    var mastertable = new MasterTable
                    {
                        InvoiceId = row[0].ToString(),
                        ArPOCId = arPocId,
                        AgingId = agingId,
                        BusinessUnitId=BussinessUnitId,
                        CompanyCategoryId=CompanyCategoryId,
                        ClientId=clientId,
                        BandId=BandId,
                       
                        
                       
                    };
                    _context.MasterTables.Add(mastertable);
                }
                else
                {
                    existingMaster.ArPOCId=arPocId;
                    existingMaster.AgingId=agingId;
                    existingMaster.BusinessUnitId = BussinessUnitId;
                    existingMaster.CompanyCategoryId = CompanyCategoryId;
                    existingMaster.ClientId = clientId; 
                    existingMaster.BandId = BandId;

                    _context.MasterTables.Update(existingMaster);
                  

                }
                
                _context.SaveChanges();

            }

            return "Data added successfully.";

        }

        public int AddArPoc(string Name)
        {
            int arPocId;
          

            // Check if the data already exists in the database
            var existingArPoc = _context.ArPocs.FirstOrDefault(t => t.PocName == Name);
            if (existingArPoc == null)
            {
                var arPoc = new ArPOC
                {
                    PocName = Name
                    // add other properties here...
                };
                // Insert a new record into the ArPOC table
                _context.ArPocs.Add(arPoc);
                _context.SaveChanges();
                arPocId = arPoc.ArPOCId;


            }
            else
                arPocId = existingArPoc.ArPOCId;

            return arPocId;
        }

        public int AddAging(string days180,string days120to180,string days90to120,string days60to90,string days30to60,string days0to30,string NoDue,
            string unApplied,string GrandTotal)
        {
            var aging = new Aging
            {
                _180Days = days180,
                _120180Days = days120to180,
                _90120Days = days90to120,
                _6090Days = days60to90,
                _3060Days = days30to60,
                _030Days = days0to30,
                NotDue = NoDue,
                UnappliedReceiptsReconcialiationPending = unApplied,
                GrandTotal = GrandTotal,


            };
            _context.Agings.Add(aging);
            _context.SaveChanges();
            return aging.AgingId;
        }

        public int AddBussinessUnit(string BUname,string NewBuName)
        {
            int BussinessUnitId;


            // Check if the data already exists in the database
            var existingBU = _context.BusinessUnits.FirstOrDefault(t => t.BuName == BUname);
            if (existingBU == null)
            {
                var bussinessUnit = new BusinessUnit
                {
                    BuName = BUname,
                    newBuName = NewBuName
                    // add other properties here...
                };
                // Insert a new record into the ArPOC table
                _context.BusinessUnits.Add(bussinessUnit);
                _context.SaveChanges();
                BussinessUnitId = bussinessUnit.BusinessUnitId;


            }
            else
                BussinessUnitId = existingBU.BusinessUnitId;

            return BussinessUnitId;

        }


        public int AddClient(string clientName)
        {
            int ClientId;


            // Check if the data already exists in the database
            var existingClient = _context.Clients.FirstOrDefault(t => t.ClientName == clientName);
            if (existingClient == null)
            {
                var client = new Client
                {
                    ClientName = clientName
                };
                // Insert a new record into the ArPOC table
                _context.Clients.Add(client);
                _context.SaveChanges();
                ClientId =client.ClientId;


            }
            else
                ClientId = existingClient.ClientId;

            return  ClientId;

        }

        public int AddCompanyCategory(string companyCategoryName)
        {
            int CCId;


            // Check if the data already exists in the database
            var existingCC = _context.companyCategories.FirstOrDefault(t => t.CompanyCategoryName == companyCategoryName);
            if (existingCC == null)
            {
                var companyCategory = new CompanyCategory
                {
                   CompanyCategoryName = companyCategoryName
                };
                // Insert a new record into the ArPOC table
                _context.companyCategories.Add(companyCategory);
                _context.SaveChanges();
                CCId = companyCategory.CompanyCategoryId;


            }
            else
                CCId=existingCC.CompanyCategoryId;

            return CCId;

        }

        public int AddBandId(string Bandname)
        {
            int BandId;


            // Check if the data already exists in the database
            var existingBand = _context.Bands.FirstOrDefault(t => t.BandName == Bandname);
            if (existingBand == null)
            {
                var band = new Band
                {
                    BandName = Bandname
                };
                // Insert a new record into the ArPOC table
                _context.Bands.Add(band);
                _context.SaveChanges();
                BandId = band.BandId;


            }
            else
               BandId=existingBand.BandId;

            return BandId;

        }




    }
}
