using Mtf.Database;
using Mtf.MessageBoxes;
using System;
using System.Globalization;

namespace LiveView.Services
{
    public static class DatabaseStatistics
    {
        public static int GetDatabaseUsagePercentageWithLimit()
        {
            try
            {
                var engineEdition = Convert.ToInt32(BaseRepository.ExecuteScalarQuery("SELECT SERVERPROPERTY('EngineEdition')"));
                var maxSizeInBytes = engineEdition == 4 ? 10L * 1024 * 1024 * 1024 : Int64.MaxValue;

                var result = BaseRepository.ExecuteQuery("EXEC sp_spaceused");
                var firstRow = result.Rows[0];
                var databaseSize = ParseSize(firstRow["database_size"].ToString());
                var unallocatedSpace = ParseSize(firstRow["unallocated space"].ToString());

                if (databaseSize > 0)
                {
                    var usedSpace = databaseSize - unallocatedSpace;
                    var usagePercentage = (int)Math.Round(usedSpace / maxSizeInBytes * 100);
                    return usagePercentage;
                }
            }
            catch (Exception ex)
            {
                ErrorBox.Show(ex);
            }

            return -1;
        }

        private static double ParseSize(string size)
        {
            if (String.IsNullOrWhiteSpace(size))
            {
                return 0;
            }

            var sizeValue = Double.Parse(size.Substring(0, size.Length - 3), CultureInfo.InvariantCulture);
            var sizeUnit = size.Substring(size.Length - 2);

            switch (sizeUnit)
            {
                case "KB":
                    return sizeValue * 1024;
                case "MB":
                    return sizeValue * 1024 * 1024;
                case "GB":
                    return sizeValue * 1024 * 1024 * 1024;
                default:
                    return sizeValue;
            }
        }
    }
}
