using Mtf.Extensions.Interfaces;
using System;

namespace Database.Models
{
    public class TemplateProcess : IHaveId<int>
    {
        public int Id { get; set; }

        public int TemplateId { get; set; }

        public int? AgentId { get; set; }

        public string ProcessName { get; set; }

        public string ProcessParameters { get; set; }

        public override string ToString()
        {
            return String.Concat(ProcessName, " ", ProcessParameters);
        }
    }
}
