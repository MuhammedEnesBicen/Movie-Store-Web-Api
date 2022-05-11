using System;

namespace Movie_Store_Web_Api.TokenOpeartions.Models
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string RefreshToken { get; set; }
    }
}
