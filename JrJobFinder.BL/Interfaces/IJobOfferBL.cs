using JrJobFinder.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JrJobFinder.BL.Interfaces
{
    public interface IJobOfferBL
    {
         Task<IEnumerable<JobOffer>> GetAllJobOffers(
            string? technology,
            bool? isRemote,
            string? level,
            string? location,
            CancellationToken cancellationToken = default);
        Task<JobOffer> CreateJobOffer(JobOffer offer);

    }
}
