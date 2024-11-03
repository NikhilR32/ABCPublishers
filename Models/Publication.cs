namespace ABCPublishers.Models
{
    public class Publication
    {
        public Dictionary<string, Section> Sections { get; set; } = new Dictionary<string, Section>();
    }
}
