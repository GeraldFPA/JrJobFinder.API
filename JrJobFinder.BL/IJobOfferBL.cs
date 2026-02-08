using JrJobFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JrJobFinder.BL
{
    public interface IJobOfferBL
    {
         Task<List<JobOffer>> GetAllJobOffers(
            string? technology,
            bool? isRemote,
            string? level,
            string? location,
            CancellationToken cancellationToken = default);
    }
}
