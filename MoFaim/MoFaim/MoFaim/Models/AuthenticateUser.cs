using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoFaim.Models
{
    class AuthenticateUser
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "email")]
        private string Email { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "role")]
        public string Role { get; set; }

        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
    }
}
