using System.Xml.Serialization;

namespace D365FOSecurityConverter.Models
{
    public class AxSecurityRole
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Label { get; set; }

        [XmlArray("DirectAccessPermissions"), XmlArrayItem("AxSecurityDataEntityReference")]
        public AxSecurityDataEntityReference[] SecurityDataEntityReference { get; set; }
        [XmlArray("Duties"), XmlArrayItem("AxSecurityDutyReference")]
        public AxSecurityDutyReference[] RoleDuties { get; set; }
        [XmlArray("Privileges"), XmlArrayItem("AxSecurityPrivilegeReference")]
        public AxSecurityPrivilegeReference[] RolePrivileges { get; set; }
    }
}
