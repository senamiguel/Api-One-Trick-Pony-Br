using System.Text.Json.Serialization;

namespace Api_One_Trick_Pony_Br.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
