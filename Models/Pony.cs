using System.Security.Principal;
using System.Text.Json.Serialization;

namespace Api_One_Trick_Pony_Br.Models
{
    public class Pony : Account
    {
        public string Name { get; set; }
        public int Karma { get; set; }
        public string Champion { get; set; }
        public int IconId { get; set; }
        public string Bio { get; set; }
        public string Rank { get; set; }
        [JsonIgnore]
        public List<SocialMedia> SocialMedias { get; set; }
        [JsonIgnore]
        public List<Account> Accounts { get; set; }
        [JsonIgnore]
        public List<Comment> Comments { get; set; }
    }
}
