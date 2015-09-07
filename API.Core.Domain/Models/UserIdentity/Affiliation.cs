namespace API.Core.Domain.Models.UserIdentity
{
    public class Affiliation
    {
        public int AffiliationId { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Website { get; set; }
    }
}
