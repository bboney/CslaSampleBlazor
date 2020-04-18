using System;

namespace CslaSampleBlazor.Dal.Security
{
    public class NavigationDto
    {
        public int NavigationKey { get; set; }
        public string CreatedByUserId { get; set; }
        public int CreatedByUserKey { get; set; }
        public DateTime CreatedOnDate { get; set; }
        public bool HasChildren { get; set; }
        public bool IsPrivilegeRequired { get; set; }
        public byte[] LastChanged { get; set; }
        public string ModifiedByUserId { get; set; }
        public int ModifiedByUserKey { get; set; }
        public DateTime ModifiedOnDate { get; set; }
        public string Name { get; set; }
        public string NavigationId { get; set; }
        public int NavigationType { get; set; }
        public int? ParentNavigationKey { get; set; }
        public int Sequence { get; set; }
        public string SpriteCssClass { get; set; }
        public string Url { get; set; }
    }
}