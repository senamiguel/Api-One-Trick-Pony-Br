namespace Api_One_Trick_Pony_Br.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public Account? Author { get; set; }
        public string? Message { get; set; }
        public DateTime Date { get; set; }

    }
}
