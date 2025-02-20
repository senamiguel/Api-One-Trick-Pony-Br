using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using System.Text.Json.Serialization;

namespace Api_One_Trick_Pony_Br.Models
{
    public class Pony
    {
        public int Id { get; set; }
        public string Bio { get; set; }
        public int IconId { get; set; }
        public int Karma { get; set; }
        public string Champion { get; set; }
        public string Rank { get; set; }
        public List<SocialMedia> SocialMedias { get; set; }
        public List<Comment> Comments { get; set; }
        public Account Account { get; set; }
    }
}
