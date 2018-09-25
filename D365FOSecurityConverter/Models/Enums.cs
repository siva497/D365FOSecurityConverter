namespace D365FOSecurityConverter.Models
{
    public enum AccessType
    {
        None,
        Read,
        Create,
        Update,
        Delete,
        Invoke
    }

    public enum AccessLevel
    {
        Unset,
        Allow,
        Deny
    }
}
