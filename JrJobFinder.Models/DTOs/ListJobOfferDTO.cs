using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JrJobFinder.Models.DTOs
{
    public class ListJobOfferDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Company { get; set; } = null!;
        public string Technologies { get; set; } = null!;
        public string ExperienceLevel { get; set; } = null!;
        public string Location { get; set; } = null!;
        public bool IsRemote { get; set; }
        public string Source { get; set; } = null!;
        public DateTime PostedDate { get; set; }
    }
}
