using System.Collections.Generic;

namespace D365FOSecurityConverter.Models
{
    public class AxSecurityDataEntityReference
    {
        public string Name { get; set; }
        public Grant Grants { get; set; }

        public class Grant
        {
            AccessLevel Read { get; set; }
            AccessLevel Create { get; set; }
            AccessLevel Update { get; set; }
            AccessLevel Delete { get; set; }
            AccessLevel Invoke { get; set; }
        }
    }

}
