namespace API.Core.Domain.Models.UserIdentity
{
    public class UserAgentDetails
    {
        public string IP { get; set; }
        public string Hostname { get; set; }
        public string BrowserBrand { get; set; }
        public string BrowserVersion { get; set; }
    }
}
