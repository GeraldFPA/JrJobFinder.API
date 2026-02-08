namespace JrJobFinder.Models
{
    public class JobOffer
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public DateTime PostedDate { get; set; }
        public bool IsRemote { get; set; }
        public string ExperienceLevel { get; set; }
        public string Technologies { get; set; }
        public string Source { get; set; }
        public string SourceUrl { get; set; }
    }
}
