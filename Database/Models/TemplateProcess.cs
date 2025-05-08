using Mtf.Database.Interfaces;
using System;

namespace Database.Models
{
    public class TemplateProcess : IHaveId<long>
    {
        public long Id { get; set; }

        public long TemplateId { get; set; }

        public string ProcessName { get; set; }

        public string ProcessParameters { get; set; }

        public override string ToString()
        {
            return String.Concat(ProcessName, ProcessParameters);
        }
    }
}
