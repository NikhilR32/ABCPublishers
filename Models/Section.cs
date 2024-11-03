namespace ABCPublishers.Models
{
    public class NavigationItem
    {
        public string Text { get; set; }
        public string Section { get; set; }
    }

    public class Section
    {
        public string Title { get; set; }
        public List<string> Content { get; set; } = new List<string>();
        public List<NavigationItem> Navigation { get; set; } = new List<NavigationItem>();
    }
}
