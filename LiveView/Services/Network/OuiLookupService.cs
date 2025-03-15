using LiveView.Models.Network;
using Mtf.Database.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LiveView.Services.Network
{
    /// <summary>
    /// Organizationally Unique Identifier
    /// </summary>
    public partial class OuiLookupService
    {
        private readonly List<OuiRecord> ouiDatabase;

        public OuiLookupService()
        {
            var ouiContent = Mtf.Database.Services.ResourceHelper.ReadEmbeddedResource("LiveView.Resources.oui.csv", typeof(OuiLookupService).Assembly, Encoding.UTF8);
            ouiDatabase = CsvReader.GetRecords(ouiContent);
        }

        public string Lookup(string macAddress)
        {
            if (String.IsNullOrEmpty(macAddress))
            {
                return String.Empty;
            }
            var entries = GetLookupRecords(ref macAddress);
            return entries.Any() ? String.Join(Environment.NewLine, entries) : "Unknown Manufacturer";
        }

        private IEnumerable<OuiRecord> GetLookupRecords(ref string macAddress)
        {
            macAddress = GetNoMacAddressChars().Replace(macAddress, String.Empty);
            var macPrefix = macAddress.Substring(0, 6).ToUpper();
            var entries = ouiDatabase.Where(e => String.Equals(e.Assignment, macPrefix, StringComparison.InvariantCultureIgnoreCase));
            return entries;
        }

        public string LookupWithDetails(string macAddress)
        {
            var entries = GetLookupRecords(ref macAddress);
            return entries.Any() ? String.Join(String.Concat(Environment.NewLine, Environment.NewLine), entries.Select(e => e.ToStringWithDetails())) : "Unknown Manufacturer";
        }

        private static Regex GetNoMacAddressChars()
        {
            return new Regex("[^0-9a-zA-Z]");
        }
    }

}
