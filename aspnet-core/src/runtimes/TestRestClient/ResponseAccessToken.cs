using System;
using System.Collections.Generic;
using System.Text;

namespace TestRestClient
{
    class ResponseAccessToken
    {
        public string accessToken { get; set; }
        public string encryptedAccessToken { get; set; }
        public int expireInSeconds { get; set; }
        public int userId { get; set; }
    }
}
