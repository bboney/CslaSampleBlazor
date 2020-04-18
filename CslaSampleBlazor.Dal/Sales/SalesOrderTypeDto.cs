using System;

namespace CslaSampleBlazor.Dal.Sales
{
    public class SalesOrderTypeDto 
    {
        public int SalesOrderTypeKey { get; set; }
        public string CreatedByUserId { get; set; }
        public int CreatedByUserKey { get; set; }
        public DateTime CreatedOnDate { get; set; }
        public byte[] LastChanged { get; set; }
        public string ModifiedByUserId { get; set; }
        public int ModifiedByUserKey { get; set; }
        public DateTime ModifiedOnDate { get; set; }
        public string Name { get; set; }
        public string SalesOrderTypeId { get; set; }
        public Int16 SalesOrderTypeValue { get; set; }
        
    }
}