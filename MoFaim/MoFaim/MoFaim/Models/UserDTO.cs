using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoFaim.Models
{
    public class UserDTO
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "FirstName")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "LastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "Email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "Password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "RoleId")]
        public int RoleId { get; set; }

        [JsonProperty(PropertyName = "Role")]
        public string Role { get; set; }

        public string FullName { get; set; }

        public UserDTO() {
            FullName = this.FirstName + " " + this.LastName;
        }

        public UserDTO(string Email,string Password)
        {
            this.Email = Email;
            this.Password = Password;
        }

        public UserDTO(string FirstName,string LastName,string Email,string Password)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Password = Password;
        }
    }
}
