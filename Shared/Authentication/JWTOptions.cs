﻿namespace Shared.Authentication
{
    public class JWTOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }
        public double DurationInDays { get; set; }
    }
}
