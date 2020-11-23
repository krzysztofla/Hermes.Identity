using System;

namespace Hermes.Identity.Dto
{
    public class AuthDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string Role { get; set; }
        public DateTime Expires { get; set; }
    }
}
