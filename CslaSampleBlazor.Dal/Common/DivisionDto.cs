
using System;

namespace CslaSampleBlazor.Dal.Common
{
    /// <summary>
    /// This class is used as a Data Transformation Object 
    /// between a Data Access Layer implementation and a
    /// Business Object
    /// </summary>
    /// 
    public class DivisionDto
    {
        public int DivisionKey { get; set; }
        public int CreatedByUserKey { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime CreatedOnDate { get; set; }
        public string DivisionId { get; set; }
        public int DivisionValue { get; set; }
        public byte[] LastChanged { get; set; }
        public int ModifiedByUserKey { get; set; }
        public string ModifiedByUserId { get; set; }
        public DateTime ModifiedOnDate { get; set; }
        public string Name { get; set; }
    }
}
