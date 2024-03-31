using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgency.Application.Authentication
{
    public class JwtSettings
    {
        public const string SECTION_NAME = "JwtSettings";
        
        public string Secret { get; init; } = null!;
        public string Issuer { get; init; } = null!;
        public int ExpiryMinutes { get; init; }
        public string Audience { get; init; } = null!;

    }
}