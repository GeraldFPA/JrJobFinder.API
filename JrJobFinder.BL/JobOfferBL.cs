namespace JrJobFinder.BL
{
    using JrJobFinder.DA;
    using Microsoft.EntityFrameworkCore;
    using JrJobFinder.Models;

    public class JobOfferBL : IJobOfferBL
    {
        private AppDbContext DbContext;
        public JobOfferBL(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public async Task<List<JobOffer>> GetAllJobOffers(
            string? technology,
            bool? isRemote,
            string? level, 
            string? location, 
            CancellationToken cancellationToken= default)
        {
            IQueryable<JobOffer> query = DbContext.JobOffers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(technology))
            {
                query = query.Where(j =>
                    EF.Functions.Like(j.Technologies,$"%{technology }%"));
            }

            if (isRemote.HasValue)
            {
                query = query.Where(j => j.IsRemote == isRemote.Value);
            }

            if (!string.IsNullOrWhiteSpace(level))
            {
                query = query.Where(j =>
                    j.ExperienceLevel == level);
            }

            if (!string.IsNullOrWhiteSpace(location))
            {
                query = query.Where(j =>
                    EF.Functions.Like(j.Location,$"%{location}%"));
            }
            return await query.AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
