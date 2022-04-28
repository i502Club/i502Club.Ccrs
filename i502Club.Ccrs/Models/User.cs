namespace i502Club.Ccrs.Models
{
    /// <summary>
    /// User Class is not an actual model in the CCRS system but
    /// can be useful for hydrating submitted by, updated by, and 
    /// created by values.
    /// </summary>
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ExternalUserIdentifier { get; set; }
    }
}
