using System;

namespace Models
{
    public class CraftsMan
    {
        public DateTime DateOfEmployment { get; set; }
        public string SurName { get; set; }
        public string FieldOfWork { get; set; }
        public string FirstName { get; set; } 
        public Guid Id { get; set; }
    }
}
