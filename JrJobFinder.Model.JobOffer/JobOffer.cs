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
        public string experienceLevel { get; set; }
        public string technologies { get; set; }
        public string source { get; set; }
        public string sourceUrl { get; set; }
    }
}
