using LiveView.Models.Network;
using System.Collections.Generic;
using System.IO;

namespace LiveView.Services
{
    public static class CsvReader
    {
        public static List<OuiRecord> GetRecords(string ouiContent)
        {
            var records = new List<OuiRecord>();
            using (var reader = new StringReader(ouiContent))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var columns = line.Split('|');
                    var record = new OuiRecord
                    {
                        Assignment = columns[0].Trim(),
                        OrganizationName = columns[1].Trim(),
                        OrganizationAddress = columns[2].Trim()
                    };
                    records.Add(record);
                }
            }
            return records;
        }
    }
}
