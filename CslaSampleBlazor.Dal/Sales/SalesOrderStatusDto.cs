using System;

namespace CslaSampleBlazor.Dal.Sales
{
    public class SalesOrderStatusDto 
    {
        public int SalesOrderStatusKey { get; set; }
        public string CreatedByUserId { get; set; }
        public int CreatedByUserKey { get; set; }
        public DateTime CreatedOnDate { get; set; }
        public byte[] LastChanged { get; set; }
        public string ModifiedByUserId { get; set; }
        public int ModifiedByUserKey { get; set; }
        public DateTime ModifiedOnDate { get; set; }
        public string Name { get; set; }
        public string SalesOrderStatusId { get; set; }
        public Int16 SalesOrderStatusValue { get; set; }
        
    }
}