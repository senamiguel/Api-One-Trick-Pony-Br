using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Api_One_Trick_Pony_Br.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public Comment(){ Date = DateTime.Now; }
    }
}
