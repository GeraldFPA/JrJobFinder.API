namespace JrJobFinder.BL
{
    using JrJobFinder.DA;
    public class JobOfferBL : IJobOfferBL
    {
        private AppDbContext DbContext;
        public JobOfferBL(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public IQueryable<Models.JobOffer> GetAllJobOffers()
        {
            return DbContext.JobOffers;
        }
    }
}
