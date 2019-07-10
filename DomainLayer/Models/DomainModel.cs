using System;

namespace DomainLayer
{
    public class DomainModel
    {
        public Guid CompanyId { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
