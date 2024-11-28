using System;

namespace LiveView.Models.Network
{
    public class OuiRecord
    {
        public string Assignment { get; set; }

        public string OrganizationName { get; set; }

        public string OrganizationAddress { get; set; }

        public override string ToString()
        {
            return OrganizationName;
        }

        public string ToStringWithDetails()
        {
            return String.Concat(OrganizationName, "\r", OrganizationAddress);
        }
    }

}
