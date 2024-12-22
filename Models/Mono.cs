using System.Security.Principal;

namespace Api_One_Trick_Pony_Br.Models
{
    public class Mono : Account
    {
        public string Name { get; set; }
        public int Karma { get; set; }
        public string Champion { get; set; }
        public int IconId { get; set; }
        public string Bio { get; set; }
        public string Rank { get; set; }
        public List<SocialMedia> SocialMedias { get; set; }
        public List<Account> Accounts { get; set; }
        public List<Comment> Comments { get; set; }
        public Mono()
        {
            SocialMedias = new List<SocialMedia>();
            Accounts = new List<Account>();
            Comments = new List<Comment>();
        }
    }
}
