using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ToolBox
    {
        public DateTime Acquired { get; set; }       
        public string Brand { get; set; }
        public string Color { get; set; }
        public Guid Id { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; } 
        public Guid OwnerId { get; set; }
        public CraftsMan Owner { get; set; }
    }
}
