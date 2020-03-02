using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Tool
    {
        public DateTime Acquired { get; set; }
        public string Brand { get; set; }
        public Guid Id { get; set; }
        public string Model{ get; set; }
        public string SerialNumber { get; set; }
        public string Type { get; set; }
        public Guid ToolBoxId { get; set; }
        public ToolBox ToolBox { get; set; }
    }
}
