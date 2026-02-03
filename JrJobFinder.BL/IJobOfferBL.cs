using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JrJobFinder.BL
{
    public interface IJobOfferBL
    {
        IQueryable<Models.JobOffer> GetAllJobOffers();
    }
}
